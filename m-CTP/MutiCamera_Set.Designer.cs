
using System.Windows.Forms;

namespace m_CTP
{
    partial class MutiCamera_Set
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
            this.buttonOpenfolder = new Sunny.UI.UIButton();
            this.buttonCapture = new Sunny.UI.UIButton();
            this.uiGroupBox1 = new Sunny.UI.UIGroupBox();
            this.cbISO2 = new Sunny.UI.UITextBox();
            this.cbExposure2 = new Sunny.UI.UITextBox();
            this.cbISO1 = new Sunny.UI.UITextBox();
            this.cbExposure1 = new Sunny.UI.UITextBox();
            this.set = new Sunny.UI.UIButton();
            this.get = new Sunny.UI.UIButton();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiGroupBox2 = new Sunny.UI.UIGroupBox();
            this.SetSavepath = new Sunny.UI.UIButton();
            this.buttonChoosePath = new Sunny.UI.UIButton();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.textBoxPicturePath = new Sunny.UI.UITextBox();
            this.textBoxCapname = new Sunny.UI.UITextBox();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.camera1 = new System.Windows.Forms.PictureBox();
            this.camera2 = new System.Windows.Forms.PictureBox();
            this.cbChoose = new Sunny.UI.UIComboBox();
            this.choose = new Sunny.UI.UIButton();
            this.search = new Sunny.UI.UIButton();
            this.cbDeviceList = new Sunny.UI.UIComboBox();
            this.cbDeviceList1 = new Sunny.UI.UIComboBox();
            this.cbDeviceList2 = new Sunny.UI.UIComboBox();
            this.uiButton1 = new Sunny.UI.UIButton();
            this.Open = new Sunny.UI.UIButton();
            this.Close = new Sunny.UI.UIButton();
            this.show = new Sunny.UI.UIButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btUp = new Sunny.UI.UIButton();
            this.btDown = new Sunny.UI.UIButton();
            this.uiGroupBox1.SuspendLayout();
            this.uiGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.camera1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.camera2)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOpenfolder
            // 
            this.buttonOpenfolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonOpenfolder.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonOpenfolder.Location = new System.Drawing.Point(326, 62);
            this.buttonOpenfolder.MinimumSize = new System.Drawing.Size(1, 1);
            this.buttonOpenfolder.Name = "buttonOpenfolder";
            this.buttonOpenfolder.Size = new System.Drawing.Size(94, 40);
            this.buttonOpenfolder.TabIndex = 23;
            this.buttonOpenfolder.Text = "打开文件夹";
            this.buttonOpenfolder.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonOpenfolder.Click += new System.EventHandler(this.buttonOpenfolder_Click);
            // 
            // buttonCapture
            // 
            this.buttonCapture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCapture.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonCapture.Location = new System.Drawing.Point(309, 194);
            this.buttonCapture.MinimumSize = new System.Drawing.Size(1, 1);
            this.buttonCapture.Name = "buttonCapture";
            this.buttonCapture.Size = new System.Drawing.Size(111, 40);
            this.buttonCapture.TabIndex = 24;
            this.buttonCapture.Text = "拍摄";
            this.buttonCapture.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonCapture.Click += new System.EventHandler(this.buttonCapture_Click);
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiGroupBox1.Controls.Add(this.cbISO2);
            this.uiGroupBox1.Controls.Add(this.cbExposure2);
            this.uiGroupBox1.Controls.Add(this.cbISO1);
            this.uiGroupBox1.Controls.Add(this.cbExposure1);
            this.uiGroupBox1.Controls.Add(this.set);
            this.uiGroupBox1.Controls.Add(this.get);
            this.uiGroupBox1.Controls.Add(this.uiLabel2);
            this.uiGroupBox1.Controls.Add(this.uiLabel1);
            this.uiGroupBox1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox1.Location = new System.Drawing.Point(460, 340);
            this.uiGroupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox1.Size = new System.Drawing.Size(390, 251);
            this.uiGroupBox1.TabIndex = 25;
            this.uiGroupBox1.Text = "相机参数";
            this.uiGroupBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbISO2
            // 
            this.cbISO2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.cbISO2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbISO2.Location = new System.Drawing.Point(236, 120);
            this.cbISO2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbISO2.MinimumSize = new System.Drawing.Size(1, 16);
            this.cbISO2.Name = "cbISO2";
            this.cbISO2.Padding = new System.Windows.Forms.Padding(5);
            this.cbISO2.ShowText = false;
            this.cbISO2.Size = new System.Drawing.Size(145, 33);
            this.cbISO2.TabIndex = 32;
            this.cbISO2.Text = "uiTextBox2";
            this.cbISO2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbISO2.Watermark = "";
            // 
            // cbExposure2
            // 
            this.cbExposure2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.cbExposure2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbExposure2.Location = new System.Drawing.Point(236, 55);
            this.cbExposure2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbExposure2.MinimumSize = new System.Drawing.Size(1, 16);
            this.cbExposure2.Name = "cbExposure2";
            this.cbExposure2.Padding = new System.Windows.Forms.Padding(5);
            this.cbExposure2.ShowText = false;
            this.cbExposure2.Size = new System.Drawing.Size(145, 33);
            this.cbExposure2.TabIndex = 32;
            this.cbExposure2.Text = "cbExposure2";
            this.cbExposure2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbExposure2.Watermark = "";
            // 
            // cbISO1
            // 
            this.cbISO1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.cbISO1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbISO1.Location = new System.Drawing.Point(75, 120);
            this.cbISO1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbISO1.MinimumSize = new System.Drawing.Size(1, 16);
            this.cbISO1.Name = "cbISO1";
            this.cbISO1.Padding = new System.Windows.Forms.Padding(5);
            this.cbISO1.ShowText = false;
            this.cbISO1.Size = new System.Drawing.Size(145, 33);
            this.cbISO1.TabIndex = 33;
            this.cbISO1.Text = "uiTextBox3";
            this.cbISO1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbISO1.Watermark = "";
            // 
            // cbExposure1
            // 
            this.cbExposure1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.cbExposure1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbExposure1.Location = new System.Drawing.Point(75, 55);
            this.cbExposure1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbExposure1.MinimumSize = new System.Drawing.Size(1, 16);
            this.cbExposure1.Name = "cbExposure1";
            this.cbExposure1.Padding = new System.Windows.Forms.Padding(5);
            this.cbExposure1.ShowText = false;
            this.cbExposure1.Size = new System.Drawing.Size(145, 33);
            this.cbExposure1.TabIndex = 31;
            this.cbExposure1.Text = "cbExposure1";
            this.cbExposure1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbExposure1.Watermark = "";
            // 
            // set
            // 
            this.set.Cursor = System.Windows.Forms.Cursors.Hand;
            this.set.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.set.Location = new System.Drawing.Point(248, 172);
            this.set.MinimumSize = new System.Drawing.Size(1, 1);
            this.set.Name = "set";
            this.set.Size = new System.Drawing.Size(111, 40);
            this.set.TabIndex = 26;
            this.set.Text = "设置参数";
            this.set.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.set.Click += new System.EventHandler(this.set_Click);
            // 
            // get
            // 
            this.get.Cursor = System.Windows.Forms.Cursors.Hand;
            this.get.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.get.Location = new System.Drawing.Point(86, 172);
            this.get.MinimumSize = new System.Drawing.Size(1, 1);
            this.get.Name = "get";
            this.get.Size = new System.Drawing.Size(111, 40);
            this.get.TabIndex = 25;
            this.get.Text = "获取参数";
            this.get.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.get.Click += new System.EventHandler(this.get_Click);
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel2.Location = new System.Drawing.Point(9, 118);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(100, 35);
            this.uiLabel2.TabIndex = 1;
            this.uiLabel2.Text = "增益";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel1.Location = new System.Drawing.Point(9, 52);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(135, 35);
            this.uiLabel1.TabIndex = 0;
            this.uiLabel1.Text = "曝光";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiGroupBox2
            // 
            this.uiGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiGroupBox2.Controls.Add(this.SetSavepath);
            this.uiGroupBox2.Controls.Add(this.buttonChoosePath);
            this.uiGroupBox2.Controls.Add(this.uiLabel5);
            this.uiGroupBox2.Controls.Add(this.textBoxPicturePath);
            this.uiGroupBox2.Controls.Add(this.textBoxCapname);
            this.uiGroupBox2.Controls.Add(this.uiLabel4);
            this.uiGroupBox2.Controls.Add(this.buttonCapture);
            this.uiGroupBox2.Controls.Add(this.buttonOpenfolder);
            this.uiGroupBox2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox2.Location = new System.Drawing.Point(4, 340);
            this.uiGroupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox2.Name = "uiGroupBox2";
            this.uiGroupBox2.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox2.Size = new System.Drawing.Size(450, 249);
            this.uiGroupBox2.TabIndex = 26;
            this.uiGroupBox2.Text = "设置存储路径";
            this.uiGroupBox2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SetSavepath
            // 
            this.SetSavepath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SetSavepath.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SetSavepath.Location = new System.Drawing.Point(158, 194);
            this.SetSavepath.MinimumSize = new System.Drawing.Size(1, 1);
            this.SetSavepath.Name = "SetSavepath";
            this.SetSavepath.Size = new System.Drawing.Size(111, 40);
            this.SetSavepath.TabIndex = 30;
            this.SetSavepath.Text = "设置路径";
            this.SetSavepath.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SetSavepath.Click += new System.EventHandler(this.SetSavepath_Click);
            // 
            // buttonChoosePath
            // 
            this.buttonChoosePath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonChoosePath.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonChoosePath.Location = new System.Drawing.Point(15, 194);
            this.buttonChoosePath.MinimumSize = new System.Drawing.Size(1, 1);
            this.buttonChoosePath.Name = "buttonChoosePath";
            this.buttonChoosePath.Size = new System.Drawing.Size(111, 40);
            this.buttonChoosePath.TabIndex = 29;
            this.buttonChoosePath.Text = "选择路径";
            this.buttonChoosePath.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonChoosePath.Click += new System.EventHandler(this.buttonChoosePath_Click);
            // 
            // uiLabel5
            // 
            this.uiLabel5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel5.Location = new System.Drawing.Point(15, 55);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(90, 57);
            this.uiLabel5.TabIndex = 27;
            this.uiLabel5.Text = "存储\r\n路径：";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxPicturePath
            // 
            this.textBoxPicturePath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxPicturePath.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxPicturePath.Location = new System.Drawing.Point(106, 64);
            this.textBoxPicturePath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxPicturePath.MinimumSize = new System.Drawing.Size(1, 16);
            this.textBoxPicturePath.Name = "textBoxPicturePath";
            this.textBoxPicturePath.Padding = new System.Windows.Forms.Padding(5);
            this.textBoxPicturePath.ShowText = false;
            this.textBoxPicturePath.Size = new System.Drawing.Size(203, 43);
            this.textBoxPicturePath.TabIndex = 28;
            this.textBoxPicturePath.Text = "C:\\Users\\SF\\Desktop\\test";
            this.textBoxPicturePath.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.textBoxPicturePath.Watermark = "";
            // 
            // textBoxCapname
            // 
            this.textBoxCapname.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxCapname.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxCapname.Location = new System.Drawing.Point(107, 131);
            this.textBoxCapname.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxCapname.MinimumSize = new System.Drawing.Size(1, 16);
            this.textBoxCapname.Name = "textBoxCapname";
            this.textBoxCapname.Padding = new System.Windows.Forms.Padding(5);
            this.textBoxCapname.ShowText = false;
            this.textBoxCapname.Size = new System.Drawing.Size(313, 43);
            this.textBoxCapname.TabIndex = 29;
            this.textBoxCapname.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.textBoxCapname.Watermark = "";
            // 
            // uiLabel4
            // 
            this.uiLabel4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel4.Location = new System.Drawing.Point(11, 118);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(100, 56);
            this.uiLabel4.TabIndex = 0;
            this.uiLabel4.Text = "路径\r\n名称：";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.HelpRequest += new System.EventHandler(this.folderBrowserDialog1_HelpRequest);
            // 
            // camera1
            // 
            this.camera1.Location = new System.Drawing.Point(4, 47);
            this.camera1.Name = "camera1";
            this.camera1.Size = new System.Drawing.Size(269, 269);
            this.camera1.TabIndex = 29;
            this.camera1.TabStop = false;
            // 
            // camera2
            // 
            this.camera2.Location = new System.Drawing.Point(279, 47);
            this.camera2.Name = "camera2";
            this.camera2.Size = new System.Drawing.Size(269, 269);
            this.camera2.TabIndex = 30;
            this.camera2.TabStop = false;
            // 
            // cbChoose
            // 
            this.cbChoose.DataSource = null;
            this.cbChoose.FillColor = System.Drawing.Color.White;
            this.cbChoose.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbChoose.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.cbChoose.Items.AddRange(new object[] {
            "jpg",
            "bmp",
            "png",
            "tiff"});
            this.cbChoose.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.cbChoose.Location = new System.Drawing.Point(555, 142);
            this.cbChoose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbChoose.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbChoose.Name = "cbChoose";
            this.cbChoose.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbChoose.Size = new System.Drawing.Size(286, 33);
            this.cbChoose.SymbolSize = 24;
            this.cbChoose.TabIndex = 33;
            this.cbChoose.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbChoose.Watermark = "";
            // 
            // choose
            // 
            this.choose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.choose.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.choose.Location = new System.Drawing.Point(580, 237);
            this.choose.MinimumSize = new System.Drawing.Size(1, 1);
            this.choose.Name = "choose";
            this.choose.Size = new System.Drawing.Size(100, 30);
            this.choose.TabIndex = 34;
            this.choose.Text = "选择格式";
            this.choose.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.choose.Click += new System.EventHandler(this.choose_Click);
            // 
            // search
            // 
            this.search.Cursor = System.Windows.Forms.Cursors.Hand;
            this.search.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.search.Location = new System.Drawing.Point(770, 51);
            this.search.MinimumSize = new System.Drawing.Size(1, 1);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(71, 30);
            this.search.TabIndex = 36;
            this.search.Text = "搜索";
            this.search.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // cbDeviceList
            // 
            this.cbDeviceList.DataSource = null;
            this.cbDeviceList.FillColor = System.Drawing.Color.White;
            this.cbDeviceList.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbDeviceList.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.cbDeviceList.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.cbDeviceList.Location = new System.Drawing.Point(555, 48);
            this.cbDeviceList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbDeviceList.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbDeviceList.Name = "cbDeviceList";
            this.cbDeviceList.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbDeviceList.Size = new System.Drawing.Size(208, 33);
            this.cbDeviceList.SymbolSize = 24;
            this.cbDeviceList.TabIndex = 35;
            this.cbDeviceList.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbDeviceList.Watermark = "";
            // 
            // cbDeviceList1
            // 
            this.cbDeviceList1.DataSource = null;
            this.cbDeviceList1.FillColor = System.Drawing.Color.White;
            this.cbDeviceList1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbDeviceList1.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.cbDeviceList1.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.cbDeviceList1.Location = new System.Drawing.Point(555, 99);
            this.cbDeviceList1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbDeviceList1.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbDeviceList1.Name = "cbDeviceList1";
            this.cbDeviceList1.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbDeviceList1.Size = new System.Drawing.Size(139, 33);
            this.cbDeviceList1.SymbolSize = 24;
            this.cbDeviceList1.TabIndex = 37;
            this.cbDeviceList1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbDeviceList1.Watermark = "";
            this.cbDeviceList1.SelectedIndexChanged += new System.EventHandler(this.cbDeviceList1_SelectedIndexChanged);
            // 
            // cbDeviceList2
            // 
            this.cbDeviceList2.DataSource = null;
            this.cbDeviceList2.FillColor = System.Drawing.Color.White;
            this.cbDeviceList2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbDeviceList2.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.cbDeviceList2.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.cbDeviceList2.Location = new System.Drawing.Point(702, 99);
            this.cbDeviceList2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbDeviceList2.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbDeviceList2.Name = "cbDeviceList2";
            this.cbDeviceList2.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbDeviceList2.Size = new System.Drawing.Size(139, 33);
            this.cbDeviceList2.SymbolSize = 24;
            this.cbDeviceList2.TabIndex = 38;
            this.cbDeviceList2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbDeviceList2.Watermark = "";
            // 
            // uiButton1
            // 
            this.uiButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton1.Location = new System.Drawing.Point(702, 237);
            this.uiButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Radius = 1;
            this.uiButton1.Size = new System.Drawing.Size(1, 1);
            this.uiButton1.TabIndex = 39;
            this.uiButton1.Text = "选择";
            this.uiButton1.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // Open
            // 
            this.Open.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Open.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Open.Location = new System.Drawing.Point(580, 201);
            this.Open.MinimumSize = new System.Drawing.Size(1, 1);
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(100, 30);
            this.Open.TabIndex = 40;
            this.Open.Text = "打开连接";
            this.Open.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Open.Click += new System.EventHandler(this.Open_Click);
            // 
            // Close
            // 
            this.Close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Close.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Close.Location = new System.Drawing.Point(719, 201);
            this.Close.MinimumSize = new System.Drawing.Size(1, 1);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(100, 30);
            this.Close.TabIndex = 41;
            this.Close.Text = "断开连接";
            this.Close.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // show
            // 
            this.show.Cursor = System.Windows.Forms.Cursors.Hand;
            this.show.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.show.Location = new System.Drawing.Point(719, 237);
            this.show.MinimumSize = new System.Drawing.Size(1, 1);
            this.show.Name = "show";
            this.show.Size = new System.Drawing.Size(100, 30);
            this.show.TabIndex = 42;
            this.show.Text = "显示";
            this.show.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.show.Click += new System.EventHandler(this.show_Click);
            // 
            // btUp
            // 
            this.btUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btUp.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btUp.Location = new System.Drawing.Point(580, 286);
            this.btUp.MinimumSize = new System.Drawing.Size(1, 1);
            this.btUp.Name = "btUp";
            this.btUp.Size = new System.Drawing.Size(100, 30);
            this.btUp.TabIndex = 43;
            this.btUp.Text = "滑台上升";
            this.btUp.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btUp.Click += new System.EventHandler(this.btUp_Click);
            // 
            // btDown
            // 
            this.btDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btDown.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btDown.Location = new System.Drawing.Point(719, 286);
            this.btDown.MinimumSize = new System.Drawing.Size(1, 1);
            this.btDown.Name = "btDown";
            this.btDown.Size = new System.Drawing.Size(100, 30);
            this.btDown.TabIndex = 44;
            this.btDown.Text = "滑台下降";
            this.btDown.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btDown.Click += new System.EventHandler(this.btDown_Click);
            // 
            // MutiCamera_Set
            // 
            this.AllowShowTitle = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(854, 596);
            this.Controls.Add(this.btDown);
            this.Controls.Add(this.btUp);
            this.Controls.Add(this.show);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.Open);
            this.Controls.Add(this.uiButton1);
            this.Controls.Add(this.cbDeviceList2);
            this.Controls.Add(this.cbDeviceList1);
            this.Controls.Add(this.search);
            this.Controls.Add(this.cbDeviceList);
            this.Controls.Add(this.choose);
            this.Controls.Add(this.cbChoose);
            this.Controls.Add(this.camera2);
            this.Controls.Add(this.camera1);
            this.Controls.Add(this.uiGroupBox2);
            this.Controls.Add(this.uiGroupBox1);
            this.Name = "MutiCamera_Set";
            this.Padding = new System.Windows.Forms.Padding(0, 35, 0, 0);
            this.ShowTitle = true;
            this.Text = "双相机";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MutiCamera_Set_FormClosing);
            this.uiGroupBox1.ResumeLayout(false);
            this.uiGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.camera1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.camera2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Sunny.UI.UIButton buttonOpenfolder;
        private Sunny.UI.UIButton buttonCapture;
        private Sunny.UI.UIGroupBox uiGroupBox1;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIGroupBox uiGroupBox2;
        private Sunny.UI.UIButton buttonChoosePath;
        private Sunny.UI.UITextBox textBoxCapname;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UITextBox textBoxPicturePath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private Sunny.UI.UIButton SetSavepath;
        public  System.Windows.Forms.PictureBox camera1;
        public System.Windows.Forms.PictureBox camera2;
        private Sunny.UI.UIButton set;
        private Sunny.UI.UIButton get;
        private Sunny.UI.UIComboBox cbChoose;
        private Sunny.UI.UIButton choose;
        private Sunny.UI.UIButton search;
        private Sunny.UI.UIComboBox cbDeviceList;
        private Sunny.UI.UIComboBox cbDeviceList1;
        private Sunny.UI.UIComboBox cbDeviceList2;
        private Sunny.UI.UIButton uiButton1;
        private Sunny.UI.UIButton Open;
        private Sunny.UI.UIButton Close;
        private Sunny.UI.UIButton show;
        private System.Windows.Forms.Timer timer1;
        private Sunny.UI.UITextBox cbISO2;
        private Sunny.UI.UITextBox cbExposure2;
        private Sunny.UI.UITextBox cbISO1;
        private Sunny.UI.UITextBox cbExposure1;
        private Sunny.UI.UIButton btUp;
        private Sunny.UI.UIButton btDown;
    }
}