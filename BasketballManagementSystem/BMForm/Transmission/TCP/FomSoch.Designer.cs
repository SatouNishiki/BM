namespace BasketballManagementSystem.BMForm.Transmission.TCP
{
    partial class FomSoch
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
            this.picIndicator = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBoxPortNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxIp = new System.Windows.Forms.TextBox();
            this.textBoxWrite = new System.Windows.Forms.TextBox();
            this.butSend = new System.Windows.Forms.Button();
            this.butClsWrite = new System.Windows.Forms.Button();
            this.textBoxRead = new System.Windows.Forms.TextBox();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.butClsLog = new System.Windows.Forms.Button();
            this.labelRead = new System.Windows.Forms.Label();
            this.labelLog = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.butStop = new System.Windows.Forms.Button();
            this.butStart = new System.Windows.Forms.Button();
            this.butClsRead = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.timerServerStart = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picIndicator)).BeginInit();
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
            this.groupBox3.Controls.Add(this.textBoxPortNo);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.textBoxIp);
            this.groupBox3.Location = new System.Drawing.Point(288, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(187, 35);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            // 
            // textBoxPortNo
            // 
            this.textBoxPortNo.Location = new System.Drawing.Point(133, 10);
            this.textBoxPortNo.Name = "textBoxPortNo";
            this.textBoxPortNo.Size = new System.Drawing.Size(48, 19);
            this.textBoxPortNo.TabIndex = 3;
            this.textBoxPortNo.Text = "1001";
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
            // textBoxIp
            // 
            this.textBoxIp.Location = new System.Drawing.Point(22, 11);
            this.textBoxIp.Name = "textBoxIp";
            this.textBoxIp.Size = new System.Drawing.Size(66, 19);
            this.textBoxIp.TabIndex = 0;
            this.textBoxIp.Text = "172.18.1.6";
            // 
            // textBoxWrite
            // 
            this.textBoxWrite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxWrite.Location = new System.Drawing.Point(42, 5);
            this.textBoxWrite.Multiline = true;
            this.textBoxWrite.Name = "textBoxWrite";
            this.textBoxWrite.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxWrite.Size = new System.Drawing.Size(450, 60);
            this.textBoxWrite.TabIndex = 4;
            // 
            // butSend
            // 
            this.butSend.Location = new System.Drawing.Point(2, 3);
            this.butSend.Name = "butSend";
            this.butSend.Size = new System.Drawing.Size(24, 43);
            this.butSend.TabIndex = 5;
            this.butSend.Text = "送信";
            this.butSend.UseVisualStyleBackColor = true;
            this.butSend.Click += new System.EventHandler(this.butSend_Click);
            // 
            // butClsWrite
            // 
            this.butClsWrite.Location = new System.Drawing.Point(2, 0);
            this.butClsWrite.Name = "butClsWrite";
            this.butClsWrite.Size = new System.Drawing.Size(18, 23);
            this.butClsWrite.TabIndex = 6;
            this.butClsWrite.Text = "C";
            this.butClsWrite.UseVisualStyleBackColor = true;
            this.butClsWrite.Click += new System.EventHandler(this.butCls_Click);
            // 
            // textBoxRead
            // 
            this.textBoxRead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxRead.Location = new System.Drawing.Point(42, 73);
            this.textBoxRead.Multiline = true;
            this.textBoxRead.Name = "textBoxRead";
            this.textBoxRead.ReadOnly = true;
            this.textBoxRead.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxRead.Size = new System.Drawing.Size(450, 82);
            this.textBoxRead.TabIndex = 7;
            // 
            // textBoxLog
            // 
            this.textBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxLog.Location = new System.Drawing.Point(42, 163);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ReadOnly = true;
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLog.Size = new System.Drawing.Size(450, 62);
            this.textBoxLog.TabIndex = 9;
            // 
            // butClsLog
            // 
            this.butClsLog.Location = new System.Drawing.Point(3, 3);
            this.butClsLog.Name = "butClsLog";
            this.butClsLog.Size = new System.Drawing.Size(18, 23);
            this.butClsLog.TabIndex = 10;
            this.butClsLog.Text = "C";
            this.butClsLog.UseVisualStyleBackColor = true;
            this.butClsLog.Click += new System.EventHandler(this.butClsLog_Click);
            // 
            // labelRead
            // 
            this.labelRead.BackColor = System.Drawing.Color.Gray;
            this.labelRead.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelRead.Location = new System.Drawing.Point(5, 0);
            this.labelRead.Name = "labelRead";
            this.labelRead.Size = new System.Drawing.Size(18, 60);
            this.labelRead.TabIndex = 11;
            this.labelRead.Text = " 受信文字";
            // 
            // labelLog
            // 
            this.labelLog.BackColor = System.Drawing.Color.Gray;
            this.labelLog.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelLog.Location = new System.Drawing.Point(5, 0);
            this.labelLog.Name = "labelLog";
            this.labelLog.Size = new System.Drawing.Size(18, 51);
            this.labelLog.TabIndex = 12;
            this.labelLog.Text = "   ログ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(539, 47);
            this.panel1.TabIndex = 13;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.butStop);
            this.groupBox2.Controls.Add(this.butStart);
            this.groupBox2.Controls.Add(this.picIndicator);
            this.groupBox2.Location = new System.Drawing.Point(67, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(124, 35);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            // 
            // butStop
            // 
            this.butStop.Enabled = false;
            this.butStop.Location = new System.Drawing.Point(73, 8);
            this.butStop.Name = "butStop";
            this.butStop.Size = new System.Drawing.Size(43, 23);
            this.butStop.TabIndex = 9;
            this.butStop.Text = "Stop";
            this.butStop.UseVisualStyleBackColor = true;
            this.butStop.Click += new System.EventHandler(this.butStop_Click);
            // 
            // butStart
            // 
            this.butStart.Location = new System.Drawing.Point(24, 8);
            this.butStart.Name = "butStart";
            this.butStart.Size = new System.Drawing.Size(43, 23);
            this.butStart.TabIndex = 8;
            this.butStart.Text = "Start";
            this.butStart.UseVisualStyleBackColor = true;
            this.butStart.Click += new System.EventHandler(this.butStart_Click);
            // 
            // butClsRead
            // 
            this.butClsRead.Location = new System.Drawing.Point(3, 4);
            this.butClsRead.Name = "butClsRead";
            this.butClsRead.Size = new System.Drawing.Size(18, 23);
            this.butClsRead.TabIndex = 10;
            this.butClsRead.Text = "C";
            this.butClsRead.UseVisualStyleBackColor = true;
            this.butClsRead.Click += new System.EventHandler(this.butClsRead_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Controls.Add(this.panel8, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBoxWrite, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxLog, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxRead, 1, 1);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(539, 230);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.butClsLog);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(500, 163);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(34, 62);
            this.panel8.TabIndex = 18;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.butSend);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(5, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(29, 60);
            this.panel3.TabIndex = 13;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Gray;
            this.panel4.Controls.Add(this.labelRead);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(5, 73);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(29, 82);
            this.panel4.TabIndex = 14;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Gray;
            this.panel5.Controls.Add(this.labelLog);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(5, 163);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(29, 62);
            this.panel5.TabIndex = 15;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.butClsWrite);
            this.panel6.Location = new System.Drawing.Point(500, 5);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(34, 60);
            this.panel6.TabIndex = 16;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.butClsRead);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(500, 73);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(34, 82);
            this.panel7.TabIndex = 17;
            // 
            // FomSoch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 277);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "FomSoch";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "ソケット通信";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FomSoch_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.picIndicator)).EndInit();
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
        private System.Windows.Forms.TextBox textBoxIp;
        private System.Windows.Forms.TextBox textBoxPortNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxWrite;
        private System.Windows.Forms.Button butSend;
        private System.Windows.Forms.Button butClsWrite;
        private System.Windows.Forms.PictureBox picIndicator;
        private System.Windows.Forms.TextBox textBoxRead;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.Button butClsLog;
        private System.Windows.Forms.Label labelRead;
        private System.Windows.Forms.Label labelLog;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button butClsRead;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Timer timerServerStart;
        private System.Windows.Forms.Button butStop;
        private System.Windows.Forms.Button butStart;
    }
}