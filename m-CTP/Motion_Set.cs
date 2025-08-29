using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;

namespace m_CTP
{
    public partial class Motion_Set : UIPage
    {
        DarkroomPLC DarkroomPLC;
        Link link = new Link();
        public static string PlotName = null;
        public static bool RFIDcontrol = false;
        public Motion_Set()
        {
            InitializeComponent();
        }

        private void Motion_Set_Initialize(object sender, EventArgs e)
        {
           
        }

        private void Slide1Forward_Click(object sender, EventArgs e)//滑台1前进控制
        {
            if (Link.darkroomPLCH== true) 
            {
                if (Slide1Forward.Text == "滑台前进")
                {
                    Link.darkroomPLC.Slide_1_Forward(Convert.ToDouble(Slide1ForwardSpeed.Text), Convert.ToDouble(Slide1ForwardDis.Text), true);
                   // Link.transmitPLC.Slide_2_Forward(Convert.ToDouble(Slide1ForwardSpeed.Text), Convert.ToDouble(Slide1ForwardDis.Text),true);
                    Slide1Forward.Text = "停止前进";
                    Slide1Back.Enabled = false;
                    Slide1Forward.FillColor = Color.Red;
                    Form1.ProgramChecking = "水平滑台前进";
                }
                else
                {
                    Link.darkroomPLC.Slide_1_Forward(Convert.ToDouble(Slide1ForwardSpeed.Text), Convert.ToDouble(Slide1ForwardDis.Text), false);
                   // Link.transmitPLC.Slide_2_Forward(Convert.ToDouble(Slide1ForwardSpeed.Text), Convert.ToDouble(Slide1ForwardDis.Text), false);
                    Slide1Forward.Text = "滑台前进";
                    Slide1Back.Enabled = true;
                    Slide1Forward.FillColor = Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
                    Form1.ProgramChecking = "水平滑台停止前进";
                }
            }
        }

        private void Slide1Back_Click(object sender, EventArgs e)//滑台1后退控制
        {
            if (Link.darkroomPLCH == true)
            {
                if (Slide1Back.Text == "滑台后退")
                {
                     Link.darkroomPLC.Slide_1_Back(Convert.ToDouble(Slide1BackSpeed.Text), Convert.ToDouble(Slide1BackDis.Text), true);
                    //Link.transmitPLC.Slide_2_Back(Convert.ToDouble(Slide1BackSpeed.Text), Convert.ToDouble(Slide1BackDis.Text), true);
                    Slide1Back.Text = "停止后退";
                    Slide1Forward.Enabled = false;
                    Slide1Back.FillColor = Color.Red;
                    Form1.ProgramChecking = "水平滑台后退";
                }
                else
                {
                     Link.darkroomPLC.Slide_1_Back(Convert.ToDouble(Slide1BackSpeed.Text), Convert.ToDouble(Slide1BackDis.Text), false);
                  //  Link.transmitPLC.Slide_2_Back(Convert.ToDouble(Slide1BackSpeed.Text), Convert.ToDouble(Slide1BackDis.Text), false);
                    Slide1Back.Text = "滑台后退";
                    Slide1Forward.Enabled = true;
                    Slide1Back.FillColor = Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
                    Form1.ProgramChecking = "水平滑台停止后退";
                }
            }
              
        }

        private void Slide2Up_Click(object sender, EventArgs e)//上升控制
        {
            if (Link.darkroomPLCH == true) 
            {
                if (Slide2Up.Text == "滑台上升")
                {
                    Link.darkroomPLC.Slide_2_Forward(Convert.ToDouble(Slide2UpSpeed.Text), Convert.ToDouble(Slide2UpDis.Text), true);
                    Slide2Up.Text = "停止上升";
                    Slide2Up.FillColor = Color.Red;
                    Slide2Down.Enabled = false;
                    Form1.ProgramChecking = "垂直滑台上升";
                }
                else
                {
                    Link.darkroomPLC.Slide_2_Forward(Convert.ToDouble(Slide2UpSpeed.Text), Convert.ToDouble(Slide2UpDis.Text), false);
                    Slide2Up.Text = "滑台上升";
                    Slide2Down.Enabled = true;
                    Slide2Up.FillColor = Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
                    Form1.ProgramChecking = "垂直滑台停止上升";
                }
            }
           
        }

        private void Slide2Down_Click(object sender, EventArgs e)//滑台下降控制
        {
            if (Link.darkroomPLCH == true) 
            {
                if (Slide2Down.Text == "滑台下降")
                {
                    Link.darkroomPLC.Slide_2_Back(Convert.ToDouble(Slide2DwonSpeed.Text), Convert.ToDouble(Slide2DownDis.Text), true);
                    Slide2Down.Text = "停止下降";
                    Slide2Up.Enabled = false;
                    Slide2Down.FillColor = Color.Red;
                    Form1.ProgramChecking = "垂直滑台下降";
                }
                else
                {
                    Link.darkroomPLC.Slide_2_Back(Convert.ToDouble(Slide2DwonSpeed.Text), Convert.ToDouble(Slide2DownDis.Text), false);
                    Slide2Down.Text = "滑台下降";
                    Slide2Up.Enabled = true;
                    Slide2Down.FillColor = Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
                    Form1.ProgramChecking = "垂直滑台停止下降";
                }
            }
           
        }

       

      

        private void timer1_Tick(object sender, EventArgs e)
        {
            byte[] ReadData = new byte[10];
            if (Link.rFID.ReadUserMem(0, 10, ref ReadData))
            {
               string str = System.Text.Encoding.Default.GetString(ReadData);
                Byte[] ThisByte = new Byte[10];
                Buffer.BlockCopy(ReadData, 0, ThisByte, 0, 10);
                str = Encoding.Default.GetString(ThisByte);
             
                //tb_ReadData.Text = RfidLib.Tool.ByteToHexString(ReadData, 0, ReadCnt << 1, " ");
                timer1.Stop();
                // MessageBox.Show("Read user memory succeed.");
            }
            else
            {
                // MessageBox.Show("Read user memory failed, please check the parameter ,and ensure tag is in right area...");
            }
        }
        //public static void ReadPlotName() 
        //{
        //    while (RFIDcontrol) 
        //    {
        //        byte[] ReadData = new byte[256];
        //        if (Link.rFID.ReadUserMem(0, 3, ref ReadData))
        //        {
        //            string a = Encoding.Default.GetString(ReadData).Trim();
        //            string[] sArray = a.Split('\0');
        //            PlotName = sArray[0];
        //        } 
        //    }
               
        //}
        private void uiGroupBox2_Click(object sender, EventArgs e)
        {

        }

        private void Slide2UpSpeed_TextChanged(object sender, EventArgs e)
        {

        }

        private void Slide1ForwardSpeed_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
