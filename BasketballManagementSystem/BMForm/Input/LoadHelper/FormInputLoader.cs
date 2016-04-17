using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasketballManagementSystem.baseClass.game;
using BasketballManagementSystem.baseClass.player;
using BasketballManagementSystem.manager;

namespace BasketballManagementSystem.bmForm.input.loadHelper
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

        delegate void SetListBoxDelegate(FormInputView f, Game game);

        public void LoadForm(FormInputModel fModel, FormInputView fView, Game game)
        {
            fModel.Game = game;
            SaveDataManager.GetInstance().SetGame(game);


            //別スレッドからコントロールを操作するための努力
            if (fView.MyCortTeamListBox.InvokeRequired)
            {
                SetListBoxDelegate sbd = (fi, g) =>
                {
                    fi.MyCortTeamListBox.Enabled = false;

                    fi.MyCortTeamListBox.Items.Clear();
                    foreach (Player p in g.MyTeam.CortMember)
                    {
                        fi.MyCortTeamListBox.Items.Add(p);
                    }

                    SelectedIndexClick(fi);
                    fi.MyCortTeamListBox.Enabled = true;


                    fi.MyOutTeamListBox.Enabled = false;

                    fi.MyOutTeamListBox.Items.Clear();
                    foreach (Player p in g.MyTeam.OutMember)
                    {
                        fi.MyOutTeamListBox.Items.Add(p);
                    }
                    SelectedIndexClick(fi);
                    fi.MyOutTeamListBox.Enabled = true;

                    fi.OppentCortTeamListBox.Enabled = false;

                    fi.OppentCortTeamListBox.Items.Clear();
                    foreach (Player p in g.OppentTeam.CortMember)
                    {
                        fi.OppentCortTeamListBox.Items.Add(p);
                    }

                    SelectedIndexClick(fi);
                    fi.OppentCortTeamListBox.Enabled = true;

                    fi.OppentOutTeamListBox.Enabled = false;

                    fi.OppentOutTeamListBox.Items.Clear();
                    foreach (Player p in g.OppentTeam.OutMember)
                    {
                        fi.OppentOutTeamListBox.Items.Add(p);
                    }

                    SelectedIndexClick(fi);
                    fi.OppentOutTeamListBox.Enabled = true;

                    fi.SortAllMemberList();
                };

                fView.Invoke(sbd, new object[] { fView, game });
            }
            else
            {
                fView.MyCortTeamListBox.Enabled = false;

                
                fView.MyCortTeamListBox.Items.Clear();
                foreach (Player p in game.MyTeam.CortMember)
                {
                    fView.MyCortTeamListBox.Items.Add(p);
                }

                SelectedIndexClick(fView);
                fView.MyCortTeamListBox.Enabled = true;


                fView.MyOutTeamListBox.Enabled = false;

                fView.MyOutTeamListBox.Items.Clear();
                foreach (Player p in game.MyTeam.OutMember)
                {
                    fView.MyOutTeamListBox.Items.Add(p);
                }

                SelectedIndexClick(fView);
                fView.MyOutTeamListBox.Enabled = true;


                fView.OppentCortTeamListBox.Enabled = false;

                fView.OppentCortTeamListBox.Items.Clear();
                foreach (Player p in game.OppentTeam.CortMember)
                {
                    fView.OppentCortTeamListBox.Items.Add(p);
                }

                SelectedIndexClick(fView);
                fView.OppentCortTeamListBox.Enabled = true;


                fView.OppentOutTeamListBox.Enabled = false;

                fView.OppentOutTeamListBox.Items.Clear();
                foreach (Player p in game.OppentTeam.OutMember)
                {
                    fView.OppentOutTeamListBox.Items.Add(p);
                }

                SelectedIndexClick(fView);
                fView.OppentOutTeamListBox.Enabled = true;

                fView.SortAllMemberList();
            }
        }

        /// <summary>
        /// ロードイベント後にselectedIndexの再設定をはさむためのメソッド
        /// </summary>
        /// <param name="f"></param>
        private void SelectedIndexClick(FormInputView f)
        {
            int index = f.MyCortTeamListBox.Items.IndexOf(f.SelectedPlayer);
            f.MyCortTeamListBox.PerformIndexClick(index);
        }
    }
}
