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
using BasketballManagementSystem.baseClass.action;
using System.Collections;
using System.Windows.Forms.DataVisualization.Charting;
using BasketballManagementSystem.baseClass.actionPoint;
using BasketballManagementSystem.interfaces.actionPointGraph;

namespace BasketballManagementSystem.bmForm.actionPointGraph
{
    public partial class FormActionPointGraphView : Form, IActionPointGraphView
    {
        private Game game = new Game();

        public event Action<Player> SelectedPlayerChangedEvent;
      
        public FormActionPointGraphView()
        {
            InitializeComponent();

        }



        private void SelectedPlayerChangedEventThrow(Player selectedPlayer)
        {
            if (this.SelectedPlayerChangedEvent != null)
            {
                this.SelectedPlayerChangedEvent(selectedPlayer);
            }
        }


        /// <summary>
        /// リストのアイテムの選択が変更されたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TeamList_SelectedIndexChanged(object sender, EventArgs e)
        {
            object obj = ((ListBox)sender).SelectedItem;

            if (obj != null && obj is Player)
            {
                ActionPointChart.Series["PlayerActionPoint"].Points.Clear();
                ActionPointChart.Series["AverageActionPoint"].Points.Clear();
                ActionPointShitGraph.Series["PointAction"].Points.Clear();
                ActionPointShitGraph.Series["DefaultAction"].Points.Clear();
                ActionPointShitGraph.Series["MissAction"].Points.Clear();
                ActionPointShitGraph.Series["FaulAction"].Points.Clear();

                DrawActionPoint((Player)obj);

                this.SelectedPlayerChangedEventThrow((Player)obj);

                DrawAverageActionPoint();
                DrawAPShiftGraph((Player)obj);
            }
        }

        /// <summary>
        /// チームの平均アクションポイントをレーダーチャートで描画します。
        /// </summary>
        private void DrawAverageActionPoint()
        {
            
         //   DataSet ds = GetDataSet(selectedPlayer.IsMyTeam);
            DataSet ds = GetDataSetHelper(((Player)this.Presenter.GetModelProperty("SelectedPlayer")).IsMyTeam);

            ActionPointChart.DataSource = ds;

            for (var i = 0; i < ds.Tables[0].Columns.Count; i++)
            {
                DataPoint dp = new DataPoint();
                dp.SetValueXY(ds.Tables[0].Columns[i], ds.Tables[0].Rows[0][i]);
                
                dp.LabelBackColor = Color.Orange;
                ActionPointChart.Series["AverageActionPoint"].Points.Add(dp);
            }

            ActionPointChart.DataBind();
        }

        /// <summary>
        /// 渡されたプレイヤーのアクションポイントをレーダーチャートで描画します。
        /// </summary>
        /// <param name="p"></param>
        private void DrawActionPoint(Player p)
        {

            DataSet ds = GetDataSetHelper(p);

            ActionPointChart.DataSource = ds;

            for (var i = 0; i < ds.Tables[0].Columns.Count; i++)
            {
                DataPoint dp = new DataPoint();
                dp.SetValueXY(ds.Tables[0].Columns[i], ds.Tables[0].Rows[0][i]);
                
                dp.IsValueShownAsLabel = true;  //グラフに値を表示するように指定
                dp.Label = ds.Tables[0].Columns[i].ColumnName;

                dp.LabelBackColor = Color.LightBlue;
                ActionPointChart.Series["PlayerActionPoint"].Points.Add(dp);
            }

            ActionPointChart.DataBind();

        }

        /// <summary>
        /// 渡されたプレイヤーの各アクションポイントを時間推移グラフで描画します。
        /// </summary>
        /// <param name="p"></param>
        private void DrawAPShiftGraph(Player p)
        {
            DataPoint firstPoint = new DataPoint(0D, 0D);

            foreach (var v in ActionPointShitGraph.Series)
            {
                v.Points.Add(firstPoint);
            }
            
            int PA = 0;
            int DA = 0;
            int MA = 0;
            int FA = 0;

            foreach (var o in p.GetActionList(p))
            {
                DataPoint dp = new DataPoint();

                if (o is Miss)
                {
                    MA += ((ActionBase)o).ActionPoint;
                    dp.SetValueXY(((ActionBase)o).ElapsedTime.TotalSeconds, MA);
                    ActionPointShitGraph.Series["MissAction"].Points.Add(dp);
                }
                else if (o is Faul)
                {
                    FA += ((ActionBase)o).ActionPoint;
                    dp.SetValueXY(((ActionBase)o).ElapsedTime.TotalSeconds, FA);
                    ActionPointShitGraph.Series["FaulAction"].Points.Add(dp);
                }
                else if (o is RelationPointAction)
                {
                    PA += ((ActionBase)o).ActionPoint;
                    dp.SetValueXY(((ActionBase)o).ElapsedTime.TotalSeconds, PA);
                    ActionPointShitGraph.Series["PointAction"].Points.Add(dp);
                }
                else
                {
                    DA += ((ActionBase)o).ActionPoint;
                    dp.SetValueXY(((ActionBase)o).ElapsedTime.TotalSeconds, DA);
                    ActionPointShitGraph.Series["DefaultAction"].Points.Add(dp);
                }
            }
                            
        }

