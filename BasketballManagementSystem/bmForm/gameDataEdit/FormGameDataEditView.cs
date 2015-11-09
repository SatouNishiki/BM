using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BasketballManagementSystem.baseClass.game;
using BasketballManagementSystem.manager;
using BMFileLibrary;
using System.IO;
using BasketballManagementSystem.baseClass.player;
using BasketballManagementSystem.baseClass.action;
using System.Collections;
using BasketballManagementSystem.interfaces.gameDataEdit;

namespace BasketballManagementSystem.bmForm.gameDataEdit
{
    public partial class FormGameDataEditView : Form, IGameDataEditView
    {
        public FormGameDataEditView()
        {
            InitializeComponent();

        }

        public void Init()
        {
            Game game = (Game)this.Presenter.GetModelProperty("Game");

            PlayerSelectCombo.Items.Add("AllPlayer");

            foreach (var p in game.MyTeam.TeamMember)
            {
                PlayerSelectCombo.Items.Add(p);
            }

            foreach (var p in game.OppentTeam.TeamMember)
            {
                PlayerSelectCombo.Items.Add(p);
            }

            foreach (var s in Player.GetAllActionName())
            {
                ActionSelectConbo.Items.Add(s);
            }

            if (PlayerSelectCombo.Items.Count != 0)
                PlayerSelectCombo.SelectedIndex = 0;

            if (ActionSelectConbo.Items.Count != 0)
                ActionSelectConbo.SelectedIndex = 0;


            List<Player> l = new List<Player>();

            l.AddRange(game.MyTeam.TeamMember);
            l.AddRange(game.OppentTeam.TeamMember);

            PlayerInfoGridView.DataSource = l;
        }

        private void ActionSelectConbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PlayerSelectCombo.SelectedItem == null) return;

            if (PlayerSelectCombo.SelectedItem.ToString() == "AllPlayer")
            {
                if (PlayerSelectCombo.Items.Count == 1) return;

                List<object> obj = new List<object>();

                for (var i = 1; i < PlayerSelectCombo.Items.Count; i++)
                {
                    Player p = (Player)PlayerSelectCombo.Items[i];

                    object oo = p.GetActionProperty(p, (string)ActionSelectConbo.SelectedItem);
                   
                    if (obj != null)
                    {
                        foreach (var o in (IList)oo)
                        {
                            obj.Add(o);
                        }

                    }
                }
                ActionInfoGridView.DataSource = obj;
            }
            else
            {
                Player p = (Player)PlayerSelectCombo.SelectedItem;

                ActionInfoGridView.DataSource = p.GetActionProperty(p, (string)ActionSelectConbo.SelectedItem);
            }
        }

        private void gameDataSave_Click(object sender, EventArgs e)
        {
            Game game = (Game)this.Presenter.GetModelProperty("Game");

            List<Player> l = (List<Player>)PlayerInfoGridView.DataSource;

            game.MyTeam.CortMember.Clear();
            game.MyTeam.OutMember.Clear();
            game.OppentTeam.CortMember.Clear();
            game.OppentTeam.OutMember.Clear();

            foreach (var p in l)
            {
                if (p.IsMyTeam)
                {
                    if (p.IsStarter)
                    {
                        game.MyTeam.CortMember.Add(p);
                    }
                    else
                    {
                        game.MyTeam.OutMember.Add(p);
                    }
                }
                else
                {
                    if (p.IsStarter)
                    {
                        game.OppentTeam.CortMember.Add(p);
                    }
                    else
                    {
                        game.OppentTeam.OutMember.Add(p);
                    }
                }
            }


            foreach (string name in ActionSelectConbo.Items)
            {
                foreach (var p in game.MyTeam.TeamMember)
                {
                    ActionInfoGridView.DataSource = p.GetActionProperty(p, name);

                    p.SetActionProperty(p, name, ActionInfoGridView.DataSource);

                }
            }

        }

        private void EditForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            gameDataSave_Click(sender, e);
        }

        private void printForm_Click(object sender, EventArgs e)
        {
            FormPrinter fp = new FormPrinter();
            fp.PrintForm(this);
        }

        private void printPreview_Click(object sender, EventArgs e)
        {
            FormPrinter fp = new FormPrinter();
            fp.ShowPrintPreview(this);
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
