<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/OAmaster.Master" AutoEventWireup="true"
    CodeBehind="SelectUserPlan.aspx.cs" Inherits="Dianda.Web.Admin.WebForm1" %>

<%@ Register Src="../commonASCX/selectDate.ascx" TagName="selectDate" TagPrefix="uc1" %>
<%@ Register Src="~/Admin/ShowPlanUser.ascx" TagName="ShareForUser" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="/Admin/js/SelectDate2.js" type="text/javascript"></script>

    <link href="css/OACSS.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        function enableTooltips(id) {
            var links, i, h;
            if (!document.getElementById || !document.getElementsByTagName) return;
            h = document.createElement("span");
            h.id = "btc";
            h.setAttribute("id", "btc");
            h.style.position = "absolute";
            document.getElementsByTagName("body")[0].appendChild(h);
            if (id == null) links = document.getElementsByTagName("a");
            else links = document.getElementById(id).getElementsByTagName("a");
            for (i = 0; i < links.length; i++) {
                Prepare(links[i]);
            }
        }
        function Prepare(el) {
            var tooltip, t, b, s, l;
            t = el.getAttribute("message");
            if (t == null || t.length == 0) return;
            el.removeAttribute("message");
            tooltip = CreateEl("span", "tooltip");
            s = CreateEl("span", "top");
            //s.appendChild(document.createTextNode(t)); 改动 
            s.innerHTML = t;
            tooltip.appendChild(s);
            //b=CreateEl("b","bottom"); 
            l = el.getAttribute("href");
            if (l.length > 30) l = l.substr(0, 27) + "...";
            //b.appendChild(document.createTextNode(l)); 
            //tooltip.appendChild(b); 
            setOpacity(tooltip);
            el.tooltip = tooltip;
            el.onmouseover = showTooltip;
            el.onmouseout = hideTooltip;
            el.onmousemove = Locate;
        }
        function showTooltip(e) {
            document.getElementById("btc").appendChild(this.tooltip);
            Locate(e);
        }
        function hideTooltip(e) {
            var d = document.getElementById("btc");
            if (d.childNodes.length > 0) d.removeChild(d.firstChild);
        }
        function setOpacity(el) {
            el.style.filter = "alpha(opacity:95)";
            el.style.KHTMLOpacity = "0.95";
            el.style.MozOpacity = "0.95";
            el.style.opacity = "0.95";
        }
        function CreateEl(t, c) {
            var x = document.createElement(t);
            x.className = c;
            x.style.display = "block";
            return (x);
        }
        function Locate(e) {
            var posx = 0, posy = 0;
            if (e == null) e = window.event;
            if (e.pageX || e.pageY) {
                posx = e.pageX; posy = e.pageY;
            }
            else if (e.clientX || e.clientY) {
                if (document.documentElement.scrollTop) {
                    posx = e.clientX + document.documentElement.scrollLeft;
                    posy = e.clientY + document.documentElement.scrollTop;
                }
                else {
                    posx = e.clientX + document.body.scrollLeft;
                    posy = e.clientY + document.body.scrollTop;
                }
            }
            document.getElementById("btc").style.top = (posy + 10) + "px";
            document.getElementById("btc").style.left = (posx - 20) + "px";
        } 
    </script>

    <script type="text/javascript">
        window.onload = function() { enableTooltips() }; 
    </script>

    <style type="text/css">
        p
        {
            margin: 0 0 1.7em;
        }
        .tooltip
        {
            width: 200px;
            color: #000;
            font: lighter 11px/1.3 Arial,sans-serif;
            text-decoration: none;
            text-align: left;
        }
        .tooltip
        {
            width: 200px;
            color: #fff;
            font: lighter 11px/1.3 Arial,sans-serif;
            text-decoration: none;
            text-align: left;
        }
        .tooltip span.top
        {
            text-align: left;
            text-indent: 0em;
            padding: 10px 8px;
            background-color: #0083c9;
        }
        .tooltip b.bottom
        {
            padding: 3px 8px 10px;
            color: #548912;
            background-color: #f0f0f0;
        }
    </style>
    <table align="center" cellpadding="0" cellspacing="0" width="965" bgcolor="#99cccd">
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td valign="top" cellpadding="0" cellspacing="0" width="100%">
                                        <table>
                                            <tr>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0" width="100%">
                                                        <tr>
                                                            <td align="right" valign="top">
                                                                <table id="SelectTable" runat="server" height="400px" cellpadding="0" cellspacing="0"
                                                                    width="100%">
                                                                    <tr>
                                                                        <td valign="top">
                                                                            <table width="955" cellpadding="0" cellspacing="0" bgcolor="#99cccd">
                                                                                <tr>
                                                                                    <td height="25" align="left">
                                                                                        &nbsp; 请选择检索条件
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td valign="top">
                                                                                        <table cellpadding="5" cellspacing="3" bgcolor="#ffffff" width="100%">
                                                                                            <tr>
                                                                                                <td align="left">
                                                                                                    部门：
                                                                                                    <asp:DropDownList ID="DDL_Department" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDL_Department_SelectedIndexChanged"
                                                                                                        Width="120px">
                                                                                                    </asp:DropDownList>
                                                                                                    用户：
                                                                                                    <asp:DropDownList ID="User_DPList" runat="server" Width="120px">
                                                                                                    </asp:DropDownList>
                                                                                                    <%--  开始日期：--%>
                                                                                                    <%--    <input class="Inputtext" id="txtBeginDate" runat="server" width="200" type="text"
                                                                                                        readonly="readonly" onclick="ShowCalendar(this);" />--%>
                                                                                                    <%-- <uc1:selectDate ID="selectDate_start" runat="server" />--%>
                                                                                                    <%--    结束日期：--%>
                                                                                                    <%-- <input class="Inputtext" id="txtEndTime" runat="server" width="200" type="text" readonly="readonly"
                                                                                                        onclick="ShowCalendar(this);" />--%><%--<uc1:selectDate ID="selectDate_end" 
                                                                                                        runat="server" />--%><asp:Button ID="Button1" CssClass="button1" runat="server" Text="查询"
                                                                                                            OnClick="Button1_Click" />
                                                                                                    &nbsp;<asp:Button ID="backToHome" CssClass="button1" runat="server" Text="返回" OnClick="backToHome_Click1" />
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left">
                                                                            <asp:Label ID="Label_flash" runat="server" Text=""></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="height: 10px;">
                                                                        <td align="right">
                                                                            <asp:Button ID="ButSet" runat="server" CssClass="button3d" Text="日历查看授权" OnClick="ButSet_Click"
                                                                                Visible="false" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="vertical-align: top; text-align: center;">
                                                                            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <table cellpadding="0" cellspacing="0" width="100%" id="CheckUser" runat="server">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Button ID="Button2" runat="server" CssClass="button3d" Text="查看他人个人计划" Visible="false"
                                                                                OnClick="Button2_Click" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="height: 20px;" bgcolor="#99cccd">
                                                                        <td align="left" style="font-weight: bold">
                                                                            <asp:CheckBox ID="ALLCheck" runat="server" Text="设置为所有人可见" OnCheckedChanged="ALLCheck_CheckedChanged"
                                                                                AutoPostBack="True" Font-Bold="True" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td valign="top" width="950" align="left" style="border: solid 1px black">
                                                                            <asp:ScriptManager ID="ScriptManager1" runat="server">
                                                                            </asp:ScriptManager>
                                                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                                <ContentTemplate>
                                                                                    <uc2:ShareForUser ID="ShareForUser1" runat="server" />
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td height="40px" align="center" bgcolor="#ffffff">
                                                                            <asp:Button ID="Button_sumbit" runat="server" Text=" 确 定 " CssClass="button1" OnClick="Button_sumbit_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                                                                            <input id="Button3" type="button" onclick="javascript:location.href='person_Index.aspx'" class="button1" value=" 返 回 " />
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
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="HiddenField_ip" runat="server" Value="202.121.15.15,202.121.15.15:10891;218.78.241.65,218.78.241.65:10891;oa.sjys.cn,218.78.241.65:10891;202.121.,202.121.15.15:10891;localhost,202.121.80.141:10891;172.16.2.100,172.16.2.100:10891;172.16.2.107,172.16.2.107:10891" />
    
</asp:Content>

