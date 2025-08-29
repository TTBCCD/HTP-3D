using BasicDemo;
using Basler.Pylon;
using Canondemo;
using EDSDKLib;
using MvCamCtrl.NET;
using NPOI.SS.Formula.Functions;
using OpenCvSharp.Dnn;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ComboBox = System.Windows.Forms.VisualStyles.VisualStyleElement.ComboBox;

namespace m_CTP
{
   public class MutiCamera
    {
        public static RgbCamera rgbCamera;
        //public static ListView ListView3;
        //public static ListBox ListBox3;
        //public static int CameraCount;
        //public bool ParWriteSate = false;

        public static string RGBFileName1 = "";
        public static string RGBFileId1 = "";
        public static string RGBFileName2 = "";
        public static string RGBFileId2 = "";
       private string iniPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config.ini");

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string Section, string Key, string Val, string FilePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string Section, string Key, string Def, StringBuilder RetVal, int Size, string FilePath);
        



        MyCamera.MV_CC_DEVICE_INFO_LIST m_stDeviceList = new MyCamera.MV_CC_DEVICE_INFO_LIST();
        MyCamera.MV_CC_DEVICE_INFO[] m_pDeviceInfo = new MyCamera.MV_CC_DEVICE_INFO[2];
        public static readonly object Lock = new object();
        public MyCamera m_MyCamera = new MyCamera();
        public static MyCamera.cbOutputExdelegate cbImage;
        public UInt32 m_nDevNum = 0;
        public static uint m_nCanOpenDevNum = 0;
        public static MyCamera[] m_pMyCamera = new MyCamera[2];
        int[] m_nCurSelIndex = new int[2];
        public IntPtr[] m_pHwnd = new IntPtr[2];
        public string savepicture = "jpg";
        public IntPtr[] m_hDisplayHandle = new IntPtr[2];
       public int[] m_nFrames= new int[2];
        public MV3D_RGBD_DEVICE_INFO_VECTOR m_stVector;
       public static MyCamera.MV_FRAME_OUT_INFO_EX[] m_stFrameInfo = new MyCamera.MV_FRAME_OUT_INFO_EX[4];
        bool m_bGrabbing;
        public Object[] m_BufForSaveImageLock = new Object[2];
        public IntPtr[] m_pSaveImageBuf = new IntPtr[2] { IntPtr.Zero, IntPtr.Zero };
        public UInt32[] m_nSaveImageBufSize = new UInt32[2] { 0, 0 };
        public Thread m_hReceiveThread = null;
        bool m_bTimerFlag;
        public uint bufferNodeNum = 5; // 推荐3~5个
        [DllImport("kernel32.dll", EntryPoint = "RtlMoveMemory", SetLastError = false)]
        public static extern void CopyMemory(IntPtr dest, IntPtr src, uint count);
        public readonly List<Bitmap> displayFrames = new List<Bitmap>();
        public readonly object frameLock = new object();
        //public PictureBox _targetCamera1;
        //public PictureBox _targetCamera2;
        public PictureBox camera1 = new System.Windows.Forms.PictureBox();
        public PictureBox camera2 = new System.Windows.Forms.PictureBox();
        public int flag = 0;
        public MutiCamera( )
        {
              //camera1= camera12;
             // camera2=camera22;
    
            for (int i = 0; i < 2; ++i)
            {
                m_BufForSaveImageLock[i] = new Object();
            }
        }
        public void DeviceListAcq()
        {

            System.GC.Collect();
            int nRet = MyCamera.MV_CC_EnumDevices_NET(MyCamera.MV_GIGE_DEVICE | MyCamera.MV_USB_DEVICE, ref m_stDeviceList);
            if (0 != nRet)
            {
                ShowErrorMsg("Enumerate devices fail!", nRet);
                return;
            }

            m_nDevNum = m_stDeviceList.nDeviceNum;
            cbImage = new MyCamera.cbOutputExdelegate(ImageCallBack);

        }
        public void search(UIComboBox cbDeviceList1,UIComboBox cbDeviceList2 )
            //public void search()
        {
            System.GC.Collect();
            //cbDeviceList.Items.Clear();
            cbDeviceList1.Items.Clear();
            cbDeviceList2.Items.Clear();
            m_stDeviceList.nDeviceNum = 0;
            //m_nDevNum = 0;


            int nRet = MyCamera.MV_CC_EnumDevices_NET(MyCamera.MV_GIGE_DEVICE | MyCamera.MV_USB_DEVICE | MyCamera.MV_GENTL_GIGE_DEVICE
                | MyCamera.MV_GENTL_CAMERALINK_DEVICE | MyCamera.MV_GENTL_CXP_DEVICE | MyCamera.MV_GENTL_XOF_DEVICE, ref m_stDeviceList);
            if (0 != nRet)
            {
                ShowErrorMsg("Fail to GetDeviceNumber!!", 0);
            }
            m_nDevNum = m_stDeviceList.nDeviceNum;


            //m_stVector = new MV3D_RGBD_DEVICE_INFO_VECTOR((int)m_nDevNum);
            for (int i = 0; i < m_nDevNum; i++)
            {
                int j = 0;
                //m_stVector.Add(new MV3D_RGBD_DEVICE_INFO());
                MyCamera.MV_CC_DEVICE_INFO device = (MyCamera.MV_CC_DEVICE_INFO)Marshal.PtrToStructure(m_stDeviceList.pDeviceInfo[i], typeof(MyCamera.MV_CC_DEVICE_INFO));
                string strUserDefinedName = "";
                string strSerialNumber = "";
                //= m_stVector[i].chSerialNumber;
                //strSerialNumber = strSerialNumber.TrimEnd('\0');
                if (device.nTLayerType == MyCamera.MV_GIGE_DEVICE)
                {
                    MyCamera.MV_GIGE_DEVICE_INFO_EX gigeInfo = (MyCamera.MV_GIGE_DEVICE_INFO_EX)MyCamera.ByteToStruct(device.SpecialInfo.stGigEInfo, typeof(MyCamera.MV_GIGE_DEVICE_INFO_EX));

                    if ((gigeInfo.chUserDefinedName.Length > 0) && (gigeInfo.chUserDefinedName[0] != '\0'))
                    {
                        if (MyCamera.IsTextUTF8(gigeInfo.chUserDefinedName))
                        {
                            strUserDefinedName = Encoding.UTF8.GetString(gigeInfo.chUserDefinedName).TrimEnd('\0');
                        }
                        else
                        {
                            strUserDefinedName = Encoding.Default.GetString(gigeInfo.chUserDefinedName).TrimEnd('\0');
                        }
                        //cbDeviceList.Items.Add("GEV: " + DeleteTail(strUserDefinedName) + " (" + gigeInfo.chSerialNumber + ")");
                    }
                    else
                    {
                        //cbDeviceList.Items.Add("GEV: " + gigeInfo.chManufacturerName + " " + gigeInfo.chModelName + " (" + gigeInfo.chSerialNumber + ")");
                    }
                    strSerialNumber = gigeInfo.chSerialNumber;

                    if (gigeInfo.chSerialNumber == "DA0344013") // 第一个设备
                    {
                        cbDeviceList1.Items.Clear();
                        cbDeviceList1.Items.Add("GEV: " + gigeInfo.chManufacturerName + " " + gigeInfo.chModelName + " (" + gigeInfo.chSerialNumber + ")");
                        cbDeviceList1.SelectedIndex = 0;
                       
                    }
                    else if (gigeInfo.chSerialNumber == "DA0344035") // 第二个设备
                    {
                        // 检查是否与第一个设备不同
                       
                            cbDeviceList2.Items.Clear();
                            cbDeviceList2.Items.Add("GEV: " + gigeInfo.chManufacturerName + " " + gigeInfo.chModelName + " (" + gigeInfo.chSerialNumber + ")");
                            cbDeviceList2.SelectedIndex = 0;
                        
                    }
                   // j++;
                }
               
               // cbDeviceList1.Items.Add(strSerialNumber);
               // cbDeviceList2.Items.Add(strSerialNumber);

            }



            // ch:选择第一项 | en:Select the first item
            //if (m_stDeviceList.nDeviceNum != 0)
            //{
            //    cbDeviceList.SelectedIndex = 0;

            //    cbDeviceList1.SelectedIndex = 0;
            //    cbDeviceList2.SelectedIndex = 0;


            //    cbDeviceList1.Enabled = true;
            //    cbDeviceList2.Enabled = true;


            //    //OpenDevBtn.Enabled = true;//连接设备
            //}
        }
        private string DeleteTail(string strUserDefinedName)
        {
            strUserDefinedName = Regex.Unescape(strUserDefinedName);
            int nIndex = strUserDefinedName.IndexOf("\0");
            if (nIndex >= 0)
            {
                strUserDefinedName = strUserDefinedName.Remove(nIndex);
            }

            return strUserDefinedName;
        }

