using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BasketballManagementSystem.Manager.TeamManager;
using BasketballManagementSystem.BaseClass.Player;
using BMErrorLibrary;
using BMFileLibrary;
using System.IO;
using BasketballManagementSystem.BaseClass.Club;
using System.Xml.Serialization;

namespace BasketballManagementSystem.BMForm.TeamMake
{
    public partial class TeamDataEdit : Form
    {
        private TeamManager teamManager = TeamManager.getInstance();

        private Player selectedPlayer = new Player("No Name", 0);

        public TeamDataEdit()
        {
            InitializeComponent();
            comboBoxPosition.SelectedIndex = 0;
        }

        private void loadTeam_Click(object sender, EventArgs e)
        {
            //OpenFileDialogクラスのインスタンスを作成
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = BMFile.FindDirectory("TeamData");

            Team t;

            //ダイアログを表示する
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //OKボタンがクリックされたとき
                //選択されたファイルを読み取り専用で開く
                System.IO.Stream stream;
                stream = ofd.OpenFile();

                if (stream != null)
                {
                    //指定したファイルからチーム情報取得
                    t = teamManager.loadTeam(ofd.FileName, true);

                    listBoxCortMember.Items.Clear();
                    listBoxOutMember.Items.Clear();

                    foreach (Player p in t.CortMember)
                    {
                        listBoxCortMember.Items.Add(p);
                    }

                    foreach (Player p in t.OutMember)
                    {
                        listBoxOutMember.Items.Add(p);
                    }

                    textBoxTeamName.Text = t.Name;

                }
                else
                {
                    BMError.ErrorMessageOutput("stream is null");
                }
            }
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ListBox)sender).SelectedItem != null)
            {
                selectedPlayer = (Player)((ListBox)sender).SelectedItem;

                textBoxEditName.Text = selectedPlayer.Name;
                textBoxEditNumber.Text = selectedPlayer.Number.ToString();
                labelSelectedPlayer.Text = selectedPlayer.ToString();
            }
            else
            {
                selectedPlayer = new Player("No Name", 0);
                labelSelectedPlayer.Text = selectedPlayer.ToString();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("選択されている選手を削除しますか？",
            "確認",
            MessageBoxButtons.OKCancel,
            MessageBoxIcon.Exclamation,
            MessageBoxDefaultButton.Button2);

            if (result == DialogResult.OK)
            {

                foreach (Player p in listBoxCortMember.Items)
                {
                    if (p == selectedPlayer)
                    {
                        listBoxCortMember.Items.Remove(p);
                        selectedPlayer = new Player("No Name", 0);
                        textBoxEditName.Text = selectedPlayer.Name;
                        textBoxEditNumber.Text = selectedPlayer.Number.ToString();
                        MessageBox.Show("削除しました");
                        return;
                    }
                }

                foreach (Player p in listBoxOutMember.Items)
                {
                    if (p == selectedPlayer)
                    {
                        listBoxOutMember.Items.Remove(p);
                        selectedPlayer = new Player("No Name", 0);
                        textBoxEditName.Text = selectedPlayer.Name;
                        textBoxEditNumber.Text = selectedPlayer.Number.ToString();
                        MessageBox.Show("削除しました");
                        return;
                    }
                }

                MessageBox.Show("削除に失敗しました");

            }

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            int number = 0;

            if (!int.TryParse(textBoxNumber.Text, out number))
            {
                MessageBox.Show("背番号が不正です");
                return;
            }

            Player p = new Player(textBoxName.Text, number);

            if (comboBoxPosition.SelectedIndex == 0)
            {
                listBoxCortMember.Items.Add(p);
            }
            else
            {
                listBoxOutMember.Items.Add(p);
            }
        }

        private void saveTeam_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            //はじめのファイル名を指定する
            sfd.FileName = textBoxTeamName.Text + ".txt";

            //はじめに表示されるフォルダを指定する
            sfd.InitialDirectory = BMFile.CreateDirectory("TeamData");

            //[ファイルの種類]に表示される選択肢を指定する
            sfd.Filter =
                "テキストファイル(*.txt)|*.txt|テキストファイル(*.txt)|*.txt";

            //タイトルを設定する
            sfd.Title = "保存先のファイルを選択してください";

            //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
            sfd.RestoreDirectory = true;

            //ダイアログを表示する
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Stream stream;
                stream = sfd.OpenFile();

                if (stream != null)
                {
                    Encoding ecd = Encoding.UTF8;
                    StreamWriter sw = new StreamWriter(stream, ecd);

                    sw.Write(CreateTextFile());
                    
                    sw.Close();
                    stream.Close();
                }
                else
                {
                    BMError.ErrorMessageOutput("stream is null !!");
                }
            }
        }

        private string CreateTextFile()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("[TeamName]");
            sb.AppendLine(textBoxTeamName.Text);
            sb.AppendLine("[/TeamName]");


            sb.AppendLine("[CortMember]");

            foreach (Player p in listBoxCortMember.Items)
            {
                sb.AppendLine(p.Name);
                sb.AppendLine(p.Number.ToString());
            }

            sb.AppendLine("[/CortMember]");

            sb.AppendLine("[OutMember]");
            foreach (Player p in listBoxOutMember.Items)
            {
                sb.AppendLine(p.Name);
                sb.AppendLine(p.Number.ToString());
            }
            sb.AppendLine("[/OutMember]");

            return sb.ToString();
        }

        private void loadClub_Click(object sender, EventArgs e)
        {
            OpenFileDialog _ofd = new OpenFileDialog();

            //はじめのファイル名を指定する
            _ofd.FileName = "ClubTeam1.xml";

            //はじめに表示されるフォルダを指定する
            _ofd.InitialDirectory = BMFile.CreateDirectory("Save\\ClubData");

            //[ファイルの種類]に表示される選択肢を指定する
            _ofd.Filter =
                "Xmlファイル(*.xml)|*.xml|xmlファイル(*.xml)|*.xml";

            _ofd.Title = "開くファイルを選択してください";

            //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
            _ofd.RestoreDirectory = true;

            //ダイアログを表示する
            if (_ofd.ShowDialog() == DialogResult.OK)
            {
                System.IO.Stream _stream;
                _stream = _ofd.OpenFile();

                if (_stream != null)
                {

                    XmlSerializer _s = new XmlSerializer(typeof(ClubTeam));

                    ClubTeam _clubTeam = new ClubTeam();

                    _clubTeam = (ClubTeam)_s.Deserialize(_stream);

                    ClubNameLabel.Text = _clubTeam.Name;

                    ClubMembersList.Items.Clear();

                    foreach (ClubMember _clubMember in _clubTeam.ClubMemberList)
                    {
                        ClubMembersList.Items.Add(_clubMember);
                    }

                    _stream.Close();
                }
                else
                {
                    BMError.ErrorMessageOutput("stream is null !!");
                }
            }
        }

        private void IntoCortMemberButton_Click(object sender, EventArgs e)
        {
            if (ClubMembersList.SelectedItem == null)
            {
                MessageBox.Show("メンバーが選択されていません");
                return;
            }
           
            string _s = Microsoft.VisualBasic.Interaction.InputBox(
                ClubMembersList.SelectedItem.ToString() + "の背番号を入力してください",
                "入力画面",
                "",
                200,
                100);

            int _number = 0;

            if (!int.TryParse(_s, out _number))
            {
                MessageBox.Show("値が不正です");
                return;
            }
            else
            {
                string _name = ((ClubMember)ClubMembersList.SelectedItem).Name;

                listBoxCortMember.Items.Add(new Player(_name, _number));
            }

            
        }

        private void IntoOutMemberButton_Click(object sender, EventArgs e)
        {
            if (ClubMembersList.SelectedItem == null)
            {
                MessageBox.Show("メンバーが選択されていません");
                return;
            }

            string _s = Microsoft.VisualBasic.Interaction.InputBox(
                ClubMembersList.SelectedItem.ToString() + "の背番号を入力してください",
                "入力画面",
                "",
                200,
                100);

            int _number = 0;

            if (!int.TryParse(_s, out _number))
            {
                MessageBox.Show("値が不正です");
                return;
            }
            else
            {
                string _name = ((ClubMember)ClubMembersList.SelectedItem).Name;

                listBoxOutMember.Items.Add(new Player(_name, _number));
            }
        }

        private void buttonDicision_Click(object sender, EventArgs e)
        {

            int _number = 0;

            if (!int.TryParse(textBoxEditNumber.Text, out _number))
            {
                MessageBox.Show("値が不正です");
                return;
            }

            int _index = listBoxCortMember.Items.IndexOf(selectedPlayer);

            if (_index >= 0)
            {
                Player _p = new Player(textBoxEditName.Text, _number);

                listBoxCortMember.Items.Insert(_index, _p);

                listBoxCortMember.Items.Remove(selectedPlayer);
            }
            else
            {
                _index = listBoxOutMember.Items.IndexOf(selectedPlayer);

                if (_index < 0)
                {
                    MessageBox.Show("選択選手が見つかりませんでした");
                    return;
                }

                Player _p = new Player(textBoxEditName.Text, _number);

                listBoxOutMember.Items.Insert(_index, _p);

                listBoxOutMember.Items.Remove(selectedPlayer);
            }
        }
    }
}
