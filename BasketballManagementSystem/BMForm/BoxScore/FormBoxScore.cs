using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BasketballManagementSystem.BaseClass.game;
using BasketballManagementSystem.manager;
using System.Collections;
using BasketballManagementSystem.BaseClass.player;
using BasketballManagementSystem.BaseClass.action;
using BasketballManagementSystem.BaseClass.timeOut;

namespace BasketballManagementSystem.BMForm.boxScore
{
    public partial class FormBoxScore : Form
    {
        /// <summary>
        /// スコアシートのプレイヤーの人数
        /// </summary>
        private const int PlayerNumber = 18;
        private const int FaulLineNumber = 5;

        private Game game = new Game();

        private Label[] myQuarterPointLabels = new Label[5];
        private Label[] oppentQuarterPointLabels = new Label[5];

        private Label[] myPlayerNameLabels = new Label[PlayerNumber];

        private Label[] oppentPlayerNameLabels = new Label[PlayerNumber];

        private Label[] myPlayerNumberLabels = new Label[PlayerNumber];

        private Label[] oppentPlayerNumberLabels = new Label[PlayerNumber];

        private Label[] myPlInLabels = new Label[PlayerNumber];

        private Label[] oppentPlInLabels = new Label[PlayerNumber];

        private Label[,] myFaulLines = new Label[FaulLineNumber, PlayerNumber];

        private Label[,] oppentFaulLines = new Label[FaulLineNumber, PlayerNumber];

        private List<PlayerInfomation> myPlayerLists = new List<PlayerInfomation>();

        private List<PlayerInfomation> oppentPlayerLists = new List<PlayerInfomation>();

        private Label[,] myTeamFaulLabels = new Label[4, 4];

        private Label[,] oppentTeamFaulLabels = new Label[4, 4];

        private Label[] myTeamTimeOutLabels = new Label[7];

        private Label[] oppentTeamTimeOutLabels = new Label[7];

        private RunningScore runningScore = new RunningScore();

        public FormBoxScore()
        {
            InitializeComponent();

            game = SaveDataManager.GetInstance().GetGame();

            QuarterLabelInit();

            PlayerNameArrayInit();

            PlayerNumberLabelInit();

            PlInLabelInit();

            FaulLineInit();

            TeamFaulLabelInit();

            TimeOutLabelInit();

            RunningScoreInit();

            InputBaseInfomation();

            InputMyPlayerInfomation();

            InputOppentPlayerInfomation();

            InputTeamFaulLabel();

            InputTimeOutLabel();

            InputRunningScore();

        }

        /// <summary>
        /// コントロールの配列を取得する
        /// </summary>
        /// <param name="frm">コントロールのあるフォーム</param>
        /// <param name="name">後ろの数字を除いたコントロールの名前</param>
        /// <param name="number1">コントロールの後ろについている数字の最初の番号</param>
        /// <param name="number2">コントロールの後ろについている数字の最後の番号</param>
        /// <returns>コントロールの配列。
        /// 取得できなかった時はnull(VB.NETではNothing)。</returns>
        public object GetControlArrayByName(Form frm, string name, int number1, int number2)
        {

            if (number1 > number2) { return null; }

            System.Collections.ArrayList ctrs = new System.Collections.ArrayList();

            object obj;

            for (var i = number1; i <= number2; i++)
            {
                obj = FindControlByFieldName(frm, name + i.ToString());
                ctrs.Add(obj);
            }

            if (ctrs.Count == 0)
            {
                return null;
            }
            else
            {
                ctrs.Sort(new LabelComperer());
                return ctrs.ToArray(ctrs[0].GetType());
            }
        }

        /// <summary>
        /// フォームに配置されているコントロールを名前で探す
        /// （フォームクラスのフィールドをフィールド名で探す）
        /// </summary>
        /// <param name="frm">コントロールを探すフォーム</param>
        /// <param name="name">コントロール（フィールド）の名前</param>
        /// <returns>見つかった時は、コントロールのオブジェクト。
        /// 見つからなかった時は、null(VB.NETではNothing)。</returns>
        public static object FindControlByFieldName(Form frm, string name)
        {
            Type t = frm.GetType();

