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
using BasketballManagementSystem.Manager;
using BasketballManagementSystem.BaseClass.Player;
using BasketballManagementSystem.BaseClass.Action;
using Mathmatical;

namespace BasketballManagementSystem.BMForm.PlayerData
{
    public partial class PlayerData : Form
    {
        private Game game = SaveDataManager.GetInstance().GetGame();

        private Player selectedPlayer = new Player();

        public PlayerData()
        {
            InitializeComponent();

            TeamListInit();

            DataGridViewInit();

            TotalDataInit();
        }

        private void MyTeamList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Player p = (Player)MyTeamListBox.Items[MyTeamListBox.SelectedIndex];
            SelectPlayer.Text = p.ToString();
            selectedPlayer = p;

            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
            dataGridView4.Rows.Clear();
            dataGridView5.Rows.Clear();
            DataGridViewInit();
            TotalDataInit();
        }

        private void OppentTeamList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Player p = (Player)OppentTeamListBox.Items[OppentTeamListBox.SelectedIndex];
            SelectPlayer.Text = p.ToString();
            selectedPlayer = p;

            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
            dataGridView4.Rows.Clear();
            dataGridView5.Rows.Clear();
            DataGridViewInit();
            TotalDataInit();
        }

        private void TeamListInit()
        {
            foreach (Player p in game.MyTeam.TeamMember)
            {
                this.MyTeamListBox.Items.Add(p);
            }

            foreach (Player p in game.OppentTeam.TeamMember)
            {
                this.OppentTeamListBox.Items.Add(p);
            }
        }

        private void DataGridViewInit()
        {

            dataGridView1.Rows.Add(GetRow(new Shoot2P().ActionName, new Shoot2PMiss().ActionName, 1));
            dataGridView1.Rows.Add(GetRow(new Shoot3P().ActionName, new Shoot3PMiss().ActionName, 1));
            dataGridView1.Rows.Add(GetRow(new FreeThrow().ActionName, new FreeThrowMiss().ActionName, 1));
            dataGridView1.Rows.Add(GetRow(new Assist().ActionName, 1));
            dataGridView1.Rows.Add(GetRow(new Steal().ActionName, 1));
            dataGridView1.Rows.Add(GetRow(new TurnOver().ActionName, 1));
            dataGridView1.Rows.Add(GetRow(new ShootBlock().ActionName, 1));
            dataGridView1.Rows.Add(GetRow(new PersonalFaul().ActionName, 1));
            dataGridView1.Rows.Add(GetRow(new TechnicalFaul().ActionName, 1));
            dataGridView1.Rows.Add(GetRow(new UnSportsmanLikeFaul().ActionName, 1));
            dataGridView1.Rows.Add(GetRow(new DisQualifyingFaul().ActionName, 1));

            dataGridView2.Rows.Add(GetRow(new Shoot2P().ActionName, new Shoot2PMiss().ActionName, 2));
            dataGridView2.Rows.Add(GetRow(new Shoot3P().ActionName, new Shoot3PMiss().ActionName, 2));
            dataGridView2.Rows.Add(GetRow(new FreeThrow().ActionName, new FreeThrowMiss().ActionName, 2));
            dataGridView2.Rows.Add(GetRow(new Assist().ActionName, 2));
            dataGridView2.Rows.Add(GetRow(new Steal().ActionName, 2));
            dataGridView2.Rows.Add(GetRow(new TurnOver().ActionName, 2));
            dataGridView2.Rows.Add(GetRow(new ShootBlock().ActionName, 2));
            dataGridView2.Rows.Add(GetRow(new PersonalFaul().ActionName, 2));
            dataGridView2.Rows.Add(GetRow(new TechnicalFaul().ActionName, 2));
            dataGridView2.Rows.Add(GetRow(new UnSportsmanLikeFaul().ActionName, 2));
            dataGridView2.Rows.Add(GetRow(new DisQualifyingFaul().ActionName, 2));

            dataGridView3.Rows.Add(GetRow(new Shoot2P().ActionName, new Shoot2PMiss().ActionName, 3));
            dataGridView3.Rows.Add(GetRow(new Shoot3P().ActionName, new Shoot3PMiss().ActionName, 3));
            dataGridView3.Rows.Add(GetRow(new FreeThrow().ActionName, new FreeThrowMiss().ActionName, 3));
            dataGridView3.Rows.Add(GetRow(new Assist().ActionName, 3));
            dataGridView3.Rows.Add(GetRow(new Steal().ActionName, 3));
            dataGridView3.Rows.Add(GetRow(new TurnOver().ActionName, 3));
            dataGridView3.Rows.Add(GetRow(new ShootBlock().ActionName, 3));
            dataGridView3.Rows.Add(GetRow(new PersonalFaul().ActionName, 3));
            dataGridView3.Rows.Add(GetRow(new TechnicalFaul().ActionName, 3));
            dataGridView3.Rows.Add(GetRow(new UnSportsmanLikeFaul().ActionName, 3));
            dataGridView3.Rows.Add(GetRow(new DisQualifyingFaul().ActionName, 3));

            dataGridView4.Rows.Add(GetRow(new Shoot2P().ActionName, new Shoot2PMiss().ActionName, 4));
            dataGridView4.Rows.Add(GetRow(new Shoot3P().ActionName, new Shoot3PMiss().ActionName, 4));
            dataGridView4.Rows.Add(GetRow(new FreeThrow().ActionName, new FreeThrowMiss().ActionName, 4));
            dataGridView4.Rows.Add(GetRow(new Assist().ActionName, 4));
            dataGridView4.Rows.Add(GetRow(new Steal().ActionName, 4));
            dataGridView4.Rows.Add(GetRow(new TurnOver().ActionName, 4));
            dataGridView4.Rows.Add(GetRow(new ShootBlock().ActionName, 4));
            dataGridView4.Rows.Add(GetRow(new PersonalFaul().ActionName, 4));
            dataGridView4.Rows.Add(GetRow(new TechnicalFaul().ActionName, 4));
            dataGridView4.Rows.Add(GetRow(new UnSportsmanLikeFaul().ActionName, 4));
            dataGridView4.Rows.Add(GetRow(new DisQualifyingFaul().ActionName, 4));
        }

 
        private object[] GetRow(string actionName, int quarter)
        {
            object[] o = new object[11];

            o[0] = actionName;

            for (int i = 0; i <= 9; i++)
            {
                o[i + 1] = (selectedPlayer.GetActionList(selectedPlayer,actionName, quarter, 10 - i, 9 - i)).Count;
            
            }

            return o;
        }

        private object[] GetRow(string actionName, string missActionName, int quarter)
        {
            object[] o = new object[11];

            o[0] = actionName;

            for (int i = 0; i <= 9; i++)
            {
                double a = (selectedPlayer.GetActionList(selectedPlayer, actionName, quarter, 10 - i, 9 - i)).Count;
                double b = (selectedPlayer.GetActionList(selectedPlayer, missActionName, quarter, 10 - i, 9 - i)).Count;

                string s = "";

                if((a + b) > 0.0D)
                {
                    double d = a / (a + b);
                    d = d * 100;
                    s = (int)a + "/" + (int)(a + b) + " " + Mathmatical.Mathmatical.ToRoundDown(d, 2) + "%";
                }
                else
                {
                    s = "0/0 0%";
                }

                o[i + 1] = s;
            }

            return o;
        }

        private void TotalDataInit()
        {
            dataGridView5.Rows.Add(GetTotalDataRow());
        }

        private object[] GetTotalDataRow()
        {
            object[] o = new object[11];
            double a;
            double b;
            double c;

            if (selectedPlayer.Shoot2P.Count + selectedPlayer.Shoot2PMiss.Count > 0)
            {
                 a = ((double)selectedPlayer.Shoot2P.Count / (selectedPlayer.Shoot2P.Count + selectedPlayer.Shoot2PMiss.Count)) * 100;
            }
            else
            {
                a = 0.0D;
            }

            if (selectedPlayer.Shoot3P.Count + selectedPlayer.Shoot3PMiss.Count > 0)
            {
                b = ((double)selectedPlayer.Shoot3P.Count / (selectedPlayer.Shoot3P.Count + selectedPlayer.Shoot3PMiss.Count)) * 100;
            }
            else 
            {
                b = 0.0D;
            }

            if (selectedPlayer.FreeThrow.Count + selectedPlayer.FreeThrowMiss.Count > 0)
            {
                c = ((double)selectedPlayer.FreeThrow.Count / (selectedPlayer.FreeThrow.Count + selectedPlayer.FreeThrowMiss.Count)) * 100;
            }
            else
            {
                c = 0.0D;
            }
            o[0] = selectedPlayer.Shoot2P.Count + "/" + (selectedPlayer.Shoot2P.Count + selectedPlayer.Shoot2PMiss.Count) + " " + Mathmatical.Mathmatical.ToRoundDown(a, 2) + "%";
            o[1] = selectedPlayer.Shoot3P.Count + "/" + (selectedPlayer.Shoot3P.Count + selectedPlayer.Shoot3PMiss.Count) + " " + Mathmatical.Mathmatical.ToRoundDown(b, 2) + "%";
            o[2] = selectedPlayer.FreeThrow.Count + "/" + (selectedPlayer.FreeThrow.Count + selectedPlayer.FreeThrowMiss.Count) + " " + Mathmatical.Mathmatical.ToRoundDown(c, 2) + "%";

            o[3] = selectedPlayer.Assist.Count;
            o[4] = selectedPlayer.Steal.Count;
            o[5] = selectedPlayer.TurnOver.Count;
            o[6] = selectedPlayer.ShootBlock.Count;
            o[7] = selectedPlayer.PersonalFaul.Count;
            o[8] = selectedPlayer.TechnicalFaul.Count;
            o[9] = selectedPlayer.UnSportsmanLikeFaul.Count;
            o[10] = selectedPlayer.DisQualifyingFaul.Count;

            return o;
        }

        private void PrintForm_Click(object sender, EventArgs e)
        {
            FormPrinter fp = new FormPrinter();
            fp.PrintForm(this);
        }

        private void PrintPreview_Click(object sender, EventArgs e)
        {
            FormPrinter fp = new FormPrinter();
            fp.ShowPrintPreview(this);
        }
    }
}
