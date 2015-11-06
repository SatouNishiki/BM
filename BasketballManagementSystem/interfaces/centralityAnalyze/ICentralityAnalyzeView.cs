using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasketballManagementSystem.baseClass.player;

namespace BasketballManagementSystem.interfaces.centralityAnalyze
{
    public interface ICentralityAnalyzeView : IView
    {
        event Action AnalyzeButtonClickEvent;
        event Action<Player> SourcePlayerSelectedEvent;

        void WriteResult(string text);
        void ClearResult();
    }
}
