<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="managemodel.ascx.cs" Inherits="Dianda.Web.Admin.guestBook.managemodel" %>
    <table height="40px" align="center" bgcolor="#A8A6A7" cellpadding="0" cellspacing="0"
        width="100%">
        <tr bgcolor="#ffffff">
            <td>
                <table height="30px" align="center" bgcolor="#ffffff" cellpadding="0" cellspacing="0"
                    width="98%">
                    <tr>
                        <td colspan="4" height="10" bgcolor="#ffffff">
                        </td>
                    </tr>
                    <tr bgcolor="#d4f6d9">
                        <td>
                            <table bgcolor="#ffffff" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td height="30px">
                                        &nbsp;&nbsp;<img src="/Admin/images/icon_fav.gif" width="13" height="13" />&nbsp;&nbsp;
                                        <span class="titlePosition">平台留言板</span>&nbsp;&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td height="1" bgcolor="#e0e0e0">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <br />
                <table align="center" bgcolor="#e0e0e0" cellpadding="1" cellspacing="1" width="98%">
                    <tr bgcolor="#D8EFF5">
                        <td style="height: 30px">
                            <table height="40px" bgcolor="#f4f4f4" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td style="width: 30px;">
                                        &nbsp;&nbsp; ●
                                    </td>
                                    <td style="width: 39px;">
                                        搜索：
                                    </td>
                                    <td style="width: 222px;">
                                        <asp:TextBox ID="TextBox_KEYS"   CssClass="Inputtext" runat="server" Width="200px"></asp:TextBox>
                                    </td>
                                    <%--<td style="width: 85px;">
                                        栏目筛选：
                                    </td>--%>
                                    <td>
                                        <asp:Button ID="Button_search" runat="server" Text="-搜索-"  
                                            class="btn1_mouseout" onmouseover="this.className='btn1_mouseover'" 
                                            onmouseout="this.className='btn1_mouseout'" onclick="Button_search_Click" />  &nbsp;&nbsp;
                                        <img alt="可以根据留言者姓名、留言内容、回复 进行模糊搜索！" 
                                            src="../images/2009-3-23/ask.gif" style="width: 20px; height: 20px" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <br />
                     <table height="40px" align="center" bgcolor="#e0e0e0" cellpadding="1" cellspacing="1"
                    width="98%">
                    <tr bgcolor="#f0f0f0">
                        <td valign="top">
                            <asp:GridView ID="GridView1" CssClass="GridCommon" RowStyle-CssClass="GridCommontd"
                                HeaderStyle-CssClass="GridCommonHead" AllowPaging="True" OnRowDataBound="GridView1_RowDataBound"
                                AutoGenerateColumns="False" runat="server" Width="100%" CellPadding="4" ForeColor="#333333"
                                GridLines="None" PageSize="20" ShowHeader="False">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <table style="width: 100%;">
                                                <tr>
                                                    <td width="16">
                                                        <img src="/Admin/images/icon_fav.gif" width="13" height="13" />
                                                    </td>
                                                    <td>
                                                       <span style="color: #999999">
                                                            <%# Eval("WRITER") %>&nbsp; &nbsp;留言时间:<%# Eval("DATETIME") %><br />EMAIL:<%# Eval("TITLES")%>&nbsp; &nbsp;联系电话:<%# Eval("CLASSID")%>&nbsp; &nbsp;工作单位:<%# Eval("COURSEID")%>&nbsp; &nbsp;</span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <%# Eval("CONTENTS")%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        <table cellpadding="5" cellspacing="1" width="100%" bgcolor="#e0e0e0">
                                                            <tr>
                                                                <td bgcolor="#f0f0f0">
                                                                    <asp:Label ID="Label_reContents" runat="server" Text=""></asp:Label>
                                                                    <asp:TextBox ID="TextBox_reContents" CssClass="Inputtext" runat="server" Height="70px"
                                                                        Rows="5" TextMode="MultiLine" Width="600px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td height="5">
                                                    </td>
                                                </tr>
                                              
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                       <table cellpadding="5" cellspacing="1" width="100%" bgcolor="#e0e0e0">
                                                            <tr>
                                                                <td bgcolor="#dcf4bf">
                                                                <asp:LinkButton ID="LinkButton_replay" runat="server" OnClick="LinkButton_replay_Click"
                                                            CommandArgument='<%# Eval("ID")+"|"+(Container.DataItemIndex).ToString() %>' >-回复-</asp:LinkButton><asp:LinkButton
                                                                ID="LinkButton_replay_submit" runat="server" OnClick="LinkButton_replay_submit_Click"
                                                                CommandArgument='<%# Eval("ID")+"|"+(Container.DataItemIndex).ToString() %>'  OnClientClick="javascript:return confirm('您确定要提交该回复吗？');">-提交回复-</asp:LinkButton>
                                                        &nbsp; &nbsp;<asp:LinkButton ID="LinkButton_del" runat="server" OnClick="LinkButton_del_Click"
                                                            CommandArgument='<%# Eval("ID")+"|"+(Container.DataItemIndex).ToString() %>'  OnClientClick="javascript:return confirm('您确定要删除吗？');">-删除-</asp:LinkButton>&nbsp;
                                                        &nbsp;<asp:LinkButton ID="LinkButton_delshow" runat="server" OnClick="LinkButton_delshow_Click"
                                                            CommandArgument='<%# Eval("ID")+"|"+(Container.DataItemIndex).ToString() %>'  OnClientClick="javascript:return confirm('您确定要取消该评论在前台的显示吗？');">-取消前台显示-</asp:LinkButton>
                                                        <asp:LinkButton ID="LinkButton_show" runat="server" OnClick="LinkButton_show_Click"
                                                            CommandArgument='<%# Eval("ID")+"|"+(Container.DataItemIndex).ToString() %>'  OnClientClick="javascript:return confirm('您确定要设置该评论在前台显示吗？');">-在前台显示-</asp:LinkButton>
                                                                </td>
                                                                </tr>
                                                                </table>
                                                    </td>
                                                </tr>
                                                  <tr>
                                                    <td>
                                                    </td>
                                                    <td height="1" bgcolor="#E5E5E5">
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <RowStyle CssClass="GridCommontd" BackColor="#FFFBD6" ForeColor="#000000" />
                                <HeaderStyle BackColor="#eaefe8" Height="25px" ForeColor="#333333" CssClass="GridCommonHead"
                                    Font-Bold="False" />
                                <FooterStyle HorizontalAlign="Right" BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#f4f4f4" ForeColor="#333333" HorizontalAlign="Right" />
                                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                                <AlternatingRowStyle BackColor="White" />
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
                                    <td align="right" bgcolor="#eaefe8">
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
                            <asp:Label ID="notice" runat="server" Text=""></asp:Label><asp:HiddenField ID="pageindexHidden"
                                runat="server" />
                        </td>
                    </tr>
                </table>
                
                </td>
                </tr>
                </table>