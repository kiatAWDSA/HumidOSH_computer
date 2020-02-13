using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;

namespace HumidOSH
{
  public partial class HumidOSH : Form
  {
    // Communication
    private SerialPort port_;
    private bool connected_                   = false;
    private string selectedCOMPort_;
    private static int serialBaudRate_        = 9600;
    private static Parity serialParity_       = Parity.None;
    private static int serialDataBits_        = 8;
    private static StopBits serialStopBits_   = StopBits.One;
    private static Handshake serialHandshake_ = Handshake.None;
    private static Encoding serialEncoding_   = Encoding.ASCII;
    private int serialReadTimeout_            = 2000; // 2000 ms before timeout.
    private SerialDataReceivedEventHandler serialDataReceivedHandler_;

    // Status of app
    private bool DAQActive_     = false;
    private bool recordActive_  = false;

    // Readings
    private double humidity_;
    private double temperature_;
    private double fanSpeed_;
    private double humidityTarget_;
    private double fanSpeedTarget_;
    private bool humidityOK_;
    private bool temperatureOK_;
    private bool fanSpeedOK_;
    private bool humidityControlActive_ = false;
    private bool fanSpeedControlActive_ = false;

    // Recording
    private string savePathway_;
    private FileStream recordStream_;
    private StreamWriter CSVWriter_;
    DateTime recordingStartTime_;

    // Codes sent during communication with Arduino
    public const string SERIAL_CMD_START      = "^";
    public const string SERIAL_CMD_DAQ_START  = "d";
    public const string SERIAL_CMD_DAQ_STOP   = "s";
    public const string SERIAL_CMD_END        = "@";
    public const string SERIAL_CMD_EOL        = "\n";

    // Codes received during communication with Arduino
    public const string SERIAL_REPLY_START                = "^";
    public const string SERIAL_SEND_DATA                  = "d";
    public const string SERIAL_SEND_DATA_ERROR            = "e";
    public const string SERIAL_SEND_DATA_CONTROLINACTIVE  = "i";
    public const string SERIAL_REPLY_CMDRESPONSE          = "r";  // Used to indicate execution status of a received command
      public const string SERIAL_REPLY_CMDRESPONSE_SUCC     = "y";  // Success
      public const string SERIAL_REPLY_CMDRESPONSE_FAIL     = "n";  // Failed
    public const char SERIAL_REPLY_SEPARATOR              = '|';
    public const string SERIAL_REPLY_END                  = "@";
    public const string SERIAL_REPLY_EOL                  = "\n";

    public HumidOSH()
    {
      InitializeComponent();

      // Refresh the list of available COM ports that will be displayed when opening the combobox for port.
      string[] portList = SerialPort.GetPortNames();
      Flow_port_comboBox.Items.Clear();
      Flow_port_comboBox.Items.AddRange(portList);
      Flow_port_comboBox.Items.Insert(0, "None");
      Flow_port_comboBox.SelectedValueChanged += portValueChanged_;

      



    }


    // Extract reply fragments from messages sent from the HumidOSH microcontroller
    private bool sendCommand(string command, bool clearFirst)
    {
      // Add the start and end flags
      string fullCommand = string.Format("{0}{1}{2}{3}",
                                          SERIAL_CMD_START,
                                          command,
                                          SERIAL_CMD_END,
                                          SERIAL_CMD_EOL);

      try
      {// Send the command
       // System.Diagnostics.Debug.WriteLine("Sending command: " + outgoingCommand.fullCommand);
        port_.Write(fullCommand);

        // Most of the times, the first communication attempt fails for unknown reason. Multiple reattempts will fix it.
        if (clearFirst)
        {
          port_.DiscardInBuffer();
          port_.DiscardOutBuffer();
          port_.Write(fullCommand);
        }

        // Since we set ReadTimeout to a finite number, ReadTo will return a TimeoutException if no response is received within
        // that time limit. This is done on purpose because the thread would be blocked forever by ReadLine if ReadTimeout is not a
        // finite number. If no response is received after the timeout or the response is an invalid format, then we assume
        // that this port is not occupied by the Arduino controlling a sandwich.
        string readBuffer = port_.ReadTo(SERIAL_REPLY_EOL);

        // Check if the start and end of the response have the correct flags
        if (readBuffer.Substring(0, 1) == SERIAL_REPLY_START && readBuffer.Substring(readBuffer.Length - 1, 1) == SERIAL_REPLY_END)
        {
          // Now extract the sandwich ID that was sent out by this Arduino
          int startPos = readBuffer.IndexOf(SERIAL_REPLY_START);
          int endPos = readBuffer.LastIndexOf(SERIAL_REPLY_END);

          // Get the parameters
          string[] replyFragments = extractReplyFragments(readBuffer, startPos, endPos);

          if (replyFragments.Length == 3 && replyFragments[0] == SERIAL_REPLY_CMDRESPONSE && replyFragments[2] == SERIAL_REPLY_CMDRESPONSE_SUCC)
          {// Sanity check; should have three fragments. one for SERIAL_REPLY_CMDRESPONSE, one for the received command, one for command status
            return true;
          }
          else
          {// Somehow, number of parameters is wrong.
           // Clear all serial port buffers and close the port.
            port_.DiscardInBuffer();
            port_.DiscardOutBuffer();
            port_.Close();

            MessageBox.Show("Failed to execute command. Invalid response received from microcontroller. Response received: \n\n" + readBuffer, "Error");
            return false;
          }
        }
        else
        {
          MessageBox.Show("Failed to execute command. Corrupted response received from microcontroller. Response received: \n\n" + readBuffer, "Error");
          return false;
        }
      }
      catch (Exception err)
      {
        // Clear all serial port buffers and close the port.
        port_.DiscardInBuffer();
        port_.DiscardOutBuffer();
        port_.Close();

        MessageBox.Show("Failed to execute command. Error message:\n\n" + err.Message, "Error");
        return false;
      }
    }

