using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasketballManagementSystem.manager;
using BasketballManagementSystem.baseClass.game;
using BasketballManagementSystem.baseClass.player;
using BasketballManagementSystem.baseClass.action;
using BasketballManagementSystem.baseClass.actionPoint;

namespace BasketballManagementSystem.baseClass.actionPoint
{
    public class ActionPointAnalyze
    {
        game.Game game = SaveDataManager.GetInstance().GetGame();

        /// <summary>
        /// sourcePlayerからtargetPlayerへの結びつき度をアクションポイントに基づいて解析します
        /// </summary>
        /// <param name="sourcePlayer"></param>
        /// <param name="targetPlayer"></param>
        /// <returns>ソースとターゲットの結びつき度　解析成功：key→ActionPointProviderのType定数　value→Typeごとの結びつき度　解析失敗：null</returns>
        public Dictionary<int, int> GetNexus(player.Player sourcePlayer, player.Player targetPlayer)
        {
            //メンバーチェンジごとで区切ったアクションのリスト
            List<List<object>> actionList = new List<List<object>>();

            Team team;

            //別チーム同士は判定不可
            if(sourcePlayer.IsMyTeam != targetPlayer.IsMyTeam) return null;

            //選手がどちらのチームなのか決める
            if(sourcePlayer.IsMyTeam)
                team = game.MyTeam;
            else
                team = game.OppentTeam;

            //ループ変数
            int count = 0;

            //ダミーデータを追加したかどうか
            bool dammyFlag = false;

            //メンバーチェンジを行っていない場合
            if (team.MemberChange.Count == 0)
            {
                //ダミーデータを追加
                MemberChange m = new MemberChange();
                m.ChengedMemberTime = game.EndTime;
                team.MemberChange.Add(m);
                dammyFlag = true;
            }

            //メンバーチェンジ情報の中から
            foreach (var t in team.MemberChange)
            {
                //ソースとターゲットが同じコートにいないときは結びつきを計算しない
                if (team.GetCortMembers()[count].IndexOf(sourcePlayer) < 0 && team.GetCortMembers()[count].IndexOf(targetPlayer) < 0)
                {
                    count++;
                    continue;
                }

                //以下ソース、ターゲットが同じコートにいたとき
                List<object> al = new List<object>();

                //ソースの全アクションから
                foreach (var a in sourcePlayer.GetActionList(sourcePlayer))
                {
                    //次のメンバーチェンジまでの間に行ったアクションを全部取得してきてリストに突っ込む

                    if (count != 0)
                    {
                        if (((ActionBase)a).ActionDate > team.MemberChange[count].ChengedMemberTime && ((ActionBase)a).ActionDate < t.ChengedMemberTime)
                        {
                            al.Add(a);
                        }
                    }
                    else
                    {
                        if (((ActionBase)a).ActionDate > game.StartTime && ((ActionBase)a).ActionDate < t.ChengedMemberTime)
                        {
                            al.Add(a);
                        }
                    }
                }

                actionList.Add(al);
                count++;
            }

            if (dammyFlag)
            {
                team.MemberChange.RemoveAt(team.MemberChange.Count - 1);
            }

            Dictionary<int, int> dic = new Dictionary<int, int>();
            ActionPointProvider ap = ActionPointProvider.GetInstance();

            int faul = 0;
            int miss = 0;
            int point = 0;
            int normal = 0;

            foreach (var l in actionList)
            {
                foreach (var a in l)
                {
                    if (ap.GetActionPointType(a) == ActionPointProvider.TypeFaul)
                        faul++;

                    else if (ap.GetActionPointType(a) == ActionPointProvider.TypeMiss)
                        miss++;

                    else if (ap.GetActionPointType(a) == ActionPointProvider.TypePoint)
                        point++;

                    else if (ap.GetActionPointType(a) == ActionPointProvider.TypeNormal)
                        normal++;
                }
            }

            dic.Add(ActionPointProvider.TypeFaul, faul);
            dic.Add(ActionPointProvider.TypeNormal, normal);
            dic.Add(ActionPointProvider.TypePoint, point);
            dic.Add(ActionPointProvider.TypeMiss, miss);

            return dic;

        }
    }
}
