using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasketballManagementSystem.bmForm.actionPointEdit;
using System.Windows.Forms;

namespace BasketballManagementSystem.factory
{
    public class FormActionPointEditFactory : FormFactory
    {
        public override abstracts.AbstractPresenter CreatePresenter()
        {
            FormActionPointEditModel model = new FormActionPointEditModel();
            FormActionPointEditView view = new FormActionPointEditView();
            FormActionPointEditPresenter presenter = new FormActionPointEditPresenter(view, model);
           
            return presenter;
        }

    }
}
