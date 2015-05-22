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

            foreach (Player _p in game.MyTeam.TeamMember)
            {
                MyTeamList.Items.Add(_p);
            }

            foreach (Player _p in game.OppentTeam.TeamMember)
            {
                OppentTeamList.Items.Add(_p);
            }
        }

        /// <summary>
        /// リストのアイテムの選択が変更されたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TeamList_SelectedIndexChanged(object sender, EventArgs e)
        {
            object _o = ((ListBox)sender).SelectedItem;

            if (_o != null && _o is Player)
            {
                ActionPointChart.Series["PlayerActionPoint"].Points.Clear();
                ActionPointChart.Series["AverageActionPoint"].Points.Clear();
                ActionPointShitGraph.Series["PointAction"].Points.Clear();
                ActionPointShitGraph.Series["DefaultAction"].Points.Clear();
                ActionPointShitGraph.Series["MissAction"].Points.Clear();
                ActionPointShitGraph.Series["FaulAction"].Points.Clear();

                DrawActionPoint((Player)_o);
                selectedPlayer = (Player)_o;
                DrawAverageActionPoint();
                DrawAPShiftGraph((Player)_o);
            }
        }

        /// <summary>
        /// チームの平均アクションポイントをレーダーチャートで描画します。
        /// </summary>
        private void DrawAverageActionPoint()
        {
            
            DataSet _ds = GetDataSet(selectedPlayer.IsMyTeam);

            ActionPointChart.DataSource = _ds;

            for (int _i = 0; _i < _ds.Tables[0].Columns.Count; _i++)
            {
                DataPoint _dp = new DataPoint();
                _dp.SetValueXY(_ds.Tables[0].Columns[_i], _ds.Tables[0].Rows[0][_i]);
                
                _dp.LabelBackColor = Color.Orange;
                ActionPointChart.Series["AverageActionPoint"].Points.Add(_dp);
            }

            ActionPointChart.DataBind();
        }

        /// <summary>
        /// 渡されたプレイヤーのアクションポイントをレーダーチャートで描画します。
        /// </summary>
        /// <param name="p"></param>
        private void DrawActionPoint(Player p)
        {

            DataSet _ds = GetDataSet(p);

            ActionPointChart.DataSource = _ds;

            for (int _i = 0; _i < _ds.Tables[0].Columns.Count; _i++)
            {
                DataPoint _dp = new DataPoint();
                _dp.SetValueXY(_ds.Tables[0].Columns[_i], _ds.Tables[0].Rows[0][_i]);
                
                _dp.IsValueShownAsLabel = true;  //グラフに値を表示するように指定
                _dp.Label = _ds.Tables[0].Columns[_i].ColumnName;

                _dp.LabelBackColor = Color.LightBlue;
                ActionPointChart.Series["PlayerActionPoint"].Points.Add(_dp);
            }

            ActionPointChart.DataBind();

        }

        /// <summary>
        /// 渡されたプレイヤーの各アクションポイントを時間推移グラフで描画します。
        /// </summary>
        /// <param name="p"></param>
        private void DrawAPShiftGraph(Player _p)
        {

            int _PA = 0;
            int _DA = 0;
            int _MA = 0;
            int _FA = 0;

            foreach (string _s in Player.GetAllActionName())
            {

                object _o2 = _p.GetActionProperty(_p, _s);

                if (_o2 == null) continue;

                foreach (object _o in (IList)_o2)
                {
                    DataPoint _dp = new DataPoint();
                   
                    if (_o is Miss)
                    {
                        _MA += ((BaseClass.Action.Action)_o).ActionPoint;
                        _dp.SetValueXY(((BaseClass.Action.Action)_o).ElapsedTime.TotalSeconds, _MA);
                        ActionPointShitGraph.Series["MissAction"].Points.Add(_dp);
                    }
                    else if (_o is Faul)
                    {
                        _FA += ((BaseClass.Action.Action)_o).ActionPoint;
                        _dp.SetValueXY(((BaseClass.Action.Action)_o).ElapsedTime.TotalSeconds, _FA);
                        ActionPointShitGraph.Series["FaulAction"].Points.Add(_dp);
                    }
                    else if (_o is RelationPointAction)
                    {
                        _PA += ((BaseClass.Action.Action)_o).ActionPoint;
                        _dp.SetValueXY(((BaseClass.Action.Action)_o).ElapsedTime.TotalSeconds, _PA);
                        ActionPointShitGraph.Series["PointAction"].Points.Add(_dp);
                    }
                    else
                    {
                        _DA += ((BaseClass.Action.Action)_o).ActionPoint;
                        _dp.SetValueXY(((BaseClass.Action.Action)_o).ElapsedTime.TotalSeconds, _DA);
                        ActionPointShitGraph.Series["DefaultAction"].Points.Add(_dp);
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
            DataSet _ds = new DataSet();
            DataTable _dt = new DataTable();

            DataRow _dtRow;

            _dt.Columns.Add("PointAction", typeof(int));
            _dt.Columns.Add("DefaultAction", typeof(int));
            _dt.Columns.Add("MissAction", typeof(int));
            _dt.Columns.Add("FaulAction", typeof(int));

            _ds.Tables.Add(_dt);

            _dtRow = _ds.Tables[0].NewRow();

            int[] _temp = new int[4];

            foreach (string _s in Player.GetAllActionName())
            {
                object _o2 = p.GetActionProperty(p, _s);

                if (_o2 == null) continue;

                foreach (object _o in (IList)_o2)
                {
                    if (_o is Miss)
                    {
                        _temp[2] += ((Miss)_o).ActionPoint;
                    }
                    else if (_o is Faul)
                    {
                        _temp[3] += ((Faul)_o).ActionPoint;
                    }
                    else if (_o is RelationPointAction)
                    {
                        _temp[0] += ((RelationPointAction)_o).ActionPoint;
                    }
                    else
                    {
                        _temp[1] += ((BaseClass.Action.Action)_o).ActionPoint;
                    }
                }

            }

            for (int _i = 0; _i < 4; _i++)
            {
                _dtRow[_i] = _temp[_i];
            }

            _ds.Tables[0].Rows.Add(_dtRow);

            return _ds;
        }

        private DataSet GetDataSet(bool isMyTeam)
        {
            DataSet _ds = new DataSet();
            DataTable _dt = new DataTable();

            DataRow _dtRow;

            _dt.Columns.Add("PointAction", typeof(int));
            _dt.Columns.Add("DefaultAction", typeof(int));
            _dt.Columns.Add("MissAction", typeof(int));
            _dt.Columns.Add("FaulAction", typeof(int));

            _ds.Tables.Add(_dt);

            _dtRow = _ds.Tables[0].NewRow();

            double[] _temp = new double[4];

            double _count = 0;

            Team _t = new Team();

            if(isMyTeam)
                _t = game.MyTeam;
            else
                _t = game.OppentTeam;

            foreach (Player _p in _t.TeamMember)
            {
                foreach (string _s in Player.GetAllActionName())
                {

                    object _o2 = _p.GetActionProperty(_p, _s);

                    if (_o2 == null) continue;

                    foreach (object _o in (IList)_o2)
                    {
                        if (_o is Miss)
                        {
                            _temp[2] += ((Miss)_o).ActionPoint;
                        }
                        else if (_o is Faul)
                        {
                            _temp[3] += ((Faul)_o).ActionPoint;
                        }
                        else if (_o is RelationPointAction)
                        {
                            _temp[0] += ((RelationPointAction)_o).ActionPoint;
                        }
                        else
                        {
                            _temp[1] += ((BaseClass.Action.Action)_o).ActionPoint;
                        }
                    }

                }

                _count++;
            }

            for (int _i = 0; _i < 4; _i++)
            {
                _temp[_i] /= _count;
                _dtRow[_i] = _temp[_i];
            }

            _ds.Tables[0].Rows.Add(_dtRow);

            return _ds;
        }

    }
}
