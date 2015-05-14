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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGraphScore));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title4 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title5 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.ChartQuarter1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.MyTeamList = new System.Windows.Forms.ListBox();
            this.OppentTeamList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Quarter1 = new System.Windows.Forms.TabPage();
            this.Quarter2 = new System.Windows.Forms.TabPage();
            this.ChartQuarter2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Quarter3 = new System.Windows.Forms.TabPage();
            this.ChartQuarter3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Quarter4 = new System.Windows.Forms.TabPage();
            this.ChartQuarter4 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ChartQuarterAll = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ファイルToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PrintForm = new System.Windows.Forms.ToolStripMenuItem();
            this.PrintPreview = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.ChartQuarter1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.Quarter1.SuspendLayout();
            this.Quarter2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChartQuarter2)).BeginInit();
            this.Quarter3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChartQuarter3)).BeginInit();
            this.Quarter4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChartQuarter4)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChartQuarterAll)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ChartQuarter1
            // 
            resources.ApplyResources(this.ChartQuarter1, "ChartQuarter1");
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisX.Title = "クォーター開始からの時間[Second]";
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.AxisY.Title = "点数[点]";
            chartArea1.Name = "ChartArea1";
            this.ChartQuarter1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.ChartQuarter1.Legends.Add(legend1);
            this.ChartQuarter1.Name = "ChartQuarter1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.ChartQuarter1.Series.Add(series1);
            title1.Name = "Title1";
            title1.Text = "クォーター1のグラフ";
            this.ChartQuarter1.Titles.Add(title1);
            // 
            // MyTeamList
            // 
            resources.ApplyResources(this.MyTeamList, "MyTeamList");
            this.MyTeamList.FormattingEnabled = true;
            this.MyTeamList.Name = "MyTeamList";
            this.MyTeamList.SelectedIndexChanged += new System.EventHandler(this.List_SelectedIndexChanged);
            // 
            // OppentTeamList
            // 
            resources.ApplyResources(this.OppentTeamList, "OppentTeamList");
            this.OppentTeamList.FormattingEnabled = true;
            this.OppentTeamList.Name = "OppentTeamList";
            this.OppentTeamList.SelectedIndexChanged += new System.EventHandler(this.List_SelectedIndexChanged);
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
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Controls.Add(this.Quarter1);
            this.tabControl1.Controls.Add(this.Quarter2);
            this.tabControl1.Controls.Add(this.Quarter3);
            this.tabControl1.Controls.Add(this.Quarter4);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // Quarter1
            // 
            resources.ApplyResources(this.Quarter1, "Quarter1");
            this.Quarter1.Controls.Add(this.ChartQuarter1);
            this.Quarter1.Name = "Quarter1";
            this.Quarter1.UseVisualStyleBackColor = true;
            // 
            // Quarter2
            // 
            resources.ApplyResources(this.Quarter2, "Quarter2");
            this.Quarter2.Controls.Add(this.ChartQuarter2);
            this.Quarter2.Name = "Quarter2";
            this.Quarter2.UseVisualStyleBackColor = true;
            // 
            // ChartQuarter2
            // 
            resources.ApplyResources(this.ChartQuarter2, "ChartQuarter2");
            chartArea2.AxisX.Minimum = 0D;
            chartArea2.AxisX.Title = "クォーター開始からの時間[Second]";
            chartArea2.AxisY.Minimum = 0D;
            chartArea2.AxisY.Title = "点数[点]";
            chartArea2.Name = "ChartArea1";
            this.ChartQuarter2.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.ChartQuarter2.Legends.Add(legend2);
            this.ChartQuarter2.Name = "ChartQuarter2";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.ChartQuarter2.Series.Add(series2);
            title2.Name = "Title1";
            title2.Text = "クォーター2のグラフ";
            this.ChartQuarter2.Titles.Add(title2);
            // 
            // Quarter3
            // 
            resources.ApplyResources(this.Quarter3, "Quarter3");
            this.Quarter3.Controls.Add(this.ChartQuarter3);
            this.Quarter3.Name = "Quarter3";
            this.Quarter3.UseVisualStyleBackColor = true;
            // 
            // ChartQuarter3
            // 
            resources.ApplyResources(this.ChartQuarter3, "ChartQuarter3");
            chartArea3.AxisX.Minimum = 0D;
            chartArea3.AxisX.Title = "クォーター開始からの時間[Second]";
            chartArea3.AxisY.Minimum = 0D;
            chartArea3.AxisY.Title = "点数[点]";
            chartArea3.Name = "ChartArea1";
            this.ChartQuarter3.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.ChartQuarter3.Legends.Add(legend3);
            this.ChartQuarter3.Name = "ChartQuarter3";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.ChartQuarter3.Series.Add(series3);
            title3.Name = "Title1";
            title3.Text = "クォーター3のグラフ";
            this.ChartQuarter3.Titles.Add(title3);
            // 
            // Quarter4
            // 
            resources.ApplyResources(this.Quarter4, "Quarter4");
            this.Quarter4.Controls.Add(this.ChartQuarter4);
            this.Quarter4.Name = "Quarter4";
            this.Quarter4.UseVisualStyleBackColor = true;
            // 
            // ChartQuarter4
            // 
            resources.ApplyResources(this.ChartQuarter4, "ChartQuarter4");
            chartArea4.AxisX.Minimum = 0D;
            chartArea4.AxisX.Title = "クォーター開始からの時間[Second]";
            chartArea4.AxisY.Minimum = 0D;
            chartArea4.AxisY.Title = "点数[点]";
            chartArea4.Name = "ChartArea1";
            this.ChartQuarter4.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.ChartQuarter4.Legends.Add(legend4);
            this.ChartQuarter4.Name = "ChartQuarter4";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.ChartQuarter4.Series.Add(series4);
            title4.Name = "Title1";
            title4.Text = "クォーター4のグラフ";
            this.ChartQuarter4.Titles.Add(title4);
            // 
            // tabPage1
            // 
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Controls.Add(this.ChartQuarterAll);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ChartQuarterAll
            // 
            resources.ApplyResources(this.ChartQuarterAll, "ChartQuarterAll");
            chartArea5.AxisX.Minimum = 0D;
            chartArea5.AxisX.Title = "試合開始からの時間[Second]";
            chartArea5.AxisY.Minimum = 0D;
            chartArea5.AxisY.Title = "点数[点]";
            chartArea5.Name = "ChartArea1";
            this.ChartQuarterAll.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.ChartQuarterAll.Legends.Add(legend5);
            this.ChartQuarterAll.Name = "ChartQuarterAll";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            this.ChartQuarterAll.Series.Add(series5);
            title5.Name = "Title1";
            title5.Text = "試合全体のグラフ";
            this.ChartQuarterAll.Titles.Add(title5);
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルToolStripMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // ファイルToolStripMenuItem
            // 
            resources.ApplyResources(this.ファイルToolStripMenuItem, "ファイルToolStripMenuItem");
            this.ファイルToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PrintForm,
            this.PrintPreview});
            this.ファイルToolStripMenuItem.Name = "ファイルToolStripMenuItem";
            // 
            // PrintForm
            // 
            resources.ApplyResources(this.PrintForm, "PrintForm");
            this.PrintForm.Name = "PrintForm";
            this.PrintForm.Click += new System.EventHandler(this.PrintForm_Click);
            // 
            // PrintPreview
            // 
            resources.ApplyResources(this.PrintPreview, "PrintPreview");
            this.PrintPreview.Name = "PrintPreview";
            this.PrintPreview.Click += new System.EventHandler(this.PrintPreview_Click);
            // 
            // FormGraphScore
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OppentTeamList);
            this.Controls.Add(this.MyTeamList);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormGraphScore";
            ((System.ComponentModel.ISupportInitialize)(this.ChartQuarter1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.Quarter1.ResumeLayout(false);
            this.Quarter2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ChartQuarter2)).EndInit();
            this.Quarter3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ChartQuarter3)).EndInit();
            this.Quarter4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ChartQuarter4)).EndInit();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ChartQuarterAll)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart ChartQuarter1;
        private System.Windows.Forms.ListBox MyTeamList;
        private System.Windows.Forms.ListBox OppentTeamList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Quarter1;
        private System.Windows.Forms.TabPage Quarter2;
        private System.Windows.Forms.DataVisualization.Charting.Chart ChartQuarter2;
        private System.Windows.Forms.TabPage Quarter3;
        private System.Windows.Forms.DataVisualization.Charting.Chart ChartQuarter3;
        private System.Windows.Forms.TabPage Quarter4;
        private System.Windows.Forms.DataVisualization.Charting.Chart ChartQuarter4;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataVisualization.Charting.Chart ChartQuarterAll;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ファイルToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PrintForm;
        private System.Windows.Forms.ToolStripMenuItem PrintPreview;
    }
}