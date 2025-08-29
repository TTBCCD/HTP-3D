using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDSDKLib;
using System.Windows.Forms;
using System.IO;


namespace Canondemo
{
    //RGB相机类，里面包含了多个相机，即相机列表。
   public class RgbCamera
   {
        private IntPtr cameralist_ptr;
        public List<aCamera> aCameraList; // 相机列表，实际有2个相机
        public int CameraCount; // 相机数

        public Av[] avarray = new Av[54];
        public ShutterSpeed[] ssarray = new ShutterSpeed[71];
        public ISO[] isoarray = new ISO[24];

        public static ListView listViewCaminfo;
        public static ListBox listBox;
        public static string[]caminfo;

     //   public static string picturepath;
        public static string basepath;

        public RgbCamera()
        {
            aCameraList = new List<aCamera>();
            InitializeAEs(); // 给快门速度，Av 及 ISO 数组赋值

        }

        public int connectRgbCameras(ListView listViewCaminfo1, ListBox listBox1) //返回值是相机数
        {
            listViewCaminfo = listViewCaminfo1; // 将参数传递进来的窗口控件赋值给类的属性，使得其它的函数都能访问控件。需要调试！
            listBox = listBox1;

            // 检测RGB相机列表 和 总RGB相机数
            Util.Assert(EDSDK.EdsGetCameraList(out cameralist_ptr), "获取RGB相机，检测失败!");
            Util.Assert(EDSDK.EdsGetChildCount(cameralist_ptr, out CameraCount), "获取RGB相机个数，检测失败!");

            // 对列表中的每个相机，获取相机的指针，并依据相机指针建立每个相机的实例。建立相机实例还需要窗口控件列表和列表盒
            IntPtr aCa_ptr;
            for (int i = 0; i < CameraCount; i++)
            {
                Util.Assert(EDSDK.EdsGetChildAtIndex(cameralist_ptr, i, out aCa_ptr), string.Format("Failed to get the Camera {0}", i.ToString()));
                aCamera acam = new aCamera(aCa_ptr, listViewCaminfo, listBox1);
                aCameraList.Add(acam); // 将相机实例添加到相机列表中
            }

            // 给窗口的控件添加相机的基本信息项
            for (int i = 0; i < CameraCount; i++)
            {
                caminfo = new string[5]{ aCameraList[i].OwnerName, aCameraList[i].Count.ToString(), GetTargetSS(aCameraList[i].ShutterSpeed), GetTargetApture(aCameraList[i].Aperture), GetTargetISO(aCameraList[i].ISO) };
                ListViewItem lvi = new ListViewItem(caminfo);
                listViewCaminfo.Items.Add(lvi);
                aCameraList[i].LvIndex = i;
            }
            //

            // 检查是否相机至于手动档M档
            foreach (aCamera ac in aCameraList)
            {
                if (ac.AEMode != 3)
                {
                    listBox1.Items.Add(string.Format("{0} 没有置于M档!", ac.OwnerName));
                }
            }

            for (int i = 0; i < CameraCount; i++)
            {
                aCameraList[i].ChangePicturesSaveLocation(3);
                aCameraList[i].PicturePath = GetBasePath();
            }

            return CameraCount;
            //SetNewPictureFolder();
        }

        public void shootForAllCameras(string picturepath)
        {
            for (int i = 0; i < CameraCount; i++)
            {
                aCameraList[i].PicturePath = picturepath;
                //aCameraList[i].OneCapture(); // RGB相机拍照//USB触发拍照时使用
            }
        }


        public string GetTargetSS(uint ss)
        {
            string ssname = null;
            foreach (ShutterSpeed s in ssarray)
            {
                if (s.Tv == ss)
                {
                    ssname = s.ShutterSpeedName;
                    break;
                }
            }
            return ssname;
        }

