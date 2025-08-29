using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Basler.Pylon;
using OpenCvSharp;
using Sunny.UI;

namespace m_CTP
{
    public partial class Hyper_Set : UIPage
    {
        private delegate void StartDevGrad(string str) ;
        private delegate void StopDevGrad(string str);
        private string MannulHyperPath = "";
        public static string HyperFileName = "";
        public static string HyperFileId = "";
        //public  Thread STR;
        //public  Thread SOR;
        internal static HyperSpecCamera hyperCamera;
        static PictureBox PylonimgDraw;
        public static bool HyperSate = false;
        static bool isrun = true;
      
        public Hyper_Set()
        {
            InitializeComponent();
            PylonimgDraw = pictureBox1;
        }

        private void Hyper_Set_Load(object sender, EventArgs e)
        {

        }

        private void OpenHyper_Click(object sender, EventArgs e)
        {
            //if (Link.HyperCameraControlH == true)
            //{
            //    UIMessageBox.Show("相机已经打开", UILocalize.InfoTitle, Style);
            //}
            //else 
            //{
            //        Link.hyperCamera_1.Camera_Init();
            //        CloseHyper.Enabled = true;
            //        Link.HyperCameraControlH = true; 
            //}
            if (Link.HyperCameraControlH == true) 
            {
                if (!HyperSate)
                {
                    hyperCamera.open();
                    HyperSate = true;
                }
            }
        }
        public static void startC() 
        {
            Link.hyperCamera_1.Camera_Init();
        }
        public static void StopC()
        {
            HyperCamera_1.Vix_Exit();
        }

        private void StartCollection_Click(object sender, EventArgs e)
        {
            if (StartCollection.Enabled == true)
            {

                if (HyperPath.Text == null || HyperPath.Text == "")
                {
                    MannulHyperPath = "D:\\" + "hyper";
                    HyperFileName = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                }
                else
                {
                    MannulHyperPath = HyperPath.Text;
                    HyperFileName = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                }
                StartHyperGrad(MannulHyperPath);
                StartCollection.Enabled = false;
                StopCollection.Enabled = true;
                Form1.ProgramChecking = "高光谱手动采集开启";
            }

            //try
            //{
            //    if (Link.HyperCameraControlH && HyperSate)
            //    {
            //        if (HyperPath.Text == null || HyperPath.Text == "") //string.Empty
            //        {
            //            DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss");// 2008-09-04//
            //            string filePath = "D:\\hyper\\" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss");//以时间日期为准创建文件夹路径
            //            hyperCamera.startGrab(filePath);
            //        }
            //        else
            //        {
            //            DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss");// 2008-09-04//
            //            string filePath = HyperPath.Text + "\\" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss");//以时间日期为准创建文件夹路径
            //            hyperCamera.startGrab(filePath);
            //        }

            //    }
            //}
            //catch 
            //{
            //    Console.WriteLine("设备连接失败");
            //}


        }
        public static void StartHyperGrad(string str)//开始采集
        {
            //Link.hyperCamera_1.StartCamera(str);
            if (Link.HyperCameraControlH && HyperSate)
            {
               // string str2 = str.ToString();
                //DateTime.Now.ToString("yyyy-MM-dd-hh-mm");// 2008-09-04//
                string filePath = str + "\\" + HyperFileName;//以时间日期为准创建文件夹路径
                hyperCamera.startGrab(filePath);
            } 
        }

