using Canondemo;
using OpenCvSharp;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace m_CTP
{
   public  class Depth
    {
        //private string MannulHyperPath = "";
        public static string HyperFileName = "";
        public static string HyperFileId = "";
        //public  Thread STR;
        //public  Thread SOR;
        internal static HyperSpecCamera hyperCamera;
       public static PictureBox PylonimgDraw;
        public static bool HyperSate = false;
        //static bool isrun = true;
        public static readonly object Lock = new object();
      
        public static IntPtr m_handle = IntPtr.Zero;
  
        public UInt32 m_nDevNum = 0;
        public MV3D_RGBD_DEVICE_INFO_VECTOR m_stVector;
        public Thread m_hReceiveThread = null;
        public  static MV3D_RGBD_IMAGE_DATA m_stImageInfo = new MV3D_RGBD_IMAGE_DATA();
      
        public static UInt32 m_MaxImageSize = 1024 * 1024 * 30;
        public static byte[] m_pcDataBuf = new byte[m_MaxImageSize];
        public CancellationTokenSource _cancellationTokenSource;
        public bool m_bGrabbing = false;
        public readonly object _renderLock = new object();
        public readonly object _syncLock = new object();
        public DateTime _lastRenderTime = DateTime.MinValue;
        public bool m_softTriggerRequested=true;
        public void OpenDepth()
        {
            if (m_nDevNum == 0 )
            {
                ShowErrorMsg("No device, please select", 0);
                return;
            }

            // ch:打开设备 | en:Open device
            int nRet = Mv3dRgbdSDK.MV3D_RGBD_OpenDeviceBySerialNumber(ref m_handle, m_stVector[0].chSerialNumber);
            if (0 != nRet)
            {
                ShowErrorMsg("Open Device Failed ", nRet);
                return;
            }

            nRet = Mv3dRgbdSDK.MV3D_RGBD_SoftTrigger(m_handle);
        }
        public void DeviceListAcq(UIComboBox cbDevice)
        {
            // ch:创建设备列表 | en:Create Device List
            //System.GC.Collect();
            cbDevice.Items.Clear();
            m_nDevNum = 0;
            int nRet = Mv3dRgbdSDK.MV3D_RGBD_GetDeviceNumber(Mv3dRgbdSDK.DeviceType_USB | Mv3dRgbdSDK.DeviceType_USB_Vir, ref m_nDevNum);

            m_stVector = new MV3D_RGBD_DEVICE_INFO_VECTOR((int)m_nDevNum);
            for (UInt32 i = 0; i < m_nDevNum; i++)
            {
                m_stVector.Add(new MV3D_RGBD_DEVICE_INFO());
            }

            // ch:获取网络中设备信息 | en:Enumerate all devices within net
            nRet = Mv3dRgbdSDK.MV3D_RGBD_GetDeviceList( Mv3dRgbdSDK.DeviceType_USB |  Mv3dRgbdSDK.DeviceType_USB_Vir, m_stVector[0], m_nDevNum, ref m_nDevNum);
            if (0 != nRet)
            {
                ShowErrorMsg("Enumerate devices fail!", nRet);
                return;
            }

            // ch:在窗体列表中显示设备名 | en:Display device name in the form list
            for (int i = 0; i < m_nDevNum; i++)
            {
                string strSerialNumber = m_stVector[i].chSerialNumber;// System.Text.Encoding.Default.GetString(m_stVector[i].chSerialNumber);
                strSerialNumber = strSerialNumber.TrimEnd('\0');

                string strModelName = m_stVector[i].chModelName;
                strModelName = strModelName.TrimEnd('\0');

                //if (Mv3dRgbdSDK.DeviceType_Ethernet == m_stVector[i].enDeviceType || Mv3dRgbdSDK.DeviceType_Ethernet_Vir == m_stVector[i].enDeviceType)
                //{
                //    string strCurrentIp = m_stVector[i].get_netinfo().chCurrentIp;
                //    strCurrentIp = strCurrentIp.TrimEnd('\0');

                //    cbDevice.Items.Add("DEV:" + "Name:" + strModelName + " " + "IP:" + strCurrentIp + " " + "SerialNum:" + strSerialNumber);
                //}
                //else
                if (Mv3dRgbdSDK.DeviceType_USB == m_stVector[i].enDeviceType || Mv3dRgbdSDK.DeviceType_USB_Vir == m_stVector[i].enDeviceType)
                {
                    string strUsbProtocol = Convert.ToString(m_stVector[i].get_usbinfo().enUsbProtocol);
                    strUsbProtocol = strUsbProtocol.TrimEnd('\0');

                    cbDevice.Items.Add("USB:" + "Name:" + strModelName + " " + "UsbProtocol:" + strUsbProtocol + " " + "SerialNum:" + strSerialNumber);
                }

            }

            // ch:选择第一项 | en:Select the first item
            if (m_nDevNum != 0)
            {
                cbDevice.SelectedIndex = 0;
            }


        }
        public void CloseDepth(PictureBox pic1)
        {
            m_bGrabbing=false;
            if (m_bGrabbing == true)
            {
                m_bGrabbing = false;
                m_hReceiveThread.Join();
            }
            //if (m_hReceiveThread != null && m_hReceiveThread.IsAlive)
            //{
            //    if (!m_hReceiveThread.Join(2000)) // 2秒超时
            //    {
            //        m_hReceiveThread.Abort(); // 强制终止
            //    }
            //}

            pic1.Image = null;
            Mv3dRgbdSDK.MV3D_RGBD_Stop(m_handle);
            Mv3dRgbdSDK.MV3D_RGBD_CloseDevice(ref m_handle);



           

        }
        public void StopPreview()
        {
            try
            {
                _cts?.Cancel(); // 安全调用
            }
            catch (ObjectDisposedException)
            {
                // 已释放则忽略
            }// 1. 发出取消信号[6](@ref)
            m_bGrabbing = false; // 2. 设置停止标志

            // 3. 等待线程退出（混合模式：自旋等待+超时阻塞）
            SpinWait.SpinUntil(() => !(_cts?.IsCancellationRequested ?? true), 500);
            Thread.Sleep(100); // 确保线程完全退出

            // 4. 停止硬件采集
            if (m_handle != IntPtr.Zero)
                Mv3dRgbdSDK.MV3D_RGBD_Stop(m_handle);

            // 5. 释放资源
            _cts?.Dispose();
           

        }
       
        public uint SaveImage(uint nFileType,string savePath)
        {
            
            int nRet = (int)Mv3dRgbdSDK.MV3D_RGBD_OK;
            nRet = Mv3dRgbdSDK.MV3D_RGBD_Start(m_handle);
            m_bGrabbing = true;
            MV3D_RGBD_FRAME_DATA stFrameData = new MV3D_RGBD_FRAME_DATA();
            nRet = Mv3dRgbdSDK.MV3D_RGBD_SoftTrigger(m_handle);
            nRet = Mv3dRgbdSDK.MV3D_RGBD_FetchFrame(m_handle, stFrameData, 500); // 缩短超时时间
          
            if (stFrameData.stImageData[0].pData != IntPtr.Zero)
            {
                // 安全拷贝数据
                if (m_MaxImageSize < stFrameData.stImageData[0].nDataLen)
                {
                    m_pcDataBuf = new byte[stFrameData.stImageData[0].nDataLen];
                    m_MaxImageSize = stFrameData.stImageData[0].nDataLen;
                    
                }

                Marshal.Copy(
                    stFrameData.stImageData[0].pData,
                    m_pcDataBuf,
                    0,
                    (int)stFrameData.stImageData[0].nDataLen

                );
               
            }
            //GCHandle handle = GCHandle.Alloc(m_pcDataBuf, GCHandleType.Pinned);
            m_stImageInfo.nWidth = stFrameData.stImageData[0].nWidth;
            m_stImageInfo.nHeight = stFrameData.stImageData[0].nHeight;
            m_stImageInfo.enImageType = stFrameData.stImageData[0].enImageType;
            m_stImageInfo.nDataLen = stFrameData.stImageData[0].nDataLen;
            m_stImageInfo.nFrameNum = stFrameData.stImageData[0].nFrameNum;
            m_stImageInfo.pData = Marshal.UnsafeAddrOfPinnedArrayElement(m_pcDataBuf, 0);
            
            //nRet = Mv3dRgbdSDK.MV3D_RGBD_SoftTrigger(m_handle);
            // 新增：从 HyperPath 文本框获取路径
            //string savePath = path;
            if (string.IsNullOrEmpty(savePath))
            {
                ShowErrorMsg("保存路径不能为空！", 0);
                return Mv3dRgbdSDK.MV3D_RGBD_E_CALLORDER;
            }


            // 新增：根据文件类型自动添加扩展名（需与 nFileType 匹配）

            Thread.Sleep(500);
            savePath = Path.Combine(savePath, $"Image_{DateTime.Now:yyyyMMdd_HHmmss}");

            if (!m_bGrabbing)
            {
                ShowErrorMsg("未开始采集！", 0);
                return Mv3dRgbdSDK.MV3D_RGBD_E_CALLORDER;
            }

            if (0 == m_stImageInfo.nDataLen)
            {
                ShowErrorMsg("无图像数据！", 0);
                return Mv3dRgbdSDK.MV3D_RGBD_E_NODATA;
            }

            //Monitor.Enter(Lock);
            //// 修改：将路径参数替换为 savePath
            //nRet = Mv3dRgbdSDK.MV3D_RGBD_SaveImage(m_handle, m_stImageInfo, nFileType, savePath);
            //Monitor.Exit(Lock);
            int roiX = 418;
            int roiY = 400;
            int roiWidth = 650;
            int roiHeight = 650;

            Monitor.Enter(Lock);
            try
            {
                // 获取当前图像数据
                byte[] imageData = m_pcDataBuf;
                int width = (int)m_stImageInfo.nWidth;
                int height = (int)m_stImageInfo.nHeight;

                // 创建裁剪后的图像数据
                 byte[] croppedData = new byte[roiWidth * roiHeight * 2]; // 假设16位图像，每个像素2字节
                string str = savePath + ".tiff";
                Rect roi = new Rect(418, 400, 650, 650);
                //CalculateNonZeroMinMaxInRoi(imageData, width, height, roi, str);
                // 复制非零区域的数据
                for (int y = 0; y < roiHeight; y++)
                {
                    int srcIndex = ((roiY + y) * width + roiX) * 2;
                    int dstIndex = (y * roiWidth) * 2;
                    Buffer.BlockCopy(imageData, srcIndex, croppedData, dstIndex, roiWidth * 2);
                }

                // 更新图像信息
                MV3D_RGBD_IMAGE_DATA croppedImageInfo = new MV3D_RGBD_IMAGE_DATA
                {
                    nWidth = (uint)roiWidth,
                    nHeight = (uint)roiHeight,
                    enImageType = m_stImageInfo.enImageType,
                    nDataLen = (uint)croppedData.Length,
                    nFrameNum = m_stImageInfo.nFrameNum
                };

                // 分配非托管内存并复制数据
                IntPtr pCroppedData = Marshal.AllocHGlobal(croppedData.Length);
                Marshal.Copy(croppedData, 0, pCroppedData, croppedData.Length);
                croppedImageInfo.pData = pCroppedData;

                // 保存裁剪后的图像
                //Cv2.ImWrite(str, croppedData);
                nRet = Mv3dRgbdSDK.MV3D_RGBD_SaveImage(m_handle, croppedImageInfo, nFileType, savePath);

                // 释放非托管内存
                Marshal.FreeHGlobal(pCroppedData);

                if (Mv3dRgbdSDK.MV3D_RGBD_OK != nRet)
                {
                    ShowErrorMsg("SaveImage failed", 0);
                }
            }
            finally
            {
                Monitor.Exit(Lock);
            }            //Monitor.Exit(Lock);
            if (Mv3dRgbdSDK.MV3D_RGBD_OK != nRet)
            {
                ShowErrorMsg($"保存失败: 错误代码 {nRet}", 0);
            }
            else
            {
                // 新增：成功提示（可选）
                //    MessageBox.Show($"图片已保存至:\n{savePath}");
                Form1.ProgramChecking = "深度图保存成功!";
            }
            //handle.Free(); // 解除固定，允许 GC 回收
            //Marshal.FreeHGlobal(m_stImageInfo.pData); // 释放非托管内存
                                               // GC.Collect();
            return (uint)nRet;
        }
     public void CalculateNonZeroMinMaxInRoi(     byte[] imageData,     int width,     int height,     Rect roi,     string filename)
        // out byte minValue,
        //out byte maxValue,
        // out bool hasNonZeroValues)
        {
            // minValue = 0;
            // maxValue = 0;
            //  hasNonZeroValues = false;

            using (Mat fullImage = new Mat(height, width, MatType.CV_16UC1, imageData))
            {
                // 验证ROI是否在图像范围内
                if (roi.X < 0 || roi.Y < 0 ||
                    roi.X + roi.Width > width ||
                    roi.Y + roi.Height > height)
                {
                    throw new ArgumentException("ROI is out of image boundaries");
                }

                // 提取ROI区域
                using (Mat roiMat = new Mat(fullImage, roi))
                {
                    // 创建非零掩码 (非零值=255, 零值=0)
                    using (Mat nonZeroMask = new Mat())
                    {
                        Cv2.Compare(roiMat, Scalar.All(0), nonZeroMask, CmpTypes.NE);

                        // 检查是否存在非零值
                        int nonZeroCount = Cv2.CountNonZero(nonZeroMask);
                        //hasNonZeroValues = nonZeroCount > 0;

                        //if (!hasNonZeroValues)
                        //{
                        //    // 没有非零值，返回默认值
                        //    return;
                        //}

                        // 计算非零区域的最小/最大值
                        OpenCvSharp.Point maxLoc;
                        OpenCvSharp.Point maxLoc1;
                        double minVal, maxVal;
                        Cv2.MinMaxLoc(roiMat, out minVal, out maxVal, out maxLoc, out maxLoc1, nonZeroMask);
                        //textBox1.Text = minVal.ToString();
                        Cv2.ImWrite(filename, roiMat);
                        //textBox2.Text = maxVal.ToString();
                    }
                }
            }
        }
        public uint SaveIMG(uint nFileType, string savePath)
        {

            int nRet = (int)Mv3dRgbdSDK.MV3D_RGBD_OK;
            nRet = Mv3dRgbdSDK.MV3D_RGBD_Start(m_handle);
            m_bGrabbing = true;
            MV3D_RGBD_FRAME_DATA stFrameData = new MV3D_RGBD_FRAME_DATA();
            nRet = Mv3dRgbdSDK.MV3D_RGBD_SoftTrigger(m_handle);
            nRet = Mv3dRgbdSDK.MV3D_RGBD_FetchFrame(m_handle, stFrameData, 500); // 缩短超时时间

            if (stFrameData.stImageData[0].pData != IntPtr.Zero)
            {
                // 安全拷贝数据
                if (m_MaxImageSize < stFrameData.stImageData[0].nDataLen)
                {
                    m_pcDataBuf = new byte[stFrameData.stImageData[0].nDataLen];
                    m_MaxImageSize = stFrameData.stImageData[0].nDataLen;

                }

                Marshal.Copy(
                    stFrameData.stImageData[0].pData,
                    m_pcDataBuf,
                    0,
                    (int)stFrameData.stImageData[0].nDataLen

                );

            }
            //GCHandle handle = GCHandle.Alloc(m_pcDataBuf, GCHandleType.Pinned);
            m_stImageInfo.nWidth = stFrameData.stImageData[0].nWidth;
            m_stImageInfo.nHeight = stFrameData.stImageData[0].nHeight;
            m_stImageInfo.enImageType = stFrameData.stImageData[0].enImageType;
            m_stImageInfo.nDataLen = stFrameData.stImageData[0].nDataLen;
            m_stImageInfo.nFrameNum = stFrameData.stImageData[0].nFrameNum;
            m_stImageInfo.pData = Marshal.UnsafeAddrOfPinnedArrayElement(m_pcDataBuf, 0);

            //nRet = Mv3dRgbdSDK.MV3D_RGBD_SoftTrigger(m_handle);
            // 新增：从 HyperPath 文本框获取路径
            //string savePath = path;
            if (string.IsNullOrEmpty(savePath))
            {
                ShowErrorMsg("保存路径不能为空！", 0);
                return Mv3dRgbdSDK.MV3D_RGBD_E_CALLORDER;
            }


            // 新增：根据文件类型自动添加扩展名（需与 nFileType 匹配）

            Thread.Sleep(500);
            string DataId = DateTime.Now.ToString("yyyyMMddHHmmss") + (0).ToString("00");
            string DataName = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "-" + (0).ToString("00");
            CreatExcel.InterData(DataAcquisition.interExcelFile, "0", "0", "depth", DataId, DataName);
            savePath = Path.Combine(savePath,DataName);

            if (!m_bGrabbing)
            {
                ShowErrorMsg("未开始采集！", 0);
                return Mv3dRgbdSDK.MV3D_RGBD_E_CALLORDER;
            }

            if (0 == m_stImageInfo.nDataLen)
            {
                ShowErrorMsg("无图像数据！", 0);
                return Mv3dRgbdSDK.MV3D_RGBD_E_NODATA;
            }

            //Monitor.Enter(Lock);
            //// 修改：将路径参数替换为 savePath
            //nRet = Mv3dRgbdSDK.MV3D_RGBD_SaveImage(m_handle, m_stImageInfo, nFileType, savePath);
            //Monitor.Exit(Lock);
            int roiX = 418;
            int roiY = 400;
            int roiWidth = 650;
            int roiHeight = 650;

            Monitor.Enter(Lock);
            try
            {
                // 获取当前图像数据
                byte[] imageData = m_pcDataBuf;
                int width = (int)m_stImageInfo.nWidth;
                int height = (int)m_stImageInfo.nHeight;

                // 创建裁剪后的图像数据
                byte[] croppedData = new byte[roiWidth * roiHeight * 2]; // 假设16位图像，每个像素2字节

                // 复制非零区域的数据
                for (int y = 0; y < roiHeight; y++)
                {
                    int srcIndex = ((roiY + y) * width + roiX) * 2;
                    int dstIndex = (y * roiWidth) * 2;
                    Buffer.BlockCopy(imageData, srcIndex, croppedData, dstIndex, roiWidth * 2);
                }

                // 更新图像信息
                MV3D_RGBD_IMAGE_DATA croppedImageInfo = new MV3D_RGBD_IMAGE_DATA
                {
                    nWidth = (uint)roiWidth,
                    nHeight = (uint)roiHeight,
                    enImageType = m_stImageInfo.enImageType,
                    nDataLen = (uint)croppedData.Length,
                    nFrameNum = m_stImageInfo.nFrameNum
                };

                // 分配非托管内存并复制数据
                IntPtr pCroppedData = Marshal.AllocHGlobal(croppedData.Length);
                Marshal.Copy(croppedData, 0, pCroppedData, croppedData.Length);
                croppedImageInfo.pData = pCroppedData;

                // 保存裁剪后的图像
                nRet = Mv3dRgbdSDK.MV3D_RGBD_SaveImage(m_handle, croppedImageInfo, nFileType, savePath);

                // 释放非托管内存
                Marshal.FreeHGlobal(pCroppedData);

                if (Mv3dRgbdSDK.MV3D_RGBD_OK != nRet)
                {
                    ShowErrorMsg("SaveImage failed", 0);
                }
            }
            finally
            {
                Monitor.Exit(Lock);
            }
            if (Mv3dRgbdSDK.MV3D_RGBD_OK != nRet)
            {
                ShowErrorMsg($"保存失败: 错误代码 {nRet}", 0);
            }
            else
            {
                // 新增：成功提示（可选）
                //    MessageBox.Show($"图片已保存至:\n{savePath}");
            }
            //handle.Free(); // 解除固定，允许 GC 回收
            //Marshal.FreeHGlobal(m_stImageInfo.pData); // 释放非托管内存
            // GC.Collect();
            return (uint)nRet;
        }
        public void Set_Par(string exposure,string gain)
        {
            try
            {
                float.Parse(exposure);
                float.Parse(gain);
            }
            catch
            {
                ShowErrorMsg("Please enter correct type!", 0);
                return;
            }
            bool bHasError = false;

            MV3D_RGBD_PARAM pstValue = new MV3D_RGBD_PARAM();

            pstValue.enParamType = Mv3dRgbdSDK.ParamType_Float;
            MV3D_RGBD_FLOATPARAM floatParam = new MV3D_RGBD_FLOATPARAM();

            floatParam.fCurValue = float.Parse(exposure);
            pstValue.set_floatparam(floatParam);
            int nRet = Mv3dRgbdSDK.MV3D_RGBD_SetParam(m_handle, Mv3dRgbdSDK.MV3D_RGBD_FLOAT_EXPOSURETIME, pstValue);
            if (Mv3dRgbdSDK.MV3D_RGBD_OK != nRet)
            {
                bHasError = true;
                ShowErrorMsg("Set Exposure Time Fail!", nRet);
            }

            floatParam.fCurValue = float.Parse(gain);
            pstValue.set_floatparam(floatParam);
            nRet = Mv3dRgbdSDK.MV3D_RGBD_SetParam(m_handle, Mv3dRgbdSDK.MV3D_RGBD_FLOAT_GAIN, pstValue);
            if (Mv3dRgbdSDK.MV3D_RGBD_OK != nRet)
            {
                bHasError = true;
                ShowErrorMsg("Set Gain Fail!", nRet);
            }

            if (false == bHasError)
            {
                string errorMsg = "Set Para Success!";
                MessageBox.Show(errorMsg, "INFO");
            }
        }
        public void Get_par(out string exposure, out string gain)
        {
            exposure = "";
            gain = "";

            MV3D_RGBD_PARAM pstValue = new MV3D_RGBD_PARAM();

            pstValue.enParamType = Mv3dRgbdSDK.ParamType_Float;
            MV3D_RGBD_FLOATPARAM floatParam = new MV3D_RGBD_FLOATPARAM();

            int nRet = Mv3dRgbdSDK.MV3D_RGBD_GetParam( m_handle, Mv3dRgbdSDK.MV3D_RGBD_FLOAT_EXPOSURETIME, pstValue);
            if (Mv3dRgbdSDK.MV3D_RGBD_OK != nRet)
            {
                ShowErrorMsg("Get Exposure Time Fail!", nRet);
            }
            else
            {
                floatParam = pstValue.get_floatparam();
                exposure = floatParam.fCurValue.ToString("F1");
            }

            nRet = Mv3dRgbdSDK.MV3D_RGBD_GetParam( m_handle, Mv3dRgbdSDK.MV3D_RGBD_FLOAT_GAIN, pstValue);
            if (Mv3dRgbdSDK.MV3D_RGBD_OK != nRet)
            {
                ShowErrorMsg("Get Gain Fail!", nRet);
            }
            else
            {
                floatParam = pstValue.get_floatparam();
                gain = floatParam.fCurValue.ToString("F1");
            }

        }

        public CancellationTokenSource _cts;
        public readonly object _frameLock = new object();
        public void StartPreview(PictureBox pictureBox1)
        {
            _cts = new CancellationTokenSource();
            m_bGrabbing = true;

            // 使用Task替代Thread支持优雅取消
            Task.Run(() => ReceiveThreadProcess(pictureBox1, _cts.Token));

            int nRet = Mv3dRgbdSDK.MV3D_RGBD_Start(m_handle);
            if (0 != nRet)
            {
                StopPreview(); // 统一调用停止方法
                ShowErrorMsg("Start Grabbing Fail!", nRet);
            }
        }
        public void ReceiveThreadProcess(PictureBox pictureBox1, CancellationToken token)
        {
            int nRet = (int)Mv3dRgbdSDK.MV3D_RGBD_OK;

            while (m_bGrabbing && !token.IsCancellationRequested)
            {
                Thread.Sleep(100);
                MV3D_RGBD_FRAME_DATA stFrameData = new MV3D_RGBD_FRAME_DATA();
                 nRet = Mv3dRgbdSDK.MV3D_RGBD_SoftTrigger(m_handle);
                
                 nRet = Mv3dRgbdSDK.MV3D_RGBD_FetchFrame(m_handle, stFrameData, 500); // 缩短超时时间
                
                try
                {
                    if (nRet == 0 && !token.IsCancellationRequested)
                    {
                        lock (_frameLock) // 扩大锁范围至整个帧处理流程[2,4](@ref)
                        {
                            if (pictureBox1.IsDisposed) break;
                            if (stFrameData.stImageData[0].pData != IntPtr.Zero)
                            {
                                // 安全拷贝数据
                                if (m_MaxImageSize < stFrameData.stImageData[0].nDataLen)
                                {
                                    m_pcDataBuf = new byte[stFrameData.stImageData[0].nDataLen];
                                    m_MaxImageSize = stFrameData.stImageData[0].nDataLen;
                                }

                                Marshal.Copy(
                                    stFrameData.stImageData[0].pData,
                                    m_pcDataBuf,
                                    0,
                                    (int)stFrameData.stImageData[0].nDataLen
                                );
                            }
                            if (pictureBox1.InvokeRequired)
                            {
                                pictureBox1.BeginInvoke((MethodInvoker)delegate
                                {

                                    IntPtr hWnd = pictureBox1.Handle;
                                    Int32 i = 0;
                                    // ch:目前渲染深度图 | en:Display depth image
                                    Mv3dRgbdSDK.MV3D_RGBD_DisplayImage(m_handle, stFrameData.stImageData[i], hWnd);
                                    {
                                        {
                                            //Monitor.Enter(Lock);
                                            m_stImageInfo.nWidth = stFrameData.stImageData[i].nWidth;
                                            m_stImageInfo.nHeight = stFrameData.stImageData[i].nHeight;
                                            m_stImageInfo.enImageType = stFrameData.stImageData[i].enImageType;
                                            m_stImageInfo.nDataLen = stFrameData.stImageData[i].nDataLen;
                                            m_stImageInfo.nFrameNum = stFrameData.stImageData[i].nFrameNum;
                                            m_stImageInfo.pData = Marshal.UnsafeAddrOfPinnedArrayElement(m_pcDataBuf, 0);

                                            if (m_MaxImageSize < stFrameData.stImageData[i].nDataLen)
                                            {
                                                m_pcDataBuf = new byte[stFrameData.stImageData[i].nDataLen];
                                                m_MaxImageSize = stFrameData.stImageData[i].nDataLen;
                                            }

                                            //Marshal.Copy(stFrameData.stImageData[i].pData, m_pcDataBuf, 0, (int)stFrameData.stImageData[i].nDataLen);
                                            //Thread.Sleep(10);
                                            //Monitor.Exit(Lock);
                                        }
                                    }
                                });
                            }
                        }
                    }
                    }

                finally
                {
                    
                    Mv3dRgbdSDK.MV3D_RGBD_Release(); // [3](@ref)
                }
                
            }

            }

        
        //public void StartPreview(PictureBox pictureBox1)
        //{

        //    m_bGrabbing = true;

        //    //m_hReceiveThread = new Thread(ReceiveThreadProcess(pictureBox1));
        //    m_hReceiveThread = new Thread(() => ReceiveThreadProcess(pictureBox1));
        //    m_hReceiveThread.Start();
        //    //m_hReceiveThread.Start();

        //    // ch:开始采集 | en:Start Grabbing
        //    int nRet = Mv3dRgbdSDK.MV3D_RGBD_Start(m_handle);

        //    if (0 != nRet)
        //    {
        //        m_bGrabbing = false;
        //        m_hReceiveThread.Join();
        //        ShowErrorMsg("Start Grabbing Fail!", nRet);
        //        return;
        //    }

        //}

        //public void ReceiveThreadProcess(PictureBox pictureBox1)
        //{
        //    int nRet = (int)Mv3dRgbdSDK.MV3D_RGBD_OK;

        //    while (m_bGrabbing)
        //    {
        //        MV3D_RGBD_FRAME_DATA stFrameData = new MV3D_RGBD_FRAME_DATA();
        //        nRet = Mv3dRgbdSDK.MV3D_RGBD_FetchFrame(m_handle, stFrameData, 1000);
        //        if (0 == nRet)
        //        {
        //            if (pictureBox1.InvokeRequired)
        //            {
        //                pictureBox1.BeginInvoke((MethodInvoker)delegate
        //                {

        //                    IntPtr hWnd = pictureBox1.Handle;
        //                    Int32 i = 0;
        //                    // ch:目前渲染深度图 | en:Display depth image
        //                    Mv3dRgbdSDK.MV3D_RGBD_DisplayImage(m_handle, stFrameData.stImageData[i], hWnd);
        //                    {
        //                        {
        //                            Monitor.Enter(Lock);
        //                            m_stImageInfo.nWidth = stFrameData.stImageData[i].nWidth;
        //                            m_stImageInfo.nHeight = stFrameData.stImageData[i].nHeight;
        //                            m_stImageInfo.enImageType = stFrameData.stImageData[i].enImageType;
        //                            m_stImageInfo.nDataLen = stFrameData.stImageData[i].nDataLen;
        //                            m_stImageInfo.nFrameNum = stFrameData.stImageData[i].nFrameNum;
        //                            m_stImageInfo.pData = Marshal.UnsafeAddrOfPinnedArrayElement(m_pcDataBuf, 0);

        //                            if (m_MaxImageSize < stFrameData.stImageData[i].nDataLen)
        //                            {
        //                                m_pcDataBuf = new byte[stFrameData.stImageData[i].nDataLen];
        //                                m_MaxImageSize = stFrameData.stImageData[i].nDataLen;
        //                            }

        //                            Marshal.Copy(stFrameData.stImageData[i].pData, m_pcDataBuf, 0, (int)stFrameData.stImageData[i].nDataLen);
        //                            //Thread.Sleep(10);
        //                            Monitor.Exit(Lock);
        //                        }
        //                    }
        //                });
        //            }
        //            else
        //            {
        //                return;
        //            }

        //        }
        //    }

        //}
        public void softStartPreview(PictureBox pictureBox1)
        {

            m_bGrabbing = true;
            SoftTrigger(pictureBox1);
        }
        public void SoftTrigger(PictureBox pictureBox1)
        {
            if (!m_bGrabbing)
            {
                ShowErrorMsg("Camera not grabbing!", -1);
                return;
            }

            // 发送软触发命令
            int nRet = Mv3dRgbdSDK.MV3D_RGBD_SoftTrigger(m_handle);
            if (nRet != 0) {

                m_bGrabbing = false;
                m_hReceiveThread.Join();
                ShowErrorMsg("Start softtrigger Fail!", nRet);
                return;
            }

            // 获取并处理单帧
            FetchAndDisplayFrame(pictureBox1);
        }
        private void FetchAndDisplayFrame(PictureBox pictureBox1)
        {
            MV3D_RGBD_FRAME_DATA stFrameData = new MV3D_RGBD_FRAME_DATA();
            int nRet = Mv3dRgbdSDK.MV3D_RGBD_FetchFrame(m_handle,stFrameData, 1000);
            if (0 == nRet)
            {
                IntPtr hWnd = pictureBox1.Handle;
                Int32 i = 0;
                // ch:目前渲染深度图 | en:Display depth image
                Mv3dRgbdSDK.MV3D_RGBD_DisplayImage(m_handle, stFrameData.stImageData[i], hWnd);
                {
                    {
                        Monitor.Enter(Lock);
                        m_stImageInfo.nWidth = stFrameData.stImageData[i].nWidth;
                        m_stImageInfo.nHeight = stFrameData.stImageData[i].nHeight;
                        m_stImageInfo.enImageType = stFrameData.stImageData[i].enImageType;
                        m_stImageInfo.nDataLen = stFrameData.stImageData[i].nDataLen;
                        m_stImageInfo.nFrameNum = stFrameData.stImageData[i].nFrameNum;
                        m_stImageInfo.pData = Marshal.UnsafeAddrOfPinnedArrayElement(m_pcDataBuf, 0);

                        if (m_MaxImageSize < stFrameData.stImageData[i].nDataLen)
                        {
                            m_pcDataBuf = new byte[stFrameData.stImageData[i].nDataLen];
                            m_MaxImageSize = stFrameData.stImageData[i].nDataLen;
                        }

                        Marshal.Copy(stFrameData.stImageData[i].pData, m_pcDataBuf, 0, (int)stFrameData.stImageData[i].nDataLen);
                        Monitor.Exit(Lock);
                    }
                }

            }
            Mv3dRgbdSDK.MV3D_RGBD_Release();

        }
       
      
        public void ShowErrorMsg(string csMessage, int nErrorNum)
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

            switch ((uint)nErrorNum)
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
        //public void ReceiveThreadProcess(CancellationToken token)
        //{
        //    int nRet = (int)Mv3dRgbdSDK.MV3D_RGBD_OK;

        //    while (!token.IsCancellationRequested)
        //    {
        //        MV3D_RGBD_FRAME_DATA stFrameData = new MV3D_RGBD_FRAME_DATA();
        //        nRet = Mv3dRgbdSDK.MV3D_RGBD_FetchFrame(m_handle, stFrameData, 1000);


        //        if (0 == nRet)
        //        {
        //            // 线程安全渲染
        //           RenderFrameSafely(stFrameData);
        //        }

        //        // 释放资源
        //        Mv3dRgbdSDK.MV3D_RGBD_Release();
        //        //token.ThrowIfCancellationRequested();
        //        //Mv3dRgbdSDK.MV3D_RGBD_FreeFrame(m_handle, ref stFrameData);
        //    }
        //}
        //public void RenderFrameSafely(MV3D_RGBD_FRAME_DATA stFrameData,PictureBox pictureBox1)
        //{
        //    if (this.IsDisposed || Link.depth._cancellationTokenSource?.IsCancellationRequested == true)
        //        return;
        //    if (pictureBox1.InvokeRequired)
        //    {
        //        this.BeginInvoke((Action<MV3D_RGBD_FRAME_DATA>)RenderFrameSafely, stFrameData);
        //    }
        //    else
        //    {
        //        lock (Link.depth._renderLock)
        //        {
        //            if (Link.depth.m_handle == IntPtr.Zero || stFrameData == null || stFrameData.stImageData == null)
        //                return;
        //            if ((DateTime.Now - Link.depth._lastRenderTime).TotalMilliseconds > 33)
        //            {
        //                IntPtr hWnd = pictureBox1.Handle;
        //                Int32 i = 0;
        //                Mv3dRgbdSDK.MV3D_RGBD_DisplayImage(Link.depth.m_handle,
        //                    stFrameData.stImageData[i], hWnd);
        //                {
        //                    {
        //                        Monitor.Enter(Link.depth.Lock);
        //                        Link.depth.m_stImageInfo.nWidth = stFrameData.stImageData[i].nWidth;
        //                        Link.depth.m_stImageInfo.nHeight = stFrameData.stImageData[i].nHeight;
        //                        Link.depth.m_stImageInfo.enImageType = stFrameData.stImageData[i].enImageType;
        //                        Link.depth.m_stImageInfo.nDataLen = stFrameData.stImageData[i].nDataLen;
        //                        Link.depth.m_stImageInfo.nFrameNum = stFrameData.stImageData[i].nFrameNum;
        //                        Link.depth.m_stImageInfo.pData = Marshal.UnsafeAddrOfPinnedArrayElement(Link.depth.m_pcDataBuf, 0);

        //                        if (m_MaxImageSize < stFrameData.stImageData[i].nDataLen)
        //                        {
        //                            Link.depth.m_pcDataBuf = new byte[stFrameData.stImageData[i].nDataLen];
        //                            m_MaxImageSize = stFrameData.stImageData[i].nDataLen;
        //                        }

        //                        Marshal.Copy(stFrameData.stImageData[i].pData, Link.depth.m_pcDataBuf, 0, (int)stFrameData.stImageData[i].nDataLen);
        //                        Monitor.Exit(Link.depth.Lock);
        //                    }
        //                }
        //                Link.depth._lastRenderTime = DateTime.Now;
        //            }
        //        }
        //    }
        //}
    }
}
