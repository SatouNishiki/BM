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
                int _point = 0;

                if(Shoot2P.Count > 0)
                _point += Shoot2P[0].point * Shoot2P.Count;

                if(Shoot3P.Count > 0)
                _point += Shoot3P[0].point * Shoot3P.Count;

                if(FreeThrow.Count > 0)
                _point += FreeThrow[0].point * FreeThrow.Count;


                return _point;
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
        public delegate bool GetActionListDelegate(Action.Action action);

        public delegate bool GetPointActionListDelegate(RelationPointAction action);

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

            string _s1;

            if (this.Number < 10)
                _s1 = "0" + this.Number;
            else
                _s1 = this.Number.ToString();

            string _s = _s1 + " : " + this.Name;

            return _s;
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
        public List<Action.Action> GetActionList(Player player)
        {
            List<Action.Action> _actionList = new List<Action.Action>();

            //PlayerクラスのTypeオブジェクトを取得する
            Type _t = typeof(Player);

            //プロパティを取得する
            PropertyInfo[] _pi = _t.GetProperties();

            foreach (PropertyInfo _p in _pi)
            {
                if (!_p.PropertyType.IsGenericType) continue;

                object _obj = GetActionProperty(player, _p.Name);

                if (_obj != null)
                {
                    foreach (object _o in (IList)_obj)
                    {
                        _actionList.Add((Action.Action)_o);
                    }

                }
            }

            //linqクエリー式 actionListを絶対時間によって昇順ソート命令
            var query = from p in _actionList
                        orderby p.ActionDate.Ticks
                        select p;

            List<Action.Action> rt = query.ToList<Action.Action>();

            return rt;
        }


        /// <summary>
        /// 条件を指定したActionListの取得
        /// </summary>
        /// <param name="dl">{PlayerTypeInstance}.GetActionListDelegateに一致するようなデリゲート</param>
        /// <returns>ActionList</returns>
        public List<Action.Action> GetActionList(Player player, GetActionListDelegate dl)
        {
            List<Action.Action> _actionList = GetActionList(player);

            _actionList.RemoveAll(a => !(dl(a)));
            return _actionList;
        }
        
        /// <summary>
        /// 指定のクォーターに行われたアクションを時系列(残り時間の多い)順のlistにして返す
        /// </summary>
        /// <param name="quarter">クォーター(1-4)</param>
        /// <param name="extend">延長を含めたリストを返すかどうか</param>
        /// <returns>Action型のlist</returns>
        public List<Action.Action> GetActionList(Player player, int quarter, bool extend)
        {
            List<Action.Action> _actionList = new List<Action.Action>();

            _actionList = this.GetActionList(player);

            if (extend)
            {
                if (quarter < 4)
                {
                    _actionList.RemoveAll(a => a.Quarter != quarter);
                }
                else
                {
                    _actionList.RemoveAll(a => a.Quarter < quarter);
                }

            }
            else
            {
                _actionList.RemoveAll(a => a.Quarter != quarter);
            }
            return _actionList;
        }

        /// <summary>
        /// 指定されたクォーターの中で残り時間が条件に一致するものだけを返す
        /// </summary>
        /// <param name="quarter">クォーター</param>
        /// <param name="minutes1">時間1</param>
        /// <param name="minutes2">時間2</param>
        /// <returns></returns>
        public List<Action.Action> GetActionList(Player player, int quarter, int minutes1, int minutes2, bool extend)
        {
            List<Action.Action> _l = this.GetActionList(player, quarter, extend);

            if(minutes1 > minutes2){
                int temp = minutes1;
                minutes1 = minutes2;
                minutes2 = temp;
            }

            _l.RemoveAll(a => !(a.RemainingTime.Minutes >= minutes1 && a.RemainingTime.Minutes < minutes2));

            return _l;
        }

        /// <summary>
        /// 指定されたクォーターの中で残り時間,アクション名が条件に一致するものだけを返す
        /// </summary>
        /// <param name="actionName">アクション名</param>
        /// <param name="quarter">クォーター</param>
        /// <param name="minutes1">時間1</param>
        /// <param name="minutes2">時間2</param>
        /// <returns></returns>
        public List<Action.Action> GetActionList(Player player, string actionName, int quarter, int minutes1, int minutes2, bool extend)
        {
            if (minutes1 > minutes2)
            {
                int temp = minutes1;
                minutes1 = minutes2;
                minutes2 = temp;
            }

            List<Action.Action> _l = this.GetActionList(player, quarter, minutes1, minutes2, extend);

            _l.RemoveAll(a => !(a.ActionName == actionName));

            return _l;
        }

        /// <summary>
        /// 指定のクォーターに行われた点数に関係するアクションを時系列(残り時間の多い)順のlistにして返す
        /// </summary>
        /// <param name="quarter">クォーター(1-4)</param>
        /// <returns>RelationPointAction型のlist</returns>
        public List<RelationPointAction> GetPointActionList(int quarter, bool extend)
        {
            List<RelationPointAction> _actionList = new List<RelationPointAction>();

            _actionList = this.GetPointActionList();
            if (extend)
            {

                if (quarter < 4)
                {
                    _actionList.RemoveAll(a => a.Quarter != quarter);
                }
                else
                {

                    _actionList.RemoveAll(a => a.Quarter < quarter);
                }
            }
            else
            {
                _actionList.RemoveAll(a => a.Quarter != quarter);
            }
     
            return _actionList;

        }

        /// <summary>
        /// 点数に関係するアクションを時系列(残り時間の多い)順のlistにして返す
        /// </summary>
        /// <returns>RelationPointAction型のlist</returns>
        public List<RelationPointAction> GetPointActionList()
        {
            List<RelationPointAction> _actionList = new List<RelationPointAction>();


            foreach (RelationPointAction a in FreeThrow)
            {
                _actionList.Add(a);
            }
            foreach (RelationPointAction a in Shoot2PMiss)
            {
                _actionList.Add(a);
            }
            foreach (RelationPointAction a in Shoot3PMiss)
            {
                 _actionList.Add(a); 
            }
            foreach (RelationPointAction a in FreeThrowMiss)
            {
               _actionList.Add(a); 
            }

            foreach (RelationPointAction a in Shoot3P)
            {
                _actionList.Add(a);
            }
            foreach (RelationPointAction a in Shoot2P)
            {
                _actionList.Add(a);
            }

            //linqクエリー式 actionListを絶対時間によって昇順ソート命令
            var query = from p in _actionList
                        orderby p.ActionDate.Ticks
                        select p;

            List<RelationPointAction> rt = query.ToList<RelationPointAction>();

            return rt;
        }

        public List<RelationPointAction> GetPointActionList(bool b)
        {
            if (b)
            {
                return GetPointActionList();
            }
            else
            {
                List<RelationPointAction> _actionList = new List<RelationPointAction>();


                foreach (RelationPointAction a in FreeThrow)
                {
                    _actionList.Add(a);
                }

                foreach (RelationPointAction a in Shoot3P)
                {
                    _actionList.Add(a);
                }
                foreach (RelationPointAction a in Shoot2P)
                {
                    _actionList.Add(a);
                }

                //linqクエリー式 actionListを絶対時間によって昇順ソート命令
                var query = from p in _actionList
                            orderby p.ActionDate.Ticks
                            select p;

                List<RelationPointAction> rt = query.ToList<RelationPointAction>();

                return rt;
            }
        }

        public List<RelationPointAction> GetPointActionList(GetPointActionListDelegate dl)
        {
            List<RelationPointAction> _l = GetPointActionList();

            _l.RemoveAll(a => !dl(a));

            return _l;
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
                Type _type = typeof(Player);
                PropertyInfo _myPropInfo = _type.GetProperty(propName);

                if (_myPropInfo == null) return null;

                object _o = _myPropInfo.GetValue(p, null);

                if (typeof(List<>).IsAssignableFrom(_o.GetType().GetGenericTypeDefinition()))
                {
                    Type _elementType = _o.GetType().GetGenericArguments()[0];
                 
                    if (typeof(Action.Action).IsAssignableFrom(_o.GetType().GetGenericArguments()[0]))
                    {
                        return _o;
                    }

                }

                return null;
                
            }
            catch (Exception exc)
            {
                BMErrorLibrary.BMError.ErrorMessageOutput(exc.Message);
                return null;
            }
        }

        public void SetActionProperty(Player p, string propName, object obj)
        {
            try
            {
                Type _type = typeof(Player);
                PropertyInfo _myPropInfo = _type.GetProperty(propName);

                if (_myPropInfo == null) return;

                object _o = _myPropInfo.GetValue(p, null);

                if (typeof(List<>).IsAssignableFrom(_o.GetType().GetGenericTypeDefinition()))
                {
                    Type _elementType = _o.GetType().GetGenericArguments()[0];

                    if (typeof(Action.Action).IsAssignableFrom(_o.GetType().GetGenericArguments()[0]))
                    {
                        _myPropInfo.SetValue(p, obj, null);
                    }

                }

                return;

            }
            catch (Exception exc)
            {
                BMErrorLibrary.BMError.ErrorMessageOutput(exc.Message);
                return;
            }
        }

        /// <summary>
        /// ActionListの名前を全て取得する
        /// </summary>
        /// <returns></returns>
        public static List<string> GetAllActionName()
        {
            List<string> _l = new List<string>();

            //PlayerクラスのTypeオブジェクトを取得する
            Type _t = typeof(Player);

            //プロパティを取得する
            PropertyInfo[] _pi = _t.GetProperties();

            foreach (PropertyInfo _p in _pi)
            {
                if (!_p.PropertyType.IsGenericType) continue;

                try
                {
                    
                    if (typeof(List<>).IsAssignableFrom(_p.PropertyType.GetGenericTypeDefinition()))
                    {
                        Type _elementType = _p.PropertyType.GetGenericArguments()[0];

                        if (typeof(Action.Action).IsAssignableFrom(_elementType))
                        {
                            _l.Add(_p.Name);
                        }
                    }
                }
                catch(Exception exc)
                {
                    BMErrorLibrary.BMError.ErrorMessageOutput(exc.Message);
                    return null;
                }
            }

            return _l;

        }

        //playerのインスタンス同士の比較用
        public override bool Equals(object obj)
        {
            //objがnullか、型が違うときは、等価でない
            if (obj == null || this.GetType() != obj.GetType())
            {
                return false;
            }

            Player _p = (Player)obj;

            //名前と背番号が同じなら一致
            return ((this.Name == _p.Name) && (this.Number == _p.Number));
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        
    }
}
