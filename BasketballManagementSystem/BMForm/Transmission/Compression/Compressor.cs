using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballManagementSystem.BMForm.Transmission.Compression
{
    public class Compressor
    {
        /// <summary>
        /// byte配列で受け取ったデータをDeflate圧縮する
        /// </summary>
        /// <param name="inbyte">圧縮したいバイト配列</param>
        /// <returns>圧縮されたバイト配列</returns>
        public static byte[] Compress(byte[] inbyte)
        {
            var ms = new System.IO.MemoryStream();
            var CompressedStream = new System.IO.Compression.DeflateStream(ms, System.IO.Compression.CompressionMode.Compress, true);
            CompressedStream.Write(inbyte, 0, inbyte.Length);
            CompressedStream.Close();
            byte[] destination = ms.ToArray();
            ms.Close();
            return destination;
        }

        /// <summary>
        /// byte配列で受け取ったDeflate圧縮済みデータを解凍する
        /// </summary>
        /// <param name="inbyte">圧縮されたバイト配列</param>
        /// <returns>解凍後バイト配列</returns>
        public static byte[] Decompress(byte[] inbyte)
        {
            var ms = new System.IO.MemoryStream();
            var CompressedStream = new System.IO.Compression.DeflateStream(ms, System.IO.Compression.CompressionMode.Decompress, true);
            CompressedStream.Write(inbyte, 0, inbyte.Length);
            CompressedStream.Close();
            byte[] destination = ms.ToArray();
            ms.Close();
            return destination;
        }
    }
}
 