        public void CameraMode(bool con) 
        {
            if (con)
            {
                for (int i=0;i< m_nCanOpenDevNum;i++)
                {
                    m_pMyCamera[i].MV_CC_SetEnumValue_NET("TriggerMode", (uint)MyCamera.MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_ON);
                } 
            }
            else
            {
                for (int i = 0; i < m_nCanOpenDevNum; i++)
                {
                    m_pMyCamera[i].MV_CC_SetEnumValue_NET("TriggerMode", (uint)MyCamera.MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_OFF);
                }
            }
        }
        public void OpenCamera()
        {
            bool bOpened = false;
            // ch:判断输入格式是否正确 | en:Determine whether the input format is correct

            // ch:获取使用设备的数量 | en:Get Used Device Number
            int nCameraUsingNum = 2;
            for (int i = 0, j = 0; j < m_stDeviceList.nDeviceNum; j++)
            {
                //ch:获取选择的设备信息 | en:Get Selected Device Information
                MyCamera.MV_CC_DEVICE_INFO device =
                    (MyCamera.MV_CC_DEVICE_INFO)Marshal.PtrToStructure(m_stDeviceList.pDeviceInfo[j], typeof(MyCamera.MV_CC_DEVICE_INFO));

                string StrTemp = "";
                string strUserDefinedName = "";

                if (device.nTLayerType == MyCamera.MV_GIGE_DEVICE)
                {
                    MyCamera.MV_GIGE_DEVICE_INFO_EX gigeInfo = (MyCamera.MV_GIGE_DEVICE_INFO_EX)MyCamera.ByteToStruct(device.SpecialInfo.stGigEInfo, typeof(MyCamera.MV_GIGE_DEVICE_INFO_EX));

                    if ((gigeInfo.chUserDefinedName.Length > 0) && (gigeInfo.chUserDefinedName[0] != '\0'))
                    {
                        if (MyCamera.IsTextUTF8(gigeInfo.chUserDefinedName))
                        {
                            strUserDefinedName = Encoding.UTF8.GetString(gigeInfo.chUserDefinedName).TrimEnd('\0');
                        }
                        else
                        {
                            strUserDefinedName = Encoding.Default.GetString(gigeInfo.chUserDefinedName).TrimEnd('\0');
                        }
                        StrTemp = "GEV: " + strUserDefinedName + " (" + gigeInfo.chSerialNumber + ")";
                    }
                    else
                    {
                        StrTemp = "GEV: " + gigeInfo.chManufacturerName + " " + gigeInfo.chModelName + " (" + gigeInfo.chSerialNumber + ")";
                    }
                    if (gigeInfo.chSerialNumber == "DA0344013")
                    {
                        i = 0;
                    }
                    else if (gigeInfo.chSerialNumber == "DA0344035")
                    {
                        i = 1;
                    }
                }

              
                //ch:打开设备 | en:Open Device
                if (null == m_pMyCamera[i])
                {
                    m_pMyCamera[i] = new MyCamera();
                    if (null == m_pMyCamera[i])
                    {
                        return;
                    }
                }

                int nRet = m_pMyCamera[i].MV_CC_CreateDevice_NET(ref device);
                if (MyCamera.MV_OK != nRet)
                {
                    return;
                }

                nRet = m_pMyCamera[i].MV_CC_OpenDevice_NET();
                nRet = m_pMyCamera[i].MV_CC_SetImageNodeNum_NET(bufferNodeNum);
                if (MyCamera.MV_OK != nRet)
                {
                    ShowErrorMsg("Create device fail!", nRet);
                    continue;
                }
                else
                {
                    //richTextBox.Text += String.Format("Open Device[{0}] success!\r\n", StrTemp);
                    Form1.ProgramChecking = "相机"+i+"连接成功";
                    m_nCanOpenDevNum++;
                    m_pDeviceInfo[i] = device;
                    // ch:探测网络最佳包大小(只对GigE相机有效) | en:Detection network optimal package size(It only works for the GigE camera)
                    if (device.nTLayerType == MyCamera.MV_GIGE_DEVICE)
                    {
                        int nPacketSize = m_pMyCamera[i].MV_CC_GetOptimalPacketSize_NET();
                        if (nPacketSize > 0)
                        {
                            nRet = m_pMyCamera[i].MV_CC_SetIntValueEx_NET("GevSCPSPacketSize", nPacketSize);
                            if (nRet != MyCamera.MV_OK)
                            {
                                ShowErrorMsg("Set Packet Size failed!\r\n", nRet);
                            }
                        }
                        else
                        {
                            ShowErrorMsg("Get Packet Size failed!\r\n", nRet);
                        }
                    }

                    m_pMyCamera[i].MV_CC_SetEnumValue_NET("TriggerMode", (uint)MyCamera.MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_ON);
                    //m_pMyCamera[i].MV_CC_SetEnumValue_NET("TriggerMode",  (uint)MyCamera.MV_CAM_TRIGGER_MODE.MV_TRIGGER_SOURCE_SOFTWARE);
                    //cbImage = new MyCamera.cbOutputExdelegate(ImageCallBack);
                   // nRet = m_pMyCamera[i].MV_CC_RegisterImageCallBackEx_NET(cbImage, (IntPtr)i);
                    if (MyCamera.MV_OK != nRet)
                    {
                        ShowErrorMsg(" fail!", nRet);
                        continue;
                    }
                    bOpened = true;
                    if (m_nCanOpenDevNum == nCameraUsingNum)
                    {
                        break;
                    }
                    //i++;
                }
            }

            // ch:只要有一台设备成功打开 | en:As long as there is a device successfully opened
            
        }
        public void StartGrabbing(PictureBox pictureBox1, PictureBox pictureBox2)
        {
            int nRet;
            m_hDisplayHandle[0] = pictureBox1.Handle;
            m_hDisplayHandle[1] = pictureBox2.Handle;

            cbImage = new MyCamera.cbOutputExdelegate(ImageCallBack);
           // GC.KeepAlive(cbImage);
            nRet = m_pMyCamera[0].MV_CC_RegisterImageCallBackEx_NET(cbImage, (IntPtr)0);
            //cbImage = new MyCamera.cbOutputExdelegate(ImageCallBack);
            nRet = m_pMyCamera[1].MV_CC_RegisterImageCallBackEx_NET(cbImage, (IntPtr)1);
         
            // ch:开始采集 | en:Start Grabbing
            for (int i = 0; i < m_nCanOpenDevNum; i++)
            {
                m_nFrames[i] = 0;
                m_stFrameInfo[i].nFrameLen = 0;//取流之前先清除帧长度
                m_stFrameInfo[i].enPixelType = MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR8;

                nRet = m_pMyCamera[i].MV_CC_StartGrabbing_NET();
                if (MyCamera.MV_OK != nRet)
                {
                    ShowErrorMsg("Start Grabbing failed! \r\n", nRet);
                }
                // nRet = m_pMyCamera[i].MV_CC_SetCommandValue_NET("AcquisitionStart");
                nRet = m_pMyCamera[i].MV_CC_SetEnumValue_NET("AcquisitionMode",2);
                nRet = m_pMyCamera[i].MV_CC_SetEnumValue_NET("TriggerMode", 1);
                if (nRet != MyCamera.MV_OK)
                {
                    ShowErrorMsg("启动连续采集失败", nRet);
                }
            }
            //cbImage = new MyCamera.cbOutputExdelegate(ImageCallBack);
            //nRet = m_pMyCamera.MV_CC_RegisterImageCallBackEx_NET(cbImage, IntPtr.Zero);
            //ch:开始计时  | en:Start Timing
            m_bTimerFlag = true;
            // ch:控件操作 | en:Control Operation
            //SetCtrlWhenStartGrab();
            // ch:标志位置位true | en:Set Position Bit true
            m_bGrabbing = true;


            //设置曝光时间

         
            StringBuilder temp = new StringBuilder(255);
            //string exp1= GetPrivateProfileString("CameraSettings", "ExposureTime1","",temp,255,iniPath).ToString();
            //string exp2= GetPrivateProfileString("CameraSettings", "ExposureTime2", "", temp, 255, iniPath).ToString();
            //Console.WriteLine(exp1, exp2);



            //Set_par(exp1, "8.0", exp2, "8.0");

        }
        public void StopGrabbing()
        {
            // ch:标志位设为false | en:Set flag bit false
            for (int i = 0; i < m_nCanOpenDevNum; ++i)
            {
                m_pMyCamera[i].MV_CC_StopGrabbing_NET();
            }
            //ch:标志位设为false  | en:Set Flag Bit false
            m_bGrabbing = false;
        }
        public void CloseCamera()
        {
            for (int i = 0; i < m_nCanOpenDevNum; ++i)
            {
                int nRet;

                nRet = m_pMyCamera[i].MV_CC_CloseDevice_NET();
                if (MyCamera.MV_OK != nRet)
                {
                    return;
                }

                nRet = m_pMyCamera[i].MV_CC_DestroyDevice_NET();
                if (MyCamera.MV_OK != nRet)
                {
                    return;
                }
            }

            //控件操作 ch: | en:Control Operation
            //SetCtrlWhenClose();
            // ch:取流标志位清零 | en:Zero setting grabbing flag bit
            m_bGrabbing = false;
            // ch:重置成员变量 | en:Reset member variable
            ResetMember();

        }
       

