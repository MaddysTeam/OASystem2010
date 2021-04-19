using System;
namespace Dianda.Model
{
	/// <summary>
	/// 实体类TEST_question 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class SessionUser
	{
        public SessionUser()
		{}   
		#region Model
		private string _USERNAME;//用户名的SESSION
		private string _REALNAME;//用户的真实姓名
		private string _USERID;//用户ID的SESSION
		private string _Role_NUM;//用户的身份SESSION 1表示"主持教师",2表示"面授教师",3表示"班主任",4表示"课程学习者",5表示"自由学习者";
        private string _SF;//1表示学生；2表示教师
        private string _PPN;//用户的通行证编号
        private string _COURSEID;//用户当前所在的课程的ID
        private string _CLASSID;//用户的班级名称
        private string _CLASSID_ID;//用户的班级ID
        private string _XUEQI;//工作学期
        private string _UNITID;//单位代码
        private string _GRADE;//年级
        private string _JHID;//计划id
        private string _MAJORTYPE;//专业类别

        private string _COURSENAME;//用户当前所在的课程的名称

		/// <summary>
        ///用户名的SESSION
		/// </summary>
        public string USERNAME
		{
            set { _USERNAME = value; }
            get { return _USERNAME; }
		}
        /// <summary>
        ///学期的SESSION
        /// </summary>
        public string XUEQI
        {
            set { _XUEQI = value; }
            get { return _XUEQI; }
        }
		/// <summary>
        ///用户的真实姓名
		/// </summary>
        public string REALNAME
		{
            set { _REALNAME = value; }
            get { return _REALNAME; }
		}
		/// <summary>
        /// 用户ID的SESSION
		/// </summary>
        public string USERID
		{
            set { _USERID = value; }
            get { return _USERID; }
		}
        /// <summary>
        /// //用户的身份SESSION 1表示"主持教师",2表示"面授教师",3表示"班主任",4表示"课程学习者",5表示"自由学习者";
        /// </summary>
        public string Role_NUM
        {
            set { _Role_NUM = value; }
            get { return _Role_NUM; }
        }
        /// <summary>
        /// 1表示学生；2表示教师
        /// </summary>
        public string SF
        {
            set { _SF = value; }
            get { return _SF; }
        }
        /// <summary>
        /// /用户的通行证编号
        /// </summary>
        public string PPN
        {
            set { _PPN = value; }
            get { return _PPN; }
        }
        /// <summary>
        /// 用户当前所在的课程的ID
        /// </summary>
        public string COURSEID
        {
            set { _COURSEID = value; }
            get { return _COURSEID; }
        }
        /// <summary>
        /// 用户当前所在的课程的名称
        /// </summary>
        public string COURSENAME
        {
            set { _COURSENAME = value; }
            get { return _COURSENAME; }
        }
        /// <summary>
        /// 用户的班级名称
        /// </summary>
        public string CLASSID
        {
            set { _CLASSID = value; }
            get { return _CLASSID; }
        }
        /// <summary>
        /// 用户的班级ID
        /// </summary>
        public string CLASSID_ID
        {
            set { _CLASSID_ID = value; }
            get { return _CLASSID_ID; }
        }
        /// <summary>
        /// 单位代码
        /// </summary>
        public string UNITID
        {
            set { _UNITID = value; }
            get { return _UNITID; }
        }
        /// <summary>
        /// 年级
        /// </summary>
        public string GRADE
        {
            set { _GRADE = value; }
            get { return _GRADE; }
        }
        /// <summary>
        /// 计划id
        /// </summary>
        public string JHID
        {
            set { _JHID = value; }
            get { return _JHID; }
        }
        /// <summary>
        /// 专业类别
        /// </summary>
        public string MAJORTYPE
        {
            set { _MAJORTYPE = value; }
            get { return _MAJORTYPE; }
        }
		#endregion Model

	}
}

