
namespace m_CTP
{
    partial class Hyper_Set
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
            this.LightControl = new Sunny.UI.UIButton();
            this.R_acquisition = new Sunny.UI.UIButton();
            this.StopCollection = new Sunny.UI.UIButton();
            this.StartCollection = new Sunny.UI.UIButton();
            this.StopPreview = new Sunny.UI.UIButton();
            this.StartPreview = new Sunny.UI.UIButton();
            this.CloseHyper = new Sunny.UI.UIButton();
            this.OpenHyper = new Sunny.UI.UIButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiTextBox1 = new Sunny.UI.UITextBox();
            this.GainLevel = new Sunny.UI.UITextBox();
            this.Gain = new Sunny.UI.UITextBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.SaveSet = new Sunny.UI.UIButton();
            this.HyperSelectPath = new Sunny.UI.UIButton();
            this.HyperPath = new Sunny.UI.UITextBox();
            this.uiLabel6 = new Sunny.UI.UILabel();
            this.HyperFrameRate = new Sunny.UI.UITextBox();
            this.HyperExposureTime = new Sunny.UI.UITextBox();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.uiButton1 = new Sunny.UI.UIButton();
            this.uiButton2 = new Sunny.UI.UIButton();
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
            this.pictureBox1.Size = new System.Drawing.Size(497, 480);
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
            this.uiTabControl1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTabControl1.ItemSize = new System.Drawing.Size(150, 40);
            this.uiTabControl1.Location = new System.Drawing.Point(506, 38);
            this.uiTabControl1.MainPage = "";
            this.uiTabControl1.Name = "uiTabControl1";
            this.uiTabControl1.SelectedIndex = 0;
            this.uiTabControl1.Size = new System.Drawing.Size(345, 480);
            this.uiTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.uiTabControl1.TabIndex = 13;
            this.uiTabControl1.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.LightControl);
            this.tabPage1.Controls.Add(this.R_acquisition);
            this.tabPage1.Controls.Add(this.StopCollection);
            this.tabPage1.Controls.Add(this.StartCollection);
            this.tabPage1.Controls.Add(this.StopPreview);
            this.tabPage1.Controls.Add(this.StartPreview);
            this.tabPage1.Controls.Add(this.CloseHyper);
            this.tabPage1.Controls.Add(this.OpenHyper);
            this.tabPage1.Location = new System.Drawing.Point(0, 40);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(345, 440);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "相机控制";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // LightControl
            // 
            this.LightControl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LightControl.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LightControl.Location = new System.Drawing.Point(178, 348);
            this.LightControl.MinimumSize = new System.Drawing.Size(1, 1);
            this.LightControl.Name = "LightControl";
            this.LightControl.Size = new System.Drawing.Size(131, 64);
            this.LightControl.TabIndex = 7;
            this.LightControl.Text = "打开光源";
            this.LightControl.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LightControl.Click += new System.EventHandler(this.LightControl_Click);
            // 
            // R_acquisition
            // 
            this.R_acquisition.Cursor = System.Windows.Forms.Cursors.Hand;
            this.R_acquisition.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.R_acquisition.Location = new System.Drawing.Point(13, 348);
            this.R_acquisition.MinimumSize = new System.Drawing.Size(1, 1);
            this.R_acquisition.Name = "R_acquisition";
            this.R_acquisition.Size = new System.Drawing.Size(131, 64);
            this.R_acquisition.TabIndex = 6;
            this.R_acquisition.Text = "采集参考板";
            this.R_acquisition.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.R_acquisition.Click += new System.EventHandler(this.R_acquisition_Click);
            // 
            // StopCollection
            // 
            this.StopCollection.Cursor = System.Windows.Forms.Cursors.Hand;
            this.StopCollection.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StopCollection.Location = new System.Drawing.Point(178, 247);
            this.StopCollection.MinimumSize = new System.Drawing.Size(1, 1);
            this.StopCollection.Name = "StopCollection";
            this.StopCollection.Size = new System.Drawing.Size(131, 64);
            this.StopCollection.TabIndex = 5;
            this.StopCollection.Text = "停止采集";
            this.StopCollection.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StopCollection.Click += new System.EventHandler(this.StopCollection_Click);
            // 
            // StartCollection
            // 
            this.StartCollection.Cursor = System.Windows.Forms.Cursors.Hand;
            this.StartCollection.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StartCollection.Location = new System.Drawing.Point(13, 247);
            this.StartCollection.MinimumSize = new System.Drawing.Size(1, 1);
            this.StartCollection.Name = "StartCollection";
            this.StartCollection.Size = new System.Drawing.Size(131, 64);
            this.StartCollection.TabIndex = 4;
            this.StartCollection.Text = "开始采集";
            this.StartCollection.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StartCollection.Click += new System.EventHandler(this.StartCollection_Click);
            // 
            // StopPreview
            // 
            this.StopPreview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.StopPreview.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StopPreview.Location = new System.Drawing.Point(178, 146);
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
            this.StartPreview.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StartPreview.Location = new System.Drawing.Point(13, 146);
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
            this.CloseHyper.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CloseHyper.Location = new System.Drawing.Point(178, 45);
            this.CloseHyper.MinimumSize = new System.Drawing.Size(1, 1);
            this.CloseHyper.Name = "CloseHyper";
            this.CloseHyper.Size = new System.Drawing.Size(131, 64);
            this.CloseHyper.TabIndex = 1;
            this.CloseHyper.Text = "关闭相机";
            this.CloseHyper.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CloseHyper.Click += new System.EventHandler(this.CloseHyper_Click);
            // 
            // OpenHyper
            // 
            this.OpenHyper.Cursor = System.Windows.Forms.Cursors.Hand;
            this.OpenHyper.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.OpenHyper.Location = new System.Drawing.Point(13, 45);
            this.OpenHyper.MinimumSize = new System.Drawing.Size(1, 1);
            this.OpenHyper.Name = "OpenHyper";
            this.OpenHyper.Size = new System.Drawing.Size(131, 64);
            this.OpenHyper.TabIndex = 0;
            this.OpenHyper.Text = "打开相机";
            this.OpenHyper.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.OpenHyper.Click += new System.EventHandler(this.OpenHyper_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.uiLabel3);
            this.tabPage2.Controls.Add(this.uiLabel2);
            this.tabPage2.Controls.Add(this.uiTextBox1);
            this.tabPage2.Controls.Add(this.GainLevel);
            this.tabPage2.Controls.Add(this.Gain);
            this.tabPage2.Controls.Add(this.uiLabel1);
            this.tabPage2.Controls.Add(this.SaveSet);
            this.tabPage2.Controls.Add(this.HyperSelectPath);
            this.tabPage2.Controls.Add(this.HyperPath);
            this.tabPage2.Controls.Add(this.uiLabel6);
            this.tabPage2.Controls.Add(this.HyperFrameRate);
            this.tabPage2.Controls.Add(this.HyperExposureTime);
            this.tabPage2.Controls.Add(this.uiLabel5);
            this.tabPage2.Controls.Add(this.uiLabel4);
            this.tabPage2.Location = new System.Drawing.Point(0, 40);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(345, 440);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "相机设置";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel3.Location = new System.Drawing.Point(240, 20);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(18, 41);
            this.uiLabel3.TabIndex = 15;
            this.uiLabel3.Text = "B";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel2.Location = new System.Drawing.Point(117, 20);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(18, 41);
            this.uiLabel2.TabIndex = 13;
            this.uiLabel2.Text = "G";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiTextBox1
            // 
            this.uiTextBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.uiTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox1.DoubleValue = 31D;
            this.uiTextBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTextBox1.IntValue = 31;
            this.uiTextBox1.Location = new System.Drawing.Point(273, 20);
            this.uiTextBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBox1.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTextBox1.Name = "uiTextBox1";
            this.uiTextBox1.Padding = new System.Windows.Forms.Padding(5);
            this.uiTextBox1.ShowText = false;
            this.uiTextBox1.Size = new System.Drawing.Size(60, 40);
            this.uiTextBox1.TabIndex = 14;
            this.uiTextBox1.Text = "31";
            this.uiTextBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTextBox1.Watermark = "";
            // 
            // GainLevel
            // 
            this.GainLevel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.GainLevel.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.GainLevel.DoubleValue = 69D;
            this.GainLevel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.GainLevel.IntValue = 69;
            this.GainLevel.Location = new System.Drawing.Point(150, 20);
            this.GainLevel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GainLevel.MinimumSize = new System.Drawing.Size(1, 16);
            this.GainLevel.Name = "GainLevel";
            this.GainLevel.Padding = new System.Windows.Forms.Padding(5);
            this.GainLevel.ShowText = false;
            this.GainLevel.Size = new System.Drawing.Size(60, 40);
            this.GainLevel.TabIndex = 6;
            this.GainLevel.Text = "69";
            this.GainLevel.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.GainLevel.Watermark = "";
            // 
            // Gain
            // 
            this.Gain.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Gain.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Gain.DoubleValue = 120D;
            this.Gain.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Gain.IntValue = 120;
            this.Gain.Location = new System.Drawing.Point(35, 20);
            this.Gain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Gain.MinimumSize = new System.Drawing.Size(1, 16);
            this.Gain.Name = "Gain";
            this.Gain.Padding = new System.Windows.Forms.Padding(5);
            this.Gain.ShowText = false;
            this.Gain.Size = new System.Drawing.Size(60, 40);
            this.Gain.TabIndex = 5;
            this.Gain.Text = "120";
            this.Gain.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.Gain.Watermark = "";
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel1.Location = new System.Drawing.Point(5, 20);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(15, 41);
            this.uiLabel1.TabIndex = 11;
            this.uiLabel1.Text = "R";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SaveSet
            // 
            this.SaveSet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SaveSet.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SaveSet.Location = new System.Drawing.Point(188, 226);
            this.SaveSet.MinimumSize = new System.Drawing.Size(1, 1);
            this.SaveSet.Name = "SaveSet";
            this.SaveSet.Size = new System.Drawing.Size(128, 56);
            this.SaveSet.TabIndex = 10;
            this.SaveSet.Text = "保存设置";
            this.SaveSet.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SaveSet.Click += new System.EventHandler(this.SaveSet_Click);
            // 
            // HyperSelectPath
            // 
            this.HyperSelectPath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HyperSelectPath.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.HyperSelectPath.Location = new System.Drawing.Point(7, 381);
            this.HyperSelectPath.MinimumSize = new System.Drawing.Size(1, 1);
            this.HyperSelectPath.Name = "HyperSelectPath";
            this.HyperSelectPath.Size = new System.Drawing.Size(128, 56);
            this.HyperSelectPath.TabIndex = 9;
            this.HyperSelectPath.Text = "选择存储路径";
            this.HyperSelectPath.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
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
            this.HyperPath.Size = new System.Drawing.Size(332, 42);
            this.HyperPath.TabIndex = 6;
            this.HyperPath.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.HyperPath.Watermark = "";
            // 
            // uiLabel6
            // 
            this.uiLabel6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel6.Location = new System.Drawing.Point(3, 285);
            this.uiLabel6.Name = "uiLabel6";
            this.uiLabel6.Size = new System.Drawing.Size(116, 41);
            this.uiLabel6.TabIndex = 8;
            this.uiLabel6.Text = "存储路径：";
            this.uiLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // HyperFrameRate
            // 
            this.HyperFrameRate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HyperFrameRate.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.HyperFrameRate.DoubleValue = 20D;
            this.HyperFrameRate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.HyperFrameRate.IntValue = 20;
            this.HyperFrameRate.Location = new System.Drawing.Point(105, 155);
            this.HyperFrameRate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.HyperFrameRate.MinimumSize = new System.Drawing.Size(1, 16);
            this.HyperFrameRate.Name = "HyperFrameRate";
            this.HyperFrameRate.Padding = new System.Windows.Forms.Padding(5);
            this.HyperFrameRate.ShowText = false;
            this.HyperFrameRate.Size = new System.Drawing.Size(146, 42);
            this.HyperFrameRate.TabIndex = 5;
            this.HyperFrameRate.Text = "20";
            this.HyperFrameRate.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.HyperFrameRate.Watermark = "";
            // 
            // HyperExposureTime
            // 
            this.HyperExposureTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HyperExposureTime.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.HyperExposureTime.DoubleValue = 30000D;
            this.HyperExposureTime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.HyperExposureTime.IntValue = 30000;
            this.HyperExposureTime.Location = new System.Drawing.Point(105, 89);
            this.HyperExposureTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.HyperExposureTime.MinimumSize = new System.Drawing.Size(1, 16);
            this.HyperExposureTime.Name = "HyperExposureTime";
            this.HyperExposureTime.Padding = new System.Windows.Forms.Padding(5);
            this.HyperExposureTime.ShowText = false;
            this.HyperExposureTime.Size = new System.Drawing.Size(146, 42);
            this.HyperExposureTime.TabIndex = 4;
            this.HyperExposureTime.Text = "30000";
            this.HyperExposureTime.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.HyperExposureTime.Watermark = "";
            // 
            // uiLabel5
            // 
            this.uiLabel5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel5.Location = new System.Drawing.Point(5, 156);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(93, 41);
            this.uiLabel5.TabIndex = 7;
            this.uiLabel5.Text = "帧频";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel4
            // 
            this.uiLabel4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel4.Location = new System.Drawing.Point(5, 90);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(93, 41);
            this.uiLabel4.TabIndex = 6;
            this.uiLabel4.Text = "积分时间";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiButton1
            // 
            this.uiButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton1.Location = new System.Drawing.Point(519, 524);
            this.uiButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Size = new System.Drawing.Size(131, 64);
            this.uiButton1.TabIndex = 8;
            this.uiButton1.Text = "滑台前进";
            this.uiButton1.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton1.Click += new System.EventHandler(this.uiButton1_Click_1);
            // 
            // uiButton2
            // 
            this.uiButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton2.Location = new System.Drawing.Point(684, 524);
            this.uiButton2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton2.Name = "uiButton2";
            this.uiButton2.Size = new System.Drawing.Size(131, 64);
            this.uiButton2.TabIndex = 14;
            this.uiButton2.Text = "滑台后退";
            this.uiButton2.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton2.Click += new System.EventHandler(this.uiButton2_Click);
            // 
            // Hyper_Set
            // 
            this.AllowShowTitle = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(854, 596);
            this.Controls.Add(this.uiButton2);
            this.Controls.Add(this.uiButton1);
            this.Controls.Add(this.uiTabControl1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "Hyper_Set";
            this.Padding = new System.Windows.Forms.Padding(0, 35, 0, 0);
            this.ShowTitle = true;
            this.Text = "高光谱 ";
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
        private  System.Windows.Forms.PictureBox pictureBox1;
        private Sunny.UI.UITabControl uiTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private Sunny.UI.UIButton LightControl;
        private Sunny.UI.UIButton R_acquisition;
        private Sunny.UI.UIButton StopCollection;
        private Sunny.UI.UIButton StartCollection;
        private Sunny.UI.UIButton StopPreview;
        private Sunny.UI.UIButton StartPreview;
        private Sunny.UI.UIButton CloseHyper;
        private Sunny.UI.UIButton OpenHyper;
        private System.Windows.Forms.TabPage tabPage2;
        private Sunny.UI.UITextBox HyperFrameRate;
        private Sunny.UI.UITextBox HyperExposureTime;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UIButton SaveSet;
        private Sunny.UI.UIButton HyperSelectPath;
        private Sunny.UI.UITextBox HyperPath;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UITextBox Gain;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UITextBox GainLevel;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UITextBox uiTextBox1;
        private Sunny.UI.UIButton uiButton1;
        private Sunny.UI.UIButton uiButton2;
    }
}