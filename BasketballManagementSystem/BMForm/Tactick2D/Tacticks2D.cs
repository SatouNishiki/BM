using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D; 
using BasketballManagementSystem.BaseClass.Position;
using BasketballManagementSystem.Manager.SaveDataManager;
using BasketballManagementSystem.BaseClass.Game;
using BasketballManagementSystem.BaseClass.Player;
using BasketballManagementSystem.BaseClass.Action;
using BasketballManagementSystem.Manager.PrintManager;

namespace BasketballManagementSystem.BMForm.Tactick2D
{
    public partial class Tacticks2D : Form
    {
        private Game game = SaveDataManager.GetInstance().GetGame();

        private Point leftTop;
        private Point rightDown;
        
        private Graphics graphics;
        
        private double[] range;

        private Player selectedPlayer = null;

        private const string AllTeamAction = "AllTeamAction";

        private const string AllAction = "AllAction";

        //ペイントエリア内でのシュート成功率の中で"このくらい入ればいい方"と思われるような値
        //この値を上げるとシュート成功率推定の判定が甘くなる(高い値が出やすくなる)
        //デフォルトは50%(NBAの解説、及びネット上での検索結果)
        private double valuationBasisPercent = 50;

        public Tacticks2D()
        {
            InitializeComponent();

            leftTop = CortPictureBox.Location;

            rightDown = new Point(CortPictureBox.Location.X + CortPictureBox.Size.Width, CortPictureBox.Location.Y + CortPictureBox.Size.Height);

            //身長175cmの男性の平均的な片腕の長さ0.75[m]をボールキープ可能レンジと定義
            range = CortHelper.GetCortLengthFromForm(leftTop, rightDown, 0.75);

            DrawActionKindsComboBox.Items.Add(AllTeamAction);
            DrawActionKindsComboBox.Items.Add(AllAction);
            DrawActionKindsComboBox.Items.Add(new Shoot2P().ActionName);
            DrawActionKindsComboBox.Items.Add(new Shoot3P().ActionName);
            DrawActionKindsComboBox.Items.Add(new FreeThrow().ActionName);
            DrawActionKindsComboBox.Items.Add(new Shoot2PMiss().ActionName);
            DrawActionKindsComboBox.Items.Add(new Shoot3PMiss().ActionName);
            DrawActionKindsComboBox.Items.Add(new FreeThrowMiss().ActionName);

            DrawActionKindsComboBox.SelectedIndex = 0;

            foreach (var p in game.MyTeam.TeamMember)
            {
                MyTeamListBox.Items.Add(p);
            }

            foreach (var p in game.OppentTeam.TeamMember)
            {
                OppentTeamListBox.Items.Add(p);
            }
        }

        private void AddInformationText(string message)
        {
            if(selectedPlayer == null) return;

            string team = "null";

            if (selectedPlayer.IsMyTeam)
            {
                team = game.MyTeam.Name;
            }
            else
            {
                team = game.OppentTeam.Name;
            }

            InformationRichTextBox.Text = "SelectedPlayer = " + selectedPlayer + "\n";
            InformationRichTextBox.AppendText("Team = " + team + "\n");
            InformationRichTextBox.AppendText("AllPoint = " + selectedPlayer.Point + "\n");
            InformationRichTextBox.AppendText("MaxShootRange = " + CortHelper.GetMaxShootRange(ActionListConverter.ToRelationPointActionList(selectedPlayer.GetActionList(selectedPlayer))) + "[m]\n");
            InformationRichTextBox.AppendText(message);
        }
       

        private void Cort_Paint(object sender, PaintEventArgs e)
        {
            string selectedString = (string)DrawActionKindsComboBox.SelectedItem;

            switch (selectedString)
            {
                case AllTeamAction :
                    DrawAllTeamAction(e);
                    break;

                case AllAction :
                    DrawAllAction(e);
                    break;

                default :
                    DrawEachAction(e);
                    break;
            }
        }

