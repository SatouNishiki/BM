using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasketballManagementSystem.baseClass.player;
using BasketballManagementSystem.baseClass.position;

namespace BasketballManagementSystem.bmForm.strategySimulation
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

        public BoardPlayer()
        {
            Player = new Player();
            PlayerPosition = new Position();
        }
    }
}
