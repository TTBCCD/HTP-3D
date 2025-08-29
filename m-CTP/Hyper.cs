using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace m_CTP
{
    public partial class Hyper : UIPage
    {
        private delegate void StartDevGrad(string str);
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
        //public HyperCamera_2 hyperCamera_2;
        



        // public Camera camera; //Basler.Pylon相机，即高光谱相机成像单元

        static int spectrum_cols = 239;//默认监视空间点（光谱曲线）抽取位置

        static int current_col = 0;//生成光谱伪彩图
        static int rgb_mat_width = 1024;//缓存帧数（光谱伪彩图宽度)
        static Mat rgb_mat;//用于生成临时光谱合成图
        public static int b_row = 31;//0-269
        public static int g_row = 69;//0-269
        public static int r_row = 120;//0-269

        static FileStream fs; // 高光谱存储文件流
        static string filepath; // 存储文件路径
        static bool filepathExist; // 存储文件是否已经给定，true给定，false未指定

        static long frameNum; //一次采集共计采集的帧数
        static byte[] buffer; // 用于存储一帧数据的 PixelData

        static int Width; // 抓取的数据一帧的宽度
        static int Height; // 抓取结果的一帧数据高度

        public bool IsReady; // 表示相机可以执行拍摄
        static PictureBox pi;
        static UITextBox text;

        public static bool GradSate = false;
        public Hyper()
        {
            InitializeComponent();
            //hyperCamera_2 = new HyperCamera_2();
            pi = picturebox1;
            text = Num;
        }


        private void Hyper_Set_Initialize(object sender, EventArgs e)
        {

        }
        public static void DrawImage(byte[] bytes, int Height, int Width)//1024*1280 1280为光谱分辨率
        {
            Mat image = new Mat(Height, Width, MatType.CV_16UC1, bytes);//将数据变成图片

            double g_MaxValue;
            double g_MinValue;
            //Height = 1024
            //width = 1280
            /*计算线最大光强*/
            Mat spectrum = image.ColRange(spectrum_cols, spectrum_cols + 1);//监视空间点位置-光谱曲线
                                                                            //float []data = new float[spectrum.Cols];
                                                                            //string[] text = new string[spectrum.Cols];
            int max = -1;//这是检测光谱曲线数值的，最大数值4095
            for (int index = 0; index < spectrum.Cols; index++)
            {
                if (max < spectrum.Get<short>(index, 0))
                {
                    max = spectrum.Get<short>(index, 0);
                }
                //text[index] = Convert.ToString(index);
                //Console.WriteLine(data[index]);
            }
            text.Invoke(new MethodInvoker(() =>
            {
                max = max / 16;
                text.Text = max.ToString();
            }));

            Cv2.MinMaxLoc(image, out g_MinValue, out g_MaxValue); // 获取整个image的最大和最小值
            image.ConvertTo(image, MatType.CV_8U, 255.0 / g_MaxValue);


            //合成伪彩图
            if (current_col == 0)
            {
                //创建一个采色通道图像
                rgb_mat = new Mat(Height, Height, MatType.CV_8UC3, new Scalar(255, 255, 255));
                current_col++;
            }
            for (int index = 0; index < image.Rows; index++)//用图像列数作为循环条件
            {
                //Vec3b color = rgb_mat.Set<Vec3b>(index, current_col - 1);
                Vec3b colormap;//3位数组
                colormap.Item0 = image.Get<byte>(index, b_row);//B//从 灰度图 获取像素值。
                colormap.Item1 = image.Get<byte>(index, g_row);//G
                colormap.Item2 = image.Get<byte>(index,r_row);//R
                rgb_mat.Set<Vec3b>(index, current_col - 1, colormap);//用于修改 Mat 图像中某个像素的 BGR 值。

            }
            if (current_col < rgb_mat.Cols)
            {
                current_col++;
            }
            else
            {
                Rect rc1 = new Rect(1, 0, rgb_mat.Cols - 1, rgb_mat.Rows);
                Rect rc2 = new Rect(0, 0, rgb_mat.Cols - 1, rgb_mat.Rows);
                new Mat(rgb_mat, rc1).CopyTo(new Mat(rgb_mat, rc2));

                //rgb_mat(new Rect(1, 0, rgb_mat.Cols - 1, rgb_mat.Rows)).copyTo(rgb_mat(new Rect(0, 0, rgb_mat.Cols - 1, rgb_mat.Rows)));
            }
            System.Drawing.Image drawImage = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(rgb_mat);
            //Cv2.Resize(drawImage, drawImage, new System.Drawing.Size(pi.Width, pi.Height));
            pi.Invoke(new MethodInvoker(() =>
            {
                //Graphics g1 = pi.CreateGraphics();//画布
                //                                  //g1.Clear(Color.White);
                //g1.DrawImage(drawImage, new PointF(0, 0));
                //drawImage.Dispose();
                //g1.Dispose();
                //g1 = null;
                pi.Image?.Dispose();
                pi.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(rgb_mat);

            }));
        }
        public void OpenHyper_Click(object sender, EventArgs e)
        {
            Link.hyperCamera_2.Camera_Init();
        }


        public void CloseHyper_Click(object sender, EventArgs e)
        {
            StopCollection_Click(null, null);
            Link.hyperCamera_2.Camera_Exit();
        }

        public void StartCollection_Click(object sender, EventArgs e)
        {
            
            
            string path = Path.Text.Trim();
            if (string.IsNullOrEmpty(path))
            {
                ShowErrorMsg("保存路径不能为空！", 0);
                return;
            }

            // 确保目录存在
            if (!Directory.Exists(path))
            {
                try
                {
                    Directory.CreateDirectory(path);
                }
                catch (Exception ex)
                {
                    ShowErrorMsg($"创建目录失败: {ex.Message}", 0);
                    return;
                }
            }
            Hyper_Set.HyperFileName = DateTime.Now.ToString("yyyyMMddHHmmss");
            Link.hyperCamera_2.StartCamera(path);
            GradSate = true;
        }
       

        public void StopCollection_Click(object sender, EventArgs e)
        {
            string path = Path.Text.Trim();
            if (string.IsNullOrEmpty(path))
            {
                ShowErrorMsg("保存路径不能为空！", 0);
                return;
            }

            // 确保目录存在
            if (!Directory.Exists(path))
            {
                try
                {
                    Directory.CreateDirectory(path);
                }
                catch (Exception ex)
                {
                    ShowErrorMsg($"创建目录失败: {ex.Message}", 0);
                    return;
                }
            }
            Link.hyperCamera_2.StopCamera(path);
            GradSate = false;
            current_col = 0;
        } public void ShowErrorMsg(string csMessage, int nErrorNum)
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

        private void btnGetGain_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(GetGain.Text);
            double b = Link.hyperCamera_2.GetCameraExposureGainValue(a);
            SetGain.Text = b.ToString();
        }

        private void btnSetGain_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(GetGain.Text);
            Link.hyperCamera_2.SetCameraGain(a);
        }

        private void btnGetEXp_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(GetExp.Text);
            double b = Link.hyperCamera_2.GetCameraExposureTimeValue(a);
            SetExp.Text = b.ToString();
        }

        private void btnSetExp_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(GetExp.Text);
            Link.hyperCamera_2.SetCameraTime(a);
        }

        private void btnGetFrame_Click(object sender, EventArgs e)
        {
            int a = Link.hyperCamera_2.GetCameraFps();
            GetFrame.Text = a.ToString();
        }

        private void btnSetFrame_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(SetFrame.Text);
            Link.hyperCamera_2.SetCameraFps(a);
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择文件路径";
            dialog.RootFolder = Environment.SpecialFolder.Desktop;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var selectFolder = dialog.SelectedPath;
                Path.Text = dialog.SelectedPath;
            }
        }

        private void btnPixelMerge_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(cbPixelMerge.Text);
            Link.hyperCamera_2.Camera_SetBinningMode(a);
        }

        private void btnPMState_Click(object sender, EventArgs e)
        {
            int a = -1;
           Link.hyperCamera_2.Camera_GetBinningMode(ref a);
            PixelMergeState.Text = a.ToString();
        }
    }

}