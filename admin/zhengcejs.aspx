<%@ Page Language="C#" AutoEventWireup="true" CodeFile="zhengcejs.aspx.cs" Inherits="admin_zhengcejs" %>

<!DOCTYPE html>
<html lang="en">
 
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
    <form id="form1"  name="form1" runat="server">
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
        <li><label class="labelblue">单位层级：</label>            
            <input type="radio" name="cengji"  ID="cengji1" value="1" onclick="getRadio()" runat="server">国务院  
            <input type="radio" name="cengji"  ID="cengji2" value="2" onclick="getRadio()" runat="server">国家部委 
            <input type="radio" name="cengji"  ID="cengji3" value="3" onclick="getRadio()" runat="server">地方
        </li>
        <li id="buweili" <%=buweiview %>><label class="labelblue">国家部委：</label>
            <input   type="radio"   name="buwei"   value="2" onclick="getRadiobw()" ID="buwei2" runat="server">发改委
            <input   type="radio"   name="buwei"   value="1" onclick="getRadiobw()" ID="buwei1" runat="server">工信部
            <input   type="radio"   name="buwei"   value="5" onclick="getRadiobw()" ID="buwei5" runat="server">科技部
            <input   type="radio"   name="buwei"   value="3" onclick="getRadiobw()" ID="buwei3" runat="server">商务部
            <input   type="radio"   name="buwei"   value="4" onclick="getRadiobw()" ID="buwei4" runat="server">财政部  
            
        </li>
        <li  id="zhengceli" <%=kejiview %>><label class="labelblue">政策类型：</label>            
            <input   type="radio"   name="zhengcel" id="zhengcel1"  value="1" onclick="getRadiozx()" runat="server">专项  
            <input   type="radio"   name="zhengcel" id="zhengcel2"  value="2" onclick="getRadiozx()" runat="server">非专项
        </li>
        <div id="xiangmuli" <%=xiangmuliview %>>
            <ul>
                <li ><label class="labelblue">项目类型：</label>            
                    <input   type="radio"   name="xiangmu" id="xiangmu1"  value="1" onclick="getRadioxm()" runat="server">重点研发计划重点专项  
                    <input   type="radio"   name="xiangmu" id="xiangmu2"  value="2" onclick="getRadioxm()" runat="server">重点研发计划试点专项 
                    <input   type="radio"   name="xiangmu" id="xiangmu3"  value="3" onclick="getRadioxm()" runat="server">重大专项
                </li>
                <li id="zhangxiangli1"  <%=zhangxiangli1view %>><label class="labelblue">专项名称：</label>
                    <asp:DropDownList  CssClass="inputLB" Width="400px"  ID="zhangxiang1" runat="server"></asp:DropDownList> 
                </li>
                <li id="zhangxiangli2"  <%=zhangxiangli2view %>><label class="labelblue">专项名称：</label>
                    <asp:DropDownList  CssClass="inputLB" Width="400px"  ID="zhangxiang2" runat="server"></asp:DropDownList> 
                </li>
                <li id="zhangxiangli3"  <%=zhangxiangli3view %>><label class="labelblue">专项名称：</label>
                    <asp:DropDownList  CssClass="inputLB" Width="400px"  ID="zhangxiang3" runat="server"></asp:DropDownList> 
                </li>
                <li><label class="labelblue">专项年份：</label>
                    <input   type="radio"   name="zxnian" id="Radio1"  value="2016" runat="server">2016  
                    <input   type="radio"   name="zxnian" id="Radio2"  value="2017" runat="server">2017
                    <input   type="radio"   name="zxnian" id="Radio3"  value="2018" runat="server" checked="true">2018
                    <input   type="radio"   name="zxnian" id="Radio4"  value="2019" runat="server">2019
                </li>                
                <li><label class="labelblue">课题方向：</label>
                    <asp:TextBox ID="ketifx" CssClass="inputLB" MaxLength="500" Width="600px" runat="server"></asp:TextBox>
                </li>                
                <li><label class="labelblue">实施周期：</label>
                    <asp:TextBox ID="shishizq" CssClass="inputLB" MaxLength="500" Width="600px" runat="server"></asp:TextBox>
                </li>
            </ul>
        </div>
        <%--<li id="difangli"  <%=difangview %><label class="labelblue">地方省级：</label>
            <asp:DropDownList  CssClass="inputLB" Width="200px"  ID="buwensheng" runat="server"></asp:DropDownList> 
        </li>--%>
        <div  id="gongchengli" <%=gongchengview %>>
            <ul>
                <li>
                    <label class="labelblue">所属工程：（政策所属：五大工程，其他）</label>
                    <asp:RadioButtonList ID="gongchengc" runat="server" RepeatColumns="6" style="padding-left:86px;"></asp:RadioButtonList>
                </li>
                <li>                
                    <label class="labelblue">十大领域：（政策所属：十大重点领域）</label>
                    <asp:CheckBoxList ID="hangyec" runat="server" RepeatColumns="5" style="padding-left:86px;"></asp:CheckBoxList>              
                </li>
            </ul>
        </div>
        <div id="zhichidiv" <%=zhichiview %>>
            <ul>
                <li><label class="labelblue">支持地区：</label>
                   <%-- <asp:Button ID="Button1"   runat="server" Text="全选" OnClick="Button1_Click" />
                    <asp:Button ID="Button2"   runat="server" Text="反选" OnClick="Button2_Click" />--%>
                    全选<asp:CheckBox ID="CheckBoxAll" runat="server" onClick="javascript:Check_Uncheck_All(this);" /><br /> 
                    <%--<asp:CheckBoxList ID="CheckBoxListMusicType" runat="server" RepeatColumns="3" RepeatDirection="Horizontal" Width="300"></asp:CheckBoxList> --%>


                    <asp:CheckBoxList ID="gldiqu" name="gldiqu" CssClass="inputLB" Width="600px" RepeatColumns="5"  runat="server"></asp:CheckBoxList>
                </li>
                <li class="danhang"><label class="labelblue">支持类型：</label>
                     <asp:RadioButton ID="RadioButton4" runat="server" class="radio" Text="  有资金支持" GroupName="zijin" /> 
                     <asp:RadioButton ID="RadioButton5" runat="server" class="radio" Text="  没有资金支持"   GroupName="zijin" /> 
           
                    
                </li>
                <%-- <li class="danhang"><label class="labelblue">支持级别：</label>
                     <asp:RadioButton ID="RadioButton6" runat="server" class="radio" Text="  国家中央支持"  GroupName="jibei"/> 
                     <asp:RadioButton ID="RadioButton7" runat="server" class="radio" Text="  部委支持"  GroupName="jibei"/> 
                     <asp:RadioButton ID="RadioButton8" runat="server" class="radio" Text="  地方支持" GroupName="jibei"/>
                     
                </li>--%>
                <li class="danhang"><label class="labelblue">支持对象：</label>
                     <asp:RadioButton ID="jishu1_1" runat="server" class="radio" Text="  园区" GroupName="duixiang"/> 
                     <asp:RadioButton ID="jishu1_2" runat="server" class="radio" Text="  企业"  GroupName="duixiang"/> 
                     <asp:RadioButton ID="jishu1_3" runat="server" class="radio" Text="  科研单位"  GroupName="duixiang"/> 
                     
                </li>
                <li class="danhang"><label class="labelblue">评审方式：</label>
                     <asp:RadioButton ID="RadioButton2" runat="server" class="radio" Text="  评审" GroupName="jishu4_5"/>
                     <asp:RadioButton ID="RadioButton1" runat="server" class="radio" Text="  招投标" GroupName="jishu4_5" />              
                     <asp:RadioButton ID="RadioButton3" runat="server" class="radio" Text="  其他(请注明)" GroupName="jishu4_5"/>&nbsp;&nbsp;
                     <input runat="server" class="igbt7_1 " type="text" id="Text3"  autocomplete="off"/>
                </li>
            </ul>
        </div>
        <br />
        <%--   <li  ><label class="labelblue">政策依据：</label><br />
            <asp:TextBox ID="yiju"   Width="800px" TextMode="MultiLine" Height="100px" runat="server"></asp:TextBox>
        </li>
        <li  ><label class="labelblue">政策/规划目标：</label><br />
             <asp:TextBox ID="mubiao"   Width="800px" TextMode="MultiLine" Height="100px" runat="server"></asp:TextBox>
        </li>--%>
 
        <li><label class="labelblue">有效日期：</label>
            <asp:TextBox ID="youxiaoqi"  CssClass="inputLB" Width="600px" runat="server"></asp:TextBox>
        </li>
    
         
        <li><label class="labelblue">针对行业：</label>                       
              <asp:CheckBoxList ID="hangyecbl" runat="server" RepeatColumns="5"></asp:CheckBoxList>
        </li>
   
        <li><label class="labelblue">原文链接：</label>
            <asp:TextBox ID="zcywdizhi" CssClass="inputLB" MaxLength="500" Width="600px" runat="server"></asp:TextBox>
        </li>
        <li  ><label class="labelblue">政策全文：</label><br />
            <asp:Label ID="content1"  runat="server" Text="" Visible="False"></asp:Label>
            <asp:TextBox ID="content"   Width="800px" TextMode="MultiLine" Height="100px" runat="server"></asp:TextBox>
        </li>
        <li><label class="labelblue"></label>
            <asp:TextBox ID="url" CssClass="inputLB" MaxLength="500" Width="600px" runat="server" Visible="false"></asp:TextBox>
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

