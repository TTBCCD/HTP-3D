
namespace m_CTP
{
    partial class Link
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
            this.uiGroupBox4 = new Sunny.UI.UIGroupBox();
            this.cbDeviceList = new Sunny.UI.UIComboBox();
            this.DepthLink = new Sunny.UI.UISwitch();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.ThemalInstructions = new Sunny.UI.UISymbolButton();
            this.uiGroupBox2 = new Sunny.UI.UIGroupBox();
            this.Camera2 = new Sunny.UI.UIComboBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.Camera1 = new Sunny.UI.UIComboBox();
            this.CameraLink = new Sunny.UI.UISwitch();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.uiLabel12 = new Sunny.UI.UILabel();
            this.RGBInstructions = new Sunny.UI.UISymbolButton();
            this.uiGroupBox3 = new Sunny.UI.UIGroupBox();
            this.FluorPort = new Sunny.UI.UIComboBox();
            this.uiLabel11 = new Sunny.UI.UILabel();
            this.FluorControl = new Sunny.UI.UISwitch();
            this.uiLabel7 = new Sunny.UI.UILabel();
            this.FluorInstructions = new Sunny.UI.UISymbolButton();
            this.uiGroupBox5 = new Sunny.UI.UIGroupBox();
            this.LidarPort = new Sunny.UI.UITextBox();
            this.LidarControl = new Sunny.UI.UISwitch();
            this.uiLabel15 = new Sunny.UI.UILabel();
            this.uiLabel6 = new Sunny.UI.UILabel();
            this.LidarIP = new Sunny.UI.UITextBox();
            this.uiLabel16 = new Sunny.UI.UILabel();
            this.LidarInstructions = new Sunny.UI.UISymbolButton();
            this.uiGroupBox6 = new Sunny.UI.UIGroupBox();
            this.HyperControl = new Sunny.UI.UISwitch();
            this.HyperInstructions = new Sunny.UI.UISymbolButton();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.uiTabControl1 = new Sunny.UI.UITabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.uiSymbolButton1 = new Sunny.UI.UISymbolButton();
            this.MotionControl1 = new Sunny.UI.UISwitch();
            this.MotionPort1 = new Sunny.UI.UITextBox();
            this.uiLabel18 = new Sunny.UI.UILabel();
            this.uiLabel19 = new Sunny.UI.UILabel();
            this.MotionIP1 = new Sunny.UI.UITextBox();
            this.uiLabel17 = new Sunny.UI.UILabel();
            this.CodePort = new System.IO.Ports.SerialPort(this.components);
            this.uiGroupBox4.SuspendLayout();
            this.uiGroupBox2.SuspendLayout();
            this.uiGroupBox3.SuspendLayout();
            this.uiGroupBox5.SuspendLayout();
            this.uiGroupBox6.SuspendLayout();
            this.uiTabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiGroupBox4
            // 
            this.uiGroupBox4.Controls.Add(this.cbDeviceList);
            this.uiGroupBox4.Controls.Add(this.DepthLink);
            this.uiGroupBox4.Controls.Add(this.uiLabel5);
            this.uiGroupBox4.Controls.Add(this.ThemalInstructions);
            this.uiGroupBox4.FillColor = System.Drawing.Color.White;
            this.uiGroupBox4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox4.Location = new System.Drawing.Point(4, 310);
            this.uiGroupBox4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox4.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox4.Name = "uiGroupBox4";
            this.uiGroupBox4.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox4.Size = new System.Drawing.Size(239, 260);
            this.uiGroupBox4.TabIndex = 3;
            this.uiGroupBox4.Text = "深度相机连接";
            this.uiGroupBox4.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbDeviceList
            // 
            this.cbDeviceList.DataSource = null;
            this.cbDeviceList.FillColor = System.Drawing.Color.White;
            this.cbDeviceList.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbDeviceList.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.cbDeviceList.Items.AddRange(new object[] {
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10",
            "COM11",
            "COM12",
            "COM13"});
            this.cbDeviceList.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.cbDeviceList.Location = new System.Drawing.Point(7, 81);
            this.cbDeviceList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbDeviceList.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbDeviceList.Name = "cbDeviceList";
            this.cbDeviceList.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbDeviceList.Size = new System.Drawing.Size(226, 37);
            this.cbDeviceList.SymbolSize = 24;
            this.cbDeviceList.TabIndex = 13;
            this.cbDeviceList.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbDeviceList.Watermark = "";
            // 
            // DepthLink
            // 
            this.DepthLink.ActiveColor = System.Drawing.Color.Red;
            this.DepthLink.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DepthLink.InActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.DepthLink.Location = new System.Drawing.Point(145, 217);
            this.DepthLink.MinimumSize = new System.Drawing.Size(1, 1);
            this.DepthLink.Name = "DepthLink";
            this.DepthLink.Size = new System.Drawing.Size(91, 40);
            this.DepthLink.SwitchShape = Sunny.UI.UISwitch.UISwitchShape.Square;
            this.DepthLink.TabIndex = 5;
            this.DepthLink.Text = "uiSwitch1";
            this.DepthLink.ValueChanged += new Sunny.UI.UISwitch.OnValueChanged(this.ThemalControl_ValueChanged);
            // 
            // uiLabel5
            // 
            this.uiLabel5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel5.Location = new System.Drawing.Point(3, 181);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(154, 40);
            this.uiLabel5.TabIndex = 7;
            this.uiLabel5.Text = "深度相机开关";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ThemalInstructions
            // 
            this.ThemalInstructions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ThemalInstructions.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ThemalInstructions.IsCircle = true;
            this.ThemalInstructions.Location = new System.Drawing.Point(193, 35);
            this.ThemalInstructions.MinimumSize = new System.Drawing.Size(1, 1);
            this.ThemalInstructions.Name = "ThemalInstructions";
            this.ThemalInstructions.Size = new System.Drawing.Size(40, 35);
            this.ThemalInstructions.Symbol = 61736;
            this.ThemalInstructions.TabIndex = 7;
            this.ThemalInstructions.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ThemalInstructions.Click += new System.EventHandler(this.ThemalInstructions_Click);
            // 
            // uiGroupBox2
            // 
            this.uiGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiGroupBox2.Controls.Add(this.Camera2);
            this.uiGroupBox2.Controls.Add(this.uiLabel1);
            this.uiGroupBox2.Controls.Add(this.Camera1);
            this.uiGroupBox2.Controls.Add(this.CameraLink);
            this.uiGroupBox2.Controls.Add(this.uiLabel4);
            this.uiGroupBox2.Controls.Add(this.uiLabel12);
            this.uiGroupBox2.Controls.Add(this.RGBInstructions);
            this.uiGroupBox2.FillColor = System.Drawing.Color.White;
            this.uiGroupBox2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox2.Location = new System.Drawing.Point(610, 40);
            this.uiGroupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox2.Name = "uiGroupBox2";
            this.uiGroupBox2.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox2.Size = new System.Drawing.Size(240, 260);
            this.uiGroupBox2.TabIndex = 1;
            this.uiGroupBox2.Text = "双目相机连接";
            this.uiGroupBox2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiGroupBox2.Click += new System.EventHandler(this.uiGroupBox2_Click);
            // 
            // Camera2
            // 
            this.Camera2.DataSource = null;
            this.Camera2.FillColor = System.Drawing.Color.White;
            this.Camera2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Camera2.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.Camera2.Items.AddRange(new object[] {
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10",
            "COM11",
            "COM12",
            "COM13"});
            this.Camera2.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.Camera2.Location = new System.Drawing.Point(4, 138);
            this.Camera2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Camera2.MinimumSize = new System.Drawing.Size(63, 0);
            this.Camera2.Name = "Camera2";
            this.Camera2.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.Camera2.Size = new System.Drawing.Size(226, 37);
            this.Camera2.SymbolSize = 24;
            this.Camera2.TabIndex = 13;
            this.Camera2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.Camera2.Watermark = "";
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel1.Location = new System.Drawing.Point(3, 110);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(92, 31);
            this.uiLabel1.TabIndex = 13;
            this.uiLabel1.Text = "相机2";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Camera1
            // 
            this.Camera1.DataSource = null;
            this.Camera1.FillColor = System.Drawing.Color.White;
            this.Camera1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Camera1.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.Camera1.Items.AddRange(new object[] {
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10",
            "COM11",
            "COM12",
            "COM13"});
            this.Camera1.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.Camera1.Location = new System.Drawing.Point(4, 68);
            this.Camera1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Camera1.MinimumSize = new System.Drawing.Size(63, 0);
            this.Camera1.Name = "Camera1";
            this.Camera1.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.Camera1.Size = new System.Drawing.Size(226, 37);
            this.Camera1.SymbolSize = 24;
            this.Camera1.TabIndex = 12;
            this.Camera1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.Camera1.Watermark = "";
            // 
            // CameraLink
            // 
            this.CameraLink.ActiveColor = System.Drawing.Color.Red;
            this.CameraLink.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CameraLink.InActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.CameraLink.Location = new System.Drawing.Point(146, 217);
            this.CameraLink.MinimumSize = new System.Drawing.Size(1, 1);
            this.CameraLink.Name = "CameraLink";
            this.CameraLink.Size = new System.Drawing.Size(91, 40);
            this.CameraLink.SwitchShape = Sunny.UI.UISwitch.UISwitchShape.Square;
            this.CameraLink.TabIndex = 6;
            this.CameraLink.Text = "uiSwitch2";
            this.CameraLink.ValueChanged += new Sunny.UI.UISwitch.OnValueChanged(this.RGBcontrol_ValueChanged);
            // 
            // uiLabel4
            // 
            this.uiLabel4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel4.Location = new System.Drawing.Point(5, 189);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(154, 40);
            this.uiLabel4.TabIndex = 6;
            this.uiLabel4.Text = "双目相机开关";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel12
            // 
            this.uiLabel12.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel12.Location = new System.Drawing.Point(3, 32);
            this.uiLabel12.Name = "uiLabel12";
            this.uiLabel12.Size = new System.Drawing.Size(92, 40);
            this.uiLabel12.TabIndex = 11;
            this.uiLabel12.Text = "相机1";
            this.uiLabel12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RGBInstructions
            // 
            this.RGBInstructions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RGBInstructions.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RGBInstructions.IsCircle = true;
            this.RGBInstructions.Location = new System.Drawing.Point(196, 25);
            this.RGBInstructions.MinimumSize = new System.Drawing.Size(1, 1);
            this.RGBInstructions.Name = "RGBInstructions";
            this.RGBInstructions.Size = new System.Drawing.Size(40, 35);
            this.RGBInstructions.Symbol = 61736;
            this.RGBInstructions.TabIndex = 6;
            this.RGBInstructions.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RGBInstructions.Click += new System.EventHandler(this.RGBInstructions_Click);
            // 
            // uiGroupBox3
            // 
            this.uiGroupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiGroupBox3.Controls.Add(this.FluorPort);
            this.uiGroupBox3.Controls.Add(this.uiLabel11);
            this.uiGroupBox3.Controls.Add(this.FluorControl);
            this.uiGroupBox3.Controls.Add(this.uiLabel7);
            this.uiGroupBox3.Controls.Add(this.FluorInstructions);
            this.uiGroupBox3.FillColor = System.Drawing.Color.White;
            this.uiGroupBox3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox3.Location = new System.Drawing.Point(611, 307);
            this.uiGroupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox3.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox3.Name = "uiGroupBox3";
            this.uiGroupBox3.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox3.Size = new System.Drawing.Size(239, 260);
            this.uiGroupBox3.TabIndex = 4;
            this.uiGroupBox3.Text = "荧光相机连接";
            this.uiGroupBox3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiGroupBox3.Visible = false;
            // 
            // FluorPort
            // 
            this.FluorPort.DataSource = null;
            this.FluorPort.FillColor = System.Drawing.Color.White;
            this.FluorPort.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FluorPort.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.FluorPort.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.FluorPort.Location = new System.Drawing.Point(7, 81);
            this.FluorPort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FluorPort.MinimumSize = new System.Drawing.Size(63, 0);
            this.FluorPort.Name = "FluorPort";
            this.FluorPort.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.FluorPort.Size = new System.Drawing.Size(226, 37);
            this.FluorPort.SymbolSize = 24;
            this.FluorPort.TabIndex = 27;
            this.FluorPort.Text = "COM1";
            this.FluorPort.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.FluorPort.Watermark = "";
            // 
            // uiLabel11
            // 
            this.uiLabel11.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel11.Location = new System.Drawing.Point(3, 30);
            this.uiLabel11.Name = "uiLabel11";
            this.uiLabel11.Size = new System.Drawing.Size(92, 40);
            this.uiLabel11.TabIndex = 26;
            this.uiLabel11.Text = "串口：";
            this.uiLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FluorControl
            // 
            this.FluorControl.ActiveColor = System.Drawing.Color.Red;
            this.FluorControl.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FluorControl.InActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.FluorControl.Location = new System.Drawing.Point(145, 217);
            this.FluorControl.MinimumSize = new System.Drawing.Size(1, 1);
            this.FluorControl.Name = "FluorControl";
            this.FluorControl.Size = new System.Drawing.Size(91, 40);
            this.FluorControl.SwitchShape = Sunny.UI.UISwitch.UISwitchShape.Square;
            this.FluorControl.TabIndex = 7;
            this.FluorControl.Text = "uiSwitch5";
            this.FluorControl.ValueChanged += new Sunny.UI.UISwitch.OnValueChanged(this.FluorControl_ValueChanged);
            // 
            // uiLabel7
            // 
            this.uiLabel7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel7.Location = new System.Drawing.Point(3, 181);
            this.uiLabel7.Name = "uiLabel7";
            this.uiLabel7.Size = new System.Drawing.Size(137, 40);
            this.uiLabel7.TabIndex = 7;
            this.uiLabel7.Text = "荧光相机开关";
            this.uiLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FluorInstructions
            // 
            this.FluorInstructions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FluorInstructions.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FluorInstructions.IsCircle = true;
            this.FluorInstructions.Location = new System.Drawing.Point(196, 35);
            this.FluorInstructions.MinimumSize = new System.Drawing.Size(1, 1);
            this.FluorInstructions.Name = "FluorInstructions";
            this.FluorInstructions.Size = new System.Drawing.Size(40, 35);
            this.FluorInstructions.Symbol = 61736;
            this.FluorInstructions.TabIndex = 9;
            this.FluorInstructions.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FluorInstructions.Click += new System.EventHandler(this.FluorInstructions_Click);
            // 
            // uiGroupBox5
            // 
            this.uiGroupBox5.Controls.Add(this.LidarPort);
            this.uiGroupBox5.Controls.Add(this.LidarControl);
            this.uiGroupBox5.Controls.Add(this.uiLabel15);
            this.uiGroupBox5.Controls.Add(this.uiLabel6);
            this.uiGroupBox5.Controls.Add(this.LidarIP);
            this.uiGroupBox5.Controls.Add(this.uiLabel16);
            this.uiGroupBox5.Controls.Add(this.LidarInstructions);
            this.uiGroupBox5.FillColor = System.Drawing.Color.White;
            this.uiGroupBox5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox5.Location = new System.Drawing.Point(306, 310);
            this.uiGroupBox5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox5.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox5.Name = "uiGroupBox5";
            this.uiGroupBox5.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox5.Size = new System.Drawing.Size(239, 260);
            this.uiGroupBox5.TabIndex = 5;
            this.uiGroupBox5.Text = "激光雷达连接";
            this.uiGroupBox5.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiGroupBox5.Visible = false;
            // 
            // LidarPort
            // 
            this.LidarPort.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.LidarPort.DoubleValue = 5000D;
            this.LidarPort.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LidarPort.IntValue = 5000;
            this.LidarPort.Location = new System.Drawing.Point(107, 136);
            this.LidarPort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.LidarPort.MinimumSize = new System.Drawing.Size(1, 16);
            this.LidarPort.Name = "LidarPort";
            this.LidarPort.Padding = new System.Windows.Forms.Padding(5);
            this.LidarPort.ShowText = false;
            this.LidarPort.Size = new System.Drawing.Size(126, 40);
            this.LidarPort.TabIndex = 21;
            this.LidarPort.Text = "5000";
            this.LidarPort.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.LidarPort.Watermark = "";
            // 
            // LidarControl
            // 
            this.LidarControl.ActiveColor = System.Drawing.Color.Red;
            this.LidarControl.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LidarControl.InActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.LidarControl.Location = new System.Drawing.Point(145, 217);
            this.LidarControl.MinimumSize = new System.Drawing.Size(1, 1);
            this.LidarControl.Name = "LidarControl";
            this.LidarControl.Size = new System.Drawing.Size(91, 40);
            this.LidarControl.SwitchShape = Sunny.UI.UISwitch.UISwitchShape.Square;
            this.LidarControl.TabIndex = 8;
            this.LidarControl.Text = "uiSwitch1";
            this.LidarControl.ValueChanged += new Sunny.UI.UISwitch.OnValueChanged(this.LidarControl_ValueChanged);
            // 
            // uiLabel15
            // 
            this.uiLabel15.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel15.Location = new System.Drawing.Point(3, 136);
            this.uiLabel15.Name = "uiLabel15";
            this.uiLabel15.Size = new System.Drawing.Size(70, 40);
            this.uiLabel15.TabIndex = 22;
            this.uiLabel15.Text = "端口：";
            this.uiLabel15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel6
            // 
            this.uiLabel6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel6.Location = new System.Drawing.Point(3, 181);
            this.uiLabel6.Name = "uiLabel6";
            this.uiLabel6.Size = new System.Drawing.Size(130, 40);
            this.uiLabel6.TabIndex = 6;
            this.uiLabel6.Text = "激光雷达开关";
            this.uiLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LidarIP
            // 
            this.LidarIP.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.LidarIP.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LidarIP.Location = new System.Drawing.Point(7, 78);
            this.LidarIP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.LidarIP.MinimumSize = new System.Drawing.Size(1, 16);
            this.LidarIP.Name = "LidarIP";
            this.LidarIP.Padding = new System.Windows.Forms.Padding(5);
            this.LidarIP.ShowText = false;
            this.LidarIP.Size = new System.Drawing.Size(226, 40);
            this.LidarIP.TabIndex = 20;
            this.LidarIP.Text = "192.168.1.200";
            this.LidarIP.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.LidarIP.Watermark = "";
            this.LidarIP.TextChanged += new System.EventHandler(this.uiTextBox10_TextChanged);
            // 
            // uiLabel16
            // 
            this.uiLabel16.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel16.Location = new System.Drawing.Point(3, 42);
            this.uiLabel16.Name = "uiLabel16";
            this.uiLabel16.Size = new System.Drawing.Size(92, 40);
            this.uiLabel16.TabIndex = 19;
            this.uiLabel16.Text = "IP地址：";
            this.uiLabel16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LidarInstructions
            // 
            this.LidarInstructions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LidarInstructions.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LidarInstructions.IsCircle = true;
            this.LidarInstructions.Location = new System.Drawing.Point(196, 35);
            this.LidarInstructions.MinimumSize = new System.Drawing.Size(1, 1);
            this.LidarInstructions.Name = "LidarInstructions";
            this.LidarInstructions.Size = new System.Drawing.Size(40, 35);
            this.LidarInstructions.Symbol = 61736;
            this.LidarInstructions.TabIndex = 8;
            this.LidarInstructions.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LidarInstructions.Click += new System.EventHandler(this.LidarInstructions_Click);
            // 
            // uiGroupBox6
            // 
            this.uiGroupBox6.Controls.Add(this.HyperControl);
            this.uiGroupBox6.Controls.Add(this.HyperInstructions);
            this.uiGroupBox6.Controls.Add(this.uiLabel3);
            this.uiGroupBox6.FillColor = System.Drawing.Color.White;
            this.uiGroupBox6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox6.Location = new System.Drawing.Point(306, 40);
            this.uiGroupBox6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox6.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox6.Name = "uiGroupBox6";
            this.uiGroupBox6.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox6.Size = new System.Drawing.Size(239, 260);
            this.uiGroupBox6.TabIndex = 6;
            this.uiGroupBox6.Text = "高光谱相机连接";
            this.uiGroupBox6.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // HyperControl
            // 
            this.HyperControl.ActiveColor = System.Drawing.Color.Red;
            this.HyperControl.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.HyperControl.InActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.HyperControl.Location = new System.Drawing.Point(145, 217);
            this.HyperControl.MinimumSize = new System.Drawing.Size(1, 1);
            this.HyperControl.Name = "HyperControl";
            this.HyperControl.Size = new System.Drawing.Size(91, 40);
            this.HyperControl.SwitchShape = Sunny.UI.UISwitch.UISwitchShape.Square;
            this.HyperControl.TabIndex = 5;
            this.HyperControl.Text = "uiSwitch1";
            this.HyperControl.ValueChanged += new Sunny.UI.UISwitch.OnValueChanged(this.HyperControl_ValueChanged);
            // 
            // HyperInstructions
            // 
            this.HyperInstructions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HyperInstructions.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.HyperInstructions.IsCircle = true;
            this.HyperInstructions.Location = new System.Drawing.Point(196, 25);
            this.HyperInstructions.MinimumSize = new System.Drawing.Size(1, 1);
            this.HyperInstructions.Name = "HyperInstructions";
            this.HyperInstructions.Size = new System.Drawing.Size(40, 35);
            this.HyperInstructions.Symbol = 61736;
            this.HyperInstructions.TabIndex = 5;
            this.HyperInstructions.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.HyperInstructions.Click += new System.EventHandler(this.HyperInstructions_Click);
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel3.Location = new System.Drawing.Point(4, 174);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(154, 40);
            this.uiLabel3.TabIndex = 5;
            this.uiLabel3.Text = "高光谱相机开关";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiTabControl1
            // 
            this.uiTabControl1.Controls.Add(this.tabPage2);
            this.uiTabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.uiTabControl1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTabControl1.ItemSize = new System.Drawing.Size(75, 40);
            this.uiTabControl1.Location = new System.Drawing.Point(1, 40);
            this.uiTabControl1.MainPage = "";
            this.uiTabControl1.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.uiTabControl1.Name = "uiTabControl1";
            this.uiTabControl1.SelectedIndex = 0;
            this.uiTabControl1.Size = new System.Drawing.Size(242, 260);
            this.uiTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.uiTabControl1.TabBackColor = System.Drawing.Color.White;
            this.uiTabControl1.TabIndex = 7;
            this.uiTabControl1.TabSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.uiTabControl1.TabSelectedForeColor = System.Drawing.Color.Black;
            this.uiTabControl1.TabUnSelectedForeColor = System.Drawing.Color.Black;
            this.uiTabControl1.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.uiSymbolButton1);
            this.tabPage2.Controls.Add(this.MotionControl1);
            this.tabPage2.Controls.Add(this.MotionPort1);
            this.tabPage2.Controls.Add(this.uiLabel18);
            this.tabPage2.Controls.Add(this.uiLabel19);
            this.tabPage2.Controls.Add(this.MotionIP1);
            this.tabPage2.Controls.Add(this.uiLabel17);
            this.tabPage2.Location = new System.Drawing.Point(0, 40);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(242, 220);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "运动控制";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // uiSymbolButton1
            // 
            this.uiSymbolButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton1.IsCircle = true;
            this.uiSymbolButton1.Location = new System.Drawing.Point(196, 10);
            this.uiSymbolButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton1.Name = "uiSymbolButton1";
            this.uiSymbolButton1.Size = new System.Drawing.Size(40, 35);
            this.uiSymbolButton1.Symbol = 61736;
            this.uiSymbolButton1.TabIndex = 16;
            this.uiSymbolButton1.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton1.Click += new System.EventHandler(this.uiSymbolButton1_Click);
            // 
            // MotionControl1
            // 
            this.MotionControl1.ActiveColor = System.Drawing.Color.Red;
            this.MotionControl1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MotionControl1.InActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.MotionControl1.Location = new System.Drawing.Point(148, 177);
            this.MotionControl1.MinimumSize = new System.Drawing.Size(1, 1);
            this.MotionControl1.Name = "MotionControl1";
            this.MotionControl1.Size = new System.Drawing.Size(91, 40);
            this.MotionControl1.SwitchShape = Sunny.UI.UISwitch.UISwitchShape.Square;
            this.MotionControl1.TabIndex = 15;
            this.MotionControl1.Text = "uiSwitch1";
            this.MotionControl1.ValueChanged += new Sunny.UI.UISwitch.OnValueChanged(this.MotionControl1_ValueChanged);
            // 
            // MotionPort1
            // 
            this.MotionPort1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.MotionPort1.DoubleValue = 502D;
            this.MotionPort1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MotionPort1.IntValue = 502;
            this.MotionPort1.Location = new System.Drawing.Point(104, 104);
            this.MotionPort1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MotionPort1.MinimumSize = new System.Drawing.Size(1, 16);
            this.MotionPort1.Name = "MotionPort1";
            this.MotionPort1.Padding = new System.Windows.Forms.Padding(5);
            this.MotionPort1.ShowText = false;
            this.MotionPort1.Size = new System.Drawing.Size(126, 40);
            this.MotionPort1.TabIndex = 13;
            this.MotionPort1.Text = "502";
            this.MotionPort1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.MotionPort1.Watermark = "";
            // 
            // uiLabel18
            // 
            this.uiLabel18.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel18.Location = new System.Drawing.Point(3, 104);
            this.uiLabel18.Name = "uiLabel18";
            this.uiLabel18.Size = new System.Drawing.Size(70, 40);
            this.uiLabel18.TabIndex = 14;
            this.uiLabel18.Text = "端口：";
            this.uiLabel18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel19
            // 
            this.uiLabel19.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel19.Location = new System.Drawing.Point(6, 149);
            this.uiLabel19.Name = "uiLabel19";
            this.uiLabel19.Size = new System.Drawing.Size(133, 40);
            this.uiLabel19.TabIndex = 12;
            this.uiLabel19.Text = "运动控制开关";
            this.uiLabel19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MotionIP1
            // 
            this.MotionIP1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.MotionIP1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MotionIP1.Location = new System.Drawing.Point(10, 52);
            this.MotionIP1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MotionIP1.MinimumSize = new System.Drawing.Size(1, 16);
            this.MotionIP1.Name = "MotionIP1";
            this.MotionIP1.Padding = new System.Windows.Forms.Padding(5);
            this.MotionIP1.ShowText = false;
            this.MotionIP1.Size = new System.Drawing.Size(226, 40);
            this.MotionIP1.TabIndex = 6;
            this.MotionIP1.Text = "192.168.1.42";
            this.MotionIP1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.MotionIP1.Watermark = "";
            // 
            // uiLabel17
            // 
            this.uiLabel17.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel17.Location = new System.Drawing.Point(3, 9);
            this.uiLabel17.Name = "uiLabel17";
            this.uiLabel17.Size = new System.Drawing.Size(92, 40);
            this.uiLabel17.TabIndex = 2;
            this.uiLabel17.Text = "IP地址：";
            this.uiLabel17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CodePort
            // 
            this.CodePort.PortName = "COM5";
            this.CodePort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.ReadCode);
            // 
            // Link
            // 
            this.AllowShowTitle = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(854, 596);
            this.Controls.Add(this.uiTabControl1);
            this.Controls.Add(this.uiGroupBox6);
            this.Controls.Add(this.uiGroupBox3);
            this.Controls.Add(this.uiGroupBox2);
            this.Controls.Add(this.uiGroupBox4);
            this.Controls.Add(this.uiGroupBox5);
            this.Name = "Link";
            this.Padding = new System.Windows.Forms.Padding(0, 35, 0, 0);
            this.ShowTitle = true;
            this.Text = "设备连接";
            this.Initialize += new System.EventHandler(this.Link_Initialize);
            this.uiGroupBox4.ResumeLayout(false);
            this.uiGroupBox2.ResumeLayout(false);
            this.uiGroupBox3.ResumeLayout(false);
            this.uiGroupBox5.ResumeLayout(false);
            this.uiGroupBox6.ResumeLayout(false);
            this.uiTabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Sunny.UI.UIGroupBox uiGroupBox4;
        private Sunny.UI.UIGroupBox uiGroupBox2;
        private Sunny.UI.UIGroupBox uiGroupBox3;
        private Sunny.UI.UIGroupBox uiGroupBox5;
        private Sunny.UI.UIGroupBox uiGroupBox6;
        private Sunny.UI.UISwitch DepthLink;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UISymbolButton ThemalInstructions;
        private Sunny.UI.UISwitch CameraLink;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UISymbolButton RGBInstructions;
        private Sunny.UI.UISwitch FluorControl;
        private Sunny.UI.UILabel uiLabel7;
        private Sunny.UI.UISymbolButton FluorInstructions;
        private Sunny.UI.UISwitch LidarControl;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UISymbolButton LidarInstructions;
        private Sunny.UI.UISwitch HyperControl;
        private Sunny.UI.UISymbolButton HyperInstructions;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UIComboBox Camera1;
        private Sunny.UI.UILabel uiLabel12;
        private Sunny.UI.UITextBox LidarPort;
        private Sunny.UI.UILabel uiLabel15;
        private Sunny.UI.UITextBox LidarIP;
        private Sunny.UI.UILabel uiLabel16;
        private Sunny.UI.UIComboBox FluorPort;
        private Sunny.UI.UILabel uiLabel11;
        private Sunny.UI.UITabControl uiTabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private Sunny.UI.UISwitch MotionControl1;
        private Sunny.UI.UITextBox MotionPort1;
        private Sunny.UI.UILabel uiLabel18;
        private Sunny.UI.UILabel uiLabel19;
        private Sunny.UI.UITextBox MotionIP1;
        private Sunny.UI.UILabel uiLabel17;
        private Sunny.UI.UISymbolButton uiSymbolButton1;
        public System.IO.Ports.SerialPort CodePort;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIComboBox Camera2;
        private Sunny.UI.UIComboBox cbDeviceList;
    }
}