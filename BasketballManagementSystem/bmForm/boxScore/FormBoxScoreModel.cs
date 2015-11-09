using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasketballManagementSystem.interfaces;
using BasketballManagementSystem.baseClass.game;
using BasketballManagementSystem.manager;

namespace BasketballManagementSystem.bmForm.boxScore
{
    public class FormBoxScoreModel : abstracts.AbstractModel
    {
        public Game Game { get; set; }

        public FormBoxScoreModel()
        {
            this.Game = SaveDataManager.GetInstance().GetGame();
        }

    }
}
