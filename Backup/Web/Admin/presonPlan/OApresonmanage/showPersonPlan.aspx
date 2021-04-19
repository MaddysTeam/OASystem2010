<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="showPersonPlan.aspx.cs"
    Inherits="Dianda.Web.Admin.presonPlan.OApresonmanage.showPersonPlan" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>个人计划显示区域</title>
    <link href="../../css/OACSS.css" rel="Stylesheet" type="text/css" media="all" />
    <link href="../../css/OACSS.css" rel="Stylesheet" type="text/css" media="all" />

   <%-- <script src="../../js/SelectDate.js" type="text/javascript"></script>--%>
    <script src="../../js/SelectDate2.js" type="text/javascript"></script>

    <style type="text/css">
        .style1
        {
            height: 20px;
        }
        .style2
        {
            height: auto;
            vertical-align: top;
        }
    </style>

    <script language="javascript" type="text/javascript">
// <!CDATA[

        function Button3_onclick() {

        }

// ]]>
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="230" style="text-align: center" height="494" border="0" cellspacing="0"
            cellpadding="0" bgcolor="#125698" class="ziti_style">
            <tr>
                <td align="center" height="29px" background="/Admin/images/OAimages/right_top.jpg">
                    <asp:Label ID="Label_addProject" runat="server" Text="个人计划显示" CssClass="ziti_style3"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    <div id="div2" runat="server">
                        <table width="230" style="text-align: left; height: auto" border="0" cellspacing="0"
                            cellpadding="0" bgcolor="#125698" class="ziti_style">
                            <tr>
                                <td style="padding-left: 15px; padding-top: 5px;">
                                    <asp:Label ID="Label_Title" runat="server" Text="标题:"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-left: 15px;">
                                    <%-- <asp:TextBox ID="TextBox_Title" runat="server" Width="158px" MaxLength="25" CssClass="textbox_name"></asp:TextBox>