        // 构造函数接收外部类的PictureBox控件

        public void ResetMember()
        {
            m_stDeviceList = new MyCamera.MV_CC_DEVICE_INFO_LIST();
            m_bGrabbing = false;
            m_nCanOpenDevNum = 0;
            m_nDevNum = 0;
            DeviceListAcq();
            m_nFrames = new int[2];
            cbImage = new MyCamera.cbOutputExdelegate(ImageCallBack);
           // MyCamera.SetCallback(cbImage);
            //m_bTimerFlag = false;
            m_hDisplayHandle = new IntPtr[2];
            m_pDeviceInfo = new MyCamera.MV_CC_DEVICE_INFO[2];
        }
        public void ImageCallBack(IntPtr pData, ref MyCamera.MV_FRAME_OUT_INFO_EX pFrameInfo, IntPtr pUser)
        {
            Debug.WriteLine("Callback entered!");
            int nIndex = (int)pUser;

            // ch:抓取的帧数 | en:Aquired Frame Number
            ++m_nFrames[nIndex];

            lock (m_BufForSaveImageLock[nIndex])
            {
                if (m_pSaveImageBuf[nIndex] == IntPtr.Zero || pFrameInfo.nFrameLen > m_nSaveImageBufSize[nIndex])
                {
                    if (m_pSaveImageBuf[nIndex] != IntPtr.Zero)
                    {
                        Marshal.Release(m_pSaveImageBuf[nIndex]);
                        m_pSaveImageBuf[nIndex] = IntPtr.Zero;
                    }

                    m_pSaveImageBuf[nIndex] = Marshal.AllocHGlobal((Int32)pFrameInfo.nFrameLen);
                    if (m_pSaveImageBuf[nIndex] == IntPtr.Zero)
                    {
                        return;
                    }
                    m_nSaveImageBufSize[nIndex] = pFrameInfo.nFrameLen;
                }

                m_stFrameInfo[nIndex] = pFrameInfo;

                Console.WriteLine(pFrameInfo.nFrameLen.ToString());
                CopyMemory(m_pSaveImageBuf[nIndex], pData, pFrameInfo.nFrameLen);
            }

            MyCamera.MV_FRAME_OUT_INFO_EX frameInfoCopy = pFrameInfo; // 创建结构体副本
            IntPtr pDataCopy = pData;
            PictureBox targetPictureBox = (nIndex == 0) ? camera1 : camera2;
            MyCamera.MV_DISPLAY_FRAME_INFO stDisplayInfo = new MyCamera.MV_DISPLAY_FRAME_INFO();


            stDisplayInfo.hWnd = m_hDisplayHandle[nIndex];
            stDisplayInfo.pData = pData;
            stDisplayInfo.nDataLen = pFrameInfo.nFrameLen;
            stDisplayInfo.nWidth = pFrameInfo.nWidth;
            stDisplayInfo.nHeight = pFrameInfo.nHeight;
            stDisplayInfo.enPixelType = pFrameInfo.enPixelType;

            m_pMyCamera[nIndex].MV_CC_DisplayOneFrame_NET(ref stDisplayInfo);
            if (targetPictureBox.InvokeRequired)
            {
                targetPictureBox.BeginInvoke(new Action(() =>
                {
                    // 使用副本而不是原始ref参数
                    DisplayImageOnUI(targetPictureBox, pDataCopy, frameInfoCopy);
                }));
            }
            else
            {
                DisplayImageOnUI(targetPictureBox, pDataCopy, frameInfoCopy);
            }

            //SafeDisplayImage(nIndex, pData, pFrameInfo);

        }
        public void DisplayImageOnUI(PictureBox pictureBox, IntPtr pData, MyCamera.MV_FRAME_OUT_INFO_EX frameInfo)
        {
            MyCamera.MV_DISPLAY_FRAME_INFO stDisplayInfo = new MyCamera.MV_DISPLAY_FRAME_INFO()
            {
                hWnd = pictureBox.Handle,
                pData = pData,
                nDataLen = frameInfo.nFrameLen,
                nWidth = frameInfo.nWidth,
                nHeight = frameInfo.nHeight,
                enPixelType = frameInfo.enPixelType
            };

            // 获取相机实例
            MyCamera camera = GetCameraForPictureBox(pictureBox);
            camera.MV_CC_DisplayOneFrame_NET(ref stDisplayInfo);
        }
        public MyCamera GetCameraForPictureBox(PictureBox box)
        {
            return (box == camera1) ? m_pMyCamera[0] : m_pMyCamera[1];
        }
        public void Get_par(out string exposure1, out string gain1, out string exposure2, out string gain2)
        {
            exposure1 = "";
            gain1 = "";
            exposure2 = "";
            gain2 = "";
            MyCamera.MVCC_FLOATVALUE stParam = new MyCamera.MVCC_FLOATVALUE();

            if (m_nCanOpenDevNum == 1)
            {
                int nRet = m_pMyCamera[0].MV_CC_GetFloatValue_NET("ExposureTime", ref stParam);
                if (MyCamera.MV_OK != nRet)
                {
                    ShowErrorMsg("Get Exposure Time Fail!", nRet);
                }
                else
                {
                    exposure1 = stParam.fCurValue.ToString("F1");
                }
                //nRet = m_pMyCamera[1].MV_CAML
                nRet = m_pMyCamera[0].MV_CC_GetFloatValue_NET("Gain", ref stParam);
                if (MyCamera.MV_OK != nRet)
                {
                    ShowErrorMsg("Get Gain Fail!", nRet);
                }
                else
                {

                    gain1 = stParam.fCurValue.ToString("F1");
                }
            }
            else if (m_nCanOpenDevNum == 2)
            {
                int nRet = m_pMyCamera[0].MV_CC_GetFloatValue_NET("ExposureTime", ref stParam);
                if (MyCamera.MV_OK != nRet)
                {
                    ShowErrorMsg("Get Exposure Time Fail!", nRet);
                }
                else
                {
                    exposure1 = stParam.fCurValue.ToString("F1");
                }
                //nRet = m_pMyCamera[1].MV_CAML
                nRet = m_pMyCamera[0].MV_CC_GetFloatValue_NET("Gain", ref stParam);
                if (MyCamera.MV_OK != nRet)
                {
                    ShowErrorMsg("Get Gain Fail!", nRet);
                }
                else
                {

                    gain1 = stParam.fCurValue.ToString("F1");
                }
                nRet = m_pMyCamera[1].MV_CC_GetFloatValue_NET("ExposureTime", ref stParam);
                if (MyCamera.MV_OK != nRet)
                {
                    ShowErrorMsg("Get Exposure Time Fail!", nRet);
                }
                else
                {
                    exposure2 = stParam.fCurValue.ToString("F1");
                }

                nRet = m_pMyCamera[1].MV_CC_GetFloatValue_NET("Gain", ref stParam);
                if (MyCamera.MV_OK != nRet)
                {
                    ShowErrorMsg("Get Gain Fail!", nRet);
                }
                else
                {
                    gain2 = stParam.fCurValue.ToString("F1");
                }
            }




        }


