using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasketballManagementSystem.BMForm.Input.EventHelper
{
    public class KeyboardEventHelper
    {
        private bool fastFowardFlagPushed = false;
        private bool rewindFlagPushed = false;

        public void KeyDownEvent(FormInput form, KeyEventArgs key)
        {
            switch (key.KeyData)
            {
                case Keys.Right:
                    form.QuarterTimer.fastFowardFlag = true;
                    fastFowardFlagPushed = true;
                    break;

                case Keys.Left:
                    form.QuarterTimer.rewindFlag = true;
                    rewindFlagPushed = true;
                    break;

                case Keys.Space:
                    form.QuarterTimerStopButton.PerformClick();
                    break;
            }
        }

        public void KeyUpEvent(FormInput form)
        {
            if(fastFowardFlagPushed)
            form.QuarterTimer.rewindFlag = false;

            if(rewindFlagPushed)
            form.QuarterTimer.fastFowardFlag = false;
        }
    }
}
