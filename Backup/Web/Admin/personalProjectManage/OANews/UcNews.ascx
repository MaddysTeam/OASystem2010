<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcNews.ascx.cs" Inherits="Dianda.Web.Admin.personalProjectManage.OANews.UcNews" %>
<table cellpadding="0" cellspacing="0" border="0" width="100%">
    <tr>
        <td align="left">
            <img src="/Admin/images/OAimages/leftsideBar_top.jpg" style="vertical-align: bottom" />
        </td>
    </tr>
    <tr style="background: url(/Admin/images/OAimages/leftsideBar_bg.jpg); height: 20px"
        id="form1_tr" onmouseover="chag_bg(1);" onmouseout="rest_bg(1);">
        <td align="left">
            <asp:LinkButton ID="Button_Send" runat="server" Text="发件箱" CssClass="master_a" OnClick="Button_Send_Click"></asp:LinkButton>
        </td>
    </tr>
    <tr style="background: url(/Admin/images/OAimages/leftsideBar_bg.jpg); height: 20px">
        <td align="left">
        </td>
    </tr>
    <tr style="background: url(/Admin/images/OAimages/leftsideBar_bg.jpg); height: 20px"
        id="form2_tr" onmouseover="chag_bg(2);" onmouseout="rest_bg(2);">
        <td align="left">
            <asp:LinkButton ID="Button_Receive" runat="server" Text="收件箱" CssClass="master_a"
                OnClick="Button_Receive_Click"></asp:LinkButton>
        </td>
    </tr>
    <tr>
        <td align="left">
            <img src="/Admin/images/OAimages/leftsideBar_bot.jpg" />
        </td>
    </tr>
</table>