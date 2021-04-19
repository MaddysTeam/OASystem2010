using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Serialization;


namespace Dianda.Web.Admin
{
    /// <summary>
    /// ajax 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class ajax : System.Web.Services.WebService
    {

        /// <summary>
        /// 远程更新用户数据 java web service
        /// </summary>
        /// <param name="model">用户实体类</param>
        /// <param name="enumOperation">操作类型枚举</param>
        /// <returns></returns>
        public int UpdateUserRemoteInfoWithJAVAWebService(Dianda.Model.USER_Users model, EnumRemoteOperation enumOperation)
        {
            UserInfoEntity userInfo = new UserInfoEntity();
            userInfo.id = model.ID.ToString();
            userInfo.ename = model.USERNAME;
            userInfo.pwd = model.PASSWORD;
            userInfo.realname = model.REALNAME;
            userInfo.sex = model.SEX;
            userInfo.email = model.EMAIL;
            userInfo.idcard = "12345";
            userInfo.birthday = model.BIRTHDAY;
            userInfo.tele = model.TEL;
            userInfo.address = model.ADDRESS;
            userInfo.post = "";
            userInfo.districtid = "";
            userInfo.schoolid = "";
            userInfo.edulevelcode = "";
            userInfo.subjectcode = "";
            userInfo.gradecode = "";
            userInfo.delflag = model.DELFLAG.ToString();
            object[] args = new object[1];
            args[0] = RemoteWebservice.SerializeObject(userInfo);
            JAVAUserServicePort.UserServiceDelegateClient client = new JAVAUserServicePort.UserServiceDelegateClient();
            switch (enumOperation)
            {
                case EnumRemoteOperation.Import:
                    client.importUser((new JavaScriptSerializer()).Serialize(userInfo));
                    break;
                case EnumRemoteOperation.Edit:

                    client.editUser((new JavaScriptSerializer()).Serialize(userInfo));
                    break;


            }
            return 1;
        }


        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }




    }



    public enum EnumRemoteOperation
    {
        Import = 1,
        Edit = 2
    }


    [Serializable]
    public class UserInfoEntity
    {
        public string id { get; set; }
        public string ename { get; set; }
        public string pwd { get; set; }
        public string realname { get; set; }
        public string sex { get; set; }
        public string email { get; set; }
        public string idcard { get; set; }
        public string birthday { get; set; }
        public string tele { get; set; }
        public string address { get; set; }
        public string post { get; set; }
        public string districtid { get; set; }
        public string schoolid { get; set; }
        public string edulevelcode { get; set; }
        public string subjectcode { get; set; }
        public string gradecode { get; set; }
        public string departcode { get; set; }
        public string roleid { get; set; }
        public string positioncode { get; set; }
        public string delflag { get; set; }
    }

}
