<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="show.aspx.cs" Inherits="Dianda.Web.Admin.personalProjectManage.OAapply.show" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="/Admin/css/OACSS.css" rel="stylesheet" type="text/css" />
    <title>业务申请详细信息</title>
</head>
<body style="background-color: #99cccd">
    <form id="form1" runat="server">
    <div id="Info" runat="server">
        <table width="720" align="center" border="0" cellspacing="1" cellpadding="1">
            <tr runat="server" id="showinfo">
                <td>
                    <table width="100%" align="center" border="10" cellspacing="5" cellpadding="5">
                        <tr style="background-color: #ffffff">
                            <td>
                                所属项目：<asp:Label ID="Label_ProjectName" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                                业务类型：<asp:Label ID="Label_AppType" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                                申请状态：<asp:Label ID="Label_Status" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                               <asp:Label ID="Label_DATETIME" runat="server" Text="申请时间："></asp:Label> 
                            </td>
                        </tr>
                        <tr style="background-color: #ffffff">
                            <td>
                                申请人：<asp:Label ID="Label_SendUserID" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                                申请部门：<asp:Label ID="Label_DEPARTMENT" runat="server" Text=""></asp:Label>
                            </td>
                            <td id="td_address" runat="server">
                                预定要求：<asp:Label ID="Label1_Adress" runat="server" Text=""></asp:Label>
                            </td>
                            <td id="td_1" runat="server" >
                                联系电话：<asp:Label ID="Label_TelNum" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr style="background-color: #ffffff"  runat="server" id="tr_userTime">
                            <td colspan="4">
                                详细信息：<asp:Label ID="Label_userTime" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr style="background-color: #ffffff">
                            <td colspan="4">
                                用途描述：<asp:Label ID="Label_Overviews" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr style="background-color: #ffffff">
                            <td>
                                审核人：<asp:Label ID="Label_DoUserID" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                                审核时间：<asp:Label ID="Label_ReadTime" runat="server" Text=""></asp:Label>
                            </td>
                            <td >
                                 <asp:Label ID="LB_ZXR" runat="server" Text=""></asp:Label>
                            </td>
                            <td >
                                 <asp:Label ID="LB_ZXSJ" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr style="background-color: #ffffff">
                            <td colspan="4">
                                审核意见：<asp:Label ID="Label_DoNote" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Label ID="notice" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
