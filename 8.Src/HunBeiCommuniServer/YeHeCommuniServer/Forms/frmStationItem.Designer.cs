namespace CommuniServer
{
    partial class frmStationItem
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.lblDeviceType = new System.Windows.Forms.Label();
            this.txtStationName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelByLocalPort = new System.Windows.Forms.Panel();
            this.numLocalPort = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.panelBylRemotePort = new System.Windows.Forms.Panel();
            this.numRemotePort = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.panelByIPAddress = new System.Windows.Forms.Panel();
            this.txtStationIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbDiscriminateMode = new System.Windows.Forms.ComboBox();
            this.ucSerialPortSetting1 = new CommuniServer.UCSerialPortSetting();
            this.rbSocket = new System.Windows.Forms.RadioButton();
            this.rbSerialPort = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbGroup = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelByLocalPort.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLocalPort)).BeginInit();
            this.panelBylRemotePort.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRemotePort)).BeginInit();
            this.panelByIPAddress.SuspendLayout();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(302, 306);
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(387, 306);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(455, 288);
            this.tabControl1.TabIndex = 28;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cmbGroup);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.txtRemark);
            this.tabPage1.Controls.Add(this.lblDeviceType);
            this.tabPage1.Controls.Add(this.txtStationName);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(447, 263);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "常规";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(89, 77);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtRemark.Size = new System.Drawing.Size(240, 69);
            this.txtRemark.TabIndex = 5;
            // 
            // lblDeviceType
            // 
            this.lblDeviceType.AutoSize = true;
            this.lblDeviceType.Location = new System.Drawing.Point(18, 27);
            this.lblDeviceType.Name = "lblDeviceType";
            this.lblDeviceType.Size = new System.Drawing.Size(65, 12);
            this.lblDeviceType.TabIndex = 0;
            this.lblDeviceType.Text = "站点名称：";
            // 
            // txtStationName
            // 
            this.txtStationName.Location = new System.Drawing.Point(89, 24);
            this.txtStationName.Name = "txtStationName";
            this.txtStationName.Size = new System.Drawing.Size(240, 21);
            this.txtStationName.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "备注：";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Controls.Add(this.ucSerialPortSetting1);
            this.tabPage2.Controls.Add(this.rbSocket);
            this.tabPage2.Controls.Add(this.rbSerialPort);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(447, 263);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "通讯";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelByLocalPort);
            this.panel1.Controls.Add(this.panelBylRemotePort);
            this.panel1.Controls.Add(this.panelByIPAddress);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmbDiscriminateMode);
            this.panel1.Location = new System.Drawing.Point(24, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(371, 66);
            this.panel1.TabIndex = 29;
            // 
            // panelByLocalPort
            // 
            this.panelByLocalPort.Controls.Add(this.numLocalPort);
            this.panelByLocalPort.Controls.Add(this.label3);
            this.panelByLocalPort.Location = new System.Drawing.Point(4, 30);
            this.panelByLocalPort.Name = "panelByLocalPort";
            this.panelByLocalPort.Size = new System.Drawing.Size(338, 25);
            this.panelByLocalPort.TabIndex = 27;
            // 
            // numLocalPort
            // 
            this.numLocalPort.Location = new System.Drawing.Point(85, 4);
            this.numLocalPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numLocalPort.Name = "numLocalPort";
            this.numLocalPort.Size = new System.Drawing.Size(237, 21);
            this.numLocalPort.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "本地端口：";
            // 
            // panelBylRemotePort
            // 
            this.panelBylRemotePort.Controls.Add(this.numRemotePort);
            this.panelBylRemotePort.Controls.Add(this.label4);
            this.panelBylRemotePort.Location = new System.Drawing.Point(4, 30);
            this.panelBylRemotePort.Name = "panelBylRemotePort";
            this.panelBylRemotePort.Size = new System.Drawing.Size(338, 25);
            this.panelBylRemotePort.TabIndex = 26;
            // 
            // numRemotePort
            // 
            this.numRemotePort.Location = new System.Drawing.Point(85, 4);
            this.numRemotePort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numRemotePort.Name = "numRemotePort";
            this.numRemotePort.Size = new System.Drawing.Size(240, 21);
            this.numRemotePort.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "远程端口：";
            // 
            // panelByIPAddress
            // 
            this.panelByIPAddress.Controls.Add(this.txtStationIP);
            this.panelByIPAddress.Controls.Add(this.label1);
            this.panelByIPAddress.Location = new System.Drawing.Point(4, 30);
            this.panelByIPAddress.Name = "panelByIPAddress";
            this.panelByIPAddress.Size = new System.Drawing.Size(338, 25);
            this.panelByIPAddress.TabIndex = 25;
            // 
            // txtStationIP
            // 
            this.txtStationIP.Location = new System.Drawing.Point(85, 3);
            this.txtStationIP.Name = "txtStationIP";
            this.txtStationIP.Size = new System.Drawing.Size(240, 21);
            this.txtStationIP.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "站点IP：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 21;
            this.label2.Text = "标识方式：";
            // 
            // cmbDiscriminateMode
            // 
            this.cmbDiscriminateMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDiscriminateMode.FormattingEnabled = true;
            this.cmbDiscriminateMode.Location = new System.Drawing.Point(89, 4);
            this.cmbDiscriminateMode.Name = "cmbDiscriminateMode";
            this.cmbDiscriminateMode.Size = new System.Drawing.Size(240, 20);
            this.cmbDiscriminateMode.TabIndex = 22;
            this.cmbDiscriminateMode.SelectedIndexChanged += new System.EventHandler(this.cmbDiscriminateMode_SelectedIndexChanged);
            // 
            // ucSerialPortSetting1
            // 
            this.ucSerialPortSetting1.Location = new System.Drawing.Point(31, 72);
            this.ucSerialPortSetting1.Name = "ucSerialPortSetting1";
            this.ucSerialPortSetting1.Size = new System.Drawing.Size(322, 164);
            this.ucSerialPortSetting1.TabIndex = 31;
            // 
            // rbSocket
            // 
            this.rbSocket.AutoSize = true;
            this.rbSocket.Checked = true;
            this.rbSocket.Location = new System.Drawing.Point(109, 34);
            this.rbSocket.Name = "rbSocket";
            this.rbSocket.Size = new System.Drawing.Size(71, 16);
            this.rbSocket.TabIndex = 30;
            this.rbSocket.TabStop = true;
            this.rbSocket.Text = "通过网络";
            this.rbSocket.UseVisualStyleBackColor = true;
            this.rbSocket.CheckedChanged += new System.EventHandler(this.rbSocket_CheckedChanged);
            // 
            // rbSerialPort
            // 
            this.rbSerialPort.AutoSize = true;
            this.rbSerialPort.Location = new System.Drawing.Point(109, 12);
            this.rbSerialPort.Name = "rbSerialPort";
            this.rbSerialPort.Size = new System.Drawing.Size(71, 16);
            this.rbSerialPort.TabIndex = 29;
            this.rbSerialPort.Text = "通过串口";
            this.rbSerialPort.UseVisualStyleBackColor = true;
            this.rbSerialPort.CheckedChanged += new System.EventHandler(this.rbSerialPort_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 28;
            this.label5.Text = "通讯方式：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 2;
            this.label7.Text = "分组：";
            // 
            // cmbGroup
            // 
            this.cmbGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGroup.FormattingEnabled = true;
            this.cmbGroup.Location = new System.Drawing.Point(89, 51);
            this.cmbGroup.Name = "cmbGroup";
            this.cmbGroup.Size = new System.Drawing.Size(240, 20);
            this.cmbGroup.TabIndex = 3;
            // 
            // frmStationItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 343);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmStationItem";
            this.Text = "站点";
            this.Load += new System.EventHandler(this.frmStationItem_Load);
            this.Controls.SetChildIndex(this.okButton, 0);
            this.Controls.SetChildIndex(this.cancelButton, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelByLocalPort.ResumeLayout(false);
            this.panelByLocalPort.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLocalPort)).EndInit();
            this.panelBylRemotePort.ResumeLayout(false);
            this.panelBylRemotePort.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRemotePort)).EndInit();
            this.panelByIPAddress.ResumeLayout(false);
            this.panelByIPAddress.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label lblDeviceType;
        private System.Windows.Forms.TextBox txtStationName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbDiscriminateMode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelByLocalPort;
        private System.Windows.Forms.NumericUpDown numLocalPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelByIPAddress;
        private System.Windows.Forms.TextBox txtStationIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelBylRemotePort;
        private System.Windows.Forms.NumericUpDown numRemotePort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rbSocket;
        private System.Windows.Forms.RadioButton rbSerialPort;
        private UCSerialPortSetting ucSerialPortSetting1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbGroup;
        private System.Windows.Forms.Label label7;
    }
}