        private void DrawAllTeamAction(PaintEventArgs e)
        {
            //Graphicsオブジェクトを作成する
            graphics = e.Graphics;

            foreach (var p in game.MyTeam.TeamMember)
            {
                foreach (var action in ActionListConverter.ToRelationPointActionList(p.GetActionList(p)))
                {
                    Point point = PositionConvert.ConvertToPoint(action.Position, leftTop, rightDown);

                    //四角のパスを作成する
                    GraphicsPath gp = new GraphicsPath();

                    gp.AddEllipse(point.X, point.Y, (int)range[0], (int)range[1]);

                    //PathGradientBrushオブジェクトの作成
                    PathGradientBrush gb = new PathGradientBrush(gp);
                    PathGradientBrush gb2 = new PathGradientBrush(gp);

                    if (!(action is Miss))
                    {

                        //パスグラデーションの中心の色を白にする
                        gb.CenterColor = Color.Red;
                        //パス内の点に対応している色を指定する
                        gb.SurroundColors =
                            new Color[] { Color.Yellow };
                        graphics.FillEllipse(gb, point.X, point.Y, (int)range[0], (int)range[1]);

                    }
                    else
                    {
                        //パスグラデーションの中心の色を白にする
                        gb2.CenterColor = Color.Blue;
                        //パス内の点に対応している色を指定する
                        gb2.SurroundColors =
                            new Color[] { Color.LightBlue };

                        graphics.FillEllipse(gb2, point.X, point.Y, (int)range[0], (int)range[1]);
                    }
                }
            }

            foreach (var p in game.OppentTeam.TeamMember)
            {
                foreach (var action in ActionListConverter.ToRelationPointActionList(p.GetActionList(p)))
                {
                    Point point = PositionConvert.ConvertToPoint(action.Position, leftTop, rightDown);

                    //四角のパスを作成する
                    GraphicsPath gp = new GraphicsPath();

                    gp.AddEllipse(point.X, point.Y, (int)range[0], (int)range[1]);

                    //PathGradientBrushオブジェクトの作成
                    PathGradientBrush gb = new PathGradientBrush(gp);
                    PathGradientBrush gb2 = new PathGradientBrush(gp);

                    if (!(action is Miss))
                    {

                        //パスグラデーションの中心の色を白にする
                        gb.CenterColor = Color.Red;
                        //パス内の点に対応している色を指定する
                        gb.SurroundColors =
                            new Color[] { Color.Yellow };
                        graphics.FillEllipse(gb, point.X, point.Y, (int)range[0], (int)range[1]);

                    }
                    else
                    {
                        //パスグラデーションの中心の色を白にする
                        gb2.CenterColor = Color.Blue;
                        //パス内の点に対応している色を指定する
                        gb2.SurroundColors =
                            new Color[] { Color.LightBlue };

                        graphics.FillEllipse(gb2, point.X, point.Y, (int)range[0], (int)range[1]);
                    }
                }
            }
        }

        private void DrawAllAction(PaintEventArgs e)
        {
            if (selectedPlayer == null) return;

            graphics = e.Graphics;

            foreach (var action in ActionListConverter.ToRelationPointActionList(selectedPlayer.GetActionList(selectedPlayer)))
            {
                Point point = PositionConvert.ConvertToPoint(action.Position, leftTop, rightDown);

                //四角のパスを作成する
                GraphicsPath gp = new GraphicsPath();

                gp.AddEllipse(point.X, point.Y, (int)range[0], (int)range[1]);

                //PathGradientBrushオブジェクトの作成
                PathGradientBrush gb = new PathGradientBrush(gp);
                PathGradientBrush gb2 = new PathGradientBrush(gp);

                if (!(action is Miss))
                {

                    //パスグラデーションの中心の色を白にする
                    gb.CenterColor = Color.Red;
                    //パス内の点に対応している色を指定する
                    gb.SurroundColors =
                        new Color[] { Color.Yellow };
                    graphics.FillEllipse(gb, point.X, point.Y, (int)range[0], (int)range[1]);

                }
                else
                {
                    //パスグラデーションの中心の色を白にする
                    gb2.CenterColor = Color.Blue;
                    //パス内の点に対応している色を指定する
                    gb2.SurroundColors =
                        new Color[] { Color.LightBlue };

                    graphics.FillEllipse(gb2, point.X, point.Y, (int)range[0], (int)range[1]);
                }
            }
        }

