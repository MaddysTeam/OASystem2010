<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="show.aspx.cs" Inherits="Dianda.Web.Admin.userManager.OAgroupmanage.show" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%--<meta http-equiv="Pragma" content="no-cache" />--%>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <link href="/Admin/css/OACSS.css" rel="stylesheet" type="text/css" />
    <title>人员详细信息</title>
    <base target="_self" />
</head>

<body style="background-color:#99cccd">
    <form id="form1" runat="server">
    <div>
<table width="720" align="center" border="10" cellspacing="5" cellpadding="5">
  <tr style="background-color:#ffffff">
    <td>姓名：<asp:Label ID="Label_Name" runat="server" Text=""></asp:Label></td>
    <td>性别：<asp:Label ID="Label_SEX" runat="server" Text=""></asp:Label></td>
    <td>生日：<asp:Label ID="Label_BIRTHDAY" runat="server" Text=""></asp:Label></td>
    <td>籍贯：<asp:Label ID="Label_NativePlace" runat="server" Text=""></asp:Label></td>
  </tr>
  <tr style="background-color:#ffffff">
    <td>联系电话：<asp:Label ID="Label_TEL" runat="server" Text=""></asp:Label></td>
    <td>邮箱：<asp:Label ID="Label_EMAIL" runat="server" Text=""></asp:Label></td>
    <td  style="word-break: break-all; width:180px" >部门：<asp:Label ID="Label_DEPARTMENT" runat="server" Text=""></asp:Label></td>
    <td>状态：<asp:Label ID="Label_WorkStats" runat="server" Text=""></asp:Label></td> 
  </tr>
  <tr style="background-color:#ffffff">
    <td>移动电话：<asp:Label ID="Label_Temp1" runat="server" Text=""></asp:Label></td>
    <td>工作岗位：<asp:Label ID="Label_Station" runat="server" Text=""></asp:Label></td>
    <td>入职时间：<asp:Label ID="Label_DatesEmployed" runat="server" Text=""></asp:Label></td>
    <td>离职时间：<asp:Label ID="Label_LeaveDates" runat="server" Text=""></asp:Label></td> 
  </tr>
  <tr style="background-color:#ffffff">
    <td>学历：<asp:Label ID="Label_EducationLevel" runat="server" Text=""></asp:Label></td>
    <td>毕业学校：<asp:Label ID="Label_GraduateSchool" runat="server" Text=""></asp:Label></td>
    <td>专业：<asp:Label ID="Label_Major" runat="server" Text=""></asp:Label></td>
    <td>&nbsp;</td>
  </tr>
  <tr style="background-color:#ffffff">
    <td colspan="4">工作履历：<asp:Label ID="Label_TrackRecord" runat="server" Text=""></asp:Label></td>
  </tr>
</table>
    </div></form>
</body>
</html>
