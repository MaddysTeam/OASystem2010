<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/OAmaster.Master" AutoEventWireup="true"
    CodeBehind="manage.aspx.cs" Inherits="Dianda.Web.Admin.personalProjectManage.OANews.manage" %>

<%@ Register Src="ucmanage.ascx" TagName="ucmanage" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:ucmanage ID="ucmanage1" runat="server" />
</asp:Content>
