using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO;

namespace EDSDKLib
{
    public class aCamera : EosDisposable
    {
        IntPtr camera;
        private EDSDK.EdsObjectEventHandler edsObjectEventHandler;
        //private EDSDK.EdsPropertyEventHandler edsPropertyEventHandler;
        //private EDSDK.EdsStateEventHandler edsStateEventHandler;
        public event EventHandler<EosImageEventArgs> PictureTaken;
        public event EventHandler<EosVolumeInfoEventArgs> VolumeInfoChanged;
        private readonly EosImageTransporter transporter = new EosImageTransporter();
        private EDSDK.EdsDeviceInfo deviceInfo;
        string picturePath;
        string basePath;
        public static int count = 0;
        ListView LV;
        ListBox LB;
        int lvindex = 0;
        public static string RGBDataName = null;
        public string CameraName
        {
            get { return GetCameraName(); }
        }

        public string OwnerName
        {
            get { return GetOwnerName(); }
            set { SetPropertyStringData(EDSDK.PropID_OwnerName,value); }
        }

        public uint AEMode
        {
            get { return GetAEMode(); }
        }

        public uint Aperture
        {
            get { return GetAv(); }
            set { SetAv(value); }
        }

        public uint ShutterSpeed
        {
            get { return GetShutterSpeed(); }
            set { SetShutterSpeed(value); }
        }

        public uint ISO
        {
            get { return GetISO(); }
            set { SetISO(value); }
        }

        public int Count
        {
            get { return count; }
            set {
                count = value;
                SetLV_Count(count.ToString());
            }
        }

        public int LvIndex
        {
            get { return lvindex; }
            set { lvindex = value; }
        }

        public EDSDK.EdsVolumeInfo Volumeinfo
        {
            get { return GetVolumeInfo(); }
        }

        

        /// <summary>
        /// Gets a value indicating whether session to the camera is open.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if the session is open; otherwise, <c>false</c>.
        /// </value>
        public bool IsSessionOpen { get; private set; }

        public bool IsLocked { get; private set; }

        public string PicturePath
        {
            get { return picturePath; }
            set 
            {
                picturePath = value;
                if (!Directory.Exists(picturePath))
                {
                    Directory.CreateDirectory(picturePath);
                }

            }
        }

        public bool IsLegacy
        {
            get { return deviceInfo.DeviceSubType == 0; }
        }


        public aCamera(IntPtr cam,ListView lv,ListBox lb)
        {
            this.camera = cam;
            Util.Assert(EDSDK.EdsOpenSession(cam), "Failed to open the cameras");
            this.IsSessionOpen = true;
            Util.Assert(EDSDK.EdsGetDeviceInfo(cam, out deviceInfo),"Failed to get device info.");
            SetEventHandlers();
            this.LV = lv;
            this.LB = lb;
            //ownername = GetOwnerName();
        }

        private string GetCameraName()
        {
            string CameraName;
            Util.Assert(EDSDK.EdsGetPropertyData(camera, EDSDK.PropID_ProductName, 0, out CameraName), "Failed to get the camera name!");
            return CameraName;
        }

        private EDSDK.EdsVolumeInfo GetVolumeInfo()
        {
            EDSDK.EdsVolumeInfo VolumeInfo;
            Util.Assert(EDSDK.EdsGetVolumeInfo(camera, out VolumeInfo), "Failed to get the VolumeInfo!");
            return VolumeInfo;
        }

        private string GetOwnerName()
        {
            string OwnerName;
            Util.Assert(EDSDK.EdsGetPropertyData(camera, EDSDK.PropID_OwnerName, 0, out OwnerName), "Failed to get the owner name!");
            return OwnerName;
        }

        private void SetOwnerName(string str)
        {
            EDSDK.EdsDataType dataType;
            int dataSize;
            Util.Assert(EDSDK.EdsGetPropertySize(camera, EDSDK.PropID_OwnerName, 0, out dataType, out dataSize), "Failed to get datasize");
            //Util.Assert(EDSDK.EdsSetPropertyData(camera, EDSDK.PropID_OwnerName, 0, Marshal.SizeOf(typeof(string)), str), "Failed to set Ownername.");
            Util.Assert(EDSDK.EdsSetPropertyData(camera, EDSDK.PropID_OwnerName, 0, dataSize, str), "Failed to set Ownername.");
        }

        private uint GetAEMode()
        {
            uint AEMode;
            Util.Assert(EDSDK.EdsGetPropertyData(camera, EDSDK.PropID_AEMode, 0, out AEMode), "Failed to get the AEMode!");
            return AEMode;
        }

