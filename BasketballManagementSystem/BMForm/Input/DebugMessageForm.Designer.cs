namespace BasketballManagementSystem.BMForm.Input
{
    partial class DebugMessageForm
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
            this.DebugMessageTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // DebugMessageTextBox
            // 
            this.DebugMessageTextBox.BackColor = System.Drawing.Color.White;
            this.DebugMessageTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DebugMessageTextBox.ForeColor = System.Drawing.Color.Black;
            this.DebugMessageTextBox.HideSelection = false;
            this.DebugMessageTextBox.Location = new System.Drawing.Point(12, 12);
            this.DebugMessageTextBox.Multiline = true;
            this.DebugMessageTextBox.Name = "DebugMessageTextBox";
            this.DebugMessageTextBox.ReadOnly = true;
            this.DebugMessageTextBox.Size = new System.Drawing.Size(358, 383);
            this.DebugMessageTextBox.TabIndex = 32;
            // 
            // DebugMessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 407);
            this.Controls.Add(this.DebugMessageTextBox);
            this.Name = "DebugMessageForm";
            this.Text = "DebugMessageForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox DebugMessageTextBox;
    }
}