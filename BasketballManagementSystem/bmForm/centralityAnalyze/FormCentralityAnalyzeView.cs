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
using BasketballManagementSystem.interfaces.centralityAnalyze;

namespace BasketballManagementSystem.bmForm.centralityAnalyze
{
    public partial class FormCentralityAnalyzeView : Form, ICentralityAnalyzeView
    {
        private Game game;


        public event Action AnalyzeButtonClickEvent;

        public event Action<Player> SourcePlayerSelectedEvent;

        public FormCentralityAnalyzeView()
        {
            InitializeComponent();
        }

        private void AnalyzeButtonClickEventThrow()
        {
            if (this.AnalyzeButtonClickEvent != null)
            {
                this.AnalyzeButtonClickEvent();
            }
        }

        private void SourcePlayerSelectedEventThrow(Player selectedPlayer)
        {
            if (this.SourcePlayerSelectedEvent != null)
            {
                this.SourcePlayerSelectedEvent(selectedPlayer);
            }
        }

        public void Init()
        {
            game = (Game)this.Presenter.GetModelProperty("Game");
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
            

           // ActionPointAnalyze a = new ActionPointAnalyze();

           

            this.AnalyzeButtonClickEventThrow();
            /*
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
            }*/
        }

        public void WriteResult(string text)
        {
            ResultTextBox.AppendText(text);
        }

        public void ClearResult()
        {
            this.ResultTextBox.Clear();
        }


        private void MyTeamListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
          //  sourcePlayer = (Player)((ListBox)sender).SelectedItem;
            if (((ListBox)sender).SelectedIndex >= 0)
            {
                this.SourcePlayerSelectedEventThrow((Player)((ListBox)sender).SelectedItem);
                SourceTextBox.Text = ((Player)this.Presenter.GetModelProperty("SourcePlayer")).ToString();
            }
        }

        private void OppentTeamListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
         //   sourcePlayer = (Player)((ListBox)sender).SelectedItem;
            if (((ListBox)sender).SelectedIndex >= 0)
            {
                this.SourcePlayerSelectedEventThrow((Player)((ListBox)sender).SelectedItem);
                SourceTextBox.Text = ((Player)this.Presenter.GetModelProperty("SourcePlayer")).ToString();
            }
        }


        private abstracts.AbstractPresenter presenter;

        public abstracts.AbstractPresenter Presenter
        {
            get
            {
                return this.presenter;
            }
            set
            {
                this.presenter = value;
            }
        }

        public event events.DataInputEventHandler DataInputEvent;

        private void DataChangeEventThrow(string name, object value)
        {
            if (this.DataInputEvent != null)
            {
                this.DataInputEvent(this, new events.DataInputEventArgs(name, value));
            }
        }

    }
}
