namespace SensorCollectorForm
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem21 = new System.Windows.Forms.ListViewItem(new string[] {
            "SET RTC",
            "-",
            "-",
            "-"}, -1);
            System.Windows.Forms.ListViewItem listViewItem22 = new System.Windows.Forms.ListViewItem(new string[] {
            "DWNLOAD EEPROM",
            "-",
            "-",
            "-"}, -1);
            System.Windows.Forms.ListViewItem listViewItem23 = new System.Windows.Forms.ListViewItem(new string[] {
            "CLR EEPROM",
            "-",
            "-",
            "-"}, -1);
            System.Windows.Forms.ListViewItem listViewItem24 = new System.Windows.Forms.ListViewItem(new string[] {
            "SEND TO SERVER",
            "-",
            "-",
            "-"}, -1);
            this.btn_write_RTC = new System.Windows.Forms.Button();
            this.btn_read_rtc = new System.Windows.Forms.Button();
            this.btn_clear_eeprom = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_tab2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.comboBox_serialPorts = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_dnwld_eeprom = new System.Windows.Forms.Button();
            this.btn_OpenCom = new System.Windows.Forms.Button();
            this.timer_Get_EEPROM = new System.Windows.Forms.Timer(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.status = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.MessageListView = new System.Windows.Forms.ListView();
            this.Commands = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LastStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TimeReceived = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Count = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.debug = new System.Windows.Forms.TabPage();
            this.timer_UpdateToServer = new System.Windows.Forms.Timer(this.components);
            this.panel_tab2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.status.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.debug.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_write_RTC
            // 
            this.btn_write_RTC.Location = new System.Drawing.Point(372, 171);
            this.btn_write_RTC.Name = "btn_write_RTC";
            this.btn_write_RTC.Size = new System.Drawing.Size(100, 43);
            this.btn_write_RTC.TabIndex = 4;
            this.btn_write_RTC.Text = "Write RTC";
            this.btn_write_RTC.UseVisualStyleBackColor = true;
            this.btn_write_RTC.Click += new System.EventHandler(this.btn_write_RTC_Click);
            // 
            // btn_read_rtc
            // 
            this.btn_read_rtc.Location = new System.Drawing.Point(249, 171);
            this.btn_read_rtc.Name = "btn_read_rtc";
            this.btn_read_rtc.Size = new System.Drawing.Size(100, 43);
            this.btn_read_rtc.TabIndex = 3;
            this.btn_read_rtc.Text = "READ RTC";
            this.btn_read_rtc.UseVisualStyleBackColor = true;
            this.btn_read_rtc.Click += new System.EventHandler(this.btn_read_rtc_Click);
            // 
            // btn_clear_eeprom
            // 
            this.btn_clear_eeprom.Location = new System.Drawing.Point(3, 171);
            this.btn_clear_eeprom.Name = "btn_clear_eeprom";
            this.btn_clear_eeprom.Size = new System.Drawing.Size(100, 43);
            this.btn_clear_eeprom.TabIndex = 2;
            this.btn_clear_eeprom.Text = "Clear EEPROM";
            this.btn_clear_eeprom.UseVisualStyleBackColor = true;
            this.btn_clear_eeprom.Click += new System.EventHandler(this.btn_clear_eeprom_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Com Port";
            // 
            // panel_tab2
            // 
            this.panel_tab2.Controls.Add(this.tableLayoutPanel2);
            this.panel_tab2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_tab2.Location = new System.Drawing.Point(3, 3);
            this.panel_tab2.Name = "panel_tab2";
            this.panel_tab2.Size = new System.Drawing.Size(494, 424);
            this.panel_tab2.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.button3, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.button4, 3, 3);
            this.tableLayoutPanel2.Controls.Add(this.comboBox_serialPorts, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.button2, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.button1, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.btn_clear_eeprom, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.btn_write_RTC, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.btn_dnwld_eeprom, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.btn_read_rtc, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.btn_OpenCom, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(494, 424);
            this.tableLayoutPanel2.TabIndex = 27;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(126, 255);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 43);
            this.button3.TabIndex = 25;
            this.button3.Text = "Connection String (obsolete)";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(372, 255);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 43);
            this.button4.TabIndex = 26;
            this.button4.Text = "Check Internet Connectivity";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // comboBox_serialPorts
            // 
            this.comboBox_serialPorts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_serialPorts.FormattingEnabled = true;
            this.comboBox_serialPorts.Location = new System.Drawing.Point(126, 3);
            this.comboBox_serialPorts.Name = "comboBox_serialPorts";
            this.comboBox_serialPorts.Size = new System.Drawing.Size(117, 21);
            this.comboBox_serialPorts.TabIndex = 22;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(249, 255);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 43);
            this.button2.TabIndex = 24;
            this.button2.Text = "Send to Server";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 255);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 43);
            this.button1.TabIndex = 23;
            this.button1.Text = "Add Temp Value to DB - Current time";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_dnwld_eeprom
            // 
            this.btn_dnwld_eeprom.Location = new System.Drawing.Point(126, 171);
            this.btn_dnwld_eeprom.Name = "btn_dnwld_eeprom";
            this.btn_dnwld_eeprom.Size = new System.Drawing.Size(100, 43);
            this.btn_dnwld_eeprom.TabIndex = 18;
            this.btn_dnwld_eeprom.Text = "Download EEPROM";
            this.btn_dnwld_eeprom.UseVisualStyleBackColor = true;
            this.btn_dnwld_eeprom.Click += new System.EventHandler(this.btn_dnwld_eeprom_Click);
            // 
            // btn_OpenCom
            // 
            this.btn_OpenCom.Location = new System.Drawing.Point(249, 3);
            this.btn_OpenCom.Name = "btn_OpenCom";
            this.btn_OpenCom.Size = new System.Drawing.Size(74, 43);
            this.btn_OpenCom.TabIndex = 20;
            this.btn_OpenCom.Text = "Select Port";
            this.btn_OpenCom.UseVisualStyleBackColor = true;
            this.btn_OpenCom.Click += new System.EventHandler(this.btn_OpenCom_Click);
            // 
            // timer_Get_EEPROM
            // 
            this.timer_Get_EEPROM.Enabled = true;
            this.timer_Get_EEPROM.Interval = 450000;
            this.timer_Get_EEPROM.Tick += new System.EventHandler(this.timer_Get_EEPROM_Tick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.status);
            this.tabControl1.Controls.Add(this.debug);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(508, 456);
            this.tabControl1.TabIndex = 2;
            // 
            // status
            // 
            this.status.Controls.Add(this.tableLayoutPanel1);
            this.status.Location = new System.Drawing.Point(4, 22);
            this.status.Name = "status";
            this.status.Padding = new System.Windows.Forms.Padding(3);
            this.status.Size = new System.Drawing.Size(500, 430);
            this.status.TabIndex = 0;
            this.status.Text = "Status";
            this.status.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.MessageListView, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.richTextBox, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(494, 424);
            this.tableLayoutPanel1.TabIndex = 21;
            // 
            // MessageListView
            // 
            this.MessageListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Commands,
            this.LastStatus,
            this.TimeReceived,
            this.Count});
            this.tableLayoutPanel1.SetColumnSpan(this.MessageListView, 4);
            this.MessageListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MessageListView.GridLines = true;
            this.MessageListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem21,
            listViewItem22,
            listViewItem23,
            listViewItem24});
            this.MessageListView.LabelWrap = false;
            this.MessageListView.Location = new System.Drawing.Point(3, 3);
            this.MessageListView.Name = "MessageListView";
            this.tableLayoutPanel1.SetRowSpan(this.MessageListView, 2);
            this.MessageListView.Size = new System.Drawing.Size(488, 206);
            this.MessageListView.TabIndex = 0;
            this.MessageListView.UseCompatibleStateImageBehavior = false;
            this.MessageListView.View = System.Windows.Forms.View.Details;
            // 
            // Commands
            // 
            this.Commands.Text = "Column Header";
            this.Commands.Width = 120;
            // 
            // LastStatus
            // 
            this.LastStatus.Text = "Last Status";
            this.LastStatus.Width = 120;
            // 
            // TimeReceived
            // 
            this.TimeReceived.Text = "Time Received";
            this.TimeReceived.Width = 120;
            // 
            // Count
            // 
            this.Count.Text = "Count";
            this.Count.Width = 120;
            // 
            // richTextBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.richTextBox, 4);
            this.richTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox.Location = new System.Drawing.Point(3, 215);
            this.richTextBox.Name = "richTextBox";
            this.tableLayoutPanel1.SetRowSpan(this.richTextBox, 2);
            this.richTextBox.Size = new System.Drawing.Size(488, 206);
            this.richTextBox.TabIndex = 20;
            this.richTextBox.Text = "";
            // 
            // debug
            // 
            this.debug.Controls.Add(this.panel_tab2);
            this.debug.Location = new System.Drawing.Point(4, 22);
            this.debug.Name = "debug";
            this.debug.Padding = new System.Windows.Forms.Padding(3);
            this.debug.Size = new System.Drawing.Size(500, 430);
            this.debug.TabIndex = 1;
            this.debug.Text = "Debug";
            this.debug.UseVisualStyleBackColor = true;
            // 
            // timer_UpdateToServer
            // 
            this.timer_UpdateToServer.Interval = 450000;
            this.timer_UpdateToServer.Tick += new System.EventHandler(this.timer_UpdateToServer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 456);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Eezitracker";
            this.panel_tab2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.status.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.debug.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_write_RTC;
        private System.Windows.Forms.Button btn_read_rtc;
        private System.Windows.Forms.Button btn_clear_eeprom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel_tab2;
        private System.Windows.Forms.Button btn_dnwld_eeprom;
        private System.Windows.Forms.Button btn_OpenCom;
        private System.Windows.Forms.ComboBox comboBox_serialPorts;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Timer timer_Get_EEPROM;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage status;
        private System.Windows.Forms.TabPage debug;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ListView MessageListView;
        private System.Windows.Forms.ColumnHeader Commands;
        public System.Windows.Forms.ColumnHeader LastStatus;
        private System.Windows.Forms.ColumnHeader TimeReceived;
        private System.Windows.Forms.ColumnHeader Count;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RichTextBox richTextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Timer timer_UpdateToServer;
    }
}