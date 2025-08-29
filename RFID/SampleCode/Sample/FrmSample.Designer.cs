namespace Sample
{
    partial class FrmSample
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
            this.b_Write = new System.Windows.Forms.Button();
            this.l_ReadAddr = new System.Windows.Forms.Label();
            this.tb_ReadAddr = new System.Windows.Forms.TextBox();
            this.l_ReadCnt = new System.Windows.Forms.Label();
            this.tb_ReadCnt = new System.Windows.Forms.TextBox();
            this.b_Read = new System.Windows.Forms.Button();
            this.tb_ReadData = new System.Windows.Forms.TextBox();
            this.gb_RfidOper = new System.Windows.Forms.GroupBox();
            this.cb_uhf = new System.Windows.Forms.CheckBox();
            this.rb_rw_epc = new System.Windows.Forms.RadioButton();
            this.rb_rw_user = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.gb_RfidOper.SuspendLayout();
            this.SuspendLayout();
            // 
            // l_ConnAddr
            // 
            this.l_ConnAddr.AutoSize = true;
            this.l_ConnAddr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F);
            this.l_ConnAddr.Location = new System.Drawing.Point(25, 42);
            this.l_ConnAddr.Name = "l_ConnAddr";
            this.l_ConnAddr.Size = new System.Drawing.Size(91, 22);
            this.l_ConnAddr.TabIndex = 18;
            this.l_ConnAddr.Text = "Address:  ";
            this.l_ConnAddr.Click += new System.EventHandler(this.l_ConnAddr_Click);
            // 
            // cb_ConnAddr
            // 
            this.cb_ConnAddr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F);
            this.cb_ConnAddr.FormattingEnabled = true;
            this.cb_ConnAddr.Location = new System.Drawing.Point(127, 38);
            this.cb_ConnAddr.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cb_ConnAddr.Name = "cb_ConnAddr";
            this.cb_ConnAddr.Size = new System.Drawing.Size(162, 28);
            this.cb_ConnAddr.TabIndex = 19;
            this.cb_ConnAddr.Text = "192.168.0.10";
            this.cb_ConnAddr.SelectedIndexChanged += new System.EventHandler(this.cb_ConnAddr_SelectedIndexChanged);
            // 
            // l_BaudPort
            // 
            this.l_BaudPort.AutoSize = true;
            this.l_BaudPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F);
            this.l_BaudPort.Location = new System.Drawing.Point(314, 42);
            this.l_BaudPort.Name = "l_BaudPort";
            this.l_BaudPort.Size = new System.Drawing.Size(48, 22);
            this.l_BaudPort.TabIndex = 20;
            this.l_BaudPort.Text = "Port:";
            this.l_BaudPort.Click += new System.EventHandler(this.l_BaudPort_Click);
            // 
            // cb_BaudPort
            // 
            this.cb_BaudPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F);
            this.cb_BaudPort.FormattingEnabled = true;
            this.cb_BaudPort.Items.AddRange(new object[] {
            "115200"});
            this.cb_BaudPort.Location = new System.Drawing.Point(378, 38);
            this.cb_BaudPort.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cb_BaudPort.Name = "cb_BaudPort";
            this.cb_BaudPort.Size = new System.Drawing.Size(93, 28);
            this.cb_BaudPort.TabIndex = 22;
            this.cb_BaudPort.Text = "502";
            this.cb_BaudPort.SelectedIndexChanged += new System.EventHandler(this.cb_BaudPort_SelectedIndexChanged);
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
            // b_Write
            // 
            this.b_Write.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F);
            this.b_Write.Location = new System.Drawing.Point(533, 232);
            this.b_Write.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.b_Write.Name = "b_Write";
            this.b_Write.Size = new System.Drawing.Size(130, 45);
            this.b_Write.TabIndex = 29;
            this.b_Write.Text = "Write";
            this.b_Write.UseVisualStyleBackColor = true;
            this.b_Write.Click += new System.EventHandler(this.b_Write_Click);
            // 
            // l_ReadAddr
            // 
            this.l_ReadAddr.AutoSize = true;
            this.l_ReadAddr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F);
            this.l_ReadAddr.Location = new System.Drawing.Point(14, 80);
            this.l_ReadAddr.Name = "l_ReadAddr";
            this.l_ReadAddr.Size = new System.Drawing.Size(131, 22);
            this.l_ReadAddr.TabIndex = 24;
            this.l_ReadAddr.Text = "Address(Word)";
            // 
            // tb_ReadAddr
            // 
            this.tb_ReadAddr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F);
            this.tb_ReadAddr.Location = new System.Drawing.Point(158, 83);
            this.tb_ReadAddr.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_ReadAddr.Name = "tb_ReadAddr";
            this.tb_ReadAddr.Size = new System.Drawing.Size(89, 27);
            this.tb_ReadAddr.TabIndex = 26;
            this.tb_ReadAddr.Text = "0";
            // 
            // l_ReadCnt
            // 
            this.l_ReadCnt.AutoSize = true;
            this.l_ReadCnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F);
            this.l_ReadCnt.Location = new System.Drawing.Point(252, 80);
            this.l_ReadCnt.Name = "l_ReadCnt";
            this.l_ReadCnt.Size = new System.Drawing.Size(128, 22);
            this.l_ReadCnt.TabIndex = 25;
            this.l_ReadCnt.Text = "Number(Word)";
            // 
            // tb_ReadCnt
            // 
            this.tb_ReadCnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F);
            this.tb_ReadCnt.Location = new System.Drawing.Point(393, 83);
            this.tb_ReadCnt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_ReadCnt.Name = "tb_ReadCnt";
            this.tb_ReadCnt.Size = new System.Drawing.Size(89, 27);
            this.tb_ReadCnt.TabIndex = 27;
            this.tb_ReadCnt.Text = "8";
            // 
            // b_Read
            // 
            this.b_Read.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F);
            this.b_Read.Location = new System.Drawing.Point(533, 134);
            this.b_Read.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.b_Read.Name = "b_Read";
            this.b_Read.Size = new System.Drawing.Size(130, 45);
            this.b_Read.TabIndex = 28;
            this.b_Read.Text = "Read";
            this.b_Read.UseVisualStyleBackColor = true;
            this.b_Read.Click += new System.EventHandler(this.b_Read_Click);
            // 
            // tb_ReadData
            // 
            this.tb_ReadData.Location = new System.Drawing.Point(9, 134);
            this.tb_ReadData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_ReadData.Multiline = true;
            this.tb_ReadData.Name = "tb_ReadData";
            this.tb_ReadData.Size = new System.Drawing.Size(473, 214);
            this.tb_ReadData.TabIndex = 30;
            // 
            // gb_RfidOper
            // 
            this.gb_RfidOper.Controls.Add(this.textBox1);
            this.gb_RfidOper.Controls.Add(this.button1);
            this.gb_RfidOper.Controls.Add(this.cb_uhf);
            this.gb_RfidOper.Controls.Add(this.rb_rw_epc);
            this.gb_RfidOper.Controls.Add(this.rb_rw_user);
            this.gb_RfidOper.Controls.Add(this.l_ReadAddr);
            this.gb_RfidOper.Controls.Add(this.tb_ReadData);
            this.gb_RfidOper.Controls.Add(this.b_Read);
            this.gb_RfidOper.Controls.Add(this.b_Write);
            this.gb_RfidOper.Controls.Add(this.tb_ReadCnt);
            this.gb_RfidOper.Controls.Add(this.l_ReadCnt);
            this.gb_RfidOper.Controls.Add(this.tb_ReadAddr);
            this.gb_RfidOper.Enabled = false;
            this.gb_RfidOper.Location = new System.Drawing.Point(11, 112);
            this.gb_RfidOper.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gb_RfidOper.Name = "gb_RfidOper";
            this.gb_RfidOper.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gb_RfidOper.Size = new System.Drawing.Size(680, 410);
            this.gb_RfidOper.TabIndex = 31;
            this.gb_RfidOper.TabStop = false;
            // 
            // cb_uhf
            // 
            this.cb_uhf.AutoSize = true;
            this.cb_uhf.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F);
            this.cb_uhf.Location = new System.Drawing.Point(19, 27);
            this.cb_uhf.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cb_uhf.Name = "cb_uhf";
            this.cb_uhf.Size = new System.Drawing.Size(69, 26);
            this.cb_uhf.TabIndex = 33;
            this.cb_uhf.Text = "UHF";
            this.cb_uhf.UseVisualStyleBackColor = true;
            this.cb_uhf.CheckedChanged += new System.EventHandler(this.cb_uhf_CheckedChanged);
            // 
            // rb_rw_epc
            // 
            this.rb_rw_epc.AutoSize = true;
            this.rb_rw_epc.Enabled = false;
            this.rb_rw_epc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F);
            this.rb_rw_epc.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rb_rw_epc.Location = new System.Drawing.Point(265, 27);
            this.rb_rw_epc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rb_rw_epc.Name = "rb_rw_epc";
            this.rb_rw_epc.Size = new System.Drawing.Size(68, 26);
            this.rb_rw_epc.TabIndex = 32;
            this.rb_rw_epc.Text = "EPC";
            this.rb_rw_epc.UseVisualStyleBackColor = true;
            // 
            // rb_rw_user
            // 
            this.rb_rw_user.AutoSize = true;
            this.rb_rw_user.Enabled = false;
            this.rb_rw_user.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F);
            this.rb_rw_user.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rb_rw_user.Location = new System.Drawing.Point(108, 27);
            this.rb_rw_user.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rb_rw_user.Name = "rb_rw_user";
            this.rb_rw_user.Size = new System.Drawing.Size(135, 26);
            this.rb_rw_user.TabIndex = 31;
            this.rb_rw_user.Text = "USER DATA";
            this.rb_rw_user.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F);
            this.button1.Location = new System.Drawing.Point(533, 57);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 45);
            this.button1.TabIndex = 34;
            this.button1.Text = "转换";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(346, 27);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(179, 28);
            this.textBox1.TabIndex = 35;
            // 
            // FrmSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 557);
            this.Controls.Add(this.gb_RfidOper);
            this.Controls.Add(this.b_Connect);
            this.Controls.Add(this.l_ConnAddr);
            this.Controls.Add(this.cb_ConnAddr);
            this.Controls.Add(this.l_BaudPort);
            this.Controls.Add(this.cb_BaudPort);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmSample";
            this.Text = "Sample";
            this.gb_RfidOper.ResumeLayout(false);
            this.gb_RfidOper.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label l_ConnAddr;
        private System.Windows.Forms.ComboBox cb_ConnAddr;
        private System.Windows.Forms.Label l_BaudPort;
        private System.Windows.Forms.ComboBox cb_BaudPort;
        private System.Windows.Forms.Button b_Connect;
        private System.Windows.Forms.Button b_Write;
        private System.Windows.Forms.Label l_ReadAddr;
        private System.Windows.Forms.TextBox tb_ReadAddr;
        private System.Windows.Forms.Label l_ReadCnt;
        private System.Windows.Forms.TextBox tb_ReadCnt;
        private System.Windows.Forms.Button b_Read;
        private System.Windows.Forms.TextBox tb_ReadData;
        private System.Windows.Forms.GroupBox gb_RfidOper;
        private System.Windows.Forms.CheckBox cb_uhf;
        private System.Windows.Forms.RadioButton rb_rw_epc;
        private System.Windows.Forms.RadioButton rb_rw_user;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
    }
}

