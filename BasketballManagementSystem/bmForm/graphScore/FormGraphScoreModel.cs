using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasketballManagementSystem.baseClass.game;
using BasketballManagementSystem.manager;

namespace BasketballManagementSystem.bmForm.graphScore
{
    public class FormGraphScoreModel : abstracts.AbstractModel
    {
        public Game Game { get; set; }

        public FormGraphScoreModel()
        {
            this.Game = SaveDataManager.GetInstance().GetGame();
        }
    }
}
