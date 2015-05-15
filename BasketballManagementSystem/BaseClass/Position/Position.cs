using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasketballManagementSystem.BaseClass.Position
{

    /// <summary>
    /// 競技バスケットボールのルールにのっとって、コートの大きさを縦(x)28m、横(y)15mとしたときの座標
    /// </summary>
    [Serializable]
    public class Position
    {
        public double PosX { get; set; }
        public double PosY { get; set; }

        public Position() { }

        public Position(double x, double y)
        {
            PosX = x;
            PosY = y;
        }

        public override string ToString()
        {
            return PosX + ", " + PosY;
        }
    }
}
