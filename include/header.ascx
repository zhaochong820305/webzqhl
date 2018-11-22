<%@ Control Language="C#" AutoEventWireup="true" CodeFile="header.ascx.cs" Inherits="include_header" %>
<head>
    <meta name="renderer" content="ie-comp">
    <meta name="renderer" content="ie-stand">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>工信部电子情报所科技成果评价与推广转化服务中心-北京中企慧联科技发展中心</title>
    <meta name="keywords" content="科技评价在线申请,工信部电子情报所科技成果评价与推广转化服务中心,中企慧联，北京中企慧联科技发展中心">
    <meta name="description" content="以支撑政府,服务行业为宗旨,以促进先进,成熟,适用的科技成果推广应用和产业化为目标,强化科技成果推广转化服务于产业科技创新和技术进步的能力,搭建科技成果推广转化服务平台,推动工业和信息化领域重大科技成果和行业共性技术,关键技术的转移和扩散,支撑军民两用技术的双向转移,促进部属高校,行业科研院所与行业企业和地方省市产学研合作,为广大工业企业,高校及院所提供“一站式”成果转化中介服务,提升产业技术水平,加速产业结构调整和升级改造 ">
    <link href="css/style.css" rel="stylesheet" >
    <link href="css/cgpj.css" rel="stylesheet" >
    <script type="text/javascript" lang="javascript">
        //加入收藏
        function AddFavorite(sURL, sTitle) {
            sURL = encodeURI(sURL);
            try{
                window.external.addFavorite(sURL, sTitle);
            }catch(e) {
                try{
                    window.sidebar.addPanel(sTitle, sURL, "");
                }catch (e) {
                    alert("加入收藏失败，请使用Ctrl+D进行添加,或手动在浏览器里进行设置.");
                }
            }
        }
        //设为首页

        function SetHome(url){
            if (document.all) {
                document.body.style.behavior='url(#default#homepage)';
                document.body.setHomePage(url);
            }else{
                alert("您好,您的浏览器不支持自动设置页面为首页功能,请您手动在浏览器里设置该页面为首页!");
            }
        }
    </script>
    
    <script type="text/javascript" src="js/jquery.js"></script>
    <script type="text/javascript" src="js/scripts.js"></script>
        
    <script type="text/javascript" lang="javascript">
        //加入收藏
        function AddFavorite(sURL, sTitle) {
            sURL = encodeURI(sURL);
            try{
                window.external.addFavorite(sURL, sTitle);
            }catch(e) {
                try{
                    window.sidebar.addPanel(sTitle, sURL, "");
                }catch (e) {
                    alert("加入收藏失败，请使用Ctrl+D进行添加,或手动在浏览器里进行设置.");
                }
            }
        }
        //设为首页

        function SetHome(url){
            if (document.all) {
                document.body.style.behavior='url(#default#homepage)';
                document.body.setHomePage(url);
            }else{
                alert("您好,您的浏览器不支持自动设置页面为首页功能,请您手动在浏览器里设置该页面为首页!");
            }
        }
    </script>
</head>