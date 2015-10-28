using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasketballManagementSystem.bMForm.popupForm
{
    public partial class PopupForm : Form
    {
        private int timerCount = 0;
        private int timerCountRimit = 5;

        public PopupForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// フォームを表示
        /// </summary>
        /// <param name="message">表示するメッセージ</param>
        public void Show(string message)
        {
            this.label1.Text = message;
            this.Show();

            this.timer1.Enabled = true;

        }

        /// <summary>
        /// フォームを表示
        /// </summary>
        /// <param name="message">表示するメッセージ</param>
        /// <param name="time">表示時間(1/10秒単位)</param>
        public void Show(string message, int time)
        {
            this.label1.Text = message;
            this.timerCountRimit = time;
            this.Show();

            this.timer1.Enabled = true;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timerCount++;

            if (timerCount > 5)
            {
                //徐々に消える
                for (int i = 10; i >= 0; i--)
                {
                    //フォームの不透明度を変更する
                    this.Opacity = 0.1 * i;
                    //一時停止
                    System.Threading.Thread.Sleep(50);
                }
                this.Dispose();
            }
        }
    }
}
