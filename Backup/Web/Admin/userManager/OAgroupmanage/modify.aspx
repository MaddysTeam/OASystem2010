<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/OAmaster.Master" AutoEventWireup="true" CodeBehind="modify.aspx.cs" Inherits="Dianda.Web.Admin.userManager.OAgroupmanage.modify" %>
<%@ Register src="~/Admin/OAleftmenu.ascx" tagname="OAleftmenu" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <table cellpadding="0" cellspacing="0" width="100%" class="tab_height1">
            <tr>
            <td width="4"></td>
                <td valign="top" width="115" align="left">
                    <uc1:OAleftmenu ID="OAleftmenu" runat="server" />
                </td>
                <td width="5"></td>
                <td valign="top">
                
    <table align="center" cellpadding="0" cellspacing="0" width="100%">
    <tr><td height="3px"></td></tr>
       <tr><td>
       <table align="center" cellpadding="0" cellspacing="0" width="98%">
       <tr><td>
          <table class="tab1" cellpadding="0" cellspacing="0"><tr><td class="tab1_td1">&nbsp;</td><td class="tab1_td2"><asp:Label ID="LB_NAME1" runat="server" Text="Label" CssClass="LB_name1"></asp:Label>���� >>�༭<asp:Label ID="LB_NAME2" runat="server" Text="Label" CssClass="LB_name1"></asp:Label>
          </td></tr></table>  
          </td></tr>
      <tr><td>
      <table class="tab3"><tr><td><table class="tab4"><tr><td valign="top">
                                    <table class="tab5"><tr><td>
                                    
      <table><tr><td colspan = "3" align="center"><asp:Label ID="tag" runat="server" Text=""  ForeColor="Red"/></td></tr>
      <tr>
     <td style="height: 40px;" align="right">
         ���ƣ�
    </td>
      <td style="height: 40px; color: #ff0000;">
         <asp:TextBox ID="NAME"    runat="server" CssClass="textbox_name"></asp:TextBox>
          (*������)
      </td>
    </tr>
    <tr>
     <td></td>
      <td><ASP:RequiredFieldValidator id="Validator1" Runat="Server" ValidationGroup="add"
������ControlToValidate="NAME"
������ErrorMessage="���Ʋ���Ϊ��!"
������Display="Dynamic" /><ASP:RegularExpressionValidator id="RegularExpressionValidator1" RunAt="Server"
ControlToValidate="NAME" ValidationGroup="add"
ValidationExpression="^([\u4e00-\u9fa5]|[0-9_a-zA-Z]){2,25}$"
errorMessage="������2~25�ַ�!"
display="Dynamic" /></td>
    </tr>
    
        <tr>
     <td style="height: 46px;" align="right" valign="top">
     ������
    </td>
      <td style="height: 46px">
         <asp:TextBox ID="CONTENT"  runat="server" CssClass="textbox_content" TextMode="MultiLine"></asp:TextBox></td>
    </tr>
    <tr>
    <td></td>    
    <td style="padding-left:300px; padding-top:10px">
      <asp:Button ID="Button_sumbit" runat="server" ValidationGroup="add"  Text=" ȷ�� " OnClick="Button_queding_Click" CssClass="button1" />��<asp:Button ID="Button_goback" runat="server" Text="����" OnClick="Button_goback_Click" CssClass="button1" />
    </td>
    </tr></table>
    </td></tr></table></td></tr><tr height="20px"><td></td></tr></table></td></tr></table>
    <table class="tab6"><tr><td align="center"><img src="/Admin/images/OAimages/Separator_content.jpg"></td></tr></table>
    </td></tr></table>
    </td></tr>
    <tr><td height="10px"></td></tr>
   </table>
                   </td>
                <td width="5"></td>
            </tr>
        </table>
</asp:Content>
