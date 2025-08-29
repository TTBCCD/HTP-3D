using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//namespace m_CTP
//{

//        //400-1700高光谱相机
//        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
//        public struct psVixWbParam1
//        {
//            public int iTake;//是否采集有效
//            public int iTimeId;//采集参考板曝光时间
//            public int iGainId;//采集参考板增益
//            public int iReflectivity;//参考板反射率
//            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
//            public int[] iTakeTime;//采集参考板时间
//            int iTakeType;        // 是否采集反射率
//        }
//        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
//        public struct psVixDeviceParam2
//        {
//            // [MarshalAs(UnmanagedType.LPStr)]
//            public int iProgramMode;                   // 软件运行模式:标准光谱
//            public int iInverted;                      // 图像倒置	
//            public int iBinning;                       // 图像画幅
//            public int iWidth;                         // 图像宽
//            public int iHeight;                        // 图像高
//            public int iDepth;                         // 数据位深	
//            public int iSize;                          // 大小
//            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2048)]
//            public double[] fBaud;                 // 波段信息(新增)
//            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4096)]
//            public byte[] pImg;                // 相机图像缓冲区
//            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4096)]
//            public byte[] pScanImg;                    // 推扫图像缓冲区
//            public int iTimeId;                        // 当前曝光时间ID
//            public int iGainId;                        // 当前增益ID
//            int iSoltWidth;                     // 当前光谱间隔
//            int iMaxLineNum;                    // 系统存储线数能力
//            int iExpoureTimeNum;                // 曝光时间通道数
//            int iExpoureGainNum;                // 曝光增益通道数
//            int iMinSoltWidth;                  // 相机支持的最小光谱间隔
//            int iReserve;                       // 是否支持LET检测模式
//            int iReserve2;                      // usb2.0 如果大于1则为2.0，否则为3.0
//            int iReserve3;                      // 保留
//        }
//        public struct psVixDeviceParam1
//        {
//            public int iProgramMode;                   // 软件运行模式：自动或触发模式
//            public int iFlip;                          // 图像倒置	
//            public int iBinning;                       // 图像画幅
//            public int iWidth;                         // 图像宽
//            public int iHeight;                        // 图像高
//            public int iDepth;                         // 数据位深	
//            public int iSize;                          // 大小
//                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2048)]
//            public double[] fBaud;                  // 波段信息(新增)
//                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4096)]
//            public byte[] pImg;                  // 光谱图像缓冲区
//            public int iPreViewWidth;                  // 推扫图像(伪彩)宽度
//           public int iPreViewHeight;                 // 推扫图像(伪彩)高度
//                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4096)]
//                public byte[] pScanImg;                // 推扫图像(伪彩)缓冲区 -> 当前线的伪彩图
//                public int iTimeId;                        // 当前曝光时间ID
//                public int iGainId;                        // 当前增益ID
//                public int iDenoise;                       // 当前降噪
//                public int iSoltWidth;                     // 当前光谱间隔
//                public int iMaxLineNum;                    // 系统存储线数能力
//                public int iExpoureTimeNum;                // 曝光时间通道数
//                public int iExpoureGainNum;                // 曝光增益通道数
//                public int iMinSoltWidth;                  // 相机支持的最小光谱间隔
//                public int iSupportExtend;                 // 是否支持LET检测模式
//                public int iUSB2;                          // usb2.0 如果大于1则为2.0，否则为3.0
//                public int iDeviceType;                    // 设备类型 0/S270 1/S230 2/S270G 3/S230G
//                public int iCapturing;                     // 是否启动采集
//                public int iClassifiable;                  // 是否分类
//                public int iROIMode;                       // 硬ROI模式
//                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
//                public int[] iROIBand;    // 硬ROI波段
//            public int iROIHeight;
//            public int iROIYOffset;
//            public int iImageBinningH;                 // 图像画幅
//            public int iImageBinningW;                 // 图像画幅
//            public int iPseudoRed;                     // 伪彩红色波段
//                public int iPseudoGreen;                   // 伪彩绿色波段
//                public int iPseudoBlue;                    // 伪彩蓝色波段
//        }
//        public class HyperCamera_2
//        {


//            /* 相机初始化需要传递回调函数进去，返回相机参数*/
//            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
//            public delegate void DllcallBack(int info_type, long wParam, long lParam, IntPtr reserve);

//            /*相机初始化*/
//            [DllImport("VixLib.dll", EntryPoint = "Vix_Init", CallingConvention = CallingConvention.Cdecl)]
//            public static extern int Vix_Init(ref psVixDeviceParam1 psVixDeviceParam, ref psVixWbParam1 psVixWbParam, DllcallBack callbackfunc, string datapath, IntPtr sVixID);//ef psVixDeviceParam psVixDeviceParam, 

//            [DllImport("VixLib.dll", EntryPoint = "Vix_InitTidy", CallingConvention = CallingConvention.Cdecl)]
//            public static extern int Vix_InitTidy(DllcallBack callbackfunc, string datapath, string sVixID);//ef psVixDeviceParam psVixDeviceParam, 

//            /*关闭相机*/
//            [DllImport("VixLib.dll", EntryPoint = "Vix_Exit", CallingConvention = CallingConvention.Cdecl)]
//            public static extern void Vix_Exit();
//        /*获取帧频*/
//        [DllImport("VixLib.dll", EntryPoint = "Vix_GetFps", CallingConvention = CallingConvention.Cdecl)]
//        public static extern int Vix_GetFps();
//        /*设置帧频*/
//        [DllImport("VixLib.dll", EntryPoint = "Vix_SetFps", CallingConvention = CallingConvention.Cdecl)]
//        public static extern int Vix_SetFps(int a);
//        /*获取曝光时间*/
//        [DllImport("VixLib.dll", EntryPoint = "Vix_GetExposureTimeValue", CallingConvention = CallingConvention.Cdecl)]
//            public static extern double Vix_GetExposureTimeValue(int id);

//            /*设置曝光时间*/
//            [DllImport("VixLib.dll", EntryPoint = "Vix_SetTime", CallingConvention = CallingConvention.Cdecl)]
//            public static extern int Vix_SetTime(int id);

