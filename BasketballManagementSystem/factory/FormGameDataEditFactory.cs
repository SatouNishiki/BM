using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasketballManagementSystem.bmForm.gameDataEdit;

namespace BasketballManagementSystem.factory
{
    public class FormGameDataEditFactory : FormFactory
    {
        public override abstracts.AbstractPresenter CreatePresenter()
        {
            FormGameDataEditModel model = new FormGameDataEditModel();
            FormGameDataEditView view = new FormGameDataEditView();
            FormGameDataEditPresenter presenter = new FormGameDataEditPresenter(model, view);

            return presenter;
        }
    }
}
