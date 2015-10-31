using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BasketballManagementSystem.baseClass.actionPoint;
using BasketballManagementSystem.manager;
using BasketballManagementSystem.baseClass.game;
using BasketballManagementSystem.baseClass.player;

namespace BasketballManagementSystem.bmForm.centralityAnalyze
{
    public partial class FormCentralityAnalyze : Form
    {
        private Game game = SaveDataManager.GetInstance().GetGame();

        private Player sourcePlayer;
        private Player targetPlayer;

        public FormCentralityAnalyze()
        {
            InitializeComponent();     
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
       
        private void AnalyzeButton_Click(object sender, EventArgs e)
        {

            if (sourcePlayer == null)
            {
                MessageBox.Show("ソースプレイヤーがいません");
                return;
            }

            ActionPointAnalyze a = new ActionPointAnalyze();

            ResultTextBox.Clear();
            ResultTextBox.AppendText("**解析結果**\n");
            ResultTextBox.AppendText("解析方法 : 行動傾向点基準結びつき度分析\n");
            ResultTextBox.AppendText("\n");

            Team team;

            if (sourcePlayer.IsMyTeam)
                team = game.MyTeam;
            else
                team = game.OppentTeam;

            foreach (var p in team.TeamMember)
            {
                targetPlayer = p;

                if (sourcePlayer == targetPlayer) continue;

                Dictionary<int, int> dic = a.GetNexus(sourcePlayer, targetPlayer);

                if (dic == null)
                {
                    ResultTextBox.Text = "解析失敗";
                    return;
                }

                ResultTextBox.AppendText("対象 : " + sourcePlayer.Name + "(" + sourcePlayer.Number + ") → " + targetPlayer.Name + "(" + targetPlayer.Number + ")\n");
                ResultTextBox.AppendText("\n");
                ResultTextBox.AppendText("通常 = " + dic[ActionPointProvider.TypeNormal] + "\n"); 
                ResultTextBox.AppendText("得点 = " + dic[ActionPointProvider.TypePoint] + "\n");
                ResultTextBox.AppendText("ミス = " + dic[ActionPointProvider.TypeMiss] + "\n");
                ResultTextBox.AppendText("ファウル = " + dic[ActionPointProvider.TypeFaul] + "\n");
                ResultTextBox.AppendText("\n");
            }
        }

        private void MyTeamListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            sourcePlayer = (Player)((ListBox)sender).SelectedItem;
            SourceTextBox.Text = sourcePlayer.ToString();
        }

        private void OppentTeamListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            sourcePlayer = (Player)((ListBox)sender).SelectedItem;
            SourceTextBox.Text = sourcePlayer.ToString();
        }
    }
}
