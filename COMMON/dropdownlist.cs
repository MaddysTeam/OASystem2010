using System;
using System.Collections.Generic;
using System.Web;
using System.Xml;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Dianda.COMMON
{
   public class dropdownlist
    {
        public dropdownlist()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        /// <summary>
        /// 把数据集中的数据赋值给一个下拉框
        /// 如果fromNode为空，则是全部赋值，如果不为空，则从该节点一下赋值
        /// </summary>
        /// <param name="dataTables"></param>
        /// <param name="dropDownLists"></param>
        /// <param name="fromNode"></param>
        public void MakeDropDownList(DataTable dataTables, DropDownList dropDownListssss, string fromNode)
        {
            try
            {
                //对传进来的数据集进行格式化（变成有承继关系的数据集）
                DataTable newdt = MakeDataTablePath(dataTables, fromNode);

                dropDownListssss.DataSource = newdt;
                dropDownListssss.DataTextField = "title";
                dropDownListssss.DataValueField = "identifier";
                dropDownListssss.DataBind();
            }
            catch
            {

            }
        }
        /// <summary>
        /// 把数据集中到FROMNODE节点的数据截取出来
        /// 如果FROMNODE=“”则表示全部截取
        /// </summary>
        /// <param name="dataTables"></param>
        /// <param name="coloumsID"></param>
        /// <returns></returns>
        public DataTable MakeDataTablePath(DataTable dataTables, string fromNode)
        {
            DataTable dt = dataTables.Copy();
            try
            {
                int i = dt.Rows.Count;
                int m = dt.Columns.Count;

                DataColumn newColumn = new DataColumn();
                newColumn = dt.Columns.Add("item_Lev", Type.GetType("System.String"));
                newColumn.AllowDBNull = true;
                newColumn.MaxLength = 50;
                newColumn.DefaultValue = "";


                string selectFromNodeLev = "";//筛选的节点Lev
                string deleteNodeLev = "";//被删除的节点的lev


                //先将传进来的数据集整理成有层次结构的数据
                for (int k = 0; k < i; k++)
                {
                    for (int j = 0; j < i; j++)
                    {
                        string oldeers = dt.Rows[k]["item_Id_0"].ToString();
                        string oldeers_temp = dataTables.Rows[j]["item_Id"].ToString();
                        if (oldeers == "" || oldeers == null)//对于一级的节点
                        {
                            dt.Rows[k]["item_Lev"] = "/" + dt.Rows[k]["item_Id"].ToString() + "/";
                        }
                        if (oldeers == oldeers_temp)
                        {
                            string rj = dt.Rows[j]["item_Id_0"].ToString();
                            string rk = dt.Rows[k]["item_Id_0"].ToString();
                            TableCell tc = new TableCell();
                            dt.Rows[k]["item_Lev"] = dt.Rows[j]["item_Lev"].ToString() + dt.Rows[k]["item_Id"].ToString() + "/";
                        }
                    }
                    string item_LevString = dt.Rows[k]["item_Lev"].ToString();
                    string[] arrays = item_LevString.Split('/');//把LEV切开，看看有多少级，然后构造TITLE的名称

                    string kg = null;
                    for (int cc = 0; cc < arrays.Length; cc++)
                    {
                        kg += "　";
                    }
                    dt.Rows[k]["title"] = kg + "|--" + dt.Rows[k]["title"].ToString();


                    if (fromNode != null && fromNode != "")//如果有节点的筛选工作
                    {
                        if (dt.Rows[k]["identifier"].ToString() == fromNode)
                        {
                            selectFromNodeLev = "item_Lev like '" + dt.Rows[k]["item_Lev"].ToString() + "%'";
                        }
                    }
                    if (dt.Rows[k]["isvisible"].ToString().ToLower() == "false")//被删除的节点
                    {
                        deleteNodeLev = deleteNodeLev + "," + dt.Rows[k]["item_Lev"].ToString();
                    }

                }

                //先将传进来的数据集整理成有层次结构的数据

                //再对该数据集中 isvisible=false的做不显示操作，并且根据开始节点的identifier值，显示数据集合中的一部分

                string[] deletNodeArray = deleteNodeLev.Split(',');
                string deletString = "";
                for (int ee = 0; ee < deletNodeArray.Length; ee++)
                {
                    if (deletNodeArray[ee].ToString() != "" && deletNodeArray[ee].ToString() != null)
                    {
                        if (ee != deletNodeArray.Length - 1)
                        {
                            deletString = deletString + " item_Lev not like '" + deletNodeArray[ee].ToString() + "%'   and ";
                        }
                        else
                        {
                            deletString = deletString + " item_Lev not like '" + deletNodeArray[ee].ToString() + "%'";
                        }
                    }
                }
                if (deletString.Length > 2 && selectFromNodeLev.Length > 2)
                {
                    deletString = " and (" + deletString + ")";
                }
                else if (selectFromNodeLev.Length == 0 && deletString.Length > 2)
                {
                    deletString = deletString;
                }
 
                DataView dv = new DataView();
                dv = dt.DefaultView;
                dv.RowFilter = selectFromNodeLev + deletString;
                dt = dv.ToTable();

                //再对该数据集中 isvisible=false的做不显示操作，并且根据开始节点的identifier值，显示数据集合中的一部分
            }
            catch
            {
                
            }
            return dt;
        }
    }
}