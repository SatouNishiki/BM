using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BasketballManagementSystem.BaseClass.Position;

namespace BasketballManagementSystem.BaseClass.Action
{
    /// <summary>
    /// 得点に関係するアクションのクラス
    /// </summary>
    [Serializable]
    public class RelationPointAction : Action
    {
        /// <summary>
        /// このアクションが行われたときに入る点数
        /// </summary>
        public int Point { get; set; }

        /// <summary>
        /// このアクションが行われた場所
        /// </summary>
        public Position.Position Position { get; set; }

        public RelationPointAction()
        {
            Position = new Position.Position();
        }

        public override string ToString()
        {
            //四捨五入
            int posX = (int)Math.Round(Position.PosX, MidpointRounding.AwayFromZero);
            int posY = (int)Math.Round(Position.PosY, MidpointRounding.AwayFromZero);

            return "ActionName=" + ActionName  + ", ActionPosition=" + posX
                + "[m] , " + posY + "[m]";
        }
    }
}
