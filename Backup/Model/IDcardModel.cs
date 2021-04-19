using System;
using System.Text;

namespace Dianda.Model
{
   public class IDcardModel
    {

       public IDcardModel()
		{}   
		#region Model
		private string _ADDRESS;//出身地
		private string _BIRTHDAY;//出生日期
		private string _AGE;//年龄
		private string _SEX;//性别;
       
		/// <summary>
        ///出身地
		/// </summary>
        public string ADDRESS
		{
            set { _ADDRESS = value; }
            get { return _ADDRESS; }
		}
        /// <summary>
        ///出生日期
        /// </summary>
        public string BIRTHDAY
        {
            set { _BIRTHDAY = value; }
            get { return _BIRTHDAY; }
        }
		/// <summary>
        ///年龄
		/// </summary>
        public string AGE
		{
            set { _AGE = value; }
            get { return _AGE; }
		}
		/// <summary>
        /// 性别;
		/// </summary>
        public string SEX
		{
            set { _SEX = value; }
            get { return _SEX; }
		}
		#endregion Model

	}
}

