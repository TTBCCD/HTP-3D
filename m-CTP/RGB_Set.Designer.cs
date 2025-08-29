
namespace m_CTP
{
    partial class RGB_Set
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
            this.listViewCaminfo = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.buttonOpenfolder = new Sunny.UI.UIButton();
            this.buttonCapture = new Sunny.UI.UIButton();
            this.uiGroupBox1 = new Sunny.UI.UIGroupBox();
            this.cbISO = new Sunny.UI.UIComboBox();
            this.cbAperture = new Sunny.UI.UIComboBox();
            this.cbShutterSpeed = new Sunny.UI.UIComboBox();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiGroupBox2 = new Sunny.UI.UIGroupBox();
            this.SetSavepath = new Sunny.UI.UIButton();
            this.buttonChoosePath = new Sunny.UI.UIButton();
            this.textBoxCapname = new Sunny.UI.UITextBox();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.textBoxPicturePath = new Sunny.UI.UITextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.uiGroupBox1.SuspendLayout();
            this.uiGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewCaminfo
            // 
            this.listViewCaminfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listViewCaminfo.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listViewCaminfo.FullRowSelect = true;
            this.listViewCaminfo.GridLines = true;
            this.listViewCaminfo.HideSelection = false;
            this.listViewCaminfo.Location = new System.Drawing.Point(396, 39);
            this.listViewCaminfo.Margin = new System.Windows.Forms.Padding(4);
            this.listViewCaminfo.Name = "listViewCaminfo";
            this.listViewCaminfo.Size = new System.Drawing.Size(454, 227);
            this.listViewCaminfo.TabIndex = 22;
            this.listViewCaminfo.UseCompatibleStateImageBehavior = false;
            this.listViewCaminfo.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "相机名";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "编号";
            this.columnHeader2.Width = 90;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Shutter";
            this.columnHeader3.Width = 90;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Aperture";
            this.columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "ISO";
            this.columnHeader5.Width = 69;
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.BackColor = System.Drawing.SystemColors.WindowText;
            this.listBox1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBox1.ForeColor = System.Drawing.Color.LimeGreen;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 36;
            this.listBox1.Location = new System.Drawing.Point(4, 39);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(388, 76);
            this.listBox1.TabIndex = 21;
            // 
            // buttonOpenfolder
            // 
            this.buttonOpenfolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonOpenfolder.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonOpenfolder.Location = new System.Drawing.Point(4, 258);
            this.buttonOpenfolder.MinimumSize = new System.Drawing.Size(1, 1);
            this.buttonOpenfolder.Name = "buttonOpenfolder";
            this.buttonOpenfolder.Size = new System.Drawing.Size(180, 60);
            this.buttonOpenfolder.TabIndex = 23;
            this.buttonOpenfolder.Text = "打开文件夹";
            this.buttonOpenfolder.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonOpenfolder.Click += new System.EventHandler(this.buttonOpenfolder_Click);
            // 
            // buttonCapture
            // 
            this.buttonCapture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCapture.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonCapture.Location = new System.Drawing.Point(212, 258);
            this.buttonCapture.MinimumSize = new System.Drawing.Size(1, 1);
            this.buttonCapture.Name = "buttonCapture";
            this.buttonCapture.Size = new System.Drawing.Size(180, 60);
            this.buttonCapture.TabIndex = 24;
            this.buttonCapture.Text = "拍摄";
            this.buttonCapture.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonCapture.Click += new System.EventHandler(this.buttonCapture_Click);
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiGroupBox1.Controls.Add(this.cbISO);
            this.uiGroupBox1.Controls.Add(this.cbAperture);
            this.uiGroupBox1.Controls.Add(this.cbShutterSpeed);
            this.uiGroupBox1.Controls.Add(this.uiLabel3);
            this.uiGroupBox1.Controls.Add(this.uiLabel2);
            this.uiGroupBox1.Controls.Add(this.uiLabel1);
            this.uiGroupBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox1.Location = new System.Drawing.Point(460, 306);
            this.uiGroupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox1.Size = new System.Drawing.Size(390, 285);
            this.uiGroupBox1.TabIndex = 25;
            this.uiGroupBox1.Text = "相机设置";
            this.uiGroupBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbISO
            // 
            this.cbISO.DataSource = null;
            this.cbISO.FillColor = System.Drawing.Color.White;
            this.cbISO.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbISO.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.cbISO.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.cbISO.Location = new System.Drawing.Point(186, 169);
            this.cbISO.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbISO.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbISO.Name = "cbISO";
            this.cbISO.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbISO.Size = new System.Drawing.Size(145, 31);
            this.cbISO.SymbolSize = 24;
            this.cbISO.TabIndex = 5;
            this.cbISO.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbISO.Watermark = "";
            this.cbISO.SelectedIndexChanged += new System.EventHandler(this.cbISO_SelectedIndexChanged);
            // 
            // cbAperture
            // 
            this.cbAperture.DataSource = null;
            this.cbAperture.FillColor = System.Drawing.Color.White;
            this.cbAperture.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbAperture.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.cbAperture.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.cbAperture.Location = new System.Drawing.Point(186, 114);
            this.cbAperture.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbAperture.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbAperture.Name = "cbAperture";
            this.cbAperture.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbAperture.Size = new System.Drawing.Size(145, 31);
            this.cbAperture.SymbolSize = 24;
            this.cbAperture.TabIndex = 4;
            this.cbAperture.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbAperture.Watermark = "";
            this.cbAperture.SelectedIndexChanged += new System.EventHandler(this.cbAperture_SelectedIndexChanged);
            // 
            // cbShutterSpeed
            // 
            this.cbShutterSpeed.DataSource = null;
            this.cbShutterSpeed.FillColor = System.Drawing.Color.White;
            this.cbShutterSpeed.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbShutterSpeed.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.cbShutterSpeed.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.cbShutterSpeed.Location = new System.Drawing.Point(186, 52);
            this.cbShutterSpeed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbShutterSpeed.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbShutterSpeed.Name = "cbShutterSpeed";
            this.cbShutterSpeed.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbShutterSpeed.Size = new System.Drawing.Size(145, 31);
            this.cbShutterSpeed.SymbolSize = 24;
            this.cbShutterSpeed.TabIndex = 3;
            this.cbShutterSpeed.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbShutterSpeed.Watermark = "";
            this.cbShutterSpeed.SelectedIndexChanged += new System.EventHandler(this.cbShutterSpeed_SelectedIndexChanged);
            this.cbShutterSpeed.Scroll += new System.Windows.Forms.ScrollEventHandler(this.cbShutterSpeed_Scroll);
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel3.Location = new System.Drawing.Point(32, 169);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(100, 35);
            this.uiLabel3.TabIndex = 2;
            this.uiLabel3.Text = "ISO";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel2.Location = new System.Drawing.Point(32, 114);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(100, 35);
            this.uiLabel2.TabIndex = 1;
            this.uiLabel2.Text = "Aperture";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel1.Location = new System.Drawing.Point(32, 48);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(135, 35);
            this.uiLabel1.TabIndex = 0;
            this.uiLabel1.Text = "ShutterSpeed";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiGroupBox2
            // 
            this.uiGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiGroupBox2.Controls.Add(this.SetSavepath);
            this.uiGroupBox2.Controls.Add(this.buttonChoosePath);
            this.uiGroupBox2.Controls.Add(this.textBoxCapname);
            this.uiGroupBox2.Controls.Add(this.uiLabel4);
            this.uiGroupBox2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox2.Location = new System.Drawing.Point(4, 358);
            this.uiGroupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox2.Name = "uiGroupBox2";
            this.uiGroupBox2.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox2.Size = new System.Drawing.Size(450, 233);
            this.uiGroupBox2.TabIndex = 26;
            this.uiGroupBox2.Text = "设置存储路径";
            this.uiGroupBox2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SetSavepath
            // 
            this.SetSavepath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SetSavepath.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SetSavepath.Location = new System.Drawing.Point(267, 153);
            this.SetSavepath.MinimumSize = new System.Drawing.Size(1, 1);
            this.SetSavepath.Name = "SetSavepath";
            this.SetSavepath.Size = new System.Drawing.Size(180, 60);
            this.SetSavepath.TabIndex = 30;
            this.SetSavepath.Text = "设置存储路径";
            this.SetSavepath.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SetSavepath.Click += new System.EventHandler(this.SetSavepath_Click);
            // 
            // buttonChoosePath
            // 
            this.buttonChoosePath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonChoosePath.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonChoosePath.Location = new System.Drawing.Point(29, 153);
            this.buttonChoosePath.MinimumSize = new System.Drawing.Size(1, 1);
            this.buttonChoosePath.Name = "buttonChoosePath";
            this.buttonChoosePath.Size = new System.Drawing.Size(180, 60);
            this.buttonChoosePath.TabIndex = 29;
            this.buttonChoosePath.Text = "选择存储路径";
            this.buttonChoosePath.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonChoosePath.Click += new System.EventHandler(this.buttonChoosePath_Click);
            // 
            // textBoxCapname
            // 
            this.textBoxCapname.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxCapname.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxCapname.Location = new System.Drawing.Point(15, 79);
            this.textBoxCapname.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxCapname.MinimumSize = new System.Drawing.Size(1, 16);
            this.textBoxCapname.Name = "textBoxCapname";
            this.textBoxCapname.Padding = new System.Windows.Forms.Padding(5);
            this.textBoxCapname.ShowText = false;
            this.textBoxCapname.Size = new System.Drawing.Size(405, 38);
            this.textBoxCapname.TabIndex = 29;
            this.textBoxCapname.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.textBoxCapname.Watermark = "";
            // 
            // uiLabel4
            // 
            this.uiLabel4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel4.Location = new System.Drawing.Point(11, 51);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(100, 23);
            this.uiLabel4.TabIndex = 0;
            this.uiLabel4.Text = "路径名称：";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel5
            // 
            this.uiLabel5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel5.Location = new System.Drawing.Point(0, 155);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(109, 27);
            this.uiLabel5.TabIndex = 27;
            this.uiLabel5.Text = "存储路径：";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxPicturePath
            // 
            this.textBoxPicturePath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxPicturePath.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxPicturePath.Location = new System.Drawing.Point(4, 187);
            this.textBoxPicturePath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxPicturePath.MinimumSize = new System.Drawing.Size(1, 16);
            this.textBoxPicturePath.Name = "textBoxPicturePath";
            this.textBoxPicturePath.Padding = new System.Windows.Forms.Padding(5);
            this.textBoxPicturePath.ShowText = false;
            this.textBoxPicturePath.Size = new System.Drawing.Size(388, 38);
            this.textBoxPicturePath.TabIndex = 28;
            this.textBoxPicturePath.Text = "D:\\RGB";
            this.textBoxPicturePath.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.textBoxPicturePath.Watermark = "";
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.HelpRequest += new System.EventHandler(this.folderBrowserDialog1_HelpRequest);
            // 
            // RGB_Set
            // 
            this.AllowShowTitle = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(854, 596);
            this.Controls.Add(this.textBoxPicturePath);
            this.Controls.Add(this.uiLabel5);
            this.Controls.Add(this.uiGroupBox2);
            this.Controls.Add(this.uiGroupBox1);
            this.Controls.Add(this.buttonCapture);
            this.Controls.Add(this.buttonOpenfolder);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.listViewCaminfo);
            this.Name = "RGB_Set";
            this.Padding = new System.Windows.Forms.Padding(0, 35, 0, 0);
            this.ShowTitle = true;
            this.Text = "可见光相机";
            this.Initialize += new System.EventHandler(this.RGB_Set_Initialize);
            this.uiGroupBox1.ResumeLayout(false);
            this.uiGroupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewCaminfo;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ListBox listBox1;
        private Sunny.UI.UIButton buttonOpenfolder;
        private Sunny.UI.UIButton buttonCapture;
        private Sunny.UI.UIGroupBox uiGroupBox1;
        private Sunny.UI.UIComboBox cbISO;
        private Sunny.UI.UIComboBox cbAperture;
        private Sunny.UI.UIComboBox cbShutterSpeed;
        private Sunny.UI.UILabel uiLabel3;
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
    }
}