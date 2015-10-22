using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasketballManagementSystem.BMForm.boxScore
{
    public class PlayerInfomation
    {
        public Label Name { get; set; }

        public Label Number { get; set; }

        public Label[] Fauls { get; set; }

        public Label PlIn { get; set; }

        public PlayerInfomation()
        {
            Fauls = new Label[5];
        }
    }
}
