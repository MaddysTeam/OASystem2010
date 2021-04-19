<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExcelDataStatistics.aspx.cs"
    Inherits="Dianda.Web.Admin.sysTongji.ExcelDataStatistics" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Excel导出统计数据</title>
</head>
<body style="font-size: 12px">
    <form id="form1" runat="server">
    <table id="mxmk" border="1" cellpadding="0" cellspacing="0" width="100%" runat="server">
        <tr>
            <td align="center" colspan="2">
                教研室内网OA平台使用情况
            </td>
        </tr>
        <tr>
            <td align="center" rowspan="2" style="width: 250px">
                模块功能
            </td>
            <td align="center">
                使用时期（次数、篇幅等）
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="lblYear" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" rowspan="1">
                <asp:Label ID="Label1" runat="server"></asp:Label>
                <asp:GridView ID="GridView1" runat="server" CssClass="Gridview" AutoGenerateColumns="False" Width="100%" CellPadding="0">
                    <Columns>
                        <asp:BoundField HeaderText="月份" DataField="FromTable" ItemStyle-Width="250px" ItemStyle-HorizontalAlign="Center" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                总注册用户数：<asp:Label ID="lblCount" runat="server"></asp:Label>位、包括教研室全体人员及学科组注册组员
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