<script   language="javascript">   
    function getRadio(evt) {//层级
        var evt = evt || window.event;
        var e = evt.srcElement || evt.target;
        if (e.value == "2") {
            if (document.getElementById('buweili') != null && document.getElementById('buweili') != null) {
                document.getElementById('buweili').style.display = '';
                //document.getElementById('difangli').style.display = 'none';
                //
            }
        } else if (e.value == "3") {
            document.getElementById('buweili').style.display = 'none';
            //document.getElementById('difangli').style.display = '';
            document.getElementById('zhengceli').style.display = 'none';
            document.getElementById('xiangmuli').style.display = 'none';            
            document.getElementById('gongchengli').style.display = 'none';
            document.getElementById('zhichidiv').style.display = '';
        } else {
            document.getElementById('buweili').style.display = 'none';
            //document.getElementById('difangli').style.display = 'none';
            document.getElementById('zhengceli').style.display = 'none';
            document.getElementById('xiangmuli').style.display = 'none';
            document.getElementById('gongchengli').style.display = 'none';
            document.getElementById('zhichidiv').style.display = '';
            
        }
    }
    function getRadiobw(evt) {//部委
        var evt = evt || window.event;
        var e = evt.srcElement || evt.target;
        if (e.value == "1") {//工信部
            if (document.getElementById('gongchengli') != null && document.getElementById('gongchengli') != null) {
                document.getElementById('gongchengli').style.display = '';
                document.getElementById('zhengceli').style.display = 'none';
                document.getElementById('xiangmuli').style.display = 'none';
                document.getElementById('zhichidiv').style.display = '';
            }
        } else if (e.value == "5") {//其它
            document.getElementById('zhengceli').style.display = '';
            document.getElementById('xiangmuli').style.display = '';
            document.getElementById('zhichidiv').style.display = 'none';
            document.getElementById('gongchengli').style.display = 'none';
        } else {//科技部
            document.getElementById('gongchengli').style.display = 'none';
            document.getElementById('zhengceli').style.display = 'none';
            document.getElementById('xiangmuli').style.display = 'none';
            document.getElementById('zhichidiv').style.display = '';
        }
    }
    function getRadiozx(evt) {//专项，非专项
        var evt = evt || window.event;
        var e = evt.srcElement || evt.target;
        if (e.value == "1") {
            if (document.getElementById('xiangmuli') != null && document.getElementById('xiangmuli') != null) {
                document.getElementById('xiangmuli').style.display = '';
                document.getElementById('zhichidiv').style.display = 'none';
            }        
        } else {
            document.getElementById('xiangmuli').style.display = 'none';
            document.getElementById('zhichidiv').style.display = ''; 
            document.getElementById('gongchengli').style.display = 'none';
        }
    } 
    function getRadioxm(evt) {//专项分类
        var evt = evt || window.event;
        var e = evt.srcElement || evt.target;
        if (e.value == "1") {
            if (document.getElementById('zhangxiangli1') != null && document.getElementById('zhangxiangli1') != null) {
                document.getElementById('zhangxiangli1').style.display = '';
                document.getElementById('zhangxiangli2').style.display = 'none';
                document.getElementById('zhangxiangli3').style.display = 'none';
            }
        } else if (e.value == "2") {
            document.getElementById('zhangxiangli1').style.display = 'none';
            document.getElementById('zhangxiangli2').style.display = '';
            document.getElementById('zhangxiangli3').style.display = 'none';
        } else if (e.value == "3") {
            document.getElementById('zhangxiangli1').style.display = 'none';
            document.getElementById('zhangxiangli2').style.display = 'none';
            document.getElementById('zhangxiangli3').style.display = '';
        }
    }
    //全选
    function Check_Uncheck_All(cb) { 
        var cbl = document.getElementById("<%=gldiqu.ClientID%>"); 
        var input = cbl.getElementsByTagName("input"); 
        if (cb.checked) { 
        for (var i = 0; i < input.length; i++) { 
        input[i].checked = true; 
        } 
        } 
        else { 
        for (var i = 0; i < input.length; i++) { 
        input[i].checked = false; 
        } 
        } 
    } 


  </script>   