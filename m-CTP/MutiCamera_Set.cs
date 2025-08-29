using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EDSDKLib;
using Sunny.UI;
using Canondemo;
using System.Runtime.InteropServices;
using MvCamCtrl.NET;
using BasicDemo;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Text.RegularExpressions;
using System.Threading;
using Basler.Pylon;
using System.Drawing.Imaging;
using System.Reflection;
using System.Diagnostics;
using System.Globalization;
using NPOI.SS.Formula.Functions;

namespace m_CTP
{
    public partial class MutiCamera_Set : UIPage
    {

        public static RgbCamera rgbCamera;
      
        public string savepicture = "jpg";
     
       
        public MutiCamera_Set()
        {
            InitializeComponent();
            camera1.HandleCreated += (sender, e) => {
                camera1.Invoke((MethodInvoker)delegate {
                    Link.ca1 = camera1;
                    // 更新UI的代码
                });
            };
            camera2.HandleCreated += (sender, e) => {
                camera2.Invoke((MethodInvoker)delegate {
                    Link.ca2 = camera2;
                    // 更新UI的代码
                });
            };
        }
        public MutiCamera_Set( PictureBox pictureBox1,  PictureBox pictureBox2)
        {
            InitializeComponent();
            //camera1.Invoke(new MethodInvoker(() =>
            //{
            //   // pictureBox1 = camera1 ;
            //}));
            camera1.HandleCreated += (sender, e) => {
                camera1.Invoke((MethodInvoker)delegate {
                     pictureBox1 = camera1 ;
                    // 更新UI的代码
                });
            };
            camera2.HandleCreated += (sender, e) => {
                camera2.Invoke((MethodInvoker)delegate {
                    pictureBox2 = camera2;
                    // 更新UI的代码
                });
            };
            //camera2.Invoke(new MethodInvoker(() =>
            //{
            //   // pictureBox2 = camera2;
            //}));
            //camera1.Invoke
            // InitializeComponent();
            //m_pDeviceInfo = new MyCamera.MV_CC_DEVICE_INFO[2];
            //m_nFrames = new int[2];
            //Link.mutiCamera.cbImage = new MyCamera.cbOutputExdelegate(ImageCallBack);
            //for (int i = 0; i < 2; ++i)
            //{
            //    m_BufForSaveImageLock[i] = new Object();
            //}


        }
        //private void DeviceListAcq()
        //{

        //    System.GC.Collect();
        //    int nRet = MyCamera.MV_CC_EnumDevices_NET(MyCamera.MV_GIGE_DEVICE | MyCamera.MV_USB_DEVICE, ref m_stDeviceList);
        //    if (0 != nRet)
        //    {
        //        ShowErrorMsg("Enumerate devices fail!", nRet);
        //        return;
        //    }

        //    m_nDevNum = m_stDeviceList.nDeviceNum;



        //}




        //错误信息
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
       
        //public void savepng()
        //{
        //    string basePath = textBoxPicturePath.Text.Trim();
        //    if (string.IsNullOrEmpty(basePath))
        //    {
        //        ShowErrorMsg("保存路径不能为空！", 0);
        //        return;
        //    }

        //    // 确保目录存在
        //    if (!Directory.Exists(basePath))
        //    {
        //        try
        //        {
        //            Directory.CreateDirectory(basePath);
        //        }
        //        catch (Exception ex)
        //        {
        //            ShowErrorMsg($"创建目录失败: {ex.Message}", 0);
        //            return;
        //        }
        //    }

        //    DateTime timestamp = DateTime.Now;

        //    for (int i = 0; i < m_nCanOpenDevNum; ++i)
        //    {
        //        MyCamera.MV_SAVE_IMG_TO_FILE_PARAM stSaveParam = new MyCamera.MV_SAVE_IMG_TO_FILE_PARAM();
        //        lock (m_BufForSaveImageLock[i])
        //        {
        //            if (m_stFrameInfo[i].nFrameLen == 0)
        //            {
        //                ShowErrorMsg($"No.{i} save image failed! No data!\r\n", 0);
        //                continue;
        //            }
        //            stSaveParam.enImageType = MyCamera.MV_SAVE_IAMGE_TYPE.MV_Image_Png;
        //            stSaveParam.enPixelType = m_stFrameInfo[i].enPixelType;
        //            stSaveParam.pData = m_pSaveImageBuf[i];
        //            stSaveParam.nDataLen = m_stFrameInfo[i].nFrameLen;
        //            stSaveParam.nHeight = m_stFrameInfo[i].nHeight;
        //            stSaveParam.nWidth = m_stFrameInfo[i].nWidth;
        //            stSaveParam.nQuality = 80;
        //            // 生成唯一的带有时间戳的文件名
        //            string timestampStr = timestamp.ToString("yyyyMMdd_HHmmssfff", CultureInfo.InvariantCulture);
        //            string fileName = $"Dev{i}_Image_w{stSaveParam.nWidth}_h{stSaveParam.nHeight}_fn{m_stFrameInfo[i].nFrameNum}_{timestampStr}.png";

        //            // 使用Path.Combine构建完整路径
        //            stSaveParam.pImagePath = Path.Combine(basePath, fileName);

        //            int nRet = m_pMyCamera[i].MV_CC_SaveImageToFile_NET(ref stSaveParam);
        //            if (MyCamera.MV_OK != nRet)
        //            {
        //                ShowErrorMsg($"No.{i} save image failed! nRet=0x{nRet:X8}\r\n", 0);
        //            }
        //            else
        //            {
        //                ShowErrorMsg($"No.{i} save bmp image succeeded! File: {stSaveParam.pImagePath}\r\n", 0);
        //            }
        //        }

        //    }
        //}
        //public void savejpg()
        //{
        //    string basePath = textBoxPicturePath.Text.Trim();
        //    if (string.IsNullOrEmpty(basePath))
        //    {
        //        ShowErrorMsg("保存路径不能为空！", 0);
        //        return;
        //    }

        //    // 确保目录存在
        //    if (!Directory.Exists(basePath))
        //    {
        //        try
        //        {
        //            Directory.CreateDirectory(basePath);
        //        }
        //        catch (Exception ex)
        //        {
        //            ShowErrorMsg($"创建目录失败: {ex.Message}", 0);
        //            return;
        //        }
        //    }

        //    DateTime timestamp = DateTime.Now;