        public void Set_par(string exposure1,string gain1,string exposure2,string gain2) 
        {
            try
            {
                if (m_nCanOpenDevNum == 1)
                {
                    float.Parse(exposure1);
                    float.Parse(gain1);
                }
                else if (m_nCanOpenDevNum == 2)
                {
                    float.Parse(exposure1);
                    float.Parse(gain1);
                    float.Parse(exposure2);
                    float.Parse(gain2);
                }

            }
            catch
            {
                ShowErrorMsg("Please enter correct type!", 0);
                return;
            }

            if (float.Parse(exposure1) < 0 || float.Parse(gain1) < 0)
            {
                ShowErrorMsg("Set ExposureTime or Gain fail,Because ExposureTime or Gain less than zero.\r\n", 0);
                return;
            }

            int nRet;
            bool bSuccess = true;
            void SetGainForCamera(MyCamera camera, float gain)
            {
                // 关闭自动增益（必需步骤）
                camera.MV_CC_SetEnumValue_NET("GainAuto", 0);
                
                // 设置增益值
                nRet = camera.MV_CC_SetFloatValue_NET("Gain", gain);
                if (nRet != MyCamera.MV_OK)
                {
                    ShowErrorMsg($"Set Gain Failed! nRet=0x{nRet:X8}\r\n", 0);
                    bSuccess = false;
                }
            }
            if (m_nCanOpenDevNum == 1)
            {

                m_pMyCamera[0].MV_CC_SetEnumValue_NET("ExposureAuto", 0);

                nRet = m_pMyCamera[0].MV_CC_SetFloatValue_NET("ExposureTime", float.Parse(exposure1));
                if (nRet != MyCamera.MV_OK)
                {
                    ShowErrorMsg("No.{0} Set Exposure Time Failed! nRet=0x{1}\r\n", nRet);
                    bSuccess = false;
                }
               
                WritePrivateProfileString("CameraSettings", "ExposureTime", exposure1, iniPath);
                //m_pMyCamera[0].MV_CC_SetEnumValue_NET("GainAuto", 0);

                //nRet = m_pMyCamera[0].MV_CC_SetFloatValue_NET("Gain", float.Parse(gain1));
                //if (nRet != MyCamera.MV_OK)
                //{
                //    ShowErrorMsg("No.{0} Set Gain Failed! nRet=0x{1}\r\n", nRet);
                //    bSuccess = false;
                //}

                //SetGainForCamera(m_pMyCamera[0], float.Parse(gain1));
            }
            else if (m_nCanOpenDevNum == 2)
            {

                m_pMyCamera[0].MV_CC_SetEnumValue_NET("ExposureAuto", 0);

                nRet = m_pMyCamera[0].MV_CC_SetFloatValue_NET("ExposureTime", float.Parse(exposure1));
                if (nRet != MyCamera.MV_OK)
                {
                    ShowErrorMsg("No.{0} Set Exposure Time Failed! nRet=0x{1}\r\n", nRet);
                    bSuccess = false;
                }
                m_pMyCamera[0].MV_CC_SetEnumValue_NET("GainAuto", 0);
                
                WritePrivateProfileString("CameraSettings", "ExposureTime1", exposure1, iniPath);
                //nRet = m_pMyCamera[0].MV_CC_SetFloatValue_NET("Gain", float.Parse(gain1));
                //if (nRet != MyCamera.MV_OK)
                //{
                //    ShowErrorMsg("No.{0} Set Gain Failed! nRet=0x{1}\r\n", nRet);
                //    bSuccess = false;
                //}
                m_pMyCamera[1].MV_CC_SetEnumValue_NET("ExposureAuto", 0);

                nRet = m_pMyCamera[1].MV_CC_SetFloatValue_NET("ExposureTime", float.Parse(exposure1));
                if (nRet != MyCamera.MV_OK)
                {
                    ShowErrorMsg("No.{0} Set Exposure Time Failed! nRet=0x{1}\r\n", nRet);
                    bSuccess = false;
                }
              
                WritePrivateProfileString("CameraSettings", "ExposureTime2", exposure2, iniPath);
                //m_pMyCamera[1].MV_CC_SetEnumValue_NET("GainAuto", 0);

                // nRet = m_pMyCamera[1].MV_CC_SetFloatValue_NET("Gain", float.Parse(gain2));
                // if (nRet != MyCamera.MV_OK)
                // {
                //     ShowErrorMsg("No.{0} Set Gain Failed! nRet=0x{1}\r\n", nRet);
                //     bSuccess = false;
                // }


            }


            if (bSuccess)
            {
                ShowErrorMsg("Set Parameters Succeed!\r\n", 0);
            }
        }