        private uint GetAv()
        {
            uint av;
            Util.Assert(EDSDK.EdsGetPropertyData(camera, EDSDK.PropID_Av, 0, out av), "Failed to get the Av!");
            return av;
        }

        private void SetAv(uint av)
        {
            Util.Assert(EDSDK.EdsSetPropertyData(camera, EDSDK.PropID_Av, 0, Marshal.SizeOf(typeof(uint)), av), "Failed to set Av.");
        }

        private uint GetShutterSpeed()
        {
            uint ss;
            Util.Assert(EDSDK.EdsGetPropertyData(camera, EDSDK.PropID_Tv, 0, out ss), "Failed to get the Tv!");
            return ss;
        }

        private void SetShutterSpeed(uint tv)
        {
            Util.Assert(EDSDK.EdsSetPropertyData(camera, EDSDK.PropID_Tv, 0, Marshal.SizeOf(typeof(uint)), tv), "Failed to set Tv.");
        }        

        private uint GetISO()
        {
            uint iso;
            Util.Assert(EDSDK.EdsGetPropertyData(camera, EDSDK.PropID_ISOSpeed, 0, out iso), "Failed to get the ISO!");
            return iso;
        }

        private void SetISO(uint iso)
        {
            Util.Assert(EDSDK.EdsSetPropertyData(camera, EDSDK.PropID_ISOSpeed, 0, Marshal.SizeOf(typeof(uint)), iso), "Failed to set iso.");
        }

        private void SetEventHandlers()
        {
            //edsStateEventHandler = this.HandleStateEvent;
            //Util.Assert(Edsdk.EdsSetCameraStateEventHandler(this.Handle, Edsdk.StateEvent_All,
            //    _edsStateEventHandler, IntPtr.Zero), "Failed to set state handler.");

            edsObjectEventHandler = this.HandleObjectEvent;
            Util.Assert(EDSDK.EdsSetObjectEventHandler(camera, EDSDK.ObjectEvent_All, edsObjectEventHandler, IntPtr.Zero), "Failed to set object handler.");

            //edsPropertyEventHandler = this.HandlePropertyEvent;
            //Util.Assert(Edsdk.EdsSetPropertyEventHandler(this.Handle, Edsdk.PropertyEvent_All,
            //    _edsPropertyEventHandler, IntPtr.Zero), "Failed to set object handler.");
        }

        private uint HandleObjectEvent(uint objectEvent, IntPtr sender, IntPtr context)
        {
            try
            {
                switch (objectEvent)
                {
                    case EDSDK.ObjectEvent_VolumeInfoChanged:
                        this.OnObjectEventVolumeInfoChanged(sender);
                        break;
                    case EDSDK.ObjectEvent_DirItemCreated:
                        this.OnObjectEventDirItemCreated(sender, context);
                        break;
                    case EDSDK.ObjectEvent_DirItemRequestTransfer:
                        this.OnObjectEventDirItemRequestTransfer(sender);
                        break;
                }
            }
            catch (Exception ex)
            {
                SetLB(OwnerName + "|Handing HandleObjectEvent|" + ex.ToString());
            }
            finally
            {
                EDSDK.EdsRelease(sender);
            }

            return EDSDK.EDS_ERR_OK;
        }

        private void OnVolumeInfoChanged(EosVolumeInfoEventArgs eventArgs)
        {
            if (this.VolumeInfoChanged != null)
                this.VolumeInfoChanged(this, eventArgs);
        }

        private void OnObjectEventVolumeInfoChanged(IntPtr sender)
        {
            EDSDK.EdsVolumeInfo volumeInfo;
            Util.Assert(EDSDK.EdsGetVolumeInfo(sender, out volumeInfo), "Failed to get volume info.");

            this.OnVolumeInfoChanged(new EosVolumeInfoEventArgs(new EosVolumeInfo
            {
                Access = volumeInfo.Access,
                FreeSpaceInBytes = volumeInfo.FreeSpaceInBytes,
                MaxCapacityInBytes = volumeInfo.MaxCapacity,
                StorageType = volumeInfo.StorageType,
                VolumeLabel = volumeInfo.szVolumeLabel
            }));
        }

        private void OnObjectEventDirItemCreated(IntPtr sender, IntPtr context)
        {
            this.OnPictureTaken(transporter.TransportInMemory(sender));
        }

