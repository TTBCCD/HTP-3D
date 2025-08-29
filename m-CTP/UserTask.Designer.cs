
namespace m_CTP
{
    partial class UserTask
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
            this.LEDTopON = new Sunny.UI.UIButton();
            this.uiGroupBox1 = new Sunny.UI.UIGroupBox();
            this.asLightOFF = new Sunny.UI.UIButton();
            this.LEDTopOFF = new Sunny.UI.UIButton();
            this.LEDBottomOFF = new Sunny.UI.UIButton();
            this.asLightON = new Sunny.UI.UIButton();
            this.LEDBottomON = new Sunny.UI.UIButton();
            this.uiGroupBox3 = new Sunny.UI.UIGroupBox();
            this.btUP = new Sunny.UI.UIButton();
            this.btDown = new Sunny.UI.UIButton();
            this.verticalGet = new Sunny.UI.UIButton();
            this.uiButton2 = new Sunny.UI.UIButton();
            this.uiLabel10 = new Sunny.UI.UILabel();
            this.verticalSet = new Sunny.UI.UIButton();
            this.RiseSpeed = new Sunny.UI.UITextBox();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.BwdDist = new Sunny.UI.UIGroupBox();
            this.uiTextBox2 = new Sunny.UI.UITextBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiButton3 = new Sunny.UI.UIButton();
            this.uiButton1 = new Sunny.UI.UIButton();
            this.horizontalGet = new Sunny.UI.UIButton();
            this.horizontalSet = new Sunny.UI.UIButton();
            this.uiLabel9 = new Sunny.UI.UILabel();
            this.RGBLocation = new Sunny.UI.UITextBox();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.uiLabel17 = new Sunny.UI.UILabel();
            this.FwdDist = new Sunny.UI.UITextBox();
            this.uiLabel8 = new Sunny.UI.UILabel();
            this.FwdSpeed = new Sunny.UI.UITextBox();
            this.uiLabel6 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiGroupBox1.SuspendLayout();
            this.uiGroupBox3.SuspendLayout();
            this.BwdDist.SuspendLayout();
            this.SuspendLayout();
            // 
            // LEDTopON
            // 
            this.LEDTopON.BackColor = System.Drawing.Color.White;
            this.LEDTopON.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LEDTopON.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LEDTopON.Location = new System.Drawing.Point(38, 78);
            this.LEDTopON.MinimumSize = new System.Drawing.Size(1, 1);
            this.LEDTopON.Name = "LEDTopON";
            this.LEDTopON.Size = new System.Drawing.Size(90, 60);
            this.LEDTopON.TabIndex = 0;
            this.LEDTopON.Text = "LED(上）";
            this.LEDTopON.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LEDTopON.Click += new System.EventHandler(this.LEDTopON_Click);
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiGroupBox1.Controls.Add(this.asLightOFF);
            this.uiGroupBox1.Controls.Add(this.LEDTopOFF);
            this.uiGroupBox1.Controls.Add(this.LEDBottomOFF);
            this.uiGroupBox1.Controls.Add(this.asLightON);
            this.uiGroupBox1.Controls.Add(this.LEDTopON);
            this.uiGroupBox1.Controls.Add(this.LEDBottomON);
            this.uiGroupBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox1.Location = new System.Drawing.Point(4, 351);
            this.uiGroupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox1.Size = new System.Drawing.Size(420, 244);
            this.uiGroupBox1.TabIndex = 4;
            this.uiGroupBox1.Text = "灯光设置";
            this.uiGroupBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // asLightOFF
            // 
            this.asLightOFF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.asLightOFF.Enabled = false;
            this.asLightOFF.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.asLightOFF.Location = new System.Drawing.Point(291, 144);
            this.asLightOFF.MinimumSize = new System.Drawing.Size(1, 1);
            this.asLightOFF.Name = "asLightOFF";
            this.asLightOFF.Size = new System.Drawing.Size(90, 60);
            this.asLightOFF.TabIndex = 19;
            this.asLightOFF.Text = "卤素灯关闭";
            this.asLightOFF.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.asLightOFF.Click += new System.EventHandler(this.asLightOFF_Click);
            // 
            // LEDTopOFF
            // 
            this.LEDTopOFF.BackColor = System.Drawing.Color.White;
            this.LEDTopOFF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LEDTopOFF.Enabled = false;
            this.LEDTopOFF.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LEDTopOFF.Location = new System.Drawing.Point(39, 144);
            this.LEDTopOFF.MinimumSize = new System.Drawing.Size(1, 1);
            this.LEDTopOFF.Name = "LEDTopOFF";
            this.LEDTopOFF.Size = new System.Drawing.Size(90, 60);
            this.LEDTopOFF.TabIndex = 17;
            this.LEDTopOFF.Text = "  LED（上）\r\n   关闭";
            this.LEDTopOFF.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LEDTopOFF.Click += new System.EventHandler(this.LEDTopOFF_Click);
            // 
            // LEDBottomOFF
            // 
            this.LEDBottomOFF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LEDBottomOFF.Enabled = false;
            this.LEDBottomOFF.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LEDBottomOFF.Location = new System.Drawing.Point(165, 144);
            this.LEDBottomOFF.MinimumSize = new System.Drawing.Size(1, 1);
            this.LEDBottomOFF.Name = "LEDBottomOFF";
            this.LEDBottomOFF.Size = new System.Drawing.Size(90, 60);
            this.LEDBottomOFF.TabIndex = 18;
            this.LEDBottomOFF.Text = "  LED（下）\r\n   关闭";
            this.LEDBottomOFF.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LEDBottomOFF.Click += new System.EventHandler(this.LEDBottomOFF_Click);
            // 
            // asLightON
            // 
            this.asLightON.Cursor = System.Windows.Forms.Cursors.Hand;
            this.asLightON.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.asLightON.Location = new System.Drawing.Point(290, 78);
            this.asLightON.MinimumSize = new System.Drawing.Size(1, 1);
            this.asLightON.Name = "asLightON";
            this.asLightON.Size = new System.Drawing.Size(90, 60);
            this.asLightON.TabIndex = 16;
            this.asLightON.Text = "卤素灯开启";
            this.asLightON.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.asLightON.Click += new System.EventHandler(this.asLightON_Click);
            // 
            // LEDBottomON
            // 
            this.LEDBottomON.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LEDBottomON.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LEDBottomON.Location = new System.Drawing.Point(164, 78);
            this.LEDBottomON.MinimumSize = new System.Drawing.Size(1, 1);
            this.LEDBottomON.Name = "LEDBottomON";
            this.LEDBottomON.Size = new System.Drawing.Size(90, 60);
            this.LEDBottomON.TabIndex = 0;
            this.LEDBottomON.Text = "  LED（侧）\r\n   开启";
            this.LEDBottomON.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LEDBottomON.Click += new System.EventHandler(this.LEDBottomON_Click);
            // 
            // uiGroupBox3
            // 
            this.uiGroupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiGroupBox3.Controls.Add(this.btUP);
            this.uiGroupBox3.Controls.Add(this.btDown);
            this.uiGroupBox3.Controls.Add(this.verticalGet);
            this.uiGroupBox3.Controls.Add(this.uiButton2);
            this.uiGroupBox3.Controls.Add(this.uiLabel10);
            this.uiGroupBox3.Controls.Add(this.verticalSet);
            this.uiGroupBox3.Controls.Add(this.RiseSpeed);
            this.uiGroupBox3.Controls.Add(this.uiLabel4);
            this.uiGroupBox3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox3.Location = new System.Drawing.Point(432, 40);
            this.uiGroupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox3.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox3.Name = "uiGroupBox3";
            this.uiGroupBox3.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox3.Size = new System.Drawing.Size(420, 301);
            this.uiGroupBox3.TabIndex = 6;
            this.uiGroupBox3.Text = "垂直滑台设置";
            this.uiGroupBox3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btUP
            // 
            this.btUP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btUP.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btUP.Location = new System.Drawing.Point(104, 199);
            this.btUP.MinimumSize = new System.Drawing.Size(1, 1);
            this.btUP.Name = "btUP";
            this.btUP.Size = new System.Drawing.Size(90, 60);
            this.btUP.TabIndex = 23;
            this.btUP.Text = "上升";
            this.btUP.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btUP.Click += new System.EventHandler(this.btUP_Click);
            // 
            // btDown
            // 
            this.btDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btDown.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btDown.Location = new System.Drawing.Point(231, 199);
            this.btDown.MinimumSize = new System.Drawing.Size(1, 1);
            this.btDown.Name = "btDown";
            this.btDown.Size = new System.Drawing.Size(90, 60);
            this.btDown.TabIndex = 22;
            this.btDown.Text = "下降";
            this.btDown.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btDown.Click += new System.EventHandler(this.btDown_Click);
            // 
            // verticalGet
            // 
            this.verticalGet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.verticalGet.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.verticalGet.Location = new System.Drawing.Point(308, 49);
            this.verticalGet.MinimumSize = new System.Drawing.Size(1, 1);
            this.verticalGet.Name = "verticalGet";
            this.verticalGet.Size = new System.Drawing.Size(73, 41);
            this.verticalGet.TabIndex = 21;
            this.verticalGet.Text = "读取速度";
            this.verticalGet.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.verticalGet.Visible = false;
            this.verticalGet.Click += new System.EventHandler(this.verticalGet_Click);
            // 
            // uiButton2
            // 
            this.uiButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton2.FillColor = System.Drawing.Color.Red;
            this.uiButton2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton2.Location = new System.Drawing.Point(336, 246);
            this.uiButton2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton2.Name = "uiButton2";
            this.uiButton2.Size = new System.Drawing.Size(70, 40);
            this.uiButton2.TabIndex = 22;
            this.uiButton2.Text = "  LED（侧）\r\n   控制";
            this.uiButton2.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton2.Click += new System.EventHandler(this.uiButton2_Click);
            // 
            // uiLabel10
            // 
            this.uiLabel10.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel10.Location = new System.Drawing.Point(256, 49);
            this.uiLabel10.Name = "uiLabel10";
            this.uiLabel10.Size = new System.Drawing.Size(46, 50);
            this.uiLabel10.TabIndex = 15;
            this.uiLabel10.Text = "m/s";
            this.uiLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // verticalSet
            // 
            this.verticalSet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.verticalSet.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.verticalSet.Location = new System.Drawing.Point(183, 118);
            this.verticalSet.MinimumSize = new System.Drawing.Size(1, 1);
            this.verticalSet.Name = "verticalSet";
            this.verticalSet.Size = new System.Drawing.Size(73, 41);
            this.verticalSet.TabIndex = 7;
            this.verticalSet.Text = "设置参数";
            this.verticalSet.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.verticalSet.Visible = false;
            this.verticalSet.Click += new System.EventHandler(this.verticalSet_Click);
            // 
            // RiseSpeed
            // 
            this.RiseSpeed.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.RiseSpeed.DoubleValue = 0.0273D;
            this.RiseSpeed.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RiseSpeed.Location = new System.Drawing.Point(137, 49);
            this.RiseSpeed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RiseSpeed.MinimumSize = new System.Drawing.Size(1, 16);
            this.RiseSpeed.Name = "RiseSpeed";
            this.RiseSpeed.Padding = new System.Windows.Forms.Padding(5);
            this.RiseSpeed.ReadOnly = true;
            this.RiseSpeed.ShowText = false;
            this.RiseSpeed.Size = new System.Drawing.Size(102, 50);
            this.RiseSpeed.TabIndex = 5;
            this.RiseSpeed.Text = "0.0273";
            this.RiseSpeed.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.RiseSpeed.Watermark = "";
            // 
            // uiLabel4
            // 
            this.uiLabel4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel4.Location = new System.Drawing.Point(23, 49);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(107, 50);
            this.uiLabel4.TabIndex = 4;
            this.uiLabel4.Text = "运行速度：";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel4.Click += new System.EventHandler(this.uiLabel4_Click);
            // 
            // BwdDist
            // 
            this.BwdDist.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BwdDist.Controls.Add(this.uiLabel2);
            this.BwdDist.Controls.Add(this.uiTextBox2);
            this.BwdDist.Controls.Add(this.uiLabel1);
            this.BwdDist.Controls.Add(this.uiButton3);
            this.BwdDist.Controls.Add(this.uiButton1);
            this.BwdDist.Controls.Add(this.horizontalGet);
            this.BwdDist.Controls.Add(this.horizontalSet);
            this.BwdDist.Controls.Add(this.uiLabel9);
            this.BwdDist.Controls.Add(this.RGBLocation);
            this.BwdDist.Controls.Add(this.uiLabel5);
            this.BwdDist.Controls.Add(this.uiLabel17);
            this.BwdDist.Controls.Add(this.FwdDist);
            this.BwdDist.Controls.Add(this.uiLabel8);
            this.BwdDist.Controls.Add(this.FwdSpeed);
            this.BwdDist.Controls.Add(this.uiLabel6);
            this.BwdDist.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BwdDist.Location = new System.Drawing.Point(4, 40);
            this.BwdDist.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BwdDist.MinimumSize = new System.Drawing.Size(1, 1);
            this.BwdDist.Name = "BwdDist";
            this.BwdDist.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.BwdDist.Size = new System.Drawing.Size(420, 301);
            this.BwdDist.TabIndex = 9;
            this.BwdDist.Text = "水平滑台设置";
            this.BwdDist.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiTextBox2
            // 
            this.uiTextBox2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox2.DoubleValue = 2D;
            this.uiTextBox2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTextBox2.IntValue = 2;
            this.uiTextBox2.Location = new System.Drawing.Point(148, 209);
            this.uiTextBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBox2.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTextBox2.Name = "uiTextBox2";
            this.uiTextBox2.Padding = new System.Windows.Forms.Padding(5);
            this.uiTextBox2.ShowText = false;
            this.uiTextBox2.Size = new System.Drawing.Size(102, 40);
            this.uiTextBox2.TabIndex = 20;
            this.uiTextBox2.Text = "2";
            this.uiTextBox2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiTextBox2.Watermark = "";
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel1.Location = new System.Drawing.Point(20, 209);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(121, 40);
            this.uiLabel1.TabIndex = 24;
            this.uiLabel1.Text = "高光谱拍摄数量";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiButton3
            // 
            this.uiButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton3.FillColor = System.Drawing.Color.Red;
            this.uiButton3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton3.Location = new System.Drawing.Point(337, 247);
            this.uiButton3.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton3.Name = "uiButton3";
            this.uiButton3.Size = new System.Drawing.Size(70, 40);
            this.uiButton3.TabIndex = 23;
            this.uiButton3.Text = "卤素灯\r\n 控制";
            this.uiButton3.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton3.Click += new System.EventHandler(this.uiButton3_Click);
            // 
            // uiButton1
            // 
            this.uiButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton1.FillColor = System.Drawing.Color.Red;
            this.uiButton1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton1.Location = new System.Drawing.Point(261, 246);
            this.uiButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Size = new System.Drawing.Size(70, 40);
            this.uiButton1.TabIndex = 20;
            this.uiButton1.Text = "  LED（上）\r\n    控制";
            this.uiButton1.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton1.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // horizontalGet
            // 
            this.horizontalGet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.horizontalGet.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.horizontalGet.Location = new System.Drawing.Point(309, 58);
            this.horizontalGet.MinimumSize = new System.Drawing.Size(1, 1);
            this.horizontalGet.Name = "horizontalGet";
            this.horizontalGet.Size = new System.Drawing.Size(73, 41);
            this.horizontalGet.TabIndex = 21;
            this.horizontalGet.Text = "读取速度";
            this.horizontalGet.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.horizontalGet.Visible = false;
            this.horizontalGet.Click += new System.EventHandler(this.horizontalGet_Click);
            // 
            // horizontalSet
            // 
            this.horizontalSet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.horizontalSet.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.horizontalSet.Location = new System.Drawing.Point(309, 144);
            this.horizontalSet.MinimumSize = new System.Drawing.Size(1, 1);
            this.horizontalSet.Name = "horizontalSet";
            this.horizontalSet.Size = new System.Drawing.Size(73, 48);
            this.horizontalSet.TabIndex = 8;
            this.horizontalSet.Text = "设置参数";
            this.horizontalSet.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.horizontalSet.Click += new System.EventHandler(this.horizontalSet_Click);
            // 
            // uiLabel9
            // 
            this.uiLabel9.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel9.Location = new System.Drawing.Point(257, 109);
            this.uiLabel9.Name = "uiLabel9";
            this.uiLabel9.Size = new System.Drawing.Size(23, 50);
            this.uiLabel9.TabIndex = 14;
            this.uiLabel9.Text = "m";
            this.uiLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RGBLocation
            // 
            this.RGBLocation.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.RGBLocation.DoubleValue = 0.45D;
            this.RGBLocation.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RGBLocation.Location = new System.Drawing.Point(148, 159);
            this.RGBLocation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RGBLocation.MinimumSize = new System.Drawing.Size(1, 16);
            this.RGBLocation.Name = "RGBLocation";
            this.RGBLocation.Padding = new System.Windows.Forms.Padding(5);
            this.RGBLocation.ShowText = false;
            this.RGBLocation.Size = new System.Drawing.Size(102, 40);
            this.RGBLocation.TabIndex = 19;
            this.RGBLocation.Text = "0.45";
            this.RGBLocation.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.RGBLocation.Watermark = "";
            // 
            // uiLabel5
            // 
            this.uiLabel5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel5.Location = new System.Drawing.Point(257, 49);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(46, 50);
            this.uiLabel5.TabIndex = 10;
            this.uiLabel5.Text = "m/s";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel17
            // 
            this.uiLabel17.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel17.Location = new System.Drawing.Point(20, 159);
            this.uiLabel17.Name = "uiLabel17";
            this.uiLabel17.Size = new System.Drawing.Size(107, 40);
            this.uiLabel17.TabIndex = 18;
            this.uiLabel17.Text = "RGB拍摄位置";
            this.uiLabel17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FwdDist
            // 
            this.FwdDist.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.FwdDist.DoubleValue = 0.9D;
            this.FwdDist.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FwdDist.Location = new System.Drawing.Point(148, 109);
            this.FwdDist.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FwdDist.MinimumSize = new System.Drawing.Size(1, 16);
            this.FwdDist.Name = "FwdDist";
            this.FwdDist.Padding = new System.Windows.Forms.Padding(5);
            this.FwdDist.ReadOnly = true;
            this.FwdDist.ShowText = false;
            this.FwdDist.Size = new System.Drawing.Size(102, 40);
            this.FwdDist.TabIndex = 12;
            this.FwdDist.Text = "0.9";
            this.FwdDist.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.FwdDist.Watermark = "";
            // 
            // uiLabel8
            // 
            this.uiLabel8.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel8.Location = new System.Drawing.Point(22, 109);
            this.uiLabel8.Name = "uiLabel8";
            this.uiLabel8.Size = new System.Drawing.Size(107, 40);
            this.uiLabel8.TabIndex = 11;
            this.uiLabel8.Text = "前进距离：";
            this.uiLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FwdSpeed
            // 
            this.FwdSpeed.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.FwdSpeed.DoubleValue = 0.0273D;
            this.FwdSpeed.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FwdSpeed.Location = new System.Drawing.Point(148, 59);
            this.FwdSpeed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FwdSpeed.MinimumSize = new System.Drawing.Size(1, 16);
            this.FwdSpeed.Name = "FwdSpeed";
            this.FwdSpeed.Padding = new System.Windows.Forms.Padding(5);
            this.FwdSpeed.ReadOnly = true;
            this.FwdSpeed.ShowText = false;
            this.FwdSpeed.Size = new System.Drawing.Size(102, 40);
            this.FwdSpeed.TabIndex = 9;
            this.FwdSpeed.Text = "0.0273";
            this.FwdSpeed.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.FwdSpeed.Watermark = "";
            // 
            // uiLabel6
            // 
            this.uiLabel6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel6.Location = new System.Drawing.Point(21, 58);
            this.uiLabel6.Name = "uiLabel6";
            this.uiLabel6.Size = new System.Drawing.Size(107, 41);
            this.uiLabel6.TabIndex = 8;
            this.uiLabel6.Text = "运行速度：";
            this.uiLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel6.Click += new System.EventHandler(this.uiLabel6_Click);
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel2.Location = new System.Drawing.Point(257, 154);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(23, 50);
            this.uiLabel2.TabIndex = 25;
            this.uiLabel2.Text = "m";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UserTask
            // 
            this.AllowShowTitle = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(854, 596);
            this.Controls.Add(this.BwdDist);
            this.Controls.Add(this.uiGroupBox3);
            this.Controls.Add(this.uiGroupBox1);
            this.Name = "UserTask";
            this.Padding = new System.Windows.Forms.Padding(0, 35, 0, 0);
            this.ShowTitle = true;
            this.Text = "参数设置";
            this.Initialize += new System.EventHandler(this.UserTask_Initialize);
            this.uiGroupBox1.ResumeLayout(false);
            this.uiGroupBox3.ResumeLayout(false);
            this.BwdDist.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIButton LEDTopON;
        private Sunny.UI.UIGroupBox uiGroupBox1;
        private Sunny.UI.UIGroupBox uiGroupBox3;
        private Sunny.UI.UITextBox RiseSpeed;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UIGroupBox BwdDist;
        private Sunny.UI.UIButton LEDBottomON;
        private Sunny.UI.UILabel uiLabel9;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UITextBox FwdDist;
        private Sunny.UI.UILabel uiLabel8;
        private Sunny.UI.UITextBox FwdSpeed;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UIButton horizontalSet;
        private Sunny.UI.UILabel uiLabel10;
        private Sunny.UI.UIButton asLightON;
        private Sunny.UI.UITextBox RGBLocation;
        private Sunny.UI.UILabel uiLabel17;
        private Sunny.UI.UIButton asLightOFF;
        private Sunny.UI.UIButton LEDTopOFF;
        private Sunny.UI.UIButton LEDBottomOFF;
        private Sunny.UI.UIButton verticalGet;
        private Sunny.UI.UIButton horizontalGet;
        private Sunny.UI.UIButton btUP;
        private Sunny.UI.UIButton btDown;
        private Sunny.UI.UIButton verticalSet;
        private Sunny.UI.UIButton uiButton3;
        private Sunny.UI.UIButton uiButton2;
        private Sunny.UI.UIButton uiButton1;
        private Sunny.UI.UITextBox uiTextBox2;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel2;
    }
}