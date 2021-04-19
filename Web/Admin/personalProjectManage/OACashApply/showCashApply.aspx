<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="showCashApply.aspx.cs"
    Inherits="Dianda.Web.Admin.personalProjectManage.OACashApply.showCashApply" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../css/OACSS.css" rel="stylesheet" type="text/css" />
</head>
<body style="background-color: #99cccd">
    <form id="form1" runat="server">
    <div>
        <table width="720" align="center" border="10" cellspacing="5" cellpadding="5">
            <tr style="background-color: #ffffff">
                <td>
                    申请人：<asp:Label ID="lblApplierRealName" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    金额：<asp:Label ID="lblApplyCount" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    项目：<asp:Label ID="lblProjectName" runat="server" Text=""></asp:Label>
                </td>
               
            </tr>
            <tr style="background-color: #ffffff">
                <td>
                    领取预约时间：<asp:Label ID="lblGetDateTime" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    资金卡：<asp:Label ID="lblCardName" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    用途：<asp:Label ID="lblUseFor" runat="server" Text=""></asp:Label>
                </td>
             
            </tr>
            <tr style="background-color: #ffffff">
                <td>
                    联系方式：<asp:Label ID="lblApplierTel" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    申请时间：<asp:Label ID="lblDATETIME" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    状态：<asp:Label ID="lblStatas" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
