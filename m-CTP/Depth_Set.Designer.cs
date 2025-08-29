
namespace m_CTP
{
    partial class Depth_Set
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.uiTabControl1 = new Sunny.UI.UITabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.uiButton1 = new Sunny.UI.UIButton();
            this.bnSave = new Sunny.UI.UIButton();
            this.bnEnum = new Sunny.UI.UIButton();
            this.cbDevice = new Sunny.UI.UIComboBox();
            this.StopPreview = new Sunny.UI.UIButton();
            this.StartPreview = new Sunny.UI.UIButton();
            this.CloseHyper = new Sunny.UI.UIButton();
            this.OpenDepth = new Sunny.UI.UIButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.bnGet = new Sunny.UI.UIButton();
            this.bnSet = new Sunny.UI.UIButton();
            this.HyperSelectPath = new Sunny.UI.UIButton();
            this.HyperPath = new Sunny.UI.UITextBox();
            this.uiLabel6 = new Sunny.UI.UILabel();
            this.cbGain = new Sunny.UI.UITextBox();
            this.cbExposure = new Sunny.UI.UITextBox();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.uiLabel4 = new Sunny.UI.UILabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.uiTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Gainsboro;
            this.pictureBox1.Location = new System.Drawing.Point(3, 38);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(550, 550);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // uiTabControl1
            // 
            this.uiTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiTabControl1.Controls.Add(this.tabPage1);
            this.uiTabControl1.Controls.Add(this.tabPage2);
            this.uiTabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.uiTabControl1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTabControl1.ItemSize = new System.Drawing.Size(100, 40);
            this.uiTabControl1.Location = new System.Drawing.Point(559, 38);
            this.uiTabControl1.MainPage = "";
            this.uiTabControl1.Name = "uiTabControl1";
            this.uiTabControl1.SelectedIndex = 0;
            this.uiTabControl1.Size = new System.Drawing.Size(292, 550);
            this.uiTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.uiTabControl1.TabIndex = 13;
            this.uiTabControl1.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.uiButton1);
            this.tabPage1.Controls.Add(this.bnSave);
            this.tabPage1.Controls.Add(this.bnEnum);
            this.tabPage1.Controls.Add(this.cbDevice);
            this.tabPage1.Controls.Add(this.StopPreview);
            this.tabPage1.Controls.Add(this.StartPreview);
            this.tabPage1.Controls.Add(this.CloseHyper);
            this.tabPage1.Controls.Add(this.OpenDepth);
            this.tabPage1.Location = new System.Drawing.Point(0, 40);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(292, 510);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "相机控制";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // uiButton1
            // 
            this.uiButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton1.Location = new System.Drawing.Point(141, 343);
            this.uiButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Size = new System.Drawing.Size(131, 64);
            this.uiButton1.TabIndex = 7;
            this.uiButton1.Text = "软触发";
            this.uiButton1.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton1.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // bnSave
            // 
            this.bnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bnSave.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bnSave.Location = new System.Drawing.Point(4, 343);
            this.bnSave.MinimumSize = new System.Drawing.Size(1, 1);
            this.bnSave.Name = "bnSave";
            this.bnSave.Size = new System.Drawing.Size(131, 64);
            this.bnSave.TabIndex = 6;
            this.bnSave.Text = "保存图片";
            this.bnSave.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bnSave.Click += new System.EventHandler(this.bnSave_Click);
            // 
            // bnEnum
            // 
            this.bnEnum.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bnEnum.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bnEnum.Location = new System.Drawing.Point(69, 86);
            this.bnEnum.MinimumSize = new System.Drawing.Size(1, 1);
            this.bnEnum.Name = "bnEnum";
            this.bnEnum.Size = new System.Drawing.Size(143, 43);
            this.bnEnum.TabIndex = 5;
            this.bnEnum.Text = "搜索设备";
            this.bnEnum.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bnEnum.Click += new System.EventHandler(this.bnEnum_Click);
            // 
            // cbDevice
            // 
            this.cbDevice.DataSource = null;
            this.cbDevice.FillColor = System.Drawing.Color.White;
            this.cbDevice.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbDevice.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.cbDevice.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.cbDevice.Location = new System.Drawing.Point(4, 17);
            this.cbDevice.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbDevice.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbDevice.Name = "cbDevice";
            this.cbDevice.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbDevice.Size = new System.Drawing.Size(284, 44);
            this.cbDevice.SymbolSize = 24;
            this.cbDevice.TabIndex = 4;
            this.cbDevice.Text = "uiComboBox1";
            this.cbDevice.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbDevice.Watermark = "";
            // 
            // StopPreview
            // 
            this.StopPreview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.StopPreview.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StopPreview.Location = new System.Drawing.Point(140, 250);
            this.StopPreview.MinimumSize = new System.Drawing.Size(1, 1);
            this.StopPreview.Name = "StopPreview";
            this.StopPreview.Size = new System.Drawing.Size(131, 64);
            this.StopPreview.TabIndex = 3;
            this.StopPreview.Text = "停止预览";
            this.StopPreview.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StopPreview.Click += new System.EventHandler(this.StopPreview_Click);
            // 
            // StartPreview
            // 
            this.StartPreview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.StartPreview.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StartPreview.Location = new System.Drawing.Point(3, 250);
            this.StartPreview.MinimumSize = new System.Drawing.Size(1, 1);
            this.StartPreview.Name = "StartPreview";
            this.StartPreview.Size = new System.Drawing.Size(131, 64);
            this.StartPreview.TabIndex = 2;
            this.StartPreview.Text = "开始预览";
            this.StartPreview.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StartPreview.Click += new System.EventHandler(this.StartPreview_Click);
            // 
            // CloseHyper
            // 
            this.CloseHyper.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseHyper.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CloseHyper.Location = new System.Drawing.Point(140, 161);
            this.CloseHyper.MinimumSize = new System.Drawing.Size(1, 1);
            this.CloseHyper.Name = "CloseHyper";
            this.CloseHyper.Size = new System.Drawing.Size(131, 64);
            this.CloseHyper.TabIndex = 1;
            this.CloseHyper.Text = "关闭相机";
            this.CloseHyper.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CloseHyper.Click += new System.EventHandler(this.CloseDepth_Click);
            // 
            // OpenDepth
            // 
            this.OpenDepth.Cursor = System.Windows.Forms.Cursors.Hand;
            this.OpenDepth.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.OpenDepth.Location = new System.Drawing.Point(3, 161);
            this.OpenDepth.MinimumSize = new System.Drawing.Size(1, 1);
            this.OpenDepth.Name = "OpenDepth";
            this.OpenDepth.Size = new System.Drawing.Size(131, 64);
            this.OpenDepth.TabIndex = 0;
            this.OpenDepth.Text = "打开相机";
            this.OpenDepth.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.OpenDepth.Click += new System.EventHandler(this.OpenDepth_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.bnGet);
            this.tabPage2.Controls.Add(this.bnSet);
            this.tabPage2.Controls.Add(this.HyperSelectPath);
            this.tabPage2.Controls.Add(this.HyperPath);
            this.tabPage2.Controls.Add(this.uiLabel6);
            this.tabPage2.Controls.Add(this.cbGain);
            this.tabPage2.Controls.Add(this.cbExposure);
            this.tabPage2.Controls.Add(this.uiLabel5);
            this.tabPage2.Controls.Add(this.uiLabel4);
            this.tabPage2.Location = new System.Drawing.Point(0, 40);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(292, 510);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "相机设置";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // bnGet
            // 
            this.bnGet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bnGet.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bnGet.Location = new System.Drawing.Point(160, 168);
            this.bnGet.MinimumSize = new System.Drawing.Size(1, 1);
            this.bnGet.Name = "bnGet";
            this.bnGet.Size = new System.Drawing.Size(128, 56);
            this.bnGet.TabIndex = 11;
            this.bnGet.Text = "获取参数";
            this.bnGet.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bnGet.Click += new System.EventHandler(this.bnGet_Click);
            // 
            // bnSet
            // 
            this.bnSet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bnSet.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bnSet.Location = new System.Drawing.Point(9, 168);
            this.bnSet.MinimumSize = new System.Drawing.Size(1, 1);
            this.bnSet.Name = "bnSet";
            this.bnSet.Size = new System.Drawing.Size(128, 56);
            this.bnSet.TabIndex = 10;
            this.bnSet.Text = "设置参数";
            this.bnSet.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bnSet.Click += new System.EventHandler(this.SaveSet_Click);
            // 
            // HyperSelectPath
            // 
            this.HyperSelectPath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HyperSelectPath.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.HyperSelectPath.Location = new System.Drawing.Point(82, 394);
            this.HyperSelectPath.MinimumSize = new System.Drawing.Size(1, 1);
            this.HyperSelectPath.Name = "HyperSelectPath";
            this.HyperSelectPath.Size = new System.Drawing.Size(128, 56);
            this.HyperSelectPath.TabIndex = 9;
            this.HyperSelectPath.Text = "选择路径";
            this.HyperSelectPath.TipsFont = new System.Drawing.Font("宋体", 6.375F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.HyperSelectPath.Click += new System.EventHandler(this.HyperSelectPath_Click);
            // 
            // HyperPath
            // 
            this.HyperPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HyperPath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.HyperPath.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.HyperPath.Location = new System.Drawing.Point(9, 331);
            this.HyperPath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.HyperPath.MinimumSize = new System.Drawing.Size(1, 16);
            this.HyperPath.Name = "HyperPath";
            this.HyperPath.Padding = new System.Windows.Forms.Padding(5);
            this.HyperPath.ShowText = false;
            this.HyperPath.Size = new System.Drawing.Size(279, 42);
            this.HyperPath.TabIndex = 6;
            this.HyperPath.Text = "C:\\Users\\SF\\Desktop\\test";
            this.HyperPath.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.HyperPath.Watermark = "";
            // 
            // uiLabel6
            // 
            this.uiLabel6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel6.Location = new System.Drawing.Point(3, 285);
            this.uiLabel6.Name = "uiLabel6";
            this.uiLabel6.Size = new System.Drawing.Size(232, 41);
            this.uiLabel6.TabIndex = 8;
            this.uiLabel6.Text = "存储路径：";
            this.uiLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbGain
            // 
            this.cbGain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbGain.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.cbGain.DoubleValue = 20D;
            this.cbGain.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbGain.IntValue = 20;
            this.cbGain.Location = new System.Drawing.Point(158, 98);
            this.cbGain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbGain.MinimumSize = new System.Drawing.Size(1, 16);
            this.cbGain.Name = "cbGain";
            this.cbGain.Padding = new System.Windows.Forms.Padding(5);
            this.cbGain.ShowText = false;
            this.cbGain.Size = new System.Drawing.Size(93, 42);
            this.cbGain.TabIndex = 5;
            this.cbGain.Text = "20";
            this.cbGain.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbGain.Watermark = "";
            // 
            // cbExposure
            // 
            this.cbExposure.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbExposure.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.cbExposure.DoubleValue = 30000D;
            this.cbExposure.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbExposure.IntValue = 30000;
            this.cbExposure.Location = new System.Drawing.Point(158, 32);
            this.cbExposure.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbExposure.MinimumSize = new System.Drawing.Size(1, 16);
            this.cbExposure.Name = "cbExposure";
            this.cbExposure.Padding = new System.Windows.Forms.Padding(5);
            this.cbExposure.ShowText = false;
            this.cbExposure.Size = new System.Drawing.Size(93, 42);
            this.cbExposure.TabIndex = 4;
            this.cbExposure.Text = "30000";
            this.cbExposure.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbExposure.Watermark = "";
            // 
            // uiLabel5
            // 
            this.uiLabel5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel5.Location = new System.Drawing.Point(25, 99);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(110, 41);
            this.uiLabel5.TabIndex = 7;
            this.uiLabel5.Text = "增益";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel4
            // 
            this.uiLabel4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel4.Location = new System.Drawing.Point(25, 33);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(110, 41);
            this.uiLabel4.TabIndex = 6;
            this.uiLabel4.Text = "曝光时间";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Depth_Set
            // 
            this.AllowShowTitle = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(854, 596);
            this.Controls.Add(this.uiTabControl1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "Depth_Set";
            this.Padding = new System.Windows.Forms.Padding(0, 35, 0, 0);
            this.ShowTitle = true;
            this.Text = "深度相机";
            this.TitleFont = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Initialize += new System.EventHandler(this.Hyper_Set_Initialize);
            this.Load += new System.EventHandler(this.Hyper_Set_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.uiTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        //dehui 修改Picturebox1访问级别
        private System.Windows.Forms.PictureBox pictureBox1;
        private Sunny.UI.UITabControl uiTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private Sunny.UI.UIButton StopPreview;
        private Sunny.UI.UIButton StartPreview;
        private Sunny.UI.UIButton CloseHyper;
        private Sunny.UI.UIButton OpenDepth;
        private System.Windows.Forms.TabPage tabPage2;
        private Sunny.UI.UITextBox cbGain;
        private Sunny.UI.UITextBox cbExposure;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UIButton bnSet;
        private Sunny.UI.UIButton HyperSelectPath;
        private Sunny.UI.UITextBox HyperPath;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UIComboBox cbDevice;
        private Sunny.UI.UIButton bnEnum;
        private Sunny.UI.UIButton bnGet;
        private Sunny.UI.UIButton bnSave;
        private Sunny.UI.UIButton uiButton1;
    }
}