        /// <summary>
        /// アクションポイントのDataSetを取得
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private DataSet GetDataSetHelper(Player p)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            DataRow dtRow;

            dt.Columns.Add("PointAction", typeof(int));
            dt.Columns.Add("DefaultAction", typeof(int));
            dt.Columns.Add("MissAction", typeof(int));
            dt.Columns.Add("FaulAction", typeof(int));

            ds.Tables.Add(dt);

            dtRow = ds.Tables[0].NewRow();

            int[] temp = new int[4];

            ActionPointProvider ap = ActionPointProvider.GetInstance();

            foreach (var s in Player.GetAllActionName())
            {
                object o2 = p.GetActionProperty(p, s);

                if (o2 == null) continue;

                foreach (var o in (IList)o2)
                {
                    if (ap.GetActionPointType(o) == ActionPointProvider.TypeMiss)
                    {
                        temp[2] += ((Miss)o).ActionPoint;
                    }
                    else if (ap.GetActionPointType(o) == ActionPointProvider.TypeFaul)
                    {
                        temp[3] += ((Faul)o).ActionPoint;
                    }
                    else if (ap.GetActionPointType(o) == ActionPointProvider.TypePoint)
                    {
                        temp[0] += ((RelationPointAction)o).ActionPoint;
                    }
                    else if (ap.GetActionPointType(o) == ActionPointProvider.TypeNormal)
                    {
                        temp[1] += ((ActionBase)o).ActionPoint;
                    }
                }

            }

            for (var i = 0; i < 4; i++)
            {
                dtRow[i] = temp[i];
            }

            ds.Tables[0].Rows.Add(dtRow);

            return ds;
        }

        private DataSet GetDataSetHelper(bool isMyTeam)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            DataRow dtRow;

            dt.Columns.Add("PointAction", typeof(int));
            dt.Columns.Add("DefaultAction", typeof(int));
            dt.Columns.Add("MissAction", typeof(int));
            dt.Columns.Add("FaulAction", typeof(int));

            ds.Tables.Add(dt);

            dtRow = ds.Tables[0].NewRow();

            double[] temp = new double[4];

            double count = 0;

            Team t = new Team();

            if(isMyTeam)
                t = game.MyTeam;
            else
                t = game.OppentTeam;

            ActionPointProvider ap = ActionPointProvider.GetInstance();

            foreach (var p in t.TeamMember)
            {
                foreach (var s in Player.GetAllActionName())
                {

                    object o2 = p.GetActionProperty(p, s);

                    if (o2 == null) continue;

                    foreach (var o in (IList)o2)
                    {
                        if (ap.GetActionPointType(o) == ActionPointProvider.TypeMiss)
                        {
                            temp[2] += ((Miss)o).ActionPoint;
                        }
                        else if (ap.GetActionPointType(o) == ActionPointProvider.TypeFaul)
                        {
                            temp[3] += ((Faul)o).ActionPoint;
                        }
                        else if (ap.GetActionPointType(o) == ActionPointProvider.TypePoint)
                        {
                            temp[0] += ((RelationPointAction)o).ActionPoint;
                        }
                        else if (ap.GetActionPointType(o) == ActionPointProvider.TypeNormal)
                        {
                            temp[1] += ((ActionBase)o).ActionPoint;
                        }
                    }

                }

                count++;
            }

            for (var i = 0; i < 4; i++)
            {
                temp[i] /= count;
                dtRow[i] = temp[i];
            }

            ds.Tables[0].Rows.Add(dtRow);

            return ds;
        }

        private void PrintFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPrinter f = new FormPrinter();
            f.PrintForm(this);
        }

        private void PrintPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPrinter f = new FormPrinter();
            f.ShowPrintPreview(this);
        }


        public void SetMyListBox(List<Player> players)
        {
            foreach (var p in players)
            {
                MyTeamList.Items.Add(p);
            }
        }

        public void SetOppentListBox(List<Player> players)
        {
            foreach (var p in players)
            {
                OppentTeamList.Items.Add(p);
            }
        }

        public event events.DataInputEventHandler DataInputEvent;

        private abstracts.AbstractPresenter presenter;
        
        public abstracts.AbstractPresenter Presenter
        {
            get
            {
                return this.presenter;
            }
            set
            {
                this.presenter = value;
            }
        }


        public void SetMyTeamName(string name)
        {
            MyTeamName.Text = name;
        }

        public void SetOppentTeamName(string name)
        {
            OppentTeamName.Text = name;
        }

        private void DataInputViewEventThrow(string name, object value)
        {
            if (this.DataInputEvent != null)
            {
                this.DataInputEvent(this, new events.DataInputEventArgs(name, value));
            }
        }

        private void FormActionPointGraphView_Load(object sender, EventArgs e)
        {
            game = (Game)this.Presenter.GetModelProperty("Game");

            SetMyListBox(game.MyTeam.TeamMember);
            SetMyTeamName(game.MyTeam.Name);
            SetOppentListBox(game.OppentTeam.TeamMember);
            SetOppentTeamName(game.OppentTeam.Name);
        }
    }
}
