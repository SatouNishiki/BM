using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasketballManagementSystem.baseClass.player;

namespace BasketballManagementSystem.interfaces.actionPointGraph
{
    public interface IActionPointGraphView : IView
    {
        event Action<Player> SelectedPlayerChangedEvent;

        void SetMyListBox(List<Player> players);
        void SetOppentListBox(List<Player> players);
        void SetMyTeamName(string name);
        void SetOppentTeamName(string name);

    }
}
