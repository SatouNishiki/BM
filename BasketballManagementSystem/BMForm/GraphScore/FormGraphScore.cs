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
using System.Windows.Forms.DataVisualization.Charting.ChartTypes;
using BasketballManagementSystem.BaseClass.Action;
using BasketballManagementSystem.BaseClass.Player;
using System.Windows.Forms.DataVisualization.Charting;
using BMErrorLibrary;
using BasketballManagementSystem.Manager.PrintManager;

namespace BasketballManagementSystem.BMForm.GraphScore
{
    //TODO: 絶望的に汚い

    public partial class FormGraphScore : Form
    {
        /// <summary>
        /// ゲームデータ格納用変数
        /// </summary>
        private Game game = new Game();

        private SaveDataManager saveDataManager = SaveDataManager.GetInstance();


        public FormGraphScore()
        {
            InitializeComponent();
           

            //このフォームが呼び出されたときにSaveDataをもらう
            game = saveDataManager.GetGame();

            PlotAllClear();

            foreach (Player p in game.MyTeam.TeamMember)
            {
                MyTeamList.Items.Add(p);
            }

            foreach (Player p in game.OppentTeam.TeamMember)
            {
                OppentTeamList.Items.Add(p);
            }

            PlotTeamAllPoint();
        }

        private void PlotAllClear()
        {
            ChartQuarter1.Series.Clear();
            ChartQuarter2.Series.Clear();
            ChartQuarter3.Series.Clear();
            ChartQuarter4.Series.Clear();
            ChartQuarterAll.Series.Clear();
        }

