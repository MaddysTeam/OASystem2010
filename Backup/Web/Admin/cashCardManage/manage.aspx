<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/OAmaster.Master" AutoEventWireup="true"
    CodeBehind="manage.aspx.cs" Inherits="Dianda.Web.Admin.cashCardManage.manage" %>

<%@ Register Src="OAleftmenu.ascx" TagName="OAleftmenu" TagPrefix="uc1" %>
<%@ Register src="OAleftmenu_Show.ascx" tagname="OAleftmenu_Show" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="/Admin/js/SelectDate.js" type="text/javascript"></script>

    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td width="10">
            </td>
            <td valign="top" width="115" align="left">
                <uc1:OAleftmenu ID="OAleftmenu1" runat="server" Visible="false" />
                <uc2:OAleftmenu_Show ID="OAleftmenu_Show1" runat="server" Visible="false" />
            </td>
            <td width="5">
            </td>
            <td valign="top">
                <table border="0" cellpadding="0" cellspacing="0" width="100%" height="397px">
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
                                                                <asp:Label ID="LB_name" runat="server" Text="" CssClass="LB_name1"></asp:Label>资金卡
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
                                                                                    <td align="left">
                                                                                        <table class="tab2">
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <asp:Label ID="lblshowMessage" runat="server" Text=""></asp:Label>
                                                                                                    <%--   <asp:Button ID="Button_Message" runat="server" Text="新设资金卡通知" OnClick="Button_Message_onclick"
                                                                                                        CssClass="button2" />--%>&nbsp;&nbsp;&nbsp;<asp:Label ID="LB_SX" runat="server" Text="状态："></asp:Label><asp:DropDownList
                                                                                                            ID="DDL_SX" runat="server" OnSelectedIndexChanged="DDL_SX_Change" AutoPostBack="true">
                                                                                                            <asp:ListItem Value="">-全部-</asp:ListItem>
                                                                                                            <asp:ListItem Value="使用中">使用中</asp:ListItem>
                                                                                                            <asp:ListItem Value="已注销">已注销</asp:ListItem>
                                                                                                            <asp:ListItem Value="已过期">已过期</asp:ListItem>
                                                                                                        </asp:DropDownList>
                                                                                                </td>
                                                                                                <td width="200">
                                                                                                </td>
                                                                                                <td>
                                                                                                    <%-- <asp:DropDownList ID="ddlMailBox" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlMailBox_SelectedIndexChanged">
                                                                                                        <asp:ListItem Selected="True" Value="1">信息发布箱</asp:ListItem>
                                                                                                        <asp:ListItem Value="2">信息接收箱</asp:ListItem>
                                                                                                    </asp:DropDownList>--%>
                                                                                                </td>
                                                                                                <td align="right">
                                                                                                    <table>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:Button ID="Button_add" runat="server" Text="新建" OnClick="Button_add_onclick"
                                                                                                                    CssClass="button3a" />
                                                                                                            </td>
                                                                                                            <td>
                                                                                                                <asp:Button ID="Button_modify" runat="server" Text="编辑" OnClick="Button_modify_onclick"
                                                                                                                    CssClass="button3a" />
                                                                                                            </td>
                                                                                                            <td>
                                                                                                                <asp:Button ID="Button_delete" runat="server" Text="注销" OnClientClick="if(confirm('您确定要注销吗？')){return true;}else{return false;}"
                                                                                                                    OnClick="Button_delete_onclick" CssClass="button3a" />
                                                                                                            </td>
                                                                                                            <td>
                                                                                                                <asp:Button ID="Button_recover" runat="server" Text="恢复" OnClick="Button_recover_onclick"
                                                                                                                    CssClass="button3a" />
                                                                                                            </td>
                                                                                                            <td>
                                                                                                                <asp:Button ID="Button_div" runat="server" Text="搜索" OnClick="Button_div_onclick"
                                                                                                                    CssClass="button3a" />
                                                                                                            </td>
                                                                                                            <td>
                                                                                                                <asp:Button ID="Button_LimitNums" runat="server" Text="记账" OnClick="Button_LimitNums_onclick"
                                                                                                                    CssClass="button3a" />
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td colspan="9" align="center">
                                                                                                    <asp:Label ID="tag" runat="server" Text="" CssClass="tag1" />
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td colspan="9" align="left">
                                                                                                    <div id="div2" runat="server" visible="false">
                                                                                                        <table width="95%">
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    资金卡编号：
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <asp:TextBox ID="txtCardNum" runat="server" CssClass="textbox_name" Width="120"></asp:TextBox>
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    资金卡名称：
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <asp:TextBox ID="txtCardName" runat="server" CssClass="textbox_name" Width="120"></asp:TextBox>
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    持卡人：
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <asp:TextBox ID="txtCardholderRealName" runat="server" CssClass="textbox_name" Width="120"></asp:TextBox>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    创建日期：
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <input id="TB_AddDateTime" runat="server" style="width: 118px" type="text" readonly="readonly"
                                                                                                                        onclick="ShowCalendar(this);" />
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    所属项目：
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <asp:DropDownList ID="ddlProjectID" runat="server">
                                                                                                                    </asp:DropDownList>
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    所属部门：
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <asp:DropDownList ID="ddlDepartmentID" runat="server">
                                                                                                                    </asp:DropDownList>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    所属专项资金：
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <asp:DropDownList ID="DDL_SpecialFundsID" runat="server">
                                                                                                                    </asp:DropDownList>
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    所属预算报告：
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <asp:DropDownList ID="DDL_SFOrderID" runat="server">
                                                                                                                    </asp:DropDownList>
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    状态：
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <asp:DropDownList ID="DDL_ZT" runat="server" >
                                                                                                                        <asp:ListItem Value="">-全部-</asp:ListItem>
                                                                                                                        <asp:ListItem Value="使用中">使用中</asp:ListItem>
                                                                                                                        <asp:ListItem Value="已注销">已注销</asp:ListItem>
                                                                                                                        <asp:ListItem Value="已过期">已过期</asp:ListItem>
                                                                                                                    </asp:DropDownList>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td style="height: 8px" colspan="4">
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td style="height: 18px" colspan="4">
                                                                                                                    <asp:Button ID="Button_search" runat="server" Text="搜索" OnClick="Button_search_onclick"
                                                                                                                        CssClass="button1" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button_close"
                                                                                                                            runat="server" Text="关闭" OnClick="Button_close_onclick" CssClass="button1" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button
                                                                                                                                ID="Button_viewall" runat="server" Text="返回全部" CssClass="button1" OnClick="Button_viewall_onclick" />
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td style="height: 8px" colspan="4">
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </div>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                        <asp:GridView ID="GridView1" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound"
                                                                                            runat="server" CellPadding="0" CssClass="GridView1" DataKeyNames="ID" Width="100%">
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
                                                                                                <asp:BoundField HeaderText="编号" DataField="CardNum" Visible="false">
                                                                                                    <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                                                    <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                </asp:BoundField>
                                                                                                <asp:BoundField HeaderText="名称" DataField="CardName">
                                                                                                    <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                                                    <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                </asp:BoundField>
                                                                                                <asp:BoundField HeaderText="可用金额" DataField="LimitNums">
                                                                                                    <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                                                    <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                </asp:BoundField>
                                                                                                <asp:BoundField HeaderText="持卡人" DataField="CardholderRealName">
                                                                                                    <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                                                    <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                </asp:BoundField>
                                                                                                <asp:BoundField HeaderText="审批人" DataField="ApproverRealName" Visible="false">
                                                                                                    <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                                                    <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                </asp:BoundField>
                                                                                                <asp:BoundField HeaderText="所属部门" DataField="DepartmentName" Visible="false">
                                                                                                    <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                                                    <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                </asp:BoundField>
                                                                                                <asp:BoundField HeaderText="所属项目" DataField="ProjectName">
                                                                                                    <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                                                    <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                </asp:BoundField>
                                                                                                <asp:BoundField HeaderText="所属帐户" DataField="AccountName">
                                                                                                    <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                                                    <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                </asp:BoundField>
                                                                                                <asp:BoundField HeaderText="所属专项资金" DataField="SpecialFundsName">
                                                                                                    <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                                                    <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                </asp:BoundField>
                                                                                                <asp:BoundField HeaderText="所属预算报告" DataField="SFOrderName">
                                                                                                    <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                                                    <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                </asp:BoundField>
                                                                                                <asp:BoundField HeaderText="到期时间" DataField="EndTime" DataFormatString="{0:yyyy-MM-dd}">
                                                                                                    <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                                                    <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                </asp:BoundField>
                                                                                                <asp:BoundField HeaderText="状态" DataField="Statas">
                                                                                                    <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                                                    <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                </asp:BoundField>
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
                                                                                            <tr height="7px">
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
                                                                                        </table>
                                                                                        <%--下面是分页控件--%>
                                                                                        <asp:Label ID="notice" runat="server" Text="" ForeColor="Red"></asp:Label>
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
