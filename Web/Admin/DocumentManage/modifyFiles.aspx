<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/OAmaster.Master" AutoEventWireup="true" CodeBehind="modifyFiles.aspx.cs" Inherits="Dianda.Web.Admin.DocumentManage.modifyFiles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                <asp:TextBox ID="TextBox_FolderName" CssClass="textbox_name" Width="150" runat="server"></asp:TextBox><asp:RequiredFieldValidator  ID="RequiredFieldValidator1" ControlToValidate="TextBox_FolderName"  Display="Static"  runat="server" ErrorMessage="*文件名称不能为空">*文件名称不能为空</asp:RequiredFieldValidator>
            </td>
            </tr>
            <tr>
             <td align="right">
                
                上级目录:
            </td>
            
            <td align="left">
                <asp:DropDownList ID="DropDownList_upid" runat="server">
            </asp:DropDownList>
            </td>
        </tr>
     <%--    <tr>
            <td align="right">
                
                是否共享:
            </td>
            <td align="left">
                 <asp:RadioButtonList ID="RadioButtonList_isshare" RepeatColumns="2" runat="server">
                     <asp:ListItem Value="1">是</asp:ListItem>
                     <asp:ListItem Selected="True" Value="0">否</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            </tr>--%>
                    <tr>
            <td align="right">
                
                文件:
            </td>
                        
            <td align="left">
                <asp:FileUpload ID="FileUpload1" runat="server" />(*留空表示不修改原文件！)<asp:HiddenField 
                    ID="HiddenField_oldpath" runat="server" /><asp:HiddenField 
                    ID="HiddenField_pid" runat="server" />
                <br />
                [*支持的文件类型：<asp:Label ID="Label_filetype" runat="server" Text=""></asp:Label>]
            </td>
            </tr>
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
</asp:Content>
