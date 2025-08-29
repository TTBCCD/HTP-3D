namespace Sample
{
    partial class FrmSample14443
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.l_ConnAddr = new System.Windows.Forms.Label();
            this.cb_ConnAddr = new System.Windows.Forms.ComboBox();
            this.l_BaudPort = new System.Windows.Forms.Label();
            this.cb_BaudPort = new System.Windows.Forms.ComboBox();
            this.b_Connect = new System.Windows.Forms.Button();
            this.gb_RfidOper = new System.Windows.Forms.GroupBox();
            this.tb_ReadData = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.b_setProtocol = new System.Windows.Forms.Button();
            this.rb_14443A = new System.Windows.Forms.RadioButton();
            this.rb_15693 = new System.Windows.Forms.RadioButton();
            this.b_ReadRecord = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssl_status = new System.Windows.Forms.ToolStripStatusLabel();
            this.gb_RfidOper.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // l_ConnAddr
            // 
            this.l_ConnAddr.AutoSize = true;
            this.l_ConnAddr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F);
            this.l_ConnAddr.Location = new System.Drawing.Point(29, 42);
            this.l_ConnAddr.Name = "l_ConnAddr";
            this.l_ConnAddr.Size = new System.Drawing.Size(91, 22);
            this.l_ConnAddr.TabIndex = 18;
            this.l_ConnAddr.Text = "Address:  ";
            // 
            // cb_ConnAddr
            // 
            this.cb_ConnAddr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F);
            this.cb_ConnAddr.FormattingEnabled = true;
            this.cb_ConnAddr.Location = new System.Drawing.Point(132, 38);
            this.cb_ConnAddr.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cb_ConnAddr.Name = "cb_ConnAddr";
            this.cb_ConnAddr.Size = new System.Drawing.Size(162, 28);
            this.cb_ConnAddr.TabIndex = 19;
            this.cb_ConnAddr.Text = "192.168.0.10";
            // 
            // l_BaudPort
            // 
            this.l_BaudPort.AutoSize = true;
            this.l_BaudPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F);
            this.l_BaudPort.Location = new System.Drawing.Point(318, 42);
            this.l_BaudPort.Name = "l_BaudPort";
            this.l_BaudPort.Size = new System.Drawing.Size(48, 22);
            this.l_BaudPort.TabIndex = 20;
            this.l_BaudPort.Text = "Port:";
            // 
            // cb_BaudPort
            // 
            this.cb_BaudPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F);
            this.cb_BaudPort.FormattingEnabled = true;
            this.cb_BaudPort.Items.AddRange(new object[] {
            "115200"});
            this.cb_BaudPort.Location = new System.Drawing.Point(382, 38);
            this.cb_BaudPort.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cb_BaudPort.Name = "cb_BaudPort";
            this.cb_BaudPort.Size = new System.Drawing.Size(93, 28);
            this.cb_BaudPort.TabIndex = 22;
            this.cb_BaudPort.Text = "502";
            // 
            // b_Connect
            // 
            this.b_Connect.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F);
            this.b_Connect.Location = new System.Drawing.Point(553, 30);
            this.b_Connect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.b_Connect.Name = "b_Connect";
            this.b_Connect.Size = new System.Drawing.Size(130, 43);
            this.b_Connect.TabIndex = 23;
            this.b_Connect.Text = "Connect";
            this.b_Connect.UseVisualStyleBackColor = true;
            this.b_Connect.Click += new System.EventHandler(this.b_connect_Click);
            // 
            // gb_RfidOper
            // 
            this.gb_RfidOper.Controls.Add(this.tb_ReadData);
            this.gb_RfidOper.Controls.Add(this.groupBox1);
            this.gb_RfidOper.Controls.Add(this.b_ReadRecord);
            this.gb_RfidOper.Enabled = false;
            this.gb_RfidOper.Location = new System.Drawing.Point(22, 102);
            this.gb_RfidOper.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gb_RfidOper.Name = "gb_RfidOper";
            this.gb_RfidOper.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gb_RfidOper.Size = new System.Drawing.Size(680, 416);
            this.gb_RfidOper.TabIndex = 31;
            this.gb_RfidOper.TabStop = false;
            // 
            // tb_ReadData
            // 
            this.tb_ReadData.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F);
            this.tb_ReadData.Location = new System.Drawing.Point(19, 189);
            this.tb_ReadData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_ReadData.Multiline = true;
            this.tb_ReadData.Name = "tb_ReadData";
            this.tb_ReadData.Size = new System.Drawing.Size(643, 211);
            this.tb_ReadData.TabIndex = 33;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.b_setProtocol);
            this.groupBox1.Controls.Add(this.rb_14443A);
            this.groupBox1.Controls.Add(this.rb_15693);
            this.groupBox1.Location = new System.Drawing.Point(12, 22);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(649, 83);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            // 
            // b_setProtocol
            // 
            this.b_setProtocol.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F);
            this.b_setProtocol.Location = new System.Drawing.Point(519, 27);
            this.b_setProtocol.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.b_setProtocol.Name = "b_setProtocol";
            this.b_setProtocol.Size = new System.Drawing.Size(130, 45);
            this.b_setProtocol.TabIndex = 31;
            this.b_setProtocol.Text = "SET";
            this.b_setProtocol.UseVisualStyleBackColor = true;
            this.b_setProtocol.Click += new System.EventHandler(this.b_setProtocol_Click);
            // 
            // rb_14443A
            // 
            this.rb_14443A.AutoSize = true;
            this.rb_14443A.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F);
            this.rb_14443A.Location = new System.Drawing.Point(158, 37);
            this.rb_14443A.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rb_14443A.Name = "rb_14443A";
            this.rb_14443A.Size = new System.Drawing.Size(128, 26);
            this.rb_14443A.TabIndex = 1;
            this.rb_14443A.TabStop = true;
            this.rb_14443A.Text = "ISO 14443A";
            this.rb_14443A.UseVisualStyleBackColor = true;
            // 
            // rb_15693
            // 
            this.rb_15693.AutoSize = true;
            this.rb_15693.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F);
            this.rb_15693.Location = new System.Drawing.Point(19, 37);
            this.rb_15693.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rb_15693.Name = "rb_15693";
            this.rb_15693.Size = new System.Drawing.Size(116, 26);
            this.rb_15693.TabIndex = 0;
            this.rb_15693.TabStop = true;
            this.rb_15693.Text = "ISO 15693";
            this.rb_15693.UseVisualStyleBackColor = true;
            // 
            // b_ReadRecord
            // 
            this.b_ReadRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F);
            this.b_ReadRecord.Location = new System.Drawing.Point(532, 129);
            this.b_ReadRecord.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.b_ReadRecord.Name = "b_ReadRecord";
            this.b_ReadRecord.Size = new System.Drawing.Size(130, 45);
            this.b_ReadRecord.TabIndex = 32;
            this.b_ReadRecord.Text = "ReadRecord";
            this.b_ReadRecord.UseVisualStyleBackColor = true;
            this.b_ReadRecord.Click += new System.EventHandler(this.b_ReadRecord_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssl_status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 518);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 12, 0);
            this.statusStrip1.Size = new System.Drawing.Size(728, 26);
            this.statusStrip1.TabIndex = 33;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssl_status
            // 
            this.tssl_status.Name = "tssl_status";
            this.tssl_status.Size = new System.Drawing.Size(58, 20);
            this.tssl_status.Text = "Status:";
            // 
            // FrmSample14443
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 544);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.gb_RfidOper);
            this.Controls.Add(this.b_Connect);
            this.Controls.Add(this.l_ConnAddr);
            this.Controls.Add(this.cb_ConnAddr);
            this.Controls.Add(this.l_BaudPort);
            this.Controls.Add(this.cb_BaudPort);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmSample14443";
            this.Text = "Sample";
            this.Load += new System.EventHandler(this.FrmSample14443_Load);
            this.gb_RfidOper.ResumeLayout(false);
            this.gb_RfidOper.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label l_ConnAddr;
        private System.Windows.Forms.ComboBox cb_ConnAddr;
        private System.Windows.Forms.Label l_BaudPort;
        private System.Windows.Forms.ComboBox cb_BaudPort;
        private System.Windows.Forms.Button b_Connect;
        private System.Windows.Forms.GroupBox gb_RfidOper;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button b_setProtocol;
        private System.Windows.Forms.RadioButton rb_14443A;
        private System.Windows.Forms.RadioButton rb_15693;
        private System.Windows.Forms.TextBox tb_ReadData;
        private System.Windows.Forms.Button b_ReadRecord;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssl_status;
    }
}

