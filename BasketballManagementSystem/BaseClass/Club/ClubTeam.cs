using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballManagementSystem.BaseClass.club
{
    /// <summary>
    /// 部活をあらわすクラス
    /// </summary>
    [Serializable]
    public class ClubTeam
    {
        /// <summary>
        /// 部活名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 部員のリスト
        /// </summary>
        public List<ClubMember> ClubMemberList { get; set; }


        public ClubTeam()
        {
            ClubMemberList = new List<ClubMember>();
        }
    }
}
