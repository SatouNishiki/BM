using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasketballManagementSystem.events.input
{
    /// <summary>
    /// 入力画面のチーム変更イベント
    /// </summary>
    public class TeamChangeEventArgs : EventArgs
    {
        public enum TeamType
        {
            MyTeam, OppentTeam
        }

        private ListBox cortMemberListBox;
        private ListBox outMemberListBox;
        private TeamType type;

        public ListBox CortMemberListBox
        {
            get { return this.cortMemberListBox; }
            set { this.cortMemberListBox = value; }
        }

        public ListBox OutMemberListBox
        {
            get { return this.outMemberListBox; }
            set { this.outMemberListBox = value; }
        }

        public TeamType Type
        {
            get { return this.type; }
            set { this.type = value; }
        }

        public TeamChangeEventArgs(ListBox cortList, ListBox outList, TeamType type)
        {
            this.CortMemberListBox = cortList;
            this.OutMemberListBox = outList;
            this.Type = type;
        }
    }

    
}
