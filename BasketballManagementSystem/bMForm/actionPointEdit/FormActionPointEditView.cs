using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BasketballManagementSystem.baseClass.settings;
using BasketballManagementSystem.interfaces.actionPointEdit;
using BasketballManagementSystem.abstracts;
using BasketballManagementSystem.events;

namespace BasketballManagementSystem.bMForm.actionPointEdit
{
    public partial class FormActionPointEditView : Form, IActionPointEditView
    {
       
        private AbstractPresenter presenter;


        public event Action LoadEvent;
        public event Action SetDefaultClickEvent;
        public event Action SaveClickEvent;
        public event DataInputEventHandler DataInputEvent;

        public AbstractPresenter Presenter
        {
            get
            {
                return this.presenter;
            }
            set
            {
                this.presenter = value;
            }
        }

        public FormActionPointEditView()
        {
            InitializeComponent();
            
        }

        /// <summary>
        /// セーブボタンがクリックされたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_Click(object sender, EventArgs e)
        {
            this.SaveClickEventThrow();
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
        /// 傾向点をデフォルトに戻す
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingAPDefault_Click(object sender, EventArgs e)
        {
            this.SetDefaultClickEventThrow();
        }

        public List<NumericUpDown> GetNumericUpDownControls()
        {
            List<NumericUpDown> controls = new List<NumericUpDown>();

            foreach (var c in Controls)
            {
                if (c.GetType() == typeof(GroupBox))
                {
                    foreach (var c2 in ((GroupBox)c).Controls)
                    {
                        //GroupBoxに囲まれた全てのNumericUpDownコントロールを取得してくる
                        if (c2.GetType() == typeof(NumericUpDown))
                            controls.Add((NumericUpDown)c2);
                    }
                }
            }

            return controls;
        }

        


        private void LoadEventThrow()
        {
            if (this.LoadEvent != null)
            {
                this.LoadEvent();
            }
        }

        private void SetDefaultClickEventThrow()
        {
            if (this.SetDefaultClickEvent != null)
            {
                this.SetDefaultClickEvent();
            }
        }

        private void SaveClickEventThrow()
        {
            if (this.SaveClickEvent != null)
            {
                this.SaveClickEvent();
            }
        }

        private void DataChangeEventThrow(string name, object value)
        {
            if (this.DataInputEvent != null)
            {
                this.DataInputEvent(this, new DataInputEventArgs(name, value));
            }
        }

        private void FormActionPointEditView_Load(object sender, EventArgs e)
        {
            this.LoadEventThrow();
        }
        
    }
}
