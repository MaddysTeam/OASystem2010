using System;
using System.Collections.Generic;
using System.Web;
using System.Xml;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dianda.COMMON
{
  public  class GridViewControl
    {

      private const string _novalueStrings = "没有可以处理的数据!";
        /// <summary>
        ///  获取到列表中单个被选中的数据（返回{采集的数量，采集的内容}）
        /// </summary>
        /// <param name="gvc">要获取那个列表控件的值</param>
        /// <param name="checkboxName">列表中的复选框的名称</param>
        /// <param name="cellWhere">复选框放在第几个列中</param>
        /// <param name="gridViewKey">要采集的数据集合的关键字</param>
        /// <param name="fenge">保存采集后的字符串，要什么分隔</param>
        /// <returns></returns>
        public string[] getSelect(GridView gvc, string checkboxName,int cellWhere,string gridViewKey,char fenge)
        {
            string[] coutw = {"0","0"};
            try
            {
                int num = 0;
                int rows = gvc.Rows.Count;
                string selectValue = "";
                if (rows > 0)
                {
                    for (int i = 0; i < rows; i++)
                    {
                        CheckBox cb = (CheckBox)gvc.Rows[i].Cells[cellWhere].FindControl(checkboxName);
                        if (cb.Checked)
                        {
                            string id=gvc.DataKeys[i][gridViewKey].ToString();
                            num = num + 1;
                            selectValue = selectValue + id + fenge;
                        }
                    }
                    coutw[0] = num.ToString();
                    coutw[1] = selectValue.Length > 0 ? selectValue : _novalueStrings;
                }
                else
                {
                    coutw[0] = "0";
                    coutw[1] = _novalueStrings;
                }
            }
            catch
            {
            }
            return coutw;
        }


      /// <summary>
      /// 全选，全不选
      /// </summary>
        /// <param name="gvc">要获取那个列表控件的值</param>
        /// <param name="checkboxName">列表中的复选框的名称</param>
      /// <param name="isCheck">选中，还是不选中</param>
        /// <param name="cellWhere">复选框放在第几个列中</param>
      public void selectAll(GridView gvc, string checkboxName, bool isCheck, int cellWhere)
        {
            try
            {
                int rows = gvc.Rows.Count;
                if (rows > 0)
                {
                    for (int i = 0; i < rows; i++)
                    {
                        CheckBox cb = (CheckBox)gvc.Rows[i].Cells[cellWhere].FindControl(checkboxName);
                        cb.Checked = isCheck;
                    }
                }
            }
            catch
            {
            }
        }
    }
}
