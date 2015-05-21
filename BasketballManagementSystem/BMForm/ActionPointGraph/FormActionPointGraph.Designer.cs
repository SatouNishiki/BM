namespace BasketballManagementSystem.BMForm.ActionPointGraph
{
    partial class FormActionPointGraph
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormActionPointGraph));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.ActionPointChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.MyTeamList = new System.Windows.Forms.ListBox();
            this.OppentTeamList = new System.Windows.Forms.ListBox();
            this.OppentTeamName = new System.Windows.Forms.Label();
            this.MyTeamName = new System.Windows.Forms.Label();
            this.ActionPointGraphTab = new System.Windows.Forms.TabControl();
            this.APRadarChart = new System.Windows.Forms.TabPage();
            this.APShiftGraph = new System.Windows.Forms.TabPage();
            this.ActionPointShitGraph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.ActionPointChart)).BeginInit();
            this.ActionPointGraphTab.SuspendLayout();
            this.APRadarChart.SuspendLayout();
            this.APShiftGraph.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ActionPointShitGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // ActionPointChart
            // 
            resources.ApplyResources(this.ActionPointChart, "ActionPointChart");
            chartArea3.Name = "ChartArea1";
            this.ActionPointChart.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.ActionPointChart.Legends.Add(legend3);
            this.ActionPointChart.Name = "ActionPointChart";
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Radar;
            series7.Legend = "Legend1";
            series7.Name = "PlayerActionPoint";
            series8.BorderColor = System.Drawing.Color.Orange;
            series8.BorderWidth = 5;
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Radar;
            series8.Color = System.Drawing.Color.Transparent;
            series8.Legend = "Legend1";
            series8.Name = "AverageActionPoint";
            this.ActionPointChart.Series.Add(series7);
            this.ActionPointChart.Series.Add(series8);
            // 
            // MyTeamList
            // 
            resources.ApplyResources(this.MyTeamList, "MyTeamList");
            this.MyTeamList.FormattingEnabled = true;
            this.MyTeamList.Name = "MyTeamList";
            this.MyTeamList.SelectedIndexChanged += new System.EventHandler(this.TeamList_SelectedIndexChanged);
            // 
            // OppentTeamList
            // 
            resources.ApplyResources(this.OppentTeamList, "OppentTeamList");
            this.OppentTeamList.FormattingEnabled = true;
            this.OppentTeamList.Name = "OppentTeamList";
            this.OppentTeamList.SelectedIndexChanged += new System.EventHandler(this.TeamList_SelectedIndexChanged);
            // 
            // OppentTeamName
            // 
            resources.ApplyResources(this.OppentTeamName, "OppentTeamName");
            this.OppentTeamName.Name = "OppentTeamName";
            // 
            // MyTeamName
            // 
            resources.ApplyResources(this.MyTeamName, "MyTeamName");
            this.MyTeamName.Name = "MyTeamName";
            // 
            // ActionPointGraphTab
            // 
            resources.ApplyResources(this.ActionPointGraphTab, "ActionPointGraphTab");
            this.ActionPointGraphTab.Controls.Add(this.APRadarChart);
            this.ActionPointGraphTab.Controls.Add(this.APShiftGraph);
            this.ActionPointGraphTab.Name = "ActionPointGraphTab";
            this.ActionPointGraphTab.SelectedIndex = 0;
            // 
            // APRadarChart
            // 
            resources.ApplyResources(this.APRadarChart, "APRadarChart");
            this.APRadarChart.Controls.Add(this.ActionPointChart);
            this.APRadarChart.Name = "APRadarChart";
            this.APRadarChart.UseVisualStyleBackColor = true;
            // 
            // APShiftGraph
            // 
            resources.ApplyResources(this.APShiftGraph, "APShiftGraph");
            this.APShiftGraph.Controls.Add(this.ActionPointShitGraph);
            this.APShiftGraph.Name = "APShiftGraph";
            this.APShiftGraph.UseVisualStyleBackColor = true;
            // 
            // ActionPointShitGraph
            // 
            resources.ApplyResources(this.ActionPointShitGraph, "ActionPointShitGraph");
            chartArea4.Name = "ChartArea1";
            this.ActionPointShitGraph.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.ActionPointShitGraph.Legends.Add(legend4);
            this.ActionPointShitGraph.Name = "ActionPointShitGraph";
            series9.ChartArea = "ChartArea1";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series9.Legend = "Legend1";
            series9.Name = "PointAction";
            series10.ChartArea = "ChartArea1";
            series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series10.Legend = "Legend1";
            series10.Name = "DefaultAction";
            series11.ChartArea = "ChartArea1";
            series11.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series11.Legend = "Legend1";
            series11.Name = "MissAction";
            series12.ChartArea = "ChartArea1";
            series12.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series12.Legend = "Legend1";
            series12.Name = "FaulAction";
            this.ActionPointShitGraph.Series.Add(series9);
            this.ActionPointShitGraph.Series.Add(series10);
            this.ActionPointShitGraph.Series.Add(series11);
            this.ActionPointShitGraph.Series.Add(series12);
            // 
            // FormActionPointGraph
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ActionPointGraphTab);
            this.Controls.Add(this.MyTeamName);
            this.Controls.Add(this.OppentTeamName);
            this.Controls.Add(this.OppentTeamList);
            this.Controls.Add(this.MyTeamList);
            this.Name = "FormActionPointGraph";
            ((System.ComponentModel.ISupportInitialize)(this.ActionPointChart)).EndInit();
            this.ActionPointGraphTab.ResumeLayout(false);
            this.APRadarChart.ResumeLayout(false);
            this.APShiftGraph.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ActionPointShitGraph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart ActionPointChart;
        private System.Windows.Forms.ListBox MyTeamList;
        private System.Windows.Forms.ListBox OppentTeamList;
        private System.Windows.Forms.Label OppentTeamName;
        private System.Windows.Forms.Label MyTeamName;
        private System.Windows.Forms.TabControl ActionPointGraphTab;
        private System.Windows.Forms.TabPage APRadarChart;
        private System.Windows.Forms.TabPage APShiftGraph;
        private System.Windows.Forms.DataVisualization.Charting.Chart ActionPointShitGraph;
    }
}