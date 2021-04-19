using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Dianda.BLL
{
  public  class Project_ProjectsExt
    {
      Model.Project_Projects mProjcet = new Dianda.Model.Project_Projects();
      BLL.Project_Projects bProject = new Project_Projects();
      COMMON.common commonss = new Dianda.COMMON.common();
      COMMON.pageControl PageControl = new Dianda.COMMON.pageControl();
      /// <summary>
      /// 根据项目的ID获取到当前项目下的一些功能按钮是否可以使用
      /// false表示不可用，true表示可以用
      /// </summary>
      /// <param name="projectid"></param>
      /// <returns></returns>
      public bool  ProjectStatus(string projectid)
      {
          bool coutw = false;
          try
          {
              projectid = commonss.RequestSafeString(projectid, 50);
              mProjcet = bProject.GetModel(int.Parse(projectid));
              if (mProjcet.Status == 1 && mProjcet.DELFLAG==0)
              {
                  coutw = true;
              }
          }
          catch
          {
              coutw = false;
          }
          return coutw;
      }
      /// <summary>
      /// 根据项目的ID获取到当前项目的状态名称
      /// </summary>
      /// <param name="projectid"></param>
      /// <returns></returns>
      public string getProjectStautsName(string projectid)
      {
          string coutw = "垃圾箱中";
          try
          {
              projectid = commonss.RequestSafeString(projectid, 50);
              mProjcet = bProject.GetModel(int.Parse(projectid));
              if (mProjcet.DELFLAG == 1)
              {
                  coutw = "已删除";
              }
              else
              {
                  if (mProjcet.Status == 1)
                  {
                      coutw = "运行中";
                  }
                  else if (mProjcet.Status == 0)
                  {
                      coutw = "待审核";
                  }
                  else if (mProjcet.Status ==2)
                  {
                      coutw = "审核不通过";
                  }
                  else if (mProjcet.Status == 3)
                  {
                      coutw = "暂停中";
                  }
                  else if (mProjcet.Status == 4)
                  {
                      coutw = "草稿箱中";
                  }
                  else if (mProjcet.Status == 5)
                  {
                      coutw = "已完成";
                  }
                  else
                  {
                      coutw = "垃圾箱中";
                  }
              }
          }
          catch
          {
              coutw ="项目异常";
          }
          return coutw;
      }

      /// <summary>
      /// 根据条件删除表中的数据
      /// </summary>
      /// <param name="sqlwhere">删除的条件</param>
      /// <param name="tableName">删除的表名</param>
      public void DeleteTableData(string sqlwhere,string tableName)
      {
          try
          {
              string sql = " UPDATE " + tableName + " SET DELFLAG=1 WHERE " + sqlwhere;
              PageControl.doSql(sql);
          }
          catch
          { }
      }

    }
}
