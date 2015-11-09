using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasketballManagementSystem.events.input
{
    /// <summary>
    /// KeyEventArgsのラッピングイベント
    /// </summary>
    public class KeyboardEventArgs : EventArgs
    {
        public enum KeyType
        {
            KeyDown, KeyUp
        }

        private KeyEventArgs keyEventArgs;
        private KeyType type;

        public KeyEventArgs KeyEventArgs
        {
            get { return this.keyEventArgs; }
            set { this.keyEventArgs = value; }
        }

        public KeyType Type
        {
            get { return this.type; }
            set { this.type = value; }
        }

        public KeyboardEventArgs(KeyEventArgs keyEventArgs, KeyType type)
        {
            this.KeyEventArgs = keyEventArgs;
            this.Type = type;
        }
       
    }
}
