<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GridView_PageSet.ascx.cs" Inherits="Dianda.Web.ascxManage.GridView_PageSet" %>
<table width="100%" id="table1" runat="server" visible="false">
    <tr>
        <td  class="noSelectStyle">
            <asp:LinkButton ID="LinkButton_Frist" runat="server" CssClass="<%$Resources:pageSet_res,linkbuttonCss%>"
                OnClick="LinkButton_Change_Click"></asp:LinkButton>
            <asp:LinkButton ID="LinkButton_Previous" runat="server" CssClass="<%$Resources:pageSet_res,linkbuttonCss%>"
                OnClick="LinkButton_Change_Click"></asp:LinkButton>
            <asp:LinkButton ID="LinkButton_Next" runat="server" CssClass="<%$Resources:pageSet_res,linkbuttonCss%>"
                OnClick="LinkButton_Change_Click"></asp:LinkButton>
            <asp:LinkButton ID="LinkButton_End" runat="server" CssClass="<%$Resources:pageSet_res,linkbuttonCss%>"
                OnClick="LinkButton_Change_Click"></asp:LinkButton>
            <asp:Label ID="Label_PageIndex" CssClass="<%$Resources:pageSet_res,pageNumsCss%>" runat="server"
                Text=""></asp:Label>
            <asp:Label ID="Label_All" runat="server" CssClass="<%$Resources:pageSet_res,pageNumsCss%>"
                Text=""></asp:Label>
            <asp:DropDownList ID="DropDownList_ChangPage" runat="server" OnSelectedIndexChanged="LinkButton_Change_Click"
                AutoPostBack="True">
            </asp:DropDownList>
        </td>
    </tr>
</table>