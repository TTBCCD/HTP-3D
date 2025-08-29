using MathNet.Numerics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace m_CTP
{
    public class TransmitPLC
    {
        HCPLC hCPLC;
        private const int nNetId = 0;//传送带PLC ID = 0
        public const int StowageMode = 1001;//装载模式
        public const int MeasureMode = 1000;//测量模式
        public const int UnloadMode = 1002;//卸载模式
        public const int MannelMode = 1203;//手动模式
        private bool StowageSate = false;
        private bool MeasureModeSate = false;
        private bool UnloadModeSate = false;
        private const double speedslope = 5602;//速度转脉冲频率数据
        private const int Distanceslope = 5556;//距离转脉冲数数据

        //private const int SlideFor_2_M = 1011;//滑台2前进线圈
        //private const int SlideBake_2_M = 1012;//滑台2后退线圈
        //private const int SlideSpeed_2_DW = 1014;//DW滑台2速度寄存器地址
        //private const int SlideDis_2_DW = 1012;//DW滑台2距离寄存器地址
        //private const int SlideSpeed_1_DW = 1014;//DW滑台2速度寄存器地址
        //private const int SlideDis_1_DW = 1012;//DW滑台2距离寄存器地址
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



        private const int MeasurModeIndex = 1000;//数据寄存器
        private const int WaterControl_1 = 1003;//浇水开关
        private const int WaterControlNumber = 1002;//浇水数据寄存器
        private const int WeighControl_1 = 1004;//称重总开关
        private const int SingleWeighCon = 1005;//单次称重完成控制
        private const int SingleWeighComplete = 1101;//单次称重完成信号
        private const int SingleWeighCompleteData = 1004;//称重完成数据
        private const int Turntablenum = 1006;//转台单次转动角度
        private const int TurntablenCON = 1007;//单次转台转动控制
        public TransmitPLC()
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

        //启动传送带模式1
        //启动传送带模式2
        //启动传送带模式3
        //停止传送带
        public bool MearMode_Stowage(bool con) //装载模式
        {
            if (con)
            {
                byte[] ValueM = new byte[1];
                ValueM[0] = (byte)1;
                hCPLC.WriteH3U(SoftElemType.REGI_H3U_M, StowageMode, 1, ValueM, nNetId);
                StowageSate = true;
                return false;
            }
            else
            {
                byte[] ValueM1 = new byte[1];
                ValueM1[0] = (byte)0;
                hCPLC.WriteH3U(SoftElemType.REGI_H3U_M, StowageMode, 1, ValueM1, nNetId);
                StowageSate = false;
                return false;
            }

        }
        public bool MearMode_Measure(bool con) //测量模式
        {
            if (con)
            {
                byte[] ValueM = new byte[1];
                ValueM[0] = (byte)1;
                hCPLC.WriteH3U(SoftElemType.REGI_H3U_M, MeasureMode, 1, ValueM, nNetId);
                MeasureModeSate = true;
                return false;
            }
            else
            {
                byte[] ValueM = new byte[1];
                ValueM[0] = (byte)0;
                hCPLC.WriteH3U(SoftElemType.REGI_H3U_M, MeasureMode, 1, ValueM, nNetId);
                MeasureModeSate = false;
                return false;
            }

        }
        public bool MearMode_Unload(bool con) //卸载模式
        {
            if (con)
            {
                byte[] ValueM = new byte[1];
                ValueM[0] = (byte)1;
                hCPLC.WriteH3U(SoftElemType.REGI_H3U_M, UnloadMode, 1, ValueM, nNetId);
                UnloadModeSate = true;
                return false;
            }
            else
            {
                byte[] ValueM = new byte[1];
                ValueM[0] = (byte)0;
                hCPLC.WriteH3U(SoftElemType.REGI_H3U_M, UnloadMode, 1, ValueM, nNetId);
                UnloadModeSate = false;
                return false;
            }
        }
        public bool MearMode_Mannel(bool con) //手动模式
        {
            if (con)
            {
                byte[] ValueM = new byte[1];
                ValueM[0] = (byte)1;
                hCPLC.WriteH3U(SoftElemType.REGI_H3U_M, MannelMode, 1, ValueM, nNetId);
                UnloadModeSate = true;
                return false;
            }
            else
            {
                byte[] ValueM = new byte[1];
                ValueM[0] = (byte)0;
                hCPLC.WriteH3U(SoftElemType.REGI_H3U_M, MannelMode, 1, ValueM, nNetId);
                UnloadModeSate = false;
                return false;
            }
        }

        public int ReadMearmodeSET() //读取测量模式设置状态
        {
            byte[] a = hCPLC.ReadH3UBool(SoftElemType.REGI_H3U_M, MeasurModeIndex, 1, nNetId);
            return (int)a[0];
        }
        public int ReadLoadmodeSET() //读取装载模式设置状态
        {
            byte[] a = hCPLC.ReadH3UBool(SoftElemType.REGI_H3U_M, StowageMode, 1, nNetId);
            return (int)a[0];
        }
        public int ReadUnloadmodeSET() //读取卸载模式设置状态
        {
            byte[] a = hCPLC.ReadH3UBool(SoftElemType.REGI_H3U_M, UnloadMode, 1, nNetId);
            return (int)a[0];
        }
        public int ReadMannelmodeSET() //读取手动模式设置状态
        {
            byte[] a = hCPLC.ReadH3UBool(SoftElemType.REGI_H3U_M, MannelMode, 1, nNetId);
            return (int)a[0];
        }
        public float Read_M(int id) //读取线圈数据
        {
            return hCPLC.ReadH3U(SoftElemType.REGI_H3U_M, id, 1, nNetId);
        }
        public float Read_D(int id) //读取寄存器数据
        {
            return hCPLC.ReadH3U(SoftElemType.REGI_H3U_DW, id, 1, nNetId);
        }

        public bool WaterControl(bool con, int num) //浇水模式
        {
            if (con)
            {
                byte[] Value = new byte[2];
                Value[0] = (byte)(num % 256);
                Value[1] = (byte)(num / 256);
                byte[] ValueM = new byte[1];
                ValueM[0] = (byte)1;
                hCPLC.WriteH3U(SoftElemType.REGI_H3U_DW, WaterControlNumber, 1, Value, nNetId);
                hCPLC.WriteH3U(SoftElemType.REGI_H3U_M, WaterControl_1, 1, ValueM, nNetId);
                UnloadModeSate = true;
                Form1.ProgramChecking = "启用浇水成功";
                return true;
            }
            else
            {
                byte[] ValueM = new byte[1];
                ValueM[0] = (byte)0;
                hCPLC.WriteH3U(SoftElemType.REGI_H3U_M, WaterControl_1, 1, ValueM, nNetId);
                UnloadModeSate = false;
                Form1.ProgramChecking = "停用浇水模式成功";
                return false;
            }
        }
        public void WaterSet(int num) //浇水量设置
        {
            byte[] Value = new byte[2];
            Value[0] = (byte)(num % 256);
            Value[1] = (byte)(num / 256);
            hCPLC.WriteH3U(SoftElemType.REGI_H3U_DW, WaterControlNumber, 1, Value, nNetId);
        }

        public bool WeighControl(bool con) //称重模式
        {
            if (con)
            {
                byte[] ValueM = new byte[1];
                ValueM[0] = (byte)1;
                hCPLC.WriteH3U(SoftElemType.REGI_H3U_M, WeighControl_1, 1, ValueM, nNetId);
                UnloadModeSate = true;
                Form1.ProgramChecking = "启用称重成功";
                return false;
            }
            else
            {
                byte[] ValueM = new byte[1];
                ValueM[0] = (byte)0;
                hCPLC.WriteH3U(SoftElemType.REGI_H3U_M, WeighControl_1, 1, ValueM, nNetId);
                UnloadModeSate = false;
                Form1.ProgramChecking = "停用称重成功";
                return false;
            }
        }
        public bool WeighControlComplete(bool con) //称重完成指令
        {
            if (con)
            {
                byte[] ValueM = new byte[1];
                ValueM[0] = (byte)1;
                hCPLC.WriteH3U(SoftElemType.REGI_H3U_M, SingleWeighCon, 1, ValueM, nNetId);
                Thread.Sleep(2000);
                ValueM[0] = (byte)0;
                hCPLC.WriteH3U(SoftElemType.REGI_H3U_M, SingleWeighCon, 1, ValueM, nNetId);
                UnloadModeSate = true;
            }
            return false;
        }
        public bool WeighCompleteSingle(bool con) //称重完成信号
        {
            byte[] a = hCPLC.ReadH3UBool(SoftElemType.REGI_H3U_M, SingleWeighComplete, 1, nNetId);
            if (a[0] == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public double WeighDataRead() //称重完成数据
        {
            byte[] a = hCPLC.ReadH3UBool(SoftElemType.REGI_H3U_DW, SingleWeighCompleteData, 2, nNetId);
            double b = ((double)(a[3] << 24 & 0xff000000) + (double)(a[2] << 16 & 0xff0000) + (double)(a[1] << 8 & 0xff00) + (double)(a[0] & 0xff)) / 10;
            return b;
        }

        public bool TurntableNUM(int num) //转台控制
        {

            byte[] Value = new byte[2];
            Value[0] = (byte)(num % 256);
            Value[1] = (byte)(num / 256);
            hCPLC.WriteH3U(SoftElemType.REGI_H3U_DW, Turntablenum, 1, Value, nNetId);

            return true;
        }
        public bool TurntableControl(bool con) //转台控制
        {
            byte[] ValueM = new byte[1];
            ValueM[0] = (byte)1;
            hCPLC.WriteH3U(SoftElemType.REGI_H3U_M, TurntablenCON, 1, ValueM, nNetId);
            Thread.Sleep(500);
            ValueM[0] = (byte)0;
            hCPLC.WriteH3U(SoftElemType.REGI_H3U_M, TurntablenCON, 1, ValueM, nNetId);

            return true;
        }
        public bool StartControl() //开始运行按键
        {
            byte[] ValueM = new byte[1];
            ValueM[0] = (byte)1;
            hCPLC.WriteH3U(SoftElemType.REGI_H3U_M, 1020, 1, ValueM, nNetId);
            Thread.Sleep(500);
            ValueM[0] = (byte)0;
            hCPLC.WriteH3U(SoftElemType.REGI_H3U_M, 1020, 1, ValueM, nNetId);
            return true;
        }
        public bool StopControl() //停止按键
        {
            byte[] ValueM = new byte[1];
            ValueM[0] = (byte)1;
            hCPLC.WriteH3U(SoftElemType.REGI_H3U_M, 1021, 1, ValueM, nNetId);
            Thread.Sleep(500);
            ValueM[0] = (byte)0;
            hCPLC.WriteH3U(SoftElemType.REGI_H3U_M, 1021, 1, ValueM, nNetId);
            return true;
        }
        public bool RsetControl() //复位按键
        {
            byte[] ValueM = new byte[1];
            ValueM[0] = (byte)1;
            hCPLC.WriteH3U(SoftElemType.REGI_H3U_M, 1022, 1, ValueM, nNetId);
            Thread.Sleep(500);
            ValueM[0] = (byte)0;
            hCPLC.WriteH3U(SoftElemType.REGI_H3U_M, 1022, 1, ValueM, nNetId);
            return true;
        }
        public bool OneMearComplete(bool con) //本次测量结束,暗室1
        {
            if (con)
            {
                byte[] ValueM = new byte[1];
                ValueM[0] = (byte)1;
                hCPLC.WriteH3U(SoftElemType.REGI_H3U_M, 1008, 1, ValueM, nNetId);
                Thread.Sleep(1000);
                ValueM[0] = (byte)0;
                hCPLC.WriteH3U(SoftElemType.REGI_H3U_M, 1008, 1, ValueM, nNetId);
            }
            return true;
        }
        public bool OneMearComplete_H(bool con) //本次测量结束,暗室2
        {
            if (con)
            {
                byte[] ValueM = new byte[1];
                ValueM[0] = (byte)1;
                hCPLC.WriteH3U(SoftElemType.REGI_H3U_M, 1010, 1, ValueM, nNetId);
                Thread.Sleep(1000);
                ValueM[0] = (byte)0;
                hCPLC.WriteH3U(SoftElemType.REGI_H3U_M, 1010, 1, ValueM, nNetId);
            }
            return true;
        }
        public bool ReadTurntable() //转台转动到目标位置，暗室1
        {
            byte[] a = hCPLC.ReadH3UBool(SoftElemType.REGI_H3U_M, 1103, 1, nNetId);
            if (a[0] == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Reachhead() //带植株盆栽是否到达指定测量位置
        {
            byte[] a = hCPLC.ReadH3UBool(SoftElemType.REGI_H3U_M, 1102, 1, nNetId);
            if (a[0] == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Reachhead_H() //带植株盆栽是否到达暗室2指定测量位置
        {
            byte[] a = hCPLC.ReadH3UBool(SoftElemType.REGI_H3U_M, 1105, 1, nNetId);
            if (a[0] == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Slide_2_Forward(double speed, double distance, bool con)//滑台2前进控制，垂直滑台
        {
            if (con)
            {
                int speed1 = (int)(speed);
                int distance1 = (int)(distance * Distanceslope);
                byte[] Value = new byte[2];
                byte[] Value_2 = new byte[2];
                Value[0] = (byte)(speed1 % 256);
                Value[1] = (byte)(speed1 / 256);
                Value_2[0] = (byte)(distance1 % 256);
                Value_2[1] = (byte)(distance1 / 256);
                byte[] ValueM = new byte[1];
                ValueM[0] = (byte)1;
                hCPLC.WriteH3U(SoftElemType.REGI_H3U_DW, SlideSpeed_2_DW, 1, Value, nNetId);//设置速度
                hCPLC.WriteH3U(SoftElemType.REGI_H3U_M, SlideFor_2_M, 1, ValueM, nNetId);// 启动前进句柄

            }
            else
            {
                byte[] ValueM = new byte[1];
                ValueM[0] = (byte)0;
                hCPLC.WriteH3U(SoftElemType.REGI_H3U_M, SlideFor_2_M, 1, ValueM, nNetId);// 停止滑台前进

            }

        }
        public void Slide_2_Back(double speed, double distance, bool con)//滑台2后退控制，垂直滑台
        {
            if (con)
            {
                int speed1 = (int)(speed);
                int distance1 = (int)(distance * Distanceslope);
                byte[] Value = new byte[2];
                byte[] Value_2 = new byte[2];
                Value[0] = (byte)(speed1 % 256);
                Value[1] = (byte)(speed1 / 256);
                Value_2[0] = (byte)(distance1 % 256);
                Value_2[1] = (byte)(distance1 / 256);
                byte[] ValueM = new byte[1];
                ValueM[0] = 1;
                hCPLC.WriteH3U(SoftElemType.REGI_H3U_DW, SlideSpeed_2_DW, 1, Value, nNetId);//设置速度
                                                                                            // hCPLC.WriteH3U(SoftElemType.REGI_H3U_DW, SlideDis_2_DW, 1, Value_2, nNetId);//设置距离
                hCPLC.WriteH3U(SoftElemType.REGI_H3U_M, SlideBake_2_M, 1, ValueM, nNetId);// 启动后退句柄
            }
            else
            {
                byte[] ValueM = new byte[1];
                ValueM[0] = 0;
                hCPLC.WriteH3U(SoftElemType.REGI_H3U_M, SlideBake_2_M, 1, ValueM, nNetId);// 停止滑台后退

            }

        }
        public void LightControl(bool con)//卤素灯开关
        {
            if (con)
            {
                byte[] ValueM = new byte[1];
                ValueM[0] = 1;
                hCPLC.WriteH3U(SoftElemType.REGI_H3U_M, 1013, 1, ValueM, nNetId);// 启动后退句柄

            }
            else
            {
                byte[] ValueM = new byte[1];
                ValueM[0] = 0;
                hCPLC.WriteH3U(SoftElemType.REGI_H3U_M, 1013, 1, ValueM, nNetId);// 停止滑台后退
            }

        }
        public void DrakRoom1(bool con)//暗室1开关
        {
            if (!con)
            {
                byte[] ValueM = new byte[1];
                ValueM[0] = 1;
                hCPLC.WriteH3U(SoftElemType.REGI_H3U_M, 1006, 1, ValueM, nNetId);// 启动后退句柄

            }
            else
            {
                byte[] ValueM = new byte[1];
                ValueM[0] = 0;
                hCPLC.WriteH3U(SoftElemType.REGI_H3U_M, 1006, 1, ValueM, nNetId);// 停止滑台后退
            }

        }
        public void DrakRoom2(bool con)//暗室2开关
        {
            if (!con)
            {
                byte[] ValueM = new byte[1];
                ValueM[0] = 1;
                hCPLC.WriteH3U(SoftElemType.REGI_H3U_M, 1009, 1, ValueM, nNetId);// 启动后退句柄

            }
            else
            {
                byte[] ValueM = new byte[1];
                ValueM[0] = 0;
                hCPLC.WriteH3U(SoftElemType.REGI_H3U_M, 1009, 1, ValueM, nNetId);// 停止滑台后退
            }

        }
        public bool SlideSateRead_2() //滑台2状态读取，垂直滑台
        {
            byte[] a = hCPLC.ReadH3UBool(SoftElemType.REGI_H3U_M, 1107, 1, nNetId);
            if (a[0] == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }





        public void verticalSet(double speed1, double distance1,  double distance2)
        {

            int speedup = (int)(speed1 * speedslope);
            int distanceup = (int)(distance1 * Distanceslope);
            byte[] Value_up = new byte[2];
            byte[] Value_up_2 = new byte[2];
            Value_up[0] = (byte)(speedup % 256);
            Value_up[1] = (byte)(speedup / 256);
            Value_up_2[0] = (byte)(distanceup % 256);
            Value_up_2[1] = (byte)(distanceup / 256);

            hCPLC.WriteH3U(SoftElemType.REGI_H3U_DW, SlideSpeed_2_DW, 1, Value_up, nNetId);//设置上升速度
            hCPLC.WriteH3U(SoftElemType.REGI_H3U_DW, SlideDis_2_DW, 1, Value_up_2, nNetId);


            int distancefall = (int)(distance2 * Distanceslope); 
            byte[] Value_fall_2 = new byte[2];
            Value_fall_2[0] = (byte)(distancefall % 256);
            Value_fall_2[1] = (byte)(distancefall / 256);
            hCPLC.WriteH3U(SoftElemType.REGI_H3U_DW, SlideDis_2_DW_B, 1, Value_fall_2, nNetId);

        }
    
    
         public void horizontalSet(double speed1, double distance1, double distance2)
        {

            int speedfwd = (int)(speed1 * speedslope);
            int distancefwd = (int)(distance1 * Distanceslope);
            byte[] Value_fwd = new byte[2];
            byte[] Value_fwd_2 = new byte[2];
            Value_fwd[0] = (byte)(speedfwd % 256);
            Value_fwd[1] = (byte)(speedfwd / 256);
            Value_fwd_2[0] = (byte)(distancefwd % 256);
            Value_fwd_2[1] = (byte)(distancefwd / 256);

            hCPLC.WriteH3U(SoftElemType.REGI_H3U_DW, SlideSpeed_1_DW, 1, Value_fwd, nNetId);//设置上升速度
            hCPLC.WriteH3U(SoftElemType.REGI_H3U_DW, SlideDis_1_DW, 1, Value_fwd_2, nNetId);


            int distancebwd = (int)(distance2 * Distanceslope);
            byte[] Value_bwd_2 = new byte[2];
            Value_bwd_2[0] = (byte)(distancebwd % 256);
            Value_bwd_2[1] = (byte)(distancebwd / 256);

            hCPLC.WriteH3U(SoftElemType.REGI_H3U_DW, SlideDis_1_DW_B, 1, Value_bwd_2, nNetId);

        }

        public float verticalGet()
        {
            float value = 0;
            
            
            
           value= hCPLC.ReadH3U(SoftElemType.REGI_H3U_DW, SlideSpeed_2_DW, 1, nNetId);
            return value;   
        }
        public float horizontalGet()
        {
            float value = 0;



            value = hCPLC.ReadH3U(SoftElemType.REGI_H3U_DW, SlideSpeed_1_DW, 1, nNetId);
            return value;
        }


    }
}
