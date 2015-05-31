using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using BMErrorLibrary;
using BasketballManagementSystem.BaseClass.Settings;

namespace BasketballManagementSystem.BaseClass.ActionPoint
{
    /// <summary>
    /// ActionPointの重みを定義しているクラス
    /// </summary>
    [Serializable]
    public class ActionPointProvider
    {
        /// <summary>
        /// このクラスのインスタンス
        /// </summary>
        private static ActionPointProvider instance;


        //以下はそれぞれのアクションごとの傾向点を表します
        //プロパティ名は"AP + [アクション名]"で構成され、これ以外の形にはできません
        //(GetActionPointやSetActionPoint等で構文判定しているため) 

        public int APAssist { get; set; }

        public int APDisQualifyingFaul { get; set; }

        public int APFreeThrow { get; set; }

        public int APFreeThrowMiss { get; set; }

        public int APPersonalFaul { get; set; }

        public int APShoot2P { get; set; }

        public int APShoot2PMiss { get; set; }

        public int APShoot3P { get; set; }

        public int APShoot3PMiss { get; set; }

        public int APShootBlock { get; set; }

        public int APSteal { get; set; }

        public int APTechnicalFaul { get; set; }

        public int APTurnOver { get; set; }

        public int APUnSportsmanLikeFaul { get; set; }

        public int APOther { get; set; }



        private ActionPointProvider() 
        {
            
        }

        /// <summary>
        /// ActionPointProviderのインスタンスを取得
        /// </summary>
        /// <returns>ActionPointProviderのインスタンス</returns>
        public static ActionPointProvider GetInstance()
        {
            if (instance == null)
                instance = new ActionPointProvider();
            
            return instance;
        }

        /// <summary>
        /// 指定されたアクションの名前に紐付けられた傾向点を取得します
        /// </summary>
        /// <param name="actionName">アクション名</param>
        /// <returns>取得成功=傾向点　設定されていない=APOtherの値　致命的なエラー=-1</returns>
        public int GetActionPoint(string actionName)
        {
            //PlayerクラスのTypeオブジェクトを取得する
            Type type = typeof(ActionPointProvider);

            //プロパティを取得する
            PropertyInfo[] properties = type.GetProperties();

            foreach (var pi in properties)
            {
                if (pi.PropertyType != typeof(int)) continue;

                if (!pi.Name.Contains("AP")) continue;

                if (pi.Name == "AP" + actionName)
                {
                    object obj = pi.GetValue(AppSetting.GetInstance().ActionPointProvider, null);

                    int rt = 0;

                    try
                    {
                        rt = (int)obj;
                    }
                    catch(Exception exc)
                    {
                        BMError.ErrorMessageOutput(exc.Message, true);
                        return -1;
                    }

                    return rt;
                }
            }

            return APOther;
        }

        /// <summary>
        /// 指定された名前のアクションに紐付けられている傾向点変数に引数の値を割り当てます
        /// </summary>
        /// <param name="actionName">アクション名</param>
        /// <param name="value">傾向点</param>
        public void SetActionPoint(string actionName, int value)
        {
            //PlayerクラスのTypeオブジェクトを取得する
            Type type = typeof(ActionPointProvider);

            //プロパティを取得する
            PropertyInfo[] properties = type.GetProperties();

            foreach (var pi in properties)
            {
                if (pi.PropertyType != typeof(int)) continue;

                if (!pi.Name.Contains("AP")) continue;

                if (pi.Name == "AP" + actionName)
                {
                    try
                    {
                        pi.SetValue(AppSetting.GetInstance().ActionPointProvider, value);
                    }
                    catch (Exception exc)
                    {
                        BMError.ErrorMessageOutput(exc.Message, true);
                        return;
                    }

                }
            }
            
        }

        /// <summary>
        /// 傾向点の設定を初期化します
        /// </summary>
        public void SetDefault()
        {
            APAssist = 3;
            APShootBlock = 2;
            APSteal = 2;
            APTurnOver = 1;

            APPersonalFaul = 1;
            APUnSportsmanLikeFaul = 3;
            APTechnicalFaul = 5;
            APDisQualifyingFaul = 10;

            APFreeThrow = 1;
            APShoot2P = 2;
            APShoot3P = 3;

            APFreeThrowMiss = 3;
            APShoot2PMiss = 2;
            APShoot3PMiss = 1;

            APOther = 0;
        }
    }
}
