<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="showMessage.aspx.cs" Inherits="Dianda.Web.Admin.cashCardManage.showMessage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/OACSS.css" rel="stylesheet" type="text/css" />
    <base target="_self" />
    <meta http-equiv="Pragma" content="no-cache">
</head>
<body>
    <form id="form1" runat="server">
    <div id="divGv" runat="server">
        <table align="center" cellpadding="0" cellspacing="0" width="100%" bgcolor="#99cccd">
            <tr>
                <td>
                    <table align="center" bgcolor="#99cccd" cellpadding="0" cellspacing="0" width="98%">
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
                                                        <asp:Label ID="LB_name" runat="server" Text="" CssClass="LB_name1"></asp:Label>资金卡新建通知
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table class="tab3">
                                                <tr>
                                                    <td>
                                                        <table class="tab12">
                                                            <tr>
                                                                <td valign="top">
                                                                    <table class="tab5">
                                                                        <tr>
                                                                            <td align="center">
                                                                                <table class="tab2">
                                                                                    <tr>
                                                                                        <td style="width: 500px; " align="left">
                                                                                            <asp:DropDownList ID="ddlIsRead" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlIsRead_SelectedIndexChanged">
                                                                                                <asp:ListItem Value="0">未读</asp:ListItem>
                                                                                                <asp:ListItem Value="1">已读</asp:ListItem>
                                                                                            </asp:DropDownList>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="center">
                                                                                            <asp:Label ID="tag" runat="server" Text="" CssClass="tag1" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                                <asp:GridView ID="GridView1" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound"
                                                                                    runat="server" CellPadding="3" CssClass="GridView1" PageSize="8">
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="通知名目">
                                                                                            <ItemTemplate>
                                                                                                <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click" CommandArgument='<%#Eval("id")%>'
                                                                                                    runat="server"><%#Eval("CardName")%></asp:LinkButton>
                                                                                            </ItemTemplate>
                                                                                            <%--<ItemTemplate>
                                                                                               <%#Eval("CardName")%>
                                                                                            </ItemTemplate>--%>
                                                                                            <HeaderStyle CssClass="HeaderStyle1" HorizontalAlign="Center" />
                                                                                            <ItemStyle CssClass="ItemStyle1" HorizontalAlign="Center" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:BoundField HeaderText="通知时间" DataField="DATETIME">
                                                                                            <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                            <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                        </asp:BoundField>
                                                                                        <asp:BoundField HeaderText="发出通知者" DataField="">
                                                                                            <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                            <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                        </asp:BoundField>
                                                                                        <asp:BoundField HeaderText="阅读状态" DataField="">
                                                                                            <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                            <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                        </asp:BoundField>
                                                                                        <asp:TemplateField HeaderText="预算报告">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="LB_budget" runat="server" Text=""></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                            <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                    <FooterStyle CssClass="FooterStyle1" />
                                                                                    <PagerStyle HorizontalAlign="Left" CssClass="PagerStyle1" />
                                                                                    <SelectedRowStyle CssClass="SelectedRowStyle1" />
                                                                                </asp:GridView>
                                                                                
                                                                                <asp:Label ID="notice" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                                                <%-- 记录当前是第几页--%>
                                                                                <asp:HiddenField ID="HiddenField1" runat="server" />
                                                                                <%-- 记录当前是第几页--%>
                                                                                <%-- 记录信息集中总共有多少条记录--%>
                                                                                <asp:HiddenField ID="dtrowsHidden" runat="server" />
                                                                                <%-- 记录信息集中总共有多少条记录--%>
                                                                                <%--下面是分页控件--%>
                                                                                <table cellpadding="0" cellspacing="0" height="25" width="100%" runat="server" id="pageControlShow">
                                                                                <tr><td height="5px"></td></tr>
                                                                                    <tr>
                                                                                        <td align="right" bgcolor="#ffffff">
                                                                                            <asp:LinkButton ID="FirstPage" OnClick="PageChange_Click" runat="server">第一页</asp:LinkButton>
                                                                                            &nbsp;&nbsp;<asp:LinkButton ID="PreviousPage" OnClick="PageChange_Click" runat="server">上一页</asp:LinkButton>
                                                                                            &nbsp;&nbsp;<asp:LinkButton ID="NextPage" OnClick="PageChange_Click" runat="server">下一页</asp:LinkButton>
                                                                                            &nbsp;&nbsp;<asp:LinkButton ID="LastPage" OnClick="PageChange_Click" runat="server">最后页</asp:LinkButton>
                                                                                            &nbsp;&nbsp;<asp:Label ID="Label_showInfo" runat="server" Text=""></asp:Label>&nbsp;&nbsp;跳转到：<asp:DropDownList
                                                                                                ID="DropDownList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                                                                                            </asp:DropDownList>
                                                                                            &nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                   
                                                                                </table>
                                                                                <%--下面是分页控件--%>
                                                                                <asp:HiddenField ID="pageindexHidden" runat="server" />
                                                                                <asp:HiddenField ID="H_NAME" runat="server" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
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
        </table>
    </div>
    <div id="divsend" runat="server">
        <table width="730">
            <tr>
                <td>
                    <div style="overflow-x: hidden; overflow-y: auto; height: 550px; width: 100%; text-align: left;"
                        id="div_XS" runat="server">
                        <asp:DataList ID="DataList1" runat="server" CellPadding="0" RepeatColumns="1" Width="100%"
                            OnItemDataBound="DataList1_ItemDataBound">
                            <ItemTemplate>
                                <table border='0' cellpadding='0' cellspacing='1' bgcolor='#99cccd' width='96%' style="height: 35px;">
                                    <tr style='background-color: #99cccd;'>
                                        <td style="font-weight: bold;" align="center">
                                            &nbsp;&nbsp;&nbsp;《<%#   DataBinder.Eval(Container.DataItem, "BudgetName")%>》&nbsp;的新建资金卡通知
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
                                            &nbsp;<%#   DataBinder.Eval(Container.DataItem, "LimitNums")%>
                                            元 &nbsp;
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
                                                        <asp:Button ID='Btn_YY' Text='已阅' runat='server' CssClass='button1' OnClick="Btn_YY_Click"
                                                            CommandArgument='<%#   DataBinder.Eval(Container.DataItem, "ID")+","+ DataBinder.Eval(Container.DataItem, "CardName")  %> ' />
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button_cancel" runat="server"
                                                            Text="返回" CssClass="button1" OnClick="Button_cancel_Click" />
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
        <%--<asp:HiddenField ID="HiddenField_ID" runat="server" />
        <table width="720" align="center" border="1" cellspacing="0" cellpadding="1">
            <tr>
                <td style="width: 100px">
                    资金卡名称：
                </td>
                <td>
                    <asp:Label ID="lblCardName" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    持卡人：
                </td>
                <td>
                    <asp:Label ID="lblCardholderRealName" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    所属部门：
                </td>
                <td>
                    <asp:Label ID="lblDepartmentName" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    所属项目：
                </td>
                <td>
                    <asp:Label ID="lblProjectName" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    初始金额：
                </td>
                <td>
                    <asp:Label ID="lblLimitNums" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    审批人：
                </td>
                <td>
                    <asp:Label ID="lblApproverRealName" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    通知时间：
                </td>
                <td>
                    <asp:Label ID="lblDATETIME" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    阅读状态：
                </td>
                <td>
                    <asp:Label ID="lblIsRead" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    阅读时间：
                </td>
                <td>
                    <asp:Label ID="lblReadTime" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    阅读者：
                </td>
                <td>
                    <asp:Label ID="lblDoUserID" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    备注说明：
                </td>
                <td>
                    <asp:TextBox ID="txtDoNotes" runat="server" TextMode="MultiLine" Height="100px" Width="456px"
                        MaxLength="800"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="Button_sumbit" runat="server" Text="已阅" OnClick="Button_sumbit_Click"
                        CssClass="button1" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button_cancel"
                            runat="server" Text="返回" CssClass="button1" OnClick="Button_cancel_Click" />
                </td>
            </tr>
        </table>--%>
    </div>
    </form>
</body>
</html>
