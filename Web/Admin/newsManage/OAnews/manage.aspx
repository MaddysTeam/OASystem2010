<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/OAmaster.Master" AutoEventWireup="true"
    CodeBehind="manage.aspx.cs" Inherits="Dianda.Web.Admin.newsManage.OAnews.manage" %>

<%@ Register Src="ucmanage.ascx" TagName="ucmanage" TagPrefix="uc1" %>
<%@ Register Src="UcNews.ascx" TagName="UcNews" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="0" cellspacing="0" width="100%" class="tab_height1">
        <tr>
            <td>
            </td>
            <td rowspan="2" valign="top" width="115" align="left">
                <uc2:UcNews ID="UcNews1" runat="server" />
            </td>
            <td>
            </td>
            <td align="left">
                <table align="center" cellpadding="0" cellspacing="0" width="98%">
                    <tr>
                        <td height="3px">
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
                                        <asp:Label ID="LabelTitle" Style="font-size: 12px; color: White" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td width="10">
            </td>
            <td width="5">
            </td>
            <td valign="top">
                <uc1:ucmanage ID="ucmanage1" runat="server" />
            </td>
            <td width="5">
            </td>
        </tr>
    </table>
</asp:Content>
