<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/OAmaster.Master" AutoEventWireup="true" CodeBehind="sysrili.aspx.cs" Inherits="Dianda.Web.Admin.sysrili" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script src="/Admin/js/SelectDate.js" type="text/javascript"></script>
<table align="center" bgcolor="#ffffff" cellpadding="0" cellspacing="0"  width="100%">
    <tr><td height="3px"></td></tr>
        <tr  height="340px">
            <td  align="center">
            学期开始时间：<input  class="Inputtext"  id="starttime" runat="server" Width="200" type="text" readonly="readonly" onClick="ShowCalendar(this);" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br /><br />学期结束时间：<input  class="Inputtext"  id="endtime" runat="server" Width="200" type="text" readonly="readonly" onClick="ShowCalendar(this);" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br /><br /><asp:Button ID="Button_sumbit" runat="server" ValidationGroup="add1" Text=" 确定 " OnClick="Button_queding_Click" CssClass="button1"/>
            </td>
            </tr>
            <tr><td align="center">
                <asp:Label ID="Label_notice"  runat="server" Text=""></asp:Label></td></tr>
                <tr height="30"><td bgcolor="#125697" style="color:White" height="50" align="center">设置时间时，学期开始的时间请设置为星期一；学期结束的时间请设置为星期天。谢谢！</td></tr>
            </table>
</asp:Content>
