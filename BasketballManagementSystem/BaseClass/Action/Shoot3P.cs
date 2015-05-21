using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasketballManagementSystem.BaseClass.Action
{
    /// <summary>
    /// 3ポイントシュートのクラス
    /// </summary>
    [Serializable]
    public class Shoot3P : RelationPointAction
    {
        public Shoot3P()
        {
            Point = 3;
        }
    }
}
