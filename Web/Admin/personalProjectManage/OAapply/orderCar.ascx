<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="orderCar.ascx.cs" Inherits="Dianda.Web.Admin.personalProjectManage.OAapply.orderCar" %>

<script language="javascript" type="text/javascript">
    function onClientClick(selectedId, carid) {
        //用隐藏控件记录下选中的行号
        document.getElementById("ctl00_ContentPlaceHolder1_orderCar_HiddenField1").value = carid;
        var inputs = document.getElementById("<%=GridView1.ClientID%>").getElementsByTagName("input");
        for (var i = 0; i < inputs.length; i++) {
            if (inputs[i].type == "radio") {
                if (inputs[i].id == selectedId)
                    inputs[i].checked = true;
                else
                    inputs[i].checked = false;

            }
        }
    }

    function setHFClick() {
        //用隐藏控件记录下选中的行号
        document.getElementById("ctl00_ContentPlaceHolder1_orderCar_HiddenField1").value = "";
        var inputs = document.getElementById("<%=GridView1.ClientID%>").getElementsByTagName("input");
        for (var i = 0; i < inputs.length; i++) {
            if (inputs[i].type == "radio") {
                inputs[i].checked = false;

            }
        }
    }

    function check() {
        var ordertime = document.getElementById("ctl00_ContentPlaceHolder1_orderCar_TB_ordertime1").value;

        if (ordertime.length == 0) {
            alert("用车时间不能为空!");
            return false;
        }
    }
    function SetValue(str,flag) {
        document.getElementById("<%= HiddenField2.ClientID%>").value = str;
        if (flag=="1")
        {
            var ordertime = document.getElementById("ctl00_ContentPlaceHolder1_orderCar_TB_ordertime1").value;
            document.getElementById("ctl00$ContentPlaceHolder1$orderCar$TB_ordertime2").value = ordertime;
        }
        return true;
    }
    
</script>

        <asp:HiddenField ID="HiddenField2" runat="server" />
        <table border="0" cellpadding="0" cellspacing="0" width="100%" bgcolor="#99CCCD">
            <tr>
                <td>
                    用车时间：<input class="Inputtext" id="TB_ordertime1" runat="server" width="200" type="text"
                        readonly="readonly" onclick="ShowCalendar(this);" onpropertychange="SetValue('fales','1');" />&nbsp;<asp:DropDownList
                            ID="DDL_hour1" runat="server" AutoPostBack="true" onchange="SetValue('fales','0')"
                            OnSelectedIndexChanged="ddl_Part_change">
                        </asp:DropDownList>
                    &nbsp;时&nbsp;
                    <asp:DropDownList ID="DDL_minute1" runat="server" onchange="SetValue('fales','0')" AutoPostBack="true"
                        OnSelectedIndexChanged="ddl_Part_change">
                        <asp:ListItem>00</asp:ListItem>
                        <asp:ListItem>05</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>15</asp:ListItem>
                        <asp:ListItem>20</asp:ListItem>
                        <asp:ListItem>25</asp:ListItem>
                        <asp:ListItem>30</asp:ListItem>
                        <asp:ListItem>35</asp:ListItem>
                        <asp:ListItem>40</asp:ListItem>
                        <asp:ListItem>45</asp:ListItem>
                        <asp:ListItem>50</asp:ListItem>
                        <asp:ListItem>55</asp:ListItem>
                        <asp:ListItem>59</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;分&nbsp;&nbsp;至&nbsp;&nbsp;<input class="Inputtext" id="TB_ordertime2" runat="server"
                        width="200" type="text" readonly="readonly" onclick="ShowCalendar(this);" />&nbsp;<asp:DropDownList
                            ID="DDL_hour2" runat="server" onchange="SetValue('fales','0');">
                        </asp:DropDownList>
                    &nbsp;时&nbsp;<asp:DropDownList ID="DDL_minute2" runat="server"  onchange="SetValue('fales','0');">
                        <asp:ListItem Selected="True">00</asp:ListItem>
                        <asp:ListItem>05</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>15</asp:ListItem>
                        <asp:ListItem>20</asp:ListItem>
                        <asp:ListItem>25</asp:ListItem>
                        <asp:ListItem>30</asp:ListItem>
                        <asp:ListItem>35</asp:ListItem>
                        <asp:ListItem>40</asp:ListItem>
                        <asp:ListItem>45</asp:ListItem>
                        <asp:ListItem>50</asp:ListItem>
                        <asp:ListItem>55</asp:ListItem>
                        <asp:ListItem >59</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;分&nbsp;<asp:Button ID="Button_Check" runat="server" Text="查看预订情况" CssClass="button4"
                        OnClick="Button_Check_Click" />&nbsp;&nbsp;<%--<asp:Label ID="LB_notice" runat="server"
                    Text="请先查看预订情况再申请！" ForeColor="Red"></asp:Label>--%>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GridView1" AutoGenerateColumns="false" runat="server" Width="100%"
                        DataKeyNames="DELFLAG" OnRowDataBound="GridView1_RowDataBound" CssClass="GridView1">
                        <Columns>
                            <asp:TemplateField HeaderText="">
                                <HeaderTemplate>
                                    选择车辆
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:RadioButton ID="RadioButton_choose" runat="server" Enabled="false" />
                                    <asp:HiddenField ID="Hid_ID" runat="server" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="车名" DataField="CarName">
                                <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="司机" DataField="DriverName">
                                <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="车牌" DataField="CarNum">
                                <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="简介">
                                <ItemTemplate>
                                    <span title="<%#Eval("Infors").ToString()%>">
                                        <%#Eval("Infors").ToString().Length > 20? Eval("Infors").ToString().Substring(0, 20) + "..." : Eval("Infors").ToString()%></span>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="预订情况" DataField="">
                                <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                            </asp:BoundField>
                        </Columns>
                        <RowStyle Height="5" />
                    </asp:GridView>
                    <%--<input id="Hidden1" type="hidden" runat="server"/>--%>
                    <asp:Label ID="notice" runat="server" Text="" ForeColor="Red"></asp:Label>
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    乘车人数：<asp:TextBox ID="TB_PeopleNum" runat="server" Text="0"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;始发地：<asp:TextBox
                        ID="TB_FromAddress" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;目的地：<asp:TextBox
                            ID="TB_ToAddress" runat="server"></asp:TextBox>&nbsp;&nbsp;
                </td>
            </tr>
        </table>
<%--    </ContentTemplate>
</asp:UpdatePanel>--%>
