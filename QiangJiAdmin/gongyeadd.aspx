<%@ Page Language="C#" AutoEventWireup="true" CodeFile="gongyeadd.aspx.cs" Inherits="QiangJiAdmin_gongyeadd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="css/qiyegl.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="js/themes/default/default.css" />
	<link rel="stylesheet" href="js/plugins/code/prettify.css" />
	<script charset="utf-8" src="js/kindeditor-all.js"></script>
	<script charset="utf-8" src="js/lang/zh-CN.js"></script>
	<script charset="utf-8" src="js/plugins/code/prettify.js"></script>
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
    <div>
    <table class="gridtable">
            <tr style="page-break-inside: avoid;">
                
                <th class="auto-style4">强基产品名称：</th>
                <td  colspan="3">
                    <asp:TextBox ID="pname"   Width="675px"   runat="server"></asp:TextBox>
                </td>
            </tr>
            <%--<tr style="page-break-inside: avoid;">
               
                 <th class="auto-style3">应用场景：</th>
                <td colspan="3" >
                   <asp:TextBox ID="JianJie" runat="server" Width="730px"  Height="47px" TextMode="MultiLine"></asp:TextBox>                    
                </td>
            </tr>--%>
            <%--<tr style="page-break-inside: avoid;">
               
                <th class="auto-style3">标签：</th>
                <td  >
                   <asp:TextBox ID="biaoqian" runat="server" Width="246px"  Height="90px" TextMode="MultiLine"></asp:TextBox>
                    
                </td>
                <th class="auto-style3">多个标签<br>&quot;,号分开</th>
                <td colspan="1" >
                     搜索：<asp:TextBox ID="txtDemo" runat="server" Width="100px"  Height="22px" AutoPostBack="True" OnTextChanged="txtDemo_TextChanged"  ></asp:TextBox>
                     <br>
                     <asp:DropDownList ID="ddlbiaoqian" runat="server" Height="22px" Width="246px" AutoPostBack="True" OnSelectedIndexChanged="ddlbiaoqian_SelectedIndexChanged">
                     </asp:DropDownList>
                     <br><br>
                     <span>
                         添加标签：<asp:TextBox ID="biaoqianadd" runat="server" Width="100px"  Height="22px" ></asp:TextBox>
                         <asp:Button CssClass="buttonLB1" ID="Button17" runat="server" OnClick="Button17_Click" Text="添加标签" />
                         <asp:Label ID="Label14"  runat="server" Text="" ForeColor="#FF3300" ></asp:Label>
                     </span>
                </td>
            </tr>--%>           
            <%--<tr style="page-break-inside: avoid;">   
                <th class="auto-style3"></th>
                <td colspan="3" style="color:red;" >
                     图片、视频、专利、查新报告、评价报告、用户检测报告、使用报告等内容在添加完成后，以编辑的形式添加。
            </tr>--%>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style3">市场价格：</th>
                <td >
                    <asp:TextBox ID="marketprice" Width="246px" runat="server"></asp:TextBox>
                </td>
                <th class="auto-style3">单价：</th>
                <td >
                    <asp:TextBox ID="price" Width="246px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">                
                <th class="auto-style3" >订货号：</th>
                <td class="auto-style1">
                     <asp:TextBox ID="orderno"   Width="246px"   runat="server"></asp:TextBox>
                </td>
                <th class="auto-style3" >型号：</th>
                <td class="auto-style1">
                     <asp:TextBox ID="xinghao"   Width="246px"   runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">                
                <th class="auto-style3" >规格参数：</th>
                <td class="auto-style1">
                     <asp:TextBox ID="guige"   Width="246px"   runat="server"></asp:TextBox>
                </td>
                <th class="auto-style3" >品牌：</th>
                <td class="auto-style1">
                     <asp:TextBox ID="pinpai"   Width="246px"   runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">                
                <th class="auto-style3" >系列：</th>
                <td class="auto-style1">
                     <asp:TextBox ID="xilie"   Width="246px"   runat="server"></asp:TextBox>
                </td>
                <th class="auto-style3" >品类：</th>
                <td class="auto-style1">
                     <asp:TextBox ID="pinlei"   Width="246px"   runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">                
                <th class="auto-style3" >单位：</th>
                <td class="auto-style1">
                     <asp:TextBox ID="danwen"   Width="246px"   runat="server"></asp:TextBox>
                </td>
                <th class="auto-style3" >库存：</th>
                <td class="auto-style1">
                     <asp:TextBox ID="kucun"   Width="246px"   runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">                
                <th class="auto-style3" >工业强基分类：</th>
                <td class="auto-style1">
                     <asp:DropDownList ID="qiangji" runat="server" Height="22px" Width="246px">
                     </asp:DropDownList>
                </td>
                <th class="auto-style3" >产业一条龙：</th>
                <td class="auto-style1">
                     <asp:DropDownList ID="chanye" runat="server" Height="22px" Width="246px">
                     </asp:DropDownList>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                 
                <th class="auto-style3" >所在地：</th>
                <td class="auto-style1">
                     <asp:DropDownList ID="DiZhi" runat="server" Height="22px" Width="246px">
                     </asp:DropDownList>
                </td>
            </tr>
             <tr style="page-break-inside: avoid;">
                <th class="auto-style4"  >十大领域：</th>
                <td class="auto-style2" colspan="3">                    
                    <asp:CheckBoxList ID="lingyu" runat="server" RepeatColumns="4"></asp:CheckBoxList>
                </td>                
            </tr>
            <%--<tr style="page-break-inside: avoid;">
                <th class="auto-style4">技术分类：（可多选）</th>
                <td colspan="3">                    
                    <asp:CheckBoxList ID="YingYongLingYu" runat="server" RepeatColumns="5"></asp:CheckBoxList>
                </td>--%>
            
            
            
            
           <%-- <tr style="page-break-inside: avoid;">
                <th class="auto-style4">成果持人有（编号）：</th>
                <td  >
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" RepeatDirection="Horizontal">
                        <asp:ListItem>企业</asp:ListItem>
                        <asp:ListItem>个人</asp:ListItem>
                    </asp:RadioButtonList>
                    
                   
                  <td colspan="2">  
                     <asp:DropDownList ID="ChiYouRenID" runat="server" Height="22px" Width="246px">
                        </asp:DropDownList>
                    
                   
                </td>
            </tr>--%>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style4">产品详情：</th>
                <td colspan="3" >
                      <%--<asp:TextBox ID="JieShao" runat="server" Width="730px"></asp:TextBox>--%>
                      <asp:Label ID="content1"  runat="server" Text="" Visible="False"></asp:Label>
                      <asp:TextBox ID="content" CssClass="inputLB" Width="670px" TextMode="MultiLine" Height="300px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">                
                <th class="auto-style4"><label>是否首页：</label></th>
                <td  ><asp:CheckBox ID="indexview" runat="server" />
                    </td>
                <th class="auto-style4"><label>重要性：</label></th>
                <td  ><asp:TextBox ID="TextBox10" Width="246px" runat="server"  Text="11"></asp:TextBox>
                    </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style4">展示图上传：</th>
                <td colspan="3">
                    <asp:TextBox ID="pic" runat="server" Width="700px" Visible="false"></asp:TextBox>
                    <asp:FileUpload ID="upfile" class="buttonLB" runat="server" Width="500px" />
            
                </td>
            </tr>
                     
                     
            <tr style="page-break-inside: avoid;">
                <td colspan="4" style="text-align: center;">
                    <asp:Button CssClass="buttonLB1" ID="Button1" runat="server" OnClick="Button1_Click" Text="添加" />
                    <asp:Label ID="Label1" runat="server"    style="text-align: center" ForeColor="#FF3300"></asp:Label>
                   <%--  <a href="Results.aspx"  >返回成果交易</a> --%>
                </td>
            </tr>
        </table>

         <table class="gridtable">
            <tr>
                <th class="active">企业名称：</th>
                <td colspan="3"><asp:TextBox ID="tbname" runat="server" Width="681px"></asp:TextBox>
                    &nbsp;</td>
                
            </tr>
            <tr>
                <th class="active">登录名：</th>
                <td>
                    <asp:TextBox ID="tblogin" runat="server" Width="280px"></asp:TextBox></td>
                <th class="active">密码：</th>
                <td>
                    <asp:TextBox ID="tbpass" runat="server" Width="280px"></asp:TextBox></td>
            </tr>
            <tr>
                <th class="auto-style1">详细地址：</th>
                <td class="auto-style1">
                    <asp:TextBox ID="tbadd" runat="server" Width="280px"></asp:TextBox></td>
                <th class="auto-style1">邮政编码：</th>
                <td class="auto-style1">
                    <asp:TextBox ID="tbzipcode" runat="server" Width="280px"></asp:TextBox></td>
            </tr>
            <tr>
                <th class="active">法人姓名：</th>
                <td>
                    <asp:TextBox ID="tbfaren" runat="server" Width="280px"></asp:TextBox></td>
                <th class="active">法人电话：</th>
                <td>
                    <asp:TextBox ID="tbfarentel" runat="server" Width="280px"></asp:TextBox></td>
            </tr>
            <tr>
                <th class="active">联系人：</th>
                <td>
                    <asp:TextBox ID="tblianxi" runat="server" Width="280px"></asp:TextBox></td>
                <th class="active">联系电话：</th>
                <td>
                    <asp:TextBox ID="tblianxitel" runat="server" Width="280px"></asp:TextBox>
                    <asp:TextBox ID="companyid" runat="server" Width="280px" Visible="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th class="active">经营范围：</th>
                <td colspan="3">
                    <asp:TextBox ID="jingyingfw" runat="server" Width="683px" Height="55px"></asp:TextBox></td>
            </tr>
            <tr>
                <th class="active">地区：</th>
                <td colspan="3">
                    <asp:DropDownList ID="ddldiqu" runat="server"></asp:DropDownList>
                    </td>
            </tr>
            <tr>
                <th class="active">企业性质：</th>
                <td colspan="3">
                    <asp:DropDownList ID="ddlqiyexz" runat="server"></asp:DropDownList></td>
            </tr>
            <tr>
                <th class="active">行业领域：</th>
                <td>
                    <asp:DropDownList ID="hangye" runat="server"   OnSelectedIndexChanged="hangye_SelectedIndexChanged"></asp:DropDownList></td>
                <td id="tdHangYe2ID">
                       <%-- <asp:DropDownList ID="hangye2" runat="server"   OnSelectedIndexChanged="hangye2_SelectedIndexChanged"></asp:DropDownList></td>
                <td id="desc">
                    <asp:Label ID="Label4" runat="server" Width="330px"></asp:Label>--%>
                </td>
            </tr>
            <tr>
                <th class="active">是否上市公司：</th>
                <td colspan="3">
                        <asp:CheckBox ID="ishangshi" runat="server" />     </td>
            </tr>
            <tr>
                <td colspan="4" style="text-align: center">
                    <asp:Button CssClass="buttonLB1" ID="Button21" runat="server" Text="添加信息" OnClick="Button21_Click"/> 
                                   
                    <asp:Label ID="Label15" runat="server" Text=""  style="text-align: center" ForeColor="Red" ></asp:Label>                     
                </td>
            </tr>
        </table>  
    </div>
    </form>
</body>
</html>
