<%@ Page Language="C#" AutoEventWireup="true" CodeFile="projectlist.aspx.cs" Inherits="admin_projectlist" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="css/qiyegl.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" >   
        <div class="tab-content" >
            基本信息：  <a href="Project.aspx" class="buttonLB1">返回项目列表</a>
            <hr>
            <%=str %>  <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </div>       
    </form>
</body>
</html>