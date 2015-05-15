namespace BasketballManagementSystem.BMForm.ClubEdit
{
    partial class FormClubEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormClubEdit));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadClub = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveClub = new System.Windows.Forms.ToolStripMenuItem();
            this.ClubMembersList = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.ClubName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ButtonDelete = new System.Windows.Forms.Button();
            this.ButtonDicision = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.WeightSelected = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.HeightSelected = new System.Windows.Forms.TextBox();
            this.IsManSelected = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.NameSelected = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ButtonAdd = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.WeightAdd = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.HeightAdd = new System.Windows.Forms.TextBox();
            this.IsManAdd = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.NameAdd = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoadClub,
            this.SaveClub});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            // 
            // LoadClub
            // 
            resources.ApplyResources(this.LoadClub, "LoadClub");
            this.LoadClub.Name = "LoadClub";
            this.LoadClub.Click += new System.EventHandler(this.loadClub_Click);
            // 
            // SaveClub
            // 
            resources.ApplyResources(this.SaveClub, "SaveClub");
            this.SaveClub.Name = "SaveClub";
            this.SaveClub.Click += new System.EventHandler(this.saveClub_Click);
            // 
            // ClubMembersList
            // 
            resources.ApplyResources(this.ClubMembersList, "ClubMembersList");
            this.ClubMembersList.FormattingEnabled = true;
            this.ClubMembersList.Name = "ClubMembersList";
            this.ClubMembersList.SelectedIndexChanged += new System.EventHandler(this.ClubMembersList_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.ClubName);
            this.groupBox1.Controls.Add(this.ClubMembersList);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // ClubName
            // 
            resources.ApplyResources(this.ClubName, "ClubName");
            this.ClubName.Name = "ClubName";
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.ButtonDelete);
            this.groupBox2.Controls.Add(this.ButtonDicision);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.WeightSelected);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.HeightSelected);
            this.groupBox2.Controls.Add(this.IsManSelected);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.NameSelected);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // ButtonDelete
            // 
            resources.ApplyResources(this.ButtonDelete, "ButtonDelete");
            this.ButtonDelete.Name = "ButtonDelete";
            this.ButtonDelete.UseVisualStyleBackColor = true;
            this.ButtonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // ButtonDicision
            // 
            resources.ApplyResources(this.ButtonDicision, "ButtonDicision");
            this.ButtonDicision.Name = "ButtonDicision";
            this.ButtonDicision.UseVisualStyleBackColor = true;
            this.ButtonDicision.Click += new System.EventHandler(this.ButtonDicision_Click);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // WeightSelected
            // 
            resources.ApplyResources(this.WeightSelected, "WeightSelected");
            this.WeightSelected.Name = "WeightSelected";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // HeightSelected
            // 
            resources.ApplyResources(this.HeightSelected, "HeightSelected");
            this.HeightSelected.Name = "HeightSelected";
            // 
            // IsManSelected
            // 
            resources.ApplyResources(this.IsManSelected, "IsManSelected");
            this.IsManSelected.Name = "IsManSelected";
            this.IsManSelected.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // NameSelected
            // 
            resources.ApplyResources(this.NameSelected, "NameSelected");
            this.NameSelected.Name = "NameSelected";
            // 
            // groupBox3
            // 
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.ButtonAdd);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.WeightAdd);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.HeightAdd);
            this.groupBox3.Controls.Add(this.IsManAdd);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.NameAdd);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // ButtonAdd
            // 
            resources.ApplyResources(this.ButtonAdd, "ButtonAdd");
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.UseVisualStyleBackColor = true;
            this.ButtonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // WeightAdd
            // 
            resources.ApplyResources(this.WeightAdd, "WeightAdd");
            this.WeightAdd.Name = "WeightAdd";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // HeightAdd
            // 
            resources.ApplyResources(this.HeightAdd, "HeightAdd");
            this.HeightAdd.Name = "HeightAdd";
            // 
            // IsManAdd
            // 
            resources.ApplyResources(this.IsManAdd, "IsManAdd");
            this.IsManAdd.Name = "IsManAdd";
            this.IsManAdd.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // NameAdd
            // 
            resources.ApplyResources(this.NameAdd, "NameAdd");
            this.NameAdd.Name = "NameAdd";
            // 
            // FormClubEdit
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormClubEdit";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormClubEdit_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoadClub;
        private System.Windows.Forms.ToolStripMenuItem SaveClub;
        private System.Windows.Forms.ListBox ClubMembersList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NameSelected;
        private System.Windows.Forms.CheckBox IsManSelected;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox WeightSelected;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox HeightSelected;
        private System.Windows.Forms.Button ButtonDicision;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox WeightAdd;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox HeightAdd;
        private System.Windows.Forms.CheckBox IsManAdd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox NameAdd;
        private System.Windows.Forms.Button ButtonAdd;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox ClubName;
        private System.Windows.Forms.Button ButtonDelete;
    }
}