using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballManagementSystem.events
{
    /// <summary>
    /// View,Modelのプロパティが変わったときによばれるイベント
    /// </summary>
    public class PropertyChangedEventArgs : EventArgs
    {
        private string propertyName;
        private object value;

        /// <summary>
        /// 変更されたプロパティ名
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

        public PropertyChangedEventArgs(string propName, object value)
        {
            this.PropertyName = propName;
            this.Value = value;
        }
    }
}
