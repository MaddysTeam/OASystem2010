<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OAleftmenu.ascx.cs" Inherits="Dianda.Web.OAleftmenu" %>
    
<table cellpadding="0" cellspacing="0" border="0" width="100%">
<tr> 
                            <td align="left">
                               <img src="/Admin/images/OAimages/leftsideBar_top.jpg" style=" vertical-align:bottom"/>
                            </td>
                        </tr>
                        <tr style="background:url(/Admin/images/OAimages/leftsideBar_bg.jpg); height:20px" id="form1_tr" onmouseover="chag_bg(1);" onmouseout="rest_bg(1);">
                            <td align="left">
                                <a href="/Admin/userManager/OAusersmanage/manage.aspx"  target="_self" class="master_a">人员管理</a>
                            </td>
                        </tr>
                         <tr style="background:url(/Admin/images/OAimages/leftsideBar_bg.jpg); height:20px"> 
                            <td align="left">
                            </td>
                        </tr>
                        <tr style="background:url(/Admin/images/OAimages/leftsideBar_bg.jpg); height:20px" id="form2_tr" onmouseover="chag_bg(2);" onmouseout="rest_bg(2);">
                            <td align="left">
                               <a href ="/Admin/userManager/OAgroupmanage/manage.aspx?tags=部门"  target="_self" class="master_a">部门管理</a>
                            </td>
                        </tr>
                        <tr style="background:url(/Admin/images/OAimages/leftsideBar_bg.jpg); height:20px"> 
                            <td align="left">
                            </td>
                        </tr>
                        <tr style="background:url(/Admin/images/OAimages/leftsideBar_bg.jpg); height:20px" id="form3_tr" onmouseover="chag_bg(3);" onmouseout="rest_bg(3);">
                            <td align="left">
                                <a href ="/Admin/userManager/OAgroupmanage/manage.aspx?tags=岗位"  target="_self" class="master_a">岗位管理</a>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                               <img src="/Admin/images/OAimages/leftsideBar_bot.jpg" />
                            </td>
                        </tr>
                    </table>
                        
