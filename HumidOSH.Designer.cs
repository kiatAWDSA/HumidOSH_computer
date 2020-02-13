namespace HumidOSH
{
  partial class HumidOSH
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HumidOSH));
      this.Flow = new System.Windows.Forms.FlowLayoutPanel();
      this.Flow_port = new System.Windows.Forms.GroupBox();
      this.Flow_port_comboBox = new System.Windows.Forms.ComboBox();
      this.Flow_DAQ = new System.Windows.Forms.GroupBox();
      this.Flow_DAQ_flow = new System.Windows.Forms.FlowLayoutPanel();
      this.Flow_DAQ_flow_RH = new System.Windows.Forms.FlowLayoutPanel();
      this.Flow_DAQ_flow_RH_label = new System.Windows.Forms.Label();
      this.Flow_DAQ_flow_RH_value = new System.Windows.Forms.TextBox();
      this.Flow_DAQ_flow_temperature = new System.Windows.Forms.FlowLayoutPanel();
      this.Flow_DAQ_flow_temperature_label = new System.Windows.Forms.Label();
      this.Flow_DAQ_flow_temperature_value = new System.Windows.Forms.TextBox();
      this.Flow_DAQ_flow_fanSpeed = new System.Windows.Forms.FlowLayoutPanel();
      this.Flow_DAQ_flow_fanSpeed_label = new System.Windows.Forms.Label();
      this.Flow_DAQ_flow_fanSpeed_value = new System.Windows.Forms.TextBox();
      this.Flow_DAQ_flow_RHTarget = new System.Windows.Forms.FlowLayoutPanel();
      this.Flow_DAQ_flow_RHTarget_label = new System.Windows.Forms.Label();
      this.Flow_DAQ_flow_RHTarget_value = new System.Windows.Forms.TextBox();
      this.Flow_DAQ_flow_fanSpeedTarget = new System.Windows.Forms.FlowLayoutPanel();
      this.Flow_DAQ_flow_fanSpeedTarget_label = new System.Windows.Forms.Label();
      this.Flow_DAQ_flow_fanSpeedTarget_value = new System.Windows.Forms.TextBox();
      this.Flow_DAQ_flow_startDAQ = new System.Windows.Forms.Button();
      this.Flow_DAQ_flow_stopDAQ = new System.Windows.Forms.Button();
      this.Flow_record = new System.Windows.Forms.GroupBox();
      this.Flow_record_flow = new System.Windows.Forms.FlowLayoutPanel();
      this.Flow_record_flow_filepath = new System.Windows.Forms.FlowLayoutPanel();
      this.Flow_record_flow_filepath_label = new System.Windows.Forms.Label();
      this.Flow_record_flow_filepath_textbox = new System.Windows.Forms.TextBox();
      this.Flow_record_flow_browse = new System.Windows.Forms.Button();
      this.Flow_record_flow_startRecord = new System.Windows.Forms.Button();
      this.Flow_record_flow_stopRecord = new System.Windows.Forms.Button();
      this.recordFileDialog = new System.Windows.Forms.SaveFileDialog();
      this.Flow.SuspendLayout();
      this.Flow_port.SuspendLayout();
      this.Flow_DAQ.SuspendLayout();
      this.Flow_DAQ_flow.SuspendLayout();
      this.Flow_DAQ_flow_RH.SuspendLayout();
      this.Flow_DAQ_flow_temperature.SuspendLayout();
      this.Flow_DAQ_flow_fanSpeed.SuspendLayout();
      this.Flow_DAQ_flow_RHTarget.SuspendLayout();
      this.Flow_DAQ_flow_fanSpeedTarget.SuspendLayout();
      this.Flow_record.SuspendLayout();
      this.Flow_record_flow.SuspendLayout();
      this.Flow_record_flow_filepath.SuspendLayout();
      this.SuspendLayout();
      // 
      // Flow
      // 
      this.Flow.AutoSize = true;
      this.Flow.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.Flow.Controls.Add(this.Flow_port);
      this.Flow.Controls.Add(this.Flow_DAQ);
      this.Flow.Controls.Add(this.Flow_record);
      this.Flow.Dock = System.Windows.Forms.DockStyle.Top;
      this.Flow.Location = new System.Drawing.Point(0, 0);
      this.Flow.Name = "Flow";
      this.Flow.Size = new System.Drawing.Size(1031, 73);
      this.Flow.TabIndex = 0;
      // 
      // Flow_port
      // 
      this.Flow_port.AutoSize = true;
      this.Flow_port.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.Flow_port.Controls.Add(this.Flow_port_comboBox);
      this.Flow_port.Location = new System.Drawing.Point(3, 3);
      this.Flow_port.Name = "Flow_port";
      this.Flow_port.Size = new System.Drawing.Size(115, 59);
      this.Flow_port.TabIndex = 0;
      this.Flow_port.TabStop = false;
      this.Flow_port.Text = "Communication port";
      // 
      // Flow_port_comboBox
      // 
      this.Flow_port_comboBox.FormattingEnabled = true;
      this.Flow_port_comboBox.Location = new System.Drawing.Point(9, 19);
      this.Flow_port_comboBox.Name = "Flow_port_comboBox";
      this.Flow_port_comboBox.Size = new System.Drawing.Size(100, 21);
      this.Flow_port_comboBox.TabIndex = 1;
      // 
      // Flow_DAQ
      // 
      this.Flow_DAQ.AutoSize = true;
      this.Flow_DAQ.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.Flow_DAQ.Controls.Add(this.Flow_DAQ_flow);
      this.Flow_DAQ.Location = new System.Drawing.Point(124, 3);
      this.Flow_DAQ.Name = "Flow_DAQ";
      this.Flow_DAQ.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
      this.Flow_DAQ.Size = new System.Drawing.Size(595, 67);
      this.Flow_DAQ.TabIndex = 1;
      this.Flow_DAQ.TabStop = false;
      this.Flow_DAQ.Text = "Data acquisition";
      // 
      // Flow_DAQ_flow
      // 
      this.Flow_DAQ_flow.AutoSize = true;
      this.Flow_DAQ_flow.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.Flow_DAQ_flow.Controls.Add(this.Flow_DAQ_flow_RH);
      this.Flow_DAQ_flow.Controls.Add(this.Flow_DAQ_flow_temperature);
      this.Flow_DAQ_flow.Controls.Add(this.Flow_DAQ_flow_fanSpeed);
      this.Flow_DAQ_flow.Controls.Add(this.Flow_DAQ_flow_RHTarget);
      this.Flow_DAQ_flow.Controls.Add(this.Flow_DAQ_flow_fanSpeedTarget);
      this.Flow_DAQ_flow.Controls.Add(this.Flow_DAQ_flow_startDAQ);
      this.Flow_DAQ_flow.Controls.Add(this.Flow_DAQ_flow_stopDAQ);
      this.Flow_DAQ_flow.Dock = System.Windows.Forms.DockStyle.Fill;
      this.Flow_DAQ_flow.Location = new System.Drawing.Point(3, 13);
      this.Flow_DAQ_flow.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
      this.Flow_DAQ_flow.Name = "Flow_DAQ_flow";
      this.Flow_DAQ_flow.Size = new System.Drawing.Size(589, 51);
      this.Flow_DAQ_flow.TabIndex = 0;
      // 
      // Flow_DAQ_flow_RH
      // 
      this.Flow_DAQ_flow_RH.AutoSize = true;
      this.Flow_DAQ_flow_RH.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.Flow_DAQ_flow_RH.Controls.Add(this.Flow_DAQ_flow_RH_label);
      this.Flow_DAQ_flow_RH.Controls.Add(this.Flow_DAQ_flow_RH_value);
      this.Flow_DAQ_flow_RH.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
      this.Flow_DAQ_flow_RH.Location = new System.Drawing.Point(3, 3);
      this.Flow_DAQ_flow_RH.Name = "Flow_DAQ_flow_RH";
      this.Flow_DAQ_flow_RH.Size = new System.Drawing.Size(56, 45);
      this.Flow_DAQ_flow_RH.TabIndex = 1;
      // 
      // Flow_DAQ_flow_RH_label
      // 
      this.Flow_DAQ_flow_RH_label.AutoSize = true;
      this.Flow_DAQ_flow_RH_label.Location = new System.Drawing.Point(3, 0);
      this.Flow_DAQ_flow_RH_label.Name = "Flow_DAQ_flow_RH_label";
      this.Flow_DAQ_flow_RH_label.Size = new System.Drawing.Size(40, 13);
      this.Flow_DAQ_flow_RH_label.TabIndex = 1;
      this.Flow_DAQ_flow_RH_label.Text = "RH (%)";
      // 
      // Flow_DAQ_flow_RH_value
      // 
      this.Flow_DAQ_flow_RH_value.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Flow_DAQ_flow_RH_value.Location = new System.Drawing.Point(3, 16);
      this.Flow_DAQ_flow_RH_value.Name = "Flow_DAQ_flow_RH_value";
      this.Flow_DAQ_flow_RH_value.ReadOnly = true;
      this.Flow_DAQ_flow_RH_value.Size = new System.Drawing.Size(50, 26);
      this.Flow_DAQ_flow_RH_value.TabIndex = 0;
      this.Flow_DAQ_flow_RH_value.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // Flow_DAQ_flow_temperature
      // 
      this.Flow_DAQ_flow_temperature.AutoSize = true;
      this.Flow_DAQ_flow_temperature.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.Flow_DAQ_flow_temperature.Controls.Add(this.Flow_DAQ_flow_temperature_label);
      this.Flow_DAQ_flow_temperature.Controls.Add(this.Flow_DAQ_flow_temperature_value);
      this.Flow_DAQ_flow_temperature.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
      this.Flow_DAQ_flow_temperature.Location = new System.Drawing.Point(65, 3);
      this.Flow_DAQ_flow_temperature.Name = "Flow_DAQ_flow_temperature";
      this.Flow_DAQ_flow_temperature.Size = new System.Drawing.Size(93, 45);
      this.Flow_DAQ_flow_temperature.TabIndex = 2;
      // 
      // Flow_DAQ_flow_temperature_label
      // 
      this.Flow_DAQ_flow_temperature_label.AutoSize = true;
      this.Flow_DAQ_flow_temperature_label.Location = new System.Drawing.Point(3, 0);
      this.Flow_DAQ_flow_temperature_label.Name = "Flow_DAQ_flow_temperature_label";
      this.Flow_DAQ_flow_temperature_label.Size = new System.Drawing.Size(87, 13);
      this.Flow_DAQ_flow_temperature_label.TabIndex = 1;
      this.Flow_DAQ_flow_temperature_label.Text = "Temperature (°C)";
      // 
      // Flow_DAQ_flow_temperature_value
      // 
      this.Flow_DAQ_flow_temperature_value.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Flow_DAQ_flow_temperature_value.Location = new System.Drawing.Point(3, 16);
      this.Flow_DAQ_flow_temperature_value.Name = "Flow_DAQ_flow_temperature_value";
      this.Flow_DAQ_flow_temperature_value.ReadOnly = true;
      this.Flow_DAQ_flow_temperature_value.Size = new System.Drawing.Size(80, 26);
      this.Flow_DAQ_flow_temperature_value.TabIndex = 0;
      this.Flow_DAQ_flow_temperature_value.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // Flow_DAQ_flow_fanSpeed
      // 
      this.Flow_DAQ_flow_fanSpeed.AutoSize = true;
      this.Flow_DAQ_flow_fanSpeed.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.Flow_DAQ_flow_fanSpeed.Controls.Add(this.Flow_DAQ_flow_fanSpeed_label);
      this.Flow_DAQ_flow_fanSpeed.Controls.Add(this.Flow_DAQ_flow_fanSpeed_value);
      this.Flow_DAQ_flow_fanSpeed.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
      this.Flow_DAQ_flow_fanSpeed.Location = new System.Drawing.Point(164, 3);
      this.Flow_DAQ_flow_fanSpeed.Name = "Flow_DAQ_flow_fanSpeed";
      this.Flow_DAQ_flow_fanSpeed.Size = new System.Drawing.Size(96, 45);
      this.Flow_DAQ_flow_fanSpeed.TabIndex = 3;
      // 
      // Flow_DAQ_flow_fanSpeed_label
      // 
      this.Flow_DAQ_flow_fanSpeed_label.AutoSize = true;
      this.Flow_DAQ_flow_fanSpeed_label.Location = new System.Drawing.Point(3, 0);
      this.Flow_DAQ_flow_fanSpeed_label.Name = "Flow_DAQ_flow_fanSpeed_label";
      this.Flow_DAQ_flow_fanSpeed_label.Size = new System.Drawing.Size(90, 13);
      this.Flow_DAQ_flow_fanSpeed_label.TabIndex = 1;
      this.Flow_DAQ_flow_fanSpeed_label.Text = "Fan speed (RPM)";
      // 
      // Flow_DAQ_flow_fanSpeed_value
      // 
      this.Flow_DAQ_flow_fanSpeed_value.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Flow_DAQ_flow_fanSpeed_value.Location = new System.Drawing.Point(3, 16);
      this.Flow_DAQ_flow_fanSpeed_value.Name = "Flow_DAQ_flow_fanSpeed_value";
      this.Flow_DAQ_flow_fanSpeed_value.ReadOnly = true;
      this.Flow_DAQ_flow_fanSpeed_value.Size = new System.Drawing.Size(80, 26);
      this.Flow_DAQ_flow_fanSpeed_value.TabIndex = 0;
      this.Flow_DAQ_flow_fanSpeed_value.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // Flow_DAQ_flow_RHTarget
      // 
      this.Flow_DAQ_flow_RHTarget.AutoSize = true;
      this.Flow_DAQ_flow_RHTarget.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.Flow_DAQ_flow_RHTarget.Controls.Add(this.Flow_DAQ_flow_RHTarget_label);
      this.Flow_DAQ_flow_RHTarget.Controls.Add(this.Flow_DAQ_flow_RHTarget_value);
      this.Flow_DAQ_flow_RHTarget.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
      this.Flow_DAQ_flow_RHTarget.Location = new System.Drawing.Point(266, 3);
      this.Flow_DAQ_flow_RHTarget.Name = "Flow_DAQ_flow_RHTarget";
      this.Flow_DAQ_flow_RHTarget.Size = new System.Drawing.Size(76, 45);
      this.Flow_DAQ_flow_RHTarget.TabIndex = 4;
      // 
      // Flow_DAQ_flow_RHTarget_label
      // 
      this.Flow_DAQ_flow_RHTarget_label.AutoSize = true;
      this.Flow_DAQ_flow_RHTarget_label.Location = new System.Drawing.Point(3, 0);
      this.Flow_DAQ_flow_RHTarget_label.Name = "Flow_DAQ_flow_RHTarget_label";
      this.Flow_DAQ_flow_RHTarget_label.Size = new System.Drawing.Size(70, 13);
      this.Flow_DAQ_flow_RHTarget_label.TabIndex = 1;
      this.Flow_DAQ_flow_RHTarget_label.Text = "RH target (%)";
      // 
      // Flow_DAQ_flow_RHTarget_value
      // 
      this.Flow_DAQ_flow_RHTarget_value.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Flow_DAQ_flow_RHTarget_value.Location = new System.Drawing.Point(3, 16);
      this.Flow_DAQ_flow_RHTarget_value.Name = "Flow_DAQ_flow_RHTarget_value";
      this.Flow_DAQ_flow_RHTarget_value.ReadOnly = true;
      this.Flow_DAQ_flow_RHTarget_value.Size = new System.Drawing.Size(60, 26);
      this.Flow_DAQ_flow_RHTarget_value.TabIndex = 0;
      this.Flow_DAQ_flow_RHTarget_value.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // Flow_DAQ_flow_fanSpeedTarget
      // 
      this.Flow_DAQ_flow_fanSpeedTarget.AutoSize = true;
      this.Flow_DAQ_flow_fanSpeedTarget.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.Flow_DAQ_flow_fanSpeedTarget.Controls.Add(this.Flow_DAQ_flow_fanSpeedTarget_label);
      this.Flow_DAQ_flow_fanSpeedTarget.Controls.Add(this.Flow_DAQ_flow_fanSpeedTarget_value);
      this.Flow_DAQ_flow_fanSpeedTarget.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
      this.Flow_DAQ_flow_fanSpeedTarget.Location = new System.Drawing.Point(348, 3);
      this.Flow_DAQ_flow_fanSpeedTarget.Name = "Flow_DAQ_flow_fanSpeedTarget";
      this.Flow_DAQ_flow_fanSpeedTarget.Size = new System.Drawing.Size(126, 45);
      this.Flow_DAQ_flow_fanSpeedTarget.TabIndex = 5;
      // 
      // Flow_DAQ_flow_fanSpeedTarget_label
      // 
      this.Flow_DAQ_flow_fanSpeedTarget_label.AutoSize = true;
      this.Flow_DAQ_flow_fanSpeedTarget_label.Location = new System.Drawing.Point(3, 0);
      this.Flow_DAQ_flow_fanSpeedTarget_label.Name = "Flow_DAQ_flow_fanSpeedTarget_label";
      this.Flow_DAQ_flow_fanSpeedTarget_label.Size = new System.Drawing.Size(120, 13);
      this.Flow_DAQ_flow_fanSpeedTarget_label.TabIndex = 1;
      this.Flow_DAQ_flow_fanSpeedTarget_label.Text = "Fan speed target (RPM)";
      // 
      // Flow_DAQ_flow_fanSpeedTarget_value
      // 
      this.Flow_DAQ_flow_fanSpeedTarget_value.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Flow_DAQ_flow_fanSpeedTarget_value.Location = new System.Drawing.Point(3, 16);
      this.Flow_DAQ_flow_fanSpeedTarget_value.Name = "Flow_DAQ_flow_fanSpeedTarget_value";
      this.Flow_DAQ_flow_fanSpeedTarget_value.ReadOnly = true;
      this.Flow_DAQ_flow_fanSpeedTarget_value.Size = new System.Drawing.Size(110, 26);
      this.Flow_DAQ_flow_fanSpeedTarget_value.TabIndex = 0;
      this.Flow_DAQ_flow_fanSpeedTarget_value.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // Flow_DAQ_flow_startDAQ
      // 
      this.Flow_DAQ_flow_startDAQ.Location = new System.Drawing.Point(480, 3);
      this.Flow_DAQ_flow_startDAQ.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
      this.Flow_DAQ_flow_startDAQ.Name = "Flow_DAQ_flow_startDAQ";
      this.Flow_DAQ_flow_startDAQ.Size = new System.Drawing.Size(50, 45);
      this.Flow_DAQ_flow_startDAQ.TabIndex = 6;
      this.Flow_DAQ_flow_startDAQ.Text = "Start DAQ";
      this.Flow_DAQ_flow_startDAQ.UseVisualStyleBackColor = true;
      this.Flow_DAQ_flow_startDAQ.Click += new System.EventHandler(this.Flow_DAQ_flow_startDAQ_Click);
      // 
      // Flow_DAQ_flow_stopDAQ
      // 
      this.Flow_DAQ_flow_stopDAQ.Enabled = false;
      this.Flow_DAQ_flow_stopDAQ.Location = new System.Drawing.Point(536, 3);
      this.Flow_DAQ_flow_stopDAQ.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
      this.Flow_DAQ_flow_stopDAQ.Name = "Flow_DAQ_flow_stopDAQ";
      this.Flow_DAQ_flow_stopDAQ.Size = new System.Drawing.Size(50, 45);
      this.Flow_DAQ_flow_stopDAQ.TabIndex = 8;
      this.Flow_DAQ_flow_stopDAQ.Text = "Stop DAQ";
      this.Flow_DAQ_flow_stopDAQ.UseVisualStyleBackColor = true;
      this.Flow_DAQ_flow_stopDAQ.Visible = false;
      this.Flow_DAQ_flow_stopDAQ.Click += new System.EventHandler(this.Flow_DAQ_flow_stopDAQ_Click);
      // 
      // Flow_record
      // 
      this.Flow_record.AutoSize = true;
      this.Flow_record.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.Flow_record.Controls.Add(this.Flow_record_flow);
      this.Flow_record.Location = new System.Drawing.Point(725, 3);
      this.Flow_record.Name = "Flow_record";
      this.Flow_record.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
      this.Flow_record.Size = new System.Drawing.Size(288, 65);
      this.Flow_record.TabIndex = 2;
      this.Flow_record.TabStop = false;
      this.Flow_record.Text = "Data recording";
      // 
      // Flow_record_flow
      // 
      this.Flow_record_flow.AutoSize = true;
      this.Flow_record_flow.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.Flow_record_flow.Controls.Add(this.Flow_record_flow_filepath);
      this.Flow_record_flow.Controls.Add(this.Flow_record_flow_browse);
      this.Flow_record_flow.Controls.Add(this.Flow_record_flow_startRecord);
      this.Flow_record_flow.Controls.Add(this.Flow_record_flow_stopRecord);
      this.Flow_record_flow.Dock = System.Windows.Forms.DockStyle.Fill;
      this.Flow_record_flow.Location = new System.Drawing.Point(3, 13);
      this.Flow_record_flow.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
      this.Flow_record_flow.Name = "Flow_record_flow";
      this.Flow_record_flow.Size = new System.Drawing.Size(282, 49);
      this.Flow_record_flow.TabIndex = 0;
      // 
      // Flow_record_flow_filepath
      // 
      this.Flow_record_flow_filepath.Controls.Add(this.Flow_record_flow_filepath_label);
      this.Flow_record_flow_filepath.Controls.Add(this.Flow_record_flow_filepath_textbox);
      this.Flow_record_flow_filepath.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
      this.Flow_record_flow_filepath.Location = new System.Drawing.Point(0, 0);
      this.Flow_record_flow_filepath.Margin = new System.Windows.Forms.Padding(0);
      this.Flow_record_flow_filepath.Name = "Flow_record_flow_filepath";
      this.Flow_record_flow_filepath.Size = new System.Drawing.Size(148, 49);
      this.Flow_record_flow_filepath.TabIndex = 1;
      // 
      // Flow_record_flow_filepath_label
      // 
      this.Flow_record_flow_filepath_label.AutoSize = true;
      this.Flow_record_flow_filepath_label.Location = new System.Drawing.Point(3, 3);
      this.Flow_record_flow_filepath_label.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
      this.Flow_record_flow_filepath_label.Name = "Flow_record_flow_filepath_label";
      this.Flow_record_flow_filepath_label.Size = new System.Drawing.Size(47, 13);
      this.Flow_record_flow_filepath_label.TabIndex = 14;
      this.Flow_record_flow_filepath_label.Text = "File path";
      // 
      // Flow_record_flow_filepath_textbox
      // 
      this.Flow_record_flow_filepath_textbox.BackColor = System.Drawing.SystemColors.Window;
      this.Flow_record_flow_filepath_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Flow_record_flow_filepath_textbox.Location = new System.Drawing.Point(3, 19);
      this.Flow_record_flow_filepath_textbox.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
      this.Flow_record_flow_filepath_textbox.Name = "Flow_record_flow_filepath_textbox";
      this.Flow_record_flow_filepath_textbox.ReadOnly = true;
      this.Flow_record_flow_filepath_textbox.Size = new System.Drawing.Size(144, 20);
      this.Flow_record_flow_filepath_textbox.TabIndex = 1;
      this.Flow_record_flow_filepath_textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.Flow_record_flow_filepath_textbox.WordWrap = false;
      // 
      // Flow_record_flow_browse
      // 
      this.Flow_record_flow_browse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Flow_record_flow_browse.Location = new System.Drawing.Point(148, 17);
      this.Flow_record_flow_browse.Margin = new System.Windows.Forms.Padding(0, 17, 3, 3);
      this.Flow_record_flow_browse.Name = "Flow_record_flow_browse";
      this.Flow_record_flow_browse.Size = new System.Drawing.Size(29, 22);
      this.Flow_record_flow_browse.TabIndex = 2;
      this.Flow_record_flow_browse.Text = "...";
      this.Flow_record_flow_browse.UseVisualStyleBackColor = true;
      this.Flow_record_flow_browse.Click += new System.EventHandler(this.Flow_record_flow_browse_Click);
      // 
      // Flow_record_flow_startRecord
      // 
      this.Flow_record_flow_startRecord.Enabled = false;
      this.Flow_record_flow_startRecord.Location = new System.Drawing.Point(183, 3);
      this.Flow_record_flow_startRecord.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
      this.Flow_record_flow_startRecord.Name = "Flow_record_flow_startRecord";
      this.Flow_record_flow_startRecord.Size = new System.Drawing.Size(45, 45);
      this.Flow_record_flow_startRecord.TabIndex = 3;
      this.Flow_record_flow_startRecord.Text = "Start record";
      this.Flow_record_flow_startRecord.UseVisualStyleBackColor = true;
      this.Flow_record_flow_startRecord.Click += new System.EventHandler(this.Flow_record_flow_startRecord_Click);
      // 
      // Flow_record_flow_stopRecord
      // 
      this.Flow_record_flow_stopRecord.Enabled = false;
      this.Flow_record_flow_stopRecord.Location = new System.Drawing.Point(234, 3);
      this.Flow_record_flow_stopRecord.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
      this.Flow_record_flow_stopRecord.Name = "Flow_record_flow_stopRecord";
      this.Flow_record_flow_stopRecord.Size = new System.Drawing.Size(45, 45);
      this.Flow_record_flow_stopRecord.TabIndex = 4;
      this.Flow_record_flow_stopRecord.Text = "Stop record";
      this.Flow_record_flow_stopRecord.UseVisualStyleBackColor = true;
      this.Flow_record_flow_stopRecord.Visible = false;
      this.Flow_record_flow_stopRecord.Click += new System.EventHandler(this.Flow_record_flow_stopRecord_Click);
      // 
      // recordFileDialog
      // 
      this.recordFileDialog.DefaultExt = "csv";
      this.recordFileDialog.Filter = "CSV file|*.csv";
      this.recordFileDialog.Title = "File to save recorded data";
      // 
      // HumidOSH
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1031, 450);
      this.Controls.Add(this.Flow);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "HumidOSH";
      this.Text = "HumidOSH";
      this.Flow.ResumeLayout(false);
      this.Flow.PerformLayout();
      this.Flow_port.ResumeLayout(false);
      this.Flow_DAQ.ResumeLayout(false);
      this.Flow_DAQ.PerformLayout();
      this.Flow_DAQ_flow.ResumeLayout(false);
      this.Flow_DAQ_flow.PerformLayout();
      this.Flow_DAQ_flow_RH.ResumeLayout(false);
      this.Flow_DAQ_flow_RH.PerformLayout();
      this.Flow_DAQ_flow_temperature.ResumeLayout(false);
      this.Flow_DAQ_flow_temperature.PerformLayout();
      this.Flow_DAQ_flow_fanSpeed.ResumeLayout(false);
      this.Flow_DAQ_flow_fanSpeed.PerformLayout();
      this.Flow_DAQ_flow_RHTarget.ResumeLayout(false);
      this.Flow_DAQ_flow_RHTarget.PerformLayout();
      this.Flow_DAQ_flow_fanSpeedTarget.ResumeLayout(false);
      this.Flow_DAQ_flow_fanSpeedTarget.PerformLayout();
      this.Flow_record.ResumeLayout(false);
      this.Flow_record.PerformLayout();
      this.Flow_record_flow.ResumeLayout(false);
      this.Flow_record_flow_filepath.ResumeLayout(false);
      this.Flow_record_flow_filepath.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.FlowLayoutPanel Flow;
    private System.Windows.Forms.GroupBox Flow_port;
    private System.Windows.Forms.GroupBox Flow_DAQ;
    private System.Windows.Forms.GroupBox Flow_record;
    private System.Windows.Forms.ComboBox Flow_port_comboBox;
    private System.Windows.Forms.FlowLayoutPanel Flow_DAQ_flow;
    private System.Windows.Forms.FlowLayoutPanel Flow_DAQ_flow_RH;
    private System.Windows.Forms.Label Flow_DAQ_flow_RH_label;
    private System.Windows.Forms.TextBox Flow_DAQ_flow_RH_value;
    private System.Windows.Forms.FlowLayoutPanel Flow_DAQ_flow_temperature;
    private System.Windows.Forms.Label Flow_DAQ_flow_temperature_label;
    private System.Windows.Forms.TextBox Flow_DAQ_flow_temperature_value;
    private System.Windows.Forms.FlowLayoutPanel Flow_DAQ_flow_fanSpeed;
    private System.Windows.Forms.Label Flow_DAQ_flow_fanSpeed_label;
    private System.Windows.Forms.TextBox Flow_DAQ_flow_fanSpeed_value;
    private System.Windows.Forms.FlowLayoutPanel Flow_DAQ_flow_RHTarget;
    private System.Windows.Forms.Label Flow_DAQ_flow_RHTarget_label;
    private System.Windows.Forms.TextBox Flow_DAQ_flow_RHTarget_value;
    private System.Windows.Forms.FlowLayoutPanel Flow_DAQ_flow_fanSpeedTarget;
    private System.Windows.Forms.Label Flow_DAQ_flow_fanSpeedTarget_label;
    private System.Windows.Forms.TextBox Flow_DAQ_flow_fanSpeedTarget_value;
    private System.Windows.Forms.Button Flow_DAQ_flow_startDAQ;
    private System.Windows.Forms.Button Flow_DAQ_flow_stopDAQ;
    private System.Windows.Forms.FlowLayoutPanel Flow_record_flow;
    private System.Windows.Forms.FlowLayoutPanel Flow_record_flow_filepath;
    private System.Windows.Forms.Label Flow_record_flow_filepath_label;
    private System.Windows.Forms.TextBox Flow_record_flow_filepath_textbox;
    private System.Windows.Forms.Button Flow_record_flow_browse;
    private System.Windows.Forms.Button Flow_record_flow_startRecord;
    private System.Windows.Forms.Button Flow_record_flow_stopRecord;
    private System.Windows.Forms.SaveFileDialog recordFileDialog;
  }
}