    // Event handler for when the selected communication port is changed.
    private void portValueChanged_(object sender, EventArgs e)
    {
      selectedCOMPort_ = Flow_port_comboBox.SelectedItem.ToString();
    }


    /********************************************************
     * 
     * Start DAQ
     * 
     ********************************************************/
    private void Flow_DAQ_flow_startDAQ_Click(object sender, EventArgs e)
    {
      // Prevent further alterations of controls.
      Flow_DAQ_flow_startDAQ.Enabled = false;
      Flow_port_comboBox.Enabled = false;
      DAQActive_ = false;

      // Prepare the communications port.
      port_ = new SerialPort(selectedCOMPort_, serialBaudRate_, serialParity_, serialDataBits_, serialStopBits_);
      port_.Handshake = serialHandshake_;
      port_.Encoding = serialEncoding_;
      port_.ReadTimeout = serialReadTimeout_; // 2000 ms before timeout.

      // Open the communications port.
      try
      {
        port_.Open();
        port_.DiscardInBuffer();
        port_.DiscardOutBuffer();
        connected_ = true;
      }
      catch (Exception err)
      {
        connected_ = false;
        MessageBox.Show("Failed to start communications with the given port. Error message:\n\n" + err.Message, "Error");
      }

      // Communications has begun. Send command to begin DAQ.
      if (connected_)
      {
        if (sendCommand(SERIAL_CMD_DAQ_START, true))
        {
          // DAQ successfully initiated. Apply changes to controls.
          Flow_DAQ_flow_startDAQ.Visible = false;
          Flow_DAQ_flow_stopDAQ.Enabled = true;
          Flow_DAQ_flow_stopDAQ.Visible = true;
          Flow_record_flow_startRecord.Enabled = true;
          DAQActive_ = true;

          // Handle all incoming messages.
          serialDataReceivedHandler_ = new SerialDataReceivedEventHandler(handleSerialDataReceived);
          port_.DataReceived += serialDataReceivedHandler_;
        }
        else
        {
          // Failed to start DAQ.
          connected_ = false;
          Flow_DAQ_flow_startDAQ.Enabled = true;
          Flow_port_comboBox.Enabled = true;
        }
      }
      else
      {
        Flow_DAQ_flow_startDAQ.Enabled = true;
        Flow_port_comboBox.Enabled = true;
      }
    }


