using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasketballManagementSystem.BMForm.Input
{
    public partial class DebugMessageForm : Form
    {
        public DebugMessageForm()
        {
            InitializeComponent();
        }

        public void addDebugMessage(string message)
        {
            // 現在の日付と時刻を取得する
            DateTime dtNow = DateTime.Now;

            DebugMessageTextBox.AppendText(">[" + dtNow.ToString() + "]" + message + "\n");
            DebugMessageTextBox.AppendText(" \n");


        }
    }
}
