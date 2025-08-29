using MathNet.Numerics;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace m_CTP
{
    public partial class UserTask : UIPage
    {
        public static bool WateringControlHandle = false;
        public static int WateringSHandle = 0;
        public static bool WeighingControlHandle = false;
        public static bool TurntableControlHandle = false;
        public static int TurntableSHandle = 60;
        public static bool AcquisitionPara = false;
        public static bool GradDirctionHandle = true;//false：水平方向 true：垂直方向
        public static string AutoSpeedH = "200";
        public static string AutoDistanceH = "2";
        public static int R_speed = 200;
        public static int Stoptime = 5;
        public static bool Room1ControlH = true;
        public static bool Room2ControlH = true;


        public static bool LEDTop = true;
        public static bool LEDBottom =  true;
        public static bool asLight = true;

        private const int SlideSpeed_2_DW = 1005;//DW滑台2速度寄存器地址        
        private const int SlideDis_2_DW = 22;//DW滑台2距离寄存器地址
        private const int SlideDis_2_DW_B = 16;///DW滑台2后退距离 


        private const int SlideSpeed_1_DW = 1002;//滑台1速度寄存器地址
        private const int SlideDis_1_DW = 14;//DW滑台1距离寄存器地址
        private const int SlideDis_1_DW_B = 18;///DW滑台1后退距离

        public static double SportDistance = 0.9;
        public static int RGBLoc = 0;
        public static int HyperCaptrue = 2;
        public static double SportSpeed = 0.0273;

        public static double SportDistance1 = 0.2;
      
        public static double SportSpeed1 = 0.0273;

        public UserTask()
        {
            InitializeComponent();
        }

        private void LEDTopON_Click(object sender, EventArgs e)
        {
            if (LEDTopON.Text == "  LED（上）")
            {
                Link.darkroomPLC.Slide_2_Forward(Convert.ToDouble(RiseSpeed.Text), SportDistance1, true);
                btUP.Text = "停止上升";
                btUP.FillColor = Color.Red;
                btDown.Enabled = false;
                //Form1.ProgramChecking = "垂直滑台上升";
            }
            else
            {
                Link.darkroomPLC.Slide_2_Forward(Convert.ToDouble(RiseSpeed.Text), SportDistance1, false);
                btUP.Text = "上升";
                btDown.Enabled = true;
                btUP.FillColor = Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
                //Form1.ProgramChecking = "垂直滑台停止上升";
            }










            Link.darkroomPLC.LED1_Control(true);
            LEDTop=true;
            LEDTopON.Enabled = false;
            LEDTopOFF.Enabled = true;

        }

     

        private void verticalSet_Click(object sender, EventArgs e)
        {
           //Link.transmitPLC.verticalSet(Convert.ToDouble(RiseSpeed.Text), Convert.ToDouble(RiseSpeed.Text),
           //    Convert.ToDouble(FallDist.Text));
          SportSpeed1 = Convert.ToDouble(RiseSpeed.Text);


        }


        private void UserTask_Initialize(object sender, EventArgs e)
        {
            //if (Link.darkroomPLCH && Link.transmitPLCH && Link.RFIDIsConnected)
            //{
            //    uiGroupBox1.Enabled = true;
            //    uiGroupBox2.Enabled = true;
            //    uiGroupBox3.Enabled = true;
            //    uiGroupBox4.Enabled = true;
            //}
            //else if (!Link.darkroomPLCH)
            //{
            //    UIMessageBox.Show("请连接暗室控制开关", UILocalize.InfoTitle, Style);
            //}
            //else if (!Link.transmitPLCH)
            //{
            //    UIMessageBox.Show("请连接传送带控制开关", UILocalize.InfoTitle, Style);
            //} 
            //else if (!Link.RFIDIsConnected) 
            //{
            //    UIMessageBox.Show("请连接RFID控制开关", UILocalize.InfoTitle, Style);
            //}
            // AutoSpeedH = AutoSpeed.Text;
            // AutoDistanceH =AutoDistance.Text;

        }

        private void LEDBottomON_Click(object sender, EventArgs e)
        {

          
            Link.darkroomPLC.LED2_Control(true);
            LEDBottomON.Enabled = false;

            LEDBottomOFF.Enabled = true;


        }

        private void horizontalSet_Click(object sender, EventArgs e)
        {
            SportDistance = Convert.ToDouble(FwdDist.Text);
            RGBLoc = Convert.ToInt32(RGBLocation.Text);
            SportSpeed = Convert.ToDouble(FwdSpeed.Text);
            HyperCaptrue = Convert.ToInt32(uiTextBox2.Text);
        }

        private void uiGroupBox2_Click(object sender, EventArgs e)
        {

        }

        private void uiLabel4_Click(object sender, EventArgs e)
        {

        }

        private void uiLabel12_Click(object sender, EventArgs e)
        {

        }

       
        private void asLightON_Click(object sender, EventArgs e)
        {
           

            Link.darkroomPLC.LightControl(true);
            asLightON.Enabled = false;
            asLightOFF.Enabled = true;
        }

        private void LEDTopOFF_Click(object sender, EventArgs e)
        {
            
            Link.darkroomPLC.LED1_Control(false);
            LEDTopON.Enabled = true;
            LEDTopOFF.Enabled = false;
            LEDTop = false;
        }

        private void LEDBottomOFF_Click(object sender, EventArgs e)
        {
           
            Link.darkroomPLC.LED2_Control(false);
            LEDBottomON.Enabled = true;

            LEDBottomOFF.Enabled = false;
        }

        private void asLightOFF_Click(object sender, EventArgs e)
        {
          
            Link.darkroomPLC.LightControl(false);
            asLightON.Enabled = true;
            asLightOFF.Enabled = false;
        }

        private void verticalGet_Click(object sender, EventArgs e)
        {
            
               
                RiseSpeed.Text = (Link.darkroomPLC.verticalGet() / 38520).ToString("0.000");




        }

        private void horizontalGet_Click(object sender, EventArgs e)
        {

            FwdSpeed.Text = (Link.darkroomPLC.horizontalGet()/38520).ToString("0.000");
               
        }

        private void btUP_Click(object sender, EventArgs e)
        {
            if (Link.darkroomPLCH == true)
            {
                if (btUP.Text == "上升")
                {
                    Link.darkroomPLC.Slide_2_Forward(Convert.ToDouble(RiseSpeed.Text), SportDistance1, true);
                    btUP.Text = "停止上升";
                    btUP.FillColor = Color.Red;
                    btDown.Enabled = false;
                    //Form1.ProgramChecking = "垂直滑台上升";
                }
                else
                {
                    Link.darkroomPLC.Slide_2_Forward(Convert.ToDouble(RiseSpeed.Text), SportDistance1, false);
                    btUP.Text = "上升";
                    btDown.Enabled = true;
                    btUP.FillColor = Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
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
                    Link.darkroomPLC.Slide_2_Back(Convert.ToDouble(RiseSpeed.Text), SportDistance1, true);
                    btDown.Text = "停止下降";
                    btUP.Enabled = false;
                    btDown.FillColor = Color.Red;
                    //Form1.ProgramChecking = "垂直滑台下降";
                }
                else
                {
                    Link.darkroomPLC.Slide_2_Back(Convert.ToDouble(RiseSpeed.Text), SportDistance1, false);
                    btDown.Text = "下降";
                    btUP.Enabled = true;
                    btDown.FillColor = Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
                    //Form1.ProgramChecking = "垂直滑台停止下降";
                }
            }
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            if (LEDTop == false)
            {
                
                LEDTop = true;
                uiButton1.FillColor = Color.Red;
            }
            else 
            {
                LEDTop = false;
                uiButton1.FillColor = Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            }
         
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            if (LEDBottom == false)
            {

                LEDBottom = true;
                uiButton2.FillColor = Color.Red;
            }
            else
            {
                LEDBottom = false;
                uiButton2.FillColor = Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            }
        }

        private void uiButton3_Click(object sender, EventArgs e)
        {
            if (asLight == false)
            {
                asLight = true;
                uiButton3.FillColor = Color.Red;
            }
            else
            {
                asLight = false;
                uiButton3.FillColor = Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            }
        }

        private void uiLabel6_Click(object sender, EventArgs e)
        {

        }
    }
}
