<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewnotes.aspx.cs" Inherits="Dianda.Web.Admin.budgetManage.viewnotes" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
        <title>查看备注信息</title>
    <link href="../../css/OACSS.css" rel="stylesheet" type="text/css" />
</head>
<body style="background-color: #99cccd">
    <form id="form1" runat="server">
    <table width="650" border="10" cellspacing="0" cellpadding="0" class="tab5">
        <tr>
            <td align="left">
                <asp:Label ID="LB_Notes" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>