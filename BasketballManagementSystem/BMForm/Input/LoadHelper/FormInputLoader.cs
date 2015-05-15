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
            /*
            if (f.GameNameText.Text != game.name)
                f.GameNameText.Text = game.name;
            

            if (f.GameLocationText.Text != game.location)
            f.GameLocationText.Text = game.location;
            */

            f.Game = game;
            SaveDataManager.GetInstance().SetGame(game);

            //別スレッドからコントロールを操作するための努力
            if (f.MyCortTeam.InvokeRequired)
            {
                SetListBoxDelegate sbd = (_f, _g) =>
                {
                    _f.MyCortTeam.Enabled = false;

                    _f.MyCortTeam.Items.Clear();
                    foreach (Player p in _g.MyTeam.CortMember)
                    {
                        _f.MyCortTeam.Items.Add(p);
                    }

                    _f.MyCortTeam.Enabled = true;



                    _f.MyOutTeam.Enabled = false;

                    _f.MyOutTeam.Items.Clear();
                    foreach (Player p in _g.MyTeam.OutMember)
                    {
                        _f.MyOutTeam.Items.Add(p);
                    }

                    _f.MyOutTeam.Enabled = true;
                    _f.OppentCortTeam.Enabled = false;

                    _f.OppentCortTeam.Items.Clear();
                    foreach (Player p in _g.OppentTeam.CortMember)
                    {
                        _f.OppentCortTeam.Items.Add(p);
                    }

                    _f.OppentCortTeam.Enabled = true;
                    _f.OppentOutTeam.Enabled = false;

                    _f.OppentOutTeam.Items.Clear();
                    foreach (Player p in _g.OppentTeam.OutMember)
                    {
                        _f.OppentOutTeam.Items.Add(p);
                    }

                    _f.OppentOutTeam.Enabled = true;
                };

                f.Invoke(sbd, new object[] { f, game });
            }
            else
            {
                f.MyCortTeam.Enabled = false;

                f.MyCortTeam.Items.Clear();
                foreach (Player p in game.MyTeam.CortMember)
                {
                    f.MyCortTeam.Items.Add(p);
                }

                f.MyCortTeam.Enabled = true;



                f.MyOutTeam.Enabled = false;

                f.MyOutTeam.Items.Clear();
                foreach (Player p in game.MyTeam.OutMember)
                {
                    f.MyOutTeam.Items.Add(p);
                }

                f.MyOutTeam.Enabled = true;
                f.OppentCortTeam.Enabled = false;

                f.OppentCortTeam.Items.Clear();
                foreach (Player p in game.OppentTeam.CortMember)
                {
                    f.OppentCortTeam.Items.Add(p);
                }

                f.OppentCortTeam.Enabled = true;
                f.OppentOutTeam.Enabled = false;

                f.OppentOutTeam.Items.Clear();
                foreach (Player p in game.OppentTeam.OutMember)
                {
                    f.OppentOutTeam.Items.Add(p);
                }

                f.OppentOutTeam.Enabled = true;
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
