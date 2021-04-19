<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="orderSignet.ascx.cs" Inherits="Dianda.Web.Admin.personalProjectManage.OAapply.orderSignet" %>

<table border="0" cellpadding="0" cellspacing="0" width="100%" bgcolor="#99CCCD">
    <tr>
        <td align="center"  Width="60">印章种类：</td>
        <td align="left" valign="middle">
            <asp:DropDownList ID="DDL_Signet" runat="server" Width="120">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="center">敲章份数：</td>
        <td><asp:TextBox ID="TB_Signetnums" runat="server" Width="120"></asp:TextBox>&nbsp;&nbsp;份&nbsp;&nbsp;<asp:Label ID="LB_notice" runat="server" Text="敲章份数只能输入大于0的数字！" ForeColor="Red"></asp:Label></td>
    </tr>
    <tr>
        <td align="center">上传附件：</td>
        <td><asp:FileUpload ID="FileUpload1" runat="server" style="width:190px; height:20px;"/></td>
    </tr>
</table>

