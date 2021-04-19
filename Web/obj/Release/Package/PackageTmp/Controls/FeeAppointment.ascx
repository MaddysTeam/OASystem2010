<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FeeAppointment.ascx.cs"
    Inherits="Dianda.Web.Controls.FeeAppointment" %>
<div>
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr style="padding-bottom: 2px; padding-top: 2px;">
            <td>
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td align="right" style="width: 80px;">
                            预约类型：
                        </td>
                        <td>
                            <asp:RadioButtonList ID="RBList_RXZ" runat="server" RepeatColumns="2" onclick="ChanageShow()">
                                <asp:ListItem Text="资金卡" Value="0" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="专项资金" Value="1"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <div style="display: block; width: 100%;" id="divShow1">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr style="padding-bottom: 2px; padding-top: 2px;">
                            <td align="right" style="width: 80px;">
                                所属项目：
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlProjectID" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr style="padding-bottom: 2px; padding-top: 2px;">
                            <td align="right" style="width: 80px;">
                                <asp:Label ID="Lab_ZJK" runat="server" Text="资金卡："></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="DDList_Cards" runat="server">
                                </asp:DropDownList>
                                <asp:Button ID="Btn_Add" runat="server" Text="+" OnClientClick="return funAddRow();" />
                                <asp:HiddenField ID="hide_CardListID" runat="server" />
                                <asp:HiddenField ID="hide_CarDetails" runat="server" />
                                <asp:HiddenField ID="hide_Sum" runat="server" />
                                <asp:HiddenField ID="hide_CardName" runat="server" />
                            </td>
                        </tr>
                    </table>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td align="left">
                                <div id="divTab" style="width: 99%; display: none;">
                                    <asp:DataList ID="DataList1" runat="server" CellPadding="1" RepeatColumns="1" GridLines="none"
                                        Width="100%" OnItemDataBound="DataList1_ItemDataBound">
                                        <ItemTemplate>
                                            <fieldset>
                                            <legend>
                                                        <asp:Label ID="Lab_MX" runat="server" Text=''><%# Eval("AccountName") %>：<%#Eval("Subscription")%>/<%#Eval("EveryDayNum") %></asp:Label><label
                                                            style='color: Red;'>（每日限报金额）</label></legend>
                                                        <asp:DataList ID="DList_ZJK" runat="server" RepeatDirection="Horizontal" GridLines="none"
                                                            CellPadding="0" CellSpacing="0" OnItemDataBound="DList_ZJKMX_ItemDataBound" RepeatColumns="1">
                                                            <ItemTemplate>
                                                                <table>
                                                                    <tr>
                                                                        <td>
                                                                            资金卡：<input type="button" id="<%#Eval("cardID") %>" value="-" onclick="funRemoveRow(this);"
                                                                                style="display: none;" />
                                                                        </td>
                                                                        <td>
                                                                            <label id="lab_cardname">
                                                                                <a href="showCardInfo.aspx?id=<%#Eval("cardID") %>" target="_blank">
                                                                                    <%# Eval("cardname")%></a></label>
                                                                        </td>
                                                                            <td align="center">
                                                                            <asp:LinkButton ID="LBtn_JZ" CssClass="button3a" CommandArgument='<%# Eval("CarDetails") %>'
                                                                                runat="server" OnClick="lb_Click">记账</asp:LinkButton>
                                                                            <asp:HiddenField ID="hide_AccountID" runat="server" Value='<%#Eval("AccountID") %>' />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <table border="0" cellpadding="0" cellspacing="0" width="100%" class="Green_Table"
                                                                    id="tab_ZJK" runat="server">
                                                                    <tr>
                                                                        <td rowspan="2" align="left">
                                                                            <asp:DataList ID="DList_ZJKMX" runat="server" RepeatColumns="6" RepeatDirection="Horizontal"
                                                                                GridLines="None" CellPadding="0" CellSpacing="0">
                                                                                <ItemTemplate>
                                                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="Green_Table">
                                                                                        <tr class="Green_TableHeader">
                                                                                            <td>
                                                                                                <%# Eval("DetailName")%>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr class="Green_TableRowCenter">
                                                                                            <td>
                                                                                                <%# Eval("CarDetails") %>/<%# Eval("DetailName_FY")%>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </ItemTemplate>
                                                                                <ItemStyle Width="100px" />
                                                                            </asp:DataList>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ItemTemplate>
                                                        </asp:DataList>
                                            </fieldset>
                                            <table id='tab_Account' width="100%" border="0" cellpadding="0" cellspacing="0">
                                            </table>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                    </asp:DataList>
                                    <asp:DataList ID="DataList2" runat="server" CellPadding="1" RepeatColumns="1" GridLines="none"
                                        Width="100%" OnItemDataBound="DataList1_ItemDataBound">
                                        <ItemTemplate>
                                            <fieldset>
                                                <legend>
                                                        <asp:Label ID="Lab_MX" runat="server" Text=''><%# Eval("AccountName") %>：<%#Eval("Subscription")%>/<%#Eval("EveryDayNum") %></asp:Label><label
                                                            style='color: Red;'>（每日限报金额）</label></legend>
                                                        <asp:DataList ID="DList_ZJK" runat="server" RepeatDirection="Horizontal" GridLines="None"
                                                            CellPadding="0" CellSpacing="0" OnItemDataBound="DList_ZJKMX_ItemDataBound" RepeatColumns="1">
                                                            <ItemTemplate>
                                                                资金卡：<input type="button" id="<%#Eval("cardID") %>" value="-" onclick="funRemoveRow(this);"
                                                                    style="display: none;" />
                                                                <label id="lab_cardname">
                                                                    <a href="showCardInfo.aspx?id=<%#Eval("cardID") %>" target="_blank">
                                                                        <%# Eval("cardname")%></a></label>
                                                                <asp:HiddenField ID="hide_AccountID" runat="server" Value='<%#Eval("AccountID") %>' />
                                                                <table border="0" cellpadding="0" cellspacing="0" width="100%" class="Green_Table"
                                                                    id="tab_ZJK" runat="server">
                                                                    <tr>
                                                                        <td rowspan="2" align="left">
                                                                            <asp:DataList ID="DList_ZJKMX" runat="server" RepeatColumns="6" RepeatDirection="Horizontal"
                                                                                GridLines="None" CellPadding="0" CellSpacing="0">
                                                                                <ItemTemplate>
                                                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="Green_Table">
                                                                                        <tr class="Green_TableHeader">
                                                                                            <td>
                                                                                                <%# Eval("DetailName")%>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr class="Green_TableRowCenter">
                                                                                            <td>
                                                                                                <%# Eval("CarDetails") %>/<%# Eval("DetailName_FY")%>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </ItemTemplate>
                                                                                <ItemStyle Width="80px" />
                                                                            </asp:DataList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="Green_TableRowCenter">
                                                                    </tr>
                                                                </table>
                                                            </ItemTemplate>
                                                        </asp:DataList>
                                            </fieldset>
                                            <table id='tab_Account' width="100%" border="0" cellpadding="0" cellspacing="0">
                                            </table>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                    </asp:DataList>
                                </div>
                            </td>
                        </tr>
                        <tr style="padding-bottom: 2px; padding-top: 2px;">
                            <td>
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td align="right" style="width: 80px;">
                                            金额：
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Txt_ApplyCount1" class="Inputtext" runat="server" Text="0" Enabled="false"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="display: none; width: 100%;" id="divShow2">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr style="padding-bottom: 2px; padding-top: 2px;">
                            <td align="right" style="width: 80px;">
                                专项资金：
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="DDL_SpecialFundsID" runat="server" onchange="funChangeSelect()">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr style="padding-bottom: 2px; padding-top: 2px;">
                            <td align="right" style="width: 80px;">
                                金额：
                            </td>
                            <td>
                                <asp:TextBox ID="Txt_ApplyCount2" class="Inputtext" runat="server" Text="0"></asp:TextBox>
                                /&nbsp;<label id="lab_ZHTS"></label>
                                <label style="color: Red;">
                                    （每日限报金额）</label>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>

    <script type="text/javascript">
        var DDList_Cards = "<%=DDList_Cards.ClientID %>";                   //下拉列表
        var TableName = "<%=DataList1.ClientID %>";                         //表的名字
        //新增一行
        function funAddRow(){
            var TnF = true;
            var IDStr = $("#" + DDList_Cards).val();                                        //id字符串
            
            if(IDStr == "" || IDStr==null){
                alert("无资金卡可使用！");
                return false;
            }
            var arr = IDStr.split('|');
            if(IDStr.indexOf('|')==-1){
                alert("该资金卡未绑定账号，不能使用！");
                return false;
            }
            var CardID = arr[0];                                                            //资金卡ID
            var AccountID = arr[1];                                                         //账户ID
            var divTab = $("#divTab");                                                      //div对象
            
            var tab_Account = divTab.find("fieldset[id*=table" + AccountID + "@]");         //是否存在该账户表
            var Input_CardID = divTab.find("#" + CardID);                                   //查找资金卡删除按钮
            if(Input_CardID.length != 0)
                TnF = false;
                
            var TRNum = tab_Account.length;
            if(TnF){
                var DataTab = Dianda.Web.Controls.FeeAppointment.ReturnVal(CardID, TRNum).value;
//                alert(DataTab)
                if(DataTab != "" && DataTab != null)
                {
                    if(TRNum == 0)
                        $(DataTab).appendTo(divTab);
                    else{
                        $(DataTab).appendTo(tab_Account);
                    }
                    divTab.show();
                }
                else{
                    alert("该资金卡不可用，请选择其它资金卡！");
                }
            }
            else{
                alert("该资金卡已添加过！");
            }

            return false;
        }
        
        //删除一行
        function funRemoveRow(s)
        {
            BtnID = s.id;                                                               //触发事件的按钮id
            var fieldsetID = s.hideid;
            var divTab = $("#divTab");                                                  //div对象
            var tab_Account = divTab.find("table[id*=tab_Account" + BtnID + "@]");      //表对象
            tab_Account.remove();
            
            var table = divTab.find("fieldset[id*=table"+ fieldsetID +"]");
            var son = table.find("table");
            if(son.length==0)
                table.remove();
            
            funShowDiv();
            funTotal();
            return false;
        }
        //焦点离开触发事件
        function funOnBlur(s)
        {
            var Txt = $("input[id*="+s+"]").val();
            var Lab = $("[id*="+(s).replace('@Txt','@Lab')+"]").html().replace('<BR>/','');
            Txt = Txt.replace("—","");
            
            funTotal();
            
            if(Txt!=""){
                if(isNaN(Txt)){
                    alert("请正确填写需要的金额！");
                    return false;
                }
                
                var type = /^\d+(\.[0-9]{0,2})?$/gi;
                if(!type.test(Txt)){
                    alert("小数点后只能有两位！");
                    return false;
                }
            }
            
            return true;
        }
        function funTotal()
        {
            var Sum = 0;
            var divTab = $("#divTab");
            var tab_Account = divTab.find("fieldset");
            
            tab_Account.each(function(i){
                var Txt = $(this).find("input[id*=@Txt]");
                var Tol = 0;
                Txt.each(function(j){
                    var val = $(this).val();
                    var type = /^\d+(\.[0-9]{0,2})?$/gi;
                    if(!isNaN(val)&&type.test(val))
                        Tol = Math.round((Tol + val*1)*100)/100;
                });
                var tabID = $(this).attr("id");
                var labID = tabID.replace("table", "lab_Account");
                Sum = Math.round((Sum + Tol)*100)/100;
                $("label[id*="+labID+"]").html(Tol);
            });
            $("input[id*=Txt_ApplyCount1]").val(Sum);
        }
        
        //预约类型切换事件
        function ChanageShow()
        {
            var RBList_RXZ = $("input[id*=RBList_RXZ]:checked").val();
            var divShow1 = $("#divShow1");
            var divShow2 = $("#divShow2");
            if(RBList_RXZ=="0")
            {
                divShow1.show();
                divShow2.hide();
            }
            else
            {
                divShow1.hide();
                divShow2.show();
            }
        }
        function funChangeSelect()
        {
            var SpecialFundsID = $("select[id*=DDL_SpecialFundsID]").val();
            var JE = SpecialFundsID.substring(SpecialFundsID.lastIndexOf("|")+1,SpecialFundsID.length);
            $("label[id*=lab_ZHTS]").html(JE);
        }
        function funShowDiv()
        {
            var divTab = $("#divTab");                                      //div对象
            var tab_Account = divTab.find("table[id*=tab_Account]");            //表对象
            if(tab_Account.length==0)
                divTab.hide();
            else
                divTab.show();
        }
        ChanageShow();
        funChangeSelect();
        funShowDiv();
    </script>

</div>
