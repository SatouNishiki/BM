using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasketballManagementSystem.BaseClass.Player;


namespace BasketballManagementSystem.BMForm.StrategySimulation
{
    /// <summary>
    /// StrategySimulationで使われる戦術の1盤面をあらわすクラス
    /// </summary>
    public class Board
    {

        /// <summary>
        /// 盤面にいるプレイヤーのlist
        /// </summary>
        public List<BoardPlayer> FieldMembers { get; set; }

        /// <summary>
        /// 実行する時間
        /// </summary>
        public int ExecuteTime { get; set; }

    }
}
