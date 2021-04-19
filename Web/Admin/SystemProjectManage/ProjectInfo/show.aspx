<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="show.aspx.cs" Inherits="Dianda.Web.Admin.SystemProjectManage.ProjectInfo.show" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <link href="/Admin/css/OACSS.css" rel="stylesheet" type="text/css" />
    <title>业务申请详细信息</title>
</head>

<body style="background-color:#99cccd">
    <form id="form1" runat="server">
    <div id="Info" runat="server">
<table width="98%" align="center" border="0" cellspacing="5" cellpadding="5">
  <tr style="background-color:#ffffff">
    <td>项目名称：<asp:Label ID="Label_ProjectName" runat="server" Text=""></asp:Label></td>
    <td>项目状态：<asp:Label ID="Label_Status" runat="server" Text=""></asp:Label></td>
    <td>负责人：<asp:Label ID="Label_LeaderID" runat="server" Text=""></asp:Label></td>
    <td>预计经费：<asp:Label ID="Label_CashTotal" runat="server" Text=""></asp:Label></td>
  </tr>
  <tr style="background-color:#ffffff">
    <td>申请人：<asp:Label ID="Label_SendUserID" runat="server" Text=""></asp:Label></td>
     <td>申请时间：<asp:Label ID="Label_DATETIME" runat="server" Text=""></asp:Label></td> 
     <td>预计开始时间：<asp:Label ID="Label_StartTime" runat="server" Text=""></asp:Label></td>
     <td>预计结束时间：<asp:Label ID="Label_EndTime" runat="server" Text=""></asp:Label></td>
  </tr>
    <tr style="background-color:#ffffff">
    <td colspan="4">
    所属规化/总项目：<asp:Label ID="Lab_ColNames" runat="server"></asp:Label><br />
    项目概要：<asp:Label ID="Label_Overviews" runat="server" Text=""></asp:Label></td>
  </tr>
     <tr style="background-color:#ffffff">
      <td>资金卡：<asp:Label ID="Label_CashCardID" runat="server" Text=""></asp:Label></td>
    <td colspan="3">参与部门：<asp:Label ID="Label_DepartmentID" runat="server" Text=""></asp:Label></td>
  </tr>
  <tr style="background-color:#ffffff">
    <td>审核人：<asp:Label ID="Label_DoUserID" runat="server" Text=""></asp:Label></td>
    <td>审核时间：<asp:Label ID="Label_ReadTime" runat="server" Text=""></asp:Label></td>
    <td  runat="server" id="td_note">审核意见：<asp:Label ID="Label_DoNote" runat="server" Text=""></asp:Label></td>
    <td align="center" runat="server" id="td_fj"><asp:Label ID="LB_fj" runat="server" Text=""></asp:Label></td>
  </tr>
</table>
    </div></form>
</body>
</html>