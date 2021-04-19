using System;
using System.Collections.Generic;
using System.Text;

namespace Dianda.BLL
{
    /// <summary>
    /// 信息栏目的扩展类方法
    /// </summary>
    public class News_ColumnsExt
    {
        Model.News_Columns mcolumns = new Dianda.Model.News_Columns();
        BLL.News_Columns bcolumns = new News_Columns();
        /// <summary>
        /// 项目信息栏目和部门信息栏目的添加类
        /// </summary>
        /// <param name="names">栏目的名称</param>
        /// <param name="ForItems">是哪种类型的</param>
        /// <param name="ItemsID">这个类型对应的ID</param>
        /// <returns></returns>
        public bool addCloumns(string names,string ForItems,string ItemsID,int parentid)
        {
            bool coutw = false;
            try
            {

                mcolumns.COLUMNSPATH = "0/" + bcolumns.GetMaxId().ToString();
                mcolumns.DATETIME = DateTime.Now;
                mcolumns.DELFLAG = 0;
                mcolumns.ForItems = ForItems;
                mcolumns.IMAGEURL = "0";
                mcolumns.ISMENU = 0;
                mcolumns.ISSHENHE = 0;
                mcolumns.ItemsID = ItemsID;
                mcolumns.NAME = names;
                mcolumns.ONLYONE = 0;
                mcolumns.PARENTID = parentid;
                mcolumns.PNAMES = "系统>>" + names;
                mcolumns.SHUNXU = 0;
                bcolumns.Add(mcolumns);
                coutw = true;
            }
            catch
            {
                coutw = false;
            }
            return coutw;
        }
    }
}