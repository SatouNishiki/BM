﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using BMFileLibrary;
using BMErrorLibrary;
using System.Xml.XmlConfiguration;
using System.Xml.Serialization;
using System.ComponentModel;
using System.Xml;
using System.Globalization;
using BasketballManagementSystem.baseClass.actionPoint;
using System.Windows.Forms;

namespace BasketballManagementSystem.baseClass.settings
{
    /// <summary>
    /// アプリケーションの設定を保存するクラス
    /// App.configを使ってもいいが自作クラスを保存しようと思ったり階層構造にしようと思ったりすると微妙な書き方を要求される
    /// 自作で実装する場合元のコードにシリアライズ不能な型の変換処理(例:Color→string)を書かなくてよく、
    /// また、生成されたxmlファイルもごちゃごちゃしなくて見やすい
    /// </summary>
    public class AppSetting
    {

        /// <summary>
        /// 入力画面の背景色
        /// </summary>
        [XmlIgnore]
        public Color FormInputBackGroundColor { get; set; }

        /// <summary>
        /// 入力画面のボタンの背景色
        /// </summary>
        [XmlIgnore]
        public Color FormInputButtonColor { get; set; }

        /// <summary>
        /// 入力画面のボタンの文字色
        /// </summary>
        [XmlIgnore]
        public Color FormInputButtonTextColor { get; set; }

        /// <summary>
        /// アプリケーションの言語設定
        /// </summary>
        public string Culture { get; set; }

        /// <summary>
        /// 入力画面の言語設定ComboBoxの選択インデックス
        /// </summary>
        public int CultureSelectedIndex { get; set; }

        /// <summary>
        /// UDPクライアントの送信間隔
        /// </summary>
        public int UDPSendInterval { get; set; }

        /// <summary>
        /// 入力画面のFPS設定
        /// </summary>
        public int FormInputFPS { get; set; }

        /// <summary>
        /// デバックウインドウを表示するかどうか
        /// </summary>
        public bool DebugWindowChecked { get; set; }

        /// <summary>
        /// コメント機能を利用するかどうか
        /// </summary>
        public bool UseCommentChecked { get; set; }

        /// <summary>
        /// ActionPointProvider(行動傾向点の重みを決定するクラス)のインスタンス
        /// </summary>
        public ActionPointProvider ActionPointProvider { get; set; }


        /************************** 以下シリアライズ用変換プロパティ *********************************************/

        [XmlAttribute("FormInputBackGroundColor")]
        public string FormInputBackGroundColorAsRGB
        {
            get {
                return ColorTranslator.ToHtml(FormInputBackGroundColor);
            }
            set {
                FormInputBackGroundColor = ColorTranslator.FromHtml(value);
            }
        }

        [XmlAttribute("FormInputButtonColor")]
        public string FormInputButtonColorAsRGB
        {
            get { return ColorTranslator.ToHtml(FormInputButtonColor); }
            set { FormInputButtonColor = ColorTranslator.FromHtml(value); }
        }

        [XmlAttribute("FormInputButtonTextColor")]
        public string FormInputButtonTextColorAsRGB
        {
            get { return ColorTranslator.ToHtml(FormInputButtonTextColor); }
            set { FormInputButtonTextColor = ColorTranslator.FromHtml(value); }
        }


        /***********************************************************************************************************/

        private static AppSetting instance;

        private AppSetting()
        {
            ActionPointProvider = ActionPointProvider.GetInstance();
        }

        /// <summary>
        /// 初回起動時の初期化用メソッド
        /// </summary>
        private void Init()
        {
            CultureSelectedIndex = 1;
            ActionPointProvider.SetDefault();
        }

        /// <summary>
        /// AppSettingクラスのインスタンスを取得
        /// </summary>
        /// <returns>AppSettingクラスのインスタンス</returns>
        public static AppSetting GetInstance()
        {
            if (instance == null)
            {
                instance = new AppSetting();
              
                instance.LoadAppSetting();
            }

            return instance;
        }

        public void SetInstance(AppSetting a)
        {
            instance = a;
        }

        /// <summary>
        /// 設定を保存するメソッド(通常はアプリケーション終了時に自動的に呼ばれます)
        /// </summary>
        public void SettingChanged()
        {

            string s = BMFile.CreateDirectory("Save\\Settings") + "\\AppSettings.xml";

            //XmlSerializerオブジェクトを作成
            //オブジェクトの型を指定する
            System.Xml.Serialization.XmlSerializer serializer =
                new System.Xml.Serialization.XmlSerializer(typeof(AppSetting));
            //書き込むファイルを開く（UTF-8 BOM無し）
            System.IO.StreamWriter sw = new System.IO.StreamWriter(
                s, false, new System.Text.UTF8Encoding(false));
            //シリアル化し、XMLファイルに保存する
            AppSetting a = AppSetting.GetInstance();
            serializer.Serialize(sw, a);
            //ファイルを閉じる
            sw.Close();
        }

        /// <summary>
        /// 設定を規定のフォルダにある設定ファイルから読み込みます
        /// 読み込みに失敗した場合アプリケーション設定を初期化しfalseの戻り値を返却します
        /// </summary>
        /// <returns>読み込み成功? true : false</returns>
        public bool LoadAppSetting()
        {

            BMFile.CreateDirectory("Save\\Settings");

            //保存元のファイル名
            string fileName = BMFile.CreateFile("Save\\Settings\\AppSettings.xml");

            //戻り値
            bool rt = true;

            System.IO.StreamReader sr = null;


            //読み込むファイルを開く
            sr = new System.IO.StreamReader(
                 fileName, new System.Text.UTF8Encoding(false));

            //XmlSerializerオブジェクトを作成
            System.Xml.Serialization.XmlSerializer _serializer =
                new System.Xml.Serialization.XmlSerializer(typeof(AppSetting));
            try
            {
                //XMLファイルから読み込み、逆シリアル化する
                AppSetting obj = (AppSetting)_serializer.Deserialize(sr);

                instance = obj;

            }
            catch
            {
                //デシリアライズに失敗=ファイルが壊れているか初回起動時
                instance = AppSetting.GetInstance();
                Init();
                rt = false;
            }
            finally
            {
                if (sr != null)
                    sr.Close();
            }

            return rt;
        }
    }
}
