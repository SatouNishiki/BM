﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExchangeListBox;

namespace BasketballManagementSystem.BMForm.Input.EventHelper
{
    public class KeyboardEventHelper
    {
        private bool fastFowardFlagPushed = false;
        private bool rewindFlagPushed = false;

        public void KeyDownEvent(FormInput form, KeyEventArgs key)
        {
            //修飾キーが押されていない時
            if (!IsModifiersKeyPush(key))
            {

                switch (key.KeyData)
                {
                    case Keys.Right:
                        form.QuarterTimer.fastFowardFlag = true;
                        fastFowardFlagPushed = true;
                        break;

                    case Keys.Left:
                        form.QuarterTimer.rewindFlag = true;
                        rewindFlagPushed = true;
                        break;

                    case Keys.Space:
                        form.QuarterTimerStopButton.PerformClick();
                        break;

                    case Keys.D1:
                        SelectedIndexChange(form.MyCortTeamListBox, 0);
                        break;

                    case Keys.D2:
                        SelectedIndexChange(form.MyCortTeamListBox, 1);
                        break;

                    case Keys.D3:
                        SelectedIndexChange(form.MyCortTeamListBox, 2);
                        break;

                    case Keys.D4:
                        SelectedIndexChange(form.MyCortTeamListBox, 3);
                        break;

                    case Keys.D5:
                        SelectedIndexChange(form.MyCortTeamListBox, 4);
                        break;

                    case Keys.D6:
                        SelectedIndexChange(form.MyCortTeamListBox, 5);
                        break;

                    case Keys.D7:
                        SelectedIndexChange(form.MyCortTeamListBox, 6);
                        break;

                    case Keys.D8:
                        SelectedIndexChange(form.MyCortTeamListBox, 7);
                        break;

                    case Keys.D9:
                        SelectedIndexChange(form.MyCortTeamListBox, 8);
                        break;

                    case Keys.D0:
                        SelectedIndexChange(form.MyCortTeamListBox, 9);
                        break;
                }

            }
            else
            {
                //Ctrlキーが押されているとき
                if (IsCtrlKeyPush(key))
                {
                    switch (key.KeyCode)
                    {
                        case Keys.Z:
                            form.UndoToolStripButton.PerformClick();
                            break;

                        case Keys.Y:
                            form.RedoToolStripButton.PerformClick();
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// 修飾キーが押されているかを確認する
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private bool IsModifiersKeyPush(KeyEventArgs key)
        {
            return IsShiftKeyPush(key) || IsCtrlKeyPush(key) || IsAltKeyPush(key);
        }

        /// <summary>
        /// シフトキーが押されているかを確認する
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private bool IsShiftKeyPush(KeyEventArgs key)
        {
            return (key.Modifiers & Keys.Shift) == Keys.Shift;
        }

        /// <summary>
        /// Ctrlキーが押されているかを確認する
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private bool IsCtrlKeyPush(KeyEventArgs key)
        {
            return (key.Modifiers & Keys.Control) == Keys.Control;
        }

        private bool IsAltKeyPush(KeyEventArgs key)
        {
            return (key.Modifiers & Keys.Alt) == Keys.Alt;
        }

        public void KeyUpEvent(FormInput form)
        {
            if(fastFowardFlagPushed)
            form.QuarterTimer.rewindFlag = false;

            if(rewindFlagPushed)
            form.QuarterTimer.fastFowardFlag = false;
        }

        private bool CanListMemberSelect(ListBox listbox, int selectNumber)
        {
            return listbox.Items.Count > selectNumber;
        }

        private void SelectedIndexChange(ExChangeList listbox, int selectNumber)
        {
            if (CanListMemberSelect(listbox, selectNumber))
            {
                listbox.PerformIndexClick(selectNumber);
            }
        }
    }
}