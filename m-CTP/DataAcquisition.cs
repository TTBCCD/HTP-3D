using Basler.Pylon;
using Canondemo;
using EDSDKLib;
using MathNet.Numerics;
using NPOI.OpenXmlFormats;
using NPOI.SS.UserModel;
using Sunny.UI;
using Sunny.UI.Demo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace m_CTP
{
    public partial class DataAcquisition : UIPage
    {
        private int MearModeIndex = 0;//0:空模式 1：测量模式 2：装载模式 3：卸载模式
        public static bool CanMear = false;
        public static string GlobleTaskPath = "";
        public static string GlobleTaskID = "";
        public static string TaskTime = "";
        public static string interExcelFile = "";
        public static string DataFile = "";
        public static string PlotName = "null";
        public static string GloblePlotID = "0";
        public static string PlotPath = "";
        public static string PlotPath_RGB = "";
        public static string PlotPath_Hyper = "";
        public static string PlotPath_Lidar = "";
        public static string PlotPath_Themal = "";
        public static string PlotPath_Flour = "";
        public static string PlotPath_Depth = "";
        public static string Calibrate = "";
        public static string HyperCaliPath = "";
        public static string RGBCaliPath = "";
        public static string DepthCaliPath = "";
        public static string LidarCaliPath = "";
        public static string ThermalCaliPath = "";
        public static string TaskName = "";
        public static string PlantName = "";
        public static bool start = false;
        public static bool slide1 = false;
        public int Times = 0;
        public int Times_H = 0;
        public int TeTimes = 0;
        public bool StopLoop = false;
        public int TaskIdIndex = 0;
        public int PlotIdIndex = 0;
        private delegate void StartDevGrad1();
        public static bool mearLoopControl = false;
        public static bool mearLoopControl_H = false;
        public static bool SingleMearComplete = true;//true：可以进行下一株测量，false：上一株测量未完成
        public static bool SingleMearComplete_H = true;//true：可以进行下一株测量，false：上一株测量未完成
        public List<PlotInfor> pl = new List<PlotInfor>();
        public double SlideBackSpeed = 0.1;//0.1m/s
        public double WeighingNum = 0;
        public  bool StopCheck = false;
        public bool StopCheck_H = false;
        public string WeighPlotName = "";
        public string RGBcaliname = "";
        public string RGBcalID = "";
        public bool FlushComtrol = false;
        public string PlotHyper = null;
        public bool PlotHyper_H = false;//高光谱扫描状态
        public bool PlotHyperSate = true;//高光谱扫描状态
        public static bool PlotConnectHyperSate = false;//高光谱扫描状态
        public string MutiCameraPath = "C:\\Users\\SF\\Desktop\\test";

        private CancellationTokenSource _cts;
        private bool _isAcquisitionRunning;

        public DataAcquisition()
        {
            InitializeComponent();
        }


        private void Creat_Click(object sender, EventArgs e)
        {
            if (UserInform.GlobleProjectPath  != "" &&UserInform.GlobleProjectPath != null)
            {

                TaskName = "TASK" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm");
                GlobleTaskPath = UserInform.GlobleProjectPath + "\\" + TaskName;//创建TASK文件夹GlobleProjectPath=D:\mctp\rubber\pro\
                CreatExcel.CreateDirectory(GlobleTaskPath);
                Calibrate = GlobleTaskPath + "\\calibrate";
                HyperCaliPath = Calibrate + "\\hyper";
                RGBCaliPath = Calibrate + "\\rgb";

                CreatExcel.CreateDirectory(Calibrate);
                CreatExcel.CreateDirectory(HyperCaliPath);
                CreatExcel.CreateDirectory(RGBCaliPath);
                //CreatExcel.CreateDirectory(DepthCaliPath);


                GlobleTaskID = DateTime.Now.ToString("yyyyMMss") + TaskIdIndex.ToString();
                TaskIdIndex++;
                TaskTime = DateTime.Now.ToString("yyyy/M/d");
                //创建服务器上传文件
                interExcelFile = "D:\\" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".mh";
                CreatExcel.CreatFile(interExcelFile);


                if (Link.HyperCameraControlH)
                {
                    Hyper.HyperFileName = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "-" + 0.ToString("00");
                    Hyper.HyperFileId = DateTime.Now.ToString("yyyyMMddHHmmss") + 0.ToString("00");
                    string str = HyperCaliPath + "\\" + Hyper_Set.HyperFileName + ".img";
                    string str1 = HyperCaliPath + "\\" + Hyper_Set.HyperFileName + ".hdr";
                    File.Copy("D:\\calibrate\\hyper\\cali.img", str, true);//将参考板数据拷贝到任务内
                    File.Copy("D:\\calibrate\\hyper\\cali.hdr", str1, true);//将参考板数据拷贝到任务内
                    CreatExcel.InterData(interExcelFile, "0", "1", "hyper", Hyper.HyperFileId, Hyper.HyperFileName);
                }
                if (Link.MutiCamera)
                {
                    MutiCamera.RGBFileName1 = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "-" + 0.ToString("001");
                    MutiCamera.RGBFileId1 = DateTime.Now.ToString("yyyyMMddHHmmss") + 0.ToString("001");
                    MutiCamera.RGBFileName2 = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "-" + 0.ToString("002");
                    MutiCamera.RGBFileId2 = DateTime.Now.ToString("yyyyMMddHHmmss") + 0.ToString("002");
                    string str = RGBCaliPath + "\\" + MutiCamera.RGBFileName1 + ".jpg";
                    string str2 = RGBCaliPath + "\\" + MutiCamera.RGBFileName2 + ".jpg";
                    File.Copy("D:\\calibrate\\rgb\\cali1.jpg", str, true);//将参考板数据拷贝到任务内
                    File.Copy("D:\\calibrate\\rgb\\cali2.jpg", str2, true);//将参考板数据拷贝到任务内
                    CreatExcel.InterData(interExcelFile, "0", "1", "rgb", MutiCamera.RGBFileId1, MutiCamera.RGBFileName1);
                    CreatExcel.InterData(interExcelFile, "0", "1", "rgb", MutiCamera.RGBFileId2, MutiCamera.RGBFileName2);
                }

                uiTextBox1.Text = "rubber";//用户名称
                proName.Text = UserInform.Projectselect;//项目名称
                tbtaskName.Text = TaskName;//任务名称
            }
            else
            {
                MessageBox.Show("进入项目列表，请先加载项目");
            }
            
        }
        private async void Cali_Click_1(object sender, EventArgs e)
        {
            Cali.Enabled = false;
            try
            {
                await StartCaliAcquProcess();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"错误: {ex.Message}");
            }
            finally
            {
                Cali.Enabled = true;
            }
        }
        
        //参考板采集

        private async Task StartCaliAcquProcess()
        {
            double distance = UserTask.SportDistance;

            if (UserTask.asLight)
            {
                Link.darkroomPLC.LightControl(true);
            }
            if (UserTask.LEDTop)
            {
                Link.darkroomPLC.LED1_Control(true);
            }
           //先走20cm再拍
            Link.darkroomPLC.Slide_1_Forward(UserTask.SportSpeed, 0.2, true);//设置滑台距离
           
            await Task.Delay(500);
            slide1 = true;

            HyperCaliPath = "D:\\calibrate\\hyper";
            RGBCaliPath = "D:\\calibrate\\rgb\\";
            while (Link.darkroomPLC.SlideSateRead_1())
            {
                await Task.Delay(100);
                

            }
            if (Link.HyperCameraControlH)
                {
                    Hyper_Set.HyperFileName = "cali";
                    Link.hyperCamera_2.StartCamera(HyperCaliPath);

                }

            Link.darkroomPLC.Slide_1_Forward(UserTask.SportSpeed, 0.2, false);


            Link.darkroomPLC.Slide_1_Forward(UserTask.SportSpeed,0.5, true);
            // 2. 等待滑台停止并关闭高光谱相机
            while (Link.darkroomPLC.SlideSateRead_1())
            {
                await Task.Delay(100);

            }

            if (Link.HyperCameraControlH) 
            { 
                Link.hyperCamera_2.StopCamera(HyperCaliPath);
            }
            if (UserTask.asLight)
            {
                Link.darkroomPLC.LightControl(false);
            }
            Link.darkroomPLC.Slide_1_Forward(UserTask.SportSpeed, 0.5, false);//设置滑台距离







            await Task.Delay(500);

            Link.darkroomPLC.Slide_1_Back(UserTask.SportSpeed, 0.35, true);//设置滑台距离1
                                                                           //4.到达指定位置 拍摄图片
                                                                           //滑台在中间位置拍摄
            if (UserTask.LEDBottom)
            {
                Link.darkroomPLC.LED2_Control(true);
            }
            while (Link.darkroomPLC.SlideSateRead_1())
           {
                    await Task.Delay(100);

           }
           Link.darkroomPLC.Slide_1_Back(UserTask.SportSpeed, 0.35, false);//设置滑台距离1
            if (Link.MutiCamera)
            {
                Link.mutiCamera.bnTriggerExec();
                string[] str = new string[2];
                str[0] = "cali1.jpg";
                str[1] = "cali2.jpg";
                Link.mutiCamera.savejpg(RGBCaliPath, str);
            }

            if (Link.Depth) 
            {

            }
            await Task.Delay(500);
            if (UserTask.LEDBottom)
            {
                Link.darkroomPLC.LED2_Control(false);
            }
            if (UserTask.LEDTop)
            {
                Link.darkroomPLC.LED1_Control(false);
            }
            //重写深度图像保存，外加上传数据对应表
            Link.darkroomPLC.Slide_1_Back(UserTask.SportSpeed, 0.5, true);//设置滑台距离2
           while (Link.darkroomPLC.SlideSateRead_1())
           {
             await Task.Delay(100);

           }
           Link.darkroomPLC.Slide_1_Back(UserTask.SportSpeed, 0.5, false);//设置滑台距离2
        }

        private async void MeasureStart_Click(object sender, EventArgs e)
        {
            MeasureStart.Enabled = false;
            _isAcquisitionRunning = true;
            _cts = new CancellationTokenSource();
            try
            {
                await StartAcquisitionProcess(_cts.Token);
            }
            catch (Exception ex)
            {
               // MessageBox.Show($"错误: {ex.Message}");
            }
            finally
            {
                _isAcquisitionRunning = false;
                MeasureStart.Enabled = true;
                _cts?.Dispose(); // 释放资源
            }

        }

        //开始采集
        private async Task StartAcquisitionProcess(CancellationToken token)
        {
            double distance =UserTask.SportDistance;

            PlotName =plantName.Text;
            if (judgePlotDouble(PlotName))
            {
                PlotName = PlotName + "-" + DateTime.Now.ToString("HHmmss");
                PlotPath = GlobleTaskPath + "\\" + PlotName;
            }
            else
            {
                //创建文件存储路径
                PlotPath = GlobleTaskPath + "\\" + PlotName;
            }

            //获取盆栽名称 ID
            GloblePlotID = judgePlotID(PlotName);
            PlotPath_RGB = PlotPath + "\\rgb";
            PlotPath_Depth = PlotPath + "\\depth";
            CreatExcel.CreateDirectory(PlotPath);
            CreatExcel.CreateDirectory(PlotPath_RGB);
            CreatExcel.CreateDirectory(PlotPath_Depth);
            PlotPath_Hyper = PlotPath + "\\hyper";
            CreatExcel.CreateDirectory(PlotPath_Hyper);
            // 1. 向前移动滑台并开启高光谱相机

            //
            if (UserTask.asLight) 
            {
                Link.darkroomPLC.LightControl(true);
            }
            if (UserTask.LEDTop)
            {
                Link.darkroomPLC.LED1_Control(true);
            }
            for (int i = 0;i<UserTask.HyperCaptrue; i++) 
            {
                //高光谱采集
                Link.darkroomPLC.Slide_1_Forward(UserTask.SportSpeed, distance / UserTask.HyperCaptrue, true);//设置滑台距离
                slide1 = true;
                if (Link.HyperCameraControlH)
                {
                    Hyper_Set.HyperFileName = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "-" + 0.ToString("00");
                    Hyper_Set.HyperFileId = DateTime.Now.ToString("yyyyMMddHHmmss") + 0.ToString("00");
                    Link.hyperCamera_2.StartCamera(PlotPath_Hyper);
                }
                // 2. 等待滑台停止并关闭高光谱相机
                while (Link.darkroomPLC.SlideSateRead_1())
                {
                    await Task.Delay(100, token);

                }
                if (Link.HyperCameraControlH)
                {
                    Link.hyperCamera_2.StopCamera(PlotPath_Hyper);
                    CreatExcel.InterData(interExcelFile, "0", "0", "hyper", Hyper_Set.HyperFileId, Hyper_Set.HyperFileName);
                }
                // 3. 滑台返回移动
                Link.darkroomPLC.Slide_1_Forward(UserTask.SportSpeed, distance  / UserTask.HyperCaptrue, false);//设置滑台距离
                await Task.Delay(5000);//等待500ms
            }

            if (UserTask.asLight)
            {
                Link.darkroomPLC.LightControl(false);
            }
            //  await Task.Delay(500);//等待500ms
            while(UserTask.RGBLoc<0.9&&UserTask.RGBLoc>0)
            {
                if (UserTask.LEDBottom)
                {
                    Link.darkroomPLC.LED2_Control(true);
                }




                Link.darkroomPLC.Slide_1_Back(UserTask.SportSpeed, (UserTask.RGBLoc + 0.11), true);//设置滑台距离1
                slide1 = false;                                    //滑台在中间位置拍摄
                while (Link.darkroomPLC.SlideSateRead_1())
                {
                    token.ThrowIfCancellationRequested();
                    await Task.Delay(100);

                }
                Link.darkroomPLC.Slide_1_Back(UserTask.SportSpeed, (UserTask.RGBLoc + 0.11), false);
                if (Link.MutiCamera)
                {
                    Link.mutiCamera.bnTriggerExec();
                    Link.mutiCamera.SaveImage(PlotPath_RGB);
                }

                if (Link.Depth)
                {
                    Link.depth.SaveIMG(Mv3dRgbdSDK.FileType_TIFF, PlotPath_Depth);
                }
                await Task.Delay(1000);//等待1000ms
                //重写深度图像保存，外加上传数据对应表
                Link.darkroomPLC.Slide_1_Back(UserTask.SportSpeed, distance, true);//设置滑台距离2
                while (Link.darkroomPLC.SlideSateRead_1())
                {
                    await Task.Delay(100);

                }
                Link.darkroomPLC.Slide_1_Back(UserTask.SportSpeed, distance, false);//设置滑台距离2
            }


            //if (UserTask.RGBCaptrue == 1)
            //{
            //    if (UserTask.LEDBottom)
            //    {
            //        Link.darkroomPLC.LED2_Control(true);
            //    }
            //    Link.darkroomPLC.Slide_1_Back(UserTask.SportSpeed, (distance/2+0.11), true);//设置滑台距离1
            //                                                        //4.到达指定位置 拍摄图片
            //    slide1 = false;                                    //滑台在中间位置拍摄
            //    while (Link.darkroomPLC.SlideSateRead_1())
            //    {
            //        token.ThrowIfCancellationRequested();
            //        await Task.Delay(100);

            //    }
            //    Link.darkroomPLC.Slide_1_Back(UserTask.SportSpeed, distance, false);//设置滑台距离1
            //    //双目相机采集
            //    if (Link.MutiCamera)
            //    {
            //        Link.mutiCamera.bnTriggerExec();
            //        Link.mutiCamera.SaveImage(PlotPath_RGB);
            //    }

            //    if (Link.Depth) 
            //    {
            //        Link.depth.SaveIMG(Mv3dRgbdSDK.FileType_TIFF, PlotPath_Depth);
            //    }
            //    await Task.Delay(1000);//等待1000ms
            //    //重写深度图像保存，外加上传数据对应表
            //    Link.darkroomPLC.Slide_1_Back(UserTask.SportSpeed, distance, true);//设置滑台距离2
            //    while (Link.darkroomPLC.SlideSateRead_1())
            //    {
            //        await Task.Delay(100);

            //    }
            //    Link.darkroomPLC.Slide_1_Back(UserTask.SportSpeed, distance, false);//设置滑台距离2

            //}
            //else if (UserTask.RGBCaptrue > 1)
            //{
            //    if (UserTask.LEDBottom)
            //    {
            //        Link.darkroomPLC.LED2_Control(true);
            //    }
            //    for (int i = 0; i < UserTask.RGBCaptrue; i++)
            //    {
            //        //(distance / (UserTask.RGBCaptrue + 1) + 0.15)
            //        double dis = distance / UserTask.RGBCaptrue;
            //        double dis1 = distance / UserTask.RGBCaptrue/2;
            //        if(i==0)
            //        {
            //            Link.darkroomPLC.Slide_1_Back(UserTask.SportSpeed, dis1 +0.11, true);//设置滑台距离1
            //                                                                                              //4.到达指定位置 拍摄图片
            //                                                                                              //滑台在中间位置拍摄
            //            while (Link.darkroomPLC.SlideSateRead_1())
            //            {
            //                await Task.Delay(100);

            //            }
            //            Link.darkroomPLC.Slide_1_Back(UserTask.SportSpeed, dis1 + 0.11, false);//设置滑台距离1
            //            if (Link.MutiCamera)
            //            {
            //                Link.mutiCamera.bnTriggerExec();
            //                Link.mutiCamera.SaveImage(PlotPath_RGB);
            //            }

            //            if (Link.Depth)
            //            {
            //                Link.depth.SaveIMG(Mv3dRgbdSDK.FileType_TIFF, PlotPath_Depth);
            //            }
            //            //重写深度图像保存，外加上传数据对应表
            //            await Task.Delay(1000);//等待1000ms
            //        }
            //        else
            //        {
            //            Link.darkroomPLC.Slide_1_Back(UserTask.SportSpeed, dis, true);//设置滑台距离1
            //                                                                                              //4.到达指定位置 拍摄图片
            //                                                                                              //滑台在中间位置拍摄
            //            while (Link.darkroomPLC.SlideSateRead_1())
            //            {
            //                await Task.Delay(100);

            //            }
            //            Link.darkroomPLC.Slide_1_Back(UserTask.SportSpeed, dis, false);//设置滑台距离1
            //            if (Link.MutiCamera)
            //            {
            //                Link.mutiCamera.bnTriggerExec();
            //                Link.mutiCamera.SaveImage(PlotPath_RGB);
            //            }

            //            if (Link.Depth)
            //            {
            //                Link.depth.SaveIMG(Mv3dRgbdSDK.FileType_TIFF, PlotPath_Depth);
            //            }
            //            //重写深度图像保存，外加上传数据对应表
            //            await Task.Delay(1000);//等待1000ms
            //        }
                
                    
            //    }
            //    Link.darkroomPLC.Slide_1_Back(UserTask.SportSpeed, distance, true);//设置滑台距离2
            //    while (Link.darkroomPLC.SlideSateRead_1())
            //    {
            //        await Task.Delay(100);

            //    }
            //    Link.darkroomPLC.Slide_1_Back(UserTask.SportSpeed, distance , false);//设置滑台距离2
            //}
            //else if(UserTask.RGBCaptrue == 0)//回原点
            //{
            //    if (UserTask.LEDBottom)
            //    {
            //        Link.darkroomPLC.LED2_Control(true);
            //    }
            //    await Task.Delay(500);
            //    for (int i = 0;i<3;i++) 
            //    {
                   
            //        Link.darkroomPLC.Slide_1_Back(UserTask.SportSpeed, ((distance / 2*i) + 0.11), true);//设置滑台距离1
            //                                                                                        //4.到达指定位置 拍摄图片
            //        slide1 = false;                                    //滑台在中间位置拍摄
            //        while (Link.darkroomPLC.SlideSateRead_1())
            //        {
            //            token.ThrowIfCancellationRequested();
            //            await Task.Delay(100);

            //        }
            //        Link.darkroomPLC.Slide_1_Back(UserTask.SportSpeed, distance, false);//设置滑台距离1
            //        if (Link.MutiCamera)
            //        {
            //            Link.mutiCamera.bnTriggerExec();
            //            Link.mutiCamera.SaveImage(PlotPath_RGB);
            //        }

            //        if (Link.Depth)
            //        {
            //            Link.depth.SaveIMG(Mv3dRgbdSDK.FileType_TIFF, PlotPath_Depth);
            //        }
            //    }
            //    await Task.Delay(1000);//等待1000ms
            //}
            if (UserTask.asLight)
            {
                Link.darkroomPLC.LightControl(false);
            }
            if (UserTask.LEDTop)
            {
                Link.darkroomPLC.LED1_Control(false);
            }
            if (UserTask.LEDBottom)
            {
                Link.darkroomPLC.LED2_Control(false);
            }

        }
        private void MeasureStop_Click(object sender, EventArgs e)
        {
            MeasureStop.Text = "停止中";
            //uiTextBox2.Visible = true;
            if (_isAcquisitionRunning && _cts != null)
            {
               
                _cts.Cancel();
                Link.hyperCamera_2.StopCamera(PlotPath_Hyper);
                Link.darkroomPLC.Slide_1_Forward(UserTask.SportSpeed, UserTask.SportDistance, false);
                Thread.Sleep(500);
                Link.darkroomPLC.Slide_1_Back(UserTask.SportSpeed, UserTask.SportDistance, true);
                while (Link.darkroomPLC.SlideSateRead_1())
                {
                        Thread.Sleep(500) ;

                }
                Link.darkroomPLC.Slide_1_Back(UserTask.SportSpeed, UserTask.SportDistance, false);
                
                if (UserTask.asLight)
                {
                    Link.darkroomPLC.LightControl(false);
                }
                if (UserTask.LEDTop)
                {
                    Link.darkroomPLC.LED1_Control(false);
                }
                if (UserTask.LEDBottom)
                {
                    Link.darkroomPLC.LED2_Control(false);
                }
                MeasureStop.Text = "停止采集";
            }

        }
        public void mearLoop() 
        {
            while (mearLoopControl)
            {
                Thread.Sleep(1000);
                if (Link.transmitPLC.Reachhead()) //检测转台上是否有植株
                {
                    Times++;
                    if (Times > 5)
                    {
                        Times = 0;
                       
                        if (SingleMearComplete) //是否可以进行测量
                        {
                            SingleMearComplete = false;
                            MearPlot();
                        }
                    }
                }
                else
                {
                    Times=0;
                }
            }
        }
        public void mearLoop_Hyper()
        {
            while (mearLoopControl_H)
            {
                Thread.Sleep(1000);
                if (Link.transmitPLC.Reachhead_H()) //检测转台上是否有植株
                {
                    Times_H++;
                    if (Times_H > 5)
                    {
                        Times_H = 0;
                        if (SingleMearComplete_H) //是否可以进行测量
                        {
                            SingleMearComplete_H = false;
                            MearPlot_H();
                        }
                    }
                }
                else
                {
                    Times_H = 0;
                }
            }
        }
        
        private void StopProgram()
        {
            Form1.ProgramChecking = "设备停止中";
            int a = 0;
            while (!StopCheck)
            {
                Thread.Sleep(1000);
                a++;
                if (a>20)
                {
                    a = 0;
                    DialogResult result = MessageBox.Show(
                     "后方进入是否为空托盘？",  // 消息内容
                     "停止判定",           // 标题
                      MessageBoxButtons.YesNo,  // 按钮（是和否）
                      MessageBoxIcon.Question   // 图标（可选）
                    );
                    if (result == DialogResult.Yes)
                    {
                        StopCheck = true;
                    }
                    else
                    {
                        StopCheck = false;
                    }
                }
            }
            StopCheck = false;
            mearLoopControl = false;
            mearLoopControl_H = false;
            Link.transmitPLC.StopControl();//调试使用

         
            /* 高光谱参考文件复制*/
            //if (Link.HyperCameraControlH) 
            //{
            //    Hyper_Set.HyperFileName = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "-" + 0.ToString("00");
            //    Hyper_Set.HyperFileId = DateTime.Now.ToString("yyyyMMddHHmmss") + 0.ToString("00");
            //    string str = HyperCaliPath + "\\" + Hyper_Set.HyperFileName + ".spe";
            //    string str1 = HyperCaliPath + "\\" + Hyper_Set.HyperFileName + ".hdr";
            //    File.Copy("D:\\calibrate\\hyper\\cali.spe", str, true);//将参考板数据拷贝到任务内
            //    File.Copy("D:\\calibrate\\hyper\\cali.hdr", str1, true);//将参考板数据拷贝到任务内
            //    CreatExcel.InterData(interExcelFile, "0", "1", "hyper", Hyper_Set.HyperFileId, Hyper_Set.HyperFileName);
            //}
            /* RGB参考文件复制*/
           // RgbCali();
            this.Invoke((EventHandler)(delegate
            {
                MeasureStart.Enabled = true;
            }
             )
            );
            pl.Clear();
            Form1.ProgramChecking = "设备停止运行";
        }

        public void RgbCali()//rgb校准文件复制
        {
            
            RGBcaliname = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "-" + 1.ToString("00");
            RGBcalID = DateTime.Now.ToString("yyyyMMddHHmmss") + 1.ToString("00");
            string str2 = RGBCaliPath + "\\" + RGBcaliname + ".JPG";
            File.Copy("D:\\calibrate\\rgb\\N001.JPG", str2, true);//将参考板数据拷贝到任务内
            CreatExcel.InterData(interExcelFile, "1", "1", "rgb", RGBcalID, RGBcaliname);

            RGBcaliname = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "-" + 2.ToString("00"); ;
            RGBcalID = DateTime.Now.ToString("yyyyMMddHHmmss") + 2.ToString("00");
            string str3 = RGBCaliPath + "\\" + RGBcaliname + ".JPG";
            File.Copy("D:\\calibrate\\rgb\\N002.JPG", str3, true);//将参考板数据拷贝到任务内
            CreatExcel.InterData(interExcelFile, "2", "1", "rgb", RGBcalID, RGBcaliname);

            RGBcaliname = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "-" + 3.ToString("00"); ;
            RGBcalID = DateTime.Now.ToString("yyyyMMddHHmmss") + 3.ToString("00");
            string str4 = RGBCaliPath + "\\" + RGBcaliname + ".JPG";
            File.Copy("D:\\calibrate\\rgb\\N003.JPG", str4, true);//将参考板数据拷贝到任务内
            CreatExcel.InterData(interExcelFile, "0", "1", "rgb", RGBcalID, RGBcaliname);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            uiTextBox1.Text = "rubber";//用户名称
            //uiTextBox4.Text = Link.CodeName;//盆栽名称
            proName.Text = UserInform.Projectselect;//项目名称
            tbtaskName.Text = TaskName;//任务名称
           
        }
    
        public void MearPlot()//测量程序
        {
            /*单株测量完成在启动该参数进行下一株测量*/
            /*RFID开启采集*/
            //称重完成再将变量改名，必须称重要比测量快
            StopCheck = true;
           // Thread.Sleep(UserTask.Stoptime * 1000);//等待植株静止一段时间
            if (Link.CodeName == null || Link.CodeName == "")//盆栽编号未识别
            {
                Link.CodeName = DateTime.Now.ToString("yyyyMMddHHmmss");
                Form1.ProgramChecking = "盆栽编号未识别";
            }
            PlotName = Link.CodeName;
            WeighPlotName = Link.CodeName;//称重数据名称暂存
            Link.CodeName = null;
            this.Invoke((EventHandler)(delegate
            {
                plantName.Text = PlotName;
            }
            )
           );
            if (judgePlotDouble(PlotName))
            {
                PlotName = PlotName + "-" + DateTime.Now.ToString("HHmmss");
                PlotPath = GlobleTaskPath + "\\" + PlotName;
            }
            else
            {
                //创建文件存储路径
                PlotPath = GlobleTaskPath + "\\" + PlotName;
            }
            //获取盆栽名称 ID
            GloblePlotID = judgePlotID(PlotName);
            
            //创建文件存储路径
           // PlotPath = GlobleTaskPath + "\\" + PlotName;
            PlotPath_RGB = PlotPath + "\\rgb";
            string DataId = DateTime.Now.ToString("yyyyMMddHHmmss") + 1.ToString("00");
            string DataName = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "-" + 1.ToString("00");
            CreatExcel.InterData(interExcelFile, "0", "0", "ply", DataId, DataName);
            CreatExcel.CreateDirectory(PlotPath);
            CreatExcel.CreateDirectory(PlotPath_RGB);

            //CreatExcel.CreateDirectory(PlotPath_Hyper);
            /*循坏控制次数：360/角度*/
            int LoopCount = 0;
            aCamera.count = 0;

            if (UserTask.TurntableSHandle == 0)// 判断角度信息
            {
                LoopCount = 1;
            }
            else 
            {
                LoopCount = 360/ UserTask.TurntableSHandle;
            }
            //RGB拍照1次
            for (int i=0;i< LoopCount; i++) 
            {

                while (PlotHyper_H) 
                {
                    Thread.Sleep(1000);
                }
                if (Link.RGBControlH)
                {
                    Thread.Sleep(UserTask.Stoptime * 1000);//等待植株静止一段时间
                    OneShot(PlotPath_RGB);// 先不拍照测试
                    Thread t2 = new Thread(RGBDataProcessing);
                    t2.Start();//pass argument using Start(Object) method
                }
                /*判定进行单次扫描还是多次扫描*/
                if (UserTask.TurntableSHandle == 0)
                {
                   // Link.transmitPLC.TurntableNUM(0);
                }//旋转角度设置为零，设备旋转45°拍摄一次，即可返回原点。
                else 
                {
                    Thread.Sleep(2000);
                    Link.transmitPLC.TurntableNUM(UserTask.TurntableSHandle);
                    Link.transmitPLC.TurntableControl(true);
                    while (!Link.transmitPLC.ReadTurntable() && TeTimes < 300)
                    {
                        Thread.Sleep(100);
                        TeTimes++;
                        if (TeTimes > 300)
                        {
                            MessageBox.Show("转台未旋转");
                        }
                    }
                    TeTimes = 0;
                }   
            }//测量循环
            Link.transmitPLC.OneMearComplete(true);//测量结束
            SingleMearComplete = true;//可以进行下一株测量
            WeighPlotName = PlotName ;//称重数据名称暂存
            StopCheck = false;
        }
        public void MearPlot_H() //高光谱测量程序
        {
            StopCheck_H = true;
            if (UserTask.Room1ControlH)//苗子先到达暗室2中间，下一棵苗子才能进来
            {
                PlotHyper = WeighPlotName;
            }
            else 
            {
              PlotHyper = Link.CodeName;
              Link.CodeName = null;
            }
            if (PlotHyper == null || PlotHyper == "")//盆栽编号未识别
            {
                PlotHyper = DateTime.Now.ToString("yyyyMMddHHmmss");
                Form1.ProgramChecking = "盆栽编号未识别";
            }
           
            if (judgePlotDouble(PlotHyper) && !UserTask.Room1ControlH)
            {
                PlotHyper = PlotHyper + "-" + DateTime.Now.ToString("HHmmss");
                PlotPath = GlobleTaskPath + "\\" + PlotHyper + "-" + DateTime.Now.ToString("HHmmss");
            }
            else
            {
                //创建文件存储路径
                PlotPath = GlobleTaskPath + "\\" + PlotHyper;
            }
            GloblePlotID = judgePlotID(PlotHyper);
            PlotPath = GlobleTaskPath + "\\" + PlotHyper;
            PlotPath_Hyper = PlotPath + "\\hyper";
            CreatExcel.CreateDirectory(PlotPath);
            CreatExcel.CreateDirectory(PlotPath_Hyper);
            Thread.Sleep(1000);
            /*高光谱测量程序*/
            PlotHyper_H = true;//高光谱正在扫描。rgb停止
          
            Hyper_Set.HyperFileName = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "-" + 0.ToString("00");
            Hyper_Set.HyperFileId = DateTime.Now.ToString("yyyyMMddHHmmss") + 0.ToString("00");
            if (PlotHyperSate) 
            {
                try
                {
                    //Thread thread = new Thread(new ParameterizedThreadStart(Hyper_Set.StartHyperGrad));
                   // thread.Start(PlotPath_Hyper);
                    Hyper_Set.StartHyperGrad(PlotPath_Hyper);
                    CreatExcel.InterData(interExcelFile, "0", "0", "hyper", Hyper_Set.HyperFileId, Hyper_Set.HyperFileName);
                }
                catch
                {
                    Console.WriteLine("高光谱断链1");
                    PlotHyperSate = false;
                    Thread thread = new Thread(ConnectHyper);
                    thread.Start();

                }
            }
            Thread.Sleep(500);
            Link.transmitPLC.LightControl(true);
            Link.transmitPLC.Slide_2_Forward(Convert.ToDouble(UserTask.AutoSpeedH), Convert.ToDouble(UserTask.AutoDistanceH), true);
            Thread.Sleep(30000);
            if (PlotHyperSate)
            {
                try
                {
                    string str = null;
                    //Thread thread = new Thread(new ParameterizedThreadStart(Hyper_Set.StopHyperGrad));
                    //thread.Start(str);
                    Hyper_Set.StopHyperGrad(null);
                }
                catch
                {
                    Console.WriteLine("高光谱断链2");
                    PlotHyperSate = false;
                }
                //Thread.Sleep(500);
            }
            PlotHyper_H = false;
            Thread.Sleep(1000);
            Link.transmitPLC.Slide_2_Forward(Convert.ToDouble(UserTask.AutoSpeedH), Convert.ToDouble(UserTask.AutoDistanceH), false);
            Link.transmitPLC.LightControl(false);
            Link.transmitPLC.Slide_2_Back(300, Convert.ToDouble(UserTask.AutoDistanceH), true);
            Thread.Sleep(20000);
            Link.transmitPLC.Slide_2_Back(300, Convert.ToDouble(UserTask.AutoDistanceH), false);
            Link.transmitPLC.OneMearComplete_H(true);
            SingleMearComplete_H = true;
            Link.CodeName = null;
            StopCheck_H = false;
        }
        public void ConnectHyper()
        {
            Thread.Sleep(240000);
            try
            {

                Hyper_Set.initPylon(Hyper_Set.hyperCamera);
                if (DataAcquisition.PlotConnectHyperSate)
                {
                    Form1.ProgramChecking = "高光谱重连成功";
                    Console.WriteLine("高光谱重连成功");
                }
                else 
                {
                    Form1.ProgramChecking = "高光谱重连失败";
                    Console.WriteLine("高光谱重连失败");
                    Hyper_Set.hyperCamera.close();
                }
                PlotHyperSate = true;
            }
            catch 
            {
                Form1.ProgramChecking = "高光谱重连失败";
                Console.WriteLine("高光谱重连失败");
                Hyper_Set.hyperCamera.close();
                PlotHyperSate = true;
            }
        }

        private void OneShot(string str) //拍照
        {

            string str1 = str;
            RGB_Set.rgbCamera.shootForAllCameras(str1);
            Link.vR3D.Capture();
        }
       
        public void HyperFile() 
        {
            Thread.Sleep(5000);
            string str3 = PlotPath_Hyper + "\\" + Hyper_Set.HyperFileName + ".spe";
            if (File.Exists(str3))
            {
                CreatExcel.InterData(interExcelFile, "0", "0", "hyper", Hyper_Set.HyperFileId, Hyper_Set.HyperFileName);
            }
            else 
            {
              
            }
        }

        public void deleteLine(string plotna,string filename) //过滤重写
        {
            using (StreamReader sr = new StreamReader(filename))//需要加标定文件到指定文件夹
            {
                string line;
                StreamWriter wr = new StreamWriter(filename + ".hdr");

                // 从文件读取并显示行，直到文件的末尾 
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Contains("lines ="))
                    {
                        wr.WriteLine("lines =" + filename);
                    }
                    else
                    {
                        wr.WriteLine(line);
                    }
                    //Console.WriteLine(line);
                }
                //filename = 0;//dehui
                wr.Flush();
                wr.Close();
            }
        }


        public void WeighLoop() //称重模式
        {
            while (mearLoopControl) //测量结束不进行称重
            {
                //判断是否进行称重，称重结束退出该测量步骤
               // if (UserTask.WeighingControlHandle == true)
                //{
                    if (Link.transmitPLC.WeighCompleteSingle(true))
                    {
                        Thread.Sleep(2000);
                        WeighingNum = Link.transmitPLC.WeighDataRead();
                        Thread.Sleep(1000);
                        Link.transmitPLC.WeighControlComplete(true);//称重完成
                        CreatExcel.WriteData(DataFile, WeighPlotName, UserTask.WateringSHandle, WeighingNum);
                        //上一株浇水完成，称重完成，本株测量完成发送信号测量结束
                    }
               //}
                Thread.Sleep(100);
            }
        }
        public void RGBDataProcessing() //RGB数据处理
        {
            Thread.Sleep(3000);
            int a = 0;
            string str1 = PlotPath_RGB + "\\" + "N001" + ".JPG";
            string str2 = PlotPath_RGB + "\\" + "N002" + ".JPG";
            string str3 = PlotPath_RGB + "\\" + "N003" + ".JPG";
            string str4 = PlotPath_RGB + "\\" + "N004" + ".JPG";
            string str5 = PlotPath_RGB + "\\" + "N005" + ".JPG";
            string str6 = PlotPath_RGB + "\\" + "N006" + ".JPG";
            string str7 = PlotPath_RGB + "\\" + "N007" + ".JPG";
            string str8 = PlotPath_RGB + "\\" + "N008" + ".JPG";
            if (File.Exists(str1))
            {
                string DataId = DateTime.Now.ToString("yyyyMMddHHmmss") + (a++).ToString("00");
                string DataName = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "-" + (a).ToString("00");
                Microsoft.VisualBasic.FileIO.FileSystem.RenameFile(str1, DataName + ".JPG");

            }
            else 
            {
                Link.rgb_Set.DisposeCanera();//释放资源
                Thread.Sleep(1000);
                Link.rgb_Set.ConnectCanera();
                RGB_Set.rgbCamera.shootForAllCameras("D:\\RGB");
            }
            if (File.Exists(str2))
            {

                string DataId = DateTime.Now.ToString("yyyyMMddHHmmss") + (a++).ToString("00");
                string DataName = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "-" + (a).ToString("00");
                Microsoft.VisualBasic.FileIO.FileSystem.RenameFile(str2, DataName + ".JPG");

            }
            if (File.Exists(str3))
            {
                    string DataId = DateTime.Now.ToString("yyyyMMddHHmmss") + (a++).ToString("00");
                    string DataName = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "-" + (a).ToString("00");
                    Microsoft.VisualBasic.FileIO.FileSystem.RenameFile(str3, DataName + ".JPG");
                  
            }
            if (File.Exists(str4))
            {
                string DataId = DateTime.Now.ToString("yyyyMMddHHmmss") + (a++).ToString("00");
                string DataName = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "-" + (a).ToString("00");
                Microsoft.VisualBasic.FileIO.FileSystem.RenameFile(str4, DataName + ".JPG");
              
            }
            if (File.Exists(str5))
            {
                string DataId = DateTime.Now.ToString("yyyyMMddHHmmss") + (a++).ToString("00");
                string DataName = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "-" + (a).ToString("00");
                Microsoft.VisualBasic.FileIO.FileSystem.RenameFile(str5, DataName + ".JPG");
               
            }
            if (File.Exists(str6))
            {
                string DataId = DateTime.Now.ToString("yyyyMMddHHmmss") + (a++).ToString("00");
                string DataName = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "-" + (a).ToString("00");
                Microsoft.VisualBasic.FileIO.FileSystem.RenameFile(str6, DataName + ".JPG");
             
            }
            if (File.Exists(str7))
            {
                string DataId = DateTime.Now.ToString("yyyyMMddHHmmss") + (a++).ToString("00");
                string DataName = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "-" + (a).ToString("00");
                Microsoft.VisualBasic.FileIO.FileSystem.RenameFile(str7, DataName + ".JPG");
               
            }
            if (File.Exists(str8))
            {
                string DataId = DateTime.Now.ToString("yyyyMMddHHmmss") + (a++).ToString("00");
                string DataName = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "-" + (a).ToString("00");
                Microsoft.VisualBasic.FileIO.FileSystem.RenameFile(str8, DataName + ".JPG");
                
            }

        }

       
        private void DataAcquisition_Initialize(object sender, EventArgs e)
        {
            if (Link.darkroomPLCH )
            {
               
            }
            else
            {
                Creat.Enabled = false;
                MeasureStart.Enabled = false;
                MessageBox.Show("设备连接失败！！，请连接控制系统");
            }

        }
        public string judgePlotID(string str) //判断植株ID是否被测量过,没有测量会生成新的ID
        {
            for (int i = 0; i < pl.Count; i++)
            {
                if (pl[i].PLOTNAME == str)
                {
                    return pl[i].PLOTID;
                }
            }
            PlotInfor pl1 = new PlotInfor();
            pl1.PLOTNAME = str;
            pl1.PLOTID = DateTime.Now.ToString("yyMMddss") + PlotIdIndex.ToString("000");
            pl.Add(pl1);
            PlotIdIndex++;
            return pl1.PLOTID;
        }
        public bool judgePlotDouble(string str) //判断植株ID是否被测量过,没有测量会生成新的ID
        {
            for (int i = 0; i < pl.Count; i++)
            {
                if (pl[i].PLOTNAME == str)
                {
                    return true;
                }
            }
            return false;
            //PlotInfor pl1 = new PlotInfor();
            //pl1.PLOTNAME = str;
            //pl1.PLOTID = DateTime.Now.ToString("yyMMddss") + PlotIdIndex.ToString("000");
            //pl.Add(pl1);
            //PlotIdIndex++;
            //return pl1.PLOTID;
        }
        public static void CopyDirectory(string srcDir, string tgtDir,string he,int a)
        {
            DirectoryInfo source = new DirectoryInfo(srcDir);
            DirectoryInfo target = new DirectoryInfo(tgtDir);

            if (!source.Exists)
            {
                return;
            }
            FileInfo[] files = source.GetFiles();//文件

            if (files.Length==0) 
            {
                for (int i = 0; i < files.Length; i++)
                {
                    File.Copy(files[i].FullName, target.FullName + @"/" + files[i].Name, true);
                }
                if (he == "hyper")
                {
                    string str = tgtDir + "\\cali.img";
                    string hycaliName = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + a.ToString("00");
                    string hycaliId = DateTime.Now.ToString("yyyyMMddHHmmss") + a.ToString("00");
                    Microsoft.VisualBasic.FileIO.FileSystem.RenameFile(str, hycaliName + ".img");
                    CreatExcel.InterData(interExcelFile, "0", "1", "hypercali", hycaliId, hycaliName);
                    string str1 = HyperCaliPath + "\\cali.hdr";
                    Microsoft.VisualBasic.FileIO.FileSystem.RenameFile(str1, hycaliName + ".hdr");
                }
            }
        }

        private void HyperAlidar()
        {

            //滑台移动
            if (!UserTask.GradDirctionHandle)
            {
                Link.darkroomPLC.Slide_1_Forward(Convert.ToDouble(UserTask.AutoSpeedH), Convert.ToDouble(UserTask.AutoDistanceH), true);
            }
            else
            {
                Link.darkroomPLC.Slide_2_Forward(Convert.ToDouble(UserTask.AutoSpeedH), Convert.ToDouble(UserTask.AutoDistanceH), true);
            }
            //高光谱扫描创建委托
            if (Link.HyperCameraControlH)
            {
                Link.darkroomPLC.LightControl(true);//打开光源
                Hyper_Set.HyperFileName = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "-" + 0.ToString("00");
                Hyper_Set.HyperFileId = DateTime.Now.ToString("yyyyMMddHHmmss") + 0.ToString("00");
                Hyper_Set.StartHyperGrad(PlotPath_Hyper);
            }

            if (Link.LidarControlH)
            {
                //激光雷达扫描
                Lidar_Set.LidarName = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "-" + 0.ToString("00");
                string str = PlotPath_Lidar + "\\" + Lidar_Set.LidarName + ".txt";
                Lidar_Set.LidarId = DateTime.Now.ToString("yyyyMMddHHmmss") + 0.ToString("00");
                Lidar_Set.StartLidar(UserTask.AutoSpeedH, str);
            }

            //滑台停止
            if (!UserTask.GradDirctionHandle)
            {

                while (Link.darkroomPLC.SlideSateRead_1())
                {
                    Thread.Sleep(100);
                }
            }
            else
            {
                while (Link.darkroomPLC.SlideSateRead_2())
                {
                    Thread.Sleep(100);
                }
            }
            if (Link.LidarControlH)
            {
                //停止高光谱
                Hyper_Set.StopHyperGrad(PlotPath_Hyper);
                Link.darkroomPLC.LightControl(false);//关闭光源
                CreatExcel.InterData(interExcelFile, "0", "0", "hyper", Hyper_Set.HyperFileId, Hyper_Set.HyperFileName);
            }
            if (Link.LidarControlH)
            {
                //停止激光雷达扫描
                Lidar_Set.StpoLidar();
                CreatExcel.InterData(interExcelFile, "0", "0", "lidar", Lidar_Set.LidarId, Lidar_Set.LidarName);
            }
            if (!UserTask.GradDirctionHandle)
            {
                Link.darkroomPLC.Slide_1_Forward(Convert.ToDouble(UserTask.AutoSpeedH), Convert.ToDouble(UserTask.AutoDistanceH), false);
            }//复位控制线圈
            else
            {
                Link.darkroomPLC.Slide_2_Forward(Convert.ToDouble(UserTask.AutoSpeedH), Convert.ToDouble(UserTask.AutoDistanceH), false);
            }
            Thread.Sleep(1000);
            if (!UserTask.GradDirctionHandle)//滑台恢复到原点
            {
                Link.darkroomPLC.Slide_1_Back(SlideBackSpeed, Convert.ToDouble(UserTask.AutoDistanceH), true);
            }
            else
            {
                Link.darkroomPLC.Slide_2_Back(SlideBackSpeed, Convert.ToDouble(UserTask.AutoDistanceH), true);
            }
            if (!UserTask.GradDirctionHandle)
            {

                while (Link.darkroomPLC.SlideSateRead_1())
                {
                    Thread.Sleep(100);
                }
            }
            else
            {
                while (Link.darkroomPLC.SlideSateRead_2())
                {
                    Thread.Sleep(100);
                }
            }
            if (!UserTask.GradDirctionHandle)//复位按键
            {
                Link.darkroomPLC.Slide_1_Back(SlideBackSpeed, Convert.ToDouble(UserTask.AutoDistanceH), false);
            }//复位滑台运动按键
            else
            {
                Link.darkroomPLC.Slide_2_Back(SlideBackSpeed, Convert.ToDouble(UserTask.AutoDistanceH), false);
            }
        }

        private void Rset_Click(object sender, EventArgs e)
        {
            Link.transmitPLC.RsetControl();
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {

            //if (Link.HyperCameraControlH)
            //{
            //    FlushComtrol = false;
            //    HyperCamera_1.Vix_Exit();
            //    Thread.Sleep(1000);

            //    Link.hyperCamera_1.Camera_Init();
            //}
           

        }

       

       

        private void uiButton4_Click(object sender, EventArgs e)
        {
            Link.mutiCamera.bnTriggerExec();

            //GC.Collect();
        }

        private void uiButton5_Click(object sender, EventArgs e)
        {

            string[] str = new string[2];
            str[0] = DateTime.Now.ToString("yyyyMMddHHmmss")+"_1"+".jpg";
            str[1] = DateTime.Now.ToString("yyyyMMddHHmmss") + "_2" + ".jpg";

            Link.mutiCamera.savejpg(MutiCameraPath,str);

            
            //else if (savepicture == "png")
            //{
            //    Link.mutiCamera.savepng(textBoxPicturePath.Text.Trim());

            //}
            //else
            //{
            //    Link.mutiCamera.savetiff(textBoxPicturePath.Text.Trim());
            //}
        }

        private void uiButton6_Click(object sender, EventArgs e)
        {
            //int nRet = Mv3dRgbdSDK.MV3D_RGBD_SoftTrigger(m_handle);
            Link.depth.SaveImage(Mv3dRgbdSDK.FileType_BMP, MutiCameraPath);
        }

        private void uiButton7_Click(object sender, EventArgs e)
        {
            Link.hyperCamera_2.StartCamera(MutiCameraPath);
        }

        private void uiButton8_Click(object sender, EventArgs e)
        {
            Link.hyperCamera_2.StopCamera(MutiCameraPath);
        }

      

    }
    public struct PlotInfor 
    {
       public string PLOTNAME;
       public string PLOTID;
    }
}
//if (MearModeIndex == 0)//
//{
//    UIMessageBox.Show("选择运行模式", UILocalize.InfoTitle, Style);
//    return;
//}
//else if (MearModeIndex == 2)//装载模式
//{
//    Link.transmitPLC.StartControl();
//    Thread.Sleep(500);
//    int a = Link.transmitPLC.ReadLoadmodeSET();
//    if ((int)a == 1)
//    {
//        Form1.ProgramChecking = "装载模式设置成功,点击装载区按钮进行装载";
//        MeasureStart.Enabled = false;
//        MeasureStop.Enabled = true;

