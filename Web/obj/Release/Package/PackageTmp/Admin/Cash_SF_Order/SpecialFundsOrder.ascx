<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SpecialFundsOrder.ascx.cs"
    Inherits="Dianda.Web.Admin.Cash_SF_Order.SpecialFundsOrder" %>
<table width="100%">
    <tr>
        <td align="center">
            <asp:GridView ID="GridView1" AutoGenerateColumns="False" DataKeyNames="ID" runat="server"
                CssClass="GridView1">
                <Columns>
                    <asp:BoundField HeaderText="预算名称" DataField="NAMES">
                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="预算金额">
                        <ItemTemplate>
                            <%#Eval("ActualAmount")%><%#Eval("BAUNIT")%>
                            <%--<%#Eval("BAUNIT").ToString() == "1" ? "元" : ""%>
                            <%#Eval("BAUNIT").ToString() == "10000" ? "万" : ""%>--%>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="申请人">
                        <ItemTemplate>
                            <%#Eval("REALNAME")%>
                            <%--(<%#Eval("Applyuser")%>)--%>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="状态">
                        <ItemTemplate>
                            <%#Eval("Status").ToString() == "0" ? "待审核" : ""%>
                            <%#Eval("Status").ToString() == "1" ? "审核通过" : ""%>
                            <%#Eval("Status").ToString() == "2" ? "审核不通过" : ""%>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="申请时间↓" DataField="ADDTIME" DataFormatString="{0:yyyy-MM-dd}">
                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                    </asp:BoundField>
                </Columns>
                <FooterStyle CssClass="FooterStyle1" />
                <PagerStyle HorizontalAlign="Left" CssClass="PagerStyle1" />
                <SelectedRowStyle CssClass="SelectedRowStyle1" />
            </asp:GridView>
            <asp:Label ID="notice" runat="server" Text="" ForeColor="Red"></asp:Label>
            <br />
            <asp:Label ID="lblhuizong" runat="server" Text=""></asp:Label>
            &nbsp;&nbsp;
        </td>
    </tr>
</table>
