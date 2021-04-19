using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Dianda.Web.Admin.personalProjectManage.OAapply
{
    public partial class orderSignet : System.Web.UI.UserControl
    {
        Dianda.COMMON.pageControl pageControl = new Dianda.COMMON.pageControl();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //显示印章种类
                ShowDDLInfo();
            }
        }

        /// <summary>
        /// 显示印章种类
        /// </summary>
        protected void ShowDDLInfo()
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "SELECT ID, SignetName FROM Project_SignetList WHERE DELFLAG = 0 ";

                dt = pageControl.doSql(sql).Tables[0];

                //ListItem li = new ListItem("-请选择-","");
                //DDL_Signet.Items.Add(li);

                if(dt.Rows.Count>0)
                {
                    for (int i = 0; i < dt.Rows.Count;i++ )
                    {
                        ListItem li1 = new ListItem(dt.Rows[i]["SignetName"].ToString(),dt.Rows[i]["ID"].ToString());
                        DDL_Signet.Items.Add(li1);
                    }
                }
            }
            catch
            {
 
            }
        }

        /// <summary>
        /// 返回用户所选择的印章种类
        /// </summary>
        public string orderSignetID
        {
            get
            {
                return DDL_Signet.SelectedValue;
            }
            set
            {
                DDL_Signet.SelectedValue = value;
            }

        }

        /// <summary>
        /// 返回敲章份数
        /// </summary>
        public string SignetNums
        {
            get
            {
                return TB_Signetnums.Text.ToString();
            }
            set
            {
                TB_Signetnums.Text = value;
            }

        }

        /// <summary>
        /// 返回上传的控件
        /// </summary>
        public FileUpload FileUp
        {
            get
            {
                return FileUpload1;
            }

            set
            {
                FileUpload1 = value;
            }
        }
    }
}