using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasketballManagementSystem.abstracts;
using BasketballManagementSystem.baseClass.game;
using BasketballManagementSystem.manager;

namespace BasketballManagementSystem.bmForm.gameDataEdit
{
    public class FormGameDataEditModel : AbstractModel
    {
        public Game Game { get; set; }

        public FormGameDataEditModel()
        {
            this.Game = SaveDataManager.GetInstance().GetGame();
        }
    }
}
