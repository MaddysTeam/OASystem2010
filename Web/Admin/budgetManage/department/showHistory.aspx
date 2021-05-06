<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="showHistory.aspx.cs" MasterPageFile="~/Admin/OAmaster.Master" Inherits="Dianda.Web.Admin.budgetManage.department.showHistory" %>

<%@ Register Src="/Admin/cashCardManage/OAleftmenu.ascx" TagName="OAleftmenu" TagPrefix="uc1" %>
<%@ Register Src="/Admin/cashCardManage/OAleftmenu_Show.ascx" TagName="OAleftmenu_Show" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="/Admin/css/OACSS.css" rel="stylesheet" type="text/css" />
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td width="4">
            </td>
            <td valign="top" width="115" align="left" runat="server" id="td_left">
                <uc1:OAleftmenu ID="OAleftmenu1" runat="server" Visible="false" />
                <uc2:OAleftmenu_Show ID="OAleftmenu_Show1" runat="server" Visible="false" />
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
                                                <td>
                                                    <table class="tab3" border="0">
                                                        <tr>
                                                            <td valign="top">
                                                                <table width="100%" class="tab4" align="center" cellspacing="0" cellpadding="0">
                                                                    <tr>
                                                                        <td valign="top">
                                                                            <table class="tab5">
                                                                                <tr>
                                                                                    <td>
                                                                                        <div id="cash_jbxx" runat="server">
                                                                                            <table align="center" width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                                <tr valign="top">
                                                                                                    <td align="right" height="22">
                                                                                                        <asp:Label ID="LB_MSG" runat="server" ForeColor="Red" Text=""></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button
                                                                                                            ID="Button_jz" runat="server" Text="记帐" CssClass="button1" OnClick="Button_jz_Click" />&nbsp;&nbsp;<asp:Button
                                                                                                                ID="Button_cancel" runat="server" Text="返回" CssClass="button1" OnClick="Button_cancel_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr valign="middle">
                                                                                                    <td align="center">
                                                                                                        <table width="97%" border="0" cellpadding="0" cellspacing="1" bgcolor="#000000">
                                                                                                            <%--<tr style="background-color: #99cccd" height="25px">
                                                                                                                <td align="center" colspan="2" style="height: 30px;">
                                                                                                                    &nbsp;&nbsp;&nbsp;<asp:Label ID="lblCardName" Font-Bold="true" runat="server" Text=""></asp:Label>&nbsp;
                                                                                                                </td>
                                                                                                            </tr>--%>
                                                                                                            <tr style="background-color: #ffffff">
                                                                                                                <td style="width: 100px; height: 25px;" align="right">
                                                                                                                    资金卡名称：
                                                                                                                </td>
                                                                                                                <td align="left">
                                                                                                                    &nbsp;
                                                                                                                    <asp:Label ID="LB_Name" runat="server" Text=""></asp:Label>
                                                                                                                    &nbsp;
                                                                                                                </td>
                                                                                                                <td style="width: 100px; height: 25px;" align="right">
                                                                                                                    所属项目：
                                                                                                                </td>
                                                                                                                <td align="left">
                                                                                                                    &nbsp;
                                                                                                                    <asp:Label ID="LB_Project" runat="server" Text=""></asp:Label>
                                                                                                                    &nbsp;
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr style="background-color: #ffffff">
                                                                                                                <td style="width: 100px; height: 25px;" align="right">
                                                                                                                    资金卡编号：
                                                                                                                </td>
                                                                                                                <td align="left">
                                                                                                                    &nbsp;
                                                                                                                    <asp:Label ID="LB_CardNum" runat="server" Text=""></asp:Label>
                                                                                                                    &nbsp;
                                                                                                                </td>
                                                                                                                <td style="width: 100px; height: 25px;" align="right">
                                                                                                                    所属帐户：
                                                                                                                </td>
                                                                                                                <td align="left">
                                                                                                                    &nbsp;
                                                                                                                    <asp:Label ID="LB_AccountName" runat="server" Text=""></asp:Label>
                                                                                                                    &nbsp;
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr style="background-color: #ffffff">
                                                                                                                <td style="width: 100px; height: 25px;" align="right">
                                                                                                                    持卡人：
                                                                                                                </td>
                                                                                                                <td align="left">
                                                                                                                    &nbsp;
                                                                                                                    <asp:Label ID="LB_Holder" runat="server" Text=""></asp:Label>
                                                                                                                    &nbsp;
                                                                                                                </td>
                                                                                                                <td style="width: 100px; height: 25px;" align="right">
                                                                                                                    所属专项资金：
                                                                                                                </td>
                                                                                                                <td align="left">
                                                                                                                    &nbsp;
                                                                                                                    <asp:Label ID="LB_SpecialFundsName" runat="server" Text=""></asp:Label>
                                                                                                                    &nbsp;
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr style="background-color: #ffffff">
                                                                                                                <td style="width: 100px; height: 25px;" align="right">
                                                                                                                    审批人：
                                                                                                                </td>
                                                                                                                <td align="left">
                                                                                                                    &nbsp;
                                                                                                                    <asp:Label ID="LB_Checker" runat="server" Text=""></asp:Label>
                                                                                                                    &nbsp;
                                                                                                                </td>
                                                                                                                <td style="width: 100px; height: 25px;" align="right">
                                                                                                                    所属预算报告：
                                                                                                                </td>
                                                                                                                <td align="left">
                                                                                                                    &nbsp;
                                                                                                                    <asp:Label ID="LB_SFOrderName" runat="server" Text=""></asp:Label>
                                                                                                                    &nbsp;
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td height="5">
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr valign="bottom">
                                                                                                    <td align="center">
                                                                                                        <div style="width: 97%;text-align: left;">
                                                                                                            <table height="30px" border="0" cellpadding="0" cellspacing="0" style="border-collapse: collapse">
                                                                                                                <tr style="height: 30px;">
                                                                                                                    <td style="border: solid 1px #242727; width: 36px" align="center">
                                                                                                                        预算<br />
                                                                                                                        金额
                                                                                                                    </td>
                                                                                                                    <td style="border-top: solid 1px #242727; border-bottom: solid 1px #242727;">
                                                                                                                        <asp:DataList ID="DList_YSJE" runat="server" GridLines="None" Height="100%" 
                                                                                                                            onitemdatabound="DList_YSJE_ItemDataBound">
                                                                                                                            <ItemTemplate>
                                                                                                                                <%# ReturnStr(Eval("Oldbalance").ToString())%></ItemTemplate>
                                                                                                                            <ItemStyle Width="60px" CssClass="HistoryDataList" />
                                                                                                                        </asp:DataList>
                                                                                                                    </td>
                                                                                                                    <td style="border-top: solid 1px #242727; border-right: solid 1px #242727; border-bottom: solid 1px #242727; width: 80px; text-align:center;">
                                                                                                                        <asp:Label ID="Lab_YSJE" runat="server" Text="0"></asp:Label>
                                                                                                                    </td>
                                                                                                                    <td style="border-top: solid 1px #242727; border-right: solid 1px #242727; border-bottom: solid 1px #242727; width: 80px;">
                                                                                                                        &nbsp;
                                                                                                                    </td>
                                                                                                                     <td style="border-top: solid 1px #242727; border-right: solid 1px #242727; border-bottom: solid 1px #242727; width: 80px;">
                                                                                                                        &nbsp;
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                            </table>
                                                                                                            <table width="97%" border="0" cellpadding="0" cellspacing="0">
                                                                                                                <tr>
                                                                                                                    <td style="height:30px;">
                                                                                                                        <asp:Label ID="notice" runat="server" Text="" ForeColor="red"></asp:Label>
                                                                                                                        <asp:GridView ID="GridView1" AutoGenerateColumns="False" runat="server" CellPadding="3"
                                                                                                                            CssClass="GridView11">
                                                                                                                            <Columns>
                                                                                                                                <asp:TemplateField HeaderText="序号">
                                                                                                                                    <ItemTemplate>
                                                                                                                                        <%# Eval("PX") %>
                                                                                                                                    </ItemTemplate>
                                                                                                                                    <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" Width="30" />
                                                                                                                                    <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" Width="30" />
                                                                                                                                </asp:TemplateField>
                                                                                                                            </Columns>
                                                                                                                        </asp:GridView>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                            </table>
                                                                                                            <table height="30px" border="0" cellpadding="0" cellspacing="0" style="border-collapse: collapse">
                                                                                                                <tr style="height: 30px;">
                                                                                                                    <td style="border-top: solid 1px #242727; border-left: solid 1px #242727; border-right: solid 1px #242727;
                                                                                                                        width: 36px" align="center">
                                                                                                                        细目<br />
                                                                                                                        名称
                                                                                                                    </td>
                                                                                                                    <td style="border-top: solid 1px #242727;">
                                                                                                                        <asp:DataList ID="DList_xm" runat="server" GridLines="None" Height="100%">
                                                                                                                            <ItemTemplate>
                                                                                                                                <%# Eval("DetailName").ToString()%></ItemTemplate>
                                                                                                                            <ItemStyle Width="60px" CssClass="HistoryDataList" />
                                                                                                                        </asp:DataList>
                                                                                                                    </td>
                                                                                                                    <td style="border-top: solid 1px #242727; border-right: solid 1px #242727; width: 80px; text-align:center;">
                                                                                                                       总计
                                                                                                                    </td>
                                                                                                                    <td style="border-top: solid 1px #242727; border-right: solid 1px #242727; width: 80px; text-align:center;">
                                                                                                                       &nbsp;
                                                                                                                    </td>
                                                                                                                    <td style="border-top: solid 1px #242727; border-right: solid 1px #242727; width: 80px; text-align:center;">
                                                                                                                       &nbsp;
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr style="height: 30px;">
                                                                                                                    <td style="border-top: solid 1px #242727; border-left: solid 1px #242727; border-right: solid 1px #242727;
                                                                                                                        width: 36px" align="center">
                                                                                                                        可用<br />
                                                                                                                        金额
                                                                                                                    </td>
                                                                                                                    <td style="border-top: solid 1px #242727;">
                                                                                                                        <asp:DataList ID="DList_KYJE" runat="server" GridLines="None" Height="100%" 
                                                                                                                            onitemdatabound="DList_KYJE_ItemDataBound">
                                                                                                                            <ItemTemplate>
                                                                                                                                <%# ReturnStr(Eval("KYbalance").ToString())%></ItemTemplate>
                                                                                                                            <ItemStyle Width="60px" CssClass="HistoryDataList" />
                                                                                                                        </asp:DataList>
                                                                                                                    </td>
                                                                                                                    <td style="border-top: solid 1px #242727; border-right: solid 1px #242727; width: 80px; text-align:center;">
                                                                                                                        <asp:Label ID="Lab_KYJE" runat="server" Text="0"></asp:Label>
                                                                                                                    </td>
                                                                                                                    <td style="border-top: solid 1px #242727; border-right: solid 1px #242727; width: 80px; text-align:center;">
                                                                                                                       &nbsp;
                                                                                                                    </td>
                                                                                                                    <td style="border-top: solid 1px #242727; border-right: solid 1px #242727; width: 80px; text-align:center;">
                                                                                                                       &nbsp;
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr style="background-color: #FFC21A; height: 30px;">
                                                                                                                    <td style="border-top: solid 1px #242727; border-left: solid 1px #242727; border-right: solid 1px #242727;
                                                                                                                        width: 36px" align="center">
                                                                                                                        当前<br />
                                                                                                                        余额
                                                                                                                    </td>
                                                                                                                    <td style="border-top: solid 1px #242727; border-bottom: solid 1px #242727;">
                                                                                                                        <asp:DataList ID="DList_DQYE" runat="server" GridLines="None" Height="100%" 
                                                                                                                            onitemdatabound="DList_DQYE_ItemDataBound">
                                                                                                                            <ItemTemplate>
                                                                                                                                <%# ReturnStr(Eval("Balance").ToString())%></ItemTemplate>
                                                                                                                            <ItemStyle Width="60px" CssClass="HistoryDataList" />
                                                                                                                        </asp:DataList>
                                                                                                                    </td>
                                                                                                                    <td style="border-top: solid 1px #242727; border-right: solid 1px #242727; border-bottom: solid 1px #242727; width: 80px; text-align:center;">
                                                                                                                        <asp:Label ID="Lab_DQYE" runat="server" Text="0"></asp:Label>
                                                                                                                    </td>
                                                                                                                    <td style="border-top: solid 1px #242727; border-right: solid 1px #242727; border-bottom: solid 1px #242727; width: 80px;">
                                                                                                                        &nbsp;
                                                                                                                    </td>
                                                                                                                    <td style="border-top: solid 1px #242727; border-right: solid 1px #242727; border-bottom: solid 1px #242727; width: 80px;">
                                                                                                                        &nbsp;
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                            </table>
                                                                                                        </div>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td height="10">
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr valign="top">
                                                                                                    <td align="center" height="80">
                                                                                                        <table border="1" width="97%" height="100%" style="border-collapse: collapse; border-color: #A9BDC8;"
                                                                                                            rules="none">
                                                                                                            <tr valign="top">
                                                                                                                <td align="left">
                                                                                                                    <asp:Label ID="LB_Info" runat="server" Text=""></asp:Label>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </div>
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
        </tr>
    </table>
</asp:Content>