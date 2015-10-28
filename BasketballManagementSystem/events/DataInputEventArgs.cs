using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballManagementSystem.events
{
    /// <summary>
    /// データが入力された時のイベント
    /// </summary>
    public class DataInputEventArgs : EventArgs
    {
        private string propertyName;
        private object value;

        /// <summary>
        /// 入力されたプロパティ名
        /// </summary>
        public string PropertyName
        {
            get { return this.propertyName; }
            set { this.propertyName = value; }
        }

        /// <summary>
        /// 変更後の値
        /// </summary>
        public object Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public DataInputEventArgs(string propName, object value)
        {
            this.PropertyName = propName;
            this.Value = value;

            
        }
    }
}
