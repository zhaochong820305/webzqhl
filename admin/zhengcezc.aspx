<%@ Page Language="C#" AutoEventWireup="true" CodeFile="zhengcezc.aspx.cs" Inherits="admin_zhengcezc" %>

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
        .danhang{height:40px;line-height:40px;}
        body {  overflow-x:hidden;  overflow-y:auto; } 
        .radio label{color:#282828;}
        .zhengce ul li .labelblue{font-weight:800;color:blue; line-height:40px;}
        .igbt7_1{border:none;border-bottom:1px #888 solid;height:25px;    width:100px;    font-size: 14px;    color: #282828;    outline:none;}
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
        <li class="danhang"><label class="labelblue">政策名称：</label>
            <%--<asp:TextBox ID="mingcheng" CssClass="inputLB" MaxLength="100" Width="600px" runat="server"></asp:TextBox>--%>
            <asp:Label ID="mingcheng"  runat="server" Text="" ></asp:Label>
        </li>
        
       
        <li><label class="labelblue">支持产能：</label>
            <asp:TextBox ID="glchanneng" CssClass="inputLB" MaxLength="20" Width="600px" runat="server"></asp:TextBox>(鼓励/支持-产能)
        </li>
        <li><label class="labelblue">支持地区：</label>
            <asp:DropDownList ID="gldiqu"  CssClass="inputLB" Width="600px" runat="server"></asp:DropDownList>(鼓励/支持-地区)
        </li>
        <li class="danhang"><label class="labelblue">支持主体：</label>
             <asp:CheckBox ID="jishu1_1" runat="server" class="radio" Text="  组织机构/企业，企业规模，类型等" /> 
             <asp:CheckBox ID="jishu1_2" runat="server" class="radio" Text="  个人" /> 
             <asp:CheckBox ID="jishu1_3" runat="server" class="radio" Text="  项目" />
             <asp:CheckBox ID="jishu1_4" runat="server" class="radio" Text="  其他(请注明)" />&nbsp;&nbsp;
             <input runat="server" class="igbt7_1 " type="text" id="txtjishu4_3"  autocomplete="off"/>
             (鼓励/支持-主体/对象)
        </li>
        <li class="danhang"><label class="labelblue">支持时间：</label>
             <asp:RadioButton ID="CheckBox1" runat="server" class="radio" Text="  投资前" GroupName="jishu4_4" /> 
             <asp:RadioButton ID="CheckBox2" runat="server" class="radio" Text="  投资后" GroupName="jishu4_4"/>
             <asp:RadioButton ID="CheckBox3" runat="server" class="radio" Text="  其他(请注明)" GroupName="jishu4_4"/>&nbsp;&nbsp;
             <input runat="server" class="igbt7_1 " type="text" id="Text1"  autocomplete="off"/>（发文单位所属层级）
        </li>
        <li  ><label class="labelblue">支持时间-具体说明：</label><br />
<%--            <asp:Label ID="content1"  runat="server" Text="" Visible="False"></asp:Label>--%>
            <asp:TextBox ID="zcshuoming"   Width="800px" TextMode="MultiLine" Height="100px" runat="server"></asp:TextBox>
        </li>
        <li class="danhang"><label class="labelblue">支持规模-支持方式：</label>
             <asp:CheckBox ID="CheckBox4" runat="server" class="radio" Text="  固定资产投资比例" /> 
             <asp:CheckBox ID="CheckBox5" runat="server" class="radio" Text="  一定额度资金" /> 
             <asp:CheckBox ID="CheckBox6" runat="server" class="radio" Text="  退税" />
             <asp:CheckBox ID="CheckBox7" runat="server" class="radio" Text="  其他(请注明)" />&nbsp;&nbsp;
             <input runat="server" class="igbt7_1 " type="text" id="Text2"  autocomplete="off"/>（支持规模-支持方式）
        </li>
        <li  ><label class="labelblue">支持规模-具体说明：</label><br />
<%--            <asp:Label ID="content1"  runat="server" Text="" Visible="False"></asp:Label>--%>
            <asp:TextBox ID="gmshuoming"   Width="800px" TextMode="MultiLine" Height="100px" runat="server"></asp:TextBox>
        </li>
        <li class="danhang"><label class="labelblue">评审方式：</label>
             <asp:RadioButton ID="RadioButton1" runat="server" class="radio" Text="  招投标" GroupName="jishu4_5" /> 
             <asp:RadioButton ID="RadioButton2" runat="server" class="radio" Text="  定向" GroupName="jishu4_5"/>
             <asp:RadioButton ID="RadioButton3" runat="server" class="radio" Text="  其他(请注明)" GroupName="jishu4_5"/>&nbsp;&nbsp;
             <input runat="server" class="igbt7_1 " type="text" id="Text3"  autocomplete="off"/>（发文单位所属层级） 
        </li>
       
        <br />
        <li  ><label class="labelblue">评审方式-具体说明：</label><br />
<%--            <asp:Label ID="content1"  runat="server" Text="" Visible="False"></asp:Label>--%>
            <asp:TextBox ID="psshuoming"   Width="800px" TextMode="MultiLine" Height="100px" runat="server"></asp:TextBox>
        </li>
        <li class="danhang"><label class="labelblue">申报/建设条件：</label>
             <asp:CheckBox ID="CheckBox8" runat="server" class="radio" Text="  资产/规模要求" /> 
             <asp:CheckBox ID="CheckBox9" runat="server" class="radio" Text="  企业性质要求" /> 
             <asp:CheckBox ID="CheckBox10" runat="server" class="radio" Text="  技术要求" />
             <asp:CheckBox ID="CheckBox11" runat="server" class="radio" Text="  其他(请注明)" />&nbsp;&nbsp;
             <input runat="server" class="igbt7_1 " type="text" id="Text4"  autocomplete="off"/>
        </li>
        <li  ><label class="labelblue">申报/建设具体条件：</label><br />
<%--            <asp:Label ID="content1"  runat="server" Text="" Visible="False"></asp:Label>--%>
            <asp:TextBox ID="sbjttiaojian"   Width="800px" TextMode="MultiLine" Height="100px" runat="server"></asp:TextBox>
        </li>
        <%--<li> 
            <%=str %>
        </li>--%>
        <li><label class="labelblue">限制产能：</label>
            <asp:TextBox ID="xzchanneng"  CssClass="inputLB" Width="600px" runat="server"></asp:TextBox>（限制/禁止-产能）
        </li>
        <li><label class="labelblue">限制地区：</label>
            <%--<asp:TextBox ID="hangye" CssClass="inputLB" MaxLength="20" Width="600px" runat="server"></asp:TextBox>--%>
            <asp:DropDownList  CssClass="inputLB" Width="600px"  ID="xzdiqu" runat="server" AutoPostBack="True"></asp:DropDownList>（限制/禁止-地区）
        </li>
        <li><label class="labelblue">限制主体：</label>
            <asp:TextBox ID="xzzhuti" CssClass="inputLB" MaxLength="20" Width="600px" runat="server"></asp:TextBox>（限制/禁止-主体）
        </li>
        
        <li  ><label class="labelblue">限制方式说明：</label><br />
            <asp:Label ID="content1"  runat="server" Text="" Visible="False"></asp:Label>
            <asp:TextBox ID="content"   Width="800px" TextMode="MultiLine" Height="100px" runat="server"></asp:TextBox>
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
