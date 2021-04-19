<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/OAmaster.Master" AutoEventWireup="true"
    CodeBehind="manageCashCard.aspx.cs" Inherits="Dianda.Web.Admin.cashCardManage.manageCashCard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td valign="top">
                <table border="0" cellpadding="0" cellspacing="0" width="100%" height="397">
                    <tr>
                        <td height="3px">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table align="center" bgcolor="#99cccd" cellpadding="0" cellspacing="0" width="95%">
                                <tr>
                                    <td>
                                        <table cellpadding="0" cellspacing="0" width="100%">
                                            <tr>
                                                <td>
                                                    <table class="tab7">
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
                                                                                                    请选择筛选条件：<asp:DropDownList ID="DDL_SF" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDL_SF_Change">
                                                                                                        <%--指的是持卡人是我，即CardholderID是登陆者 --%>
                                                                                                        <asp:ListItem Value="0">我的资金卡</asp:ListItem>
                                                                                                        <%--指的是经费的审批人是我，因为资金卡在创建时要选择一个预算报告，而预算报告在审核时得有个经费审批人
                                                                                                        ，在资金卡新建时也要选择一个审批人，这个审批人其实就应该选择所选择预算报告的经费审批人，切记！所以这里就以预算报告审核
                                                                                                        时的经费审批人为准！(严宏达2012－02－03日说的)--%>
                                                                                                        <asp:ListItem Value="1">作为经费审批人</asp:ListItem>
                                                                                                        <%--指的是审批过的预算报告所对应的资金卡 --%>
                                                                                                        <asp:ListItem Value="2">作为预算审批人</asp:ListItem>
                                                                                                    </asp:DropDownList>&nbsp;&nbsp;
                                                                                                    <asp:Label ID="LB_SF" runat="server" Text="作为资金卡的持卡人所拥有的资金卡！" ForeColor="Red"></asp:Label> 
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="center">
                                                                                                    <asp:Label ID="tag" runat="server" Text="" CssClass="tag1" />
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                        <asp:GridView ID="GridView1" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound"
                                                                                            runat="server" CellPadding="3" CssClass="GridView1" DataKeyNames="ID" PageSize="10">
                                                                                            <Columns>
                                                                                                <asp:BoundField HeaderText="编号" DataField="CardNum" >
                                                                                                    <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                                    <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                </asp:BoundField>
                                                                                                <asp:BoundField HeaderText="名称" DataField="CardName">
                                                                                                    <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                                    <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                </asp:BoundField>
                                                                                                <asp:BoundField HeaderText="余额" DataField="Balance_2"> 
                                                                                                    <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                                    <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                </asp:BoundField>
                                                                                                <asp:BoundField HeaderText="持卡人" DataField="CardholderRealName">
                                                                                                    <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                                    <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                </asp:BoundField>
                                                                                                <asp:BoundField HeaderText="审批人" DataField="ApproverRealName" Visible="false">
                                                                                                    <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                                    <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                </asp:BoundField>
                                                                                                <asp:BoundField HeaderText="所属部门" DataField="DepartmentName" >
                                                                                                    <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                                    <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                </asp:BoundField>
                                                                                                <asp:BoundField HeaderText="所属项目" DataField="ProjectName">
                                                                                                    <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                                    <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                </asp:BoundField>
                                                                                                <asp:BoundField HeaderText="所属预算报告" DataField="SFOrderName">
                                                                                                    <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                                    <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                </asp:BoundField>
                                                                                                <asp:BoundField HeaderText="状态" DataField="Statas">
                                                                                                    <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                                    <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                </asp:BoundField>
                                                                                            </Columns>
                                                                                            <FooterStyle CssClass="FooterStyle1" />
                                                                                            <PagerStyle HorizontalAlign="Left" CssClass="PagerStyle1" />
                                                                                            <SelectedRowStyle CssClass="SelectedRowStyle1" />
                                                                                        </asp:GridView>
                                                                                        <asp:Label ID="notice" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                                                        <%-- 记录当前是第几页--%>
                                                                                        <asp:HiddenField ID="HiddenField1" runat="server" />
                                                                                        <%-- 记录当前是第几页--%>
                                                                                        <%-- 记录信息集中总共有多少条记录--%>
                                                                                        <asp:HiddenField ID="dtrowsHidden" runat="server" />
                                                                                        <%-- 记录信息集中总共有多少条记录--%>
                                                                                        <%--下面是分页控件--%>
                                                                                        <table cellpadding="0" cellspacing="0" height="25" width="100%" runat="server" id="pageControlShow">
                                                                                            <tr>
                                                                                                <td height="7">
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="right" bgcolor="#FFFFFF">
                                                                                                    <asp:LinkButton ID="FirstPage" OnClick="PageChange_Click" runat="server">第一页</asp:LinkButton>
                                                                                                    &nbsp;&nbsp;<asp:LinkButton ID="PreviousPage" OnClick="PageChange_Click" runat="server">上一页</asp:LinkButton>
                                                                                                    &nbsp;&nbsp;<asp:LinkButton ID="NextPage" OnClick="PageChange_Click" runat="server">下一页</asp:LinkButton>
                                                                                                    &nbsp;&nbsp;<asp:LinkButton ID="LastPage" OnClick="PageChange_Click" runat="server">最后页</asp:LinkButton>
                                                                                                    &nbsp;&nbsp;<asp:Label ID="Label_showInfo" runat="server" Text=""></asp:Label>&nbsp;&nbsp;跳转到：<asp:DropDownList
                                                                                                        ID="DropDownList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                                                                                                    </asp:DropDownList>
                                                                                                    &nbsp;
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr height="7px">
                                                                                                <td>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                        <%--下面是分页控件--%>
                                                                                        <asp:HiddenField ID="pageindexHidden" runat="server" />
                                                                                        <asp:HiddenField ID="H_NAME" runat="server" />
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
