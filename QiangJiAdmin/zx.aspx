<%@ Page Language="C#" AutoEventWireup="true" CodeFile="zx.aspx.cs" Inherits="admin_zx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>管理中心</title>
    <link href="css/main.css" rel="stylesheet" />
    <link href="css/ps.css" rel="stylesheet" />
    <link href="css/font-awesome.min.css" rel="stylesheet" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/grid.css" rel="stylesheet" />
    <link rel="stylesheet" href="js/themes/default/default.css" />
	<link rel="stylesheet" href="js/plugins/code/prettify.css" />
	<script charset="utf-8" src="js/kindeditor-all.js"></script>
	<script charset="utf-8" src="js/lang/zh-CN.js"></script>
	<script charset="utf-8" src="js/plugins/code/prettify.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin-left:40px;margin-top:10px;">当前位置：<a href="zxsq.aspx">在线申请</a>>>申请</div>
    <div style="margin-left:40px;margin-top:0px;">
    <ul>
        <li><label>企业名称：</label>
            <asp:TextBox ID="qymc" CssClass="inputLB" MaxLength="100" Width="600px" runat="server"></asp:TextBox>
        </li>
        <li><label>联 系 人 ：</label>
            <asp:TextBox ID="lxr" CssClass="inputLB" MaxLength="100" Width="600px" runat="server"></asp:TextBox>
        </li>
        <li><label>联系电话：</label>
            <asp:TextBox ID="lxdh" CssClass="inputLB" MaxLength="100" Width="600px" runat="server"></asp:TextBox>
        </li>
        <li><label> email ： &nbsp;&nbsp;</label>
            <asp:TextBox ID="email" CssClass="inputLB"   MaxLength="20" Width="600px" runat="server"></asp:TextBox>
        </li>
        <li><label>项目名称：</label>
            <asp:TextBox ID="xmmc" CssClass="inputLB" MaxLength="20" Width="600px" runat="server"></asp:TextBox>
        </li>
        <li><label>项目区域：</label>
            <asp:TextBox ID="quyu" CssClass="inputLB" MaxLength="20" Width="600px" runat="server"></asp:TextBox>
        </li>
        <li><label>项目类型：</label>
            <asp:TextBox ID="typename" CssClass="inputLB" MaxLength="20" Width="600px" runat="server"></asp:TextBox>
        </li>
        <%--<li><label>项目介绍：</label>
            <asp:TextBox ID="xmjs" CssClass="inputLB" TextMode="MultiLine" Width="600px" runat="server"></asp:TextBox>
        </li>
        <li><label>技术优势：</label>
            <asp:TextBox ID="jsys" CssClass="inputLB" TextMode="MultiLine" MaxLength="20" Width="600px" runat="server"></asp:TextBox>
        </li>
        <li><label>知识产权：</label>
            <asp:TextBox ID="cqqk" CssClass="inputLB" TextMode="MultiLine" MaxLength="20" Width="600px" runat="server"></asp:TextBox>
        </li>
        <li><label>投资进度：</label>
            <asp:TextBox ID="tzjd" CssClass="inputLB" TextMode="MultiLine" MaxLength="20" Width="600px" runat="server"></asp:TextBox>
        </li>
        <li><label>销售利润：</label>
            <asp:TextBox ID="xslr" CssClass="inputLB" TextMode="MultiLine" MaxLength="20" Width="600px" runat="server"></asp:TextBox>
        </li>--%>
        
        <br />
        <li><label>是否处理？：</label>
            <asp:CheckBox ID="cl" runat="server" />            
        </li>
        <li><label>&nbsp;</label>
            <asp:Button ID="bc" CssClass="buttonLB" runat="server" Text=" 保 存 " OnClick="bc_Click" />
        </li>
        <li>
            <asp:Label ID="msg" runat="server" ForeColor="Red"></asp:Label>
        </li>
    </ul>
    </div>
    </form>
</body>
</html>