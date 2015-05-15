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

        private const int PermissionPlayerCount = 5;

        public FormStrategySimulation()
        {
            InitializeComponent();

            System.Reflection.Assembly myAssembly =
    System.Reflection.Assembly.GetExecutingAssembly();

            int count = 0;
            int width;

            if (game.MyTeam.TeamMember.Count != 0)
            {
                width = dragDropBoxBench.Width / game.MyTeam.TeamMember.Count;
            }
            else
            {
                width = 0;
            }
            int height = 10;


            foreach (Player p in game.MyTeam.TeamMember)
            {
                Bitmap playerGraph = new Bitmap(myAssembly.GetManifestResourceStream
                     ("BasketballManagementSystem.BMForm.StrategySimulation.Picture.People.png"));

                playerGraph.Tag = p.ToString();

                if (count % 2 == 0)
                {
                    dragDropBoxBench.LocationBitmapList.Add(new LocationBitmap(playerGraph, new Point(count * width, height)));
                }
                else
                {
                    dragDropBoxBench.LocationBitmapList.Add(new LocationBitmap(playerGraph, new Point(count * width, height + dragDropBoxBench.Height / 2)));
                }

                count++;

            }

            width = dragDropBoxBench2.Width / PermissionPlayerCount;

            Bitmap playerGraph2 = new Bitmap(myAssembly.GetManifestResourceStream
                     ("BasketballManagementSystem.BMForm.StrategySimulation.Picture.Player2.png"));

            for (count = 0; count < PermissionPlayerCount; count++)
            {
                dragDropBoxBench2.LocationBitmapList.Add(new LocationBitmap(playerGraph2, new Point(count * width, height)));
            }
        }

        private void buttonAddBoard_Click(object sender, EventArgs e)
        {
            Board board = new Board();

            foreach (LocationBitmap lb in dragDropBoxCort.LocationBitmapList)
            {
                LocationBitmap l = lb.CloneDeep();

                board.FieldMembers.Add(l);
            }

            board.ExecuteTime = listBoxBoard.Items.Count;

            listBoxBoard.Items.Add(board);
        }

        private void listBoxBoard_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}
