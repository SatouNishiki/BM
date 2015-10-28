using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasketballManagementSystem.interfaces;
using BasketballManagementSystem.events;
using System.Reflection;
using BMErrorLibrary;

namespace BasketballManagementSystem.abstracts
{
    public abstract class AbstractPresenter : IPresenter
    {
        protected IModel model;
        protected IView view;


        IModel IPresenter.Model
        {
            get { return this.model; }
        }

        IView IPresenter.View
        {
            get { return this.view; }
        }

        public AbstractPresenter(IView iview, IModel imodel)
        {
            this.view = iview;
            this.model = imodel;
            iview.Presenter = this;
            iview.DataInputEvent += iview_DataInputEvent;
        }

        /// <summary>
        /// viewのデータが変更されたときここに落ちる
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void iview_DataInputEvent(object sender, DataInputEventArgs e)
        {
            this.SetModelPropertyFromView(e.PropertyName, e.Value);
        }

        /// <summary>
        /// viewで変更されたプロパティをmodelのプロパティに適用する
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        private void SetModelPropertyFromView(string name, object value)
        {
            PropertyInfo modelProperty = this.model.GetType().GetProperty(name);

            if (modelProperty == null)
            {
                BMError.ErrorMessageOutput("プロパティ:" + name + " が見つかりません", true);
                return;
            }

            if (modelProperty.PropertyType.Equals(value.GetType()))
            {
                object valueToAssign = Convert.ChangeType(value, modelProperty.PropertyType);

                if (valueToAssign != null)
                {
                    modelProperty.SetValue(this.model, valueToAssign, null);
                }
            }
            else
            {
                BMError.ErrorMessageOutput("プロパティ:" + name + " の型が一致しません", true);
                return;
            }
            
        }

        /// <summary>
        /// viewからmodelのプロパティを取得
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public object GetModelProperty(string name)
        {
            return this.model.GetType().GetProperty(name).GetValue(model);
        }


        public virtual void ShowView()
        {
            throw new NotImplementedException();
        }
    }
}
