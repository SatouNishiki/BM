using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasketballManagementSystem.abstracts;
using System.Windows.Forms;

namespace BasketballManagementSystem.bmForm.boxScore
{
    public class FormBoxScorePresenter : AbstractPresenter
    {
        private FormBoxScoreModel boxScoreModel;
        private FormBoxScoreView boxScoreView;
        private Form form;

        public FormBoxScorePresenter(FormBoxScoreModel model, FormBoxScoreView view)
            : base(view, model)
        {
            this.boxScoreModel = model;
            this.boxScoreView = view;
            this.form = view;
            view.Presenter = this;

            view.Init();
            
        }

        public override Form GetForm()
        {
            return this.form;
        }

        public override void ShowView()
        {
            this.boxScoreView.Show();
        }
    }
}
