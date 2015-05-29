using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using BasketballManagementSystem.BaseClass.Action;
using BasketballManagementSystem.BaseClass.Position;

namespace BasketballManagementSystem.BMForm.Input.EventHelper
{
    /// <summary>
    /// コートをクリックされたときのイベントを管理するクラス
    /// listを表示して点数入力を可能にする
    /// </summary>
    public class CortEventHelper
    {
        //マウスの押された位置を覚える変数
        private Point mousePoint = Point.Empty;

        //コートをクリックされたときに出すリスト
        private ListBox selectPointList;

        //入力画面のインスタンスを代入する変数
        private FormInput formInput;

        //アクションが入力されたときの処理をするクラスのインスタンス
        private ActionClickEventHelper actionClickEvent = new ActionClickEventHelper();

        //すでにlistが存在しているかどうか
        private bool isExistListBox = false;

        //リストの中のキャンセル文字を表す固定文字列
        private const string cancelString = "キャンセル";

        //アクションが行われた場所(実際のコート上の相対座標)
        Position position = new Position();

        /// <summary>
        /// コートがクリックされたときに呼ばれる
        /// マウスの位置にlistboxを出す
        /// 二個以上は表示しない
        /// </summary>
        /// <param name="f"></param>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void onCortClick(FormInput f, PictureBox pictureBox , object sender, EventArgs e)
        {
            //もし画面上にlistboxがなかったら
            if (!isExistListBox)
            {
                formInput = f;

                //マウスの位置を記憶
                mousePoint.X = Cursor.Position.X;
                mousePoint.Y = Cursor.Position.Y;

                //マウスの位置をフォーム上の座標に変換
                mousePoint = f.PointToClient(mousePoint);

                //コートの画像の左上、右下の座標算出
                Point leftTop = pictureBox.Location;
                int rightDownX = pictureBox.Location.X + pictureBox.Size.Width;
                int rightDownY = pictureBox.Location.Y + pictureBox.Size.Height;
                Point rightDown = new Point();
                rightDown.X = rightDownX;
                rightDown.Y = rightDownY;

                //入力された場所の座標を実際のコートに変換
                position = PositionConvert.ConvertToPosition(mousePoint, leftTop, rightDown);

                selectPointList = new ListBox();

                selectPointList.Name = "selectPointList";

                //listboxにアイテム追加
                selectPointList.Items.Add((new Shoot2P()).ActionName);
                selectPointList.Items.Add((new Shoot2PMiss()).ActionName);
                selectPointList.Items.Add((new Shoot3P()).ActionName);
                selectPointList.Items.Add((new Shoot3PMiss()).ActionName);
                selectPointList.Items.Add((new FreeThrow()).ActionName);
                selectPointList.Items.Add((new FreeThrowMiss()).ActionName);
                selectPointList.Items.Add(cancelString);

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
                f.Controls.Add(selectPointList);
                
                //コントロールを最前面にもってくる
                selectPointList.BringToFront();

                isExistListBox = true;
            }
            else
            {
                selectPointList.Dispose();
                isExistListBox = false;
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
                    Type t = Type.GetType("BasketballManagementSystem.BaseClass.Action." + selectItemName);

                    object o = Activator.CreateInstance(t);

                    //何のアクションを入力してほしいかを渡す
                    actionClickEvent.ActionInputAccept(formInput, o, position);

                }
                catch (Exception exc)
                {
                    BMErrorLibrary.BMError.ErrorMessageOutput(exc.Message);
                }
            }

            //操作が終わったらlistを消す
            ((ListBox)sender).Dispose();

            //フラグを"listが存在しない"に書き換え
            isExistListBox = false;
        }
    }
}
