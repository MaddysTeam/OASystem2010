using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Xml;
using System.Configuration;

namespace Dianda.COMMON
{
    public class sysInformation
    {
        /// <summary>
        /// lev 是调用配置文件时，该文件的相对位置，用../../../表示
        /// </summary>
        /// <param name="lev"></param>
        /// <returns></returns>
        public DataTable getInfo(string lev)
        {
            try
            {
                string xmlurl = System.Configuration.ConfigurationSettings.AppSettings["sysInforUrl"];//获取到配置文件的地址
            
                COMMON.XmlOp _XmlOp = new COMMON.XmlOp(xmlurl);
                DataSet DS = new DataSet();
                DS = _XmlOp.GetDs("channel");
                DataTable dt = DS.Tables[0];
                return dt;
            }
            catch
            {
                return null;
            }
        }
        public bool modiy(string lev, string[] nodeName, string[] nodeValue)
        {
            bool coutw = false;
            try
            {
                string xmlurl = System.Configuration.ConfigurationSettings.AppSettings["sysInforUrl"];//获取到配置文件的地址
                
                COMMON.XmlOp _XmlOp = new COMMON.XmlOp(xmlurl);
                coutw = _XmlOp.UpdateNode("//channel/item[ID='1']", nodeName, nodeValue);
                _XmlOp.Save(xmlurl);   //保存Xml文档
                return coutw;


            }
            catch
            {
                return coutw;
            }
        }
    }
}