        //    for (int i = 0; i < m_nCanOpenDevNum; ++i)
        //    {
        //        MyCamera.MV_SAVE_IMG_TO_FILE_PARAM stSaveParam = new MyCamera.MV_SAVE_IMG_TO_FILE_PARAM();
        //        lock (m_BufForSaveImageLock[i])
        //        {
        //            if (m_stFrameInfo[i].nFrameLen == 0)
        //            {
        //                ShowErrorMsg($"No.{i} save image failed! No data!\r\n", 0);
        //                continue;
        //            }

        //            stSaveParam.enImageType = MyCamera.MV_SAVE_IAMGE_TYPE.MV_Image_Tif;
        //            stSaveParam.enPixelType = m_stFrameInfo[i].enPixelType;
        //            stSaveParam.pData = m_pSaveImageBuf[i];
        //            stSaveParam.nDataLen = m_stFrameInfo[i].nFrameLen;
        //            stSaveParam.nHeight = m_stFrameInfo[i].nHeight;
        //            stSaveParam.nWidth = m_stFrameInfo[i].nWidth;
        //            //stSaveParam.iMethodValue = 90;

        //            // 生成唯一的带有时间戳的文件名
        //            string timestampStr = timestamp.ToString("yyyyMMdd_HHmmssfff", CultureInfo.InvariantCulture);
        //            string fileName = $"Dev{i}_Image_w{stSaveParam.nWidth}_h{stSaveParam.nHeight}_fn{m_stFrameInfo[i].nFrameNum}_{timestampStr}.jpg";

        //            // 使用Path.Combine构建完整路径
        //            stSaveParam.pImagePath = Path.Combine(basePath, fileName);

        //            int nRet = m_pMyCamera[i].MV_CC_SaveImageToFile_NET(ref stSaveParam);
        //            if (MyCamera.MV_OK != nRet)
        //            {
        //                ShowErrorMsg($"No.{i} save image failed! nRet=0x{nRet:X8}\r\n", 0);
        //            }
        //            else
        //            {
        //                ShowErrorMsg($"No.{i} save bmp image succeeded! File: {stSaveParam.pImagePath}\r\n", 0);
        //            }
        //        }
        //    }





        //}
        //public void savetiff()
        //{
        //    string basePath = textBoxPicturePath.Text.Trim();
        //    if (string.IsNullOrEmpty(basePath))
        //    {
        //        ShowErrorMsg("保存路径不能为空！", 0);
        //        return;
        //    }

        //    // 确保目录存在
        //    if (!Directory.Exists(basePath))
        //    {
        //        try
        //        {
        //            Directory.CreateDirectory(basePath);
        //        }
        //        catch (Exception ex)
        //        {
        //            ShowErrorMsg($"创建目录失败: {ex.Message}", 0);
        //            return;
        //        }
        //    }

        //    DateTime timestamp = DateTime.Now;

        //    for (int i = 0; i < m_nCanOpenDevNum; ++i)
        //    {
        //        MyCamera.MV_SAVE_IMG_TO_FILE_PARAM stSaveParam = new MyCamera.MV_SAVE_IMG_TO_FILE_PARAM();
        //        lock (m_BufForSaveImageLock[i])
        //        {
        //            if (m_stFrameInfo[i].nFrameLen == 0)
        //            {
        //                ShowErrorMsg($"No.{i} save image failed! No data!\r\n", 0);
        //                continue;
        //            }
        //            stSaveParam.enImageType = MyCamera.MV_SAVE_IAMGE_TYPE.MV_Image_Tif;
        //            stSaveParam.enPixelType = m_stFrameInfo[i].enPixelType;
        //            stSaveParam.pData = m_pSaveImageBuf[i];
        //            stSaveParam.nDataLen = m_stFrameInfo[i].nFrameLen;
        //            stSaveParam.nHeight = m_stFrameInfo[i].nHeight;
        //            stSaveParam.nWidth = m_stFrameInfo[i].nWidth;
        //            //stSaveParam.iMethodValue = 90;
        //            // 生成唯一的带有时间戳的文件名
        //            string timestampStr = timestamp.ToString("yyyyMMdd_HHmmssfff", CultureInfo.InvariantCulture);
        //            string fileName = $"Dev{i}_Image_w{stSaveParam.nWidth}_h{stSaveParam.nHeight}_fn{m_stFrameInfo[i].nFrameNum}_{timestampStr}.tiff";

        //            // 使用Path.Combine构建完整路径
        //            stSaveParam.pImagePath = Path.Combine(basePath, fileName);

        //            int nRet = m_pMyCamera[i].MV_CC_SaveImageToFile_NET(ref stSaveParam);
        //            if (MyCamera.MV_OK != nRet)
        //            {
        //                ShowErrorMsg($"No.{i} save image failed! nRet=0x{nRet:X8}\r\n", 0);
        //            }
        //            else
        //            {
        //                ShowErrorMsg($"No.{i} save bmp image succeeded! File: {stSaveParam.pImagePath}\r\n", 0);
        //            }
        //        }
        //    }


        //}
        

        //public void savebmp()
        //{
        //    // 从文本框获取并验证路径
        //    string basePath = textBoxPicturePath.Text.Trim();
        //    if (string.IsNullOrEmpty(basePath))
        //    {
        //        ShowErrorMsg("保存路径不能为空！", 0);
        //        return;
        //    }

        //    // 确保目录存在
        //    if (!Directory.Exists(basePath))
        //    {
        //        try
        //        {
        //            Directory.CreateDirectory(basePath);
        //        }
        //        catch (Exception ex)
        //        {
        //            ShowErrorMsg($"创建目录失败: {ex.Message}", 0);
        //            return;
        //        }
        //    }

        //    DateTime timestamp = DateTime.Now;

        //    for (int i = 0; i < m_nCanOpenDevNum; ++i)
        //    {
        //        MyCamera.MV_SAVE_IMG_TO_FILE_PARAM stSaveParam = new MyCamera.MV_SAVE_IMG_TO_FILE_PARAM();
        //        lock (m_BufForSaveImageLock[i])
        //        {
        //            if (m_stFrameInfo[i].nFrameLen == 0)
        //            {
        //                ShowErrorMsg($"No.{i} save image failed! No data!\r\n", 0);
        //                continue;
        //            }