            System.Reflection.FieldInfo fi = t.GetField(
                name,
                System.Reflection.BindingFlags.Public |
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.DeclaredOnly);

            if (fi == null)
                return null;

            return fi.GetValue(frm);
        }


        /// <summary>
        /// Labelの並び替え
        /// </summary>
        private class LabelComperer : IComparer
        {
            public int Compare(object x, object y)
            {
                //Label型以外の比較はエラー
                if ((!(x is Label)) || (!(y is Label)))
                {
                    throw new ArgumentException("Label型でなければなりません");
                }

                //画面上のロケーションでソートする
                int s1 = ((Label)x).Location.Y;
                int s2 = ((Label)y).Location.Y;

                return s1.CompareTo(s2);
            }
        }

        private void QuarterLabelInit()
        {
            myQuarterPointLabels[0] = Q1m;
            myQuarterPointLabels[1] = Q2m;
            myQuarterPointLabels[2] = Q3m;
            myQuarterPointLabels[3] = Q4m;
            myQuarterPointLabels[4] = Q5m;

            oppentQuarterPointLabels[0] = Q1o;
            oppentQuarterPointLabels[1] = Q2o;
            oppentQuarterPointLabels[2] = Q3o;
            oppentQuarterPointLabels[3] = Q4o;
            oppentQuarterPointLabels[4] = Q5o;

        }

        private void PlayerNameArrayInit()
        {

            myPlayerNameLabels = (Label[])GetControlArrayByName(this, "label", 1, 18);

            oppentPlayerNameLabels = (Label[])GetControlArrayByName(this, "label", 91, 108);

        }

        public void PlayerNumberLabelInit()
        {

            myPlayerNumberLabels = (Label[])GetControlArrayByName(this, "label", 19, 36);

            oppentPlayerNumberLabels = (Label[])GetControlArrayByName(this, "label", 73, 90);

        }

        private void PlInLabelInit()
        {
            myPlInLabels = (Label[])GetControlArrayByName(this, "label", 37, 54);

            oppentPlInLabels = (Label[])GetControlArrayByName(this, "label", 55, 72);
        }

        private void FaulLineInit()
        {

            Label[] ar1 = (Label[])GetControlArrayByName(this, "label", 109, 126);
            Label[] ar2 = (Label[])GetControlArrayByName(this, "label", 127, 144);
            Label[] ar3 = (Label[])GetControlArrayByName(this, "label", 181, 198);
            Label[] ar4 = (Label[])GetControlArrayByName(this, "label", 163, 180);
            Label[] ar5 = (Label[])GetControlArrayByName(this, "label", 145, 162);

            Label[] ar6 = (Label[])GetControlArrayByName(this, "label", 199, 216);
            Label[] ar7 = (Label[])GetControlArrayByName(this, "label", 253, 270);
            Label[] ar8 = (Label[])GetControlArrayByName(this, "label", 271, 288);
            Label[] ar9 = (Label[])GetControlArrayByName(this, "label", 235, 252);
            Label[] ar10 = (Label[])GetControlArrayByName(this, "label", 217, 234);

            for (var i = 0; i < PlayerNumber; i++)
            {
                myFaulLines[0, i] = ar1[i];
            }

            for (var i = 0; i < PlayerNumber; i++)
            {
                myFaulLines[1, i] = ar2[i];
            }

            for (var i = 0; i < PlayerNumber; i++)
            {
                myFaulLines[2, i] = ar3[i];
            }

            for (var i = 0; i < PlayerNumber; i++)
            {
                myFaulLines[3, i] = ar4[i];
            }

            for (var i = 0; i < PlayerNumber; i++)
            {
                myFaulLines[4, i] = ar5[i];
            }

            for (var i = 0; i < PlayerNumber; i++)
            {
                oppentFaulLines[0, i] = ar6[i];
            }

            for (var i = 0; i < PlayerNumber; i++)
            {
                oppentFaulLines[1, i] = ar7[i];
            }

            for (var i = 0; i < PlayerNumber; i++)
            {
                oppentFaulLines[2, i] = ar8[i];
            }

            for (var i = 0; i < PlayerNumber; i++)
            {
                oppentFaulLines[3, i] = ar9[i];
            }

            for (var i = 0; i < PlayerNumber; i++)
            {
                oppentFaulLines[4, i] = ar10[i];
            }
        }