//    }
//    else
//    {
//        Form1.ProgramChecking = "运行模式设置失败，请再次设置";
//        return;
//    }
//}
//else if (MearModeIndex == 3)//卸载模式
//{
//    Link.transmitPLC.StartControl();
//    Thread.Sleep(500);
//    float a = Link.transmitPLC.ReadUnloadmodeSET();
//    if ((int)a == 1)
//    {
//        Form1.ProgramChecking = "卸载模式设置成功,设备开始运转";
//        MeasureStart.Enabled = false;
//        MeasureStop.Enabled = true;

//    }
//    else
//    {
//        Form1.ProgramChecking = "运行模式设置失败，请再次设置";
//        return;
//    }

//}
//else if (MearModeIndex == 1)//测量模式
//{

//    Thread.Sleep(500);
//    float a = Link.transmitPLC.ReadMearmodeSET();
//    if ((int)a == 1 && UserInform.ProjectSelected)
//    {
//        Form1.ProgramChecking = "运行模式设置成功,设备开始运转";
//        MeasureStart.Enabled = false;
//        MeasureStop.Enabled = true;
//        timer1.Start();
//    }
//    else if (!UserInform.ProjectSelected)
//    {
//        MessageBox.Show("项目未加载，请加载项目");
//        return;
//    }
//    else
//    {
//        Form1.ProgramChecking = "运行模式设置失败，请再次设置";
//        return;
//    }
//    Link.transmitPLC.StartControl();
//    //创建任务文件夹
//    TaskName = "TASK" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm");
//    GlobleTaskPath = UserInform.GlobleProjectPath + "\\" + TaskName;//创建TASK文件夹
//    CreatExcel.CreateDirectory(GlobleTaskPath);
//    Calibrate = GlobleTaskPath + "\\calibrate";
//    HyperCaliPath = Calibrate + "\\hyper";
//    RGBCaliPath = Calibrate + "\\rgb";
//   //idarCaliPath = Calibrate + "\\lidar";
//    CreatExcel.CreateDirectory(Calibrate);
//    CreatExcel.CreateDirectory(HyperCaliPath);
//    CreatExcel.CreateDirectory(RGBCaliPath);
//    //eatExcel.CreateDirectory(LidarCaliPath);





