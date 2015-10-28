namespace BasketballManagementSystem.bMForm.strategySimulation
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
            this.BenchDragDropBox.AllowDrop = true;
            this.BenchDragDropBox.BackColor = System.Drawing.Color.LightSteelBlue;
            this.BenchDragDropBox.Location = new System.Drawing.Point(9, 404);
            this.BenchDragDropBox.LocationBitmapList = ((System.Collections.Generic.List<DragDropPictureBox.LocationBitmap>)(resources.GetObject("BenchDragDropBox.LocationBitmapList")));
            this.BenchDragDropBox.Name = "BenchDragDropBox";
            this.BenchDragDropBox.Size = new System.Drawing.Size(867, 103);
            this.BenchDragDropBox.TabIndex = 0;
            this.BenchDragDropBox.TabStop = false;
            // 
            // dragDropBoxCort
            // 
            this.dragDropBoxCort.AllowDrop = true;
            this.dragDropBoxCort.Image = ((System.Drawing.Image)(resources.GetObject("dragDropBoxCort.Image")));
            this.dragDropBoxCort.Location = new System.Drawing.Point(222, 45);
            this.dragDropBoxCort.LocationBitmapList = ((System.Collections.Generic.List<DragDropPictureBox.LocationBitmap>)(resources.GetObject("dragDropBoxCort.LocationBitmapList")));
            this.dragDropBoxCort.Name = "dragDropBoxCort";
            this.dragDropBoxCort.Size = new System.Drawing.Size(654, 353);
            this.dragDropBoxCort.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.dragDropBoxCort.TabIndex = 1;
            this.dragDropBoxCort.TabStop = false;
            // 
            // BoardListBox
            // 
            this.BoardListBox.FormattingEnabled = true;
            this.BoardListBox.ItemHeight = 12;
            this.BoardListBox.Location = new System.Drawing.Point(12, 45);
            this.BoardListBox.Name = "BoardListBox";
            this.BoardListBox.Size = new System.Drawing.Size(207, 292);
            this.BoardListBox.TabIndex = 2;
            this.BoardListBox.SelectedIndexChanged += new System.EventHandler(this.BoardListBox_SelectedIndexChanged);
            // 
            // AddBoardButton
            // 
            this.AddBoardButton.Location = new System.Drawing.Point(12, 354);
            this.AddBoardButton.Name = "AddBoardButton";
            this.AddBoardButton.Size = new System.Drawing.Size(75, 23);
            this.AddBoardButton.TabIndex = 3;
            this.AddBoardButton.Text = "BoardAdd";
            this.AddBoardButton.UseVisualStyleBackColor = true;
            this.AddBoardButton.Click += new System.EventHandler(this.AddBoardButton_Click);
            // 
            // Bench2DragDropBox
            // 
            this.Bench2DragDropBox.AllowDrop = true;
            this.Bench2DragDropBox.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Bench2DragDropBox.Location = new System.Drawing.Point(9, 514);
            this.Bench2DragDropBox.LocationBitmapList = ((System.Collections.Generic.List<DragDropPictureBox.LocationBitmap>)(resources.GetObject("Bench2DragDropBox.LocationBitmapList")));
            this.Bench2DragDropBox.Name = "Bench2DragDropBox";
            this.Bench2DragDropBox.Size = new System.Drawing.Size(867, 71);
            this.Bench2DragDropBox.TabIndex = 4;
            this.Bench2DragDropBox.TabStop = false;
            // 
            // SimulateButton
            // 
            this.SimulateButton.Location = new System.Drawing.Point(103, 354);
            this.SimulateButton.Name = "SimulateButton";
            this.SimulateButton.Size = new System.Drawing.Size(75, 23);
            this.SimulateButton.TabIndex = 5;
            this.SimulateButton.Text = "Simulation";
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
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.ConfigToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(884, 26);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(40, 22);
            this.FileToolStripMenuItem.Text = "File";
            // 
            // ConfigToolStripMenuItem
            // 
            this.ConfigToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UseLiteFPSModeItem,
            this.SpeedItem});
            this.ConfigToolStripMenuItem.Name = "ConfigToolStripMenuItem";
            this.ConfigToolStripMenuItem.Size = new System.Drawing.Size(56, 22);
            this.ConfigToolStripMenuItem.Text = "Config";
            // 
            // UseLiteFPSModeItem
            // 
            this.UseLiteFPSModeItem.Name = "UseLiteFPSModeItem";
            this.UseLiteFPSModeItem.Size = new System.Drawing.Size(152, 22);
            this.UseLiteFPSModeItem.Text = "UseLiteFPS";
            this.UseLiteFPSModeItem.Click += new System.EventHandler(this.UseLiteFPSModeItem_Click);
            // 
            // SpeedItem
            // 
            this.SpeedItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SpeedComboBox});
            this.SpeedItem.Name = "SpeedItem";
            this.SpeedItem.Size = new System.Drawing.Size(152, 22);
            this.SpeedItem.Text = "Speed";
            // 
            // SpeedComboBox
            // 
            this.SpeedComboBox.Items.AddRange(new object[] {
            "1",
            "3",
            "5",
            "10",
            "15"});
            this.SpeedComboBox.Name = "SpeedComboBox";
            this.SpeedComboBox.Size = new System.Drawing.Size(121, 26);
            this.SpeedComboBox.SelectedIndexChanged += new System.EventHandler(this.SpeedComboBox_SelectedIndexChanged);
            this.SpeedComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SpeedComboBox_KeyPress);
            // 
            // FormStrategySimulation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 597);
            this.Controls.Add(this.SimulateButton);
            this.Controls.Add(this.Bench2DragDropBox);
            this.Controls.Add(this.AddBoardButton);
            this.Controls.Add(this.BoardListBox);
            this.Controls.Add(this.dragDropBoxCort);
            this.Controls.Add(this.BenchDragDropBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormStrategySimulation";
            this.Text = "FormStrategySimulation";
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