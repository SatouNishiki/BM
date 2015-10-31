using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasketballManagementSystem.bmForm.input;
using BasketballManagementSystem.abstracts;
using System.Windows.Forms;

namespace BasketballManagementSystem.factory
{
    public class FormInputFactory : FormFactory
    {
        public override AbstractPresenter CreatePresenter()
        {
            FormInputModel model = new FormInputModel();
            FormInputView view = new FormInputView();
            FormInputPresenter presenter = new FormInputPresenter(view, model);

            return presenter;
        }

    }
}
