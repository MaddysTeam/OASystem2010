<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/OAmaster.Master"
    CodeBehind="budgetmanage.aspx.cs" Inherits="Dianda.Web.Admin.budgetManage.budgetmanage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table align="center" bgcolor="#99cccd" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td height="3px">
            </td>
        </tr>
        <tr>
            <td>
                <table align="center" cellpadding="0" cellspacing="0" width="98%">
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
                                                                        <td align="center">
                                                                            <table class="tab2">
                                                                                <tr>
                                                                                    <td>
                                                                                        <table class="tab2">
                                                                                            <tr>
                                                                                                <td align="left">
                                                                                                    按状态筛选：<asp:DropDownList ID="DDL_Status" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlStatas_SelectedIndexChanged">
                                                                                                    </asp:DropDownList>
                                                                                                    &nbsp;
                                                                                                    专项资金筛选：<asp:DropDownList ID="DDL_SpecialFunds" runat="server" AutoPostBack="true"
                                                                                                        OnSelectedIndexChanged="DDL_SpecialFunds_SelectedIndexChanged">
                                                                                                    </asp:DropDownList>
                                                                                                    &nbsp;
                                                                                                    <asp:DropDownList ID="DropDownList_year" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList_year_SelectedIndexChanged">
                                                                                                    </asp:DropDownList>
                                                                                                </td>
                                                                                                <td align="left" runat="server" id="td_Dep">
                                                                                                    按部门筛选：<asp:DropDownList ID="DDL_Department" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDepartmentID_SelectedIndexChanged" Width="150px">
                                                                                                    </asp:DropDownList>
                                                                                                    &nbsp;&nbsp;&nbsp;<asp:DropDownList ID="DDL_Adder" runat="server" AutoPostBack="true"
                                                                                                        OnSelectedIndexChanged="ddlDDLAdder_SelectedIndexChanged" Width="100px">
                                                                                                    </asp:DropDownList>
                                                                                                </td>
                                                                                                <td align="right">
                                                                                                    <asp:Button ID="Button_check" runat="server" Text="审核" CssClass="button3a" OnClick="Button_check_onclick" />
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:Button ID="Button_add" runat="server" Text="新建申请" CssClass="button3b" OnClick="Button_add_onclick" />
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:Button ID="Button_modify" runat="server" Text="编辑申请" CssClass="button3b" OnClick="Button_modify_onclick" />
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:Button ID="Button_sumbit" runat="server" Text="撤销申请" OnClientClick="if(confirm('您确定要撤销吗？')){return true;}else{return false;}"
                                                                                                        CssClass="button3b" OnClick="Button_sumbit_onclick" />
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr align="center">
                                                                        <td align="center" colspan="5">
                                                                            <asp:Label ID="tag" runat="server" Text="" CssClass="tag1" /><asp:Label ID="notice"
                                                                                runat="server" Text="" ForeColor="Red"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <asp:GridView ID="GridView1" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound"
                                                                    runat="server" CellPadding="3" CssClass="GridView1" PageSize="15" DataKeyNames="ID">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="">
                                                                            <HeaderTemplate>
                                                                                <asp:CheckBox ID="CheckBox_All" runat="server" AutoPostBack="true" OnCheckedChanged="CheckBox_choose_CheckedChanged"
                                                                                    Text="" />全选
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:CheckBox ID="CheckBox_choose" runat="server" /><asp:HiddenField ID="Hid_ID"
                                                                                    runat="server" />
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                            <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField HeaderText="预算报告名称" DataField="NAMES">
                                                                            <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                            <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField HeaderText="所属项目" DataField="ProjectName">
                                                                            <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                            <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField HeaderText="预算金额" DataField="BudgetAmount">
                                                                            <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                            <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField HeaderText="申请时间" DataField="ADDTIME" DataFormatString="{0:yyyy-MM-dd}">
                                                                            <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                            <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField HeaderText="预算审批人" DataField="CheckerName">
                                                                            <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                            <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField HeaderText="经费审批人" DataField="AssignCheckerName">
                                                                            <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                            <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField HeaderText="专项资金" DataField="SFName">
                                                                            <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                            <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField HeaderText="审批时间" DataField="CheckTime" DataFormatString="{0:yyyy-MM-dd}">
                                                                            <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                            <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField HeaderText="状态">
                                                                            <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                            <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                        </asp:BoundField>
                                                                        <%--
                                                                                    <asp:BoundField HeaderText="报告操作记录">
                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                    </asp:BoundField>--%>
                                                                        <asp:TemplateField HeaderText="操作记录">
                                                                            <ItemTemplate>
                                                                                <asp:HyperLink ID="HL_viewbudget" runat="server">点击查看</asp:HyperLink>
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                            <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="查看备注">
                                                                            <ItemTemplate>
                                                                                <asp:HyperLink ID="HL_BZ" runat="server">点击查看</asp:HyperLink>
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                            <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <FooterStyle CssClass="FooterStyle1" />
                                                                    <PagerStyle HorizontalAlign="Left" CssClass="PagerStyle1" />
                                                                    <SelectedRowStyle CssClass="SelectedRowStyle1" />
                                                                </asp:GridView>
                                                                <%-- 记录当前是第几页--%>
                                                                <asp:HiddenField ID="HiddenField1" runat="server" />
                                                                <%-- 记录当前是第几页--%>
                                                                <%-- 记录信息集中总共有多少条记录--%>
                                                                <asp:HiddenField ID="dtrowsHidden" runat="server" />
                                                                <%-- 记录信息集中总共有多少条记录--%>
                                                                <%--下面是分页控件--%>
                                                                <table cellpadding="0" cellspacing="0" height="25" width="100%" runat="server" id="pageControlShow">
                                                                    <tr height="4px">
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right" bgcolor="#ffffff">
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
                                                                <br />
                                                                <div style="width: 100%; text-align: center" id="div_total" runat="server">
                                                                    <table width="98%" height="50px" style="border: solid 1px #99cccd; text-align: center"
                                                                        cellpadding="0" cellspacing="0">
                                                                        <tr style="background-color: #99cccd;">
                                                                            <td>
                                                                                预算申请状态：<%--<asp:Label ID="Label_Time" runat="server" Text="Label"></asp:Label>--%>
                                                                            </td>
                                                                            <td>
                                                                                待审核
                                                                            </td>
                                                                            <td>
                                                                                审核通过
                                                                            </td>
                                                                            <td>
                                                                                审核未通过
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="border-right: solid 1px #99cccd; width: 120px">
                                                                                预算金额合计：
                                                                            </td>
                                                                            <td style="border-right: solid 1px #99cccd">
                                                                                <asp:Label ID="Label_money1" runat="server"></asp:Label>元
                                                                            </td>
                                                                            <td style="border-right: solid 1px #99cccd">
                                                                                <asp:Label ID="Label_money2" runat="server"></asp:Label>元
                                                                            </td>
                                                                            <td style="border-right: solid 1px #99cccd">
                                                                                <asp:Label ID="Label_money3" runat="server"></asp:Label>元
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
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
    <td width="5">
    </td>
    </tr> </table>
</asp:Content>
