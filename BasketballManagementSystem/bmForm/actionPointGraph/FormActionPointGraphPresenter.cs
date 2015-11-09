using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasketballManagementSystem.abstracts;

namespace BasketballManagementSystem.bmForm.actionPointGraph
{
    public class FormActionPointGraphPresenter : AbstractPresenter
    {
        private FormActionPointGraphModel graphModel;
        private FormActionPointGraphView graphView;

        public FormActionPointGraphPresenter(FormActionPointGraphModel model, FormActionPointGraphView view)
            :base(view, model)
        {
            this.graphModel = model;
            this.graphView = view;

            view.Presenter = this;

            view.SelectedPlayerChangedEvent += view_SelectedPlayerChangedEvent;
        }

        void view_SelectedPlayerChangedEvent(baseClass.player.Player obj)
        {
            this.graphModel.SelectedPlayer = obj;
        }

        public override void ShowView()
        {
            this.graphView.Show();
        }

        public override System.Windows.Forms.Form GetForm()
        {
            return this.graphView;
        }
    }
}
