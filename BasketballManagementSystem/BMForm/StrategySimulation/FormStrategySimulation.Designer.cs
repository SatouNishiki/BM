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
            ((System.ComponentModel.ISupportInitialize)(this.dragDropBoxBench)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dragDropBoxCort)).BeginInit();
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
            // FormStrategySimulation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 481);
            this.Controls.Add(this.dragDropBoxCort);
            this.Controls.Add(this.dragDropBoxBench);
            this.Name = "FormStrategySimulation";
            this.Text = "FormStrategySimulation";
            ((System.ComponentModel.ISupportInitialize)(this.dragDropBoxBench)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dragDropBoxCort)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DragDropPictureBox.DragDropBox dragDropBoxBench;
        private DragDropPictureBox.DragDropBox dragDropBoxCort;


    }
}