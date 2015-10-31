using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BasketballManagementSystem.interfaces;

namespace BasketballManagementSystem.bmForm.boxScore
{
    public class PlayerInfomationModel : IModel
    {
        public Label Name { get; set; }

        public Label Number { get; set; }

        public Label[] Fauls { get; set; }

        public Label PlIn { get; set; }

        public PlayerInfomationModel()
        {
            Fauls = new Label[5];
        }

        public event events.PropertyChangedEventHandler PropertyChangedEvent = null;
    }
}
