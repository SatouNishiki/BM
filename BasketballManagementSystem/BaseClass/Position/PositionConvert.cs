using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BasketballManagementSystem.BaseClass.Position
{
    public class PositionConvert
    {
        public static readonly double CortX = 28.0;
        public static readonly double CortY = 15.0;

        /// <summary>
        /// 指定されたオブジェクトの座標をコートの大きさを縦(x)28m、横(y)15mとしたときの座標に変換する
        /// objectPoint : 変換する対象のオブジェクトの座標(フォーム上の座標)
        /// leftTop : 変換する対象があったコートの左上の座標(フォーム上の座標)
        /// rightTop : 変換する対象があったコートの右下の座標(フォーム上の座標)
        /// </summary>
        /// <param name="objectPoint"></param>
        /// <param name="leftTop"></param>
        /// <param name="rightDown"></param>
        /// <returns></returns>
        public static Position ConvertToPosition(Point objectPoint, Point leftTop, Point rightDown)
        {
            //フォーム上のコートの横幅、縦幅
            double _formCortX = rightDown.X - leftTop.X;
            double _formCortY = rightDown.Y - leftTop.Y;

            //実際のコートとの比
            double _ratioX = _formCortX / CortX;
            double _ratioY = _formCortY / CortY;

            //フォーム上のコートから見たオブジェクトの相対座標
            double _relativeX = objectPoint.X - leftTop.X;
            double _relativeY = objectPoint.Y - leftTop.Y;

            //実際のコート上の相対座標
            double _relativeRealX = _relativeX / _ratioX;
            double _relativeRealY = _relativeY / _ratioY;

            return new Position(_relativeRealX, _relativeRealY);
        }
        
        /// <summary>
        /// Position型変数を指定された描画先上の座標に変換する
        /// </summary>
        /// <param name="position">BMで定義された実際のコート上の位置情報</param>
        /// <param name="leftTop">描画先の左上座標</param>
        /// <param name="rightDown">描画先の右下座標</param>
        /// <returns>描画先上のPoint型座標</returns>
        public static Point ConvertToPoint(Position position, Point leftTop, Point rightDown)
        {
            //フォーム上描画先のx,yの長さ
            double _XLength = rightDown.X - leftTop.X;
            double _YLength = rightDown.Y - leftTop.Y;

            //実際のコートとの比
            double _ratioX = _XLength / CortX;
            double _ratioY = _YLength / CortY;

            return new Point((int)(position.PosX * _ratioX), (int)(position.PosY * _ratioY));
        }

        
    }
}
