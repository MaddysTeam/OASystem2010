<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CalendarControl.ascx.cs" Inherits="Dianda.Web.Admin.presonPlan.OApresonmanage.CalendarControl" %>
<style type="text/css">
    .style1
    {
        width: 366px;
    }
    .style2
    {
        width: 267px;
    }
    .style3
    {
        width: 24px;
    }
</style>
<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
   <ContentTemplate>
   
       <table align="center" class="style1">
           <tr>
               <td colspan="2">
                   &nbsp;</td>
                   <td>
                   </td>
           </tr>
           <tr>
               <td class="style2">
                   <asp:Calendar ID="Calendar1" runat="server" ShowDayHeader="False" 
                       ShowGridLines="True" ShowNextPrevMonth="False" ShowTitle="False" Width="328px">
                   </asp:Calendar>
               </td>
               <td>
                   &nbsp;</td>
           </tr>
       </table>
   
   </ContentTemplate>
</asp:UpdatePanel>
