using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace BasketballManagementSystem.bmForm.Transmission.compression
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

            byte[] buffer = new byte[1024]; //解凍するときに一時的に保持するバッファ
            MemoryStream mssrc = new MemoryStream(inbyte);
            MemoryStream outstream = new MemoryStream();

            DeflateStream uncompressStream = new DeflateStream(mssrc, CompressionMode.Decompress);
            while (true)
            {
                int readSize = uncompressStream.Read(buffer, 0, buffer.Length);
                if (readSize == 0) break;
                outstream.Write(buffer, 0, readSize);
                //上記の０は常に０とする。Streamなので書き込むと位置は進むため。
            }
            uncompressStream.Close();
            byte[] outByte = outstream.ToArray();

            return outByte;
        }
    }
}
 