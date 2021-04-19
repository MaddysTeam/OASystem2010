<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="showCardInfo.aspx.cs" Inherits="Dianda.Web.Admin.personalProjectManage.OACashApply.showCardInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../css/OACSS.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="1024">
            <tr>
                <td align="center">
                    <table width="90%">
                        <tr>
                            <td align="center">
                                <asp:Label ID="LB_MSG" runat="server" ForeColor="Red" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr valign="middle">
                            <td align="center">
                                <table width="97%" border="0" cellpadding="0" cellspacing="1" bgcolor="#000000">
                                    <tr style="background-color: #ffffff">
                                        <td style="width: 100px; height: 25px;" align="right">
                                            资金卡名称：
                                        </td>
                                        <td align="left">
                                            &nbsp;<asp:Label ID="LB_Name" runat="server" Text=""></asp:Label>
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
                                            &nbsp;<asp:Label ID="LB_Holder" runat="server" Text=""></asp:Label>
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
                                            &nbsp;<asp:Label ID="LB_Checker" runat="server" Text=""></asp:Label>
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
                            <td align="left" style="padding-left:16px;">
                                <table border="0" cellpadding="0" cellspacing="0" style="border-collapse: collapse; height:30px;">
                                    <tr style="height: 30px;">
                                        <td style="border: solid 1px #242727; width: 36px" align="center">
                                            预算<br />
                                            金额
                                        </td>
                                        <td style="border-top: solid 1px #242727; border-bottom: solid 1px #242727;">
                                            <asp:DataList ID="DList_YSJE" runat="server" GridLines="None" Height="30px" OnItemDataBound="DList_YSJE_ItemDataBound">
                                                <ItemTemplate>
                                                    <%# ReturnStr(Eval("Oldbalance").ToString())%></ItemTemplate>
                                                <ItemStyle Width="60px" CssClass="HistoryDataList" />
                                            </asp:DataList>
                                        </td>
                                        <td style="border-top: solid 1px #242727; border-right: solid 1px #242727; border-bottom: solid 1px #242727;
                                            width: 80px; text-align: center;">
                                            <asp:Label ID="Lab_YSJE" runat="server" Text="0"></asp:Label>
                                        </td>
                                        <td style="border-top: solid 1px #242727; border-right: solid 1px #242727; border-bottom: solid 1px #242727;
                                            width: 80px;">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr valign="middle" runat="server" id="tr_czjl">
                            <td align="left" style="padding-left:16px;">
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="height: 30px;">
                                            <asp:Label ID="notice" runat="server" Text="" ForeColor="red"></asp:Label>
                                            <asp:GridView ID="GridView1" AutoGenerateColumns="False" runat="server" CellPadding="3"
                                                CssClass="GridView11" Height="30px">
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
                            </td>
                        </tr>
                        <tr valign="top">
                            <td align="left" style="padding-left:16px;">
                                <table border="0" cellpadding="0" cellspacing="0" style="border-collapse: collapse">
                                    <tr style="height: 30px;">
                                        <td style="border-top: solid 1px #242727; border-left: solid 1px #242727; border-right: solid 1px #242727;
                                            width: 36px" align="center">
                                            可用<br />
                                            金额
                                        </td>
                                        <td style="border-top: solid 1px #242727;">
                                            <asp:DataList ID="DList_KYJE" runat="server" GridLines="None" Height="30px" OnItemDataBound="DList_KYJE_ItemDataBound">
                                                <ItemTemplate>
                                                    <%# ReturnStr(Eval("KYbalance").ToString())%></ItemTemplate>
                                                <ItemStyle Width="60px" CssClass="HistoryDataList" />
                                            </asp:DataList>
                                        </td>
                                        <td style="border-top: solid 1px #242727; border-right: solid 1px #242727; width: 80px;
                                            text-align: center;">
                                            <asp:Label ID="Lab_KYJE" runat="server" Text="0"></asp:Label>
                                        </td>
                                        <td style="border-top: solid 1px #242727; border-right: solid 1px #242727; width: 80px;
                                            text-align: center;">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr style="background-color: #FFC21A; height: 30px;">
                                        <td style="border: solid 1px #242727;
                                            width: 36px" align="center">
                                            当前<br />
                                            余额
                                        </td>
                                        <td style="border-top: solid 1px #242727; border-bottom: solid 1px #242727;">
                                            <asp:DataList ID="DList_DQYE" runat="server" GridLines="None" Height="30px" OnItemDataBound="DList_DQYE_ItemDataBound">
                                                <ItemTemplate>
                                                    <%# ReturnStr(Eval("Balance").ToString())%></ItemTemplate>
                                                <ItemStyle Width="60px" CssClass="HistoryDataList" />
                                            </asp:DataList>
                                        </td>
                                        <td style="border-top: solid 1px #242727; border-right: solid 1px #242727; border-bottom: solid 1px #242727;
                                            width: 80px; text-align: center;">
                                            <asp:Label ID="Lab_DQYE" runat="server" Text="0"></asp:Label>
                                        </td>
                                        <td style="border-top: solid 1px #242727; border-right: solid 1px #242727; border-bottom: solid 1px #242727;
                                            width: 80px;">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
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
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
