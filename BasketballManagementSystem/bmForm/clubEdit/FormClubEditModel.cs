using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasketballManagementSystem.interfaces;
using BasketballManagementSystem.baseClass.club;
using System.Windows.Forms;
using BMFileLibrary;
using System.Xml.Serialization;
using BMErrorLibrary;

namespace BasketballManagementSystem.bmForm.clubEdit
{
    public class FormClubEditModel : abstracts.AbstractModel
    {

        public List<ClubMember> ClubMembers { get; set; }

        /// <summary>
        /// フォームを閉じれるかどうか
        /// </summary>
        public bool CanFinish { get; set; }

        public FormClubEditModel()
        {
            this.ClubMembers = new List<ClubMember>();
            this.CanFinish = true;
        }
      
        public ClubTeam LoadClubTeam()
        {
             OpenFileDialog ofd = new OpenFileDialog();

            //はじめのファイル名を指定する
            ofd.FileName = "ClubTeam1.xml";

            //はじめに表示されるフォルダを指定する
            ofd.InitialDirectory = BMFile.CreateDirectory("Save\\ClubData");

            //[ファイルの種類]に表示される選択肢を指定する
            ofd.Filter =
                "Xmlファイル(*.xml)|*.xml|xmlファイル(*.xml)|*.xml";

            ofd.Title = "開くファイルを選択してください";

            //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
            ofd.RestoreDirectory = true;

            ClubTeam clubTeam = null;

            //ダイアログを表示する
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                System.IO.Stream stream;
                stream = ofd.OpenFile();

                
                if (stream != null)
                {

                    XmlSerializer s = new XmlSerializer(typeof(ClubTeam));

                    clubTeam = (ClubTeam)s.Deserialize(stream);
                }
                else
                {
                    BMError.ErrorMessageOutput("stream is null !!", true);
                }
            }

            return clubTeam;
        }

        public void SaveClubTeam(ClubTeam team)
        {
             SaveFileDialog sfd = new SaveFileDialog();

            //はじめのファイル名を指定する
            sfd.FileName = team.Name;

            //はじめに表示されるフォルダを指定する
            sfd.InitialDirectory = BMFile.CreateDirectory("Save\\ClubData");

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

                    XmlSerializer s = new XmlSerializer(typeof(ClubTeam));

                    s.Serialize(stream, team);

                    stream.Close();

                }
                else
                {
                    BMError.ErrorMessageOutput("stream is null !!", true);
                }
            }
        }
    }
}
