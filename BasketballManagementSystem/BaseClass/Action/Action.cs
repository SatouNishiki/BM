using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Reflection;
using BasketballManagementSystem.BaseClass.Settings;

namespace BasketballManagementSystem.BaseClass.Action
{
    /// <summary>
    /// Actionの基底クラスを定義
    /// </summary>
    [Serializable]
    public class Action
    {

        /// <summary>
        /// アクションの名前
        /// </summary>
        public string ActionName { get; set; } 

        /// <summary>
        /// 行動傾向点(旧アクションポイント)
        /// </summary>
        public int ActionPoint 
        {
            get
            {
                return AppSetting.GetInstance().ActionPointProvider.GetActionPoint(ActionName);   
            }
        } 

        /// <summary>
        /// アクションの行われたときの絶対時間
        /// </summary>
        public DateTime ActionDate { get; set; }

        /// <summary>
        /// このアクションが行われたときのクォーター
        /// </summary>
        public int Quarter { get; set; }

        /// <summary>
        /// アクションを行ったプレイヤー名
        /// </summary>
        public string OwnerName { get; set; }

        /// <summary>
        /// アクションを行ったプレイヤーの背番号
        /// </summary>
        public int OwnerNumber { get; set; }

        
        /// <summary>
        /// このアクションが行われたときの残り時間
        /// </summary>
        [XmlIgnore]
        public TimeSpan RemainingTime { get; set; }

        /// <summary>
        /// このアクションが行われたときの、そのクォーターからの経過時間
        /// </summary>
        [XmlIgnore]
        public TimeSpan ElapsedTime { get; set; }

        /*********************** 以下シリアライズ変換用プロパティ *********************************/

        [XmlAttribute("RemainingTime")]
        public string XmlRemainingTime
        {
            get { return XmlConvert.ToString(RemainingTime); }
            set { RemainingTime = XmlConvert.ToTimeSpan(value); }
        }


        [XmlAttribute("RlapsedTime")]
        public string XmlElapsedTime
        {
            get { return XmlConvert.ToString(ElapsedTime); }
            set { ElapsedTime = XmlConvert.ToTimeSpan(value); }
        }


        /*******************************************************************************************/


        public Action()
        {
            ActionName = this.GetType().Name;
            ActionDate = new DateTime();
            Quarter = 1;
            RemainingTime = new TimeSpan();
            ElapsedTime = new TimeSpan();
            OwnerName = "";
            OwnerNumber = 0;
        }

    
        public override string ToString()
        {
            return  "ActionName=" + ActionName ;
        }


        /// <summary>
        /// 渡された名前のプロパティを動的に取得する
        /// </summary>
        /// <param name="action">Actionクラス、またはそれを継承したクラスのインスタンス</param>
        /// <param name="name">プロパティ名</param>
        /// <returns>取得成功? プロパティ : null</returns>
        public object GetPropertyFromString(Action action, string name)
        {
            try
            {
                Type type = typeof(Action);
                PropertyInfo myPropInfo = type.GetProperty(name);

                if (myPropInfo == null) return null;

                object o = myPropInfo.GetValue(action, null);
          
                return o;

            }
            catch (Exception exc)
            {
                BMErrorLibrary.BMError.ErrorMessageOutput(exc.Message, true);
                return null;
            }
        }
    }
}
