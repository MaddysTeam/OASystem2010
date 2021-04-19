using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Dianda.COMMON
{
    public class staticApp
    {
        /// <summary>
        /// //*Hashtable用于存放全局变量，由key和value成对实现
        /// </summary>
        private static Hashtable table = new Hashtable();
        private staticApp()
        {
        }
        /// <summary>
        /// 获取指定KEY的值
        /// </summary>
        /// <param name="akey"></param>
        /// <returns></returns>
        public static object GetValue(object akey)
        {
            return table[akey];
        }
        /// <summary>
        /// 设置指定KEY值的值
        /// </summary>
        /// <param name="akey"></param>
        /// <param name="avalue"></param>
        public static void SetValue(object akey, object avalue)
        {
            table[akey] = avalue;
        }
        /// <summary>
        /// 清理指定KEY值的值
        /// </summary>
        /// <param name="akey"></param>
        public static void Remove(object akey)
        {
            table.Remove(akey);
        }
        /// <summary>
        /// 模糊查询全局变量中是否有指定的值
        /// </summary>
        /// <param name="akey"></param>
        public static void IshaveValue(object akey)
        {
            ArrayList akeys = new ArrayList(table.Keys);
            for (int i = 0; i < akeys.Count; i++)
            {
                string akeysi = akeys[i].ToString();
                if (akeysi.Contains(akey.ToString()))
                {
                    SetValue((object)akeysi, null);
                }
            }

        }
        /// <summary>
        /// 清理指定关键字的全局变量
        /// </summary>
        /// <param name="akey"></param>
        public static void RemoveKey(object akey)
        {
            try
            {
                ArrayList akeys = new ArrayList(table.Keys);
                for (int i = 0; i < akeys.Count; i++)
                {
                    string akeysi = akeys[i].ToString();
                    if (akeysi.Contains(akey.ToString()))
                    {
                        table.Remove(akeysi);
                    }
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// 清理系统中的所有全局变量
        /// </summary>
        public static void RemoveAll()
        {
            try
            {
                ArrayList akeys = new ArrayList(table.Keys);
                for (int i = 0; i < akeys.Count; i++)
                {
                    string akeysi = akeys[i].ToString();
                    table.Remove(akeysi);
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// 标记是否是最新数据：1 已是最新、0 需要更新（默认值）
        /// </summary>
        private static int istongjiStatic = 0;

        public static int IstongjiStatic
        {
            get { return staticApp.istongjiStatic; }
            set { staticApp.istongjiStatic = value; }
        }
    }
}
