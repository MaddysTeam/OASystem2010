<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addtreeNode.aspx.cs" Inherits="Dianda.Web.Admin.DocumentManage.addtreeNode" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>我的文档>新建目录</title>
    <link href="../css/OACSS.css" rel="stylesheet" type="text/css" />
<script type="text/javascript"> 
function reloadpage() 
{ 
parent.parent.GB_hide(); 
} 
</script> 

</head>
<body>
    <form id="form1" runat="server">
    <table cellpadding="10" cellspacing="10" width="98%" align="center">
  <tr><td colspan="2" height="50"></td></tr>
        <tr>
            <td align="right">
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
                <asp:DropDownList ID="DropDownList_upid" runat="server">
            </asp:DropDownList>
            </td>
        </tr>
         <tr>
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
                    ID="Button_reset" runat="server" CausesValidation=false Text=" 返回 "  OnClientClick="reloadpage();"  CssClass="button1" 
                    /></td>
            </tr>
             <tr><td colspan="2" height="20"></td></tr>
    </table>
    </form>
</body>
</html>
