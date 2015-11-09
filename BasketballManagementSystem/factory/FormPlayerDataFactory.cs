using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasketballManagementSystem.bmForm.playerData;

namespace BasketballManagementSystem.factory
{
    public class FormPlayerDataFactory : FormFactory
    {
        public override abstracts.AbstractPresenter CreatePresenter()
        {
            FormPlayerDataModel model = new FormPlayerDataModel();
            FormPlayerDataView view = new FormPlayerDataView();
            FormPlayerDataPresenter presenter = new FormPlayerDataPresenter(model, view);
            return presenter;
        }
    }
}
