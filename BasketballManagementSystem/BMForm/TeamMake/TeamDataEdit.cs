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
            PositionComboBox.SelectedIndex = 0;
        }

        private void loadTeam_Click(object sender, EventArgs e)
        {
            //OpenFileDialogクラスのインスタンスを作成
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = BMFile.FindDirectory("TeamData");

            Team team;

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
                    team = teamManager.loadTeam(ofd.FileName, true);

                    CortMemberListBox.Items.Clear();
                    OutMemberListBox.Items.Clear();

                    foreach (var p in team.CortMember)
                    {
                        CortMemberListBox.Items.Add(p);
                    }

                    foreach (var p in team.OutMember)
                    {
                        OutMemberListBox.Items.Add(p);
                    }

                    TeamNameTextBox.Text = team.Name;

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

                EditNameTextBox.Text = selectedPlayer.Name;
                EditNumberTextBox.Text = selectedPlayer.Number.ToString();
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

                foreach (var p in CortMemberListBox.Items)
                {
                    if (p == selectedPlayer)
                    {
                        CortMemberListBox.Items.Remove(p);
                        selectedPlayer = new Player("No Name", 0);
                        EditNameTextBox.Text = selectedPlayer.Name;
                        EditNumberTextBox.Text = selectedPlayer.Number.ToString();
                        MessageBox.Show("削除しました");
                        return;
                    }
                }

                foreach (var p in OutMemberListBox.Items)
                {
                    if (p == selectedPlayer)
                    {
                        OutMemberListBox.Items.Remove(p);
                        selectedPlayer = new Player("No Name", 0);
                        EditNameTextBox.Text = selectedPlayer.Name;
                        EditNumberTextBox.Text = selectedPlayer.Number.ToString();
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

            if (!int.TryParse(NumberTextBox.Text, out number))
            {
                MessageBox.Show("背番号が不正です");
                return;
            }

            Player p = new Player(NameTextBox.Text, number);

            if (PositionComboBox.SelectedIndex == 0)
            {
                CortMemberListBox.Items.Add(p);
            }
            else
            {
                OutMemberListBox.Items.Add(p);
            }
        }

        private void saveTeam_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            //はじめのファイル名を指定する
            sfd.FileName = TeamNameTextBox.Text + ".txt";

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
            sb.AppendLine(TeamNameTextBox.Text);
            sb.AppendLine("[/TeamName]");


            sb.AppendLine("[CortMember]");

            foreach (Player p in CortMemberListBox.Items)
            {
                sb.AppendLine(p.Name);
                sb.AppendLine(p.Number.ToString());
            }

            sb.AppendLine("[/CortMember]");

            sb.AppendLine("[OutMember]");
            foreach (Player p in OutMemberListBox.Items)
            {
                sb.AppendLine(p.Name);
                sb.AppendLine(p.Number.ToString());
            }
            sb.AppendLine("[/OutMember]");

            return sb.ToString();
        }

        private void LoadClub_Click(object sender, EventArgs e)
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

            //ダイアログを表示する
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                System.IO.Stream stream;
                stream = ofd.OpenFile();

                if (stream != null)
                {

                    XmlSerializer s = new XmlSerializer(typeof(ClubTeam));

                    ClubTeam clubTeam = new ClubTeam();

                    clubTeam = (ClubTeam)s.Deserialize(stream);

                    ClubNameLabel.Text = clubTeam.Name;

                    ClubMembersListBox.Items.Clear();

                    foreach (var _clubMember in clubTeam.ClubMemberList)
                    {
                        ClubMembersListBox.Items.Add(_clubMember);
                    }

                    stream.Close();
                }
                else
                {
                    BMError.ErrorMessageOutput("stream is null !!");
                }
            }
        }

        private void IntoCortMemberButton_Click(object sender, EventArgs e)
        {
            if (ClubMembersListBox.SelectedItem == null)
            {
                MessageBox.Show("メンバーが選択されていません");
                return;
            }
           
            string _s = Microsoft.VisualBasic.Interaction.InputBox(
                ClubMembersListBox.SelectedItem.ToString() + "の背番号を入力してください",
                "入力画面",
                "",
                200,
                100);

            int number = 0;

            if (!int.TryParse(_s, out number))
            {
                MessageBox.Show("値が不正です");
                return;
            }
            else
            {
                string _name = ((ClubMember)ClubMembersListBox.SelectedItem).Name;

                CortMemberListBox.Items.Add(new Player(_name, number));
            }

            
        }

        private void IntoOutMemberButton_Click(object sender, EventArgs e)
        {
            if (ClubMembersListBox.SelectedItem == null)
            {
                MessageBox.Show("メンバーが選択されていません");
                return;
            }

            string _s = Microsoft.VisualBasic.Interaction.InputBox(
                ClubMembersListBox.SelectedItem.ToString() + "の背番号を入力してください",
                "入力画面",
                "",
                200,
                100);

            int number = 0;

            if (!int.TryParse(_s, out number))
            {
                MessageBox.Show("値が不正です");
                return;
            }
            else
            {
                string _name = ((ClubMember)ClubMembersListBox.SelectedItem).Name;

                OutMemberListBox.Items.Add(new Player(_name, number));
            }
        }

        private void buttonDicision_Click(object sender, EventArgs e)
        {

            int _number = 0;

            if (!int.TryParse(EditNumberTextBox.Text, out _number))
            {
                MessageBox.Show("値が不正です");
                return;
            }

            int _index = CortMemberListBox.Items.IndexOf(selectedPlayer);

            if (_index >= 0)
            {
                Player _p = new Player(EditNameTextBox.Text, _number);

                CortMemberListBox.Items.Insert(_index, _p);

                CortMemberListBox.Items.Remove(selectedPlayer);
            }
            else
            {
                _index = OutMemberListBox.Items.IndexOf(selectedPlayer);

                if (_index < 0)
                {
                    MessageBox.Show("選択選手が見つかりませんでした");
                    return;
                }

                Player _p = new Player(EditNameTextBox.Text, _number);

                OutMemberListBox.Items.Insert(_index, _p);

                OutMemberListBox.Items.Remove(selectedPlayer);
            }
        }
    }
}
