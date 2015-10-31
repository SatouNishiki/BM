using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasketballManagementSystem.bmForm.boxScore;

namespace BasketballManagementSystem.factory
{
    public class FormBoxScoreFactory : FormFactory
    {
        public override abstracts.AbstractPresenter CreatePresenter()
        {
            FormBoxScoreModel model = new FormBoxScoreModel();
            FormBoxScoreView view = new FormBoxScoreView();
            FormBoxScorePresenter presenter = new FormBoxScorePresenter(model, view);

            return presenter;
        }
    }
}