//            /*获取相机增益*/
//            [DllImport("VixLib.dll", EntryPoint = "Vix_GetExposureGainValue", CallingConvention = CallingConvention.Cdecl)]
//            public static extern double Vix_GetExposureGainValue(int id);

//            /*设置相机增益*/
//            [DllImport("VixLib.dll", EntryPoint = "Vix_SetGain", CallingConvention = CallingConvention.Cdecl)]
//            public static extern int Vix_SetGain(int id);

//            /*通过像素获取波段信息. pos 为光谱方向像素位置*/
//            [DllImport("VixLib.dll", EntryPoint = "Vix_GetBaud", CallingConvention = CallingConvention.Cdecl)]
//            public static extern double Vix_GetBaud(int pos);

//            /*从配置文件读取相机参数
//             * 返回值：iMode-运行模式
//                iType-采集画幅
//                iDepth-采集位深
//             */
//            [DllImport("VixLib.dll", EntryPoint = "Vix_ReadDeviceParamFromIniFile", CallingConvention = CallingConvention.Cdecl)]
//            public static extern void Vix_ReadDeviceParamFromIniFile(int iMode, int iType, int iDepth);

//            /*存储相机参数到配置文件
//             * 输入值：iMode-运行模式
//              iType-采集画幅
//              iDepth-采集位深
//              注：不会立即生效，应用软件重启时再次调用本库，方能生效
//             */
//            [DllImport("VixLib.dll", EntryPoint = "Vix_SaveDeviceParamToIniFile", CallingConvention = CallingConvention.Cdecl)]
//            public static extern void Vix_SaveDeviceParamToIniFile(int iMode, int iType, int iDepth);

//            /*采集参考板动作。如果采集数据为反射率，需要提前放置白板，并通过采集参考板操
//              作采集参考白板。SDK 只有在有效采集到参考白板时才允许光谱采集操作时指定采集类型
//              为反射率。
//              返回值：psVixWbParam（参考板采集参数，见公共数据结构）
//            */
//            [DllImport("VixLib.dll", EntryPoint = "Vix_TakeWbData", CallingConvention = CallingConvention.Cdecl)]
//            public static extern void Vix_TakeWbData(psVixWbParam1 psVixWbParam);

//            /*清除参考板。清除后不允许发起类型为反射率的光谱采集。
//             返回值：psVixWbParam（参考板采集参数，见公共数据结构）
//            */
//            [DllImport("VixLib.dll", EntryPoint = "Vix_ClearWbData", CallingConvention = CallingConvention.Cdecl)]
//            public static extern void Vix_ClearWbData(psVixWbParam1 psVixWbParam);

//            /*根据使用的白板物理参数，设置参考板反射率。
//             输入值：val = 10~100
//            */
//            [DllImport("VixLib.dll", EntryPoint = "Vix_SetWbReflectivity", CallingConvention = CallingConvention.Cdecl)]
//            public static extern void Vix_SetWbReflectivity(int val);

//            /*光谱采集启动停止操作接口。通过参数启动/停止预览采集（不存储光谱数据）或者
//              普通推扫采集（将采集数据存入 file 指定路径，文件名实时生成）
//              输入：
//              act 为动作类型（见下述采集光谱动作宏定义）
//              iType 为采集类型：=0（采集光强）、=1（采集反射率）
//              iFormat 为采集文件存储格式：=0（BSQ 文件）
//              =1（BIL 文件）
//              =2（图片集合）
//              fBaud0 为采集起始波段
//              fBaud1 为采集终止波段
//              iMaxLineNum 存储线数
//              file 为存储文件名
//            采集光谱动作宏定义：分别为：停止采集、开始采集、开始采集预览
//            STOP_ACT 0
//            TAKE_ACT 1
//            PREVIEW_ACT 2
//             */
//            [DllImport("VixLib.dll", EntryPoint = "Vix_StartTakeSpectrumData", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]//, EntryPoint = "Vix_StartTakeSpectrumData", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)
//            public static extern int Vix_StartTakeSpectrumData(int act, int iType, int iFormat, double[] fBaud0, double[] fBaud1, int iMaxLineNum, string file);

//            /*基于光谱图像三个通道生成同等大小的伪彩图像，缺省通道为红(650nm)/绿(550nm)
//            /蓝(450nm)。
//            输入：
//             iType 为光谱图像类型：0-光强，1-反射率
//             iRedShow 为 0-正常显示，1-过曝区域使用红色显示
//             pSpectrum 为光谱图像缓冲区地址
//             w 为图像宽像素数
//             h 为图像高像素数
//             输出：
//             pRgb 为 RGB 伪彩图像缓冲区地址
//            */
//            [DllImport("VixLib.dll", EntryPoint = "Vix_SpectrumToRgb", CallingConvention = CallingConvention.Cdecl)]
//            public static extern void Vix_SpectrumToRgb(int iType, int iRedShow, byte[] pSpectrum, byte[] pRgb, int w, int h);

//            /*SDK 初始化时(见设备初始化)出参 pImg 携带当前实时光谱图像的缓冲区地址。用户
//             * 备份此缓冲区内容后可通过本接口存储当前光谱数据。
//               本接口将备份的光谱图像存储为一张 tif 图片文件。单帧光谱数据强制存储为 tif
//               后缀，如用户指定为非 tif 后缀文件名，软件将在结尾添加 tif 后缀
//            输入：
//            file 为存储文件名
//            pSpectrum 应用自定义光谱图像缓冲区地址
//           注意：pImg 为光谱图像缓冲区，相机工作过程中持续使用最新数据刷新此缓冲区，应用程
//           序操作此数据时需要先在根据设备初始化时获取的图像尺寸创建内存空间，备份 pImg 图
//          像后正新的专用内存空间完成图像操作。
//            */
//            [DllImport("VixLib.dll", EntryPoint = "Vix_SaveSpectrumToFile", CallingConvention = CallingConvention.Cdecl)]
//            public static extern void Vix_SaveSpectrumToFile(string file, byte[] pSpectrum);

