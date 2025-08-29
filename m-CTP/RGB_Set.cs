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

namespace m_CTP
{
    public partial class RGB_Set : UIPage
    {
        //#region //标准库
        //[DllImport("VR3DConsole.dll", EntryPoint = "InitConsole", CallingConvention = CallingConvention.Cdecl)]
        //public static extern bool InitConsole(string Port);

        //[DllImport("VR3DConsole.dll", EntryPoint = "Capture", CallingConvention = CallingConvention.Cdecl)]
        //public static extern bool Capture();
        //#endregion

        public static RgbCamera rgbCamera;
        public static ListView ListView3;
        public static ListBox ListBox3;
        private static int CameraCount;
        private bool ParWriteSate = false;
        public RGB_Set()
        {
            InitializeComponent();

        }
        


        private void buttonCapture_Click(object sender, EventArgs e)//单张RGB图像采集
        {
            this.BeginInvoke((Action)delegate
            {
                // 窗口显示和文件路径
                listBox1.Items.Add(string.Format("{0}|OneShot_A!", DateTime.Now));
                string realpicturepath = textBoxPicturePath.Text;//RgbDatafolder"C:\\Users\\10446\\Desktop"
                if (!Directory.Exists(realpicturepath)) Directory.CreateDirectory(realpicturepath);//感觉可以不用创建文件夹
                rgbCamera.shootForAllCameras(realpicturepath);//将USB拍照先注视掉，此步骤变为
                Link.vR3D.Capture();//控制驱动盒拍摄图片
            });
        }

        private void cbShutterSpeed_SelectedIndexChanged(object sender, EventArgs e)//设置快门速度
        {
            int i = 0;
            foreach (aCamera ac in rgbCamera.aCameraList)
            {
                listViewCaminfo.Items[i].SubItems[2].Text = cbShutterSpeed.Text;
                ac.ShutterSpeed = rgbCamera.ssarray[cbShutterSpeed.SelectedIndex].Tv;
                ac.SetLV_SS(rgbCamera.GetTargetSS(ac.ShutterSpeed));
                i++;
            }
        }

        private void cbAperture_SelectedIndexChanged(object sender, EventArgs e)//设置光圈
        {
            int i = 0; 
            foreach (aCamera ac in rgbCamera.aCameraList)
            {
                listViewCaminfo.Items[i].SubItems[3].Text = cbAperture.Text;
                ac.Aperture = rgbCamera.avarray[cbAperture.SelectedIndex].AV;
                ac.SetLV_Aperture(rgbCamera.GetTargetApture(ac.Aperture));
                i++;
            }
        }

        private void cbISO_SelectedIndexChanged(object sender, EventArgs e)//设置增益
        {
            int i = 0;
            foreach (aCamera ac in rgbCamera.aCameraList)
            {
                listViewCaminfo.Items[i].SubItems[4].Text = cbISO.Text;
                ac.ISO = rgbCamera.isoarray[cbISO.SelectedIndex].ISOSpeed;
                ac.SetLV_ISO(rgbCamera.GetTargetISO(ac.ISO));
                i++;
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
                    listBox1.Items.Add(ex.Message);
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

        public  int ConnectCanera() 
        {
            rgbCamera = new RgbCamera();
            CameraCount = rgbCamera.connectRgbCameras(listViewCaminfo, listBox1);
            cbAperture.Enabled = cbISO.Enabled = cbShutterSpeed.Enabled = true;
          
            return CameraCount;
        }
        public void DisposeCanera()
        {
            rgbCamera.DisposeCam();//关闭相机资源
            listViewCaminfo.Clear();//清空列表
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
           
        }

        private void RGB_Set_Initialize(object sender, EventArgs e)
        {
            if (Link.RGBControlH&& ParWriteSate==false)
            {
                for (int i = 0; i < CameraCount; i++)
                {
                    string[] str = new string[5] { RgbCamera.listViewCaminfo.Items[i].SubItems[0].Text,
                    RgbCamera.listViewCaminfo.Items[i].SubItems[1].Text, RgbCamera.listViewCaminfo.Items[i].SubItems[2].Text,
                    RgbCamera.listViewCaminfo.Items[i].SubItems[3].Text, RgbCamera.listViewCaminfo.Items[i].SubItems[4].Text};
                    ListViewItem lvi = new ListViewItem(str);
                    listViewCaminfo.Items.Add(lvi);
                }
                cbAperture.Enabled = cbISO.Enabled = cbShutterSpeed.Enabled = true;
                for (int i = 0; i < 71; i++)
                {
                    cbShutterSpeed.Items.Add(rgbCamera.ssarray[i].ShutterSpeedName);
                }
                for (int i = 0; i < 54; i++)
                {
                    cbAperture.Items.Add(rgbCamera.avarray[i].AvName);
                }
                for (int i = 0; i < 24; i++)
                {
                    cbISO.Items.Add(rgbCamera.isoarray[i].ISOName);
                }
                cbISO.Text = "100";
                cbShutterSpeed.Text = "1/60";
                ParWriteSate = true;
            }
        }

        private void listViewCaminfoUI_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbShutterSpeed_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
        }
    }
}
