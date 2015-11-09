using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasketballManagementSystem.bmForm.centralityAnalyze;

namespace BasketballManagementSystem.factory
{
    public class FormCentralityAnalyzeFactory : FormFactory
    {
        public override abstracts.AbstractPresenter CreatePresenter()
        {
            FormCentralityAnalyzeModel model = new FormCentralityAnalyzeModel();
            FormCentralityAnalyzeView view = new FormCentralityAnalyzeView();
            FormCentralityAnalyzePresenter presenter = new FormCentralityAnalyzePresenter(model, view);

            return presenter;
        }
    }
}
