<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/OAmaster.Master" AutoEventWireup="true"
    CodeBehind="delSource.aspx.cs" Inherits="Dianda.Web.Admin.DocumentManage.delSource" %>
<%@ Register src="../projectControl.ascx" tagname="projectControl" tagprefix="uc2" %>
<%@ Register Src="fileslist.ascx" TagName="fileslist" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="0" cellspacing="0" width="90%" align="center">
   <tr><td height="40px">
      <uc2:projectControl ID="projectControl1" runat="server" />
      </td></tr>

  <tr><td valign="top">
  <table class="tab7"><tr><td><table class="tab4"><tr><td valign="top">
                                    <table class="tab5">
        <tr>
        <td height="30">
        您的本次操作将对以下所有文件夹及文件进行删除！您确定要删除吗？(点确定后，将进行删除操作，不再提示！) <asp:Button ID="Button_sumbit" 
                runat="server" Text=" 确定 " CssClass="button1" onclick="Button_sumbit_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button
                    ID="Button_reset" runat="server" CausesValidation="false" Text=" 返回 " 
                CssClass="button1" onclick="Button_reset_Click"
                   />
        </td>
        </tr>
        
        <tr>
            <td colspan="2" height="50">
                <uc1:fileslist ID="fileslist1" runat="server" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
               
            </td>
        </tr>
        <tr>
            <td colspan="2" height="20">
            </td>
        </tr></table></td></tr></table></td></tr></table>
             </td></tr>
    </table>
</asp:Content>
