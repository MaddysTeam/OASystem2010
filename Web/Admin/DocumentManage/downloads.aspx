<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/OAmaster.Master" AutoEventWireup="true" CodeBehind="downloads.aspx.cs" Inherits="Dianda.Web.Admin.DocumentManage.downloads" %>
<%@ Register Src="fileslist.ascx" TagName="fileslist" TagPrefix="uc1" %>
<%@ Register src="../projectControl.ascx" tagname="projectControl" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="0" cellspacing="0" width="90%" align="center">
      <tr><td height="40px">
      <uc2:projectcontrol ID="projectControl1" runat="server" />
      </td></tr>
    <tr><td>
    <table class="tab7"><tr><td><table class="tab4"><tr><td valign="top">
                                    <table class="tab5">
        <tr>
        <td height="60" valign="middle">
        <table width="50%" align="center">
        <tr>
        <td align="center" style="height:30px;">您所选的下载包含以下列表数据！</td>
        </tr>
        <tr>
        <td align="center"><asp:Button ID="Button_sumbit" 
                runat="server" Text=" 点击下载 " CssClass="button1" onclick="Button_sumbit_Click" />&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button
                    ID="Button_reset" runat="server" CausesValidation="false" Text=" 返回 " 
                CssClass="button1" onclick="Button_reset_Click"
                   /></td></tr>
        </table>
        </td>
        </tr>
        <tr>
            <td colspan="2" height="50">
                <uc1:fileslist ID="fileslist1" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2" height="243">
        </td>
        </tr></table></td></tr></table></td></tr></table>
    </table><table class="tab6"><tr><td align="center"><img src="/Admin/images/OAimages/Separator_content.jpg"></td></tr></table>
</asp:Content>