        private void PlotTeamAllPoint()
        {
            ChartQuarter1.Series.Add("MyAllPoint");
            ChartQuarter1.Series.Add("OppentAllPoint");

            ChartQuarter2.Series.Add("MyAllPoint");
            ChartQuarter2.Series.Add("OppentAllPoint");

            ChartQuarter3.Series.Add("MyAllPoint");
            ChartQuarter3.Series.Add("OppentAllPoint");

            ChartQuarter4.Series.Add("MyAllPoint");
            ChartQuarter4.Series.Add("OppentAllPoint");

            ChartQuarterAll.Series.Add("MyAllPoint");
            ChartQuarterAll.Series.Add("OppentAllPoint");

            
            ChartQuarter1.Series["MyAllPoint"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            ChartQuarter1.Series["OppentAllPoint"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            ChartQuarter2.Series["MyAllPoint"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            ChartQuarter2.Series["OppentAllPoint"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            ChartQuarter3.Series["MyAllPoint"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            ChartQuarter3.Series["OppentAllPoint"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            ChartQuarter4.Series["MyAllPoint"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            ChartQuarter4.Series["OppentAllPoint"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            ChartQuarterAll.Series["MyAllPoint"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            ChartQuarterAll.Series["OppentAllPoint"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
             
            
             
            //グラフの初期点の座標(左端の座標)を指定
            //これがないと最初に点数が入ったときにその座標に点だけが打たれ、折れ線にならない(2点目以降から折れ線グラフになる)
            ChartQuarter1.Series["MyAllPoint"].Points.AddXY(0, 0);
            ChartQuarter2.Series["MyAllPoint"].Points.AddXY(0, 0);
            ChartQuarter3.Series["MyAllPoint"].Points.AddXY(0, 0);
            ChartQuarter4.Series["MyAllPoint"].Points.AddXY(0, 0);
            ChartQuarterAll.Series["MyAllPoint"].Points.AddXY(0, 0);
          

            ChartQuarter1.Series["OppentAllPoint"].Points.AddXY(0, 0);
            ChartQuarter2.Series["OppentAllPoint"].Points.AddXY(0, 0);
            ChartQuarter3.Series["OppentAllPoint"].Points.AddXY(0, 0);
            ChartQuarter4.Series["OppentAllPoint"].Points.AddXY(0, 0);
            ChartQuarterAll.Series["OppentAllPoint"].Points.AddXY(0, 0);

            

            int point = 0;

            foreach (RelationPointAction r in game.MyTeam.GetQuarterPointAction(1))
            {
                point += r.point;

                ChartQuarter1.Series["MyAllPoint"].Points.AddXY(r.ElapsedTime.TotalSeconds, point);

            }

            point = 0;

            foreach (RelationPointAction r in game.OppentTeam.GetQuarterPointAction(1))
            {
                point += r.point;

                ChartQuarter1.Series["OppentAllPoint"].Points.AddXY(r.ElapsedTime.TotalSeconds, point);

            }


            point = 0;

            foreach (RelationPointAction r in game.MyTeam.GetQuarterPointAction(2))
            {
                point += r.point;

                ChartQuarter2.Series["MyAllPoint"].Points.AddXY(r.ElapsedTime.TotalSeconds, point);

            }

            point = 0;

            foreach (RelationPointAction r in game.OppentTeam.GetQuarterPointAction(2))
            {
                point += r.point;

                ChartQuarter2.Series["OppentAllPoint"].Points.AddXY(r.ElapsedTime.TotalSeconds,  point);

            }

            point = 0;

            foreach (RelationPointAction r in game.MyTeam.GetQuarterPointAction(3))
            {
                point += r.point;

                ChartQuarter3.Series["MyAllPoint"].Points.AddXY(r.ElapsedTime.TotalSeconds, point);

            }

            point = 0;

            foreach (RelationPointAction r in game.OppentTeam.GetQuarterPointAction(3))
            {
                point += r.point;

                ChartQuarter3.Series["OppentAllPoint"].Points.AddXY(r.ElapsedTime.TotalSeconds, point);

            }

            point = 0;

            foreach (RelationPointAction r in game.MyTeam.GetQuarterPointAction(4))
            {
                point += r.point;

                ChartQuarter4.Series["MyAllPoint"].Points.AddXY(r.ElapsedTime.TotalSeconds, point);

            }

            point = 0;

            foreach (RelationPointAction r in game.OppentTeam.GetQuarterPointAction(4))
            {
                point += r.point;

                ChartQuarter4.Series["OppentAllPoint"].Points.AddXY(r.ElapsedTime.TotalSeconds,  point);
            }


            point = 0;

            foreach (RelationPointAction r in game.MyTeam.GetQuarterPointActionAll())
            {
                point += r.point;

                ChartQuarterAll.Series["MyAllPoint"].Points.AddXY((int)((r.ActionDate - game.StartTime).TotalSeconds), point);
            }

            point = 0;

            foreach (RelationPointAction r in game.OppentTeam.GetQuarterPointActionAll())
            {
                point += r.point;

                ChartQuarterAll.Series["OppentAllPoint"].Points.AddXY((int)((r.ActionDate - game.StartTime).TotalSeconds), point);
            }

        }

        private void List_SelectedIndexChanged(object sender, EventArgs e)
        {
            PlotAllClear();

            PlotTeamAllPoint();

            ChartQuarter1.Series.Add("SelectPlayerAllPoint");
            ChartQuarter2.Series.Add("SelectPlayerAllPoint");
            ChartQuarter3.Series.Add("SelectPlayerAllPoint");
            ChartQuarter4.Series.Add("SelectPlayerAllPoint");
            ChartQuarterAll.Series.Add("SelectPlayerAllPoint");

            ChartQuarter1.Series["SelectPlayerAllPoint"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            ChartQuarter2.Series["SelectPlayerAllPoint"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            ChartQuarter3.Series["SelectPlayerAllPoint"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            ChartQuarter4.Series["SelectPlayerAllPoint"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            ChartQuarterAll.Series["SelectPlayerAllPoint"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            ChartQuarter1.Series["SelectPlayerAllPoint"].Points.AddXY(0, 0);
            ChartQuarter2.Series["SelectPlayerAllPoint"].Points.AddXY(0, 0);
            ChartQuarter3.Series["SelectPlayerAllPoint"].Points.AddXY(0, 0);
            ChartQuarter4.Series["SelectPlayerAllPoint"].Points.AddXY(0, 0);
            ChartQuarterAll.Series["SelectPlayerAllPoint"].Points.AddXY(0, 0);

            
            Player p = (Player)(((ListBox)sender).SelectedItem);

            int point = 0;

            foreach (RelationPointAction r in p.GetPointActionList(1, false))
            {
                point += r.point;

                ChartQuarter1.Series["SelectPlayerAllPoint"].Points.AddXY(r.ElapsedTime.TotalSeconds, point);
                
            }

            point = 0;

            foreach (RelationPointAction r in p.GetPointActionList(2, false))
            {
                point += r.point;

                ChartQuarter2.Series["SelectPlayerAllPoint"].Points.AddXY(r.ElapsedTime.TotalSeconds, point);

            }

            point = 0;

            foreach (RelationPointAction r in p.GetPointActionList(3, false))
            {
                point += r.point;

                ChartQuarter3.Series["SelectPlayerAllPoint"].Points.AddXY(r.ElapsedTime.TotalSeconds, point);

            }

            point = 0;

            foreach (RelationPointAction r in p.GetPointActionList(4, true))
            {
                point += r.point;

                ChartQuarter4.Series["SelectPlayerAllPoint"].Points.AddXY(r.ElapsedTime.TotalSeconds,  point);
            }

             point = 0;

            foreach (RelationPointAction r in p.GetPointActionList())
            {
                point += r.point;

                ChartQuarterAll.Series["SelectPlayerAllPoint"].Points.AddXY((int)((r.ActionDate - game.StartTime).TotalSeconds), point);
            }

        }

        /// <summary>
        /// タブのページが変わったときに再描画いれないとわかりにくい
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            PlotAllClear();
            PlotTeamAllPoint();
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
