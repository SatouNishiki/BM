using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BasketballManagementSystem.BaseClass.ActionPoint;
using BasketballManagementSystem.Manager;
using BasketballManagementSystem.BaseClass.Game;
using BasketballManagementSystem.BaseClass.Player;

namespace BasketballManagementSystem.BMForm.CentralityAnalyze
{
    public partial class FormCentralityAnalyze : Form
    {
        private Game game = SaveDataManager.GetInstance().GetGame();

        private Player sourcePlayer;
        private Player targetPlayer;

        public FormCentralityAnalyze()
        {
            InitializeComponent();

          //  ActionPointAnalyze a = new ActionPointAnalyze();
        //    MessageBox.Show(a.GetNexus(SaveDataManager.GetInstance().GetGame().MyTeam.TeamMember[0], SaveDataManager.GetInstance().GetGame().MyTeam.TeamMember[1]).ToString());
          
        }

        private void FormCentralityAnalyze_Load(object sender, EventArgs e)
        {
            foreach (var p in game.MyTeam.TeamMember)
            {
                MyTeamListBox.Items.Add(p);
            }

            foreach (var p in game.OppentTeam.TeamMember)
            {
                OppentTeamListBox.Items.Add(p);
            }
        }

        private void AddSourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
         //   sourcePlayer = (Player)((ListBox)(((ContextMenuStrip)sender).SourceControl)).SelectedItem;
            var menu = (ContextMenuStrip)sender;
            sourcePlayer = (Player)((ListBox)(menu.SourceControl)).SelectedItem;
            SourceTextBox.Text = sourcePlayer.ToString();
        }

        private void AddTargetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            targetPlayer = (Player)((ListBox)(((ContextMenuStrip)sender).SourceControl)).SelectedItem;
            TargetTextBox.Text = targetPlayer.ToString();
        }

        private void AnalyzeButton_Click(object sender, EventArgs e)
        {

            if (sourcePlayer == null)
                MessageBox.Show("ソースプレイヤーがいません");

            if (targetPlayer == null)
                MessageBox.Show("ターゲットプレイヤーがいません");

            ActionPointAnalyze a = new ActionPointAnalyze();
        

            Dictionary<int, int> dic = a.GetNexus(sourcePlayer, targetPlayer);

            if (dic == null) { 
                ResultTextBox.Text = "解析失敗";
                return;
            }

            ResultTextBox.AppendText("Normal Nexus = " + dic[ActionPointProvider.TypeNormal] + "\n");
            ResultTextBox.AppendText("Point Nexus = " + dic[ActionPointProvider.TypePoint] + "\n");
            ResultTextBox.AppendText("Miss Nexus = " + dic[ActionPointProvider.TypeMiss] + "\n");
            ResultTextBox.AppendText("Faul Nexus = " + dic[ActionPointProvider.TypeFaul] + "\n");

        }

        private void MyTeamListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sourcePlayer == null)
            {
                sourcePlayer = (Player)((ListBox)sender).SelectedItem;
                SourceTextBox.Text = sourcePlayer.ToString();
            }
            else
            {
                targetPlayer = (Player)((ListBox)sender).SelectedItem;
                TargetTextBox.Text = targetPlayer.ToString();
            }
        }

        private void OppentTeamListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sourcePlayer == null)
            {
                sourcePlayer = (Player)((ListBox)sender).SelectedItem;
                SourceTextBox.Text = sourcePlayer.ToString();
            }
            else
            {
                targetPlayer = (Player)((ListBox)sender).SelectedItem;
                TargetTextBox.Text = targetPlayer.ToString();
            }
        } 
    }
}
