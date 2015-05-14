using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasketballManagementSystem.Interface
{
    /// <summary>
    /// 終了処理を行うものはこれを実装
    /// </summary>
    interface IClose
    {
        /// <summary>
        /// それぞれが行いたい終了処理を記述
        /// </summary>
        void IClose();
    }
}
