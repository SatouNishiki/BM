using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasketballManagementSystem.interfaces.actionPointEdit
{
    public interface IActionPointEditView : IView
    {
        event Action LoadEvent;
        event Action SetDefaultClickEvent;
        event Action SaveClickEvent;

        List<NumericUpDown> GetNumericUpDownControls();
    }
}
