<%@ Page Language="C#" AutoEventWireup="true" CodeFile="zhengceadd.aspx.cs" Inherits="admin_zhengceadd" %>

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
        .zhengce ul li .labelblue{font-weight:800;color:blue; line-height:40px;}
        body {  overflow-x:hidden;  overflow-y:auto; } 
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
        <div style="margin-left:40px;margin-top:10px;">当前位置：<a href="zhengce.aspx?class=<%=classid %>&page=<%=page %>">政策大数据管理</a>>>政策大数据</div>
    <div style="margin-left:40px;margin-top:0px;" class="zhengce">
    <ul>
        <li><label class="labelblue">政策名称：</label>
            <asp:TextBox ID="mingcheng" CssClass="inputLB" MaxLength="100" Width="600px" runat="server"></asp:TextBox>
        </li>
        
        <li><label class="labelblue">政策文号：</label>
            <asp:TextBox ID="wenhao" CssClass="inputLB" MaxLength="50" Width="600px" runat="server"></asp:TextBox>
        </li>
        <li><label class="labelblue">发布日期：</label>
            <asp:TextBox ID="faburiqi" type="date" CssClass="inputLB" Width="600px" runat="server"></asp:TextBox>
        </li>
        <li><label class="labelblue">发布单位：</label>
            <asp:TextBox ID="fawendanwen" CssClass="inputLB" MaxLength="20" Width="600px" runat="server"></asp:TextBox>
        </li>
        <li><label class="labelblue">单位层级：（发文单位所属层级）</label>
            <%--<asp:DropDownList  CssClass="inputLB" Width="200px"  ID="cengji" runat="server" AutoPostBack="True"></asp:DropDownList>--%>
             <asp:RadioButtonList ID="cengjicb" runat="server" RepeatColumns="5" style="padding-left:86px;"></asp:RadioButtonList><%--<asp:RadioButtonList ID="RadioButtonList1" runat="server"></asp:RadioButtonList>--%>
        </li>
        <li><label class="labelblue">部委省级：</label>
            <asp:DropDownList  CssClass="inputLB" Width="200px"  ID="buwensheng" runat="server" AutoPostBack="True"></asp:DropDownList>（发文的部委/省级）
        </li>
        <li><label class="labelblue">所属工程：（政策所属：五大工程，其他）</label>
           <%-- <asp:DropDownList  CssClass="inputLB" Width="200px"  ID="gongcheng" runat="server" AutoPostBack="True"></asp:DropDownList>--%>
             <asp:CheckBoxList ID="gongchengc" runat="server" RepeatColumns="5" style="padding-left:86px;"></asp:CheckBoxList>
        </li>
        <li><label class="labelblue">十大领域：（政策所属：十大重点领域）</label>
            <%--<asp:DropDownList  CssClass="inputLB" Width="200px"  ID="lingyu" runat="server" AutoPostBack="True"></asp:DropDownList>--%>
            <asp:CheckBoxList ID="hangyec" runat="server" RepeatColumns="5" style="padding-left:86px;"></asp:CheckBoxList>

        </li>
       <%-- <li><label class="labelblue">显示权值：</label>
            <asp:TextBox ID="qz" Text="0" CssClass="inputLB" Width="300px" runat="server"></asp:TextBox>
            权值为数值，权值越大越优先显示
        </li>
        <br />
        <li><label class="labelblue">发布否？：</label>
            <asp:CheckBox ID="en" runat="server" />            
        </li>--%>
        <%--<li><label class="labelblue">发布到首页？：</label>
            <asp:CheckBox ID="sel" runat="server" />            
        </li>--%>
        <br />
        <li  ><label class="labelblue">政策依据：</label><br />
<%--            <asp:Label ID="content1"  runat="server" Text="" Visible="False"></asp:Label>--%>
            <asp:TextBox ID="yiju"   Width="800px" TextMode="MultiLine" Height="100px" runat="server"></asp:TextBox>
        </li>
        <li  ><label class="labelblue">政策/规划目标：</label><br />
<%--            <asp:Label ID="content1"  runat="server" Text="" Visible="False"></asp:Label>--%>
            <asp:TextBox ID="mubiao"   Width="800px" TextMode="MultiLine" Height="100px" runat="server"></asp:TextBox>
        </li>
        <%--<li> 
            <%=str %>
        </li>--%>
        <li><label class="labelblue">有效日期：</label>
            <asp:TextBox ID="youxiaoqi" type="date" CssClass="inputLB" Width="600px" runat="server"></asp:TextBox>
        </li>
        <li><label class="labelblue">下面选择：</label>       
            <asp:TextBox ID="tbhangye" CssClass="inputLB" MaxLength="500" Width="500px" runat="server"></asp:TextBox>
        </li>
        <li><label class="labelblue">针对行业：</label>
            <%--<asp:TextBox ID="hangye" CssClass="inputLB" MaxLength="20" Width="600px" runat="server"></asp:TextBox>--%>
            <asp:DropDownList  CssClass="inputLB" Width="200px"  ID="hangye" runat="server" AutoPostBack="True" OnSelectedIndexChanged="hangye_SelectedIndexChanged"></asp:DropDownList>
            <asp:DropDownList  CssClass="inputLB" Width="200px"  ID="hangye2" runat="server" AutoPostBack="True" ></asp:DropDownList>
            <asp:Button ID="Button1" CssClass="buttonLB" runat="server" Text="添加" OnClick="hangyeadd_Click" />
            <%--            <asp:CheckBoxList ID="hangyecl" runat="server" RepeatColumns="5"></asp:CheckBoxList>--%> 
        </li>
        <li><label class="labelblue">针对产品：</label>
            <asp:TextBox ID="chanpin" CssClass="inputLB" MaxLength="300" Width="600px" runat="server"></asp:TextBox>
        </li>
        <li><label class="labelblue">原文链接：</label>
            <asp:TextBox ID="zcywdizhi" CssClass="inputLB" MaxLength="500" Width="600px" runat="server"></asp:TextBox>
        </li>
        <li  ><label class="labelblue">政策全文：</label><br />
            <asp:Label ID="content1"  runat="server" Text="" Visible="False"></asp:Label>
            <asp:TextBox ID="content"   Width="800px" TextMode="MultiLine" Height="100px" runat="server"></asp:TextBox>
        </li>
         <li><label class="labelblue">采集网址：</label>
            <asp:TextBox ID="url" CssClass="inputLB" MaxLength="500" Width="600px" runat="server"></asp:TextBox>
        </li>
        <li><label class="labelblue">&nbsp;</label>
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