        public void savepng(string path)
        {
            string basePath = path;
            if (string.IsNullOrEmpty(basePath))
            {
                ShowErrorMsg("保存路径不能为空！", 0);
                return;
            }

            // 确保目录存在
            if (!Directory.Exists(basePath))
            {
                try
                {
                    Directory.CreateDirectory(basePath);
                }
                catch (Exception ex)
                {
                    ShowErrorMsg($"创建目录失败: {ex.Message}", 0);
                    return;
                }
            }

            DateTime timestamp = DateTime.Now;
            int nRet;
            for (int i = 0; i < m_nCanOpenDevNum; ++i)
            {
                MyCamera.MV_SAVE_IMG_TO_FILE_PARAM stSaveParam = new MyCamera.MV_SAVE_IMG_TO_FILE_PARAM();
                lock (m_BufForSaveImageLock[i])
                {
                    if (m_stFrameInfo[i].nFrameLen == 0)
                    {
                        ShowErrorMsg($"No.{i} save image failed! No data!\r\n", 0);
                        continue;
                    }
                    stSaveParam.enImageType = MyCamera.MV_SAVE_IAMGE_TYPE.MV_Image_Png;
                    stSaveParam.enPixelType = m_stFrameInfo[i].enPixelType;
                    stSaveParam.pData = m_pSaveImageBuf[i];
                    stSaveParam.nDataLen = m_stFrameInfo[i].nFrameLen;
                    stSaveParam.nHeight = m_stFrameInfo[i].nHeight;
                    stSaveParam.nWidth = m_stFrameInfo[i].nWidth;
                    stSaveParam.nQuality = 80;

                    // 生成唯一的带有时间戳的文件名
                    string timestampStr = timestamp.ToString("yyyyMMdd_HHmmssfff", CultureInfo.InvariantCulture);
                    string fileName = $"Dev{i}_Image_w{stSaveParam.nWidth}_h{stSaveParam.nHeight}_fn{m_stFrameInfo[i].nFrameNum}_{timestampStr}.png";
                    if (m_stFrameInfo[i].enPixelType == MyCamera.MvGvspPixelType.PixelType_Gvsp_RGB8_Packed)
                    {
                        // 转换Bayer格式到RGB
                        MyCamera.MV_PIXEL_CONVERT_PARAM stConvertParam = new MyCamera.MV_PIXEL_CONVERT_PARAM();
                        stConvertParam.nWidth = m_stFrameInfo[i].nWidth;
                        stConvertParam.nHeight = m_stFrameInfo[i].nHeight;
                        stConvertParam.pSrcData = m_pSaveImageBuf[i];
                        stConvertParam.nSrcDataLen = m_stFrameInfo[i].nFrameLen;
                        stConvertParam.enSrcPixelType = m_stFrameInfo[i].enPixelType;
                        stConvertParam.enDstPixelType = MyCamera.MvGvspPixelType.PixelType_Gvsp_RGB8_Packed;
                        stConvertParam.pDstBuffer = Marshal.AllocHGlobal(m_stFrameInfo[i].nWidth * m_stFrameInfo[i].nHeight * 3);
                        stConvertParam.nDstBufferSize = (uint)(m_stFrameInfo[i].nWidth * m_stFrameInfo[i].nHeight * 3);

                        nRet = m_pMyCamera[i].MV_CC_ConvertPixelType_NET(ref stConvertParam);
                        if (MyCamera.MV_OK == nRet)
                        {
                            stSaveParam.pData = stConvertParam.pDstBuffer;
                            stSaveParam.nDataLen = (uint)(m_stFrameInfo[i].nWidth * m_stFrameInfo[i].nHeight * 3);
                            stSaveParam.enPixelType = MyCamera.MvGvspPixelType.PixelType_Gvsp_RGB8_Packed;
                        }
                        // 保存后释放内存
                        Marshal.FreeHGlobal(stConvertParam.pDstBuffer);
                    }
                    // 使用Path.Combine构建完整路径
                    stSaveParam.pImagePath = Path.Combine(basePath, fileName);

                    nRet = m_pMyCamera[i].MV_CC_SaveImageToFile_NET(ref stSaveParam);
                    if (MyCamera.MV_OK != nRet)
                    {
                        ShowErrorMsg($"No.{i} save image failed! nRet=0x{nRet:X8}\r\n", 0);
                    }
                    else
                    {
                        ShowErrorMsg($"No.{i} save bmp image succeeded! File: {stSaveParam.pImagePath}\r\n", 0);
                    }
                }

            }
        }
        public void savejpg(string path, string[] FileName)
        {
            string basePath =path;
            if (string.IsNullOrEmpty(basePath))
            {
                ShowErrorMsg("保存路径不能为空！", 0);
                return;
            }

            // 确保目录存在
            if (!Directory.Exists(basePath))
            {
                try
                {
                    Directory.CreateDirectory(basePath);
                }
                catch (Exception ex)
                {
                    ShowErrorMsg($"创建目录失败: {ex.Message}", 0);
                    return;
                }
            }

            DateTime timestamp = DateTime.Now;

            for (int i = 0; i < m_nCanOpenDevNum; ++i)
            {
                int nRet;
                MyCamera.MV_SAVE_IMG_TO_FILE_PARAM stSaveParam = new MyCamera.MV_SAVE_IMG_TO_FILE_PARAM();
                lock (m_BufForSaveImageLock[i])
                {
                    if (m_stFrameInfo[i].nFrameLen == 0)
                    {
                        ShowErrorMsg($"No.{i} save image failed! No data!\r\n", 0);
                        continue;
                    }

                    stSaveParam.enImageType = MyCamera.MV_SAVE_IAMGE_TYPE.MV_Image_Bmp;
                    stSaveParam.enPixelType = m_stFrameInfo[i].enPixelType;
                    stSaveParam.pData = m_pSaveImageBuf[i];
                    stSaveParam.nDataLen = m_stFrameInfo[i].nFrameLen;
                    stSaveParam.nHeight = m_stFrameInfo[i].nHeight;
                    stSaveParam.nWidth = m_stFrameInfo[i].nWidth;
                    //stSaveParam.iMethodValue = 90;
                    if (m_stFrameInfo[i].enPixelType == MyCamera.MvGvspPixelType.PixelType_Gvsp_RGB8_Packed)
                    {
                        // 转换Bayer格式到RGB
                        MyCamera.MV_PIXEL_CONVERT_PARAM stConvertParam = new MyCamera.MV_PIXEL_CONVERT_PARAM();
                        stConvertParam.nWidth = m_stFrameInfo[i].nWidth;
                        stConvertParam.nHeight = m_stFrameInfo[i].nHeight;
                        stConvertParam.pSrcData = m_pSaveImageBuf[i];
                        stConvertParam.nSrcDataLen = m_stFrameInfo[i].nFrameLen;
                        stConvertParam.enSrcPixelType = m_stFrameInfo[i].enPixelType;
                        stConvertParam.enDstPixelType = MyCamera.MvGvspPixelType.PixelType_Gvsp_RGB8_Packed;
                        stConvertParam.pDstBuffer = Marshal.AllocHGlobal(m_stFrameInfo[i].nWidth * m_stFrameInfo[i].nHeight * 3);
                        stConvertParam.nDstBufferSize = (uint)(m_stFrameInfo[i].nWidth * m_stFrameInfo[i].nHeight * 3);

                        nRet = m_pMyCamera[i].MV_CC_ConvertPixelType_NET(ref stConvertParam);
                        if (MyCamera.MV_OK == nRet)
                        {
                            stSaveParam.pData = stConvertParam.pDstBuffer;
                            stSaveParam.nDataLen = (uint)(m_stFrameInfo[i].nWidth * m_stFrameInfo[i].nHeight * 3);
                            stSaveParam.enPixelType = MyCamera.MvGvspPixelType.PixelType_Gvsp_RGB8_Packed;
                        }
                        // 保存后释放内存
                        Marshal.FreeHGlobal(stConvertParam.pDstBuffer);
                    }
                    // 生成唯一的带有时间戳的文件名
                    string timestampStr = timestamp.ToString("yyyyMMdd_HHmmssfff", CultureInfo.InvariantCulture);
                    //string fileName = $"Dev{i}_Image_w{stSaveParam.nWidth}_h{stSaveParam.nHeight}_fn{m_stFrameInfo[i].nFrameNum}_{timestampStr}.jpg";

                    string DataId = DateTime.Now.ToString("yyyyMMddHHmmss") + (0).ToString("00");
                    string DataName = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "-" + (0).ToString("00");
                    // 使用Path.Combine构建完整路径
                    stSaveParam.pImagePath = Path.Combine(basePath, FileName[i]);

                     nRet = m_pMyCamera[i].MV_CC_SaveImageToFile_NET(ref stSaveParam);
                    if (MyCamera.MV_OK != nRet)
                    {
                        ShowErrorMsg($"No.{i} save image failed! nRet=0x{nRet:X8}\r\n", 0);
                    }
                    else
                    {
                      //  ShowErrorMsg($"No.{i} save bmp image succeeded! File: {stSaveParam.pImagePath}\r\n", 0);
                    }
                }
            }





        }

