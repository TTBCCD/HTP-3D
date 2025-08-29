using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MvCamCtrl.NET;
using System.Windows.Forms;
using OpenCvSharp.Dnn;
using Basler.Pylon;
using static MvCamCtrl.NET.MyCamera;


namespace Canondemo
{
    public partial class MVS
    {

        //工业相机
        [DllImport("kernel32.dll", EntryPoint = "CopyMemory", SetLastError = false)]
        public static extern void CopyMemory(IntPtr dest, IntPtr src, uint count);

        // ch:判断用户自定义像素格式 | en:Determine custom pixel format
        public const Int32 CUSTOMER_PIXEL_FORMAT = unchecked((Int32)0x80000000);

        MyCamera.MV_CC_DEVICE_INFO_LIST m_stDeviceList = new MyCamera.MV_CC_DEVICE_INFO_LIST();
        public MyCamera m_MyCamera = new MyCamera();
        bool m_bGrabbing = false;
        Thread m_hReceiveThread = null;
        MyCamera.MV_FRAME_OUT_INFO_EX m_stFrameInfo = new MyCamera.MV_FRAME_OUT_INFO_EX();

        // ch:用于从驱动获取图像的缓存 | en:Buffer for getting image from driver
        UInt32 m_nBufSizeForDriver = 0;
        IntPtr m_BufForDriver = IntPtr.Zero;
        private static Object BufForDriverLock = new Object();

        // ch:Bitmap及其像素格式 | en:Bitmap and Pixel Format
        Bitmap m_bitmap = null;
        PixelFormat m_bitmapPixelFormat = PixelFormat.DontCare;
        IntPtr m_ConvertDstBuf = IntPtr.Zero;
        UInt32 m_nConvertDstBufLen = 0;
        PictureBox pictureBox1;
        MyCamera.MVCC_ENUMVALUE stPixelFormat;

