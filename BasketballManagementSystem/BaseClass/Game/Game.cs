using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasketballManagementSystem.BaseClass.Player;
using System.Xml.Serialization;
using BasketballManagementSystem.BaseClass.TimeOut;
using Utility;

namespace BasketballManagementSystem.BaseClass.Game
{
    /// <summary>
    /// BMのデータを集約する全ゲームデータのクラス
    /// </summary>
    [Serializable]
    public class Game
    {
        /// <summary>
        /// 自分のチーム
        /// </summary>
        public Team MyTeam { get; set; }

        /// <summary>
        /// 相手チーム
        /// </summary>
        public Team OppentTeam { get; set; }

        /// <summary>
        /// 試合開始時間
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 試合終了時間
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// 試合の名前
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 試合が行われた場所
        /// </summary>
        public string Location { get; set; }


        public Game()
        {
            MyTeam = new Team();
            OppentTeam = new Team();
            StartTime = new DateTime();
            Name = "Game1";
            Location = "NoInputLocation";
        }

        /// <summary>
        /// ゲームオブジェクト同士の比較用関数
        /// </summary>
        /// <param name="obj">ゲームデータオブジェクト</param>
        /// <returns>this == obj ? true : false</returns>
        public override bool Equals(object obj)
        {
            //objがnullか、型が違うときは、等価でない
            if (obj == null || this.GetType() != obj.GetType())
            {
                return false;
            }

            Game _g = (Game)obj;

            if (this.Location != _g.Location) return false;
            if (this.Name != _g.Name) return false;
            if (this.StartTime.Millisecond != _g.StartTime.Millisecond) return false;
            if (this.MyTeam.CortMember.Count != _g.MyTeam.CortMember.Count) return false;
            if (this.MyTeam.OutMember.Count != _g.MyTeam.OutMember.Count) return false;
            if (this.OppentTeam.CortMember.Count != _g.OppentTeam.CortMember.Count) return false;
            if (this.OppentTeam.OutMember.Count != _g.OppentTeam.OutMember.Count) return false;
            if (this.MyTeam.TimeOutList.Count != _g.MyTeam.TimeOutList.Count) return false;
            if (this.OppentTeam.TimeOutList.Count != _g.OppentTeam.TimeOutList.Count) return false;
            if (this.MyTeam.MemberChange.Count != _g.MyTeam.MemberChange.Count) return false;
            if (this.OppentTeam.MemberChange.Count != _g.OppentTeam.MemberChange.Count) return false;

            for (int _i = 0; _i < this.MyTeam.TeamMember.Count; _i++)
            {
                List<Action.Action> _l = this.MyTeam.TeamMember[_i].GetActionList(this.MyTeam.TeamMember[_i]);
                List<Action.Action> _l2 = _g.MyTeam.TeamMember[_i].GetActionList(_g.MyTeam.TeamMember[_i]);

                if (this.MyTeam.TeamMember[_i].GetActionList(this.MyTeam.TeamMember[_i]).Count
                    != _g.MyTeam.TeamMember[_i].GetActionList(_g.MyTeam.TeamMember[_i]).Count)
                    return false;
            }

            for (int _i = 0; _i < this.OppentTeam.TeamMember.Count; _i++)
            {
                if (this.OppentTeam.TeamMember[_i].GetActionList(this.OppentTeam.TeamMember[_i]).Count 
                    != _g.OppentTeam.TeamMember[_i].GetActionList(_g.OppentTeam.TeamMember[_i]).Count)
                    return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// ゲームデータオブジェクトのディープコピーを作成する
        /// </summary>
        /// <returns>ディープコピー</returns>
        public Game CloneDeep()
        {
            return Util.CloneDeep<Game>(this);
        }

    }
}
