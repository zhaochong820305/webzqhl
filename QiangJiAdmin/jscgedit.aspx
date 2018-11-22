<%@ Page Language="C#" AutoEventWireup="true" CodeFile="jscgedit.aspx.cs" Inherits="admin_jscgedit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="css/qiyegl.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery.js"></script>
    <script>       
         
        $(document).ready(function () {

            $("#project").click(function () {
                $('#list1').show(); $('#list2').hide(); $('#list3').hide(); $('#list4').hide(); $('#list5').hide(); $('#list6').hide();
                $('#project').css("color", "blue"); $('#jishu').css("color", "#FFFFFF"); $('#shichang').css("color", "#FFFFFF"); $('#rongzi').css("color", "#FFFFFF");
                $('#rongzi1').css("color", "#FFFFFF"); $('#rongzi2').css("color", "#FFFFFF");
                return false;
            });
            $("#jishu").click(function () {
                $('#list1').hide(); $('#list2').show(); $('#list3').hide(); $('#list4').hide(); $('#list5').hide(); $('#list6').hide();
                $('#project').css("color", "#FFFFFF"); $('#jishu').css("color", "blue"); $('#shichang').css("color", "#FFFFFF"); $('#rongzi').css("color", "#FFFFFF");
                $('#rongzi1').css("color", "#FFFFFF"); $('#rongzi2').css("color", "#FFFFFF");
                return false;
            });
            $("#shichang").click(function () {
                $('#list1').hide(); $('#list2').hide(); $('#list3').show(); $('#list4').hide(); $('#list5').hide(); $('#list6').hide();
                $('#project').css("color", "#FFFFFF"); $('#jishu').css("color", "#FFFFFF"); $('#shichang').css("color", "blue"); $('#rongzi').css("color", "#FFFFFF");
                $('#rongzi1').css("color", "#FFFFFF"); $('#rongzi2').css("color", "#FFFFFF");
                return false;
            });
            $("#rongzi").click(function () {
                $('#list1').hide(); $('#list2').hide(); $('#list3').hide(); $('#list4').show(); $('#list5').hide(); $('#list6').hide();
                $('#project').css("color", "#FFFFFF"); $('#jishu').css("color", "#FFFFFF"); $('#shichang').css("color", "#FFFFFF"); $('#rongzi').css("color", "blue");
                $('#rongzi1').css("color", "#FFFFFF"); $('#rongzi2').css("color", "#FFFFFF");
                return false;
            });
            $("#rongzi1").click(function () {
                $('#list1').hide(); $('#list2').hide(); $('#list3').hide(); $('#list4').hide(); $('#list5').show(); $('#list6').hide();
                $('#project').css("color", "#FFFFFF"); $('#jishu').css("color", "#FFFFFF"); $('#shichang').css("color", "#FFFFFF"); $('#rongzi').css("color", "#FFFFFF");
                $('#rongzi1').css("color", "blue"); $('#rongzi2').css("color", "#FFFFFF");
                return false;
            });
            $("#rongzi2").click(function () {
                $('#list1').hide(); $('#list2').hide(); $('#list3').hide(); $('#list4').hide(); $('#list5').hide(); $('#list6').show();
                $('#project').css("color", "#FFFFFF"); $('#jishu').css("color", "#FFFFFF"); $('#shichang').css("color", "#FFFFFF"); $('#rongzi').css("color", "#FFFFFF");
                $('#rongzi1').css("color", "#FFFFFF"); $('#rongzi2').css("color", "blue");
                return false;
            });
        });
    </script>
    <style type="text/css">
        .auto-style1 {
            height: 42px;
        }
        .auto-style2 {
            height: 85px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
         <a href="jscg.aspx" class="buttonLB1">返回技术成果</a> 
        &nbsp;&nbsp;<button id="project" <% if (typeid == 1) Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %>  >编辑基本信息</button>  
        &nbsp;&nbsp;<button id="jishu"  <% if (typeid == 2) Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %> >编辑详细信息</button>   
        &nbsp;&nbsp;<button id="shichang"  <% if (typeid == 3) Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %> >编辑技术专利</button>  
        &nbsp;&nbsp;<button id="rongzi"  <% if (typeid == 4) Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %> >编辑获奖情况</button>	
        &nbsp;&nbsp;<button id="rongzi1"  <% if (typeid == 5) Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %> >编辑成果鉴定</button>
        &nbsp;&nbsp;<button id="rongzi2"  <% if (typeid == 6) Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %> >编辑附件</button>
        <br>
        <%--基本信息--%>
        <table class="gridtable" <% if (typeid == 1) Response.Write("style='display: block'"); else Response.Write("style='display: none'"); %>     id="list1" >
            <tr style="page-break-inside: avoid;">
                <th class="auto-style4">选择企业：</th>
                <td colspan="3">
                    
                    <asp:Label ID="lbcompanyname" runat="server"    style="text-align: center"></asp:Label>
                    
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style4">项目名称：</th>
                <td >
                    <asp:TextBox ID="tbName" Width="246px" runat="server"></asp:TextBox>
                </td>
                 <th class="auto-style3">技术水平：</th>
                <td >
                    <asp:DropDownList ID="ddljishu" runat="server" Height="22px" Width="246px">
                        </asp:DropDownList>
                    
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style4">所属行业：</th>
                <td >
                     <asp:DropDownList ID="ddlhangye" runat="server" Height="22px" Width="246px">
                        </asp:DropDownList>
                </td>
            
                <th class="auto-style3">成果类型：</th>
                <td >
                     <asp:DropDownList ID="ddlchengguo" runat="server" Height="22px" Width="246px">
                        </asp:DropDownList>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style5">所处阶段：</th>
                <td class="auto-style6" >
                    <asp:TextBox ID="tbjieduan" runat="server" Width="246px"></asp:TextBox>
                </td>
            
                <th class="auto-style3">技术成果来源：</th>
                <td class="auto-style6" >
                    <asp:DropDownList ID="ddllaiyuan" runat="server" Height="22px" Width="246px">
                        </asp:DropDownList>
                   
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style4"  >关键词：</th>
                <td class="auto-style2">
                    <asp:TextBox ID="tbKey" runat="server" Width="246px" ></asp:TextBox>
                </td>
                <th class="auto-style3" >合作方式：</th>
                <td class="auto-style1">
                    <asp:TextBox ID="tbhezuo" Width="246px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style4">总投资（万元）：</th>
                <td >
                    <asp:TextBox ID="tbtouzi" Width="246px" runat="server"></asp:TextBox>
                </td>
            
                <th class="auto-style3">设备投资（万元）：</th>
                <td >
                    <asp:TextBox ID="tbshebei" Width="246px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style4">新增利润（万元）：</th>
                <td >
                   <asp:TextBox ID="tblirui" Width="246px" runat="server"></asp:TextBox>
                </td>
            
                <th class="auto-style3">节省成本（万元）：</th>
                <td >
                   <asp:TextBox ID="tbjieye" Width="246px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style4">技术先进性说明：</th>
                <td colspan="3">
                    <asp:TextBox ID="tbxianjin" runat="server" Width="700px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style4">主要技术参数：</th>
                <td colspan="3">
                    <asp:TextBox ID="tbcanshu" runat="server" Width="700px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <td colspan="4" style="text-align: center;">
                    <asp:Button CssClass="buttonLB1" ID="Button1" runat="server" OnClick="Button1_Click" Text="修改" />
                    <asp:Label ID="Label1" runat="server"    style="text-align: center" ForeColor="#FF3300"></asp:Label>
                    <a href="jscg.aspx" class="buttonLB1">返回技术成果</a>
                </td>
            </tr>
        </table>
        <%-- 详细信息--%>
        <table class="gridtable" <% if (typeid == 2) Response.Write("style='display: block'"); else Response.Write("style='display: none'"); %>     id="list2" >
            <tr style="page-break-inside: avoid;">
                <th class="auto-style4">项目意义：</th>
                <td colspan="3">
                    <asp:TextBox ID="tbYiYi" runat="server" Width="700px" Height="48px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style4">项目目标：</th>
                <td colspan="3">
                    <asp:TextBox ID="tbMuBiao" runat="server" Width="700px" Height="69px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style4">主要任务：</th>
                <td colspan="3">
                    <asp:TextBox ID="tbRenWu" runat="server" Width="700px" Height="60px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style4">已有技术基础：</th>
                <td colspan="3">
                    <asp:TextBox ID="tbJiChu" runat="server" Width="700px" Height="42px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style4">配套条件及资金筹措：</th>
                <td colspan="3">
                    <asp:TextBox ID="tbChuoCuo" runat="server" Width="700px" Height="57px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style2">技术、经济效益、推广应用及产业化前景：</th>
                <td colspan="3" class="auto-style2">
                    <asp:TextBox ID="tbQianJing" runat="server" Width="700px" Height="60px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style4">计划实施年限。包括年度计划、阶段目标等：</th>
                <td colspan="3">
                    <asp:TextBox ID="tbJiHua" runat="server" Width="700px" Height="56px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style4">组织措施及实施方案：</th>
                <td colspan="3">
                    <asp:TextBox ID="tbFangAn" runat="server" Width="700px" Height="62px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <td colspan="4" style="text-align: center;">
                    <asp:Button CssClass="buttonLB1" ID="Button2" runat="server" OnClick="Button2_Click" Text="修改" />
                    <asp:Label ID="Label2" runat="server"    style="text-align: center" ForeColor="#FF3300"></asp:Label>
                    <a href="jscg.aspx" class="buttonLB1">返回技术成果</a>
                </td>
            </tr>
        </table>
        <%--技术专利--%>
        <table class="gridtable" <% if (typeid == 3) Response.Write("style='display: block'"); else Response.Write("style='display: none'"); %>     id="list3" >
            <tr style="page-break-inside: avoid;">
                <th class="auto-style4">专利名称：</th>
                <td colspan="3">
                    <asp:TextBox ID="tbZhuanLi" runat="server" Width="700px"></asp:TextBox>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style4">专利类型：</th>
                <td colspan="3">
                    <asp:TextBox ID="tbLeiXing" runat="server" Width="700px"></asp:TextBox>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style4">申请号（登记号）：</th>
                <td colspan="3">
                    <asp:TextBox ID="tbHaoMa" runat="server" Width="700px"></asp:TextBox>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style4">申请人：</th>
                <td colspan="3">
                    <asp:TextBox ID="tbShenQing" runat="server" Width="700px"></asp:TextBox>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style4">授权日期：</th>
                <td colspan="3">
                    <asp:TextBox ID="tbShiJian" runat="server" Width="700px"></asp:TextBox>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style4">分类号：</th>
                <td colspan="3">
                    <asp:TextBox ID="tbFenLeiHao" runat="server" Width="700px"></asp:TextBox>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style4">所有权人：</th>
                <td colspan="3">
                    <asp:TextBox ID="tbShuoYouRen" runat="server" Width="700px"></asp:TextBox>
                </td>
            </tr>
             
            <tr style="page-break-inside: avoid;">
                <td colspan="4" style="text-align: center;">
                    <asp:Button CssClass="buttonLB1" ID="Button3" runat="server" OnClick="Button3_Click" Text="修改" />
                    <asp:Label ID="Label3" runat="server"    style="text-align: center" ForeColor="#FF3300"></asp:Label>
                    <a href="jscg.aspx" class="buttonLB1">返回技术成果</a>
                </td>
            </tr>
        </table>
        <%--获奖情况--%>
        <table class="gridtable" <% if (typeid == 4) Response.Write("style='display: block'"); else Response.Write("style='display: none'"); %>     id="list4" >
            <tr style="page-break-inside: avoid;">
                <th class="auto-style4">获奖名称和级别：</th>
                <td colspan="3">
                    <asp:TextBox ID="JiangMing" runat="server" Width="700px"></asp:TextBox>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style4">颁奖单位：</th>
                <td colspan="3">
                    <asp:TextBox ID="BanJiang" runat="server" Width="700px"></asp:TextBox>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style4">获奖时间：</th>
                <td colspan="3">
                    <asp:TextBox ID="JiangShi" runat="server" Width="700px"></asp:TextBox>
                </td>
            </tr>
             
            <tr style="page-break-inside: avoid;">
                <td colspan="4" style="text-align: center;">
                    <asp:Button CssClass="buttonLB1" ID="Button4" runat="server" OnClick="Button4_Click" Text="修改" />
                    <asp:Label ID="Label4" runat="server"    style="text-align: center" ForeColor="#FF3300"></asp:Label>
                    <a href="jscg.aspx" class="buttonLB1">返回技术成果</a>
                </td>
            </tr>
        </table>
        <%--成果鉴定--%>
        <table class="gridtable" <% if (typeid == 5) Response.Write("style='display: block'"); else Response.Write("style='display: none'"); %>     id="list5" >
            <tr style="page-break-inside: avoid;">
                <th class="auto-style4">鉴定结果：</th>
                <td colspan="3">
                    <asp:TextBox ID="JieGuo" runat="server" Width="700px"></asp:TextBox>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style4">鉴定单位：</th>
                <td colspan="3">
                    <asp:TextBox ID="JDanWei" runat="server" Width="700px"></asp:TextBox>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style4">鉴定时间：</th>
                <td colspan="3">
                    <asp:TextBox ID="JShiJian" runat="server" Width="700px"></asp:TextBox>
                </td>
            </tr>
             
            <tr style="page-break-inside: avoid;">
                <td colspan="4" style="text-align: center;">
                    <asp:Button CssClass="buttonLB1" ID="Button5" runat="server" OnClick="Button5_Click" Text="修改" />
                    <asp:Label ID="Label5" runat="server"    style="text-align: center" ForeColor="#FF3300"></asp:Label>
                    <a href="jscg.aspx" class="buttonLB1">返回技术成果</a>
                </td>
            </tr>
        </table>
         <%--上传附件--%>
        <table class="gridtable" <% if (typeid == 6) Response.Write("style='display: block'"); else Response.Write("style='display: none'"); %>     id="list6" >
            <tr style="page-break-inside: avoid;">
                <th class="auto-style4">附件地址：</th>
                <td colspan="3">
           
                    <asp:TextBox ID="pic" runat="server" Width="700px"></asp:TextBox>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style4">附件上传：</th>
                <td colspan="3">
                    <asp:FileUpload ID="upfile" class="buttonLB" runat="server" Width="500px" />
            
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style4">图片显示：</th>
                <td colspan="3">
                     <asp:Image ID="imgh" runat="server" Height="100px" Width="374px" />
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <td colspan="4" style="text-align: center;">
                    <asp:Button CssClass="buttonLB1" ID="Button6" runat="server" OnClick="Button6_Click" Text=" 上 传 " />
                    <asp:Label ID="Label6" runat="server"    style="text-align: center" ForeColor="#FF3300"></asp:Label>
                    <a href="jscg.aspx" class="buttonLB1">返回技术成果</a>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
