using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasketballManagementSystem.interfaces;

namespace BasketballManagementSystem.abstracts
{
    public class AbstractModel : IModel
    {
        public event events.PropertyChangedEventHandler PropertyChangedEvent;

        protected void PropertyChangedEventThrow(object sender, events.PropertyChangedEventArgs e)
        {
            if (this.PropertyChangedEvent != null)
            {
                this.PropertyChangedEvent(sender, e);
            }
        }
    }
}
