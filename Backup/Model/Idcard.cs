using System;
using System.Collections.Generic;
using System.Text;

namespace Dianda.Model
{
   public class Idcard
    {
       public Idcard()
		{}   
		#region Model
		private string _Province;//省级单位
		private string _City;//市级单位
		private string _Sex;//性别
		private string _Birthday;//出生年月日
      

		/// <summary>
        ///省级单位
		/// </summary>
        public string Province
		{
            set { _Province = value; }
            get { return _Province; }
		}
        /// <summary>
        ///市级单位
        /// </summary>
        public string City
        {
            set { _City = value; }
            get { return _City; }
        }
		/// <summary>
        ///性别
		/// </summary>
        public string Sex
		{
            set { _Sex = value; }
            get { return _Sex; }
		}
		/// <summary>
        /// 出生年月日
		/// </summary>
        public string Birthday
		{
            set { _Birthday = value; }
            get { return _Birthday; }
		}
		#endregion Model

    }
}
