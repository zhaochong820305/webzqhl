<%@ Page Language="C#" AutoEventWireup="true" CodeFile="main.aspx.cs" Inherits="admin_main" %>

<%@ Register Src="~/Admin/include/header.ascx" TagPrefix="uc1" TagName="header" %>
<%@ Register Src="~/Admin/include/Left.ascx" TagPrefix="uc1" TagName="Left" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>管理中心</title>
    <link href="css/main.css" rel="stylesheet" />
    <link href="css/ps.css" rel="stylesheet" />
    <link href="css/font-awesome.min.css" rel="stylesheet" />
<link href="css/style.css" rel="stylesheet" type="text/css" />
<script src="js/jquery-2.1.1.min.js" type="text/javascript"></script>
<style>
*{margin:0; padding:0;}
</style>
</head>
<body style="background:url(images/back.png) no-repeat 0 -100px; background-size:150%;">
<div id="headerc" >
    <form runat="server">
        <uc1:header runat="server" id="header" />
        </form>
</div>
<div id="content">
    <div style="float:left;width:160px;height:100%;">
        <uc1:left runat="server" id="left" />
    </div>
    <div class="right">
    	<div class="right_top" id="li_show">
        	管理用户
        </div>
        <div id="hosts" style="position:absolute;border-width:2px;height:1500px;width:980px;left:170px;">
            <iframe src="content.aspx" frameborder="0" id="_content"  hspace="0" vspace="0"  scrolling="auto"  style="width:980px;height:100%;"></iframe>
        </div>
     </div>
</div>
 
<div id="footer">

</div>
<script>
        function loadurl(url ,element)
        {
			var ps = document.getElementById("_content");
			li_show.innerHTML=element.innerHTML;
			 ps.src = url;
        }

   		</script>
</body>
</html>
