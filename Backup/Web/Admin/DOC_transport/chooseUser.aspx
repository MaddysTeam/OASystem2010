<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="chooseUser.aspx.cs" Inherits="Dianda.Web.Admin.DOC_transport.chooseUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>chooseUsers</title>
    <link href="../../App_Themes/BlueTheme/Default.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div><br /><br />
        <table height="20px" cellpadding="0" cellspacing="0" width="100%">
            <tr bgcolor="#e0e0e0">
                <td colspan="3" align="left" style="height: 25px">
                    &nbsp;&nbsp;○&nbsp; 请选择公文接收人员： （先选择组织机构）
                 
                    <asp:Button ID="Button_do" runat="server" Text="-确定所选的用户-" 
                        onclick="Button_do_Click" />&nbsp;
                    <asp:Button ID="Button_colse" runat="server" OnClientClick="window.parent.parent.GB_hide();" Text="-关闭-" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:CheckBoxList ID="CheckBoxList_organList" runat="server" AutoPostBack="True"
                        OnSelectedIndexChanged="CheckBoxList_organList_SelectedIndexChanged">
                    </asp:CheckBoxList>
                </td>
            </tr>
        </table>
           <br />
                <table height="40px" align="center" bgcolor="#e0e0e0" cellpadding="1" cellspacing="1"
                    width="98%">
                    <tr><td>  <asp:CheckBox ID="chkAll" runat="server" 
                            OnCheckedChanged="chkAll_CheckedChanged1" AutoPostBack="True" Text="全选" /></td></tr>
                    <tr bgcolor="#f0f0f0">
                        <td valign="top">
                            <asp:GridView ID="GridView1" CssClass="GridCommon" RowStyle-CssClass="GridCommontd"
                                HeaderStyle-CssClass="GridCommonHead" 
                                AutoGenerateColumns="False" runat="server" Width="100%" CellPadding="4" ForeColor="#333333"
                                GridLines="None" PageSize="15"  OnRowDataBound="GridView1_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="选择">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckBox_check" runat="server" />  <%--<%# (Container.DataItemIndex + 1)%>--%>
                                        </ItemTemplate>
                                        <HeaderStyle Width="30px" />
                                        <ItemStyle HorizontalAlign="Center" Width="30px" />
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="用户名" DataField="USERNAME">
                                        <HeaderStyle HorizontalAlign="Left" Width="40px" />
                                        <ItemStyle HorizontalAlign="left" Width="70px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="真实姓名" DataField="REALNAME">
                                        <HeaderStyle HorizontalAlign="Left" Width="50px" />
                                        <ItemStyle HorizontalAlign="left" Width="80px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="性别" DataField="SEX">
                                        <HeaderStyle HorizontalAlign="Left" Width="30px" />
                                        <ItemStyle HorizontalAlign="Left" Width="30px" />
                                    </asp:BoundField>
                                          <asp:BoundField HeaderText="组织机构" DataField="ORGAN">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                 
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
                          <%--  <table cellpadding="0" cellspacing="0" height="25" width="100%"   runat="server" id="pageControlShow">
                                <tr>
                                    <td align="right" bgcolor="#eaefe8">
                                        <asp:LinkButton ID="FirstPage" OnClick="PageChange_Click" runat="server">第一页</asp:LinkButton>
                                        &nbsp;&nbsp;<asp:LinkButton ID="PreviousPage" OnClick="PageChange_Click" runat="server">上一页</asp:LinkButton>
                                        &nbsp;&nbsp;<asp:LinkButton ID="NextPage" OnClick="PageChange_Click" runat="server">下一页</asp:LinkButton>
                                        &nbsp;&nbsp;<asp:LinkButton ID="LastPage" OnClick="PageChange_Click" runat="server">最后页</asp:LinkButton>
                                        &nbsp;&nbsp;<asp:Label ID="Label_showInfo" runat="server" Text=""></asp:Label>&nbsp;&nbsp;跳转到：<asp:DropDownList
                                            ID="DropDownList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                                        </asp:DropDownList>&nbsp;
                                    </td>
                                </tr>
                            </table>--%>
                            <%--下面是分页控件--%>
                            
                            
                            
                            
                            
                            
                            <asp:Label ID="notice" runat="server" Text=""></asp:Label><asp:HiddenField ID="pageindexHidden"
                                runat="server" />
                        </td>
                    </tr>
                    <tr>
                    <td align="center"><asp:Button ID="Button1" runat="server"   onclick="Button_do_Click" Text="-确定所选的用户-" />&nbsp;
                    <asp:Button ID="Button2" runat="server" OnClientClick="window.parent.parent.GB_hide();" Text="-关闭-" /></td>
                    </tr>
                </table>
    </div>
    </form>
</body>
</html>
