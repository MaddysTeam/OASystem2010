using System;
namespace Dianda.Model
{
	/// <summary>
	/// ʵ����TEST_question ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class SessionUser
	{
        public SessionUser()
		{}   
		#region Model
		private string _USERNAME;//�û�����SESSION
		private string _REALNAME;//�û�����ʵ����
		private string _USERID;//�û�ID��SESSION
		private string _Role_NUM;//�û������SESSION 1��ʾ"���ֽ�ʦ",2��ʾ"���ڽ�ʦ",3��ʾ"������",4��ʾ"�γ�ѧϰ��",5��ʾ"����ѧϰ��";
        private string _SF;//1��ʾѧ����2��ʾ��ʦ
        private string _PPN;//�û���ͨ��֤���
        private string _COURSEID;//�û���ǰ���ڵĿγ̵�ID
        private string _CLASSID;//�û��İ༶����
        private string _CLASSID_ID;//�û��İ༶ID
        private string _XUEQI;//����ѧ��
        private string _UNITID;//��λ����
        private string _GRADE;//�꼶
        private string _JHID;//�ƻ�id
        private string _MAJORTYPE;//רҵ���

        private string _COURSENAME;//�û���ǰ���ڵĿγ̵�����

		/// <summary>
        ///�û�����SESSION
		/// </summary>
        public string USERNAME
		{
            set { _USERNAME = value; }
            get { return _USERNAME; }
		}
        /// <summary>
        ///ѧ�ڵ�SESSION
        /// </summary>
        public string XUEQI
        {
            set { _XUEQI = value; }
            get { return _XUEQI; }
        }
		/// <summary>
        ///�û�����ʵ����
		/// </summary>
        public string REALNAME
		{
            set { _REALNAME = value; }
            get { return _REALNAME; }
		}
		/// <summary>
        /// �û�ID��SESSION
		/// </summary>
        public string USERID
		{
            set { _USERID = value; }
            get { return _USERID; }
		}
        /// <summary>
        /// //�û������SESSION 1��ʾ"���ֽ�ʦ",2��ʾ"���ڽ�ʦ",3��ʾ"������",4��ʾ"�γ�ѧϰ��",5��ʾ"����ѧϰ��";
        /// </summary>
        public string Role_NUM
        {
            set { _Role_NUM = value; }
            get { return _Role_NUM; }
        }
        /// <summary>
        /// 1��ʾѧ����2��ʾ��ʦ
        /// </summary>
        public string SF
        {
            set { _SF = value; }
            get { return _SF; }
        }
        /// <summary>
        /// /�û���ͨ��֤���
        /// </summary>
        public string PPN
        {
            set { _PPN = value; }
            get { return _PPN; }
        }
        /// <summary>
        /// �û���ǰ���ڵĿγ̵�ID
        /// </summary>
        public string COURSEID
        {
            set { _COURSEID = value; }
            get { return _COURSEID; }
        }
        /// <summary>
        /// �û���ǰ���ڵĿγ̵�����
        /// </summary>
        public string COURSENAME
        {
            set { _COURSENAME = value; }
            get { return _COURSENAME; }
        }
        /// <summary>
        /// �û��İ༶����
        /// </summary>
        public string CLASSID
        {
            set { _CLASSID = value; }
            get { return _CLASSID; }
        }
        /// <summary>
        /// �û��İ༶ID
        /// </summary>
        public string CLASSID_ID
        {
            set { _CLASSID_ID = value; }
            get { return _CLASSID_ID; }
        }
        /// <summary>
        /// ��λ����
        /// </summary>
        public string UNITID
        {
            set { _UNITID = value; }
            get { return _UNITID; }
        }
        /// <summary>
        /// �꼶
        /// </summary>
        public string GRADE
        {
            set { _GRADE = value; }
            get { return _GRADE; }
        }
        /// <summary>
        /// �ƻ�id
        /// </summary>
        public string JHID
        {
            set { _JHID = value; }
            get { return _JHID; }
        }
        /// <summary>
        /// רҵ���
        /// </summary>
        public string MAJORTYPE
        {
            set { _MAJORTYPE = value; }
            get { return _MAJORTYPE; }
        }
		#endregion Model

	}
}