        private void TeamFaulLabelInit()
        {
            Label[] ar1 = (Label[])GetControlArrayByName(this, "label", 289, 292);
            Label[] ar2 = (Label[])GetControlArrayByName(this, "label", 293, 296);
            Label[] ar3 = (Label[])GetControlArrayByName(this, "label", 297, 300);
            Label[] ar4 = (Label[])GetControlArrayByName(this, "label", 301, 304);

            Label[] ar5 = (Label[])GetControlArrayByName(this, "label", 305, 308);
            Label[] ar6 = (Label[])GetControlArrayByName(this, "label", 309, 312);
            Label[] ar7 = (Label[])GetControlArrayByName(this, "label", 313, 316);
            Label[] ar8 = (Label[])GetControlArrayByName(this, "label", 317, 320);

            for (var i = 0; i < 4; i++)
            {
                myTeamFaulLabels[0, i] = ar1[i];
            }

            for (var i = 0; i < 4; i++)
            {
                myTeamFaulLabels[1, i] = ar2[i];
            }

            for (var i = 0; i < 4; i++)
            {
                myTeamFaulLabels[2, i] = ar3[i];
            }

            for (var i = 0; i < 4; i++)
            {
                myTeamFaulLabels[3, i] = ar4[i];
            }

            for (var i = 0; i < 4; i++)
            {
                oppentTeamFaulLabels[0, i] = ar5[i];
            }

            for (var i = 0; i < 4; i++)
            {
                oppentTeamFaulLabels[1, i] = ar6[i];
            }

            for (var i = 0; i < 4; i++)
            {
                oppentTeamFaulLabels[2, i] = ar7[i];
            }

            for (var i = 0; i < 4; i++)
            {
                oppentTeamFaulLabels[3, i] = ar8[i];
            }
        }

        private void TimeOutLabelInit()
        {
            myTeamTimeOutLabels = (Label[])GetControlArrayByName(this, "label", 321, 327);
            oppentTeamTimeOutLabels = (Label[])GetControlArrayByName(this, "label", 328, 334);
        }

