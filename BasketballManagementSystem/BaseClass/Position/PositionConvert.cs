using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BasketballManagementSystem.baseClass.position
{
    public class PositionConvert
    {
        /// <summary>
        /// コートの横幅
        /// </summary>
        public static readonly double CortX = 28.0;

        /// <summary>
        /// コートの縦幅
        /// </summary>
        public static readonly double CortY = 15.0;

        /// <summary>
        /// 指定されたオブジェクトの座標をコートの大きさを縦(x)28m、横(y)15mとしたときの座標に変換する
        /// </summary>
        /// <param name="objectPoint">変換する対象のオブジェクトの座標(フォーム上の座標)</param>
        /// <param name="leftTop">変換する対象があったコートの左上の座標(フォーム上の座標)</param>
        /// <param name="rightDown">変換する対象があったコートの右下の座標(フォーム上の座標)</param>
        /// <param name="isMyTeam">プレイヤー変数の持つチーム情報</param>
        /// <param name="isCortChange">コートチェンジを行っているかどうか</param>
        /// <returns></returns>
        public static Position ConvertToPosition(Point objectPoint, Point leftTop, Point rightDown, bool isMyTeam, bool isCortChange)
        {
            //フォーム上のコートの横幅、縦幅
            double formCortX = rightDown.X - leftTop.X;
            double formCortY = rightDown.Y - leftTop.Y;

            //実際のコートとの比
            double ratioX = formCortX / CortX;
            double ratioY = formCortY / CortY;

            //フォーム上のコートから見たオブジェクトの相対座標
            double relativeX = objectPoint.X - leftTop.X;
            double relativeY = objectPoint.Y - leftTop.Y;

            //実際のコート上の相対座標
            double relativeRealX = relativeX / ratioX;
            double relativeRealY = relativeY / ratioY;

            if (!isCortChange)
            {
                //コートの図で左に攻めてるチームなら
                if (!isMyTeam)
                {
                    relativeRealX = CortX - relativeRealX;
                }
            }
            else
            {
                //コートチェンジ以降に左に攻めてるチーム(コートチェンジ前は右に攻めてたチーム)なら
                if (isMyTeam)
                {
                    relativeRealX = CortX - relativeRealX;
                }
            }

            return new Position(relativeRealX, relativeRealY);
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
            double xLength = rightDown.X - leftTop.X;
            double yLength = rightDown.Y - leftTop.Y;

            //実際のコートとの比
            double ratioX = xLength / CortX;
            double ratioY = yLength / CortY;

            return new Point((int)(position.PosX * ratioX), (int)(position.PosY * ratioY));
        }

        
    }
}
