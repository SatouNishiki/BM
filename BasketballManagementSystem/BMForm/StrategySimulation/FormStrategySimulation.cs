using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BasketballManagementSystem.baseClass.game;
using BasketballManagementSystem.manager;
using BasketballManagementSystem.baseClass.player;
using DragDropPictureBox;
using System.Reflection;
using BasketballManagementSystem.baseClass.position;
using BMErrorLibrary;

namespace BasketballManagementSystem.bmForm.strategySimulation
{
    public partial class FormStrategySimulation : Form
    {
        private Game game = SaveDataManager.GetInstance().GetGame();

        /// <summary>
        /// 下のほうのベンチにいる人とかボールとかの合計数
        /// </summary>
        private const int OtherObjectCount = 6;

        private const string BallTag = "ボール";
        private const string OppentPlayerTag = "相手プレイヤー";

        private Assembly myAssembly = Assembly.GetExecutingAssembly();
       
        /// <summary>
        /// シュミレーションのアニメを回すときに今どこをまわしてるのかを知るために使用
        /// </summary>
        private int animationCount = 0;

        private int moveFinishMemberCount = 0;

        /// <summary>
        /// liteFPSモードのときのループ数計算カウンターとして使用
        /// </summary>
        private int loopCount = 0;

        private bool isLiteFPSMode = false;

        private int speed = 1;

        /// <summary>
        /// シュミレート前にリストの中身を覚えるために使用
        /// </summary>
        private List<Board> boardListBoxItems = new List<Board>();

        private List<LocationBitmap> canMoveMembers = new List<LocationBitmap>();

        private int beforeAnimationCount = 0;

        public FormStrategySimulation()
        {
            InitializeComponent();
            SpeedComboBox.SelectedIndex = 0;

            //今何個目の要素を入れようとしてるか
            int count = 0;

            //入れようとしてるDragDropBoxの幅
            int width;

            //0除算起こらないように
            if (game.MyTeam.TeamMember.Count != 0)
                width = BenchDragDropBox.Width / game.MyTeam.TeamMember.Count;
            else
                width = 0;

            //画像表示するときの高さ
            int height = 10;


            foreach (var p in game.MyTeam.TeamMember)
            {
                if (count % 2 == 0)
                    IntoDragDropBox(BenchDragDropBox, "Player_Blue.png", count * width, height, true, p.ToString());
                else
                    IntoDragDropBox(BenchDragDropBox, "Player_Blue.png", count * width, height + BenchDragDropBox.Height / 2, true, p.ToString());

                count++;
            }

            width = Bench2DragDropBox.Width / OtherObjectCount;

            for (count = 0; count < OtherObjectCount - 1; count++)
                IntoDragDropBox(Bench2DragDropBox, "Player_Red.png", count * width, height, true, OppentPlayerTag + count);


            IntoDragDropBox(Bench2DragDropBox, "Ball2.png", count * width, height, true, BallTag);

        }

        /// <summary>
        /// 指定されたdragdropboxに画像を入れる
        /// </summary>
        /// <param name="dragDropBox">対象</param>
        /// <param name="pictureName">画像の名前</param>
        /// <param name="x">x座標</param>
        /// <param name="y">y座標</param>
        /// <param name="canMove">動かせるかどうか</param>
        /// <param name="tag">タグ付与(何もなければnull)</param>
        private void IntoDragDropBox(DragDropBox dragDropBox, string pictureName, int x, int y, bool canMove, object tag)
        {
            Bitmap bitmap = CreateBitmap(pictureName);

            bitmap.Tag = tag;

            LocationBitmap l = new LocationBitmap(bitmap, new Point(x, y));
            l.CanMove = canMove;

            dragDropBox.LocationBitmapList.Add(l);
        }

        /// <summary>
        /// 指定された名前の画像をbitmapにして返す
        /// </summary>
        /// <param name="pictureName"></param>
        /// <returns></returns>
        private Bitmap CreateBitmap(string pictureName)
        {
            return new Bitmap(myAssembly.GetManifestResourceStream
                     ("BasketballManagementSystem.BMForm.StrategySimulation.Picture." + pictureName));
        }

