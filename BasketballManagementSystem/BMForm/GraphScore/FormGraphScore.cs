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
using System.Windows.Forms.DataVisualization.Charting.ChartTypes;
using BasketballManagementSystem.baseClass.action;
using BasketballManagementSystem.baseClass.player;
using System.Windows.Forms.DataVisualization.Charting;
using BMErrorLibrary;

namespace BasketballManagementSystem.bmForm.graphScore
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

            foreach (var p in game.MyTeam.TeamMember)
            {
                MyTeamListBox.Items.Add(p);
            }

            foreach (var p in game.OppentTeam.TeamMember)
            {
                OppentTeamListBox.Items.Add(p);
            }

            PlotTeamAllPoint();
        }

        private void PlotAllClear()
        {
            Quarter1Chart.Series.Clear();
            Quarter2Chart.Series.Clear();
            Quarter3Chart.Series.Clear();
            Quarter4Chart.Series.Clear();
            QuarterAllChart.Series.Clear();
        }

        private void PlotTeamAllPoint()
        {
            Quarter1Chart.Series.Add("MyAllPoint");
            Quarter1Chart.Series.Add("OppentAllPoint");

            Quarter2Chart.Series.Add("MyAllPoint");
            Quarter2Chart.Series.Add("OppentAllPoint");

            Quarter3Chart.Series.Add("MyAllPoint");
            Quarter3Chart.Series.Add("OppentAllPoint");

            Quarter4Chart.Series.Add("MyAllPoint");
            Quarter4Chart.Series.Add("OppentAllPoint");

            QuarterAllChart.Series.Add("MyAllPoint");
            QuarterAllChart.Series.Add("OppentAllPoint");

            
            Quarter1Chart.Series["MyAllPoint"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            Quarter1Chart.Series["OppentAllPoint"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            Quarter2Chart.Series["MyAllPoint"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            Quarter2Chart.Series["OppentAllPoint"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            Quarter3Chart.Series["MyAllPoint"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            Quarter3Chart.Series["OppentAllPoint"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            Quarter4Chart.Series["MyAllPoint"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            Quarter4Chart.Series["OppentAllPoint"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            QuarterAllChart.Series["MyAllPoint"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            QuarterAllChart.Series["OppentAllPoint"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
             
            
             
            //グラフの初期点の座標(左端の座標)を指定
            //これがないと最初に点数が入ったときにその座標に点だけが打たれ、折れ線にならない(2点目以降から折れ線グラフになる)
            Quarter1Chart.Series["MyAllPoint"].Points.AddXY(0, 0);
            Quarter2Chart.Series["MyAllPoint"].Points.AddXY(0, 0);
            Quarter3Chart.Series["MyAllPoint"].Points.AddXY(0, 0);
            Quarter4Chart.Series["MyAllPoint"].Points.AddXY(0, 0);
            QuarterAllChart.Series["MyAllPoint"].Points.AddXY(0, 0);
          

            Quarter1Chart.Series["OppentAllPoint"].Points.AddXY(0, 0);
            Quarter2Chart.Series["OppentAllPoint"].Points.AddXY(0, 0);
            Quarter3Chart.Series["OppentAllPoint"].Points.AddXY(0, 0);
            Quarter4Chart.Series["OppentAllPoint"].Points.AddXY(0, 0);
            QuarterAllChart.Series["OppentAllPoint"].Points.AddXY(0, 0);

            

            int point = 0;

            foreach (var r in ActionListConverter.ToRelationPointActionList(game.MyTeam.GetQuarterAction(1)))
            {
                point += r.Point;

                Quarter1Chart.Series["MyAllPoint"].Points.AddXY(r.ElapsedTime.TotalSeconds, point);

            }

            point = 0;

            foreach (var r in ActionListConverter.ToRelationPointActionList(game.OppentTeam.GetQuarterAction(1)))
            {
                point += r.Point;

                Quarter1Chart.Series["OppentAllPoint"].Points.AddXY(r.ElapsedTime.TotalSeconds, point);

            }


            point = 0;

            foreach (var r in ActionListConverter.ToRelationPointActionList(game.MyTeam.GetQuarterAction(2)))
            {
                point += r.Point;

                Quarter2Chart.Series["MyAllPoint"].Points.AddXY(r.ElapsedTime.TotalSeconds, point);

            }

            point = 0;

            foreach (var r in ActionListConverter.ToRelationPointActionList(game.OppentTeam.GetQuarterAction(2)))
            {
                point += r.Point;

                Quarter2Chart.Series["OppentAllPoint"].Points.AddXY(r.ElapsedTime.TotalSeconds,  point);

            }

            point = 0;

            foreach (var r in ActionListConverter.ToRelationPointActionList(game.MyTeam.GetQuarterAction(3)))
            {
                point += r.Point;

                Quarter3Chart.Series["MyAllPoint"].Points.AddXY(r.ElapsedTime.TotalSeconds, point);

            }

            point = 0;

            foreach (var r in ActionListConverter.ToRelationPointActionList(game.OppentTeam.GetQuarterAction(3)))
            {
                point += r.Point;

                Quarter3Chart.Series["OppentAllPoint"].Points.AddXY(r.ElapsedTime.TotalSeconds, point);

            }

            point = 0;

            foreach (var r in ActionListConverter.ToRelationPointActionList(game.MyTeam.GetQuarterAction(4)))
            {
                point += r.Point;

                Quarter4Chart.Series["MyAllPoint"].Points.AddXY(r.ElapsedTime.TotalSeconds, point);

            }

            point = 0;

            foreach (var r in ActionListConverter.ToRelationPointActionList(game.OppentTeam.GetQuarterAction(4)))
            {
                point += r.Point;

                Quarter4Chart.Series["OppentAllPoint"].Points.AddXY(r.ElapsedTime.TotalSeconds,  point);
            }


            point = 0;

            foreach (var r in ActionListConverter.ToRelationPointActionList(game.MyTeam.GetActionAll()))
            {
                point += r.Point;

                QuarterAllChart.Series["MyAllPoint"].Points.AddXY((int)((r.ActionDate - game.StartTime).TotalSeconds), point);
            }

            point = 0;

            foreach (var r in ActionListConverter.ToRelationPointActionList(game.OppentTeam.GetActionAll()))
            {
                point += r.Point;

                QuarterAllChart.Series["OppentAllPoint"].Points.AddXY((int)((r.ActionDate - game.StartTime).TotalSeconds), point);
            }

        }

        private void List_SelectedIndexChanged(object sender, EventArgs e)
        {
            PlotAllClear();

            PlotTeamAllPoint();

            Quarter1Chart.Series.Add("SelectPlayerAllPoint");
            Quarter2Chart.Series.Add("SelectPlayerAllPoint");
            Quarter3Chart.Series.Add("SelectPlayerAllPoint");
            Quarter4Chart.Series.Add("SelectPlayerAllPoint");
            QuarterAllChart.Series.Add("SelectPlayerAllPoint");

            Quarter1Chart.Series["SelectPlayerAllPoint"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            Quarter2Chart.Series["SelectPlayerAllPoint"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            Quarter3Chart.Series["SelectPlayerAllPoint"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            Quarter4Chart.Series["SelectPlayerAllPoint"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            QuarterAllChart.Series["SelectPlayerAllPoint"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            Quarter1Chart.Series["SelectPlayerAllPoint"].Points.AddXY(0, 0);
            Quarter2Chart.Series["SelectPlayerAllPoint"].Points.AddXY(0, 0);
            Quarter3Chart.Series["SelectPlayerAllPoint"].Points.AddXY(0, 0);
            Quarter4Chart.Series["SelectPlayerAllPoint"].Points.AddXY(0, 0);
            QuarterAllChart.Series["SelectPlayerAllPoint"].Points.AddXY(0, 0);

            
            Player p = (Player)(((ListBox)sender).SelectedItem);

            int point = 0;

            foreach (var r in ActionListConverter.ToRelationPointActionList(p.GetActionList(p, 1)))
            {
                point += r.Point;

                Quarter1Chart.Series["SelectPlayerAllPoint"].Points.AddXY(r.ElapsedTime.TotalSeconds, point);
                
            }

            point = 0;

            foreach (var r in ActionListConverter.ToRelationPointActionList(p.GetActionList(p, 2)))
            {
                point += r.Point;

                Quarter2Chart.Series["SelectPlayerAllPoint"].Points.AddXY(r.ElapsedTime.TotalSeconds, point);

            }

            point = 0;

            foreach (var r in ActionListConverter.ToRelationPointActionList(p.GetActionList(p, 3)))
            {
                point += r.Point;

                Quarter3Chart.Series["SelectPlayerAllPoint"].Points.AddXY(r.ElapsedTime.TotalSeconds, point);

            }

            point = 0;

            foreach (var r in ActionListConverter.ToRelationPointActionList(p.GetActionList(p, 4)))
            {
                point += r.Point;

                Quarter4Chart.Series["SelectPlayerAllPoint"].Points.AddXY(r.ElapsedTime.TotalSeconds,  point);
            }

             point = 0;

            foreach (var r in ActionListConverter.ToRelationPointActionList(p.GetActionList(p)))
            {
                point += r.Point;

                QuarterAllChart.Series["SelectPlayerAllPoint"].Points.AddXY((int)((r.ActionDate - game.StartTime).TotalSeconds), point);
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
