using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasketballManagementSystem.abstracts;

namespace BasketballManagementSystem.bmForm.gameDataEdit
{
    public class FormGameDataEditPresenter : AbstractPresenter
    {
        private FormGameDataEditModel formModel;
        private FormGameDataEditView formView;

        public FormGameDataEditPresenter(FormGameDataEditModel model, FormGameDataEditView view)
            : base(view, model)
        {
            this.formModel = model;
            this.formView = view;

            this.formView.Presenter = this;

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
