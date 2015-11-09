using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BasketballManagementSystem.bmForm.actionPointGraph;

namespace BasketballManagementSystem.factory
{
    public class FormAcitonPointGraphFactory : FormFactory
    {
        public override abstracts.AbstractPresenter CreatePresenter()
        {
            FormActionPointGraphModel model = new FormActionPointGraphModel();
            FormActionPointGraphView view = new FormActionPointGraphView();
            
            FormActionPointGraphPresenter presenter = new FormActionPointGraphPresenter(model, view);

            return presenter;
        }

       
    }
}
