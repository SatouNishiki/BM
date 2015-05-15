using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using BasketballManagementSystem.BaseClass.Player;


namespace BasketballManagementSystem.BMForm.Input.FormInputEvent
{
    public class ListDragAndDropEvent
    {
        //マウスの押された位置を覚える変数
        private Point mouseDownPoint = Point.Empty;

        /// <summary>
        /// マウスが動いたときの処理を委託されるクラス
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void onMouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDownPoint != Point.Empty)
            {
                //ドラッグと判定しないマウスの位置の範囲
                Rectangle moveRect = new Rectangle(
                    mouseDownPoint.X - SystemInformation.DragSize.Width / 2,
                    mouseDownPoint.Y - SystemInformation.DragSize.Height / 2,
                    SystemInformation.DragSize.Width,
                    SystemInformation.DragSize.Height);

                if (!moveRect.Contains(e.X, e.Y))
                {
                    ListBox lbx = (ListBox)sender;

                    //ドラッグするアイテムのインデックス
                    int itemIndex = lbx.IndexFromPoint(mouseDownPoint);

                    if (itemIndex < 0)
                    {
                        return;
                    }

                    //ドラッグするアイテムを取得
                    Player item = (Player)lbx.Items[itemIndex];

                    //ドラッグアンドドロップ処理開始
                    DragDropEffects dde = lbx.DoDragDrop(item, DragDropEffects.All | DragDropEffects.Link);

                    if (dde == DragDropEffects.Move)
                    {
                        lbx.Items.RemoveAt(itemIndex);
                    }

                    mouseDownPoint = Point.Empty;
                }
            }
        }

        /// <summary>
        /// マウスを離したときの処理委託
        /// </summary>
        public void onMouseUp()
        {
            mouseDownPoint = Point.Empty;
        }

        /// <summary>
        /// マウスを押したときの処理委託
        /// 押した位置記録
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void onMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ListBox lbx = (ListBox)sender;

                if (lbx.IndexFromPoint(e.X, e.Y) >= 0)
                {
                    mouseDownPoint = new Point(e.X, e.Y);
                }
                else
                {
                    mouseDownPoint = Point.Empty;
                }
            }
        }

        /// <summary>
        /// アイテムがlistbox内にドラッグされたとき
        /// 自チームは自チームのlistに、相手チームは相手チームのリストに移動されているのか判定
        /// アイテムの型があっているのか判定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="PlayerList"></param>
        /// <param name="OutMemberList"></param>
        /// <param name="OppentPlayerList"></param>
        /// <param name="OppentOutMemberList"></param>
        public void onDragEnter(object sender, DragEventArgs e, ListBox PlayerList, ListBox OutMemberList,
            ListBox OppentPlayerList, ListBox OppentOutMemberList)
        {
            //ドロップされているデータ
            Player p = (Player)(e.Data.GetData(typeof(Player)));

            bool b = false;

            //そのデータに記載されているチームと同じチームのリストにドラッグしているのか判定
            if (p.isMyTeam)
            {
                if ((ListBox)sender == PlayerList || (ListBox)sender == OutMemberList)
                {
                    b = true;
                }
            }
            else
            {
                if ((ListBox)sender == OppentPlayerList || (ListBox)sender == OppentOutMemberList)
                {
                    b = true;
                }

            }

            if (e.Data.GetDataPresent(typeof(Player)) && b)
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        /// <summary>
        /// アイテムがドロップされたときの処理委託
        /// アイテムの型があっていれば受け入れ(追加)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void onDragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Player)))
            {
                ListBox taeget = (ListBox)sender;

                Player item = (Player)e.Data.GetData(typeof(Player));

                taeget.Items.Add(item);
            }
        }
    }
}
