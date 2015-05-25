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
using BasketballManagementSystem.BaseClass.Player;
using BasketballManagementSystem.BaseClass.Action;
using System.Collections;
using System.Windows.Forms.DataVisualization.Charting;

namespace BasketballManagementSystem.BMForm.ActionPointGraph
{
    public partial class FormActionPointGraph : Form
    {
        /// <summary>
        /// 現在のゲームデータオブジェクト
        /// </summary>
        private Game game = SaveDataManager.GetInstance().GetGame();

        /// <summary>
        /// 選択選手
        /// </summary>
        private Player selectedPlayer = new Player("No Name", 0);

        public FormActionPointGraph()
        {
            InitializeComponent();

            SetTeam();

        }

        /// <summary>
        /// チームのリストの初期化
        /// </summary>
        private void SetTeam()
        {
            MyTeamName.Text = game.MyTeam.Name;
            OppentTeamName.Text = game.OppentTeam.Name;

            foreach (var p in game.MyTeam.TeamMember)
            {
                MyTeamList.Items.Add(p);
            }

            foreach (var p in game.OppentTeam.TeamMember)
            {
                OppentTeamList.Items.Add(p);
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
                selectedPlayer = (Player)obj;
                DrawAverageActionPoint();
                DrawAPShiftGraph((Player)obj);
            }
        }

        /// <summary>
        /// チームの平均アクションポイントをレーダーチャートで描画します。
        /// </summary>
        private void DrawAverageActionPoint()
        {
            
            DataSet ds = GetDataSet(selectedPlayer.IsMyTeam);

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

            DataSet ds = GetDataSet(p);

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

            int PA = 0;
            int DA = 0;
            int MA = 0;
            int FA = 0;

            foreach (var s in Player.GetAllActionName())
            {

                object o2 = p.GetActionProperty(p, s);

                if (o2 == null) continue;

                foreach (var o in (IList)o2)
                {
                    DataPoint dp = new DataPoint();
                   
                    if (o is Miss)
                    {
                        MA += ((BaseClass.Action.Action)o).ActionPoint;
                        dp.SetValueXY(((BaseClass.Action.Action)o).ElapsedTime.TotalSeconds, MA);
                        ActionPointShitGraph.Series["MissAction"].Points.Add(dp);
                    }
                    else if (o is Faul)
                    {
                        FA += ((BaseClass.Action.Action)o).ActionPoint;
                        dp.SetValueXY(((BaseClass.Action.Action)o).ElapsedTime.TotalSeconds, FA);
                        ActionPointShitGraph.Series["FaulAction"].Points.Add(dp);
                    }
                    else if (o is RelationPointAction)
                    {
                        PA += ((BaseClass.Action.Action)o).ActionPoint;
                        dp.SetValueXY(((BaseClass.Action.Action)o).ElapsedTime.TotalSeconds, PA);
                        ActionPointShitGraph.Series["PointAction"].Points.Add(dp);
                    }
                    else
                    {
                        DA += ((BaseClass.Action.Action)o).ActionPoint;
                        dp.SetValueXY(((BaseClass.Action.Action)o).ElapsedTime.TotalSeconds, DA);
                        ActionPointShitGraph.Series["DefaultAction"].Points.Add(dp);
                    }
                }
                
            }   
        }

        /// <summary>
        /// アクションポイントのDataSetを取得
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private DataSet GetDataSet(Player p)
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

            foreach (var s in Player.GetAllActionName())
            {
                object o2 = p.GetActionProperty(p, s);

                if (o2 == null) continue;

                foreach (var o in (IList)o2)
                {
                    if (o is Miss)
                    {
                        temp[2] += ((Miss)o).ActionPoint;
                    }
                    else if (o is Faul)
                    {
                        temp[3] += ((Faul)o).ActionPoint;
                    }
                    else if (o is RelationPointAction)
                    {
                        temp[0] += ((RelationPointAction)o).ActionPoint;
                    }
                    else
                    {
                        temp[1] += ((BaseClass.Action.Action)o).ActionPoint;
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

        private DataSet GetDataSet(bool isMyTeam)
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

            foreach (var p in t.TeamMember)
            {
                foreach (var s in Player.GetAllActionName())
                {

                    object o2 = p.GetActionProperty(p, s);

                    if (o2 == null) continue;

                    foreach (var o in (IList)o2)
                    {
                        if (o is Miss)
                        {
                            temp[2] += ((Miss)o).ActionPoint;
                        }
                        else if (o is Faul)
                        {
                            temp[3] += ((Faul)o).ActionPoint;
                        }
                        else if (o is RelationPointAction)
                        {
                            temp[0] += ((RelationPointAction)o).ActionPoint;
                        }
                        else
                        {
                            temp[1] += ((BaseClass.Action.Action)o).ActionPoint;
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

    }
}
