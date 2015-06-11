using System;
using System.Collections.Generic;
using System.Linq;
using BasketballManagementSystem.BaseClass.Action;
using System.Xml.Serialization;
using System.Reflection;
using System.Collections;

namespace BasketballManagementSystem.BaseClass.Player
{
    /// <summary>
    /// 選手をあらわすクラス
    /// </summary>
    [Serializable]
    public class Player : IConvertible
    {
        /**************************** PublicProperty *******************************************/

        /// <summary>
        /// 自分のチームかどうか
        /// </summary>
        public bool IsMyTeam { get; set; }

        /// <summary>
        /// スターターかどうか
        /// </summary>
        public bool IsStarter { get; set; }

        /// <summary>
        /// 選手の名前
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 背番号
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// プレイヤーの総得点
        /// </summary>
        public int Point
        {
            get
            {
                int point = 0;

                if(Shoot2P.Count > 0)
                point += Shoot2P[0].Point * Shoot2P.Count;

                if(Shoot3P.Count > 0)
                point += Shoot3P[0].Point * Shoot3P.Count;

                if(FreeThrow.Count > 0)
                point += FreeThrow[0].Point * FreeThrow.Count;


                return point;
            }
        }

        /********************************************************************************************/


        /************************************* ActionList ******************************************/

        //ここ以下の"ActionList"ゾーンの変数名はクラス名と同じにしないと自動読み込みが効かないので注意
        
        /// <summary>
        /// 2ポイントシュートを保持するlist
        /// </summary>
        public List<Shoot2P> Shoot2P { get; set; }  

        /// <summary>
        /// 3ポイントシュートを保持するlist
        /// </summary>
        public List<Shoot3P> Shoot3P { get; set; }

        /// <summary>
        /// フリースローを保持するlist
        /// </summary>
        public List<FreeThrow> FreeThrow { get; set; }

        /// <summary>
        /// アシストを保持するlist
        /// </summary>
        public List<Assist> Assist { get; set; }

        /// <summary>
        /// パーソナルファールを保持するlist
        /// </summary>
        public List<PersonalFaul> PersonalFaul { get; set; }

        /// <summary>
        /// ターンオーバーを保持するlist
        /// </summary>
        public List<TurnOver> TurnOver { get; set; }

        /// <summary>
        /// スティールを保持するlist
        /// </summary>
        public List<Steal> Steal { get; set; }

        /// <summary>
        /// シュートブロックを保持するlist
        /// </summary>
        public List<ShootBlock> ShootBlock { get; set; }


        /// <summary>
        /// 2ポイントシュートのミスを保持するlist
        /// </summary>
        public List<Shoot2PMiss> Shoot2PMiss { get; set; }

        /// <summary>
        /// 3ポイントシュートのミスを保持するlist
        /// </summary>
        public List<Shoot3PMiss> Shoot3PMiss { get; set; }

        /// <summary>
        /// フリースローのミスを保持するlist
        /// </summary>
        public List<FreeThrowMiss> FreeThrowMiss { get; set; }

        /// <summary>
        /// アンスポーツマンライクファールを保持するlist
        /// </summary>
        public List<UnSportsmanLikeFaul> UnSportsmanLikeFaul { get; set; }

        /// <summary>
        /// テクニカルファールを保持するlist
        /// </summary>
        public List<TechnicalFaul> TechnicalFaul { get; set; }

        /// <summary>
        /// ディスクォリファイングファールを保持するlist
        /// </summary>
        public List<DisQualifyingFaul> DisQualifyingFaul { get; set; }


        /********************************************************************************************/


        /********************************** Delegate ************************************************/

        /// <summary>
        /// 引数のアクションがほしかったらtrueを返すようなデリゲート
        /// </summary>
        /// <param name="action">Listから列挙されるアクション</param>
        /// <returns>引数のアクションがほしい:true いらない:false</returns>
        public delegate bool GetActionListDelegate(ActionBase action);

        /********************************************************************************************/

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Player()
        {
            Init();
        }

        /// <summary>
        /// 名前と背番号を代入
        /// </summary>
        /// <param name="name"></param>
        /// <param name="number"></param>
        public Player(string name, int number)
        {
            Init();
            this.Name = name;
            this.Number = number;
        }

