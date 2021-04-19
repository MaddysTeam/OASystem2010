using System;
using System.Collections.Generic;
using System.Text;

namespace Dianda.BLL
{
    /// <summary>
    /// 访问日志的扩展方法集合
    /// </summary>
  public  class SYS_LogsExt
    {
      Model.SYS_LOGS mlogs = new Dianda.Model.SYS_LOGS();
      BLL.SYS_LOGS blogs = new SYS_LOGS();
      COMMON.common commons = new Dianda.COMMON.common();

      /// <summary>
      /// 将当前用户的操作记录到日志表中
      /// </summary>
      /// <param name="userinfo">用户的姓名+（用户名）</param>
      /// <param name="doType">用户的操作类型</param>
      /// <param name="results">用户的操作结果</param>
      public void addlogs(string userinfo,string doType,string results)
      {
          try
          {
              mlogs.DATETIME = DateTime.Now;
              mlogs.DELFLAG = 0;
              mlogs.DOTYPE = doType;
              mlogs.IP = commons.GetClientIpAddress("xy");
              mlogs.RESULT = results;
              mlogs.USERINFO = userinfo;
              blogs.Add(mlogs);
          }
          catch
          {
          }
      }
    }
}
