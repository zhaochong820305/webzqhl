<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Resultadd.aspx.cs" Inherits="admin_cgjyadd" %>

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
                
                <th class="auto-style4">成果名称：</th>
                <td  colspan="3">
                    <asp:TextBox ID="RName"   Width="730px"   runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
               
                 <th class="auto-style3">应用场景：</th>
                <td colspan="3" >
                   <asp:TextBox ID="JianJie" runat="server" Width="730px"  Height="47px" TextMode="MultiLine"></asp:TextBox>
                    
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
               
                <th class="auto-style3">标签：</th>
                <td  >
                   <asp:TextBox ID="biaoqian" runat="server" Width="300px"  Height="90px" TextMode="MultiLine"></asp:TextBox>
                    
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
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style4">成果介绍：</th>
                <td colspan="3" >
                      <%--<asp:TextBox ID="JieShao" runat="server" Width="730px"></asp:TextBox>--%>
                      <asp:Label ID="content1"  runat="server" Text="" Visible="False"></asp:Label>
                      <asp:TextBox ID="content" CssClass="inputLB" Width="730px" TextMode="MultiLine" Height="300px" runat="server"></asp:TextBox>
                </td>
            <tr style="page-break-inside: avoid;">   
                <th class="auto-style3"></th>
                <td colspan="3" style="color:red;" >
                     图片、视频、专利、查新报告、评价报告、用户检测报告、使用报告等内容在添加完成后，以编辑的形式添加。
           </tr>
           <%-- <tr style="page-break-inside: avoid;">   
                <th class="auto-style3">图片介绍：</th>
                <td colspan="3" >
                    <asp:TextBox ID="TuPian" runat="server" Width="730px"></asp:TextBox>
                </td>
            </tr>
        
            <tr style="page-break-inside: avoid;">
                <th class="auto-style5">视频介绍：</th>
                <td class="auto-style6" colspan="3">
                    <asp:TextBox ID="ShiPin" runat="server" Width="730px"></asp:TextBox>
                </td>--%>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style3">成果阶段：</th>
                <td class="auto-style6">
                   
                     <asp:DropDownList ID="JieDuan" runat="server" Height="22px" Width="246px">
                        </asp:DropDownList>
                </td>
                <th class="auto-style3" >强基分类：</th>
                <td class="auto-style1">
                     <asp:DropDownList ID="webtype" runat="server" Height="22px" Width="246px">
                        </asp:DropDownList>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style4"  >成果类别：</th>
                <td class="auto-style2">
                     <asp:DropDownList ID="LeiBie" runat="server" Height="22px" Width="246px">
                        </asp:DropDownList>
                </td>
                <th class="auto-style3" >成果所在地：</th>
                <td class="auto-style1">
                     <asp:DropDownList ID="DiZhi" runat="server" Height="22px" Width="246px">
                        </asp:DropDownList>
                </td>
            </tr>
             <tr style="page-break-inside: avoid;">
                <th class="auto-style4"  >应用领域：</th>
                <td class="auto-style2" colspan="3">
                    <%-- <asp:DropDownList ID="hangye" runat="server" Height="22px" Width="246px">
                        </asp:DropDownList>--%>
                    <asp:CheckBoxList ID="hangyec" runat="server" RepeatColumns="5"></asp:CheckBoxList>
                </td>
                
            </tr>
            <%--<tr style="page-break-inside: avoid;">
                <th class="auto-style4">技术分类：（可多选）</th>
                <td colspan="3">                    
                    <asp:CheckBoxList ID="YingYongLingYu" runat="server" RepeatColumns="5"></asp:CheckBoxList>
                </td>--%>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style3">上马需配套资金（万元）：</th>
                <td colspan="3">
                    <asp:TextBox ID="ZiJin" Width="246px" runat="server"></asp:TextBox>
                </td>
            </tr>
            
            <tr style="page-break-inside: avoid;">
                <th class="auto-style4">成果水平：</th>
                <td >
                    <asp:DropDownList ID="ShuiPing" runat="server" Height="22px" Width="246px">
                        </asp:DropDownList>
                </td>
                <th class="auto-style4">成果密级：</th>
                <td >
                    
                    <asp:DropDownList ID="MiJi" runat="server" Height="22px" Width="246px">
                        </asp:DropDownList>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style4">成果属性：</th>
                <td >
                    <asp:DropDownList ID="ShuXing" runat="server" Height="22px" Width="246px">
                        </asp:DropDownList>
                 
                </td>
                <th class="auto-style4">成果创新形式：</th>
                <td >
                    <asp:DropDownList ID="ChuangXinXingShi" runat="server" Height="22px" Width="246px">
                        </asp:DropDownList>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style4">应用情况：</th>
                <td >
                     
                    <asp:DropDownList ID="YingYongQingKuang" runat="server" Height="22px" Width="246px">
                        </asp:DropDownList>
                </td>
                <th class="auto-style4">未应用原因：</th>
                <td >
                    <asp:DropDownList ID="NoYingYYin" runat="server" Height="22px" Width="246px">
                        </asp:DropDownList>
                </td>
            </tr>
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
                <th class="auto-style4">成果交易状态：</th>
                <td>
                 
                    <asp:DropDownList ID="JiaoYiState" runat="server" Height="22px" Width="246px">
                        </asp:DropDownList>
                </td>
                <th class="auto-style4"><label>首页位置：</label></th>
                <td  ><%--<asp:CheckBox ID="indexview" runat="server" />--%>
                    <asp:DropDownList ID="indexlocation" runat="server" Height="22px" Width="246px">
                        </asp:DropDownList> </td>
            </tr>
    
                    <tr>
                        <th class="active" height="30px" colspan="4">合作方式信息
                        <asp:Label ID="Label8" runat="server"></asp:Label>
                    <tr>
                        <th class="active">合作方式<td>&nbsp;<asp:CheckBox ID="hezuotype1" runat="server" />技术转让
                        <th>合作费用：</th><td><asp:TextBox ID="hezuocost1" Width="246px" runat="server" Text="0"></asp:TextBox>万元</td>
                    </tr>
                    <tr>
                        <th class="active"><td>&nbsp;<asp:CheckBox ID="hezuotype2" runat="server" />独家授权
                        <th>合作费用：</th><td><asp:TextBox ID="hezuocost2" Width="246px" runat="server" Text="0"></asp:TextBox>万元</td>
                    </tr>
                    <tr>
                        <th class="active"><td>&nbsp;<asp:CheckBox ID="hezuotype3" runat="server" />非独家授权
                        <th>合作费用：</th><td><asp:TextBox ID="hezuocost3" Width="246px" runat="server" Text="0"></asp:TextBox>万元</td>
                    </tr>
                    <tr>
                        <th class="active"><td>&nbsp;<asp:CheckBox ID="hezuotype4" runat="server" />技术入股
                        <td></td><td></td>
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
    </div>
    </form>
</body>
</html>
