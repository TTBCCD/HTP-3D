using m_CTP;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Canondemo
{
    public  class LidarHe16
    {
        UdpClient udpcRecv;
        public StreamWriter sw;
        double lidarMovingSpeed = 0;
        int freamCount = 0;
        public static double temperature1 = 0;
        double TimeNow1 = 0;//seconds
        double TimeNow = 0;//seconds
        double CarDistance = 0;
        public int leftDataBytesNum = 0;
        //Thread thrRecv;

        //double CarDistance = 0;
        //连接服务器
        //创建数据流

        public void UdpServices()//建立客户端
        {
            try
            {
              
                IPAddress ip = IPAddress.Parse("192.168.1.102");
                IPEndPoint remoteIpep = new IPEndPoint(ip, 6699);
                udpcRecv = new UdpClient(remoteIpep);
                freamCount = 0;
                CarDistance = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误", "请检查网络");
            }

        }
        public void UdpServices_setting()//建立客户端
        {
            try
            {

                IPAddress ip = IPAddress.Parse("192.168.1.102");
                IPEndPoint remoteIpep = new IPEndPoint(ip, 7788);
                udpcRecv = new UdpClient(remoteIpep);
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误", "请检查网络");
            }

        }
        public void STartGard_setting()
        {
            Thread thrRecv = new Thread(ReceiveMessage22_1);
            thrRecv.IsBackground = true;
            thrRecv.Start();
            
        }
        public void UdpServices_Dispose() 
        {
            //thrRecv.Abort();
            udpcRecv.Close();
            udpcRecv.Dispose();
        }
        public void STartGard()
        {
            Thread thrRecv = new Thread(ReceiveMessage22);
            thrRecv.IsBackground = true;
            thrRecv.Start();
            CarDistance = 0;
        }
        delegate int OnBufferReceChange(byte[] buffer, int length); // 声明委托

        public void CloseTask()
        {
            Lidar_Set.TH = false;
        }

        public void UDPsend(byte[] buffer)//发送数据到指定地址
        {
            IPAddress ip = IPAddress.Parse("192.168.1.200");
            IPEndPoint remoteIpep = new IPEndPoint(ip, 6699);
            udpcRecv.Send(buffer, buffer.Length, remoteIpep);//

        }
        private void ReceiveMessage22_1()//从服务器上获取数据
        {
            OnBufferReceChange onBufferReceChange = new OnBufferReceChange(DeCodeData_HE16_1); //实例化委托，绑定到DeCodeData
            IPAddress ip = IPAddress.Parse("192.168.1.200");
            IPEndPoint remoteIpep = new IPEndPoint(ip, 7788);
            Console.WriteLine("-----remoteIpep:" + remoteIpep.Address + ":" + remoteIpep.Port);
            while (Lidar_Set.TH)
            {
                try
                {
                    byte[] bytRecv = udpcRecv.Receive(ref remoteIpep);//在远程主机获取数据
                    string message = Encoding.UTF8.GetString(
                        bytRecv, 0, bytRecv.Length);
                    onBufferReceChange(bytRecv, bytRecv.Length);
                    Console.WriteLine("-----reveice  message:" + message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("UDP异常", ex.Message);
                }
            }

        }
        private void ReceiveMessage22()//从服务器上获取数据
        {
            OnBufferReceChange onBufferReceChange = new OnBufferReceChange(DeCodeData_HE16); //实例化委托，绑定到DeCodeData
            IPAddress ip = IPAddress.Parse("192.168.1.200");
            IPEndPoint remoteIpep = new IPEndPoint(ip, 6699);
            Console.WriteLine("-----remoteIpep:" + remoteIpep.Address + ":" + remoteIpep.Port);
            while (Lidar_Set.TH)
            {
                try
                {
                    byte[] bytRecv = udpcRecv.Receive(ref remoteIpep);//在远程主机获取数据
                    string message = Encoding.UTF8.GetString(
                        bytRecv, 0, bytRecv.Length);
                    onBufferReceChange(bytRecv, bytRecv.Length);
                    Console.WriteLine("-----reveice  message:" + message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("UDP异常", ex.Message);
                }
            }

        }
        private int DeCodeData_HE16_1(byte[] buffer, int length)//获取校准数据
        {

            bool findHead = false;
            bool fsum = false;
            int LoopIndex = 0;
            double AngleMultiple = 0;
            double Intervaltime = 0;
            // 
            Console.WriteLine("buffer length: " + buffer.Length);
            //解析收到的数据
            leftDataBytesNum = buffer.Length; //剩余字节数 初始化为 buffer总长度

            while (leftDataBytesNum >= 1248) //当剩余的字节数多余2个，继续下一个循环再次
            {
                //1. 判断报文头部
                if (buffer[0] == (char)0xa5 && buffer[1] == (char)0xff && buffer[2] == (char)0x00 && buffer[3] == (char)0x5a && buffer[4] == (char)0x11 && buffer[5] == (char)0x11 && buffer[6] == (char)0x55 && buffer[7] == (char)0x55)
                {
                    for (int i =0;i<16;i++) 
                    {
                        if (buffer[468+i*3]== (char)0x00)
                        {
                            double S1 = ((double)((buffer[468 +1+i*3] << 8 & 0xff00) + (double)buffer[468 + 2+ i * 3]))*0.01;
                            sw.WriteLine(S1.ToString("f3"));
                        }
                        else 
                        {
                            double S1 = -((double)((buffer[468 + 1 + i * 3] << 8 & 0xff00) + (double)buffer[468 + 2 + i * 3]))*0.01;
                            sw.WriteLine(S1.ToString("f3"));
                        }
  
                    }
                    buffer = buffer.Skip(1248).ToArray();
                    leftDataBytesNum = buffer.Length;
                }
                else
                {
                    buffer = buffer.Skip(1).ToArray();
                    leftDataBytesNum = buffer.Length;
                }
                
            }
           
            return 0;

        }
        private int DeCodeData_HE16(byte[] buffer, int length)
        {

            bool findHead = false;
            bool fsum = false;
            int LoopIndex = 0;
            double AngleMultiple = 0;
            double Intervaltime = 0;
            // 
            Console.WriteLine("buffer length: " + buffer.Length);
            //解析收到的数据
            leftDataBytesNum = buffer.Length; //剩余字节数 初始化为 buffer总长度

            while (leftDataBytesNum >= 1248) //当剩余的字节数多余2个，继续下一个循环再次
            {
                //1. 判断报文头部
                if (buffer[0] == (char)0x55 && buffer[1] == (char)0xaa && buffer[2] == (char)0x05 && buffer[3] == (char)0x5a)
                {
                    findHead = true;
                    Console.WriteLine("Find head");
                    freamCount++; //
                }
                if (!findHead)
                {
                    return -1; //buffer开始的字节不是报文头部，扔掉.通过增加每次收取的间隔时间，确保每次都能收到1个或者多个完整报文。
                    //这里也可能是上一个报文的后半部分
                }
                /*计算获得两次数据的间隔时间*/
                if (freamCount > 1)
                {
                    TimeNow1 = TimeNow;
                    TimeNow = (double)((buffer[20] << 40 & 0xff0000000000) + (buffer[21] << 32 & 0xff000000) + (buffer[22] << 24 & 0xff000000) + (buffer[23] << 16 & 0xff0000) + (buffer[24] << 8 & 0xff00) + (buffer[25] & 0xff))
                              + ((double)((buffer[26] << 24 & 0xff000000) + (buffer[27] << 16 & 0xff0000) + (buffer[28] << 8 & 0xff00) + (buffer[29] & 0xff))) / 1000000;
                    Intervaltime = TimeNow - TimeNow1;
                    CarDistance = CarDistance + lidarMovingSpeed * Intervaltime;
                }
                else
                {
                    Intervaltime = 0;
                    TimeNow = (double)((buffer[20] << 40 & 0xff0000000000) + (buffer[21] << 32 & 0xff000000) + (buffer[22] << 24 & 0xff000000) + (buffer[23] << 16 & 0xff0000) + (buffer[24] << 8 & 0xff00) + (buffer[25] & 0xff))
                             + ((double)((buffer[26] << 24 & 0xff000000) + (buffer[27] << 16 & 0xff0000) + (buffer[28] << 8 & 0xff00) + (buffer[29] & 0xff))) / 1000000;
                    CarDistance = CarDistance + lidarMovingSpeed * Intervaltime;
                }

                buffer = buffer.Skip(42).ToArray();
                /**/
                //解析报文长度
                if (buffer[0] == (char)0xff && buffer[1] == (char)0xee)
                {
                    while (LoopIndex < 1200)
                    {


                        for (int i = 0; i < 32; i++)
                        {

                            if (i<16)
                            {

                                double HorizontalAngle = (((double)((buffer[LoopIndex + 2] << 8 & 0xff00) + (double)buffer[LoopIndex + 3])) / 100);
                                //𝑥 = 𝑟 𝑐𝑜𝑠( 𝜔) 𝑠𝑖𝑛( 𝛼) + R 𝑐𝑜𝑠( 𝛼);其中 r 为实测距离，ω 为激光的垂直角度，α 为激光的水平旋转角度，R 为
                                //光心到原点的平面半径，x, y, z 为极坐标投影到笛卡尔 X, Y, Z 轴上的坐标
                                //𝑦 = 𝑟 𝑐𝑜𝑠( 𝜔) 𝑐𝑜𝑠( 𝛼) +R 𝑠𝑖𝑛( 𝛼);
                                //𝑧 = 𝑟 𝑠𝑖𝑛( 𝜔);
                                //600rpm
                                //lidarMovingSpeed
                                //一个数据块内Z坐标几乎相同
                                //按照小车速度0.093m/m 一个数据块时间小车行走0.124mm
                                HorizontalAngle = HorizontalAngleCal(HorizontalAngle,i);
                                if (HorizontalAngle>360) 
                                {
                                    HorizontalAngle = HorizontalAngle - 360;
                                }
                                if (HorizontalAngle<0) 
                                {
                                    HorizontalAngle = 360 + HorizontalAngle;
                                }
                                double VerticalAngle = VerticalAngleCal(i); ;
                                double r = ((double)((buffer[LoopIndex + 4 + (i * 3)] << 8 & 0xff00) + (double)buffer[LoopIndex + 4 + (i * 3) + 1])) * 0.25 / 100;
                                double y = (double)(r * Math.Cos(VerticalAngle / 180 * Math.PI) * Math.Sin(HorizontalAngle / 180 * Math.PI)); //y坐标
                                double z = 1.5-(double)(r * Math.Cos(VerticalAngle / 180 * Math.PI) * Math.Cos(HorizontalAngle / 180 * Math.PI));//z坐标
                                double x = 0;
                                if (VerticalAngle > 0)
                                {
                                    x = -((double)(r * Math.Sin(VerticalAngle / 180 * Math.PI)) + CarDistance);//z
                                }
                                //if (MainForm.ST == true)
                               // {
                                   sw.WriteLine(y.ToString("f3") + " " + z.ToString("f3")+ " "+ x.ToString("f3")); //空格分隔
                                     //sw.WriteLine(r.ToString("f3"));
                                    //sw.WriteLine(HorizontalAngle.ToString());
                                //}
                            }
                            else if(i>16)
                            {
                                double HorizontalAngle;// ((double)((buffer[LoopIndex + 2] << 8 & 0xff00) + (ushort)buffer[LoopIndex + 3])) / 100;
                                double  HorizontalAngle_1 = (((double)((buffer[LoopIndex + 2] << 8 & 0xff00) + (double)buffer[LoopIndex + 3])) / 100);
                                double HorizontalAngle_2 = (((double)((buffer[LoopIndex +100+ 2] << 8 & 0xff00) + (double)buffer[LoopIndex+100 + 3])) / 100);
                                if (LoopIndex != 1100)
                                {
                                    if (HorizontalAngle_1 > HorizontalAngle_2)
                                    {
                                        HorizontalAngle = HorizontalAngle_1 + (HorizontalAngle_2 + 360 - HorizontalAngle_1) / 2;
                                    }
                                    else 
                                    {
                                        HorizontalAngle = HorizontalAngle_1 + (HorizontalAngle_2 - HorizontalAngle_1) / 2;
                                    }
                                    if (HorizontalAngle  < 30 || HorizontalAngle > 330)
                                    {
                                        HorizontalAngle = HorizontalAngleCal(HorizontalAngle, i - 16);
                                        if (HorizontalAngle > 360)
                                        {
                                            HorizontalAngle = HorizontalAngle - 360;
                                        }
                                        if (HorizontalAngle < 0)
                                        {
                                            HorizontalAngle = HorizontalAngle + 360;
                                        }
                                        double VerticalAngle = VerticalAngleCal(i - 16);

                                        double r = ((double)((buffer[LoopIndex + 4 + (i * 3)] << 8 & 0xff00) + buffer[LoopIndex + 4 + (i * 3) + 1])) * 0.25 / 100;
                                        double y = (double)(r * Math.Cos(VerticalAngle / 180 * Math.PI) * Math.Sin(HorizontalAngle / 180 * Math.PI)); //X坐标
                                        double z = 1.5-(double)(r * Math.Cos(VerticalAngle / 180 * Math.PI) * Math.Cos(HorizontalAngle / 180 * Math.PI));//y坐标
                                        double x = 0;
                                        if (VerticalAngle > 0)
                                        {
                                            x = -((double)(r * Math.Sin(VerticalAngle / 180 * Math.PI)) + CarDistance);//z
                                        }
                                        else
                                        {
                                            x = -((double)(r * Math.Sin((VerticalAngle / 180 * Math.PI))) + CarDistance);
                                        }

                                        sw.WriteLine(y.ToString("f3") + " " + z.ToString("f3")+ " "+ x.ToString("f3")); //空格分隔
                                                                                                                          // sw.WriteLine(VerticalAngle.ToString("f3")+","+r.ToString("f3")+","+ HorizontalAngle.ToString("f3"));                                                                               //sw.WriteLine(HorizontalAngle.ToString());                                                                                    //}                                                                                     // sw.WriteLine(HorizontalAngle.ToString("f3"))
                                    }
                                    else 
                                    {
                                        
                                    }

                                }

                            }

                        }
                        LoopIndex = LoopIndex + 100;
                    }
                    buffer = buffer.Skip(1206).ToArray();
                    leftDataBytesNum = buffer.Length;
                }
                else
                {
                    buffer = buffer.Skip(1206).ToArray();
                    leftDataBytesNum = buffer.Length;
                }

            }
            return 0;

        }

        public void WriteSteam(double lidarMovingSpeed1, string lidarDataSaveFilePath)//创建数据流
        {
            lidarMovingSpeed = lidarMovingSpeed1;
             sw = new StreamWriter(lidarDataSaveFilePath, false);
            
        }
        public double VerticalAngleCal(int a)//USB->电源速度改成为正，反方向速度为负
        {
            double hc = 0;
            switch (a) 
            {
                case 0:
                    hc = 12.99;
                    break;
                case 1:
                    hc =14.98;
                    break;
                case 2:
                    hc =8.99;
                    break;
                case 3:
                    hc = 10.99;
                    break;
                case 4:
                    hc =5;
                    break;
                case 5:
                    hc =6.99;
                    break;
                case 6:
                    hc = 1;
                    break;
                case 7:
                    hc = 3;
                    break;
                case 8:
                    hc =-3;//-3
                    break;
                case 9:
                    hc =-1;//-1
                    break;
                case 10:
                    hc =-6.99;
                    break;
                case 11:
                    hc =-4.99;
                    break;
                case 12:
                    hc = -10.99;
                    break;
                case 13:
                    hc =-8.99;
                    break;
                case 14:
                    hc = -14.99;
                    break;
                case 15:
                    hc = -12.99;
                    break;

            }
            return hc;
        }
        public double HorizontalAngleCal(double h, int a)
        {
            double hc = 0;
            switch (a)
            {
                case 0:
                    hc = h + 3.16;
                    break;
                case 1:
                    hc = h - 7.65;
                    break;
                case 2:
                    hc = h + 3.13;
                    break;
                case 3:
                    hc = h - 7.57;
                    break;
                case 4:
                    hc = h + 3.12;
                    break;
                case 5:
                    hc = h - 7.51;
                    break;
                case 6:
                    hc = h + 3.11;
                    break;
                case 7:
                    hc = h - 7.48;
                    break;
                case 8:
                    hc = h + 3.11;
                    break;
                case 9:
                    hc = h - 7.48;
                    break;
                case 10:
                    hc = h + 3.12;
                    break;
                case 11:
                    hc = h - 7.49;
                    break;
                case 12:
                    hc = h + 3.15;
                    break;
                case 13:
                    hc = h - 7.54;
                    break;
                case 14:
                    hc = h + 3.18;
                    break;
                case 15:
                    hc = h - 7.61;
                    break;

            }
            return hc;
        }
        public void DisposeSteam() //释放数据流
        {
            while (leftDataBytesNum>1000) 
            { 

            }
            sw.Flush();
            sw.Dispose();
        }
    }
   


}
