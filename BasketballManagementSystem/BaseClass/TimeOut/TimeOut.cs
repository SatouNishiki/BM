using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace BasketballManagementSystem.BaseClass.timeOut
{
    [Serializable]
    public class TimeOut
    {
        /// <summary>
        /// 前半をあらわす定数
        /// </summary>
        public static readonly int FirstHalf = 100;

        /// <summary>
        /// 後半をあらわす定数
        /// </summary>
        public static readonly int SecondHalf = 101;

        /// <summary>
        /// 延長を表す定数
        /// </summary>
        public static readonly int ExtraInning = 102;

        /// <summary>
        /// タイムアウトが行われたクォーター(延長は5クォーター、6クォーターと数える)
        /// </summary>
        public int Quarter { get; set; }

        /// <summary>
        /// タイムアウトが行われたときの絶対時刻
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// タイムアウトが行われたときの残り時間
        /// </summary>
        [XmlIgnore]
        public TimeSpan RemainingTimeMinutes { get; set; }

        //TimeSpan型はなぜかシリアライズのサポート外なためこんなことしないといけない 激おこぷんぷん丸
        [XmlAttribute("remainingTimeMinutes", DataType = "duration")]
        public string XmlRemainingTimeMinutes
        {
            get { return XmlConvert.ToString(RemainingTimeMinutes); }
            set { RemainingTimeMinutes = XmlConvert.ToTimeSpan(value); }
        }

        public TimeOut()
        {
            Quarter = 0;
            Time = new DateTime();
            RemainingTimeMinutes = new TimeSpan();
        }

        public TimeOut(int q, DateTime d, TimeSpan t)
        {
            Quarter = q;
            Time = d;
            RemainingTimeMinutes = t;
        }

        /// <summary>
        /// タイムアウトが指定した区間に当たるかどうかを返す
        /// </summary>
        /// <param name="timeoutSection">TimeOutクラスで宣言された定数</param>
        /// <returns></returns>
        public bool GetTimeOutSection(int timeoutSection)
        {
            if (timeoutSection == FirstHalf)
            {
                return Quarter == 1 || Quarter == 2;
            }
            else if (timeoutSection == SecondHalf)
            {
                return Quarter == 3 || Quarter == 4;
            }
            else
            {
                return Quarter > 4;
            }
        }
    }
}
