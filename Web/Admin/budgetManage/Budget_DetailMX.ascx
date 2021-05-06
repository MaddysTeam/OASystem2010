<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Budget_DetailMX.ascx.cs"
    Inherits="Dianda.Web.Admin.budgetManage.Budget_DetailMX" %>
<table border="0" cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td>
            项目经费预算明细：&nbsp;&nbsp;<input type="button" id="btn_create" value="+" class="" onclick="AddRow()" />&nbsp;&nbsp;<label
                style="color: Red;">明细名称最多填写八个字</label>
            <asp:HiddenField ID="hideID" runat="server" />
            <asp:HiddenField ID="hideDelDetailID" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <table id="tabDetailList" border="0" cellpadding="0" cellspacing="0">
            </table>
        </td>
    </tr>
    <tr style="height:30px;">
        <td align="left">
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        预算金额：<asp:TextBox ID="TB_Balance" runat="server" CssClass="textbox_name" Height="16px"
                            Enabled="false" Width="60px" Text="0"></asp:TextBox>
                        元
                    </td>
                    <td width="15">
                    </td>
                   <%-- <td runat="server" id="td_LimitNums">
                        可用金额：<asp:TextBox ID="TB_LimitNums" runat="server" AutoPostBack="true" CssClass="textbox_name"
                            Height="16px" Width="60px" Text="0"
                            ></asp:TextBox>
                        元
                    </td>--%>
                </tr>
            </table>
        </td>
    </tr>
</table>

<script type="text/javascript">
var RowsNum = 0;
//加载完成时运行的代码
$(document).ready(function(){
	Show();
});

function Show()
{
    var hideID = $("input[id*=hideID]");
    if(hideID.val() != "")
    {  
    	var Frist_dt = Dianda.Web.Admin.budgetManage.Budget_DetailMX.First_Read(hideID.val()).value;
        
        if(Frist_dt!=null)
        {
            var tabDetailList = document.getElementById("tabDetailList");
            if(Frist_dt != null)
            {
                for(var i=0;i<Frist_dt.Rows.length;i++)
                {
                    RowsNum = i;
                    CreateRow(tabDetailList,Frist_dt.Rows[i]);
                }
            }
            sumTotle();
        }
    }
    else {
    	for (var i = 0; i < 6; i++) {
    		AddRow();
    	}
    }
}

//删除行
function DelRow(s)
{
    //被选中的行
    if(confirm("确认删除该明细?"))
    {
        if(s.id!=""){
            var hideDelDetailID = $("input[id*=hideDelDetailID]");
            hideDelDetailID.val(hideDelDetailID.val()==""?s.id:hideDelDetailID.val()+","+s.id);
        }
        $(s).parent().parent().remove();
        sumTotle();
    }

}
//添加行
function AddRow()
{
    var tabDetailList = document.getElementById("tabDetailList");
    RowsNum++;
    CreateRow(tabDetailList);
}

