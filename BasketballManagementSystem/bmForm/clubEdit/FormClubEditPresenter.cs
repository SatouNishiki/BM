using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasketballManagementSystem.abstracts;
using BasketballManagementSystem.baseClass.club;
using System.Windows.Forms;

namespace BasketballManagementSystem.bmForm.clubEdit
{
    public class FormClubEditPresenter : AbstractPresenter
    {
        private FormClubEditView formView;
        private FormClubEditModel formModel;

        public FormClubEditPresenter(FormClubEditModel model, FormClubEditView view)
            : base(view, model)
        {
            this.formModel = model;
            this.formView = view;

            this.formView.LoadClubTeamClickEvent += formView_LoadClubTeamClickEvent;
            this.formView.SaveClubTeamClickEvent += formView_SaveClubTeamClickEvent;
            this.formView.AddButtonClickEvent += formView_AddButtonClickEvent;
            this.formView.SelectedClubMemberChangedEvent += formView_SelectedClubMemberChangedEvent;
            this.formView.ClubMemberEditDicisionEvent += formView_ClubMemberEditDicisionEvent;
            this.formView.FormClosingEvent += formView_FormClosingEvent;
            this.formView.DeleteButtonClickEvent += formView_DeleteButtonClickEvent;
        }

        void formView_DeleteButtonClickEvent()
        {
            if (this.formView.GetSelectedIndex() < 0)
            {
                this.formView.ShowMessage("メンバーが選択されていません");
                return;
            }

            DialogResult d = this.formView.ShowOkCancelMessageBox("本当に削除してよろしいでしょうか?", "確認");

            if(d == DialogResult.OK)
            {
                this.formView.RemoveAtClubMember(this.formView.GetSelectedIndex());
                this.formView.ClearSelectedHeightTextBox();
                this.formView.ClearSelectedNameTextBox();
                this.formView.ClearSelectedWeightTextBox();
            }
        }

        void formView_FormClosingEvent()
        {
            if (this.formView.ChangeFlag)
            {
                DialogResult d = this.formView.ShowOkCancelMessageBox("保存されていない変更がありますがよろしいですか?", "確認");

                if (d == DialogResult.Cancel)
                {
                    this.formModel.CanFinish = false;
                }
                else
                {
                    this.formModel.CanFinish = true;
                }
            }
        }

        void formView_ClubMemberEditDicisionEvent()
        {
            ClubMember clubMember = new ClubMember();
            double height = 0.0D;
            double weight = 0.0D;

            if (this.formView.GetSelectedNameText() == string.Empty)
            {
                this.formView.ShowMessage("名前が未入力です");
                return;
            }

            if (this.formView.GetSelectedHeightText() != string.Empty)
            {
                if (!double.TryParse(this.formView.GetSelectedHeightText(), out height))
                {
                    this.formView.ShowMessage("値が不正です");
                    return;
                }
            }

            if (this.formView.GetSelectedWeightText()!= string.Empty)
            {
                if (!double.TryParse(this.formView.GetSelectedWeightText(), out weight))
                {
                    this.formView.ShowMessage("値が不正です");
                    return;
                }
            }

            clubMember.Name = this.formView.GetSelectedNameText();
            clubMember.Height = height;
            clubMember.Weight = weight;

            clubMember.IsMan = this.formView.GetSelectedSexCheck();

            int index = this.formView.GetSelectedIndex();

            if (index >= 0)
            {
                this.formView.ChangeToSelectedMember(clubMember, index);
            }

            this.formView.ClearSelectedHeightTextBox();
            this.formView.ClearSelectedNameTextBox();
            this.formView.ClearSelectedWeightTextBox();


        }

        void formView_SelectedClubMemberChangedEvent(ClubMember obj)
        {
            this.formView.ShowSelectedClubMemberData(obj);
        }

        void formView_AddButtonClickEvent()
        {
            ClubMember clubMember = new ClubMember();
            double height = 0.0D;
            double weight = 0.0D;

            if (this.formView.GetAddNameText() == string.Empty)
            {
                this.formView.ShowMessage("名前が未入力です");
                return;
            }

            if (this.formView.GetAddHeightText() != string.Empty)
            {
                if (!double.TryParse(this.formView.GetAddHeightText(), out height))
                {
                    this.formView.ShowMessage("値が不正です");
                    return;
                }
            }

            if (this.formView.GetAddWeightText() != string.Empty)
            {
                if (!double.TryParse(this.formView.GetAddWeightText(), out weight))
                {
                    this.formView.ShowMessage("値が不正です");
                    return;
                }
            }

            clubMember.Name = this.formView.GetAddNameText();
            clubMember.Height = height;
            clubMember.Weight = weight;

            clubMember.IsMan = this.formView.GetAddSexCheck();

            this.formModel.ClubMembers.Add(clubMember);

            this.formView.ShowClubMemberList(formModel.ClubMembers);

            this.formView.ClearAddHeightTextBox();
            this.formView.ClearAddNameTextBox();
            this.formView.ClearAddWeightTextBox();
        }

        void formView_SaveClubTeamClickEvent(baseClass.club.ClubTeam obj)
        {
            this.formModel.SaveClubTeam(obj);
        }

        void formView_LoadClubTeamClickEvent()
        {
            ClubTeam team = this.formModel.LoadClubTeam();

            if (team != null)
                this.formView.ShowClubTeamData(team);
        }

        public override void ShowView()
        {
            this.formView.Show();
        }

        public override Form GetForm()
        {
            return this.formView;
        }
    }
}
