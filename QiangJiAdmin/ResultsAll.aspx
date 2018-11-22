<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ResultsAll.aspx.cs" Inherits="admin_ResultsAll" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>全部成果</title>
    <link href="css/qiyegl.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    基本信息：  <a href="Results.aspx" class="buttonLB1">返回交易成果</a>
            
            <%=strall %>    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>
