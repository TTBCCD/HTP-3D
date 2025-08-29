using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;

namespace EDSDKLib
{
    internal class EosImageTransporter:IEosAssertable
    {
        private static EDSDK.EdsDirectoryItemInfo GetDirectoryItemInfo(IntPtr directoryItem)
        {
            EDSDK.EdsDirectoryItemInfo directoryItemInfo;
            Util.Assert(EDSDK.EdsGetDirectoryItemInfo(directoryItem, out directoryItemInfo), "Failed to get directory item info.");
            return directoryItemInfo;
        }

        private static IntPtr CreateFileStream(string imageFilePath)
        {
            IntPtr stream;
            Util.Assert(EDSDK.EdsCreateFileStream(imageFilePath, EDSDK.EdsFileCreateDisposition.CreateAlways,
                EDSDK.EdsAccess.ReadWrite, out stream), "Failed to create file stream");
            return stream;
        }

        private static IntPtr CreateMemoryStream(ulong size)
        {
            IntPtr stream;
            Util.Assert(EDSDK.EdsCreateMemoryStream(size, out stream), "Failed to create memory stream");
            return stream;
        }

        private static void DestroyStream(ref IntPtr stream)
        {
            if (stream != IntPtr.Zero)
            {
                Util.Assert(EDSDK.EdsRelease(stream), "Failed to release stream");
                stream = IntPtr.Zero;
            }
        }

        private static void Download(IntPtr directoryItem, ulong size, IntPtr stream)
        {
            if (stream == IntPtr.Zero)
                return;
            try
            {
                Util.Assert(EDSDK.EdsDownload(directoryItem, size, stream), "Failed to download to stream");
                Util.Assert(EDSDK.EdsDownloadComplete(directoryItem), "Failed to complete download");
            }
            catch (EosException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new EosException(-1, "Unexpected exception while downloading.", ex);
            }
        }

        private static void Transport(IntPtr directoryItem, ulong size, IntPtr stream, bool destroyStream)
        {
            try
            {
                Download(directoryItem, size, stream);
            }
            catch (EosException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new EosException(-1, "Unexpected exception while transporting.", ex);
            }
            finally
            {
                if (destroyStream) DestroyStream(ref stream);
            }
        }

        public EosImageEventArgs TransportAsFile(IntPtr directoryItem, string imageBasePath, string filename)
        {
            var directoryItemInfo = GetDirectoryItemInfo(directoryItem);
            var imageFilePath1 = Path.Combine(imageBasePath ?? Environment.CurrentDirectory, directoryItemInfo.szFileName);
            FileInfo fi = new FileInfo(imageFilePath1);
            filename = filename + fi.Extension;
            //string extention = fi.Extension;
            var imageFilePath = Path.Combine(imageBasePath ?? Environment.CurrentDirectory, filename);
            var stream = CreateFileStream(imageFilePath);
            Transport(directoryItem, directoryItemInfo.Size, stream, true);

            return new EosFileImageEventArgs(imageFilePath);
        }

        public EosImageEventArgs TransportInMemory(IntPtr directoryItem)
        {
            var directoryItemInfo = GetDirectoryItemInfo(directoryItem);
            var stream = CreateMemoryStream(directoryItemInfo.Size);
            try
            {
                Transport(directoryItem, directoryItemInfo.Size, stream, false);
                var converter = new EosConverter();
                return new EosMemoryImageEventArgs(converter.ConvertImageStreamToBytes(stream));
            }
            finally
            {
                DestroyStream(ref stream);
            }
        }
    }

    public class EosConverter : IEosAssertable
    {
        public byte[] ConvertImageStreamToBytes(IntPtr imageStream)
        {
            IntPtr imagePtr;
            Util.Assert(EDSDK.EdsGetPointer(imageStream, out imagePtr), "Failed to get image pointer.");

            ulong imageLen;
            Util.Assert(EDSDK.EdsGetLength(imageStream, out imageLen), "Failed to get image pointer length.");

            var bytes = new byte[imageLen];
            Marshal.Copy(imagePtr, bytes, 0, bytes.Length);
            return bytes;
        }
    }
}