    /********************************************************
     * 
     * Stop DAQ
     * 
     ********************************************************/
    private void Flow_DAQ_flow_stopDAQ_Click(object sender, EventArgs e)
    {
      // Prevent further alterations of controls.
      Flow_DAQ_flow_stopDAQ.Enabled = false;
      if (recordActive_)
      {
        Flow_record_flow_stopRecord.Enabled = false;
      }
      else
      {
        Flow_record_flow_startRecord.Enabled = false;
      }

      // Stop handling all incoming messages.
      port_.DataReceived -= serialDataReceivedHandler_;

      if (sendCommand(SERIAL_CMD_DAQ_STOP, false))
      {
        // DAQ successfully stopped. Apply changes to controls.
        Flow_DAQ_flow_stopDAQ.Visible = false;
        Flow_DAQ_flow_startDAQ.Enabled = true;
        Flow_DAQ_flow_startDAQ.Visible = true;
        Flow_port_comboBox.Enabled = true;

        if (recordActive_)
        {// Stop recording, if it is active
          Flow_record_flow_stopRecord_Click(this, new EventArgs());
          Flow_record_flow_startRecord.Enabled = false;
        }

        try
        {
          // Clear all serial port buffers and close the port.
          port_.DiscardInBuffer();
          port_.DiscardOutBuffer();
          port_.Close();
        }
        catch (Exception err)
        {
          MessageBox.Show("Encountered an error when closing communications port. Error message:\n\n" + err.Message, "Error");
        }
        connected_ = false;
        DAQActive_ = false;
      }
      else
      {
        // Failed to stop DAQ.
        Flow_DAQ_flow_stopDAQ.Enabled = true;
        if (recordActive_)
        {
          Flow_record_flow_stopRecord.Enabled = true;
        }
        else
        {
          Flow_record_flow_startRecord.Enabled = true;
        }

        // Resume handling messages as usual.
        serialDataReceivedHandler_ = new SerialDataReceivedEventHandler(handleSerialDataReceived);
        port_.DataReceived += serialDataReceivedHandler_;
      }
    }

    /********************************************************
     * 
     * Browse location to record data
     * 
     ********************************************************/
    private void Flow_record_flow_browse_Click(object sender, EventArgs e)
    {
      if (recordFileDialog.ShowDialog() == DialogResult.OK)
      {
        Flow_record_flow_filepath_textbox.Text = recordFileDialog.FileName;
        savePathway_ = Flow_record_flow_filepath_textbox.Text;
      }
    }

    /********************************************************
     * 
     * Start recording
     * 
     ********************************************************/
    private void Flow_record_flow_startRecord_Click(object sender, EventArgs e)
    {
      if (DAQActive_)
      {
        Flow_record_flow_startRecord.Enabled = false;
        Flow_record_flow_browse.Enabled = false;
        bool legitFilePath_ = false;
        bool fileExists = File.Exists(savePathway_);
        recordActive_ = false;

        try
        {
          recordStream_ = new FileStream(savePathway_, FileMode.Append, FileAccess.Write, FileShare.Read); // append or create new file; write-only; don't allow anyone else to modify this file.
          CSVWriter_ = new StreamWriter(recordStream_, Encoding.GetEncoding("ISO-8859-15")); // Needs this encoding, otherwise the degree symbol doesn't come out properly.
          CSVWriter_.AutoFlush = true;
          legitFilePath_ = true;
        }
        catch (Exception err)
        {
          // Failed to open the file
          Flow_record_flow_startRecord.Enabled = true;
          Flow_record_flow_browse.Enabled = true;
          MessageBox.Show("The program encountered an error when attempting to open the file to record data. Please check that the path exists or change the name of the file.", "Error recording data");
          MessageBox.Show(err.Message, "Error recording data");
          return;
        }

        if (legitFilePath_)
        {// File path is valid; begin recording
          try
          {
            // Check if the file is already created. Add the header at first line if it is a new file.
            if (!fileExists)
            {
              CSVWriter_.Write("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}",
                                new Object[] {  "Time",
                                                ",",
                                                "Relative humidity (%)",
                                                ",",
                                                "Temperature (°C)",
                                                ",",
                                                "Fan speed (RPM)",
                                                ",",
                                                "Relative humidity target (%)",
                                                ",",
                                                "Fan speed target (RPM)",
                                                Environment.NewLine });
            }

            // Set the flag
            recordActive_ = true;
          }
          catch (Exception err)
          {
            MessageBox.Show("The program encountered an error when attempting to write data into the file. Please check that the path exists or change the name of the file.", "Error recording data");
            MessageBox.Show(err.Message, "Error recording data");
          }

          if (recordActive_)
          {// We only reach here if everything worked properly
            Flow_record_flow_startRecord.Visible = false;
            Flow_record_flow_stopRecord.Enabled = true;
            Flow_record_flow_stopRecord.Visible = true;

            // Determine the starting time.
            recordingStartTime_ = DateTime.Now;
            RecordData(recordingStartTime_);
          }
          else
          {// Failed to write headers to the file when we were supposed to; revert state to before clicking start record
            Flow_record_flow_startRecord.Enabled = true;
            Flow_record_flow_browse.Enabled = true;
          }
        }
      }
    }