        private void RunningScoreInit()
        {
            Label[] ar1 = (Label[])GetControlArrayByName(this, "label", 335, 374);

            Label _ar2_1 = label476;
            Label[] ar2_2 = (Label[])GetControlArrayByName(this, "label", 517, 535);
            Label[] ar2_3 = (Label[])GetControlArrayByName(this, "label", 496, 515);
            List<Label> l = new List<Label>();
            l.Add(_ar2_1);
            l.AddRange(ar2_2);
            l.AddRange(ar2_3);
            Label[] ar2 = l.ToArray();

            Label ar3_1 = label638;
            Label[] ar3_2 = (Label[])GetControlArrayByName(this, "label", 659, 678);
            Label[] ar3_3 = (Label[])GetControlArrayByName(this, "label", 639, 640);
            Label[] ar3_4 = (Label[])GetControlArrayByName(this, "label", 684, 700);
            List<Label> l2 = new List<Label>();
            l2.Add(ar3_1);
            l2.AddRange(ar3_2);
            l2.AddRange(ar3_3);
            l2.AddRange(ar3_4);
            Label[] ar3 = l2.ToArray();

            Label ar4_1 = label799;
            Label[] ar4_2 = (Label[])GetControlArrayByName(this, "label", 821, 837);
            Label[] ar4_3 = (Label[])GetControlArrayByName(this, "label", 800, 803);
            Label[] ar4_4 = (Label[])GetControlArrayByName(this, "label", 841, 858);
            List<Label> l3 = new List<Label>();
            l3.Add(ar4_1);
            l3.AddRange(ar4_2);
            l3.AddRange(ar4_3);
            l3.AddRange(ar4_4);
            Label[] ar4 = l3.ToArray();

            List<Label> r = new List<Label>();
            r.AddRange(ar1);
            r.AddRange(ar2);
            r.AddRange(ar3);
            r.AddRange(ar4);

            this.runningScore.teamANumbers = r.ToArray();


            Label[] br1_1 = (Label[])GetControlArrayByName(this, "label", 375, 378);
            Label[] br1_2 = (Label[])GetControlArrayByName(this, "label", 379, 390);
            Label[] br1_3 = (Label[])GetControlArrayByName(this, "label", 391, 402);
            Label[] br1_4 = (Label[])GetControlArrayByName(this, "label", 403, 414);

            Label br2_1 = label516;
            Label[] br2_2 = (Label[])GetControlArrayByName(this, "label", 537, 556);
            Label[] br2_3 = (Label[])GetControlArrayByName(this, "label", 559, 577);

            Label br3_1 = label679;
            Label[] br3_2 = (Label[])GetControlArrayByName(this, "label", 701, 717);
            Label[] br3_3 = (Label[])GetControlArrayByName(this, "label", 680, 683);
            Label[] br3_4 = (Label[])GetControlArrayByName(this, "label", 721, 738);

            Label br4_1 = label838;
            Label[] br4_2 = (Label[])GetControlArrayByName(this, "label", 859, 878);
            Label[] br4_3 = (Label[])GetControlArrayByName(this, "label", 839, 840);
            Label[] br4_4 = (Label[])GetControlArrayByName(this, "label", 884, 900);

            List<Label> br = new List<Label>();
            br.AddRange(br1_1);
            br.AddRange(br1_2);
            br.AddRange(br1_3);
            br.AddRange(br1_4);
            br.Add(br2_1);
            br.AddRange(br2_2);
            br.AddRange(br2_3);
            br.Add(br3_1);
            br.AddRange(br3_2);
            br.AddRange(br3_3);
            br.AddRange(br3_4);
            br.Add(br4_1);
            br.AddRange(br4_2);
            br.AddRange(br4_3);
            br.AddRange(br4_4);

            this.runningScore.teamAPoints = br.ToArray();


            Label cr1_1 = label415;
            Label[] cr1_2 = (Label[])GetControlArrayByName(this, "label", 416, 436);
            Label[] cr1_3 = (Label[])GetControlArrayByName(this, "label", 440, 457);

            Label cr2_1 = label557;
            Label[] cr2_2 = (Label[])GetControlArrayByName(this, "label", 578, 595);
            Label cr2_3 = label558;
            Label[] cr2_4 = (Label[])GetControlArrayByName(this, "label", 596, 614);
            Label cr2_5 = label615;

            Label cr3_1 = label718;
            Label[] cr3_2 = (Label[])GetControlArrayByName(this, "label", 739, 757);
            Label[] cr3_3 = (Label[])GetControlArrayByName(this, "label", 719, 720);
            Label[] cr3_4 = (Label[])GetControlArrayByName(this, "label", 761, 778);

            Label cr4_1 = label879;
            Label[] cr4_2 = (Label[])GetControlArrayByName(this, "label", 901, 917);
            Label[] cr4_3 = (Label[])GetControlArrayByName(this, "label", 880, 883);
            Label[] cr4_4 = (Label[])GetControlArrayByName(this, "label", 921, 938);

            List<Label> cr = new List<Label>();
            cr.Add(cr1_1);
            cr.AddRange(cr1_2);
            cr.AddRange(cr1_3);
            cr.Add(cr2_1);
            cr.AddRange(cr2_2);
            cr.Add(cr2_3);
            cr.AddRange(cr2_4);
            cr.Add(cr2_5);
            cr.Add(cr3_1);
            cr.AddRange(cr3_2);
            cr.AddRange(cr3_3);
            cr.AddRange(cr3_4);
            cr.Add(cr4_1);
            cr.AddRange(cr4_2);
            cr.AddRange(cr4_3);
            cr.AddRange(cr4_4);

            this.runningScore.teamBPoints = cr.ToArray();


            Label dr1_1 = label437;
            Label[] dr1_2 = (Label[])GetControlArrayByName(this, "label", 458, 475);
            Label[] dr1_3 = (Label[])GetControlArrayByName(this, "label", 438, 439);
            Label[] dr1_4 = (Label[])GetControlArrayByName(this, "label", 477, 495);

            Label dr2_1 = label616;
            Label[] dr2_2 = (Label[])GetControlArrayByName(this, "label", 617, 637);
            Label[] dr2_3 = (Label[])GetControlArrayByName(this, "label", 641, 658);

            Label dr3_1 = label758;
            Label[] dr3_2 = (Label[])GetControlArrayByName(this, "label", 779, 798);
            Label[] dr3_3 = (Label[])GetControlArrayByName(this, "label", 759, 760);
            Label[] dr3_4 = (Label[])GetControlArrayByName(this, "label", 804, 820);

            Label dr4_1 = label918;
            Label[] dr4_2 = (Label[])GetControlArrayByName(this, "label", 939, 957);
            Label[] dr4_3 = (Label[])GetControlArrayByName(this, "label", 919, 920);
            Label[] dr4_4 = (Label[])GetControlArrayByName(this, "label", 961, 978);

            List<Label> dr = new List<Label>();
            dr.Add(dr1_1);
            dr.AddRange(dr1_2);
            dr.AddRange(dr1_3);
            dr.AddRange(dr1_4);
            dr.Add(dr2_1);
            dr.AddRange(dr2_2);
            dr.AddRange(dr2_3);
            dr.Add(dr3_1);
            dr.AddRange(dr3_2);
            dr.AddRange(dr3_3);
            dr.AddRange(dr3_4);
            dr.Add(dr4_1);
            dr.AddRange(dr4_2);
            dr.AddRange(dr4_3);
            dr.AddRange(dr4_4);

            this.runningScore.teamBNumbers = dr.ToArray();

        }

