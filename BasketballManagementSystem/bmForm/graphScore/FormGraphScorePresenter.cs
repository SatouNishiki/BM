using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballManagementSystem.bmForm.graphScore
{
    public class FormGraphScorePresenter : abstracts.AbstractPresenter
    {
        private FormGraphScoreModel formModel;
        private FormGraphScoreView formView;

        public FormGraphScorePresenter(FormGraphScoreModel model, FormGraphScoreView view)
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
