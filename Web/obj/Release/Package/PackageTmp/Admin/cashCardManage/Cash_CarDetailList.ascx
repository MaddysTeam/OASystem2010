<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Cash_CarDetailList.ascx.cs"
    Inherits="Dianda.Web.Admin.cashCardManage.Cash_CarDetailList" %>

<script type="text/javascript">
    function ChangeTotalText(isnew,action) {

        var total = 0;
        var bili = 0.01;
        var bhbili = 0.01;
        var controls = document.getElementById("<%=GridView1.ClientID%>").rows;
        for (var i = 0; i < controls.length; i++) {
            if (controls.item(i).getElementsByTagName("INPUT")[0].type == "text") {
                //计算总金额时需要考虑到单位是万元还是元，如是万元，则要乘以单位值10000
                total = total + parseFloat(controls.item(i).getElementsByTagName("INPUT")[0].value) * parseInt(controls.item(i).getElementsByTagName("SELECT")[0].value)
            }
        }

        if (null != action && action.toString() == "modify") {

            for (var i = 0; i < controls.length; i++) {
                var k = 0;
                bili = parseFloat(controls.item(i).getElementsByTagName("INPUT")[0].value) * parseInt(controls.item(i).getElementsByTagName("SELECT")[0].value) / total
                
                if (parseFloat(controls.item(i).getElementsByTagName("INPUT")[1].value) > 0)//对应的是HiddenField_KYbalance最加载时的金额
                {
                    k = 2;//这里是为了取百分制下标用，因为一旦输入框有值，公交卡、现金这个单选就不能用了，就变成label了，即SPAN，所以百分制就处于第三位，即下标为2，
                }
                controls.item(i).getElementsByTagName("INPUT")[2].value = bili;

                if (parseFloat(bili) < parseFloat("0.01")) {
                    if (parseFloat(controls.item(i).getElementsByTagName("INPUT")[0].value)==0)
                    {
                        controls.item(i).getElementsByTagName("SPAN")[k].innerHTML = ""; 
                    }else
                    {
                        controls.item(i).getElementsByTagName("SPAN")[k].innerHTML = "<0.01%";
                    }
                    
                }
                else {
                    //这里有三个100，前一个100是因为要换成百分制(%)，所以要乘以100；后面又乘个100，完了又总除以100的目的是保持小数点后二位
                    controls.item(i).getElementsByTagName("SPAN")[k].innerHTML = Math.round((parseFloat(bili) * 100) * 100) / 100 + "%";
                }
            }
        }   

        if (isnew == 0)//编辑时预算金额是不变的
        {
            var TB_Balance = document.getElementById("<%=TB_Balance.ClientID%>");
            TB_Balance.value = total;
        }
        else {
            var TB_LimitNums = document.getElementById("<%=TB_LimitNums.ClientID%>");
            TB_LimitNums.value = total;
        }
    }

    //可用金额变化时，各资金卡明细的变化
    function setSchoolRate() {
        var controls = document.getElementById("<%=GridView1.ClientID%>").rows;
        var TB_LimitNums = document.getElementById("<%=TB_LimitNums.ClientID%>");
         
        for (var i = 0; i < controls.length; i++) {
            var bili = controls.item(i).getElementsByTagName("INPUT")[2].value
            if (null == TB_LimitNums.value || TB_LimitNums.value == "") {
                controls.item(i).getElementsByTagName("INPUT")[0].value = 0;
            }
            else {
                var balance = (parseFloat(TB_LimitNums.value) * parseFloat(bili)) / parseInt(controls.item(i).getElementsByTagName("SELECT")[0].value);
                controls.item(i).getElementsByTagName("INPUT")[0].value = Math.round(balance * 100)/100;
            }
        }
    }
    function isDigit() {
        return ((event.keyCode >= 48) && (event.keyCode <= 57));
    }   
</script>

