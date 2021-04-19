<%@ Page Language="C#" AutoEventWireup="true"   MasterPageFile="~/Admin/ajaxAdmin_noSession.Master"  CodeBehind="powertolk.aspx.cs" Inherits="Dianda.Web.Admin.DOC_transport.powertolk" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder2" runat="server" ID="ContentPlaceHolder2">
<iframe name="middle" src="http://www.shtvsss.com/totalOnline/Default.aspx?user=<%=Session["USERID_SYSUSER"].ToString()%>" allowtransparency="true" align="middle" frameborder="0" width="100%" height="500"></iframe>
</asp:Content>