        //            stSaveParam.enImageType = MyCamera.MV_SAVE_IAMGE_TYPE.MV_Image_Bmp;
        //            stSaveParam.enPixelType = m_stFrameInfo[i].enPixelType;
        //            stSaveParam.pData = m_pSaveImageBuf[i];
        //            stSaveParam.nDataLen = m_stFrameInfo[i].nFrameLen;
        //            stSaveParam.nHeight = m_stFrameInfo[i].nHeight;
        //            stSaveParam.nWidth = m_stFrameInfo[i].nWidth;

        //            // 生成唯一的带有时间戳的文件名
        //            string timestampStr = timestamp.ToString("yyyyMMdd_HHmmssfff", CultureInfo.InvariantCulture);
        //            string fileName = $"Dev{i}_Image_w{stSaveParam.nWidth}_h{stSaveParam.nHeight}_fn{m_stFrameInfo[i].nFrameNum}_{timestampStr}.bmp";

        //            // 使用Path.Combine构建完整路径
        //            stSaveParam.pImagePath = Path.Combine(basePath, fileName);

        //            int nRet = m_pMyCamera[i].MV_CC_SaveImageToFile_NET(ref stSaveParam);
        //            if (MyCamera.MV_OK != nRet)
        //            {
        //                ShowErrorMsg($"No.{i} save image failed! nRet=0x{nRet:X8}\r\n", 0);
        //            }
        //            else
        //            {
        //                ShowErrorMsg($"No.{i} save bmp image succeeded! File: {stSaveParam.pImagePath}\r\n", 0);
        //            }
        //        }
        //    }
        //}
        public void buttonCapture_Click(object sender, EventArgs e)//单张RGB图像采集
        {
            savepicture = "jpg"; 
            if (savepicture == "bmp")
            {
                Link.mutiCamera.savebmp(textBoxPicturePath.Text.Trim());

            }
            else if (savepicture == "png")
            {
                Link.mutiCamera.savepng(textBoxPicturePath.Text.Trim());

            }
            else if (savepicture == "jpg")
            {
                Link.mutiCamera.SaveImage(textBoxPicturePath.Text.Trim());
            }
            else
            {
                Link.mutiCamera.savetiff(textBoxPicturePath.Text.Trim());
            }



            //if (savepicture == "bmp")
            //{
            //    savebmp();

            //}
            //else if (savepicture == "png")
            //{
            //    savepng();

            //}
            //else
            //{
            //    savetiff();
            //}

        }


        private void cbExposure_SelectedIndexChanged(object sender, EventArgs e)//设置光圈
        {
            int i = 0;
            foreach (aCamera ac in rgbCamera.aCameraList)
            {
                //listViewCaminfo.Items[i].SubItems[3].Text = cbISO.Text;
                //ac.Aperture = rgbCamera.avarray[cbISO.SelectedIndex].AV;
                //ac.SetLV_Aperture(rgbCamera.GetTargetApture(ac.Aperture));
                //i++;
            }
        }

        private void cbISO_SelectedIndexChanged(object sender, EventArgs e)//设置增益
        {
            int i = 0;
            foreach (aCamera ac in rgbCamera.aCameraList)
            {
                //listViewCaminfo.Items[i].SubItems[4].Text = cbISO.Text;
                //ac.ISO = rgbCamera.isoarray[cbISO.SelectedIndex].ISOSpeed;
                //ac.SetLV_ISO(rgbCamera.GetTargetISO(ac.ISO));
                //i++;
            }
        }

        private void buttonOpenfolder_Click(object sender, EventArgs e)//打开RGB文件存储位置
        {
            if (textBoxPicturePath.Text != string.Empty)
            {
                try
                {
                    System.Diagnostics.Process.Start("explorer", textBoxPicturePath.Text);
                }
                catch (Exception ex)
                {
                    //listBox1.Items.Add(ex.Message);
                }
            }
        }

        private void buttonChoosePath_Click(object sender, EventArgs e)//选择存储路径
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择文件路径";
            dialog.RootFolder = Environment.SpecialFolder.Desktop;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var selectFolder = dialog.SelectedPath;
                textBoxCapname.Text = dialog.SelectedPath;
            }
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void SetSavepath_Click(object sender, EventArgs e)//设置存储路径
        {
            textBoxPicturePath.Text = textBoxCapname.Text;
        }


        private void cbShutterSpeed_Scroll(object sender, ScrollEventArgs e)
        {

        }

