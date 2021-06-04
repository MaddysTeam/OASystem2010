<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/OAmaster.Master"
    CodeBehind="list.aspx.cs" Inherits="Dianda.Web.Admin.budgetManage.department.list" %>

<%@ Register Src="/Admin/cashCardManage/OAleftmenu.ascx" TagName="OAleftmenu" TagPrefix="uc1" %>
<%@ Register Src="/Admin/cashCardManage/OAleftmenu_Show.ascx" TagName="OAleftmenu_Show" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td width="10">
            </td>
            <td valign="top" width="115" align="left">
                <uc1:OAleftmenu ID="OAleftmenu1" runat="server" Visible="true" />
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
                                                                <asp:Label ID="LB_name" runat="server" Text="" CssClass="LB_name1"></asp:Label>部门预算管理
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
                                                                                                        CssClass="button2" />--%>&nbsp;&nbsp;&nbsp;<asp:Label ID="LB_SX" runat="server" Text="所属项目："></asp:Label><asp:DropDownList
                                                                                                            ID="DDL_PARENT_BUDGET" runat="server"  AutoPostBack="true" OnSelectedIndexChanged="DDL_parent_budget_SelectedIndexChanged">
                                                                                                            <asp:ListItem Value="">-全部-</asp:ListItem>
<%--                                                                                                            <asp:ListItem Value="使用中">使用中</asp:ListItem>
                                                                                                            <asp:ListItem Value="已注销">已注销</asp:ListItem>
                                                                                                            <asp:ListItem Value="已过期">已过期</asp:ListItem>--%>
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
                                                                                                                <asp:Button ID="Button_add" runat="server" Text="新建" 
                                                                                                                    CssClass="button3a" OnClick="Button_add_onclick" />
                                                                                                            </td>
                                                                                                            <td>
                                                                                                                <asp:Button ID="Button_modify" runat="server" Text="编辑" OnClick="Button_modify_onclick"
                                                                                                                    CssClass="button3a" />
                                                                                                            </td>
                                                                                                            <td>
                                                                                                                 <asp:Button ID="Button_delete" Visible="false" runat="server" Text="删除" OnClick="Button_delete_onclick" OnClientClick="if(confirm('您确定要注销吗？')){return true;}else{return false;}"
                                                                                                                    CssClass="button3a" />
                                                                                                            </td>
                                                                                                            <td>
                                                                                                                <asp:Button ID="Button_recover" Visible="false" runat="server" Text="恢复"
                                                                                                                    CssClass="button3a" />
                                                                                                            </td>
                                                                                                            <td>
                                                                                                                <asp:Button ID="Button_div" runat="server" Text="搜索"  OnClick="Button_div_Click"
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
                                                                                                    <div id="DIV_SearchArea" runat="server" visible="false">
                                                                                                        <table width="95%">
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    预算编号：
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <asp:TextBox ID="txtCode" runat="server" CssClass="textbox_name" Width="120"></asp:TextBox>
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    预算名称：
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <asp:TextBox ID="txtBudgetName" runat="server" CssClass="textbox_name" Width="120"></asp:TextBox>
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    项目负责人：
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                   <asp:DropDownList ID="ddlManagerId" runat="server">
                                                                                                                    </asp:DropDownList>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                              <%--  <td>
                                                                                                                    创建日期：
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <input id="TB_AddDateTime" runat="server" style="width: 118px" type="text" readonly="readonly"
                                                                                                                        onclick="ShowCalendar(this);" />
                                                                                                                </td>--%>
                                                                                                             <%--   <td>
                                                                                                                    所属项目：
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <asp:DropDownList ID="ddlProjectID" runat="server">
                                                                                                                    </asp:DropDownList>
                                                                                                                </td>--%>
                                                                                                                <td>
                                                                                                                    所属部门：
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <asp:DropDownList ID="ddlDepartmentID" runat="server" OnSelectedIndexChanged="ddlDepartmentID_SelectedIndexChanged"  AutoPostBack="True">
                                                                                                                    </asp:DropDownList>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td style="height: 8px" colspan="4">
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td style="height: 18px" colspan="4">
                                                                                                                    <asp:Button ID="BtnAdvSearch" runat="server" Text="搜索" OnClick="BtnAdvSearch_Click1"
                                                                                                                        CssClass="button1" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button_close" OnClick="Button_close_Click"
                                                                                                                            runat="server" Text="关闭"  CssClass="button1" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button
                                                                                                                                ID="Button_viewall" OnClick="Button_viewall_Click" runat="server" Text="返回全部" CssClass="button1" />
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
                                                                                        <asp:GridView ID="GridView1" AutoGenerateColumns="False"  OnRowDataBound="GridView1_RowDataBound"
                                                                                            runat="server" CellPadding="0" CssClass="GridView1" DataKeyNames="ParentID" Width="100%">
                                                                                            <Columns>
                                                                                                <asp:TemplateField HeaderText="">
                                                                                                    <HeaderTemplate>
                                                                                                        <asp:CheckBox ID="CheckBox_All" runat="server" AutoPostBack="true" 
                                                                                                            Text="" />全选
                                                                                                    </HeaderTemplate>
                                                                                                    <ItemTemplate>
                                                                                                        <asp:CheckBox ID="CheckBox_choose" runat="server" /><asp:HiddenField ID="Hid_ID"
                                                                                                            runat="server" />
                                                                                                    </ItemTemplate>
                                                                                                    <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                    <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                                </asp:TemplateField>
                                                                                                <asp:BoundField HeaderText="编号" DataField="Code" >
                                                                                                    <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                                                    <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                </asp:BoundField>
                                                                                                <asp:BoundField HeaderText="子项目名称" DataField="BudgetName">
                                                                                                    <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                                                    <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                </asp:BoundField>
                                                                                             <%--   <asp:BoundField HeaderText="项目负责人" DataField="parentId">
                                                                                                    <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                                                    <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                </asp:BoundField>--%>
                                                                                                <asp:BoundField HeaderText="预算总额(元)" DataField="Balance">
                                                                                                    <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                                                    <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                </asp:BoundField>
                                                                                                <asp:BoundField HeaderText="可用余额(元)" DataField="KYbalance" >
                                                                                                    <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                                                    <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                </asp:BoundField>
																								<asp:BoundField HeaderText="所属项目" DataField="ParentBudgetName">
                                                                                                    <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                                                    <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                </asp:BoundField>
																								<asp:BoundField HeaderText="总预算金额" DataField="ParentLimitNums">
                                                                                                    <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                                                    <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                </asp:BoundField>
																								<asp:BoundField HeaderText="总可用余额" DataField="ParentYEBalance">
                                                                                                    <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                                                    <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                </asp:BoundField>
																								
                                                                                         <%--       <asp:BoundField HeaderText="所属部门" DataField="DepartmentName" Visible="false">
                                                                                                    <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                                                    <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                </asp:BoundField>--%>
                                                                                               <%-- <asp:BoundField HeaderText="所属项目" DataField="ProjectName">
                                                                                                    <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                                                    <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                </asp:BoundField>

																								<asp:BoundField HeaderText="总预算金额" DataField="ProjectName">
                                                                                                    <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                                                    <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                </asp:BoundField>
																								<asp:BoundField HeaderText="总可用余额" DataField="ProjectName">
                                                                                                    <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                                                    <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                </asp:BoundField>--%>
                                                                                               <%-- <asp:BoundField HeaderText="所属帐户" DataField="AccountName">
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
                                                                                                </asp:BoundField>--%>
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
                                                                                                    &nbsp;&nbsp;<asp:LinkButton ID="PreviousPage" OnClick="PageChange_Click"  runat="server">上一页</asp:LinkButton>
                                                                                                    &nbsp;&nbsp;<asp:LinkButton ID="NextPage" OnClick="PageChange_Click"  runat="server">下一页</asp:LinkButton>
                                                                                                    &nbsp;&nbsp;<asp:LinkButton ID="LastPage" OnClick="PageChange_Click"  runat="server">最后页</asp:LinkButton>
                                                                                                    &nbsp;&nbsp;<asp:Label ID="Label_showInfo" runat="server" Text=""></asp:Label>&nbsp;&nbsp;跳转到：<asp:DropDownList
                                                                                                        ID="DropDownList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" >
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