        public MVS(ComboBox comboBox)
        {
            DeviceListAcq(comboBox);
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        public  void DeviceListAcq(ComboBox comboBox)// 查找相机
        {
            // ch:创建设备列表 | en:Create Device List
            System.GC.Collect();
            comboBox.Items.Clear();
            m_stDeviceList.nDeviceNum = 0;

            int nRet = MyCamera.MV_CC_EnumDevices_NET(MyCamera.MV_GIGE_DEVICE | MyCamera.MV_USB_DEVICE, ref m_stDeviceList);
            if (0 != nRet)
            {
                ShowErrorMsg("Enumerate devices fail!", 0);
                return;
            }

            // ch:在窗体列表中显示设备名 | en:Display device name in the form list
            for (int i = 0; i < m_stDeviceList.nDeviceNum; i++)
            {
                MyCamera.MV_CC_DEVICE_INFO device = (MyCamera.MV_CC_DEVICE_INFO)Marshal.PtrToStructure(m_stDeviceList.pDeviceInfo[i], typeof(MyCamera.MV_CC_DEVICE_INFO));
                if (device.nTLayerType == MyCamera.MV_GIGE_DEVICE)
                {
                    MyCamera.MV_GIGE_DEVICE_INFO gigeInfo = (MyCamera.MV_GIGE_DEVICE_INFO)MyCamera.ByteToStruct(device.SpecialInfo.stGigEInfo, typeof(MyCamera.MV_GIGE_DEVICE_INFO));

                    if (gigeInfo.chUserDefinedName != "")
                    {
                        comboBox.Items.Add("GEV: " + gigeInfo.chUserDefinedName + " (" + gigeInfo.chSerialNumber + ")");
                    }
                    else
                    {
                        comboBox.Items.Add("GEV: " + gigeInfo.chManufacturerName + " " + gigeInfo.chModelName + " (" + gigeInfo.chSerialNumber + ")");
                    }
                }
                else if (device.nTLayerType == MyCamera.MV_USB_DEVICE)
                {
                    MyCamera.MV_USB3_DEVICE_INFO usbInfo = (MyCamera.MV_USB3_DEVICE_INFO)MyCamera.ByteToStruct(device.SpecialInfo.stUsb3VInfo, typeof(MyCamera.MV_USB3_DEVICE_INFO));
                    if (usbInfo.chUserDefinedName != "")
                    {
                        comboBox.Items.Add("U3V: " + usbInfo.chUserDefinedName + " (" + usbInfo.chSerialNumber + ")");
                    }
                    else
                    {
                        comboBox.Items.Add("U3V: " + usbInfo.chManufacturerName + " " + usbInfo.chModelName + " (" + usbInfo.chSerialNumber + ")");
                    }
                }
            }

            // ch:选择第一项 | en:Select the first item
            if (m_stDeviceList.nDeviceNum != 0)
            {
                comboBox.SelectedIndex = 0;
            }
        }
        private void ShowErrorMsg(string csMessage, int nErrorNum)//错误信息显示
        {
            string errorMsg;
            if (nErrorNum == 0)
            {
                errorMsg = csMessage;
            }
            else
            {
                errorMsg = csMessage + ": Error =" + String.Format("{0:X}", nErrorNum);
            }

            switch (nErrorNum)
            {
                case MyCamera.MV_E_HANDLE: errorMsg += " Error or invalid handle "; break;
                case MyCamera.MV_E_SUPPORT: errorMsg += " Not supported function "; break;
                case MyCamera.MV_E_BUFOVER: errorMsg += " Cache is full "; break;
                case MyCamera.MV_E_CALLORDER: errorMsg += " Function calling order error "; break;
                case MyCamera.MV_E_PARAMETER: errorMsg += " Incorrect parameter "; break;
                case MyCamera.MV_E_RESOURCE: errorMsg += " Applying resource failed "; break;
                case MyCamera.MV_E_NODATA: errorMsg += " No data "; break;
                case MyCamera.MV_E_PRECONDITION: errorMsg += " Precondition error, or running environment changed "; break;
                case MyCamera.MV_E_VERSION: errorMsg += " Version mismatches "; break;
                case MyCamera.MV_E_NOENOUGH_BUF: errorMsg += " Insufficient memory "; break;
                case MyCamera.MV_E_UNKNOW: errorMsg += " Unknown error "; break;
                case MyCamera.MV_E_GC_GENERIC: errorMsg += " General error "; break;
                case MyCamera.MV_E_GC_ACCESS: errorMsg += " Node accessing condition error "; break;
                case MyCamera.MV_E_ACCESS_DENIED: errorMsg += " No permission "; break;
                case MyCamera.MV_E_BUSY: errorMsg += " Device is busy, or network disconnected "; break;
                case MyCamera.MV_E_NETER: errorMsg += " Network error "; break;
            }

            MessageBox.Show(errorMsg, "PROMPT");
        }
        public void Open_cbDevice(int ID)//打开相机
        {
            if (m_stDeviceList.nDeviceNum == 0 || ID ==-1)
            {
                ShowErrorMsg("No device, please select", 0);
                return;
            }

            // ch:获取选择的设备信息 | en:Get selected device information
            MyCamera.MV_CC_DEVICE_INFO device =
                (MyCamera.MV_CC_DEVICE_INFO)Marshal.PtrToStructure(m_stDeviceList.pDeviceInfo[ID],
                                                              typeof(MyCamera.MV_CC_DEVICE_INFO));

            // ch:打开设备 | en:Open device
            if (null == m_MyCamera)
            {
                m_MyCamera = new MyCamera();
                if (null == m_MyCamera)
                {
                    ShowErrorMsg("Applying resource fail!", MyCamera.MV_E_RESOURCE);
                    return;
                }
            }

            int nRet = m_MyCamera.MV_CC_CreateDevice_NET(ref device);
            if (MyCamera.MV_OK != nRet)
            {
                ShowErrorMsg("Create device fail!", nRet);
                return;
            }

            nRet = m_MyCamera.MV_CC_OpenDevice_NET();
            if (MyCamera.MV_OK != nRet)
            {
                m_MyCamera.MV_CC_DestroyDevice_NET();
                ShowErrorMsg("Device open fail!", nRet);
                return;
            }

            // ch:探测网络最佳包大小(只对GigE相机有效) | en:Detection network optimal package size(It only works for the GigE camera)
            if (device.nTLayerType == MyCamera.MV_GIGE_DEVICE)
            {
                int nPacketSize = m_MyCamera.MV_CC_GetOptimalPacketSize_NET();
                if (nPacketSize > 0)
                {
                    nRet = m_MyCamera.MV_CC_SetIntValueEx_NET("GevSCPSPacketSize", nPacketSize);
                    if (nRet != MyCamera.MV_OK)
                    {
                        ShowErrorMsg("Set Packet Size failed!", nRet);
                    }
                }
                else
                {
                    ShowErrorMsg("Get Packet Size failed!", nPacketSize);
                }
            }
        }
        public void Close_cbDevice()//关闭相机
        {
            // ch:取流标志位清零 | en:Reset flow flag bit
            if (m_bGrabbing == true)
            {
                m_bGrabbing = false;
                m_hReceiveThread.Join();
            }

            if (m_BufForDriver != IntPtr.Zero)
            {
                Marshal.Release(m_BufForDriver);
            }

            // ch:关闭设备 | en:Close Device
            m_MyCamera.MV_CC_CloseDevice_NET();
            m_MyCamera.MV_CC_DestroyDevice_NET();

            // ch:控件操作 | en:Control Operation
           // SetCtrlWhenClose();
        }
        public void bnContinuesMode(bool Mode)//连续触发//Continues
        {
            if (Mode)
            {
                // ch:打开触发模式 | en:Open Trigger Mode
                m_MyCamera.MV_CC_SetEnumValue_NET("TriggerMode", (uint)MyCamera.MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_ON);
            }
            else 
            {
                m_MyCamera.MV_CC_SetEnumValue_NET("TriggerMode", (uint)MyCamera.MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_OFF);
            }
        }

        public void bnTriggerSource(String source) //触发源信号设置
        {
            // ch:触发源选择:0 - Line0; | en:Trigger source select:0 - Line0;
            //           1 - Line1;
            //           2 - Line2;
            //           3 - Line3;
            //           4 - Counter;
            //           7 - Software;
            int sourceID = 7;
            switch (source)
            {
                case "0-Line0":
                    sourceID = 0;
                    break;
                case "1-Line1":
                    sourceID = 1;
                    break;
                case "2-Line2":
                    sourceID = 2;
                    break;
                case "3-Line3":
                    sourceID = 3;
                    break;
                case "4-Counter":
                    sourceID = 4;
                    break;
                case "7-Software":
                    sourceID = 7;
                    break;

            }
            m_MyCamera.MV_CC_SetEnumValue_NET("TriggerSource", (uint)sourceID);//(uint)MyCamera.MV_CAM_TRIGGER_SOURCE.MV_TRIGGER_SOURCE_SOFTWARE
        }

        public void bnTriggerExec()//软触发一次
        {
            // ch:触发命令 | en:Trigger command
            int nRet = m_MyCamera.MV_CC_SetCommandValue_NET("TriggerSoftware");
            if (MyCamera.MV_OK != nRet)
            {
                ShowErrorMsg("Trigger Software Fail!", nRet);
            }
        }
        // ch:像素类型是否为Mono格式 | en:If Pixel Type is Mono 
        private Boolean IsMono(UInt32 enPixelType)
        {
            switch (enPixelType)
            {
                case (UInt32)MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono1p:
                case (UInt32)MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono2p:
                case (UInt32)MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono4p:
                case (UInt32)MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono8:
                case (UInt32)MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono8_Signed:
                case (UInt32)MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono10:
                case (UInt32)MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono10_Packed:
                case (UInt32)MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono12:
                case (UInt32)MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono12_Packed:
                case (UInt32)MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono14:
                case (UInt32)MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono16:
                    return true;
                default:
                    return false;
            }
        }

        // ch:取图前的必要操作步骤 | en:Necessary operation before grab
        public Int32 NecessaryOperBeforeGrab()
        {
            // ch:取图像宽 | en:Get Iamge Width
            MyCamera.MVCC_INTVALUE_EX stWidth = new MyCamera.MVCC_INTVALUE_EX();
            int nRet = m_MyCamera.MV_CC_GetIntValueEx_NET("Width", ref stWidth);
            if (MyCamera.MV_OK != nRet)
            {
                ShowErrorMsg("Get Width Info Fail!", nRet);
                return nRet;
            }
            // ch:取图像高 | en:Get Iamge Height
            MyCamera.MVCC_INTVALUE_EX stHeight = new MyCamera.MVCC_INTVALUE_EX();
            nRet = m_MyCamera.MV_CC_GetIntValueEx_NET("Height", ref stHeight);
            if (MyCamera.MV_OK != nRet)
            {
                ShowErrorMsg("Get Height Info Fail!", nRet);
                return nRet;
            }
            // ch:取像素格式 | en:Get Pixel Format
            stPixelFormat = new MyCamera.MVCC_ENUMVALUE();
            nRet = m_MyCamera.MV_CC_GetEnumValue_NET("PixelFormat", ref stPixelFormat);
            if (MyCamera.MV_OK != nRet)
            {
                ShowErrorMsg("Get Pixel Format Fail!", nRet);
                return nRet;
            }

            // ch:设置bitmap像素格式，申请相应大小内存 | en:Set Bitmap Pixel Format, alloc memory
            if ((Int32)MyCamera.MvGvspPixelType.PixelType_Gvsp_Undefined == stPixelFormat.nCurValue)
            {
                ShowErrorMsg("Unknown Pixel Format!", MyCamera.MV_E_UNKNOW);
                return MyCamera.MV_E_UNKNOW;
            }
            else if (IsMono(stPixelFormat.nCurValue))
            {
                m_bitmapPixelFormat = PixelFormat.Format8bppIndexed;

                if (IntPtr.Zero != m_ConvertDstBuf)
                {
                    Marshal.Release(m_ConvertDstBuf);
                    m_ConvertDstBuf = IntPtr.Zero;
                }

                // Mono8为单通道
                m_nConvertDstBufLen = (UInt32)(stWidth.nCurValue * stHeight.nCurValue);
                m_ConvertDstBuf = Marshal.AllocHGlobal((Int32)m_nConvertDstBufLen);
                if (IntPtr.Zero == m_ConvertDstBuf)
                {
                    ShowErrorMsg("Malloc Memory Fail!", MyCamera.MV_E_RESOURCE);
                    return MyCamera.MV_E_RESOURCE;
                }
            }
            else
            {
                m_bitmapPixelFormat = PixelFormat.Format24bppRgb;

                if (IntPtr.Zero != m_ConvertDstBuf)
                {
                    Marshal.FreeHGlobal(m_ConvertDstBuf);
                    m_ConvertDstBuf = IntPtr.Zero;
                }

                // RGB为三通道
                m_nConvertDstBufLen = (UInt32)(3 * stWidth.nCurValue * stHeight.nCurValue);
                m_ConvertDstBuf = Marshal.AllocHGlobal((Int32)m_nConvertDstBufLen);
                if (IntPtr.Zero == m_ConvertDstBuf)
                {
                    ShowErrorMsg("Malloc Memory Fail!", MyCamera.MV_E_RESOURCE);
                    return MyCamera.MV_E_RESOURCE;
                }
            }

            // 确保释放保存了旧图像数据的bitmap实例，用新图像宽高等信息new一个新的bitmap实例
            if (null != m_bitmap)
            {
                m_bitmap.Dispose();
                m_bitmap = null;
            }
            m_bitmap = new Bitmap((Int32)stWidth.nCurValue, (Int32)stHeight.nCurValue, m_bitmapPixelFormat);

            // ch:Mono8格式，设置为标准调色板 | en:Set Standard Palette in Mono8 Format
            if (PixelFormat.Format8bppIndexed == m_bitmapPixelFormat)
            {
                ColorPalette palette = m_bitmap.Palette;
                for (int i = 0; i < palette.Entries.Length; i++)
                {
                    palette.Entries[i] = Color.FromArgb(i, i, i);
                }
                m_bitmap.Palette = palette;
            }

            return MyCamera.MV_OK;
        }
        public void bnStartGrab(PictureBox pictureBox)//开始采集
        {
            // ch:前置配置 | en:pre-operation
            int nRet = NecessaryOperBeforeGrab();
            if (MyCamera.MV_OK != nRet)
            {
                return;
            }

            // ch:标志位置true | en:Set position bit true
            m_bGrabbing = true;

            m_stFrameInfo.nFrameLen = 0;//取流之前先清除帧长度
            m_stFrameInfo.enPixelType = MyCamera.MvGvspPixelType.PixelType_Gvsp_Undefined;

            m_hReceiveThread = new Thread(ReceiveThreadProcess);
            m_hReceiveThread.Start(pictureBox);

            // ch:开始采集 | en:Start Grabbing
            nRet = m_MyCamera.MV_CC_StartGrabbing_NET();
            if (MyCamera.MV_OK != nRet)
            {
                m_bGrabbing = false;
                m_hReceiveThread.Join();
                ShowErrorMsg("Start Grabbing Fail!", nRet);
                return;
            }

            // ch:控件操作 | en:Control Operation
            //SetCtrlWhenStartGrab();
    
        }
        
        public void ReceiveThreadProcess(object obj)//采集线程
        {
            pictureBox1 = obj as PictureBox;
            MyCamera.MV_FRAME_OUT stFrameInfo = new MyCamera.MV_FRAME_OUT();
            MyCamera.MV_DISPLAY_FRAME_INFO stDisplayInfo = new MyCamera.MV_DISPLAY_FRAME_INFO();
            MyCamera.MV_PIXEL_CONVERT_PARAM stConvertInfo = new MyCamera.MV_PIXEL_CONVERT_PARAM();
            int nRet = MyCamera.MV_OK;

            while (m_bGrabbing)
            {
                nRet = m_MyCamera.MV_CC_GetImageBuffer_NET(ref stFrameInfo, 1000);
                // 可以测试一下，直接写代码从这个stFrameInfo里面，保存bmp图片到文件。
                // 方案二：拍摄过程的每一站图片，保存到内存变量里，等一次拍摄结束，再写入到文件。

                if (nRet == MyCamera.MV_OK)
                {
                    lock (BufForDriverLock)
                    {
                        if (m_BufForDriver == IntPtr.Zero || stFrameInfo.stFrameInfo.nFrameLen > m_nBufSizeForDriver)
                        {
                            if (m_BufForDriver != IntPtr.Zero)
                            {
                                Marshal.Release(m_BufForDriver);
                                m_BufForDriver = IntPtr.Zero;
                            }

                            m_BufForDriver = Marshal.AllocHGlobal((Int32)stFrameInfo.stFrameInfo.nFrameLen);
                            if (m_BufForDriver == IntPtr.Zero)
                            {
                                return;
                            }
                            m_nBufSizeForDriver = stFrameInfo.stFrameInfo.nFrameLen;
                        }

                        m_stFrameInfo = stFrameInfo.stFrameInfo;
                        CopyMemory(m_BufForDriver, stFrameInfo.pBufAddr, stFrameInfo.stFrameInfo.nFrameLen);

                        // ch:转换像素格式 | en:Convert Pixel Format
                        stConvertInfo.nWidth = stFrameInfo.stFrameInfo.nWidth;
                        stConvertInfo.nHeight = stFrameInfo.stFrameInfo.nHeight;
                        stConvertInfo.enSrcPixelType = stFrameInfo.stFrameInfo.enPixelType;
                        stConvertInfo.pSrcData = stFrameInfo.pBufAddr;
                        stConvertInfo.nSrcDataLen = stFrameInfo.stFrameInfo.nFrameLen;
                        stConvertInfo.pDstBuffer = m_ConvertDstBuf;
                        stConvertInfo.nDstBufferSize = m_nConvertDstBufLen;
                        if (PixelFormat.Format8bppIndexed == m_bitmap.PixelFormat)
                        {
                            stConvertInfo.enDstPixelType = MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono8;
                            m_MyCamera.MV_CC_ConvertPixelType_NET(ref stConvertInfo);
                        }
                        else
                        {
                            stConvertInfo.enDstPixelType = MyCamera.MvGvspPixelType.PixelType_Gvsp_RGB8_Packed;
                            m_MyCamera.MV_CC_ConvertPixelType_NET(ref stConvertInfo);
                        }

                        // ch:保存Bitmap数据 | en:Save Bitmap Data
                        BitmapData bitmapData = m_bitmap.LockBits(new Rectangle(0, 0, stConvertInfo.nWidth, stConvertInfo.nHeight), ImageLockMode.ReadWrite, m_bitmap.PixelFormat);
                        CopyMemory(bitmapData.Scan0, stConvertInfo.pDstBuffer, (UInt32)(bitmapData.Stride * m_bitmap.Height));
                        m_bitmap.UnlockBits(bitmapData);
                    }
                    //pictureBox1.Invoke(new MethodInvoker(() =>
                    //{
                        stDisplayInfo.hWnd = pictureBox1.Handle;
                        
                    //}));
                    stDisplayInfo.pData = stFrameInfo.pBufAddr;
                    stDisplayInfo.nDataLen = stFrameInfo.stFrameInfo.nFrameLen;
                    stDisplayInfo.nWidth = stFrameInfo.stFrameInfo.nWidth;
                    stDisplayInfo.nHeight = stFrameInfo.stFrameInfo.nHeight;
                    stDisplayInfo.enPixelType = stFrameInfo.stFrameInfo.enPixelType;
                    m_MyCamera.MV_CC_DisplayOneFrame_NET(ref stDisplayInfo);
                    m_MyCamera.MV_CC_FreeImageBuffer_NET(ref stFrameInfo);
                   // pictureBox1.DrawToBitmap(bitmapData, stConvertInfo);
                   // pictureBox1.Show();
                    //MyCamera.MV_SAVE_IMG_TO_FILE_PARAM stSaveFileParam = new MyCamera.MV_SAVE_IMG_TO_FILE_PARAM();

                    //stSaveFileParam.enImageType = MyCamera.MV_SAVE_IAMGE_TYPE.MV_Image_Bmp;
                    //stSaveFileParam.enPixelType = m_stFrameInfo.enPixelType;
                    //stSaveFileParam.pData = m_BufForDriver;
                    //stSaveFileParam.nDataLen = m_stFrameInfo.nFrameLen;
                    //stSaveFileParam.nHeight = m_stFrameInfo.nHeight;
                    //stSaveFileParam.nWidth = m_stFrameInfo.nWidth;
                    //stSaveFileParam.iMethodValue = 2;
                    //stSaveFileParam.pImagePath = "D:\\RGB\\" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".bmp";//"Image_w" + stSaveFileParam.nWidth.ToString() + "_h" + stSaveFileParam.nHeight.ToString() + "_fn" + m_stFrameInfo.nFrameNum.ToString() + ".bmp";
                    //int nRet1 = m_MyCamera.MV_CC_SaveImageToFile_NET(ref stSaveFileParam);
                    Console.WriteLine("2");
                }
                else
                {
                    //if (bnTriggerMode.Checked)
                    //{
                    //    Thread.Sleep(5);
                    //}
                }
            }
        }

        public void bnSaveImage(string Type,string path)//保存图片
        {
            if (false == m_bGrabbing)
            {
                ShowErrorMsg("Not Start Grabbing", 0);
                return;
            }

            MyCamera.MV_SAVE_IMG_TO_FILE_PARAM stSaveFileParam = new MyCamera.MV_SAVE_IMG_TO_FILE_PARAM();

            lock (BufForDriverLock)
            {
                if (m_stFrameInfo.nFrameLen == 0)
                {
                    ShowErrorMsg("Save Bmp Fail!", 0);
                    return;
                }
                stSaveFileParam.enImageType = MyCamera.MV_SAVE_IAMGE_TYPE.MV_Image_Bmp;
                string name = ".bmp";
                switch (Type) 
                {
                    case "bmp":
                        name = ".bmp";
                        stSaveFileParam.enImageType = MyCamera.MV_SAVE_IAMGE_TYPE.MV_Image_Bmp;
                        stSaveFileParam.enPixelType = m_stFrameInfo.enPixelType;
                        stSaveFileParam.pData = m_BufForDriver;
                        stSaveFileParam.nDataLen = m_stFrameInfo.nFrameLen;
                        stSaveFileParam.nHeight = m_stFrameInfo.nHeight;
                        stSaveFileParam.nWidth = m_stFrameInfo.nWidth;
                        stSaveFileParam.iMethodValue = 2;
                        stSaveFileParam.pImagePath = path + name;//"Image_w" + stSaveFileParam.nWidth.ToString() + "_h" + stSaveFileParam.nHeight.ToString() + "_fn" + m_stFrameInfo.nFrameNum.ToString() + ".bmp";
                        break;
                    case "jpg":
                        stSaveFileParam.enImageType = MyCamera.MV_SAVE_IAMGE_TYPE.MV_Image_Jpeg;
                        name = ".jpg";
                        stSaveFileParam.enPixelType = m_stFrameInfo.enPixelType;
                        stSaveFileParam.pData = m_BufForDriver;
                        stSaveFileParam.nDataLen = m_stFrameInfo.nFrameLen;
                        stSaveFileParam.nHeight = m_stFrameInfo.nHeight;
                        stSaveFileParam.nWidth = m_stFrameInfo.nWidth;
                        stSaveFileParam.nQuality = 80;
                        stSaveFileParam.iMethodValue = 2;
                        stSaveFileParam.pImagePath = path + name;
                        break;
                    case "tiff":
                        stSaveFileParam.enImageType = MyCamera.MV_SAVE_IAMGE_TYPE.MV_Image_Tif;
                        name = ".tif";
                        stSaveFileParam.enPixelType = m_stFrameInfo.enPixelType;
                        stSaveFileParam.pData = m_BufForDriver;
                        stSaveFileParam.nDataLen = m_stFrameInfo.nFrameLen;
                        stSaveFileParam.nHeight = m_stFrameInfo.nHeight;
                        stSaveFileParam.nWidth = m_stFrameInfo.nWidth;
                        stSaveFileParam.iMethodValue = 2;
                        stSaveFileParam.pImagePath = path + name;
                        break;
                    case "png":
                        stSaveFileParam.enImageType = MyCamera.MV_SAVE_IAMGE_TYPE.MV_Image_Png;
                        name = ".png";
                        stSaveFileParam.enPixelType = m_stFrameInfo.enPixelType;
                        stSaveFileParam.pData = m_BufForDriver;
                        stSaveFileParam.nDataLen = m_stFrameInfo.nFrameLen;
                        stSaveFileParam.nHeight = m_stFrameInfo.nHeight;
                        stSaveFileParam.nWidth = m_stFrameInfo.nWidth;
                        stSaveFileParam.nQuality = 8;
                        stSaveFileParam.iMethodValue = 2;
                        stSaveFileParam.pImagePath = path + name;
                        break;
                }
                //stSaveFileParam.enPixelType = m_stFrameInfo.enPixelType;
                //stSaveFileParam.pData = m_BufForDriver;
                //stSaveFileParam.nDataLen = m_stFrameInfo.nFrameLen;
                //stSaveFileParam.nHeight = m_stFrameInfo.nHeight;
                //stSaveFileParam.nWidth = m_stFrameInfo.nWidth;
                //stSaveFileParam.iMethodValue = 2;
                //stSaveFileParam.pImagePath = path+ name;//"Image_w" + stSaveFileParam.nWidth.ToString() + "_h" + stSaveFileParam.nHeight.ToString() + "_fn" + m_stFrameInfo.nFrameNum.ToString() + ".bmp";
                int nRet = m_MyCamera.MV_CC_SaveImageToFile_NET(ref stSaveFileParam);
                if (MyCamera.MV_OK != nRet)
                {
                    ShowErrorMsg("Save Bmp Fail!", nRet);
                    return;
                }
            }
            ShowErrorMsg("Save Succeed!", 0);
        }
        public string bnGetParam(string ParaType)//获取相机参数
        {
            MyCamera.MVCC_FLOATVALUE stParam = new MyCamera.MVCC_FLOATVALUE();
            /*
             * ParaType:
             * "ExposureTime"  积分时间
             * "Gain" 增益
             * "ResultingFrameRate" 帧频
             */
            int nRet = m_MyCamera.MV_CC_GetFloatValue_NET(ParaType, ref stParam);
            if (MyCamera.MV_OK == nRet)
            {
                return stParam.fCurValue.ToString("F1");
            }
            else 
            {
                return null;
            }
            //nRet = m_MyCamera.MV_CC_GetFloatValue_NET("Gain", ref stParam);
            //if (MyCamera.MV_OK == nRet)
            //{
            //    tbGain.Text = stParam.fCurValue.ToString("F1");
            //}

            //nRet = m_MyCamera.MV_CC_GetFloatValue_NET("ResultingFrameRate", ref stParam);
            //if (MyCamera.MV_OK == nRet)
            //{
            //    tbFrameRate.Text = stParam.fCurValue.ToString("F1");
            //}
        }
        public void bnSetParam(string ParaType, string Value)//设置参数
        {
            //try
            //{
            //    float.Parse(tbExposure.Text);
            //    float.Parse(tbGain.Text);
            //    float.Parse(tbFrameRate.Text);
            //}
            //catch
            //{
            //    ShowErrorMsg("Please enter correct type!", 0);
            //    return;
            //}
            int nRet = 0;
            if (ParaType == "ExposureTime")
            {
                m_MyCamera.MV_CC_SetEnumValue_NET("ExposureAuto", 0);//取消自动曝光时间
                nRet = m_MyCamera.MV_CC_SetFloatValue_NET(ParaType, float.Parse(Value));
                if (nRet != MyCamera.MV_OK)
                {
                    ShowErrorMsg("Set Exposure Time Fail!", nRet);
                }
            }
            else if (ParaType == "Gain")
            {
                m_MyCamera.MV_CC_SetEnumValue_NET("GainAuto", 0);
                nRet = m_MyCamera.MV_CC_SetFloatValue_NET(ParaType, float.Parse(Value));
                if (nRet != MyCamera.MV_OK)
                {
                    ShowErrorMsg("Set Gain Fail!", nRet);
                }
            }
            else if (ParaType == "AcquisitionFrameRate")
            {
                nRet = m_MyCamera.MV_CC_SetFloatValue_NET(ParaType, float.Parse(Value));
                if (nRet != MyCamera.MV_OK)
                {
                    ShowErrorMsg("Set Frame Rate Fail!", nRet);
                }
            }
            else 
            {

            }




           
        }
        public void bnStopGrab()
        {
            // ch:标志位设为false | en:Set flag bit false
            m_bGrabbing = false;
            m_hReceiveThread.Join();

            // ch:停止采集 | en:Stop Grabbing
            int nRet = m_MyCamera.MV_CC_StopGrabbing_NET();
            if (nRet != MyCamera.MV_OK)
            {
                ShowErrorMsg("Stop Grabbing Fail!", nRet);
            }

            // ch:控件操作 | en:Control Operation
            //SetCtrlWhenStopGrab();
        }
        //public void cbPixelFormat(object sender, EventArgs e)
        //{
        //    // 设置像素格式
        //    int nRet = m_MyCamera.MV_CC_SetEnumValue_NET("PixelFormat", );
        //    if (nRet != MyCamera.MV_OK)
        //    {
              
        //    }
        //   // stPixelFormat.CurValue = m_pcPixelFormat.SupportValue[cmbPixelFormat.SelectedIndex];
        //   // Get_ImageCompressionMode();
        //}
        public void Get_PixelFormat(ComboBox comboBox)
        {
            //ComboBox cmbPixelFormat = new ComboBox();
            comboBox.Items.Clear();
            Int32 nPixelFormatIndex = 0;
            MVCC_ENUMENTRY pcEnumEntry = new MVCC_ENUMENTRY();

            Int32 nRet = m_MyCamera.MV_CC_GetEnumValue_NET("PixelFormat", ref stPixelFormat);
            if (MyCamera.MV_OK == nRet)
            {
                for (UInt32 i = 0; i < stPixelFormat.nSupportedNum; i++)
                {
                    pcEnumEntry.nValue = stPixelFormat.nSupportValue[i];
                    nRet = m_MyCamera.MV_CC_GetEnumEntrySymbolic_NET("PixelFormat", ref pcEnumEntry);
                    if (MyCamera.MV_OK == nRet)
                    {
                        comboBox.Items.Add(pcEnumEntry.chSymbolic);
                    }

                    if (stPixelFormat.nSupportValue[i] == stPixelFormat.nCurValue)
                    {
                        nPixelFormatIndex = (Int32)i;
                    }
                }

            }
        }
        public void cbPixelFormat(uint a)
        {
            if (!m_bGrabbing)
            {
                int nRet = m_MyCamera.MV_CC_GetEnumValue_NET("PixelFormat",ref stPixelFormat);

                // 设置像素格式
                nRet = m_MyCamera.MV_CC_SetEnumValue_NET("PixelFormat", a);
                if (nRet != MyCamera.MV_OK)
                {
                    ShowErrorMsg("Set PixelFormat Fail!", nRet);
                    //for (UInt32 i = 0; i < stPixelFormat.nSupportedNum; i++)
                    //{
                    //    if (stPixelFormat.nSupportValue[i] == stPixelFormat.nCurValue)
                    //    {
                    //        //cmbPixelFormat.SelectedIndex = (Int32)i;
                    //        MessageBox.Show("像素类型不存在");
                    //        return;
                    //    }
                    //}
                }
                //stPixelFormat.nCurValue = stPixelFormat.nSupportValue[cmbPixelFormat.SelectedIndex];
                //Get_ImageCompressionMode();
            }
            else 
            {
                MessageBox.Show("请关闭视频流");
            }
          
        }

        //private void Get_PixelFormat1()
        //{
        //    cmbPixelFormat.Items.Clear();
        //    Int32 nPixelFormatIndex = 0;
        //    CEnumEntry pcEnumEntry = new CEnumEntry();

        //    Int32 nRet = m_MyCamera.GetEnumValue("PixelFormat", ref m_pcPixelFormat);
        //    if (CErrorDefine.MV_OK == nRet)
        //    {
        //        for (UInt32 i = 0; i < m_pcPixelFormat.SupportedNum; i++)
        //        {
        //            pcEnumEntry.Value = m_pcPixelFormat.SupportValue[i];
        //            nRet = m_MyCamera.GetEnumEntrySymbolic("PixelFormat", ref pcEnumEntry);
        //            if (CErrorDefine.MV_OK == nRet)
        //            {
        //                cmbPixelFormat.Items.Add(pcEnumEntry.Symbolic);
        //            }

        //            if (m_pcPixelFormat.SupportValue[i] == m_pcPixelFormat.CurValue)
        //            {
        //                nPixelFormatIndex = (Int32)i;
        //            }
        //        }
        //        cmbPixelFormat.SelectedIndex = nPixelFormatIndex;
        //        cmbPixelFormat.Enabled = true;
        //    }
        //}

    }
}
