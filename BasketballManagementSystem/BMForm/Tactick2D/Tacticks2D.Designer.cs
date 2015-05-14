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
            this.Cort = new System.Windows.Forms.PictureBox();
            this.DrawActionKinds = new System.Windows.Forms.ComboBox();
            this.MyTeamList = new System.Windows.Forms.ListBox();
            this.OppentTeamList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.InformationText = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printForm = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreview = new System.Windows.Forms.ToolStripMenuItem();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.valuationBasis = new System.Windows.Forms.ToolStripMenuItem();
            this.percent = new System.Windows.Forms.ToolStripTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Cort)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Cort
            // 
            resources.ApplyResources(this.Cort, "Cort");
            this.Cort.Name = "Cort";
            this.Cort.TabStop = false;
            this.Cort.Click += new System.EventHandler(this.Cort_Click);
            this.Cort.Paint += new System.Windows.Forms.PaintEventHandler(this.Cort_Paint);
            // 
            // DrawActionKinds
            // 
            resources.ApplyResources(this.DrawActionKinds, "DrawActionKinds");
            this.DrawActionKinds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DrawActionKinds.FormattingEnabled = true;
            this.DrawActionKinds.Name = "DrawActionKinds";
            this.DrawActionKinds.SelectedIndexChanged += new System.EventHandler(this.DrawActionKinds_SelectedIndexChanged);
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
            // InformationText
            // 
            resources.ApplyResources(this.InformationText, "InformationText");
            this.InformationText.BackColor = System.Drawing.SystemColors.Window;
            this.InformationText.Name = "InformationText";
            this.InformationText.ReadOnly = true;
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.configToolStripMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printForm,
            this.printPreview});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            // 
            // printForm
            // 
            resources.ApplyResources(this.printForm, "printForm");
            this.printForm.Name = "printForm";
            this.printForm.Click += new System.EventHandler(this.printForm_Click);
            // 
            // printPreview
            // 
            resources.ApplyResources(this.printPreview, "printPreview");
            this.printPreview.Name = "printPreview";
            this.printPreview.Click += new System.EventHandler(this.printPreview_Click);
            // 
            // configToolStripMenuItem
            // 
            resources.ApplyResources(this.configToolStripMenuItem, "configToolStripMenuItem");
            this.configToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.valuationBasis});
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            // 
            // valuationBasis
            // 
            resources.ApplyResources(this.valuationBasis, "valuationBasis");
            this.valuationBasis.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.percent});
            this.valuationBasis.Name = "valuationBasis";
            // 
            // percent
            // 
            resources.ApplyResources(this.percent, "percent");
            this.percent.Name = "percent";
            this.percent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.percent_KeyPress);
            this.percent.TextChanged += new System.EventHandler(this.percent_TextChanged);
            // 
            // Tacticks2D
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.InformationText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OppentTeamList);
            this.Controls.Add(this.MyTeamList);
            this.Controls.Add(this.DrawActionKinds);
            this.Controls.Add(this.Cort);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Tacticks2D";
            ((System.ComponentModel.ISupportInitialize)(this.Cort)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Cort;
        private System.Windows.Forms.ComboBox DrawActionKinds;
        private System.Windows.Forms.ListBox MyTeamList;
        private System.Windows.Forms.ListBox OppentTeamList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox InformationText;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printForm;
        private System.Windows.Forms.ToolStripMenuItem printPreview;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem valuationBasis;
        private System.Windows.Forms.ToolStripTextBox percent;
    }
}