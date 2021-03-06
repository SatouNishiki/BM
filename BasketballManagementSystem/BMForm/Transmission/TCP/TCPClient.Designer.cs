﻿namespace BasketballManagementSystem.bmForm.Transmission.tcp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TCPClient));
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
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
            this.GameSendTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.UserNameTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.IndicatorPctureBox)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // IndicatorPctureBox
            // 
            this.IndicatorPctureBox.BackColor = System.Drawing.Color.Navy;
            this.IndicatorPctureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.IndicatorPctureBox, "IndicatorPctureBox");
            this.IndicatorPctureBox.Name = "IndicatorPctureBox";
            this.IndicatorPctureBox.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.PortNumberTextbox);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.IpTextButton);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // PortNumberTextbox
            // 
            resources.ApplyResources(this.PortNumberTextbox, "PortNumberTextbox");
            this.PortNumberTextbox.Name = "PortNumberTextbox";
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
            // IpTextButton
            // 
            resources.ApplyResources(this.IpTextButton, "IpTextButton");
            this.IpTextButton.Name = "IpTextButton";
            // 
            // WriteTextBox
            // 
            resources.ApplyResources(this.WriteTextBox, "WriteTextBox");
            this.WriteTextBox.Name = "WriteTextBox";
            // 
            // SendButton
            // 
            resources.ApplyResources(this.SendButton, "SendButton");
            this.SendButton.Name = "SendButton";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // WriteClearButton
            // 
            resources.ApplyResources(this.WriteClearButton, "WriteClearButton");
            this.WriteClearButton.Name = "WriteClearButton";
            this.WriteClearButton.UseVisualStyleBackColor = true;
            this.WriteClearButton.Click += new System.EventHandler(this.WriteClearButton_Click);
            // 
            // ReadTextBox
            // 
            resources.ApplyResources(this.ReadTextBox, "ReadTextBox");
            this.ReadTextBox.Name = "ReadTextBox";
            this.ReadTextBox.ReadOnly = true;
            // 
            // LogTextBox
            // 
            resources.ApplyResources(this.LogTextBox, "LogTextBox");
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.ReadOnly = true;
            // 
            // LogClearButton
            // 
            resources.ApplyResources(this.LogClearButton, "LogClearButton");
            this.LogClearButton.Name = "LogClearButton";
            this.LogClearButton.UseVisualStyleBackColor = true;
            this.LogClearButton.Click += new System.EventHandler(this.LogClearButton_Click);
            // 
            // ReadLabel
            // 
            this.ReadLabel.BackColor = System.Drawing.Color.Transparent;
            this.ReadLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            resources.ApplyResources(this.ReadLabel, "ReadLabel");
            this.ReadLabel.Name = "ReadLabel";
            // 
            // LogLabel
            // 
            this.LogLabel.BackColor = System.Drawing.Color.Transparent;
            this.LogLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            resources.ApplyResources(this.LogLabel, "LogLabel");
            this.LogLabel.Name = "LogLabel";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox4);
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
            this.groupBox2.Controls.Add(this.IndicatorPctureBox);
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
            // ReadClearButton
            // 
            resources.ApplyResources(this.ReadClearButton, "ReadClearButton");
            this.ReadClearButton.Name = "ReadClearButton";
            this.ReadClearButton.UseVisualStyleBackColor = true;
            this.ReadClearButton.Click += new System.EventHandler(this.ReadClearButton_Click);
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.panel8, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.WriteTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.LogTextBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ReadTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel6, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel7, 2, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.LogClearButton);
            resources.ApplyResources(this.panel8, "panel8");
            this.panel8.Name = "panel8";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.SendButton);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Controls.Add(this.ReadLabel);
            resources.ApplyResources(this.panel4, "panel4");
            this.panel4.Name = "panel4";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.Controls.Add(this.LogLabel);
            resources.ApplyResources(this.panel5, "panel5");
            this.panel5.Name = "panel5";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.WriteClearButton);
            resources.ApplyResources(this.panel6, "panel6");
            this.panel6.Name = "panel6";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.ReadClearButton);
            resources.ApplyResources(this.panel7, "panel7");
            this.panel7.Name = "panel7";
            // 
            // GameSendTimer
            // 
            this.GameSendTimer.Interval = 500;
            this.GameSendTimer.Tick += new System.EventHandler(this.GameSendTimer_Tick);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.UserNameTextBox);
            this.groupBox4.Controls.Add(this.label4);
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // UserNameTextBox
            // 
            resources.ApplyResources(this.UserNameTextBox, "UserNameTextBox");
            this.UserNameTextBox.Name = "UserNameTextBox";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // TCPClient
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "TCPClient";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TCPClient_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.IndicatorPctureBox)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
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
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Timer GameSendTimer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox UserNameTextBox;
        private System.Windows.Forms.Label label4;
    }
}