        public void SaveImage(string path) 
        {
            string basePath = path;
            if (string.IsNullOrEmpty(basePath))
            {
                ShowErrorMsg("保存路径不能为空！", 0);
                return;
            }

            // 确保目录存在
            if (!Directory.Exists(basePath))
            {
                try
                {
                    Directory.CreateDirectory(basePath);
                }
                catch (Exception ex)
                {
                    ShowErrorMsg($"创建目录失败: {ex.Message}", 0);
                    return;
                }
            }

            DateTime timestamp = DateTime.Now;
            int nRet;
            for (int i = 0; i < m_nCanOpenDevNum; ++i)
            {
                MyCamera.MV_SAVE_IMG_TO_FILE_PARAM stSaveParam = new MyCamera.MV_SAVE_IMG_TO_FILE_PARAM();
                lock (m_BufForSaveImageLock[i])
                {
                    if (m_stFrameInfo[i].nFrameLen == 0)
                    {
                        ShowErrorMsg($"No.{i} save image failed! No data!\r\n", 0);
                        continue;
                    }

                    stSaveParam.enImageType = MyCamera.MV_SAVE_IAMGE_TYPE.MV_Image_Bmp;
                    stSaveParam.enPixelType = m_stFrameInfo[i].enPixelType;
                    stSaveParam.pData = m_pSaveImageBuf[i];
                    stSaveParam.nDataLen = m_stFrameInfo[i].nFrameLen;
                    stSaveParam.nHeight = m_stFrameInfo[i].nHeight;
                    stSaveParam.nWidth = m_stFrameInfo[i].nWidth;
                    //stSaveParam.iMethodValue = 90;

                    // 生成唯一的带有时间戳的文件名
                    // string timestampStr = timestamp.ToString("yyyyMMdd_HHmmssfff", CultureInfo.InvariantCulture);
                    //string fileName = $"Dev{i}_Image_w{stSaveParam.nWidth}_h{stSaveParam.nHeight}_fn{m_stFrameInfo[i].nFrameNum}_{timestampStr}.jpg";
                    if (m_stFrameInfo[i].enPixelType == MyCamera.MvGvspPixelType.PixelType_Gvsp_RGB8_Packed)
                    {
                        // 转换Bayer格式到RGB
                        MyCamera.MV_PIXEL_CONVERT_PARAM stConvertParam = new MyCamera.MV_PIXEL_CONVERT_PARAM();
                        stConvertParam.nWidth = m_stFrameInfo[i].nWidth;
                        stConvertParam.nHeight = m_stFrameInfo[i].nHeight;
                        stConvertParam.pSrcData = m_pSaveImageBuf[i];
                        stConvertParam.nSrcDataLen = m_stFrameInfo[i].nFrameLen;
                        stConvertParam.enSrcPixelType = m_stFrameInfo[i].enPixelType;
                        stConvertParam.enDstPixelType = MyCamera.MvGvspPixelType.PixelType_Gvsp_RGB8_Packed;
                        stConvertParam.pDstBuffer = Marshal.AllocHGlobal(m_stFrameInfo[i].nWidth * m_stFrameInfo[i].nHeight * 3);
                        stConvertParam.nDstBufferSize = (uint)(m_stFrameInfo[i].nWidth * m_stFrameInfo[i].nHeight * 3);

                        nRet = m_pMyCamera[i].MV_CC_ConvertPixelType_NET(ref stConvertParam);
                        if (MyCamera.MV_OK == nRet)
                        {
                            stSaveParam.pData = stConvertParam.pDstBuffer;
                            stSaveParam.nDataLen = (uint)(m_stFrameInfo[i].nWidth * m_stFrameInfo[i].nHeight * 3);
                            stSaveParam.enPixelType = MyCamera.MvGvspPixelType.PixelType_Gvsp_RGB8_Packed;
                        }
                        // 保存后释放内存
                        Marshal.FreeHGlobal(stConvertParam.pDstBuffer);
                    }
                    string DataId = DateTime.Now.ToString("yyyyMMddHHmmss") + (i).ToString("00");
                    string DataName = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "-" + (i).ToString("00");
                    string fileName = DataName + ".jpg";
                    // 使用Path.Combine构建完整路径
                    stSaveParam.pImagePath = Path.Combine(basePath, fileName);
                    CreatExcel.InterData(DataAcquisition.interExcelFile, i.ToString(), "0", "rgb", DataId, DataName);
                     nRet = m_pMyCamera[i].MV_CC_SaveImageToFile_NET(ref stSaveParam);
                    if (MyCamera.MV_OK != nRet)
                    {
                        ShowErrorMsg($"No.{i} save image failed! nRet=0x{nRet:X8}\r\n", 0);
                    }
                    else
                    {
                        Form1.ProgramChecking = "save RGB image succeded!";
                        //ShowErrorMsg($"No.{i} save bmp image succeeded! File: {stSaveParam.pImagePath}\r\n", 0);
                    }
                }
            }


        }
        public void savetiff(string path)
        {
            string basePath = path;
            if (string.IsNullOrEmpty(basePath))
            {
                ShowErrorMsg("保存路径不能为空！", 0);
                return;
            }

            // 确保目录存在
            if (!Directory.Exists(basePath))
            {
                try
                {
                    Directory.CreateDirectory(basePath);
                }
                catch (Exception ex)
                {
                    ShowErrorMsg($"创建目录失败: {ex.Message}", 0);
                    return;
                }
            }

            DateTime timestamp = DateTime.Now;
            int nRet;
            for (int i = 0; i < m_nCanOpenDevNum; ++i)
            {
                MyCamera.MV_SAVE_IMG_TO_FILE_PARAM stSaveParam = new MyCamera.MV_SAVE_IMG_TO_FILE_PARAM();
                lock (m_BufForSaveImageLock[i])
                {
                    if (m_stFrameInfo[i].nFrameLen == 0)
                    {
                        ShowErrorMsg($"No.{i} save image failed! No data!\r\n", 0);
                        continue;
                    }
                    stSaveParam.enImageType = MyCamera.MV_SAVE_IAMGE_TYPE.MV_Image_Tif;
                    stSaveParam.enPixelType = m_stFrameInfo[i].enPixelType;
                    stSaveParam.pData = m_pSaveImageBuf[i];
                    stSaveParam.nDataLen = m_stFrameInfo[i].nFrameLen;
                    stSaveParam.nHeight = m_stFrameInfo[i].nHeight;
                    stSaveParam.nWidth = m_stFrameInfo[i].nWidth;
                    if (m_stFrameInfo[i].enPixelType == MyCamera.MvGvspPixelType.PixelType_Gvsp_RGB8_Packed)
                    {
                        // 转换Bayer格式到RGB
                        MyCamera.MV_PIXEL_CONVERT_PARAM stConvertParam = new MyCamera.MV_PIXEL_CONVERT_PARAM();
                        stConvertParam.nWidth = m_stFrameInfo[i].nWidth;
                        stConvertParam.nHeight = m_stFrameInfo[i].nHeight;
                        stConvertParam.pSrcData = m_pSaveImageBuf[i];
                        stConvertParam.nSrcDataLen = m_stFrameInfo[i].nFrameLen;
                        stConvertParam.enSrcPixelType = m_stFrameInfo[i].enPixelType;
                        stConvertParam.enDstPixelType = MyCamera.MvGvspPixelType.PixelType_Gvsp_RGB8_Packed;
                        stConvertParam.pDstBuffer = Marshal.AllocHGlobal(m_stFrameInfo[i].nWidth * m_stFrameInfo[i].nHeight * 3);
                        stConvertParam.nDstBufferSize = (uint)(m_stFrameInfo[i].nWidth * m_stFrameInfo[i].nHeight * 3);

                        nRet = m_pMyCamera[i].MV_CC_ConvertPixelType_NET(ref stConvertParam);
                        if (MyCamera.MV_OK == nRet)
                        {
                            stSaveParam.pData = stConvertParam.pDstBuffer;
                            stSaveParam.nDataLen = (uint)(m_stFrameInfo[i].nWidth * m_stFrameInfo[i].nHeight * 3);
                            stSaveParam.enPixelType = MyCamera.MvGvspPixelType.PixelType_Gvsp_RGB8_Packed;
                        }
                        // 保存后释放内存
                        Marshal.FreeHGlobal(stConvertParam.pDstBuffer);
                    }
                    //stSaveParam.iMethodValue = 90;
                    // 生成唯一的带有时间戳的文件名
                    string timestampStr = timestamp.ToString("yyyyMMdd_HHmmssfff", CultureInfo.InvariantCulture);
                    string fileName = $"Dev{i}_Image_w{stSaveParam.nWidth}_h{stSaveParam.nHeight}_fn{m_stFrameInfo[i].nFrameNum}_{timestampStr}.tiff";

                    // 使用Path.Combine构建完整路径
                    stSaveParam.pImagePath = Path.Combine(basePath, fileName);

                     nRet = m_pMyCamera[i].MV_CC_SaveImageToFile_NET(ref stSaveParam);
                    if (MyCamera.MV_OK != nRet)
                    {
                        ShowErrorMsg($"No.{i} save image failed! nRet=0x{nRet:X8}\r\n", 0);
                    }
                    else
                    {
                        ShowErrorMsg($"No.{i} save bmp image succeeded! File: {stSaveParam.pImagePath}\r\n", 0);
                    }
                }
            }


        }
        public void savebmp(string path)
        {
            // 从文本框获取并验证路径
            string basePath = path;
            if (string.IsNullOrEmpty(basePath))
            {
                ShowErrorMsg("保存路径不能为空！", 0);
                return;
            }

            // 确保目录存在
            if (!Directory.Exists(basePath))
            {
                try
                {
                    Directory.CreateDirectory(basePath);
                }
                catch (Exception ex)
                {
                    ShowErrorMsg($"创建目录失败: {ex.Message}", 0);
                    return;
                }
            }
          
            DateTime timestamp = DateTime.Now;

            for (int i = 0; i < m_nCanOpenDevNum; ++i)
            {

                MyCamera.MV_SAVE_IMG_TO_FILE_PARAM stSaveParam = new MyCamera.MV_SAVE_IMG_TO_FILE_PARAM();
                MyCamera.MV_PIXEL_CONVERT_PARAM stConvertInfo = new MyCamera.MV_PIXEL_CONVERT_PARAM();
                lock (m_BufForSaveImageLock[i])
                {
                    if (m_stFrameInfo[i].nFrameLen == 0)
                    {
                        ShowErrorMsg($"No.{i} save image failed! No data!\r\n", 0);
                        continue;
                    }

                    

                    stSaveParam.enImageType = MyCamera.MV_SAVE_IAMGE_TYPE.MV_Image_Bmp;
                    stSaveParam.enPixelType = m_stFrameInfo[i].enPixelType;
                    stSaveParam.pData = m_pSaveImageBuf[i];
                    stSaveParam.nDataLen = m_stFrameInfo[i].nFrameLen;
                    stSaveParam.nHeight = m_stFrameInfo[i].nHeight;
                    stSaveParam.nWidth = m_stFrameInfo[i].nWidth;



                    int nRet;
                    // 在设置保存参数前添加转换
                    if (m_stFrameInfo[i].enPixelType == MyCamera.MvGvspPixelType.PixelType_Gvsp_RGB8_Packed)
                    {
                        // 转换Bayer格式到RGB
                        MyCamera.MV_PIXEL_CONVERT_PARAM stConvertParam = new MyCamera.MV_PIXEL_CONVERT_PARAM();
                        stConvertParam.nWidth = m_stFrameInfo[i].nWidth;
                        stConvertParam.nHeight = m_stFrameInfo[i].nHeight;
                        stConvertParam.pSrcData = m_pSaveImageBuf[i];
                        stConvertParam.nSrcDataLen = m_stFrameInfo[i].nFrameLen;
                        stConvertParam.enSrcPixelType = m_stFrameInfo[i].enPixelType;
                        stConvertParam.enDstPixelType = MyCamera.MvGvspPixelType.PixelType_Gvsp_RGB8_Packed;
                        stConvertParam.pDstBuffer = Marshal.AllocHGlobal(m_stFrameInfo[i].nWidth * m_stFrameInfo[i].nHeight * 3);
                        stConvertParam.nDstBufferSize = (uint)(m_stFrameInfo[i].nWidth * m_stFrameInfo[i].nHeight * 3);

                         nRet = m_pMyCamera[i].MV_CC_ConvertPixelType_NET(ref stConvertParam);
                        if (MyCamera.MV_OK == nRet)
                        {
                            stSaveParam.pData = stConvertParam.pDstBuffer;
                            stSaveParam.nDataLen = (uint)(m_stFrameInfo[i].nWidth * m_stFrameInfo[i].nHeight * 3);
                            stSaveParam.enPixelType = MyCamera.MvGvspPixelType.PixelType_Gvsp_RGB8_Packed;
                        }
                        // 保存后释放内存
                        Marshal.FreeHGlobal(stConvertParam.pDstBuffer);
                    }

                    // 生成唯一的带有时间戳的文件名
                    string timestampStr = timestamp.ToString("yyyyMMdd_HHmmssfff", CultureInfo.InvariantCulture);

                    string fileName = $"Image_w{stSaveParam.nWidth}_h{stSaveParam.nHeight}_fn{m_stFrameInfo[i].nFrameNum}_{timestampStr}_Dev{i}.bmp";

                 
                    // 使用Path.Combine构建完整路径
                    stSaveParam.pImagePath = Path.Combine(basePath, fileName);
                  
                     nRet = m_pMyCamera[i].MV_CC_SaveImageToFile_NET(ref stSaveParam);
                    if (MyCamera.MV_OK != nRet)
                    {
                        ShowErrorMsg($"No.{i} save image failed! nRet=0x{nRet:X8}\r\n", 0);
                    }
                    else
                    {
                       // ShowErrorMsg($"No.{i} save bmp image succeeded! File: {stSaveParam.pImagePath}\r\n", 0);
                    }

                    //GC.Collect();
                }
            }
        }
        public void ShowErrorMsg(string csMessage, int nErrorNum)
        {
            string errorMsg;
            if (nErrorNum == (int)Mv3dRgbdSDK.MV3D_RGBD_OK)
            {
                errorMsg = csMessage;
            }
            else
            {
                errorMsg = csMessage + ": Error =" + String.Format("{0:X}", nErrorNum);
            }
            uint nErrNum = (uint)nErrorNum;
            switch (nErrNum)
            {
                case Mv3dRgbdSDK.MV3D_RGBD_E_HANDLE: errorMsg += " Error or invalid handle "; break;
                case Mv3dRgbdSDK.MV3D_RGBD_E_SUPPORT: errorMsg += " Not supported function "; break;
                case Mv3dRgbdSDK.MV3D_RGBD_E_BUFOVER: errorMsg += " Cache is full "; break;
                case Mv3dRgbdSDK.MV3D_RGBD_E_CALLORDER: errorMsg += " Function calling order error "; break;
                case Mv3dRgbdSDK.MV3D_RGBD_E_PARAMETER: errorMsg += " Incorrect parameter "; break;
                case Mv3dRgbdSDK.MV3D_RGBD_E_RESOURCE: errorMsg += " Applying resource failed "; break;
                case Mv3dRgbdSDK.MV3D_RGBD_E_NODATA: errorMsg += " No data "; break;
                case Mv3dRgbdSDK.MV3D_RGBD_E_PRECONDITION: errorMsg += " Precondition error, or running environment changed "; break;
                case Mv3dRgbdSDK.MV3D_RGBD_E_VERSION: errorMsg += " Version mismatches "; break;
                case Mv3dRgbdSDK.MV3D_RGBD_E_NOENOUGH_BUF: errorMsg += " Insufficient memory "; break;
                case Mv3dRgbdSDK.MV3D_RGBD_E_ABNORMAL_IMAGE: errorMsg += " error image "; break;
                case Mv3dRgbdSDK.MV3D_RGBD_E_LOAD_LIBRARY: errorMsg += " load dll  error "; break;
                case Mv3dRgbdSDK.MV3D_RGBD_E_UNKNOW: errorMsg += " Unknown error "; break;
            }

            
            MessageBox.Show(errorMsg, "PROMPT");
        }



        public  void bnTriggerExec()
        {
            int nRet;

            for (int i = 0; i < m_nCanOpenDevNum; ++i)
            {
                m_pMyCamera[i].MV_CC_SetEnumValue_NET("TriggerSource", (uint)MyCamera.MV_CAM_TRIGGER_SOURCE.MV_TRIGGER_SOURCE_SOFTWARE);

                nRet = m_pMyCamera[i].MV_CC_SetCommandValue_NET("TriggerSoftware");
                if (MyCamera.MV_OK != nRet)
                {
                    //richTextBox.Text += String.Format("No.{0} Set software trigger failed! nRet=0x{1}\r\n", (i + 1).ToString(), nRet.ToString("X"));
                }
                Thread.Sleep(500);
            }
        }

    }
}