    /********************************************************
     * 
     * Stop recording
     * 
     ********************************************************/
    private void Flow_record_flow_stopRecord_Click(object sender, EventArgs e)
    {
      Flow_record_flow_stopRecord.Enabled = false;
      recordActive_ = false;

      try
      {
        CSVWriter_.Flush();
        CSVWriter_.Close();

        // Successful in stopping data recording. Modify the controls accordingly.
        Flow_record_flow_stopRecord.Visible = false;
        Flow_record_flow_startRecord.Enabled = true;
        Flow_record_flow_startRecord.Visible = true;
        Flow_record_flow_browse.Enabled = true;
      }
      catch (Exception err)
      {
        MessageBox.Show("Failed to stop recording data. Error message:\n\n" + err.Message, "Error stopping data recording");
        Flow_record_flow_stopRecord.Enabled = true;
      }
    }

    /********************************************************
     * 
     * Handle received serial messages
     * 
     ********************************************************/
    public void handleSerialDataReceived(object sender, SerialDataReceivedEventArgs e)
    {
      while (port_.BytesToRead > 0)
      {
        try
        {
          string readBuffer = port_.ReadTo(SERIAL_REPLY_EOL);

          // Check if the start and end of the response have the correct flags
          if (readBuffer.Substring(0, 1) == SERIAL_REPLY_START && readBuffer.Substring(readBuffer.Length - 1, 1) == SERIAL_REPLY_END)
          {
            int startPos = readBuffer.IndexOf(SERIAL_REPLY_START);
            int endPos = readBuffer.LastIndexOf(SERIAL_REPLY_END);

            // System.Diagnostics.Debug.WriteLine("Received reply: " + readBuffer);

            string[] bufferFragments = extractReplyFragments(readBuffer, startPos, endPos);

            // The first fragment is the command type
            switch (bufferFragments[0])
            {
              case SERIAL_SEND_DATA:
                {
                  /*********************************
                  *           READINGS             *
                  * *******************************/
                  /* Temperature reading of both heaters.
                  * Format:
                  * ^d|[RH]|[temp]|[fanSpeed]|[RHTarget]|[fanSpeedTarget]@
                  * where    ^                is SERIAL_REPLY_START
                  *          d                is SERIAL_SEND_DATA
                  *          |                is SERIAL_REPLY_SEPARATOR
                  *          [RH]             is the relative humidity reading (%)
                  *          [temp]           is the temperature reading (°C)
                  *          [fanSpeed]       is the fan speed (RPM)
                  *          [RHTarget]       is the relative humidity target (%)
                  *          [fanSpeedTarget] is the fan speed target (RPM)
                  *          @                is SERIAL_REPLY_END
                  */

                  // Sanity check for number of fragments
                  if (bufferFragments.Length == 6)
                  {
                    HandleNewReadings(bufferFragments[1],
                                      bufferFragments[2],
                                      bufferFragments[3],
                                      bufferFragments[4],
                                      bufferFragments[5]);
                  }
                  else
                  {// Somehow, number of parameters is wrong.
                    // Ignore the message.
                  }
                }
                break;
              default:
                // The message sent from Arduino doesn't comply with any of the defined formats, so assume it is corrupted.
                // Ignore the message.
                break;
            }
          }
          else
          {
            // The message sent from Arduino doesn't have the correct start and end flags, so assume it is corrupted.
            // Ignore the message.
          }
        }
        catch (Exception)
        {
          // Ignore the message.
        }
      }
    }


