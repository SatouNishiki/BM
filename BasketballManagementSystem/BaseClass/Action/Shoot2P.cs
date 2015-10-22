using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasketballManagementSystem.BaseClass.action
{
    /// <summary>
    /// 2ポイントシュートのクラス
    /// </summary>
    [Serializable]
    public class Shoot2P : RelationPointAction
    {
        public Shoot2P()
        {
            Point = 2;
        }

    }
}
