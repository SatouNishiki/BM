using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace BasketballManagementSystem.interfaces
{
    /// <summary>
    /// プレゼンテーター共通インターフェースベース
    /// </summary>
    public interface IPresenter
    {
        IModel Model { get; }
        IView View { get; }

        /// <summary>
        /// view側からモデルのプロパティを取得
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        object GetModelProperty(string name);

        /// <summary>
        /// ViewのShow()メソッドを呼び出す
        /// </summary>
        void ShowView();
    }
}
