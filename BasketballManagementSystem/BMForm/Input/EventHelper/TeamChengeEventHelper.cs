using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BasketballManagementSystem.BaseClass.Player;
using BasketballManagementSystem.Manager;
using DandDPlayerList;
using BMErrorLibrary;
using BMFileLibrary;

namespace BasketballManagementSystem.BMForm.Input.EventHelper
{
    public class TeamChengeEventHelper
    {
        private TeamManager teamManager = TeamManager.getInstance();

        /// <summary>
        /// 自チーム変更ボタンが押されたときの処理委託
        /// ファイル選択をし、そのファイルに記述されているチームを読み込む
        /// </summary>
        /// <param name="f"></param>
        /// <param name="PlayerList"></param>
        /// <param name="OutMemberList"></param>
        /// <param name="myTeam"></param>
        public void onMyTeamChange(FormInput f, ListBox PlayerList, ListBox OutMemberList)
        {
            //OpenFileDialogクラスのインスタンスを作成
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = BMFile.FindDirectory("TeamData");

            Team t;

            //ダイアログを表示する
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //OKボタンがクリックされたとき
                //選択されたファイルを読み取り専用で開く
                System.IO.Stream stream;
                stream = ofd.OpenFile();
               
                if (stream != null)
                {
                    //指定したファイルからチーム情報取得
                    t = teamManager.loadTeam(ofd.FileName, true);

                    //チームをリストにセット
                    SetTeamList(f, PlayerList, OutMemberList, t);

                    f.MyTeam.Name = t.Name;
                }
                else
                {
                    BMError.ErrorMessageOutput("stream is null", true);
                }
            }
        }

        /// <summary>
        /// 相手チーム変更ボタンが押されたときの処理委託
        /// ファイル選択をし、そのファイルに記述されているチームを読み込む
        /// </summary>
        /// <param name="f"></param>
        /// <param name="OppentPlayerList"></param>
        /// <param name="OppentOutMemberList"></param>
        /// <param name="oppentTeam"></param>
        public void onOppentTeamChange(FormInput f, ListBox OppentPlayerList, ListBox OppentOutMemberList)
        {
            //OpenFileDialogクラスのインスタンスを作成
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.InitialDirectory = BMFile.FindDirectory("TeamData");

            Team t;

            //ダイアログを表示する
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //OKボタンがクリックされたとき
                //選択されたファイルを読み取り専用で開く
                System.IO.Stream stream;
                stream = ofd.OpenFile();

                if (stream != null)
                {
                    t = teamManager.loadTeam(ofd.FileName, false);

                    SetTeamList(f, OppentPlayerList, OppentOutMemberList, t);

                    f.OppentTeam.Name = t.Name;
                }
                else
                {
                    BMError.ErrorMessageOutput("stream is null", true);
                }
            }
        }

        /// <summary>
        /// addListとoutMemberListの中身をリセット
        /// teamのデータをlistに追加する
        /// </summary>
        /// <param name="f"></param>
        /// <param name="addList"></param>
        /// <param name="outMemberList"></param>
        /// <param name="team"></param>
        private void SetTeamList(FormInput f, ListBox cortMemberList, ListBox outMemberList, Team team)
        {
            cortMemberList.Items.Clear();
            outMemberList.Items.Clear();

            List<Player> l1 = team.CortMember;
            List<Player> l2 = team.OutMember;

            foreach (var p in l1)
            {
                cortMemberList.Items.Add(p);     
            }

            foreach (var p in l2)
            {
                outMemberList.Items.Add(p);
            }
        }
    }
}
