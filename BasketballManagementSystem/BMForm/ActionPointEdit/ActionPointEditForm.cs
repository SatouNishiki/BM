using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BasketballManagementSystem.BaseClass.Settings;

namespace BasketballManagementSystem.BMForm.ActionPointEdit
{
    public partial class ActionPointEditForm : Form
    {
        /// <summary>
        /// フォーム内のnumericUpDownコントロールのlist
        /// </summary>
        private List<NumericUpDown> numericUpDowns = new List<NumericUpDown>();

        public ActionPointEditForm()
        {
            InitializeComponent();

            foreach (var c in Controls)
            {
                if (c.GetType() == typeof(GroupBox))
                {
                    foreach (var c2 in ((GroupBox)c).Controls)
                    {
                        //GroupBoxに囲まれた全てのNumericUpDownコントロールを取得してくる
                        if(c2.GetType() == typeof(NumericUpDown))
                        numericUpDowns.Add((NumericUpDown)c2);
                    }
                }
            }
        }

        /// <summary>
        /// セーブボタンがクリックされたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_Click(object sender, EventArgs e)
        {
            foreach (var n in numericUpDowns)
            {
                AppSetting.GetInstance().ActionPointProvider.SetActionPoint
                    (
                        n.Name.Substring(0, n.Name.Length - 13), //名前から"numericUpDown"の13文字を切り取る=Actionの名前になる
                        int.Parse(n.Value.ToString())
                    );
            }
        }

        /// <summary>
        /// フォームが閉じられたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ActionPointEditForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Save_Click(sender, e);
        }

        /// <summary>
        /// フォームがロードされたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ActionPointEditForm_Load(object sender, EventArgs e)
        {
            foreach (var n in numericUpDowns)
            {
                string s = n.Name.Substring(0, n.Name.Length - 13);
                n.Value = AppSetting.GetInstance().ActionPointProvider.GetActionPoint(s);
            }
        }

        /// <summary>
        /// 傾向点をデフォルトに戻す
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingAPDefault_Click(object sender, EventArgs e)
        {
            AppSetting.GetInstance().ActionPointProvider.SetDefault();
            ActionPointEditForm_Load(sender, e);
        }
    }
}
