using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using BasketballManagementSystem.baseClass.action;
using BasketballManagementSystem.baseClass.position;
using BasketballManagementSystem.baseClass.command;
using BasketballManagementSystem.interfaces;

namespace BasketballManagementSystem.bmForm.input.eventHelper
{
    /// <summary>
    /// コートをクリックされたときのイベントを管理するクラス
    /// listを表示して点数入力を可能にする
    /// </summary>
    public class CortEventHelper
    {
        /// <summary>
        /// マウスの押された位置を覚える変数
        /// </summary>
        private Point mousePoint = Point.Empty;

        /// <summary>
        /// コートをクリックされたときに出すリスト
        /// </summary>
        private ListBox selectPointList;

        /// <summary>
        /// コートのPictureBox
        /// </summary>
        private PictureBox pictureBox;

        /// <summary>
        /// すでにlistが存在しているかどうか
        /// </summary>
        private bool isExistListBox = false;

        /// <summary>
        /// リストの中のキャンセル文字を表す固定文字列
        /// </summary>
        private const string cancelString = "キャンセル";

        /// <summary>
        /// アクションが行われた場所(実際のコート上の相対座標)
        /// </summary>
        private Position position = new Position();

        private FormInputModel model;

        /// <summary>
        /// コートがクリックされたときに呼ばれる
        /// マウスの位置にlistboxを出す
        /// 二個以上は表示しない
        /// </summary>
        /// <param name="formInputView"></param>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnCortClick(FormInputView formInputView, FormInputModel formInputModel, PictureBox pictureBox, EventArgs e)
        {
            this.model = formInputModel;
            this.pictureBox = pictureBox;

            //もし画面上にlistboxがなかったら
            if (!isExistListBox)
            {

                //マウスの位置を記憶
                mousePoint.X = Cursor.Position.X;
                mousePoint.Y = Cursor.Position.Y;

                //マウスの位置をフォーム上の座標に変換
                mousePoint = formInputView.PointToClient(mousePoint);

                //コートの画像の左上、右下の座標算出
                Point leftTop = pictureBox.Location;
                int rightDownX = pictureBox.Location.X + pictureBox.Size.Width;
                int rightDownY = pictureBox.Location.Y + pictureBox.Size.Height;
                Point rightDown = new Point();
                rightDown.X = rightDownX;
                rightDown.Y = rightDownY;

                bool isChangeCort = false;

                if (formInputModel.Quarter >= 3) isChangeCort = true;

                //入力された場所の座標を実際のコートに変換
                position = PositionConvert.ConvertToPosition(mousePoint, leftTop, rightDown, formInputModel.SelectedPlayer.IsMyTeam, isChangeCort);

                selectPointList = new ListBox();

                selectPointList.Name = "selectPointList";
                selectPointList.Font = new Font("MS UI Gothic", 12);

                //listboxにアイテム追加
                selectPointList.Items.Add((new Shoot2P()).ActionName);
                selectPointList.Items.Add((new Shoot2PMiss()).ActionName);
                selectPointList.Items.Add((new Shoot3P()).ActionName);
                selectPointList.Items.Add((new Shoot3PMiss()).ActionName);
                selectPointList.Items.Add((new FreeThrow()).ActionName);
                selectPointList.Items.Add((new FreeThrowMiss()).ActionName);
                selectPointList.Items.Add(cancelString);

                selectPointList.Size = new Size(selectPointList.Size.Width + 15, selectPointList.Size.Height + 30);

                Point p2 = new Point(mousePoint.X + 40, mousePoint.Y - 40);

                while (p2.Y + selectPointList.Size.Height > rightDown.Y)
                {
                    p2.Offset(new Point(0, -10));
                }

                selectPointList.Location = p2;

                //クリック点に円を描画
                using(Graphics graphics = pictureBox.CreateGraphics()){

                    int radius = 5;

                    pictureBox.Refresh();
                    graphics.FillEllipse(Brushes.Red, ((MouseEventArgs)e).X - radius, ((MouseEventArgs)e).Y - radius, radius * 2, radius * 2);
                }

                //クリックされたときのイベントを設定
                selectPointList.Click += new EventHandler(SelectPointListClick);

                //コントロールをフォームに追加
                formInputView.Controls.Add(selectPointList);
                
                //コントロールを最前面にもってくる
                selectPointList.BringToFront();

                isExistListBox = true;
            }
            else
            {
                selectPointList.Dispose();
                isExistListBox = false;
                //点の消去(背景色で塗りつぶし)
                using (Graphics graphics = pictureBox.CreateGraphics()) graphics.Clear(pictureBox.BackColor);
                //コートイメージの再描画
                pictureBox.Refresh();
            }
        }

        /// <summary>
        /// listboxがクリックされたときに呼ばれる
        /// 項目ごとにアクション入力イベント管理クラスに処理を委託
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectPointListClick(object sender, EventArgs e)
        {
            //選択されたリストの文字列
            string selectItemName = (string)((ListBox)sender).SelectedItem;

            //キャンセルだったら何も処理しない
            if (selectItemName != cancelString)
            {
                try
                {
                    //フルパスでうたないと動かないらしい
                    Type t = Type.GetType("BasketballManagementSystem.baseClass.action." + selectItemName);

                    object o = Activator.CreateInstance(t);

                    //何のアクションを入力してほしいかを渡す
                    ICommand command = new ActionCommand(model, t, this.position);
                    this.model.StackGameData();
                    command.Execute();
                        

                }
                catch (Exception exc)
                {
                    BMErrorLibrary.BMError.ErrorMessageOutput(exc.Message, true);
                }
            }

            //操作が終わったらlistを消す
            ((ListBox)sender).Dispose();

            //点の消去(背景色で塗りつぶし)
            using (Graphics graphics = pictureBox.CreateGraphics()) graphics.Clear(pictureBox.BackColor);

            //イメージの再描画
            pictureBox.Refresh();

            //フラグを"listが存在しない"に書き換え
            isExistListBox = false;
        }
    }
}
