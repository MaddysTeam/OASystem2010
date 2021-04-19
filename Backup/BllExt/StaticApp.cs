using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Dianda.BllExt
{
    /// <summary>
    /// 获取本系统中所需要的所有的全局变量
    /// </summary>
    public class StaticApp
    {
        Dianda.COMMON.pageControl dosqls = new Dianda.COMMON.pageControl();//通用的数据库操作方法

        /// <summary>
        /// 通用的获取方法
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        public object getComms(string keys)
        {
            object coutw = new object();
            try
            {
                //先检查民族是否存在，如果不存在，则构建一个
                if (checkKey(keys))
                {
                    coutw = Dianda.COMMON.staticApp.GetValue((object)keys);
                }
                else
                {
                    coutw = setValue(keys);

                }
            }
            catch
            {
            }
            return coutw;
        }

        /// <summary>
        /// 移除包含的内容的全局变量
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        public object MoveContains(string keys)
        {
            object coutw = new object();
            ishave(keys);
            return coutw;
        }

        public void Remove(string keys)
        {
            Dianda.COMMON.staticApp.RemoveKey(keys);
        }
        /// <summary>
        /// 重启系统的全局变量
        /// </summary>
        public void RemoveAll()
        {
            Dianda.COMMON.staticApp.RemoveAll();
        }
        private bool ishave(string keys)
        {
            bool coutw = false;
            Dianda.COMMON.staticApp.IshaveValue((object)keys);
            return coutw;
        }
        /// <summary>
        /// 检查当前的KEY中是否有数据
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        private bool checkKey(string keys)
        {
            bool coutw = false;
            try
            {
                object getobject = Dianda.COMMON.staticApp.GetValue((object)keys);
                if (getobject != null)
                {
                    coutw = true;
                }
                else
                {
                    coutw = false;
                }
            }
            catch
            {
                coutw = false;
            }
            return coutw;
        }
        /// <summary>
        /// 给指定的KEY放置值
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        private object setValue(string tableNameKEY)
        {
            object coutw = new object();
            try
            {

                Dianda.COMMON.staticApp.Remove((object)tableNameKEY);//先删除
                //如果tableNameKEY中包含“|”则表示有查询条件限制
                string tablename = tableNameKEY;
                string tiaojian = "";
                if (tableNameKEY.Contains("|"))
                {
                    string[] arrays = tableNameKEY.Split('|');
                    tablename = arrays[0].ToString();
                    tiaojian = arrays[1].ToString();
                }

                string sql = "select * from " + tablename + " " + tiaojian;
                DataSet ds = dosqls.doSql(sql);
                coutw = (object)ds;
                Dianda.COMMON.staticApp.SetValue((object)tableNameKEY, coutw);
            }
            catch
            {
            }
            return coutw;
        }
    }
}
