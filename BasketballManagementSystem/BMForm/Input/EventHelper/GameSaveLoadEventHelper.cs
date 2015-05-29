using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BMErrorLibrary;
using System.Xml.Serialization;
using BasketballManagementSystem.BaseClass.Game;
using System.IO;
using BMFileLibrary;

namespace BasketballManagementSystem.BMForm.Input.EventHelper
{
    public class GameSaveLoadEvent
    {
        private const string defaultFileName = "Game1";

        public void GameSave(Game game)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            //はじめのファイル名を指定する
            sfd.FileName = defaultFileName;

            //はじめに表示されるフォルダを指定する
            sfd.InitialDirectory = BMFile.CreateDirectory("Save\\GameData");

            //[ファイルの種類]に表示される選択肢を指定する
            sfd.Filter =
                "Xmlファイル(*.xml)|*.xml|xmlファイル(*.xml)|*.xml";

            sfd.Title = "保存先のファイルを選択してください";

            //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
            sfd.RestoreDirectory = true;

            //ダイアログを表示する
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                System.IO.Stream stream;
                stream = sfd.OpenFile();

                if (stream != null)
                {

                    XmlSerializer s = new XmlSerializer(typeof(Game));

                    s.Serialize(stream, game);

                    stream.Close();
                }
                else
                {
                    BMError.ErrorMessageOutput("stream is null !!");
                }
            }
        }

        public Game GameLoad()
        {
            //OpenFileDialogクラスのインスタンスを作成
            OpenFileDialog ofd = new OpenFileDialog();

            //はじめのファイル名を指定する
            //はじめに「ファイル名」で表示される文字列を指定する
            ofd.FileName = "Game1.xml";

            //はじめに表示されるフォルダを指定する
            //指定しない（空の文字列）の時は、現在のディレクトリが表示される
            ofd.InitialDirectory = BMFile.CreateDirectory("Save\\GameData");

            //[ファイルの種類]に表示される選択肢を指定する
            //指定しないとすべてのファイルが表示される
            ofd.Filter =
                "Xmlファイル(*.xml)|*.xml|xmlファイル(*.xml)|*.xml";
        
            //タイトルを設定する
            ofd.Title = "開くファイルを選択してください";

            //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
            ofd.RestoreDirectory = true;

            Game loadInstance = new Game();

            //ダイアログを表示する
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                System.IO.Stream stream;
                stream = ofd.OpenFile();

                if (stream != null)
                {

                    XmlSerializer s = new XmlSerializer(typeof(Game));

                    loadInstance = (Game)s.Deserialize(stream);

                    stream.Close();
                }
                else
                {
                    BMError.ErrorMessageOutput("stream is null !!");
                }
            }
            else
            {
                return null;
            }

            return loadInstance;
        }
    }
}
