<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Dianda.Web.login" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
<head id="Head1" runat="server">
    <title>平台登录</title>
    <link href="App_Themes/BlueTheme/Default.css" rel="stylesheet" type="text/css" />
</head>
<body bgcolor="#000B19">
    <form id="form1" runat="server">
    <div>
        <br />
        <br />
        <br />
        <br />
        <br />
        <table cellpadding="0" cellspacing="0" align="center" width="915" background="/Admin/images/login.jpg"
            height="548">
            <tr>
                <td valign="top">
                    <table cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td height="275">
                            </td>
                            <td>
                            </td>
                            <td>
                               
                            </td>
                        </tr>
                        <tr>
                            <td width="400">
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox_username" runat="server" CssClass="Inputtext" Width="160"></asp:TextBox>
                            </td>
                            <td>
                               
                            </td>
                        </tr>
                        <tr>
                            <td height="25">
                            </td>
                            <td>
                            </td>
                            <td>
                                
                            </td>
                        </tr>
                        <tr>
                            <td>
                               
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox_pwd" runat="server" TextMode="Password" CssClass="Inputtext"
                                    Width="160"></asp:TextBox>
                            </td>
                            <td>
                               
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" align="center" valign="middle" height="80">
                                <asp:ImageButton ID="ImageButton_login" ImageUrl="/Admin/images/loginbutton.jpg"
                                    runat="server" OnClick="ImageButton_login_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" align="center" height="30">
                             
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td align="center">
               
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
