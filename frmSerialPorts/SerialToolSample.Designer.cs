namespace frmSerialPorts
{
    partial class SerialToolSample
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
            this.cbox1BaudRate = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbox0PortName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblmsg0 = new System.Windows.Forms.Label();
            this.btn1Reset = new System.Windows.Forms.Button();
            this.btn0Open = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt0Rece = new System.Windows.Forms.TextBox();
            this.lbl2Get = new System.Windows.Forms.Label();
            this.chk1AutoNewLine = new System.Windows.Forms.CheckBox();
            this.chk0HexView = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbl2Send = new System.Windows.Forms.Label();
            this.txt1Send = new System.Windows.Forms.TextBox();
            this.chk3Auto = new System.Windows.Forms.CheckBox();
            this.chk2Hex = new System.Windows.Forms.CheckBox();
            this.btn2Send = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbox4StopBits = new System.Windows.Forms.ComboBox();
            this.cbox3Parity = new System.Windows.Forms.ComboBox();
            this.cbox2DataBits = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn5GetSalve = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbox1BaudRate
            // 
            this.cbox1BaudRate.FormattingEnabled = true;
            this.cbox1BaudRate.Location = new System.Drawing.Point(237, 14);
            this.cbox1BaudRate.Name = "cbox1BaudRate";
            this.cbox1BaudRate.Size = new System.Drawing.Size(102, 20);
            this.cbox1BaudRate.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(190, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "波特率:";
            // 
            // cbox0PortName
            // 
            this.cbox0PortName.FormattingEnabled = true;
            this.cbox0PortName.Location = new System.Drawing.Point(82, 14);
            this.cbox0PortName.Name = "cbox0PortName";
            this.cbox0PortName.Size = new System.Drawing.Size(102, 20);
            this.cbox0PortName.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "端口号：";
            // 
            // lblmsg0
            // 
            this.lblmsg0.AutoSize = true;
            this.lblmsg0.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblmsg0.ForeColor = System.Drawing.Color.Red;
            this.lblmsg0.Location = new System.Drawing.Point(351, 47);
            this.lblmsg0.Name = "lblmsg0";
            this.lblmsg0.Size = new System.Drawing.Size(33, 12);
            this.lblmsg0.TabIndex = 18;
            this.lblmsg0.Text = "flag";
            // 
            // btn1Reset
            // 
            this.btn1Reset.Location = new System.Drawing.Point(597, 14);
            this.btn1Reset.Name = "btn1Reset";
            this.btn1Reset.Size = new System.Drawing.Size(75, 50);
            this.btn1Reset.TabIndex = 17;
            this.btn1Reset.Text = "Reset";
            this.btn1Reset.UseVisualStyleBackColor = true;
            this.btn1Reset.Click += new System.EventHandler(this.btn1Reset_Click);
            // 
            // btn0Open
            // 
            this.btn0Open.Location = new System.Drawing.Point(516, 14);
            this.btn0Open.Name = "btn0Open";
            this.btn0Open.Size = new System.Drawing.Size(75, 50);
            this.btn0Open.TabIndex = 16;
            this.btn0Open.Text = "Open";
            this.btn0Open.UseVisualStyleBackColor = true;
            this.btn0Open.Click += new System.EventHandler(this.btn0Open_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt0Rece);
            this.groupBox1.Controls.Add(this.lbl2Get);
            this.groupBox1.Controls.Add(this.chk1AutoNewLine);
            this.groupBox1.Controls.Add(this.chk0HexView);
            this.groupBox1.Location = new System.Drawing.Point(31, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(693, 370);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data Received";
            // 
            // txt0Rece
            // 
            this.txt0Rece.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt0Rece.Location = new System.Drawing.Point(3, 17);
            this.txt0Rece.Multiline = true;
            this.txt0Rece.Name = "txt0Rece";
            this.txt0Rece.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt0Rece.Size = new System.Drawing.Size(687, 350);
            this.txt0Rece.TabIndex = 21;
            // 
            // lbl2Get
            // 
            this.lbl2Get.AutoSize = true;
            this.lbl2Get.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl2Get.ForeColor = System.Drawing.Color.Red;
            this.lbl2Get.Location = new System.Drawing.Point(499, 4);
            this.lbl2Get.Name = "lbl2Get";
            this.lbl2Get.Size = new System.Drawing.Size(40, 12);
            this.lbl2Get.TabIndex = 20;
            this.lbl2Get.Text = "Get:0";
            // 
            // chk1AutoNewLine
            // 
            this.chk1AutoNewLine.AutoSize = true;
            this.chk1AutoNewLine.Location = new System.Drawing.Point(178, 0);
            this.chk1AutoNewLine.Name = "chk1AutoNewLine";
            this.chk1AutoNewLine.Size = new System.Drawing.Size(96, 16);
            this.chk1AutoNewLine.TabIndex = 0;
            this.chk1AutoNewLine.Text = "Auto newline";
            this.chk1AutoNewLine.UseVisualStyleBackColor = true;
            this.chk1AutoNewLine.CheckedChanged += new System.EventHandler(this.chk1AutoNewLine_CheckedChanged);
            // 
            // chk0HexView
            // 
            this.chk0HexView.AutoSize = true;
            this.chk0HexView.Location = new System.Drawing.Point(94, 0);
            this.chk0HexView.Name = "chk0HexView";
            this.chk0HexView.Size = new System.Drawing.Size(72, 16);
            this.chk0HexView.TabIndex = 0;
            this.chk0HexView.Text = "Hex view";
            this.chk0HexView.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbl2Send);
            this.groupBox2.Controls.Add(this.txt1Send);
            this.groupBox2.Controls.Add(this.chk3Auto);
            this.groupBox2.Controls.Add(this.chk2Hex);
            this.groupBox2.Location = new System.Drawing.Point(34, 446);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(536, 62);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data Send";
            // 
            // lbl2Send
            // 
            this.lbl2Send.AutoSize = true;
            this.lbl2Send.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl2Send.ForeColor = System.Drawing.Color.Red;
            this.lbl2Send.Location = new System.Drawing.Point(456, 0);
            this.lbl2Send.Name = "lbl2Send";
            this.lbl2Send.Size = new System.Drawing.Size(47, 12);
            this.lbl2Send.TabIndex = 20;
            this.lbl2Send.Text = "Send:0";
            // 
            // txt1Send
            // 
            this.txt1Send.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt1Send.Location = new System.Drawing.Point(3, 17);
            this.txt1Send.Multiline = true;
            this.txt1Send.Name = "txt1Send";
            this.txt1Send.Size = new System.Drawing.Size(530, 42);
            this.txt1Send.TabIndex = 21;
            // 
            // chk3Auto
            // 
            this.chk3Auto.AutoSize = true;
            this.chk3Auto.Location = new System.Drawing.Point(119, 0);
            this.chk3Auto.Name = "chk3Auto";
            this.chk3Auto.Size = new System.Drawing.Size(48, 16);
            this.chk3Auto.TabIndex = 0;
            this.chk3Auto.Text = "Auto";
            this.chk3Auto.UseVisualStyleBackColor = true;
            // 
            // chk2Hex
            // 
            this.chk2Hex.AutoSize = true;
            this.chk2Hex.Location = new System.Drawing.Point(74, 0);
            this.chk2Hex.Name = "chk2Hex";
            this.chk2Hex.Size = new System.Drawing.Size(42, 16);
            this.chk2Hex.TabIndex = 0;
            this.chk2Hex.Text = "Hex";
            this.chk2Hex.UseVisualStyleBackColor = true;
            // 
            // btn2Send
            // 
            this.btn2Send.Location = new System.Drawing.Point(576, 463);
            this.btn2Send.Name = "btn2Send";
            this.btn2Send.Size = new System.Drawing.Size(74, 42);
            this.btn2Send.TabIndex = 21;
            this.btn2Send.Text = "Send";
            this.btn2Send.UseVisualStyleBackColor = true;
            this.btn2Send.Click += new System.EventHandler(this.btn2Send_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(351, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 27;
            this.label4.Text = "停止位：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(190, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 12);
            this.label6.TabIndex = 26;
            this.label6.Text = "校验位:";
            // 
            // cbox4StopBits
            // 
            this.cbox4StopBits.FormattingEnabled = true;
            this.cbox4StopBits.Location = new System.Drawing.Point(408, 14);
            this.cbox4StopBits.Name = "cbox4StopBits";
            this.cbox4StopBits.Size = new System.Drawing.Size(102, 20);
            this.cbox4StopBits.TabIndex = 25;
            // 
            // cbox3Parity
            // 
            this.cbox3Parity.FormattingEnabled = true;
            this.cbox3Parity.Location = new System.Drawing.Point(237, 44);
            this.cbox3Parity.Name = "cbox3Parity";
            this.cbox3Parity.Size = new System.Drawing.Size(102, 20);
            this.cbox3Parity.TabIndex = 24;
            // 
            // cbox2DataBits
            // 
            this.cbox2DataBits.FormattingEnabled = true;
            this.cbox2DataBits.Location = new System.Drawing.Point(82, 44);
            this.cbox2DataBits.Name = "cbox2DataBits";
            this.cbox2DataBits.Size = new System.Drawing.Size(102, 20);
            this.cbox2DataBits.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 22;
            this.label3.Text = "数据位：";
            // 
            // btn5GetSalve
            // 
            this.btn5GetSalve.Location = new System.Drawing.Point(656, 463);
            this.btn5GetSalve.Name = "btn5GetSalve";
            this.btn5GetSalve.Size = new System.Drawing.Size(74, 42);
            this.btn5GetSalve.TabIndex = 28;
            this.btn5GetSalve.Text = "GetSalve";
            this.btn5GetSalve.UseVisualStyleBackColor = true;
            this.btn5GetSalve.Click += new System.EventHandler(this.btn5GetSalve_Click);
            // 
            // SerialToolSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 520);
            this.Controls.Add(this.btn5GetSalve);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbox4StopBits);
            this.Controls.Add(this.cbox3Parity);
            this.Controls.Add(this.cbox2DataBits);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn2Send);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblmsg0);
            this.Controls.Add(this.btn1Reset);
            this.Controls.Add(this.btn0Open);
            this.Controls.Add(this.cbox1BaudRate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbox0PortName);
            this.Controls.Add(this.label1);
            this.Name = "SerialToolSample";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SerialToolSample";
            this.Load += new System.EventHandler(this.SerialToolSample_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbox1BaudRate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbox0PortName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblmsg0;
        private System.Windows.Forms.Button btn1Reset;
        private System.Windows.Forms.Button btn0Open;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl2Get;
        private System.Windows.Forms.CheckBox chk1AutoNewLine;
        private System.Windows.Forms.CheckBox chk0HexView;
        private System.Windows.Forms.TextBox txt0Rece;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chk3Auto;
        private System.Windows.Forms.CheckBox chk2Hex;
        private System.Windows.Forms.Label lbl2Send;
        private System.Windows.Forms.TextBox txt1Send;
        private System.Windows.Forms.Button btn2Send;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbox4StopBits;
        private System.Windows.Forms.ComboBox cbox3Parity;
        private System.Windows.Forms.ComboBox cbox2DataBits;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn5GetSalve;

    }
}