        private void OnObjectEventDirItemRequestTransfer(IntPtr sender)
        {

            string CaptureName = OwnerName.Trim(); //+ '_' + (++count).ToString(); //+ '_' + (++count).ToString();//+ '_' + (++count).ToString(); //RGBDataName;//;OwnerName.Trim() + '_' + (++count).ToString()
            this.OnPictureTaken(transporter.TransportAsFile(sender, picturePath, CaptureName));
            SetLV_Count(count.ToString());
        }

        private void OnPictureTaken(EosImageEventArgs eventArgs)
        {
            if (this.PictureTaken != null)
                this.PictureTaken(this, eventArgs);
        }

        public void OneCapture()
        {
            Util.Assert(EDSDK.EdsSendCommand(camera, EDSDK.CameraCommand_TakePicture, 0), "Failed to capure!");
        }

        public void ChangePicturesSaveLocation(int saveLocation)
        {
            Util.Assert(EDSDK.EdsSetPropertyData(camera, EDSDK.PropID_SaveTo, 0, Marshal.SizeOf(typeof(int)), saveLocation), "Failed to set SaveTo location.");

            if (!this.IsLegacy)
            {
                this.LockAndExceute(() =>
                {
                    var capacity = new EDSDK.EdsCapacity { NumberOfFreeClusters = 0x7FFFFFFF, BytesPerSector = 0x1000, Reset = 1 };
                    Util.Assert(EDSDK.EdsSetCapacity(camera, capacity), "Failed to set capacity.");
                });
            }
        }

        protected virtual void ExecuteSetter(Action action)
        {
            action();
        }

        protected void SetPropertyStringData(uint propertyId, string data)
        {
            this.ExecuteSetter(() =>
            {
                var bytes = Util.ConvertStringToBytesWithNullByteAtEnd(data);
                //if (bytes.Length > maxByteLength)
                //    throw new ArgumentException(string.Format("'{0}' converted to bytes is longer than {1}.", data, maxByteLength), "data");

                Util.Assert(EDSDK.EdsSetPropertyData(camera, propertyId, 0, bytes.Length, bytes),
                    string.Format("Failed to set property string data: propertyId {0}, data {1}", propertyId, data),
                    propertyId, data);
            });
        }

        private void Lock()
        {

            if (!this.IsLocked)
            {
                Util.Assert(EDSDK.EdsSendStatusCommand(camera, EDSDK.CameraState_UILock,0),
                    "Failed to lock camera.");
                this.IsLocked = true;
            }
        }

        private void Unlock()
        {
            if (this.IsLocked)
            {
                EDSDK.EdsSendStatusCommand(camera, EDSDK.CameraState_UIUnLock,0);
                this.IsLocked = false;
            }
        }

        private void LockAndExceute(Action action)
        {
            this.Lock();
            try { action(); }
            finally { this.Unlock(); }
        }

        
        protected internal override void DisposeUnmanaged()
        {
            if (this.IsSessionOpen)
                EDSDK.EdsCloseSession(camera);
            base.DisposeUnmanaged();
        }
        public void DisposeCAM() 
        {
            if (this.IsSessionOpen) 
            {
                EDSDK.EdsCloseSession(camera);
            }
               
        }
        private delegate void SetListView(string str);
        private void SetLV_Count(string str)
        {
            if(LV.InvokeRequired)
            {
                SetListView slv = SetLV_Count;
                LV.Invoke(slv, str);
            }
            else
            {
               LV.Items[lvindex].SubItems[1].Text = str;
            }
        }

        public void SetLV_SS(string str)
        {
            if (LV.InvokeRequired)
            {
                SetListView slv = SetLV_SS;
                LV.Invoke(slv, str);
            }
            else
            {
                LV.Items[lvindex].SubItems[2].Text = str;
            }
        }

        public void SetLV_Aperture(string str)
        {
            if (LV.InvokeRequired)
            {
                SetListView slv = SetLV_Aperture;
                LV.Invoke(slv, str);
            }
            else
            {
                LV.Items[lvindex].SubItems[3].Text = str;
            }
        }

        public void SetLV_ISO(string str)
        {
            if (LV.InvokeRequired)
            {
                SetListView slv = SetLV_ISO;
                LV.Invoke(slv, str);
            }
            else
            {
               LV.Items[lvindex].SubItems[4].Text = str;
            }
        }

        private delegate void SetListBox(string str);
        private void SetLB(string str)
        {
            if (LB.InvokeRequired)
            {
                SetListBox slb = SetLB;
                LB.Invoke(slb, str);
            }
            else
            {
                LB.Items.Add(str);
            }
        }
    }
}
