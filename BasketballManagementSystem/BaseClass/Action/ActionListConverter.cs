using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMErrorLibrary;

namespace BasketballManagementSystem.BaseClass.Action
{
    public class ActionListConverter
    {
        /// <summary>
        /// objectのリストをAction型のリストへと変換します
        /// </summary>
        /// <param name="objectList">Actionオブジェクトが入ったlist</param>
        /// <returns>listの要素が全てAction型か? ActionList : null <returns>
        public static List<Action> ToActionList(List<object> objectList)
        {
            List<Action> actionList = new List<Action>();

            foreach (var obj in objectList)
            {
                if (!(obj is Action))
                {
                    BMError.ErrorMessageOutput("不正な型変換が行われました", true);
                    return null;
                }

                actionList.Add((Action)obj);
            }

            return actionList;
        }

        /// <summary>
        /// objectのリストをRelationPointAction型のリストへと変換します 
        /// objectの要素にRelationPointAction型ではないAction型のオブジェクトがあった場合、それらを無視したリストが帰ってきます
        /// </summary>
        /// <param name="objectList"></param>
        /// <returns></returns>
        public static List<RelationPointAction> ToRelationPointActionList(List<object> objectList)
        {
            List<RelationPointAction> actionList = new List<RelationPointAction>();

            foreach (var obj in objectList)
            {
                if (!(obj is Action))
                {
                    BMError.ErrorMessageOutput("不正な変換が行われました", true);
                    return null;
                }

                if (obj is RelationPointAction)
                {
                    actionList.Add((RelationPointAction)obj);
                }
            }

            return actionList;
        }
    }
}
