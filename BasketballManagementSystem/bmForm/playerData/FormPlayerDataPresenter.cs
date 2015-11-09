using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballManagementSystem.bmForm.playerData
{
    public class FormPlayerDataPresenter : abstracts.AbstractPresenter
    {
        private FormPlayerDataModel formModel;
        private FormPlayerDataView formView;

        public FormPlayerDataPresenter(FormPlayerDataModel model, FormPlayerDataView view)
            : base(view, model)
        {
            this.formModel = model;
            this.formView = view;

            this.formView.Init();
        }

        public override void ShowView()
        {
            this.formView.Show();
        }

        public override System.Windows.Forms.Form GetForm()
        {
            return this.formView;
        }
    }
}
