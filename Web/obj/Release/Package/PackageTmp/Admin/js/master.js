var flag = 0;
var menuUrlArr = new Array();
menuUrlArr[0] = "td_menu1$$"

var curStatus = "show";

function chag_bg(p) {
    if (document.getElementById("form" + p + "_tr").style.background == "url(/Admin/images/OAimages/leftsideBar_bg.jpg)") {
        document.getElementById("form" + p + "_tr").style.background = "url(/Admin/images/OAimages/leftsideBar.jpg)";
    }
    }
        function rest_bg(p) {       
                document.getElementById("form" + p + "_tr").style.background = "url(/Admin/images/OAimages/leftsideBar_bg.jpg)";
            }
            function chag_bg2(p) {
                if (document.getElementById("menu" + p + "_tr").style.background == "url(/Admin/images/OAimages/lan.jpg)") {
                    document.getElementById("menu" + p + "_tr").style.background = "url(/Admin/images/OAimages/hui.jpg)";
                    document.getElementById("master_b" + p).style.color = "Black";
                }
            }
            function rest_bg2(p) {
                document.getElementById("menu" + p + "_tr").style.background = "url(/Admin/images/OAimages/lan.jpg)";
                document.getElementById("master_b" + p).style.color = "White";
            }
            
            
            function chag_bg3(p) {
                if (p == 1) {
                    document.getElementById("ger_main").src = "/Admin/images/OAimages/home1_over.gif";
                }
            }
            function rest_bg3(p) {
                if (p == 1) {
                    document.getElementById("ger_main").src = "/Admin/images/OAimages/home1.gif";
                }
            }
            function chag_bg4(p) {
                if (p == 1) {
                    document.getElementById("bum_main").src = "/Admin/images/OAimages/home2_over.gif";
                }
            }
            function rest_bg4(p) {
                if (p == 1) {
                    document.getElementById("bum_main").src = "/Admin/images/OAimages/home2.gif";
                }
            }            
            
           
            
            
         ////////////////////��ʾ���������ؼ�
            function show() {
                if (document.getElementById("canlender_rili").style.display == "none") {                    
                    document.getElementById("canlender_rili").style.display = "block";
                    document.getElementById("showrili").src = "/Admin/images/OAimages/rstyle2_over.jpg";
                    document.getElementById("hiderili").src = "/Admin/images/OAimages/rstyle1.jpg";
                    if (document.getElementById("div_scroll1") != null) {
                        document.getElementById("div_scroll1").style.height = "127px";
                    }
                    if (document.getElementById("div_scroll2") != null) {
                        document.getElementById("div_scroll2").style.height = "127px";
                    }
                    document.getElementById("monthTbl").style.display = "none";

                    curStatus = "show";
                }
            }
            function hide() {
                if (document.getElementById("canlender_rili").style.display == "block") {
                    document.getElementById("canlender_rili").style.display = "none";
                    document.getElementById("hiderili").src = "/Admin/images/OAimages/rstyle1_over.jpg";
                    document.getElementById("showrili").src = "/Admin/images/OAimages/rstyle2.jpg";
                    if (document.getElementById("div_scroll1") != null) {
                        document.getElementById("div_scroll1").style.height = "270px";
                    }
                    if (document.getElementById("div_scroll2") != null) {
                        document.getElementById("div_scroll2").style.height = "270px";
                    }
                    document.getElementById("monthTbl").style.display = "block";

                    curStatus = "hide";
                }
            }

            function initStatus() {
                if (curStatus == "show") {
                    show();
                }
                else if (curStatus == "hide") {
                    hide();
                }
            }
         
         