//            /*存储某空间位置光谱数据为 csv 文件。
//             * 输入：
//             file 为存储文件名
//             pSpectrum 应用自定义光谱图像缓冲区地址
//             hPos 为空间位置（高方向像素）
//            注意：同（5.3.6）pImg 为光谱图像缓冲区，相机工作过程中持续使用最新数据刷新此缓
//             冲区，应用程序操作此数据时需要先在根据设备初始化时获取的图像尺寸创建内存空间，
//             备份 pImg 图像后正新的专用内存空间完成图像操作。
//             */
//            [DllImport("VixLib.dll", EntryPoint = "Vix_SaveSpectrumCurveToFile", CallingConvention = CallingConvention.Cdecl)]
//            public static extern void Vix_SaveSpectrumCurveToFile(string file, byte[] pSpectrum, int hPos);
//        [DllImport("VixLib.dll", EntryPoint = "Vix_SetBinningMode", CallingConvention = CallingConvention.Cdecl)]
//        public static extern void Vix_SetBinningMode(int Val);
//        [DllImport("VixLib.dll", EntryPoint = "Vix_GetBinningMode", CallingConvention = CallingConvention.Cdecl)]
//        public static extern void Vix_GetBinningMode(ref int Val);

//        public static byte[] buffer;//数据存储
//            public static double ImageWidth;// 数据宽度
//            public static double ImageHeight;// 数据高度
//            public static double ImageDepth;//图像位深
//            public static DllcallBack dllcallBack;//创建委托
//            public string sVixID = null;
//            public string datapath = null;
//            public psVixDeviceParam1 psVixDevice1 = new psVixDeviceParam1();//400-1700相机参数
//            public psVixWbParam1 psVixWbParam1 = new psVixWbParam1(); //400-1700参考板相机参数
//            public static int ImageFrame = 0;
//            public static byte[] Prgb;


//            public static void GradImage(int info_type, long wParam, long lParam, IntPtr reserve)
//            {
//                if (info_type == 0)
//                {
//                    //图像采集结束
//                }
//                else if (info_type == 1)
//                {
//                    //进行数据处理

//                }
//            }

//            public void StartCamera(object str) //开始采集数据
//            {
//                try
//                {
//                    int act = 1;//开始采集句柄
//                    int iType = 0;//采集光强
//                    IntPtr iType1 = new IntPtr(iType);
//                    int iFormat = 1;//存储文件类型
//                    double[] fBaud0 = new double[8];//起始波段
//                    double[] fBaud1 = new double[8];//起始波段//最终波段
//                    for (int i = 0; i < 8; i++)
//                    {
//                        if (i == 0)
//                        {
//                            fBaud0[i] = 400;
//                            fBaud1[i] = 1000;
//                        }
//                        else
//                        {
//                            fBaud0[i] = 0;
//                            fBaud1[i] = 0;
//                        }

//                    }
//                    int iMaxLineNum = 3000;//存储线数，大于这个线相机自动停止采集
//                    IntPtr iMaxLineNum1 = new IntPtr(iMaxLineNum);
//                    //Hyper_Set.HyperFileName;
//                    string file = str + "\\" + Hyper_Set.HyperFileName;//将路径作为参数传进来
//                    Vix_StartTakeSpectrumData(act, iType, iFormat, fBaud0, fBaud1, iMaxLineNum, file);
//                    //return true;
//                }
//                catch (Exception e)
//                {
//                    MessageBox.Show("Exception: {0}", e.Message);
//                    //return false;
//                }

//            }
//            public void StopCamera(object str) //开始采集数据
//            {
//                try
//                {
//                    int act = 0;//开始采集句柄
//                    IntPtr act1 = new IntPtr(act);
//                    int iType = 0;//采集反射率
//                    IntPtr iType1 = new IntPtr(iType);
//                    int iFormat = 1;//存储文件类型
//                    IntPtr iFormat1 = new IntPtr(iFormat);
//                    double[] fBaud0 = new double[8];//起始波段
//                    double[] fBaud1 = new double[8];//起始波段//最终波段
//                    for (int i = 0; i < 8; i++)
//                    {
//                        if (i == 0)
//                        {
//                            fBaud0[i] = 400;
//                            fBaud1[i] = 1000;
//                        }
//                        else
//                        {
//                            fBaud0[i] = 0;
//                            fBaud1[i] = 0;
//                        }

//                    }
//                    int iMaxLineNum = 3000;//存储线数，大于这个线相机自动停止采集
//                                           //IntPtr iMaxLineNum1 = new IntPtr(iMaxLineNum);
//                    string file = str + "\\" + DateTime.Now.ToString("yyyyMMddhhmmss");//将路径作为参数传进来
//                    Vix_StartTakeSpectrumData(act, iType, iFormat, fBaud0, fBaud1, iMaxLineNum, file);
//                    //return true;
//                }
//                catch (Exception e)
//                {
//                    MessageBox.Show("Exception: {0}", e.Message);
//                    //return false;
//                }

//            }
//            //public bool StartCamera1() //开始采集数据预览
//            //{
//            //    try
//            //    {
//            //        int act = 2;//开始采集句柄
//            //        int iType = 1;//采集反射率
//            //        int iFormat = 1;//存储文件类型
//            //        double fBaud0 = 400;//起始波段
//            //        double fBaud1 = 1000;//最终波段
//            //        int iMaxLineNum = 1600;//存储线数，大于这个线相机自动停止采集
//            //        string file = "C:\\Users\\10446\\Desktop\\VIX";//存储文件名
//            //        Vix_StartTakeSpectrumData(act, iType, iFormat, fBaud0, fBaud1, iMaxLineNum,file);
//            //        return true;
//            //    }
//            //    catch (Exception e)
//            //    {
//            //        MessageBox.Show("Exception: {0}", e.Message);
//            //        return false;
//            //    }

//            //}

//            //public bool StopCamera() //停止采集数据
//            //{
//            //    try
//            //    {
//            //        int act = 0;//开始采集句柄
//            //        int iType = 1;//采集反射率
//            //        int iFormat = 1;//存储文件类型
//            //        int fBaud0 = 400;//起始波段
//            //        int fBaud1 = 1000;//最终波段
//            //        int iMaxLineNum = 10000;//存储线数，大于这个线相机自动停止采集
//            //        string file = "C:\\Users\\10446\\Desktop\\VIX" + DateTime.Now.ToString() + ".spe";//存储文件名
//            //        Vix_StartTakeSpectrumData(act, iType, iFormat, fBaud0, fBaud1, iMaxLineNum, file);
//            //        return true;
//            //    }
//            //    catch (Exception e)
//            //    {
//            //        MessageBox.Show("Exception: {0}", e.Message);
//            //        return false;
//            //    }