        /// <summary>
        /// 名前と背番号を表示
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {

            string s1;

            if (this.Number < 10)
                s1 = "0" + this.Number;
            else
                s1 = this.Number.ToString();

            string s = s1 + " : " + this.Name;

            return s;
        }

        /// <summary>
        /// 初期化用メソッド
        /// </summary>
        private void Init()
        {
            Shoot2P = new List<Shoot2P>();
            Shoot3P = new List<Shoot3P>();
            FreeThrow = new List<FreeThrow>();
            Assist = new List<Assist>();
            PersonalFaul = new List<PersonalFaul>();
            TurnOver = new List<TurnOver>();
            Steal = new List<Steal>();
            ShootBlock = new List<ShootBlock>();
            Shoot2PMiss = new List<Shoot2PMiss>();
            Shoot3PMiss = new List<Shoot3PMiss>();
            FreeThrowMiss = new List<FreeThrowMiss>();
            TechnicalFaul = new List<TechnicalFaul>();
            UnSportsmanLikeFaul = new List<UnSportsmanLikeFaul>();
            DisQualifyingFaul = new List<DisQualifyingFaul>();
        }

        /********************ここ以下IConvertibleのabstractメソッド**********************************/

        public TypeCode GetTypeCode()
        {
            return TypeCode.Object;
        }

