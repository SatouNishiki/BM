namespace BasketballManagementSystem.bmForm.clubEdit
{
    partial class FormClubEditView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormClubEditView));
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadClubItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveClubItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClubMembersListBox = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.ClubNameTextBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.WomanSelectedRadioButton = new System.Windows.Forms.RadioButton();
            this.ManSelectedRadioButton = new System.Windows.Forms.RadioButton();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.DicisionButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.WeightSelectedTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.HeightSelectedTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.NameSelectedTextBox = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.WomanAddRadioButton = new System.Windows.Forms.RadioButton();
            this.ManAddRadioButton = new System.Windows.Forms.RadioButton();
            this.AddButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.WeightAddTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.HeightAddTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.NameAddTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.MenuStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
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
            this.LoadClubItem,
            this.SaveClubItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            // 
            // LoadClubItem
            // 
            resources.ApplyResources(this.LoadClubItem, "LoadClubItem");
            this.LoadClubItem.Name = "LoadClubItem";
            this.LoadClubItem.Click += new System.EventHandler(this.LoadClubToolStripMenuItem_Click);
            // 
            // SaveClubItem
            // 
            resources.ApplyResources(this.SaveClubItem, "SaveClubItem");
            this.SaveClubItem.Name = "SaveClubItem";
            this.SaveClubItem.Click += new System.EventHandler(this.SaveClubToolStripMenuItem_Click);
            // 
            // ClubMembersListBox
            // 
            resources.ApplyResources(this.ClubMembersListBox, "ClubMembersListBox");
            this.ClubMembersListBox.FormattingEnabled = true;
            this.ClubMembersListBox.Name = "ClubMembersListBox";
            this.ClubMembersListBox.SelectedIndexChanged += new System.EventHandler(this.ClubMembersListBox_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.ClubNameTextBox);
            this.groupBox1.Controls.Add(this.ClubMembersListBox);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // ClubNameTextBox
            // 
            resources.ApplyResources(this.ClubNameTextBox, "ClubNameTextBox");
            this.ClubNameTextBox.Name = "ClubNameTextBox";
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.WomanSelectedRadioButton);
            this.groupBox2.Controls.Add(this.ManSelectedRadioButton);
            this.groupBox2.Controls.Add(this.DeleteButton);
            this.groupBox2.Controls.Add(this.DicisionButton);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.WeightSelectedTextBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.HeightSelectedTextBox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.NameSelectedTextBox);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // WomanSelectedRadioButton
            // 
            resources.ApplyResources(this.WomanSelectedRadioButton, "WomanSelectedRadioButton");
            this.WomanSelectedRadioButton.Name = "WomanSelectedRadioButton";
            this.WomanSelectedRadioButton.UseVisualStyleBackColor = true;
            // 
            // ManSelectedRadioButton
            // 
            resources.ApplyResources(this.ManSelectedRadioButton, "ManSelectedRadioButton");
            this.ManSelectedRadioButton.Checked = true;
            this.ManSelectedRadioButton.Name = "ManSelectedRadioButton";
            this.ManSelectedRadioButton.TabStop = true;
            this.ManSelectedRadioButton.UseVisualStyleBackColor = true;
            // 
            // DeleteButton
            // 
            resources.ApplyResources(this.DeleteButton, "DeleteButton");
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // DicisionButton
            // 
            resources.ApplyResources(this.DicisionButton, "DicisionButton");
            this.DicisionButton.Name = "DicisionButton";
            this.DicisionButton.UseVisualStyleBackColor = true;
            this.DicisionButton.Click += new System.EventHandler(this.DicisionButton_Click);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // WeightSelectedTextBox
            // 
            resources.ApplyResources(this.WeightSelectedTextBox, "WeightSelectedTextBox");
            this.WeightSelectedTextBox.Name = "WeightSelectedTextBox";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // HeightSelectedTextBox
            // 
            resources.ApplyResources(this.HeightSelectedTextBox, "HeightSelectedTextBox");
            this.HeightSelectedTextBox.Name = "HeightSelectedTextBox";
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
            // NameSelectedTextBox
            // 
            resources.ApplyResources(this.NameSelectedTextBox, "NameSelectedTextBox");
            this.NameSelectedTextBox.Name = "NameSelectedTextBox";
            // 
            // groupBox3
            // 
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Controls.Add(this.WomanAddRadioButton);
            this.groupBox3.Controls.Add(this.ManAddRadioButton);
            this.groupBox3.Controls.Add(this.AddButton);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.WeightAddTextBox);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.HeightAddTextBox);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.NameAddTextBox);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // WomanAddRadioButton
            // 
            resources.ApplyResources(this.WomanAddRadioButton, "WomanAddRadioButton");
            this.WomanAddRadioButton.Name = "WomanAddRadioButton";
            this.WomanAddRadioButton.UseVisualStyleBackColor = true;
            // 
            // ManAddRadioButton
            // 
            resources.ApplyResources(this.ManAddRadioButton, "ManAddRadioButton");
            this.ManAddRadioButton.Checked = true;
            this.ManAddRadioButton.Name = "ManAddRadioButton";
            this.ManAddRadioButton.TabStop = true;
            this.ManAddRadioButton.UseVisualStyleBackColor = true;
            // 
            // AddButton
            // 
            resources.ApplyResources(this.AddButton, "AddButton");
            this.AddButton.Name = "AddButton";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // WeightAddTextBox
            // 
            resources.ApplyResources(this.WeightAddTextBox, "WeightAddTextBox");
            this.WeightAddTextBox.Name = "WeightAddTextBox";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // HeightAddTextBox
            // 
            resources.ApplyResources(this.HeightAddTextBox, "HeightAddTextBox");
            this.HeightAddTextBox.Name = "HeightAddTextBox";
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
            // NameAddTextBox
            // 
            resources.ApplyResources(this.NameAddTextBox, "NameAddTextBox");
            this.NameAddTextBox.Name = "NameAddTextBox";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // FormClubEdit
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.MenuStrip);
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "FormClubEdit";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormClubEdit_FormClosing);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
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

        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoadClubItem;
        private System.Windows.Forms.ToolStripMenuItem SaveClubItem;
        private System.Windows.Forms.ListBox ClubMembersListBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NameSelectedTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox WeightSelectedTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox HeightSelectedTextBox;
        private System.Windows.Forms.Button DicisionButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox WeightAddTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox HeightAddTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox NameAddTextBox;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox ClubNameTextBox;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.RadioButton WomanSelectedRadioButton;
        private System.Windows.Forms.RadioButton ManSelectedRadioButton;
        private System.Windows.Forms.RadioButton WomanAddRadioButton;
        private System.Windows.Forms.RadioButton ManAddRadioButton;
    }
}