<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucshow.ascx.cs" Inherits="Dianda.Web.Admin.cashCardManage.ucshow" %>
<div>
    <table width="720" align="center" border="10" cellspacing="5" cellpadding="5">
        <tr style="background-color:#ffffff">
            <td align="center" colspan="2">
                <asp:Label ID="lblCardName" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr style="background-color:#ffffff">
            <td style=" width:100px">
                资金卡编号：
            </td>
            <td>
                <asp:Label ID="lblCardNum" runat="server" Text=""></asp:Label>
                &nbsp;
            </td>
        </tr>
        <tr style="background-color:#ffffff">
            <td>
                持卡人：
            </td>
            <td>
                <asp:Label ID="lblCardholderRealName" runat="server" Text=""></asp:Label>
                &nbsp;
            </td>
        </tr>
        <tr style="background-color:#ffffff">
            <td>
                所属部门：
            </td>
            <td>
                <asp:Label ID="lblDepartmentName" runat="server" Text=""></asp:Label>
                &nbsp;
            </td>
        </tr>
        <tr style="background-color:#ffffff">
            <td>
                所属项目：
            </td>
            <td>
                <asp:Label ID="lblProjectName" runat="server" Text=""></asp:Label>
                &nbsp;
            </td>
        </tr>
        <tr style="background-color:#ffffff">
            <td>
                初始金额：
            </td>
            <td>
                <asp:Label ID="lblLimitNums" runat="server" Text=""></asp:Label>
                &nbsp;
            </td>
        </tr>
        <tr style="background-color:#ffffff">
            <td>
                审批人：
            </td>
            <td>
                <asp:Label ID="lblApproverRealName" runat="server" Text=""></asp:Label>
                &nbsp;
            </td>
        </tr>
        <tr style="background-color:#ffffff">
            <td>
                状态：
            </td>
            <td>
                <asp:Label ID="lblStatas" runat="server" Text=""></asp:Label>
                &nbsp;
            </td>
        </tr>
    </table>
</div>
