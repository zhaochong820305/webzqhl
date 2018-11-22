<%@ Page Language="C#" AutoEventWireup="true" CodeFile="comGuQuan.aspx.cs" Inherits="comGuQuan" %>

<%@ Register Src="~/include/header.ascx" TagPrefix="uc1" TagName="header" %>
<%@ Register Src="~/include/footer.ascx" TagPrefix="uc1" TagName="footer" %>
<%@ Register Src="~/include/menu.ascx" TagPrefix="uc1" TagName="menu" %>
<%@ Register Src="~/include/left.ascx" TagPrefix="uc1" TagName="left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>编辑企业信息</title>

<link rel="stylesheet" href="css/style.css" />
<link rel="stylesheet" href="css/company.css" />
</head>

<body>
    
    <uc1:menu runat="server" ID="menu" />

    <form  runat="server" id="form1" class="form1">
         
        <uc1:left runat="server" ID="left" />   
        <div class="rightmenu">
         当前位置：编辑股权信息
         <table class="gridtable" <% if (typeid == 6) Response.Write("style='display: block'"); else Response.Write("style='display: none'"); %> id="list6">
                <tr>
                    <th class="active">是否有股权激励：</th>
                    <td>
                        <asp:CheckBox ID="cbguquan" runat="server" />
                    </td>

                </tr>
                <tr>
                    <th class="active">激励措施：</th>
                    <td colspan="3">
                        <asp:TextBox CssClass="inputLB" ID="tbjili" runat="server" BorderWidth="1" Height="19px" Width="670px"></asp:TextBox>
                        &nbsp;</td>

                </tr>
                <tr>
                    <td colspan="4" style="text-align: center">
                        <asp:Button ID="Button3" runat="server" CssClass="buttonLB1" Text="修改员工激励信息" OnClick="Button3_Click" />
                        <asp:Label ID="Label3" runat="server" Text="" Style="text-align: center" ForeColor="Red"></asp:Label>

                    </td>
                </tr>
            </table>
       </div>
    </form>
</body>
<script src="js/angular.min.js" type="text/javascript"></script>
<script>
	var app=angular.module("lesson",[]);
	app.controller("formContr",function($scope){
		$scope.form1={};		
		});
</script>
     <uc1:footer runat="server" id="footer" />
</html>
