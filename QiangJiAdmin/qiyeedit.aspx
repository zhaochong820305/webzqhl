<%@ Page Language="C#" AutoEventWireup="true" CodeFile="qiyeedit.aspx.cs" Inherits="admin_qiyeedit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>管理中心</title>

    <link href="css/qiyegl.css" rel="stylesheet" type="text/css" />

    <script charset="utf-8" src="js/kindeditor-all.js"></script>
    <script charset="utf-8" src="js/lang/zh-CN.js"></script>
    <script charset="utf-8" src="js/plugins/code/prettify.js"></script>
    <script src="../js/jquery.js"></script>
    <script>


        $(document).ready(function () {

            $("#project").click(function () {
                $('#list1').show(); $('#list2').hide(); $('#list3').hide(); $('#list4').hide(); $('#list5').hide(); $('#list6').hide(); $('#list7').hide(); $('#list8').hide();
                $('#project').css("color", "blue"); $('#jishu').css("color", "#FFFFFF"); $('#shichang').css("color", "#FFFFFF"); $('#rongzi').css("color", "#FFFFFF");
                $('#rongzi5').css("color", "#FFFFFF"); $('#rongzi6').css("color", "#FFFFFF"); $('#rongzi7').css("color", "#FFFFFF"); $('#rongzi8').css("color", "#FFFFFF");
                return false;
            });
            $("#jishu").click(function () {
                $('#list1').hide(); $('#list2').show(); $('#list3').hide(); $('#list4').hide(); $('#list5').hide(); $('#list6').hide(); $('#list7').hide(); $('#list8').hide();
                $('#project').css("color", "#FFFFFF"); $('#jishu').css("color", "blue"); $('#shichang').css("color", "#FFFFFF"); $('#rongzi').css("color", "#FFFFFF");
                $('#rongzi5').css("color", "#FFFFFF"); $('#rongzi6').css("color", "#FFFFFF"); $('#rongzi7').css("color", "#FFFFFF"); $('#rongzi8').css("color", "#FFFFFF");
                return false;
            });
            $("#shichang").click(function () {
                $('#list1').hide(); $('#list2').hide(); $('#list3').show(); $('#list4').hide(); $('#list5').hide(); $('#list6').hide(); $('#list7').hide(); $('#list8').hide();
                $('#project').css("color", "#FFFFFF"); $('#jishu').css("color", "#FFFFFF"); $('#shichang').css("color", "blue"); $('#rongzi').css("color", "#FFFFFF");
                $('#rongzi5').css("color", "#FFFFFF"); $('#rongzi6').css("color", "#FFFFFF"); $('#rongzi7').css("color", "#FFFFFF"); $('#rongzi8').css("color", "#FFFFFF");
                return false;
            });
            $("#rongzi").click(function () {
                $('#list1').hide(); $('#list2').hide(); $('#list3').hide(); $('#list4').show(); $('#list5').hide(); $('#list6').hide(); $('#list7').hide(); $('#list8').hide();
                $('#project').css("color", "#FFFFFF"); $('#jishu').css("color", "#FFFFFF"); $('#shichang').css("color", "#FFFFFF"); $('#rongzi').css("color", "blue");
                $('#rongzi5').css("color", "#FFFFFF"); $('#rongzi6').css("color", "#FFFFFF"); $('#rongzi7').css("color", "#FFFFFF"); $('#rongzi8').css("color", "#FFFFFF");
                return false;
            });
            $("#rongzi5").click(function () {
                $('#list1').hide(); $('#list2').hide(); $('#list3').hide(); $('#list4').hide(); $('#list5').show(); $('#list6').hide(); $('#list7').hide(); $('#list8').hide();
                $('#project').css("color", "#FFFFFF"); $('#jishu').css("color", "#FFFFFF"); $('#shichang').css("color", "#FFFFFF"); $('#rongzi').css("color", "#FFFFFF");
                $('#rongzi5').css("color", "blue"); $('#rongzi6').css("color", "#FFFFFF"); $('#rongzi7').css("color", "#FFFFFF"); $('#rongzi8').css("color", "#FFFFFF");
                return false;
            });
            $("#rongzi6").click(function () {
                $('#list1').hide(); $('#list2').hide(); $('#list3').hide(); $('#list4').hide(); $('#list5').hide(); $('#list6').show(); $('#list7').hide(); $('#list8').hide();
                $('#project').css("color", "#FFFFFF"); $('#jishu').css("color", "#FFFFFF"); $('#shichang').css("color", "#FFFFFF"); $('#rongzi').css("color", "#FFFFFF");
                $('#rongzi5').css("color", "#FFFFFF"); $('#rongzi6').css("color", "blue"); $('#rongzi7').css("color", "#FFFFFF"); $('#rongzi8').css("color", "#FFFFFF");
                return false;
            });
            $("#rongzi7").click(function () {
                $('#list1').hide(); $('#list2').hide(); $('#list3').hide(); $('#list4').hide(); $('#list5').hide(); $('#list6').hide(); $('#list7').show(); $('#list8').hide();
                $('#project').css("color", "#FFFFFF"); $('#jishu').css("color", "#FFFFFF"); $('#shichang').css("color", "#FFFFFF"); $('#rongzi').css("color", "#FFFFFF");
                $('#rongzi5').css("color", "#FFFFFF"); $('#rongzi6').css("color", "#FFFFFF"); $('#rongzi7').css("color", "blue"); $('#rongzi8').css("color", "#FFFFFF");
                return false;
            });
            $("#rongzi8").click(function () {
                $('#list1').hide(); $('#list2').hide(); $('#list3').hide(); $('#list4').hide(); $('#list5').hide(); $('#list6').hide(); $('#list7').hide(); $('#list8').show();
                $('#project').css("color", "#FFFFFF"); $('#jishu').css("color", "#FFFFFF"); $('#shichang').css("color", "#FFFFFF"); $('#rongzi').css("color", "#FFFFFF");
                $('#rongzi5').css("color", "#FFFFFF"); $('#rongzi6').css("color", "#FFFFFF"); $('#rongzi7').css("color", "#FFFFFF"); $('#rongzi8').css("color", "blue");
                return false;
            });
        });
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div style="margin-left: 40px; margin-top: 10px;">
            &nbsp;<a href="qygl.aspx" class='buttonLB1'>返回企业管理</a>
            &nbsp;<a href="Project.aspx?cid=<%=scompanyid %>" class='buttonLB1'>项目管理</a>
        </div>
        </br>
        &nbsp;&nbsp;
        <button id="project" <% if (typeid == 1) Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %>>编辑企业信息</button>
        &nbsp;&nbsp;
        <button id="jishu"   <% if (typeid == 2) Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %>>编辑上市信息</button>
        &nbsp;&nbsp;
        <button id="shichang" <% if (typeid == 3) Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %>>编辑业务员信息</button>
        &nbsp;&nbsp;
        <button id="rongzi" <% if (typeid == 4) Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %>>编辑财务信息</button>
        </br>&nbsp;&nbsp;
        <button id="rongzi5" <% if (typeid == 5) Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %>>编辑团队信息</button>
        
        &nbsp;&nbsp;
        <button id="rongzi6" <% if (typeid == 6) Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %>>编辑股权激励</button>
        
        &nbsp;&nbsp;
        <button id="rongzi7" <% if (typeid == 7) Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %>>编辑发布网站</button>
        &nbsp;&nbsp;
        <button id="rongzi8" <% if (typeid == 8) Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %>>编辑企业需求</button>
        <div style="margin-left: 40px; margin-top: 0px;">
            <br>
            当前位置：编辑企业信息
        <table class="gridtable" <% if (typeid == 1) Response.Write("style='display: block'"); else Response.Write("style='display: none'"); %> id="list1">
            <tr>
                <th class="active">企业名称：</th>
                <td colspan="3">
                    <asp:TextBox CssClass="inputLB" ID="tbname" runat="server" Width="685px"></asp:TextBox>
                    <asp:TextBox CssClass="inputLB" ID="tbid" runat="server" Width="30px" Visible="false"></asp:TextBox>
                    &nbsp;</td>

            </tr>
            <tr>
                <th class="active">企业简称：</th>
                <td colspan="3">
                    <asp:TextBox CssClass="inputLB" ID="tbviewname" runat="server" Width="685px"></asp:TextBox>
                    <asp:TextBox CssClass="inputLB" ID="TextBox2" runat="server" Width="30px" Visible="false"></asp:TextBox>
                    &nbsp;</td>

            </tr>
            <tr>
                <th class="active">登录名：</th>
                <td>
                    <asp:TextBox CssClass="inputLB" ID="tblogin" runat="server" Width="280px"></asp:TextBox></td>
                <th class="active">密码：</th>
                <td>
                    <asp:TextBox CssClass="inputLB" ID="tbpass" runat="server" Width="280px"></asp:TextBox></td>
            </tr>
            <tr>
                <th class="auto-style1">详细地址：</th>
                <td class="auto-style1">
                    <asp:TextBox CssClass="inputLB" ID="tbadd" runat="server" Width="280px"></asp:TextBox></td>
                <th class="auto-style1">邮政编码：</th>
                <td class="auto-style1">
                    <asp:TextBox CssClass="inputLB" ID="tbzipcode" runat="server" Width="280px"></asp:TextBox></td>
            </tr>
            <tr>
                <th class="active">法人姓名：</th>
                <td>
                    <asp:TextBox CssClass="inputLB" ID="tbfaren" runat="server" Width="280px"></asp:TextBox></td>
                <th class="active">法人电话：</th>
                <td>
                    <asp:TextBox CssClass="inputLB" ID="tbfarentel" runat="server" Width="280px"></asp:TextBox></td>
            </tr>
            <tr>
                <th class="active">联系人：</th>
                <td>
                    <asp:TextBox CssClass="inputLB" ID="tblianxi" runat="server" Width="280px"></asp:TextBox></td>
                <th class="active">联系电话：</th>
                <td>
                    <asp:TextBox CssClass="inputLB" ID="tblianxitel" runat="server" Width="280px"></asp:TextBox></td>
            </tr>
            <tr>
                <th class="active">经营范围：</th>
                <td colspan="3">
                    <asp:TextBox CssClass="inputLB" ID="jingyingfw" runat="server" Width="685px" Height="42px" TextMode="MultiLine" ></asp:TextBox></td>
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
                    <asp:DropDownList ID="hangye" runat="server" AutoPostBack="True" OnSelectedIndexChanged="hangye_SelectedIndexChanged"></asp:DropDownList></td>
                <td id="tdHangYe2ID">
                    <asp:DropDownList ID="hangye2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="hangye2_SelectedIndexChanged"></asp:DropDownList></td>
                <td id="desc">
                    <asp:Label ID="Label7" runat="server" Width="330px"></asp:Label>
                </td>
            </tr>
            <tr>
                <th class="active">是否上市公司：</th>
                <td colspan="3">
                    <asp:CheckBox ID="ishangshi" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="4" style="text-align: center">
                    <asp:Button ID="Button1" runat="server" CssClass="buttonLB1" Text="修改基本信息" OnClick="Button1_Click" />
                    <asp:Label ID="Label1" runat="server" Text="" Style="text-align: center" ForeColor="Red"></asp:Label>


                </td>
            </tr>
        </table>


            <table class="gridtable" <% if (typeid == 2) Response.Write("style='display: block'"); else Response.Write("style='display: none'"); %> id="list2">

                <tr>
                    <th class="active">上市方向：</th>
                    <td>
                        <asp:TextBox CssClass="inputLB" ID="tbFangXiang" runat="server" BorderWidth="1" Width="264px"></asp:TextBox>
                    </td>
                    <th class="active">上市时间：</th>
                    <td>
                        <asp:TextBox CssClass="inputLB" BorderWidth="1" ID="tbShiJian" runat="server" Width="263px"></asp:TextBox></td>
                </tr>
                <tr>
                    <th class="active">上市准备情况<br>
                        (券商、律师、财务)：</th>
                    <td colspan="3">
                        <asp:TextBox CssClass="inputLB" ID="tbZhuiBei" runat="server" BorderWidth="1" Height="47px" Width="640px" TextMode="MultiLine" ></asp:TextBox>
                        &nbsp;</td>

                </tr>
                <tr>
                    <td colspan="4" style="text-align: center">
                        <asp:Button ID="Button2" runat="server" CssClass="buttonLB1" Text="修改上市信息" OnClick="btSave_Click" />
                        <asp:Label ID="Label2" runat="server" Text="" Style="text-align: center" ForeColor="Red"></asp:Label>


                    </td>
                </tr>
            </table>

            <table class="gridtable" <% if (typeid == 6) Response.Write("style='display: block'"); else Response.Write("style='display: none'"); %> id="list6">
                <tr>
                    <th class="active">是否有股权激励：</th>
                    <td>
                        <asp:CheckBox ID="cbguquan" runat="server" />
                    </td>

                </tr>
                <tr>
                    <th class="active">激励措施：</th>
                    <td colspan="3">
                        <asp:TextBox CssClass="inputLB" ID="tbjili" runat="server" BorderWidth="1"  TextMode="MultiLine" Height="80px"></asp:TextBox>
                        &nbsp;</td>

                </tr>
                <tr>
                    <td colspan="4" style="text-align: center">
                        <asp:Button ID="Button3" runat="server" CssClass="buttonLB1" Text="修改员工激励信息" OnClick="Button3_Click" />
                        <asp:Label ID="Label3" runat="server" Text="" Style="text-align: center" ForeColor="Red"></asp:Label>

                    </td>
                </tr>
            </table>
            <table class="gridtable" <% if (typeid == 7) Response.Write("style='display: block'"); else Response.Write("style='display: none'"); %> id="list7">

                <tr>
                    <th class="active">网站分类：</th>
                    <td colspan="3">
                        <div class='webtype'>
                            <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatColumns="3"></asp:CheckBoxList>
                        </div>
                        &nbsp;</td>

                </tr>
                <tr>
                    <th class="active">强基分类：</th>
                    <td colspan="3">
                        <asp:DropDownList ID="ddlLianMengType" runat="server"></asp:DropDownList>
                        &nbsp;</td>

                </tr>
                 <tr>
                    <th class="active">网址：</th>
                    <td colspan="3">
                         <asp:TextBox CssClass="inputLB" BorderWidth="1" ID="url" runat="server" Width="263px"></asp:TextBox> 示例：http://www.baidu.com/
                        &nbsp;</td>

                </tr>
                <tr>
                    <th class="active">logo：</th>
                    <td class="logo">
                         
                            <label>图片：<b></b></label>
                            <asp:TextBox ID="pic" runat="server" class="inputLB" value="" Style="width: 300px;" Enabled="false"></asp:TextBox>
                         
                            <asp:FileUpload ID="upfile" class="buttonLB" runat="server" />
                            151 * 47 pixels
                         
                            <asp:Image ID="imgh" runat="server" Height="100px" Width="374px" />
                        
                            <label>&nbsp;</label>
                            <asp:Button ID="Button8" class="buttonLB" runat="server" Text="上传" OnClick="Button8_Click" />
                        
                    </td>

                </tr>
                <tr>
                    <td colspan="4" style="text-align: center">
                        <asp:Button ID="Button7" runat="server" CssClass="buttonLB1" Text="修改发布网站信息" OnClick="Button7_Click" />
                        <asp:Label ID="msg" runat="server" Text="" Style="text-align: center" ForeColor="Red"></asp:Label>

                    </td>
                </tr>
            </table>
            <table class="gridtable" <% if (typeid == 8) Response.Write("style='display: block'"); else Response.Write("style='display: none'"); %> id="list8">
                <tr>
                    <th class="active" height="30px">需求信息： <a href="xuqiuadd.aspx?cid=<%=scompanyid%>&op=add" class="buttonLB1">添加</a>
                        <asp:Label ID="Label10" runat="server"></asp:Label>
                    <tr>
                        <th class="active">&nbsp;<asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField DataField="rongzi" HeaderText="融资需求" DataFormatString="{0}" />
                                <%--   <asp:BoundField DataField="zhengce" HeaderText="政策扶持" DataFormatString="{0}" />--%>
                                <asp:BoundField DataField="chanyelian" HeaderText="产业链整合需求" DataFormatString="{0}" />
                                <asp:BoundField DataField="touzi" HeaderText="投资需求" DataFormatString="{0}" />
                                <%--  <asp:BoundField DataField="shouguo" HeaderText="收购需求" DataFormatString="{0}" />--%>
                                <asp:BoundField DataField="beishou" HeaderText="被收购需求" DataFormatString="{0}" />
                                <asp:BoundField DataField="Update" HeaderText="收录时间" />
                                <asp:TemplateField HeaderText="操作">
                                    <ItemTemplate>
                                        <%--<asp:LinkButton ID="bj" runat="server" CommandArgument='<%# Eval("ID") %>' OnCommand="bj_Command">报表</asp:LinkButton>--%>
                                        <a href="xuqiuadd.aspx?id=<%# Eval("ID") %>&op=kan&cid=<%=scompanyid%>">查看</a>
                                        <a href="xuqiuadd.aspx?id=<%# Eval("ID") %>&op=edit&cid=<%=scompanyid%>">编辑</a>
                                        <asp:LinkButton ID="sc" runat="server" CommandArgument='<%# Eval("ID") %>' OnClientClick="if(confirm(&quot;确定要删除该需求信息吗?&quot;)==false)return false;" OnCommand="xq_Command">删除</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </tr>
            </table>
            <table class="gridtable" <% if (typeid == 3) Response.Write("style='display: block'"); else Response.Write("style='display: none'"); %> id="list3">
                <tr>
                    <th class="active">设置推荐人：</th>
                    <td colspan="2">
                        <asp:DropDownList ID="tunjiang" runat="server"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:Button ID="Button4" runat="server" CssClass="buttonLB1" Text="修改推荐人" OnClick="Button4_Click" />
                        <asp:Label ID="Label4" runat="server" Text="" Style="text-align: center" ForeColor="Red"></asp:Label>
                        
                        <a href="tunjian.aspx"  CssClass="buttonLB1" >添加推荐人</a>
                </tr>
                <tr>
                    <th class="active">设置业务员：</th>
                    <td colspan="2">
                        <asp:DropDownList ID="yewu" runat="server"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:Button ID="Button5" runat="server" CssClass="buttonLB1" Text="修改业务员" OnClick="Button5_Click" />
                        <asp:Label ID="Label5" runat="server" Text="" Style="text-align: center" ForeColor="Red"></asp:Label>
                </tr>
                <tr>
                    <th class="active">设置合作状态：</th>
                    <td colspan="2">
                        <asp:DropDownList ID="hezuozt" runat="server"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:Button ID="Button6" runat="server" CssClass="buttonLB1" Text="设置合作状态" OnClick="Button6_Click" />
                        <asp:Label ID="Label6" runat="server" Text="" Style="text-align: center" ForeColor="Red"></asp:Label>
                </tr>
            </table>

            <table class="gridtable" <% if (typeid == 4) Response.Write("style='display: block'"); else Response.Write("style='display: none'"); %> id="list4">
                <tr>
                    <th class="active" height="30px">财务数据： <a href="CaiWuAdd.aspx?cid=<%=scompanyid%>&op=add" class="buttonLB1">添加</a>
                        <asp:Label ID="Label8" runat="server"></asp:Label>
                    <tr>
                        <th class="active">&nbsp;<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField DataField="Year" HeaderText="年份" DataFormatString="{0}年" />
                                <asp:BoundField DataField="DebtRatio" HeaderText="资产负债率" DataFormatString="{0}%" />
                                <asp:BoundField DataField="TotalAsset" HeaderText="企业总资产" DataFormatString="{0}万元" />
                                <asp:BoundField DataField="Income" HeaderText="销售收入" DataFormatString="{0}万元" />
                                <asp:BoundField DataField="Profit" HeaderText="利润" DataFormatString="{0}万元" />
                                <asp:BoundField DataField="CreateDate" HeaderText="收录时间" />
                                <asp:TemplateField HeaderText="操作">
                                    <ItemTemplate>
                                        <%--<asp:LinkButton ID="bj" runat="server" CommandArgument='<%# Eval("ID") %>' OnCommand="bj_Command">报表</asp:LinkButton>--%>
                                        <a href="CaiWuAdd.aspx?id=<%# Eval("ID") %>&op=kan&cid=<%=scompanyid%>">查看</a>
                                        <a href="CaiWuAdd.aspx?id=<%# Eval("ID") %>&op=edit&cid=<%=scompanyid%>">编辑</a>
                                        <asp:LinkButton ID="sc" runat="server" CommandArgument='<%# Eval("ID") %>' OnClientClick="if(confirm(&quot;确定要删除该财务数据么?&quot;)==false)return false;" OnCommand="sc_Command">删除</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </tr>
            </table>

            <table class="gridtable" <% if (typeid == 5) Response.Write("style='display: block'"); else Response.Write("style='display: none'"); %> id="list5">
                <tr>
                    <th height="30px">企业管理团队：<a href="TeamAdd.aspx?cid=<%=scompanyid %>&op=add" class="buttonLB1">添加</a>
                        <asp:Label ID="Label9" runat="server"></asp:Label>
                    <tr>
                        <td>&nbsp;<asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField DataField="Name" HeaderText="姓名" />
                                <asp:BoundField DataField="zhiweiname" HeaderText="职位" />
                                <asp:BoundField DataField="XueLi" HeaderText="学历" />
                                <asp:BoundField DataField="ZhuanYe" HeaderText="专业" />
                                <asp:BoundField DataField="StockCompany" HeaderText="上市公司任职" />
                                <asp:BoundField DataField="CreateDate" HeaderText="收录时间" />
                                <asp:TemplateField HeaderText="操作">
                                    <ItemTemplate>
                                        <%--<asp:LinkButton ID="bj" runat="server" CommandArgument='<%# Eval("ID") %>' OnCommand="bj_Command">报表</asp:LinkButton>--%>
                                        <a href="TeamAdd.aspx?id=<%# Eval("ID") %>&op=kan&cid=<%=scompanyid%>">查看</a>
                                        <a href="TeamAdd.aspx?id=<%# Eval("ID") %>&op=edit&cid=<%=scompanyid%>">编辑</a>
                                        <asp:LinkButton ID="sc1" runat="server" CommandArgument='<%# Eval("ID") %>' OnClientClick="if(confirm(&quot;确定要删除该团队数据么?&quot;)==false)return false;" OnCommand="sc1_Command">删除</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </tr>
            </table>
        </div>

    </form>
</body>
</html>
