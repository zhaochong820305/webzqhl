<%@ Page Language="C#" validateRequest="false" AutoEventWireup="true" CodeFile="news.aspx.cs" Inherits="admin_news" %>
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
        .webtype { color:blue; font-weight:900; font-size:16px;}
        body { 
 overflow-x:hidden; 
 overflow-y:auto; 
} 
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
<body>
    <form id="form1" runat="server">
        <div style="margin-left:40px;margin-top:10px;">当前位置：<a href="xwgl.aspx?class=<%=classid %>&page=<%=page %>">新闻管理</a>>>新闻</div>
    <div style="margin-left:40px;margin-top:0px;">
    <ul>
        <li><label>新闻标题：</label>
            <asp:TextBox ID="title" CssClass="inputLB" MaxLength="100" Width="600px" runat="server"></asp:TextBox>
        </li>
        <li><label  ><%--新闻分类：--%></label>
            <asp:DropDownList ID="classn" CssClass="inputLB" Width="400px" runat="server" Visible="false"></asp:DropDownList>
        </li>
        <li><label>新闻图片：</label>
            <asp:TextBox ID="pic" CssClass="inputLB" MaxLength="100" Width="600px" runat="server"></asp:TextBox>
        </li>
        <li><label>&nbsp;&nbsp;</label>
           <asp:FileUpload ID="upfile" CssClass="buttonLB" runat="server" /> <asp:Button ID="scfile" CssClass="buttonLB" runat="server" Text=" 上 传 " OnClick="scfile_Click" />
        </li>
        <li><label>发布作者：</label>
            <asp:TextBox ID="writer" CssClass="inputLB" MaxLength="20" Width="600px" runat="server"></asp:TextBox>
        </li>
        <li><label>发布时间：</label>
            <asp:TextBox ID="cdate" type="date" CssClass="inputLB" Width="600px" runat="server"></asp:TextBox>
        </li>
        <li><label>显示权值：</label>
            <asp:TextBox ID="qz" Text="0" CssClass="inputLB" Width="300px" runat="server"></asp:TextBox>
            权值为数值，权值越大越优先显示
        </li>
        <br />
        <li><label>发布否？：</label>
            <asp:CheckBox ID="en" runat="server" />            
        </li>
        <li><label>发布到首页？：</label>
            <asp:CheckBox ID="sel" runat="server" />            
        </li>
        <br />
        <li style="height:350px;"><label>新闻内容：</label><br />
            <asp:Label ID="content1"  runat="server" Text="" Visible="False"></asp:Label>
            <asp:TextBox ID="content" CssClass="inputLB" Width="800px" TextMode="MultiLine" Height="300px" runat="server"></asp:TextBox>
        </li>
        <%--<li> 
            <%=str %>
        </li>--%>
        <li> 
            <div class='webtype'>中企慧联</div>
            <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatColumns="5"></asp:CheckBoxList></li>
        <li> 
            <div class='webtype'>联盟网站</div>
            <asp:CheckBoxList ID="CheckBoxList2" runat="server" RepeatColumns="5"></asp:CheckBoxList></li>
        <li> 
            <div class='webtype'>工业强基</div>
            <asp:CheckBoxList ID="CheckBoxList3" runat="server" RepeatColumns="5"></asp:CheckBoxList></li>
        <li> 
            <div class='webtype'>成果交易</div>
            <asp:CheckBoxList ID="CheckBoxList4" runat="server" RepeatColumns="5"></asp:CheckBoxList></li> 
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

