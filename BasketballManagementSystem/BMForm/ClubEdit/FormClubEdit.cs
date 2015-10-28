using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BasketballManagementSystem.baseClass.club;
using BMFileLibrary;
using System.Xml.Serialization;
using BMErrorLibrary;

namespace BasketballManagementSystem.bMForm.clubEdit
{
    public partial class FormClubEdit : Form
    {
        /// <summary>
        /// trueのとき保存されていない変更がある
        /// </summary>
        private bool changeFlag = false;

        public FormClubEdit()
        {
            InitializeComponent();
        }

        private void LoadClubToolStripMenuItem_Click(object sender, EventArgs e)
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

                    ClubNameTextBox.Text = clubTeam.Name;

                    ClubMembersListBox.Items.Clear();
                    foreach (ClubMember clubMember in clubTeam.ClubMemberList)
                    {
                        ClubMembersListBox.Items.Add(clubMember);
                    }

                    changeFlag = false;

                    stream.Close();
                }
                else
                {
                    BMError.ErrorMessageOutput("stream is null !!", true);
                }
            }
        }

        private void SaveClubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ClubNameTextBox.Text == string.Empty)
            {
                MessageBox.Show("Clubの名前を入力してください");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();

            //はじめのファイル名を指定する
            sfd.FileName = ClubNameTextBox.Text;

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

                    ClubTeam clubTeam = new ClubTeam();

                    clubTeam.Name = ClubNameTextBox.Text;

                    foreach (ClubMember clubMember in ClubMembersListBox.Items)
                    {
                        clubTeam.ClubMemberList.Add(clubMember);
                    }

                    s.Serialize(stream, clubTeam);

                    changeFlag = false;

                    stream.Close();
                }
                else
                {
                    BMError.ErrorMessageOutput("stream is null !!", true);
                }
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            ClubMember clubMember = new ClubMember();
            double height = 0.0D;
            double weight = 0.0D;

            if (NameAddTextBox.Text == string.Empty)
            {
                MessageBox.Show("名前が未入力です");
                return;
            }

            if (HeightAddTextBox.Text != string.Empty)
            {
                if (!double.TryParse(HeightAddTextBox.Text, out height))
                {
                    MessageBox.Show("値が不正です");
                    return;
                }
            }

            if (WeightAddTextBox.Text != string.Empty)
            {
                if (!double.TryParse(WeightAddTextBox.Text, out weight))
                {
                    MessageBox.Show("値が不正です");
                    return;
                }
            }

            clubMember.Name = NameAddTextBox.Text;
            clubMember.Height = height;
            clubMember.Weight = weight;

            clubMember.IsMan = ManAddRadioButton.Checked;

            ClubMembersListBox.Items.Add(clubMember);

            changeFlag = true;

            NameAddTextBox.Text = string.Empty;
            HeightAddTextBox.Text = string.Empty;
            WeightAddTextBox.Text = string.Empty;
        }

        private void ClubMembersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ClubMembersListBox.SelectedItem == null) return;
            ClubMember selectedClubMember = (ClubMember)ClubMembersListBox.SelectedItem;

            NameSelectedTextBox.Text = selectedClubMember.Name;

            if (selectedClubMember.IsMan)
                ManSelectedRadioButton.Checked = true;
            else
                WomanSelectedRadioButton.Checked = false;

            HeightSelectedTextBox.Text = selectedClubMember.Height.ToString();
            WeightSelectedTextBox.Text = selectedClubMember.Weight.ToString();
           
        }

        private void DicisionButton_Click(object sender, EventArgs e)
        {
            ClubMember clubMember = new ClubMember();
            double height = 0.0D;
            double weight = 0.0D;

            if (NameSelectedTextBox.Text == string.Empty)
            {
                MessageBox.Show("名前が未入力です");
                return;
            }

            if (HeightSelectedTextBox.Text != string.Empty)
            {
                if (!double.TryParse(HeightSelectedTextBox.Text, out height))
                {
                    MessageBox.Show("値が不正です");
                    return;
                }
            }

            if (WeightSelectedTextBox.Text != string.Empty)
            {
                if (!double.TryParse(WeightSelectedTextBox.Text, out weight))
                {
                    MessageBox.Show("値が不正です");
                    return;
                }
            }

            clubMember.Name = NameSelectedTextBox.Text;
            clubMember.Height = height;
            clubMember.Weight = weight;

            clubMember.IsMan = ManSelectedRadioButton.Checked;

            int index = ClubMembersListBox.SelectedIndex;

            if (index < 0) return;

            ClubMembersListBox.Items.Insert(index, clubMember);
            ClubMembersListBox.Items.Remove(ClubMembersListBox.SelectedItem);

            changeFlag = true;

            NameSelectedTextBox.Text = string.Empty;
            HeightSelectedTextBox.Text = string.Empty;
            WeightSelectedTextBox.Text = string.Empty;

        }

        private void FormClubEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (changeFlag)
            {
                DialogResult d = MessageBox.Show("保存されていない変更がありますがよろしいですか?",
                                 "確認",
                                 MessageBoxButtons.OKCancel,
                                 MessageBoxIcon.Exclamation,
                                 MessageBoxDefaultButton.Button2);

                if (d == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (ClubMembersListBox.SelectedItem == null)
            {
                MessageBox.Show("メンバーが選択されていません");
                return;
            }

            DialogResult d = MessageBox.Show("本当に削除してよろしいでしょうか?",
                                 "確認",
                                 MessageBoxButtons.OKCancel,
                                 MessageBoxIcon.Exclamation,
                                 MessageBoxDefaultButton.Button2);

            if (d == DialogResult.OK)
            {
                ClubMembersListBox.Items.Remove(ClubMembersListBox.SelectedItem);
            }

            NameSelectedTextBox.Text = string.Empty;
            HeightSelectedTextBox.Text = string.Empty;
            WeightSelectedTextBox.Text = string.Empty;
        }

    }
}
