<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="orderFood.ascx.cs" Inherits="Dianda.Web.Admin.personalProjectManage.OAapply.orderFood" %>
<script language=javascript type="text/javascript">
    function check() {
        var ordertime = document.getElementById("ctl00_ContentPlaceHolder1_orderFood_TB_ordertime").value;

        if (ordertime.length == 0) {
            alert("订饭时间不能为空!");
            return false;
        }
    }
      function SetValue(str)
    {
    document.getElementById("<%= HiddenField2.ClientID%>").value=str;   
    return true;
    }
  </script>
  <asp:HiddenField ID="HiddenField2" runat="server" />
<table border="0" cellpadding="0" cellspacing="0" width="100%" bgcolor="#99CCCD">
    <tr>
        <td align="right"  Width="100">用饭日期时间：</td>
        <td align="left" valign="middle"><input  class="Inputtext"  id="TB_ordertime" runat="server" Width="200" type="text" readonly="readonly" onClick="ShowCalendar(this);" onpropertychange="SetValue('fales');" />&nbsp;&nbsp;&nbsp;<asp:Button ID="Button_Check" runat="server" Text="检查是否可预订"  CssClass="button4" OnClick="Button_Check_Click" OnClientClick="SetValue('true');" /><asp:HiddenField ID="HF_ordernums" runat="server" />
        </td>
    </tr>
    <tr>
        <td align="right">预订：</td>
        <td><asp:TextBox ID="TB_nums" runat="server"></asp:TextBox>&nbsp;&nbsp;份&nbsp;&nbsp;<asp:Label ID="LB_notice" runat="server" Text="" ForeColor="Red"></asp:Label></td>
    </tr>
</table>
