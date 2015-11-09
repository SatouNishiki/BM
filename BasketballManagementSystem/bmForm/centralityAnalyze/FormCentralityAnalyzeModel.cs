using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasketballManagementSystem.interfaces;
using BasketballManagementSystem.baseClass.player;
using BasketballManagementSystem.baseClass.game;
using BasketballManagementSystem.manager;
using BasketballManagementSystem.baseClass.actionPoint;

namespace BasketballManagementSystem.bmForm.centralityAnalyze
{
    public class FormCentralityAnalyzeModel : abstracts.AbstractModel
    {
        public Game Game { get; set; }

        public Player SourcePlayer { get; set; }

        public Player TargetPlayer { get; set; }
        

        public FormCentralityAnalyzeModel()
        {
            Game = SaveDataManager.GetInstance().GetGame();
        }

        /// <summary>
        /// 行動傾向点に基づいた中心性解析を行う
        /// </summary>
        /// <returns></returns>
        public List<Dictionary<int, int>> Analyze()
        {
            if (this.SourcePlayer == null)
                return null;

            Team team;

            ActionPointAnalyzer analyze = new ActionPointAnalyzer();

            if (SourcePlayer.IsMyTeam)
                team = Game.MyTeam;
            else
                team = Game.OppentTeam;

            List<Dictionary<int, int>> dicList = new List<Dictionary<int, int>>();

            foreach (var p in team.TeamMember)
            {
                TargetPlayer = p;

                if (SourcePlayer == TargetPlayer) continue;

                dicList.Add(analyze.GetNexus(SourcePlayer, TargetPlayer));
            }

            return dicList;
        }

     
    }
}
