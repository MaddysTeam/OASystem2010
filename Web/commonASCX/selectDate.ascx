<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="selectDate.ascx.cs" Inherits="Dianda.Web.commonASCX.selectDate" %>
<asp:DropDownList ID="DropDownList_Y" runat="server" AutoPostBack="True" 
    onselectedindexchanged="DropDownList_Y_SelectedIndexChanged"></asp:DropDownList>
<asp:DropDownList ID="DropDownList_M" runat="server" AutoPostBack="True" 
    onselectedindexchanged="DropDownList_M_SelectedIndexChanged"></asp:DropDownList><asp:DropDownList ID="DropDownList_D" runat="server"></asp:DropDownList>


