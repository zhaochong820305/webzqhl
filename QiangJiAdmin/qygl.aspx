<%@ Page Language="C#" AutoEventWireup="true" CodeFile="qygl.aspx.cs" Inherits="admin_qygl" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>管理中心</title>

    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/grid.css" rel="stylesheet" />
    <script src="js/jquery-2.1.1.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
    function showdiv1() {
        //document.getElementById('pmsg1').style.display = "block";
        //document.getElementById('pmsg0').style.display = "block";
        document.getElementById("bg").style.display = "block";
        document.getElementById("show").style.display = "block";
        var php = "success";
        document.getElementById('pmsg1').innerHTML = php;
    }
    function showdiv0() {
        document.getElementById("bg").style.display = "block";
        document.getElementById("show").style.display = "block";
        document.getElementById('pmsg1').style.display = "none";
        document.getElementById('pmsg0').style.display = "block";
    }
    function showdiv() {            
                document.getElementById("bg").style.display ="block";
                document.getElementById("show").style.display = "block";               
            }
    function hidediv() {
                document.getElementById("bg").style.display ='none';
                document.getElementById("show").style.display ='none';
            }
    </script>
    <style type="text/css">
        *{margin:0; padding:0;}
        #bg{ display: none;  position: absolute;  top: 0%;  left: 0%;  width: 100%;  height: 100%;  background-color: black;  z-index:1001;  -moz-opacity: 0.7;  opacity:.70;  filter: alpha(opacity=70);}
        #show{display: none;  position: absolute;  top: 10%;  left: 22%;  width: 53%;  height: 49%;  padding: 8px;  border: 8px solid #E8E9F7;  background-color: white;  z-index:1002;  overflow: auto;}
        #pmsg1{ display: none; color:red; width: 30%; height: 10%; position: absolute;  }
        #pmsg0{ display: none;  color:red; width: 30%; height: 10%; position: absolute; left: 32%;}
    </style>
  
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server"></asp:ScriptManagerProxy>
   <div id="tab1" class="taba" style="display:block;width:100%;">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
        <div style="height:150px;width:100%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;业&nbsp;务&nbsp;员： <asp:DropDownList ID="yewu" Width="200px" CssClass="inputLB" runat="server" AutoPostBack="True" OnSelectedIndexChanged="yewu_SelectedIndexChanged"></asp:DropDownList>
            &nbsp;推&nbsp;荐&nbsp;人&nbsp;：<asp:DropDownList  CssClass="inputLB" Width="200px"  ID="tunjiang" runat="server" AutoPostBack="True" OnSelectedIndexChanged="tunjiang_SelectedIndexChanged"></asp:DropDownList>
            &nbsp;行业领域：<asp:DropDownList  CssClass="inputLB" Width="200px"  ID="hangye" runat="server" AutoPostBack="True" OnSelectedIndexChanged="hangye_SelectedIndexChanged"></asp:DropDownList>
            <br>
           
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;企业性质：<asp:DropDownList ID="qiyesz" runat="server" CssClass="inputLB" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="qiyesz_SelectedIndexChanged">
            </asp:DropDownList>
            &nbsp;所在地区：<asp:DropDownList ID="diqu" runat="server" CssClass="inputLB" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="diqu_SelectedIndexChanged">
            </asp:DropDownList>
            &nbsp;合作状态：<asp:DropDownList ID="hezuozt" runat="server" CssClass="inputLB" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="hezuozt_SelectedIndexChanged">
            </asp:DropDownList><br>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注册网站：
            <asp:DropDownList ID="typeid" runat="server" CssClass="inputLB" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="hezuozt_SelectedIndexChanged">
                <asp:ListItem Value="">全部网站</asp:ListItem>
                <asp:ListItem Value="1">中企慧联</asp:ListItem>
                <asp:ListItem Value="2">联盟网站</asp:ListItem>
                <asp:ListItem Value="3">强基网站</asp:ListItem>
                <asp:ListItem Value="4">成果交易</asp:ListItem>
                <asp:ListItem Value="10">调查问卷</asp:ListItem>
                <asp:ListItem Value="11">后台录入</asp:ListItem>
            </asp:DropDownList>
            &nbsp;关键词：<asp:TextBox ID="sname" CssClass="inputLB" Width="197px" runat="server" Text=""  ></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="ss" runat="server" CssClass="buttonLB" OnClick="ss_Click" Text="搜索" />
            <br><br>
            &nbsp;&nbsp;&nbsp;&nbsp;<a href="qiyeadd.aspx" class="buttonLB1">&nbsp;++添加</a>&nbsp;&nbsp;
             <a href="qiyeonline.aspx" class="buttonLB1">&nbsp;企业在线提交信息</a>&nbsp;&nbsp; <%--<a href="qiyeview.aspx" >&nbsp;i查看信息</a>&nbsp;&nbsp;
            <a href="qiyeedit.aspx" >&nbsp;编辑基本信息</a>&nbsp;&nbsp;
            <a style="cursor:pointer" onclick="showdiv();">&nbsp;编辑上市规划</a>&nbsp;&nbsp;
            <a href="qiyejili.aspx" >&nbsp;编辑员工激励信息</a>&nbsp;&nbsp;   
            <a href="qiyeview.aspx" target="_blank">&nbsp;管理团队</a>&nbsp;&nbsp;    
            <a href="qiyeview.aspx" target="_blank">&nbsp;编辑财务数据</a>&nbsp;&nbsp;  
            <a href="qiyeview.aspx" target="_blank">&nbsp;设置推荐人</a>&nbsp;&nbsp;
            <a href="qiyeview.aspx" target="_blank">&nbsp;设置业务员</a>&nbsp;&nbsp;  
            <a href="qiyeview.aspx" target="_blank">&nbsp;设置合作状态</a>&nbsp;&nbsp;        --%>
            <br></br>
            <br></br>
            </br></br>
             
            </div>
        <div id="bg"></div>
        <div id="show">编辑上市规划       
             <input id="btnclose1" type="button" value="关闭" onclick="hidediv();"/><br /><br />
            上市方向：<asp:TextBox ID="tbFangXiang" runat="server" BorderWidth="1"></asp:TextBox>    上市时间：<asp:TextBox  BorderWidth="1" ID="tbShiJian" runat="server"></asp:TextBox>
            <br /><br /> 上市准备情况(券商、律师、财务)：<asp:TextBox ID="tbZhuiBei" runat="server" BorderWidth="1"></asp:TextBox>
            <br /><br /> <input id="btnclose" type="button" value="关闭" onclick="hidediv();"/>
            <asp:Button ID="btSave" runat="server" Text="保存"  OnClick="btSave_Click"/>
            <asp:Label ID="Labelmsg" runat="server" Text="" ForeColor="#FF3300"></asp:Label><div id="pmsg1"></div><div id="pmsg0"></div>
        </div>
        <div style="float:left;height:500px;margin-top:40px;line-height:30px;width:100%;margin-left:19px;">
            <table border="0" style="width:100%;height:10%;padding: inherit; margin: 0 auto; border: thin solid #eac998;">
                <tr><td style="vertical-align:top;background-color:#F7F7DE" width="100%">

                    <asp:GridView ID="myGrid" Width="860px" Height="100%" runat="server"
                       CssClass="mGrid"
   PagerStyle-CssClass="pgr"   BackColor="White" 
        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
        ForeColor="Black" GridLines="Vertical" AllowPaging="True" 
            AutoGenerateColumns="False" PageSize="14" OnPageIndexChanging="myGrid_PageIndexChanging" 
                      ShowHeaderWhenEmpty="True" OnRowDataBound="myGrid_RowDataBound" OnSelectedIndexChanged="myGrid_SelectedIndexChanged" DataKeyNames="id" >
                        <Columns>
                            <asp:BoundField DataField="id" HeaderText="企业编号" >
                            <HeaderStyle Width="40px" Wrap="True" />
                            <ItemStyle Width="40px" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="企业名称" DataField="Name" >
                            <HeaderStyle Width="175px" />
                            <ItemStyle Width="175px" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="登录名" DataField="MemberName" >
                            <HeaderStyle Width="80px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Contact" HeaderText="联系人" >
                            <HeaderStyle Width="52px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ContactTel" HeaderText="联系电话" >
                            <HeaderStyle Width="102px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="typename" HeaderText="应用网站" >
                            <HeaderStyle Width="55px" />
                            </asp:BoundField>
                           <%-- <asp:BoundField DataField="EnterType" HeaderText="企业性质" >
                            <HeaderStyle Width="68px" />
                            </asp:BoundField>--%>
                          <%--  <asp:BoundField DataField="KeyArea" HeaderText="行业领域" >                            
                            <HeaderStyle Width="130px" />
                            <ItemStyle Width="130px"  Wrap="True" />
                            </asp:BoundField>--%>
                            <asp:BoundField DataField="CreateDate" HeaderText="收录时间" DataFormatString="{0:yyyy-MM-dd}"  >
                            <HeaderStyle Width="85px" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="操作">
                                <ItemTemplate>
                                    <%--<asp:LinkButton ID="bj" runat="server" CommandArgument='<%# Eval("ID") %>' OnCommand="bj_Command">报表</asp:LinkButton>--%>
                                    <a href="qiyelist.aspx?id=<%# Eval("ID") %>" >报表</a>   
                                    <a href="qiyeedit.aspx?id=<%# Eval("ID") %>" >编辑</a>        
                                    <asp:LinkButton ID="sc" runat="server" CommandArgument='<%# Eval("ID") %>' OnClientClick="if(confirm(&quot;确定要删除该企业数据么?&quot;)==false)return false;" OnCommand="sc_Command">删除</asp:LinkButton>                                                                  
                                    <%#Eval("shenhe").ToString()=="已审核"?"已审核":Eval("shenhe").ToString()=="未审核"?"<a href='qiyeedit.aspx?id="+ Eval("ID") +"&edit=shenhe&phone="+ Eval("ContactTel") +"&typeid="+ Eval("typeid") +"' onclick='if(confirm(&quot;确定要审核该企业信息么?审核完的企业可以在对应网站登陆查看权限显示&quot;)==false)return false;'>审核</a>":""%>
                                </ItemTemplate>
                                <HeaderStyle Width="120px" />
                                <ItemStyle Width="120px" />
                            </asp:TemplateField>
                           <%-- <asp:CommandField ButtonType="Button" ShowSelectButton="True" />--%>
                        </Columns>
                        <FooterStyle BackColor="#CCCC99" />
          <PagerSettings FirstPageText="&lt;&lt;" LastPageText="&gt;&gt;" 
              Mode="NumericFirstLast" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="center" />
        <PagerTemplate>  
        <table border="0" style="width:100%;">  
            <tr>  
                <td style="text-align: center;color: Black;font-size: 10pt;font-family: 宋体;text-decoration: none;">  
   
                    第<font style="font-family: Tahoma;color: Red"><%=PgIndex+ 1 %></font>页  
                    共<font style="font-family: Tahoma;color: Red"><%=PgCount %></font>页                   共<font style="font-family: Tahoma;color: Red"><%=RCount %></font>条                   
                    <asp:LinkButton ID="btnFirst" runat="server" CssClass="font_color" CausesValidation="False" CommandArgument="first" CommandName="Page" OnClick="btnGridView_Click" Text="首页" />  
                    <asp:LinkButton ID="btnPrev" runat="server" CssClass="font_color" CausesValidation="False" CommandArgument="prev" CommandName="Page" OnClick="btnGridView_Click" Text="上一页" />  
                    <asp:LinkButton ID="btnNext" runat="server" CssClass="font_color" CausesValidation="False" CommandArgument="next" CommandName="Page" OnClick="btnGridView_Click" Text="下一页" />  
                    <asp:LinkButton ID="btnLast" runat="server" CssClass="font_color" CausesValidation="False" CommandArgument="last" CommandName="Page" OnClick="btnGridView_Click" Text="尾页" />  
                </td>  
            </tr>  
        </table>  
    </PagerTemplate>  
        <RowStyle BackColor="#F7F7DE" />
        <SelectedRowStyle BackColor="#FFFFCC" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FBFBF2" />
        <SortedAscendingHeaderStyle BackColor="#848384" />
        <SortedDescendingCellStyle BackColor="#EAEAD3" />
        <SortedDescendingHeaderStyle BackColor="#575357" />
                    </asp:GridView>
                    </td></tr>
                
            </table>
        </div> 
                
      </ContentTemplate></asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
