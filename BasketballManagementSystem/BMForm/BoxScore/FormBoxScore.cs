using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BasketballManagementSystem.BaseClass.Game;
using BasketballManagementSystem.Manager.SaveDataManager;
using System.Collections;
using BasketballManagementSystem.BaseClass.Player;
using BasketballManagementSystem.BaseClass.Action;
using BasketballManagementSystem.BaseClass.TimeOut;
using BasketballManagementSystem.Manager.PrintManager;

namespace BasketballManagementSystem.BMForm.BoxScore
{
    public partial class FormBoxScore : Form
    {
        /// <summary>
        /// スコアシートのプレイヤーの人数
        /// </summary>
        private const int playerNumber = 18;
        private const int faulLineNumber = 5;

        private Game game = new Game();

        private Label[] myQuarterPointLabels = new Label[5];
        private Label[] oppentQuarterPointLabels = new Label[5];

        private Label[] myPlayerNameLabels = new Label[playerNumber];

        private Label[] oppentPlayerNameLabels = new Label[playerNumber];

        private Label[] myPlayerNumberLabels = new Label[playerNumber];

        private Label[] oppentPlayerNumberLabels = new Label[playerNumber];

        private Label[] myPlInLabels = new Label[playerNumber];

        private Label[] oppentPlInLabels = new Label[playerNumber];

        private Label[,] myFaulLines = new Label[faulLineNumber, playerNumber];

        private Label[,] oppentFaulLines = new Label[faulLineNumber, playerNumber];

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

            object _obj;

