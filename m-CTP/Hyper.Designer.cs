
namespace m_CTP
{
    partial class Hyper
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
            this.picturebox1 = new System.Windows.Forms.PictureBox();
            this.uiTabControl1 = new Sunny.UI.UITabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnPMState = new Sunny.UI.UIButton();
            this.btnPixelMerge = new Sunny.UI.UIButton();
            this.cbPixelMerge = new Sunny.UI.UIComboBox();
            this.PixelMergeState = new Sunny.UI.UITextBox();
            this.StopCollection = new Sunny.UI.UIButton();
            this.StartCollection = new Sunny.UI.UIButton();
            this.CloseHyper = new Sunny.UI.UIButton();
            this.OpenHyper = new Sunny.UI.UIButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnSetFrame = new Sunny.UI.UIButton();
            this.btnGetFrame = new Sunny.UI.UIButton();
            this.btnSetExp = new Sunny.UI.UIButton();
            this.btnGetEXp = new Sunny.UI.UIButton();
            this.btnSetGain = new Sunny.UI.UIButton();
            this.GetExp = new Sunny.UI.UITextBox();
            this.SetGain = new Sunny.UI.UITextBox();
            this.btnGetGain = new Sunny.UI.UIButton();
            this.SetFrame = new Sunny.UI.UITextBox();
            this.SetExp = new Sunny.UI.UITextBox();
            this.GetGain = new Sunny.UI.UITextBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.GetFrame = new Sunny.UI.UITextBox();
            this.Num = new Sunny.UI.UITextBox();
            this.Path = new Sunny.UI.UITextBox();
            this.btnPath = new Sunny.UI.UIButton();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox1)).BeginInit();
            this.uiTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // picturebox1
            // 
            this.picturebox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picturebox1.BackColor = System.Drawing.Color.Gainsboro;
            this.picturebox1.Location = new System.Drawing.Point(3, 38);
            this.picturebox1.Name = "picturebox1";
            this.picturebox1.Size = new System.Drawing.Size(480, 480);
            this.picturebox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picturebox1.TabIndex = 12;
            this.picturebox1.TabStop = false;
            // 
            // uiTabControl1
            // 
            this.uiTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiTabControl1.Controls.Add(this.tabPage1);
            this.uiTabControl1.Controls.Add(this.tabPage2);
            this.uiTabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.uiTabControl1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTabControl1.ItemSize = new System.Drawing.Size(150, 40);
            this.uiTabControl1.Location = new System.Drawing.Point(506, 38);
            this.uiTabControl1.MainPage = "";
            this.uiTabControl1.Name = "uiTabControl1";
            this.uiTabControl1.SelectedIndex = 0;
            this.uiTabControl1.Size = new System.Drawing.Size(345, 480);
            this.uiTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.uiTabControl1.TabIndex = 13;
            this.uiTabControl1.TipsFont = new System.Drawing.Font("宋体", 6.375F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnPMState);
            this.tabPage1.Controls.Add(this.btnPixelMerge);
            this.tabPage1.Controls.Add(this.cbPixelMerge);
            this.tabPage1.Controls.Add(this.PixelMergeState);
            this.tabPage1.Controls.Add(this.StopCollection);
            this.tabPage1.Controls.Add(this.StartCollection);
            this.tabPage1.Controls.Add(this.CloseHyper);
            this.tabPage1.Controls.Add(this.OpenHyper);
            this.tabPage1.Location = new System.Drawing.Point(0, 40);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(345, 440);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "相机控制";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnPMState
            // 
            this.btnPMState.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPMState.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPMState.Location = new System.Drawing.Point(231, 315);
            this.btnPMState.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnPMState.Name = "btnPMState";
            this.btnPMState.Size = new System.Drawing.Size(100, 40);
            this.btnPMState.TabIndex = 19;
            this.btnPMState.Text = "获取状态";
            this.btnPMState.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPMState.Click += new System.EventHandler(this.btnPMState_Click);
            // 
            // btnPixelMerge
            // 
            this.btnPixelMerge.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPixelMerge.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPixelMerge.Location = new System.Drawing.Point(231, 256);
            this.btnPixelMerge.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnPixelMerge.Name = "btnPixelMerge";
            this.btnPixelMerge.Size = new System.Drawing.Size(100, 40);
            this.btnPixelMerge.TabIndex = 18;
            this.btnPixelMerge.Text = "像素合并";
            this.btnPixelMerge.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPixelMerge.Click += new System.EventHandler(this.btnPixelMerge_Click);
            // 
            // cbPixelMerge
            // 
            this.cbPixelMerge.DataSource = null;
            this.cbPixelMerge.FillColor = System.Drawing.Color.White;
            this.cbPixelMerge.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbPixelMerge.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.cbPixelMerge.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "4"});
            this.cbPixelMerge.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.cbPixelMerge.Location = new System.Drawing.Point(13, 256);
            this.cbPixelMerge.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbPixelMerge.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbPixelMerge.Name = "cbPixelMerge";
            this.cbPixelMerge.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbPixelMerge.Size = new System.Drawing.Size(189, 40);
            this.cbPixelMerge.SymbolSize = 24;
            this.cbPixelMerge.TabIndex = 16;
            this.cbPixelMerge.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbPixelMerge.Watermark = "";
            // 
            // PixelMergeState
            // 
            this.PixelMergeState.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.PixelMergeState.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PixelMergeState.Location = new System.Drawing.Point(13, 315);
            this.PixelMergeState.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PixelMergeState.MinimumSize = new System.Drawing.Size(1, 16);
            this.PixelMergeState.Name = "PixelMergeState";
            this.PixelMergeState.Padding = new System.Windows.Forms.Padding(5);
            this.PixelMergeState.ShowText = false;
            this.PixelMergeState.Size = new System.Drawing.Size(189, 37);
            this.PixelMergeState.TabIndex = 15;
            this.PixelMergeState.Text = "uiTextBox3";
            this.PixelMergeState.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.PixelMergeState.Watermark = "";
            // 
            // StopCollection
            // 
            this.StopCollection.Cursor = System.Windows.Forms.Cursors.Hand;
            this.StopCollection.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StopCollection.Location = new System.Drawing.Point(178, 135);
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
            this.StartCollection.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StartCollection.Location = new System.Drawing.Point(13, 135);
            this.StartCollection.MinimumSize = new System.Drawing.Size(1, 1);
            this.StartCollection.Name = "StartCollection";
            this.StartCollection.Size = new System.Drawing.Size(131, 64);
            this.StartCollection.TabIndex = 4;
            this.StartCollection.Text = "开始采集";
            this.StartCollection.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StartCollection.Click += new System.EventHandler(this.StartCollection_Click);
            // 
            // CloseHyper
            // 
            this.CloseHyper.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseHyper.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
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
            this.OpenHyper.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
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
            this.tabPage2.Controls.Add(this.btnSetFrame);
            this.tabPage2.Controls.Add(this.btnGetFrame);
            this.tabPage2.Controls.Add(this.btnSetExp);
            this.tabPage2.Controls.Add(this.btnGetEXp);
            this.tabPage2.Controls.Add(this.btnSetGain);
            this.tabPage2.Controls.Add(this.GetExp);
            this.tabPage2.Controls.Add(this.SetGain);
            this.tabPage2.Controls.Add(this.btnGetGain);
            this.tabPage2.Controls.Add(this.SetFrame);
            this.tabPage2.Controls.Add(this.SetExp);
            this.tabPage2.Controls.Add(this.GetGain);
            this.tabPage2.Controls.Add(this.uiLabel1);
            this.tabPage2.Controls.Add(this.GetFrame);
            this.tabPage2.Location = new System.Drawing.Point(0, 40);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(200, 60);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "相机设置";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnSetFrame
            // 
            this.btnSetFrame.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSetFrame.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSetFrame.Location = new System.Drawing.Point(198, 382);
            this.btnSetFrame.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSetFrame.Name = "btnSetFrame";
            this.btnSetFrame.Size = new System.Drawing.Size(128, 40);
            this.btnSetFrame.TabIndex = 21;
            this.btnSetFrame.Text = "设置帧频";
            this.btnSetFrame.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSetFrame.Click += new System.EventHandler(this.btnSetFrame_Click);
            // 
            // btnGetFrame
            // 
            this.btnGetFrame.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGetFrame.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnGetFrame.Location = new System.Drawing.Point(198, 308);
            this.btnGetFrame.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnGetFrame.Name = "btnGetFrame";
            this.btnGetFrame.Size = new System.Drawing.Size(128, 40);
            this.btnGetFrame.TabIndex = 20;
            this.btnGetFrame.Text = "获取帧频";
            this.btnGetFrame.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnGetFrame.Click += new System.EventHandler(this.btnGetFrame_Click);
            // 
            // btnSetExp
            // 
            this.btnSetExp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSetExp.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSetExp.Location = new System.Drawing.Point(198, 236);
            this.btnSetExp.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSetExp.Name = "btnSetExp";
            this.btnSetExp.Size = new System.Drawing.Size(128, 40);
            this.btnSetExp.TabIndex = 19;
            this.btnSetExp.Text = "设置曝光";
            this.btnSetExp.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSetExp.Click += new System.EventHandler(this.btnSetExp_Click);
            // 
            // btnGetEXp
            // 
            this.btnGetEXp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGetEXp.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnGetEXp.Location = new System.Drawing.Point(198, 164);
            this.btnGetEXp.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnGetEXp.Name = "btnGetEXp";
            this.btnGetEXp.Size = new System.Drawing.Size(128, 40);
            this.btnGetEXp.TabIndex = 18;
            this.btnGetEXp.Text = "获取曝光";
            this.btnGetEXp.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnGetEXp.Click += new System.EventHandler(this.btnGetEXp_Click);
            // 
            // btnSetGain
            // 
            this.btnSetGain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSetGain.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSetGain.Location = new System.Drawing.Point(198, 92);
            this.btnSetGain.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSetGain.Name = "btnSetGain";
            this.btnSetGain.Size = new System.Drawing.Size(128, 40);
            this.btnSetGain.TabIndex = 17;
            this.btnSetGain.Text = "设置增益";
            this.btnSetGain.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSetGain.Click += new System.EventHandler(this.btnSetGain_Click);
            // 
            // GetExp
            // 
            this.GetExp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.GetExp.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.GetExp.DoubleValue = 44D;
            this.GetExp.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.GetExp.IntValue = 44;
            this.GetExp.Location = new System.Drawing.Point(-45, -26);
            this.GetExp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GetExp.MinimumSize = new System.Drawing.Size(1, 16);
            this.GetExp.Name = "GetExp";
            this.GetExp.Padding = new System.Windows.Forms.Padding(5);
            this.GetExp.ShowText = false;
            this.GetExp.Size = new System.Drawing.Size(142, 40);
            this.GetExp.TabIndex = 6;
            this.GetExp.Text = "44";
            this.GetExp.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.GetExp.Watermark = "";
            // 
            // SetGain
            // 
            this.SetGain.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SetGain.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.SetGain.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SetGain.Location = new System.Drawing.Point(-45, -98);
            this.SetGain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SetGain.MinimumSize = new System.Drawing.Size(1, 16);
            this.SetGain.Name = "SetGain";
            this.SetGain.Padding = new System.Windows.Forms.Padding(5);
            this.SetGain.ShowText = false;
            this.SetGain.Size = new System.Drawing.Size(142, 40);
            this.SetGain.TabIndex = 6;
            this.SetGain.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.SetGain.Watermark = "";
            // 
            // btnGetGain
            // 
            this.btnGetGain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGetGain.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnGetGain.Location = new System.Drawing.Point(198, 20);
            this.btnGetGain.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnGetGain.Name = "btnGetGain";
            this.btnGetGain.Size = new System.Drawing.Size(128, 40);
            this.btnGetGain.TabIndex = 16;
            this.btnGetGain.Text = "获取增益";
            this.btnGetGain.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnGetGain.Click += new System.EventHandler(this.btnGetGain_Click);
            // 
            // SetFrame
            // 
            this.SetFrame.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SetFrame.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.SetFrame.DoubleValue = 60D;
            this.SetFrame.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SetFrame.IntValue = 60;
            this.SetFrame.Location = new System.Drawing.Point(-45, 192);
            this.SetFrame.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SetFrame.MinimumSize = new System.Drawing.Size(1, 16);
            this.SetFrame.Name = "SetFrame";
            this.SetFrame.Padding = new System.Windows.Forms.Padding(5);
            this.SetFrame.ShowText = false;
            this.SetFrame.Size = new System.Drawing.Size(142, 40);
            this.SetFrame.TabIndex = 14;
            this.SetFrame.Text = "60";
            this.SetFrame.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.SetFrame.Watermark = "";
            // 
            // SetExp
            // 
            this.SetExp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SetExp.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.SetExp.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SetExp.Location = new System.Drawing.Point(-45, 46);
            this.SetExp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SetExp.MinimumSize = new System.Drawing.Size(1, 16);
            this.SetExp.Name = "SetExp";
            this.SetExp.Padding = new System.Windows.Forms.Padding(5);
            this.SetExp.ShowText = false;
            this.SetExp.Size = new System.Drawing.Size(142, 40);
            this.SetExp.TabIndex = 6;
            this.SetExp.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.SetExp.Watermark = "";
            // 
            // GetGain
            // 
            this.GetGain.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.GetGain.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.GetGain.DoubleValue = 40D;
            this.GetGain.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.GetGain.IntValue = 40;
            this.GetGain.Location = new System.Drawing.Point(-45, -170);
            this.GetGain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GetGain.MinimumSize = new System.Drawing.Size(1, 16);
            this.GetGain.Name = "GetGain";
            this.GetGain.Padding = new System.Windows.Forms.Padding(5);
            this.GetGain.ShowText = false;
            this.GetGain.Size = new System.Drawing.Size(142, 40);
            this.GetGain.TabIndex = 5;
            this.GetGain.Text = "40";
            this.GetGain.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.GetGain.Watermark = "";
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
            // GetFrame
            // 
            this.GetFrame.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GetFrame.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.GetFrame.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.GetFrame.Location = new System.Drawing.Point(27, 308);
            this.GetFrame.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GetFrame.MinimumSize = new System.Drawing.Size(1, 16);
            this.GetFrame.Name = "GetFrame";
            this.GetFrame.Padding = new System.Windows.Forms.Padding(5);
            this.GetFrame.ShowText = false;
            this.GetFrame.Size = new System.Drawing.Size(1, 42);
            this.GetFrame.TabIndex = 4;
            this.GetFrame.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.GetFrame.Watermark = "";
            // 
            // Num
            // 
            this.Num.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Num.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Num.Location = new System.Drawing.Point(26, 525);
            this.Num.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Num.MinimumSize = new System.Drawing.Size(1, 16);
            this.Num.Name = "Num";
            this.Num.Padding = new System.Windows.Forms.Padding(5);
            this.Num.ShowText = false;
            this.Num.Size = new System.Drawing.Size(150, 37);
            this.Num.TabIndex = 14;
            this.Num.Text = "uiTextBox2";
            this.Num.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.Num.Watermark = "";
            // 
            // Path
            // 
            this.Path.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Path.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Path.Location = new System.Drawing.Point(519, 535);
            this.Path.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Path.MinimumSize = new System.Drawing.Size(1, 16);
            this.Path.Name = "Path";
            this.Path.Padding = new System.Windows.Forms.Padding(5);
            this.Path.ShowText = false;
            this.Path.Size = new System.Drawing.Size(150, 40);
            this.Path.TabIndex = 15;
            this.Path.Text = "C:\\Users\\SF\\Desktop\\test";
            this.Path.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.Path.Watermark = "";
            // 
            // btnPath
            // 
            this.btnPath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPath.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPath.Location = new System.Drawing.Point(695, 536);
            this.btnPath.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnPath.Name = "btnPath";
            this.btnPath.Size = new System.Drawing.Size(100, 35);
            this.btnPath.TabIndex = 16;
            this.btnPath.Text = "保存路径";
            this.btnPath.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPath.Click += new System.EventHandler(this.btnPath_Click);
            // 
            // Hyper
            // 
            this.AllowShowTitle = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(854, 596);
            this.Controls.Add(this.btnPath);
            this.Controls.Add(this.Path);
            this.Controls.Add(this.Num);
            this.Controls.Add(this.uiTabControl1);
            this.Controls.Add(this.picturebox1);
            this.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "Hyper";
            this.Padding = new System.Windows.Forms.Padding(0, 35, 0, 0);
            this.ShowTitle = true;
            this.Text = "高光谱 ";
            this.TitleFont = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Initialize += new System.EventHandler(this.Hyper_Set_Initialize);
            ((System.ComponentModel.ISupportInitialize)(this.picturebox1)).EndInit();
            this.uiTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        //dehui 修改Picturebox1访问级别
        private System.Windows.Forms.PictureBox picturebox1;
        private Sunny.UI.UITabControl uiTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private Sunny.UI.UIButton StopCollection;
        private Sunny.UI.UIButton StartCollection;
        private Sunny.UI.UIButton CloseHyper;
        private Sunny.UI.UIButton OpenHyper;
        private System.Windows.Forms.TabPage tabPage2;
        private Sunny.UI.UITextBox GetFrame;
        private Sunny.UI.UITextBox GetGain;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UITextBox SetExp;
        private Sunny.UI.UITextBox SetFrame;
        private Sunny.UI.UIButton btnPixelMerge;
        private Sunny.UI.UIComboBox cbPixelMerge;
        private Sunny.UI.UITextBox PixelMergeState;
        private Sunny.UI.UITextBox Num;
        private Sunny.UI.UIButton btnPMState;
        private Sunny.UI.UIButton btnGetGain;
        private Sunny.UI.UIButton btnGetEXp;
        private Sunny.UI.UIButton btnSetGain;
        private Sunny.UI.UITextBox GetExp;
        private Sunny.UI.UITextBox SetGain;
        private Sunny.UI.UIButton btnSetFrame;
        private Sunny.UI.UIButton btnGetFrame;
        private Sunny.UI.UIButton btnSetExp;
        private Sunny.UI.UITextBox Path;
        private Sunny.UI.UIButton btnPath;
    }
}