using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasketballManagementSystem.events;

namespace BasketballManagementSystem.interfaces
{
    /// <summary>
    /// ドメインモデルを表すインターフェース
    /// </summary>
    public interface IModel
    {
        /// <summary>
        /// プロパティが変更されたときのイベント
        /// </summary>
        event PropertyChangedEventHandler PropertyChangedEvent;
    }
}
