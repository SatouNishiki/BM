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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBoxWrite = new System.Windows.Forms.TextBox();
            this.panel9 = new System.Windows.Forms.Panel();
            this.listBoxClient = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.butClsLog = new System.Windows.Forms.Button();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.butSend = new System.Windows.Forms.Button();
            this.textBoxRead = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.labelRead = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.labelLog = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.butClsWrite = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.butClsRead = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.butStop = new System.Windows.Forms.Button();
            this.butStart = new System.Windows.Forms.Button();
            this.picIndicator = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBoxPortNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.timerServerSend = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIndicator)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 152F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel8, 2, 2);
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(582, 249);
            this.tableLayoutPanel1.TabIndex = 20;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.textBoxWrite);
            this.panel2.Controls.Add(this.panel9);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(42, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(381, 74);
            this.panel2.TabIndex = 20;
            // 
            // textBoxWrite
            // 
            this.textBoxWrite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxWrite.Location = new System.Drawing.Point(94, 0);
            this.textBoxWrite.Multiline = true;
            this.textBoxWrite.Name = "textBoxWrite";
            this.textBoxWrite.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxWrite.Size = new System.Drawing.Size(287, 74);
            this.textBoxWrite.TabIndex = 19;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.listBoxClient);
            this.panel9.Controls.Add(this.label1);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(94, 74);
            this.panel9.TabIndex = 20;
            // 
            // listBoxClient
            // 
            this.listBoxClient.BackColor = System.Drawing.Color.Azure;
            this.listBoxClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxClient.ForeColor = System.Drawing.Color.Black;
            this.listBoxClient.FormattingEnabled = true;
            this.listBoxClient.ItemHeight = 12;
            this.listBoxClient.Location = new System.Drawing.Point(0, 12);
            this.listBoxClient.Name = "listBoxClient";
            this.listBoxClient.Size = new System.Drawing.Size(94, 62);
            this.listBoxClient.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "クライアント選択";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.butClsLog);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(431, 169);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(146, 75);
            this.panel8.TabIndex = 18;
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
            // textBoxLog
            // 
            this.textBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxLog.Location = new System.Drawing.Point(42, 169);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ReadOnly = true;
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLog.Size = new System.Drawing.Size(381, 75);
            this.textBoxLog.TabIndex = 9;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.butSend);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(5, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(29, 74);
            this.panel3.TabIndex = 13;
            // 
            // butSend
            // 
            this.butSend.Location = new System.Drawing.Point(2, 13);
            this.butSend.Name = "butSend";
            this.butSend.Size = new System.Drawing.Size(24, 43);
            this.butSend.TabIndex = 5;
            this.butSend.Text = "送信";
            this.butSend.UseVisualStyleBackColor = true;
            this.butSend.Click += new System.EventHandler(this.butSend_Click);
            // 
            // textBoxRead
            // 
            this.textBoxRead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxRead.Location = new System.Drawing.Point(42, 87);
            this.textBoxRead.Multiline = true;
            this.textBoxRead.Name = "textBoxRead";
            this.textBoxRead.ReadOnly = true;
            this.textBoxRead.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxRead.Size = new System.Drawing.Size(381, 74);
            this.textBoxRead.TabIndex = 7;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Gray;
            this.panel4.Controls.Add(this.labelRead);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(5, 87);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(29, 74);
            this.panel4.TabIndex = 14;
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
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Gray;
            this.panel5.Controls.Add(this.labelLog);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(5, 169);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(29, 75);
            this.panel5.TabIndex = 15;
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
            // panel6
            // 
            this.panel6.Controls.Add(this.butClsWrite);
            this.panel6.Location = new System.Drawing.Point(431, 5);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(144, 74);
            this.panel6.TabIndex = 16;
            // 
            // butClsWrite
            // 
            this.butClsWrite.Location = new System.Drawing.Point(2, 0);
            this.butClsWrite.Name = "butClsWrite";
            this.butClsWrite.Size = new System.Drawing.Size(18, 23);
            this.butClsWrite.TabIndex = 6;
            this.butClsWrite.Text = "C";
            this.butClsWrite.UseVisualStyleBackColor = true;
            this.butClsWrite.Click += new System.EventHandler(this.butClsWrite_Click);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.butClsRead);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(431, 87);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(146, 74);
            this.panel7.TabIndex = 17;
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
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(582, 47);
            this.panel1.TabIndex = 21;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.butStop);
            this.groupBox2.Controls.Add(this.butStart);
            this.groupBox2.Controls.Add(this.picIndicator);
            this.groupBox2.Location = new System.Drawing.Point(7, 5);
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
            this.butStart.Location = new System.Drawing.Point(25, 8);
            this.butStart.Name = "butStart";
            this.butStart.Size = new System.Drawing.Size(43, 23);
            this.butStart.TabIndex = 8;
            this.butStart.Text = "Start";
            this.butStart.UseVisualStyleBackColor = true;
            this.butStart.Click += new System.EventHandler(this.butStart_Click);
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
            this.groupBox3.Location = new System.Drawing.Point(150, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(110, 35);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            // 
            // textBoxPortNo
            // 
            this.textBoxPortNo.Location = new System.Drawing.Point(44, 10);
            this.textBoxPortNo.Name = "textBoxPortNo";
            this.textBoxPortNo.Size = new System.Drawing.Size(48, 19);
            this.textBoxPortNo.TabIndex = 3;
            this.textBoxPortNo.Text = "1001";
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
            // timerServerSend
            // 
            this.timerServerSend.Enabled = true;
            this.timerServerSend.Tick += new System.EventHandler(this.timerServerSend_Tick);
            // 
            // FomServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 296);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Name = "FomServer";
            this.Text = "ソケット通信";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picIndicator)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button butClsLog;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button butSend;
        private System.Windows.Forms.TextBox textBoxRead;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label labelRead;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label labelLog;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button butClsWrite;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button butClsRead;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button butStop;
        private System.Windows.Forms.Button butStart;
        private System.Windows.Forms.PictureBox picIndicator;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBoxPortNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxClient;
        private System.Windows.Forms.TextBox textBoxWrite;
        private System.Windows.Forms.Timer timerServerSend;
    }
}