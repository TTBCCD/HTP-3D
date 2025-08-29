using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;
using Canondemo;
using System.Threading;

namespace m_CTP
{
    public partial class Lidar_Set : UIPage
    {
        public static bool TH = false;
        public static bool ST = false;
        public static string LidarName = "";
        public static string LidarId = "";
        public Lidar_Set()
        {
            InitializeComponent();
        }

        private void uiGroupBox2_Click(object sender, EventArgs e)
        {

        }

        private void uiButton1_Click(object sender, EventArgs e)//采集控制
        {
            if (uiButton1.Text == "开始测量")
            {
                uiButton1.Text = "停止测量";
                string str = null;
                Link.lidarHe16.UdpServices();
                str = "D:\\lidar\\" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + ".txt";
                double speed = Convert.ToDouble(LidarScanspeed.Text);//前进速度为正 后退速度为负
                Link.lidarHe16.WriteSteam(speed, str);
                Thread.Sleep(1000);
                Link.lidarHe16.STartGard();
                TH = true;
                Form1.ProgramChecking = "激光雷达手动采集开始";
            }
            else if (uiButton1.Text == "停止测量")
            {

                Link.lidarHe16.CloseTask();
                Thread.Sleep(500);
                TH = false;
                Link.lidarHe16.DisposeSteam();
                Thread.Sleep(500);
                Link.lidarHe16.UdpServices_Dispose();
                uiButton1.Text = "开始测量";
                Form1.ProgramChecking = "激光雷达手动采集结束";
            }
            else 
            {

            }
        }
        public static void StartLidar(string a,string str)//开始采集
        {
            Link.lidarHe16.UdpServices(); 
            double speed = -Convert.ToDouble(a);//前进速度为正 后退速度为负
            Link.lidarHe16.WriteSteam(speed, str);
            Thread.Sleep(1000);
            Link.lidarHe16.STartGard();
            ST = true;
            TH = true;

        }

        public static void StpoLidar()//停止采集
        {
            Link.lidarHe16.CloseTask();
            Thread.Sleep(300);
            ST = false;
            TH = false;
            Link.lidarHe16.DisposeSteam();
            Thread.Sleep(300);
            Link.lidarHe16.UdpServices_Dispose();
        }

        private void Lidar_Set_Initialize(object sender, EventArgs e)
        {

        }
    }
}
