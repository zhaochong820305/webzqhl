<%@ Page Language="C#" AutoEventWireup="true" CodeFile="projectedit.aspx.cs" Inherits="admin_projectedit" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="css/qiyegl.css" rel="stylesheet" type="text/css" />
	<script charset="utf-8" src="js/kindeditor-all.js"></script>
	<script charset="utf-8" src="js/lang/zh-CN.js"></script>
	<script charset="utf-8" src="js/plugins/code/prettify.js"></script>
    <script src="../js/jquery.js"></script>
    <link rel="stylesheet" href="//apps.bdimg.com/libs/jqueryui/1.10.4/css/jquery-ui.min.css" />
    <script src="//apps.bdimg.com/libs/jquery/1.10.2/jquery.min.js"></script>
    <script src="//apps.bdimg.com/libs/jqueryui/1.10.4/jquery-ui.min.js"></script>    
    <script>
      $(function() {
          $("#tbSDate").datepicker();
          $("#tbEDate").datepicker();
      });
    </script>
    <style>
        .bianji label{ display:inline-block; width:100px; margin-top:10px;}
        .bianji input{ margin-top:10px;}
        .hide {display:none;        }
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
    <script>       
         
        $(document).ready(function () {

            $("#project").click(function () {
                $('#list1').show(); $('#list2').hide(); $('#list3').hide(); $('#list4').hide();
                $('#project').css("color", "blue"); $('#jishu').css("color", "#FFFFFF"); $('#shichang').css("color", "#FFFFFF"); $('#rongzi').css("color", "#FFFFFF");
                return false;
            });
            $("#jishu").click(function () {
                $('#list1').hide(); $('#list2').show(); $('#list3').hide(); $('#list4').hide(); 
                $('#project').css("color", "#FFFFFF"); $('#jishu').css("color", "blue"); $('#shichang').css("color", "#FFFFFF"); $('#rongzi').css("color", "#FFFFFF");
                return false;
            });
            $("#shichang").click(function () {
                $('#list1').hide(); $('#list2').hide(); $('#list3').show(); $('#list4').hide();
                $('#project').css("color", "#FFFFFF"); $('#jishu').css("color", "#FFFFFF"); $('#shichang').css("color", "blue"); $('#rongzi').css("color", "#FFFFFF");
                return false;
            });
            $("#rongzi").click(function () {
                $('#list1').hide(); $('#list2').hide(); $('#list3').hide(); $('#list4').show(); 
                $('#project').css("color", "#FFFFFF"); $('#jishu').css("color", "#FFFFFF"); $('#shichang').css("color", "#FFFFFF"); $('#rongzi').css("color", "blue");
                return false;
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <a href="Project.aspx" class="buttonLB1">返回项目列表</a> 
        &nbsp;&nbsp;<button id="project" <% if (typeid == 1) Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %>  >编项目基本信息</button>  
        &nbsp;&nbsp;<button id="jishu"  <% if (typeid == 2) Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %> >编辑技术信息</button>   
        &nbsp;&nbsp;<button id="shichang"  <% if (typeid == 3) Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %> >编辑市场信息</button>  
        &nbsp;&nbsp;<button id="rongzi"  <% if (typeid == 4) Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %> >编辑融资信息</button>	
         <br>
        <table  class="gridtable"  <% if (typeid == 1) Response.Write("style='display: block'"); else Response.Write("style='display: none'"); %>     id="list1" >
            <tr style="page-break-inside: avoid;">
                <th class="auto-style3" colspan="4">编辑项目基本信息  </th>
               
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style3">选择企业：</th>
                <td colspan="3">
                    <div class="input-group">
<%--&nbsp;<asp:DropDownList ID="ddlCompany" runat="server" Height="22px" Width="246px">
                        </asp:DropDownList>--%>
                        <asp:Label ID="lCompany" runat="server" Text="Label"></asp:Label>
                    </div>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style3">项目名称：</th>
                <td colspan="3">
                    <asp:TextBox ID="tbName" runat="server" CssClass="inputLB" Width="422px"></asp:TextBox>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style3">项目目标：</th>
                <td colspan="3">
                    <asp:TextBox ID="tbMuBiao" runat="server" CssClass="inputLB"  Width="421px"></asp:TextBox>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style3">项目规模(万元)：</th>
                <td colspan="3">
                    <asp:TextBox ID="tbGuiGe" CssClass="inputLB"  runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style3">固定资产投资(万元)：</th>
                <td colspan="3">
                    <asp:TextBox ID="tbGuDing"  CssClass="inputLB" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style3">非固定资产投资(万元)：</th>
                <td colspan="3">
                    <asp:TextBox ID="tbnoGuDing" CssClass="inputLB"  runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style3">开始时间：</th>
                <td class="auto-style2">
                    <asp:TextBox ID="tbSDate" CssClass="inputLB"  runat="server"></asp:TextBox>
                </td>
                <th class="active" style="width: 120px;">结束时间：</th>
                <td class="auto-style1">
                    <asp:TextBox ID="tbEDate" CssClass="inputLB"  runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style3">项目进度(%)：</th>
                <td colspan="3">
                    <asp:TextBox ID="tbJinDu" CssClass="inputLB"  runat="server" Width="420px"></asp:TextBox>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style3">项目性质：</th>
                <td colspan="3">
                    <asp:DropDownList ID="ddlXingZhi" runat="server" Height="22px" Width="246px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style3">军工情况：</th>
                <td colspan="3">
                    <asp:DropDownList ID="ddlJunGong" runat="server" Height="22px" Width="246px">
                    </asp:DropDownList>
                </td>
            </tr>
             <tr style="page-break-inside: avoid;">
                <th class="auto-style3">项目资质：</th>
                <td colspan="3">
                    <asp:Label ID="content1"  runat="server" Text="" Visible="False"></asp:Label>
            <asp:TextBox ID="content" CssClass="inputLB" Width="750px" TextMode="MultiLine" Height="150px" runat="server"></asp:TextBox>
                  <%--  <asp:TextBox ID="tbZiZhi" runat="server" Height="47px" Width="421px"></asp:TextBox>--%>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <td colspan="4" style="text-align: center;">
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" class="buttonLB1" Text="修改" />
                    <asp:Label ID="Label1" runat="server"     ForeColor="#FF3300"></asp:Label>
                </td>
            </tr>
        </table>
    
        
    
        <table  class="gridtable"  <% if (typeid == 2) Response.Write("style='display: block'"); else Response.Write("style='display: none'"); %>  id="list2" >
            <tr style="page-break-inside: avoid;">
                <th class="auto-style3" colspan="2">编辑技术信息</th>
               
            </tr>
            
            <tr style="page-break-inside: avoid;">
                <th class="auto-style3">技术来源：</th>
                <td>
                    <asp:DropDownList ID="ddlLaiYuan" runat="server"  CssClass="inputLB" Height="25px" Width="327px"></asp:DropDownList>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style3">技术地位：</th>
                <td>
                    <asp:DropDownList ID="ddlDiWei" runat="server" CssClass="inputLB"  Height="25px" Width="327px"></asp:DropDownList>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style3">查新情况：</th>
                <td>
                    <asp:TextBox ID="tbChaXin" runat="server" CssClass="inputLB"  Width="421px"></asp:TextBox>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style3">技术壁垒：</th>
                <td>
                    <%--<asp:TextBox ID="tbTuiChuJiZhi" runat="server" Width="422px"></asp:TextBox>--%>
                    <asp:DropDownList ID="ddlBiLei" runat="server" Height="25px" Width="323px"></asp:DropDownList>
                </td>
            </tr>
            
            <tr style="page-break-inside: avoid;">
                <th class="auto-style3">专利/著作权等：</th>
                <td>
                    <asp:TextBox ID="tbZhuZuoQuan" runat="server" CssClass="inputLB" TextMode="MultiLine"   Height="49px" Width="427px"></asp:TextBox>
                </td>
            </tr>
            
            <tr style="page-break-inside: avoid;">
                <th class="auto-style3">研发力量：</th>
                <td>
                    <asp:TextBox ID="tbLiLiang" runat="server"  CssClass="inputLB" Width="421px"></asp:TextBox>
                </td>
            </tr>
            
            <tr style="page-break-inside: avoid;">
                <th class="auto-style3">未来研发方向：</th>
                <td>
                    <asp:TextBox ID="tbYanFaFang" runat="server" CssClass="inputLB"  Width="421px"></asp:TextBox>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <td colspan="2" style="text-align: center;">
                    <asp:Button ID="Button4" runat="server" class="buttonLB1" OnClick="Button4_Click" Text="修改" />
                    <asp:Label ID="Label4" runat="server"     ForeColor="#FF3300"></asp:Label>
                </td>
            </tr>
        </table>
    
         
    
        <table  class="gridtable"   <% if (typeid == 3) Response.Write("style='display: block'"); else Response.Write("style='display: none'"); %>  id="list3" >
            <tr style="page-break-inside: avoid;">
                <th class="auto-style3" colspan="2">编辑市场信息</th>
                
            </tr>
            
            <tr style="page-break-inside: avoid;">
                <th class="auto-style3">细分市场规模(万元)：</th>
                <td>
                    <asp:TextBox   CssClass="inputLB" ID="tbShiGuiMo" runat="server" Width="422px"></asp:TextBox>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style3">本项目所占细分市场份额(%)：</th>
                <td>
                    <asp:TextBox CssClass="inputLB"  ID="tbShiFene" runat="server" Width="421px"></asp:TextBox>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style3">未来市场规模(万元)：</th>
                <td>
                    <asp:TextBox  CssClass="inputLB" ID="tbShiGuoMoWei" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style3">本项目可能占有的市场份额(%)：</th>
                <td>
                    <asp:TextBox CssClass="inputLB"  ID="tbShiFeeWei" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style3">依附其他行业情况：</th>
                <td>
                    <asp:TextBox CssClass="inputLB"  ID="tbYiFuHangYe" runat="server" TextMode="MultiLine" Height="49px" Width="427px"></asp:TextBox>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style3">相关产业政策：</th>
                <td>
                     
                                <asp:CheckBox ID="CheckBox120" runat="server" Text="120" />工业强基
                                <br />
                                <asp:CheckBox ID="CheckBox121" runat="server" Text="121" />工业强基工业转型升级专项 
                                <br />   
                                <asp:CheckBox ID="CheckBox122" runat="server" Text="122" />产业振兴与技改 
                                <br />                               
                                <asp:CheckBox ID="CheckBox123" runat="server" Text="123" /> 专项建设基金
                                <br />
                                <asp:CheckBox ID="CheckBox124" runat="server" Text="124" /> 重点研发计划  
                                <br />
                                <asp:CheckBox ID="CheckBox125" runat="server" Text="125" /> 重大专项  
                                <br />
                                <asp:CheckBox ID="CheckBox126" runat="server" Text="126" /> 创新能力建设基金 
                                <br />
                                <asp:CheckBox ID="CheckBox127" runat="server" Text="127" /> 国家级重点技术平台 
                              
                      
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <td colspan="2" style="text-align: center;">
                    <asp:Button ID="Button2" runat="server" class="buttonLB1" OnClick="Button2_Click" Text="修改" />
                    <asp:Label ID="Label2" runat="server"     ForeColor="#FF3300"></asp:Label>
                    <br />
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <td colspan="2" style="text-align: center;">
                    &nbsp;</td>
            </tr>
        </table>
    
        
    
        <table  class="gridtable"  <% if (typeid == 4) Response.Write("style='display: block'"); else Response.Write("style='display: none'"); %>  id="list4" >
            <tr style="page-break-inside: avoid;">
                <th class="auto-style3" colspan="2">编辑融资信息</th>
                 
            </tr>
             
            <tr style="page-break-inside: avoid;">
                <th class="auto-style3">资金需求规模(万元)：</th>
                <td>
                    <asp:TextBox  CssClass="inputLB" ID="tbZiJinXuQiu" runat="server" Width="422px"></asp:TextBox>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style3">资金用途：</th>
                <td>
                    <asp:TextBox CssClass="inputLB"  ID="tbYongTu" runat="server" Width="421px"></asp:TextBox>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style3">融资规划：</th>
                <td>
                    <asp:TextBox CssClass="inputLB"  ID="tbRongZiGuiHua" runat="server" Width="421px"></asp:TextBox>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style3">回报预期/退出机制：</th>
                <td>
                    <asp:DropDownList ID="ddlTuiChu" runat="server" Height="25px" Width="188px"></asp:DropDownList>
                    <%--<asp:TextBox ID="tbTuiChuJiZhi" runat="server" Width="422px"></asp:TextBox>--%>
                </td>
            </tr>
            
            <tr style="page-break-inside: avoid;">
                <th class="auto-style3">预期收益情况：</th>
                <td>
                    <asp:TextBox CssClass="inputLB"  ID="tbYuQiShou" TextMode="MultiLine" runat="server" Height="49px" Width="427px"></asp:TextBox>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <td colspan="2" style="text-align: center;">
                    <asp:Button ID="Button3" runat="server" class="buttonLB1" OnClick="Button3_Click" Text="修改" />
                    <asp:Label ID="Label3" runat="server"     ForeColor="#FF3300"></asp:Label>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
