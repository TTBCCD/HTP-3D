using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;

namespace EDSDKLib
{
    public abstract class EosImageEventArgs : EventArgs
    {
        public virtual Image GetImage()
        {
            using (var stream = this.GetStream())
                return Image.FromStream(stream);
        }

        public virtual Bitmap GetBitmap()
        {
            using (var stream = this.GetStream())
                return new Bitmap(stream);
        }

        public abstract Stream GetStream();
    }

    public class EosFileImageEventArgs : EosImageEventArgs
    {
        internal EosFileImageEventArgs(string imageFilePath)
        {
            this.ImageFilePath = imageFilePath;
        }

        public string ImageFilePath { get; private set; }

        public override Stream GetStream()
        {
            return new FileStream(this.ImageFilePath, FileMode.Open,
                FileAccess.Read, FileShare.Read);
        }
    }

    public class EosMemoryImageEventArgs : EosImageEventArgs
    {
        internal EosMemoryImageEventArgs(byte[] imageData)
        {
            this.ImageData = imageData;
        }

        public byte[] ImageData { get; private set; }

        public override Stream GetStream()
        {
            return new MemoryStream(this.ImageData);
        }
    }

    public class EosVolumeInfoEventArgs : EventArgs
    {
        internal EosVolumeInfoEventArgs(EosVolumeInfo volumeInfo)
        {
            this.VolumeInfo = volumeInfo;
        }

        public EosVolumeInfo VolumeInfo { get; private set; }
    }
}
