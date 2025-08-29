using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Basler.Pylon;
using MvCamCtrl.NET;
using OpenCvSharp;
using Sunny.UI;
using Sunny.UI.Win32;

namespace m_CTP
{
    public partial class Depth_Set : UIPage
    {
        private delegate void StartDevGrad(string str) ;
        private delegate void StopDevGrad(string str);
       
        public static UInt32 m_MaxImageSize = 1024 * 1024 * 30;
     
        public Depth_Set()
        {
            InitializeComponent();
            Depth.PylonimgDraw = pictureBox1;
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
           ControlStyles.AllPaintingInWmPaint |
         ControlStyles.UserPaint, true);

            // 强制PictureBox启用双缓冲
            typeof(PictureBox).GetProperty("DoubleBuffered",
                BindingFlags.Instance | BindingFlags.NonPublic)
                .SetValue(pictureBox1, true, null);
        }

        private void Hyper_Set_Load(object sender, EventArgs e)
        {

        }

        public void OpenDepth_Click(object sender, EventArgs e)
        {
          
            string exposure = "";
            string gain = "";
            Link.depth.OpenDepth();
            Link.depth.Get_par(out exposure,
                out gain);
        }
      

      

        
        private void SaveSet_Click(object sender, EventArgs e)
        {
            Link.depth.Set_Par(cbExposure.Text, cbGain.Text);
            //try
            //{
            //    float.Parse(cbExposure.Text);
            //    float.Parse(cbGain.Text);
            //}
            //catch
            //{
            //    ShowErrorMsg("Please enter correct type!", 0);
            //    return;
            //}
            //bool bHasError = false;

            //MV3D_RGBD_PARAM pstValue = new MV3D_RGBD_PARAM();

            //pstValue.enParamType = Mv3dRgbdSDK.ParamType_Float;
            //MV3D_RGBD_FLOATPARAM floatParam = new MV3D_RGBD_FLOATPARAM();

            //floatParam.fCurValue = float.Parse(cbExposure.Text);
            //pstValue.set_floatparam(floatParam);
            //int nRet = Mv3dRgbdSDK.MV3D_RGBD_SetParam(Link.depth.m_handle, Mv3dRgbdSDK.MV3D_RGBD_FLOAT_EXPOSURETIME, pstValue);
            //if (Mv3dRgbdSDK.MV3D_RGBD_OK != nRet)
            //{
            //    bHasError = true;
            //    ShowErrorMsg("Set Exposure Time Fail!", nRet);
            //}

            //floatParam.fCurValue = float.Parse(cbGain.Text);
            //pstValue.set_floatparam(floatParam);
            //nRet = Mv3dRgbdSDK.MV3D_RGBD_SetParam(Link.depth.m_handle, Mv3dRgbdSDK.MV3D_RGBD_FLOAT_GAIN, pstValue);
            //if (Mv3dRgbdSDK.MV3D_RGBD_OK != nRet)
            //{
            //    bHasError = true;
            //    ShowErrorMsg("Set Gain Fail!", nRet);
            //}

            //if (false == bHasError)
            //{
            //    string errorMsg = "Set Para Success!";
            //    MessageBox.Show(errorMsg, "INFO");
            //}
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

        public void CloseDepth_Click(object sender, EventArgs e)
        {
           Link.depth.CloseDepth(pictureBox1); 
           
        }

        
        private void Hyper_Set_Initialize(object sender, EventArgs e)
        {

        }



        public void StartPreview_Click(object sender, EventArgs e)
        {
            Link.depth.StopPreview();
            Link.depth.StartPreview(pictureBox1);
            

        }

        public void StopPreview_Click(object sender, EventArgs e)
        {
            Link.depth.m_bGrabbing = false; 

           
            Link.depth.StopPreview();
            //Link.depth.CloseDepth();

        }
       
        private void bnEnum_Click(object sender, EventArgs e)
        {
            Link.depth.DeviceListAcq(cbDevice);
        }
       
      
        private void bnGet_Click(object sender, EventArgs e)
        {
            string exposure, gain;

            Link.depth.Get_par(
                out exposure,
                out gain
                
            );

            // 更新UI
            cbExposure.Text = exposure;
            cbGain.Text = gain;
          
           

        }

    
        private void bnSave_Click(object sender, EventArgs e)
        {
            int nRet = (int)Link.depth.SaveImage(Mv3dRgbdSDK.FileType_TIFF, HyperPath.Text.Trim());
            //if (Mv3dRgbdSDK.MV3D_RGBD_OK != nRet)
            //{
            //    ShowErrorMsg("SaveImage failed!", 0);
            //    return;
            //}

            //ShowErrorMsg("Save tiff image success!", 0);

        }

        private void uiButton1_Click(object sender, EventArgs e)
        {

            Link.depth.softStartPreview(pictureBox1);
            //int nRet = (int)Mv3dRgbdSDK.MV3D_RGBD_SoftTrigger(Link.depth.m_handle);
            //if (Mv3dRgbdSDK.MV3D_RGBD_OK != nRet)
            //{
            //    ShowErrorMsg("MV3D_RGBD_SoftTrigger failed!", 0);
            //    return;
            //}

            //ShowErrorMsg("MV3D_RGBD_SoftTrigger  success!", 0);
        }



        //private uint SaveImage(uint nFileType)
        //{
        //    int nRet = (int)Mv3dRgbdSDK.MV3D_RGBD_OK;

        //    // 新增：从 HyperPath 文本框获取路径
        //    string savePath = HyperPath.Text.Trim();
        //    if (string.IsNullOrEmpty(savePath))
        //    {
        //        ShowErrorMsg("保存路径不能为空！", 0);
        //         return Mv3dRgbdSDK.MV3D_RGBD_E_CALLORDER;
        //    }

        //    // 新增：根据文件类型自动添加扩展名（需与 nFileType 匹配）

        //    savePath = Path.Combine(savePath, $"Image_{DateTime.Now:yyyyMMdd_HHmmss}");

        //    /*if (!m_bGrabbing)
        //    {
        //        ShowErrorMsg("未开始采集！", 0);
        //        return Mv3dRgbdSDK.MV3D_RGBD_E_CALLORDER;
        //    }*/

        //    if (0 == Link.depth.m_stImageInfo.nDataLen)
        //    {
        //        ShowErrorMsg("无图像数据！", 0);
        //        return Mv3dRgbdSDK.MV3D_RGBD_E_NODATA;
        //    }

        //    Monitor.Enter(Link.depth.Lock);
        //    // 修改：将路径参数替换为 savePath
        //    nRet = Mv3dRgbdSDK.MV3D_RGBD_SaveImage(Link.depth.m_handle, Link.depth.m_stImageInfo, nFileType, savePath);
        //    Monitor.Exit(Link.depth.Lock);

        //    if (Mv3dRgbdSDK.MV3D_RGBD_OK != nRet)
        //    {
        //        ShowErrorMsg($"保存失败: 错误代码 {nRet}", 0);
        //    }
        //    else
        //    {
        //        // 新增：成功提示（可选）
        //        MessageBox.Show($"图片已保存至:\n{savePath}");
        //    }

        //    return (uint)nRet;
        //}

        //private uint SaveImage(uint nFileType)
        //{
        //    int nRet = (int)Mv3dRgbdSDK.MV3D_RGBD_OK;

        //    if (!m_bGrabbing)
        //    {
        //        ShowErrorMsg("no start work!", 0);
        //        return Mv3dRgbdSDK.MV3D_RGBD_E_CALLORDER;
        //    }

        //    if (0 == m_stImageInfo.nDataLen)
        //    {
        //        ShowErrorMsg("no data!", 0);
        //        return Mv3dRgbdSDK.MV3D_RGBD_E_NODATA;
        //    }
        //MV3D_RGBD_PARAM pstValue = new MV3D_RGBD_PARAM();

        //pstValue.enParamType = Mv3dRgbdSDK.ParamType_Float;
        //MV3D_RGBD_FLOATPARAM floatParam = new MV3D_RGBD_FLOATPARAM();

        //int nRet = Mv3dRgbdSDK.MV3D_RGBD_GetParam(Link.depth.m_handle, Mv3dRgbdSDK.MV3D_RGBD_FLOAT_EXPOSURETIME, pstValue);
        //if (Mv3dRgbdSDK.MV3D_RGBD_OK != nRet)
        //{
        //    ShowErrorMsg("Get Exposure Time Fail!", nRet);
        //}
        //else
        //{
        //    floatParam = pstValue.get_floatparam();
        //    cbExposure.Text = floatParam.fCurValue.ToString("F1");
        //}

        //nRet = Mv3dRgbdSDK.MV3D_RGBD_GetParam(Link.depth.m_handle, Mv3dRgbdSDK.MV3D_RGBD_FLOAT_GAIN, pstValue);
        //if (Mv3dRgbdSDK.MV3D_RGBD_OK != nRet)
        //{
        //    ShowErrorMsg("Get Gain Fail!", nRet);
        //}
        //else
        //{
        //    floatParam = pstValue.get_floatparam();
        //    cbGain.Text = floatParam.fCurValue.ToString("F1");
        //}
        //    Monitor.Enter(Lock);
        //    nRet = Mv3dRgbdSDK.MV3D_RGBD_SaveImage(m_handle, m_stImageInfo, nFileType, "");
        //    Monitor.Exit(Lock);
        //    if (Mv3dRgbdSDK.MV3D_RGBD_OK != nRet)
        //    {
        //        ShowErrorMsg("SaveImage failed", 0);
        //    }

        //    return (uint)nRet;
        //}
        //public void DeviceListAcq()
        //{
        //    // ch:创建设备列表 | en:Create Device List
        //    System.GC.Collect();
        //    cbDevice.Items.Clear();
        //    //Link.depth.m_nDevNum;
        //    int nRet = Mv3dRgbdSDK.MV3D_RGBD_GetDeviceNumber(Mv3dRgbdSDK.DeviceType_Ethernet | Mv3dRgbdSDK.DeviceType_USB | Mv3dRgbdSDK.DeviceType_Ethernet_Vir | Mv3dRgbdSDK.DeviceType_USB_Vir, ref Link.depth.m_nDevNum);

        //    Link.depth.m_stVector = new MV3D_RGBD_DEVICE_INFO_VECTOR((int)Link.depth.m_nDevNum);
        //    for (UInt32 i = 0; i < Link.depth.m_nDevNum; i++)
        //    {
        //        Link.depth.m_stVector.Add(new MV3D_RGBD_DEVICE_INFO());
        //    }

        //    // ch:获取网络中设备信息 | en:Enumerate all devices within net
        //    nRet = Mv3dRgbdSDK.MV3D_RGBD_GetDeviceList(Mv3dRgbdSDK.DeviceType_Ethernet | Mv3dRgbdSDK.DeviceType_USB | Mv3dRgbdSDK.DeviceType_Ethernet_Vir | Mv3dRgbdSDK.DeviceType_USB_Vir, Link.depth.m_stVector[0], Link.depth.m_nDevNum, ref Link.depth.m_nDevNum);
        //    if (0 != nRet)
        //    {
        //        ShowErrorMsg("Enumerate devices fail!", nRet);
        //        return;
        //    }

        //    // ch:在窗体列表中显示设备名 | en:Display device name in the form list
        //    for (int i = 0; i < Link.depth.m_nDevNum; i++)
        //    {
        //        string strSerialNumber = Link.depth.m_stVector[i].chSerialNumber;// System.Text.Encoding.Default.GetString(m_stVector[i].chSerialNumber);
        //        strSerialNumber = strSerialNumber.TrimEnd('\0');

        //        string strModelName = Link.depth.m_stVector[i].chModelName;
        //        strModelName = strModelName.TrimEnd('\0');

        //        if (Mv3dRgbdSDK.DeviceType_Ethernet == Link.depth.m_stVector[i].enDeviceType || Mv3dRgbdSDK.DeviceType_Ethernet_Vir == Link.depth.m_stVector[i].enDeviceType)
        //        {
        //            string strCurrentIp = Link.depth.m_stVector[i].get_netinfo().chCurrentIp;
        //            strCurrentIp = strCurrentIp.TrimEnd('\0');

        //            cbDevice.Items.Add("DEV:" + "Name:" + strModelName + " " + "IP:" + strCurrentIp + " " + "SerialNum:" + strSerialNumber);
        //        }
        //        else  if (Mv3dRgbdSDK.DeviceType_USB == Link.depth.m_stVector[i].enDeviceType || Mv3dRgbdSDK.DeviceType_USB_Vir == Link.depth.m_stVector[i].enDeviceType)
        //        {
        //            string strUsbProtocol = Convert.ToString(Link.depth.m_stVector[i].get_usbinfo().enUsbProtocol);
        //            strUsbProtocol = strUsbProtocol.TrimEnd('\0');

        //            cbDevice.Items.Add("USB:" + "Name:" + strModelName + " " + "UsbProtocol:" + strUsbProtocol + " " + "SerialNum:" + strSerialNumber);
        //        }

        //    }

        //    // ch:选择第一项 | en:Select the first item
        //    if (Link.depth.m_nDevNum != 0)
        //    {
        //        cbDevice.SelectedIndex = 0;
        //    }


        //}
        //static void OnImageGrabbed(Object sender, ImageGrabbedEventArgs e)//数据流回调函数
        //{
        //    // The grab result is automatically disposed when the event call back returns.
        //    // The grab result can be cloned using IGrabResult.Clone if you want to keep a copy of it (not shown in this sample).
        //    IGrabResult grabResult = e.GrabResult;
        //    // Image grabbed successfully?
        //    if (grabResult.GrabSucceeded)
        //    {


        //        hyperCamera.receiveGrabResult(grabResult); // 首先需要接收抓取的一帧数据结果，之后才能运行下面的获取最大值和获取光谱图像
        //        int maxSpecValue = hyperCamera.getMaxSpectralValue();
        //        // _label17.Text = Convert.ToString(maxSpecValue);//将数值赋值给label

        //        Mat rgb_mat = hyperCamera.getColormap();
        //        System.Drawing.Image drawImage = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(rgb_mat);
        //        //德会修改建立委托
        //        //Graphics g1 = PylonimgDraw.CreateGraphics();//画布
        //        ////g1.Clear(Color.White);
        //        //g1.DrawImage(drawImage, new PointF(0, 0));
        //        //drawImage.Dispose();
        //        //g1.Dispose();
        //        //g1 = null;
        //        //e.Graphics.DrawImage(drawImage, drawImageStartPos);
        //        PylonimgDraw.Invoke(new MethodInvoker(() =>
        //        {
        //            Graphics g1 = PylonimgDraw.CreateGraphics();//画布
        //            //g1.Clear(Color.White);
        //            g1.DrawImage(drawImage, new PointF(0, 0));
        //            drawImage.Dispose();
        //            g1.Dispose();
        //            g1 = null;
        //        }));
        //        hyperCamera.writeToFile();
        //    }
        //    else
        //    {
        //        Console.WriteLine("Error: {0} {1}", grabResult.ErrorCode, grabResult.ErrorDescription);
        //    }
        //}
        //private void StopPreview_Click(object sender, EventArgs e)
        //{
        //    // 标志位立即停止采集
        //    m_bGrabbing = false;

        //    // 安全防护1：检查线程对象有效性
        //    if (m_hReceiveThread != null && m_hReceiveThread.IsAlive)
        //    {
        //        try
        //        {
        //            // 安全防护2：设置超时等待（防止死锁）
        //            if (!m_hReceiveThread.Join(2000)) // 最多等待2秒
        //            {
        //                // 安全防护3：强制中止（慎用）
        //                m_hReceiveThread.Abort();
        //            }
        //        }
        //        finally
        //        {
        //            // 释放线程对象
        //            m_hReceiveThread = null;
        //        }
        //    }

        //    // 停止SDK采集
        //    int nRet = Mv3dRgbdSDK.MV3D_RGBD_Stop(m_handle);
        //    if (0 != nRet)
        //    {
        //        ShowErrorMsg("Stop Grabbing Fail!", nRet);
        //    }
        //}
        //private void ShowErrorMsg(string csMessage, int nErrorNum)
        //{
        //    string errorMsg;
        //    if (nErrorNum == 0)
        //    {
        //        errorMsg = csMessage;
        //    }
        //    else
        //    {
        //        errorMsg = csMessage + ": Error =" + String.Format("{0:X}", nErrorNum);
        //    }

        //    switch ((uint)nErrorNum)
        //    {
        //        case Mv3dRgbdSDK.MV3D_RGBD_E_HANDLE: errorMsg += " Error or invalid handle "; break;
        //        case Mv3dRgbdSDK.MV3D_RGBD_E_SUPPORT: errorMsg += " Not supported function "; break;
        //        case Mv3dRgbdSDK.MV3D_RGBD_E_BUFOVER: errorMsg += " Cache is full "; break;
        //        case Mv3dRgbdSDK.MV3D_RGBD_E_CALLORDER: errorMsg += " Function calling order error "; break;
        //        case Mv3dRgbdSDK.MV3D_RGBD_E_PARAMETER: errorMsg += " Incorrect parameter "; break;
        //        case Mv3dRgbdSDK.MV3D_RGBD_E_RESOURCE: errorMsg += " Applying resource failed "; break;
        //        case Mv3dRgbdSDK.MV3D_RGBD_E_NODATA: errorMsg += " No data "; break;
        //        case Mv3dRgbdSDK.MV3D_RGBD_E_PRECONDITION: errorMsg += " Precondition error, or running environment changed "; break;
        //        case Mv3dRgbdSDK.MV3D_RGBD_E_VERSION: errorMsg += " Version mismatches "; break;
        //        case Mv3dRgbdSDK.MV3D_RGBD_E_NOENOUGH_BUF: errorMsg += " Insufficient memory "; break;
        //        case Mv3dRgbdSDK.MV3D_RGBD_E_ABNORMAL_IMAGE: errorMsg += " error image "; break;
        //        case Mv3dRgbdSDK.MV3D_RGBD_E_LOAD_LIBRARY: errorMsg += " load dll  error "; break;
        //        case Mv3dRgbdSDK.MV3D_RGBD_E_UNKNOW: errorMsg += " Unknown error "; break;
        //    }

        //    MessageBox.Show(errorMsg, "PROMPT");
        //}
        //public void ReceiveThreadProcess(CancellationToken token)
        //{
        //    int nRet = (int)Mv3dRgbdSDK.MV3D_RGBD_OK;

        //    while (!token.IsCancellationRequested && (this.Visible))
        //    {
        //        MV3D_RGBD_FRAME_DATA stFrameData = new MV3D_RGBD_FRAME_DATA();
        //        nRet = Mv3dRgbdSDK.MV3D_RGBD_FetchFrame(Link.depth.m_handle, stFrameData, 1000);


        //        if (0 == nRet)
        //        {
        //            // 线程安全渲染
        //            RenderFrameSafely(stFrameData);
        //        }

        //        // 释放资源
        //        Mv3dRgbdSDK.MV3D_RGBD_Release();
        //        //token.ThrowIfCancellationRequested();
        //        //Mv3dRgbdSDK.MV3D_RGBD_FreeFrame(m_handle, ref stFrameData);
        //    }
        //}
        //public void RenderFrameSafely(MV3D_RGBD_FRAME_DATA stFrameData)
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
        //
        //
        //                        (Link.depth.Lock);
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
