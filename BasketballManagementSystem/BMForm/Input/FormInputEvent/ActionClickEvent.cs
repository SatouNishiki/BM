using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasketballManagementSystem.BaseClass.Player;
using BasketballManagementSystem.BaseClass.Action;
using BasketballManagementSystem.BMForm.Input;
using BasketballManagementSystem.BaseClass.Position;
using BMErrorLibrary;
using System.Reflection;

namespace BasketballManagementSystem.BMForm.Input.FormInputEvent
{
    /// <summary>
    /// アクションの入力処理を行うクラス
    /// </summary>
    public class InputActionEvent
    {
         //出力用のプレイヤー変数
        Player p = new Player();
        
        Team team = new Team();

        /// <summary>
        /// アクションの入力の受付メソッド
        /// </summary>
        /// <param name="form">formInputインスタンス</param>
        /// <param name="action">アクションのインスタンス</param>
        /// <param name="position">アクションの場所</param>
        public void ActionInputAccept<Type>(FormInput form, Type action, Position position)
        {
            //現在選択しているプレイヤーが自分のチームなのか相手のチームなのか判定
            if (form.MyTeam.TeamMember.IndexOf(form.SelectedPlayer) >= 0)
            {
                team = form.MyTeam;

                actionInput(form, action, position);

            }
            else if (form.OppentTeam.TeamMember.IndexOf(form.SelectedPlayer) >= 0)
            {
                team = form.OppentTeam;

                actionInput(form, action, position);
            }
            else
            {
                BMError.ErrorMessageOutput("自チーム、相手チーム共に選択している選手が見つかりませんでした");
            }
        }

        /// <summary>
        /// アクションの入力処理を行うメソッド
        /// </summary>
        /// <param name="f">FormInputインスタンス</param>
        /// <param name="action">actionのインスタンス</param>
        /// <param name="positon">アクションが行われた位置情報</param>
        private void actionInput<T>(FormInput f, T action, Position positon)
        {

            //選手リストの中で現在選択中の選手がどの場所にあるか(リストの何番目の要素か)
            int point = 0;

            p = f.SelectedPlayer;

            //選手の場所を確定
            point = team.TeamMember.IndexOf(p);

            Type t1 = action.GetType();

            //TODO: 謎警告 原因不明だがコードは正常に動作する(Type型はActionを継承してないからVCが勘違いしてる？)
            if (t1 is BaseClass.Action.Action) return;

            MethodInfo methodInfo = null;

            //入力したいプロパティを動的に探してデータを入れる
            PropertyInfo propInfo = t1.GetProperty("ActionDate");

            if (propInfo != null)
            {
                methodInfo = propInfo.GetSetMethod();
                methodInfo.Invoke(action, new object[] { DateTime.Now });
            }

            propInfo = t1.GetProperty("!uarter");

            if (propInfo != null)
            {
                methodInfo = propInfo.GetSetMethod();
                methodInfo.Invoke(action, new object[] { f.Quarter });
            }

            propInfo = t1.GetProperty("RemainingTime");

            if (propInfo != null)
            {
                methodInfo = propInfo.GetSetMethod();
                methodInfo.Invoke(action, new object[] { f.RemainingTime });
            }

            propInfo = t1.GetProperty("ElapsedTime");

            if (propInfo != null)
            {
                methodInfo = propInfo.GetSetMethod();
                methodInfo.Invoke(action, new object[] { f.ElaspedTime });
            }

            propInfo = t1.GetProperty("OwnerName");

            if (propInfo != null)
            {
                methodInfo = propInfo.GetSetMethod();
                methodInfo.Invoke(action, new object[] { p.Name });
            }

            propInfo = t1.GetProperty("OwnerNumber");

            if (propInfo != null)
            {
                methodInfo = propInfo.GetSetMethod();
                methodInfo.Invoke(action, new object[] { p.Number });
            }

            propInfo = t1.GetProperty("GivenFreeThrow");

            if (propInfo != null)
            {
                methodInfo = propInfo.GetSetMethod();
                methodInfo.Invoke(action, new object[] { f.GivenFreeThrow });

                //与フリースローのプロパティを入力する=ファウルなのでファウルカウントを増やす
                if (f.Quarter <= 4)
                {
                    team.TeamFaul[f.Quarter]++;
                }
                else
                {
                    team.TeamFaul[4]++;
                }
            }

            if (positon != null)
            {
                propInfo = t1.GetProperty("Position");

                if (propInfo != null)
                {
                    methodInfo = propInfo.GetSetMethod();
                    methodInfo.Invoke(action, new object[] { positon });
                }
            }

            //複雑なことしてるけどactionName変数に引数でもらったアクションの名前入れたいだけ
            //ジェネリックはキャストできないので動的にもってくる
            propInfo = t1.GetProperty("ActionName");

            string actionName = "";

            if (propInfo == null) return;

            actionName = (string)propInfo.GetValue(action, null);

            object o = team.TeamMember[point].GetActionProperty(p, actionName);

            try
            {
                //面倒なことしてるけど保持しているActiuonのlistの要素数とってきて表示したいだけ
                Type t = o.GetType();
                MethodInfo mi = t.GetMethod("Add");

                mi.Invoke(o, new object[] { action });

                PropertyInfo pi = t.GetProperty("Count");

                int count = (int)pi.GetValue(o, null);

                f.AddDebugMessage(p.Name + "のアクションを変更, " + action + " ,ActionCount=" + count);
            }
            catch(Exception exc)
            {
                BMError.ErrorMessageOutput(exc.Message);
            }

        }
    }
}
