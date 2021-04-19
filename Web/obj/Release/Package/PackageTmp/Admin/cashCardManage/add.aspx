<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/OAmaster.Master" AutoEventWireup="true"
    CodeBehind="add.aspx.cs" Inherits="Dianda.Web.Admin.cashCardManage.add" %>

<%@ Register Src="Cash_CarDetailList.ascx" TagName="Cash_CarDetailList" TagPrefix="uc2" %>
<%@ Register Src="OAleftmenu.ascx" TagName="OAleftmenu" TagPrefix="uc1" %>
<%@ Register src="Cash_CarDetailMX.ascx" tagname="Cash_CarDetailMX" tagprefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="/Admin/js/SelectDate.js" type="text/javascript"></script>

    <%--    
    <script type="text/javascript">
        function ChangeTotalText() {

            var inputs = document.getElementById("<%=GridView1.ClientID%>").getElementsByTagName("input");
            var total=0;
            for (var i = 0; i < inputs.length; i++) {
                if (inputs[i].type == "text") {
                    total = total + parseFloat(inputs[i].value)    //这是TextBox的Text值 
                    
                }
            }
            
            var txtLimitNums = document.getElementById("<%=txtLimitNums.ClientID%>");

            txtLimitNums.value = total;
            
            
        }
</script>--%>
<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0" width="100%" height="397">
                <tr>
                    <td width="4">
                    </td>
                    <td valign="top" width="115" align="left">
                        <uc1:OAleftmenu ID="OAleftmenu1" runat="server" />
                    </td>
                    <td width="5">
                    </td>
                    <td valign="top">
                        <table border="0" cellpadding="0" cellspacing="0" width="100%" bgcolor="#99cccd">
                            <tr>
                                <td height="3px">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table align="center" cellpadding="0" cellspacing="0" width="98%">
                                        <tr>
                                            <td>
                                                <table cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td>
                                                            <table class="tab1" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td class="tab1_td1">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td class="tab1_td2">
                                                                        <asp:Label ID="LB_name" runat="server" Text="" CssClass="LB_name1"></asp:Label>新建资金卡
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table class="tab4" border="0">
                                                                <tr>
                                                                    <td width="10">
                                                                    </td>
                                                                    <td style="width: 400px;" valign="top">
                                                                        <div id="div2" runat="server">
                                                                            <table border="0" width="100%">
                                                                                <tr>
                                                                                    <td colspan="2" align="center">
                                                                                        <asp:Label ID="tag" runat="server" Text="" CssClass="tag1" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td width="120">
                                                                                        资金卡编号：
                                                                                    </td>
                                                                                    <td align="left">
                                                                                        <asp:Label ID="lblCardNum" runat="server" Text="(提交后自动生成)" ForeColor="Gray"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        资金卡名称：
                                                                                    </td>
                                                                                    <td align="left">
                                                                                        <asp:TextBox ID="txtCardName" runat="server" CssClass="textbox_name" Width="180px"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RequiredFieldValidator ID="Validator1" runat="Server" ControlToValidate="txtCardName"
                                                                                            ValidationGroup="add2" ErrorMessage="资金卡名称不能为空!" Display="Dynamic" /><%--<asp:RegularExpressionValidator
                                                                                                ID="RegularExpressionValidator2" runat="Server" ControlToValidate="txtCardName"
                                                                                                ValidationGroup="add2" ValidationExpression="^([\u4e00-\u9fa5]|[0-9_a-zA-Z]){2,25}$"
                                                                                                ErrorMessage="资金卡名称在2~25字符!" Display="Dynamic" />--%>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        所属项目：
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlProjectID" runat="server" Width="180px">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        所属预算报告：
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="DDL_Budget" runat="server" Width="180px">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        所属部门：
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlDepartmentID" runat="server" Width="180px" AutoPostBack="true"
                                                                                            OnSelectedIndexChanged="ddlDepartmentID_SelectedIndexChanged">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        持卡人：
                                                                                    </td>
                                                                                    <td align="left">
                                                                                        <asp:DropDownList ID="ddlCardholderID" runat="server" Width="180px">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        到期时间：
                                                                                    </td>
                                                                                    <td>
                                                                                        <input id="TB_DateTime" runat="server" style="width: 176px" type="text" readonly="readonly"
                                                                                            onclick="ShowCalendar(this);" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        审批人：
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlApproverIDs" runat="server" Width="180px">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2">
                                                                                        资金卡细目如下：
                                                                                    </td>
                                                                                </tr>
                                                                                <%--                                                                        <tr visible="false">
                                                                            <td colspan="2">
                                                                                <asp:GridView ID="GridView1" Width="100%"  DataKeyNames="id"  OnRowDataBound="GridView1_RowDataBound"
                                                                                    runat="server" CellPadding="0" AutoGenerateColumns="False" ShowHeader="false" GridLines="None" Visible="false" >
                                                                                    <Columns>
                                                                                        <asp:TemplateField >
                                                                                            <ItemTemplate>
                                                                                                <table width="100%" style="text-align: left" cellpadding="0" cellspacing="0">
                                                                                                    <tr>
                                                                                                        <td width="105px" style="word-break: break-all;">
                                                                                                            <asp:Label ID="Label_Name" runat="server" Text='<%# Eval("INFORS")%>'></asp:Label>：
                                                                                                        </td>
                                                                                                        <td>
                                                                                                            <asp:TextBox ID="txtBalance" runat="server" Text="0"  CssClass="textbox_name"   Width="160px"></asp:TextBox>&nbsp;元
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                        </td>
                                                                                                        <td>
                                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="Server" ControlToValidate="txtBalance"
                                                                                                                ValidationGroup="add" ErrorMessage="费用不能为空!" Display="Dynamic" /><asp:RegularExpressionValidator
                                                                                                                    ID="RegularExpressionValidator2" runat="Server" ControlToValidate="txtBalance"
                                                                                                                    ValidationGroup="add" ValidationExpression="^([0-9]\d{0,11})$|^(0|[0-9]\d{0,11})\.(\d{0,2})$"
                                                                                                                    ErrorMessage="费用输入有误!" Display="Dynamic" />
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                </asp:GridView>
                                                                            </td>
                                                                        </tr>--%>
                                                                                <tr>
                                                                                    <td colspan="2">
                                                                                        <uc3:Cash_CarDetailMX ID="Cash_CarDetailMX1" runat="server" />
                                                                                    </td>
                                                                                </tr>
                                                                                <%--                                                                        <tr>
                                                                            <td>
                                                                                初始金额：
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtLimitNums" runat="server" CssClass="textbox_name" Height="16px"
                                                                                    Width="161px" Text="0"></asp:TextBox>
                                                                                元
                                                                            </td>
                                                                        </tr>--%>
                                                                                <%-- <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="Server" ControlToValidate="txtLimitNums"
                                                                                            ValidationGroup="add2" ErrorMessage="金额不能为空!" Display="Dynamic" /><asp:RegularExpressionValidator
                                                                                                ID="RegularExpressionValidator1" runat="Server" ControlToValidate="txtLimitNums"
                                                                                                ValidationGroup="add2" ValidationExpression="^([0-9]\d{0,11})$|^(0|[0-9]\d{0,11})\.(\d{0,2})$"
                                                                                                ErrorMessage="金额输入有误!" Display="Dynamic" />
                                                                                    </td>
                                                                                </tr>--%>
                                                                                <tr>
                                                                                    <td colspan="2" align="center">
                                                                                        <asp:Label ID="tag2" runat="server" ForeColor="Red" Text="" CssClass="tag1" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2">
                                                                                        <asp:Button ID="Button_sumbit" runat="server" ValidationGroup="add2" Text="确定" OnClick="Button_sumbit_Click"
                                                                                            CssClass="button1" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button_reset"
                                                                                                runat="server" Text="重置" OnClick="Button_reset_Click" CssClass="button1" Visible="false" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button
                                                                                                    ID="Button_cancel" runat="server" Text="返回" CssClass="button1" OnClick="Button_cancel_Click" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </td>
                                                                    <td style="width: 450px;" valign="top" align="center">
                                                                        <div style="overflow-x: hidden; overflow-y: auto; height: 550px; width: 100%; text-align: left;"
                                                                            id="div_XS" runat="server">
                                                                            <asp:DataList ID="DataList1" runat="server" CellPadding="0" RepeatColumns="1" Width="100%"
                                                                                OnItemDataBound="DataList1_ItemDataBound">
                                                                                <ItemTemplate>
                                                                                    <table border='0' cellpadding='0' cellspacing='1' bgcolor='#99cccd' width='96%' style="height: 35px;">
                                                                                        <tr style='background-color: #99cccd;'>
                                                                                            <td style="font-weight: bold;" align="center">
                                                                                                &nbsp;&nbsp;&nbsp;《<%#   DataBinder.Eval(Container.DataItem, "BudgetName")%>》&nbsp;的新建资金卡通知
                                                                                                <%-- &nbsp;&nbsp;&nbsp;资金卡：&nbsp;<%#   DataBinder.Eval(Container.DataItem, "CardName")%>
                                                                                                &nbsp;&nbsp;&nbsp;&nbsp;通知时间：&nbsp;<%#   DataBinder.Eval(Container.DataItem, "DATETIME", "{0:d}")%>--%>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                    <table border='0' cellpadding='0' cellspacing='1' bgcolor='#99cccd' width='96%' style="height: 220px;">
                                                                                        
                                                                                        <tr style='background-color: #ffffff'>
                                                                                            <td align="right">
                                                                                                预算报告：
                                                                                            </td>
                                                                                            <td>
                                                                                                &nbsp;
                                                                                                <asp:Label ID="LB_budget" runat="server" Text=""></asp:Label>
                                                                                                &nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr style='background-color: #ffffff'>
                                                                                            <td align="right">
                                                                                                所属项目：
                                                                                            </td>
                                                                                            <td>
                                                                                                &nbsp;<asp:Label ID="Lab_Project" runat="server"></asp:Label>
                                                                                                &nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr style='background-color: #ffffff'>
                                                                                            <td align="right">
                                                                                                预算金额：
                                                                                            </td>
                                                                                            <td>
                                                                                                &nbsp;<%#   DataBinder.Eval(Container.DataItem, "LimitNums")%> 元
                                                                                                &nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr style='background-color: #ffffff'>
                                                                                            <td align="right">
                                                                                                发送人：
                                                                                            </td>
                                                                                            <td>
                                                                                                &nbsp;<%#   DataBinder.Eval(Container.DataItem, "SendRealName")%>
                                                                                                &nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr style='background-color: #ffffff'>
                                                                                            <td align="right">
                                                                                                通知时间：
                                                                                            </td>
                                                                                            <td>
                                                                                                &nbsp;<%#   DataBinder.Eval(Container.DataItem, "DATETIME")%>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr style='background-color: #ffffff;'>
                                                                                            <td align="right">
                                                                                                阅读状态：
                                                                                            </td>
                                                                                            <td style="vertical-align: middle;">
                                                                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            &nbsp;
                                                                                                            <%#   DataBinder.Eval(Container.DataItem, "IsRead").ToString().Equals("0")?"未读":"已读"%>
                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;
                                                                                                        </td>
                                                                                                        <td align="left">
                                                                                                            <asp:Button ID='Btn_TQXX' Text='提取详细' runat='server' CssClass='button1' OnClick="Btn_TQXX_Click"
                                                                                                                CommandArgument='<%#   DataBinder.Eval(Container.DataItem, "ID")   %> ' />&nbsp;&nbsp;&nbsp;
                                                                                                            <asp:Button ID='Btn_YY' Text='已阅' runat='server' CssClass='button1' OnClick="Btn_YY_Click"
                                                                                                                CommandArgument='<%#   DataBinder.Eval(Container.DataItem, "ID")+","+ DataBinder.Eval(Container.DataItem, "CardName")  %> ' />
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                    <br />
                                                                                </ItemTemplate>
                                                                            </asp:DataList>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <table class="tab6">
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
