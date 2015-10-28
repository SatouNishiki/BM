using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasketballManagementSystem.baseClass.game;
using BasketballManagementSystem.baseClass.player;
using BasketballManagementSystem.manager;
using BasketballManagementSystem.baseClass.position;
using BasketballManagementSystem.baseClass.action;
using System.Reflection;
using System.Windows.Forms;
using BMErrorLibrary;
using BasketballManagementSystem.interfaces;
using BasketballManagementSystem.bMForm.input;
using BasketballManagementSystem.bMForm.popupForm;

namespace BasketballManagementSystem.baseClass.command
{
    public class ActionCommand : ICommand 
    {
        /// <summary>
        /// 入力対象のGameオブジェクト
        /// </summary>
        public Game Game { get { return this.Model.Game; } }

        /// <summary>
        /// 入力対象の選手
        /// </summary>
        public Player Player { get { return this.Model.SelectedPlayer; } }

        /// <summary>
        /// 入力場所
        /// </summary>
        public Position Position { get; set; }

        /// <summary>
        /// ファウルのとき、相手に与えたフリースローの数
        /// </summary>
        public int GivenFreeThrow { get { return this.Model.GivenFreeThrow; } }

        private Team Team;

        private Type type;

        protected FormInputModel Model { get; set; }

        public ActionCommand(FormInputModel m, Type t)
        {
            this.Model = m;
            this.type = t;
        }

        public ActionCommand(FormInputModel m, Type t, Position p)
        {
            this.Model = m;
            this.type = t;
            this.Position = p;
        }

        protected void ActionInput(Type type)
        {

            object obj = Activator.CreateInstance(type);

            if (!(obj is ActionBase)) return;

            if (Player.IsMyTeam)
            {
                this.Team = this.Model.MyTeam;
            }
            else
            {
                this.Team = this.Model.OppentTeam;
            }

            this.ActionInputHelper(obj);
        }

        private void ActionInputHelper(object action)
        {
            //選手リストの中で現在選択中の選手がどの場所にあるか(リストの何番目の要素か)
            int point = 0;

            //選手の場所を確定
            point = this.Team.TeamMember.IndexOf(this.Player);

            Type t1 = action.GetType();

            MethodInfo methodInfo = null;

            //入力したいプロパティを動的に探してデータを入れる
            PropertyInfo propInfo = t1.GetProperty("ActionDate");

            if (propInfo != null)
            {
                methodInfo = propInfo.GetSetMethod();
                methodInfo.Invoke(action, new object[] { DateTime.Now });
            }

            propInfo = t1.GetProperty("Quarter");

            if (propInfo != null)
            {
                methodInfo = propInfo.GetSetMethod();
                methodInfo.Invoke(action, new object[] { this.Model.QuarterTimer.quarter });
            }

            propInfo = t1.GetProperty("RemainingTime");

            if (propInfo != null)
            {
                methodInfo = propInfo.GetSetMethod();
                methodInfo.Invoke(action, new object[] { this.Model.QuarterTimer.remainingTime });
            }

            propInfo = t1.GetProperty("ElapsedTime");

            if (propInfo != null)
            {
                methodInfo = propInfo.GetSetMethod();
                methodInfo.Invoke(action, new object[] { this.Model.QuarterTimer.elapsedTime });
            }

            propInfo = t1.GetProperty("OwnerName");

            if (propInfo != null)
            {
                methodInfo = propInfo.GetSetMethod();
                methodInfo.Invoke(action, new object[] { this.Player.Name });
            }

            propInfo = t1.GetProperty("OwnerNumber");

            if (propInfo != null)
            {
                methodInfo = propInfo.GetSetMethod();
                methodInfo.Invoke(action, new object[] { this.Player.Number });
            }

            propInfo = t1.GetProperty("GivenFreeThrow");

            if (propInfo != null)
            {
                methodInfo = propInfo.GetSetMethod();
                methodInfo.Invoke(action, new object[] { this.GivenFreeThrow });

                //与フリースローのプロパティを入力する=ファウルなのでファウルカウントを増やす
                if (this.Model.QuarterTimer.quarter <= 4)
                {
                    this.Team.TeamFaul[this.Model.QuarterTimer.quarter]++;
                }
                else
                {
                    this.Team.TeamFaul[4]++;
                }
            }

            if (this.Position != null)
            {
                propInfo = t1.GetProperty("Position");

                if (propInfo != null)
                {
                    methodInfo = propInfo.GetSetMethod();
                    methodInfo.Invoke(action, new object[] { this.Position });
                }
            }

            if (this.Model.UseComment)
            {
                string str = Microsoft.VisualBasic.Interaction.InputBox(
                "アクションに対するコメントを入力してください",
                "入力画面",
                "",
                200,
                100);

                propInfo = t1.GetProperty("Comment");

                if (propInfo != null)
                {
                    methodInfo = propInfo.GetSetMethod();
                    methodInfo.Invoke(action, new object[] { str });
                }
            }

            //複雑なことしてるけどactionName変数に引数でもらったアクションの名前入れたいだけ
            //ジェネリックはキャストできないので動的にもってくる
            propInfo = t1.GetProperty("ActionName");

            string actionName = "";

            if (propInfo == null) return;

            actionName = (string)propInfo.GetValue(action, null);

            object o = this.Team.TeamMember[point].GetActionProperty(this.Player, actionName);

            try
            {
                //面倒なことしてるけど保持しているActiuonのlistの要素数とってきて表示したいだけ
                Type t = o.GetType();
                MethodInfo mi = t.GetMethod("Add");

                mi.Invoke(o, new object[] { action });

                PropertyInfo pi = t.GetProperty("Count");

                int count = (int)pi.GetValue(o, null);

                PopupForm p = new PopupForm();
                p.Show(this.Player.Name + "のアクションを変更, " + action + " ,ActionCount=" + count);

            }
            catch (Exception exc)
            {
                BMError.ErrorMessageOutput(exc.Message, true);
            }

        }

        public void Execute()
        {
            this.ActionInput(this.type);
        }
    }
}
