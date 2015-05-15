using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasketballManagementSystem.Interface.loder
{
    /// <summary>
    /// loadを行う奴はこれを実装
    /// </summary>
    interface ILorder
    {
        /// <summary>
        /// それぞれのロードで行う動作を定義
        /// </summary>
        void load();
    }
}
