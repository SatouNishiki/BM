using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballManagementSystem.baseClass.action
{
    [Serializable]
    public class Faul : NonRelationPointAction
    {
        /// <summary>
        /// 与えたフリースローの数
        /// </summary>
        public int GivenFreeThrow { get; set; }
    }
}
