namespace BasketballManagementSystem.BMForm.Transmission.tCP
{
    partial class TCPServer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TCPServer));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
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
            this.groupBox1.SuspendLayout();
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
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox3);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PasswordTextBox);
            this.groupBox1.Controls.Add(this.label3);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // PasswordTextBox
            // 
            resources.ApplyResources(this.PasswordTextBox, "PasswordTextBox");
            this.PasswordTextBox.Name = "PasswordTextBox";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.StopButton);
            this.groupBox2.Controls.Add(this.StartButton);
            this.groupBox2.Controls.Add(this.picIndicator);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // StopButton
            // 
            resources.ApplyResources(this.StopButton, "StopButton");
            this.StopButton.Name = "StopButton";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // StartButton
            // 
            resources.ApplyResources(this.StartButton, "StartButton");
            this.StartButton.Name = "StartButton";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // picIndicator
            // 
            this.picIndicator.BackColor = System.Drawing.Color.Navy;
            this.picIndicator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.picIndicator, "picIndicator");
            this.picIndicator.Name = "picIndicator";
            this.picIndicator.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.PortNumberTextBox);
            this.groupBox3.Controls.Add(this.label2);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // PortNumberTextBox
            // 
            resources.ApplyResources(this.PortNumberTextBox, "PortNumberTextBox");
            this.PortNumberTextBox.Name = "PortNumberTextBox";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // ServerSendTimer
            // 
            this.ServerSendTimer.Enabled = true;
            this.ServerSendTimer.Tick += new System.EventHandler(this.ServerSendTimer_Tick);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.ReadClearButton);
            resources.ApplyResources(this.panel7, "panel7");
            this.panel7.Name = "panel7";
            // 
            // ReadClearButton
            // 
            resources.ApplyResources(this.ReadClearButton, "ReadClearButton");
            this.ReadClearButton.Name = "ReadClearButton";
            this.ReadClearButton.UseVisualStyleBackColor = true;
            this.ReadClearButton.Click += new System.EventHandler(this.ReadClearButton_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.WriteClearButton);
            resources.ApplyResources(this.panel6, "panel6");
            this.panel6.Name = "panel6";
            // 
            // WriteClearButton
            // 
            resources.ApplyResources(this.WriteClearButton, "WriteClearButton");
            this.WriteClearButton.Name = "WriteClearButton";
            this.WriteClearButton.UseVisualStyleBackColor = true;
            this.WriteClearButton.Click += new System.EventHandler(this.WriteClearButton_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.Controls.Add(this.labelLog);
            resources.ApplyResources(this.panel5, "panel5");
            this.panel5.Name = "panel5";
            // 
            // labelLog
            // 
            this.labelLog.BackColor = System.Drawing.Color.Transparent;
            this.labelLog.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            resources.ApplyResources(this.labelLog, "labelLog");
            this.labelLog.Name = "labelLog";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Controls.Add(this.ReadLabel);
            resources.ApplyResources(this.panel4, "panel4");
            this.panel4.Name = "panel4";
            // 
            // ReadLabel
            // 
            this.ReadLabel.BackColor = System.Drawing.Color.Transparent;
            this.ReadLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            resources.ApplyResources(this.ReadLabel, "ReadLabel");
            this.ReadLabel.Name = "ReadLabel";
            // 
            // ReadTextBox
            // 
            resources.ApplyResources(this.ReadTextBox, "ReadTextBox");
            this.ReadTextBox.Name = "ReadTextBox";
            this.ReadTextBox.ReadOnly = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.SendButton);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // SendButton
            // 
            resources.ApplyResources(this.SendButton, "SendButton");
            this.SendButton.Name = "SendButton";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // LogTextBox
            // 
            resources.ApplyResources(this.LogTextBox, "LogTextBox");
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.ReadOnly = true;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.LogClearButton);
            resources.ApplyResources(this.panel8, "panel8");
            this.panel8.Name = "panel8";
            // 
            // LogClearButton
            // 
            resources.ApplyResources(this.LogClearButton, "LogClearButton");
            this.LogClearButton.Name = "LogClearButton";
            this.LogClearButton.UseVisualStyleBackColor = true;
            this.LogClearButton.Click += new System.EventHandler(this.LogClearButton_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.WriteTextBox);
            this.panel2.Controls.Add(this.panel9);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // WriteTextBox
            // 
            resources.ApplyResources(this.WriteTextBox, "WriteTextBox");
            this.WriteTextBox.Name = "WriteTextBox";
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.ClientListBox);
            this.panel9.Controls.Add(this.label1);
            resources.ApplyResources(this.panel9, "panel9");
            this.panel9.Name = "panel9";
            // 
            // ClientListBox
            // 
            this.ClientListBox.BackColor = System.Drawing.Color.Azure;
            resources.ApplyResources(this.ClientListBox, "ClientListBox");
            this.ClientListBox.ForeColor = System.Drawing.Color.Black;
            this.ClientListBox.FormattingEnabled = true;
            this.ClientListBox.Name = "ClientListBox";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel8, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.LogTextBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ReadTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel6, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel7, 2, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // TCPServer
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Name = "TCPServer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormServer_FormClosing);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Label label3;
    }
}