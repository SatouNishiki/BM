namespace BasketballManagementSystem.BMForm.Tactick2D
{
    partial class Tacticks2D
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tacticks2D));
            this.CortPictureBox = new System.Windows.Forms.PictureBox();
            this.DrawActionKindsComboBox = new System.Windows.Forms.ComboBox();
            this.MyTeamListBox = new System.Windows.Forms.ListBox();
            this.OppentTeamListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.InformationRichTextBox = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PrintFormItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PrintPreviewItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FaluationBasisItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PercentTextBox = new System.Windows.Forms.ToolStripTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.CortPictureBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CortPictureBox
            // 
            resources.ApplyResources(this.CortPictureBox, "CortPictureBox");
            this.CortPictureBox.Name = "CortPictureBox";
            this.CortPictureBox.TabStop = false;
            this.CortPictureBox.Click += new System.EventHandler(this.Cort_Click);
            this.CortPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.Cort_Paint);
            // 
            // DrawActionKindsComboBox
            // 
            this.DrawActionKindsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DrawActionKindsComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.DrawActionKindsComboBox, "DrawActionKindsComboBox");
            this.DrawActionKindsComboBox.Name = "DrawActionKindsComboBox";
            this.DrawActionKindsComboBox.SelectedIndexChanged += new System.EventHandler(this.DrawActionKinds_SelectedIndexChanged);
            // 
            // MyTeamListBox
            // 
            this.MyTeamListBox.FormattingEnabled = true;
            resources.ApplyResources(this.MyTeamListBox, "MyTeamListBox");
            this.MyTeamListBox.Name = "MyTeamListBox";
            this.MyTeamListBox.SelectedIndexChanged += new System.EventHandler(this.TeamList_SelectedIndexChanged);
            // 
            // OppentTeamListBox
            // 
            this.OppentTeamListBox.FormattingEnabled = true;
            resources.ApplyResources(this.OppentTeamListBox, "OppentTeamListBox");
            this.OppentTeamListBox.Name = "OppentTeamListBox";
            this.OppentTeamListBox.SelectedIndexChanged += new System.EventHandler(this.TeamList_SelectedIndexChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // InformationRichTextBox
            // 
            this.InformationRichTextBox.BackColor = System.Drawing.SystemColors.Window;
            resources.ApplyResources(this.InformationRichTextBox, "InformationRichTextBox");
            this.InformationRichTextBox.Name = "InformationRichTextBox";
            this.InformationRichTextBox.ReadOnly = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.configToolStripMenuItem});
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
            this.PrintFormItem.Click += new System.EventHandler(this.printForm_Click);
            // 
            // PrintPreviewItem
            // 
            this.PrintPreviewItem.Name = "PrintPreviewItem";
            resources.ApplyResources(this.PrintPreviewItem, "PrintPreviewItem");
            this.PrintPreviewItem.Click += new System.EventHandler(this.printPreview_Click);
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FaluationBasisItem});
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            resources.ApplyResources(this.configToolStripMenuItem, "configToolStripMenuItem");
            // 
            // FaluationBasisItem
            // 
            this.FaluationBasisItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PercentTextBox});
            this.FaluationBasisItem.Name = "FaluationBasisItem";
            resources.ApplyResources(this.FaluationBasisItem, "FaluationBasisItem");
            // 
            // PercentTextBox
            // 
            this.PercentTextBox.Name = "PercentTextBox";
            resources.ApplyResources(this.PercentTextBox, "PercentTextBox");
            this.PercentTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.percent_KeyPress);
            this.PercentTextBox.TextChanged += new System.EventHandler(this.percent_TextChanged);
            // 
            // Tacticks2D
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.InformationRichTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OppentTeamListBox);
            this.Controls.Add(this.MyTeamListBox);
            this.Controls.Add(this.DrawActionKindsComboBox);
            this.Controls.Add(this.CortPictureBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Tacticks2D";
            ((System.ComponentModel.ISupportInitialize)(this.CortPictureBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox CortPictureBox;
        private System.Windows.Forms.ComboBox DrawActionKindsComboBox;
        private System.Windows.Forms.ListBox MyTeamListBox;
        private System.Windows.Forms.ListBox OppentTeamListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox InformationRichTextBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PrintFormItem;
        private System.Windows.Forms.ToolStripMenuItem PrintPreviewItem;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FaluationBasisItem;
        private System.Windows.Forms.ToolStripTextBox PercentTextBox;
    }
}