<%@ Page Language="C#" AutoEventWireup="true" CodeFile="diaochatuanlist.aspx.cs" Inherits="admin_diaochatuanlist" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        html {
            font-size: 14px;
            font-family: 微软雅黑;
        }

        body {
            background-color: #fff;
            padding-top:8px;
        }

        div#content {
            overflow:hidden;
            width:18.4cm;
            margin:0 auto;
            _height:200px; 
            min-height:200px 
        }

        .title {
            width:18.4cm;
            font-size:16px;
            line-height:2.5;
            font-weight:bold;
        }
        .titlebj{background-color:#ccc; font-size:18px;  font-weight:bold; color:red; padding-left:200px;}
        table {
            margin:0;border-collapse:collapse;border-spacing:0;
            width:18.4cm;
            border-left:1px solid #000;
            border-top:1px solid #000;
        }

        table tr{
            width:18.4cm;
        }
        th {
            white-space: nowrap;
            text-align:left; 
        }
        th,td{
            padding:5px;
            border-right:1px solid #000;
            border-bottom:1px solid #000;
            line-height:1;
        }
        .con span {color:red;}

       .cw1_1{
    width:480px;
    height:46px;
    text-align:center;
    /*border:1px #888 solid;*/
}
.cw1_11{
    width:480px;
    height:46px;
    text-align:left;
    /*border:1px #888 solid;*/
}
.cw1_2{
    width:304px;
    height:46px;
    text-align:center;
    /*border:1px #888 solid;*/
}
.cw1_22{
    width:304px;
    height:46px;
    text-align:center;
    /*border-left:1px #888 solid;
    border-bottom:1px #888 solid;*/
}
.cw1_23{
    width:304px;
    height:46px;
    text-align:center;
    /*border-left:1px #888 solid;*/
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div id="content">
        <div class="title">联盟团体标准制修订提案申请表 <a href="diaochatuan.aspx?type=7">返回联盟团体标准制修订提案申请表 列表</a></div>

        <%=str2 %>
        <%--<div class="title">二、企业其他信息</div>
        <%=str2 %>
        <div class="title">三、管理团队</div>
        <%=str3 %>  
        <div class="title">四、企业财务信息</div>
        <%=str4 %>
        <div class="title">五、项目信息</div>
        <%=str5 %>   --%>
    </div>
    </div>
    </form>
</body>
</html>

