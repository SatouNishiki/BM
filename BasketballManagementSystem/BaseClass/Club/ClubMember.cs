using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballManagementSystem.baseClass.club
{
    /// <summary>
    /// 部員を表すクラス
    /// </summary>
    [Serializable]
    public class ClubMember
    {
        /// <summary>
        /// 部員の名前
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// true:男 false:女
        /// </summary>
        public bool IsMan { get; set; }

        /// <summary>
        /// 身長 未入力なら0以下を返す
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// 体重 未入力なら0以下を返す
        /// </summary>
        public double Weight { get; set; }


        public override string ToString()
        {
            return Name;
        }
    }
}
