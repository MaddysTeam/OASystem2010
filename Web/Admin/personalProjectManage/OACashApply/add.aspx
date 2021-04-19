<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/OAmaster.Master"
    CodeBehind="add.aspx.cs" Inherits="Dianda.Web.Admin.personalProjectManage.OACashApply.add" %>

<%@ Register Src="../../../Controls/FeeAppointment.ascx" TagName="FeeAppointment"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="/Admin/js/SelectDate.js" type="text/javascript"></script>

    <%@ register src="../../projectControl.ascx" tagname="projectControl" tagprefix="uc1" %>

    <table align="center" cellpadding="0" cellspacing="0" width="98%" bgcolor="#99cccd">
        <tr>
            <td>
                <table cellpadding="3" cellspacing="0" width="100%" class="tab7">
                    <tr>
                        <td valign="top">
                            <table class="tab4">
                                <tr>
                                    <td>
                                        <div id="div2" runat="server">
                                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                <tr>
                                                    <td align="center">
                                                        <asp:Label ID="tag" runat="server" Text="" CssClass="tag1" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table border="0" cellpadding="2" cellspacing="0">
                                                            <tr>
                                                                <td align="right" style="width: 80px;">
                                                                    预约说明：
                                                                </td>
                                                                <td>
                                                                    请提前2天进行报销预约，过期不报
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                    每天提交申请的时间需要在下午3点前，3点后发起的申请将顺延一天<br />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr bgcolor="#004272">
                                                    <td height="2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <uc2:FeeAppointment ID="FeeAppointment1" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table border="0" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td align="right" style="width: 80px;">
                                                                    报销日期：
                                                                </td>
                                                                <td style="padding-top: 1px">
                                                                    <table border="0" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td align="left">
                                                                                <input class="Inputtext" id="txtGetDateTime" runat="server" width="200" type="text"
                                                                                    readonly="readonly" onclick="ShowCalendar(this);" />&nbsp;<asp:DropDownList ID="ddlHour"
                                                                                        runat="server" Visible="false">
                                                                                    </asp:DropDownList>
                                                                                <asp:DropDownList ID="ddlMin" runat="server" Visible="false">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:RadioButtonList ID="RadioButtonList_shijian" runat="server" RepeatColumns="2">
                                                                                    <asp:ListItem Value=" 10:00:00" Selected="True">上午</asp:ListItem>
                                                                                    <asp:ListItem Value=" 12:00:00">下午</asp:ListItem>
                                                                                </asp:RadioButtonList>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table border="0" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td align="right" valign="top" style="width: 80px;">
                                                                    备注：
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtUseFor" runat="server" TextMode="MultiLine" Height="100px" Width="456px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr style="display: none;">
                                                                <td align="right">
                                                                    联系方式：
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtApplierTel" runat="server" CssClass="textbox_name"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Panel ID="Pan_AuditOpinion" runat="server" Visible="false">
                                                            <table border="0" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td align="right" valign="top" style="width: 80px;">
                                                                        审核意见：
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtAuditOpinion" runat="server" TextMode="MultiLine" Height="100px"
                                                                            Width="456px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                                <tr style="height: 30px;">
                                                    <td colspan="2" align="left" style="padding-left: 150px;">
                                                        <asp:Button ID="Button_sumbit" runat="server" Text="确定" CssClass="button1" OnClientClick="return funYZ();"
                                                            OnClick="Button_sumbit_Click" />
                                                        <asp:Button ID="Btn_Through" runat="server" Text="审核通过" CssClass="button1" OnClientClick="return funSHYJ();"
                                                            OnClick="Btn_Through_Click" />
                                                        <asp:Button ID="Btn_Unthread" runat="server" Text="审核不通过" CssClass="button1" OnClientClick="return funSHYJ();"
                                                            OnClick="Btn_Unthread_Click" Width="80px" />
                                                        <asp:Button ID="Btn_Done" runat="server" Text="报销完成" CssClass="button1" OnClientClick="return confirm('您确定要继续吗？');"
                                                            OnClick="Btn_Done_Click" />
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                        <asp:Button ID="Button_cancel" runat="server" Text="返回" CssClass="button1" OnClick="Button_cancel_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="50px">
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

    <script type="text/javascript">
        function funYZ()
        {
            var ValStr = "";
           
            if($("input[type=radio]:checked").val()=="0")
            {
                var TnF = funZJK();
                if(!TnF) return TnF;
            }
            //金额
            var RBList_RXZ = $("input[id*=RBList_RXZ]:checked").val();      //当前所选类型
            var ApplyCount;
            if(RBList_RXZ==0){   //按类型不同取不同的金额
                ApplyCount = $("[id*=Txt_ApplyCount1]").val();
                ValStr = $("input[id*=hide_Sum]").val();
            }
            else{
                ApplyCount = $("[id*=Txt_ApplyCount2]").val();
                var SpecialFundsID = $("select[id*=DDL_SpecialFundsID]").val();
                var AccountID = SpecialFundsID.substring(SpecialFundsID.indexOf("|")+1,SpecialFundsID.lastIndexOf("|"));
                ValStr = AccountID + "|" + ApplyCount;
            }
                
            if(isNaN(ApplyCount) || ApplyCount*1<=0){
                alert("请正确填写需要的金额！");
                return false;
            }
            var type = /^\d+(\.[0-9]{0,2})?$/gi;
            if(!type.test(ApplyCount))
            {
                alert("金额不能等于0！");
                return false;
            }
            //日期
            var PDRQ = PDNowTime();
            if(PDRQ<0)
            {
                alert("报销日期请提前两天预约，如超过下午三点请再顺延一天！");
                return false;
            }
            
            //判断当天限制金额
            var txtGetDateTime = $("input[id*=txtGetDateTime]").val();
            var B = Dianda.Web.Admin.personalProjectManage.OACashApply.add.ReturnAccount(ValStr ,txtGetDateTime, RBList_RXZ).value;
            if(!B){
                alert("申请金额已超过账户当天限制金额！");
                return false;
            }
            //备注
            var txtUseFor = $("textarea[id*=txtUseFor]").val();
            if(txtUseFor.indexOf("'")!=-1||txtUseFor.length>500)
            {
                alert(" 备注内容在0~500字符且不含“'”！");
                return false;
            }
           
            $("input[id*=Txt_ApplyCount1]").removeAttr("disabled");
            
            return true;
        }
        function funSHYJ()
        {
//            var txtAuditOpinion = $("textarea[id*=txtAuditOpinion]");
//            if(txtAuditOpinion.length==1)
//            {
//                var AuditOpinion = txtAuditOpinion.val();
//                if(AuditOpinion.indexOf("'")!=-1||AuditOpinion.length<1||AuditOpinion.length>500)
//                {
//                    alert(" 审核意见内容在1~500字符且不含“'”！");
//                    return false;
//                }
//            }
            
            return confirm('您确定要继续吗？');
        }
        function PDNowTime()
        {
            var txtGetDateTime = $("[id*=txtGetDateTime]").val();
            
            return Dianda.Web.Admin.personalProjectManage.OACashApply.add.ReturnDateOrder(txtGetDateTime).value;
        }
        //资金卡查询
        function funZJK()
        {
            var ErrNum = 0;
            var TnF = false;
            var ValStr = "", SumStr = "", CardListID = "", CardListName = "";
            var Sum = 0;
            var hide_AccountID = "",CardID = "", CardIDTemp = "", hide_AccountIDTemp = "";
            var Tol = 0;
            
            if($("input[id*=hide_CardID]").length <= 0)
            {
                alert("请添加资金卡！");
                return false;
            }
            
            var divTab = $("#divTab");
            var tab_Account = divTab.find("table[id*=tab_Account]");
            tab_Account.each(function(i){       //循环表
                var tabID = $(this).attr("id");
                var vTr = $(this).find("table[id*=tabCards]");
                vTr.each(function(j){           //循环内表
                    var CardName = $(this).attr("hideCarDName");
                    CardID = $(this).attr("hideCarD");
                    hide_AccountID = $(this).attr("hideAccount");
                    if(CardID != ""&& CardID != CardIDTemp){
                        if(ValStr==""){
                            ValStr = CardID;
                            CardListID = CardID;
                        }    
                        else{
                            ValStr += "," + CardID;
                            CardListID += "," + CardID;
                        }
                        if(CardListName == "")  //资金卡名称
                            CardListName += CardName;
                        else
                            CardListName += "," + CardName;
                        CardIDTemp = CardID;
                    }
                    if(hide_AccountID != hide_AccountIDTemp && hide_AccountIDTemp != ""){
                        if(SumStr=="")
                            SumStr = hide_AccountIDTemp+"|"+Tol;
                        else 
                            SumStr += "," + hide_AccountIDTemp+"|"+Tol;
                            
                        Tol = 0;
                    }
                    hide_AccountIDTemp = hide_AccountID;
                    
                    var vTR = $(this).find("tr");
                    vTR.each(function(k){   //循环行
                        if(k==1){
                            var vTD = $(this).find("td");
                            vTD.each(function(m){   //循环列
                                var InputTxt = $(this).find("input[type=text]");
                                if(InputTxt.length=="1"){
                                    TnF = funOnBlur(InputTxt.attr("id"));
                                    
                                    
                                    if(!TnF){
                                        InputTxt.select();
                                        ErrNum = j;
                                        return TnF;
                                    }
                                    else{
                                        var inputTxtVal = InputTxt.val().replace("—","");
                                        
                                        ValStr += inputTxtVal==""?":0":":"+inputTxtVal;
                                        Sum += inputTxtVal==""?0:inputTxtVal*1;
                                        Tol += inputTxtVal==""?0:inputTxtVal*1;
                                    }
                                }
                                else{
                                    if(k>0)
                                        ValStr += ":0";
                                }
                            });
                        }
                    });
                    
                    if(ErrNum>0){return TnF;}
                });
            });
            
            if(SumStr=="")
                SumStr = hide_AccountID+"|"+Tol;
            else 
                SumStr += "," + hide_AccountID+"|"+Tol;
                
            $("input[id*=Txt_ApplyCount1]").val(Sum);
            $("input[id*=hide_CardListID]").val(CardListID);
            $("input[id*=hide_CarDetails]").val(ValStr);
            $("input[id*=hide_Sum]").val(SumStr);
            $("input[id*=hide_CardName]").val(CardListName);
            
            return TnF;
        }
    </script>

</asp:Content>
