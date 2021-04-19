<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="showMessageDetail.aspx.cs"
    Inherits="Dianda.Web.Admin.cashCardManage.showMessageDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <base target="_self" />
    <meta http-equiv="Pragma" content="no-cache">
    <meta http-equiv="Cache-Control" content="no-cache">
    <meta http-equiv="Expires" content="0">
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="720" align="center" border="5" cellspacing="0" cellpadding="5">
            <tr>
                <td style="width: 100px">
                    资金卡名称：
                </td>
                <td>
                    <asp:Label ID="lblCardName" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    持卡人：
                </td>
                <td>
                    <asp:Label ID="lblCardholderRealName" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    所属部门：
                </td>
                <td>
                    <asp:Label ID="lblDepartmentName" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    所属项目：
                </td>
                <td>
                    <asp:Label ID="lblProjectName" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    初始金额：
                </td>
                <td>
                    <asp:Label ID="lblLimitNums" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    审批人：
                </td>
                <td>
                    <asp:Label ID="lblApproverRealName" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    通知时间：
                </td>
                <td>
                    <asp:Label ID="lblDATETIME" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    阅读状态：
                </td>
                <td>
                    <asp:Label ID="lblIsRead" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    阅读时间：
                </td>
                <td>
                    <asp:Label ID="lblReadTime" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    阅读者：
                </td>
                <td>
                    <asp:Label ID="lblDoUserID" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    备注说明：
                </td>
                <td>
                    <asp:TextBox ID="txtDoNotes" runat="server" TextMode="MultiLine" Height="100px" Width="456px"
                        MaxLength="800"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="Button_sumbit" runat="server" Text="已阅" OnClick="Button_sumbit_Click"
                        CssClass="button1" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button_cancel"
                            runat="server" Text="返回" CssClass="button1" OnClick="Button_cancel_Click" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
