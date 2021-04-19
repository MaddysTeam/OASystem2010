<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="projectTask.ascx.cs"
    Inherits="Dianda.Web.Admin.sysTongji.ascxModel.projectTask" %>
   <script type="text/javascript"> 
function enableTooltips(id){ 
var links,i,h; 
if(!document.getElementById || !document.getElementsByTagName) return; 
h=document.createElement("span"); 
h.id="btc"; 
h.setAttribute("id","btc"); 
h.style.position="absolute"; 
document.getElementsByTagName("body")[0].appendChild(h); 
if(id==null) links=document.getElementsByTagName("a"); 
else links=document.getElementById(id).getElementsByTagName("a"); 
for(i=0;i<links.length;i++){ 
Prepare(links[i]); 
} 
} 
function Prepare(el){ 
var tooltip,t,b,s,l; 
t=el.getAttribute("message"); 
if(t==null || t.length==0) return ; 
el.removeAttribute("message"); 
tooltip=CreateEl("span","tooltip"); 
s=CreateEl("span","top"); 
//s.appendChild(document.createTextNode(t)); 改动 
s.innerHTML = t; 
tooltip.appendChild(s); 
//b=CreateEl("b","bottom"); 
l=el.getAttribute("href"); 
if(l.length>30) l=l.substr(0,27)+"..."; 
//b.appendChild(document.createTextNode(l)); 
//tooltip.appendChild(b); 
setOpacity(tooltip); 
el.tooltip=tooltip; 
el.onmouseover=showTooltip; 
el.onmouseout=hideTooltip; 
el.onmousemove=Locate; 
} 
function showTooltip(e){ 
document.getElementById("btc").appendChild(this.tooltip); 
Locate(e); 
} 
function hideTooltip(e){ 
var d=document.getElementById("btc"); 
if(d.childNodes.length>0) d.removeChild(d.firstChild); 
} 
function setOpacity(el){ 
el.style.filter="alpha(opacity:95)"; 
el.style.KHTMLOpacity="0.95"; 
el.style.MozOpacity="0.95"; 
el.style.opacity="0.95"; 
} 
function CreateEl(t,c){ 
var x=document.createElement(t); 
x.className=c; 
x.style.display="block"; 
return(x); 
} 
function Locate(e){ 
var posx=0,posy=0; 
if(e==null) e=window.event; 
if(e.pageX || e.pageY){ 
posx=e.pageX; posy=e.pageY; 
} 
else if(e.clientX || e.clientY){ 
if(document.documentElement.scrollTop){ 
posx=e.clientX+document.documentElement.scrollLeft; 
posy=e.clientY+document.documentElement.scrollTop; 
} 
else{ 
posx=e.clientX+document.body.scrollLeft; 
posy=e.clientY+document.body.scrollTop; 
} 
} 
document.getElementById("btc").style.top=(posy+10)+"px"; 
document.getElementById("btc").style.left=(posx-20)+"px"; 
} 
</script> 
<script type="text/javascript"> 
window.onload=function(){enableTooltips()}; 
</script> 
<style type="text/css"> 
p{margin: 0 0 1.7em} 
.tooltip{ 
width: 200px; color:#000; 
font:lighter 11px/1.3 Arial,sans-serif; 
text-decoration:none;text-align:left} 
.tooltip{ 
width: 200px; color:#fff; 
font:lighter 11px/1.3 Arial,sans-serif; 
text-decoration:none;text-align:left} 
.tooltip span.top{ 
text-align:left; 
text-indent:1em; 
padding: 10px 8px; 
background-color:#0083c9;
} 
.tooltip b.bottom{padding:3px 8px 10px;color: #548912; 
 background-color:#f0f0f0;
} 
</style> 
    <br />
                        <table cellpadding="10" cellspacing="1" bgcolor="99cccd"  width="100%">
                        <tr>
                        <td bgcolor="#f0f0f0" height="40px" align=left>
                            <asp:Label ID="Label_tongji" runat="server" Text=""></asp:Label>
                        </td>
                        </tr>
                        </table>
                        <br />
<table align="center" cellpadding="1" cellspacing="1" width="100%">
    <tr>
        <td valign="top" align="center">
            <asp:GridView ID="GridView1" AutoGenerateColumns="False" runat="server" Width="100%"
                OnRowDataBound="GridView1_RowDataBound" CssClass="GridView1">
                <Columns>
                    <asp:TemplateField HeaderText="序号">
                        <ItemTemplate>
                            <%# (Container.DataItemIndex + 1)%>
                        </ItemTemplate>
                        <HeaderStyle CssClass="HeaderStyle1" HorizontalAlign="Center" />
                        <ItemStyle CssClass="ItemStyle1" HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="标题">
                        <ItemTemplate>
                               <a href="#"  message="任务描述:<br/><%#Eval("Overviews").ToString()%>"> <%#Eval("NAMES").ToString()%></a>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="开始日期" DataField="StartTime" DataFormatString="{0:yyyy-MM-dd}">
                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="结束日期" DataField="EndTime" DataFormatString="{0:yyyy-MM-dd}">
                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="状态" DataField="Status">
                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="人员">
                        <ItemTemplate>
                           <a href="#"  message="参与人员列表:<br/><%#Eval("UserInfo").ToString()%>">详细</a>
                        </ItemTemplate>
                        <HeaderStyle CssClass="HeaderStyle1" HorizontalAlign="Center" />
                        <ItemStyle CssClass="ItemStyle1" HorizontalAlign="Center" />
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="其他">
                        <ItemTemplate>
                          <%#Eval("IsFather").ToString()=="1"?"父任务":""%> <%#Eval("CompleteType").ToString() == "1" ? "上传文档" : ""%>
                        </ItemTemplate>
                        <HeaderStyle CssClass="HeaderStyle1" HorizontalAlign="Center" />
                        <ItemStyle CssClass="ItemStyle1" HorizontalAlign="Center"/>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Label ID="notice" runat="server" Text="" ForeColor="Red"></asp:Label>
        </td>
    </tr>
</table>
