using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasketballManagementSystem.events;
using BasketballManagementSystem.abstracts;

namespace BasketballManagementSystem.interfaces
{
    /// <summary>
    /// Viewの共通インターフェースベース
    /// </summary>
    public interface IView
    {
        /// <summary>
        /// データが入力されたときのイベント
        /// </summary>
        event DataInputEventHandler DataInputEvent;

        AbstractPresenter Presenter { get; set; }
    }
}
