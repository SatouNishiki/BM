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

            foreach (Control _c in Controls)
            {
                if (_c.GetType() == typeof(GroupBox))
                {
                    foreach (Control _c2 in ((GroupBox)_c).Controls)
                    {
                        //GroupBoxに囲まれた全てのNumericUpDownコントロールを取得してくる
                        if(_c2.GetType() == typeof(NumericUpDown))
                        numericUpDowns.Add((NumericUpDown)_c2);
                    }
                }
            }
        }

        /// <summary>
        /// セーブボタンがクリックされたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void save_Click(object sender, EventArgs e)
        {
            foreach (NumericUpDown _n in numericUpDowns)
            {
                AppSetting.GetInstance().ActionPointProvider.SetActionPoint
                    (
                        _n.Name.Substring(13), //名前から"numericUpDown"の13文字を切り取る=Actionの名前になる
                        int.Parse(_n.Value.ToString())
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
            save_Click(sender, e);
        }

        /// <summary>
        /// フォームがロードされたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ActionPointEditForm_Load(object sender, EventArgs e)
        {
            foreach (NumericUpDown _n in numericUpDowns)
            {
                string _s = _n.Name.Substring(13);
                _n.Value = AppSetting.GetInstance().ActionPointProvider.GetActionPoint(_s);
            }
        }

        /// <summary>
        /// 傾向点をデフォルトに戻す
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void settingAPDefault_Click(object sender, EventArgs e)
        {
            AppSetting.GetInstance().ActionPointProvider.SetDefault();
            ActionPointEditForm_Load(sender, e);
        }
    }
}
