namespace BasketballManagementSystem.bMForm.centralityAnalyze
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
            this.ResultTextBox = new System.Windows.Forms.TextBox();
            this.MyTeamListBox = new System.Windows.Forms.ListBox();
            this.OppentTeamListBox = new System.Windows.Forms.ListBox();
            this.SourceTextBox = new System.Windows.Forms.TextBox();
            this.AnalyzeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ResultTextBox
            // 
            this.ResultTextBox.Location = new System.Drawing.Point(216, 85);
            this.ResultTextBox.Multiline = true;
            this.ResultTextBox.Name = "ResultTextBox";
            this.ResultTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ResultTextBox.Size = new System.Drawing.Size(420, 360);
            this.ResultTextBox.TabIndex = 0;
            // 
            // MyTeamListBox
            // 
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
            // AnalyzeButton
            // 
            this.AnalyzeButton.Location = new System.Drawing.Point(216, 53);
            this.AnalyzeButton.Name = "AnalyzeButton";
            this.AnalyzeButton.Size = new System.Drawing.Size(100, 23);
            this.AnalyzeButton.TabIndex = 6;
            this.AnalyzeButton.Text = "Analize";
            this.AnalyzeButton.UseVisualStyleBackColor = true;
            this.AnalyzeButton.Click += new System.EventHandler(this.AnalyzeButton_Click);
            // 
            // FormCentralityAnalyze
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 457);
            this.Controls.Add(this.AnalyzeButton);
            this.Controls.Add(this.SourceTextBox);
            this.Controls.Add(this.OppentTeamListBox);
            this.Controls.Add(this.MyTeamListBox);
            this.Controls.Add(this.ResultTextBox);
            this.Name = "FormCentralityAnalyze";
            this.Text = "FormCentralityAnalyze";
            this.Load += new System.EventHandler(this.FormCentralityAnalyze_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ResultTextBox;
        private System.Windows.Forms.ListBox MyTeamListBox;
        private System.Windows.Forms.ListBox OppentTeamListBox;
        private System.Windows.Forms.TextBox SourceTextBox;
        private System.Windows.Forms.Button AnalyzeButton;
    }
}