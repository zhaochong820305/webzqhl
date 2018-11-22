<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Resultedit1.aspx.cs" Inherits="admin_Resultedit1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="css/qiyegl.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery.js"></script>
    <link href="css/xialia.css" rel="stylesheet" />
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
    <script>


        $(document).ready(function () {

            $("#project").click(function () {
                $('#list1').show(); $('#list2').hide(); $('#list3').hide(); $('#list4').hide(); $('#list5').hide(); $('#list6').hide(); $('#list7').hide(); $('#list8').hide(); $('#list9').hide(); $('#list10').hide();
                $('#project').css("color", "blue"); $('#jishu').css("color", "#FFFFFF"); $('#shichang').css("color", "#FFFFFF"); $('#rongzi').css("color", "#FFFFFF");
                $('#rongzi5').css("color", "#FFFFFF"); $('#rongzi6').css("color", "#FFFFFF"); $('#rongzi7').css("color", "#FFFFFF"); $('#rongzi8').css("color", "#FFFFFF"); $('#rongzi9').css("color", "#FFFFFF"); $('#rongzi10').css("color", "#FFFFFF"); $('#rongzi11').css("color", "#FFFFFF");
                return false;
            });
            $("#jishu").click(function () {
                $('#list1').hide(); $('#list2').show(); $('#list3').hide(); $('#list4').hide(); $('#list5').hide(); $('#list6').hide(); $('#list7').hide(); $('#list8').hide(); $('#list9').hide(); $('#list10').hide();
                $('#project').css("color", "#FFFFFF"); $('#jishu').css("color", "blue"); $('#shichang').css("color", "#FFFFFF"); $('#rongzi').css("color", "#FFFFFF");
                $('#rongzi5').css("color", "#FFFFFF"); $('#rongzi6').css("color", "#FFFFFF"); $('#rongzi7').css("color", "#FFFFFF"); $('#rongzi8').css("color", "#FFFFFF"); $('#rongzi9').css("color", "#FFFFFF"); $('#rongzi10').css("color", "#FFFFFF"); $('#rongzi11').css("color", "#FFFFFF");
                return false;
            });
            $("#shichang").click(function () {
                $('#list1').hide(); $('#list2').hide(); $('#list3').show(); $('#list4').hide(); $('#list5').hide(); $('#list6').hide(); $('#list7').hide(); $('#list8').hide(); $('#list9').hide(); $('#list10').hide();
                $('#project').css("color", "#FFFFFF"); $('#jishu').css("color", "#FFFFFF"); $('#shichang').css("color", "blue"); $('#rongzi').css("color", "#FFFFFF");
                $('#rongzi5').css("color", "#FFFFFF"); $('#rongzi6').css("color", "#FFFFFF"); $('#rongzi7').css("color", "#FFFFFF"); $('#rongzi8').css("color", "#FFFFFF"); $('#rongzi9').css("color", "#FFFFFF"); $('#rongzi10').css("color", "#FFFFFF"); $('#rongzi11').css("color", "#FFFFFF");
                return false;
            });
            $("#rongzi").click(function () {
                $('#list1').hide(); $('#list2').hide(); $('#list3').hide(); $('#list4').show(); $('#list5').hide(); $('#list6').hide(); $('#list7').hide(); $('#list8').hide(); $('#list9').hide(); $('#list10').hide();
                $('#project').css("color", "#FFFFFF"); $('#jishu').css("color", "#FFFFFF"); $('#shichang').css("color", "#FFFFFF"); $('#rongzi').css("color", "blue");
                $('#rongzi5').css("color", "#FFFFFF"); $('#rongzi6').css("color", "#FFFFFF"); $('#rongzi7').css("color", "#FFFFFF"); $('#rongzi8').css("color", "#FFFFFF"); $('#rongzi9').css("color", "#FFFFFF"); $('#rongzi10').css("color", "#FFFFFF"); $('#rongzi11').css("color", "#FFFFFF");
                return false;
            });
            $("#rongzi5").click(function () {
                $('#list1').hide(); $('#list2').hide(); $('#list3').hide(); $('#list4').hide(); $('#list5').show(); $('#list6').hide(); $('#list7').hide(); $('#list8').hide(); $('#list9').hide(); $('#list10').hide(); $('#list11').hide();
                $('#project').css("color", "#FFFFFF"); $('#jishu').css("color", "#FFFFFF"); $('#shichang').css("color", "#FFFFFF"); $('#rongzi').css("color", "#FFFFFF");
                $('#rongzi5').css("color", "blue"); $('#rongzi6').css("color", "#FFFFFF"); $('#rongzi7').css("color", "#FFFFFF"); $('#rongzi8').css("color", "#FFFFFF"); $('#rongzi9').css("color", "#FFFFFF"); $('#rongzi10').css("color", "#FFFFFF"); $('#rongzi11').css("color", "#FFFFFF");
                return false;
            });
            $("#rongzi6").click(function () {
                $('#list1').hide(); $('#list2').hide(); $('#list3').hide(); $('#list4').hide(); $('#list5').hide(); $('#list6').show(); $('#list7').hide(); $('#list8').hide(); $('#list9').hide(); $('#list10').hide(); $('#list11').hide();
                $('#project').css("color", "#FFFFFF"); $('#jishu').css("color", "#FFFFFF"); $('#shichang').css("color", "#FFFFFF"); $('#rongzi').css("color", "#FFFFFF");
                $('#rongzi5').css("color", "#FFFFFF"); $('#rongzi6').css("color", "blue"); $('#rongzi7').css("color", "#FFFFFF"); $('#rongzi8').css("color", "#FFFFFF"); $('#rongzi9').css("color", "#FFFFFF"); $('#rongzi10').css("color", "#FFFFFF"); $('#rongzi11').css("color", "#FFFFFF");
                return false;
            });
            $("#rongzi7").click(function () {
                $('#list1').hide(); $('#list2').hide(); $('#list3').hide(); $('#list4').hide(); $('#list5').hide(); $('#list6').hide(); $('#list7').show(); $('#list8').hide(); $('#list9').hide(); $('#list10').hide(); $('#list11').hide();
                $('#project').css("color", "#FFFFFF"); $('#jishu').css("color", "#FFFFFF"); $('#shichang').css("color", "#FFFFFF"); $('#rongzi').css("color", "#FFFFFF");
                $('#rongzi5').css("color", "#FFFFFF"); $('#rongzi6').css("color", "#FFFFFF"); $('#rongzi7').css("color", "blue"); $('#rongzi8').css("color", "#FFFFFF"); $('#rongzi9').css("color", "#FFFFFF"); $('#rongzi10').css("color", "#FFFFFF"); $('#rongzi11').css("color", "#FFFFFF");
                return false;
            });
            $("#rongzi8").click(function () {
                $('#list1').hide(); $('#list2').hide(); $('#list3').hide(); $('#list4').hide(); $('#list5').hide(); $('#list6').hide(); $('#list8').show(); $('#list7').hide(); $('#list9').hide(); $('#list10').hide(); $('#list11').hide();
                $('#project').css("color", "#FFFFFF"); $('#jishu').css("color", "#FFFFFF"); $('#shichang').css("color", "#FFFFFF"); $('#rongzi').css("color", "#FFFFFF");
                $('#rongzi5').css("color", "#FFFFFF"); $('#rongzi6').css("color", "#FFFFFF"); $('#rongzi8').css("color", "blue"); $('#rongzi7').css("color", "#FFFFFF"); $('#rongzi9').css("color", "#FFFFFF"); $('#rongzi10').css("color", "#FFFFFF"); $('#rongzi11').css("color", "#FFFFFF");
                return false;
            });
            $("#rongzi9").click(function () {
                $('#list1').hide(); $('#list2').hide(); $('#list3').hide(); $('#list4').hide(); $('#list5').hide(); $('#list6').hide(); $('#list9').show(); $('#list7').hide(); $('#list8').hide(); $('#list10').hide(); $('#list11').hide();
                $('#project').css("color", "#FFFFFF"); $('#jishu').css("color", "#FFFFFF"); $('#shichang').css("color", "#FFFFFF"); $('#rongzi').css("color", "#FFFFFF");
                $('#rongzi5').css("color", "#FFFFFF"); $('#rongzi6').css("color", "#FFFFFF"); $('#rongzi9').css("color", "blue"); $('#rongzi7').css("color", "#FFFFFF"); $('#rongzi8').css("color", "#FFFFFF"); $('#rongzi10').css("color", "#FFFFFF"); $('#rongzi11').css("color", "#FFFFFF");
                return false;
            });
            $("#rongzi10").click(function () {
                $('#list1').hide(); $('#list2').hide(); $('#list3').hide(); $('#list4').hide(); $('#list5').hide(); $('#list6').hide(); $('#list10').show(); $('#list7').hide(); $('#list8').hide(); $('#list9').hide(); $('#list11').hide();
                $('#project').css("color", "#FFFFFF"); $('#jishu').css("color", "#FFFFFF"); $('#shichang').css("color", "#FFFFFF"); $('#rongzi').css("color", "#FFFFFF");
                $('#rongzi5').css("color", "#FFFFFF"); $('#rongzi6').css("color", "#FFFFFF"); $('#rongzi10').css("color", "blue"); $('#rongzi7').css("color", "#FFFFFF"); $('#rongzi8').css("color", "#FFFFFF"); $('#rongzi9').css("color", "#FFFFFF"); $('#rongzi11').css("color", "#FFFFFF");
                return false;
            });
            $("#rongzi11").click(function () {
                $('#list1').hide(); $('#list2').hide(); $('#list3').hide(); $('#list4').hide(); $('#list5').hide(); $('#list6').hide(); $('#list11').show(); $('#list7').hide(); $('#list8').hide(); $('#list9').hide(); $('#list10').hide();
                $('#project').css("color", "#FFFFFF"); $('#jishu').css("color", "#FFFFFF"); $('#shichang').css("color", "#FFFFFF"); $('#rongzi').css("color", "#FFFFFF");
                $('#rongzi5').css("color", "#FFFFFF"); $('#rongzi6').css("color", "#FFFFFF"); $('#rongzi11').css("color", "blue"); $('#rongzi7').css("color", "#FFFFFF"); $('#rongzi8').css("color", "#FFFFFF"); $('#rongzi9').css("color", "#FFFFFF"); $('#rongzi10').css("color", "#FFFFFF");
                return false;
            });
        });

        (function ($) {
            $.fn.extend({
                MultDropList: function (options) {
                    var op = $.extend({ wraperClass: "wraper", width: "150px", height: "200px", data: "", selected: "" }, options);
                    return this.each(function () {
                        var $this = $(this); //指向TextBox
                        var $hf = $(this).next(); //指向隐藏控件存
                        var conSelector = "#" + $this.attr("id") + ",#" + $hf.attr("id");
                        var $wraper = $(conSelector).wrapAll("<div><div></div></div>").parent().parent().addClass(op.wraperClass);

                        var $list = $('<div class="list"></div>').appendTo($wraper);
                        $list.css({ "width": op.width, "height": op.height });
                        //控制弹出页面的显示与隐藏
                        $this.click(function (e) {
                            $(".list").hide();
                            $list.toggle();
                            e.stopPropagation();
                        });

                        $(document).click(function () {
                            $list.hide();
                        });

                        $list.filter("*").click(function (e) {
                            e.stopPropagation();
                        });
                        //加载默认数据
                        $list.append('<ul><li><input type="checkbox" class="selectAll" value="" /><span>全部</span></li></ul>');
                        var $ul = $list.find("ul");

                        //加载json数据
                        var listArr = op.data.split("|");
                        var jsonData;
                        for (var i = 0; i < listArr.length; i++) {
                            jsonData = eval("(" + listArr[i] + ")");
                            $ul.append('<li><input type="checkbox" value="' + jsonData.k + '" /><span>' + jsonData.v + '</span></li>');
                        }

                        //加载勾选项
                        var seledArr;
                        if (op.selected.length > 0) {
                            seledArr = selected.split(",");
                        }
                        else {
                            seledArr = $hf.val().split(",");
                        }

                        $.each(seledArr, function (index) {
                            $("li input[value='" + seledArr[index] + "']", $ul).attr("checked", "checked");

                            var vArr = new Array();
                            $("input[class!='selectAll']:checked", $ul).each(function (index) {
                                vArr[index] = $(this).next().text();
                            });
                            $this.val(vArr.join(","));
                        });
                        //全部选择或全不选
                        $("li:first input", $ul).click(function () {
                            if ($(this).attr("checked")) {
                                $("li input", $ul).attr("checked", "checked");
                            }
                            else {
                                $("li input", $ul).removeAttr("checked");
                            }
                        });
                        //点击其它复选框时，更新隐藏控件值,文本框的值
                        $("input", $ul).click(function () {
                            var kArr = new Array();
                            var vArr = new Array();
                            $("input[class!='selectAll']:checked", $ul).each(function (index) {
                                kArr[index] = $(this).val();
                                vArr[index] = $(this).next().text();
                            });
                            $hf.val(kArr.join(","));
                            $this.val(vArr.join(","));
                        });
                    });
                }
            });
        })(jQuery);
        $(document).ready(function () {
            $("#txtTest").MultDropList({ data: $("#hfddlList").val() });
        });
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <button id="project" <% if (typeid == 1) Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %>>编辑成果交易</button>
        &nbsp;&nbsp;
        <button id="jishu"   <% if (typeid == 2) Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %>>编辑成果持有人</button>
        &nbsp;&nbsp;
         <button id="shichang" <% if (typeid == 3) Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %>>编辑合作方式</button>
        &nbsp;&nbsp;
        <button id="rongzi" <% if (typeid == 4) Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %>>编辑证书</button>
        &nbsp;&nbsp;
        <button id="rongzi5" <% if (typeid == 5) Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %>>编辑图片</button>
        <br>
        
        <button id="rongzi7" <% if (typeid == 7) Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %>>编辑视频</button>
        &nbsp;&nbsp;
        <button id="rongzi9" <% if (typeid == 9) Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %>>编辑专家意见</button>
        &nbsp;&nbsp;
        <button id="rongzi8" <% if (typeid == 8) Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %>>编辑评价结论</button>
        &nbsp;&nbsp;
        <button id="rongzi10" <% if (typeid == 10) Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %>>编辑详细说明</button>
        &nbsp;&nbsp;

         <button id="rongzi11" <% if (typeid == 11) Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %>>编辑项目信息</button>
        &nbsp;&nbsp;
        <br>
       <%-- <a class='buttonLB1 button2'  href="Resultedit.aspx?type=1&id=<%=cid %>">返回成果交易</a>&nbsp; 
         &nbsp;&nbsp;--%>
        <a class='buttonLB1 button2'  href="Results.aspx">返回成果列表</a>&nbsp; 
    <table class="gridtable"  <% if (typeid == 1) Response.Write("style='display: block'"); else Response.Write("style='display: none'"); %> id="list1">
            <tr style="page-break-inside: avoid;">
                
                <th class="auto-style4">成果名称：</th>
                <td colspan="3">
                    <asp:TextBox ID="RName" Width="730px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
               
                <th class="auto-style3">应用场景：</th>
                <td colspan="3" >
                   <asp:TextBox ID="JianJie" runat="server" Width="730px"  Height="50px" TextMode="MultiLine"></asp:TextBox>
                    
                </td>
            </tr>
           <%-- <tr style="page-break-inside: avoid;">
               
                <th class="auto-style3">标签：</th>
                <td  >
                   <asp:TextBox ID="biaoqian" runat="server" Width="300px"  Height="90px" TextMode="MultiLine"></asp:TextBox>
                    
                </td>
                <th class="auto-style3">多个标签<br>&quot;,号分开</th>
                <td colspan="1" >
                   
                     <br><br>
                     <span>
                        
                     </span>
                </td>
            </tr>--%>
            <tr>
                <th>标签
                <td> <asp:HiddenField ID="hfddlList" runat="server" Value='{k:1,v:"南京"}|{k:2,v:"上海"}|{k:3,v:"扬州"}|{k:4,v:"苏州"}|{k:5,v:"无锡"}|{k:6,v:"常州"}|{k:7,v:"盐城"}|{k:8,v:"徐州"}|{k:9,v:"泰州"}|{k:10,v:"淮安"}' />

                        <div class="testContainer">
           
                            <div style="margin-left: 8px; height: 30px;">
                                <asp:Label ID="biaoqian1" runat="server" Width="300px"></asp:Label>
                                <asp:TextBox ID="txtTest" runat="server" Width="300px"></asp:TextBox>
                                <asp:HiddenField ID="hfTest" runat="server" Value="3,5" />
                            </div>
                        </div> 
                <th>添标签
                <td> <asp:TextBox ID="biaoqianadd" runat="server" Width="100px"  Height="22px" ></asp:TextBox>
                         <asp:Button CssClass="buttonLB1" ID="Button17" runat="server" OnClick="Button17_Click" Text="添加标签" />
              <asp:DropDownList ID="ddlbiaoqian" runat="server" Height="22px" Width="246px" AutoPostBack="True" OnSelectedIndexChanged="ddlbiaoqian_SelectedIndexChanged" Visible="false">
                     </asp:DropDownList>
                    </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style4">成果介绍：</th>
                <td colspan="3" >
                     <%--<asp:TextBox ID="JieShao" runat="server" Width="730px"></asp:TextBox>--%>
                     <asp:Label ID="content1"  runat="server" Text="" Visible="False"></asp:Label>
                     <asp:TextBox ID="content" CssClass="inputLB" Width="730px" TextMode="MultiLine" Height="150px" runat="server"></asp:TextBox>
                     
                </td>
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
                <th class="auto-style4"  >成果所属单位性质：</th>
                <td class="auto-style2">
                     <asp:DropDownList ID="DanWeiXingZhi" runat="server" Height="22px" Width="246px">
                        </asp:DropDownList>
                </td>
                <th class="auto-style3" >成果所在地：</th>
                <td class="auto-style1">
                     <asp:DropDownList ID="DiZhi" runat="server" Height="22px" Width="246px">
                        </asp:DropDownList>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style4"  >应用行业：</th>
                <td class="auto-style2"  colspan="3">
                     <%--<asp:DropDownList ID="hangye" runat="server" Height="22px" Width="246px">
                        </asp:DropDownList>--%>
                     <asp:CheckBoxList ID="hangyec" runat="server" RepeatColumns="5" ></asp:CheckBoxList>
                </td>
               
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style4">技术分类：（可多选）</th>
                <td colspan="3">                    
                    <asp:CheckBoxList ID="YingYongLingYu" runat="server" RepeatColumns="5"  ></asp:CheckBoxList>
                </td>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style3">上马需配套资金（万元）：</th>
                <td colspan="3">
                    <asp:TextBox ID="ZiJin" Width="246px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <%--<tr style="page-break-inside: avoid;">
                <th class="auto-style4">专利：</th>
                <td >
                    <asp:CheckBox ID="ZhuanLi" runat="server" /> 选择为有，不选为无
                </td>
            
                <th class="auto-style3">评价报告：</th>
                <td >
                   <asp:CheckBox ID="Pingjia" runat="server" /> 选择为有，不选为无
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style4">查新报告：</th>
                <td colspan="3">
                     <asp:CheckBox ID="ChaXin" runat="server" /> 选择为有，不选为无
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style4">检测报告：</th> 
                <td colspan="3">
                     <asp:CheckBox ID="JianCe" runat="server" /> 选择为有，不选为无
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style4">用户使用报告：</th>
                <td colspan="3">
                    <asp:CheckBox ID="ShiYongBao" runat="server" /> 选择为有，不选为无
                </td>
            </tr>--%>
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
            <%--<tr style="page-break-inside: avoid;">
                <th class="auto-style4">成果持人有（编号）：</th>
                <td >
                    <asp:RadioButtonList ID="1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" RepeatDirection="Horizontal">
                        <asp:ListItem>企业</asp:ListItem>
                        <asp:ListItem>个人</asp:ListItem>
                    </asp:RadioButtonList>
                    <br />
              
                    <asp:DropDownList ID="2" runat="server" Height="22px" Width="246px">
                        </asp:DropDownList>
                </td>
                <th class="auto-style4">客户经理：</th>
                <td >
                    
                    <asp:DropDownList ID="yewu" runat="server" Height="22px" Width="246px">
                        </asp:DropDownList>
                </td>
            </tr>--%>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style4">成果交易状态：</th>
                <td  >
                 
                    <asp:DropDownList ID="JiaoYiState" runat="server" Height="22px" Width="246px">
                        </asp:DropDownList>
                </td>
                <th class="auto-style4">                <label>发布到首页？：</label></th>
                <td  ><asp:CheckBox ID="indexview" runat="server" /> </td>       
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style4">业务员：</th>
                <td  >
                 
                    <asp:DropDownList ID="yewu" runat="server" Height="22px" Width="246px">
                        </asp:DropDownList>
                </td>
                <th class="auto-style4">                <label> </label></th>
                <td  > </td>       
            </tr>
             <tr style="page-break-inside: avoid;">
                <th class="auto-style4">重要性：</th>
                <td>                 
                    <asp:DropDownList ID="zhongyao" runat="server" Height="22px" Width="246px">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <th class="auto-style4">完整度：</th>
                <td> <asp:DropDownList ID="wanzheng" runat="server" Height="22px" Width="246px">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                     </asp:DropDownList> </td>       
            </tr>
            <tr style="page-break-inside: avoid;">
                <td colspan="4" style="text-align: center;">
                    <asp:Button CssClass="buttonLB1" ID="Button1" runat="server" OnClick="Button1_Click" Text="修改" />
                    <asp:Label ID="Label1" runat="server"    style="text-align: center" ForeColor="#FF3300"></asp:Label>
                  <%--  <a href="Results.aspx" class="buttonLB1">返回成果交易</a>--%>
                </td>
            </tr>
        </table>

        <table class="gridtable" <% if (typeid == 2) Response.Write("style='display: block'"); else Response.Write("style='display: none'"); %> id="list2">
               <%-- <tr>
                    <th class="active" height="30px">成果合作方式信息： <a href="ChiYouRenAdd.aspx?cid=<%=cid%>&op=add" class="buttonLB1">添加</a>
                        <asp:Label ID="Label2" runat="server"></asp:Label>
                    <tr>
                        <th class="active">&nbsp;<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField DataField="cname" HeaderText="成果持有人"  />
                                <asp:BoundField DataField="CLianXi" HeaderText="联系人" />
                                <asp:BoundField DataField="Tel" HeaderText="电话"  />
                                <asp:BoundField DataField="email" HeaderText="邮箱" />
                                <asp:BoundField DataField="addr" HeaderText="地址"  />
                                <asp:BoundField DataField="update" HeaderText="收录时间" />
                                <asp:TemplateField HeaderText="操作">
                                    <ItemTemplate>
                                       
                                        <a href="ChiYouRenAdd.aspx?id=<%# Eval("ID") %>&op=kan&cid=<%=cid%>">查看</a>
                                        <a href="ChiYouRenAdd.aspx?id=<%# Eval("ID") %>&op=edit&cid=<%=cid%>">编辑</a>
                                        <asp:LinkButton ID="sc" runat="server" CommandArgument='<%# Eval("ID") %>' OnClientClick="if(confirm(&quot;确定要删除该成果持有人数据么?&quot;)==false)return false;" OnCommand="sc_Command">删除</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </tr>--%>
                    <tr>
                        <th class="active" height="30px">
                            请选择成果持有人：
                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" RepeatDirection="Horizontal">
                                <asp:ListItem>企业</asp:ListItem>
                                <asp:ListItem>个人</asp:ListItem>
                             </asp:RadioButtonList>
                             企业关键字：<asp:TextBox ID="TextBox1" Width="246px" runat="server" Text="" AutoPostBack="True" OnTextChanged="TextBox1_TextChanged" ></asp:TextBox><br />
                             个人关键字：<asp:TextBox ID="TextBox2" Width="246px" runat="server" Text="" AutoPostBack="True" OnTextChanged="TextBox2_TextChanged" ></asp:TextBox>
                             <br><asp:DropDownList ID="ChiYouRenID" runat="server" Height="22px" Width="246px">
                             </asp:DropDownList>
                    <tr>
                        <td class="active" colspan="4" style="text-align: center"> 
                             <asp:Button ID="Button3" runat="server" CssClass="buttonLB1" Text="修改成果持有人信息" OnClick="Button3_Click" />
                             <asp:Label ID="Label2" runat="server" Text="" Style="text-align: center" ForeColor="Red"></asp:Label></td></tr>
            </table>

            <table class="gridtable" <% if (typeid == 3) Response.Write("style='display: block'"); else Response.Write("style='display: none'"); %> id="list3">
                    <tr>
                        <th class="active" height="30px" colspan="4">合作方式信息
                        <asp:Label ID="Label8" runat="server"></asp:Label>
                    <tr>
                        <td class="active">合作方式<td>&nbsp;<asp:CheckBox ID="hezuotype1" runat="server" />技术转让
                        <td>合作费用：</td><td><asp:TextBox ID="hezuocost1" Width="246px" runat="server" Text="0"></asp:TextBox>万元</td>
                    </tr>
                    <tr>
                        <td class="active"><td>&nbsp;<asp:CheckBox ID="hezuotype2" runat="server" />独家授权
                        <td>合作费用：</td><td><asp:TextBox ID="hezuocost2" Width="246px" runat="server" Text="0"></asp:TextBox>万元</td>
                    </tr>
                    <tr>
                        <td class="active"><td>&nbsp;<asp:CheckBox ID="hezuotype3" runat="server" />非独家授权
                        <td>合作费用：</td><td><asp:TextBox ID="hezuocost3" Width="246px" runat="server" Text="0"></asp:TextBox>万元</td>
                    </tr>
                    <tr>
                        <td class="active"><td>&nbsp;<asp:CheckBox ID="hezuotype4" runat="server" />技术入股
                        <td></td><td></td>
                    </tr>
                    <tr>
                        <td class="active" colspan="4" style="text-align: center"> 
                             <asp:Button ID="Button2" runat="server" CssClass="buttonLB1" Text="修改合作信息" OnClick="Button7_Click" />
                             <asp:Label ID="Label4" runat="server" Text="" Style="text-align: center" ForeColor="Red"></asp:Label></td></tr>
            </table>
           
            <table class="gridtable" <% if (typeid == 4) Response.Write("style='display: block'"); else Response.Write("style='display: none'"); %> id="list4">
                <tr>
                    <th class="active" height="30px">成果证书信息： <a href="zhengshuAdd.aspx?cid=<%=cid%>&op=add" class="buttonLB1">添加</a> <a href="zhengshulist.aspx?cid=<%=cid%>&op=add" class="buttonLB1">全部证书</a>
                        <asp:Label ID="Label3" runat="server"></asp:Label>
                    <tr>
                        <th class="active">&nbsp;<asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" >
                            <Columns>
                             <%--   <asp:BoundField DataField="cgno" HeaderText="成果编号"  />--%>
                                <asp:BoundField DataField="typename" HeaderText="证书类别" />
                                <asp:BoundField DataField="zhengshuname" HeaderText="证书名称"  />
                                <asp:BoundField DataField="zhengshuno" HeaderText="证书编号" />
                                <asp:BoundField DataField="zhengshufile" HeaderText="证书文件"  />
                                <asp:BoundField DataField="update" HeaderText="收录时间" DataFormatString="{0:yyyy-MM-dd}"  />
                                <asp:TemplateField HeaderText="操作">
                                    <ItemTemplate>
                                        <%--<asp:LinkButton ID="bj" runat="server" CommandArgument='<%# Eval("ID") %>' OnCommand="bj_Command">报表</asp:LinkButton>--%>
                                        <a href="ZhengshuAdd.aspx?id=<%# Eval("ID") %>&op=kan&cid=<%=cid%>">查看</a>
                                        <a href="ZhengshuAdd.aspx?id=<%# Eval("ID") %>&op=edit&cid=<%=cid%>">编辑</a>
                                        <asp:LinkButton ID="zs" runat="server" CommandArgument='<%# Eval("ID") %>' OnClientClick="if(confirm(&quot;确定要删除该证书数据么?&quot;)==false)return false;" OnCommand="ZS_Command">删除</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </tr>
         </table>
        
        <table class="gridtable" <% if (typeid == 5) Response.Write("style='display: block'"); else Response.Write("style='display: none'"); %> id="list5">
                <tr>
                    <th class="active" height="30px">图片信息：  <button id="rongzi6" <% if (typeid == 5) Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %>>添加图片</button>
                        <asp:Label ID="Label5" runat="server"></asp:Label>
                    <tr>
                        <th class="active">&nbsp;<asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField DataField="FileName" HeaderText="图片地址"  />
                                <asp:BoundField DataField="text" HeaderText="图片介绍" />
                                <asp:BoundField DataField="datetime" HeaderText="上传时间" />
                                <asp:BoundField DataField="viewindex" HeaderText="是否展示" />
                                <asp:TemplateField HeaderText="操作">
                                    <ItemTemplate>
                                        <%--<asp:LinkButton ID="bj" runat="server" CommandArgument='<%# Eval("ID") %>' OnCommand="bj_Command">报表</asp:LinkButton>--%>
                                        <a href="<%# Eval("FileName") %>" target="_blank">查看</a>
                                        <%--<a href="ZhengshuAdd.aspx?id=<%# Eval("ID") %>&op=edit&cid=<%=cid%>">编辑</a>--%>
                                        <asp:LinkButton ID="zs" runat="server" CommandArgument='<%# Eval("ID") %>' OnClientClick="if(confirm(&quot;确定要删除该图片数据么?&quot;)==false)return false;" OnCommand="pic_Command">删除</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </tr>
         </table>

         <%--上传附件--%>
         <table class="gridtable" <% if (typeid == 6) Response.Write("style='display: block'"); else Response.Write("style='display: none'"); %>     id="list6" >
             
            <tr style="page-break-inside: avoid;">
                <th class="auto-style4">附件上传：</th>
                <td colspan="3">
                    <asp:TextBox ID="pic" runat="server" Width="700px" Visible="false"></asp:TextBox>
                    <asp:FileUpload ID="upfile" class="buttonLB" runat="server" Width="500px" />
            
                </td>
            </tr>
            <%--<tr style="page-break-inside: avoid;">
                <th class="auto-style4">图片显示：</th>
                <td colspan="3">
                     <asp:Image ID="imgh" runat="server" Height="100px" Width="374px" />
                </td>
            </tr>--%>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style4">图片简介：</th>
                <td colspan="3">
                      <asp:TextBox ID="text" runat="server" Width="700px" Height="50px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style4">展示图：</th>
                <td colspan="3">                    
                     <asp:CheckBox ID="viewindex" runat="server"/>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <td colspan="4" style="text-align: center;">
                    <asp:Button CssClass="buttonLB1" ID="Button6" runat="server" OnClick="Button6_Click" Text=" 上 传 " />
                    <asp:Label ID="Label6" runat="server"    style="text-align: center" ForeColor="#FF3300"></asp:Label>
                   <%-- <a href="Results.aspx" class="buttonLB1">返回成果交易</a>--%>
                </td>
            </tr>
        </table>

         <%--上传附件--%>
         <table class="gridtable" <% if (typeid ==7) Response.Write("style='display: block'"); else Response.Write("style='display: none'"); %>     id="list7" >
           
            <tr style="page-break-inside: avoid;">
                <th class="auto-style4">附件上传：</th>
                <td colspan="3">
                     <asp:TextBox ID="voidfile" runat="server" Width="700px" Visible="false"></asp:TextBox>
                    <asp:FileUpload ID="FileUpload1" class="buttonLB" runat="server" Width="500px" />
            
                </td>
            </tr>
            
            <tr style="page-break-inside: avoid;">
                <th class="auto-style4">视频简介：</th>
                <td colspan="3">
                      <asp:TextBox ID="voidtext" runat="server" Width="700px" Height="50px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <td colspan="4" style="text-align: center;">
                    <asp:Button CssClass="buttonLB1" ID="Button4" runat="server" OnClick="Button4_Click" Text=" 修改 " />
                    <asp:Label ID="Label7" runat="server"    style="text-align: center" ForeColor="#FF3300"></asp:Label>
                    <%--<a href="Results.aspx" class="buttonLB1">返回成果交易</a>--%>
                </td>
            </tr>
        </table>
        <table class="gridtable" <% if (typeid ==8) Response.Write("style='display: block'"); else Response.Write("style='display: none'"); %>     id="list8" >
           
            <tr style="page-break-inside: avoid;">
                <th class="auto-style4">综合评分：</th>
                <td colspan="3">
                    <asp:TextBox ID="zongpingfen" runat="server" Width="700px" ></asp:TextBox>
                    
                </td>
            </tr>


            
            <tr style="page-break-inside: avoid;">
                <th class="auto-style4">评价结论：</th>
                <td colspan="3">
                      <asp:TextBox ID="pingjiajielun" runat="server" Width="700px" Height="50px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
              <tr style="page-break-inside: avoid;">
                <th class="auto-style4">主任委员签字：</th>
                <td >
                    <asp:TextBox ID="zhuren" runat="server" Width="280px" ></asp:TextBox>
                    
                </td>
                <th class="auto-style4">副主任委员签字：</th>
                <td >
                    <asp:TextBox ID="fuzhuren" runat="server" Width="280px" ></asp:TextBox>
                    
                </td>
            </tr>

            <tr style="page-break-inside: avoid;">
                <th class="auto-style4">评价日期：</th>
                <td colspan="3">
                    <asp:TextBox ID="pingdate" runat="server" Width="280px" ></asp:TextBox>
                    
                </td>
            </tr>
             
            <tr style="page-break-inside: avoid;">
                <td colspan="4" style="text-align: center;">
                    <asp:Button CssClass="buttonLB1" ID="Button5" runat="server" OnClick="Button5_Click" Text=" 修改 " />
                    <asp:Label ID="Label9" runat="server"    style="text-align: center" ForeColor="#FF3300"></asp:Label>
                    <%--<a href="Results.aspx" class="buttonLB1">返回成果交易</a>--%>
                </td>
            </tr>
        </table>
        <table class="gridtable" <% if (typeid == 9) Response.Write("style='display: block'"); else Response.Write("style='display: none'"); %> id="list9">
                <tr>
                    <th class="active" height="30px">专家咨询意见：  <a href="zhnanjiayiAdd.aspx?cid=<%=cid%>&op=add" class="buttonLB1">添加</a>
                        <asp:Label ID="Label10" runat="server"></asp:Label>
                    <tr>
                        <th class="active">&nbsp;<asp:GridView ID="GridView9" runat="server" AutoGenerateColumns="False">
                            <Columns>
                                
                                <asp:BoundField DataField="XingMing" HeaderText="专家姓名" />
                                <asp:BoundField DataField="PingFen" HeaderText="专家评分"  />
                                <asp:BoundField DataField="updates" HeaderText="上传时间" />
                                <asp:TemplateField HeaderText="操作">
                                    <ItemTemplate>
                                        <%--<asp:LinkButton ID="bj" runat="server" CommandArgument='<%# Eval("ID") %>' OnCommand="bj_Command">报表</asp:LinkButton>--%>
                                        <a href="zhnanjiayiAdd.aspx?id=<%# Eval("ID") %>&op=kan&cid=<%=cid%>">查看</a>
                                        <a href="zhnanjiayiAdd.aspx?id=<%# Eval("ID") %>&op=edit&cid=<%=cid%>">编辑</a>
                                        <asp:LinkButton ID="zs" runat="server" CommandArgument='<%# Eval("ID") %>' OnClientClick="if(confirm(&quot;确定要删除该专家咨询意见数据么?&quot;)==false)return false;" OnCommand="fen_Command">删除</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </tr>
         </table>
         <table class="gridtable" <% if (typeid ==10) Response.Write("style='display: block'"); else Response.Write("style='display: none'"); %>     id="list10" >
            <tr style="page-break-inside: avoid;">
                <th class="auto-style4">开发的意义：</th>
                <td colspan="3">
                      <asp:TextBox ID="yiyi" runat="server" Width="700px" Height="50px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style4">先进性：</th>
                <td colspan="3">
                      <asp:TextBox ID="xianjin" runat="server" Width="700px" Height="50px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style4">成熟度：</th>
                <td colspan="3">
                      <asp:TextBox ID="chengshu" runat="server" Width="700px" Height="50px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style4">推广应用情况：</th>
                <td colspan="3">
                      <asp:TextBox ID="yingyong" runat="server" Width="700px" Height="50px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <td colspan="4" style="text-align: center;">
                    <asp:Button CssClass="buttonLB1" ID="Button10" runat="server" OnClick="Button10_Click" Text=" 修改 " />
                    <asp:Label ID="Label11" runat="server"    style="text-align: center" ForeColor="#FF3300"></asp:Label>
                    <%--<a href="Results.aspx" class="buttonLB1">返回成果交易</a>--%>
                </td>
            </tr>
        </table>
         
         <table class="gridtable" <% if (typeid ==11) Response.Write("style='display: block'"); else Response.Write("style='display: none'"); %>     id="list11" >
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
                    <asp:Label ID="Label13"  runat="server" Text="" Visible="False"></asp:Label>
            <asp:TextBox ID="TextBox3" CssClass="inputLB" Width="750px" TextMode="MultiLine" Height="150px" runat="server"></asp:TextBox>
                  <%--  <asp:TextBox ID="tbZiZhi" runat="server" Height="47px" Width="421px"></asp:TextBox>--%>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <td colspan="4" style="text-align: center;">
                    <asp:Button CssClass="buttonLB1" ID="Button11" runat="server" OnClick="Button11_Click" Text=" 修改 " />
                    <asp:Label ID="Label12" runat="server"    style="text-align: center" ForeColor="#FF3300"></asp:Label>
                    <%--<a href="Results.aspx" class="buttonLB1">返回成果交易</a>--%>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
