using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Dianda.BllExt
{

    /// <summary>
    /// 处理所有的全局静态变量
    /// </summary>
    public class StaticFactory_CASH
    {
        StaticApp sApp = new StaticApp();   //统一处理静态变量的函数
        public const string _keyCash_DetailNameList = "Cash_ControlInfo| order by NUMS ASC";//资金卡明细名称的静态KEY
        public const string _keyvCash_Account = "vCash_Account| order by NAMES ASC";//账户的静态KEY
        public const string _keyvCash_SpecialFunds = "vCash_SpecialFunds| order by NAMES ASC";//专项资金的静态KEY
        
        #region 静态变量列表
        static DataTable _StaticCash_DetailNameList;//资金卡明细名称的静态数据
        static DataTable _StaticvCash_Account;//账户的静态数据
        static DataTable _StaticvCash_SpecialFunds;//专项资金的静态数据
        #endregion

        #region 静态变量的获取
        /// <summary>
        /// 资金卡明细名称
        /// </summary>
        public DataTable getCash_DetailNameList()
        {
            return getStaticList(_keyCash_DetailNameList, _StaticCash_DetailNameList);
        }
        /// <summary>
        /// 清空资金卡明细名称
        /// </summary>
        public void delCash_DetailNameList()
        {
            delStatic(_keyCash_DetailNameList, _StaticCash_DetailNameList);
        }
        /// <summary>
        /// 重置资金卡明细名称
        /// </summary>
        public void resetCash_DetailNameList()
        {
            resetStatic(_keyCash_DetailNameList, _StaticCash_DetailNameList);
        }

        /*-------------------------------------------------------------------------*/
        /// <summary>
        /// 账户名称
        /// </summary>
        public DataTable getCash_Account()
        {
            return getStaticList(_keyvCash_Account, _StaticvCash_Account);
        }
        /// <summary>
        /// 清空账户
        /// </summary>
        public void delCash_Account()
        {
            delStatic(_keyvCash_Account, _StaticvCash_Account);
        }
        /// <summary>
        /// 重置账户
        /// </summary>
        public void resetCash_Account()
        {
            resetStatic(_keyvCash_Account, _StaticvCash_Account);
        }
        /*-------------------------------------------------------------------------*/
        /// <summary>
        /// 专项资金
        /// </summary>
        public DataTable getCash_SpecialFunds()
        {
            return getStaticList(_keyvCash_SpecialFunds, _StaticvCash_SpecialFunds);
        }
        /// <summary>
        /// 清空专项资金
        /// </summary>
        public void delCash_SpecialFunds()
        {
            delStatic(_keyvCash_SpecialFunds, _StaticvCash_SpecialFunds);
        }
        /// <summary>
        /// 重置专项资金
        /// </summary>
        public void resetCash_SpecialFunds()
        {
            resetStatic(_keyvCash_SpecialFunds, _StaticvCash_SpecialFunds);
        }
  
        #endregion
        /// <summary>
        /// 统一获取静态数据
        /// </summary>
        /// <param name="keys"></param>
        /// <param name="staticData"></param>
        /// <returns></returns>
        private DataTable getStaticList(string keys, DataTable staticData)
        {
            if (staticData == null)
            {
                staticData = ((DataSet)getComms(keys)).Tables[0];
            }
            return staticData;
        }
        /// <summary>
        /// 统一删除静态数据
        /// </summary>
        /// <param name="keys"></param>
        /// <param name="staticData"></param>
        private void delStatic(string keys, DataTable staticData)
        {
            removeStatic(keys);
            staticData = null;
        }
        /// <summary>
        /// 重置静态数据
        /// </summary>
        /// <param name="keys"></param>
        /// <param name="staticData"></param>
        private void resetStatic(string keys, DataTable staticData)
        {
            removeStatic(keys);
            staticData = null;
            staticData = ((DataSet)getComms(keys)).Tables[0];
        }
        /// <summary>
        /// 对生产静态变量的调用
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        private object getComms(string keys)
        {
            return (object)sApp.getComms(keys);
        }
        /// <summary>
        /// 清理移除静态变量
        /// </summary>
        /// <param name="keys"></param>
        private void removeStatic(string keys)
        {
            sApp.Remove(keys);
        }
    }
}