--%>
                                    <asp:TextBox ID="TextBox_Title" runat="server" Height="90px" TextMode="MultiLine"
                                        Width="158px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-left: 15px;">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox_Title"
                                        ErrorMessage="*标题不能为空" ForeColor="Yellow" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td height="10" style="padding-left: 15px;">
                                    <img src="../../images/OAimages/r_s.jpg" />
                                </td>
                            </tr>
                            <tr>
                                <td class="style1" style="padding-left: 15px;">
                                    <asp:Label ID="Label_StartTime" runat="server" Text="开始日期:"></asp:Label>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td class="style1" style="padding-left: 15px;">
                                    <input class="Inputtext" id="TB_DateTime" runat="server" width="158px" type="text"
                                        readonly="readonly" onclick="ShowCalendar(this);" />天
                                    <br>
                                    <asp:DropDownList ID="ddl_Part" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_Part_change">
                                        <asp:ListItem Value="00">00</asp:ListItem>
                                        <asp:ListItem Value="01">01</asp:ListItem>
                                        <asp:ListItem Value="02">02</asp:ListItem>
                                        <asp:ListItem Value="03">03</asp:ListItem>
                                        <asp:ListItem Value="04">04</asp:ListItem>
                                        <asp:ListItem Value="05">05</asp:ListItem>
                                        <asp:ListItem Value="06">06</asp:ListItem>
                                        <asp:ListItem Value="07">07</asp:ListItem>
                                        <asp:ListItem Value="08">08</asp:ListItem>
                                        <asp:ListItem Value="09">09</asp:ListItem>
                                        <asp:ListItem Value="10">10</asp:ListItem>
                                        <asp:ListItem Value="11">11</asp:ListItem>
                                        <asp:ListItem Value="12">12</asp:ListItem>
                                        <asp:ListItem Value="13">13</asp:ListItem>
                                        <asp:ListItem Value="14">14</asp:ListItem>
                                        <asp:ListItem Value="15">15</asp:ListItem>
                                        <asp:ListItem Value="16">16</asp:ListItem>
                                        <asp:ListItem Value="17">17</asp:ListItem>
                                        <asp:ListItem Value="18">18</asp:ListItem>
                                        <asp:ListItem Value="19">19</asp:ListItem>
                                        <asp:ListItem Value="20">20</asp:ListItem>
                                        <asp:ListItem Value="21">21</asp:ListItem>
                                        <asp:ListItem Value="22">22</asp:ListItem>
                                        <asp:ListItem Value="23">23</asp:ListItem>
                                    </asp:DropDownList>
                                    小时<asp:DropDownList ID="ddl_second" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_Part_change">
                                        <asp:ListItem Value="00">00</asp:ListItem>
                                        <asp:ListItem Value="05">05</asp:ListItem>
                                        <asp:ListItem Value="10">10</asp:ListItem>
                                        <asp:ListItem Value="15">15</asp:ListItem>
                                        <asp:ListItem Value="20">20</asp:ListItem>
                                        <asp:ListItem Value="25">25</asp:ListItem>
                                        <asp:ListItem Value="30">30</asp:ListItem>
                                        <asp:ListItem Value="35">35</asp:ListItem>
                                        <asp:ListItem Value="40">40</asp:ListItem>
                                        <asp:ListItem Value="45">45</asp:ListItem>
                                        <asp:ListItem Value="50">50</asp:ListItem>
                                        <asp:ListItem Value="55">55</asp:ListItem>
                                    </asp:DropDownList>
                                    分钟
                                </td>
                            </tr>
                            <br />
                            <tr>
                                <td height="20" style="padding-left: 15px;">
                                    <img src="../../images/OAimages/r_s.jpg" />
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-left: 15px;">
                                    <br />
                                    <asp:Label ID="Label_EndTime" runat="server" Text="结束日期:"></asp:Label>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-left: 15px;">
                                    <input class="Inputtext" id="TB_DateTime1" runat="server" width="20px" type="text"
                                        readonly="readonly" onclick="ShowCalendar(this);" />天<br>
                                    <asp:DropDownList ID="ddl_Part1" runat="server">
                                        <asp:ListItem Value="00">00</asp:ListItem>
                                        <asp:ListItem Value="01">01</asp:ListItem>
                                        <asp:ListItem Value="02">02</asp:ListItem>
                                        <asp:ListItem Value="03">03</asp:ListItem>
                                        <asp:ListItem Value="04">04</asp:ListItem>
                                        <asp:ListItem Value="05">05</asp:ListItem>
                                        <asp:ListItem Value="06">06</asp:ListItem>
                                        <asp:ListItem Value="07">07</asp:ListItem>
                                        <asp:ListItem Value="08">08</asp:ListItem>
                                        <asp:ListItem Value="09">09</asp:ListItem>
                                        <asp:ListItem Value="10">10</asp:ListItem>
                                        <asp:ListItem Value="11">11</asp:ListItem>
                                        <asp:ListItem Value="12">12</asp:ListItem>
                                        <asp:ListItem Value="13">13</asp:ListItem>
                                        <asp:ListItem Value="14">14</asp:ListItem>
                                        <asp:ListItem Value="15">15</asp:ListItem>
                                        <asp:ListItem Value="16">16</asp:ListItem>
                                        <asp:ListItem Value="17">17</asp:ListItem>
                                        <asp:ListItem Value="18">18</asp:ListItem>
                                        <asp:ListItem Value="19">19</asp:ListItem>
                                        <asp:ListItem Value="20">20</asp:ListItem>
                                        <asp:ListItem Value="21">21</asp:ListItem>
                                        <asp:ListItem Value="22">22</asp:ListItem>
                                        <asp:ListItem Value="23">23</asp:ListItem>
                                    </asp:DropDownList>
                                    小时<asp:DropDownList ID="ddl_second1" runat="server">
                                        <asp:ListItem Value="00">00</asp:ListItem>
                                        <asp:ListItem Value="05">05</asp:ListItem>
                                        <asp:ListItem Value="10">10</asp:ListItem>
                                        <asp:ListItem Value="15">15</asp:ListItem>
                                        <asp:ListItem Value="20">20</asp:ListItem>
                                        <asp:ListItem Value="25">25</asp:ListItem>
                                        <asp:ListItem Value="30">30</asp:ListItem>
                                        <asp:ListItem Value="35">35</asp:ListItem>
                                        <asp:ListItem Value="40">40</asp:ListItem>
                                        <asp:ListItem Value="45">45</asp:ListItem>
                                        <asp:ListItem Value="50">50</asp:ListItem>
                                        <asp:ListItem Value="55">55</asp:ListItem>
                                    </asp:DropDownList>
                                    分钟
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-left: 15px;">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TB_DateTime"
                                        ErrorMessage="*开始时间不能为空" ForeColor="Yellow" Display="Dynamic"></asp:RequiredFieldValidator><asp:RequiredFieldValidator
                                            ID="RequiredFieldValidator3" runat="server" ControlToValidate="TB_DateTime1"
                                            ErrorMessage="*结束时间不能为空" ForeColor="Yellow" Display="Dynamic"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <br />
                            <tr>
                                <td height="20" style="padding-left: 15px;">
                                    <img src="../../images/OAimages/r_s.jpg" />
                                </td>
                            </tr>
                            <%--                            <tr>
                                <td style="padding-left: 15px;">
                                    <asp:Label ID="Label_Content" runat="server" Text="计划内容:"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td height="120px" style="padding-left: 15px;">
                                    <asp:TextBox ID="TextBox_Content" runat="server" Height="100px" TextMode="MultiLine"
                                        Width="158px"></asp:TextBox>
                                </td>
                            </tr>--%>
                            <tr>
                                <td style="padding-left: 5px; text-align: left">
                                    <span style="float: left; padding-left: 15px; text-align: left">状态</span><br />
                                    <asp:RadioButton ID="RadioButton5" Text="未完成" runat="server" GroupName="Status2" />
                                    <asp:RadioButton ID="RadioButton6" runat="server" Text="进行中" GroupName="Status2" />
                                    <asp:RadioButton ID="RadioButton7" runat="server" Text="完成" GroupName="Status2" />
                                    <asp:RadioButton ID="RadioButton8" runat="server" Text="删除" GroupName="Status2" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" valign="bottom" align="center" style="height: 40px;">
                                    <asp:Label ID="Labeltext" Style="font-size: 12px; color: White" runat="server" Text=""></asp:Label>
                                    <br />
                                    <asp:Button ID="Button_update" runat="server" Text="保 存" CssClass="button1" OnClick="Button_update_Click1" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="Button_getback" runat="server" Text="返 回" CssClass="button1" OnClick="Button_getback_Click" />
                                </td>
                            </tr>
                            <tr><td colspan="2" style="height: 20px;">&nbsp;</td></tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
