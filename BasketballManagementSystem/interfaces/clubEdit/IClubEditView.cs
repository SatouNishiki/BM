using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasketballManagementSystem.baseClass.club;
using System.Windows.Forms;

namespace BasketballManagementSystem.interfaces.clubEdit
{
    public interface IClubEditView : IView
    {
        event Action LoadClubTeamClickEvent;
        event Action<ClubTeam> SaveClubTeamClickEvent;
        event Action AddButtonClickEvent;
        event Action<ClubMember> SelectedClubMemberChangedEvent;
        event Action ClubMemberEditDicisionEvent;
        event Action FormClosingEvent;
        event Action DeleteButtonClickEvent;

        /// <summary>
        /// ClubTeamオブジェクトを表示に反映します
        /// </summary>
        /// <param name="clubTeam"></param>
        void ShowClubTeamData(ClubTeam clubTeam);

        DialogResult ShowOkCancelMessageBox(string message, string caption);

        /// <summary>
        /// 表示情報からClubTeamオブジェクトを作成します
        /// </summary>
        /// <returns></returns>
        ClubTeam CreateClubTeamData();

        void ShowMessage(string message);

        void RemoveAtClubMember(int index);

        /// <summary>
        /// ClubMemberオブジェクトを選択ClubMemberオブジェクト欄に表示します
        /// </summary>
        /// <param name="selectedClubMember"></param>
        void ShowSelectedClubMemberData(ClubMember selectedClubMember);

        void ShowClubMemberList(List<ClubMember> members);

        /// <summary>
        /// index番号で指定された選手をClubMemberオブジェクトに交換します
        /// </summary>
        /// <param name="member"></param>
        /// <param name="index"></param>
        void ChangeToSelectedMember(ClubMember member, int index);

        /// <summary>
        /// listboxの選択インデックスを返します
        /// </summary>
        /// <returns></returns>
        int GetSelectedIndex();

        string GetAddNameText();
        string GetAddHeightText();
        string GetAddWeightText();
        bool GetAddSexCheck();

        string GetSelectedNameText();
        string GetSelectedHeightText();
        string GetSelectedWeightText();
        bool GetSelectedSexCheck();

        void ClearAddNameTextBox();
        void ClearAddWeightTextBox();
        void ClearAddHeightTextBox();

        void ClearSelectedNameTextBox();
        void ClearSelectedHeightTextBox();
        void ClearSelectedWeightTextBox();


    }
}
