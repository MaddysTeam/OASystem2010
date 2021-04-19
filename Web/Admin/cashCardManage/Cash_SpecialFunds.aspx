<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/OAmaster.Master" AutoEventWireup="true"
    CodeBehind="Cash_SpecialFunds.aspx.cs" Inherits="Dianda.Web.Admin.cashCardManage.Cash_SpecialFunds" %>

<%@ Register Src="OAleftmenu.ascx" TagName="OAleftmenu" TagPrefix="uc1" %>
<%@ Register Src="../../ascxManage/GridView_PageSet.ascx" TagName="GridView_PageSet"
    TagPrefix="uc2" %>
<%@ Register Src="../Cash_SF_Order/SpecialFundsOrder.ascx" TagName="SpecialFundsOrder"
    TagPrefix="uc3" %>
<%@ Register src="OAleftmenu_Show.ascx" tagname="OAleftmenu_Show" tagprefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table align="center" cellpadding="0" cellspacing="0" width="100%" bgcolor="#99cccd"
        runat="server" id="showtables">
        <tr>
            <td width="10">
            </td>
            <td valign="top" width="115" align="left">
                <uc4:OAleftmenu_Show ID="OAleftmenu_Show1" runat="server" Visible="false" />
                <uc1:OAleftmenu ID="OAleftmenu1" runat="server" Visible="false" />
            </td>
            <td width="5">
            </td>
            <td>
                <table align="center" bgcolor="#99cccd" cellpadding="0" cellspacing="0" width="98%">
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0" width="98%" align="center">
                                <tr>
                                    <td height="5px">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table class="tab1" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td class="tab1_td1">
                                                    &nbsp;
                                                </td>
                                                <td class="tab1_td2">
                                                    专项资金管理
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
                                                    <div runat="server" id="gvdiv">
                                                        <table class="tab4">
                                                            <tr>
                                                                <td valign="top">
                                                                    <table class="tab5">
                                                                        <tr>
                                                                            <td>
                                                                                <table>
                                                                                    <tr>
                                                                                        <td>
                                                                                            账户：
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:DropDownList ID="DropDownList_AccountList" runat="server" AutoPostBack="True"
                                                                                                OnSelectedIndexChanged="DropDownList_AccountList_SelectedIndexChanged">
                                                                                            </asp:DropDownList>
                                                                                            &nbsp;
                                                                                        </td>
                                                                                        <td>
                                                                                            年份：
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:DropDownList ID="DropDownList_year" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList_year_SelectedIndexChanged">
                                                                                            </asp:DropDownList>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                            <td align="right">
                                                                                <table>
                                                                                    <tr>
                                                                                        <%--<td align="center">
                                                                                        <a id="show_manage" runat="server" href="YYJEHZ.aspx" target="_self" rel="gb_page_center[726,400]"
                                                                                                        class="button3d" style="text-decoration: none" title="">预约金额汇总</a>
                                                                                    </td>--%>
                                                                                        <td align="center">
                                                                                            <asp:Button ID="Button_add" runat="server" Text="新建" CssClass="button3a" OnClick="Button_add_Click" />
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            <asp:Button ID="Button1" runat="server" Text="编辑" CssClass="button3a" OnClick="Button1_Click" />
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            <asp:Button ID="Button_delete" runat="server" Text="注销" OnClientClick="if(confirm('您确定要注销吗？')){return true;}else{return false;}"
                                                                                                CssClass="button3a" OnClick="Button_delete_Click" />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="center" colspan="5">
                                                                                            <asp:Label ID="tag" runat="server" Text="" CssClass="tag1" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="center" colspan="2">
                                                                                <asp:GridView ID="GridView1" AutoGenerateColumns="False" DataKeyNames="ID" runat="server"
                                                                                    CssClass="GridView1" Style="margin-top: 0px">
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="">
                                                                                            <HeaderTemplate>
                                                                                                <asp:CheckBox ID="CheckBox_All" runat="server" AutoPostBack="true" OnCheckedChanged="CheckBox_choose_CheckedChanged"
                                                                                                    Text="" />
                                                                                            </HeaderTemplate>
                                                                                            <ItemTemplate>
                                                                                                <asp:CheckBox ID="CheckBox_choose" runat="server" /><asp:HiddenField ID="Hid_ID"
                                                                                                    runat="server" />
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                            <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="专项资金名称↓">
                                                                                            <ItemTemplate>
                                                                                                <%#Eval("NAMES")%>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                            <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="年份↓">
                                                                                            <ItemTemplate>
                                                                                                <%#Eval("YEARS")%>年
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                            <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="所属账户">
                                                                                            <ItemTemplate>
                                                                                                <%#Eval("AccountNames")%><%#Eval("AccountStatus").ToString() == "1" ? "[正常]" : "[冻结]"%>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                            <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="预算金额">
                                                                                            <ItemTemplate>
                                                                                                <%#Eval("TotalNum")%>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                            <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="可用金额">
                                                                                            <ItemTemplate>
                                                                                                <%#Eval("Balance")%>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                            <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="直接预约">
                                                                                            <ItemTemplate>
                                                                                                <%#Eval("IsListApply").ToString() == "1" ? "可以" : "不可以"%>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                            <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="状态">
                                                                                            <ItemTemplate>
                                                                                                <%#Eval("STATUS").ToString() == "1" ? "正常" : "暂停"%>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                            <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:BoundField HeaderText="创建时间" DataField="ADDTIME" DataFormatString="{0:yyyy-MM-dd}">
                                                                                            <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                                            <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                        </asp:BoundField>
                                                                                        <%--预算更改为详细--%>
                                                                                        <%--<asp:TemplateField HeaderText="预算">
                                                                                            <ItemTemplate>                                                                                                
                                                                                                <asp:LinkButton ID="LinkButton_orderlist" runat="server" CommandArgument='<%#Eval("ID")%>'
                                                                                                    ForeColor="Blue" OnClick="LinkButton_orderlist_Click">预算</asp:LinkButton>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                            <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                        </asp:TemplateField>--%>
                                                                                        <asp:TemplateField HeaderText="详细">
                                                                                            <ItemTemplate>
                                                                                                <asp:LinkButton ID="LinkButton_orderlist" runat="server" CommandArgument='<%#Eval("ID")%>'
                                                                                                    ForeColor="Blue" OnClick="LinkButton_orderlist_Click">详细</asp:LinkButton>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                            <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                    <FooterStyle CssClass="FooterStyle1" />
                                                                                    <PagerStyle HorizontalAlign="Left" CssClass="PagerStyle1" />
                                                                                    <SelectedRowStyle CssClass="SelectedRowStyle1" />
                                                                                </asp:GridView>
                                                                                <br />
                                                                                <asp:Label ID="notice" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <br />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    <%-- 按项目名称排序 by guanzhq on 2012年3月19日--%>
                                                                    <%--<uc2:GridView_PageSet ID="GridView_PageSet1" runat="server" PageSize="10" OrderString="YEARS desc,NAMES desc"
                                                                        Width="500" ReFieldsStr="*" Gridviewid="GridView1" TableNames="vCash_SpecialFunds"
                                                                        CountIndex="ID" />--%>
                                                                    <uc2:GridView_PageSet ID="GridView_PageSet1" runat="server" PageSize="10" OrderString="NAMES desc,YEARS desc"
                                                                        Width="500" ReFieldsStr="*" Gridviewid="GridView1" TableNames="vCash_SpecialFunds"
                                                                        CountIndex="ID" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
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
    </table>
    <div class="head_div11_InSamePage" id="showOrderList" runat="server" visible="false">
        <div style="position: absolute; overflow: auto; right: 130px; height: 400px; top: 100px;
            width: 690px; border: solid 0px Gray; filter: alpha(opacity=90); opacity: 0.5;"
            id="newshowTypeDiv">
        </div>
        <div class="showdivInSamePagebutton">
            <asp:Button ID="Button_guanbi" runat="server" Text="关闭" CssClass="button3a" OnClick="Button_guanbi_Click" />
        </div>
        <div class="showDivInSamePage" id="showDivInSamePage">
            <uc3:SpecialFundsOrder ID="SpecialFundsOrder1" runat="server" />
        </div>
    </div>
</asp:Content>
