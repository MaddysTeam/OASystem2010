<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucProjectHot.ascx.cs"
    Inherits="Dianda.Web.Admin.ucProjectHot" %>
<div>
    <table align="center" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td valign="top">
                <table align="center" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td valign="top">
                            <table cellpadding="0" cellspacing="0" width="100%">
                            <tr><td valign="top" style=" background-image:url(/Admin/images/OAimages/blue_line.jpg); height:12px;"></td></tr>
                                <tr>
                                    <td valign="top">
                                        <table class="tab3a">
                                            <tr>
                                                <td valign="top">
                                                    <table class="tab9">
                                                        <tr>
                                                            <td valign="top">
                                                                <table class="tab5">
                                                                    <tr>
                                                                        <td valign="top">
                                                                            <asp:GridView ID="GridView1" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound"  GridLines="None"
                                                                                runat="server" CellPadding="3" CssClass="GridView1" DataKeyNames="" PageSize="10" ShowHeader="false">
                                                                                <Columns>
                                                                                    <asp:TemplateField>
                                                                                        <ItemTemplate>
                                                                                            <table width="100%" style="border-width: 1px; border-color: #808080; border-bottom-style: dashed;>
                                                                                                <tr height:16px;">
                                                                                                    <td style="width: 80%">
                                                                                                        <asp:Label ID="lblURLS" runat="server" Text=""></asp:Label>
                                                                                                    </td>
                                                                                                    <td align="right">
                                                                                                        <asp:Label ID="lblDATETIME" runat="server" Text=""></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                                <FooterStyle CssClass="FooterStyle1" />
                                                                                <PagerStyle HorizontalAlign="Left" CssClass="PagerStyle1" />
                                                                                <SelectedRowStyle CssClass="SelectedRowStyle1" />
                                                                            </asp:GridView>
                                                                            
                                                                            
                                                                            <table class="tab6">
                                            <tr>
                                                <td align="center">
                                                    <img src="/Admin/images/OAimages/Separator_content3.jpg">
                                                </td>
                                            </tr>
                                        </table>
                                        <%-- 记录当前是第几页--%>
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                            <%-- 记录当前是第几页--%>
                            <%-- 记录信息集中总共有多少条记录--%>
                            <asp:HiddenField ID="dtrowsHidden" runat="server" />
                            <%-- 记录信息集中总共有多少条记录--%>
                            <%--下面是分页控件--%>
                            <table cellpadding="0" cellspacing="0" height="25" width="100%" runat="server" id="pageControlShow">
                                <tr>
                                    <td align="right">
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
                            <asp:Label ID="notice" runat="server" Text="" ForeColor="Red"></asp:Label>
                            <asp:HiddenField ID="pageindexHidden" runat="server" />
                            <asp:HiddenField ID="H_NAME" runat="server" />
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
                            
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</div>