        private void StopCollection_Click(object sender, EventArgs e)
        {
            //if (StopCollection.Enabled == true)
            //{
            //    StopHyperGrad(MannulHyperPath);//停止采集
            //    StartCollection.Enabled = true;
            //    Form1.ProgramChecking = "高光谱手动采集停止";
            //}
            if (Link.HyperCameraControlH && HyperSate)
            {
                isrun = false;
                hyperCamera.stopGrab();
            }
        }
        public static void StopHyperGrad(string str)//开始采集
        {
            //Link.hyperCamera_1.StopCamera(str);
            if (Link.HyperCameraControlH && HyperSate)
            {
                isrun = false;
                hyperCamera.stopGrab();
            }
        }
        private void R_acquisition_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ParameterizedThreadStart(CaliGrad));
            thread.Start(R_acquisition);

        }

        public void CaliGrad(object obj) 
        {
            UIButton button = obj as UIButton;
            button.FillColor = Color.Red;
            uiTabControl1.Enabled = false;
            string str = "D:\\calibrate\\hyper";
            Link.transmitPLC.LightControl(true);
            Form1.ProgramChecking = "参考板采集开始";
            Link.transmitPLC.Slide_2_Forward(Convert.ToDouble(UserTask.AutoSpeedH), 2, true);
            //高光谱扫描创建委托
            HyperFileName = "cali";
            StartHyperGrad(str);
            Thread.Sleep(30000);

            Link.transmitPLC.Slide_2_Forward(Convert.ToDouble(UserTask.AutoSpeedH), 2, false);
            //停止高光谱
            Thread.Sleep(1000);
            StopHyperGrad(str);
            Link.transmitPLC.LightControl(false);
            Thread.Sleep(1000);
            Link.transmitPLC.Slide_2_Back(Convert.ToDouble(UserTask.AutoSpeedH), 2, true);
            Thread.Sleep(30000);
            Link.transmitPLC.Slide_2_Back(Convert.ToDouble(UserTask.AutoSpeedH), 2, false);
            button.FillColor = Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            Form1.ProgramChecking = "参考板采集结束";
            uiTabControl1.Enabled = true;
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
          
        }

        private void SaveSet_Click(object sender, EventArgs e)
        {
            HyperSpecCamera.r_row = Convert.ToInt32(Gain.Text);
            HyperSpecCamera.g_row = Convert.ToInt32(GainLevel.Text);
            HyperSpecCamera.b_row = Convert.ToInt32(uiTextBox1.Text);
            bool is_qcq = false;
            if (hyperCamera.camera.StreamGrabber.IsGrabbing)
            {
                is_qcq = true;
                hyperCamera.stopGrab();//停止数据流

            }
            HyperSpecCameraParameters p = new HyperSpecCameraParameters();
            p.ExposureTimeAbs = Convert.ToDouble(HyperExposureTime.Text);
            p.AcquisitionFrameRateAbs = Convert.ToDouble(HyperFrameRate.Text);
            hyperCamera.setParameters(p);
            if (is_qcq)
            {
                //  m_camera.StreamGrabber.Start();
                hyperCamera.startGrab();
            }

        }

        private void HyperSelectPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择文件路径";
            dialog.RootFolder = Environment.SpecialFolder.Desktop;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var selectFolder = dialog.SelectedPath;
                HyperPath.Text = dialog.SelectedPath;
            }
        }

        private void CloseHyper_Click(object sender, EventArgs e)
        {
            //if (Link.HyperCameraControlH == false)
            //{
            //    UIMessageBox.Show("相机已关闭", UILocalize.InfoTitle, Style);
            //}
            //else 
            //{
            //    Link.HyperCameraControlH = false;
            //    HyperCamera_1.Vix_Exit();
            //}
            if (HyperSate) 
            {
                hyperCamera.close();
                HyperSate = false;
            }
        }

        private void LightControl_Click(object sender, EventArgs e)
        {
            if (LightControl.Text == "打开光源")
            {

                LightControl.Text = "关闭光源";
                LightControl.FillColor = Color.Red;
                Link.transmitPLC.LightControl(true);
                Form1.ProgramChecking = "打开高光谱光源";
            }
            else if (LightControl.Text == "关闭光源")
            {
                LightControl.Text = "打开光源";
                Link.transmitPLC.LightControl(false);
                LightControl.FillColor = Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
                Form1.ProgramChecking = "关闭高光谱光源";
            }
        }

        private void Hyper_Set_Initialize(object sender, EventArgs e)
        {

        }
        public static void initPylon(object data)
        {
            // The exit code of the sample application.
           
            int exitCode = 0;
            //Mat img =  Cv2.ImRead("./8517891.jpg");
            //Mat image = new OpenCvSharp.Mat(300, 480, OpenCvSharp.MatType.CV_16UC1, new OpenCvSharp.Scalar(255));
            //image.ConvertTo(image, MatType.CV_8U);

            //Cv2.ImShow("image", image);
            //Cv2.WaitKey(0);
            try
            {

                // 创建高光谱相机类实例，依次调用检测设备，打开设备，设置参数。
                hyperCamera = new HyperSpecCamera();
                hyperCamera.detectDevices();
                hyperCamera.open();
                HyperSpecCameraParameters p = new HyperSpecCameraParameters(); // 使用默认的参数，同原来代码里的参数
                hyperCamera.setParameters(p);
                hyperCamera.camera.StreamGrabber.ImageGrabbed += OnImageGrabbed; // 订阅
                MessageBox.Show("连接成功");
            }
            catch (Exception e)
            {
                DataAcquisition.PlotConnectHyperSate = false;
                hyperCamera.close();
                //Console.Error.WriteLine("Exception: {0}", e.Message);
                MessageBox.Show("Exception: {0}", e.Message);
                exitCode = 1;
                MessageBox.Show("连接失败");
            }
            finally
            {
               DataAcquisition.PlotConnectHyperSate = true;
                // Comment the following two lines to disable waiting on exit.
                //Console.Error.WriteLine("\nPress enter to exit.");
               // MessageBox.Show("Press enter to exit");
               // Console.ReadLine();
            }

            //Environment.Exit(exitCode);
        }
        static void OnImageGrabbed(Object sender, ImageGrabbedEventArgs e)//数据流回调函数
        {
            // The grab result is automatically disposed when the event call back returns.
            // The grab result can be cloned using IGrabResult.Clone if you want to keep a copy of it (not shown in this sample).
            IGrabResult grabResult = e.GrabResult;
            // Image grabbed successfully?
            if (grabResult.GrabSucceeded)
            {


                hyperCamera.receiveGrabResult(grabResult); // 首先需要接收抓取的一帧数据结果，之后才能运行下面的获取最大值和获取光谱图像
                int maxSpecValue = hyperCamera.getMaxSpectralValue();
                // _label17.Text = Convert.ToString(maxSpecValue);//将数值赋值给label

                Mat rgb_mat = hyperCamera.getColormap();
                System.Drawing.Image drawImage = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(rgb_mat);
                //德会修改建立委托
                //Graphics g1 = PylonimgDraw.CreateGraphics();//画布
                ////g1.Clear(Color.White);
                //g1.DrawImage(drawImage, new PointF(0, 0));
                //drawImage.Dispose();
                //g1.Dispose();
                //g1 = null;
                //e.Graphics.DrawImage(drawImage, drawImageStartPos);
                PylonimgDraw.Invoke(new MethodInvoker(() =>
                {
                    Graphics g1 = PylonimgDraw.CreateGraphics();//画布
                    //g1.Clear(Color.White);
                    g1.DrawImage(drawImage, new PointF(0, 0));
                    drawImage.Dispose();
                    g1.Dispose();
                    g1 = null;
                }));
                hyperCamera.writeToFile();
            }
            else
            {
                Console.WriteLine("Error: {0} {1}", grabResult.ErrorCode, grabResult.ErrorDescription);
            }
        }

        private void StartPreview_Click(object sender, EventArgs e)
        {
            if (Link.HyperCameraControlH&&HyperSate)
            {
                if (!hyperCamera.camera.StreamGrabber.IsGrabbing)
                    hyperCamera.startGrab();
            }
           
        }

        private void StopPreview_Click(object sender, EventArgs e)
        {
            if (Link.HyperCameraControlH && HyperSate) 
            {
                if (hyperCamera != null && hyperCamera.camera.StreamGrabber.IsGrabbing)
                    hyperCamera.stopGrab1();
            }  
        }

        private void uiButton1_Click_1(object sender, EventArgs e)
        {
            if (Link.transmitPLCH == true)
            {
                if (uiButton1.Text == "滑台前进")
                {
                    //ink.darkroomPLC.Slide_1_Forward(Convert.ToDouble(Slide1ForwardSpeed.Text), Convert.ToDouble(Slide1ForwardDis.Text), true);
                    Link.transmitPLC.Slide_2_Forward(200, 2, true);
                    uiButton1.Text = "停止前进";
                    //uiButton1.Enabled = false;
                    //Slide1Forward.FillColor = Color.Red;
                    Form1.ProgramChecking = "水平滑台前进";
                }
                else
                {
                    //ink.darkroomPLC.Slide_1_Forward(Convert.ToDouble(Slide1ForwardSpeed.Text), Convert.ToDouble(Slide1ForwardDis.Text), false);
                    Link.transmitPLC.Slide_2_Forward(200,2, false);
                    uiButton1.Text = "滑台前进";
                   // Slide1Back.Enabled = true;
                    //Slide1Forward.FillColor = Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
                    Form1.ProgramChecking = "水平滑台停止前进";
                }
            }
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            if (Link.transmitPLCH == true)
            {
                if (uiButton2.Text == "滑台后退")
                {
                    // Link.darkroomPLC.Slide_1_Back(Convert.ToDouble(Slide1BackSpeed.Text), Convert.ToDouble(Slide1BackDis.Text), true);
                    Link.transmitPLC.Slide_2_Back(200, 2, true);
                    uiButton2.Text = "停止后退";
                    //Slide1Forward.Enabled = false;
                    //Slide1Back.FillColor = Color.Red;
                    Form1.ProgramChecking = "水平滑台后退";
                }
                else
                {
                    // Link.darkroomPLC.Slide_1_Back(Convert.ToDouble(Slide1BackSpeed.Text), Convert.ToDouble(Slide1BackDis.Text), false);
                    Link.transmitPLC.Slide_2_Back(200, 2, false);
                    uiButton2.Text = "滑台后退";
                    //Slide1Forward.Enabled = true;
                   // Slide1Back.FillColor = Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
                    Form1.ProgramChecking = "水平滑台停止后退";
                }
            }
        }
    }
}
