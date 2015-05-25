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
        public static readonly Position goalPosition = new Position(1.2, PositionConvert.CortY / 2);

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
            double xLength = rightDown.X - leftTop.X;
            double yLength = rightDown.Y - leftTop.Y;

            //実際のコートとの比
            double ratioX = xLength / PositionConvert.CortX;
            double ratioY = yLength / PositionConvert.CortY;

            return new double[] { length * ratioX, length * ratioY };
        }

        /// <summary>
        /// 指定されたアクションのリストの中から最もゴールまでの距離が長いものを検索し、その距離を返す
        /// </summary>
        /// <param name="l">RelationPointAction、またはそれを継承したクラスのインスタンスリスト</param>
        /// <returns>見つかったアクションのゴールまでの距離</returns>
        public static double GetMaxShootRange(List<RelationPointAction> l)
        {
            double maxRange = 0;

            foreach (var r in l)
            {
                double c = GetDistanceFromGoal(r.Position);

                if (c > maxRange)
                {
                    maxRange = c;
                }
            }

            return maxRange;
        }

        /// <summary>
        /// ゴールまでの距離を計算する
        /// </summary>
        /// <param name="p">Potision型の変数</param>
        /// <returns>コートまでの距離</returns>
        public static double GetDistanceFromGoal(Position p)
        {
            double a = p.PosX - goalPosition.PosX;

            double b = p.PosY - goalPosition.PosY;

            double c = Math.Sqrt(a * a + b * b);

            return c;
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
