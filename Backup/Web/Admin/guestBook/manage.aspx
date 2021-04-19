<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/ajaxAdmin_noSession.Master"
    CodeBehind="manage.aspx.cs" Inherits="Dianda.Web.Admin.guestBook.manage" %>
 
<%@ Register src="managemodel.ascx" tagname="managemodel" tagprefix="uc2" %>
 
 

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <table height="40px" align="center" bgcolor="#A8A6A7" cellpadding="0" cellspacing="0"
        width="100%">
        <tr bgcolor="#ffffff">
            <td>
     <uc2:managemodel ID="managemodel1" runat="server" />
     <br /></td></tr></table>
</asp:Content>
