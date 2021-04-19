<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YYJEHZ.aspx.cs" Inherits="Dianda.Web.Admin.cashCardManage.YYJEHZ" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="../css/OACSS.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tab_height1">
        <tr style="height:23px;">
            <td style="background-color:#99cccd" class="tab1_td2">
                &nbsp;&nbsp;<asp:Label ID="LB_name" runat="server" Text="预约金额汇总" CssClass="LB_name1"></asp:Label>
        </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;<asp:Label ID="Label1" runat="server" Text="选择日期"></asp:Label>
                &nbsp;&nbsp;<asp:DropDownList ID="DDList_RQ" runat="server" AutoPostBack="True"
                    onselectedindexchanged="DDList_RQ_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="DDList_RQ" EventName="selectedindexchanged" />
                </Triggers>
                <ContentTemplate>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="GridView1">
                    <Columns>
                        <asp:BoundField HeaderText="日期" DataField="GetDateTime" >
                            <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                            <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="待审核金额" DataField="DSH" >
                            <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                            <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="审核通过金额" DataField="SHTG" >
                            <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                            <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="审核不通过金额" DataField="SHBTG" >
                            <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                            <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="每日金额合计" DataField="Tol">
                            <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                            <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
                </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
