using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DandDPlayerList;
using BasketballManagementSystem.BaseClass.Player;

namespace BasketballManagementSystem.BMForm.Input.EventHelper
{
    public class PlayerListSortEventHelper
    {
        public static void Sort(ListBox pList)
        {
            if (pList.Items.Count != 0)
            {
                int index = pList.SelectedIndex;

                Player[] array = new Player[pList.Items.Count];
                pList.Items.CopyTo(array, 0);

                Array.Sort(array, new PlayerCoparer());

                pList.Items.Clear();

                foreach (Player p in array)
                {
                    pList.Items.Add(p);
                }

                pList.SelectedIndex = index;
            }
        }
    }
}