//            //}

//            public int Camera_Init()//设备初始化
//            {
//                psVixDevice1.iProgramMode = 0;
//                psVixDevice1.iBinning = 0;
//                psVixDevice1.iWidth = 0;
//                psVixDevice1.iHeight = 0;
//                psVixDevice1.iDepth = 2;
//                psVixDevice1.iTimeId = 0;
//                psVixDevice1.fBaud = new double[2048];
//                psVixDevice1.pImg = null;
//                psVixDevice1.pScanImg = null;
//                psVixDevice1.iTimeId = 80;
//                psVixDevice1.iGainId = 0;

//                psVixWbParam1.iTake = 0;
//                psVixWbParam1.iTimeId = 0;
//                psVixWbParam1.iGainId = 0;
//                psVixWbParam1.iReflectivity = 100;
//                psVixWbParam1.iTakeTime = new int[6];

//                IntPtr sVixID = new IntPtr();
//            string str = "C:\\Users\\TTY\\AppData\\Roaming\\VIX-W417;";
//                if (!Directory.Exists(str))
//                {
//                    str = "./VIX";
//                }

//                dllcallBack = new DllcallBack(GradImage);
//                int LinkSate = Vix_Init(ref psVixDevice1, ref psVixWbParam1, dllcallBack, str, sVixID);//psVixDevice1, psVixWbParam1, 
//                if (LinkSate == 1)
//                {
//                    MessageBox.Show("成功");
//                }
//                else if (LinkSate == 0)
//                {
//                    MessageBox.Show("已经加载光谱采集库不能重复加载");
//                }
//                else if (LinkSate == -1)
//                {
//                    MessageBox.Show("不能读取设备波段信息");
//                }
//                else if (LinkSate == -5)
//                {
//                    MessageBox.Show("获取相机图像数据失败");
//                }
//                else if (LinkSate == -6)
//                {
//                    MessageBox.Show("连接相机失败");
//                }
//                return LinkSate;
//            }
//        public void Camera_Exit()
//        {
//            Vix_Exit();
//        }

//        public int GetCameraFps()//获取相机帧频
//            {
//                return Vix_GetFps();
//            }
//        public int SetCameraFps(int a)//设置相机帧频
//        {

//            return Vix_SetFps(a);
//        }


//        public double GetCameraExposureTimeValue(int id) //获取id对应的曝光时间0-149范围
//            {
//                if (id > 149)
//                {
//                    id = 149;
//                }
//                return Vix_GetExposureTimeValue(id);
//            }

//            public int SetCameraTime(int id) //设置曝光时间 0为失败 1为成功
//            {
//                if (id > 149)
//                {
//                    id = 149;
//                }
//                return Vix_SetTime(id);
//            }
//            public double GetCameraExposureGainValue(int id) //获取相机增益 0-60获取
//            {
//                if (id > 60)
//                {
//                    id = 60;
//                }

//                return Vix_GetExposureGainValue(id);
//            }
//            //psVixDeviceParam psVixDevice1 = new psVixDeviceParam();
//            // psVixWbParam psVixWbParam1 = new psVixWbParam();
//            /*
//             *   public  int iProgramMode;                   // 软件运行模式:标准光谱
//         public int iInverted;                      // 图像倒置	
//         public int iBinning;                       // 图像画幅
//        public int iWidth;                         // 图像宽
//        public int iHeight;                        // 图像高
//        public int iDepth;                         // 数据位深	
//        public int iSize;                          // 大小
//        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 30)]
//        public double[] fBaud;                 // 波段信息(新增)
//        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 30)]
//        public byte[] pImg;                // 相机图像缓冲区
//        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 30)]
//        public byte[] pScanImg;                    // 推扫图像缓冲区
//        public int iTimeId;                        // 当前曝光时间ID
//        public int iGainId;  

//             public int iTake;//是否采集有效
//        public int iTimeId;//采集参考板曝光时间
//        public int iGainId;//采集参考板增益
//        public int iReflectivity;//参考板反射率
//        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
//        public  int[] iTakeTime;//采集参考板时间
//             */
//            public int SetCameraGain(int id)//设置相机增益 0-60 设置
//            {
//                if (id > 60)
//                {
//                    id = 60;
//                }
//                return Vix_SetGain(id);
//            }

//            public double GetCameraBaud(int pos)//通过像素获取波段信息，pos 为光谱方向像素位置
//            {
//                return Vix_GetBaud(pos);
//            }

//            public void ReadCameraDeviceParamFromIniFile(ref int iMode, ref int iType, ref int iDepth) //从配置文件读取相机参数
//            {
//                Vix_ReadDeviceParamFromIniFile(iMode, iType, iDepth);
//            }
//            public void Vix_SaveCameraDeviceParamToIniFile(int iMode, int iType, int iDepth) //从配置相机参数
//            {
//                Vix_ReadDeviceParamFromIniFile(iMode, iType, iDepth);
//            }
//            public void TakeCameraWbData() //采集参考板数据
//            {
//                Vix_TakeWbData(psVixWbParam1);
//            }

//            public void ClearCameraWbData() //清楚参考板数据
//            {
//                Vix_ClearWbData(psVixWbParam1);
//            }

//            public void SetCameraWbReflectivity(int val)// 设置参考板反射率
//            {
//                Vix_SetWbReflectivity(val);
//            }


