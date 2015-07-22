namespace BasketballManagementSystem.BMForm.CentralityAnalyze
{
    partial class FormCentralityAnalyze
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
            this.components = new System.ComponentModel.Container();
            this.ResultTextBox = new System.Windows.Forms.TextBox();
            this.MyTeamListBox = new System.Windows.Forms.ListBox();
            this.OppentTeamListBox = new System.Windows.Forms.ListBox();
            this.SourceTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TargetTextBox = new System.Windows.Forms.TextBox();
            this.AnalyzeButton = new System.Windows.Forms.Button();
            this.ListContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddSourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddTargetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ListContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ResultTextBox
            // 
            this.ResultTextBox.Location = new System.Drawing.Point(216, 85);
            this.ResultTextBox.Multiline = true;
            this.ResultTextBox.Name = "ResultTextBox";
            this.ResultTextBox.Size = new System.Drawing.Size(420, 360);
            this.ResultTextBox.TabIndex = 0;
            // 
            // MyTeamListBox
            // 
            this.MyTeamListBox.ContextMenuStrip = this.ListContextMenuStrip;
            this.MyTeamListBox.FormattingEnabled = true;
            this.MyTeamListBox.ItemHeight = 12;
            this.MyTeamListBox.Location = new System.Drawing.Point(12, 12);
            this.MyTeamListBox.Name = "MyTeamListBox";
            this.MyTeamListBox.Size = new System.Drawing.Size(170, 208);
            this.MyTeamListBox.TabIndex = 1;
            this.MyTeamListBox.SelectedIndexChanged += new System.EventHandler(this.MyTeamListBox_SelectedIndexChanged);
            // 
            // OppentTeamListBox
            // 
            this.OppentTeamListBox.ContextMenuStrip = this.ListContextMenuStrip;
            this.OppentTeamListBox.FormattingEnabled = true;
            this.OppentTeamListBox.ItemHeight = 12;
            this.OppentTeamListBox.Location = new System.Drawing.Point(12, 237);
            this.OppentTeamListBox.Name = "OppentTeamListBox";
            this.OppentTeamListBox.Size = new System.Drawing.Size(170, 208);
            this.OppentTeamListBox.TabIndex = 2;
            this.OppentTeamListBox.SelectedIndexChanged += new System.EventHandler(this.OppentTeamListBox_SelectedIndexChanged);
            // 
            // SourceTextBox
            // 
            this.SourceTextBox.Location = new System.Drawing.Point(216, 18);
            this.SourceTextBox.Name = "SourceTextBox";
            this.SourceTextBox.Size = new System.Drawing.Size(186, 19);
            this.SourceTextBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(417, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "→";
            // 
            // TargetTextBox
            // 
            this.TargetTextBox.Location = new System.Drawing.Point(450, 18);
            this.TargetTextBox.Name = "TargetTextBox";
            this.TargetTextBox.Size = new System.Drawing.Size(186, 19);
            this.TargetTextBox.TabIndex = 5;
            // 
            // AnalyzeButton
            // 
            this.AnalyzeButton.Location = new System.Drawing.Point(216, 53);
            this.AnalyzeButton.Name = "AnalyzeButton";
            this.AnalyzeButton.Size = new System.Drawing.Size(75, 23);
            this.AnalyzeButton.TabIndex = 6;
            this.AnalyzeButton.Text = "Analize";
            this.AnalyzeButton.UseVisualStyleBackColor = true;
            this.AnalyzeButton.Click += new System.EventHandler(this.AnalyzeButton_Click);
            // 
            // ListContextMenuStrip
            // 
            this.ListContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddSourceToolStripMenuItem,
            this.AddTargetToolStripMenuItem});
            this.ListContextMenuStrip.Name = "ListContextMenuStrip";
            this.ListContextMenuStrip.Size = new System.Drawing.Size(139, 48);
            // 
            // AddSourceToolStripMenuItem
            // 
            this.AddSourceToolStripMenuItem.Name = "AddSourceToolStripMenuItem";
            this.AddSourceToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.AddSourceToolStripMenuItem.Text = "AddSource";
            this.AddSourceToolStripMenuItem.Click += new System.EventHandler(this.AddSourceToolStripMenuItem_Click);
            // 
            // AddTargetToolStripMenuItem
            // 
            this.AddTargetToolStripMenuItem.Name = "AddTargetToolStripMenuItem";
            this.AddTargetToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.AddTargetToolStripMenuItem.Text = "AddTarget";
            this.AddTargetToolStripMenuItem.Click += new System.EventHandler(this.AddTargetToolStripMenuItem_Click);
            // 
            // FormCentralityAnalyze
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 457);
            this.Controls.Add(this.AnalyzeButton);
            this.Controls.Add(this.TargetTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SourceTextBox);
            this.Controls.Add(this.OppentTeamListBox);
            this.Controls.Add(this.MyTeamListBox);
            this.Controls.Add(this.ResultTextBox);
            this.Name = "FormCentralityAnalyze";
            this.Text = "FormCentralityAnalyze";
            this.Load += new System.EventHandler(this.FormCentralityAnalyze_Load);
            this.ListContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ResultTextBox;
        private System.Windows.Forms.ListBox MyTeamListBox;
        private System.Windows.Forms.ListBox OppentTeamListBox;
        private System.Windows.Forms.TextBox SourceTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TargetTextBox;
        private System.Windows.Forms.Button AnalyzeButton;
        private System.Windows.Forms.ContextMenuStrip ListContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem AddSourceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddTargetToolStripMenuItem;
    }
}