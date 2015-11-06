using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasketballManagementSystem.bmForm.clubEdit;

namespace BasketballManagementSystem.factory
{
    public class FormClubEditFactory : FormFactory
    {
        public override abstracts.AbstractPresenter CreatePresenter()
        {
            FormClubEditModel model = new FormClubEditModel();
            FormClubEditView view = new FormClubEditView();
            FormClubEditPresenter presenter = new FormClubEditPresenter(model, view);

            return presenter;
        }
    }
}
