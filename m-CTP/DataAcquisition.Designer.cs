
namespace m_CTP
{
    partial class DataAcquisition
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
            this.uiGroupBox2 = new Sunny.UI.UIGroupBox();
            this.Creat = new Sunny.UI.UIButton();
            this.plantName = new Sunny.UI.UITextBox();
            this.tbtaskName = new Sunny.UI.UITextBox();
            this.proName = new Sunny.UI.UITextBox();
            this.uiTextBox1 = new Sunny.UI.UITextBox();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.MeasureStart = new Sunny.UI.UIButton();
            this.MeasureStop = new Sunny.UI.UIButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.uiButton4 = new Sunny.UI.UIButton();
            this.uiButton5 = new Sunny.UI.UIButton();
            this.uiButton6 = new Sunny.UI.UIButton();
            this.uiButton7 = new Sunny.UI.UIButton();
            this.uiButton8 = new Sunny.UI.UIButton();
            this.Cali = new Sunny.UI.UIButton();
            this.uiGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiGroupBox2
            // 
            this.uiGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiGroupBox2.Controls.Add(this.Creat);
            this.uiGroupBox2.Controls.Add(this.plantName);
            this.uiGroupBox2.Controls.Add(this.tbtaskName);
            this.uiGroupBox2.Controls.Add(this.proName);
            this.uiGroupBox2.Controls.Add(this.uiTextBox1);
            this.uiGroupBox2.Controls.Add(this.uiLabel4);
            this.uiGroupBox2.Controls.Add(this.uiLabel3);
            this.uiGroupBox2.Controls.Add(this.uiLabel2);
            this.uiGroupBox2.Controls.Add(this.uiLabel1);
            this.uiGroupBox2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox2.Location = new System.Drawing.Point(4, 40);
            this.uiGroupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox2.Name = "uiGroupBox2";
            this.uiGroupBox2.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox2.Size = new System.Drawing.Size(846, 294);
            this.uiGroupBox2.TabIndex = 1;
            this.uiGroupBox2.Text = "测量预览";
            this.uiGroupBox2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Creat
            // 
            this.Creat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Creat.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Creat.Location = new System.Drawing.Point(326, 223);
            this.Creat.MinimumSize = new System.Drawing.Size(1, 1);
            this.Creat.Name = "Creat";
            this.Creat.Size = new System.Drawing.Size(119, 43);
            this.Creat.TabIndex = 13;
            this.Creat.Text = "开始任务";
            this.Creat.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Creat.Click += new System.EventHandler(this.Creat_Click);
            // 
            // plantName
            // 
            this.plantName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.plantName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.plantName.Location = new System.Drawing.Point(549, 132);
            this.plantName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.plantName.MinimumSize = new System.Drawing.Size(1, 16);
            this.plantName.Name = "plantName";
            this.plantName.Padding = new System.Windows.Forms.Padding(5);
            this.plantName.ShowText = false;
            this.plantName.Size = new System.Drawing.Size(230, 45);
            this.plantName.TabIndex = 9;
            this.plantName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.plantName.Watermark = "";
            // 
            // tbtaskName
            // 
            this.tbtaskName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbtaskName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbtaskName.Location = new System.Drawing.Point(549, 53);
            this.tbtaskName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbtaskName.MinimumSize = new System.Drawing.Size(1, 16);
            this.tbtaskName.Name = "tbtaskName";
            this.tbtaskName.Padding = new System.Windows.Forms.Padding(5);
            this.tbtaskName.ShowText = false;
            this.tbtaskName.Size = new System.Drawing.Size(230, 45);
            this.tbtaskName.TabIndex = 8;
            this.tbtaskName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.tbtaskName.Watermark = "";
            // 
            // proName
            // 
            this.proName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.proName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.proName.Location = new System.Drawing.Point(129, 132);
            this.proName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.proName.MinimumSize = new System.Drawing.Size(1, 16);
            this.proName.Name = "proName";
            this.proName.Padding = new System.Windows.Forms.Padding(5);
            this.proName.ShowText = false;
            this.proName.Size = new System.Drawing.Size(230, 45);
            this.proName.TabIndex = 7;
            this.proName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.proName.Watermark = "";
            // 
            // uiTextBox1
            // 
            this.uiTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTextBox1.Location = new System.Drawing.Point(129, 53);
            this.uiTextBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBox1.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTextBox1.Name = "uiTextBox1";
            this.uiTextBox1.Padding = new System.Windows.Forms.Padding(5);
            this.uiTextBox1.ShowText = false;
            this.uiTextBox1.Size = new System.Drawing.Size(230, 45);
            this.uiTextBox1.TabIndex = 6;
            this.uiTextBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTextBox1.Watermark = "";
            // 
            // uiLabel4
            // 
            this.uiLabel4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel4.Location = new System.Drawing.Point(428, 132);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(105, 45);
            this.uiLabel4.TabIndex = 3;
            this.uiLabel4.Text = "盆栽名称";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel3.Location = new System.Drawing.Point(423, 53);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(105, 45);
            this.uiLabel3.TabIndex = 2;
            this.uiLabel3.Text = "任务名称";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel2.Location = new System.Drawing.Point(3, 132);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(105, 45);
            this.uiLabel2.TabIndex = 1;
            this.uiLabel2.Text = "项目名称";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel1.Location = new System.Drawing.Point(3, 53);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(105, 45);
            this.uiLabel1.TabIndex = 0;
            this.uiLabel1.Text = "用户名称";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MeasureStart
            // 
            this.MeasureStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MeasureStart.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MeasureStart.Location = new System.Drawing.Point(102, 361);
            this.MeasureStart.MinimumSize = new System.Drawing.Size(1, 1);
            this.MeasureStart.Name = "MeasureStart";
            this.MeasureStart.Size = new System.Drawing.Size(200, 75);
            this.MeasureStart.TabIndex = 3;
            this.MeasureStart.Text = "开始采集";
            this.MeasureStart.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MeasureStart.Click += new System.EventHandler(this.MeasureStart_Click);
            // 
            // MeasureStop
            // 
            this.MeasureStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MeasureStop.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MeasureStop.Location = new System.Drawing.Point(505, 361);
            this.MeasureStop.MinimumSize = new System.Drawing.Size(1, 1);
            this.MeasureStop.Name = "MeasureStop";
            this.MeasureStop.Size = new System.Drawing.Size(200, 75);
            this.MeasureStop.TabIndex = 5;
            this.MeasureStop.Text = "停止采集";
            this.MeasureStop.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MeasureStop.Click += new System.EventHandler(this.MeasureStop_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // uiButton4
            // 
            this.uiButton4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton4.Location = new System.Drawing.Point(65, 542);
            this.uiButton4.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton4.Name = "uiButton4";
            this.uiButton4.Size = new System.Drawing.Size(71, 31);
            this.uiButton4.TabIndex = 8;
            this.uiButton4.Text = "rgb触发";
            this.uiButton4.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton4.Visible = false;
            this.uiButton4.Click += new System.EventHandler(this.uiButton4_Click);
            // 
            // uiButton5
            // 
            this.uiButton5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton5.Location = new System.Drawing.Point(55, 542);
            this.uiButton5.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton5.Name = "uiButton5";
            this.uiButton5.Size = new System.Drawing.Size(71, 31);
            this.uiButton5.TabIndex = 9;
            this.uiButton5.Text = "rgb保存";
            this.uiButton5.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton5.Visible = false;
            this.uiButton5.Click += new System.EventHandler(this.uiButton5_Click);
            // 
            // uiButton6
            // 
            this.uiButton6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton6.Location = new System.Drawing.Point(55, 542);
            this.uiButton6.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton6.Name = "uiButton6";
            this.uiButton6.Size = new System.Drawing.Size(71, 31);
            this.uiButton6.TabIndex = 10;
            this.uiButton6.Text = "depth保存";
            this.uiButton6.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton6.Visible = false;
            this.uiButton6.Click += new System.EventHandler(this.uiButton6_Click);
            // 
            // uiButton7
            // 
            this.uiButton7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton7.Location = new System.Drawing.Point(55, 542);
            this.uiButton7.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton7.Name = "uiButton7";
            this.uiButton7.Size = new System.Drawing.Size(71, 31);
            this.uiButton7.TabIndex = 11;
            this.uiButton7.Text = "高光谱开始";
            this.uiButton7.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton7.Visible = false;
            this.uiButton7.Click += new System.EventHandler(this.uiButton7_Click);
            // 
            // uiButton8
            // 
            this.uiButton8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton8.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton8.Location = new System.Drawing.Point(55, 542);
            this.uiButton8.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton8.Name = "uiButton8";
            this.uiButton8.Size = new System.Drawing.Size(71, 31);
            this.uiButton8.TabIndex = 12;
            this.uiButton8.Text = "高光谱停止";
            this.uiButton8.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton8.Visible = false;
            this.uiButton8.Click += new System.EventHandler(this.uiButton8_Click);
            // 
            // Cali
            // 
            this.Cali.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Cali.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Cali.Location = new System.Drawing.Point(330, 506);
            this.Cali.MinimumSize = new System.Drawing.Size(1, 1);
            this.Cali.Name = "Cali";
            this.Cali.Size = new System.Drawing.Size(119, 43);
            this.Cali.TabIndex = 14;
            this.Cali.Text = "参考板采集";
            this.Cali.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Cali.Click += new System.EventHandler(this.Cali_Click_1);
            // 
            // DataAcquisition
            // 
            this.AllowShowTitle = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(854, 596);
            this.Controls.Add(this.Cali);
            this.Controls.Add(this.uiButton8);
            this.Controls.Add(this.MeasureStop);
            this.Controls.Add(this.MeasureStart);
            this.Controls.Add(this.uiButton7);
            this.Controls.Add(this.uiGroupBox2);
            this.Controls.Add(this.uiButton6);
            this.Controls.Add(this.uiButton4);
            this.Controls.Add(this.uiButton5);
            this.Name = "DataAcquisition";
            this.Padding = new System.Windows.Forms.Padding(0, 35, 0, 0);
            this.ShowTitle = true;
            this.Text = "数据采集";
            this.Initialize += new System.EventHandler(this.DataAcquisition_Initialize);
            this.uiGroupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Sunny.UI.UIGroupBox uiGroupBox2;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UITextBox plantName;
        private Sunny.UI.UITextBox tbtaskName;
        private Sunny.UI.UITextBox proName;
        private Sunny.UI.UITextBox uiTextBox1;
        private Sunny.UI.UIButton MeasureStart;
        private Sunny.UI.UIButton MeasureStop;
        private System.Windows.Forms.Timer timer1;
        private Sunny.UI.UIButton uiButton4;
        private Sunny.UI.UIButton uiButton5;
        private Sunny.UI.UIButton uiButton6;
        private Sunny.UI.UIButton uiButton7;
        private Sunny.UI.UIButton uiButton8;
        private Sunny.UI.UIButton Creat;
        private Sunny.UI.UIButton Cali;
    }
}