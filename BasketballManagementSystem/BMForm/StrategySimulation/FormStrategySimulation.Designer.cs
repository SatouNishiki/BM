namespace BasketballManagementSystem.bmForm.strategySimulation
{
    partial class FormStrategySimulation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStrategySimulation));
            this.BenchDragDropBox = new DragDropPictureBox.DragDropBox();
            this.dragDropBoxCort = new DragDropPictureBox.DragDropBox();
            this.BoardListBox = new System.Windows.Forms.ListBox();
            this.AddBoardButton = new System.Windows.Forms.Button();
            this.Bench2DragDropBox = new DragDropPictureBox.DragDropBox();
            this.SimulateButton = new System.Windows.Forms.Button();
            this.SimulationFPSTimer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UseLiteFPSModeItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SpeedItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SpeedComboBox = new System.Windows.Forms.ToolStripComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.BenchDragDropBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dragDropBoxCort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bench2DragDropBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BenchDragDropBox
            // 
            resources.ApplyResources(this.BenchDragDropBox, "BenchDragDropBox");
            this.BenchDragDropBox.AllowDrop = true;
            this.BenchDragDropBox.BackColor = System.Drawing.Color.LightSteelBlue;
            this.BenchDragDropBox.LocationBitmapList = ((System.Collections.Generic.List<DragDropPictureBox.LocationBitmap>)(resources.GetObject("BenchDragDropBox.LocationBitmapList")));
            this.BenchDragDropBox.Name = "BenchDragDropBox";
            this.BenchDragDropBox.TabStop = false;
            // 
            // dragDropBoxCort
            // 
            resources.ApplyResources(this.dragDropBoxCort, "dragDropBoxCort");
            this.dragDropBoxCort.AllowDrop = true;
            this.dragDropBoxCort.Image = global::BasketballManagementSystem.Properties.Resources.coat;
            this.dragDropBoxCort.LocationBitmapList = ((System.Collections.Generic.List<DragDropPictureBox.LocationBitmap>)(resources.GetObject("dragDropBoxCort.LocationBitmapList")));
            this.dragDropBoxCort.Name = "dragDropBoxCort";
            this.dragDropBoxCort.TabStop = false;
            // 
            // BoardListBox
            // 
            resources.ApplyResources(this.BoardListBox, "BoardListBox");
            this.BoardListBox.FormattingEnabled = true;
            this.BoardListBox.Name = "BoardListBox";
            this.BoardListBox.SelectedIndexChanged += new System.EventHandler(this.BoardListBox_SelectedIndexChanged);
            // 
            // AddBoardButton
            // 
            resources.ApplyResources(this.AddBoardButton, "AddBoardButton");
            this.AddBoardButton.Name = "AddBoardButton";
            this.AddBoardButton.UseVisualStyleBackColor = true;
            this.AddBoardButton.Click += new System.EventHandler(this.AddBoardButton_Click);
            // 
            // Bench2DragDropBox
            // 
            resources.ApplyResources(this.Bench2DragDropBox, "Bench2DragDropBox");
            this.Bench2DragDropBox.AllowDrop = true;
            this.Bench2DragDropBox.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Bench2DragDropBox.LocationBitmapList = ((System.Collections.Generic.List<DragDropPictureBox.LocationBitmap>)(resources.GetObject("Bench2DragDropBox.LocationBitmapList")));
            this.Bench2DragDropBox.Name = "Bench2DragDropBox";
            this.Bench2DragDropBox.TabStop = false;
            // 
            // SimulateButton
            // 
            resources.ApplyResources(this.SimulateButton, "SimulateButton");
            this.SimulateButton.Name = "SimulateButton";
            this.SimulateButton.UseVisualStyleBackColor = true;
            this.SimulateButton.Click += new System.EventHandler(this.SimulateButton_Click);
            // 
            // SimulationFPSTimer
            // 
            this.SimulationFPSTimer.Interval = 16;
            this.SimulationFPSTimer.Tick += new System.EventHandler(this.SimulationFPSTimer_Tick);
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.ConfigToolStripMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            resources.ApplyResources(this.FileToolStripMenuItem, "FileToolStripMenuItem");
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            // 
            // ConfigToolStripMenuItem
            // 
            resources.ApplyResources(this.ConfigToolStripMenuItem, "ConfigToolStripMenuItem");
            this.ConfigToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UseLiteFPSModeItem,
            this.SpeedItem});
            this.ConfigToolStripMenuItem.Name = "ConfigToolStripMenuItem";
            // 
            // UseLiteFPSModeItem
            // 
            resources.ApplyResources(this.UseLiteFPSModeItem, "UseLiteFPSModeItem");
            this.UseLiteFPSModeItem.Name = "UseLiteFPSModeItem";
            this.UseLiteFPSModeItem.Click += new System.EventHandler(this.UseLiteFPSModeItem_Click);
            // 
            // SpeedItem
            // 
            resources.ApplyResources(this.SpeedItem, "SpeedItem");
            this.SpeedItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SpeedComboBox});
            this.SpeedItem.Name = "SpeedItem";
            // 
            // SpeedComboBox
            // 
            resources.ApplyResources(this.SpeedComboBox, "SpeedComboBox");
            this.SpeedComboBox.Items.AddRange(new object[] {
            resources.GetString("SpeedComboBox.Items"),
            resources.GetString("SpeedComboBox.Items1"),
            resources.GetString("SpeedComboBox.Items2"),
            resources.GetString("SpeedComboBox.Items3"),
            resources.GetString("SpeedComboBox.Items4")});
            this.SpeedComboBox.Name = "SpeedComboBox";
            this.SpeedComboBox.SelectedIndexChanged += new System.EventHandler(this.SpeedComboBox_SelectedIndexChanged);
            this.SpeedComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SpeedComboBox_KeyPress);
            // 
            // FormStrategySimulation
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SimulateButton);
            this.Controls.Add(this.Bench2DragDropBox);
            this.Controls.Add(this.AddBoardButton);
            this.Controls.Add(this.BoardListBox);
            this.Controls.Add(this.dragDropBoxCort);
            this.Controls.Add(this.BenchDragDropBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormStrategySimulation";
            ((System.ComponentModel.ISupportInitialize)(this.BenchDragDropBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dragDropBoxCort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bench2DragDropBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DragDropPictureBox.DragDropBox BenchDragDropBox;
        private DragDropPictureBox.DragDropBox dragDropBoxCort;
        private System.Windows.Forms.ListBox BoardListBox;
        private System.Windows.Forms.Button AddBoardButton;
        private DragDropPictureBox.DragDropBox Bench2DragDropBox;
        private System.Windows.Forms.Button SimulateButton;
        private System.Windows.Forms.Timer SimulationFPSTimer;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UseLiteFPSModeItem;
        private System.Windows.Forms.ToolStripMenuItem SpeedItem;
        private System.Windows.Forms.ToolStripComboBox SpeedComboBox;


    }
}