using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasketballManagementSystem.interfaces;
using System.Windows.Forms;
using BasketballManagementSystem.events;
using BasketballManagementSystem.baseClass.settings;
using BasketballManagementSystem.abstracts;

namespace BasketballManagementSystem.bmForm.actionPointEdit
{
    public class FormActionPointEditModel : AbstractModel
    {
        /// <summary>
        /// フォーム内のnumericUpDownコントロールのlist
        /// </summary>
        private List<NumericUpDown> numericUpDowns = new List<NumericUpDown>();


        /// <summary>
        /// NumericUpDownの初期設定
        /// </summary>
        /// <param name="controls"></param>
        public void SetNumericUpDowns(List<NumericUpDown> controls)
        {
            foreach(var c in controls){
                this.numericUpDowns.Add(c);
            }
        }

        /// <summary>
        /// 設定ファイルに現在のAPをセーブします
        /// </summary>
        public void SaveAPToAppSetting()
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
        /// 設定ファイルからAPを取得し、NumericUpDownに割り当てます
        /// </summary>
        public void LoadFromAppSetting()
        {
            foreach (var n in numericUpDowns)
            {
                string s = n.Name.Substring(0, n.Name.Length - 13);
                n.Value = AppSetting.GetInstance().ActionPointProvider.GetActionPoint(s);
            }
        }

        /// <summary>
        /// 設定ファイルのAP項目をデフォルト値に設定します
        /// </summary>
        public void SetAPDefaultToAppSetting()
        {
            AppSetting.GetInstance().ActionPointProvider.SetDefault();
        }

        
    }
}