        private void DrawEachAction(PaintEventArgs e)
        {
            if (selectedPlayer == null) return;

            graphics = e.Graphics;

            foreach (var action in ActionListConverter.ToRelationPointActionList(selectedPlayer.GetActionList(selectedPlayer, a => a.ActionName == (string)DrawActionKindsComboBox.SelectedItem)))
            {
                Point point = PositionConvert.ConvertToPoint(action.Position, leftTop, rightDown);

                //四角のパスを作成する
                GraphicsPath gp = new GraphicsPath();

                gp.AddEllipse(point.X, point.Y, (int)range[0], (int)range[1]);

                //PathGradientBrushオブジェクトの作成
                PathGradientBrush gb = new PathGradientBrush(gp);
                PathGradientBrush gb2 = new PathGradientBrush(gp);

                if (!(action is Miss))
                {

                    //パスグラデーションの中心の色を白にする
                    gb.CenterColor = Color.Red;
                    //パス内の点に対応している色を指定する
                    gb.SurroundColors =
                        new Color[] { Color.Yellow };
                    graphics.FillEllipse(gb, point.X, point.Y, (int)range[0], (int)range[1]);

                }
                else
                {
                    //パスグラデーションの中心の色を白にする
                    gb2.CenterColor = Color.Blue;
                    //パス内の点に対応している色を指定する
                    gb2.SurroundColors =
                        new Color[] { Color.LightBlue };

                    graphics.FillEllipse(gb2, point.X, point.Y, (int)range[0], (int)range[1]);
                    
                }
            }
        }

        private void TeamList_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedPlayer = (Player)((ListBox)sender).SelectedItem;
            AddInformationText("");
            CortPictureBox.Refresh();
        }

        private void DrawActionKinds_SelectedIndexChanged(object sender, EventArgs e)
        {
            CortPictureBox.Refresh();
        }

        private void Cort_Click(object sender, EventArgs e)
        {
            if(selectedPlayer == null) return;

            //マウスの押された位置を覚える変数
            Point mousePoint = Point.Empty;

            //マウスの位置を記憶
            mousePoint.X = Cursor.Position.X;
            mousePoint.Y = Cursor.Position.Y;

            //マウスの位置をフォーム上の座標に変換
            mousePoint = PointToClient(mousePoint);

            Position p = PositionConvert.ConvertToPosition(mousePoint, leftTop, rightDown);

            double distance = Double.MaxValue;

            RelationPointAction shoot = new RelationPointAction();

            //ミスとフリースローを除外
            foreach (var r in ActionListConverter.ToRelationPointActionList(selectedPlayer.GetActionList(selectedPlayer, a => !(a is Miss) && !(a is FreeThrow))))
            {
                double temp = CortHelper.GetDistance(p, r.Position);
               //double temp = CortHelper.GetDistanceX(p, r.position);

                //一番近いものをとってくる
                if (distance > temp)
                {
                    distance = temp;
                    shoot = r;
                }
            }

            string message;

            if (distance == Double.MaxValue)
            {
                message = "CannotAnalyze:NotFindApproximateShoot\n";
            }
            else
            {
                double g = GetShootSuccessPercent(p, valuationBasisPercent);
                string s = g + "%";

                if (g < 0) { s = "測定不能(データが足りません)"; }

                double g2 = GetShootSuccessPercent(p, 98);
                string s2 = g2 + "%";

                if (g2 < 0) { s2 = "測定不能(データが足りません)"; }

                message =
                    "MostApproximateShoot" + shoot + "\n" +
                    "DifferenceDistance" + distance + "\n" +
                    "NormalShootSuccessPercent" + s + "\n" +
                    "FreeThrowShootSuccessPercent" + s2 + "\n";
            }

            AddInformationText(message);
        }

