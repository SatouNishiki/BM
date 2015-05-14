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
        public int point { get; set; }

        /// <summary>
        /// このアクションが行われた場所
        /// </summary>
        public Position.Position position { get; set; }

        public RelationPointAction()
        {
            position = new Position.Position();
        }

        public override string ToString()
        {
            //四捨五入
            int posX = (int)Math.Round(position.PosX, MidpointRounding.AwayFromZero);
            int posY = (int)Math.Round(position.PosY, MidpointRounding.AwayFromZero);

            return "ActionName=" + ActionName  + ", ActionPosition=" + posX
                + "[m] , " + posY + "[m]";
        }
    }
}
