﻿using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using BasketballManagementSystem.baseClass.action;
using System;
using System.Text;
using System.Threading.Tasks;

namespace BasketballManagementSystem.baseClass.player
{
    [Serializable]
    public class Team
    {
        [XmlArrayItem(Type = typeof(Player))]
        /// <summary>
        /// チームのメンバー全員
        /// </summary>
        public List<Player> TeamMember
        {
            get
            {
                List<Player> t = new List<Player>();

                t.AddRange(CortMember);
                t.AddRange(OutMember);

                return t;
            }
            private set
            {
            }
        }
       
        /// <summary>
        /// コートのメンバー
        /// </summary>
        public List<Player> CortMember { get; set; }

        /// <summary>
        /// ベンチのメンバー
        /// </summary>
        public List<Player> OutMember { get; set; }

        /// <summary>
        /// チームの総得点
        /// </summary>
        public int AllPoint
        {
            get
            {
                int point = 0;

                foreach (Player p in TeamMember)
                {
                    point += p.Point;
                }

                return point;
            }
        }

        /// <summary>
        /// チーム名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// チームファウルの数 要素番号はクォーターの数
        /// </summary>
        public int[] TeamFaul { get; set; }

        /// <summary>
        /// タイムアウト情報
        /// </summary>
        public List<timeOut.TimeOut> TimeOutList { get; set; }

        /// <summary>
        /// メンバーチェンジ情報
        /// </summary>
        public List<MemberChange> MemberChange { get; set; }

        public Team()
        {
            TeamMember = new List<Player>();
            CortMember = new List<Player>();
            OutMember = new List<Player>();
            
            //TeamFaul[クォーター数]でアクセスするときに[4]しかないと4クォーター目に到達できない
            //ポインタをずらすのは汚かったのでとりあえず5つ確保([0] - [4]までアクセス可能で0は使用しない)
            TeamFaul = new int[5];
            Name = "No Name Team";

            TimeOutList = new List<timeOut.TimeOut>();
            MemberChange = new List<MemberChange>();

        }

        /// <summary>
        /// もらった選手型のデータをリストに代入
        /// isCortMember:
        /// true = コートメンバー
        /// false = ベンチメンバー
        /// </summary>
        /// <param name="p"></param>
        /// <param name="isCortMember"></param>
        public void AddTeamMember(Player p, bool isCortMember)
        {
            if (isCortMember)
            {
                CortMember.Add(p);
            }
            else
            {
                OutMember.Add(p);
            }
            
        }

        /// <summary>
        /// 全てのメンバーに対してチームの変更を行う
        /// true = 自チーム
        /// false = 相手チーム
        /// </summary>
        /// <param name="isMyTeam"></param>
        public void allMemberChangeIsMyTeam(bool isMyTeam)
        {

            foreach (var p in CortMember)
            {
                p.IsMyTeam = isMyTeam;
            }

            foreach (var p in OutMember)
            {
                p.IsMyTeam = isMyTeam;
            }
        }

        /// <summary>
        /// 指定のクォーターに行われたアクションを時系列(残り時間の多い)順のlistにして返す
        /// </summary>
        /// <param name="quarter">クォーター </param>
        /// <returns>object型のlist</returns>
        public List<object> GetQuarterAction(int quarter)
        {
            List<object> actionList = new List<object>();

            foreach (var p in TeamMember)
            {
                actionList.AddRange(p.GetActionList(p, a => a.Quarter == quarter));
            }

            var query = from p in actionList
                        orderby ((ActionBase)p).ActionDate.Ticks
                        select p;

            List<object> rt = query.ToList<object>();

            return rt;
        }

        /// <summary>
        /// 全てのアクションを時系列(残り時間の多い)順のlistにして返す
        /// </summary>
        /// <returns>object型のlist</returns>
        public List<object> GetActionAll()
        {
            List<object> actionList = new List<object>();

            foreach (Player p in TeamMember)
            {
                actionList.AddRange(p.GetActionList(p));
            }

            var query = from p in actionList
                        orderby ((ActionBase)p).ActionDate.Ticks
                        select p;

            List<object> rt = query.ToList<object>();

            return rt;
        }

        /// <summary>
        /// 指定されたクォーターの得点を返す
        /// </summary>
        /// <param name="quarter">クォーター数 延長を取得したいときは5</param>
        /// <returns></returns>
        public int GetQuarterPoint(int quarter)
        {
            if (quarter >= 5) { quarter = 5; }

            List<RelationPointAction> r = ActionListConverter.ToRelationPointActionList(GetQuarterAction(quarter));

            int point = 0;

            foreach (var p in r)
            {
                point += p.Point;
            }

            return point;
        }

        /// <summary>
        /// TimeOutクラスで宣言された区間定数、または指定のクォーターに当たるタイムアウトの回数を返す
        /// </summary>
        /// <param name="timeoutSection">TimeOutクラスで宣言された区間定数、またはクォーター</param>
        /// <returns></returns>
        public int GetTimeOutCount(int timeoutSection)
        {
            List<timeOut.TimeOut> to = new List<timeOut.TimeOut>();

            if (timeoutSection == timeOut.TimeOut.FirstHalf ||
                timeoutSection == timeOut.TimeOut.SecondHalf ||
                timeoutSection == timeOut.TimeOut.ExtraInning)
            {
                foreach (var t in TimeOutList)
                {
                    if (t.GetTimeOutSection(timeoutSection))
                    {
                        to.Add(t);
                    }
                }
            }
            else
            {
                foreach (var t in TimeOutList)
                {
                    if (t.Quarter == timeoutSection)
                    {
                        to.Add(t);
                    }
                }
            }

            return to.Count;
        }

        /// <summary>
        /// コートにいたプレイヤーのリストをメンバーチェンジのタイミングごとに区切ったリストで返す
        /// </summary>
        /// <returns></returns>
        public List<List<Player>> GetCortMembers()
        {
            List<List<Player>> cortMembers = new List<List<Player>>();

            List<Player> players = new List<Player>();

            //スターターを代入
            foreach (var p in TeamMember)
            {
                if (p.IsStarter) players.Add(p);
            }

            cortMembers.Add(players);

            //全てのメンバーチェンジ情報を取得
            foreach (var m in MemberChange)
            {
                List<Player> tempPlayers = new List<Player>();
                int count = 0;

                //メンバーチェンジする前のコートメンバーの中からベンチにいっていない選手を探す
                foreach (var p in cortMembers[count])
                {
                    if (m.ChangedCortMembers.IndexOf(p) < 0)
                    {
                        tempPlayers.Add(p);
                    }
                }

                //ベンチから入ってきた選手を追加
                foreach (var p in m.ChangedOutMembers)
                {
                    tempPlayers.Add(p);
                }

                cortMembers.Add(tempPlayers);
            }

            return cortMembers;
        }
    }
}
