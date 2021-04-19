<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/OAmaster.Master" AutoEventWireup="true" CodeBehind="shareFiles.aspx.cs" Inherits="Dianda.Web.Admin.DocumentManage.shareFiles" %>
<%@ Register src="shareForUser.ascx" tagname="shareForUser" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<br />
<br /><br />
<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
  <table cellpadding="0" cellspacing="0" width="90%" align="center">
  <tr><td height="30px"></td></tr>
  <tr><td valign="top">
  <table class="tab7"><tr><td><table class="tab4"><tr><td valign="top">
                                    <table class="tab5">
  <tr><td colspan="2" height="50"></td></tr>
        <tr>
            <td align="right">
                文件名称:
            </td>
            <td align="left">
                <asp:Label ID="Label_cname" runat="server" Text=""></asp:Label>
            </td>
            </tr>
            
         <tr>
            <td align="right">
                
                是否共享:
            </td>
            <td align="left">
                 <asp:RadioButtonList ID="RadioButtonList_isshare" RepeatColumns="2" 
                     runat="server" AutoPostBack="True" 
                     onselectedindexchanged="RadioButtonList_isshare_SelectedIndexChanged">
                     <asp:ListItem Value="1">是</asp:ListItem>
                     <asp:ListItem Selected="True" Value="0">否</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <tr>
            <td colspan="2"><uc1:shareForUser ID="shareForUser1" runat="server" /></td>
            </tr>
            </tr>
        
    </table>
        

      <table cellpadding="3" bgcolor="#ffffff" cellspacing="3" width="80%" align="center">
          <tr>
            <td align="center" colspan="2"> <asp:Button ID="Button_sumbit" runat="server" 
                    Text=" 确定 "   CssClass="button1" onclick="Button_sumbit_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button 
                    ID="Button_reset" runat="server" CausesValidation=false Text=" 返回 " 
                    CssClass="button1" onclick="Button_reset_Click" 
                    /></td>
            </tr>
             <tr><td colspan="2" height="20"></td></tr></table></td></tr></table></td></tr></table></td></tr></table>
             </td></tr>
      </table><table class="tab6"><tr><td align="center"><img src="/Admin/images/OAimages/Separator_content.jpg"></td></tr></table>
      </ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
