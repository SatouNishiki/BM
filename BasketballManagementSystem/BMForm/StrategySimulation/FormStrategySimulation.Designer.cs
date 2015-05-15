namespace BasketballManagementSystem.BMForm.StrategySimulation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStrategySimulation));
            this.dragDropBoxBench = new DragDropPictureBox.DragDropBox();
            this.dragDropBoxCort = new DragDropPictureBox.DragDropBox();
            this.listBoxBoard = new System.Windows.Forms.ListBox();
            this.buttonAddBoard = new System.Windows.Forms.Button();
            this.dragDropBoxBench2 = new DragDropPictureBox.DragDropBox();
            ((System.ComponentModel.ISupportInitialize)(this.dragDropBoxBench)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dragDropBoxCort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dragDropBoxBench2)).BeginInit();
            this.SuspendLayout();
            // 
            // dragDropBoxBench
            // 
            this.dragDropBoxBench.AllowDrop = true;
            this.dragDropBoxBench.BackColor = System.Drawing.Color.LightSteelBlue;
            this.dragDropBoxBench.Location = new System.Drawing.Point(12, 371);
            this.dragDropBoxBench.LocationBitmapList = ((System.Collections.Generic.List<DragDropPictureBox.LocationBitmap>)(resources.GetObject("dragDropBoxBench.LocationBitmapList")));
            this.dragDropBoxBench.Name = "dragDropBoxBench";
            this.dragDropBoxBench.Size = new System.Drawing.Size(867, 103);
            this.dragDropBoxBench.TabIndex = 0;
            this.dragDropBoxBench.TabStop = false;
            // 
            // dragDropBoxCort
            // 
            this.dragDropBoxCort.AllowDrop = true;
            this.dragDropBoxCort.Image = ((System.Drawing.Image)(resources.GetObject("dragDropBoxCort.Image")));
            this.dragDropBoxCort.Location = new System.Drawing.Point(225, 12);
            this.dragDropBoxCort.LocationBitmapList = ((System.Collections.Generic.List<DragDropPictureBox.LocationBitmap>)(resources.GetObject("dragDropBoxCort.LocationBitmapList")));
            this.dragDropBoxCort.Name = "dragDropBoxCort";
            this.dragDropBoxCort.Size = new System.Drawing.Size(654, 353);
            this.dragDropBoxCort.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.dragDropBoxCort.TabIndex = 1;
            this.dragDropBoxCort.TabStop = false;
            // 
            // listBoxBoard
            // 
            this.listBoxBoard.FormattingEnabled = true;
            this.listBoxBoard.ItemHeight = 12;
            this.listBoxBoard.Location = new System.Drawing.Point(15, 12);
            this.listBoxBoard.Name = "listBoxBoard";
            this.listBoxBoard.Size = new System.Drawing.Size(207, 292);
            this.listBoxBoard.TabIndex = 2;
            this.listBoxBoard.SelectedIndexChanged += new System.EventHandler(this.listBoxBoard_SelectedIndexChanged);
            // 
            // buttonAddBoard
            // 
            this.buttonAddBoard.Location = new System.Drawing.Point(15, 321);
            this.buttonAddBoard.Name = "buttonAddBoard";
            this.buttonAddBoard.Size = new System.Drawing.Size(75, 23);
            this.buttonAddBoard.TabIndex = 3;
            this.buttonAddBoard.Text = "盤面追加";
            this.buttonAddBoard.UseVisualStyleBackColor = true;
            this.buttonAddBoard.Click += new System.EventHandler(this.buttonAddBoard_Click);
            // 
            // dragDropBoxBench2
            // 
            this.dragDropBoxBench2.AllowDrop = true;
            this.dragDropBoxBench2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.dragDropBoxBench2.Location = new System.Drawing.Point(12, 481);
            this.dragDropBoxBench2.LocationBitmapList = ((System.Collections.Generic.List<DragDropPictureBox.LocationBitmap>)(resources.GetObject("dragDropBoxBench2.LocationBitmapList")));
            this.dragDropBoxBench2.Name = "dragDropBoxBench2";
            this.dragDropBoxBench2.Size = new System.Drawing.Size(867, 71);
            this.dragDropBoxBench2.TabIndex = 4;
            this.dragDropBoxBench2.TabStop = false;
            // 
            // FormStrategySimulation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 563);
            this.Controls.Add(this.dragDropBoxBench2);
            this.Controls.Add(this.buttonAddBoard);
            this.Controls.Add(this.listBoxBoard);
            this.Controls.Add(this.dragDropBoxCort);
            this.Controls.Add(this.dragDropBoxBench);
            this.Name = "FormStrategySimulation";
            this.Text = "FormStrategySimulation";
            ((System.ComponentModel.ISupportInitialize)(this.dragDropBoxBench)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dragDropBoxCort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dragDropBoxBench2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DragDropPictureBox.DragDropBox dragDropBoxBench;
        private DragDropPictureBox.DragDropBox dragDropBoxCort;
        private System.Windows.Forms.ListBox listBoxBoard;
        private System.Windows.Forms.Button buttonAddBoard;
        private DragDropPictureBox.DragDropBox dragDropBoxBench2;


    }
}