function CreateRow(obj,drows)
{
    var DetailName="",balance="0",Unit="1",typename="现金",ID="",KYbalance="0";
    if(typeof(drows)!="undefined")
    {
        ID = typeof(drows["ID"])!= "undefined" ? drows["ID"] : "";
        DetailName = typeof(drows["DetailName"]) != "undefined" ? drows["DetailName"] : "";
        balance = typeof(drows["Balance"]) != "undefined" ? drows["Balance"] : "0";
        Unit = typeof(drows["Unit"]) != "undefined" ? drows["Unit"] : "1";
        balance = balance / Unit;
        typename = typeof(drows["TypesName"]) != "undefined" ? drows["TypesName"] : "现金";
        KYbalance = typeof(drows["KYbalance"]) != "undefined" ? drows["KYbalance"] : "0";
    }
    
    var newTr = obj.insertRow();
    newTr.style.textAlign="center";
    newTr.style.height="28px";
	//    newTr.id=l[0];

    switch (RowsNum) {
    	case 1: DetailName = '劳务费'; break;
    	case 2: DetailName = '会务费'; break;
    	case 3: DetailName = '差旅费'; break;
    	case 4: DetailName = '业务委托费'; break;
    	case 5: DetailName = '政府采购'; break;
    	case 6: DetailName = '出版印刷费'; break;
    	case 7: DetailName = '其他经费'; break;
    }
    
    for(var j=0;j<7;j++)
    {
        var newTd = newTr.insertCell();
        var str = "";
        switch(j)
        {
            case 0: newTd.innerHTML = "<input type='text' style='width:80px;' id='DetailName_"+RowsNum+"' name='DetailName' maxlength='8' value='"+DetailName+"' onchange='sumTotle()' />";break;
            case 1: newTd.innerHTML = "&nbsp;<input type='text' style='width:40px;' id='balance_"+RowsNum+"' name='balance' maxlength='8' value='"+balance+"' onkeyup='event.returnValue=isDigit(this);' />";break;
            case 2: 
                str = "&nbsp;<select id='Unit_"+RowsNum+"' name='Unit' onchange='sumTotle()'>"
                str += "<option value='1' "+ (Unit == "1" ? "selected='selected'" :"") + " >元</option>"
                str += "<option value='10000'"+ (Unit == "10000" ? "selected='selected'" :"") + "  >万元</option></select>";
                newTd.innerHTML = str;
                break;
            //case 3: 
            //     str = "&nbsp;<input type='radio' id='typename1_"+RowsNum+"' name='typename"+RowsNum+"' value='现金' "+ (typename == "现金" ? "checked='checked'" :"") + " />现金"
            //     str += "&nbsp;<input type='radio' id='typename1_"+RowsNum+"2' name='typename"+RowsNum+"' value='公务卡' "+ (typename == "公务卡" ? "checked='checked'" :"") + " />公务卡";
            //    newTd.innerHTML =str;
            //    break;
            case 4: newTd.innerHTML = "&nbsp;<input type='button' id='"+ID+"' value='-' onclick='DelRow(this)' />";break;
            case 5: newTd.innerHTML = "&nbsp;<label id='bili_"+RowsNum+"'></label>"; break;
            case 6: 
            	newTd.innerHTML = "&nbsp;<input type='hidden' id='BudgetsDetail_" + RowsNum + "' name='BudgetsDetail' value='" + ID + "' /><input type='hidden' id='RowsNum_" + RowsNum + "' name='RowsNum' value='" + RowsNum + "' /><input type='hidden' id='KYbalance_" + RowsNum + "' name='KYbalance' value='" + KYbalance + "' />"; break;
        }
    }
}
function sumTotle(s)
{
    if(typeof(s) != "undefined"){
        if(isNaN(s.value)){
            alert("请正确填写数字！");
            s.select();
        }
    }
    var DetailName = $("input[id*=DetailName]");
    var Totle = 0;
    DetailName.each(function(i){
        if($(this).val()!="")
        {
            var DetailName_ID = $(this).attr("id");
            var str = DetailName_ID.split("_");
            var balanceval = $("input[id*=balance_"+str[1]+"]").val();
            var Unit = $("select[id*=Unit_"+str[1]+"]").val();
            
            if(!isNaN(balanceval))
                Totle += (balanceval*1*Unit);
        }
    });
    
    var hideID = $("input[id*=hideID]");
    if(hideID.val() == "")
        $("input[id*=TB_Balance]").val(Totle);
    $("input[id*=TB_LimitNums]").val(Totle);
    
    DetailName.each(function(i){
        var DetailName_ID = $(this).attr("id");
        var str = DetailName_ID.split("_");
        var bili = $("label[id*=bili_"+str[1]+"]");
        var balanceval = $("input[id*=balance_"+str[1]+"]").val();
        if($(this).val()!="" && balanceval!="0")
        {
            var Unit = $("select[id*=Unit_"+str[1]+"]").val();
            
            var bfb = 0;
            if(Totle!=0)
                bfb = Math.round((balanceval*1*Unit)/Totle*10000)/100;

            if(bfb==0 && balanceval!= "0" )
                bili.html("<.01%");
            else
                bili.html(bfb+"%");
            
        }
        else{
            bili.html("");
        }
    });
}
function setSchoolRate()
{
    var Totle = $("input[id*=TB_LimitNums]").val();
    var bili = $("label[id*=bili]");
    bili.each(function(){
        if($(this).html()!=""||$(this).html()!="0%")
        {
            var bili_ID = $(this).attr("id");
            var bfb = $(this).html().replace("%","");
            var str = bili_ID.split("_");
            var Unit = $("select[id*=Unit_"+str[1]+"]").val();
            var balanceval = $("input[id*=balance_"+str[1]+"]");
            var t = 0;
            t = Math.round(bfb*Totle/100/Unit);
            
            balanceval.val(t);
        }
    });
}

var regexDec = /^\d(\.(\d))?$/;

function isDigit(s) {
//    return s.value=s.value.replace(/\D/g,'');
    var bIs = ((event.keyCode >= 48) && (event.keyCode <= 57)||(event.keyCode >= 96) && (event.keyCode <= 105)||event.keyCode==46||event.keyCode==110||event.keyCode==8);
    if(bIs)
    {
        sumTotle(s);
        if(s.value == '')
        {
            s.value = '0';
        }
    }
    else
    {
        if (!regexDec.test(s.value)) {
           s.value = '0';
        }
    }
    return bIs;
}   
</script>

