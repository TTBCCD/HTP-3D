using Basler.Pylon;
using Canondemo;
using NPOI.SS.UserModel;
using OpenCvSharp;
using Sample;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace m_CTP
{
    public partial class Link : UIPage
    {
        public static RGB_Set rgb_Set;
        public static HyperCamera_1 hyperCamera_1;
        public static HyperCamera_2 hyperCamera_2;
        public static DarkroomPLC darkroomPLC;
        public static TransmitPLC transmitPLC;
        public static MutiCamera_Set mutiCamera_Set;
        public static MutiCamera mutiCamera;
        public static Hyper hyper;
        public static Depth_Set depth_Set;
        public static Depth depth;
        public static bool LidarControlH = false;
        public static string LidarPathMa = "";//手动采集文件夹
        public static LidarHe16 lidarHe16;
        public static bool RGBControlH = false;
        public static bool HyperCameraControlH = false;
        public static System.Windows.Forms.ListView listView2 = null;
        public static System.Windows.Forms.ListBox listBox = null;
        public static VR3DConsole.VR3DConsole vR3D ;
        public static RFID rFID;
        public static bool RFIDIsConnected = false;
        public static bool darkroomPLCH = false;
        public static bool transmitPLCH = false;
        public static bool MutiCamera = false;
        public static bool Depth = false;
        public static string CodeName = null;
        public bool PlotHyperSate = false;//高光谱扫描状态
        public static PictureBox ca1;
        public static PictureBox ca2;
        //PictureBox pic1 = new PictureBox();
        //PictureBox pic2 = new PictureBox();

        public Link()
        {
            InitializeComponent();

        }

        private void uiTextBox10_TextChanged(object sender, EventArgs e)
        {

        }
        //高光谱连接
        private void HyperControl_ValueChanged(object sender, bool value)
        {
            if (true)//添加400-1700代码
            {
               
                hyperCamera_2 = new HyperCamera_2();
                //string dllPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "VixLib.dll");
                //Console.WriteLine(File.Exists(dllPath) ? "DLL 存在" : "DLL 缺失: " + dllPath);

                if (HyperControl.Active == true && HyperCameraControlH == false)
                {
                    HyperControl.Enabled = false;
                    hyperCamera_2.Camera_Init();
                    //hyperCamera_2.SetCameraTime(40);
                    HyperCameraControlH = true;
                    HyperControl.Enabled = true;
                }
                else
                {
                    HyperControl.Enabled = false;
                    hyperCamera_2.Camera_Exit();
                    HyperCameraControlH = false;
                    HyperControl.Enabled = true;
                }
                
            }
            else 
            {
                if (HyperControl.Active == true && HyperCameraControlH == false)
                {
                    HyperControl.Enabled = false;
                    //开高光谱线程
                    Thread t2 = new Thread(new ParameterizedThreadStart(Hyper_Set.initPylon));
                    t2.Start(Hyper_Set.hyperCamera);
                    HyperCameraControlH = true;
                    Hyper_Set.HyperSate = true;
                    PlotHyperSate = true;
                    HyperControl.Enabled = true;
                }
                else
                {
                    HyperControl.Enabled = false;
                    Hyper_Set.hyperCamera.close();
                    Hyper_Set.HyperSate = false;
                    HyperCameraControlH = false;
                    PlotHyperSate = false;
                    HyperControl.Enabled = true;
                }
            }
          
        }

        private void Link_Initialize(object sender, EventArgs e)
        {
            hyperCamera_1 = new HyperCamera_1();
           // hyperCamera_2 = new HyperCamera_2();
            darkroomPLC = new DarkroomPLC();
            transmitPLC = new TransmitPLC();
            rgb_Set = new RGB_Set();
            mutiCamera_Set=new MutiCamera_Set();

           
            //hyper=new Hyper();
            depth_Set =new Depth_Set();
          
        }

        private void MotionControl_ValueChanged(object sender, bool value)
        {
            //if (MotionControl.Active == true&& darkroomPLCH==false)
            //{
            //    darkroomPLC.ConnectPLC(MotionIP.Text, Convert.ToInt32(MotionPort.Text));
            //    darkroomPLCH = true;
            //}
            //else if (MotionControl.Active == false)
            //{
            //    darkroomPLC.ClosePLC();
            //    darkroomPLCH = false;
            //}

        }
        //深度相机连接

        private void ThemalControl_ValueChanged(object sender, bool value)
        {
            
            if (DepthLink.Active == true && Depth == false)

            {
                DepthLink.Enabled = false;
                depth = new Depth();
                //depth_Set.DeviceListAcq();
                //depth_Set.OpenDepth_Click(null, null);
                //depth_Set.StartPreview_Click(null,null);
                depth.DeviceListAcq(cbDeviceList);
                depth.OpenDepth();
                
              //depth.StartPreview(pictureBox1);
                Depth = true;
                Form1.ProgramChecking = "深度相机连接成功";
                DepthLink.Enabled = true;
            }
            else if (DepthLink.Active == false)
            {
                DepthLink.Enabled = false;
                depth.StopPreview();
                //depth_Set.CloseDepth_Click(null, null);
                //depth_Set.StopPreview_Click(null, null); 
                PictureBox pictureBox = new PictureBox();
                depth.CloseDepth(pictureBox);

                Depth = false;
                DepthLink.Enabled = true;

            }
        }

        private void MotionInstructions_Click(object sender, EventArgs e)
        {
            UIMessageBox.Show("暗室控制模块连接，可编程控制器PLC连接。", UILocalize.InfoTitle, Style);
        }

        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            UIMessageBox.Show("传送带控制模块连接，可编程控制器PLC连接。", UILocalize.InfoTitle, Style);
        }

        private void uiSymbolButton2_Click(object sender, EventArgs e)
        {
            UIMessageBox.Show("RFID模块连接，RFID用于读取植株信息。", UILocalize.InfoTitle, Style);
        }

        private void HyperInstructions_Click(object sender, EventArgs e)
        {
            UIMessageBox.Show("高光谱相机连接，该版本采用串口连接，自动识别相机ID，IP地址不需要设置。", UILocalize.InfoTitle, Style);
        }

        private void RGBInstructions_Click(object sender, EventArgs e)
        {
            UIMessageBox.Show("RGB相机采用串口连接，3台相机会自动识别串口，控制模块串口需要手动设置。", UILocalize.InfoTitle, Style);
        }

        private void ThemalInstructions_Click(object sender, EventArgs e)
        {
            UIMessageBox.Show("该版本不包含热红外相机软件。", UILocalize.InfoTitle, Style);
        }

        private void LidarInstructions_Click(object sender, EventArgs e)
        {
            UIMessageBox.Show("激光雷达采用IP地址连接，默认IP地址即可，如果激光雷达IP地址发生改变，需要手动IP地址。", UILocalize.InfoTitle, Style);
        }

        private void FluorInstructions_Click(object sender, EventArgs e)
        {
            UIMessageBox.Show("该版本不包含荧光相机软件", UILocalize.InfoTitle, Style);
        }

        private void MotionControl1_ValueChanged(object sender, bool value)
        {
            if (MotionControl1.Active == true&& darkroomPLCH == false)
            {
                darkroomPLC.ConnectPLC(MotionIP1.Text, Convert.ToInt32(MotionPort1.Text));
                darkroomPLCH = true;
           
            }
            else if (MotionControl1.Active == false)
            {
                darkroomPLC.ClosePLC();
                darkroomPLCH = false;

            }
        }
     

        private void LidarControl_ValueChanged(object sender, bool value)
        {
            if (LidarControl.Active == true)
            {
                LidarControlH = true;
                LidarPathMa = CreatInform.ProjectFolderPath + "\\" + "Lidar";
               
                if (!Directory.Exists(LidarPathMa))
                {
                    Directory.CreateDirectory(LidarPathMa);

                }
                else
                {
                    MessageBox.Show("该路径已存在");
                }
                lidarHe16 = new LidarHe16();
                Form1.ProgramChecking = "激光雷达连接成功";
            }
            else if(LidarControl.Active == false)
            {
                LidarControlH = false;
                Form1.ProgramChecking = "激光雷达断开连接";
            }
        }

        private void uiGroupBox2_Click(object sender, EventArgs e)
        {
          
        }
        public void search()
        {

        }
        private void RGBcontrol_ValueChanged(object sender, bool value)
        {
            if (CameraLink.Active == true&&MutiCamera==false)
            {
                CameraLink.Enabled = false;
                mutiCamera = new MutiCamera();
                mutiCamera.search( Camera1,Camera2);
               
                mutiCamera.OpenCamera();
                ca1 = new PictureBox();
                ca2 = new PictureBox();
               mutiCamera.StartGrabbing(ca1, ca2);
                //mutiCamera_Set.show_Click(null,null);
                //mutiCamera_Set.search_Click(null,null);
                //mutiCamera_Set.open();
                // mutiCamera_Set.Open_Click(null,null);
                //mutiCamera.StartGrabbing( );
                MutiCamera = true;
                //Camera2.Text = "aaa";
                CameraLink.Enabled = true;
            }
            else if (CameraLink.Active == false)
            {
                CameraLink.Enabled = false;
                //mutiCamera_Set.close();
                mutiCamera.CloseCamera();
                MutiCamera = false;
                CameraLink.Enabled = true;

            }
        }

        private void MotionControl2_ValueChanged(object sender, bool value)
        {
           
            //if (MotionControl2.Active == true && RFIDIsConnected == false)
            //{
            //    MotionControl2.Enabled = false;
            //    CodePort.Open();
               
            //    if (CodePort.IsOpen)
            //    {
            //        MessageBox.Show("连接成功");
            //        RFIDIsConnected = true;
            //    }
            //    else 
            //    {
            //        RFIDIsConnected = false;
            //        MessageBox.Show("连接失败");
            //    }
            //    MotionControl2.Enabled = true;
            //}
            //else if (MotionControl2.Active == false)
            //{
            //    MotionControl2.Enabled = false;
            //    CodePort.Close();
            //    CodePort.Dispose();
            //    RFIDIsConnected = false;
            //    MotionControl2.Enabled = true;
            //}
        }

        public  void DisPort()
        {
            if (RFIDIsConnected)
            {
                CodePort.Close();
                CodePort.Dispose();

            }
        }

        private void FluorControl_ValueChanged(object sender, bool value)
        {

        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            //HyperPort.Text =  hyperCamera_1.GetCameraFps().ToString();
        }

        private void ReadCode(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string str = CodePort.ReadLine();
            string s = str.Replace("\r", null);
            string s1 = s.Replace("\n", null);
            CodeName = s1;

            this.Invoke((EventHandler)(delegate
            {
               // uiTextBox1.Text = CodeName;
            }
            )
           );
          //  CodePort.DiscardInBuffer();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss");// 2008-09-04//
            string filePath = "D:\\hyper\\" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss");//以时间日期为准创建文件夹路径
            Hyper_Set.hyperCamera.startGrab(filePath);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Hyper_Set.isrun = false;
            Hyper_Set.hyperCamera.stopGrab();
        }
    }
}
