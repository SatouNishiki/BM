using System;
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
using BasketballManagementSystem.BaseClass.ActionPoint;
using System.Windows.Forms;

namespace BasketballManagementSystem.BaseClass.Settings
{
    /// <summary>
    /// アプリケーションの設定を保存するクラス
    /// App.configを使ってもいいが自作クラスを保存しようと思ったり階層構造にしようと思ったりすると微妙な書き方を要求される
    /// 自作で実装する場合元のコードにシリアライズ不能な型の変換処理(例:Color→string)を書かなくてよく、
    /// また、生成されたxmlファイルもごちゃごちゃしなくて見やすい
    /// </summary>
    public class AppSetting
    {

        [XmlIgnore]
        public Color FormInputBackGroundColor { get; set; }
        [XmlIgnore]
        public Color FormInputPointBackGroundColor { get; set; }
        [XmlIgnore]
        public Color FormInputButtonColor { get; set; }
        [XmlIgnore]
        public Color FormInputButtonTextColor { get; set; }

        public string Culture { get; set; }

        public int CultureSelectedIndex { get; set; }

        public int UDPSendInterval { get; set; }

        public int FormInputFPS { get; set; }

        public bool DebugWindowChecked { get; set; }

        public ActionPointProvider ActionPointProvider { get; set; }

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

        [XmlAttribute("FormInputPointBackGroundColor")]
        public string FormInputPointBackGroundColorAsRGB
        {
            get { return ColorTranslator.ToHtml(FormInputPointBackGroundColor); }
            set { FormInputPointBackGroundColor = ColorTranslator.FromHtml(value); }
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

        private static AppSetting instance;

        private AppSetting()
        {
            ActionPointProvider = ActionPointProvider.GetInstance();
            CultureSelectedIndex = 1;
        }

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

        public void SettingChanged()
        {

            string _s = BMFile.CreateDirectory("Save\\Settings") + "\\AppSettings.xml";

            //XmlSerializerオブジェクトを作成
            //オブジェクトの型を指定する
            System.Xml.Serialization.XmlSerializer _serializer =
                new System.Xml.Serialization.XmlSerializer(typeof(AppSetting));
            //書き込むファイルを開く（UTF-8 BOM無し）
            System.IO.StreamWriter _sw = new System.IO.StreamWriter(
                _s, false, new System.Text.UTF8Encoding(false));
            //シリアル化し、XMLファイルに保存する
            AppSetting _a = AppSetting.GetInstance();
            _serializer.Serialize(_sw, _a);
            //ファイルを閉じる
            _sw.Close();
        }

        public bool LoadAppSetting()
        {

            BMFile.CreateDirectory("Save\\Settings");

            //保存元のファイル名
            string _fileName = BMFile.CreateFile("Save\\Settings\\AppSettings.xml");

            bool _rt = true;

            System.IO.StreamReader _sr = null;


            //読み込むファイルを開く
            _sr = new System.IO.StreamReader(
                 _fileName, new System.Text.UTF8Encoding(false));

            //XmlSerializerオブジェクトを作成
            System.Xml.Serialization.XmlSerializer _serializer =
                new System.Xml.Serialization.XmlSerializer(typeof(AppSetting));
            try
            {
                //XMLファイルから読み込み、逆シリアル化する
                AppSetting _obj = (AppSetting)_serializer.Deserialize(_sr);

                instance = _obj;

            }
            catch
            {
                instance = AppSetting.GetInstance();
                _rt = false;
            }
            finally
            {
                if (_sr != null)
                    _sr.Close();
            }

            return _rt;
        }
    }
}
