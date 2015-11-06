using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasketballManagementSystem.interfaces;
using BasketballManagementSystem.events;
using BasketballManagementSystem.baseClass.game;
using BasketballManagementSystem.baseClass.player;
using BasketballManagementSystem.manager;
using BasketballManagementSystem.abstracts;

namespace BasketballManagementSystem.bmForm.actionPointGraph
{
    public class FormActionPointGraphModel : AbstractModel
    {
        /// <summary>
        /// 現在のゲームデータオブジェクト
        /// </summary>
        public Game Game { get; set; }
 
        private Player selectedPlayer = new Player("No Name", 0);

        /// <summary>
        /// 選択選手
        /// </summary>
        public Player SelectedPlayer
        {
            get { return this.selectedPlayer; }
            set { this.selectedPlayer = value; }
        }


        public FormActionPointGraphModel()
        {
            this.Game = SaveDataManager.GetInstance().GetGame();
        }

       
    }
}
