namespace BasketballManagementSystem.BMForm.Transmission.TCP
{
    partial class FomServer
    {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.StopButton = new System.Windows.Forms.Button();
            this.StartButton = new System.Windows.Forms.Button();
            this.picIndicator = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.PortNumberTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ServerSendTimer = new System.Windows.Forms.Timer(this.components);
            this.panel7 = new System.Windows.Forms.Panel();
            this.ReadClearButton = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.WriteClearButton = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.labelLog = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ReadLabel = new System.Windows.Forms.Label();
            this.ReadTextBox = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.SendButton = new System.Windows.Forms.Button();
            this.LogTextBox = new System.Windows.Forms.TextBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.LogClearButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.WriteTextBox = new System.Windows.Forms.TextBox();
            this.panel9 = new System.Windows.Forms.Panel();
            this.ClientListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIndicator)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel9.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(496, 47);
            this.panel1.TabIndex = 21;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.StopButton);
            this.groupBox2.Controls.Add(this.StartButton);
            this.groupBox2.Controls.Add(this.picIndicator);
            this.groupBox2.Location = new System.Drawing.Point(7, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(124, 35);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            // 
            // StopButton
            // 
            this.StopButton.Enabled = false;
            this.StopButton.Location = new System.Drawing.Point(73, 8);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(43, 23);
            this.StopButton.TabIndex = 9;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(25, 8);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(43, 23);
            this.StartButton.TabIndex = 8;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // picIndicator
            // 
            this.picIndicator.BackColor = System.Drawing.Color.Navy;
            this.picIndicator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picIndicator.Location = new System.Drawing.Point(6, 12);
            this.picIndicator.Name = "picIndicator";
            this.picIndicator.Size = new System.Drawing.Size(12, 18);
            this.picIndicator.TabIndex = 7;
            this.picIndicator.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.PortNumberTextBox);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(150, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(110, 35);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            // 
            // PortNumberTextBox
            // 
            this.PortNumberTextBox.Location = new System.Drawing.Point(44, 10);
            this.PortNumberTextBox.Name = "PortNumberTextBox";
            this.PortNumberTextBox.Size = new System.Drawing.Size(48, 19);
            this.PortNumberTextBox.TabIndex = 3;
            this.PortNumberTextBox.Text = "1001";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port";
            // 
            // ServerSendTimer
            // 
            this.ServerSendTimer.Enabled = true;
            this.ServerSendTimer.Tick += new System.EventHandler(this.ServerSendTimer_Tick);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.ReadClearButton);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(447, 87);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(44, 74);
            this.panel7.TabIndex = 17;
            // 
            // ReadClearButton
            // 
            this.ReadClearButton.Location = new System.Drawing.Point(3, 4);
            this.ReadClearButton.Name = "ReadClearButton";
            this.ReadClearButton.Size = new System.Drawing.Size(32, 23);
            this.ReadClearButton.TabIndex = 10;
            this.ReadClearButton.Text = "C";
            this.ReadClearButton.UseVisualStyleBackColor = true;
            this.ReadClearButton.Click += new System.EventHandler(this.ReadClearButton_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.WriteClearButton);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(447, 5);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(44, 74);
            this.panel6.TabIndex = 16;
            // 
            // WriteClearButton
            // 
            this.WriteClearButton.Location = new System.Drawing.Point(2, 0);
            this.WriteClearButton.Name = "WriteClearButton";
            this.WriteClearButton.Size = new System.Drawing.Size(33, 23);
            this.WriteClearButton.TabIndex = 6;
            this.WriteClearButton.Text = "C";
            this.WriteClearButton.UseVisualStyleBackColor = true;
            this.WriteClearButton.Click += new System.EventHandler(this.WriteClearButton_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.Controls.Add(this.labelLog);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(5, 169);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(47, 75);
            this.panel5.TabIndex = 15;
            // 
            // labelLog
            // 
            this.labelLog.BackColor = System.Drawing.Color.Transparent;
            this.labelLog.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelLog.Location = new System.Drawing.Point(13, 30);
            this.labelLog.Name = "labelLog";
            this.labelLog.Size = new System.Drawing.Size(23, 23);
            this.labelLog.TabIndex = 12;
            this.labelLog.Text = "LogText";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Controls.Add(this.ReadLabel);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(5, 87);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(47, 74);
            this.panel4.TabIndex = 14;
            // 
            // ReadLabel
            // 
            this.ReadLabel.BackColor = System.Drawing.Color.Transparent;
            this.ReadLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ReadLabel.Location = new System.Drawing.Point(7, 22);
            this.ReadLabel.Name = "ReadLabel";
            this.ReadLabel.Size = new System.Drawing.Size(32, 33);
            this.ReadLabel.TabIndex = 11;
            this.ReadLabel.Text = "ReadText";
            // 
            // ReadTextBox
            // 
            this.ReadTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReadTextBox.Location = new System.Drawing.Point(60, 87);
            this.ReadTextBox.Multiline = true;
            this.ReadTextBox.Name = "ReadTextBox";
            this.ReadTextBox.ReadOnly = true;
            this.ReadTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ReadTextBox.Size = new System.Drawing.Size(379, 74);
            this.ReadTextBox.TabIndex = 7;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.SendButton);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(5, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(47, 74);
            this.panel3.TabIndex = 13;
            // 
            // SendButton
            // 
            this.SendButton.Location = new System.Drawing.Point(2, 22);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(42, 29);
            this.SendButton.TabIndex = 5;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // LogTextBox
            // 
            this.LogTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogTextBox.Location = new System.Drawing.Point(60, 169);
            this.LogTextBox.Multiline = true;
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.ReadOnly = true;
            this.LogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LogTextBox.Size = new System.Drawing.Size(379, 75);
            this.LogTextBox.TabIndex = 9;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.LogClearButton);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(447, 169);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(44, 75);
            this.panel8.TabIndex = 18;
            // 
            // LogClearButton
            // 
            this.LogClearButton.Location = new System.Drawing.Point(3, 3);
            this.LogClearButton.Name = "LogClearButton";
            this.LogClearButton.Size = new System.Drawing.Size(32, 23);
            this.LogClearButton.TabIndex = 10;
            this.LogClearButton.Text = "C";
            this.LogClearButton.UseVisualStyleBackColor = true;
            this.LogClearButton.Click += new System.EventHandler(this.LogClearButton_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.WriteTextBox);
            this.panel2.Controls.Add(this.panel9);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(60, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(379, 74);
            this.panel2.TabIndex = 20;
            // 
            // WriteTextBox
            // 
            this.WriteTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WriteTextBox.Location = new System.Drawing.Point(94, 0);
            this.WriteTextBox.Multiline = true;
            this.WriteTextBox.Name = "WriteTextBox";
            this.WriteTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.WriteTextBox.Size = new System.Drawing.Size(285, 74);
            this.WriteTextBox.TabIndex = 19;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.ClientListBox);
            this.panel9.Controls.Add(this.label1);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(94, 74);
            this.panel9.TabIndex = 20;
            // 
            // ClientListBox
            // 
            this.ClientListBox.BackColor = System.Drawing.Color.Azure;
            this.ClientListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClientListBox.ForeColor = System.Drawing.Color.Black;
            this.ClientListBox.FormattingEnabled = true;
            this.ClientListBox.ItemHeight = 12;
            this.ClientListBox.Location = new System.Drawing.Point(0, 12);
            this.ClientListBox.Name = "ClientListBox";
            this.ClientListBox.Size = new System.Drawing.Size(94, 62);
            this.ClientListBox.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "SelectClient";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel8, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.LogTextBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ReadTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel6, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel7, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 47);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(496, 249);
            this.tableLayoutPanel1.TabIndex = 20;
            // 
            // FomServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 296);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Name = "FomServer";
            this.Text = "TCPServer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormServer_FormClosing);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picIndicator)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.PictureBox picIndicator;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox PortNumberTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer ServerSendTimer;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button ReadClearButton;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button WriteClearButton;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label labelLog;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label ReadLabel;
        private System.Windows.Forms.TextBox ReadTextBox;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.TextBox LogTextBox;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button LogClearButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox WriteTextBox;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.ListBox ClientListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}