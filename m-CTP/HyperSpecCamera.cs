using Basler.Pylon;
using OpenCvSharp;
using SixLabors.ImageSharp.Memory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace m_CTP
{
    internal class HyperSpecCamera
    {
        public Camera camera; //Basler.Pylon相机，即高光谱相机成像单元

        static int spectrum_cols = 239;//默认监视空间点（光谱曲线）抽取位置

        static int current_col = 0;//生成光谱伪彩图
        static int rgb_mat_width = 640;//缓存帧数（光谱伪彩图宽度)
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

        public HyperSpecCamera()
        {
           
            //空
            // 这里不能新建相机连接，避免出现此类无法创建实例的情况。需要此类可以创建实例，然后调用其函数进行连接获得bool返回值

        }

        public bool detectDevices() //通过对设备检测，然后创建Camera类实例
        {
            // Create a camera object that selects the first camera device found.
            // More constructors are available for selecting a specific camera device.

            List<ICameraInfo> deviceList = IpConfigurator.EnumerateAllDevices(); // 检测相机设备

            //Console.WriteLine("{0}", deviceList.Count); //仅用于调试
            int k = 0;
            while (deviceList.Count <= 0) // 如果未检测到相机设备，则循环持续检测
            {
                Thread.Sleep(200);//每次检测相机前，先等待200ms
                //    Console.WriteLine("正在检测设备{0}", deviceList.Count); //仅用于调试
                deviceList = IpConfigurator.EnumerateAllDevices();
                k++;
                if (k > 5) //检测超过5次尝试链接，不能检测到相机，则返回false. 5次链接大概1s
                    return false;

            }

            camera = new Camera(CameraSelectionStrategy.FirstFound); // 选择第一个相机进行链接
            return true;
        }
        public bool open()
        {
           // bool a = camera.IsConnected;
            camera.Open(); //打开高光谱相机

            if (camera.IsOpen)
                return true;
            else
                return false;

        }
        public bool setParameters(HyperSpecCameraParameters p) // 设置高光谱相机的参数,设置之前需要先调用open
        {

            if (camera.IsOpen)
            {
                camera.Parameters[PLCamera.BinningHorizontal].TrySetValue(p.BinningHorizontal);//为了匹配光谱仪设置4像元合并
                camera.Parameters[PLCamera.BinningVertical].TrySetValue(p.BinningVertical);//为了匹配光谱仪设置4像元合并
                camera.Parameters[PLCamera.Width].TrySetValue(p.Width);//设置空间维
                camera.Parameters[PLCamera.Height].TrySetValue(p.Height);//设置光谱维
                camera.Parameters[PLCamera.BinningVerticalMode].TrySetValue(p.BinningVerticalMode);//设置像元合并方式
                camera.Parameters[PLCamera.BinningHorizontalMode].TrySetValue(p.BinningHorizontalMode);//设置像元合并方式
                camera.Parameters[PLCamera.PixelFormat].TrySetValue(p.PixelFormat);//设置灵敏度

                camera.Parameters[PLCamera.AcquisitionFrameRateEnable].TrySetValue(p.AcquisitionFrameRateEnable);//
                camera.Parameters[PLCamera.AcquisitionFrameRateAbs].TrySetValue(p.AcquisitionFrameRateAbs);//启用帧频控制 设置20fps

                camera.Parameters[PLCamera.ExposureMode].TrySetValue(p.ExposureMode);//单位是us
                camera.Parameters[PLCamera.ExposureTimeAbs].TrySetValue(p.ExposureTimeAbs);//单位是us
                camera.Parameters[PLCamera.TriggerMode].TrySetValue(p.TriggerMode);//关闭外触发

            }
            else
            {
                return IsReady = false;

            }

            return IsReady = true;
        }



        public void close()
        {
            camera.Close();

        }

        public void startGrab(string FilePath1)//指定写入文件路径
        {
            filepath = FilePath1; // 更新类的静态变量，以便下面stopGrab函数可以使用
            if (File.Exists(filepath + ".spe"))
                File.Delete(filepath + ".spe");

            fs = new FileStream(filepath + ".spe", FileMode.Create); // 每次开始抓取，都要新建一个文件数据流
            filepathExist = true;
            Thread.Sleep(500);
            if (!camera.StreamGrabber.IsGrabbing)
            {
                camera.StreamGrabber.Start(GrabStrategy.OneByOne, GrabLoop.ProvidedByStreamGrabber);//打开数据流

            }
            //备注：这里调整了开文件流和 抓取 的先后顺序，改为先开文件流，再抓取。
            //开始抓取高光谱，是一帧一帧的抓取。由于在主函数里进行了订阅，将抓取完成事件 与 界面展示和文件写入函数进行
            //绑定，实现实时的显示和写入文件中System.Exception:“Failed to open stream channel at device: Timeout, no message received. (0xE101800B) : RuntimeException thrown (file 'gxstream.cpp', line 658)”
        }
        public void startGrab()//使用之前指定的文件路径
        {
            // 不需要开启新的文件流
            if (!camera.StreamGrabber.IsGrabbing)
            {
                camera.StreamGrabber.Start(GrabStrategy.OneByOne, GrabLoop.ProvidedByStreamGrabber);//打开数据流

            }
            //备注：这里调整了开文件流和 抓取 的先后顺序，改为先开文件流，再抓取。
            //开始抓取高光谱，是一帧一帧的抓取。由于在主函数里进行了订阅，将抓取完成事件 与 界面展示和文件写入函数进行
            //绑定，实现实时的显示和写入文件中

        }

        public void stopGrab1()
        {
            if (camera != null && camera.StreamGrabber.IsGrabbing)
            {
                camera.StreamGrabber.Stop();//停止数据流
            }

        }
        public void stopGrab() // 这里做了一些调整，改为先停止高光谱数据流，再清理文件流和关闭文件流。
        {

            if (camera != null && camera.StreamGrabber.IsGrabbing)
            {
                camera.StreamGrabber.Stop();//停止数据流
            }
            //isrun = false;
            filepathExist = false;
            //DEHUIJIA
            //isSave = 0;
            fs.Flush();//
            fs.Close();
            using (StreamReader sr = new StreamReader("./template.hdr"))//需要加标定文件到指定文件夹
            {
                string line;
                StreamWriter wr = new StreamWriter(filepath + ".hdr");

                // 从文件读取并显示行，直到文件的末尾 
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Contains("lines ="))
                    {
                        wr.WriteLine("lines =" + frameNum);
                    }
                    else
                    {
                        wr.WriteLine(line);
                    }
                    //Console.WriteLine(line);
                }
                frameNum = 0;//dehui
                wr.Flush();
                wr.Close();
            }
        }

        public void receiveGrabResult(IGrabResult grabResult)
        {
            // 每次一帧抓取完成，接受抓取结果
           
            buffer = grabResult.PixelData as byte[];
            Width = grabResult.Width;
            Height = grabResult.Height;
        }

        public void writeToFile()
        {
            if (filepathExist)//数据存储
            {
                fs.Write(buffer, 0, Width * Height * 2);//写入一帧数据 //buffer 具体数据 //grabResult.Width* grabResult.Height*2 帧数据的大小
                frameNum++;
            
            }
        }

        public int getMaxSpectralValue() // 计算高光谱相机测量的光谱最大数值，用于显示到窗体界面上
        {

            Mat image = new Mat(Height, Width, MatType.CV_16UC1, buffer); // column is spectrum

            //  double g_MaxValue;
            //  double g_MinValue;
            //  Cv2.MinMaxLoc(image, out g_MinValue, out g_MaxValue);

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
            return max;
        }
        public Mat getColormap() // 获取缓存伪彩图
        {
            Mat image = new Mat(Height, Width, MatType.CV_16UC1, buffer);//将数据变成图片
            double g_MaxValue;
            double g_MinValue;

            Cv2.MinMaxLoc(image, out g_MinValue, out g_MaxValue); // 获取整个image的最大和最小值
            image.ConvertTo(image, MatType.CV_8U, 255.0 / g_MaxValue);

            //合成伪彩图
            if (current_col == 0)
            {
                //创建一个采色通道图像
                rgb_mat = new Mat(Width, rgb_mat_width, MatType.CV_8UC3, new Scalar(255, 255, 255));
                current_col++;
            }
            for (int index = 0; index < image.Cols; index++)
            {
                //Vec3b color = rgb_mat.Set<Vec3b>(index, current_col - 1);
                Vec3b colormap;
                colormap.Item0 = image.Get<byte>(b_row, index);//B
                colormap.Item1 = image.Get<byte>(g_row, index);//G
                colormap.Item2 = image.Get<byte>(r_row, index);//R
                rgb_mat.Set<Vec3b>(index, current_col - 1, colormap);

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
            return rgb_mat;
        }


    }


    internal class HyperSpecCameraParameters
    {
        //以下是高光谱相机的全部可设置的参数

        public static int MODE_number = 2; // 本类能够提供的模式种类数

        public long BinningHorizontal; //为了匹配光谱仪设置4像元合并
        public long BinningVertical; //为了匹配光谱仪设置4像元合并
        public long Width; //设置空间维
        public long Height;//设置光谱维
        public string BinningVerticalMode; //设置像元合并方式
        public string BinningHorizontalMode; //设置像元合并方式
        public string PixelFormat; // 设置灵敏度

        public bool AcquisitionFrameRateEnable; // 启用帧频控制
        public double AcquisitionFrameRateAbs; // unit: fps, 帧频

        public string ExposureMode; // //单位是us
        public double ExposureTimeAbs; //单位是us
        public string TriggerMode; //关闭外触发

        public HyperSpecCameraParameters() // 构造函数，默认的一组参数
        {
            BinningHorizontal = 4; //为了匹配光谱仪设置4像元合并
            BinningVertical = 4; //为了匹配光谱仪设置4像元合并
            Width = 480; //设置空间维
            Height = 300;//设置光谱维
            BinningVerticalMode = PLCamera.BinningVerticalMode.Sum; //设置像元合并方式
            BinningHorizontalMode = PLCamera.BinningHorizontalMode.Sum; //设置像元合并方式
            PixelFormat = PLCamera.PixelFormat.Mono12; // 设置灵敏度

            AcquisitionFrameRateEnable = true; // 启用帧频控制
            AcquisitionFrameRateAbs = 20.9; // unit: fps, 帧频 20.9对应电机转速200rpm

            ExposureMode = PLCamera.ExposureMode.Timed; // //单位是us
            ExposureTimeAbs = 10000; //单位是us
            TriggerMode = PLCamera.TriggerMode.Off; //关闭外触发
        }

        public HyperSpecCameraParameters(int Mode) // 构造函数，根据不同的模式（Mode)来设置对应的不同参数
        {

            if (Mode >= MODE_number)
            {
                // 如果输入的mode大于 mode number，则赋予默认的参数值。

                BinningHorizontal = 4; //为了匹配光谱仪设置4像元合并
                BinningVertical = 4; //为了匹配光谱仪设置4像元合并
                Width = 480; //设置空间维
                Height = 300;//设置光谱维
                BinningVerticalMode = PLCamera.BinningVerticalMode.Sum; //设置像元合并方式
                BinningHorizontalMode = PLCamera.BinningHorizontalMode.Sum; //设置像元合并方式
                PixelFormat = PLCamera.PixelFormat.Mono12; // 设置灵敏度

                AcquisitionFrameRateEnable = true; // 启用帧频控制
                AcquisitionFrameRateAbs = 20; // unit: fps, 帧频

                ExposureMode = PLCamera.ExposureMode.Timed; // //单位是us
                ExposureTimeAbs = 50000; //单位是us
                TriggerMode = PLCamera.TriggerMode.Off; //关闭外触发



            }
            switch (Mode)
            {
                case 0:  //当Mode值是0的时候，（当前与默认相同，可修改）

                    BinningHorizontal = 4; //为了匹配光谱仪设置4像元合并
                    BinningVertical = 4; //为了匹配光谱仪设置4像元合并
                    Width = 480; //设置空间维
                    Height = 300;//设置光谱维
                    BinningVerticalMode = PLCamera.BinningVerticalMode.Sum; //设置像元合并方式
                    BinningHorizontalMode = PLCamera.BinningHorizontalMode.Sum; //设置像元合并方式
                    PixelFormat = PLCamera.PixelFormat.Mono12; // 设置灵敏度

                    AcquisitionFrameRateEnable = true; // 启用帧频控制
                    AcquisitionFrameRateAbs = 20; // unit: fps, 帧频

                    ExposureMode = PLCamera.ExposureMode.Timed; // //单位是us
                    ExposureTimeAbs = 50000; //单位是us
                    TriggerMode = PLCamera.TriggerMode.Off; //关闭外触发
                    break;

                case 1: //当Mode值是1的时候,（当前与默认相同，可修改）

                    BinningHorizontal = 4; //为了匹配光谱仪设置4像元合并
                    BinningVertical = 4; //为了匹配光谱仪设置4像元合并
                    Width = 480; //设置空间维
                    Height = 300;//设置光谱维
                    BinningVerticalMode = PLCamera.BinningVerticalMode.Sum; //设置像元合并方式
                    BinningHorizontalMode = PLCamera.BinningHorizontalMode.Sum; //设置像元合并方式
                    PixelFormat = PLCamera.PixelFormat.Mono12; // 设置灵敏度

                    AcquisitionFrameRateEnable = true; // 启用帧频控制
                    AcquisitionFrameRateAbs = 20; // unit: fps, 帧频

                    ExposureMode = PLCamera.ExposureMode.Timed; // //单位是us
                    ExposureTimeAbs = 50000; //单位是us
                    TriggerMode = PLCamera.TriggerMode.Off; //关闭外触发
                    break;

                    // 备注：如果增加新的case，需要注意修改 属性 MODE_number，否则无法访问新增的模式

            }

        }


    }



}