        private void AddBoardButton_Click(object sender, EventArgs e)
        {
            if (dragDropBoxCort.LocationBitmapList.Count == 0)
            {
                MessageBox.Show("盤面に何も無いので追加できません");
                return;
            }

            Board board = new Board();

            foreach (var lb in dragDropBoxCort.LocationBitmapList)
            {

                if (lb.CanMove)
                {
                    LocationBitmap l = new LocationBitmap();

                    Bitmap playerGraph;

                    if (((string)lb.Graphics.Tag).Contains(BallTag))
                    {
                        playerGraph = CreateBitmap("Ball_Dark.png");
                    }
                    else if (((string)lb.Graphics.Tag).Contains(OppentPlayerTag))
                    {
                        playerGraph = CreateBitmap("Player_Red_Dark.png");
                    }
                    else
                    {
                        playerGraph = CreateBitmap("Player_Dark.png");
                    }

                    l.CanMove = false;
                    l.Graphics = playerGraph;
                    l.Graphics.Tag = lb.Graphics.Tag;
                    l.Location = lb.Location;
                    board.FieldMembers.Add(l);
                }
            }

            board.ExecuteTime = BoardListBox.Items.Count;

            BoardListBox.Items.Add(board);
        }

        private void BoardListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            BoardChangeFromIndex(BoardListBox.SelectedIndex);
        }

        private void BoardChangeFromIndex(int index)
        {
            if (index < 0)
            {
                BMError.ErrorMessageOutput("不正な値が指定されました", false);
                return;
            }

            if (index >= BoardListBox.Items.Count)
            {
                BMError.ErrorMessageOutput("指定されたインデックスがリストの上限を超えています", true);
                return;
            }

            dragDropBoxCort.LocationBitmapList.RemoveAll(l => !l.CanMove);

            foreach (var locationBitmap in ((Board)BoardListBox.Items[index]).FieldMembers)
            {
                dragDropBoxCort.LocationBitmapList.Add(locationBitmap);
            }

            dragDropBoxCort.Refresh();
        }

        private void SimulateButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("シュミレーションを開始しますか？",
                                                  "確認",
                                                  MessageBoxButtons.OKCancel,
                                                  MessageBoxIcon.Question,
                                                  MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Cancel)
                return;

            //リストボックスを保存
            boardListBoxItems.Clear();
            foreach (Board b in BoardListBox.Items)
            {
                Board b2 = new Board();
                
                foreach (var m in b.FieldMembers)
                {
                    LocationBitmap l = new LocationBitmap();
                    l = m.CloneDeep();
                    l.Graphics.Tag = m.Graphics.Tag;
                    b2.FieldMembers.Add(l);
                }

                b2.ExecuteTime = b.ExecuteTime;

                boardListBoxItems.Add(b2);
            }

            BoardListBox.Enabled = false;
            AddBoardButton.Enabled = false;
            SimulateButton.Enabled = false;

