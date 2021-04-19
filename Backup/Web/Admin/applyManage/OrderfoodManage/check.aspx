<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/OAmaster.Master" AutoEventWireup="true" CodeBehind="check.aspx.cs" Inherits="Dianda.Web.Admin.applyManage.OrderfoodManage.check" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table border="0" cellpadding="0" cellspacing="0" width="100%" class="tab_height1">
        <tr><td height="3px"></td></tr>
        <tr><td valign="top">
          <table align="center" cellpadding="0" cellspacing="0" width="98%">
    <tr><td><table class="tab3"><tr><td><table class="tab4"><tr><td valign="top">
                                    <table class="tab5"><tr><td>
      <table width="100%" border="0" cellspacing="0" cellpadding="5">
  <tr>
    <td colspan="4" align="center"><asp:Label ID="tag" runat="server" Text=""  ForeColor="Red"/></td>
  </tr>
  <tr style="background-color:#A5BBF1;">
    <td colspan="4" align="left"><asp:Label ID="notice1" runat="server" Text="申请基本信息"  ForeColor="Red"/></td>
  </tr>
  <tr>
    <td>项目名称：<asp:Label ID="Label_ProjectName" runat="server" Text=""></asp:Label></td>
    <td>提交申请时间：<asp:Label ID="Label_DATETIME" runat="server" Text=""></asp:Label></td> 
    <td>预订份额：<asp:Label ID="Label_OrderNum" runat="server" Text=""></asp:Label></td>


  </tr>
  <tr>
      <td>订饭申请人：<asp:Label ID="Label_SendUserID" runat="server" Text=""></asp:Label></td>
      <td>用饭日期时间：<asp:Label ID="Label_UserDatetime" runat="server" Text=""></asp:Label></td>
      <td><asp:Label ID="Label_LimitNums" runat="server" Text="" ForeColor="red"></asp:Label></td>
  </tr>
  <tr>
    <td colspan="3">申请事由(备注)：<asp:Label ID="Label_Overviews" runat="server" Text=""></asp:Label></td>
  </tr>
  <tr style="background-color:#A5BBF1;">
  <td colspan = "3" align="left"><asp:Label ID="notice2" runat="server" Text="审批信息"  ForeColor="Red"/></td>
  </tr>
  <tr>
    <td  colspan="3">
        <table border="0" width="100%">
        <tr>
            <td width="60px">审批结果：</td>
            <td align="left"><asp:RadioButtonList ID="RadioButtonList_Check" runat="server" RepeatColumns="4">
                      <asp:ListItem Value="1" Selected="True">确认</asp:ListItem>
                      <asp:ListItem Value="3">挂起</asp:ListItem>
                      </asp:RadioButtonList>
            </td>
        </tr>
       </table>
   </td>
  </tr>
  <tr>
      <td  colspan="3">
        <table border="0" width="100%">
        <tr>
            <td width="60px">审批备注：</td>
            <td align="left">
            <asp:TextBox ID="TB_DoNote"  runat="server" Style="width: 500px;" Height="80px" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
       </table>
   </td>
  </tr>
  <tr>
  <td colspan="2" align="center"><asp:Button ID="Button_sumbit" runat="server"  Text=" 确定 " OnClientClick="if(confirm('您确定要审批吗？')){return true;}else{return false;}" OnClick="Button_sumbit_onclick" CssClass="button1"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button_goback" OnClick="Button_goback_onclick" runat="server"  Text=" 返回 " CssClass="button1"/></td>
  </tr>
</table>
    </td></tr></table></td></tr><tr height="20px"><td></td></tr></table></td></tr></table>
    <table class="tab6"><tr><td align="center"><img src="/Admin/images/OAimages/Separator_content.jpg"></td></tr></table>
    </td></tr></table>
    </td><td width="5"></td></tr></table>

</asp:Content>
