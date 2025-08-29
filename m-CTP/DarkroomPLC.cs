using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace m_CTP
{
    public  class DarkroomPLC
    {
        private const int nNetId = 0;// PLC ID = 1
        HCPLC hCPLC;
        private const int SlideSpeed_1_DW = 1002;//滑台1速度寄存器地址
        private const int SlideDis_1_DW = 14;//DW滑台1距离寄存器地址
        private const int SlideDis_1_DW_B = 18;///DW滑台1后退距离
        private const int SlideFor_1_M = 1;//滑台1前进线圈
        private const int SlideBake_1_M = 0;// 滑台1后退线圈
        private const int SlideSate_1_M = 5;//滑台1状态限位



        private const int SlideSpeed_2_DW = 1005;//DW滑台2速度寄存器地址
        private const int SlideDis_2_DW = 22;//DW滑台2距离寄存器地址
        private const int SlideDis_2_DW_B = 16;///DW滑台2后退距离    
        private const int SlideFor_2_M = 3;//滑台2前进线圈
        private const int SlideBake_2_M = 4;//滑台2后退线圈   
        private const int SlideSate_2_M = 15;//滑台2状态限位


        private const int asLight_Control_M = 6;//卤素灯开关
        private const int LED1_Crontol_M = 7;//上方LED开关
        private const int LED2_Crontol_M = 8;//侧方LED开关






        private const double speedslope = 38520;//速度转脉冲频率数据
        private const int Distanceslope = 38520;//距离转脉冲数数据
        private  bool ForwardSate = false;
        private bool BackSate = false;
        private bool ForwardSate1 = false;
        private bool BackSate1 = false;
        public DarkroomPLC() 
        {
            hCPLC = new HCPLC();
        }

        public void ConnectPLC(string ip, int nIpPort)//传送带PLC NetId = 0 ,连接传送带PLC
        {
            hCPLC.ConnectPLC(ip, nNetId, nIpPort);
        }

        public void ClosePLC()// 关闭PLC连接
        {
            hCPLC.ClosePLC(nNetId);
        }

        public void Slide_1_Forward(double speed,double distance,bool con)//滑台1前进控制,水平滑台
        {
            if (con) 
            {
                int speed1 =(int)(speed* speedslope);
                int distance1 = (int)(distance* Distanceslope);
                byte[] Value = new byte[2];
                byte[] Value_2 = new byte[2];
                Value[0] = (byte)(speed1 % 256);
                Value[1] = (byte)(speed1 / 256);
                Value_2[0] = (byte)(distance1 % 256);
                Value_2[1] = (byte)(distance1 / 256);
                byte[] ValueM = new byte[1];
                ValueM[0] = (byte)1;
                hCPLC.WriteH3U(SoftElemType.REGI_H3U_DW, SlideSpeed_1_DW, 1, Value, nNetId);//设置速度
                hCPLC.WriteH3U(SoftElemType.REGI_H3U_DW, SlideDis_1_DW, 1, Value_2, nNetId);//设置距离
                hCPLC.WriteH3U(SoftElemType.REGI_H3U_M, SlideFor_1_M, 1, ValueM, nNetId);// 启动前进句柄
                ForwardSate = true;
            }
            else
            {
                byte[] ValueM = new byte[1];
                ValueM[0] = (byte)0;
                hCPLC.WriteH3U(SoftElemType.REGI_H3U_M, SlideFor_1_M, 1, ValueM, nNetId);// 停止滑台前进
                ForwardSate = false;
            }
            
        }
        public void Slide_1_Back(double speed, double distance,bool con)//滑台1后退控制，水平滑台
        {
            if (con)
            {
                int speed1 = (int)(speed*speedslope);
                int distance1 = (int)(distance* Distanceslope);
                byte[] Value = new byte[2];
                byte[] Value_2 = new byte[2];
                Value[0] = (byte)(speed1 % 256);
                Value[1] = (byte)(speed1 / 256);
                Value_2[0] = (byte)(distance1 % 256);
                Value_2[1] = (byte)(distance1 / 256);
                byte[] ValueM = new byte[1];
                ValueM[0] = 1;
                hCPLC.WriteH3U(SoftElemType.REGI_H3U_DW, SlideSpeed_1_DW, 1, Value, nNetId);//设置速度
                hCPLC.WriteH3U(SoftElemType.REGI_H3U_DW, SlideDis_1_DW_B, 1, Value_2, nNetId);//设置距离
                hCPLC.WriteH3U(SoftElemType.REGI_H3U_M, SlideBake_1_M, 1, ValueM, nNetId);// 启动后退句柄
                BackSate = true;
            }
            else
            {
                byte[] ValueM = new byte[1];
                ValueM[0] = 0;
                hCPLC.WriteH3U(SoftElemType.REGI_H3U_M, SlideBake_1_M, 1, ValueM, nNetId);// 停止滑台后退
                BackSate = false;
            }

        }
        public void Slide_2_Forward(double speed, double distance, bool con)//滑台2前进控制，垂直滑台
        {
            if (con)
            {
                int speed1 = (int)(speed*speedslope);
                int distance1 = (int)(distance*Distanceslope);
                byte[] Value = new byte[2];
                byte[] Value_2 = new byte[2];
                Value[0] = (byte)(speed1 % 256);
                Value[1] = (byte)(speed1 / 256);
                Value_2[0] = (byte)(distance1 % 256);
                Value_2[1] = (byte)(distance1 / 256);
                byte[] ValueM = new byte[1];
                ValueM[0] = (byte)1;
                hCPLC.WriteH3U(SoftElemType.REGI_H3U_DW, SlideSpeed_2_DW, 1, Value, nNetId);//设置速度
                hCPLC.WriteH3U(SoftElemType.REGI_H3U_DW, SlideDis_2_DW, 1, Value_2, nNetId);//设置距离
                hCPLC.WriteH3U(SoftElemType.REGI_H3U_M, SlideFor_2_M, 1, ValueM, nNetId);// 启动前进句柄
               
            }
            else
            {
                byte[] ValueM = new byte[1];
                ValueM[0] = (byte)0;
                hCPLC.WriteH3U(SoftElemType.REGI_H3U_M, SlideFor_2_M, 1, ValueM, nNetId);// 停止滑台前进
                ForwardSate1 = false;
            }

        }
        public void Slide_2_Back(double speed, double distance, bool con)//滑台2后退控制，垂直滑台
        {
            if (con)
            {
                int speed1 = (int)(speed* speedslope);
                int distance1 = (int)(distance*Distanceslope);
                byte[] Value = new byte[2];
                byte[] Value_2 = new byte[2];
                Value[0] = (byte)(speed1 % 256);
                Value[1] = (byte)(speed1 / 256);
                Value_2[0] = (byte)(distance1 % 256);
                Value_2[1] = (byte)(distance1 / 256);
                byte[] ValueM = new byte[1];
                ValueM[0] = 1;
                hCPLC.WriteH3U(SoftElemType.REGI_H3U_DW, SlideSpeed_2_DW, 1, Value, nNetId);//设置速度
                hCPLC.WriteH3U(SoftElemType.REGI_H3U_DW, SlideDis_2_DW_B, 1, Value_2, nNetId);//设置距离
                hCPLC.WriteH3U(SoftElemType.REGI_H3U_M, SlideBake_2_M, 1, ValueM, nNetId);// 启动后退句柄
            }
            else
            {
                byte[] ValueM = new byte[1];
                ValueM[0] =0;
                hCPLC.WriteH3U(SoftElemType.REGI_H3U_M, SlideBake_2_M, 1, ValueM, nNetId);// 停止滑台后退
                BackSate1 = false;
            }

        }

        public void LightControl(bool con)//卤素灯开关
        {
            if (con)
            {
                byte[] ValueM = new byte[1];
                ValueM[0] = 1;
                hCPLC.WriteH3U(SoftElemType.REGI_H3U_M, asLight_Control_M, 1, ValueM, nNetId);// 卤素灯启动
                BackSate1 = true;
            }
            else
            {
                byte[] ValueM = new byte[1];
                ValueM[0] = 0;
                hCPLC.WriteH3U(SoftElemType.REGI_H3U_M, asLight_Control_M, 1, ValueM, nNetId);// 卤素灯关闭
                BackSate1 = false;
            }

        }
        public void LED1_Control(bool con)//LED1开关
        {
            if (con)
            {
                byte[] ValueM = new byte[1];
                ValueM[0] = 1;
                hCPLC.WriteH3U(SoftElemType.REGI_H3U_M,LED1_Crontol_M,1, ValueM, nNetId);// LED1启动
                BackSate1 = true;
            }
            else
            {
                byte[] ValueM = new byte[1];
                ValueM[0] = 0;
                hCPLC.WriteH3U(SoftElemType.REGI_H3U_M, LED1_Crontol_M, 1, ValueM, nNetId);// LED1关闭
                BackSate1 = false;
            }

        }
        public void LED2_Control(bool con)//LED2开关
        {
            if (con)
            {
                byte[] ValueM = new byte[1];
                ValueM[0] = 1;
                hCPLC.WriteH3U(SoftElemType.REGI_H3U_M, LED2_Crontol_M,1, ValueM, nNetId);// LED2启动
                BackSate1 = true;
            }
            else
            {
                byte[] ValueM = new byte[1];
                ValueM[0] = 0;
                hCPLC.WriteH3U(SoftElemType.REGI_H3U_M, LED2_Crontol_M, 1, ValueM, nNetId);// LED2关闭
                BackSate1 = false;
            }

        }







        public bool SlideSateRead_1() //滑台1状态读取，水平滑台
        {
            byte[] a = hCPLC.ReadH3UBool(SoftElemType.REGI_H3U_M, SlideSate_1_M, 1, nNetId);
            if (a[0] == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool SlideSateRead_2() //滑台2状态读取，垂直滑台
        {
            byte[] a =  hCPLC.ReadH3UBool(SoftElemType.REGI_H3U_M, SlideSate_2_M, 1, nNetId);
            if (a[0] == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public double horizontalGet()
        {
            byte[] a = hCPLC.ReadH3UBool(SoftElemType.REGI_H3U_DW, SlideSpeed_1_DW, 2, nNetId);
            double b = ((int)(a[3] << 24 & 0xff000000) + (int)(a[2] << 16 & 0xff0000) + (int)(a[1] << 8 & 0xff00) + (int)(a[0] & 0xff)) ;
            return b;
           // return value;
        }

        public void verticalSet( double distance1)
        {

          
            int distanceup = (int)(distance1 * Distanceslope);
            byte[] Value_up = new byte[2];
            byte[] Value_up_2 = new byte[2];
          
            Value_up_2[0] = (byte)(distanceup % 256);
            Value_up_2[1] = (byte)(distanceup / 256);

            hCPLC.WriteH3U(SoftElemType.REGI_H3U_DW, SlideSpeed_2_DW, 1, Value_up, nNetId);//设置上升速度
            hCPLC.WriteH3U(SoftElemType.REGI_H3U_DW, SlideDis_2_DW, 1, Value_up_2, nNetId);


           

        }

        public double verticalGet()
        {
            byte[] a = hCPLC.ReadH3UBool(SoftElemType.REGI_H3U_DW, SlideSpeed_2_DW, 2, nNetId);
            double b = ((int)(a[3] << 24 & 0xff000000) + (int)(a[2] << 16 & 0xff0000) + (int)(a[1] << 8 & 0xff00) + (int)(a[0] & 0xff));
            return b;

            //value = hCPLC.ReadH3U(SoftElemType.REGI_H3U_DW, SlideSpeed_2_DW, 1, nNetId);
            //return value;
        }
    }
}