        /// <summary>
        /// 指定された場所のシュートの成功率の概算を求める
        /// </summary>
        /// <param name="p">分析する地点</param>
        /// <returns>成功率(%)</returns>
        private double GetShootSuccessPercent(Position p, double _valuationBasis)
        {

            /******近い距離のアクションをまとめる処理******/

            List<List<RelationPointAction>> list = new List<List<RelationPointAction>>();
            list.Add(new List<RelationPointAction>());
            bool sameLineFlag = true;
            bool firstFlag = true;
            int lineCount = 0;
            Position beforeActionPoint = new Position(0, 0);

            var query = from p2 in ActionListConverter.ToRelationPointActionList(selectedPlayer.GetActionList(selectedPlayer, a => !(a is FreeThrow)))
                        orderby CortHelper.GetDistanceFromGoal(p2.Position)
                        select p2;

            List<RelationPointAction> rList = query.ToList<RelationPointAction>();

            //ミスとフリースローを除外
            foreach (var r in rList)
            {
                if (!firstFlag)
                {
                    double d2 = CortHelper.GetDistance(beforeActionPoint, r.Position);

                    if (d2 <= 2 && d2 >= 0)
                    {
                        sameLineFlag = true;
                    }
                    else
                    {
                        sameLineFlag = false;
                    }
                }

                firstFlag = false;

                if (sameLineFlag)
                {
                    list[lineCount].Add(r);
                }
                else
                {
                    lineCount++;
                    list.Add(new List<RelationPointAction>());
                    list[lineCount].Add(r);
                }

                beforeActionPoint = r.Position;
            }

            /**********それぞれの列ごとにシュートの成功率をまとめる************/

            List<double> shootSuccessPercent = new List<double>();

            foreach (var l in list)
            {
                double shootCount = 0;
                double missCount = 0;

                foreach (var r in l)
                {
                    if (!(r is Miss))
                    {
                        shootCount++;
                    }
                    else
                    {
                        missCount++;
                    }
                }
                if (shootCount + missCount != 0)
                {
                    shootSuccessPercent.Add((shootCount / (shootCount + missCount)) * 100);
                }
                else
                {
                    shootSuccessPercent.Add(0);
                }
            }

            /*************シュート成功率がgoodSuccessShootPercentage~の間で最も距離の遠いものを求める(listの後ろのほうが距離が遠い)************/

            int pos = 0;
            int count = 0;

            foreach (var d in shootSuccessPercent)
            {
                if (d >= _valuationBasis)
                {
                    pos = count;
                }

                count++;
            }

            //posが0ということはシュート成功率がgoodSuccessShootPercentage~の地点が見つからないということ データ不足につき測定不能
            if (pos == 0) return -1;

            //以下解説:
            //シュート位置によるシュート成功率の分布は最長シュート可能距離の40%に位置する点までとそれ以降で異なるという説を提唱
            //(参考文献 : https://ir.lib.osaka-kyoiku.ac.jp/dspace/bitstream/123456789/15151/1/KJ4_5802_131.pdf)
            //(上記のものはシュート成功率を高めるための方法についての論文だが、ここに各相対距離別のシュート成功率に関する考察がのっている)
            //これによると最大シュート可能距離の40%まででは高いシュート成功率を得ることができ、そこからは相対距離が
            //10%延長するごとに実験上有意な差が見られるらしい
            //またシュート成功率が最低点となる付近ではシュート成功率を表す関数の傾きがゆるやかになることは自明である
            //よって最長シュート可能距離の40%地点までは一次関数的減少を行い、それ以降ではy=1/x(x>0)のようなグラフになるのでは
            //ないかとかんがえた
            //ここでシュート成功率の分布から最長シュート可能距離の40%地点にあたると思われるポイントを探し出し関数形に当てはめている

            //最長シュート可能距離の40%に位置する地点を求める
            double fortyPercentPositon = CortHelper.GetDistanceFromGoal(list[0][0].Position);

            double point = CortHelper.GetDistanceFromGoal(p);

            if (point <= fortyPercentPositon)
            {
                double slope = 15 / fortyPercentPositon;

                return _valuationBasis - (point * slope);
            }
            else
            {
                double d = 0;

                int loop = 0;
                double i = 5;

                while (loop < point - fortyPercentPositon)
                {
                    d += i;
                    i -= i / 10;
                    loop++;
                }

                if (_valuationBasis - 15 - d < 0) 
                    return 0;
                else
                    return _valuationBasis - 15 - d;
            }
        }

        private void percent_KeyPress(object sender, KeyPressEventArgs e)
        {
            //0～9と、バックスペース以外の時は、イベントをキャンセルする
            if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void percent_TextChanged(object sender, EventArgs e)
        {
            if (PercentTextBox.Text != "")
            {
                try
                {
                   valuationBasisPercent = double.Parse(PercentTextBox.Text);
                }
                catch
                {
                    valuationBasisPercent = 50;
                    PercentTextBox.Text = "50";

                    BMErrorLibrary.BMError.ErrorMessageOutput("評価基準に不正な値が入力されました", true);
                }
            }
            else
            {
                PercentTextBox.Text = "50";
            }
        }

        private void printForm_Click(object sender, EventArgs e)
        {
            FormPrinter fp = new FormPrinter();
            fp.PrintForm(this);
        }

        private void printPreview_Click(object sender, EventArgs e)
        {
            FormPrinter fp = new FormPrinter();
            fp.ShowPrintPreview(this);
        }
    }
}
