<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/OAmaster.Master" AutoEventWireup="true"
    CodeBehind="department_Index.aspx.cs" Inherits="Dianda.Web.Admin.department_Index" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="ucProjectUserList.ascx" TagName="ucProjectUserList" TagPrefix="uc1" %>
<%@ Register Src="ucProjectHot.ascx" TagName="ucProjectHot" TagPrefix="uc2" %>
<%@ Register Src="ucProjectNews.ascx" TagName="ucProjectNews" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="margin-left: 7px; margin-top: 3px;">
        <tr style="height: 100%; background-color: White;">
            <td valign="top">
                <cc1:TabContainer ID="TabContainer_listtree" runat="server" ActiveTabIndex="0" CssClass="AjaxTabStrip_bumen">
                    <cc1:TabPanel runat="server" ID="tpHot" HeaderText="部门热点">
                        <HeaderTemplate>
                            部门热点
                        </HeaderTemplate>
                        <ContentTemplate>
                            <uc2:ucProjectHot ID="ucProjectHot1" runat="server" />
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel runat="server" ID="tpNews" HeaderText="部门项目">
                        <ContentTemplate>
                            <uc3:ucProjectNews ID="ucProjectNews1" runat="server" />
                        </ContentTemplate>
                    </cc1:TabPanel>
                </cc1:TabContainer>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <uc1:ucProjectUserList ID="ucProjectUserList1" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
