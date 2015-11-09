using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BasketballManagementSystem.baseClass.club;
using BMFileLibrary;
using System.Xml.Serialization;
using BMErrorLibrary;
using BasketballManagementSystem.interfaces.clubEdit;

namespace BasketballManagementSystem.bmForm.clubEdit
{
    public partial class FormClubEditView : Form, IClubEditView
    {
        /// <summary>
        /// trueのとき保存されていない変更がある
        /// </summary>
        public bool ChangeFlag { get; set; }

        public event Action LoadClubTeamClickEvent;
        public event Action<ClubTeam> SaveClubTeamClickEvent;
        public event Action AddButtonClickEvent;
        public event Action<ClubMember> SelectedClubMemberChangedEvent;
        public event Action ClubMemberEditDicisionEvent;
        public event Action FormClosingEvent;
        public event Action DeleteButtonClickEvent;
        public event events.DataInputEventHandler DataInputEvent;

        private void DataChangeEventThrow(string name, object value)
        {
            if (this.DataInputEvent != null)
            {
                this.DataInputEvent(this, new events.DataInputEventArgs(name, value));
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


        public FormClubEditView()
        {
            InitializeComponent();
            this.ChangeFlag = false;
        }

        /// <summary>
        /// ClubTeamオブジェクトを表示に反映します
        /// </summary>
        /// <param name="clubTeam"></param>
        public void ShowClubTeamData(ClubTeam clubTeam)
        {
            ClubNameTextBox.Text = clubTeam.Name;

            ClubMembersListBox.Items.Clear();
            foreach (ClubMember clubMember in clubTeam.ClubMemberList)
            {
                ClubMembersListBox.Items.Add(clubMember);
            }

            ChangeFlag = false;
        }

        /// <summary>
        /// 表示情報からClubTeamオブジェクトを作成します
        /// </summary>
        /// <returns></returns>
        public ClubTeam CreateClubTeamData()
        {

            if (ClubNameTextBox.Text == string.Empty)
            {
                MessageBox.Show("Clubの名前を入力してください");
                return null;
            }


            ClubTeam clubTeam = new ClubTeam();

            clubTeam.Name = ClubNameTextBox.Text;

            foreach (ClubMember clubMember in ClubMembersListBox.Items)
            {
                clubTeam.ClubMemberList.Add(clubMember);
            }

            return clubTeam;
        }

        public DialogResult ShowOkCancelMessageBox(string message, string caption)
        {
            DialogResult d = MessageBox.Show(message,
                                caption,
                                MessageBoxButtons.OKCancel,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button2);

            return d;
        }

        private void LoadClubTeamClickEventThrow()
        {
            if (this.LoadClubTeamClickEvent != null)
            {
                this.LoadClubTeamClickEvent();
            }
        }

        private void SaveClubTeamClickEventThrow(ClubTeam team)
        {
            if (this.SaveClubTeamClickEvent != null)
            {
                this.SaveClubTeamClickEvent(team);
            }
        }

        private void AddButtonClickEventThrow()
        {
            if (this.AddButtonClickEvent != null)
            {
                this.AddButtonClickEvent();
            }
        }

        private void SelectedClubMemberChangedEventThrow(ClubMember member)
        {
            if (this.SelectedClubMemberChangedEvent != null)
            {
                this.SelectedClubMemberChangedEvent(member);
            }
        }

        private void ClubMemberEditDicisionEventThrow()
        {
            if (this.ClubMemberEditDicisionEvent != null)
            {
                this.ClubMemberEditDicisionEvent();
            }
        }

        private void FormClosingEventThrow()
        {
            if (this.FormClosingEvent != null)
            {
                this.FormClosingEvent();
            }
        }

        private void DeleteButtonClickEventThrow()
        {
            if (this.DeleteButtonClickEvent != null)
            {
                this.DeleteButtonClickEvent();
            }
        }

        private void LoadClubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LoadClubTeamClickEventThrow();

      //      ClubTeam clubMembers = (ClubTeam)this.Presenter.GetModelProperty("ClubMembers");

//            this.ShowClubTeamData(clubMembers);

        }

        private void SaveClubToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ClubTeam clubTeam = this.CreateClubTeamData();

            if (clubTeam == null)
                return;

            this.SaveClubTeamClickEventThrow(clubTeam);

            ChangeFlag = false;

        }

        public string GetAddNameText()
        {
            return this.NameAddTextBox.Text;
        }

        public string GetAddHeightText()
        {
            return this.HeightAddTextBox.Text;
        }

        public string GetAddWeightText()
        {
            return this.WeightAddTextBox.Text;
        }

        public bool GetAddSexCheck()
        {
            return ManAddRadioButton.Checked;
        }

        public string GetSelectedNameText()
        {
            return this.NameSelectedTextBox.Text;
        }

        public string GetSelectedHeightText()
        {
            return this.HeightSelectedTextBox.Text;
        }

        public string GetSelectedWeightText()
        {
            return this.WeightSelectedTextBox.Text;
        }

        public bool GetSelectedSexCheck()
        {
            return this.ManSelectedRadioButton.Checked;
        }

        public void ClearAddNameTextBox()
        {
            this.NameAddTextBox.Clear();
        }

        public void ClearAddWeightTextBox()
        {
            this.WeightAddTextBox.Clear();
        }

        public void ClearAddHeightTextBox()
        {
            this.HeightAddTextBox.Clear();
        }

        public void ClearSelectedNameTextBox()
        {
            this.NameSelectedTextBox.Clear();
        }

        public void ClearSelectedHeightTextBox()
        {
            this.HeightSelectedTextBox.Clear();
        }

        public void ClearSelectedWeightTextBox()
        {
            this.WeightSelectedTextBox.Clear();
        }


        public void ShowClubMemberList(List<ClubMember> members)
        {
            this.ClubMembersListBox.Items.Clear();

            foreach (var m in members)
            {
                this.ClubMembersListBox.Items.Add(m);
            }
        }

        public void ShowSelectedClubMemberData(ClubMember selectedClubMember)
        {
            NameSelectedTextBox.Text = selectedClubMember.Name;

            if (selectedClubMember.IsMan)
                ManSelectedRadioButton.Checked = true;
            else
                WomanSelectedRadioButton.Checked = true;

            HeightSelectedTextBox.Text = selectedClubMember.Height.ToString();
            WeightSelectedTextBox.Text = selectedClubMember.Weight.ToString();
        }

        public void ChangeToSelectedMember(ClubMember member, int index)
        {
            ClubMembersListBox.Items[index] = member;
        }


        public int GetSelectedIndex()
        {
            return this.ClubMembersListBox.SelectedIndex;
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        public void RemoveAtClubMember(int index)
        {
            this.ClubMembersListBox.Items.RemoveAt(index);
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            this.AddButtonClickEventThrow();
            ChangeFlag = true;
        }

        private void ClubMembersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ClubMembersListBox.SelectedItem == null) return;

            this.SelectedClubMemberChangedEventThrow((ClubMember)ClubMembersListBox.SelectedItem);
        }

        private void DicisionButton_Click(object sender, EventArgs e)
        {

            this.ClubMemberEditDicisionEventThrow();
         
            this.ChangeFlag = true;
        }

        

        private void FormClubEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.FormClosingEventThrow();

            if (!(bool)this.presenter.GetModelProperty("CanFinish"))
            {
                e.Cancel = true;
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            this.DeleteButtonClickEventThrow();
        }


    }
}
