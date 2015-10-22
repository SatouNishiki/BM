using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace BasketballManagementSystem.BaseClass.player
{
    /// <summary>
    /// メンバーチェンジについての情報を記録するクラス
    /// </summary>
    [Serializable]
    public class MemberChange
    {
        /// <summary>
        /// メンバーチェンジを行った絶対時間
        /// </summary>
        public DateTime ChengedMemberTime { get; set; }

        /// <summary>
        /// メンバーチェンジを行ったクォーター
        /// </summary>
        public int Quarter { get; set; }

        /// <summary>
        /// メンバーチェンジを行ったときの残り時間
        /// </summary>
        [XmlIgnore]
        public TimeSpan RemainingTime { get; set; }

        [XmlAttribute("RemainingTime")]
        public string XmlElapsedTime
        {
            get { return XmlConvert.ToString(RemainingTime); }
            set { RemainingTime = XmlConvert.ToTimeSpan(value); }
        }

        /// <summary>
        /// メンバーチェンジを行ったコートプレイヤー
        /// </summary>
        public List<Player> ChangedCortMembers { get; set; }

        /// <summary>
        /// メンバーチェンジを行ったベンチプレイヤー
        /// </summary>
        public List<Player> ChangedOutMembers { get; set; }

        public MemberChange()
        {
            ChengedMemberTime = new DateTime();
            Quarter = 0;
            RemainingTime = new TimeSpan();
            ChangedCortMembers = new List<Player>();
            ChangedOutMembers = new List<Player>();
        }
    }
}
