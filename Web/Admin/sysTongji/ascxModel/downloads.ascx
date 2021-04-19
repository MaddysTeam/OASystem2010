<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="downloads.ascx.cs" Inherits="Dianda.Web.Admin.sysTongji.ascxModel.downloads" %>
 <%@ Register src="../../DocumentManage/fileslist.ascx" tagname="fileslist" tagprefix="uc1" %>
 <table cellpadding="0" cellspacing="0" width="90%" align="center">
      <tr><td height="40px">
          &nbsp;</td></tr>
    <tr><td>
    <table class="tab7"><tr><td><table class="tab4"><tr><td valign="top">
                                    <table class="tab5">
        <tr>
        <td height="60" valign="middle">
        <table width="90%" align="center">
        <tr>
        <td align="center" style="height:30px;">您所选的归档文件包含以下列表数据！（归档后的文件将存储在  <%=System.Configuration.ConfigurationManager.AppSettings["FTPURLS"]%>  上！）</td>
        </tr>
        <tr>
        <td align="center"><asp:Button ID="Button_sumbit" 
                runat="server" Text=" 点击归档 " CssClass="button1" onclick="Button_sumbit_Click" />&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button
                    ID="Button_reset" runat="server" CausesValidation="false" Text=" 返回 " 
                CssClass="button1" onclick="Button_reset_Click"
                   />&nbsp;<asp:Label ID="Label_notice" runat="server" Text=""  ForeColor=Red></asp:Label></td></tr>
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