            for (int _i = number1; _i <= number2; _i++)
            {
                _obj = FindControlByFieldName(frm, name + _i.ToString());
                ctrs.Add(_obj);
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
            System.Type _t = frm.GetType();

            System.Reflection.FieldInfo fi = _t.GetField(
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
                int _s1 = ((Label)x).Location.Y;
                int _s2 = ((Label)y).Location.Y;

                return _s1.CompareTo(_s2);
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

            Label[] _ar1 = (Label[])GetControlArrayByName(this, "label", 109, 126);
            Label[] _ar2 = (Label[])GetControlArrayByName(this, "label", 127, 144);
            Label[] _ar3 = (Label[])GetControlArrayByName(this, "label", 181, 198);
            Label[] _ar4 = (Label[])GetControlArrayByName(this, "label", 163, 180);
            Label[] _ar5 = (Label[])GetControlArrayByName(this, "label", 145, 162);

            Label[] _ar6 = (Label[])GetControlArrayByName(this, "label", 199, 216);
            Label[] _ar7 = (Label[])GetControlArrayByName(this, "label", 253, 270);
            Label[] _ar8 = (Label[])GetControlArrayByName(this, "label", 271, 288);
            Label[] _ar9 = (Label[])GetControlArrayByName(this, "label", 235, 252);
            Label[] _ar10 = (Label[])GetControlArrayByName(this, "label", 217, 234);

            for (int _i = 0; _i < playerNumber; _i++)
            {
                myFaulLines[0, _i] = _ar1[_i];
            }

            for (int _i = 0; _i < playerNumber; _i++)
            {
                myFaulLines[1, _i] = _ar2[_i];
            }

            for (int _i = 0; _i < playerNumber; _i++)
            {
                myFaulLines[2, _i] = _ar3[_i];
            }

            for (int _i = 0; _i < playerNumber; _i++)
            {
                myFaulLines[3, _i] = _ar4[_i];
            }

            for (int _i = 0; _i < playerNumber; _i++)
            {
                myFaulLines[4, _i] = _ar5[_i];
            }

            for (int _i = 0; _i < playerNumber; _i++)
            {
                oppentFaulLines[0, _i] = _ar6[_i];
            }

            for (int _i = 0; _i < playerNumber; _i++)
            {
                oppentFaulLines[1, _i] = _ar7[_i];
            }

            for (int _i = 0; _i < playerNumber; _i++)
            {
                oppentFaulLines[2, _i] = _ar8[_i];
            }

            for (int _i = 0; _i < playerNumber; _i++)
            {
                oppentFaulLines[3, _i] = _ar9[_i];
            }

            for (int _i = 0; _i < playerNumber; _i++)
            {
                oppentFaulLines[4, _i] = _ar10[_i];
            }
        }

        private void TeamFaulLabelInit()
        {
            Label[] _ar1 = (Label[])GetControlArrayByName(this, "label", 289, 292);
            Label[] _ar2 = (Label[])GetControlArrayByName(this, "label", 293, 296);
            Label[] _ar3 = (Label[])GetControlArrayByName(this, "label", 297, 300);
            Label[] _ar4 = (Label[])GetControlArrayByName(this, "label", 301, 304);

            Label[] _ar5 = (Label[])GetControlArrayByName(this, "label", 305, 308);
            Label[] _ar6 = (Label[])GetControlArrayByName(this, "label", 309, 312);
            Label[] _ar7 = (Label[])GetControlArrayByName(this, "label", 313, 316);
            Label[] _ar8 = (Label[])GetControlArrayByName(this, "label", 317, 320);

            for (int _i = 0; _i < 4; _i++)
            {
                myTeamFaulLabels[0, _i] = _ar1[_i];
            }

            for (int _i = 0; _i < 4; _i++)
            {
                myTeamFaulLabels[1, _i] = _ar2[_i];
            }

            for (int _i = 0; _i < 4; _i++)
            {
                myTeamFaulLabels[2, _i] = _ar3[_i];
            }

            for (int _i = 0; _i < 4; _i++)
            {
                myTeamFaulLabels[3, _i] = _ar4[_i];
            }

            for (int _i = 0; _i < 4; _i++)
            {
                oppentTeamFaulLabels[0, _i] = _ar5[_i];
            }

            for (int _i = 0; _i < 4; _i++)
            {
                oppentTeamFaulLabels[1, _i] = _ar6[_i];
            }

            for (int _i = 0; _i < 4; _i++)
            {
                oppentTeamFaulLabels[2, _i] = _ar7[_i];
            }

            for (int _i = 0; _i < 4; _i++)
            {
                oppentTeamFaulLabels[3, _i] = _ar8[_i];
            }
        }

        private void TimeOutLabelInit()
        {
            myTeamTimeOutLabels = (Label[])GetControlArrayByName(this, "label", 321, 327);
            oppentTeamTimeOutLabels = (Label[])GetControlArrayByName(this, "label", 328, 334);
        }

        private void RunningScoreInit()
        {
            Label[] _ar1 = (Label[])GetControlArrayByName(this, "label", 335, 374);

            Label _ar2_1 = label476;
            Label[] _ar2_2 = (Label[])GetControlArrayByName(this, "label", 517, 535);
            Label[] _ar2_3 = (Label[])GetControlArrayByName(this, "label", 496, 515);
            List<Label> _l = new List<Label>();
            _l.Add(_ar2_1);
            _l.AddRange(_ar2_2);
            _l.AddRange(_ar2_3);
            Label[] _ar2 = _l.ToArray();

            Label _ar3_1 = label638;
            Label[] _ar3_2 = (Label[])GetControlArrayByName(this, "label", 659, 678);
            Label[] _ar3_3 = (Label[])GetControlArrayByName(this, "label", 639, 640);
            Label[] _ar3_4 = (Label[])GetControlArrayByName(this, "label", 684, 700);
            List<Label> _l2 = new List<Label>();
            _l2.Add(_ar3_1);
            _l2.AddRange(_ar3_2);
            _l2.AddRange(_ar3_3);
            _l2.AddRange(_ar3_4);
            Label[] _ar3 = _l2.ToArray();

            Label _ar4_1 = label799;
            Label[] _ar4_2 = (Label[])GetControlArrayByName(this, "label", 821, 837);
            Label[] _ar4_3 = (Label[])GetControlArrayByName(this, "label", 800, 803);
            Label[] _ar4_4 = (Label[])GetControlArrayByName(this, "label", 841, 858);
            List<Label> _l3 = new List<Label>();
            _l3.Add(_ar4_1);
            _l3.AddRange(_ar4_2);
            _l3.AddRange(_ar4_3);
            _l3.AddRange(_ar4_4);
            Label[] _ar4 = _l3.ToArray();

            List<Label> _r = new List<Label>();
            _r.AddRange(_ar1);
            _r.AddRange(_ar2);
            _r.AddRange(_ar3);
            _r.AddRange(_ar4);

            this.runningScore.teamANumber = _r.ToArray();


            Label[] _br1_1 = (Label[])GetControlArrayByName(this, "label", 375, 378);
            Label[] _br1_2 = (Label[])GetControlArrayByName(this, "label", 379, 390);
            Label[] _br1_3 = (Label[])GetControlArrayByName(this, "label", 391, 402);
            Label[] _br1_4 = (Label[])GetControlArrayByName(this, "label", 403, 414);

            Label _br2_1 = label516;
            Label[] _br2_2 = (Label[])GetControlArrayByName(this, "label", 537, 556);
            Label[] _br2_3 = (Label[])GetControlArrayByName(this, "label", 559, 577);

            Label _br3_1 = label679;
            Label[] _br3_2 = (Label[])GetControlArrayByName(this, "label", 701, 717);
            Label[] _br3_3 = (Label[])GetControlArrayByName(this, "label", 680, 683);
            Label[] _br3_4 = (Label[])GetControlArrayByName(this, "label", 721, 738);

            Label _br4_1 = label838;
            Label[] _br4_2 = (Label[])GetControlArrayByName(this, "label", 859, 878);
            Label[] _br4_3 = (Label[])GetControlArrayByName(this, "label", 839, 840);
            Label[] _br4_4 = (Label[])GetControlArrayByName(this, "label", 884, 900);

            List<Label> _br = new List<Label>();
            _br.AddRange(_br1_1);
            _br.AddRange(_br1_2);
            _br.AddRange(_br1_3);
            _br.AddRange(_br1_4);
            _br.Add(_br2_1);
            _br.AddRange(_br2_2);
            _br.AddRange(_br2_3);
            _br.Add(_br3_1);
            _br.AddRange(_br3_2);
            _br.AddRange(_br3_3);
            _br.AddRange(_br3_4);
            _br.Add(_br4_1);
            _br.AddRange(_br4_2);
            _br.AddRange(_br4_3);
            _br.AddRange(_br4_4);

            this.runningScore.teamAPoint = _br.ToArray();


            Label _cr1_1 = label415;
            Label[] _cr1_2 = (Label[])GetControlArrayByName(this, "label", 416, 436);
            Label[] _cr1_3 = (Label[])GetControlArrayByName(this, "label", 440, 457);

            Label _cr2_1 = label557;
            Label[] _cr2_2 = (Label[])GetControlArrayByName(this, "label", 578, 595);
            Label _cr2_3 = label558;
            Label[] _cr2_4 = (Label[])GetControlArrayByName(this, "label", 596, 614);
            Label _cr2_5 = label615;

            Label _cr3_1 = label718;
            Label[] _cr3_2 = (Label[])GetControlArrayByName(this, "label", 739, 757);
            Label[] _cr3_3 = (Label[])GetControlArrayByName(this, "label", 719, 720);
            Label[] _cr3_4 = (Label[])GetControlArrayByName(this, "label", 761, 778);

            Label _cr4_1 = label879;
            Label[] _cr4_2 = (Label[])GetControlArrayByName(this, "label", 901, 917);
            Label[] _cr4_3 = (Label[])GetControlArrayByName(this, "label", 880, 883);
            Label[] _cr4_4 = (Label[])GetControlArrayByName(this, "label", 921, 938);

            List<Label> _cr = new List<Label>();
            _cr.Add(_cr1_1);
            _cr.AddRange(_cr1_2);
            _cr.AddRange(_cr1_3);
            _cr.Add(_cr2_1);
            _cr.AddRange(_cr2_2);
            _cr.Add(_cr2_3);
            _cr.AddRange(_cr2_4);
            _cr.Add(_cr2_5);
            _cr.Add(_cr3_1);
            _cr.AddRange(_cr3_2);
            _cr.AddRange(_cr3_3);
            _cr.AddRange(_cr3_4);
            _cr.Add(_cr4_1);
            _cr.AddRange(_cr4_2);
            _cr.AddRange(_cr4_3);
            _cr.AddRange(_cr4_4);

            this.runningScore.teamBPoint = _cr.ToArray();


            Label _dr1_1 = label437;
            Label[] _dr1_2 = (Label[])GetControlArrayByName(this, "label", 458, 475);
            Label[] _dr1_3 = (Label[])GetControlArrayByName(this, "label", 438, 439);
            Label[] _dr1_4 = (Label[])GetControlArrayByName(this, "label", 477, 495);

            Label _dr2_1 = label616;
            Label[] _dr2_2 = (Label[])GetControlArrayByName(this, "label", 617, 637);
            Label[] _dr2_3 = (Label[])GetControlArrayByName(this, "label", 641, 658);

            Label _dr3_1 = label758;
            Label[] _dr3_2 = (Label[])GetControlArrayByName(this, "label", 779, 798);
            Label[] _dr3_3 = (Label[])GetControlArrayByName(this, "label", 759, 760);
            Label[] _dr3_4 = (Label[])GetControlArrayByName(this, "label", 804, 820);

            Label _dr4_1 = label918;
            Label[] _dr4_2 = (Label[])GetControlArrayByName(this, "label", 939, 957);
            Label[] _dr4_3 = (Label[])GetControlArrayByName(this, "label", 919, 920);
            Label[] _dr4_4 = (Label[])GetControlArrayByName(this, "label", 961, 978);

            List<Label> _dr = new List<Label>();
            _dr.Add(_dr1_1);
            _dr.AddRange(_dr1_2);
            _dr.AddRange(_dr1_3);
            _dr.AddRange(_dr1_4);
            _dr.Add(_dr2_1);
            _dr.AddRange(_dr2_2);
            _dr.AddRange(_dr2_3);
            _dr.Add(_dr3_1);
            _dr.AddRange(_dr3_2);
            _dr.AddRange(_dr3_3);
            _dr.AddRange(_dr3_4);
            _dr.Add(_dr4_1);
            _dr.AddRange(_dr4_2);
            _dr.AddRange(_dr4_3);
            _dr.AddRange(_dr4_4);

            this.runningScore.teamBNumber = _dr.ToArray();

        }

        private void InputBaseInfomation()
        {
            GameName.Text = game.Name;
            GameDate.Text = game.StartTime.ToString();
            GamePlace.Text = game.Location;
            MyTeamName.Text = "チームA" + "\n" + game.MyTeam.Name;
            OppentTeamName.Text = "チームB" + "\n" + game.OppentTeam.Name;

            for (int _i = 0; _i <= 4; _i++)
            {
                myQuarterPointLabels[_i].Text = game.MyTeam.GetQuarterPoint(_i + 1).ToString();
                oppentQuarterPointLabels[_i].Text = game.OppentTeam.GetQuarterPoint(_i + 1).ToString();
            }

            MyResult.Text = game.MyTeam.AllPoint.ToString();
            OppentResult.Text = game.OppentTeam.AllPoint.ToString();
        }

        private void InputMyPlayerInfomation()
        {
            //自チームの入力
            int _i = 0;

            foreach (Player _p in game.MyTeam.TeamMember)
            {
                PlayerInfomation _pl = new PlayerInfomation();

                _pl.Name = myPlayerNameLabels[_i];
                _pl.Name.Text = _p.Name;

                _pl.Number = myPlayerNumberLabels[_i];
                _pl.Number.Text = _p.Number.ToString();

                _pl.PlIn = myPlInLabels[_i];

                if (_p.IsStarter)
                {
                    _pl.PlIn.Text = "";

                    //現在のコードを実行しているAssemblyを取得
                    System.Reflection.Assembly _myAssembly =
                        System.Reflection.Assembly.GetExecutingAssembly();
                    //指定されたリソースを読み込む
                    Bitmap _bmp =
                        new Bitmap(_myAssembly.GetManifestResourceStream
                            ("BasketballManagementSystem.BMForm.BoxScore.Picture.marubatu2.png"));

                    _pl.PlIn.Image = _bmp;
                }
                //TODO:これだとなんもアクションしてないけど途中出場している選手がいた場合に反応しない(memberchange情報を使ったほうがいい)
                else if (_p.GetActionList(_p).Count > 0)
                {
                    _pl.PlIn.Text = "";
                    //現在のコードを実行しているAssemblyを取得
                    System.Reflection.Assembly _myAssembly =
                        System.Reflection.Assembly.GetExecutingAssembly();
                    //指定されたリソースを読み込む
                    Bitmap _bmp =
                        new Bitmap(_myAssembly.GetManifestResourceStream
                            ("BasketballManagementSystem.BMForm.BoxScore.Picture.batu.png"));

                    _pl.PlIn.Image = _bmp;
                }

                for (int _j = 0; _j < 5; _j++)
                {
                    _pl.Fauls[_j] = myFaulLines[_j, _i];

                }

                int _k = 0;

                foreach (Faul _f in _p.PersonalFaul)
                {
                    if (_k > 4) break;
                    string _s = string.Empty;
                    if (_f.GivenFreeThrow != 0) { _s = _f.GivenFreeThrow.ToString(); }

                    _pl.Fauls[_k].Text = "P" + _s;

                    if (_f.Quarter <= 2)
                    {
                        if (_k != 0) { _pl.Fauls[_k - 1].BackColor = Control.DefaultBackColor; }
                        _pl.Fauls[_k].BackColor = Color.Red;
                    }
                    _k++;
                }

                foreach (Faul _f in _p.TechnicalFaul)
                {
                    if (_k > 4) break;
                    string _s = string.Empty;
                    if (_f.GivenFreeThrow != 0) { _s = _f.GivenFreeThrow.ToString(); }

                    _pl.Fauls[_k].Text = "T" + _s;

                    if (_f.Quarter <= 2)
                    {
                        if (_k != 0) { _pl.Fauls[_k - 1].BackColor = Control.DefaultBackColor; }
                        _pl.Fauls[_k].BackColor = Color.Red;
                    }
                    _k++;

                }

                foreach (Faul _f in _p.DisQualifyingFaul)
                {
                    if (_k > 4) break;

                    string _s = string.Empty;
                    if (_f.GivenFreeThrow != 0) { _s = _f.GivenFreeThrow.ToString(); }

                    _pl.Fauls[_k].Text = "D" + _s;

                    if (_f.Quarter <= 2)
                    {
                        if (_k != 0) { _pl.Fauls[_k - 1].BackColor = Control.DefaultBackColor; }
                        _pl.Fauls[_k].BackColor = Color.Red;
                    }
                    _k++;

                }

                foreach (Faul _f in _p.UnSportsmanLikeFaul)
                {
                    if (_k > 4) break;
                    string _s = string.Empty;
                    if (_f.GivenFreeThrow != 0) { _s = _f.GivenFreeThrow.ToString(); }

                    _pl.Fauls[_k].Text = "U" + _s;

                    if (_f.Quarter <= 2)
                    {
                        if (_k != 0) { _pl.Fauls[_k - 1].BackColor = Control.DefaultBackColor; }
                        _pl.Fauls[_k].BackColor = Color.Red;
                    }
                    _k++;

                }

                _i++;
            }

            for (int _l = 0; _l < playerNumber; _l++)
            {
                for (int _m = 0; _m < 5; _m++)
                {
                    if (myFaulLines[_m, _l].Text == "0")
                    {
                        //現在のコードを実行しているAssemblyを取得
                        System.Reflection.Assembly _myAssembly =
                            System.Reflection.Assembly.GetExecutingAssembly();
                        //指定されたリソースを読み込む
                        Bitmap _bmp =
                            new Bitmap(_myAssembly.GetManifestResourceStream
                                ("BasketballManagementSystem.BMForm.BoxScore.Picture.bar.png"));

                        myFaulLines[_m, _l].Text = "";
                        myFaulLines[_m, _l].Image = _bmp;
                    }

                }
            }

        }

        private void InputOppentPlayerInfomation()
        {
            //相手チームの入力

            int _i = 0;

            foreach (Player _p in game.OppentTeam.TeamMember)
            {
                PlayerInfomation _pl = new PlayerInfomation();

                _pl.Name = oppentPlayerNameLabels[_i];
                _pl.Name.Text = _p.Name;

                _pl.Number = oppentPlayerNumberLabels[_i];
                _pl.Number.Text = _p.Number.ToString();

                _pl.PlIn = oppentPlInLabels[_i];

                if (_p.IsStarter)
                {
                    _pl.PlIn.Text = "";

                    //現在のコードを実行しているAssemblyを取得
                    System.Reflection.Assembly _oppentAssembly =
                        System.Reflection.Assembly.GetExecutingAssembly();
                    //指定されたリソースを読み込む
                    Bitmap _bmp =
                        new Bitmap(_oppentAssembly.GetManifestResourceStream
                            ("BasketballManagementSystem.BMForm.BoxScore.Picture.marubatu2.png"));

                    _pl.PlIn.Image = _bmp;
                }
                //TODO:これだとなんもアクションしてないけど途中出場している選手がいた場合に反応しない
                else if (_p.GetActionList(_p).Count > 0)
                {
                    _pl.PlIn.Text = "";
                    //現在のコードを実行しているAssemblyを取得
                    System.Reflection.Assembly _oppentAssembly =
                        System.Reflection.Assembly.GetExecutingAssembly();
                    //指定されたリソースを読み込む
                    Bitmap _bmp =
                        new Bitmap(_oppentAssembly.GetManifestResourceStream
                            ("BasketballManagementSystem.BMForm.BoxScore.Picture.batu.png"));

                    _pl.PlIn.Image = _bmp;
                }

                for (int _j = 0; _j < 5; _j++)
                {
                    _pl.Fauls[_j] = oppentFaulLines[_j, _i];

                }

                int _k = 0;

                foreach (Faul _f in _p.PersonalFaul)
                {
                    if (_k > 4) break;
                    string _s = string.Empty;
                    if (_f.GivenFreeThrow != 0) { _s = _f.GivenFreeThrow.ToString(); }

                    _pl.Fauls[_k].Text = "P" + _s;

                    if (_f.Quarter <= 2)
                    {
                        if (_k != 0) { _pl.Fauls[_k - 1].BackColor = Control.DefaultBackColor; }
                        _pl.Fauls[_k].BackColor = Color.Red;
                    }
                    _k++;
                }

                foreach (Faul _f in _p.TechnicalFaul)
                {
                    if (_k > 4) break;
                    string s = string.Empty;
                    if (_f.GivenFreeThrow != 0) { s = _f.GivenFreeThrow.ToString(); }

                    _pl.Fauls[_k].Text = "T" + s;

                    if (_f.Quarter <= 2)
                    {
                        if (_k != 0) { _pl.Fauls[_k - 1].BackColor = Control.DefaultBackColor; }
                        _pl.Fauls[_k].BackColor = Color.Red;
                    }
                    _k++;

                }

                foreach (Faul _f in _p.DisQualifyingFaul)
                {
                    if (_k > 4) break;
                    string _s = string.Empty;
                    if (_f.GivenFreeThrow != 0) { _s = _f.GivenFreeThrow.ToString(); }

                    _pl.Fauls[_k].Text = "D" + _s;

                    if (_f.Quarter <= 2)
                    {
                        if (_k != 0) { _pl.Fauls[_k - 1].BackColor = Control.DefaultBackColor; }
                        _pl.Fauls[_k].BackColor = Color.Red;
                    }
                    _k++;

                }

                foreach (Faul _f in _p.UnSportsmanLikeFaul)
                {
                    if (_k > 4) break;
                    string _s = string.Empty;
                    if (_f.GivenFreeThrow != 0) { _s = _f.GivenFreeThrow.ToString(); }

                    _pl.Fauls[_k].Text = "U" + _s;

                    if (_f.Quarter <= 2)
                    {
                        if (_k != 0) { _pl.Fauls[_k - 1].BackColor = Control.DefaultBackColor; }
                        _pl.Fauls[_k].BackColor = Color.Red;
                    }
                    _k++;

                }

                _i++;
            }

            for (int _l = 0; _l < playerNumber; _l++)
            {
                for (int _m = 0; _m < 5; _m++)
                {
                    if (oppentFaulLines[_m, _l].Text == "0")
                    {
                        //現在のコードを実行しているAssemblyを取得
                        System.Reflection.Assembly _oppentAssembly =
                            System.Reflection.Assembly.GetExecutingAssembly();
                        //指定されたリソースを読み込む
                        Bitmap _bmp =
                            new Bitmap(_oppentAssembly.GetManifestResourceStream
                                ("BasketballManagementSystem.BMForm.BoxScore.Picture.bar.png"));

                        oppentFaulLines[_m, _l].Text = "";
                        oppentFaulLines[_m, _l].Image = _bmp;
                    }

                }
            }
        }

        private void InputTeamFaulLabel()
        {
            //現在のコードを実行しているAssemblyを取得
            System.Reflection.Assembly _assembly =
                System.Reflection.Assembly.GetExecutingAssembly();
            //指定されたリソースを読み込む
            Bitmap _bmp =
                new Bitmap(_assembly.GetManifestResourceStream
                    ("BasketballManagementSystem.BMForm.BoxScore.Picture.batu_touka.png"));

            for (int _i = 0; _i < 4; _i++)
            {
                for (int _j = 0; _j < game.MyTeam.TeamFaul[_i + 1]; _j++)
                {
                    if (_j > 3) break;
                    myTeamFaulLabels[_i, _j].Image = _bmp;
                }
            }

            for (int _i = 0; _i < 4; _i++)
            {
                for (int _j = 0; _j < game.OppentTeam.TeamFaul[_i + 1]; _j++)
                {
                    if (_j > 3) break;
                    oppentTeamFaulLabels[_i, _j].Image = _bmp;
                }
            }
            
        }

        private void InputTimeOutLabel()
        {
            int _i = 0;
            bool _firstFlag = true;

            //現在のコードを実行しているAssemblyを取得
                        System.Reflection.Assembly _assembly =
                            System.Reflection.Assembly.GetExecutingAssembly();
                        //指定されたリソースを読み込む
                        Bitmap _bmp =
                            new Bitmap(_assembly.GetManifestResourceStream
                                ("BasketballManagementSystem.BMForm.BoxScore.Picture.batu_touka.png"));

            foreach (TimeOut _t in game.MyTeam.TimeOutList)
            {

                if (_t.Quarter >= 3 && _t.Quarter <= 4 && _firstFlag)
                {
                    _i = 2;
                    _firstFlag = false;
                }

                if (_t.Quarter == 5)
                {
                    _i = 5;
                }

                if (_t.Quarter == 6)
                {
                    _i = 6;
                }

                myTeamTimeOutLabels[_i].Image = _bmp;
                _i++;

                if (_i > 6)
                {
                    break;
                }
            }

            Bitmap _bmp2 = new Bitmap(_assembly.GetManifestResourceStream
                               ("BasketballManagementSystem.BMForm.BoxScore.Picture.redDualLine.png"));

            for (int _j = 0; _j < myTeamTimeOutLabels.Count(); _j++)
            {
                if (myTeamTimeOutLabels[_j].Image != _bmp)
                {
                    myTeamTimeOutLabels[_j].Image = _bmp2;
                }
            }


             _i = 0;
            _firstFlag = true;

            foreach (TimeOut _t in game.OppentTeam.TimeOutList)
            {

                if (_t.Quarter >= 3 && _t.Quarter <= 4 && _firstFlag)
                {
                    _i = 2;
                    _firstFlag = false;
                }

                if (_t.Quarter == 5)
                {
                    _i = 5;
                }

                if (_t.Quarter == 6)
                {
                    _i = 6;
                }

                oppentTeamTimeOutLabels[_i].Image = _bmp;
                _i++;

                if (_i > 6)
                {
                    break;
                }
            }

            for (int _j = 0; _j < oppentTeamTimeOutLabels.Count(); _j++)
            {
                if (oppentTeamTimeOutLabels[_j].Image != _bmp)
                {
                    oppentTeamTimeOutLabels[_j].Image = _bmp2;
                }
            }
        }

        private void InputRunningScore()
        {
            runningScore.Init();
            
            foreach (RelationPointAction _r in this.game.MyTeam.GetQuarterPointActionAll())
            {
                this.runningScore.InputRunningScoreA(_r, _r.OwnerNumber);
            }

            foreach (RelationPointAction _r in this.game.OppentTeam.GetQuarterPointActionAll())
            {
                this.runningScore.InputRunningScoreB(_r, _r.OwnerNumber);
            }
        }

        private void PrintForm_Click(object sender, EventArgs e)
        {
            FormPrinter _fp = new FormPrinter();
            _fp.PrintForm(this);
        }

        private void PrintPreview_Click(object sender, EventArgs e)
        {
            FormPrinter _fp = new FormPrinter();
            _fp.ShowPrintPreview(this);
        }
    }

}


