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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.ActionPointChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.MyTeamList = new System.Windows.Forms.ListBox();
            this.OppentTeamList = new System.Windows.Forms.ListBox();
            this.OppentTeamName = new System.Windows.Forms.Label();
            this.MyTeamName = new System.Windows.Forms.Label();
            this.ActionPointGraphTab = new System.Windows.Forms.TabControl();
            this.APRadarChart = new System.Windows.Forms.TabPage();
            this.APShiftGraph = new System.Windows.Forms.TabPage();
            this.ActionPointShitGraph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PrintFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PrintPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.ActionPointChart)).BeginInit();
            this.ActionPointGraphTab.SuspendLayout();
            this.APRadarChart.SuspendLayout();
            this.APShiftGraph.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ActionPointShitGraph)).BeginInit();
            this.MenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ActionPointChart
            // 
            resources.ApplyResources(this.ActionPointChart, "ActionPointChart");
            chartArea1.Name = "ChartArea1";
            this.ActionPointChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.ActionPointChart.Legends.Add(legend1);
            this.ActionPointChart.Name = "ActionPointChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Radar;
            series1.Legend = "Legend1";
            series1.Name = "PlayerActionPoint";
            series2.BorderColor = System.Drawing.Color.Orange;
            series2.BorderWidth = 5;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Radar;
            series2.Color = System.Drawing.Color.Transparent;
            series2.Legend = "Legend1";
            series2.Name = "AverageActionPoint";
            this.ActionPointChart.Series.Add(series1);
            this.ActionPointChart.Series.Add(series2);
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
            chartArea2.Name = "ChartArea1";
            this.ActionPointShitGraph.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.ActionPointShitGraph.Legends.Add(legend2);
            this.ActionPointShitGraph.Name = "ActionPointShitGraph";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Legend = "Legend1";
            series3.Name = "PointAction";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Legend = "Legend1";
            series4.Name = "DefaultAction";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Legend = "Legend1";
            series5.Name = "MissAction";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Legend = "Legend1";
            series6.Name = "FaulAction";
            this.ActionPointShitGraph.Series.Add(series3);
            this.ActionPointShitGraph.Series.Add(series4);
            this.ActionPointShitGraph.Series.Add(series5);
            this.ActionPointShitGraph.Series.Add(series6);
            // 
            // MenuStrip
            // 
            resources.ApplyResources(this.MenuStrip, "MenuStrip");
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem});
            this.MenuStrip.Name = "MenuStrip";
            // 
            // FileToolStripMenuItem
            // 
            resources.ApplyResources(this.FileToolStripMenuItem, "FileToolStripMenuItem");
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PrintFormToolStripMenuItem,
            this.PrintPreviewToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            // 
            // PrintFormToolStripMenuItem
            // 
            resources.ApplyResources(this.PrintFormToolStripMenuItem, "PrintFormToolStripMenuItem");
            this.PrintFormToolStripMenuItem.Name = "PrintFormToolStripMenuItem";
            this.PrintFormToolStripMenuItem.Click += new System.EventHandler(this.PrintFormToolStripMenuItem_Click);
            // 
            // PrintPreviewToolStripMenuItem
            // 
            resources.ApplyResources(this.PrintPreviewToolStripMenuItem, "PrintPreviewToolStripMenuItem");
            this.PrintPreviewToolStripMenuItem.Name = "PrintPreviewToolStripMenuItem";
            this.PrintPreviewToolStripMenuItem.Click += new System.EventHandler(this.PrintPreviewToolStripMenuItem_Click);
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
            this.Controls.Add(this.MenuStrip);
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "FormActionPointGraph";
            ((System.ComponentModel.ISupportInitialize)(this.ActionPointChart)).EndInit();
            this.ActionPointGraphTab.ResumeLayout(false);
            this.APRadarChart.ResumeLayout(false);
            this.APShiftGraph.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ActionPointShitGraph)).EndInit();
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
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
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PrintFormToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PrintPreviewToolStripMenuItem;
    }
}