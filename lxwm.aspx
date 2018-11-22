<%@ Page Language="C#" AutoEventWireup="true" CodeFile="lxwm.aspx.cs" Inherits="lxwm" %>

<%@ Register Src="~/include/header.ascx" TagPrefix="uc1" TagName="header" %>
<%@ Register Src="~/include/footer.ascx" TagPrefix="uc1" TagName="footer" %>
<%@ Register Src="~/include/menu.ascx" TagPrefix="uc1" TagName="menu" %>




<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<uc1:header runat="server" id="header" />
    <link href="css/cgpj.css" rel="stylesheet" >
    <style type="text/css">
        html,body{margin:0;padding:0;}
        .iw_poi_title {color:#CC5522;font-size:14px;font-weight:bold;overflow:hidden;padding-right:13px;white-space:nowrap}
        .iw_poi_content {font:12px arial,sans-serif;overflow:visible;padding-top:4px;white-space:-moz-pre-wrap;word-wrap:break-word}
    </style>
    <%--<script type="text/javascript" src="http://api.map.baidu.com/api?key=&v=1.1&services=true"></script>--%>

    <script type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=148ba719517de5b636685962d779d367"></script>
<body>
    <uc1:menu runat="server" ID="menu" />
<!--内容-->
<!--con-->
<div class="cgpj-con">
    <div class="con-left">
       <%=leftmenu %>
        <div class="con-nav-img">
        	<a href="zxsq.aspx?class=0&fl=5">
            	<img src="images/shenqing.png" width="280">
            	<div class="con-nav-img-c">科技评价在线申请</div>
            </a>
        </div>
    </div>

    <div class="conn">
        <div class="conn-top">
            <div class="conn-top-title1">联系我们</div>
            <div class="conn-top-title2">&nbsp;联系我们</div>
            <div class="conn-top-title3">您当前的位置：&nbsp;></div>
        </div>
         <div class="conh-con">
            <div class="conh-con-c">
                <div class="gywm_l">
                    <div class="gywm_lt">联系地址 </div>
                    <div class="gywm_lb">: 北京市石景山区鲁谷路35号</div>
                </div>
                <div class="gywm_l">
                    <div class="gywm_lt1">联系人</div>
                    <div class="gywm_lb">: 卢主任</div>
                </div>
                <div class="gywm_l">
                    <div class="gywm_lt">联系电话</div>
                    <div class="gywm_lb">: 010－88686232</div>
                </div>
                <div class="gywm_l">
                    <div class="gywm_lt">联系手机</div>
                    <div class="gywm_lb">:13717888844</div>
                </div>
                <div class="bddu" id="dituContent1"></div>
            </div>

        </div>
        <div class="conh-con">
            <div class="conh-con-c">
                <div class="gywm_l">
                    <div class="gywm_lt">联系地址 </div>
                    <div class="gywm_lb">: 北京市海淀区万寿路27号院</div>
                </div>
                <div class="gywm_l">
                    <div class="gywm_lt1">联系人</div>
                    <div class="gywm_lb">: 张老师/李老师</div>
                </div>
                <div class="gywm_l">
                    <div class="gywm_lt">联系电话</div>
                    <div class="gywm_lb">: 010-68209336/9337</div>
                </div>
                <div class="gywm_l">
                    <div class="gywm_lt">电子邮箱</div>
                    <div class="gywm_lb">: welcome@zhongqihuilian.com</div>
                </div>
                <div class="bddu" id="dituContent"></div>
            </div>

        </div>
    </div>
</div>
    <uc1:footer runat="server" id="footer" />
</body>
    <script type="text/javascript">
    //创建和初始化地图函数：
    function initMap(){
        createMap();//创建地图
        setMapEvent();//设置地图事件
        addMapControl();//向地图添加控件
        addMarker();//向地图中添加marker
        createMap1();//创建地图
        setMapEvent1();//设置地图事件
        addMapControl1();//向地图添加控件
        addMarker1();//向地图中添加marker
    }

    //创建地图函数：
    function createMap(){
        var map = new BMap.Map("dituContent");//在百度地图容器中创建一个地图
        var point = new BMap.Point(116.30355,39.912631);//定义一个中心点坐标
        map.centerAndZoom(point,17);//设定地图的中心点和坐标并将地图显示在地图容器中
        window.map = map;//将map变量存储在全局

       
    }
    //创建地图函数：
    function createMap1() {
        var map1 = new BMap.Map("dituContent1");//在百度地图容器中创建一个地图
        var point1 = new BMap.Point(116.233914, 39.91001);//定义一个中心点坐标
        map1.centerAndZoom(point1, 17);//设定地图的中心点和坐标并将地图显示在地图容器中
        window.map1 = map1;//将map变量存储在全局   
    }

    //地图事件设置函数：
    function setMapEvent(){
        map.enableDragging();//启用地图拖拽事件，默认启用(可不写)
        map.enableScrollWheelZoom();//启用地图滚轮放大缩小
        map.enableDoubleClickZoom();//启用鼠标双击放大，默认启用(可不写)
        map.enableKeyboard();//启用键盘上下左右键移动地图
    }
    //地图事件设置函数：
    function setMapEvent1() {
        map1.enableDragging();//启用地图拖拽事件，默认启用(可不写)
        map1.enableScrollWheelZoom();//启用地图滚轮放大缩小
        map1.enableDoubleClickZoom();//启用鼠标双击放大，默认启用(可不写)
        map1.enableKeyboard();//启用键盘上下左右键移动地图
    }


    //地图控件添加函数：
    function addMapControl(){
        //向地图中添加缩放控件
        var ctrl_nav = new BMap.NavigationControl({anchor:BMAP_ANCHOR_TOP_LEFT,type:BMAP_NAVIGATION_CONTROL_LARGE});
        map.addControl(ctrl_nav);
        //向地图中添加缩略图控件
        var ctrl_ove = new BMap.OverviewMapControl({anchor:BMAP_ANCHOR_BOTTOM_RIGHT,isOpen:1});
        map.addControl(ctrl_ove);
        //向地图中添加比例尺控件
        var ctrl_sca = new BMap.ScaleControl({anchor:BMAP_ANCHOR_BOTTOM_LEFT});
        map.addControl(ctrl_sca);
    }
    //地图控件添加函数：
    function addMapControl1() {
        //向地图中添加缩放控件
        var ctrl_nav1 = new BMap.NavigationControl({ anchor: BMAP_ANCHOR_TOP_LEFT, type: BMAP_NAVIGATION_CONTROL_LARGE });
        map1.addControl(ctrl_nav1);
        //向地图中添加缩略图控件
        var ctrl_ove1 = new BMap.OverviewMapControl({ anchor: BMAP_ANCHOR_BOTTOM_RIGHT, isOpen: 1 });
        map1.addControl(ctrl_ove1);
        //向地图中添加比例尺控件
        var ctrl_sca1 = new BMap.ScaleControl({ anchor: BMAP_ANCHOR_BOTTOM_LEFT });
        map1.addControl(ctrl_sca1);
    }

    //标注点数组
    var markerArr = [{title:"地址",content:"北京市海淀区万寿路27号院",point:"116.301978|39.913088",isOpen:1,icon:{w:21,h:21,l:0,t:0,x:6,lb:5}}];
    //标注点数组
    var markerArr1 = [{ title: "地址", content: "北京市石景山区鲁谷路35号", point: "116.233914|39.91001", isOpen: 1, icon: { w: 21, h: 21, l: 0, t: 0, x: 6, lb: 5 } }];
    //创建marker
    function addMarker(){
        for(var i=0;i<markerArr.length;i++){
            var json = markerArr[i];
            var p0 = json.point.split("|")[0];
            var p1 = json.point.split("|")[1];
            var point = new BMap.Point(p0,p1);
            var iconImg = createIcon(json.icon);
            var marker = new BMap.Marker(point,{icon:iconImg});
            var iw = createInfoWindow(i);
            var label = new BMap.Label(json.title,{"offset":new BMap.Size(json.icon.lb-json.icon.x+10,-20)});
            marker.setLabel(label);
            map.addOverlay(marker);
            label.setStyle({
                borderColor:"#808080",
                color:"#333",
                cursor:"pointer"
            });

            (function(){
                var index = i;
                var _iw = createInfoWindow(i);
                var _marker = marker;
                _marker.addEventListener("click",function(){
                    this.openInfoWindow(_iw);
                });
                _iw.addEventListener("open",function(){
                    _marker.getLabel().hide();
                })
                _iw.addEventListener("close",function(){
                    _marker.getLabel().show();
                })
                label.addEventListener("click",function(){
                    _marker.openInfoWindow(_iw);
                })
                if(!!json.isOpen){
                    label.hide();
                    _marker.openInfoWindow(_iw);
                }
            })()
        }
    }
    
    //创建marker
    function addMarker1() {
        for (var i = 0; i < markerArr1.length; i++) {
            var json1 = markerArr1[i];
            var p01 = json1.point.split("|")[0];
            var p11 = json1.point.split("|")[1];
            var point1 = new BMap.Point(p01, p11);
            var iconImg1 = createIcon1(json1.icon);
            var marker1 = new BMap.Marker(point1, { icon: iconImg1 });
            var iw1 = createInfoWindow1(i);
            var label1 = new BMap.Label(json1.title, { "offset": new BMap.Size(json1.icon.lb - json1.icon.x + 10, -20) });
            marker1.setLabel(label1);
            map1.addOverlay(marker1);
            label1.setStyle({
                borderColor: "#808080",
                color: "#333",
                cursor: "pointer"
            });

            (function () {
                var index1 = i;
                var _iw1 = createInfoWindow1(i);
                var _marker1 = marker1;
                _marker1.addEventListener("click", function () {
                    this.openInfoWindow(_iw1);
                });
                _iw1.addEventListener("open", function () {
                    _marker1.getLabel().hide();
                })
                _iw1.addEventListener("close", function () {
                    _marker1.getLabel().show();
                })
                label1.addEventListener("click", function () {
                    _marker1.openInfoWindow(_iw1);
                })
                if (!!json1.isOpen) {
                    label1.hide();
                    _marker1.openInfoWindow(_iw1);
                }
            })()
        }
    }
    //创建InfoWindow
    function createInfoWindow(i){
        var json = markerArr[i];
        var iw = new BMap.InfoWindow("<b class='iw_poi_title' title='" + json.title + "'>" + json.title + "</b><div class='iw_poi_content'>"+json.content+"</div>");
        return iw;
    }
    //创建InfoWindow
    function createInfoWindow1(i) {
        var json1 = markerArr1[i];
        var iw1 = new BMap.InfoWindow("<b class='iw_poi_title' title='" + json1.title + "'>" + json1.title + "</b><div class='iw_poi_content'>" + json1.content + "</div>");
        return iw1;
    }
    //创建一个Icon
    function createIcon(json){
        var icon = new BMap.Icon("http://app.baidu.com/map/images/us_mk_icon.png", new BMap.Size(json.w,json.h),{imageOffset: new BMap.Size(-json.l,-json.t),infoWindowOffset:new BMap.Size(json.lb+5,1),offset:new BMap.Size(json.x,json.h)})
        return icon;
    }
    //创建一个Icon
    function createIcon1(json1) {
        var icon1 = new BMap.Icon("http://app.baidu.com/map/images/us_mk_icon.png", new BMap.Size(json1.w, json1.h), { imageOffset: new BMap.Size(-json1.l, -json1.t), infoWindowOffset: new BMap.Size(json1.lb + 5, 1), offset: new BMap.Size(json1.x, json1.h) })
        return icon1;
    }

    initMap();//创建和初始化地图
</script>
</html>