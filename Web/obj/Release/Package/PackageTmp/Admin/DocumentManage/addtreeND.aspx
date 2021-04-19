<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/OAmaster.Master" AutoEventWireup="true" CodeBehind="addtreeND.aspx.cs" Inherits="Dianda.Web.Admin.DocumentManage.addtreeND" %>
<%@ Register src="../projectControl.ascx" tagname="projectControl" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="0" cellspacing="0" width="90%" align="center">
  <tr><td height="40px">
      <uc1:projectControl ID="projectControl1" runat="server" />
      </td></tr>
  <tr><td valign="top">
  <table class="tab7"><tr><td><table class="tab4"><tr><td valign="top">
                                    <table class="tab5" height="280">
  <tr><td colspan="2" height="50"></td></tr>
        <tr>
            <td style="width:340px;" align="right">
                目录名称:
            </td>
            <td align="left">
                <asp:TextBox ID="TextBox_FolderName" CssClass="textbox_name" Width="150" runat="server"></asp:TextBox><asp:RequiredFieldValidator  ID="RequiredFieldValidator1" ControlToValidate="TextBox_FolderName"  Display="Static"  runat="server" ErrorMessage="*目录名称不能为空">*目录名称不能为空</asp:RequiredFieldValidator>
            </td>
            </tr>
            <tr>
             <td align="right">
                
                上级目录:
            </td>
            
            <td align="left">
                <asp:DropDownList ID="DropDownList_upid" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="DropDownList_upid_SelectedIndexChanged">
            </asp:DropDownList><asp:Label ID="Label_notice" runat="server" Text=""></asp:Label>
            </td>
        </tr>
         <tr style="display:none">
            <td align="right">
                
                是否共享:
            </td>
            <td align="left">
                 <asp:RadioButtonList ID="RadioButtonList_isshare" RepeatColumns="2" runat="server">
                     <asp:ListItem Value="1">是</asp:ListItem>
                     <asp:ListItem Selected="True" Value="0">否</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            </tr>
            <tr>
            <td align="center" colspan="2"> <asp:Button ID="Button_sumbit" runat="server" 
                    Text=" 确定 "   CssClass="button1" onclick="Button_sumbit_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button 
                    ID="Button_reset" runat="server" CausesValidation=false Text=" 返回 " 
                    CssClass="button1" onclick="Button_reset_Click" 
                    /></td>
            </tr>
             <tr><td colspan="2" height="20"></td></tr></table></td></tr></table></td></tr></table>
             </td></tr>
    </table><table class="tab6"><tr><td align="center"><img src="/Admin/images/OAimages/Separator_content.jpg"></td></tr></table>
</asp:Content>
