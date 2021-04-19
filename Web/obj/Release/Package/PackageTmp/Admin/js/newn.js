///////////////////////获取天气信息
var id = "101020100";
var visitor = new Cookie(document, "cityid", 43800, "/", "m.weather.com.cn", "/");
visitor.load();
var std = "";
var url = window.location.href;
var start = url.indexOf("id");
var end = url.indexOf("T");

if (start != -1) {
    var first = start + parseInt(3);
    call = url.substring(first, end);
    res(call);
} else {
    if (!visitor.idinfo || !visitor.date) {
        var js = document.createElement("script");
        js.setAttribute("type", "text/javascript");
        if (typeof (id_callback) != "undefined") { id_callback(); }
        document.body.insertBefore(js, null);
        function id_callback() {
            std = id;
            visitor.idinfo = std;
            visitor.date = "5";
            visitor.store();
            res(std);
        }
    } else {
        std = visitor.idinfo;
        res(std);
    }
    if (typeof (id) == "undefined") {
        var id = "101020100";
        res(id);
    } else {
        std = visitor.idinfo;
        res(std);
    }
}
function res(id) {
    if (id == "") {
        if (document.getElementById("weather1") != null) {
            document.getElementById("weather1").innerHTML = "天气信息加载失败！";
        }
    } else {
        var datetime = "http://m.weather.com.cn/data/" + id + '.html';
    }
    var xmlhttp = null;
    function createXMLHTTPRequext() {
        if (window.XMLHttpRequest) {
            xmlhttp = new XMLHttpRequest(); //Mozilla
        } else if (window.ActiveXObject) {
            xmlhttp = new ActiveXObject("Msxml2.XMLHTTP");
            if (!xmlhttp) {
                xmlhttp = new ActiveXObject('Microsoft.XMLHTTP');
            }
        }
    }
    var jsonobj;
    function HandleStateChange() {
        if (xmlhttp.readyState == 4) {
            var jsontext = xmlhttp.responseText;
            var func = new Function("return " + jsontext);
            jsonobj = func();
        }
    }
    function PostOrder(xmldoc) {
        createXMLHTTPRequext();
        xmlhttp.open("GET", xmldoc, false);
        xmlhttp.onreadystatechange = HandleStateChange;
        xmlhttp.send(null);
    }
    var xmlhttp;
    PostOrder(datetime);
    HandleStateChange();
    var cityinfo1 = jsonobj.weatherinfo.weather1;
    var temp1 = jsonobj.weatherinfo.temp1;

   
   
    if (document.getElementById("weather1") != null) {
        if (cityinfo1.length > 8) {
            document.getElementById("weather1").innerHTML = cityinfo1.substr(0, 7) + '...';
            document.getElementById("weather1").title = cityinfo1;
        } else {
            var regu1 = "^(多云)";
            var re1 = new RegExp(regu1);
            var regu2 = "^(暴雪)";
            var re2 = new RegExp(regu2);
            var regu3 = "^(暴雨)";
            var re3 = new RegExp(regu3);
            var regu4 = "^(大雪)";
            var re4 = new RegExp(regu4);
            var regu5 = "^(大雨)";
            var re5 = new RegExp(regu5);
            var regu6 = "^(雷阵雨)";
            var re6 = new RegExp(regu6);
            var regu7 = "^(晴)";
            var re7 = new RegExp(regu7);
            var regu8 = "^(小雪)";
            var re8 = new RegExp(regu8);
            var regu9 = "^(小雨)";
            var re9 = new RegExp(regu9);
            var regu10 = "^(阴)";
            var re10 = new RegExp(regu10);
            var regu11 = "^(雨夹雪)";
            var re11 = new RegExp(regu11);
            var regu12 = "^(阵雨)";
            var re12 = new RegExp(regu12);
            var regu13 = "^(中雪)";
            var re13 = new RegExp(regu13);
            var regu14 = "^(中雨)";
            var re14 = new RegExp(regu14);
            if (cityinfo1.search(re1) != -1)
                document.getElementById("weather1").innerHTML = "<img src='/Admin/images/OAimages/duoyun.png'>";
            if (cityinfo1.search(re2) != -1)
                document.getElementById("weather1").innerHTML = "<img src='/Admin/images/OAimages/baoxue.png'>";
            if (cityinfo1.search(re3) != -1)
                document.getElementById("weather1").innerHTML = "<img src='/Admin/images/OAimages/baoyu.png'>";
            if (cityinfo1.search(re4) != -1)
                document.getElementById("weather1").innerHTML = "<img src='/Admin/images/OAimages/daxue.png'>";
            if (cityinfo1.search(re5) != -1)
                document.getElementById("weather1").innerHTML = "<img src='/Admin/images/OAimages/dayu.png'>";
            if (cityinfo1.search(re6) != -1)
                document.getElementById("weather1").innerHTML = "<img src='/Admin/images/OAimages/leizhenyu.png'>";
            if (cityinfo1.search(re7) != -1)
                document.getElementById("weather1").innerHTML = "<img src='/Admin/images/OAimages/qing.png'>";
            if (cityinfo1.search(re8) != -1)
                document.getElementById("weather1").innerHTML = "<img src='/Admin/images/OAimages/xiaoxue.png'>";
            if (cityinfo1.search(re9) != -1)
                document.getElementById("weather1").innerHTML = "<img src='/Admin/images/OAimages/xiaoyu.png'>";
            if (cityinfo1.search(re10) != -1)
                document.getElementById("weather1").innerHTML = "<img src='/Admin/images/OAimages/yin.png'>";
            if (cityinfo1.search(re11) != -1)
                document.getElementById("weather1").innerHTML = "<img src='/Admin/images/OAimages/yujiaxue.png'>";
            if (cityinfo1.search(re12) != -1)
                document.getElementById("weather1").innerHTML = "<img src='/Admin/images/OAimages/zhenyu.png'>";
            if (cityinfo1.search(re13) != -1)
                document.getElementById("weather1").innerHTML = "<img src='/Admin/images/OAimages/zhongxue.png'>";
            if (cityinfo1.search(re14) != -1)
                document.getElementById("weather1").innerHTML = "<img src='/Admin/images/OAimages/zhongyu.png'>";
        }
    }
    if (document.getElementById("temp1") != null) {
        document.getElementById("temp1").innerHTML = temp1;
    }
}