//            public static void CameraSpectrumToRgb(int iType, int iRedShow, byte[] pSpectrum, byte[] pRgb, int w, int h) //生成为彩图
//            {
//                Vix_SpectrumToRgb(iType, iRedShow, pSpectrum, pRgb, w, h);
//            }
//            public void SaveCameraSpectrumToFile(string file, byte[] pSpectrum) //本接口将备份的光谱图像存储为一张 tif 图片文件。单帧光谱数据强制存储为 tif
//                                                                                // 后缀，如用户指定为非 tif 后缀文件名，软件将在结尾添加 tif 后缀
//            {
//                Vix_SaveSpectrumToFile(file, pSpectrum);
//            }
//        public void Camera_SetBinningMode(int Val)
//        {
//            Vix_SetBinningMode(Val);
//        }
//        public void Camera_GetBinningMode(ref int Val)
//        {
//            Vix_GetBinningMode(ref Val);
//        }
//        public void SaveCameraSpectrumCurveToFile(string file, byte[] pSpectrum, int hPos) //存储某空间位置光谱数据为 csv 文件。
//            {
//                Vix_SaveSpectrumCurveToFile(file, pSpectrum, hPos);
//            }
//        }


//}


namespace m_CTP
{

    //400-1700高光谱相机
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct psVixWbParam1
    {
        public int iTake;//是否采集有效
        public int iTimeId;//采集参考板曝光时间
        public int iGainId;//采集参考板增益
        public int iReflectivity;//参考板反射率
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public int[] iTakeTime;//采集参考板时间
        int iTakeType;        // 是否采集反射率
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct psVixDeviceParam2
    {
        // [MarshalAs(UnmanagedType.LPStr)]
        public int iProgramMode;                   // 软件运行模式:标准光谱
        public int iInverted;                      // 图像倒置	
        public int iBinning;                       // 图像画幅
        public int iWidth;                         // 图像宽
        public int iHeight;                        // 图像高
        public int iDepth;                         // 数据位深	
        public int iSize;                          // 大小
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2048)]
        public double[] fBaud;                 // 波段信息(新增)
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4096)]
        public byte[] pImg;                // 相机图像缓冲区
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4096)]
        public byte[] pScanImg;                    // 推扫图像缓冲区
        public int iTimeId;                        // 当前曝光时间ID
        public int iGainId;                        // 当前增益ID
        int iSoltWidth;                     // 当前光谱间隔
        int iMaxLineNum;                    // 系统存储线数能力
        int iExpoureTimeNum;                // 曝光时间通道数
        int iExpoureGainNum;                // 曝光增益通道数
        int iMinSoltWidth;                  // 相机支持的最小光谱间隔
        int iReserve;                       // 是否支持LET检测模式
        int iReserve2;                      // usb2.0 如果大于1则为2.0，否则为3.0
        int iReserve3;                      // 保留
    }
    public struct psVixDeviceParam1
    {
        public int iProgramMode;                   // 软件运行模式：自动或触发模式
        public int iFlip;                          // 图像倒置	
        public int iBinning;                       // 图像画幅
        public int iWidth;                         // 图像宽
        public int iHeight;                        // 图像高
        public int iDepth;                         // 数据位深	
        public int iSize;                          // 大小
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2048)]
        public double[] fBaud;                  // 波段信息(新增)
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4096)]
        public byte[] pImg;                  // 光谱图像缓冲区
        public int iPreViewWidth;                  // 推扫图像(伪彩)宽度
        public int iPreViewHeight;                 // 推扫图像(伪彩)高度
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4096)]
        public byte[] pScanImg;                // 推扫图像(伪彩)缓冲区 -> 当前线的伪彩图
        public int iTimeId;                        // 当前曝光时间ID
        public int iGainId;                        // 当前增益ID
        public int iDenoise;                       // 当前降噪
        public int iSoltWidth;                     // 当前光谱间隔
        public int iMaxLineNum;                    // 系统存储线数能力
        public int iExpoureTimeNum;                // 曝光时间通道数
        public int iExpoureGainNum;                // 曝光增益通道数
        public int iMinSoltWidth;                  // 相机支持的最小光谱间隔
        public int iSupportExtend;                 // 是否支持LET检测模式
        public int iUSB2;                          // usb2.0 如果大于1则为2.0，否则为3.0
        public int iDeviceType;                    // 设备类型 0/S270 1/S230 2/S270G 3/S230G
        public int iCapturing;                     // 是否启动采集
        public int iClassifiable;                  // 是否分类
        public int iROIMode;                       // 硬ROI模式
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public int[] iROIBand;    // 硬ROI波段
        public int iROIHeight;
        public int iROIYOffset;
        public int iImageBinningH;                 // 图像画幅
        public int iImageBinningW;                 // 图像画幅
        public int iPseudoRed;                     // 伪彩红色波段
        public int iPseudoGreen;                   // 伪彩绿色波段
        public int iPseudoBlue;                    // 伪彩蓝色波段
    }
    public class HyperCamera_2
    {


        /* 相机初始化需要传递回调函数进去，返回相机参数*/
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        // public delegate void DllcallBack(int info_type, long wParam, long lParam, IntPtr reserve);
        public delegate void DllcallBack(int info_type, int iWidth, int iHeight, int iDepth, IntPtr pImg, long frameSn, long frameTime, long triggerCount, IntPtr pColorLine);
        //int info_type, int iWidth, int iHeight, int iDepth, void * pImg, unsigned long long frameSn, unsigned long long frameTime, unsigned long long triggerCount, void * pColorLine
        /*相机初始化*/
        [DllImport("VixLib.dll", EntryPoint = "Vix_Init", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Vix_Init(ref psVixDeviceParam1 psVixDeviceParam, ref psVixWbParam1 psVixWbParam, DllcallBack callbackfunc, [MarshalAs(UnmanagedType.LPWStr)] string datapath, IntPtr sVixID);//ef psVixDeviceParam psVixDeviceParam, 

        [DllImport("VixLib.dll", EntryPoint = "Vix_InitTidy", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Vix_InitTidy(DllcallBack callbackfunc, string datapath, string sVixID);//ef psVixDeviceParam psVixDeviceParam, 

        /*关闭相机*/
        [DllImport("VixLib.dll", EntryPoint = "Vix_Exit", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Vix_Exit();
        /*获取帧频*/
        [DllImport("VixLib.dll", EntryPoint = "Vix_GetFps", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Vix_GetFps();
        /*设置帧频*/
        [DllImport("VixLib.dll", EntryPoint = "Vix_SetFps", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Vix_SetFps(int a);
        /*获取曝光时间*/
        [DllImport("VixLib.dll", EntryPoint = "Vix_GetTime", CallingConvention = CallingConvention.Cdecl)]
        public static extern double Vix_GetTime(int id);

        /*设置曝光时间*/
        [DllImport("VixLib.dll", EntryPoint = "Vix_SetTime", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Vix_SetTime(int id);

        /*获取相机增益*/
        [DllImport("VixLib.dll", EntryPoint = "Vix_GetGain", CallingConvention = CallingConvention.Cdecl)]
        public static extern double Vix_GetGain(int id);

        /*设置相机增益*/
        [DllImport("VixLib.dll", EntryPoint = "Vix_SetGain", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Vix_SetGain(int id);

        /*通过像素获取波段信息. pos 为光谱方向像素位置*/
        [DllImport("VixLib.dll", EntryPoint = "Vix_GetBaud", CallingConvention = CallingConvention.Cdecl)]
        public static extern double Vix_GetBaud(int pos);

        [DllImport("VixLib.dll", EntryPoint = "Vix_ImageCapturingStart", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Vix_ImageCapturingStart();

        /*从配置文件读取相机参数
         * 返回值：iMode-运行模式
            iType-采集画幅
            iDepth-采集位深
         */
        [DllImport("VixLib.dll", EntryPoint = "Vix_ReadDeviceParamFromIniFile", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Vix_ReadDeviceParamFromIniFile(int iMode, int iType, int iDepth);

        /*存储相机参数到配置文件
         * 输入值：iMode-运行模式
          iType-采集画幅
          iDepth-采集位深
          注：不会立即生效，应用软件重启时再次调用本库，方能生效
         */
        [DllImport("VixLib.dll", EntryPoint = "Vix_SaveDeviceParamToIniFile", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Vix_SaveDeviceParamToIniFile(int iMode, int iType, int iDepth);

        /*采集参考板动作。如果采集数据为反射率，需要提前放置白板，并通过采集参考板操
          作采集参考白板。SDK 只有在有效采集到参考白板时才允许光谱采集操作时指定采集类型
          为反射率。
          返回值：psVixWbParam（参考板采集参数，见公共数据结构）
        */
        [DllImport("VixLib.dll", EntryPoint = "Vix_TakeWbData", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Vix_TakeWbData(psVixWbParam1 psVixWbParam);

        /*清除参考板。清除后不允许发起类型为反射率的光谱采集。
         返回值：psVixWbParam（参考板采集参数，见公共数据结构）
        */
        [DllImport("VixLib.dll", EntryPoint = "Vix_ClearWbData", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Vix_ClearWbData(psVixWbParam1 psVixWbParam);

        /*根据使用的白板物理参数，设置参考板反射率。
         输入值：val = 10~100
        */
        [DllImport("VixLib.dll", EntryPoint = "Vix_SetWbReflectivity", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Vix_SetWbReflectivity(int val);

        /*光谱采集启动停止操作接口。通过参数启动/停止预览采集（不存储光谱数据）或者
          普通推扫采集（将采集数据存入 file 指定路径，文件名实时生成）
          输入：
          act 为动作类型（见下述采集光谱动作宏定义）
          iType 为采集类型：=0（采集光强）、=1（采集反射率）
          iFormat 为采集文件存储格式：=0（BSQ 文件）
          =1（BIL 文件）
          =2（图片集合）
          fBaud0 为采集起始波段
          fBaud1 为采集终止波段
          iMaxLineNum 存储线数
          file 为存储文件名
        采集光谱动作宏定义：分别为：停止采集、开始采集、开始采集预览
        STOP_ACT 0
        TAKE_ACT 1
        PREVIEW_ACT 2
         */
        [DllImport("VixLib.dll", EntryPoint = "Vix_StartTakeSpectrumData", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]//, EntryPoint = "Vix_StartTakeSpectrumData", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)
        public static extern int Vix_StartTakeSpectrumData(int act, int iFormat, double[] fBaud0, double[] fBaud1, int iMaxLineNum, string file);

        /*基于光谱图像三个通道生成同等大小的伪彩图像，缺省通道为红(650nm)/绿(550nm)
        /蓝(450nm)。
        输入：
         iType 为光谱图像类型：0-光强，1-反射率
         iRedShow 为 0-正常显示，1-过曝区域使用红色显示
         pSpectrum 为光谱图像缓冲区地址
         w 为图像宽像素数
         h 为图像高像素数
         输出：
         pRgb 为 RGB 伪彩图像缓冲区地址
        */
        [DllImport("VixLib.dll", EntryPoint = "Vix_SpectrumToRgb", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Vix_SpectrumToRgb(int iType, int iRedShow, byte[] pSpectrum, byte[] pRgb, int w, int h);

        /*SDK 初始化时(见设备初始化)出参 pImg 携带当前实时光谱图像的缓冲区地址。用户
         * 备份此缓冲区内容后可通过本接口存储当前光谱数据。
           本接口将备份的光谱图像存储为一张 tif 图片文件。单帧光谱数据强制存储为 tif
           后缀，如用户指定为非 tif 后缀文件名，软件将在结尾添加 tif 后缀
        输入：
        file 为存储文件名
        pSpectrum 应用自定义光谱图像缓冲区地址
       注意：pImg 为光谱图像缓冲区，相机工作过程中持续使用最新数据刷新此缓冲区，应用程
       序操作此数据时需要先在根据设备初始化时获取的图像尺寸创建内存空间，备份 pImg 图
      像后正新的专用内存空间完成图像操作。
        */
        [DllImport("VixLib.dll", EntryPoint = "Vix_SaveSpectrumToFile", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Vix_SaveSpectrumToFile(string file, byte[] pSpectrum);

        /*存储某空间位置光谱数据为 csv 文件。
         * 输入：
         file 为存储文件名
         pSpectrum 应用自定义光谱图像缓冲区地址
         hPos 为空间位置（高方向像素）
        注意：同（5.3.6）pImg 为光谱图像缓冲区，相机工作过程中持续使用最新数据刷新此缓
         冲区，应用程序操作此数据时需要先在根据设备初始化时获取的图像尺寸创建内存空间，
         备份 pImg 图像后正新的专用内存空间完成图像操作。
         */
        [DllImport("VixLib.dll", EntryPoint = "Vix_SaveSpectrumCurveToFile", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Vix_SaveSpectrumCurveToFile(string file, byte[] pSpectrum, int hPos);

        [DllImport("VixLib.dll", EntryPoint = "Vix_SetBinningMode", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Vix_SetBinningMode(int Val);

        [DllImport("VixLib.dll", EntryPoint = "Vix_GetBinningMode", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Vix_GetBinningMode(ref int Val);

        public static byte[] buffer;//数据存储
        public static double ImageWidth;// 数据宽度
        public static double ImageHeight;// 数据高度
        public static double ImageDepth;//图像位深
        public static DllcallBack dllcallBack;//创建委托
        public string sVixID = null;
        public string datapath = null;
        public psVixDeviceParam1 psVixDevice1 = new psVixDeviceParam1();//400-1700相机参数
        public psVixWbParam1 psVixWbParam1 = new psVixWbParam1(); //400-1700参考板相机参数
        public static int ImageFrame = 0;
        public static byte[] Prgb;
        // public Form1 form1 = new Form1();

        public static void GradImage(int info_type, int iWidth, int iHeight, int iDepth, IntPtr pImg, long frameSn, long frameTime, long triggerCount, IntPtr pColorLine)
        {
            if (info_type == 0)
            {
                //图像采集结束
            }
            else if (info_type == 1)
            {

                byte[] bytes1 = new byte[iWidth * iHeight * 2];
                byte[] bytes = new byte[iWidth * iHeight * 2];
                Marshal.Copy((IntPtr)pImg, bytes, 0, iWidth * iHeight * 2);
                //Mat image = new Mat(iHeight, iWidth, MatType.CV_16UC1, bytes);//将数据变成图片
                //进行数据处理
                if (Hyper.GradSate)//
                {
                    Hyper.DrawImage(bytes, iHeight, iWidth);
                }
            }
        }

        public void StartCamera(string str) //开始采集数据
        {
            try
            {
                int act = 1;//开始采集句柄
                int iType = 0;//采集光强
                IntPtr iType1 = new IntPtr(iType);
                int iFormat = 1;//存储文件类型
                double[] fBaud0 = new double[8];//起始波段
                double[] fBaud1 = new double[8];//起始波段//最终波段
                for (int i = 0; i < 8; i++)
                {
                    if (i == 0)
                    {
                        fBaud0[i] = 400;
                        fBaud1[i] = 1700;
                    }
                    else
                    {
                        fBaud0[i] = 0;
                        fBaud1[i] = 0;
                    }

                }
                int iMaxLineNum = 1140;//存储线数，大于这个线相机自动停止采集
                                       //IntPtr iMaxLineNum1 = new IntPtr(iMaxLineNum);
                                       // string HyperFileName = DateTime.Now.ToString("yyyyMMddhhmmss");
           
                string file = str + "\\" + Hyper_Set.HyperFileName;//将路径作为参数传进来

                Vix_StartTakeSpectrumData(act, iFormat, fBaud0, fBaud1, iMaxLineNum, file);
                // int a = Vix_ImageCapturingStart();
                //return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception: {0}", e.Message);
                //return false;
            }
            Form1.ProgramChecking = "高光谱开始采集!";

        }
        public void StopCamera(string str) //开始采集数据
        {
            try
            {
                int act = 0;//开始采集句柄
                IntPtr act1 = new IntPtr(act);
                int iType = 0;//采集反射率
                IntPtr iType1 = new IntPtr(iType);
                int iFormat = 1;//存储文件类型
                IntPtr iFormat1 = new IntPtr(iFormat);
                double[] fBaud0 = new double[8];//起始波段
                double[] fBaud1 = new double[8];//起始波段//最终波段
                for (int i = 0; i < 8; i++)
                {
                    if (i == 0)
                    {
                        fBaud0[i] = 400;
                        fBaud1[i] = 1700;
                    }
                    else
                    {
                        fBaud0[i] = 0;
                        fBaud1[i] = 0;
                    }

                }
                int iMaxLineNum = 3000;//存储线数，大于这个线相机自动停止采集
                //string HyperFileName = DateTime.Now.ToString("yyyyMMddhhmmss");                     //IntPtr iMaxLineNum1 = new IntPtr(iMaxLineNum);
                string file = str + "\\" + Hyper_Set.HyperFileName;//将路径作为参数传进来
                Vix_StartTakeSpectrumData(act, iFormat, fBaud0, fBaud1, iMaxLineNum, file);
                //return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception: {0}", e.Message);
                //return false;
            }
            Form1.ProgramChecking = "高光谱停止采集!";

        }
        //public bool StartCamera1() //开始采集数据预览
        //{
        //    try
        //    {
        //        int act = 2;//开始采集句柄
        //        int iType = 1;//采集反射率
        //        int iFormat = 1;//存储文件类型
        //        double fBaud0 = 400;//起始波段
        //        double fBaud1 = 1000;//最终波段
        //        int iMaxLineNum = 1600;//存储线数，大于这个线相机自动停止采集
        //        string file = "C:\\Users\\10446\\Desktop\\VIX";//存储文件名
        //        Vix_StartTakeSpectrumData(act, iType, iFormat, fBaud0, fBaud1, iMaxLineNum,file);
        //        return true;
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show("Exception: {0}", e.Message);
        //        return false;
        //    }

        //}

        //public bool StopCamera() //停止采集数据
        //{
        //    try
        //    {
        //        int act = 0;//开始采集句柄
        //        int iType = 1;//采集反射率
        //        int iFormat = 1;//存储文件类型
        //        int fBaud0 = 400;//起始波段
        //        int fBaud1 = 1000;//最终波段
        //        int iMaxLineNum = 10000;//存储线数，大于这个线相机自动停止采集
        //        string file = "C:\\Users\\10446\\Desktop\\VIX" + DateTime.Now.ToString() + ".spe";//存储文件名
        //        Vix_StartTakeSpectrumData(act, iType, iFormat, fBaud0, fBaud1, iMaxLineNum, file);
        //        return true;
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show("Exception: {0}", e.Message);
        //        return false;
        //    }

        //}

        public int Camera_Init()//设备初始化
        {
            psVixDevice1.iProgramMode = 0;
            psVixDevice1.iBinning = 0;
            psVixDevice1.iWidth = 0;
            psVixDevice1.iHeight = 0;
            psVixDevice1.iDepth = 2;
            psVixDevice1.iTimeId = 0;
            psVixDevice1.fBaud = new double[2048];
            psVixDevice1.pImg = null;
            psVixDevice1.pScanImg = null;
            psVixDevice1.iTimeId = 80;
            psVixDevice1.iGainId = 0;

            psVixWbParam1.iTake = 0;
            psVixWbParam1.iTimeId = 0;
            psVixWbParam1.iGainId = 0;
            psVixWbParam1.iReflectivity = 100;
            psVixWbParam1.iTakeTime = new int[6];

            IntPtr sVixID = new IntPtr();
            string str = "C:\\Users\\SF\\AppData\\Roaming\\VIX-W417"; //E:\\VIX - W417 "C:\\Users\\ydh\\AppData\\Roaming\\VIX - W417"C:\Users\SF\AppData\Roaming
            if (!Directory.Exists(str))
            {
                str = "";
            }

            dllcallBack = new DllcallBack(GradImage);
            int LinkSate = Vix_Init(ref psVixDevice1, ref psVixWbParam1, dllcallBack, str, sVixID);//psVixDevice1, psVixWbParam1, 
            if (LinkSate == 1)
            {
                //  MessageBox.Show("成功");
                Form1.ProgramChecking = "高光谱连接成功";
            }
            else if (LinkSate == 0)
            {
                MessageBox.Show("已经加载光谱采集库不能重复加载");
            }
            else if (LinkSate == -1)
            {
                MessageBox.Show("不能读取设备波段信息");
            }
            else if (LinkSate == -5)
            {
                MessageBox.Show("获取相机图像数据失败");
            }
            else if (LinkSate == -6)
            {
                MessageBox.Show("连接相机失败");
            }
            return LinkSate;
        }

        public void Camera_Exit()
        {
            Vix_Exit();
        }

        public int GetCameraFps()//获取相机帧频
        {
            return Vix_GetFps();
        }
        public int SetCameraFps(int a)//获取相机帧频
        {

            return Vix_SetFps(a);
        }

        public double GetCameraExposureTimeValue(int id) //获取id对应的曝光时间0-149范围
        {
            if (id > 200)
            {
                id = 200;
            }
            return Vix_GetTime(id);

        }

        public int SetCameraTime(int id) //设置曝光时间 0为失败 1为成功
        {
            if (id > 200)
            {
                id = 200;
            }
            return Vix_SetTime(id);
        }
        public double GetCameraExposureGainValue(int id) //获取相机增益 0-60获取
        {
            if (id > 200)
            {
                id = 200;
            }

            return Vix_GetGain(id);
        }
        //psVixDeviceParam psVixDevice1 = new psVixDeviceParam();
        // psVixWbParam psVixWbParam1 = new psVixWbParam();
        /*
         *   public  int iProgramMode;                   // 软件运行模式:标准光谱
     public int iInverted;                      // 图像倒置	
     public int iBinning;                       // 图像画幅
    public int iWidth;                         // 图像宽
    public int iHeight;                        // 图像高
    public int iDepth;                         // 数据位深	
    public int iSize;                          // 大小
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 30)]
    public double[] fBaud;                 // 波段信息(新增)
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 30)]
    public byte[] pImg;                // 相机图像缓冲区
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 30)]
    public byte[] pScanImg;                    // 推扫图像缓冲区
    public int iTimeId;                        // 当前曝光时间ID
    public int iGainId;  

         public int iTake;//是否采集有效
    public int iTimeId;//采集参考板曝光时间
    public int iGainId;//采集参考板增益
    public int iReflectivity;//参考板反射率
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
    public  int[] iTakeTime;//采集参考板时间
         */
        public int SetCameraGain(int id)//设置相机增益 0-60 设置
        {
            if (id > 200)
            {
                id = 200;
            }
            return Vix_SetGain(id);
        }

        public double GetCameraBaud(int pos)//通过像素获取波段信息，pos 为光谱方向像素位置
        {
            return Vix_GetBaud(pos);
        }

        public void ReadCameraDeviceParamFromIniFile(ref int iMode, ref int iType, ref int iDepth) //从配置文件读取相机参数
        {
            Vix_ReadDeviceParamFromIniFile(iMode, iType, iDepth);
        }
        public void Vix_SaveCameraDeviceParamToIniFile(int iMode, int iType, int iDepth) //从配置相机参数
        {
            Vix_ReadDeviceParamFromIniFile(iMode, iType, iDepth);
        }
        public void TakeCameraWbData() //采集参考板数据
        {
            Vix_TakeWbData(psVixWbParam1);
        }

        public void ClearCameraWbData() //清楚参考板数据
        {
            Vix_ClearWbData(psVixWbParam1);
        }

        public void SetCameraWbReflectivity(int val)// 设置参考板反射率
        {
            Vix_SetWbReflectivity(val);
        }


        public static void CameraSpectrumToRgb(int iType, int iRedShow, byte[] pSpectrum, byte[] pRgb, int w, int h) //生成为彩图
        {
            Vix_SpectrumToRgb(iType, iRedShow, pSpectrum, pRgb, w, h);
        }
        public void SaveCameraSpectrumToFile(string file, byte[] pSpectrum) //本接口将备份的光谱图像存储为一张 tif 图片文件。单帧光谱数据强制存储为 tif
                                                                            // 后缀，如用户指定为非 tif 后缀文件名，软件将在结尾添加 tif 后缀
        {
            Vix_SaveSpectrumToFile(file, pSpectrum);
        }

        public void SaveCameraSpectrumCurveToFile(string file, byte[] pSpectrum, int hPos) //存储某空间位置光谱数据为 csv 文件。
        {
            Vix_SaveSpectrumCurveToFile(file, pSpectrum, hPos);
        }

        public void Camera_SetBinningMode(int Val)
        {
            Vix_SetBinningMode(Val);
        }
        public void Camera_GetBinningMode(ref int Val)
        {
            Vix_GetBinningMode(ref Val);
        }
    }


}

