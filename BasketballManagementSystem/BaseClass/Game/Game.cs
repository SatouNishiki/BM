using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasketballManagementSystem.BaseClass.Player;
using System.Xml.Serialization;
using BasketballManagementSystem.BaseClass.TimeOut;
using Utility;
using BasketballManagementSystem.BaseClass.Action;

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

            Game game = (Game)obj;

            if (this.Location != game.Location) return false;
            if (this.Name != game.Name) return false;
            if (this.StartTime.Millisecond != game.StartTime.Millisecond) return false;
            if (this.MyTeam.CortMember.Count != game.MyTeam.CortMember.Count) return false;
            if (this.MyTeam.OutMember.Count != game.MyTeam.OutMember.Count) return false;
            if (this.OppentTeam.CortMember.Count != game.OppentTeam.CortMember.Count) return false;
            if (this.OppentTeam.OutMember.Count != game.OppentTeam.OutMember.Count) return false;
            if (this.MyTeam.TimeOutList.Count != game.MyTeam.TimeOutList.Count) return false;
            if (this.OppentTeam.TimeOutList.Count != game.OppentTeam.TimeOutList.Count) return false;
            if (this.MyTeam.MemberChange.Count != game.MyTeam.MemberChange.Count) return false;
            if (this.OppentTeam.MemberChange.Count != game.OppentTeam.MemberChange.Count) return false;

            for (var i = 0; i < this.MyTeam.TeamMember.Count; i++)
            {
                List<Action.Action> myList =  ActionListConverter.ToActionList(this.MyTeam.TeamMember[i].GetActionList(this.MyTeam.TeamMember[i]));
                List<Action.Action> gameList = ActionListConverter.ToActionList(game.MyTeam.TeamMember[i].GetActionList(game.MyTeam.TeamMember[i]));

                if (this.MyTeam.TeamMember[i].GetActionList(this.MyTeam.TeamMember[i]).Count
                    != game.MyTeam.TeamMember[i].GetActionList(game.MyTeam.TeamMember[i]).Count)
                    return false;
            }

            for (var i = 0; i < this.OppentTeam.TeamMember.Count; i++)
            {
                if (this.OppentTeam.TeamMember[i].GetActionList(this.OppentTeam.TeamMember[i]).Count 
                    != game.OppentTeam.TeamMember[i].GetActionList(game.OppentTeam.TeamMember[i]).Count)
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
