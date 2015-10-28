using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasketballManagementSystem.bMForm.actionPointEdit;
using System.Windows.Forms;

namespace BasketballManagementSystem.factory
{
    public class FormActionPointEditFactory : FormFactory
    {
        private Form form;

        public override abstracts.AbstractPresenter CreatePresenter()
        {
            FormActionPointEditModel model = new FormActionPointEditModel();
            FormActionPointEditView view = new FormActionPointEditView();
            FormActionPointEditPresenter presenter = new FormActionPointEditPresenter(view, model);

            this.form = view;

            return presenter;
        }

        public override Form GetForm()
        {
            return this.form;
        }
    }
}
