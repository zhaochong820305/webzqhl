<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Magicajax.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="MagicAjax" Namespace="MagicAjax.UI.Controls" TagPrefix="ajax" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>AjaxPanel example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ajax:AjaxPanel ID="AjaxPanel1" runat="server" Font-Bold="True">
            <asp:Panel ID="Panel1" runat="server" Font-Size="XX-Large" Height="45px" Width="273px">
                AjaxPanel example</asp:Panel>
            <br />
            <asp:Button ID="Button1" runat="server" BackColor="#FFC080" Height="26px" OnClick="Button1_Click"
                Text="CreateData" Width="85px" />
            &nbsp;
            <asp:Button ID="Button2" runat="server" BackColor="#FFC080" Height="26px" Text="ClearData"
                Width="73px" /><br />
            <br />
            <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#E7E7FF"
                BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal">
                <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                <AlternatingRowStyle BackColor="#F7F7F7" />
            </asp:GridView>
        </ajax:AjaxPanel>
    
    </div>
    </form>
</body>
</html>