        public string GetTargetApture(uint av)
        {
            string avname = null;
            foreach (Av a in avarray)
            {
                if (a.AV == av)
                {
                    avname = a.AvName;
                    break;
                }
            }
            return avname;
        }

        public string GetTargetISO(uint iso)
        {
            string isoname = null;
            foreach (ISO i in isoarray)
            {
                if (i.ISOSpeed == iso)
                {
                    isoname = i.ISOName;
                    break;
                }
            }
            return isoname;
        }
        

        
        private void InitializeAEs()
        {
            ssarray[0] = new ShutterSpeed("Bulb", 0x0C);
            ssarray[1] = new ShutterSpeed("30", 0x10);
            ssarray[2] = new ShutterSpeed("25", 0x13);
            ssarray[3] = new ShutterSpeed("20", 0x14);
            ssarray[4] = new ShutterSpeed("20(1/3)", 0x15);
            ssarray[5] = new ShutterSpeed("15", 0x18);
            ssarray[6] = new ShutterSpeed("13", 0x1B);
            ssarray[7] = new ShutterSpeed("10", 0x1C);
            ssarray[8] = new ShutterSpeed("10(1/3)", 0x1D);
            ssarray[9] = new ShutterSpeed("8", 0x20);
            ssarray[10] = new ShutterSpeed("6(1/3)", 0x23);
            ssarray[11] = new ShutterSpeed("6", 0x24);
            ssarray[12] = new ShutterSpeed("5", 0x25);
            ssarray[13] = new ShutterSpeed("4", 0x28);
            ssarray[14] = new ShutterSpeed("3”2", 0x2B);
            ssarray[15] = new ShutterSpeed("3", 0x2C);
            ssarray[16] = new ShutterSpeed("2”5", 0x2D);
            ssarray[17] = new ShutterSpeed("2", 0x30);
            ssarray[18] = new ShutterSpeed("1”6", 0x33);
            ssarray[19] = new ShutterSpeed("1”5", 0x34);
            ssarray[20] = new ShutterSpeed("1”3", 0x35);
            ssarray[21] = new ShutterSpeed("1", 0x38);
            ssarray[22] = new ShutterSpeed("0”8", 0x3B);
            ssarray[23] = new ShutterSpeed("0”7", 0x3C);
            ssarray[24] = new ShutterSpeed("0”6", 0x3D);
            ssarray[25] = new ShutterSpeed("0”5", 0x40);
            ssarray[26] = new ShutterSpeed("0”4", 0x43);
            ssarray[27] = new ShutterSpeed("0”3", 0x44);
            ssarray[28] = new ShutterSpeed("0”3(1/3)", 0x45);
            ssarray[29] = new ShutterSpeed("1/4", 0x48);
            ssarray[30] = new ShutterSpeed("1/5", 0x4B);
            ssarray[31] = new ShutterSpeed("1/6", 0x4C);
            ssarray[32] = new ShutterSpeed("1/6(1/3)", 0x4D);
            ssarray[33] = new ShutterSpeed("1/8", 0x50);
            ssarray[34] = new ShutterSpeed("1/10(1/3)", 0x53);
            ssarray[35] = new ShutterSpeed("1/10", 0x54);
            ssarray[36] = new ShutterSpeed("1/25", 0x5D);
            ssarray[37] = new ShutterSpeed("1/30", 0x60);
            ssarray[38] = new ShutterSpeed("1/40", 0x63);
            ssarray[39] = new ShutterSpeed("1/45", 0x64);
            ssarray[40] = new ShutterSpeed("1/50", 0x65);
            ssarray[41] = new ShutterSpeed("1/60", 0x68);
            ssarray[42] = new ShutterSpeed("1/80", 0x6B);
            ssarray[43] = new ShutterSpeed("1/90", 0x6C);
            ssarray[44] = new ShutterSpeed("1/100", 0x6D);
            ssarray[45] = new ShutterSpeed("1/125", 0x70);
            ssarray[46] = new ShutterSpeed("1/160", 0x73);
            ssarray[47] = new ShutterSpeed("1/180", 0x74);
            ssarray[48] = new ShutterSpeed("1/200", 0x75);
            ssarray[49] = new ShutterSpeed("1/250", 0x78);
            ssarray[50] = new ShutterSpeed("1/320", 0x7B);
            ssarray[51] = new ShutterSpeed("1/350", 0x7C);
            ssarray[52] = new ShutterSpeed("1/400", 0x7D);
            ssarray[53] = new ShutterSpeed("1/500", 0x80);
            ssarray[54] = new ShutterSpeed("1/640", 0x83);
            ssarray[55] = new ShutterSpeed("1/750", 0x84);
            ssarray[56] = new ShutterSpeed("1/800", 0x85);
            ssarray[57] = new ShutterSpeed("1/1000", 0x88);
            ssarray[58] = new ShutterSpeed("1/1250", 0x8B);
            ssarray[59] = new ShutterSpeed("1/1500", 0x8C);
            ssarray[60] = new ShutterSpeed("1/1600", 0x8D);
            ssarray[61] = new ShutterSpeed("1/2000", 0x90);
            ssarray[62] = new ShutterSpeed("1/2500", 0x93);
            ssarray[63] = new ShutterSpeed("1/3000", 0x94);
            ssarray[64] = new ShutterSpeed("1/3200", 0x95);
            ssarray[65] = new ShutterSpeed("1/4000", 0x98);
            ssarray[66] = new ShutterSpeed("1/5000", 0x9B);
            ssarray[67] = new ShutterSpeed("1/6000", 0x9C);
            ssarray[68] = new ShutterSpeed("1/6400", 0x9D);
            ssarray[69] = new ShutterSpeed("1/8000", 0xA0);
            ssarray[70] = new ShutterSpeed("Not valid", 0xffffffff);
            avarray[0] = new Av("1", 0x08);
            avarray[1] = new Av("1.1", 0x0B);
            avarray[2] = new Av("1.2", 0x0C);
            avarray[3] = new Av("1.2(1/3)", 0x0D);
            avarray[4] = new Av("1.4", 0x10);
            avarray[5] = new Av("1.6", 0x13);
            avarray[6] = new Av("1.8", 0x14);
            avarray[7] = new Av("1.8(1/3)", 0x15);
            avarray[8] = new Av("2", 0x18);
            avarray[9] = new Av("2.2", 0x1B);
            avarray[10] = new Av("2.5", 0x1C);
            avarray[11] = new Av("2.5(1/3)", 0x1D);
            avarray[12] = new Av("2.8", 0x20);
            avarray[13] = new Av("3.2", 0x23);
            avarray[14] = new Av("3.5", 0x24);
            avarray[15] = new Av("3.5(1/3)", 0x25);
            avarray[16] = new Av("4", 0x28);
            avarray[17] = new Av("4.5", 0x2B);
            avarray[18] = new Av("4.5", 0x2C);
            avarray[19] = new Av("5.0", 0x2D);
            avarray[20] = new Av("5.6", 0x30);
            avarray[21] = new Av("6.3", 0x33);
            avarray[22] = new Av("6.7", 0x34);
            avarray[23] = new Av("7.1", 0x35);
            avarray[24] = new Av("8", 0x38);
            avarray[25] = new Av("9", 0x3B);
            avarray[26] = new Av("9.5", 0x3C);
            avarray[27] = new Av("10", 0x3D);
            avarray[28] = new Av("11", 0x40);
            avarray[29] = new Av("13(1/3)", 0x43);
            avarray[30] = new Av("13", 0x44);
            avarray[31] = new Av("14", 0x45);
            avarray[32] = new Av("16", 0x48);
            avarray[33] = new Av("18", 0x4B);
            avarray[34] = new Av("19", 0x4C);
            avarray[35] = new Av("20", 0x4D);
            avarray[36] = new Av("22", 0x50);
            avarray[37] = new Av("25", 0x53);
            avarray[38] = new Av("27", 0x54);
            avarray[39] = new Av("29", 0x55);
            avarray[40] = new Av("32", 0x58);
            avarray[41] = new Av("36", 0x5B);
            avarray[42] = new Av("38", 0x5C);
            avarray[43] = new Av("40", 0x5D);
            avarray[44] = new Av("45", 0x60);
            avarray[45] = new Av("51", 0x63);
            avarray[46] = new Av("54", 0x64);
            avarray[47] = new Av("57", 0x65);
            avarray[48] = new Av("64", 0x68);
            avarray[49] = new Av("72", 0x6B);
            avarray[50] = new Av("76", 0x6C);
            avarray[51] = new Av("80", 0x6D);
            avarray[52] = new Av("91", 0x70);
            avarray[53] = new Av("Not valid", 0xffffffff);
            isoarray[0] = new ISO("6", 0x00000028);
            isoarray[1] = new ISO("12", 0x00000030);
            isoarray[2] = new ISO("25", 0x00000038);
            isoarray[3] = new ISO("50", 0x00000040);
            isoarray[4] = new ISO("100", 0x00000048);
            isoarray[5] = new ISO("125", 0x0000004b);
            isoarray[6] = new ISO("160", 0x0000004d);
            isoarray[7] = new ISO("200", 0x00000050);
            isoarray[8] = new ISO("250", 0x00000053);
            isoarray[9] = new ISO("320", 0x00000055);
            isoarray[10] = new ISO("400", 0x00000058);
            isoarray[11] = new ISO("500", 0x0000005b);
            isoarray[12] = new ISO("640", 0x0000005d);
            isoarray[13] = new ISO("800", 0x00000060);
            isoarray[14] = new ISO("1000", 0x00000063);
            isoarray[15] = new ISO("1250", 0x00000065);
            isoarray[16] = new ISO("1600", 0x00000068);
            isoarray[17] = new ISO("3200", 0x00000070);
            isoarray[18] = new ISO("6400", 0x00000078);
            isoarray[19] = new ISO("12800", 0x00000080);
            isoarray[20] = new ISO("25600", 0x00000088);
            isoarray[21] = new ISO("51200", 0x00000090);
            isoarray[22] = new ISO("102400", 0x00000098);
            isoarray[23] = new ISO("Not valid", 0xffffffff);
        }
        
