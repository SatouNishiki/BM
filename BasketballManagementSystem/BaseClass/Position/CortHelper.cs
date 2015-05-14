using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using BasketballManagementSystem.BaseClass.Action;

namespace BasketballManagementSystem.BaseClass.Position
{
    public class CortHelper
    {
        //ゴールの位置はエンドラインより120cm内側である(競技ルールより)
        private static Position goalPosition = new Position(1.2, PositionConvert.CortY / 2);

        /// <summary>
        /// 指定された実際のコート上の長さをフォーム上の長さに変換する
        /// </summary>
        /// <param name="leftTop">描画先の左上座標</param>
        /// <param name="rightDown">描画先の右下座標</param>
        /// <param name="length">実際のコート上の長さ(m)</param>
        /// <returns>長さ2の二次元配列(x,y)</returns>
        public static double[] GetCortLengthFromForm(Point leftTop, Point rightDown, double length)
        {
            //フォーム上描画先のx,yの長さ
            double _XLength = rightDown.X - leftTop.X;
            double _YLength = rightDown.Y - leftTop.Y;

            //実際のコートとの比
            double _ratioX = _XLength / PositionConvert.CortX;
            double _ratioY = _YLength / PositionConvert.CortY;

            return new double[] { length * _ratioX, length * _ratioY };
        }

        public static double GetMaxShootRange(List<RelationPointAction> l)
        {
            double _maxRange = 0;

            foreach (RelationPointAction r in l)
            {
                double _c = GetDistanceFromCort(r.position);

                if (_c > _maxRange)
                {
                    _maxRange = _c;
                }
            }

            return _maxRange;
        }

        public static double GetDistanceFromCort(Position p)
        {
            double _a = p.PosX - goalPosition.PosX;

            double _b = p.PosY - goalPosition.PosY;

            double _c = Math.Sqrt(_a * _a + _b * _b);

            return _c;
        }

     
        /// <summary>
        /// p1とp2間の距離を返す
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static double GetDistance(Position p1, Position p2)
        {
            double a = p1.PosX - p2.PosX;

            double b = p1.PosY - p2.PosY;

            double c = Math.Sqrt(a * a + b * b);

            return c;
        }

    }
}
