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
        private List<NumericUpDown> numericUpDownList = new List<NumericUpDown>();

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
                        numericUpDownList.Add((NumericUpDown)_c2);
                    }
                }
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            foreach (NumericUpDown _n in numericUpDownList)
            {
                AppSetting.GetInstance().ActionPointProvider.SetActionPoint
                    (
                        _n.Name.Substring(13), //名前から"numericUpDown"の13文字を切り取る=Actionの名前になる
                        int.Parse(_n.Value.ToString())
                    );
            }
        }

        private void ActionPointEditForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            save_Click(sender, e);
        }

        private void ActionPointEditForm_Load(object sender, EventArgs e)
        {
            foreach (NumericUpDown _n in numericUpDownList)
            {
                string _s = _n.Name.Substring(13);
                _n.Value = AppSetting.GetInstance().ActionPointProvider.GetActionPoint(_s);
            }
        }

        private void settingAPDefault_Click(object sender, EventArgs e)
        {
            AppSetting.GetInstance().ActionPointProvider.SetDefault();
            ActionPointEditForm_Load(sender, e);
        }
    }
}
