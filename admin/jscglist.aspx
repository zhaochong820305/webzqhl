<%@ Page Language="C#" AutoEventWireup="true" CodeFile="jscglist.aspx.cs" Inherits="admin_jscglist" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="css/qiyegl.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    基本信息：  <a href="jscg.aspx" class="buttonLB1">返回技术成果</a>
            <hr>
            <%=str %>  <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>