        public void search_Click(object sender, EventArgs e)
        {
            Link.mutiCamera.search(cbDeviceList1,cbDeviceList2);
            //Link.mutiCamera.search();
            //System.GC.Collect();
            //cbDeviceList.Items.Clear();
            //cbDeviceList1.Items.Clear();
            //cbDeviceList2.Items.Clear();
            //m_stDeviceList.nDeviceNum = 0;
            ////m_nDevNum = 0;


            //int nRet = MyCamera.MV_CC_EnumDevices_NET(MyCamera.MV_GIGE_DEVICE | MyCamera.MV_USB_DEVICE | MyCamera.MV_GENTL_GIGE_DEVICE
            //    | MyCamera.MV_GENTL_CAMERALINK_DEVICE | MyCamera.MV_GENTL_CXP_DEVICE | MyCamera.MV_GENTL_XOF_DEVICE, ref m_stDeviceList);
            //if (0 != nRet)
            //{
            //    ShowErrorMsg("Fail to GetDeviceNumber!!", 0);
            //}
            //m_nDevNum = m_stDeviceList.nDeviceNum;


            ////m_stVector = new MV3D_RGBD_DEVICE_INFO_VECTOR((int)m_nDevNum);
            //for (int i = 0; i < m_nDevNum; i++)
            //{
            //    int j = 0;
            //    //m_stVector.Add(new MV3D_RGBD_DEVICE_INFO());
            //    MyCamera.MV_CC_DEVICE_INFO device = (MyCamera.MV_CC_DEVICE_INFO)Marshal.PtrToStructure(m_stDeviceList.pDeviceInfo[i], typeof(MyCamera.MV_CC_DEVICE_INFO));
            //    string strUserDefinedName = "";
            //    string strSerialNumber = "";
            //    //= m_stVector[i].chSerialNumber;
            //    //strSerialNumber = strSerialNumber.TrimEnd('\0');
            //    if (device.nTLayerType == MyCamera.MV_GIGE_DEVICE)
            //    {
            //        MyCamera.MV_GIGE_DEVICE_INFO_EX gigeInfo = (MyCamera.MV_GIGE_DEVICE_INFO_EX)MyCamera.ByteToStruct(device.SpecialInfo.stGigEInfo, typeof(MyCamera.MV_GIGE_DEVICE_INFO_EX));

            //        if ((gigeInfo.chUserDefinedName.Length > 0) && (gigeInfo.chUserDefinedName[0] != '\0'))
            //        {
            //            if (MyCamera.IsTextUTF8(gigeInfo.chUserDefinedName))
            //            {
            //                strUserDefinedName = Encoding.UTF8.GetString(gigeInfo.chUserDefinedName).TrimEnd('\0');
            //            }
            //            else
            //            {
            //                strUserDefinedName = Encoding.Default.GetString(gigeInfo.chUserDefinedName).TrimEnd('\0');
            //            }
             //        cbDeviceList.Items.Add("GEV: " + DeleteTail(strUserDefinedName) + " (" + gigeInfo.chSerialNumber + ")");
            //        }
            //        else
            //        {
            //            cbDeviceList.Items.Add("GEV: " + gigeInfo.chManufacturerName + " " + gigeInfo.chModelName + " (" + gigeInfo.chSerialNumber + ")");
            //        }
            //        strSerialNumber = gigeInfo.chSerialNumber;
            //    }
            //    if (j == 0) // 第一个设备
            //    {
            //        cbDeviceList1.Items.Clear();
            //        cbDeviceList1.Items.Add(strSerialNumber);
            //        cbDeviceList1.SelectedIndex = 0;
            //        j++;
            //    }
            //    else if (j == 1) // 第二个设备
            //    {
            //        // 检查是否与第一个设备不同
            //        if (cbDeviceList1.Items.Count > 0 &&
            //            !cbDeviceList1.Items[0].ToString().Equals(strSerialNumber))
            //        {
            //            cbDeviceList2.Items.Clear();
            //            cbDeviceList2.Items.Add(strSerialNumber);
            //            cbDeviceList2.SelectedIndex = 0;
            //        }
            //    }
            //    //cbDeviceList1.Items.Add(strSerialNumber);
            //    //cbDeviceList2.Items.Add(strSerialNumber);

            //}



            //// ch:选择第一项 | en:Select the first item
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

        private void choose_Click(object sender, EventArgs e)
        {

            if (cbChoose.SelectedItem == null)
            {
                savepicture = "png";
            }
            else
            {
                savepicture = cbChoose.SelectedItem.ToString();
                //suc.Text = savepicture;
            }
        }
        //public void open()
        //{


        //    bool bOpened = false;
        //    // ch:判断输入格式是否正确 | en:Determine whether the input format is correct

        //    // ch:获取使用设备的数量 | en:Get Used Device Number
        //    int nCameraUsingNum = 2;
        //    for (int i = 0, j = 0; j < m_stDeviceList.nDeviceNum; j++)
        //    {
        //        //ch:获取选择的设备信息 | en:Get Selected Device Information
        //        MyCamera.MV_CC_DEVICE_INFO device =
        //            (MyCamera.MV_CC_DEVICE_INFO)Marshal.PtrToStructure(m_stDeviceList.pDeviceInfo[j], typeof(MyCamera.MV_CC_DEVICE_INFO));

        //        string StrTemp = "";
        //        string strUserDefinedName = "";

        //        if (device.nTLayerType == MyCamera.MV_GIGE_DEVICE)
        //        {
        //            MyCamera.MV_GIGE_DEVICE_INFO_EX gigeInfo = (MyCamera.MV_GIGE_DEVICE_INFO_EX)MyCamera.ByteToStruct(device.SpecialInfo.stGigEInfo, typeof(MyCamera.MV_GIGE_DEVICE_INFO_EX));

        //            if ((gigeInfo.chUserDefinedName.Length > 0) && (gigeInfo.chUserDefinedName[0] != '\0'))
        //            {
        //                if (MyCamera.IsTextUTF8(gigeInfo.chUserDefinedName))
        //                {
        //                    strUserDefinedName = Encoding.UTF8.GetString(gigeInfo.chUserDefinedName).TrimEnd('\0');
        //                }
        //                else
        //                {
        //                    strUserDefinedName = Encoding.Default.GetString(gigeInfo.chUserDefinedName).TrimEnd('\0');
        //                }
        //                StrTemp = "GEV: " + strUserDefinedName + " (" + gigeInfo.chSerialNumber + ")";
        //            }
        //            else
        //            {
        //                StrTemp = "GEV: " + gigeInfo.chManufacturerName + " " + gigeInfo.chModelName + " (" + gigeInfo.chSerialNumber + ")";
        //            }
        //        }


        //        //ch:打开设备 | en:Open Device
        //        if (null == m_pMyCamera[i])
        //        {
        //            m_pMyCamera[i] = new MyCamera();
        //            if (null == m_pMyCamera[i])
        //            {
        //                return;
        //            }
        //        }

        //        int nRet = m_pMyCamera[i].MV_CC_CreateDevice_NET(ref device);
        //        if (MyCamera.MV_OK != nRet)
        //        {
        //            return;
        //        }

        //        nRet = m_pMyCamera[i].MV_CC_OpenDevice_NET();

        //        nRet = m_pMyCamera[i].MV_CC_SetImageNodeNum_NET(bufferNodeNum);
        //        if (MyCamera.MV_OK != nRet)
        //        {
        //            ShowErrorMsg("Create device fail!", nRet);
        //            continue;
        //        }
        //        else
        //        {
        //            //richTextBox.Text += String.Format("Open Device[{0}] success!\r\n", StrTemp);

        //            m_nCanOpenDevNum++;
        //            m_pDeviceInfo[i] = device;
        //            // ch:探测网络最佳包大小(只对GigE相机有效) | en:Detection network optimal package size(It only works for the GigE camera)
        //            if (device.nTLayerType == MyCamera.MV_GIGE_DEVICE)
        //            {
        //                int nPacketSize = m_pMyCamera[i].MV_CC_GetOptimalPacketSize_NET();
        //                if (nPacketSize > 0)
        //                {
        //                    nRet = m_pMyCamera[i].MV_CC_SetIntValueEx_NET("GevSCPSPacketSize", nPacketSize);
        //                    if (nRet != MyCamera.MV_OK)
        //                    {
        //                        ShowErrorMsg("Set Packet Size failed!\r\n", nRet);
        //                    }
        //                }
        //                else
        //                {
        //                    ShowErrorMsg("Get Packet Size failed!\r\n", nRet);
        //                }
        //            }

        //            m_pMyCamera[i].MV_CC_SetEnumValue_NET("TriggerMode", (uint)MyCamera.MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_OFF);
        //            //m_pMyCamera[i].MV_CC_SetEnumValue_NET("TriggerMode",  (uint)MyCamera.MV_CAM_TRIGGER_MODE.MV_TRIGGER_SOURCE_SOFTWARE);
        //            cbImage = new MyCamera.cbOutputExdelegate(ImageCallBack);
        //            nRet = m_pMyCamera[i].MV_CC_RegisterImageCallBackEx_NET(cbImage, (IntPtr)i);
        //            if (MyCamera.MV_OK != nRet)
        //            {
        //                ShowErrorMsg(" fail!", nRet);
        //                continue;
        //            }
        //            bOpened = true;
        //            if (m_nCanOpenDevNum == nCameraUsingNum)
        //            {
        //                break;
        //            }
        //            i++;
        //        }
        //    }

        //    // ch:只要有一台设备成功打开 | en:As long as there is a device successfully opened
        //    if (bOpened)
        //    {
        //        suc.Text = "successful!";
        //        //tbUseNum.Text = m_nCanOpenDeviceNum.ToString();
        //        //SetCtrlWhenOpen();
        //    }
        //}

        public void Open_Click(object sender, EventArgs e)
        {
            Link.mutiCamera.OpenCamera();
            //open();
        }
        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    if (m_bTimerFlag)
        //    {
        //        if (m_nCanOpenDevNum > 0)
        //        {
        //            suc.Text = m_nFrames[0].ToString();
        //            //suc.Text = GetLostFrame(0);
        //        }
        //        if (m_nCanOpenDevNum > 1)
        //        {
        //            //tbGrabFrame2.Text = m_nFrames[1].ToString();
        //            //GetLostFrame(1);
        //        }

        //    }
        //}
        //private string GetLostFrame(int nIndex)
        //{
        //    MyCamera.MV_ALL_MATCH_INFO pstInfo = new MyCamera.MV_ALL_MATCH_INFO();
        //    if (m_pDeviceInfo[nIndex].nTLayerType == MyCamera.MV_GIGE_DEVICE)
        //    {
        //        MyCamera.MV_MATCH_INFO_NET_DETECT MV_NetInfo = new MyCamera.MV_MATCH_INFO_NET_DETECT();
        //        pstInfo.nInfoSize = (uint)System.Runtime.InteropServices.Marshal.SizeOf(typeof(MyCamera.MV_MATCH_INFO_NET_DETECT));
        //        pstInfo.nType = MyCamera.MV_MATCH_TYPE_NET_DETECT;
        //        int size = Marshal.SizeOf(MV_NetInfo);
        //        pstInfo.pInfo = Marshal.AllocHGlobal(size);
        //        Marshal.StructureToPtr(MV_NetInfo, pstInfo.pInfo, false);

        //        m_pMyCamera[nIndex].MV_CC_GetAllMatchInfo_NET(ref pstInfo);
        //        MV_NetInfo = (MyCamera.MV_MATCH_INFO_NET_DETECT)Marshal.PtrToStructure(pstInfo.pInfo, typeof(MyCamera.MV_MATCH_INFO_NET_DETECT));

        //        string sTemp = MV_NetInfo.nLostFrameCount.ToString();
        //        Marshal.FreeHGlobal(pstInfo.pInfo);
        //        return sTemp;
        //    }
        //    else if (m_pDeviceInfo[nIndex].nTLayerType == MyCamera.MV_USB_DEVICE)
        //    {
        //        MyCamera.MV_MATCH_INFO_USB_DETECT MV_NetInfo = new MyCamera.MV_MATCH_INFO_USB_DETECT();
        //        pstInfo.nInfoSize = (uint)System.Runtime.InteropServices.Marshal.SizeOf(typeof(MyCamera.MV_MATCH_INFO_USB_DETECT));
        //        pstInfo.nType = MyCamera.MV_MATCH_TYPE_USB_DETECT;
        //        int size = Marshal.SizeOf(MV_NetInfo);
        //        pstInfo.pInfo = Marshal.AllocHGlobal(size);
        //        Marshal.StructureToPtr(MV_NetInfo, pstInfo.pInfo, false);

        //        m_pMyCamera[nIndex].MV_CC_GetAllMatchInfo_NET(ref pstInfo);
        //        MV_NetInfo = (MyCamera.MV_MATCH_INFO_USB_DETECT)Marshal.PtrToStructure(pstInfo.pInfo, typeof(MyCamera.MV_MATCH_INFO_USB_DETECT));

        //        string sTemp = MV_NetInfo.nErrorFrameCount.ToString();
        //        Marshal.FreeHGlobal(pstInfo.pInfo);
        //        return sTemp;
        //    }
        //    else
        //    {
        //        return "0";
        //    }
        //}
        //public void StartGrabbing()
        //{
        //    int nRet;
        //    m_hDisplayHandle[0] = camera1.Handle;
        //    m_hDisplayHandle[1] = camera2.Handle;
        //    // ch:开始采集 | en:Start Grabbing
        //    for (int i = 0; i < m_nCanOpenDevNum; i++)
        //    {
        //        m_nFrames[i] = 0;
        //        m_stFrameInfo[i].nFrameLen = 0;//取流之前先清除帧长度
        //        m_stFrameInfo[i].enPixelType = MyCamera.MvGvspPixelType.PixelType_Gvsp_Undefined;

        //        nRet = m_pMyCamera[i].MV_CC_StartGrabbing_NET();
        //        if (MyCamera.MV_OK != nRet)
        //        {
        //            ShowErrorMsg("Start Grabbing failed! \r\n", nRet);
        //        }
        //        nRet = m_pMyCamera[i].MV_CC_SetCommandValue_NET("AcquisitionStart");
        //        if (nRet != MyCamera.MV_OK)
        //        {
        //            ShowErrorMsg("启动连续采集失败", nRet);
        //        }
        //    }
        //    //cbImage = new MyCamera.cbOutputExdelegate(ImageCallBack);
        //    //nRet = m_pMyCamera.MV_CC_RegisterImageCallBackEx_NET(cbImage, IntPtr.Zero);
        //    //ch:开始计时  | en:Start Timing
        //    m_bTimerFlag = true;
        //    // ch:控件操作 | en:Control Operation
        //    //SetCtrlWhenStartGrab();
        //    // ch:标志位置位true | en:Set Position Bit true
        //    m_bGrabbing = true;
        //    suc.Text = "grabbing";
        //}

        //public void StartSingleGrab()
        //{
        //     int nRet;
        //    m_hDisplayHandle[0] = camera1.Handle;
        //    m_hDisplayHandle[1] = camera2.Handle;
        //    // ch:开始采集 | en:Start Grabbing
        //    for (int i = 0; i < m_nCanOpenDevNum; i++)
        //    {
        //        m_nFrames[i] = 0;
        //        m_stFrameInfo[i].nFrameLen = 0;//取流之前先清除帧长度
        //        m_stFrameInfo[i].enPixelType = MyCamera.MvGvspPixelType.PixelType_Gvsp_Undefined;

        //        nRet = m_pMyCamera[i].MV_CC_StartGrabbing_NET();
        //        if (MyCamera.MV_OK != nRet)
        //        {
        //            ShowErrorMsg("Start Grabbing failed! \r\n", nRet);
        //        }
        //        nRet = m_pMyCamera[i].MV_CC_SetCommandValue_NET("TriggerSoftware");
        //        if (nRet != MyCamera.MV_OK)
        //            ShowErrorMsg("触发采集失败", nRet);
        //    }
        //    //cbImage = new MyCamera.cbOutputExdelegate(ImageCallBack);
        //    //nRet = m_pMyCamera.MV_CC_RegisterImageCallBackEx_NET(cbImage, IntPtr.Zero);
        //    //ch:开始计时  | en:Start Timing
        //    m_bTimerFlag = true;
        //    // ch:控件操作 | en:Control Operation
        //    //SetCtrlWhenStartGrab();
        //    // ch:标志位置位true | en:Set Position Bit true
        //    m_bGrabbing = true;
        //    suc.Text = "grabbing";
            
        //}



        //public void StopGrabbing()
        //{
        //    // ch:标志位设为false | en:Set flag bit false
        //    for (int i = 0; i < m_nCanOpenDevNum; ++i)
        //    {
        //        m_pMyCamera[i].MV_CC_StopGrabbing_NET();
        //    }
        //    //ch:标志位设为false  | en:Set Flag Bit false
        //    m_bGrabbing = false;
        //}

        //public void close()
        //    {
        //    for (int i = 0; i < m_nCanOpenDevNum; ++i)
        //    {
        //        int nRet;

        //        nRet = m_pMyCamera[i].MV_CC_CloseDevice_NET();
        //        if (MyCamera.MV_OK != nRet)
        //        {
        //            return;
        //        }

        //        nRet = m_pMyCamera[i].MV_CC_DestroyDevice_NET();
        //        if (MyCamera.MV_OK != nRet)
        //        {
        //            return;
        //        }
        //    }

        //    //控件操作 ch: | en:Control Operation
        //    //SetCtrlWhenClose();
        //    // ch:取流标志位清零 | en:Zero setting grabbing flag bit
        //    m_bGrabbing = false;
        //    // ch:重置成员变量 | en:Reset member variable
        //    ResetMember();

        //}

        public void Close_Click(object sender, EventArgs e)
        {
            //close(); 
            Link.mutiCamera.CloseCamera();
        }
        //public void ResetMember()
        //{
        //    m_stDeviceList = new MyCamera.MV_CC_DEVICE_INFO_LIST();
        //    m_bGrabbing = false;
        //    m_nCanOpenDevNum = 0;
        //    m_nDevNum = 0;
        //    DeviceListAcq();
        //    m_nFrames = new int[4];
        //    cbImage = new MyCamera.cbOutputExdelegate(Link.mutiCamera.ImageCallBack);
        //    //m_bTimerFlag = false;
        //    m_hDisplayHandle = new IntPtr[4];
        //    m_pDeviceInfo = new MyCamera.MV_CC_DEVICE_INFO[4];
        //}

        //public void ImageCallBack(IntPtr pData, ref MyCamera.MV_FRAME_OUT_INFO_EX pFrameInfo, IntPtr pUser)
        //{
        //    Debug.WriteLine("Callback entered!");
        //    int nIndex = (int)pUser;

        //    // ch:抓取的帧数 | en:Aquired Frame Number
        //    ++Link.mutiCamera.m_nFrames[nIndex];

        //    lock (Link.mutiCamera.m_BufForSaveImageLock[nIndex])
        //    {
        //        if (Link.mutiCamera.m_pSaveImageBuf[nIndex] == IntPtr.Zero || pFrameInfo.nFrameLen > Link.mutiCamera.m_nSaveImageBufSize[nIndex])
        //        {
        //            if (Link.mutiCamera.m_pSaveImageBuf[nIndex] != IntPtr.Zero)
        //            {
        //                Marshal.Release(Link.mutiCamera.m_pSaveImageBuf[nIndex]);
        //                Link.mutiCamera.m_pSaveImageBuf[nIndex] = IntPtr.Zero;
        //            }

        //            Link.mutiCamera.m_pSaveImageBuf[nIndex] = Marshal.AllocHGlobal((Int32)pFrameInfo.nFrameLen);
        //            if (Link.mutiCamera.m_pSaveImageBuf[nIndex] == IntPtr.Zero)
        //            {
        //                return;
        //            }
        //            Link.mutiCamera.m_nSaveImageBufSize[nIndex] = pFrameInfo.nFrameLen;
        //        }

        //        Link.mutiCamera.m_stFrameInfo[nIndex] = pFrameInfo;
        //        MutiCamera.CopyMemory(Link.mutiCamera.m_pSaveImageBuf[nIndex], pData, pFrameInfo.nFrameLen);
        //    }
        //    MyCamera.MV_FRAME_OUT_INFO_EX frameInfoCopy = pFrameInfo; // 创建结构体副本
        //    IntPtr pDataCopy = pData;
        //    PictureBox targetPictureBox = (nIndex == 0) ? camera1 : camera2;
        //    MyCamera.MV_DISPLAY_FRAME_INFO stDisplayInfo = new MyCamera.MV_DISPLAY_FRAME_INFO();
        //    stDisplayInfo.hWnd = Link.mutiCamera.m_hDisplayHandle[nIndex];
        //    stDisplayInfo.pData = pData;
        //    stDisplayInfo.nDataLen = pFrameInfo.nFrameLen;
        //    stDisplayInfo.nWidth = pFrameInfo.nWidth;
        //    stDisplayInfo.nHeight = pFrameInfo.nHeight;
        //    stDisplayInfo.enPixelType = pFrameInfo.enPixelType;

        //    Link.mutiCamera.m_pMyCamera[nIndex].MV_CC_DisplayOneFrame_NET(ref stDisplayInfo);
        //    if (targetPictureBox.InvokeRequired)
        //    {
        //        targetPictureBox.BeginInvoke(new Action(() =>
        //        {
        //            // 使用副本而不是原始ref参数
        //            DisplayImageOnUI(targetPictureBox, pDataCopy, frameInfoCopy);
        //        }));
        //    }
        //    else
        //    {
        //        DisplayImageOnUI(targetPictureBox, pDataCopy, frameInfoCopy);
        //    }

        //    //SafeDisplayImage(nIndex, pData, pFrameInfo);

        //}
        //private void DisplayImageOnUI(PictureBox pictureBox, IntPtr pData, MyCamera.MV_FRAME_OUT_INFO_EX frameInfo)
        //{
        //    MyCamera.MV_DISPLAY_FRAME_INFO stDisplayInfo = new MyCamera.MV_DISPLAY_FRAME_INFO()
        //    {
        //        hWnd = pictureBox.Handle,
        //        pData = pData,
        //        nDataLen = frameInfo.nFrameLen,
        //        nWidth = frameInfo.nWidth,
        //        nHeight = frameInfo.nHeight,
        //        enPixelType = frameInfo.enPixelType
        //    };

        //    // 获取相机实例
        //    MyCamera camera = GetCameraForPictureBox(pictureBox);
        //    camera.MV_CC_DisplayOneFrame_NET(ref stDisplayInfo);
        //}
        //private MyCamera GetCameraForPictureBox(PictureBox box)
        //{
        //    return (box == camera1) ? Link.mutiCamera.m_pMyCamera[0] : Link.mutiCamera.m_pMyCamera[1];
        //}

        //private void get_Click(object sender, EventArgs e)
        //{
        //    MyCamera.MVCC_FLOATVALUE stParam = new MyCamera.MVCC_FLOATVALUE();

        //    if (Link.mutiCamera.m_nCanOpenDevNum == 1)
        //    {
        //        int nRet = Link.mutiCamera.m_pMyCamera[0].MV_CC_GetFloatValue_NET("ExposureTime", ref stParam);
        //        if (MyCamera.MV_OK != nRet)
        //        {
        //            ShowErrorMsg("Get Exposure Time Fail!", nRet);
        //        }
        //        else
        //        {
        //            cbExposure1.Text = stParam.fCurValue.ToString("F1");
        //        }
        //        //nRet = m_pMyCamera[1].MV_CAML
        //        nRet = Link.mutiCamera.m_pMyCamera[0].MV_CC_GetFloatValue_NET("Gain", ref stParam);
        //        if (MyCamera.MV_OK != nRet)
        //        {
        //            ShowErrorMsg("Get Gain Fail!", nRet);
        //        }
        //        else
        //        {

        //            cbISO1.Text = stParam.fCurValue.ToString("F1");
        //        }
        //    }
        //    else if (Link.mutiCamera.m_nCanOpenDevNum == 2)
        //    {
        //        int nRet = Link.mutiCamera.m_pMyCamera[0].MV_CC_GetFloatValue_NET("ExposureTime", ref stParam);
        //        if (MyCamera.MV_OK != nRet)
        //        {
        //            ShowErrorMsg("Get Exposure Time Fail!", nRet);
        //        }
        //        else
        //        {
        //            cbExposure1.Text = stParam.fCurValue.ToString("F1");
        //        }
        //        //nRet = m_pMyCamera[1].MV_CAML
        //        nRet = Link.mutiCamera.m_pMyCamera[0].MV_CC_GetFloatValue_NET("Gain", ref stParam);
        //        if (MyCamera.MV_OK != nRet)
        //        {
        //            ShowErrorMsg("Get Gain Fail!", nRet);
        //        }
        //        else
        //        {

        //            cbISO1.Text = stParam.fCurValue.ToString("F1");
        //        }
        //        nRet = Link.mutiCamera.m_pMyCamera[1].MV_CC_GetFloatValue_NET("ExposureTime", ref stParam);
        //        if (MyCamera.MV_OK != nRet)
        //        {
        //            ShowErrorMsg("Get Exposure Time Fail!", nRet);
        //        }
        //        else
        //        {
        //            cbExposure2.Text = stParam.fCurValue.ToString("F1");
        //        }

        //        nRet = Link.mutiCamera.m_pMyCamera[1].MV_CC_GetFloatValue_NET("Gain", ref stParam);
        //        if (MyCamera.MV_OK != nRet)
        //        {
        //            ShowErrorMsg("Get Gain Fail!", nRet);
        //        }
        //        else
        //        {
        //            cbISO2.Text = stParam.fCurValue.ToString("F1");
        //        }
        //    }

        //}
        private void get_Click(object sender, EventArgs e)
        {
            //Link.mutiCamera.Get_par(out cbExposure1.Text, cbISO1.Text, cbExposure2.Text, cbISO2.Text);
            string exposure1, gain1, exposure2, gain2;

            Link.mutiCamera.Get_par(
                out exposure1,
                out gain1,
                out exposure2,
                out gain2
            );

            // 更新UI
            cbExposure1.Text = exposure1;
            cbISO1.Text = gain1;
            cbExposure2.Text = exposure2;
            cbISO2.Text = gain2;

        }

        private void set_Click(object sender, EventArgs e)
        {
            Link.mutiCamera.Set_par(cbExposure1.Text,cbISO1.Text,cbExposure2.Text,cbISO2.Text);
           // try
           // {
           //     if(m_nCanOpenDevNum==1)
           //     {
           //         float.Parse(cbExposure1.Text);
           //         float.Parse(cbISO1.Text);
           //     }
           //     else if(m_nCanOpenDevNum==2)
           //     {
           //         float.Parse(cbExposure1.Text);
           //         float.Parse(cbISO1.Text);
           //         float.Parse(cbExposure2.Text);

           //         float.Parse(cbISO2.Text);
           //     }
              
           // }
           // catch
           // {
           //     ShowErrorMsg("Please enter correct type!", 0);
           //     return;
           // }
            
           // if (float.Parse(cbExposure1.Text) < 0 || float.Parse(cbISO1.Text) < 0)
           // {
           //     ShowErrorMsg("Set ExposureTime or Gain fail,Because ExposureTime or Gain less than zero.\r\n",0);
           //     return;
           // }

           // int nRet;
           // bool bSuccess = true;
           // if (m_nCanOpenDevNum==1)
           // {
               
           //     m_pMyCamera[0].MV_CC_SetEnumValue_NET("ExposureAuto", 0);

           //     nRet = m_pMyCamera[0].MV_CC_SetFloatValue_NET("ExposureTime", float.Parse(cbExposure1.Text));
           //     if (nRet != MyCamera.MV_OK)
           //     {
           //         ShowErrorMsg("No.{0} Set Exposure Time Failed! nRet=0x{1}\r\n", nRet);
           //         bSuccess = false;
           //     }

           //     //m_pMyCamera[0].MV_CC_SetEnumValue_NET("GainAuto", 0);
           //     //nRet = m_pMyCamera[0].MV_CC_SetFloatValue_NET("Gain", float.Parse(cbISO1.Text));
           //     //if (nRet != MyCamera.MV_OK)
           //     //{
           //     //    ShowErrorMsg("No.{0} Set Gain Failed! nRet=0x{1}\r\n", 0);
           //     //    bSuccess = false;
           //     //}
           // }
           //else if(m_nCanOpenDevNum==2)
           // {
                
           //     m_pMyCamera[0].MV_CC_SetEnumValue_NET("ExposureAuto", 0);

           //     nRet = m_pMyCamera[0].MV_CC_SetFloatValue_NET("ExposureTime", float.Parse(cbExposure1.Text));
           //     if (nRet != MyCamera.MV_OK)
           //     {
           //         ShowErrorMsg("No.{0} Set Exposure Time Failed! nRet=0x{1}\r\n", nRet);
           //         bSuccess = false;
           //     }

           //     //m_pMyCamera[0].MV_CC_SetEnumValue_NET("GainAuto", 0);
           //     //nRet = m_pMyCamera[0].MV_CC_SetFloatValue_NET("Gain", float.Parse(cbISO1.Text));
           //     //if (nRet != MyCamera.MV_OK)
           //     //{
           //     //    ShowErrorMsg("No.{0} Set Gain Failed! nRet=0x{1}\r\n", 0);
           //     //    bSuccess = false;
           //     //}
              
           //     m_pMyCamera[1].MV_CC_SetEnumValue_NET("ExposureAuto", 0);

           //     nRet = m_pMyCamera[1].MV_CC_SetFloatValue_NET("ExposureTime", float.Parse(cbExposure1.Text));
           //     if (nRet != MyCamera.MV_OK)
           //     {
           //         ShowErrorMsg("No.{0} Set Exposure Time Failed! nRet=0x{1}\r\n", nRet);
           //         bSuccess = false;
           //     }

           //     //m_pMyCamera[1].MV_CC_SetEnumValue_NET("GainAuto", 0);
           //     //nRet = m_pMyCamera[1].MV_CC_SetFloatValue_NET("Gain", float.Parse(cbISO1.Text));
           //     //if (nRet != MyCamera.MV_OK)
           //     //{
           //     //    ShowErrorMsg("No.{0} Set Gain Failed! nRet=0x{1}\r\n", 0);
           //     //    bSuccess = false;
           //     //}
           // }
               

           //     if (bSuccess)
           //     {
           //         ShowErrorMsg("Set Parameters Succeed!\r\n",0);
           //     }
            }
           
        

        public void show_Click(object sender, EventArgs e)
        {
            //camera1 = Link.ca1;
            //camera2 = Link.ca2;
            Link.mutiCamera.StopGrabbing();
           
            Link.mutiCamera.StartGrabbing(camera1,camera2);
            Link.mutiCamera.CameraMode(false);

            //StartGrabbing();
            //StartSingleGrab();
        }
        private void MutiCamera_Set_FormClosing(object sender, FormClosingEventArgs e)
        {
            //StopGrabbing();
            Link.mutiCamera.StopGrabbing();
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            Link.mutiCamera.bnTriggerExec();
        }

        private void uiRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //if (uiRadioButton1.Checked)
            //{
            //    // ch:触发源设为软触发 | en:Set Trigger Source As Software
            //    for (int i = 0; i < m_nCanOpenDeviceNum; ++i)
            //    {
            //        m_pMyCamera[i].MV_CC_SetEnumValue_NET("TriggerSource", (uint)MyCamera.MV_CAM_TRIGGER_SOURCE.MV_TRIGGER_SOURCE_SOFTWARE);
            //    }
            //    if (m_bGrabbing)
            //    {
            //        bnTriggerExec.Enabled = true;
            //    }
            //}
            //else
            //{
            //    //bnTriggerExec.Enabled = false;
            //}
        }

