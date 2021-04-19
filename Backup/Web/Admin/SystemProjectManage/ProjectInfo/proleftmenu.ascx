<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="proleftmenu.ascx.cs" Inherits="Dianda.Web.Admin.SystemProjectManage.ProjectInfo.proleftmenu" %>

<table cellpadding="0" cellspacing="0" border="0" width="100%">
<tr> 
                            <td align="left">
                               <img src="/Admin/images/OAimages/leftsideBar_top.jpg" style=" vertical-align:bottom"/>
                            </td>
                        </tr>
                            <div  runat="server" id="menu_ProjectList" visible="false">
                        <tr style="background:url(/Admin/images/OAimages/leftsideBar_bg.jpg); height:20px" id="form1_tr" onmouseover="chag_bg(1);" onmouseout="rest_bg(1);">
                            <td align="left">
                               <a href ="/Admin/SystemProjectManage/ProjectInfo/manage.aspx"  target="_self" class="master_a">项目信息</a>
                            </td>
                        </tr>
                         <tr style="background:url(/Admin/images/OAimages/leftsideBar_bg.jpg); height:20px"> 
                            <td align="left">
                            </td>
                        </tr></div>
                         <div  runat="server" id="menu_ProjectShenHe" visible="false">
                        <tr style="background:url(/Admin/images/OAimages/leftsideBar_bg.jpg); height:20px" id="form2_tr" onmouseover="chag_bg(2);" onmouseout="rest_bg(2);">
                            <td align="left">
                                <a href="/Admin/SystemProjectManage/ProjectCheck/manage.aspx"  target="_self" class="master_a">立项审核</a>
                            </td>
                        </tr>
                         <tr style="background:url(/Admin/images/OAimages/leftsideBar_bg.jpg); height:20px"> 
                            <td align="left">
                            </td>
                        </tr></div>
                        <div  runat="server" id="menu_ProjectColumns" visible="false">
                        <tr style="background:url(/Admin/images/OAimages/leftsideBar_bg.jpg); height:20px" id="form3_tr" onmouseover="chag_bg(3);" onmouseout="rest_bg(3);">
                            <td align="left">
                                <a href="/Admin/sysRights/projectColumns.aspx"  target="_self" class="master_a">项目分类/规划</a>
                            </td>
                        </tr>
                         <tr style="background:url(/Admin/images/OAimages/leftsideBar_bg.jpg); height:20px"> 
                            <td align="left">
                            </td>
                        </tr>
                        </div>
                          <div  runat="server" id="menu_systongji" visible="false">
                        <tr style="background:url(/Admin/images/OAimages/leftsideBar_bg.jpg); height:20px" id="form4_tr" onmouseover="chag_bg(4);" onmouseout="rest_bg(4);">
                            <td align="left">
                                <a href="/Admin/sysTongji/manager.aspx"  target="_self" class="master_a">项目汇总</a>
                            </td>
                        </tr>
                         </div>
                        <tr>
                            <td align="left">
                               <img src="/Admin/images/OAimages/leftsideBar_bot.jpg" />
                            </td>
                        </tr>
                       
                    </table>
                        
