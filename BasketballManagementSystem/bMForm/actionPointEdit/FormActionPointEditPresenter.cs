using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasketballManagementSystem.abstracts;
using System.Windows.Forms;

namespace BasketballManagementSystem.bmForm.actionPointEdit
{
    public class FormActionPointEditPresenter : AbstractPresenter
    {
        private FormActionPointEditModel actionPointEditModel;
        private FormActionPointEditView actionPointEditView;

        public FormActionPointEditPresenter(FormActionPointEditView f, FormActionPointEditModel f2)
            :base(f, f2)
        {
            this.actionPointEditModel = f2;
            this.actionPointEditView = f;

            this.actionPointEditView.LoadEvent += actionPointEditView_InitEvent;
            this.actionPointEditView.SetDefaultClickEvent += actionPointEditView_SetDefaultClickEvent;
            this.actionPointEditView.SaveClickEvent += actionPointEditView_SaveClickEvent;
        }

        public override void ShowView()
        {
            this.actionPointEditView.Show();
        }

        public override Form GetForm()
        {
            return this.actionPointEditView;
        }

        void actionPointEditView_SaveClickEvent()
        {
            this.actionPointEditModel.SaveAPToAppSetting();
        }

        void actionPointEditView_SetDefaultClickEvent()
        {
            this.actionPointEditModel.SetAPDefaultToAppSetting();
            this.actionPointEditModel.LoadFromAppSetting();
        }

        void actionPointEditView_InitEvent()
        {
            this.actionPointEditModel.SetNumericUpDowns(this.actionPointEditView.GetNumericUpDownControls());
            this.actionPointEditModel.LoadFromAppSetting();
        }


    }
}
