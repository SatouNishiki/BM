using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DragDropPictureBox;

namespace BasketballManagementSystem.bMForm.strategySimulation
{
    /// <summary>
    /// StrategySimulationで使われる戦術の1盤面をあらわすクラス
    /// </summary>
    public class Board
    {

        /// <summary>
        /// 盤面にいるプレイヤーのlist
        /// </summary>
        public List<LocationBitmap> FieldMembers { get; set; }

        /// <summary>
        /// 実行する時間
        /// </summary>
        public int ExecuteTime { get; set; }

        public Board()
        {
            FieldMembers = new List<LocationBitmap>();
        }

        public override string ToString()
        {
            return "Time=" + ExecuteTime + " : MembersCount=" + FieldMembers.Count;
        }

    }
}
