<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/OAmaster.Master" AutoEventWireup="true"
    CodeBehind="statsCashApply.aspx.cs" Inherits="Dianda.Web.Admin.cashCardManage.statsCashApply" %>

<%@ Register Src="OAleftmenu.ascx" TagName="OAleftmenu" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="/Admin/js/SelectDate.js" type="text/javascript"></script>

    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td width="4">
            </td>
            <td valign="top" width="115" align="left">
                <uc1:OAleftmenu ID="OAleftmenu1" runat="server" />
            </td>
            <td width="5">
            </td>
            <td valign="top">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td height="3px">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table align="center" bgcolor="#99cccd" cellpadding="0" cellspacing="0" width="98%">
                                <tr>
                                    <td>
                                        <table cellpadding="0" cellspacing="0" width="100%">
                                            <tr>
                                                <td>
                                                    <table class="tab1" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td class="tab1_td1">
                                                                &nbsp;
                                                            </td>
                                                            <td class="tab1_td2">
                                                                <asp:Label ID="LB_name" runat="server" Text="" CssClass="LB_name1"></asp:Label>经费预约统计
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table class="tab3">
                                                        <tr>
                                                            <td>
                                                                <table class="tab4">
                                                                    <tr>
                                                                        <td valign="top">
                                                                            <table class="tab5">
                                                                                <tr>
                                                                                    <td>
                                                                                        <table class="tab2">
                                                                                            <tr>
                                                                                                <td>
                                                                                                    开始时间：
                                                                                                </td>
                                                                                                <td style="padding-top: 1px">
                                                                                                    <input class="Inputtext" id="txtBeginDate" runat="server" width="200" type="text"
                                                                                                        readonly="readonly" onclick="ShowCalendar(this);" />&nbsp; 结束时间：
                                                                                                    <input class="Inputtext" id="txtEndTime" runat="server" width="200" type="text" readonly="readonly"
                                                                                                        onclick="ShowCalendar(this);" />
                                                                                                </td>
                                                                                                <td>
                                                                                                    操作:
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:Button ID="Button_sumbit" runat="server" Text="搜索" OnClick="Button_sumbit_onclick"
                                                                                                        CssClass="button2" />
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="center" colspan="5">
                                                                                                    <asp:Label ID="tag" runat="server" Text="" CssClass="tag1" />
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                        <asp:DataList ID="DataList1" runat="server" 
                                                                                            onitemdatabound="DataList1_ItemDataBound" >
                                                                                            <ItemTemplate>
                                                                                                <table style="border-style: solid; border-width: 1px">
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:Label ID="lblDate" runat="server" Text=""></asp:Label>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:GridView ID="GridView1" AutoGenerateColumns="False" 
                                                                                                                runat="server" CellPadding="3" CssClass="GridView1" >
                                                                                                                <Columns>
                                                                                                                    <asp:BoundField HeaderText="申请人" DataField="ApplierRealName">
                                                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                                    </asp:BoundField>
                                                                                                                    <asp:BoundField HeaderText="金额" DataField="ApplyCount">
                                                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                                    </asp:BoundField>
                                                                                                                    <asp:BoundField HeaderText="项目" DataField="ProjectName">
                                                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                                    </asp:BoundField>
                                                                                                                    <asp:BoundField HeaderText="领取预约时间" DataField="GetDateTime">
                                                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                                    </asp:BoundField>
                                                                                                                    <asp:BoundField HeaderText="资金卡" DataField="CardName">
                                                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                                    </asp:BoundField>
                                                                                                                    <asp:BoundField HeaderText="用途" DataField="UseFor">
                                                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                                    </asp:BoundField>
                                                                                                                    <asp:BoundField HeaderText="联系方式" DataField="ApplierTel">
                                                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                                    </asp:BoundField>
                                                                                                                    <asp:BoundField HeaderText="申请时间" DataField="DATETIME">
                                                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                                    </asp:BoundField>
                                                                                                                    <asp:BoundField HeaderText="状态" DataField="StatasName">
                                                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                                    </asp:BoundField>
                                                                                                                </Columns>
                                                                                                                <FooterStyle CssClass="FooterStyle1" />
                                                                                                                <PagerStyle HorizontalAlign="Left" CssClass="PagerStyle1" />
                                                                                                                <SelectedRowStyle CssClass="SelectedRowStyle1" />
                                                                                                            </asp:GridView>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:Label ID="lblStats" runat="server" Text=""></asp:Label>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                        </asp:DataList>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table class="tab6">
                                                        <tr>
                                                            <td align="center">
                                                                <img src="/Admin/images/OAimages/Separator_content.jpg">
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="10px">
                        </td>
                    </tr>
                </table>
            </td>
            <td width="5">
            </td>
        </tr>
    </table>
</asp:Content>