//////////////////////////////////////////////////
         var menuArr = new Array();
         var menuNum;
         var path = "";
         function showObj(tarObjArr) {             
             var i;
             for (i = 0; i < tarObjArr.length; i++) {
                 var ctlObj = eval(tarObjArr[i]);
                 
                 if (ctlObj.nodeName.toUpperCase() == "DIV" || ctlObj.nodeName.toUpperCase() == "SPAN") {
                     ctlObj.style.visibility = "visible";
                 }
                 else {
                     ctlObj.style.display = "block";
                 }
             }
         }
         function hideObj(tarObjArr) {
             var i;
             for (i = 0; i < tarObjArr.length; i++) {
                 var ctlObj = eval(tarObjArr[i]);
                 if (ctlObj.nodeName.toUpperCase() == "DIV" || ctlObj.nodeName.toUpperCase() == "SPAN") {
                     ctlObj.style.visibility = "hidden";
                 }
                 else {
                     ctlObj.style.display = "none";
                 }
             }
         }

         function openChildMenu(menuChildId) {             
             var mm = "td_" + menuChildId;
                       
             if (flag != mm) {
                 document.getElementById("td_" + menuChildId).style.background = "url('/Admin/images/OAimages/nan_lbg.gif')";
             }
             if (document.getElementById(menuChildId) != null) {
                 showObj(new Array(menuChildId));
             }
             
         }

         function closeChildMenu(menuChildId) {
             var mm = "td_" + menuChildId;
             if (flag != mm) {
                 document.getElementById("td_" + menuChildId).style.background = "";
             }
             if (document.getElementById(menuChildId) != null) {
                 hideObj(new Array(menuChildId));
             }
             
         }

         /*function initChildMenu(caseId, linkPos) {
             var i, j;
             var menuName;
             var menuId;
             var innStr = "";
             var menuChildName, menuChildLink;

             getMenuInfo(caseId);
             for (i = 1; i <= menuNum; i++) {
                 menuId = "menu" + i;
                 innStr = "";
                 if (document.getElementById(menuId) != null) {
                     menuName = document.getElementById(menuId).innerHTML;
                 }

                 innStr += "<table width=\"100%\" height=\"100%\"  border=\"0\" cellpadding=\"0\" cellspacing=\"0\">";
                 innStr += "<tr><td align=\"center\">" + menuName + "</td></tr>";
                 innStr += "<tr><td height=\"0\" align=\"left\" valign=\"top\">";
                 if (menuArr[menuId].length > 0) {
                     innStr += "<div id=\"" + menuId + "_child\" style=\"visibility:hidden; position:absolute; width:120px; z-index:2;\">";
                     innStr += "<table width=\"100%\"  border=\"0\" cellspacing=\"0\" cellpadding=\"0\">";
                     for (j = 0; j < menuArr[menuId].length; j++) {
                         menuChildName = menuArr[menuId][j].split("$$")[0];
                         menuChildLink = menuArr[menuId][j].split("$$")[1];
                         if (menuChildLink != "#") {
                             menuChildLink = path + menuChildLink;
                         }
                         if (linkPos == "this" || menuChildLink == "#") {
                             innStr += "<tr><td height=\"18\" align=\"center\" style=\"background:url(/Admin/images/OAimages/nav_sub.jpg)\"><a href=\"" + menuChildLink + "\" target=\"_self\" class=\"mchild_a\">" + menuChildName + "</a></td></tr>"
                         }
                         else if (linkPos == "parent") {
                         innStr += "<tr><td height=\"18\" align=\"center\" style=\"background:url(/Admin/images/OAimages/nav_sub.jpg);\"><a href=\"javascript:parent.location.href='" + menuChildLink + "';\" class=\"mchild_a\">" + menuChildName + "</a></td></tr>"
                         }
                     }
                     innStr += "</table>";
                     innStr += "</div>";
                 }
                 innStr += "</td></tr>";
                 innStr += "</table>";

                 document.getElementById(menuId).innerHTML = innStr;
             }
         }

         function getMenuInfo(caseId) {
             if (caseId = "case1") {
                 menuNum = 6;
                 path = "../";

                 menuArr["menu1"] = new Array();
                 menuArr["menu2"] = new Array();
                 menuArr["menu3"] = new Array();
                 menuArr["menu4"] = new Array();
                 menuArr["menu5"] = new Array();
                 menuArr["menu6"] = new Array();

                 menuArr["menu1"].push("�ҵ���Ŀ$$project/Default_list.htm");
                 menuArr["menu1"].push("��������$$operation/addProject.htm");
                 menuArr["menu1"].push("����ݸ���$$operation/addProjectDraft.htm");

                 menuArr["menu4"].push("֪ͨ����$$news/newsList.htm");
                 menuArr["menu4"].push("վ����Ϣ$$news/talkList.htm");

                 menuArr["menu5"].push("����ԤԼ$$fee/feeBook.htm");
                 menuArr["menu5"].push("�ʽ𿨲�ѯ$$fee/feeBook_search.htm");

                 menuArr["menu6"].push("���¹���$$operation/hr.htm");
                 menuArr["menu6"].push("�������$$operation/fina.htm");
                 menuArr["menu6"].push("��Ϣ����$$operation/info.htm");
                 menuArr["menu6"].push("��Ŀ����$$operation/project.htm");
                 menuArr["menu6"].push("��������$$verify/Default_LUNCH.htm");
                 menuArr["menu6"].push("��������$$verify/Default_CAR.htm");
                 menuArr["menu6"].push("�����ҹ���$$verify/Default_MEET.htm");
                 menuArr["menu6"].push("��ӡ����$$verify/Default_SIGNET.htm");
             }
         }
         function m_menu() {
             initChildMenu("case1","this");
          }*/




         /////////////////////////////����
         
         /*function get_time() {
             var week;
             var year = new Date().getYear();
             var month = new Date().getMonth() + 1;
             var date = new Date().getDate();
             var hour = new Date().getHours();
             var minute = new Date().getMinutes();
             var daysInMonth = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];
             if (new Date().getDay() == 0) week = "������"
             if (new Date().getDay() == 1) week = "����һ"
             if (new Date().getDay() == 2) week = "���ڶ�"
             if (new Date().getDay() == 3) week = "������"
             if (new Date().getDay() == 4) week = "������"
             if (new Date().getDay() == 5) week = "������"
             if (new Date().getDay() == 6) week = "������"

             if (((year % 4 == 0) && (year % 100 != 0)) || (year % 400 == 0)) { daysInMonth[1] = 29; }
             var now1 = new Date(); var month1 = now1.getMonth(), year1 = now1.getFullYear(), days1 = now1.getDate(); for (var i = 0; i < month1; i++) { days1 += daysInMonth[i]; } var firstDay1 = new Date(year1, 0, 1).getDay(); if (firstDay1 == 0) firstDay1 = 7; week1 = Math.ceil((days1 - (firstDay1 != 1 ? 7 - firstDay1 + 1 : 0)) / 7) + (firstDay1 != 1 ? 1 : 0);
             //document.getElementById("menu_time").innerHTML = year + "��" + month + "��" + date + "�� " + week + " ��" + week1 + "��";

         }*/




