namespace BasketballManagementSystem.BMForm.Transmission.TCP
{
    partial class TCPClient
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
            this.IndicatorPctureBox = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.PortNumberTextbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.IpTextButton = new System.Windows.Forms.TextBox();
            this.WriteTextBox = new System.Windows.Forms.TextBox();
            this.SendButton = new System.Windows.Forms.Button();
            this.WriteClearButton = new System.Windows.Forms.Button();
            this.ReadTextBox = new System.Windows.Forms.TextBox();
            this.LogTextBox = new System.Windows.Forms.TextBox();
            this.LogClearButton = new System.Windows.Forms.Button();
            this.ReadLabel = new System.Windows.Forms.Label();
            this.LogLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.StopButton = new System.Windows.Forms.Button();
            this.StartButton = new System.Windows.Forms.Button();
            this.ReadClearButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.timerServerStart = new System.Windows.Forms.Timer(this.components);
            this.GameSendTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.IndicatorPctureBox)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // IndicatorPctureBox
            // 
            this.IndicatorPctureBox.BackColor = System.Drawing.Color.Navy;
            this.IndicatorPctureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IndicatorPctureBox.Location = new System.Drawing.Point(6, 12);
            this.IndicatorPctureBox.Name = "IndicatorPctureBox";
            this.IndicatorPctureBox.Size = new System.Drawing.Size(12, 18);
            this.IndicatorPctureBox.TabIndex = 7;
            this.IndicatorPctureBox.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.PortNumberTextbox);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.IpTextButton);
            this.groupBox3.Location = new System.Drawing.Point(288, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(187, 35);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            // 
            // PortNumberTextbox
            // 
            this.PortNumberTextbox.Location = new System.Drawing.Point(133, 10);
            this.PortNumberTextbox.Name = "PortNumberTextbox";
            this.PortNumberTextbox.Size = new System.Drawing.Size(48, 19);
            this.PortNumberTextbox.TabIndex = 3;
            this.PortNumberTextbox.Text = "1001";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(101, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP";
            // 
            // IpTextButton
            // 
            this.IpTextButton.Location = new System.Drawing.Point(22, 11);
            this.IpTextButton.Name = "IpTextButton";
            this.IpTextButton.Size = new System.Drawing.Size(66, 19);
            this.IpTextButton.TabIndex = 0;
            this.IpTextButton.Text = "172.18.1.6";
            // 
            // WriteTextBox
            // 
            this.WriteTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WriteTextBox.Location = new System.Drawing.Point(61, 5);
            this.WriteTextBox.Multiline = true;
            this.WriteTextBox.Name = "WriteTextBox";
            this.WriteTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.WriteTextBox.Size = new System.Drawing.Size(462, 101);
            this.WriteTextBox.TabIndex = 4;
            // 
            // SendButton
            // 
            this.SendButton.Location = new System.Drawing.Point(3, 28);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(43, 32);
            this.SendButton.TabIndex = 5;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // WriteClearButton
            // 
            this.WriteClearButton.Location = new System.Drawing.Point(2, 0);
            this.WriteClearButton.Name = "WriteClearButton";
            this.WriteClearButton.Size = new System.Drawing.Size(19, 23);
            this.WriteClearButton.TabIndex = 6;
            this.WriteClearButton.Text = "C";
            this.WriteClearButton.UseVisualStyleBackColor = true;
            this.WriteClearButton.Click += new System.EventHandler(this.WriteClearButton_Click);
            // 
            // ReadTextBox
            // 
            this.ReadTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReadTextBox.Location = new System.Drawing.Point(61, 114);
            this.ReadTextBox.Multiline = true;
            this.ReadTextBox.Name = "ReadTextBox";
            this.ReadTextBox.ReadOnly = true;
            this.ReadTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ReadTextBox.Size = new System.Drawing.Size(462, 136);
            this.ReadTextBox.TabIndex = 7;
            // 
            // LogTextBox
            // 
            this.LogTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogTextBox.Location = new System.Drawing.Point(61, 258);
            this.LogTextBox.Multiline = true;
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.ReadOnly = true;
            this.LogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LogTextBox.Size = new System.Drawing.Size(462, 102);
            this.LogTextBox.TabIndex = 9;
            // 
            // LogClearButton
            // 
            this.LogClearButton.Location = new System.Drawing.Point(3, 3);
            this.LogClearButton.Name = "LogClearButton";
            this.LogClearButton.Size = new System.Drawing.Size(18, 23);
            this.LogClearButton.TabIndex = 10;
            this.LogClearButton.Text = "C";
            this.LogClearButton.UseVisualStyleBackColor = true;
            this.LogClearButton.Click += new System.EventHandler(this.LogClearButton_Click);
            // 
            // ReadLabel
            // 
            this.ReadLabel.BackColor = System.Drawing.Color.Transparent;
            this.ReadLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ReadLabel.Location = new System.Drawing.Point(7, 50);
            this.ReadLabel.Name = "ReadLabel";
            this.ReadLabel.Size = new System.Drawing.Size(31, 31);
            this.ReadLabel.TabIndex = 11;
            this.ReadLabel.Text = "ReadText";
            // 
            // LogLabel
            // 
            this.LogLabel.BackColor = System.Drawing.Color.Transparent;
            this.LogLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LogLabel.Location = new System.Drawing.Point(10, 39);
            this.LogLabel.Name = "LogLabel";
            this.LogLabel.Size = new System.Drawing.Size(28, 16);
            this.LogLabel.TabIndex = 12;
            this.LogLabel.Text = "ログ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(584, 47);
            this.panel1.TabIndex = 13;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.StopButton);
            this.groupBox2.Controls.Add(this.StartButton);
            this.groupBox2.Controls.Add(this.IndicatorPctureBox);
            this.groupBox2.Location = new System.Drawing.Point(67, 3);
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
            this.StartButton.Location = new System.Drawing.Point(24, 8);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(43, 23);
            this.StartButton.TabIndex = 8;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // ReadClearButton
            // 
            this.ReadClearButton.Location = new System.Drawing.Point(3, 4);
            this.ReadClearButton.Name = "ReadClearButton";
            this.ReadClearButton.Size = new System.Drawing.Size(18, 23);
            this.ReadClearButton.TabIndex = 10;
            this.ReadClearButton.Text = "C";
            this.ReadClearButton.UseVisualStyleBackColor = true;
            this.ReadClearButton.Click += new System.EventHandler(this.ReadClearButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel1.Controls.Add(this.panel8, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.WriteTextBox, 1, 0);
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(584, 365);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.LogClearButton);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(531, 258);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(48, 102);
            this.panel8.TabIndex = 18;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.SendButton);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(5, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(48, 101);
            this.panel3.TabIndex = 13;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Controls.Add(this.ReadLabel);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(5, 114);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(48, 136);
            this.panel4.TabIndex = 14;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.Controls.Add(this.LogLabel);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(5, 258);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(48, 102);
            this.panel5.TabIndex = 15;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.WriteClearButton);
            this.panel6.Location = new System.Drawing.Point(531, 5);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(44, 60);
            this.panel6.TabIndex = 16;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.ReadClearButton);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(531, 114);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(48, 136);
            this.panel7.TabIndex = 17;
            // 
            // GameSendTimer
            // 
            this.GameSendTimer.Enabled = true;
            this.GameSendTimer.Interval = 500;
            this.GameSendTimer.Tick += new System.EventHandler(this.GameSendTimer_Tick);
            // 
            // TCPClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 412);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "TCPClient";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "TCPClient";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TCPClient_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.IndicatorPctureBox)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox IpTextButton;
        private System.Windows.Forms.TextBox PortNumberTextbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox WriteTextBox;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.Button WriteClearButton;
        private System.Windows.Forms.PictureBox IndicatorPctureBox;
        private System.Windows.Forms.TextBox ReadTextBox;
        private System.Windows.Forms.TextBox LogTextBox;
        private System.Windows.Forms.Button LogClearButton;
        private System.Windows.Forms.Label ReadLabel;
        private System.Windows.Forms.Label LogLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button ReadClearButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Timer timerServerStart;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Timer GameSendTimer;
    }
}