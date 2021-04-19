<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="modifypwd.aspx.cs" Inherits="Dianda.Web.modifypwd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<link href="Admin/css/OACSS.css" rel="stylesheet" type="text/css" />
<html xmlns="http://www.w3.org/1999/xhtml">
 <META HTTP-EQUIV="Pragma" CONTENT="no-cache">
<head runat="server">
    <title></title>
    <%--    <script type="text/javascript">
        function reloadpage() {
            alert("密码修改成功！");
            parent.parent.GB_hide(); 
} 
</script> --%>
<base target="_self" />
</head>
<body>
    <form id="form1" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%" align="center" height="60%"
        valign="middle">
        <tr>
            <td height="10px" colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Label ID="Label_tag" runat="server" Text="" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td height="10px" colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="right" width="200">
                您的旧密码：
            </td>
            <td>
                <asp:TextBox ID="TB_OLDPWD" runat="server" TextMode="Password"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
                    ID="RequiredFieldValidator2" runat="server" ControlToValidate="TB_OLDPWD" Display="Dynamic"
                    ErrorMessage="*旧密码不能为空!"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td height="10px" colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="right" width="200">
                输入新密码：
            </td>
            <td>
                <asp:TextBox ID="TB_NEWPWD1" runat="server" TextMode="Password"></asp:TextBox>&nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TB_NEWPWD1"
                    Display="Dynamic" ErrorMessage="*新密码不能为空!"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="Server" ControlToValidate="TB_NEWPWD1"
                    ValidationExpression="^([\u4e00-\u9fa5]|[0-9_a-zA-Z]){1,25}$" ErrorMessage="密码不能包含特殊字符!"
                    Display="Dynamic" />
            </td>
        </tr>
        <tr>
            <td height="10px" colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="right" width="200">
                新密码确认：
            </td>
            <td>
                <asp:TextBox ID="TB_NEWPWD2" runat="server" TextMode="Password"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
                    ID="RequiredFieldValidator3" runat="server" ControlToValidate="TB_NEWPWD2" Display="Dynamic"
                    ErrorMessage="*确认密码不能为空!"></asp:RequiredFieldValidator><asp:CompareValidator ID="CompareValidator1"
                        runat="server" ControlToValidate="TB_NEWPWD2" ControlToCompare="TB_NEWPWD1" Operator="Equal"
                        Display="Static" ErrorMessage="*两次新密码的输入不一样!"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td height="10px" colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:Button ID="Button_submit" runat="server" Text="确定修改" CssClass="button1_1" OnClick="Button_submit_onclick" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
