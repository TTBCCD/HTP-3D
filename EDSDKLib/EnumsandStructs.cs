using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDSDKLib
{
    public enum AEMode : uint
    {
        Program_AE = 0,
        ShutterSpeed_Priority_AE=1,
        Aperture_Priority_AE=2,
        Manual_Exposure = 3,
        Bulb=4,
        Auto_DepthofField_AE=5,
        DepthofField_AE=6,
        Camera_settings_registered=7,
        Lock=8,
        Auto=9,
        Night_Scene_Portrait=10,
        Sports=11,
        Portrait=12,
        Landscape=13,
        Close_Up=14,
        Flash_off=15,
        Creative_Auto=19,
        Photo_In_Movie=21,
        Not_valid = 0xFFFFFFFF,
    }

    //public enum ISOSpeed : uint
    //{
    //    ISO6 = 0x00000028,
    //    ISO12 = 0x00000030,
    //    ISO25 = 0x00000038,
    //    ISO50 = 0x00000040,
    //    ISO100 = 0x00000048,
    //    ISO125 = 0x0000004b,
    //    ISO160 = 0x0000004d,
    //    ISO200 = 0x00000050,
    //    ISO250 = 0x00000053,
    //    ISO320 = 0x00000055,
    //    ISO400 = 0x00000058,
    //    ISO500 = 0x0000005b,
    //    ISO640 = 0x0000005d,
    //    ISO800 = 0x00000060,
    //    ISO1000 = 0x00000063,
    //    ISO1250 = 0x00000065,
    //    ISO1600 = 0x00000068,
    //    ISO3200 = 0x00000070,
    //    ISO6400 = 0x00000078,
    //    ISO12800 = 0x00000080,
    //    ISO25600 = 0x00000088,
    //    ISO51200 = 0x00000090,
    //    ISO102400 = 0x00000098,
    //    Not_valid = 0xffffffff,
    //}

    //public enum Av : uint
    //{
    //    AV1,
    //    AV1_1,
    //    AV1_2,
    //    AV1_2_3,
    //    AV1_4,
    //    AV1_6,
    //    AV1_8,
    //    AV1_8_3,
    //    AV2,
    //    AV2_2,
    //    AV2_5,

    //}

    public struct Av
    {
        public string AvName;
        public uint AV;
        public Av(string avname,uint av)
        {
            this.AvName = avname;
            this.AV = av;
        }
    }

    public struct ShutterSpeed
    {
        public string ShutterSpeedName;
        public uint Tv;
        public ShutterSpeed(string ssname, uint tv)
        {
            this.ShutterSpeedName = ssname;
            this.Tv = tv;
        }
    }

    public struct ISO
    {
        public string ISOName;
        public uint ISOSpeed;
        public ISO(string isoname, uint iso)
        {
            this.ISOName = isoname;
            this.ISOSpeed = iso;
        }
    }
}