<%--每张资金卡设置其有多少项的地方--%>
<asp:GridView ID="GridView1" AutoGenerateColumns="False" DataKeyNames="ID" runat="server"
    OnRowDataBound="GridView1_RowDataBound" CellPadding="4" ForeColor="#333333" GridLines="None"
    ShowHeader="false">
    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
    <Columns>
        <asp:TemplateField HeaderText="明细名称">
            <ItemTemplate>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" Height="20" />
            <HeaderStyle HorizontalAlign="Center" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="费用">
            <ItemTemplate>
                <%-- 这个Item中如果还要加控件请保持“TextBox_balance”和“DropDownList_Unit”这二个控件始终在这里处于前二位，
           即“TextBox_balance”在input一类中下标处于[0]，“HiddenField_KYbalance”下标处于[1]，“DropDownList_Unit”在select一类中下标处于[0]；
           因为在js中有用到它们的下标，如更改后将会使资金总额连动功能失效可以往“HiddenField_deid”后面加--**************很重要，不看加错了地方出错难调噢******************--%>
                <asp:TextBox ID="TextBox_balance" Width="50px" runat="server" Text="0"></asp:TextBox>&nbsp;<asp:DropDownList
                    ID="DropDownList_Unit" runat="server">
                    <asp:ListItem Value="1">元</asp:ListItem>
                    <asp:ListItem Value="10000">万元</asp:ListItem>
                </asp:DropDownList><%------这个位置不要动----%>
                <asp:HiddenField ID="HiddenField_KYbalance" runat="server" /><%------这个位置不要动----%>
                <asp:HiddenField ID="HF_BILI" runat="server" /><%------这个位置不要动----%>
                <asp:HiddenField ID="HiddenField_balance" runat="server" />
                <asp:HiddenField ID="HiddenField_deid" runat="server" />
                <asp:HiddenField ID="HiddenField_ID" runat="server" />
                
                <%---------------------------------- 如需再加控件请加在这里------------------------------------%>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
            <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="细目的类型">
            <ItemTemplate>
                <asp:RadioButtonList ID="RadioButtonList_typename" RepeatColumns="2" runat="server">                
                    <asp:ListItem Selected="True" Value="现金">现金</asp:ListItem>
                    <asp:ListItem  Value="公务卡">公务卡</asp:ListItem>
                </asp:RadioButtonList>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
            <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="比例">
            <ItemTemplate>
                <asp:Label ID="lb_bili" runat="server" Text="" ></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
            <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="">
            <ItemTemplate>
                <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="Server" ControlToValidate="TextBox_balance"
                    ValidationGroup="add2" ValidationExpression="^([0-9]\d{0,11})$|^(0|[0-9]\d{0,11})\.(\d{0,2})$"
                    ErrorMessage="请输入数字!" Display="Dynamic" />--%>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="Server" ControlToValidate="TextBox_balance"
                    ValidationGroup="add1" ValidationExpression="^\d+(\.[0-9]{0,2})?$" ErrorMessage="请输入数字!"
                    Display="Dynamic" />
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
            <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
        </asp:TemplateField>
    </Columns>
    <FooterStyle CssClass="FooterStyle1" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <PagerStyle HorizontalAlign="Center" CssClass="PagerStyle1" BackColor="#284775" ForeColor="White" />
    <SelectedRowStyle CssClass="SelectedRowStyle1" BackColor="#E2DED6" Font-Bold="True"
        ForeColor="#333333" />
    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <EditRowStyle BackColor="#999999" />
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
</asp:GridView>
<asp:HiddenField ID="HF_MXinfor" runat="server" />
<table>
    <tr>
        <td>
            预算金额：<asp:TextBox ID="TB_Balance" runat="server" CssClass="textbox_name" Height="16px"
                Enabled="false" Width="60px" Text="0"></asp:TextBox>
            元
        </td>
        <td width="15">
        </td>
        <td runat="server" id="td_LimitNums">
            可用金额：<asp:TextBox ID="TB_LimitNums" runat="server" AutoPostBack="true" CssClass="textbox_name"
                Height="16px"  Width="60px" Text="0" onkeyup="setSchoolRate() ;" onkeypress="event.returnValue=isDigit();" onpaste="return false;" ></asp:TextBox>
            元
        </td>
    </tr>
</table>
<div style="display: none">
    <%-- style="display:none"--%>
    <asp:Label ID="Label_TOTAL" runat="server" Text="0"></asp:Label>
    <asp:Button ID="Button_save" runat="server" Text="save" OnClick="Button_save_Click" /><asp:TextBox
        ID="TextBox_totalnew" runat="server" OnTextChanged="TextBox_totalnew_TextChanged"
        AutoPostBack="true"></asp:TextBox></div>