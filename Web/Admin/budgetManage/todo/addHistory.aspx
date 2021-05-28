<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/OAmaster.Master" CodeBehind="addHistory.aspx.cs" Inherits="Dianda.Web.Admin.budgetManage.todo.addHistory" %>
<%@ Register Src="/Admin/cashCardManage/OAleftmenu.ascx" TagName="OAleftmenu" TagPrefix="uc1" %>
<%@ Register Src="/Admin/budgetManage/Budget_Show.ascx" TagName="ucshow" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="/Admin/js/SelectDate.js" type="text/javascript"></script>

    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td width="4">
            </td>
            <td valign="top" width="115" align="left">
                <uc1:OAleftmenu ID="OAleftmenu1" runat="server" />
            </td>
            <td width="5">
            </td>
            <td valign="top">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td height="3px">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table align="center" bgcolor="#99cccd" cellpadding="0" cellspacing="0" width="98%">
                                <tr>
                                    <td>
                                        <table cellpadding="0" cellspacing="0" width="100%">
                                            <tr>
                                                <td colspan="2">
                                                    <table class="tab1" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td class="tab1_td1">
                                                                &nbsp;
                                                            </td>
                                                            <td class="tab1_td2">
                                                                <asp:Label ID="LB_name" runat="server" Text="" CssClass="LB_name1"></asp:Label>记账
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table class="tab4" border="0">
                                                        <tr>
                                                            <td width="350px" valign="top">
                                                                <div id="div2" runat="server" style="padding-top: 20px; text-align: right;">
                                                                    <table width="95%" border="0" style="text-align: left;">   
                                                                    <tr><td colspan="2" align="center"><asp:Label ID="tag2" runat="server" Text="" CssClass="tag1" /></td></tr>                                                                   
                                                                        <tr>
                                                                            <td colspan="2">
                                                                                <asp:GridView ID="GridView1" Width="100%" style="border:solid 1px #99CCCD"  
                                                                                    DataKeyNames="id" runat="server"  CellPadding="0"
                                                                                    AutoGenerateColumns="False" onrowdatabound="GridView1_RowDataBound">
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="项目经费操作情况">
                                                                                            <ItemTemplate>
                                                                                                <table width="100%"  style="text-align:left" cellpadding="1" cellspacing="2">
                                                                                                    <tr>
                                                                                                        <td width="70px" align="right" style="word-break: break-all;" >
                                                                                                            <asp:HiddenField ID="HF_DetailID" runat="server" Value='<%# Eval("ID")%>'/>
                                                                                                            <asp:Label ID="Label_Name" runat="server" Text='<%# Eval("DetailName")%>'></asp:Label>：
                                                                                                        </td>                                                                                                        
                                                                                                        <td>
                                                                                                            <asp:TextBox ID="txtBalance" runat="server" CssClass="textbox_name" Width="70px" Text="0"></asp:TextBox>&nbsp;/&nbsp;<asp:Label
                                                                                                                ID="LB_Balance" runat="server" Text='<%# Eval("Balance")%>'></asp:Label>&nbsp;元
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>                                                                                                       
                                                                                                        <td>
                                                                                                        </td>
                                                                                                        <td>
                                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="Server" ControlToValidate="txtBalance"
                                                                                                                ValidationGroup="add" ErrorMessage="金额不能为空!" Display="Dynamic" /><asp:RegularExpressionValidator
                                                                                                                    ID="RegularExpressionValidator2" runat="Server" ControlToValidate="txtBalance"
                                                                                                                    ValidationGroup="add" ValidationExpression="^([0-9]\d{0,11})$|^(0|[0-9]\d{0,11})\.(\d{0,2})$"
                                                                                                                    ErrorMessage="金额只能输入到小数点前12位小数点后2位的正数!" Display="Dynamic" />
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle Font-Bold="True" Height="30px" HorizontalAlign="Center" 
                                                                                                BackColor="#99CCCD" BorderColor="#99CCCD" />
                                                                                            <ItemStyle BorderColor="#99CCCD" BorderStyle="Solid" BorderWidth="1px" />
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                </asp:GridView>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                操作类型：
                                                                            </td>
                                                                            <td>
                                                                                <asp:RadioButtonList ID="rblDoType" runat="server" RepeatColumns="2">
                                                                                    <asp:ListItem Value="1">增加</asp:ListItem>
                                                                                    <asp:ListItem Selected="True" Value="2">减少</asp:ListItem>
                                                                                </asp:RadioButtonList>
                                                                            </td>
                                                                        </tr>
                                                                          
                                                                        <tr>
                                                                            <td >
                                                                              备注：
                                                                            </td>
                                                                            <td >
                                                                                <asp:TextBox ID="TextBox1" Width="98%" Height="65px" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" align="center">
                                                                              <asp:Label ID="tag" runat="server" Text="" CssClass="tag1" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Button ID="Button_sumbit" runat="server" ValidationGroup="add" Text="确定" OnClick="Button_sumbit_Click"
                                                                                    CommandArgument="1" CssClass="button1" />&nbsp;&nbsp;&nbsp;<asp:Button ID="Button_sumbit0"
                                                                                        runat="server" ValidationGroup="add" Text="保存并继续" OnClick="Button_sumbit_Click"
                                                                                        CommandArgument="2" CssClass="button1" Width="77px" />&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button
                                                                                            ID="Button_cancel" runat="server" Text="返回" CssClass="button1" OnClick="Button_cancel_Click" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                            </td>
                                                            <td valign="top" style="width: 350px; padding-top: 25px;">
                                                                <table class="tab5" height="180" border="0" cellpadding="0" cellspacing="1" bgcolor="99cccd">
                                                                    <tr style="background-color: #99cccd" height="25px">
                                                                        <td align="center" colspan="2" style="height:30px;">
                                                                            &nbsp;&nbsp;&nbsp;<asp:Label ID="lblBudgetName" Font-Bold="true" runat="server" Text=""></asp:Label>&nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="background-color: #ffffff">
                                                                        <td style="width: 100px; height:29px;" align="right">
                                                                            经费预算编号：
                                                                        </td>
                                                                        <td>
                                                                            &nbsp;<asp:Label ID="lblBudgetCode" runat="server" Text=""></asp:Label>
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="background-color: #ffffff">
                                                                        <td align="right" style="width: 100px; height:29px;">
                                                                            所属项目：
                                                                        </td>
                                                                        <td>
                                                                            &nbsp;<asp:Label ID="lblParentBudget" runat="server" Text=""></asp:Label>
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="background-color: #ffffff">
                                                                        <td align="right" style="width: 100px; height:29px;">
                                                                            所属部门：
                                                                        </td>
                                                                        <td>
                                                                            &nbsp;<asp:Label ID="lblDepartment" runat="server" Text=""></asp:Label>
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="background-color: #ffffff">
                                                                        <td align="right" style="width: 100px; height:29px;">
                                                                            负责人：
                                                                        </td>
                                                                        <td>
                                                                            &nbsp;<asp:Label ID="lblManager" runat="server" Text=""></asp:Label>
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="background-color: #ffffff">
                                                                        <td align="right" style="width: 100px; height:29px;">
                                                                            项目审批人：
                                                                        </td>
                                                                        <td>
                                                                            &nbsp;<asp:Label ID="lblApprover" runat="server" Text=""></asp:Label>
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                   <%-- <tr style="background-color: #ffffff">
                                                                        <td align="right" style="width: 100px; height:29px;">
                                                                            持卡人：
                                                                        </td>
                                                                        <td>
                                                                            &nbsp;<asp:Label ID="lblCardholderRealName" runat="server" Text=""></asp:Label>
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    --%>
                                                                    
                                                                    <tr style="background-color: #ffffff">
                                                                        <td align="right" style="width: 100px; height:29px;">
                                                                            预算经费总额：
                                                                        </td>
                                                                        <td>
                                                                            &nbsp;<asp:Label ID="lblBalance" runat="server" Text=""></asp:Label>
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="background-color: #ffffff">
                                                                        <td align="right" style="width: 100px; height:29px;">
                                                                            项目起止时间：
                                                                        </td>
                                                                        <td>
                                                                            &nbsp;<asp:Label ID="lblStartEndDate" runat="server" Text=""></asp:Label>
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <%-- <tr style="background-color: #ffffff">
                                                                        <td align="right" style="width: 100px; height:29px;">
                                                                           到期时间：
                                                                        </td>
                                                                        <td>
                                                                            &nbsp;<asp:Label ID="Label_Time" runat="server" Text=""></asp:Label>
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="background-color: #ffffff">
                                                                        <td align="right" style="width: 100px; height:29px;">
                                                                            状态：
                                                                        </td>
                                                                        <td>
                                                                            &nbsp;<asp:Label ID="lblStatas" runat="server" Text=""></asp:Label>
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>--%>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="5px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <img src="/Admin/images/OAimages/Separator_content.jpg">
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="10px">
                        </td>
                    </tr>
                </table>
            </td>
            <td width="5">
            </td>
        </tr>
    </table>
</asp:Content>