<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Cash_applyCarDetailList.ascx.cs" Inherits="Dianda.Web.Admin.cashCardManage.Cash_applyCarDetailList" %>
<%--设置一个资金预约的多个资金卡的细目数据--%>
<asp:DropDownList ID="DropDownList_cashCar" runat="server">
</asp:DropDownList>
<asp:Button runat="server" ID="addcar" Text="+" onclick="addcar_Click" 
    />
<asp:Label ID="Label_notice" Visible="false" runat="server" Text="资金卡已经存在于列表中！"></asp:Label>


<asp:DataList ID="DataList1" runat="server">
    <ItemTemplate>
    <table cellpadding="0" cellspacing="0" width="100%">
    <tr>
    <td>
    <asp:HiddenField ID="HiddenField_cardid" Value='<%#Eval("CardID")%>' runat="server" /><%#Eval("CardNAME")%>
    </td>
    </tr>
    <tr>
    <td>
     <asp:GridView ID="GridView1" AutoGenerateColumns="False" DataKeyNames="ID" runat="server"
     onrowdatabound="GridView1_RowDataBound" CellPadding="4" 
    ForeColor="#333333" GridLines="None">
    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
    <Columns>
          <asp:TemplateField HeaderText="细目名称">
            <ItemTemplate>
             <%#Eval("DetailName")%><asp:HiddenField ID="HiddenField_detailid" Value='<%#Eval("DetailID")%>' runat="server" />
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
            <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
        </asp:TemplateField>
     
        <asp:TemplateField HeaderText="费用(元)">
            <ItemTemplate>
                <asp:TextBox ID="TextBox_balance" CssClass="textbox_name" Width="100px" runat="server"></asp:TextBox> 
                /<%#double.Parse(Eval("Balance").ToString()) * double.Parse(Eval("Unit").ToString())%>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
            <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="细目的类型">
            <ItemTemplate>
              <%#Eval("TypesName")%>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
            <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
        </asp:TemplateField>
         
         <asp:TemplateField HeaderText="">
            <ItemTemplate>
              <asp:RegularExpressionValidator  ID="RegularExpressionValidator3" runat="Server" ControlToValidate="TextBox_balance"
                                                                                        ValidationGroup="add2"  ValidationExpression="^([0-9]\d{0,11})$|^(0|[0-9]\d{0,11})\.(\d{0,2})$"
                                                                                        ErrorMessage="请输入数字!" Display="Dynamic" />
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
            <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
        </asp:TemplateField>
    </Columns>
    <FooterStyle CssClass="FooterStyle1" BackColor="#5D7B9D" Font-Bold="True" 
        ForeColor="White" />
    <PagerStyle HorizontalAlign="Center" CssClass="PagerStyle1" BackColor="#284775" 
        ForeColor="White" />
    <SelectedRowStyle CssClass="SelectedRowStyle1" BackColor="#E2DED6" 
        Font-Bold="True" ForeColor="#333333" />
    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <EditRowStyle BackColor="#999999" />
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
</asp:GridView>
    </td>
    </tr>
    </table>
    </ItemTemplate>
</asp:DataList>

<div style="display:none">
<asp:Label ID="Label_TOTAL" runat="server" Text="0"></asp:Label>
<asp:Button ID="Button_save" runat="server" Text="save" 
    onclick="Button_save_Click" /><asp:TextBox ID="TextBox_totalnew"   
    runat="server" ontextchanged="TextBox_totalnew_TextChanged" AutoPostBack="true"></asp:TextBox></div>
    <div id="nodetailslist" runat="server" visible="false">该资金卡中没有细目数据！</div>