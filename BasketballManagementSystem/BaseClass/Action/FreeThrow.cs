using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasketballManagementSystem.BaseClass.action
{
    /// <summary>
    /// フリースローのクラス
    /// </summary>
    [Serializable]
    public class FreeThrow : RelationPointAction
    {
        public FreeThrow()
        {
            Point = 1;
        }
    }
}
