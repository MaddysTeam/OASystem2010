<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/OAmaster.Master" AutoEventWireup="true" CodeBehind="Cash_Account.aspx.cs" Inherits="Dianda.Web.Admin.cashCardManage.Cash_Account" %>
<%@ Register Src="OAleftmenu.ascx" TagName="OAleftmenu" TagPrefix="uc1" %>
<%@ Register src="OAleftmenu_Show.ascx" tagname="OAleftmenu_Show" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table align="center" cellpadding="0" cellspacing="0" width="100%" bgcolor="#99cccd">
        <tr>
            <td width="10">
            </td>
            <td valign="top" width="115" align="left">
                <uc1:OAleftmenu ID="OAleftmenu1" runat="server" Visible="false" />
                <uc2:OAleftmenu_Show ID="OAleftmenu_Show1" runat="server" Visible="false" />
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
                                                    账户管理
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
                                                                        <td align="right">
                                                                            <table>
                                                                                <tr>
                                                                                   
                                                                                    <%--<td align="center">
                                                                                        <a id="show_manage" runat="server" href="YYJEHZ.aspx" target="_self" rel="gb_page_center[726,400]"
                                                                                                        class="button3d" style="text-decoration: none" title="">预约金额汇总</a>
                                                                                    </td>--%>
                                                                                    <td align="center">
                                                                                    <asp:Button ID="Button_add" runat="server" Text="新建"  
                                                                                                                    CssClass="button3a" onclick="Button_add_Click" />
                                                                                    </td>
                                                                                    <td align="center">
                                                                                     <asp:Button ID="Button1" runat="server" Text="编辑"   CssClass="button3a" 
                                                                                            onclick="Button1_Click" />
                                                                                    </td>
                                                                                    <td align="center">
                                                                                     <asp:Button ID="Button_delete" runat="server" Text="注销" OnClientClick="if(confirm('您确定要注销吗？')){return true;}else{return false;}"
                                                                                                                  CssClass="button3a" onclick="Button_delete_Click" />
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
                                                                        <td align="center">
                                                                            <asp:GridView ID="GridView1" AutoGenerateColumns="False"
                                 DataKeyNames="ID"                                               runat="server" CssClass="GridView1">
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
                                                                                    <asp:BoundField HeaderText="账户名称↑" DataField="NAMES">
                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                    </asp:BoundField>
                                                                                      <asp:TemplateField HeaderText="状态">
                                                                                        <ItemTemplate>
                                                                                          <%#Eval("STATUS").ToString()=="1"?"正常":"冻结" %>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                    </asp:TemplateField>
                                                                                     <asp:BoundField HeaderText="创建时间" DataField="ADDTIME" DataFormatString="{0:yyyy-MM-dd}">
                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                    </asp:BoundField>
                                                                                  
                                                                                    <asp:BoundField HeaderText="账户余额(元)" DataField="Balance">
                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField HeaderText="每日限额(元)" DataField="EveryDayNum">
                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                    </asp:BoundField>
                                                                                     
                                                                                </Columns>
                                                                                <FooterStyle CssClass="FooterStyle1" />
                                                                                <PagerStyle HorizontalAlign="Left" CssClass="PagerStyle1" />
                                                                                <SelectedRowStyle CssClass="SelectedRowStyle1" />
                                                                            </asp:GridView>
                                                                           
                                                                  
                                                                            <asp:Label ID="notice" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <br />
                                                        
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
    </table>
</asp:Content>
