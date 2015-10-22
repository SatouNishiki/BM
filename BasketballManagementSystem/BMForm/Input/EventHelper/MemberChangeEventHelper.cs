using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasketballManagementSystem.BaseClass.player;
using System.Windows.Forms;

namespace BasketballManagementSystem.BMForm.input.eventHelper
{
    //TODO: フラグが結構ごちゃごちゃしてる
    public class MemberChangeEventHelper
    {
        public bool IsEasyChangeMode { get; set; }

        private List<bool> enableList = new List<bool>();

        public void ChangeMember(FormInput form)
        {
            if (form.MyCortTeamListBox.SelectedItems.Count == 0
                && form.OppentOutTeamListBox.SelectedItems.Count == 0
                && form.MyOutTeamListBox.SelectedItems.Count == 0
                && form.OppentOutTeamListBox.SelectedItems.Count == 0
                && !IsEasyChangeMode)
            {
                IsEasyChangeMode = true;
                SetEasyChangeMode(form, IsEasyChangeMode);

                return;
            }


            List<object> obj1 = new List<object>();
            List<object> obj2 = new List<object>();

            foreach (var o in form.MyCortTeamListBox.SelectedItems) obj1.Add(o);
            foreach (var o in form.MyOutTeamListBox.SelectedItems) obj2.Add(o);

            if (form.MyCortTeamListBox.ExchangeSelectedItem(form.MyOutTeamListBox))
            {
                MemberChange m = new MemberChange();

                foreach (Player p in obj1)
                {
                    m.ChangedCortMembers.Add(p);
                }

                foreach (Player p in obj2)
                {
                    m.ChangedOutMembers.Add(p);
                }

                m.ChengedMemberTime = DateTime.Now;
                m.RemainingTime = form.QuarterTimer.remainingTime;
                m.Quarter = form.Quarter;
                form.StackGameData();
                form.Game.MyTeam.MemberChange.Add(m);
            }

            obj1.Clear();
            obj2.Clear();

            foreach (object o in form.OppentCortTeamListBox.SelectedItems) obj1.Add(o);
            foreach (object o in form.OppentOutTeamListBox.SelectedItems) obj2.Add(o);

            if (form.OppentCortTeamListBox.ExchangeSelectedItem(form.OppentOutTeamListBox))
            {
                MemberChange m = new MemberChange();

                foreach (Player p in obj1)
                {
                    m.ChangedCortMembers.Add(p);
                }

                foreach (Player p in obj2)
                {
                    m.ChangedOutMembers.Add(p);
                }

                m.ChengedMemberTime = DateTime.Now;
                m.RemainingTime = form.QuarterTimer.remainingTime;
                m.Quarter = form.Quarter;
                form.StackGameData();
                form.Game.OppentTeam.MemberChange.Add(m);
            }

            if (IsEasyChangeMode)
            {
                IsEasyChangeMode = false;
                SetEasyChangeMode(form, IsEasyChangeMode);
            }
        }

        private void SetEasyChangeMode(FormInput form, bool mode)
        {

            form.MyCortTeamListBox.IsEasyMemberChangeMode = mode;
            form.OppentOutTeamListBox.IsEasyMemberChangeMode = mode;
            form.MyOutTeamListBox.IsEasyMemberChangeMode = mode;
            form.MyOutTeamListBox.IsEasyMemberChangeMode = mode;

            if (mode)
            {
                bool continueFlag = false;

                foreach (Control c in form.Controls)
                {

                    foreach (Control c2 in c.Controls)
                    {

                        if (c2.Name != form.MyCortTeamListBox.Name
                        && c2.Name != form.OppentOutTeamListBox.Name
                        && c2.Name != form.MyOutTeamListBox.Name
                        && c2.Name != form.MyOutTeamListBox.Name
                        && c2.Name != form.MemberChangeButton.Name)
                        {
                            enableList.Add(c.Enabled);
                            c2.Enabled = false;
                            continueFlag = true;
                        }

                    }

                    if (continueFlag)
                    {
                        continueFlag = false;
                        enableList.Add(c.Enabled);
                        continue;
                    }

                    if (c.Name != form.MyCortTeamListBox.Name
                        && c.Name != form.OppentOutTeamListBox.Name
                        && c.Name != form.MyOutTeamListBox.Name
                        && c.Name != form.MyOutTeamListBox.Name
                        && c.Name != form.MemberChangeButton.Name)
                    {
                        enableList.Add(c.Enabled);
                        c.Enabled = false;
                    }

                }
            }
            else
            {
                bool continueFlag = false;
                int i = 0;

                foreach (Control c in form.Controls)
                {
                    foreach (Control c2 in c.Controls)
                    {

                        if (c2.Name != form.MyCortTeamListBox.Name
                        && c2.Name != form.OppentOutTeamListBox.Name
                        && c2.Name != form.MyOutTeamListBox.Name
                        && c2.Name != form.MyOutTeamListBox.Name
                        && c2.Name != form.MemberChangeButton.Name)
                        {
                            continueFlag = true;
                            c2.Enabled = enableList[i];
                        }

                    }

                    if (continueFlag)
                    {
                        continueFlag = false;
                        c.Enabled = enableList[i];
                        i++;
                        continue;
                    }

                    if (c.Name != form.MyCortTeamListBox.Name
                        && c.Name != form.OppentOutTeamListBox.Name
                        && c.Name != form.MyOutTeamListBox.Name
                        && c.Name != form.MyOutTeamListBox.Name
                        && c.Name != form.MemberChangeButton.Name)
                    {
                        c.Enabled = enableList[i];
                        i++;
                    }
                }

                enableList.Clear();
            }
        }

    }
}
