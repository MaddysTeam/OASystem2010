<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/OAmaster.Master" AutoEventWireup="true"
    CodeBehind="manageCashApplyPerson.aspx.cs" Inherits="Dianda.Web.Admin.cashCardManage.manageCashApplyPerson" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table align="center" bgcolor="#99cccd" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td height="3px">
            </td>
        </tr>
        <tr>
            <td>
                <table align="center" cellpadding="0" cellspacing="0" width="90%">
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
                                                                                        按状态筛选：<asp:DropDownList ID="ddlStatas" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlStatas_SelectedIndexChanged">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td align="right">
                                                                                        <table>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <asp:Button ID="Button_add" runat="server" Text="新建预约" CssClass="button3b" OnClick="Button_add_onclick" />
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:Button ID="Button_sumbit" runat="server" Text="撤销预约" OnClientClick="if(confirm('您确定要撤销吗？')){return true;}else{return false;}"
                                                                                                        CssClass="button3b" OnClick="Button_sumbit_onclick" />
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="center" colspan="5">
                                                                                        <asp:Label ID="tag" runat="server" Text="" CssClass="tag1" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                            <asp:GridView ID="GridView1" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound"
                                                                                runat="server" CellPadding="3" CssClass="GridView1" DataKeyNames="ID,ApplierRealName,GetDateTime,ApplyCount,Temp1">
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
                                                                                    <asp:BoundField HeaderText="申请人" DataField="ApplierRealName">
                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField HeaderText="金额" DataField="ApplyCount">
                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField HeaderText="类型" DataField="Attribute">
                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField HeaderText="领取预约时间" DataField="GetDateTime"  >
                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField HeaderText="卡名称" DataField="TEMP2">
                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                    </asp:BoundField>
                                                                                    <asp:TemplateField HeaderText="详情">
                                                                                        <ItemTemplate>
                                                                                            <a href="#" title="<%#Eval("UseFor") %>" onclick='ShowDialog(<%#Eval("ID") %>);'>详情</a>
                                                                                        </ItemTemplate>
                                                                                           <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                    </asp:TemplateField>
                                                                                  
                                                                                    <%--<asp:BoundField HeaderText="联系方式" DataField="ApplierTel">
                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                    </asp:BoundField>--%>
                                                                                    <asp:BoundField HeaderText="申请时间" DataField="DATETIME" DataFormatString="{0:yyyy-MM-dd}">
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
                                                                            <asp:Label ID="notice" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td height="140px">
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
        </tr>
    </table>
    <script type="text/javascript">
        function ShowDialog(ID)
        {
            window.showModalDialog('/Admin/cashCardManage/ShowDetail.aspx?ID='+ ID,'','dialogWidth=650px;dialogHeight=350px');
        }
    </script>
</asp:Content>
