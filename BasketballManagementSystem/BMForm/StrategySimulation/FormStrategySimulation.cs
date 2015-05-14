using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BasketballManagementSystem.BaseClass.Game;
using BasketballManagementSystem.Manager.SaveDataManager;
using BasketballManagementSystem.BaseClass.Player;
using DragDropPictureBox;

namespace BasketballManagementSystem.BMForm.StrategySimulation
{
    public partial class FormStrategySimulation : Form
    {
        private Game game = SaveDataManager.GetInstance().GetGame();

        public FormStrategySimulation()
        {
            InitializeComponent();

            System.Reflection.Assembly myAssembly =
    System.Reflection.Assembly.GetExecutingAssembly();

            int count = 0;
            int width = dragDropBoxBench.Width / game.MyTeam.TeamMember.Count;
            int height = 10;

            foreach (Player p in game.MyTeam.TeamMember)
            {
                Bitmap b = new Bitmap(myAssembly.GetManifestResourceStream
                     ("BasketballManagementSystem.BMForm.StrategySimulation.Picture.People.png"));

                b.Tag = p.ToString();

                if (count % 2 == 0)
                {
                    dragDropBoxBench.LocationBitmapList.Add(new LocationBitmap(b, new Point(count * width, height)));
                }
                else
                {
                    dragDropBoxBench.LocationBitmapList.Add(new LocationBitmap(b, new Point(count * width, height + dragDropBoxBench.Height / 2)));
                }

                count++;

            }
        }


    }
}
