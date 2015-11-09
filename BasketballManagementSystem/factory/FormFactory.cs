using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasketballManagementSystem.abstracts;
using BasketballManagementSystem.interfaces;
using System.Windows.Forms;

namespace BasketballManagementSystem.factory
{
    public abstract class FormFactory
    {
        /// <summary>
        /// Presenterの作成
        /// </summary>
        /// <returns></returns>
        public abstract AbstractPresenter CreatePresenter();
    }
}
