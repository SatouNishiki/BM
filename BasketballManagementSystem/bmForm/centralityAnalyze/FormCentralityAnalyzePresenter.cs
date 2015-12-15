using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasketballManagementSystem.abstracts;
using BasketballManagementSystem.baseClass.actionPoint;
using BasketballManagementSystem.baseClass.player;

namespace BasketballManagementSystem.bmForm.centralityAnalyze
{
    public class FormCentralityAnalyzePresenter : AbstractPresenter
    {
        private FormCentralityAnalyzeModel centralityAnalyzeModel;
        private FormCentralityAnalyzeView centralityAnalyzeView;

        public FormCentralityAnalyzePresenter(FormCentralityAnalyzeModel model, FormCentralityAnalyzeView view)
            : base(view, model)
        {
            this.centralityAnalyzeModel = model;
            this.centralityAnalyzeView = view;
            
            view.AnalyzeButtonClickEvent += view_AnalyzeButtonClickEvent;
            view.SourcePlayerSelectedEvent += view_SourcePlayerSelectedEvent;

            this.centralityAnalyzeView.Init();
        }

        void view_SourcePlayerSelectedEvent(baseClass.player.Player obj)
        {
            this.centralityAnalyzeModel.SourcePlayer = obj;
        }


        void view_AnalyzeButtonClickEvent()
        {
            Dictionary<Player, Dictionary<int, int>> dicList = this.centralityAnalyzeModel.Analyze();

            this.centralityAnalyzeView.ClearResult();

            if (dicList == null)
            {
                this.centralityAnalyzeView.WriteResult("解析失敗");

                if(this.centralityAnalyzeModel.SourcePlayer == null)
                    this.centralityAnalyzeView.WriteResult("ソースプレイヤーが未選択です");

                return;
            }

            this.centralityAnalyzeView.WriteResult("**解析結果**\n");
            this.centralityAnalyzeView.WriteResult("解析方法 : 行動傾向点基準結びつき度分析\n");
            this.centralityAnalyzeView.WriteResult("\n");

            foreach (var dic in dicList)
            {
                this.centralityAnalyzeView.WriteResult(
                    "対象 : " + this.centralityAnalyzeModel.SourcePlayer.Name + 
                    "(" + this.centralityAnalyzeModel.SourcePlayer.Number + ") → " + 
                    dic.Key.Name +
                    "(" + dic.Key.Number + ")\n");

                this.centralityAnalyzeView.WriteResult("\n");
                this.centralityAnalyzeView.WriteResult("通常 = " + dic.Value[ActionPointProvider.TypeNormal] + "\n");
                this.centralityAnalyzeView.WriteResult("得点 = " + dic.Value[ActionPointProvider.TypePoint] + "\n");
                this.centralityAnalyzeView.WriteResult("ミス = " + dic.Value[ActionPointProvider.TypeMiss] + "\n");
                this.centralityAnalyzeView.WriteResult("ファウル = " + dic.Value[ActionPointProvider.TypeFaul] + "\n");
                this.centralityAnalyzeView.WriteResult("\n");
            }
            
        }

        public override System.Windows.Forms.Form GetForm()
        {
            return this.centralityAnalyzeView;
        }

        public override void ShowView()
        {
            this.centralityAnalyzeView.Show();
        }
    }
}