//////////////////pngͼƬ����͸��
         /*function correctPNG() {
             for (var i = 0; i < document.images.length; i++) {
                 var img = document.images[i]
                 var imgName = img.src.toUpperCase()
                 if (imgName.substring(imgName.length - 3, imgName.length) == "PNG") {
                     var imgID = (img.id) ? "id='" + img.id + "' " : ""
                     var imgClass = (img.className) ? "class='" + img.className + "' " : ""
                     var imgTitle = (img.title) ? "title='" + img.title + "' " : "title='" + img.alt + "' "
                     var imgStyle = "display:inline-block;" + img.style.cssText
                     if (img.align == "left") imgStyle = "float:left;" + imgStyle
                     if (img.align == "right") imgStyle = "float:right;" + imgStyle
                     if (img.parentElement.href) imgStyle = "cursor:hand;" + imgStyle
                     var strNewHTML = "<span " + imgID + imgClass + imgTitle
   + " style=\"" + "width:" + img.width + "px; height:" + img.height + "px;" + imgStyle + ";"
   + "filter:progid:DXImageTransform.Microsoft.AlphaImageLoader"
   + "(src=\'" + img.src + "\', sizingMethod='scale');\"></span>"
                     img.outerHTML = strNewHTML
                     i = i - 1
                 }
             }
             setTimeout(correctPNG,60000);

         }*/




         //////////////////////�˵��۽�״̬
        
         
         
         
         

         function initmenu() {

             //highURL("td_menu1");
             //highURL("td_menu2");
             //highURL("td_menu3");
             //highURL("td_menu4");
             //highURL("td_menu5");
             //highURL("td_menu6");
             highURL_top("a_germain");
             highURL_top("a_bummain");
             

         }
         function highURL(menuId) {
             //if (!document.getElementById) return false;
             //if (!document.getElementById(menuId)) return false;
             //if (!document.getElementsByTagName) return false;
             var links = document.getElementById(menuId);
             //alert(links.href);
             //for (var i = 0; i < links.length; i++) {
                 //alert(links.length);
             if (links != null) {

                 var menuLink = links.href;
                 //alert(menuLink);
                 var currentLink = window.location.href;
                 //alert(menuLink);
                 //alert(currentLink);
                 if (currentLink.indexOf(menuLink) != -1) {
                     document.getElementById(menuId + "_child").style.background = "url('/Admin/images/OAimages/nan_lbg.gif')";
                     flag = menuId + "_child";
                 }
             }
             //}
         }
             function highURL_top(menuId) {
                 var links = document.getElementById(menuId);


                 var currentLink = window.location.href;
                 
                 if (links != null) {
                     var menuLink = links.href;
                     
                     if (currentLink.indexOf(menuLink) != -1) {
                         
                     if (menuId == "a_germain") {
                     document.getElementById(menuId).innerHTML = "<img src='/Admin/images/OAimages/home1_over.gif' id='ger_main'>";
                     }
                     else if (menuId == "a_bummain") {
                     document.getElementById(menuId).innerHTML = "<img src='/Admin/images/OAimages/home2_over.gif' id='bum_main'>";
                     }
                     }
                 }
             }


             function tie() {
                 var current = window.location.href;
                 
                 if (document.getElementById("a_germain") != null) {
                     var menuk1 = document.getElementById("a_germain").href;
                     var menuk2 = document.getElementById("a_bummain").href;

                     if (current.indexOf(menuk1) != -1 || current.indexOf(menuk2) != -1) {
                     document.getElementById("right_frame").style.display = "none";
                     document.getElementById("right_f_main").style.display = "block";
                     }
                 }
             }
         
         


//////////////////////��ȡ��ҳ�߶�
         /*function getInfo() {
             //var s = document.body.clientHeight;
             var s = window.screen.height;
             //alert(s);
             s -= 450;
             document.getElementById("main_tab").style.height = s;
         }*/

         if (navigator.userAgent.indexOf("MSIE") > -1) {
             //window.attachEvent("onload", correctPNG);
             //window.attachEvent("onload", m_menu);
             //window.attachEvent("onload", get_time);
             //window.attachEvent("onload", getInfo);
             window.attachEvent("onload", initmenu);
             window.attachEvent("onload", tie);
             
         }




         

         