        public string GetBasePath()
        {
         //   string basepath;
            DriveInfo[] disk = DriveInfo.GetDrives();
            List<DriveInfo> Harddisk = new List<DriveInfo>();
            foreach (DriveInfo di in disk)
            {
                if (di.DriveType == DriveType.Fixed)
                {
                    Harddisk.Add(di);
                }
            }
            DriveInfo lastdisk = Harddisk[Harddisk.Count - 1];

            basepath = lastdisk.Name + string.Format("CWCapData\\Date_{0}", DateTime.Now.ToString("yyyyMMdd"));
            //if (!Directory.Exists(basepath))
            //{
            //    Directory.CreateDirectory(basepath);
            //}
            return basepath;

        }
        public bool setNewPictureFolder(string capname)
        {
            string picturepath = basepath + "\\" + capname;
            if (picturepath != string.Empty)
            {
                Directory.CreateDirectory(picturepath);
                int capedcount = Directory.GetFiles(picturepath).Length;
                for(int i = 0; i <CameraCount; i++)
                {
                    aCameraList[i].PicturePath = picturepath;
                    aCameraList[i].Count = capedcount;

                }
                return true;
                
                
            }
            else
            {
                return false;
            }
        }
        public void DisposeCam()
        {
            for (int i = 0; i < CameraCount; i++)
            {
                aCameraList[i].DisposeCAM(); // 释放资源
            }
        }

    }
}
