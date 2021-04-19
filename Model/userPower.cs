using System;
using System.Collections.Generic;
using System.Text;

namespace Dianda.Model
{
    /// <summary>
    /// 实体类用户的权限 
    /// </summary>
    [Serializable]
    public  class userPower
    {
        public userPower()
		{}
		#region Model
		private string _userid;
		private string _pageurl;
		private string _buttomID;
		private string _specialRole;
        private string _menuRole;
        private string _isYinLeader;
		/// <summary>
		/// 用户的ID
		/// </summary>
        public string userid
		{
            set { _userid = value; }
            get { return _userid; }
		}
		/// <summary>
		/// 页面的权限地址
		/// </summary>
        public string pageurl
		{
            set { _pageurl = value; }
            get { return _pageurl; }
		}
        /// <summary>
        /// 是否是用印管理的领导
        /// </summary>
        public string isYinLeader
        {
            set { _isYinLeader = value; }
            get { return _isYinLeader; }
        }
        /// <summary>
        /// 菜单的权限
        /// </summary>
        public string menuRole
        {
            set { _menuRole = value; }
            get { return _menuRole; }
        }
		/// <summary>
		/// 按钮的权限
		/// </summary>
        public string buttomID
		{
            set { _buttomID = value; }
            get { return _buttomID; }
		}
		/// <summary>
		/// 其它的权限
		/// </summary>
        public string specialRole
		{
            set { _specialRole = value; }
            get { return _specialRole; }
		}
		 
		#endregion Model

	}
}


