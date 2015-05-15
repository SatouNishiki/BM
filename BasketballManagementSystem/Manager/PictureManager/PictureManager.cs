using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace BasketballManagementSystem.Manager.PictureManager
{
    /// <summary>
    /// pictureフォルダの中の画像を全てロードし、指定されたファイル名の画像を返す。
    /// </summary>
    class PictureManager
    {
        private static Dictionary<string, Bitmap> pictureHash = new Dictionary<string,Bitmap>();
        
        /// <summary>
        /// Pictureフォルダの中にある画像を全てロードする。
        /// </summary>
        public static void LoadAllPictures()
        {

        }
        
        /// <summary>
        /// 指定されたファイル名の画像を返す。
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static Bitmap getPicture(string fileName)
        {
            Bitmap picture = pictureHash[fileName];
            return picture;
        }
    }
}
