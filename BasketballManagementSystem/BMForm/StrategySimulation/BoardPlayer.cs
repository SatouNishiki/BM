using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasketballManagementSystem.BaseClass.Player;
using BasketballManagementSystem.BaseClass.Position;

namespace BasketballManagementSystem.BMForm.StrategySimulation
{
    public class BoardPlayer
    {
        /// <summary>
        /// 盤面にいる選手
        /// </summary>
        public Player Player { get; set; }

        /// <summary>
        /// 選手の配置情報
        /// </summary>
        public Position PlayerPosition { get; set; }
    }
}