        public bool ToBoolean(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public byte ToByte(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public char ToChar(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public DateTime ToDateTime(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public decimal ToDecimal(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public double ToDouble(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public short ToInt16(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public int ToInt32(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public long ToInt64(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public sbyte ToSByte(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public float ToSingle(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public string ToString(IFormatProvider provider)
        {
            return this.ToString();
        }

        public object ToType(Type conversionType, IFormatProvider provider)
        {
            if (conversionType == typeof(Player))
            {
                return this;
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public ushort ToUInt16(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public uint ToUInt32(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public ulong ToUInt64(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        /************************************IConvertibleのabstractメソッド終了**********************************/

        /// <summary>
        /// アクションを時系列(残り時間の多い)順のlistにして返す
        /// </summary>
        /// <returns>Action型のlist</returns>
        public List<object> GetActionList(Player player)
        {
            List<object> actionList = new List<object>();

            //PlayerクラスのTypeオブジェクトを取得する
            Type type = typeof(Player);

            //プロパティを取得する
            PropertyInfo[] properties = type.GetProperties();

            foreach (var pi in properties)
            {
                if (!pi.PropertyType.IsGenericType) continue;

                object obj = GetActionProperty(player, pi.Name);

                if (obj != null)
                {
                    foreach (var o in (IList)obj)
                    {
                        actionList.Add(o);
                    }

                }
            }

            //linqクエリー式 actionListを絶対時間によって昇順ソート命令
            var query = from p in actionList
                        orderby ((ActionBase)p).ActionDate.Ticks
                        select p;

            List<object> rt = query.ToList<object>();

            return rt;
        }


        /// <summary>
        /// 条件を指定したActionListの取得
        /// </summary>
        /// <param name="dl">{PlayerTypeInstance}.GetActionListDelegateに一致するようなデリゲート</param>
        /// <returns>ActionList</returns>
        public List<object> GetActionList(Player player, GetActionListDelegate dl)
        {
            List<object> actionList = GetActionList(player);

            actionList.RemoveAll(a => !(dl((ActionBase)a)));

            return actionList;
        }
        
        /// <summary>
        /// 指定のクォーターに行われたアクションを時系列(残り時間の多い)順のlistにして返す
        /// </summary>
        /// <param name="quarter">クォーター</param>
        /// <returns>Action型のlist</returns>
        public List<object> GetActionList(Player player, int quarter)
        {
            List<object> actionList = new List<object>();

            actionList = this.GetActionList(player, a => a.Quarter == quarter);

            return actionList;
        }

        /// <summary>
        /// 指定されたクォーターの中で残り時間が条件に一致するものだけを返す
        /// </summary>
        /// <param name="quarter">クォーター</param>
        /// <param name="minutes1">時間1</param>
        /// <param name="minutes2">時間2</param>
        /// <returns></returns>
        public List<object> GetActionList(Player player, int quarter, int minutes1, int minutes2)
        {
            List<object> actionList = this.GetActionList(player, quarter);

            if(minutes1 > minutes2){
                int temp = minutes1;
                minutes1 = minutes2;
                minutes2 = temp;
            }

            actionList.RemoveAll(a => !(((ActionBase)a).RemainingTime.Minutes >= minutes1 && ((ActionBase)a).RemainingTime.Minutes < minutes2));

            return actionList;
        }

        /// <summary>
        /// 指定されたクォーターの中で残り時間,アクション名が条件に一致するものだけを返す
        /// </summary>
        /// <param name="actionName">アクション名</param>
        /// <param name="quarter">クォーター</param>
        /// <param name="minutes1">時間1</param>
        /// <param name="minutes2">時間2</param>
        /// <returns></returns>
        public List<object> GetActionList(Player player, string actionName, int quarter, int minutes1, int minutes2)
        {
            if (minutes1 > minutes2)
            {
                int temp = minutes1;
                minutes1 = minutes2;
                minutes2 = temp;
            }

            List<object> actionList = this.GetActionList(player, quarter, minutes1, minutes2);

            actionList.RemoveAll(a => !(((ActionBase)a).ActionName == actionName));

            return actionList;
        }

        /// <summary>
        /// 指定された名前のアクションを保持するプロパティを返す
        /// </summary>
        /// <param name="p"></param>
        /// <param name="propName"></param>
        /// <returns></returns>
        public object GetActionProperty(Player p, string propName)
        {
            try
            {
                Type type = typeof(Player);
                PropertyInfo myPropInfo = type.GetProperty(propName);

                if (myPropInfo == null) return null;

                object obj = myPropInfo.GetValue(p, null);

                if (typeof(List<>).IsAssignableFrom(obj.GetType().GetGenericTypeDefinition()))
                {
                    Type elementType = obj.GetType().GetGenericArguments()[0];
                 
                    if (typeof(ActionBase).IsAssignableFrom(obj.GetType().GetGenericArguments()[0]))
                    {
                        return obj;
                    }

                }

                return null;
                
            }
            catch (Exception exc)
            {
                BMErrorLibrary.BMError.ErrorMessageOutput(exc.Message, true);
                return null;
            }
        }

        public void SetActionProperty(Player p, string propName, object obj)
        {
            try
            {
                Type type = typeof(Player);
                PropertyInfo myPropInfo = type.GetProperty(propName);

                if (myPropInfo == null) return;

                object o = myPropInfo.GetValue(p, null);

                if (typeof(List<>).IsAssignableFrom(o.GetType().GetGenericTypeDefinition()))
                {
                    Type elementType = o.GetType().GetGenericArguments()[0];

                    if (typeof(ActionBase).IsAssignableFrom(o.GetType().GetGenericArguments()[0]))
                    {
                        myPropInfo.SetValue(p, obj, null);
                    }

                }

                return;

            }
            catch (Exception exc)
            {
                BMErrorLibrary.BMError.ErrorMessageOutput(exc.Message, true);
                return;
            }
        }

        /// <summary>
        /// ActionListの名前を全て取得する
        /// </summary>
        /// <returns></returns>
        public static List<string> GetAllActionName()
        {
            List<string> l = new List<string>();

            //PlayerクラスのTypeオブジェクトを取得する
            Type type = typeof(Player);

            //プロパティを取得する
            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo pi in properties)
            {
                if (!pi.PropertyType.IsGenericType) continue;

                try
                {
                    
                    if (typeof(List<>).IsAssignableFrom(pi.PropertyType.GetGenericTypeDefinition()))
                    {
                        Type elementType = pi.PropertyType.GetGenericArguments()[0];

                        if (typeof(ActionBase).IsAssignableFrom(elementType))
                        {
                            l.Add(pi.Name);
                        }
                    }
                }
                catch(Exception exc)
                {
                    BMErrorLibrary.BMError.ErrorMessageOutput(exc.Message, true);
                    return null;
                }
            }

            return l;

        }

        //playerのインスタンス同士の比較用
        public override bool Equals(object obj)
        {
            //objがnullか、型が違うときは、等価でない
            if (obj == null || this.GetType() != obj.GetType())
            {
                return false;
            }

            Player p = (Player)obj;

            //名前と背番号が同じなら一致
            return ((this.Name == p.Name) && (this.Number == p.Number));
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        
    }
}
