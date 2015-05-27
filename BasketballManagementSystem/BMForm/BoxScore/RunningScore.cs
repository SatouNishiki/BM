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

        public Label[] teamANumbers { get; set; }
        public Label[] teamAPoints { get; set; }

        public Label[] teamBNumbers { get; set; }
        public Label[] teamBPoints { get; set; }

        private Bitmap syasen_black;
        private Bitmap syasen_red;
        private Bitmap maru_black;
        private Bitmap maru_red;
        private Bitmap kuromaru;
        private Bitmap akamaru;

        private int teamAAllPoint = 0;
        private int teamBAllPoint = 0;

        public RunningScore()
        {

            teamANumbers = new Label[RunningScoreNumber];
            teamAPoints = new Label[RunningScoreNumber];
            teamBNumbers = new Label[RunningScoreNumber];
            teamBPoints = new Label[RunningScoreNumber];

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
            teamAAllPoint += action.Point;

            //2ポイントシュートだった場合の処理
            if (action.Point == new Shoot2P().Point)
            {
                if (action.Quarter == 1 || action.Quarter == 3)
                {
                    teamAPoints[teamAAllPoint - 1].Image = syasen_black;
                    teamANumbers[teamAAllPoint - 1].ForeColor = Color.Black;
                }

                if (action.Quarter == 2 || action.Quarter >= 4)
                {
                    teamAPoints[teamAAllPoint - 1].Image = syasen_red;
                    teamANumbers[teamAAllPoint - 1].ForeColor = Color.Red;
                }
            }

            if (action.Point == new Shoot3P().Point)
            {
                if (action.Quarter == 1 || action.Quarter == 3)
                {
                    teamAPoints[teamAAllPoint - 1].Image = syasen_black;
                    teamANumbers[teamAAllPoint - 1].ForeColor = Color.Black;
                    teamANumbers[teamAAllPoint - 1].Image = maru_black;
                }

                if (action.Quarter == 2 || action.Quarter >= 4)
                {
                    teamAPoints[teamAAllPoint - 1].Image = syasen_red;
                    teamANumbers[teamAAllPoint - 1].ForeColor = Color.Red;
                    teamANumbers[teamAAllPoint - 1].Image = maru_red;
                }
            }

            if (action.Point == new FreeThrow().Point)
            {
                if (action.Quarter == 1 || action.Quarter == 3)
                {
                    teamAPoints[teamAAllPoint - 1].Image = kuromaru;
                    teamANumbers[teamAAllPoint - 1].ForeColor = Color.Black;
                }

                if (action.Quarter == 2 || action.Quarter >= 4)
                {
                    teamAPoints[teamAAllPoint - 1].Image = akamaru;
                    teamANumbers[teamAAllPoint - 1].ForeColor = Color.Red;
                }
            }
            teamANumbers[teamAAllPoint - 1].Text = playerNumber.ToString();
        }

        public void InputRunningScoreB(RelationPointAction action, int playerNumber)
        {
            teamBAllPoint += action.Point;

            //2ポイントシュートだった場合の処理
            if (action.Point == new Shoot2P().Point)
            {
                if (action.Quarter == 1 || action.Quarter == 3)
                {
                    teamBPoints[teamBAllPoint - 1].Image = syasen_black;
                    teamBNumbers[teamBAllPoint - 1].ForeColor = Color.Black;
                }

                if (action.Quarter == 2 || action.Quarter >= 4)
                {
                    teamBPoints[teamBAllPoint - 1].Image = syasen_red;
                    teamBNumbers[teamBAllPoint - 1].ForeColor = Color.Red;
                }
            }

            if (action.Point == new Shoot3P().Point)
            {
                if (action.Quarter == 1 || action.Quarter == 3)
                {
                    teamBPoints[teamBAllPoint - 1].Image = syasen_black;
                    teamBNumbers[teamBAllPoint - 1].ForeColor = Color.Black;
                    teamBNumbers[teamBAllPoint - 1].Image = maru_black;
                }

                if (action.Quarter == 2 || action.Quarter >= 4)
                {
                    teamBPoints[teamBAllPoint - 1].Image = syasen_red;
                    teamBNumbers[teamBAllPoint - 1].ForeColor = Color.Red;
                    teamBNumbers[teamBAllPoint - 1].Image = maru_red;
                }
            }

            if (action.Point == new FreeThrow().Point)
            {
                if (action.Quarter == 1 || action.Quarter == 3)
                {
                    teamBPoints[teamBAllPoint - 1].Image = kuromaru;
                    teamBNumbers[teamBAllPoint - 1].ForeColor = Color.Black;
                }

                if (action.Quarter == 2 || action.Quarter >= 4)
                {
                    teamBPoints[teamBAllPoint - 1].Image = akamaru;
                    teamBNumbers[teamBAllPoint - 1].ForeColor = Color.Red;
                }
            }
            teamBNumbers[teamBAllPoint - 1].Text = playerNumber.ToString();
        }

        public void Init()
        {
            for (var i = 0; i < RunningScoreNumber - 1; i++)
            {
                teamAPoints[i].Text = (i + 1).ToString();
                teamANumbers[i].Text = "";
                teamAPoints[i].Font = new Font(teamAPoints[i].Font.FontFamily.Name, 10.0F);
                teamANumbers[i].Font = new Font(teamAPoints[i].Font.FontFamily.Name, 10.0F);

                teamBPoints[i].Text = (i + 1).ToString();
                teamBNumbers[i].Text = "";
                teamBPoints[i].Font = new Font(teamBPoints[i].Font.FontFamily.Name, 10.0F);
                teamBNumbers[i].Font = new Font(teamAPoints[i].Font.FontFamily.Name, 10.0F);
            }

        }
    }
}