    /********************************************************
     * 
     * Handle new readings received
     * 
     ********************************************************/
    private void HandleNewReadings(string humidity, string temperature, string fanSpeed, string humidityTarget, string fanSpeedTarget)
    {
      string[] readingList = { humidity, temperature, fanSpeed };
      string[] targetList = { humidityTarget, fanSpeedTarget };
      TextBox[] readingTextBoxList = { Flow_DAQ_flow_RH_value, Flow_DAQ_flow_temperature_value, Flow_DAQ_flow_fanSpeed_value };
      TextBox[] targetTextBoxList = { Flow_DAQ_flow_RHTarget_value, Flow_DAQ_flow_fanSpeedTarget_value };

      // Begin converting the raw readings into numbers
      for (int i = 0; i < readingList.Length; i++)
      {
        bool conversionSuccess = false;

        if (readingList[i] != SERIAL_SEND_DATA_ERROR)
        {
          try
          {
            switch (i)
            {
              case 0:
                humidity_ = Convert.ToDouble(readingList[i]);
                humidityOK_ = true;
                break;
              case 1:
                temperature_ = Convert.ToDouble(readingList[i]);
                temperatureOK_ = true;
                break;
              case 2:
                fanSpeed_ = Convert.ToDouble(readingList[i]);
                fanSpeedOK_ = true;
                break;
              default:
                // Missed an index here...
                break;
            }

            conversionSuccess = true;
          }
          catch (Exception)
          {// There was an error while trying to convert the reading into Double format
            readingTextBoxList[i].Text = "Error";
          }

          if (conversionSuccess)
          {// Display the value only if it is actually a number
            readingTextBoxList[i].Text = readingList[i];
          }
        }
        else
        {// There was a problem attempting to acquire the reading.
          readingTextBoxList[i].Text = "Error";

          switch (i)
          {
            case 0:
              humidityOK_ = false;
              break;
            case 1:
              temperatureOK_ = false;
              break;
            case 2:
              fanSpeedOK_ = false;
              break;
            default:
              // Missed an index here...
              break;
          }
        }
      }

      // Begin converting the raw targets into numbers
      for (int i = 0; i < targetList.Length; i++)
      {
        bool conversionSuccess = false;

        if (targetList[i] != SERIAL_SEND_DATA_CONTROLINACTIVE)
        {
          try
          {
            switch (i)
            {
              case 0:
                humidityTarget_ = Convert.ToDouble(targetList[i]);
                humidityControlActive_ = true;
                break;
              case 1:
                fanSpeedTarget_ = Convert.ToDouble(targetList[i]);
                fanSpeedControlActive_ = true;
                break;
              default:
                // Missed an index here...
                break;
            }

            conversionSuccess = true;
          }
          catch (Exception)
          {// There was an error while trying to convert the reading into Double format
            targetTextBoxList[i].Text = "Error";
          }

          if (conversionSuccess)
          {// Display the value only if it is actually a number
            targetTextBoxList[i].Text = targetList[i];
          }
        }
        else
        {// Control for this process variable is not active.
          targetTextBoxList[i].Text = "Inactive";

          switch (i)
          {
            case 0:
              humidityControlActive_ = false;
              break;
            case 1:
              fanSpeedControlActive_ = false;
              break;
            default:
              // Missed an index here...
              break;
          }
        }
      }

      // Record the data if applicable
      if (recordActive_)
      {
        RecordData(DateTime.Now);
      }
    }


    /********************************************************
     * 
     * Handle new readings received
     * 
     ********************************************************/
    private void RecordData(DateTime currentTime)
    {
      try
      {
        // ulong milSecsElapsed = Convert.ToUInt64(currentTime.Subtract(recordingStartTime_).TotalMilliseconds);

        // If there was an error with the reading, write an empty entry
        string[] outputValues = new string[5];
        double[] readingValues = { humidity_, temperature_, fanSpeed_, humidityTarget_, fanSpeedTarget_ };
        bool[] readingStatus = { humidityOK_, temperatureOK_, fanSpeedOK_, humidityControlActive_, fanSpeedControlActive_ };
        for (int i = 0; i < outputValues.Length; i++)
        {
          if (readingStatus[i])
          {
            outputValues[i] = Convert.ToString(readingValues[i]);
          }
          else
          {
            outputValues[i] = "";
          }
        }
        
        CSVWriter_.Write("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}",
                          new Object[] {currentTime,
                                        ",",
                                        outputValues[0],  // Relative humidity (%)
                                        ",",
                                        outputValues[1],  // Temperature (°C)
                                        ",",
                                        outputValues[2],  // Fan speed (RPM)
                                        ",",
                                        outputValues[3],  // Relative humidity target (%)
                                        ",",
                                        outputValues[4],  // Fan speed target (RPM)
                                        Environment.NewLine });
      }
      catch (Exception)
      {
        // Do nothing.
      }
    }




    // Split the trimmed buffer based on a delimiter and return the splitted parts as an array.
    private static string[] extractReplyFragments(string rawBuffer, int startPos, int endPos)
    {
      // Trim the buffer to remove the start and end flags
      string trimmedBuffer = rawBuffer.Substring(startPos + 1, endPos - (startPos + 1));

      // Get the parameters
      return trimmedBuffer.Split(SERIAL_REPLY_SEPARATOR);
    }
  }
}
