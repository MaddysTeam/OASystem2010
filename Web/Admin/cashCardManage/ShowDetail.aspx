<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowDetail.aspx.cs" Inherits="Dianda.Web.Admin.cashCardManage.ShowDetail" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Cache-Control" content="no-cache" />
    <meta http-equiv="Expires" content="0" />

    <title>详情信息</title>
    <link href="../css/OACSS.css" rel="stylesheet" type="text/css" />
    
</head>
<body style="background-color: #99cccd">
    <form id="form1" runat="server">
    <table width="650" border="0" cellspacing="0" cellpadding="0">
        <tr style="border-bottom:1px solid #000000;">
            <td align="left" style="font-size:large; padding-left:8px;">详情信息</td>
        </tr>
        <tr>
            <td><hr /></td>
        </tr>
        <tr>
            <td align="left" style="padding-left:0px;">
                <pre style="word-break:break-all;width:630px; height:290px;overflow-x:hidden;"><asp:Label ID="LB_Notes" runat="server">
</asp:Label>
                </pre>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
