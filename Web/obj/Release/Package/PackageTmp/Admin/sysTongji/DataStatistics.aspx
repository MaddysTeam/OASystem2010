<%@ Page Language="C#" MasterPageFile="~/Admin/OAmaster.Master" AutoEventWireup="true"
    CodeBehind="DataStatistics.aspx.cs" Inherits="Dianda.Web.Admin.sysTongji.DataStatistics"
    Title="数据统计" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table align="center" cellpadding="0" cellspacing="0" width="100%" class="tab_height1">
        <tr>
            <td height="3px">
            </td>
        </tr>
        <tr>
            <td valign="top">
                <table align="center" bgcolor="#99cccd" cellpadding="0" cellspacing="0" width="98%">
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0" width="100%">
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
                                                                        <td>
                                                                            <table class="tab2">
                                                                                <tr>
                                                                                    <td align="left">
                                                                                        起始年份：
                                                                                        <asp:DropDownList ID="ddlYear" runat="server">
                                                                                        </asp:DropDownList>
                                                                                        &nbsp;&nbsp;
                                                                                        起始月份：
                                                                                        <asp:DropDownList ID="ddlMonth" runat="server">
                                                                                            <asp:ListItem Value="-1">-请选择-</asp:ListItem>
                                                                                            <asp:ListItem Value="01">1</asp:ListItem>
                                                                                            <asp:ListItem Value="02">2</asp:ListItem>
                                                                                            <asp:ListItem Value="03">3</asp:ListItem>
                                                                                            <asp:ListItem Value="04">4</asp:ListItem>
                                                                                            <asp:ListItem Value="05">5</asp:ListItem>
                                                                                            <asp:ListItem Value="06">6</asp:ListItem>
                                                                                            <asp:ListItem Value="07">7</asp:ListItem>
                                                                                            <asp:ListItem Value="08">8</asp:ListItem>
                                                                                            <asp:ListItem Value="09">9</asp:ListItem>
                                                                                            <asp:ListItem Value="10">10</asp:ListItem>
                                                                                            <asp:ListItem Value="11">11</asp:ListItem>
                                                                                            <asp:ListItem Value="12">12</asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                        至
                                                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                        结束年份：
                                                                                        <asp:DropDownList ID="ddltoYear" runat="server">
                                                                                        </asp:DropDownList>
                                                                                        &nbsp;&nbsp;
                                                                                        结束月份：
                                                                                        <asp:DropDownList ID="ddltoMonth" runat="server">
                                                                                            <asp:ListItem Value="-1">-请选择-</asp:ListItem>
                                                                                            <asp:ListItem Value="01">1</asp:ListItem>
                                                                                            <asp:ListItem Value="02">2</asp:ListItem>
                                                                                            <asp:ListItem Value="03">3</asp:ListItem>
                                                                                            <asp:ListItem Value="04">4</asp:ListItem>
                                                                                            <asp:ListItem Value="05">5</asp:ListItem>
                                                                                            <asp:ListItem Value="06">6</asp:ListItem>
                                                                                            <asp:ListItem Value="07">7</asp:ListItem>
                                                                                            <asp:ListItem Value="08">8</asp:ListItem>
                                                                                            <asp:ListItem Value="09">9</asp:ListItem>
                                                                                            <asp:ListItem Value="10">10</asp:ListItem>
                                                                                            <asp:ListItem Value="11">11</asp:ListItem>
                                                                                            <asp:ListItem Value="12">12</asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td align="right">
                                                                                        <asp:Button ID="btnExcel" runat="server" Text="统计" CssClass="button3a" 
                                                                                            onclick="btnExcel_Click" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr height="20px">
                                                            <td>
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
</asp:Content>
