using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dianda.BllExt
{
   public class SearchModels
    {
       /// <summary>
       /// 搜索资金卡的类
       /// </summary>
        public class SearchCashCard
        {
            private string _cardNum;//卡编号
            private string _cardName;//卡名称
            private string _whos;//持卡人
            private string _datetime;//创建日期
            private string _projectid;//项目ID
            private string _partmentid;//部门ID
            private string _specialFundsID;//专项资金ID
            private string _Cash_SF_Order;//预算报告ID
            private string _Cash_ZT;//资金卡状态
            /// <summary>
            /// 资金卡状态
            /// </summary>
            public string Cash_ZT
            {
                set { _Cash_ZT = value; }
                get { return _Cash_ZT; }
            }

            /// <summary>
            /// 卡编号
            /// </summary>
            public string cardNum
            {
                set { _cardNum = value; }
                get { return _cardNum; }
            }
            /// <summary>
            /// 卡名称
            /// </summary>
            public string cardName
            {
                set { _cardName = value; }
                get { return _cardName; }
            }
            /// <summary>
            /// 持卡人
            /// </summary>
            public string whos
            {
                set { _whos = value; }
                get { return _whos; }
            }
            /// <summary>
            /// 创建日期
            /// </summary>
            public string datetime
            {
                set { _datetime = value; }
                get { return _datetime; }
            }
            /// <summary>
            /// 项目ID
            /// </summary>
            public string projectid
            {
                set { _projectid = value; }
                get { return _projectid; }
            }
            /// <summary>
            /// 部门ID
            /// </summary>
            public string partmentid
            {
                set { _partmentid = value; }
                get { return _partmentid; }
            }
            /// <summary>
            /// 专项资金ID
            /// </summary>
            public string specialFundsID
            {
                set { _specialFundsID = value; }
                get { return _specialFundsID; }
            }
            /// <summary>
            /// 预算报告ID
            /// </summary>
            public string Cash_SF_Order
            {
                set { _Cash_SF_Order = value; }
                get { return _Cash_SF_Order; }
            }
        }
    }
}
