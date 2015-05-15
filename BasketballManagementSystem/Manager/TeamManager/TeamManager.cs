using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BasketballManagementSystem.BaseClass.Player;
using System.IO;
using System.Collections;
using TagFileLoader;
using BMErrorLibrary;

namespace BasketballManagementSystem.Manager.TeamManager
{
    class TeamManager
    {

        private static TeamManager instance = new TeamManager();

        /// <summary>
        /// インスタンス生成不可
        /// </summary>
        private TeamManager() { }


        public static TeamManager getInstance() { return instance; }


        /// <summary>
        /// 引数:ファイル名
        /// ファイル名を受け取るとそのファイルから選手情報を取得し、Team型にして返す
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public Team loadTeam(string path, bool isMyTeam)
        {

            TagFileLoader.TagFileLoader tagFileLoader = new TagFileLoader.TagFileLoader();

            ArrayList cortMemberList = tagFileLoader.loadTagFile(path, "CortMember");

            ArrayList outMemberList = tagFileLoader.loadTagFile(path, "OutMember");

            ArrayList teamName = tagFileLoader.loadTagFile(path, "TeamName");

            Team team = new Team();

            int count = 0;

            string name = "";
            int number = 0;

            //読み込んだファイル情報の中からコートメンバーの名前と番号を読み込む
            foreach (string s in cortMemberList)
            {
                if (count % 2 == 0)
                {
                    name = s;
                }
                else if (count % 2 == 1)
                {
                    number = int.Parse(s);

                    Player p = new Player(name, number);
                    p.IsMyTeam = isMyTeam;
                    p.IsStarter = true;

                    team.AddTeamMember(p, true);
                   
                }

                count++;
            }

            foreach (string s in outMemberList)
            {
                if (count % 2 == 0)
                {
                    name = s;
                }
                else if (count % 2 == 1)
                {
                    number = int.Parse(s);

                    Player p = new Player(name, number);
                    p.IsMyTeam = isMyTeam;

                    team.AddTeamMember(p, false);

                }

                count++;
            }

            team.Name = (string)teamName[0];

            return team;
        }
        
    }
}
