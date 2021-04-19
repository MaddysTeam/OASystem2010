<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="docFromModel.ascx.cs" Inherits="Dianda.Web.Admin.DOC_transport.docFromModel" %>
  <table height="30px" align="center" bgcolor="#e0e0e0" cellpadding="1" cellspacing="1"
                    width="98%">
                    <tr bgcolor="#D8EFF5">
                        <td style="height: 30px">
                            <table height="40px" bgcolor="#f4f4f4" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td style="width: 30px;">
                                        &nbsp;&nbsp; ●
                                    </td>
                                    <td style="width: 85px;" align="right">
                                       已发公文搜索：
                                    </td>
                                    <td style="width: 222px;">
                                        <asp:TextBox ID="TextBox_KEYS" CssClass="Inputtext" runat="server" Width="200px"></asp:TextBox>
                                    </td>
                                    <%--<td style="width: 85px;">
                                        栏目筛选：
                                    </td>--%>
                                    <td>
                                      &nbsp;&nbsp;  <asp:Button ID="Button_search" runat="server" Text="-搜索-" OnClick="Button_search_Click"
                                            class="btn1_mouseout" onmouseover="this.className='btn1_mouseover'" onmouseout="this.className='btn1_mouseout'" />
                                        &nbsp;
                                        (*可以搜索标题和收件人用户名)</td>
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
                                GridLines="None"  PageSize="10">
                                <Columns>
                                    <asp:TemplateField HeaderText="序号">
                                        <ItemTemplate>
                                              <%# (Container.DataItemIndex + 1) + (GridView1.PageSize)* (int.Parse(pageindexHidden.Value.ToString())-1)%>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="28" />
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="标题" DataField="TITLES">
                                        <ItemStyle HorizontalAlign="Left"  Width="300"/>
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="收件人" DataField="TOUSER">
                                        <ItemStyle HorizontalAlign="Left" Width="100" />
                                          <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="发布日期" DataField="DATETIME">
                                        <ItemStyle HorizontalAlign="Left" Width="120" />
                                          <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="附件" DataField="FILEPATH">
                                        <ItemStyle HorizontalAlign="Left" Width="50" />
                                           <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                  
                                    <asp:TemplateField HeaderText="操作">
                                        <ItemStyle HorizontalAlign="left" Width="40" />
                                        <HeaderStyle HorizontalAlign="left" />
                                        <ItemTemplate>
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
                            <table cellpadding="0" cellspacing="0" height="25" width="100%"  runat="server" id="pageControlShow">
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
                <br />
                  <table height="30px" align="center" bgcolor="#e0e0e0" cellpadding="1" cellspacing="1"
                    width="98%">
                    <tr bgcolor="#D8EFF5">
                        <td style="height: 30px">
                            <table height="40px" bgcolor="#f4f4f4" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td style="width: 40px;">
                                        &nbsp;&nbsp; ！
                                    </td>
                                    <td align="left" colspan="3">
                                        发件箱里面公文的删除不影响收件人的收取。
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>