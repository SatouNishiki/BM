﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasketballManagementSystem.baseClass.player;
using System.Windows.Forms;

namespace BasketballManagementSystem.bmForm.input.eventHelper
{
    //TODO: フラグが結構ごちゃごちゃしてる
    public class MemberChangeEventHelper
    {
        public bool IsEasyChangeMode { get; set; }

        private List<bool> enableList = new List<bool>();

        public void ChangeMember(FormInputView form)
        {
            if (form.MyCortTeamListBox.SelectedItems.Count == 0
                && form.OppentOutTeamListBox.SelectedItems.Count == 0
                && form.MyOutTeamListBox.SelectedItems.Count == 0
                && form.OppentCortTeamListBox.SelectedItems.Count == 0
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
                form.StackGameData();

                MemberChange m = new MemberChange();

                foreach (Player p in obj1)
                {
                    m.ChangedCortMembers.Add(p);

                    form.MyTeam.CortMember.Remove(p);
                    form.MyTeam.OutMember.Add(p);
                }

                foreach (Player p in obj2)
                {
                    m.ChangedOutMembers.Add(p);
                    form.MyTeam.OutMember.Remove(p);
                    form.MyTeam.CortMember.Add(p);
                }

               
                m.ChengedMemberTime = DateTime.Now;
                m.RemainingTime = form.QuarterTimer.remainingTime;
                m.Quarter = form.Quarter;
                form.Game.MyTeam.MemberChange.Add(m);
            }

            obj1.Clear();
            obj2.Clear();

            foreach (object o in form.OppentCortTeamListBox.SelectedItems) obj1.Add(o);
            foreach (object o in form.OppentOutTeamListBox.SelectedItems) obj2.Add(o);

            if (form.OppentCortTeamListBox.ExchangeSelectedItem(form.OppentOutTeamListBox))
            {

                form.StackGameData();
                MemberChange m = new MemberChange();

                foreach (Player p in obj1)
                {
                    m.ChangedCortMembers.Add(p);
                    form.OppentTeam.CortMember.Remove(p);
                    form.OppentTeam.OutMember.Add(p);
                }

                foreach (Player p in obj2)
                {
                    m.ChangedOutMembers.Add(p);
                    form.OppentTeam.OutMember.Remove(p);
                    form.OppentTeam.CortMember.Add(p);
                }

                m.ChengedMemberTime = DateTime.Now;
                m.RemainingTime = form.QuarterTimer.remainingTime;
                m.Quarter = form.Quarter;
                form.Game.OppentTeam.MemberChange.Add(m);
            }

            if (IsEasyChangeMode)
            {
                IsEasyChangeMode = false;
                SetEasyChangeMode(form, IsEasyChangeMode);
            }
        }

        private void SetEasyChangeMode(FormInputView form, bool mode)
        {

            form.MyCortTeamListBox.IsEasyMemberChangeMode = mode;
            form.OppentOutTeamListBox.IsEasyMemberChangeMode = mode;
            form.MyOutTeamListBox.IsEasyMemberChangeMode = mode;
            form.OppentCortTeamListBox.IsEasyMemberChangeMode = mode;

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
                        && c2.Name != form.OppentCortTeamListBox.Name
                        && c2.Name != form.MyMemberChangeButton.Name
                        && c2.Name != form.OppentMemberChangeButton.Name)
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
                        && c.Name != form.OppentCortTeamListBox.Name
                        && c.Name != form.MyMemberChangeButton.Name
                        && c.Name != form.OppentMemberChangeButton.Name)
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
                        && c2.Name != form.OppentCortTeamListBox.Name
                        && c2.Name != form.MyMemberChangeButton.Name
                        && c2.Name != form.OppentMemberChangeButton.Name)
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
                        && c.Name != form.OppentCortTeamListBox.Name
                        && c.Name != form.MyMemberChangeButton.Name
                        && c.Name != form.OppentMemberChangeButton.Name)
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
