<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/OAmaster.Master" AutoEventWireup="true"
    CodeBehind="columns.aspx.cs" Inherits="Dianda.Web.Admin.newsManage.OAcolumns.columns1" %>
<%@ Register src="uccolumns.ascx" tagname="uccolumns" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc2:uccolumns ID="uccolumns1" runat="server" />
</asp:Content>
