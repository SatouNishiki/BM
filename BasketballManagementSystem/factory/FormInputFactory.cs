using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasketballManagementSystem.bMForm.input;
using BasketballManagementSystem.abstracts;
using System.Windows.Forms;

namespace BasketballManagementSystem.factory
{
    public class FormInputFactory : FormFactory
    {
        private Form form;

        public override AbstractPresenter CreatePresenter()
        {
            FormInputModel model = new FormInputModel();
            FormInputView view = new FormInputView();
            FormInputPresenter presenter = new FormInputPresenter(view, model);

            this.form = view;

            return presenter;
        }

        public override Form GetForm()
        {
            return form;
        }
    }
}
