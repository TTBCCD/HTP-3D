using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.Drawing;

using STC_Object = System.IntPtr;
using STC_DataSet = System.IntPtr;
namespace BasicDemo
{
    class MyCamDev
    {
        private static readonly object Lock = new object();
        bool m_bGrabbing = false;
        Thread m_hReceiveThread = null;

        // ch:图片参数信息 | en:Image param information
        MV3D_RGBD_IMAGE_DATA m_stImageInfo = new MV3D_RGBD_IMAGE_DATA();
        static UInt32 m_MaxImageSize = 1024 * 1024 * 30;
        static byte[] m_pcDataBuf = new byte[m_MaxImageSize];

        STC_DataSet m_DevHandle = IntPtr.Zero;
        IntPtr m_hWnd = IntPtr.Zero;
        string m_strSerialNumber;

        public int Open(string strSerialNumber)
        {
            int nRet = 0;
            nRet = Mv3dRgbdSDK.MV3D_RGBD_OpenDeviceBySerialNumber(ref m_DevHandle, strSerialNumber);
            m_strSerialNumber = strSerialNumber;
            return nRet;
        }

        public int Close()
        {
            int nRet = 0;
            if(m_bGrabbing)
            {
                m_bGrabbing = false;
                m_hReceiveThread.Join();
            }
            // ch:关闭设备 | en:Close Device
            Mv3dRgbdSDK.MV3D_RGBD_Stop(m_DevHandle);
            nRet = Mv3dRgbdSDK.MV3D_RGBD_CloseDevice(ref m_DevHandle);
            m_DevHandle = IntPtr.Zero;
            m_hWnd = IntPtr.Zero;
            return nRet;
        }
        
        public void ReceiveThreadProcess()
        {
            int nRet = (int)Mv3dRgbdSDK.MV3D_RGBD_OK;

            while (m_bGrabbing)
            {
                MV3D_RGBD_FRAME_DATA stFrameData = new MV3D_RGBD_FRAME_DATA();
                nRet = Mv3dRgbdSDK.MV3D_RGBD_FetchFrame(m_DevHandle, stFrameData, 1000);
                if (0 == nRet)
                {
                    IntPtr hWnd = m_hWnd;
                    Int32 i = 0;
                    // ch:目前渲染深度图 | en:Display depth image
                    Mv3dRgbdSDK.MV3D_RGBD_DisplayImage(m_DevHandle, stFrameData.stImageData[i], hWnd);  
                    {
                        {
                            Monitor.Enter(Lock);
                            m_stImageInfo.nWidth = stFrameData.stImageData[i].nWidth;
                            m_stImageInfo.nHeight = stFrameData.stImageData[i].nHeight;
                            m_stImageInfo.enImageType = stFrameData.stImageData[i].enImageType;
                            m_stImageInfo.nDataLen = stFrameData.stImageData[i].nDataLen;
                            m_stImageInfo.nFrameNum = stFrameData.stImageData[i].nFrameNum;
                            m_stImageInfo.pData = Marshal.UnsafeAddrOfPinnedArrayElement(m_pcDataBuf, 0);

                            if (m_MaxImageSize < stFrameData.stImageData[i].nDataLen)
                            {
                                m_pcDataBuf = new byte[stFrameData.stImageData[i].nDataLen];
                                m_MaxImageSize = stFrameData.stImageData[i].nDataLen;
                            }

                            Marshal.Copy(stFrameData.stImageData[i].pData, m_pcDataBuf, 0, (int)stFrameData.stImageData[i].nDataLen);
                            Monitor.Exit(Lock);
                        }
                    }
                }
            }
            return;
        }

        public int StartGrabbing(IntPtr hWnd)
        {
            if (IntPtr.Zero != hWnd)
            {
                m_hWnd = hWnd;
            }
            
            int nRet = 0;
            m_bGrabbing = true;

            m_hReceiveThread = new Thread(ReceiveThreadProcess);
            m_hReceiveThread.Start();

            nRet = Mv3dRgbdSDK.MV3D_RGBD_Start(m_DevHandle);
            if (0x00000000 != nRet)
            {
                m_bGrabbing = false;
                m_hReceiveThread.Join();
            }

            return nRet;
        }

        public int StopGrabbing()
        {
            int nRet = 0;

            // ch:标志位设为false | en:Set flag bit false
            if (m_bGrabbing == true)
            {
                m_bGrabbing = false;
                m_hReceiveThread.Join();
            }

            // ch:停止采集 | en:Stop Grabbing
            nRet = Mv3dRgbdSDK.MV3D_RGBD_Stop(m_DevHandle);

            return nRet;
        }

        public int SoftTrigger()
        {
            int nRet = Mv3dRgbdSDK.MV3D_RGBD_SoftTrigger(m_DevHandle);
            return nRet;
        }

        public UInt32 SaveRAW()
        {
            if (!m_bGrabbing)
            {
                return Mv3dRgbdSDK.MV3D_RGBD_E_PARAMETER;   
            }

            Monitor.Enter(Lock);
            if (0 == m_stImageInfo.nDataLen)
            {
                return Mv3dRgbdSDK.MV3D_RGBD_E_NODATA;
            }

            string strFileName = m_strSerialNumber;
            strFileName += "_Image_";
            strFileName += m_stImageInfo.nFrameNum;
            strFileName += ".raw";

            FileStream file = new FileStream(strFileName, FileMode.Create, FileAccess.Write);

            {
                Monitor.Enter(Lock);

                file.Write(m_pcDataBuf, 0, (int)m_stImageInfo.nDataLen);
                Monitor.Exit(Lock);
            }

            file.Close();

            Monitor.Exit(Lock);

            return Mv3dRgbdSDK.MV3D_RGBD_OK;
        }
        public UInt32 SaveRAW(string saveDirectory)
        {
            // 1. 检查相机状态和缓冲区有效性
            if (!m_bGrabbing)
                return Mv3dRgbdSDK.MV3D_RGBD_E_PARAMETER;

            if (m_stImageInfo.nDataLen == 0)
                return Mv3dRgbdSDK.MV3D_RGBD_E_NODATA;

            try
            {
                Monitor.Enter(Lock);

                // 2. 动态生成文件名（含时间戳防覆盖）[2,5](@ref)
                string fileName = $"{m_strSerialNumber}_Frame_{m_stImageInfo.nFrameNum}_{DateTime.Now:yyyyMMdd_HHmmss}.raw";

                // 3. 处理保存路径（默认当前目录）[2](@ref)
                string fullPath = Path.Combine(saveDirectory ?? Directory.GetCurrentDirectory(), fileName);

                // 4. 检查路径存在性并创建目录
                if (!Directory.Exists(Path.GetDirectoryName(fullPath)))
                    Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

                // 5. 写入文件（支持覆盖控制）
                using (FileStream file = new FileStream(fullPath,FileMode.Create ))
                {
                    file.Write(m_pcDataBuf, 0, (int)m_stImageInfo.nDataLen);
                }

               
            }
            catch (IOException ex) // 7. 文件冲突处理
            {
                return Mv3dRgbdSDK.MV3D_RGBD_E_OUTOFRANGE;
            }
            catch (UnauthorizedAccessException) // 权限错误
            {
                return Mv3dRgbdSDK.MV3D_RGBD_E_ACCESS_DENIED;
            }
            finally
            {
                Monitor.Exit(Lock); // 确保锁释放
            }
            return Mv3dRgbdSDK.MV3D_RGBD_OK;
        }
    }
}
