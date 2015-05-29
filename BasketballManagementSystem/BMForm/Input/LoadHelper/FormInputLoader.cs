using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasketballManagementSystem.BaseClass.Game;
using BasketballManagementSystem.BaseClass.Player;
using BasketballManagementSystem.Manager.SaveDataManager;

namespace BasketballManagementSystem.BMForm.Input.LoadHelper
{
    public class FormInputLoader
    {
        private static FormInputLoader instance;

        private FormInputLoader() { }

        public static FormInputLoader GetFormInputLoaderInstance()
        {
            if (instance == null) instance = new FormInputLoader();

            return instance;
        }

        delegate void SetListBoxDelegate(FormInput f, Game game);

        public void LoadForm(FormInput f, Game game)
        {
            f.Game = game;
            SaveDataManager.GetInstance().SetGame(game);

            //別スレッドからコントロールを操作するための努力
            if (f.MyCortTeamListBox.InvokeRequired)
            {
                SetListBoxDelegate sbd = (fi, g) =>
                {
                    fi.MyCortTeamListBox.Enabled = false;

                    fi.MyCortTeamListBox.Items.Clear();
                    foreach (Player p in g.MyTeam.CortMember)
                    {
                        fi.MyCortTeamListBox.Items.Add(p);
                    }

                    fi.MyCortTeamListBox.Enabled = true;



                    fi.MyOutTeamListBox.Enabled = false;

                    fi.MyOutTeamListBox.Items.Clear();
                    foreach (Player p in g.MyTeam.OutMember)
                    {
                        fi.MyOutTeamListBox.Items.Add(p);
                    }

                    fi.MyOutTeamListBox.Enabled = true;
                    fi.OppentCortTeamListBox.Enabled = false;

                    fi.OppentCortTeamListBox.Items.Clear();
                    foreach (Player p in g.OppentTeam.CortMember)
                    {
                        fi.OppentCortTeamListBox.Items.Add(p);
                    }

                    fi.OppentCortTeamListBox.Enabled = true;
                    fi.OppentOutTeamListBox.Enabled = false;

                    fi.OppentOutTeamListBox.Items.Clear();
                    foreach (Player p in g.OppentTeam.OutMember)
                    {
                        fi.OppentOutTeamListBox.Items.Add(p);
                    }

                    fi.OppentOutTeamListBox.Enabled = true;
                };

                f.Invoke(sbd, new object[] { f, game });
            }
            else
            {
                f.MyCortTeamListBox.Enabled = false;

                f.MyCortTeamListBox.Items.Clear();
                foreach (Player p in game.MyTeam.CortMember)
                {
                    f.MyCortTeamListBox.Items.Add(p);
                }

                f.MyCortTeamListBox.Enabled = true;



                f.MyOutTeamListBox.Enabled = false;

                f.MyOutTeamListBox.Items.Clear();
                foreach (Player p in game.MyTeam.OutMember)
                {
                    f.MyOutTeamListBox.Items.Add(p);
                }

                f.MyOutTeamListBox.Enabled = true;
                f.OppentCortTeamListBox.Enabled = false;

                f.OppentCortTeamListBox.Items.Clear();
                foreach (Player p in game.OppentTeam.CortMember)
                {
                    f.OppentCortTeamListBox.Items.Add(p);
                }

                f.OppentCortTeamListBox.Enabled = true;
                f.OppentOutTeamListBox.Enabled = false;

                f.OppentOutTeamListBox.Items.Clear();
                foreach (Player p in game.OppentTeam.OutMember)
                {
                    f.OppentOutTeamListBox.Items.Add(p);
                }

                f.OppentOutTeamListBox.Enabled = true;
                /*
                f.MyCortTeam.Refresh();
                f.MyOutTeam.Refresh();
                f.OppentCortTeam.Refresh();
                f.OppentOutTeam.Refresh();

                */
            }
        }

    }
}
