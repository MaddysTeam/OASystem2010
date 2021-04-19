<%@ Page Title="" Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/OAmaster.Master" AutoEventWireup="true" CodeBehind="check.aspx.cs" Inherits="Dianda.Web.Admin.SystemProjectManage.ProjectCheck.check" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
<table border="0" cellpadding="0" cellspacing="0" width="100%" class="tab_height2">
        <tr><td height="3px"></td></tr>
        <tr><td valign="top">
          <table align="center" cellpadding="0" cellspacing="0" width="98%">
    <tr><td><table class="tab3"><tr><td><table class="tab4"><tr><td>
                                    <table class="tab5"><tr><td>
      <table width="100%" border="0" cellspacing="0" cellpadding="5">
  <tr>
    <td colspan="3" align="center"><asp:Label ID="tag" runat="server" Text=""  ForeColor="Red"/></td>
  </tr>
  <tr style="background-color:#A5BBF1;">
    <td colspan="3" align="left"><asp:Label ID="notice1" runat="server" Text="项目基本信息"  ForeColor="Red"/></td>
  </tr>
  <tr>
    <td>项目名称：<asp:Label ID="Label_ProjectName" runat="server" Text=""></asp:Label></td>
    <td>项目申请时间：<asp:Label ID="Label_DATETIME" runat="server" Text=""></asp:Label></td> 
    <td>预计经费：<asp:Label ID="Label_CashTotal" runat="server" Text=""></asp:Label></td>


  </tr>
  <tr>
      <td>立项申请人：<asp:Label ID="Label_SendUserID" runat="server" Text=""></asp:Label></td>
      <td>预计开始时间：<asp:Label ID="Label_StartTime" runat="server" Text=""></asp:Label></td>
      <td>项目资金卡：<asp:Label ID="Label_CashCardID" runat="server" Text=""></asp:Label></td>
  </tr>
  <tr>
      <td>项目负责人：<asp:Label ID="Label_LeaderID" runat="server" Text=""></asp:Label></td>
      <td>预计结束时间：<asp:Label ID="Label_EndTime" runat="server" Text=""></asp:Label></td>
      <td>参与部门：<asp:Label ID="Label_DepartmentID" runat="server" Text=""></asp:Label></td>
  </tr>
  <tr>
    <td colspan="3">项目概要：<asp:Label ID="Label_Overviews" runat="server" Text=""></asp:Label></td>
  </tr>
  <tr>
    <td colspan="3"><asp:Label ID="LB_fj" runat="server" Text=""></asp:Label></td>
  </tr>
  
  <tr style="background-color:#A5BBF1;">
  <td colspan = "3" align="left"><asp:Label ID="notice2" runat="server" Text="审批信息"  ForeColor="Red"/><asp:Label ID="LB_CheckNotice"
          runat="server" Text="" ForeColor="red"></asp:Label></td>
  </tr>
  <tr>
    <td colspan = "3">
    <table border="0" width="100%">
    <tr><td  width="55%">
        <table border="0" width="100%">
          <tr>
            <td style=" width:380px;">
                <table border="0" width="100%">
                <tr valign="middle">
                    <td width="60px">审批结果：</td>
                    <td align="left" style=" width:170px;" valign="middle">
                    
                                  <asp:RadioButtonList ID="RadioButtonList_Check" runat="server" RepeatColumns="4" OnSelectedIndexChanged="RadioButtonList_Check_Change" AutoPostBack="true">
                                  <asp:ListItem Value="1">通过</asp:ListItem>
                                  <asp:ListItem Value="2">不通过</asp:ListItem>
                                  <asp:ListItem Value="3">移交</asp:ListItem>
                                  </asp:RadioButtonList>&nbsp;&nbsp;&nbsp;

                    </td>
                    <td><asp:DropDownList ID="DDL_CheckUserList" runat="server" Visible="false"></asp:DropDownList></td>
                </tr>
               </table>
           </td>
        </tr>
              <tr>
                  <td>
                    <table border="0" width="100%">
                    <tr>
                        <td width="60px">审批备注：</td>
                        <td align="left">
                        <asp:TextBox ID="TB_DoNote"  runat="server" Style="width: 280px;" Height="80px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                        <td></td>
                    </tr>
                   </table>
               </td>
              </tr>
              <tr>
              <td align="center" style="padding-top:10px; width:280px;"><asp:Button ID="Button_sumbit" runat="server"  Text=" 确定 " OnClientClick="if(confirm('您确定要审批吗？')){return true;}else{return false;}" OnClick="Button_sumbit_onclick" CssClass="button1"/>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button_goback" OnClick="Button_goback_onclick" runat="server"  Text=" 返回 " CssClass="button1"/></td>
              </tr>
    </table>
</td>
    <td valign="top" align="left" style=" width:45%;"><asp:Label ID="LB_CheckInfo" runat="server" Text=""></asp:Label></td>
    
    </td></tr></table>
        
  </tr>
  
</table>
    </td></tr></table></td></tr><tr height="20px"><td></td></tr></table></td></tr></table><table class="tab6"><tr><td align="center"><img src="/Admin/images/OAimages/Separator_content.jpg"></td></tr></table>
    </td></tr></table>
    </td><td width="5"></td></tr></table>
    
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
