<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="uploadfilesups.aspx.cs" Inherits="Dianda.Web.Admin.personalProjectManage.OACashApply.uploadfilesups" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<link href="../../css/OACSS.css" rel="stylesheet" type="text/css" />
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>上传预算表单</title>
    <base target="_self" />
</head>
<body >
    <form id="form1" runat="server">
<table border="0" cellpadding="0" cellspacing="0" width="85%" align="center" height="60%" valign="middle">
                                                        <tr><td height="30px" colspan="2">&nbsp;</td></tr>
                                                        <div runat="server" id="div_upload">
                                                        <tr><td colspan="2" align="center"><asp:Label ID="tag" runat="server" Text="" ForeColor="Red"></asp:Label></td></tr>
                                                         <tr>
                                                            <td >
                                                                <span class="ffont">上传表单：</span>
                                                            </td>
                                                            <td>
                                                                <asp:FileUpload ID="FileUpload_list" runat="server" Style="width: 270px;
                                                                    height: 20px;" />
                                                            </td>
                                                         </tr>
                                                         <tr><td height="10px" colspan="2">&nbsp;</td></tr>
                                                            <tr>
                                                                <td >
                                                                    <span class="ffont">预计经费：</span>
                                                                </td>
                                                                <td >
                                                                    <table border="0" cellpadding="0" cellspacing="0"><tr>
                                                                    <td valign="middle">
                                                                       <asp:TextBox  MaxLength="9" ID="CashTotal" runat="server" Width="200"></asp:TextBox>&nbsp;
                                                                    </td>
                                                                    <td valign="bottom">
                                                                        
                                                                       <asp:RadioButtonList ID="RB_cashtotal" runat="server" RepeatColumns="2">
                                                                         <asp:ListItem Value="1" Selected="True">万元</asp:ListItem>
                                                                         <asp:ListItem Value="0">元</asp:ListItem>
                                                                        </asp:RadioButtonList>&nbsp;&nbsp;
                                                                    </td>
                                                                    </tr></table>
                                                                </td>
                                                            </tr>
                                                            <tr><td height="10px" colspan="2">&nbsp;</td></tr>
                                                            <tr><td align="center" colspan="2"><asp:Button ID="Button_submit" runat="server"  OnClick="Button_submit_Click"  CssClass="button1" Text=" 确定 " /></td></tr>
                                                        </div>

</table>
    </form>
</body>
</html>
