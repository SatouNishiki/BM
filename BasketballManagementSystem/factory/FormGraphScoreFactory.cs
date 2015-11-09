using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasketballManagementSystem.bmForm.graphScore;

namespace BasketballManagementSystem.factory
{
    public class FormGraphScoreFactory : FormFactory
    {
        public override abstracts.AbstractPresenter CreatePresenter()
        {
            FormGraphScoreModel model = new FormGraphScoreModel();
            FormGraphScoreView view = new FormGraphScoreView();
            FormGraphScorePresenter presenter = new FormGraphScorePresenter(model, view);

            return presenter;
        }
    }
}
