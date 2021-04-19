<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowManage.aspx.cs" Inherits="Dianda.Web.Admin.personalProjectManage.OAapply.ShowManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <META HTTP-EQUIV="Pragma" CONTENT="no-cache">
    <META HTTP-EQUIV="Cache-Control" CONTENT="no-cache">
    <META HTTP-EQUIV="Expires" CONTENT="0">

    <title>查看预定信息</title>
    <link href="../../css/OACSS.css" rel="stylesheet" type="text/css" />
</head>
<body style="background-color: #99cccd">
    <form id="form1" runat="server">
    <table width="720" border="10" cellspacing="0" cellpadding="0">
        <tr>
            <td align="center">
                <asp:GridView ID="GridView1" runat="server" CellPadding="5" align="center" CellSpacing="0"
                    Width="100%" AutoGenerateColumns="False" CssClass="GridView1">
                    <Columns>
                        <asp:TemplateField HeaderText="序号">
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Container.DataItemIndex+ 1%>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                            <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="CarName" HeaderText="预定车辆">
                            <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                            <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="预定时间">
                            <ItemTemplate>
                                <%#   Convert.ToDateTime(Eval("StartTime").ToString()).ToLongDateString().Equals(Convert.ToDateTime(Eval("EndTime").ToString()).ToLongDateString()) ? Convert.ToDateTime(Eval("StartTime").ToString()).ToLongDateString() + "&nbsp;" + Convert.ToDateTime(Eval("StartTime").ToString()).ToShortTimeString() + " 至 " + Convert.ToDateTime(Eval("EndTime").ToString()).ToShortTimeString() : Convert.ToDateTime(Eval("StartTime").ToString()).ToLongDateString() + "&nbsp;" + Convert.ToDateTime(Eval("StartTime").ToString()).ToShortTimeString() + " 至 <br>" + Convert.ToDateTime(Eval("EndTime").ToString()).ToLongDateString() + "&nbsp;" + Convert.ToDateTime(Eval("EndTime").ToString()).ToShortTimeString() + "&nbsp;&nbsp;&nbsp;&nbsp;"%>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                            <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="预定人">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("REALNAME")%>'></asp:Label>
                                (<asp:Label ID="Label5" runat="server" Text='<%# Eval("USERNAME")%>'></asp:Label>)
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                            <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="状态">
                            <ItemTemplate>
                                <%#Eval("Status").ToString().Equals("0")?"待审核":"审核通过"%>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                            <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:GridView ID="GridView2" Style="border: 1px solid #000000" CellPadding="5" align="center"
                    CellSpacing="0" Width="100%" runat="server" AutoGenerateColumns="False" CssClass="GridView1">
                    <Columns>
                        <asp:TemplateField HeaderText="序号">
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Container.DataItemIndex+ 1%>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                            <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="RoomName" HeaderText="预定会议室">
                            <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                            <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="预定时间">
                            <ItemTemplate>
                                <%--                              <%#   Convert.ToDateTime(Eval("StartTime").ToString()).ToLongDateString() + "&nbsp;&nbsp;  " + Convert.ToDateTime(Eval("StartTime").ToString()).ToShortTimeString() + " 至 " + Convert.ToDateTime(Eval("EndTime").ToString()).ToShortTimeString()%>
--%>
                                <%#   Convert.ToDateTime(Eval("StartTime").ToString()).ToLongDateString().Equals(Convert.ToDateTime(Eval("EndTime").ToString()).ToLongDateString()) ? Convert.ToDateTime(Eval("StartTime").ToString()).ToLongDateString() + "&nbsp;" + Convert.ToDateTime(Eval("StartTime").ToString()).ToShortTimeString() + " 至 " + Convert.ToDateTime(Eval("EndTime").ToString()).ToShortTimeString() : Convert.ToDateTime(Eval("StartTime").ToString()).ToLongDateString() + "&nbsp;" + Convert.ToDateTime(Eval("StartTime").ToString()).ToShortTimeString() + " 至 <br>" + Convert.ToDateTime(Eval("EndTime").ToString()).ToLongDateString() + "&nbsp;" + Convert.ToDateTime(Eval("EndTime").ToString()).ToShortTimeString() + "&nbsp;&nbsp;&nbsp;&nbsp;"%>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                            <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="预定人">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("REALNAME")%>'></asp:Label>
                                (<asp:Label ID="Label5" runat="server" Text='<%# Eval("USERNAME")%>'></asp:Label>)
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                            <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="状态">
                            <ItemTemplate>
                                <%#Eval("Status").ToString().Equals("0")?"待审核":"审核通过"%>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                            <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:GridView ID="GridView3" Style="border: 1px solid #000000" CellPadding="5" align="center"
                    CellSpacing="0" Width="100%" runat="server" AutoGenerateColumns="False" CssClass="GridView1">
                    <Columns>
                        <asp:TemplateField HeaderText="序号">
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Container.DataItemIndex+ 1%>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                            <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="OrderNum" HeaderText="预定数量">
                            <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                            <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="预定时间">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("UserDatetime")%>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                            <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="预定人">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("REALNAME")%>'></asp:Label>
                                (<asp:Label ID="Label5" runat="server" Text='<%# Eval("USERNAME")%>'></asp:Label>)
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                            <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="状态">
                            <ItemTemplate>
                                <%#Eval("Status").ToString().Equals("0")?"待审核":"审核通过"%>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                            <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:GridView ID="GridView4" Style="border: 1px solid #000000" CellPadding="5" align="center"
                    CellSpacing="0" Width="100%" runat="server" AutoGenerateColumns="False" CssClass="GridView1">
                    <Columns>
                        <asp:TemplateField HeaderText="序号">
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Container.DataItemIndex+ 1%>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                            <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="SignetName" HeaderText="用印申请">
                            <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                            <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="申请数量">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("Nums")%>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                            <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="预定人">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("REALNAME")%>'></asp:Label>
                                (<asp:Label ID="Label5" runat="server" Text='<%# Eval("USERNAME")%>'></asp:Label>)
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                            <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:Label ID="Label6" runat="server" Font-Size="12px" ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
