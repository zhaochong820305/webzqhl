<%@ Page Language="C#" AutoEventWireup="true" CodeFile="zj.aspx.cs" Inherits="admin_zj" %>

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

  
    <style>
        .bianji label{ display:inline-block; width:100px; margin-top:10px;}
        .bianji input{ margin-top:10px;}
    </style>

<script>
		KindEditor.ready(function(K) {
			var editor1 = K.create('#content', {
				cssPath : 'js/plugins/code/prettify.css',
				uploadJson : 'upload_json.ashx',
				fileManagerJson : 'file_manager_json.ashx',
				allowFileManager : true,
				afterCreate : function() {
					var self = this;
					K.ctrl(document, 13, function() {
						self.sync();
						K('form[name=example]')[0].submit();
					});
					K.ctrl(self.edit.doc, 13, function() {
						self.sync();
						K('form[name=example]')[0].submit();
					});
				}
			});
			prettyPrint();
		});
	</script>
</head>
<body style="margin:0 auto;width:1200px;">
    <form id="form1" runat="server">
    <div style="margin-left:20px;margin-top:10px;">当前位置：&nbsp;<a href="zjgl.aspx">专家管理</a>>>专家</div>
    <div style="margin:0 auto;margin-top:10px;margin-left:20px;">
    <ul>
        <li><label>专&nbsp;家&nbsp;名&nbsp;：</label>
            <asp:TextBox ID="zjname" CssClass="inputLB" MaxLength="100" Width="600px" runat="server"></asp:TextBox>
        </li>
        <li><label>专家分类：</label>
            <asp:DropDownList ID="fenlei" CssClass="inputLB" Width="600px" runat="server"></asp:DropDownList> 
        </li>
        <li><label>专家领域：</label>
            <asp:DropDownList ID="classn" CssClass="inputLB" Width="600px" runat="server"></asp:DropDownList> 
        </li>
        <li><label>专家图片：</label>
            <asp:TextBox ID="pic" CssClass="inputLB" MaxLength="100" Width="600px" runat="server"></asp:TextBox>
            
        </li>
        <li><label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
           <asp:FileUpload ID="upfile" CssClass="buttonLB" runat="server" Width="200px" /> 
           <asp:Button ID="scfile" CssClass="buttonLB" runat="server" Text=" 上 传 " OnClick="scfile_Click" />
        </li>
        <li><label>专家圆图：</label>
            <asp:TextBox ID="pic1" CssClass="inputLB" MaxLength="100" Width="600px" runat="server"></asp:TextBox>
            
        </li>
        <li><label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
           <asp:FileUpload ID="upfile1" CssClass="buttonLB" runat="server" Width="200px" /> 
           <asp:Button ID="scfile1" CssClass="buttonLB" runat="server" Text=" 上 传 " OnClick="scfile1_Click" />
        </li>
        <li><label>专家职务：</label>
            <asp:TextBox ID="zw" CssClass="inputLB" MaxLength="40" Width="600px" runat="server"></asp:TextBox>
        </li>
        <br />
        <li><label>是否组长：</label>
            <asp:CheckBox ID="zzf" runat="server" />            
        </li>
        <li><label>是否首页：</label>
            <asp:CheckBox ID="indexview" runat="server" />            
        </li>
        <li><label>是否展会：</label>
            <asp:CheckBox ID="zhanhui" runat="server" />            
        </li>
        <li><label>重&nbsp;&nbsp;要&nbsp;性：</label>
            <asp:TextBox ID="zhongyao" CssClass="inputLB" MaxLength="40" Width="600px" runat="server"></asp:TextBox>
           <%--  <asp:DropDownList ID="zhongyao" runat="server" Height="22px" Width="246px">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>9</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
              </asp:DropDownList> --%>     (越小越重要,可为小数)      
        </li>
        <li style="height:230px;"><label>专家简介：</label><br />
            <asp:Label ID="zjjj1"  runat="server" Text="" Visible="False"></asp:Label>
            <asp:TextBox ID="content" CssClass="inputLB" Width="800px" TextMode="MultiLine" Height="200px" runat="server"></asp:TextBox>
        </li>
        <%--<li style="height:230px;"><label>专家简历：</label><br />
            <asp:Label ID="zjjl1"  runat="server" Text="" Visible="False"></asp:Label>
            <asp:TextBox ID="zjjl" CssClass="inputLB" Width="800px" TextMode="MultiLine" Height="200px" runat="server"></asp:TextBox>
        </li>--%>
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
