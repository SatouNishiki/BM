namespace BasketballManagementSystem.BMForm.GraphScore
{
    partial class FormGraphScore
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGraphScore));
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title6 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title7 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title8 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea9 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend9 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title9 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea10 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend10 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title10 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.Quarter1Chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.MyTeamListBox = new System.Windows.Forms.ListBox();
            this.OppentTeamListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.Quarter1 = new System.Windows.Forms.TabPage();
            this.Quarter2 = new System.Windows.Forms.TabPage();
            this.Quarter2Chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Quarter3 = new System.Windows.Forms.TabPage();
            this.Quarter3Chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Quarter4 = new System.Windows.Forms.TabPage();
            this.Quarter4Chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.QuarterAllChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PrintFormItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PrintPreviewItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.Quarter1Chart)).BeginInit();
            this.TabControl1.SuspendLayout();
            this.Quarter1.SuspendLayout();
            this.Quarter2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Quarter2Chart)).BeginInit();
            this.Quarter3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Quarter3Chart)).BeginInit();
            this.Quarter4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Quarter4Chart)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QuarterAllChart)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Quarter1Chart
            // 
            chartArea6.AxisX.Minimum = 0D;
            chartArea6.AxisX.Title = "クォーター開始からの時間[Second]";
            chartArea6.AxisY.Minimum = 0D;
            chartArea6.AxisY.Title = "点数[点]";
            chartArea6.Name = "ChartArea1";
            this.Quarter1Chart.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.Quarter1Chart.Legends.Add(legend6);
            resources.ApplyResources(this.Quarter1Chart, "Quarter1Chart");
            this.Quarter1Chart.Name = "Quarter1Chart";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Legend = "Legend1";
            series6.Name = "Series1";
            this.Quarter1Chart.Series.Add(series6);
            title6.Name = "Title1";
            title6.Text = "クォーター1のグラフ";
            this.Quarter1Chart.Titles.Add(title6);
            // 
            // MyTeamListBox
            // 
            this.MyTeamListBox.FormattingEnabled = true;
            resources.ApplyResources(this.MyTeamListBox, "MyTeamListBox");
            this.MyTeamListBox.Name = "MyTeamListBox";
            this.MyTeamListBox.SelectedIndexChanged += new System.EventHandler(this.List_SelectedIndexChanged);
            // 
            // OppentTeamListBox
            // 
            this.OppentTeamListBox.FormattingEnabled = true;
            resources.ApplyResources(this.OppentTeamListBox, "OppentTeamListBox");
            this.OppentTeamListBox.Name = "OppentTeamListBox";
            this.OppentTeamListBox.SelectedIndexChanged += new System.EventHandler(this.List_SelectedIndexChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.DarkGreen;
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.DarkGreen;
            this.label2.Name = "label2";
            // 
            // TabControl1
            // 
            this.TabControl1.Controls.Add(this.Quarter1);
            this.TabControl1.Controls.Add(this.Quarter2);
            this.TabControl1.Controls.Add(this.Quarter3);
            this.TabControl1.Controls.Add(this.Quarter4);
            this.TabControl1.Controls.Add(this.tabPage1);
            resources.ApplyResources(this.TabControl1, "TabControl1");
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // Quarter1
            // 
            this.Quarter1.Controls.Add(this.Quarter1Chart);
            resources.ApplyResources(this.Quarter1, "Quarter1");
            this.Quarter1.Name = "Quarter1";
            this.Quarter1.UseVisualStyleBackColor = true;
            // 
            // Quarter2
            // 
            this.Quarter2.Controls.Add(this.Quarter2Chart);
            resources.ApplyResources(this.Quarter2, "Quarter2");
            this.Quarter2.Name = "Quarter2";
            this.Quarter2.UseVisualStyleBackColor = true;
            // 
            // Quarter2Chart
            // 
            chartArea7.AxisX.Minimum = 0D;
            chartArea7.AxisX.Title = "クォーター開始からの時間[Second]";
            chartArea7.AxisY.Minimum = 0D;
            chartArea7.AxisY.Title = "点数[点]";
            chartArea7.Name = "ChartArea1";
            this.Quarter2Chart.ChartAreas.Add(chartArea7);
            legend7.Name = "Legend1";
            this.Quarter2Chart.Legends.Add(legend7);
            resources.ApplyResources(this.Quarter2Chart, "Quarter2Chart");
            this.Quarter2Chart.Name = "Quarter2Chart";
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series7.Legend = "Legend1";
            series7.Name = "Series1";
            this.Quarter2Chart.Series.Add(series7);
            title7.Name = "Title1";
            title7.Text = "クォーター2のグラフ";
            this.Quarter2Chart.Titles.Add(title7);
            // 
            // Quarter3
            // 
            this.Quarter3.Controls.Add(this.Quarter3Chart);
            resources.ApplyResources(this.Quarter3, "Quarter3");
            this.Quarter3.Name = "Quarter3";
            this.Quarter3.UseVisualStyleBackColor = true;
            // 
            // Quarter3Chart
            // 
            chartArea8.AxisX.Minimum = 0D;
            chartArea8.AxisX.Title = "クォーター開始からの時間[Second]";
            chartArea8.AxisY.Minimum = 0D;
            chartArea8.AxisY.Title = "点数[点]";
            chartArea8.Name = "ChartArea1";
            this.Quarter3Chart.ChartAreas.Add(chartArea8);
            legend8.Name = "Legend1";
            this.Quarter3Chart.Legends.Add(legend8);
            resources.ApplyResources(this.Quarter3Chart, "Quarter3Chart");
            this.Quarter3Chart.Name = "Quarter3Chart";
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series8.Legend = "Legend1";
            series8.Name = "Series1";
            this.Quarter3Chart.Series.Add(series8);
            title8.Name = "Title1";
            title8.Text = "クォーター3のグラフ";
            this.Quarter3Chart.Titles.Add(title8);
            // 
            // Quarter4
            // 
            this.Quarter4.Controls.Add(this.Quarter4Chart);
            resources.ApplyResources(this.Quarter4, "Quarter4");
            this.Quarter4.Name = "Quarter4";
            this.Quarter4.UseVisualStyleBackColor = true;
            // 
            // Quarter4Chart
            // 
            chartArea9.AxisX.Minimum = 0D;
            chartArea9.AxisX.Title = "クォーター開始からの時間[Second]";
            chartArea9.AxisY.Minimum = 0D;
            chartArea9.AxisY.Title = "点数[点]";
            chartArea9.Name = "ChartArea1";
            this.Quarter4Chart.ChartAreas.Add(chartArea9);
            legend9.Name = "Legend1";
            this.Quarter4Chart.Legends.Add(legend9);
            resources.ApplyResources(this.Quarter4Chart, "Quarter4Chart");
            this.Quarter4Chart.Name = "Quarter4Chart";
            series9.ChartArea = "ChartArea1";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series9.Legend = "Legend1";
            series9.Name = "Series1";
            this.Quarter4Chart.Series.Add(series9);
            title9.Name = "Title1";
            title9.Text = "クォーター4のグラフ";
            this.Quarter4Chart.Titles.Add(title9);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.QuarterAllChart);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // QuarterAllChart
            // 
            chartArea10.AxisX.Minimum = 0D;
            chartArea10.AxisX.Title = "試合開始からの時間[Second]";
            chartArea10.AxisY.Minimum = 0D;
            chartArea10.AxisY.Title = "点数[点]";
            chartArea10.Name = "ChartArea1";
            this.QuarterAllChart.ChartAreas.Add(chartArea10);
            legend10.Name = "Legend1";
            this.QuarterAllChart.Legends.Add(legend10);
            resources.ApplyResources(this.QuarterAllChart, "QuarterAllChart");
            this.QuarterAllChart.Name = "QuarterAllChart";
            series10.ChartArea = "ChartArea1";
            series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series10.Legend = "Legend1";
            series10.Name = "Series1";
            this.QuarterAllChart.Series.Add(series10);
            title10.Name = "Title1";
            title10.Text = "試合全体のグラフ";
            this.QuarterAllChart.Titles.Add(title10);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PrintFormItem,
            this.PrintPreviewItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            resources.ApplyResources(this.FileToolStripMenuItem, "FileToolStripMenuItem");
            // 
            // PrintFormItem
            // 
            this.PrintFormItem.Name = "PrintFormItem";
            resources.ApplyResources(this.PrintFormItem, "PrintFormItem");
            this.PrintFormItem.Click += new System.EventHandler(this.PrintForm_Click);
            // 
            // PrintPreviewItem
            // 
            this.PrintPreviewItem.Name = "PrintPreviewItem";
            resources.ApplyResources(this.PrintPreviewItem, "PrintPreviewItem");
            this.PrintPreviewItem.Click += new System.EventHandler(this.PrintPreview_Click);
            // 
            // FormGraphScore
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TabControl1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OppentTeamListBox);
            this.Controls.Add(this.MyTeamListBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormGraphScore";
            ((System.ComponentModel.ISupportInitialize)(this.Quarter1Chart)).EndInit();
            this.TabControl1.ResumeLayout(false);
            this.Quarter1.ResumeLayout(false);
            this.Quarter2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Quarter2Chart)).EndInit();
            this.Quarter3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Quarter3Chart)).EndInit();
            this.Quarter4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Quarter4Chart)).EndInit();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.QuarterAllChart)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart Quarter1Chart;
        private System.Windows.Forms.ListBox MyTeamListBox;
        private System.Windows.Forms.ListBox OppentTeamListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl TabControl1;
        private System.Windows.Forms.TabPage Quarter1;
        private System.Windows.Forms.TabPage Quarter2;
        private System.Windows.Forms.DataVisualization.Charting.Chart Quarter2Chart;
        private System.Windows.Forms.TabPage Quarter3;
        private System.Windows.Forms.DataVisualization.Charting.Chart Quarter3Chart;
        private System.Windows.Forms.TabPage Quarter4;
        private System.Windows.Forms.DataVisualization.Charting.Chart Quarter4Chart;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataVisualization.Charting.Chart QuarterAllChart;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PrintFormItem;
        private System.Windows.Forms.ToolStripMenuItem PrintPreviewItem;
    }
}