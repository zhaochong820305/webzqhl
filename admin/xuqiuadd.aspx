<%@ Page Language="C#" AutoEventWireup="true" CodeFile="xuqiuadd.aspx.cs" Inherits="admin_xuqiuadd" %>

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
         <table class="gridtable"      id="list8">            
            <tr>
                <th class="active">融资需求：</th>
                <td>
                    <asp:TextBox CssClass="inputLB"  ID="rongzi" runat="server" BorderWidth="1" TextMode="MultiLine" Height="80px" Width="670px" ></asp:TextBox>   </td>
                
            </tr>
            <%--<tr>
                <th class="active">政策扶持：</th>
                <td colspan="3"> <asp:TextBox CssClass="inputLB"  ID="zhengce" runat="server" BorderWidth="1" Height="19px" Width="670px"></asp:TextBox>
                    &nbsp;</td>
                
            </tr>--%>
             <tr>
                <th class="active">产业链整合需求：</th>
                <td>
                    <asp:TextBox CssClass="inputLB"  ID="chanyelian" runat="server" BorderWidth="1" TextMode="MultiLine" Height="80px" Width="670px"></asp:TextBox>   </td>
                
            </tr>
             <tr>
                <th class="active">投资需求：</th>
                <td>
                    <asp:TextBox CssClass="inputLB"  ID="touzi" runat="server" BorderWidth="1" TextMode="MultiLine" Height="80px" Width="670px"> </asp:TextBox>  </td>
                
            </tr>
            <%-- <tr>
                <th class="active">收购需求：</th>
                <td>
                    <asp:TextBox CssClass="inputLB"  ID="shouguo" runat="server" BorderWidth="1" Height="19px" Width="670px"></asp:TextBox>   </td>
                
            </tr>--%>
             <tr>
                <th class="active">被收购需求：</th>
                <td>
                    <asp:TextBox CssClass="inputLB"  ID="beishou" runat="server" BorderWidth="1" TextMode="MultiLine" Height="80px" Width="670px"></asp:TextBox>   </td>
                
            </tr>
            <tr>
                <td colspan="4" style="text-align: center">
                    <asp:Button ID="Button1" runat="server"  CssClass="buttonLB1" Text="添加需求信息" OnClick="Button1_Click"/>
                    <asp:Button ID="Button2" runat="server" CssClass="buttonLB1"  Text="修改信息" OnClick="Button2_Click"/>
                    <asp:Label ID="Label1" runat="server" Text=""  style="text-align: center" ForeColor="Red" ></asp:Label>                     
                    <a href ="qygl.aspx" class="buttonLB1">返回企业管理</a>  <a class="buttonLB1" href ="qiyeedit.aspx?id=<%=icompanyid%>">返回编辑信息</a>
                    <asp:Label ID="Label10" runat="server" Text=""  style="text-align: center" ForeColor="Red" ></asp:Label>                
                     
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
