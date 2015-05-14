using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using BasketballManagementSystem.BaseClass.Action;

namespace BasketballManagementSystem.BMForm.BoxScore
{
    public class RunningScore
    {
        private const int RunningScoreNumber = 160;

        public Label[] teamANumber { get; set; }
        public Label[] teamAPoint { get; set; }

        public Label[] teamBNumber { get; set; }
        public Label[] teamBPoint { get; set; }

        private Bitmap syasen_black;
        private Bitmap syasen_red;
        private Bitmap maru_black;
        private Bitmap maru_red;
        private Bitmap kuromaru;
        private Bitmap akamaru;

        private int teamAAllPoint = 0;
        private int teamBAllPoint = 0;
  //      private int beforeQuarter = 1;
  //      private int nowQuarter = 1;

        public RunningScore()
        {

            teamANumber = new Label[RunningScoreNumber];
            teamAPoint = new Label[RunningScoreNumber];
            teamBNumber = new Label[RunningScoreNumber];
            teamBPoint = new Label[RunningScoreNumber];

            //現在のコードを実行しているAssemblyを取得
            System.Reflection.Assembly Assembly =
                System.Reflection.Assembly.GetExecutingAssembly();

            //指定されたリソースを読み込む
            syasen_black =
                new Bitmap(Assembly.GetManifestResourceStream
                    ("BasketballManagementSystem.BMForm.BoxScore.Picture.syasen_black.png"));

            syasen_red = new Bitmap(Assembly.GetManifestResourceStream
                    ("BasketballManagementSystem.BMForm.BoxScore.Picture.syasen_red.png"));

            maru_black = new Bitmap(Assembly.GetManifestResourceStream
                    ("BasketballManagementSystem.BMForm.BoxScore.Picture.maru_black.png"));

            maru_red = new Bitmap(Assembly.GetManifestResourceStream
                    ("BasketballManagementSystem.BMForm.BoxScore.Picture.maru_red.png"));

            kuromaru = new Bitmap(Assembly.GetManifestResourceStream
                    ("BasketballManagementSystem.BMForm.BoxScore.Picture.kuromaru.png"));

            akamaru = new Bitmap(Assembly.GetManifestResourceStream
                    ("BasketballManagementSystem.BMForm.BoxScore.Picture.akamaru.png"));

           
        }

        public void InputRunningScoreA(RelationPointAction action, int playerNumber)
        {
            /* nowQuarter = action.quarter;

                if (beforeQuarter != nowQuarter)
                {
                    if (beforeQuarter == 1 || beforeQuarter == 3)
                    {
                        teamAPoint[allPoint - 1].BackColor = Color.Black;
                        teamANumber[allPoint - 1].BackColor = Color.Black;
                    }
                    else
                    {
                        teamAPoint[allPoint - 1].BackColor = Color.Red;
                        teamANumber[allPoint - 1].BackColor = Color.Red;
                    }

                    beforeQuarter = nowQuarter;
                }
             */
            teamAAllPoint += action.point;

            //2ポイントシュートだった場合の処理
            if (action.point == new Shoot2P().point)
            {
                if (action.Quarter == 1 || action.Quarter == 3)
                {
                    teamAPoint[teamAAllPoint - 1].Image = syasen_black;
                    teamANumber[teamAAllPoint - 1].ForeColor = Color.Black;
                }

                if (action.Quarter == 2 || action.Quarter >= 4)
                {
                    teamAPoint[teamAAllPoint - 1].Image = syasen_red;
                    teamANumber[teamAAllPoint - 1].ForeColor = Color.Red;
                }
            }

            if (action.point == new Shoot3P().point)
            {
                if (action.Quarter == 1 || action.Quarter == 3)
                {
                    teamAPoint[teamAAllPoint - 1].Image = syasen_black;
                    teamANumber[teamAAllPoint - 1].ForeColor = Color.Black;
                    teamANumber[teamAAllPoint - 1].Image = maru_black;
                }

                if (action.Quarter == 2 || action.Quarter >= 4)
                {
                    teamAPoint[teamAAllPoint - 1].Image = syasen_red;
                    teamANumber[teamAAllPoint - 1].ForeColor = Color.Red;
                    teamANumber[teamAAllPoint - 1].Image = maru_red;
                }
            }

            if (action.point == new FreeThrow().point)
            {
                if (action.Quarter == 1 || action.Quarter == 3)
                {
                    teamAPoint[teamAAllPoint - 1].Image = kuromaru;
                    teamANumber[teamAAllPoint - 1].ForeColor = Color.Black;
                }

                if (action.Quarter == 2 || action.Quarter >= 4)
                {
                    teamAPoint[teamAAllPoint - 1].Image = akamaru;
                    teamANumber[teamAAllPoint - 1].ForeColor = Color.Red;
                }
            }
            teamANumber[teamAAllPoint - 1].Text = playerNumber.ToString();
        }

        public void InputRunningScoreB(RelationPointAction action, int playerNumber)
        {
            teamBAllPoint += action.point;

            //2ポイントシュートだった場合の処理
            if (action.point == new Shoot2P().point)
            {
                if (action.Quarter == 1 || action.Quarter == 3)
                {
                    teamBPoint[teamBAllPoint - 1].Image = syasen_black;
                    teamBNumber[teamBAllPoint - 1].ForeColor = Color.Black;
                }

                if (action.Quarter == 2 || action.Quarter >= 4)
                {
                    teamBPoint[teamBAllPoint - 1].Image = syasen_red;
                    teamBNumber[teamBAllPoint - 1].ForeColor = Color.Red;
                }
            }

            if (action.point == new Shoot3P().point)
            {
                if (action.Quarter == 1 || action.Quarter == 3)
                {
                    teamBPoint[teamBAllPoint - 1].Image = syasen_black;
                    teamBNumber[teamBAllPoint - 1].ForeColor = Color.Black;
                    teamBNumber[teamBAllPoint - 1].Image = maru_black;
                }

                if (action.Quarter == 2 || action.Quarter >= 4)
                {
                    teamBPoint[teamBAllPoint - 1].Image = syasen_red;
                    teamBNumber[teamBAllPoint - 1].ForeColor = Color.Red;
                    teamBNumber[teamBAllPoint - 1].Image = maru_red;
                }
            }

            if (action.point == new FreeThrow().point)
            {
                if (action.Quarter == 1 || action.Quarter == 3)
                {
                    teamBPoint[teamBAllPoint - 1].Image = kuromaru;
                    teamBNumber[teamBAllPoint - 1].ForeColor = Color.Black;
                }

                if (action.Quarter == 2 || action.Quarter >= 4)
                {
                    teamBPoint[teamBAllPoint - 1].Image = akamaru;
                    teamBNumber[teamBAllPoint - 1].ForeColor = Color.Red;
                }
            }
            teamBNumber[teamBAllPoint - 1].Text = playerNumber.ToString();
        }

        public void Init()
        {
            for (int i = 0; i < RunningScoreNumber - 1; i++)
            {
                teamAPoint[i].Text = (i + 1).ToString();
                teamANumber[i].Text = "";
                teamAPoint[i].Font = new Font(teamAPoint[i].Font.FontFamily.Name, 10.0F);
                teamANumber[i].Font = new Font(teamAPoint[i].Font.FontFamily.Name, 10.0F);

                teamBPoint[i].Text = (i + 1).ToString();
                teamBNumber[i].Text = "";
                teamBPoint[i].Font = new Font(teamBPoint[i].Font.FontFamily.Name, 10.0F);
                teamBNumber[i].Font = new Font(teamAPoint[i].Font.FontFamily.Name, 10.0F);
            }

        }
    }
}
