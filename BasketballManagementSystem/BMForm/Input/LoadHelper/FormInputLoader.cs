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
                SetListBoxDelegate sbd = (_f, _g) =>
                {
                    _f.MyCortTeamListBox.Enabled = false;

                    _f.MyCortTeamListBox.Items.Clear();
                    foreach (Player p in _g.MyTeam.CortMember)
                    {
                        _f.MyCortTeamListBox.Items.Add(p);
                    }

                    _f.MyCortTeamListBox.Enabled = true;



                    _f.MyOutTeamListBox.Enabled = false;

                    _f.MyOutTeamListBox.Items.Clear();
                    foreach (Player p in _g.MyTeam.OutMember)
                    {
                        _f.MyOutTeamListBox.Items.Add(p);
                    }

                    _f.MyOutTeamListBox.Enabled = true;
                    _f.OppentCortTeamListBox.Enabled = false;

                    _f.OppentCortTeamListBox.Items.Clear();
                    foreach (Player p in _g.OppentTeam.CortMember)
                    {
                        _f.OppentCortTeamListBox.Items.Add(p);
                    }

                    _f.OppentCortTeamListBox.Enabled = true;
                    _f.OppentOutTeamListBox.Enabled = false;

                    _f.OppentOutTeamListBox.Items.Clear();
                    foreach (Player p in _g.OppentTeam.OutMember)
                    {
                        _f.OppentOutTeamListBox.Items.Add(p);
                    }

                    _f.OppentOutTeamListBox.Enabled = true;
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
