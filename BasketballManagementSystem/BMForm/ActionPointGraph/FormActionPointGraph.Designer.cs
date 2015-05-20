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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.ActionPointChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.MyTeamList = new System.Windows.Forms.ListBox();
            this.OppentTeamList = new System.Windows.Forms.ListBox();
            this.OppentTeamName = new System.Windows.Forms.Label();
            this.MyTeamName = new System.Windows.Forms.Label();
            this.ActionPointGraphTab = new System.Windows.Forms.TabControl();
            this.APRadarChart = new System.Windows.Forms.TabPage();
            this.APShiftGraph = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.ActionPointChart)).BeginInit();
            this.ActionPointGraphTab.SuspendLayout();
            this.APRadarChart.SuspendLayout();
            this.SuspendLayout();
            // 
            // ActionPointChart
            // 
            chartArea1.Name = "ChartArea1";
            this.ActionPointChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.ActionPointChart.Legends.Add(legend1);
            this.ActionPointChart.Location = new System.Drawing.Point(3, 3);
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
            this.ActionPointChart.Size = new System.Drawing.Size(475, 333);
            this.ActionPointChart.TabIndex = 0;
            // 
            // MyTeamList
            // 
            this.MyTeamList.FormattingEnabled = true;
            this.MyTeamList.ItemHeight = 12;
            this.MyTeamList.Location = new System.Drawing.Point(12, 49);
            this.MyTeamList.Name = "MyTeamList";
            this.MyTeamList.Size = new System.Drawing.Size(131, 148);
            this.MyTeamList.TabIndex = 1;
            this.MyTeamList.SelectedIndexChanged += new System.EventHandler(this.TeamList_SelectedIndexChanged);
            // 
            // OppentTeamList
            // 
            this.OppentTeamList.FormattingEnabled = true;
            this.OppentTeamList.ItemHeight = 12;
            this.OppentTeamList.Location = new System.Drawing.Point(12, 230);
            this.OppentTeamList.Name = "OppentTeamList";
            this.OppentTeamList.Size = new System.Drawing.Size(131, 148);
            this.OppentTeamList.TabIndex = 2;
            this.OppentTeamList.SelectedIndexChanged += new System.EventHandler(this.TeamList_SelectedIndexChanged);
            // 
            // OppentTeamName
            // 
            this.OppentTeamName.AutoSize = true;
            this.OppentTeamName.Location = new System.Drawing.Point(12, 215);
            this.OppentTeamName.Name = "OppentTeamName";
            this.OppentTeamName.Size = new System.Drawing.Size(98, 12);
            this.OppentTeamName.TabIndex = 3;
            this.OppentTeamName.Text = "OppentTeamName";
            // 
            // MyTeamName
            // 
            this.MyTeamName.AutoSize = true;
            this.MyTeamName.Location = new System.Drawing.Point(12, 33);
            this.MyTeamName.Name = "MyTeamName";
            this.MyTeamName.Size = new System.Drawing.Size(77, 12);
            this.MyTeamName.TabIndex = 4;
            this.MyTeamName.Text = "MyTeamName";
            // 
            // ActionPointGraphTab
            // 
            this.ActionPointGraphTab.Controls.Add(this.APRadarChart);
            this.ActionPointGraphTab.Controls.Add(this.APShiftGraph);
            this.ActionPointGraphTab.Location = new System.Drawing.Point(179, 13);
            this.ActionPointGraphTab.Name = "ActionPointGraphTab";
            this.ActionPointGraphTab.SelectedIndex = 0;
            this.ActionPointGraphTab.Size = new System.Drawing.Size(496, 365);
            this.ActionPointGraphTab.TabIndex = 5;
            // 
            // APRadarChart
            // 
            this.APRadarChart.Controls.Add(this.ActionPointChart);
            this.APRadarChart.Location = new System.Drawing.Point(4, 22);
            this.APRadarChart.Name = "APRadarChart";
            this.APRadarChart.Padding = new System.Windows.Forms.Padding(3);
            this.APRadarChart.Size = new System.Drawing.Size(488, 339);
            this.APRadarChart.TabIndex = 0;
            this.APRadarChart.Text = "RadarChart";
            this.APRadarChart.UseVisualStyleBackColor = true;
            // 
            // APShiftGraph
            // 
            this.APShiftGraph.Location = new System.Drawing.Point(4, 22);
            this.APShiftGraph.Name = "APShiftGraph";
            this.APShiftGraph.Padding = new System.Windows.Forms.Padding(3);
            this.APShiftGraph.Size = new System.Drawing.Size(488, 339);
            this.APShiftGraph.TabIndex = 1;
            this.APShiftGraph.Text = "ShiftGraph";
            this.APShiftGraph.UseVisualStyleBackColor = true;
            // 
            // FormActionPointGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 390);
            this.Controls.Add(this.ActionPointGraphTab);
            this.Controls.Add(this.MyTeamName);
            this.Controls.Add(this.OppentTeamName);
            this.Controls.Add(this.OppentTeamList);
            this.Controls.Add(this.MyTeamList);
            this.Name = "FormActionPointGraph";
            this.Text = "FormActionPointGraph";
            ((System.ComponentModel.ISupportInitialize)(this.ActionPointChart)).EndInit();
            this.ActionPointGraphTab.ResumeLayout(false);
            this.APRadarChart.ResumeLayout(false);
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
    }
}