using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BasketballManagementSystem.BaseClass.Club;
using BMFileLibrary;
using System.Xml.Serialization;
using BMErrorLibrary;

namespace BasketballManagementSystem.BMForm.ClubEdit
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

                    ClubName.Text = _clubTeam.Name;

                    ClubMembersList.Items.Clear();
                    foreach (ClubMember _clubMember in _clubTeam.ClubMemberList)
                    {
                        ClubMembersList.Items.Add(_clubMember);
                    }

                    changeFlag = false;

                    _stream.Close();
                }
                else
                {
                    BMError.ErrorMessageOutput("stream is null !!");
                }
            }
        }

        private void saveClub_Click(object sender, EventArgs e)
        {
            if (ClubName.Text == string.Empty)
            {
                MessageBox.Show("Clubの名前を入力してください");
                return;
            }

            SaveFileDialog _sfd = new SaveFileDialog();

            //はじめのファイル名を指定する
            _sfd.FileName = ClubName.Text;

            //はじめに表示されるフォルダを指定する
            _sfd.InitialDirectory = BMFile.CreateDirectory("Save\\ClubData");

            //[ファイルの種類]に表示される選択肢を指定する
            _sfd.Filter =
                "Xmlファイル(*.xml)|*.xml|xmlファイル(*.xml)|*.xml";

            _sfd.Title = "保存先のファイルを選択してください";

            //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
            _sfd.RestoreDirectory = true;

            //ダイアログを表示する
            if (_sfd.ShowDialog() == DialogResult.OK)
            {
                System.IO.Stream _stream;
                _stream = _sfd.OpenFile();

                if (_stream != null)
                {

                    XmlSerializer _s = new XmlSerializer(typeof(ClubTeam));

                    ClubTeam _clubTeam = new ClubTeam();

                    _clubTeam.Name = ClubName.Text;

                    foreach (ClubMember _clubMember in ClubMembersList.Items)
                    {
                        _clubTeam.ClubMemberList.Add(_clubMember);
                    }

                    _s.Serialize(_stream, _clubTeam);

                    changeFlag = false;

                    _stream.Close();
                }
                else
                {
                    BMError.ErrorMessageOutput("stream is null !!");
                }
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            ClubMember _clubMember = new ClubMember();
            double _height = 0.0D;
            double _weight = 0.0D;

            if (NameAdd.Text == string.Empty)
            {
                MessageBox.Show("名前が未入力です");
                return;
            }

            if (HeightAdd.Text != string.Empty)
            {
                if (!double.TryParse(HeightAdd.Text, out _height))
                {
                    MessageBox.Show("値が不正です");
                    return;
                }
            }

            if (WeightAdd.Text != string.Empty)
            {
                if (!double.TryParse(WeightAdd.Text, out _weight))
                {
                    MessageBox.Show("値が不正です");
                    return;
                }
            }

            _clubMember.Name = NameAdd.Text;
            _clubMember.Height = _height;
            _clubMember.Weight = _weight;
            _clubMember.IsMan = IsManAdd.Checked;

            ClubMembersList.Items.Add(_clubMember);

            changeFlag = true;

            NameAdd.Text = string.Empty;
            HeightAdd.Text = string.Empty;
            WeightAdd.Text = string.Empty;
        }

        private void ClubMembersList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ClubMembersList.SelectedItem == null) return;
            ClubMember _selectedClubMember = (ClubMember)ClubMembersList.SelectedItem;

            NameSelected.Text = _selectedClubMember.Name;
            IsManSelected.Checked = _selectedClubMember.IsMan;
            HeightSelected.Text = _selectedClubMember.Height.ToString();
            WeightSelected.Text = _selectedClubMember.Weight.ToString();
           
        }

        private void ButtonDicision_Click(object sender, EventArgs e)
        {
            ClubMember _clubMember = new ClubMember();
            double _height = 0.0D;
            double _weight = 0.0D;

            if (NameSelected.Text == string.Empty)
            {
                MessageBox.Show("名前が未入力です");
                return;
            }

            if (HeightSelected.Text != string.Empty)
            {
                if (!double.TryParse(HeightSelected.Text, out _height))
                {
                    MessageBox.Show("値が不正です");
                    return;
                }
            }

            if (WeightSelected.Text != string.Empty)
            {
                if (!double.TryParse(WeightSelected.Text, out _weight))
                {
                    MessageBox.Show("値が不正です");
                    return;
                }
            }

            _clubMember.Name = NameSelected.Text;
            _clubMember.Height = _height;
            _clubMember.Weight = _weight;
            _clubMember.IsMan = IsManSelected.Checked;

            int _index = ClubMembersList.SelectedIndex;

            if (_index < 0) return;

            ClubMembersList.Items.Insert(_index, _clubMember);
            ClubMembersList.Items.Remove(ClubMembersList.SelectedItem);

            changeFlag = true;

            NameSelected.Text = string.Empty;
            HeightSelected.Text = string.Empty;
            WeightSelected.Text = string.Empty;

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

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (ClubMembersList.SelectedItem == null)
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
                ClubMembersList.Items.Remove(ClubMembersList.SelectedItem);
            }

            NameSelected.Text = string.Empty;
            HeightSelected.Text = string.Empty;
            WeightSelected.Text = string.Empty;
        }

    }
}
