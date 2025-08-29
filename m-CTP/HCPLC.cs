using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace m_CTP
{
    public enum SoftElemType
    {
        //AM600
        ELEM_QX = 0,     //QX元件
        ELEM_MW = 1,     //MW元件
        ELEM_X = 2,		 //X元件(对应QX200~QX300)
        ELEM_Y = 3,		 //Y元件(对应QX300~QX400)

        //H3U
        REGI_H3U_Y = 0x20,       //Y元件的定义	
        REGI_H3U_X = 0x21,		//X元件的定义							
        REGI_H3U_S = 0x22,		//S元件的定义				
        REGI_H3U_M = 0x23,		//M元件的定义							
        REGI_H3U_TB = 0x24,		//T位元件的定义				
        REGI_H3U_TW = 0x25,		//T字元件的定义				
        REGI_H3U_CB = 0x26,		//C位元件的定义				
        REGI_H3U_CW = 0x27,		//C字元件的定义				
        REGI_H3U_DW = 0x28,		//D字元件的定义				
        REGI_H3U_CW2 = 0x29,	    //C双字元件的定义
        REGI_H3U_SM = 0x2a,		//SM
        REGI_H3U_SD = 0x2b,		//
        REGI_H3U_R = 0x2c,		//
        //H5u
        REGI_H5U_Y = 0x30,       //Y元件的定义	
        REGI_H5U_X = 0x31,		//X元件的定义							
        REGI_H5U_S = 0x32,		//S元件的定义				
        REGI_H5U_M = 0x33,		//M元件的定义	
        REGI_H5U_B = 0x34,       //B元件的定义
        REGI_H5U_D = 0x35,       //D字元件的定义
        REGI_H5U_R = 0x36,       //R字元件的定义

    }
    class HCPLC
    {
        #region //标准库
        [DllImport("StandardModbusApi.dll", EntryPoint = "Init_ETH_String", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool Init_ETH_String(string sIpAddr, int nNetId, int IpPort);

        [DllImport("StandardModbusApi.dll", EntryPoint = "Exit_ETH", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool Exit_ETH(int nNetId );

        [DllImport("StandardModbusApi.dll", EntryPoint = "H3u_Write_Soft_Elem", CallingConvention = CallingConvention.Cdecl)]
        public static extern int H3u_Write_Soft_Elem(SoftElemType eType, int nStartAddr, int nCount, byte[] pValue, int nNetId = 0);

        [DllImport("StandardModbusApi.dll", EntryPoint = "H3u_Read_Soft_Elem", CallingConvention = CallingConvention.Cdecl)]
        public static extern int H3u_Read_Soft_Elem(SoftElemType eType, int nStartAddr, int nCount, byte[] pValue, int nNetId = 0);

        [DllImport("StandardModbusApi.dll", EntryPoint = "H3u_Read_Soft_Elem_Float", CallingConvention = CallingConvention.Cdecl)]
        public static extern int H3u_Read_Soft_Elem_Float(SoftElemType eType, int nStartAddr, int nCount, float[] pValue, int nNetId = 0);

        [DllImport("StandardModbusApi.dll", EntryPoint = "H5u_Write_Soft_Elem", CallingConvention = CallingConvention.Cdecl)]
        public static extern int H5u_Write_Soft_Elem(SoftElemType eType, int nStartAddr, int nCount, byte[] pValue, int nNetId = 0);

        [DllImport("StandardModbusApi.dll", EntryPoint = "H5u_Read_Soft_Elem", CallingConvention = CallingConvention.Cdecl)]
        public static extern int H5u_Read_Soft_Elem(SoftElemType eType, int nStartAddr, int nCount, byte[] pValue, int nNetId = 0);

        [DllImport("StandardModbusApi.dll", EntryPoint = "H5u_Read_Soft_Elem_Float", CallingConvention = CallingConvention.Cdecl)]
        public static extern int H5u_Read_Soft_Elem_Float(SoftElemType eType, int nStartAddr, int nCount, float[] pValue, int nNetId = 0);


        [DllImport("StandardModbusApi.dll", EntryPoint = "Am600_Write_Soft_Elem", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Am600_Write_Soft_Elem(SoftElemType eType, int nStartAddr, int nCount, byte[] pValue, int nNetId = 0);

        [DllImport("StandardModbusApi.dll", EntryPoint = "Am600_Read_Soft_Elem", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Am600_Read_Soft_Elem(SoftElemType eType, int nStartAddr, int nCount, byte[] pValue, int nNetId = 0);

        #endregion
        public void ConnectPLC(string ip, int nNetId, int nIpPort)//连接PLC
        {
            //int nNetId1 = 0;
            //int nIpPort1 = 502;
            
            bool result = Init_ETH_String(ip, nNetId, nIpPort);

            if (result == true)
                MessageBox.Show("连接成功");
            else
                MessageBox.Show("连接失败");
        }
        public void ClosePLC(int nNetId)//断开PLC
        {
          
            bool result = Exit_ETH(nNetId);
            if (result == true)
                MessageBox.Show("连接关闭");
            else
                MessageBox.Show("关闭连接失败");
        }
        public void WriteH3U( SoftElemType kind,int nStartAddr, int nCount, byte[] pValue, int nNetId)//写入元件
        {
            if (nCount == 1) 
            //代码示例1：把65534写入D100中
            {
                //int nStartAddr = 100;//寄存器地址
                //int nCount = 1;//寄存器个数
                //byte[] pValue = new byte[2];//缓冲区
                //int nNetId = 0;//连接id
                ushort nValue = 65534;

                //把要写的数据存入缓冲区，备写
               // pValue[0] = (byte)(nValue % 256);
               // pValue[1] = (byte)(nValue / 256);

                //调用api写数据
                int nRet = H3u_Write_Soft_Elem(kind, nStartAddr, nCount, pValue, nNetId);
               // int nRet = H3u_Write_Soft_Elem(SoftElemType.REGI_H3U_M, nStartAddr, nCount, ValueM, nNetId);
                if (1 == nRet)
                {
                   //MessageBox.Show(("写寄存器成功"));
                   Form1.ProgramChecking = "写入单个寄存器成功";
                }
                else
                {
                   // MessageBox.Show(("写寄存器失败"));
                    Form1.ProgramChecking = "写入单个寄存器失败";
                }
            }
            else if(nCount>1)
            //代码示例2：把Y5-Y14置位
            {
                

                //调用api写数据
                int nRet = H3u_Write_Soft_Elem(kind, nStartAddr, nCount, pValue, nNetId);

                if (1 == nRet)
                {
                    //MessageBox.Show(("写寄存器成功"));
                    Form1.ProgramChecking = "写入多个寄存器成功";
                }
                else
                {
                    //MessageBox.Show(("写寄存器失败"));
                    Form1.ProgramChecking = "写入多个寄存器失败";
                }
            }
        }
        public float ReadH3U(SoftElemType kind, int nStartAddr, int nCount, int nNetId)//读取单个数据
        {
            {
                //int nStartAddr = 100;
                //int nCount = 2;
                float[] pValue = new float[1];//缓冲区
               // int nNetId = 0;

                int nRet = H3u_Read_Soft_Elem_Float(kind, nStartAddr, nCount, pValue, nNetId);

                float fValue = pValue[0];

                if (1 == nRet)
                {
                    Form1.ProgramChecking = "读取单个寄存器成功";
                }
                else
                {
                    //MessageBox.Show(("读寄存器失败"));
                    Form1.ProgramChecking = "读取单个寄存器失败";
                }
                return fValue;
            }

            //代码示例2：把Y5-Y13置位
           

        }
        public byte[] ReadH3UBool(SoftElemType kind, int nStartAddr, int nCount, int nNetId) //读取bool
        {
            
                //int nStartAddr = 5;//寄存器起始地址
                //int nCount = 7;//寄存器个数
                byte[] pValue = new byte[4];//缓冲区(要是8的整数倍)
                //int nNetId = 0;//连接id
                //bool[] Y = new bool[7];//缓冲区(要是8的整数倍)

                //调用api写数据
                int nRet = H3u_Read_Soft_Elem(kind, nStartAddr, nCount, pValue, nNetId);
                if (1 == nRet)
                {
                   //MessageBox.Show(("读寄存器成功"));
                Form1.ProgramChecking = "读取开关成功";
                 }
                else
                {
                // MessageBox.Show(("读寄存器失败"));
                Form1.ProgramChecking = "读取开关失败";
                }
                return pValue;
        }
    }
}
