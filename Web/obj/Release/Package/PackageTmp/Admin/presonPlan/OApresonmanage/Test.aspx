<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs"
    Inherits="Dianda.Web.Admin.presonPlan.OApresonmanage.Test" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<html>
<head id="Head1" runat="server">
    <title></title>
    <link href="../../css/OACSS.css" rel="Stylesheet" type="text/css" media="all" />

    <script src="../../js/SelectDate.js" type="text/javascript"></script>

    <script type="text/javascript" src="../../js/master.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel" runat="server">
            <ContentTemplate>
                <table width="230px" border="0" cellspacing="0" cellpadding="0" bgcolor="#125698">
                    <tr>
                        <td valign="top">
                            <div runat="server" id="divCanlender">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td valign="top">
                                            <div id="canlender_rili" style="display: block;" runat="server">
                                                <table cellpadding="0" cellspacing="0" width="100%" class="ziti_style">
                                                    <tr>
                                                        <td style="background-image: url(/Admin/images/OAimages/right_top.jpg); width: 100%;
                                                            height: 29px;" colspan="8" align="center">
                                                            <table cellpadding="0" cellspacing="0" width="100%">
                                                                <tr>
                                                                    <td width="20" align="center">
                                                                        <asp:ImageButton ID="ImageButton_left" ImageUrl="/admin/images/OAimages/left.gif"
                                                                            runat="server" OnClick="ImageButton_preMouth_Click" />
                                                                    </td>
                                                                    <td align="center" width="190" class="ziti_style">
                                                                        <asp:Label ID="Label_now" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td width="20" align="center">
                                                                        <asp:ImageButton ID="ImageButton_right" ImageUrl="/admin/images/OAimages/right.gif"
                                                                            runat="server" OnClick="ImageButton_nextMouth_Click" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table cellpadding="0" cellspacing="0" width="100%" class="ziti_style">
                                                                <tr style="background-color: #0b4278; padding-top: 10px; height: 28px">
                                                                    <td width="8px">
                                                                    </td>
                                                                    <td width="25px" align="center">
                                                                        一
                                                                    </td>
                                                                    <td width="26px" align="center">
                                                                        二
                                                                    </td>
                                                                    <td width="26px" align="center">
                                                                        三
                                                                    </td>
                                                                    <td width="26px" align="center">
                                                                        四
                                                                    </td>
                                                                    <td width="26px" align="center">
                                                                        五
                                                                    </td>
                                                                    <td width="26px" align="center">
                                                                        六
                                                                    </td>
                                                                    <td width="26px" align="center">
                                                                        日
                                                                    </td>
                                                                    <td align="center" class="ziti_style2">
                                                                        周次
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table cellpadding="0" cellspacing="0" width="100%">
                                                                <tr>
                                                                    <td colspan="7" width="195px" align="center">
                                                                        <asp:Calendar ID="Calendar1" Width="95%" runat="server" ShowDayHeader="False" ShowTitle="False"
                                                                            DayNameFormat="Shortest" FirstDayOfWeek="Monday" BorderColor="#1563A1" OnDayRender="Calendar_DayRender"
                                                                            OnSelectionChanged="Calendar1_SelectionChanged" DayStyle-ForeColor="White" BackColor="#114880"
                                                                            BorderWidth="1px" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" ShowGridLines="True">
                                                                            <%--   <SelectedDayStyle BackColor="#ffffff" Font-Underline="false" Font-Bold="True" />
                                                              <SelectorStyle BackColor="#0D3968" Font-Underline="false"/>
                                                            <TodayDayStyle BackColor="#0D3968" Font-Underline="false" ForeColor="White" />
                                                            <OtherMonthDayStyle ForeColor="#CC9966" Font-Underline="false" />
                                                            <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" Font-Underline="false" />
                                                            <DayHeaderStyle BackColor="#FFCC66" Font-Underline="false" Font-Bold="True" Height="1px" />
                                                            <TitleStyle BackColor="#990000" Font-Underline="false" Font-Bold="True" Font-Size="9pt" 
                                                                ForeColor="#FFFFCC" /> --%>
                                                                        </asp:Calendar>
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Label ID="Label_coutzhouci" runat="server"></asp:Label><asp:HiddenField ID="H_time"
                                                                            runat="server" />
                                                                    </td>
                                                                    <td width="5px">
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" align="center">
                                            <table cellpadding="0" cellspacing="0" width="100%">
                                                <tr id="monthTbl" style="display: none;" height="30px">
                                                    <td style="background-image: url(/Admin/images/OAimages/right_top.jpg); width: 100%;
                                                        height: 31px;" align="center">
                                                        <asp:DropDownList ID="DropDownList_year" runat="server" OnSelectedIndexChanged="DropDownList_month_SelectedIndexChanged"
                                                            AutoPostBack="True">
                                                        </asp:DropDownList>
                                                        &nbsp;<asp:DropDownList ID="DropDownList_month" runat="server" AutoPostBack="True"
                                                            OnSelectedIndexChanged="DropDownList_month_SelectedIndexChanged">
                                                            <asp:ListItem Value="1">1月</asp:ListItem>
                                                            <asp:ListItem Value="2">2月</asp:ListItem>
                                                            <asp:ListItem Value="3">3月</asp:ListItem>
                                                            <asp:ListItem Value="4">4月</asp:ListItem>
                                                            <asp:ListItem Value="5">5月</asp:ListItem>
                                                            <asp:ListItem Value="6">6月</asp:ListItem>
                                                            <asp:ListItem Value="7">7月</asp:ListItem>
                                                            <asp:ListItem Value="8">8月</asp:ListItem>
                                                            <asp:ListItem Value="9">9月</asp:ListItem>
                                                            <asp:ListItem Value="10">10月</asp:ListItem>
                                                            <asp:ListItem Value="11">11月</asp:ListItem>
                                                            <asp:ListItem Value="12">12月</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table cellpadding="0" cellspacing="0" width="100%">
                                                <tr>
                                                    <td style="padding-top: 5px;">
                                                        <asp:TabContainer ID="TabContainer" runat="server" CssClass="AjaxTabStrip" OnActiveTabChanged="TabContainer_ActiveTabChanged"
                                                            ActiveTabIndex="0" AutoPostBack="true">
                                                            <asp:TabPanel ID="TabPanel_PersonProject" runat="server" HeaderText="个人计划">
                                                                <HeaderTemplate>
                                                                    <img src="../../../all_image/PoPlan.jpg" />&nbsp;&nbsp;个人计划</HeaderTemplate>
                                                                <ContentTemplate>
                                                                    <div class="div_scroll" id="div_scroll2" style="height: 127px;">
                                                                        <asp:GridView ID="GridView_PresonProject" runat="server" AutoGenerateColumns="False"
                                                                            PageSize="5" Width="205px" ForeColor="White" CellPadding="1" GridLines="None">
                                                                            <Columns>
                                                                                <asp:TemplateField>
                                                                                    <ItemTemplate>
                                                                                        <table cellpadding="1" cellspacing="1" width="100%">
                                                                                            <tr>
                                                                                                <td valign="top" align="left" width="5">
                                                                                                </td>
                                                                                                <td class="ziti_style" align="left" style="font-size: 10px">
                                                                                                    <a href="showPersonPlan.aspx?ID=<%#Eval("ID") %>" target='_self' title='<%#Eval("NAMES") %>'
                                                                                                        style="color: White;">
                                                                                                        <%#Eval("NAMES").ToString().Length > 12 ? Eval("NAMES").ToString().Substring(0,12)+"..." : Eval("NAMES").ToString()%></a><br />
                                                                                                    <%# DateTime.Parse(Eval("StartTime").ToString()).ToString("yyyy-MM-dd HH:mm")%>&nbsp;--
                                                                                                    <%# DateTime.Parse(Eval("EndTime").ToString()).ToString("yyyy-MM-dd HH:mm")%>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td colspan="2" height="6">
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </div>
                                                                </ContentTemplate>
                                                            </asp:TabPanel>
                                                            <asp:TabPanel ID="TabPanel_ClassProject" runat="server" HeaderText="项目任务">
                                                                <HeaderTemplate>
                                                                    <img src="../../../all_image/userplan.jpg" />&nbsp;&nbsp;项目任务</HeaderTemplate>
                                                                <ContentTemplate>
                                                                    <div class="div_scroll" id="div_scroll1" style="height: 127px;">
                                                                        <asp:GridView ID="GridView_ClassProject" runat="server" AutoGenerateColumns="False"
                                                                            Width="205px" ForeColor="White" CellPadding="1" GridLines="None">
                                                                            <Columns>
                                                                                <asp:TemplateField>
                                                                                    <ItemTemplate>
                                                                                        <table>
                                                                                            <tr>
                                                                                                <td valign="top" align="left" width="5">
                                                                                                </td>
                                                                                                <td class="ziti_style" align="left" style="font-size: 10px">
                                                                                                    <a href="#" style="color: White;" onclick="window.parent.window.location.href='/Admin/personalProjectManage/OAtask/manage.aspx?ID=<%#Eval("ProjectID") %>';">
                                                                                                        <%#Eval("NAMES") %></a><br />
                                                                                                    <%# DateTime.Parse(Eval("StartTime").ToString()).ToString("yyyy-MM-dd HH:mm")%>&nbsp;--
                                                                                                    <%# DateTime.Parse(Eval("EndTime").ToString()).ToString("yyyy-MM-dd HH:mm")%>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td colspan="2" height="6">
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </div>
                                                                </ContentTemplate>
                                                            </asp:TabPanel>
                                                        </asp:TabContainer>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="36" background="/Admin/images/OAimages/rbg_3.jpg">
                                            <table width="220" valign="middle" height="36" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <%-- <td width="30" align="center">
                                                        <img src="/Admin/images/OAimages/rstyle1.jpg" id="hiderili" onclick="show();" style="cursor: hand;"
                                                            alt="日历视图">
                                                    </td>
                                                    <td width="30">
                                                        <img src="/Admin/images/OAimages/rstyle2_over.jpg" id="showrili" onclick="hide();"
                                                            style="cursor: hand;" alt="列表视图">
                                                    </td>
                                                    <td width="10" align="center">
                                                        <img src="/Admin/images/OAimages/fenge.jpg">
                                                    </td>--%>
                                                    <td width="30" align="center">
                                                        <a href="#" style="color: White;" onclick="window.parent.window.location.href='/Admin/SelectUserPlan.aspx'">
                                                            <img border="0" src="/all_image/search.jpg" alt="点击查询其他用户的个人计划" /></a>
                                                    </td>
                                                    <td width="30" align="center">
                                                        <a href="#" style="color: White;" onclick="window.parent.window.location.href='/Admin/SelectUserPlan.aspx?staue=1'">
                                                            <img border="0" src="/all_image/set.jpg" alt="点击设置个人计划浏览权限" /></a>
                                                    </td>
                                                    <td align="right">
                                                        &nbsp;
                                                        <asp:Label ID="Label_addProject" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td height="2" bgcolor="003c7a">
                        </td>
                    </tr>
                    <tr>
                        <td valign="bottom">
                            <%-- <div runat="server" id="divNote" visible="true" style="height: 136px;">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td background="/Admin/images/OAimages/rbg_2.jpg" height="30">
                                            <table width="200" height="20" align="center" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label_Note" runat="server" Text="便签条" CssClass="ziti_style3"></asp:Label>
                                                    </td>
                                                    <td align="right">
                                                        <asp:Label ID="label_most" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table width="220" border="0" cellspacing="0" cellpadding="0">
                                                <caption>
                                                    <tr>
                                                        <td>
                                                            <div id="NotePad">
                                                                <asp:GridView ID="GridVie_NoteDetial" runat="server" AutoGenerateColumns="False"
                                                                    PageSize="3" ShowHeader="False" CellPadding="1" GridLines="None" CssClass="GridVie_NoteDetial1">
                                                                    <Columns>
                                                                        <asp:TemplateField>
                                                                            <ItemTemplate>
                                                                                <table border="0" cellpadding="0" cellspacing="0" style="margin-left: 4px;">
                                                                                    <tr>
                                                                                        <td>
                                                                                            <a style="color: White;" target="_self" title="<%#Eval("NAMES")%>创建时间:<%#Eval("DATETIME") %>">
                                                                                                <%# substr(Eval("NAMES"))%></a>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                                <asp:HiddenField ID="HiddenField1" runat="server" />
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </caption>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="bottom" height="36" background="/Admin/images/OAimages/rbg_3.jpg">
                                            <table width="220" height="36" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="Label_addNote" runat="server" Text=""></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>--%>
                            <div runat="server" id="div_friendlylink" visible="true">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td background="/Admin/images/OAimages/rbg_2.jpg" height="30">
                                            <table width="200" height="20" align="center" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label_FriendlyLink" runat="server" Text="专题链接" CssClass="ziti_style3"></asp:Label>
                                                    </td>
                                                    <td align="right">
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <%--<table width="220" border="0" cellspacing="0" cellpadding="0">
                                                <caption>
                                                    <tr>
                                                        <td>
                                                        <div id="Link" class="div_scroll" style="height: 85px;">
                                                            <asp:GridView ID="GridVie_FriendlyLink" AutoGenerateColumns="False" OnRowDataBound="GridVie_FriendlyLink_RowDataBound"
                                                                GridLines="None" runat="server" CellPadding="3" ShowHeader="false" ShowFooter="false"
                                                                CssClass="GridVie_NoteDetial1">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <table border="0" cellpadding="0" cellspacing="1" style="margin-left: 4px;">
                                                                                <tr>
                                                                                    <td>
                                                                                        &nbsp;&nbsp;<asp:Label ID="LB_links" runat="server" Text=""></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                            <asp:HiddenField ID="HiddenField1" runat="server" />
                                                             </div>
                                                        </td>
                                                    </tr>
                                                    <tr><td height="2">&nbsp;</td></tr>
                                                </caption>
                                            </table>--%>
                                            <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,29,0"
                                                width="228" height="82">
                                                <param name="movie" value="/FLASH/flashPlay/bcastr3.swf">
                                                <param name="quality" value="high">
                                                <param name="wmode" value="transparent">
                                                <param name="FlashVars" value="bcastr_xml_url=/FLASH/xml/bcastr.xml">
                                                <embed src="/FLASH/flashPlay/bcastr3.swf" flashvars="bcastr_xml_url=/FLASH/xml/bcastr.xml" quality="high"
                                                    pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash"
                                                    width="228" height="82"></embed>
                                            </object>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