            SimulationFPSTimer.Enabled = true;
        }

        /// <summary>
        /// シュミレーションアニメのtick処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SimulationFPSTimer_Tick(object sender, EventArgs e)
        {
            //これ以上シュミレーションの続きが無かったら
            if (BoardListBox.Items.Count == 0 || animationCount + 1 == BoardListBox.Items.Count)
            {
                //終了処理
                SimulationFPSTimer.Enabled = false;
                BoardChangeFromIndex(animationCount);
                animationCount = 0;

                //リストボックスを復元
                BoardListBox.Items.Clear();
                foreach (Board b in boardListBoxItems)
                {
                    BoardListBox.Items.Add(b);
                }

                BoardListBox.Enabled = true;
                AddBoardButton.Enabled = true;
                SimulateButton.Enabled = true;
                return;
            }


            //現在のリストメンバーと次のリストメンバーを順に操作していく
            foreach (var graph in ((Board)BoardListBox.Items[animationCount]).FieldMembers)
            {
                foreach (var nextGraph in ((Board)BoardListBox.Items[animationCount + 1]).FieldMembers)
                {
                  
                    if (CanMove(graph, nextGraph))
                    {
                        //速度管理変数の分だけ移動処理を繰り返すことで速度を調節できる
                        for (int i = 0; i < speed; i++)
                        {
                            graph.Location = TryToMove(nextGraph.Location, graph.Location);

                            if (graph.Location.X == nextGraph.Location.X && graph.Location.Y == nextGraph.Location.Y)
                            {
                                moveFinishMemberCount++;
                                break;
                            }
                        }
                    }
                }

                //liteFPSModeのときの処理 2回に一回しか描画更新しない
                if (isLiteFPSMode && loopCount % 2 == 0)
                    BoardChangeFromIndex(animationCount);

                if (!isLiteFPSMode)
                    BoardChangeFromIndex(animationCount);

                loopCount++;
            }

            //全員回り終えたらアニメーションカウントを増やして次のループへ
            if (moveFinishMemberCount >= ((Board)BoardListBox.Items[animationCount]).FieldMembers.Count)
            {
                moveFinishMemberCount = 0;
                animationCount++;
            }

        }

        private void UseLiteFPSModeItem_Click(object sender, EventArgs e)
        {
            UseLiteFPSModeItem.Checked = !UseLiteFPSModeItem.Checked;
            isLiteFPSMode = UseLiteFPSModeItem.Checked;
        }

        /// <summary>
        /// sourceに至る最短経路のうち次に移動するべき場所を求める
        /// </summary>
        /// <param name="wayPoint">現在地</param>
        /// <param name="source">目的地</param>
        /// <returns></returns>
        private Point TryToMove(Point wayPoint, Point source)
        {

            int lenght1 = (int)Math.Sqrt((source.X - wayPoint.X + 1) * (source.X - wayPoint.X + 1) + (source.Y - wayPoint.Y) * (source.Y - wayPoint.Y));
            int length2 = (int)Math.Sqrt((source.X - wayPoint.X) * (source.X - wayPoint.X) + (source.Y - wayPoint.Y + 1) * (source.Y - wayPoint.Y + 1));
            int length3 = (int)Math.Sqrt((source.X - wayPoint.X + 1) * (source.X - wayPoint.X + 1) + (source.Y - wayPoint.Y + 1) * (source.Y - wayPoint.Y + 1));
            int length4 = (int)Math.Sqrt((source.X - wayPoint.X - 1) * (source.X - wayPoint.X - 1) + (source.Y - wayPoint.Y) * (source.Y - wayPoint.Y));
            int length5 = (int)Math.Sqrt((source.X - wayPoint.X) * (source.X - wayPoint.X) + (source.Y - wayPoint.Y - 1) * (source.Y - wayPoint.Y - 1));
            int length6 = (int)Math.Sqrt((source.X - wayPoint.X - 1) * (source.X - wayPoint.X - 1) + (source.Y - wayPoint.Y - 1) * (source.Y - wayPoint.Y - 1));

            List<int> l = new List<int>();

            l.Add(lenght1);
            l.Add(length2);
            l.Add(length3);
            l.Add(length4);
            l.Add(length5);
            l.Add(length6);

            l.Sort();

            if (l[0] == lenght1)
                return new Point(source.X + 1, source.Y);

            else if (l[0] == length2)
                return new Point(source.X, source.Y + 1);

            else if (l[0] == length3)
                return new Point(source.X + 1, source.Y + 1);

            else if (l[0] == length4)
                return new Point(source.X - 1, source.Y);

            else if (l[0] == length5)
                return new Point(source.X, source.Y - 1);
            else
                return new Point(source.X - 1, source.Y - 1);
        }

        private void SpeedComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int s = 0;
            if (int.TryParse(SpeedComboBox.SelectedItem.ToString(), out s))
            {
                speed = s;
            }
            else
            {
                BMError.ErrorMessageOutput("無効な入力です", true);   
            }

        }

        /// <summary>
        /// 二つの引数から移動可能かどうかを返す
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="nextGraph"></param>
        /// <returns></returns>
        private bool CanMove(LocationBitmap graph, LocationBitmap nextGraph)
        {
            if (animationCount > beforeAnimationCount)
            {
                beforeAnimationCount = animationCount;
                canMoveMembers.Clear();
            }

            if (graph.Graphics.Tag != nextGraph.Graphics.Tag)
            {
                return false;
            }

            if (canMoveMembers.IndexOf(graph) < 0)
            {
                canMoveMembers.Add(graph);
                return true;
            }

            if (graph.Location == nextGraph.Location)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        private void SpeedComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b')
            {
                //押されたキーが 0～9、バックスペースでない場合は、イベントをキャンセルする
                e.Handled = true;
            }
        }

    }
}
