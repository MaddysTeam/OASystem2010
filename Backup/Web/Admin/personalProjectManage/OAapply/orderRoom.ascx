<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="orderRoom.ascx.cs" Inherits="Dianda.Web.Admin.personalProjectManage.OAapply.orderRoom" %>

<script language="javascript" type="text/javascript">
    function onClientClick(selectedId, carid) {
        //用隐藏控件记录下选中的行号
        document.getElementById("ctl00_ContentPlaceHolder1_orderRoom_HF_orderroomID").value = carid;
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
        //每次在点击查看预订会议室时将原先选择的会议清除
        document.getElementById("ctl00_ContentPlaceHolder1_orderRoom_HF_orderroomID").value = "";

        var inputs = document.getElementById("<%=GridView1.ClientID%>").getElementsByTagName("input");
        for (var i = 0; i < inputs.length; i++) {
            if (inputs[i].type == "radio") {
            
                 inputs[i].checked = false;

            }
        }
        
    }
    
    function check() {
        var ordertime = document.getElementById("ctl00_ContentPlaceHolder1_orderRoom_TB_orderroomtime").value;

        if (ordertime.length == 0) {
            alert("会议时间不能为空!");
            return false;
        }
    }
    function SetValue(str, flag) {
        document.getElementById("<%= HiddenField2.ClientID%>").value = str;
        if (flag == "1") {
            var ordertime = document.getElementById("ctl00_ContentPlaceHolder1_orderRoom_TB_orderroomtime").value;
            document.getElementById("ctl00$ContentPlaceHolder1$orderRoom$TB_ordertime2").value = ordertime;
        }
        return true;
    }
</script>

<asp:HiddenField ID="HiddenField2" runat="server" />
<table border="0" cellpadding="0" cellspacing="0" width="100%" bgcolor="#99CCCD">
    <tr>
        <td>
            会议时间：<input class="Inputtext" id="TB_orderroomtime" runat="server" width="200" type="text"
                readonly="readonly" onclick="ShowCalendar(this);" onpropertychange="SetValue('fales','1');" />&nbsp;<asp:DropDownList
                    ID="DDL_hour11" OnSelectedIndexChanged="ddl_Part_change" AutoPostBack="true" runat="server" onchange="SetValue('fales','0');">
                </asp:DropDownList>
            &nbsp;时&nbsp;<asp:DropDownList ID="DDL_minute11" OnSelectedIndexChanged="ddl_Part_change" AutoPostBack="true"   runat="server" onchange="SetValue('fales','0');">
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
                        width="200" type="text" readonly="readonly" onclick="ShowCalendar(this);" />&nbsp;<asp:DropDownList ID="DDL_hour21" runat="server"
                onchange="SetValue('fales','0');">
            </asp:DropDownList>
            &nbsp;时&nbsp;<asp:DropDownList ID="DDL_minute21" runat="server" onchange="SetValue('fales','0');">
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
            &nbsp;分&nbsp;<asp:Button ID="Button_Check" runat="server" CssClass="button4" Text="查看预订情况"
                OnClick="Button_Check_Click" />&nbsp;&nbsp;<%--<asp:Label
                    ID="LB_notice" runat="server" Text="请先查看预订情况再申请！" ForeColor="Red"></asp:Label>--%>
        </td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="GridView1" AutoGenerateColumns="false" runat="server" Width="100%"
                OnRowDataBound="GridView1_RowDataBound" CssClass="GridView1">
                <Columns>
                    <asp:TemplateField HeaderText="">
                        <HeaderTemplate>
                            选择会议室
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:RadioButton ID="RadioButton_choose" runat="server" Enabled="false" />
                            <asp:HiddenField ID="Hid_ID" runat="server" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="会议室名称" DataField="RoomName">
                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="简介">
                        <ItemTemplate>
                            <span title="<%#Eval("Infors").ToString()%>">
                                <%#Eval("Infors").ToString().Length > 35 ? Eval("Infors").ToString().Substring(0, 35) + "..." : Eval("Infors").ToString()%></span>
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
            <asp:HiddenField ID="HF_orderroomID" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <div style="width: auto; padding-top: 5px; float: left">
                <div style="float: left">
                    会议名称：</div>
                <asp:TextBox ID="TB_MeetingName" runat="server" Style="float: left;"></asp:TextBox>
                <div style="float: left">
                    &nbsp;&nbsp;会议人数：</div>
                <asp:TextBox ID="TB_MeetingNums" runat="server" Text="0" Style="float: left;"></asp:TextBox><%--&nbsp;&nbsp;会议地址：<asp:TextBox ID="TB_MeetingAddress" runat="server" Width="260px"></asp:TextBox>--%>
                <div style="float: left">
                    &nbsp;&nbsp;预定要求:</div>
            </div>
            <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatDirection="Horizontal"
                Style="float: left;">
                <asp:ListItem>电脑</asp:ListItem>
                <asp:ListItem>投影仪</asp:ListItem>
                <asp:ListItem>会标</asp:ListItem>
                <asp:ListItem>席卡</asp:ListItem>
            </asp:CheckBoxList>
        </td>
    </tr>
</table>


