namespace SensorCollectorForm
{
    partial class UserControl1
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.btn_read_defrost_cycle_period = new System.Windows.Forms.Button();
            this.btn_write_Defrost_cycle_period = new System.Windows.Forms.Button();
            this.btn_write_active_fridge = new System.Windows.Forms.Button();
            this.btn_enable_live_monitor_mode = new System.Windows.Forms.Button();
            this.btn_read_bat_voltage = new System.Windows.Forms.Button();
            this.btn_read_error_event_status = new System.Windows.Forms.Button();
            this.btn_clear_fridge_slarm_status = new System.Windows.Forms.Button();
            this.btn_read_fridge_status = new System.Windows.Forms.Button();
            this.btn_read_fridge_temp_alarm_thresh = new System.Windows.Forms.Button();
            this.btn_write_fridge_temp_alarm_thresh = new System.Windows.Forms.Button();
            this.btn_dnwld_eeprom = new System.Windows.Forms.Button();
            this.btn_write_RTC = new System.Windows.Forms.Button();
            this.btn_read_rtc = new System.Windows.Forms.Button();
            this.btn_clear_eeprom = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox4);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.btn_read_defrost_cycle_period);
            this.panel1.Controls.Add(this.btn_write_Defrost_cycle_period);
            this.panel1.Controls.Add(this.btn_write_active_fridge);
            this.panel1.Controls.Add(this.btn_enable_live_monitor_mode);
            this.panel1.Controls.Add(this.btn_read_bat_voltage);
            this.panel1.Controls.Add(this.btn_read_error_event_status);
            this.panel1.Controls.Add(this.btn_clear_fridge_slarm_status);
            this.panel1.Controls.Add(this.btn_read_fridge_status);
            this.panel1.Controls.Add(this.btn_read_fridge_temp_alarm_thresh);
            this.panel1.Controls.Add(this.btn_write_fridge_temp_alarm_thresh);
            this.panel1.Controls.Add(this.btn_dnwld_eeprom);
            this.panel1.Controls.Add(this.btn_write_RTC);
            this.panel1.Controls.Add(this.btn_read_rtc);
            this.panel1.Controls.Add(this.btn_clear_eeprom);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Location = new System.Drawing.Point(14, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(833, 592);
            this.panel1.TabIndex = 0;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(160, 425);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 17;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(160, 274);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 16;
            // 
            // btn_read_defrost_cycle_period
            // 
            this.btn_read_defrost_cycle_period.Location = new System.Drawing.Point(28, 376);
            this.btn_read_defrost_cycle_period.Name = "btn_read_defrost_cycle_period";
            this.btn_read_defrost_cycle_period.Size = new System.Drawing.Size(100, 43);
            this.btn_read_defrost_cycle_period.TabIndex = 15;
            this.btn_read_defrost_cycle_period.Text = "Read defrost cycle period count";
            this.btn_read_defrost_cycle_period.UseVisualStyleBackColor = true;
            this.btn_read_defrost_cycle_period.Click += new System.EventHandler(this.btn_read_defrost_cycle_period_Click);
            // 
            // btn_write_Defrost_cycle_period
            // 
            this.btn_write_Defrost_cycle_period.Location = new System.Drawing.Point(28, 425);
            this.btn_write_Defrost_cycle_period.Name = "btn_write_Defrost_cycle_period";
            this.btn_write_Defrost_cycle_period.Size = new System.Drawing.Size(100, 43);
            this.btn_write_Defrost_cycle_period.TabIndex = 14;
            this.btn_write_Defrost_cycle_period.Text = "Write defrost cycle period count";
            this.btn_write_Defrost_cycle_period.UseVisualStyleBackColor = true;
            this.btn_write_Defrost_cycle_period.Click += new System.EventHandler(this.btn_write_Defrost_cycle_period_Click);
            // 
            // btn_write_active_fridge
            // 
            this.btn_write_active_fridge.Location = new System.Drawing.Point(385, 276);
            this.btn_write_active_fridge.Name = "btn_write_active_fridge";
            this.btn_write_active_fridge.Size = new System.Drawing.Size(100, 43);
            this.btn_write_active_fridge.TabIndex = 13;
            this.btn_write_active_fridge.Text = "Write Active Fridge";
            this.btn_write_active_fridge.UseVisualStyleBackColor = true;
            this.btn_write_active_fridge.Click += new System.EventHandler(this.btn_write_active_fridge_Click);
            // 
            // btn_enable_live_monitor_mode
            // 
            this.btn_enable_live_monitor_mode.Location = new System.Drawing.Point(385, 328);
            this.btn_enable_live_monitor_mode.Name = "btn_enable_live_monitor_mode";
            this.btn_enable_live_monitor_mode.Size = new System.Drawing.Size(100, 43);
            this.btn_enable_live_monitor_mode.TabIndex = 12;
            this.btn_enable_live_monitor_mode.Text = "Enable Live monitor mode";
            this.btn_enable_live_monitor_mode.UseVisualStyleBackColor = true;
            this.btn_enable_live_monitor_mode.Click += new System.EventHandler(this.btn_enable_live_monitor_mode_Click);
            // 
            // btn_read_bat_voltage
            // 
            this.btn_read_bat_voltage.Location = new System.Drawing.Point(385, 225);
            this.btn_read_bat_voltage.Name = "btn_read_bat_voltage";
            this.btn_read_bat_voltage.Size = new System.Drawing.Size(100, 43);
            this.btn_read_bat_voltage.TabIndex = 11;
            this.btn_read_bat_voltage.Text = "Read battery voltage";
            this.btn_read_bat_voltage.UseVisualStyleBackColor = true;
            this.btn_read_bat_voltage.Click += new System.EventHandler(this.btn_read_bat_voltage_Click);
            // 
            // btn_read_error_event_status
            // 
            this.btn_read_error_event_status.Location = new System.Drawing.Point(385, 174);
            this.btn_read_error_event_status.Name = "btn_read_error_event_status";
            this.btn_read_error_event_status.Size = new System.Drawing.Size(100, 43);
            this.btn_read_error_event_status.TabIndex = 10;
            this.btn_read_error_event_status.Text = "Read Error event status";
            this.btn_read_error_event_status.UseVisualStyleBackColor = true;
            this.btn_read_error_event_status.Click += new System.EventHandler(this.btn_read_error_event_status_Click);
            // 
            // btn_clear_fridge_slarm_status
            // 
            this.btn_clear_fridge_slarm_status.Location = new System.Drawing.Point(385, 125);
            this.btn_clear_fridge_slarm_status.Name = "btn_clear_fridge_slarm_status";
            this.btn_clear_fridge_slarm_status.Size = new System.Drawing.Size(100, 43);
            this.btn_clear_fridge_slarm_status.TabIndex = 9;
            this.btn_clear_fridge_slarm_status.Text = "Clear Fridge Alarm Status";
            this.btn_clear_fridge_slarm_status.UseVisualStyleBackColor = true;
            this.btn_clear_fridge_slarm_status.Click += new System.EventHandler(this.btn_clear_fridge_slarm_status_Click);
            // 
            // btn_read_fridge_status
            // 
            this.btn_read_fridge_status.Location = new System.Drawing.Point(385, 76);
            this.btn_read_fridge_status.Name = "btn_read_fridge_status";
            this.btn_read_fridge_status.Size = new System.Drawing.Size(100, 43);
            this.btn_read_fridge_status.TabIndex = 8;
            this.btn_read_fridge_status.Text = "Read Fridge Status";
            this.btn_read_fridge_status.UseVisualStyleBackColor = true;
            this.btn_read_fridge_status.Click += new System.EventHandler(this.btn_read_fridge_status_Click);
            // 
            // btn_read_fridge_temp_alarm_thresh
            // 
            this.btn_read_fridge_temp_alarm_thresh.Location = new System.Drawing.Point(28, 328);
            this.btn_read_fridge_temp_alarm_thresh.Name = "btn_read_fridge_temp_alarm_thresh";
            this.btn_read_fridge_temp_alarm_thresh.Size = new System.Drawing.Size(113, 42);
            this.btn_read_fridge_temp_alarm_thresh.TabIndex = 7;
            this.btn_read_fridge_temp_alarm_thresh.Text = "Read Fridge Temp Alarm Threshold";
            this.btn_read_fridge_temp_alarm_thresh.UseVisualStyleBackColor = true;
            this.btn_read_fridge_temp_alarm_thresh.Click += new System.EventHandler(this.btn_read_fridge_temp_alarm_thresh_Click);
            // 
            // btn_write_fridge_temp_alarm_thresh
            // 
            this.btn_write_fridge_temp_alarm_thresh.Location = new System.Drawing.Point(28, 274);
            this.btn_write_fridge_temp_alarm_thresh.Name = "btn_write_fridge_temp_alarm_thresh";
            this.btn_write_fridge_temp_alarm_thresh.Size = new System.Drawing.Size(113, 45);
            this.btn_write_fridge_temp_alarm_thresh.TabIndex = 6;
            this.btn_write_fridge_temp_alarm_thresh.Text = "Write Fridge Alarm Temp Threshold";
            this.btn_write_fridge_temp_alarm_thresh.UseVisualStyleBackColor = true;
            this.btn_write_fridge_temp_alarm_thresh.Click += new System.EventHandler(this.btn_write_fridge_temp_alarm_thresh_Click);
            // 
            // btn_dnwld_eeprom
            // 
            this.btn_dnwld_eeprom.Location = new System.Drawing.Point(28, 125);
            this.btn_dnwld_eeprom.Name = "btn_dnwld_eeprom";
            this.btn_dnwld_eeprom.Size = new System.Drawing.Size(100, 43);
            this.btn_dnwld_eeprom.TabIndex = 5;
            this.btn_dnwld_eeprom.Text = "Download EEPROM";
            this.btn_dnwld_eeprom.UseVisualStyleBackColor = true;
            this.btn_dnwld_eeprom.Click += new System.EventHandler(this.btn_dnwld_eeprom_Click);
            // 
            // btn_write_RTC
            // 
            this.btn_write_RTC.Location = new System.Drawing.Point(28, 225);
            this.btn_write_RTC.Name = "btn_write_RTC";
            this.btn_write_RTC.Size = new System.Drawing.Size(100, 43);
            this.btn_write_RTC.TabIndex = 4;
            this.btn_write_RTC.Text = "Write RTC";
            this.btn_write_RTC.UseVisualStyleBackColor = true;
            this.btn_write_RTC.Click += new System.EventHandler(this.btn_write_RTC_Click);
            // 
            // btn_read_rtc
            // 
            this.btn_read_rtc.Location = new System.Drawing.Point(28, 176);
            this.btn_read_rtc.Name = "btn_read_rtc";
            this.btn_read_rtc.Size = new System.Drawing.Size(100, 43);
            this.btn_read_rtc.TabIndex = 3;
            this.btn_read_rtc.Text = "READ RTC";
            this.btn_read_rtc.UseVisualStyleBackColor = true;
            this.btn_read_rtc.Click += new System.EventHandler(this.btn_read_rtc_Click);
            // 
            // btn_clear_eeprom
            // 
            this.btn_clear_eeprom.Location = new System.Drawing.Point(28, 76);
            this.btn_clear_eeprom.Name = "btn_clear_eeprom";
            this.btn_clear_eeprom.Size = new System.Drawing.Size(100, 43);
            this.btn_clear_eeprom.TabIndex = 2;
            this.btn_clear_eeprom.Text = "Clear EEPROM";
            this.btn_clear_eeprom.UseVisualStyleBackColor = true;
            this.btn_clear_eeprom.Click += new System.EventHandler(this.btn_clear_eeprom_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Com Port";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Com Port";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(28, 41);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(160, 225);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(873, 633);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button btn_write_Defrost_cycle_period;
        private System.Windows.Forms.Button btn_write_active_fridge;
        private System.Windows.Forms.Button btn_enable_live_monitor_mode;
        private System.Windows.Forms.Button btn_read_bat_voltage;
        private System.Windows.Forms.Button btn_read_error_event_status;
        private System.Windows.Forms.Button btn_clear_fridge_slarm_status;
        private System.Windows.Forms.Button btn_read_fridge_status;
        private System.Windows.Forms.Button btn_read_fridge_temp_alarm_thresh;
        private System.Windows.Forms.Button btn_write_fridge_temp_alarm_thresh;
        private System.Windows.Forms.Button btn_dnwld_eeprom;
        private System.Windows.Forms.Button btn_write_RTC;
        private System.Windows.Forms.Button btn_read_rtc;
        private System.Windows.Forms.Button btn_clear_eeprom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_read_defrost_cycle_period;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
    }
}