        private void InputBaseInfomation()
        {
            GameNameLabel.Text = game.Name;
            GameDateLabel.Text = game.StartTime.ToString();
            GamePlaceLabel.Text = game.Location;
            MyTeamNameLabel.Text = "チームA" + "\n" + game.MyTeam.Name;
            OppentTeamNameLabel.Text = "チームB" + "\n" + game.OppentTeam.Name;

            for (var i = 0; i <= 4; i++)
            {
                myQuarterPointLabels[i].Text = game.MyTeam.GetQuarterPoint(i + 1).ToString();
                oppentQuarterPointLabels[i].Text = game.OppentTeam.GetQuarterPoint(i + 1).ToString();
            }

            MyResultLabel.Text = game.MyTeam.AllPoint.ToString();
            OppentResultLabel.Text = game.OppentTeam.AllPoint.ToString();
        }

        private void InputMyPlayerInfomation()
        {
            //自チームの入力
            int i = 0;

            foreach (var p in game.MyTeam.TeamMember)
            {
                PlayerInfomation pi = new PlayerInfomation();

                pi.Name = myPlayerNameLabels[i];
                pi.Name.Text = p.Name;

                pi.Number = myPlayerNumberLabels[i];
                pi.Number.Text = p.Number.ToString();

                pi.PlIn = myPlInLabels[i];

                if (p.IsStarter)
                {
                    pi.PlIn.Text = "";

                    //現在のコードを実行しているAssemblyを取得
                    System.Reflection.Assembly _myAssembly =
                        System.Reflection.Assembly.GetExecutingAssembly();
                    //指定されたリソースを読み込む
                    Bitmap bmp =
                        new Bitmap(_myAssembly.GetManifestResourceStream
                            ("BasketballManagementSystem.BMForm.BoxScore.Picture.marubatu2.png"));

                    pi.PlIn.Image = bmp;
                }
                else
                {
                    //以下、その選手がメンバーチェンジを行ったリストの中にいるか判定
                    bool flag = false;

                    foreach (var memberChange in game.MyTeam.MemberChange)
                    {
                        foreach (var changePlayer in memberChange.ChangedOutMembers)
                        {
                            if (changePlayer == p)
                            {
                                flag = true;
                                break;
                            }
                        }

                        if (flag) break;
                    }

                    if (!flag) continue;

                    pi.PlIn.Text = "";
                    //現在のコードを実行しているAssemblyを取得
                    System.Reflection.Assembly _myAssembly =
                        System.Reflection.Assembly.GetExecutingAssembly();
                    //指定されたリソースを読み込む
                    Bitmap bmp =
                        new Bitmap(_myAssembly.GetManifestResourceStream
                            ("BasketballManagementSystem.BMForm.BoxScore.Picture.batu.png"));

                    pi.PlIn.Image = bmp;
                }

                for (var j = 0; j < 5; j++)
                {
                    pi.Fauls[j] = myFaulLines[j, i];

                }

                int k = 0;

                foreach (var f in p.PersonalFaul)
                {
                    if (k > 4) break;
                    string s = string.Empty;
                    if (f.GivenFreeThrow != 0) { s = f.GivenFreeThrow.ToString(); }

                    pi.Fauls[k].Text = "P" + s;

                    if (f.Quarter <= 2)
                    {
                        if (k != 0) { pi.Fauls[k - 1].BackColor = Control.DefaultBackColor; }
                        pi.Fauls[k].BackColor = Color.Red;
                    }
                    k++;
                }

                foreach (var f in p.TechnicalFaul)
                {
                    if (k > 4) break;
                    string s = string.Empty;
                    if (f.GivenFreeThrow != 0) { s = f.GivenFreeThrow.ToString(); }

                    pi.Fauls[k].Text = "T" + s;

                    if (f.Quarter <= 2)
                    {
                        if (k != 0) { pi.Fauls[k - 1].BackColor = Control.DefaultBackColor; }
                        pi.Fauls[k].BackColor = Color.Red;
                    }
                    k++;

                }

                foreach (var f in p.DisQualifyingFaul)
                {
                    if (k > 4) break;

                    string s = string.Empty;
                    if (f.GivenFreeThrow != 0) { s = f.GivenFreeThrow.ToString(); }

                    pi.Fauls[k].Text = "D" + s;

                    if (f.Quarter <= 2)
                    {
                        if (k != 0) { pi.Fauls[k - 1].BackColor = Control.DefaultBackColor; }
                        pi.Fauls[k].BackColor = Color.Red;
                    }
                    k++;

                }

                foreach (var f in p.UnSportsmanLikeFaul)
                {
                    if (k > 4) break;
                    string s = string.Empty;
                    if (f.GivenFreeThrow != 0) { s = f.GivenFreeThrow.ToString(); }

                    pi.Fauls[k].Text = "U" + s;

                    if (f.Quarter <= 2)
                    {
                        if (k != 0) { pi.Fauls[k - 1].BackColor = Control.DefaultBackColor; }
                        pi.Fauls[k].BackColor = Color.Red;
                    }
                    k++;

                }

                i++;
            }

            for (var l = 0; l < PlayerNumber; l++)
            {
                for (var m = 0; m < 5; m++)
                {
                    if (myFaulLines[m, l].Text == "0")
                    {
                        //現在のコードを実行しているAssemblyを取得
                        System.Reflection.Assembly myAssembly =
                            System.Reflection.Assembly.GetExecutingAssembly();
                        //指定されたリソースを読み込む
                        Bitmap bmp =
                            new Bitmap(myAssembly.GetManifestResourceStream
                                ("BasketballManagementSystem.BMForm.BoxScore.Picture.bar.png"));

                        myFaulLines[m, l].Text = "";
                        myFaulLines[m, l].Image = bmp;
                    }

                }
            }

        }

