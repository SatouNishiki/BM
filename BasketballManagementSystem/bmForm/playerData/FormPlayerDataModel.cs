using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasketballManagementSystem.baseClass.game;
using BasketballManagementSystem.baseClass.player;
using BasketballManagementSystem.manager;

namespace BasketballManagementSystem.bmForm.playerData
{
    public class FormPlayerDataModel : abstracts.AbstractModel
    {
        public Game Game { get; set; }

        public Player SelectedPlayer { get; set; }

        public FormPlayerDataModel()
        {
            this.Game = SaveDataManager.GetInstance().GetGame();
            this.SelectedPlayer = new Player();
        }
    }
}
