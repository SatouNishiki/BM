using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMErrorLibrary;

namespace BasketballManagementSystem.BaseClass.Player
{
    public class PlayerCoparer : IComparer
    {
        public int Compare(object x, object y)
        {
            //nullってたら殺す
            if (x == null || y == null)
            {
                BMError.ErrorMessageOutput("値がnullなので比較できません", true);
                throw new ArgumentException("Player :: 値がnullなので比較できません");
            }

            if (x.GetType() != typeof(Player) || y.GetType() != typeof(Player))
            {
                BMError.ErrorMessageOutput("型が違うので比較できません", true);
                throw new ArgumentException("Player :: 型が違うので比較できません");
            }

            return ((Player)x).Number.CompareTo(((Player)y).Number);
        }
    }
}