        private void InputOppentPlayerInfomation()
        {
            //相手チームの入力

            int i = 0;

            foreach (var p in game.OppentTeam.TeamMember)
            {
                PlayerInfomation pl = new PlayerInfomation();

                pl.Name = oppentPlayerNameLabels[i];
                pl.Name.Text = p.Name;

                pl.Number = oppentPlayerNumberLabels[i];
                pl.Number.Text = p.Number.ToString();

                pl.PlIn = oppentPlInLabels[i];

                if (p.IsStarter)
                {
                    pl.PlIn.Text = "";

                    //現在のコードを実行しているAssemblyを取得
                    System.Reflection.Assembly oppentAssembly =
                        System.Reflection.Assembly.GetExecutingAssembly();
                    //指定されたリソースを読み込む
                    Bitmap bmp =
                        new Bitmap(oppentAssembly.GetManifestResourceStream
                            ("BasketballManagementSystem.BMForm.BoxScore.Picture.marubatu2.png"));

                    pl.PlIn.Image = bmp;
                }
                //TODO:これだとなんもアクションしてないけど途中出場している選手がいた場合に反応しない
                else
                {
                    //以下、その選手がメンバーチェンジを行ったリストの中にいるか判定
                    bool flag = false;

                    foreach (var memberChange in game.OppentTeam.MemberChange)
                    {
                        foreach (var changePlayer in memberChange.ChangedOutMembers)
                        {
                            if (changePlayer == p)
                            {
                                flag = true;
                                break;
                            }
                        }

                        if (flag) break;
                    }

                    if (!flag) continue;

                    pl.PlIn.Text = "";
                    //現在のコードを実行しているAssemblyを取得
                    System.Reflection.Assembly oppentAssembly =
                        System.Reflection.Assembly.GetExecutingAssembly();
                    //指定されたリソースを読み込む
                    Bitmap bmp =
                        new Bitmap(oppentAssembly.GetManifestResourceStream
                            ("BasketballManagementSystem.BMForm.BoxScore.Picture.batu.png"));

                    pl.PlIn.Image = bmp;
                }

                for (var j = 0; j < 5; j++)
                {
                    pl.Fauls[j] = oppentFaulLines[j, i];

                }

                int k = 0;

                foreach (var f in p.PersonalFaul)
                {
                    if (k > 4) break;
                    string s = string.Empty;
                    if (f.GivenFreeThrow != 0) { s = f.GivenFreeThrow.ToString(); }

                    pl.Fauls[k].Text = "P" + s;

                    if (f.Quarter <= 2)
                    {
                        if (k != 0) { pl.Fauls[k - 1].BackColor = Control.DefaultBackColor; }
                        pl.Fauls[k].BackColor = Color.Red;
                    }
                    k++;
                }

                foreach (var f in p.TechnicalFaul)
                {
                    if (k > 4) break;
                    string s = string.Empty;
                    if (f.GivenFreeThrow != 0) { s = f.GivenFreeThrow.ToString(); }

                    pl.Fauls[k].Text = "T" + s;

                    if (f.Quarter <= 2)
                    {
                        if (k != 0) { pl.Fauls[k - 1].BackColor = Control.DefaultBackColor; }
                        pl.Fauls[k].BackColor = Color.Red;
                    }
                    k++;

                }

                foreach (var f in p.DisQualifyingFaul)
                {
                    if (k > 4) break;
                    string s = string.Empty;
                    if (f.GivenFreeThrow != 0) { s = f.GivenFreeThrow.ToString(); }

                    pl.Fauls[k].Text = "D" + s;

                    if (f.Quarter <= 2)
                    {
                        if (k != 0) { pl.Fauls[k - 1].BackColor = Control.DefaultBackColor; }
                        pl.Fauls[k].BackColor = Color.Red;
                    }
                    k++;

                }

                foreach (var f in p.UnSportsmanLikeFaul)
                {
                    if (k > 4) break;
                    string s = string.Empty;
                    if (f.GivenFreeThrow != 0) { s = f.GivenFreeThrow.ToString(); }

                    pl.Fauls[k].Text = "U" + s;

                    if (f.Quarter <= 2)
                    {
                        if (k != 0) { pl.Fauls[k - 1].BackColor = Control.DefaultBackColor; }
                        pl.Fauls[k].BackColor = Color.Red;
                    }
                    k++;

                }

                i++;
            }

            for (var l = 0; l < PlayerNumber; l++)
            {
                for (var m = 0; m < 5; m++)
                {
                    if (oppentFaulLines[m, l].Text == "0")
                    {
                        //現在のコードを実行しているAssemblyを取得
                        System.Reflection.Assembly oppentAssembly =
                            System.Reflection.Assembly.GetExecutingAssembly();
                        //指定されたリソースを読み込む
                        Bitmap bmp =
                            new Bitmap(oppentAssembly.GetManifestResourceStream
                                ("BasketballManagementSystem.BMForm.BoxScore.Picture.bar.png"));

                        oppentFaulLines[m, l].Text = "";
                        oppentFaulLines[m, l].Image = bmp;
                    }

                }
            }
        }