        private void cbDeviceList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btUp_Click(object sender, EventArgs e)
        {
            if (Link.darkroomPLCH == true)
            {
                if (btUp.Text == "上升")
                {
                    Link.darkroomPLC.Slide_2_Forward(UserTask.SportSpeed1, UserTask.SportDistance1, true);
                    btUp.Text = "停止上升";
                    btUp.FillColor = Color.Red;
                    btDown.Enabled = false;
                    //Form1.ProgramChecking = "垂直滑台上升";
                }
                else
                {
                    Link.darkroomPLC.Slide_2_Forward(UserTask.SportSpeed1, UserTask.SportDistance1, false);
                    btUp.Text = "上升";
                    btDown.Enabled = true;
                    btUp.FillColor = Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
                    //Form1.ProgramChecking = "垂直滑台停止上升";
                }
            }
        }

        private void btDown_Click(object sender, EventArgs e)
        {
            if (Link.darkroomPLCH == true)
            {
                if (btDown.Text == "下降")
                {
                      
         
                    Link.darkroomPLC.Slide_2_Back(UserTask.SportSpeed1, UserTask.SportDistance1, true);
                    btDown.Text = "停止下降";
                    btUp.Enabled = false;
                    btDown.FillColor = Color.Red;
                    //Form1.ProgramChecking = "垂直滑台下降";
                }
                else
                {
                    Link.darkroomPLC.Slide_2_Back(UserTask.SportSpeed1, UserTask.SportDistance1, false);
                    btDown.Text = "下降";
                    btUp.Enabled = true;
                    btDown.FillColor = Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
                    //Form1.ProgramChecking = "垂直滑台停止下降";
                }
            }
        }
    }
}
