<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="admin_test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatDirection="Horizontal"
                        RepeatLayout="Flow"  AutoPostBack="True">
                        <asp:ListItem Value="101">德国</asp:ListItem> 
                        <asp:ListItem Value="102">荷兰</asp:ListItem>
                        <asp:ListItem Value="103">巴西</asp:ListItem>
                    </asp:CheckBoxList>
    </div>
    </form>
</body>
</html>
