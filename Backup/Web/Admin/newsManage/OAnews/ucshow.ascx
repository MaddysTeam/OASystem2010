<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucshow.ascx.cs" Inherits="Dianda.Web.Admin.newsManage.OAnews.ucshow" %>
<div>
    <table width="98%" align="center" border="0" cellspacing="0" cellpadding="5">
        <tr style="background-color: #ffffff">
            <td align="center">
                <asp:Label ID="Label_NAME" runat="server" Text="" Font-Size="Larger" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr style="background-color: #ffffff">
            <td align="center" style="font-size: small;">
                <asp:Label ID="lblWriter" runat="server" Text=""></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblTime"
                    runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr style="background-color: #ffffff">
            <td align="center">
                <hr />
            </td>
        </tr>
        <tr style="background-color: #ffffff">
            <td style="height:312px;" valign="top">
              <div style="word-break:break-all;width:700px;white-space:normal; width:680px;"><asp:Label ID="Label_CONTENTS" runat="server" Text="" ></asp:Label></div>
            </td>
        </tr>
    </table>
</div>