        private void InputTeamFaulLabel()
        {
            //現在のコードを実行しているAssemblyを取得
            System.Reflection.Assembly assembly =
                System.Reflection.Assembly.GetExecutingAssembly();
            //指定されたリソースを読み込む
            Bitmap bmp =
                new Bitmap(assembly.GetManifestResourceStream
                    ("BasketballManagementSystem.BMForm.BoxScore.Picture.batu_touka.png"));

            for (var i = 0; i < 4; i++)
            {
                for (var j = 0; j < game.MyTeam.TeamFaul[i + 1]; j++)
                {
                    if (j > 3) break;
                    myTeamFaulLabels[i, j].Image = bmp;
                }
            }

            for (var i = 0; i < 4; i++)
            {
                for (var j = 0; j < game.OppentTeam.TeamFaul[i + 1]; j++)
                {
                    if (j > 3) break;
                    oppentTeamFaulLabels[i, j].Image = bmp;
                }
            }
            
        }

        private void InputTimeOutLabel()
        {
            int i = 0;
            bool firstFlag = true;

            //現在のコードを実行しているAssemblyを取得
                        System.Reflection.Assembly assembly =
                            System.Reflection.Assembly.GetExecutingAssembly();
                        //指定されたリソースを読み込む
                        Bitmap bmp =
                            new Bitmap(assembly.GetManifestResourceStream
                                ("BasketballManagementSystem.BMForm.BoxScore.Picture.batu_touka.png"));

            foreach (var t in game.MyTeam.TimeOutList)
            {

                if (t.Quarter >= 3 && t.Quarter <= 4 && firstFlag)
                {
                    i = 2;
                    firstFlag = false;
                }

                if (t.Quarter == 5)
                {
                    i = 5;
                }

                if (t.Quarter == 6)
                {
                    i = 6;
                }

                myTeamTimeOutLabels[i].Image = bmp;
                i++;

                if (i > 6)
                {
                    break;
                }
            }

            Bitmap bmp2 = new Bitmap(assembly.GetManifestResourceStream
                               ("BasketballManagementSystem.BMForm.BoxScore.Picture.redDualLine.png"));

            for (var j = 0; j < myTeamTimeOutLabels.Count(); j++)
            {
                if (myTeamTimeOutLabels[j].Image != bmp)
                {
                    myTeamTimeOutLabels[j].Image = bmp2;
                }
            }


             i = 0;
            firstFlag = true;

            foreach (var t in game.OppentTeam.TimeOutList)
            {

                if (t.Quarter >= 3 && t.Quarter <= 4 && firstFlag)
                {
                    i = 2;
                    firstFlag = false;
                }

                if (t.Quarter == 5)
                {
                    i = 5;
                }

                if (t.Quarter == 6)
                {
                    i = 6;
                }

                oppentTeamTimeOutLabels[i].Image = bmp;
                i++;

                if (i > 6)
                {
                    break;
                }
            }

            for (var j = 0; j < oppentTeamTimeOutLabels.Count(); j++)
            {
                if (oppentTeamTimeOutLabels[j].Image != bmp)
                {
                    oppentTeamTimeOutLabels[j].Image = bmp2;
                }
            }
        }

        private void InputRunningScore()
        {
            runningScore.Init();
            
            foreach (var r in ActionListConverter.ToRelationPointActionList(this.game.MyTeam.GetActionAll()))
            {
                this.runningScore.InputRunningScoreA(r, r.OwnerNumber);
            }

            foreach (var r in ActionListConverter.ToRelationPointActionList(this.game.OppentTeam.GetActionAll()))
            {
                this.runningScore.InputRunningScoreB(r, r.OwnerNumber);
            }
        }

        private void PrintForm_Click(object sender, EventArgs e)
        {
            FormPrinter fp = new FormPrinter();
            fp.PrintForm(this);
        }

        private void PrintPreview_Click(object sender, EventArgs e)
        {
            FormPrinter fp = new FormPrinter();
            fp.ShowPrintPreview(this);
        }
    }

}