//    //创建任务ID
//    GlobleTaskID = DateTime.Now.ToString("yyyyMMss") + TaskIdIndex.ToString();
//    TaskIdIndex++;
//    TaskTime = DateTime.Now.ToString("yyyy/M/d");
//    //创建服务器上传文件
//    interExcelFile = "D:\\" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".mh";
//    CreatExcel.CreatFile(interExcelFile);//
//                                         //创建，称重数据、浇水数据文件

//    //这块将参考版数据上传
//    if (Link.HyperCameraControlH)
//    {
//        Hyper_Set.HyperFileName = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "-" + 0.ToString("00");
//        Hyper_Set.HyperFileId = DateTime.Now.ToString("yyyyMMddHHmmss") + 0.ToString("00");
//        string str = HyperCaliPath + "\\" + Hyper_Set.HyperFileName + ".spe";
//        string str1 = HyperCaliPath + "\\" + Hyper_Set.HyperFileName + ".hdr";
//        File.Copy("D:\\calibrate\\hyper\\cali.spe", str, true);//将参考板数据拷贝到任务内
//        File.Copy("D:\\calibrate\\hyper\\cali.hdr", str1, true);//将参考板数据拷贝到任务内
//        CreatExcel.InterData(interExcelFile, "0", "1", "hyper", Hyper_Set.HyperFileId, Hyper_Set.HyperFileName);
//    }
//    if (UserTask.Room1ControlH) 
//    {
//        //Link.transmitPLC.DrakRoom1(true);
//        mearLoopControl = true;
//        SingleMearComplete = true;
//        Thread t1 = new Thread(mearLoop);
//        t1.Start();
//    }
//    if (UserTask.Room2ControlH)
//    {
//       // Link.transmitPLC.DrakRoom2(true);
//        SingleMearComplete_H = true;
//        mearLoopControl_H = true;
//        Thread t1 = new Thread(mearLoop_Hyper);
//        t1.Start();
//    }

//}