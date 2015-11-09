namespace BasketballManagementSystem.bmForm.gameDataEdit
{
    partial class FormGameDataEditView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGameDataEditView));
            this.PlayerSelectCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ActionSelectConbo = new System.Windows.Forms.ComboBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.ActionInfoGridView = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.PlayerInfoGridView = new System.Windows.Forms.DataGridView();
            this.DataGridTab = new System.Windows.Forms.TabControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GameDataSaveItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PrintFormItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PrintPreviewItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ActionInfoGridView)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerInfoGridView)).BeginInit();
            this.DataGridTab.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PlayerSelectCombo
            // 
            resources.ApplyResources(this.PlayerSelectCombo, "PlayerSelectCombo");
            this.PlayerSelectCombo.FormattingEnabled = true;
            this.PlayerSelectCombo.Name = "PlayerSelectCombo";
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
            // ActionSelectConbo
            // 
            resources.ApplyResources(this.ActionSelectConbo, "ActionSelectConbo");
            this.ActionSelectConbo.FormattingEnabled = true;
            this.ActionSelectConbo.Name = "ActionSelectConbo";
            this.ActionSelectConbo.SelectedIndexChanged += new System.EventHandler(this.ActionSelectConbo_SelectedIndexChanged);
            // 
            // tabPage3
            // 
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.Controls.Add(this.ActionInfoGridView);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // ActionInfoGridView
            // 
            resources.ApplyResources(this.ActionInfoGridView, "ActionInfoGridView");
            this.ActionInfoGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ActionInfoGridView.Name = "ActionInfoGridView";
            this.ActionInfoGridView.RowTemplate.Height = 21;
            // 
            // tabPage2
            // 
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Controls.Add(this.PlayerInfoGridView);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // PlayerInfoGridView
            // 
            resources.ApplyResources(this.PlayerInfoGridView, "PlayerInfoGridView");
            this.PlayerInfoGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PlayerInfoGridView.Name = "PlayerInfoGridView";
            this.PlayerInfoGridView.RowTemplate.Height = 21;
            // 
            // DataGridTab
            // 
            resources.ApplyResources(this.DataGridTab, "DataGridTab");
            this.DataGridTab.Controls.Add(this.tabPage2);
            this.DataGridTab.Controls.Add(this.tabPage3);
            this.DataGridTab.Name = "DataGridTab";
            this.DataGridTab.SelectedIndex = 0;
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            resources.ApplyResources(this.FileToolStripMenuItem, "FileToolStripMenuItem");
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GameDataSaveItem,
            this.PrintFormItem,
            this.PrintPreviewItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            // 
            // GameDataSaveItem
            // 
            resources.ApplyResources(this.GameDataSaveItem, "GameDataSaveItem");
            this.GameDataSaveItem.Name = "GameDataSaveItem";
            this.GameDataSaveItem.Click += new System.EventHandler(this.gameDataSave_Click);
            // 
            // PrintFormItem
            // 
            resources.ApplyResources(this.PrintFormItem, "PrintFormItem");
            this.PrintFormItem.Name = "PrintFormItem";
            this.PrintFormItem.Click += new System.EventHandler(this.printForm_Click);
            // 
            // PrintPreviewItem
            // 
            resources.ApplyResources(this.PrintPreviewItem, "PrintPreviewItem");
            this.PrintPreviewItem.Name = "PrintPreviewItem";
            this.PrintPreviewItem.Click += new System.EventHandler(this.printPreview_Click);
            // 
            // EditForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ActionSelectConbo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PlayerSelectCombo);
            this.Controls.Add(this.DataGridTab);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "EditForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EditForm_FormClosed);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ActionInfoGridView)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PlayerInfoGridView)).EndInit();
            this.DataGridTab.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox PlayerSelectCombo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ActionSelectConbo;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView ActionInfoGridView;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView PlayerInfoGridView;
        private System.Windows.Forms.TabControl DataGridTab;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GameDataSaveItem;
        private System.Windows.Forms.ToolStripMenuItem PrintFormItem;
        private System.Windows.Forms.ToolStripMenuItem PrintPreviewItem;
    }
}