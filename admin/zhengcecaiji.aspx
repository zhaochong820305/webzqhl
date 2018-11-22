<%@ Page Language="C#" AutoEventWireup="true" CodeFile="zhengcecaiji.aspx.cs" Inherits="admin_zhengcecaiji" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>

    </title>
    <style>
        *{margin:5px; padding:0;}
        .labelbluebt{color:cornflowerblue;}
        li{list-style:none;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        政策采集开始页面
        <div style="margin-left:40px;margin-top:0px;" class="zhengce">
            <ul>
                <li><label class="labelblue">中文名称：</label>
                    <asp:TextBox ID="chinaname" CssClass="inputLB" MaxLength="50" Width="600px" runat="server"  Text="北京人民政府"></asp:TextBox>
                </li>
                <li><label class="labelblue">类别名称：</label>
                    <asp:TextBox ID="classname" CssClass="inputLB" MaxLength="50" Width="600px" runat="server"  Text="市政府文件"></asp:TextBox>
                </li>
                <li><label class="labelblue">采集网址：</label>
                    <asp:TextBox ID="url" CssClass="inputLB" MaxLength="200" Width="600px" runat="server" Text="http://zhengce.beijing.gov.cn/zfwj/"></asp:TextBox>
                </li>
                <li><label class="labelblue">采集域名：</label>
                    <asp:TextBox ID="domain" CssClass="inputLB" MaxLength="50" Width="600px" runat="server" Text="http://zhengce.beijing.gov.cn"></asp:TextBox>
                </li>
                <li><label class="labelblue">采集次数：</label>
                    <asp:TextBox ID="cishu" CssClass="inputLB" MaxLength="50" Width="600px" runat="server" Text="1"></asp:TextBox>
                </li>
                <li><label class="labelblue">采集地点：</label>
                    <asp:DropDownList  CssClass="inputLB" Width="600px"  ID="cityid" runat="server" AutoPostBack="True"></asp:DropDownList>
                </li>
                <li><label class="labelbluebt">标题地址块设置：</label>
                   
                </li>
                <li><label class="labelblue">开始字符：</label>
                    <asp:TextBox ID="startstr" CssClass="inputLB" MaxLength="50" Width="600px" runat="server" Text="历年数据查询"></asp:TextBox>
                </li>
                <li><label class="labelblue">结束字符：</label>
                    <asp:TextBox ID="endstr" CssClass="inputLB" MaxLength="50" Width="600px" runat="server"  Text="</ul>"></asp:TextBox>
                </li>  
                <li><label class="labelbluebt">标题设置：</label>
                   
                </li>
                <li><label class="labelblue">开始字符：</label>
                    <asp:TextBox ID="titlestart" CssClass="inputLB" MaxLength="50" Width="600px" runat="server" Text="历年数据查询"></asp:TextBox>
                </li>
                <li><label class="labelblue">结束字符：</label>
                    <asp:TextBox ID="titleend" CssClass="inputLB" MaxLength="50" Width="600px" runat="server"  Text="</ul>"></asp:TextBox>
                </li>  
                <li><label class="labelbluebt">地址设置：</label>
                   
                </li>
                <li><label class="labelblue">开始字符：</label>
                    <asp:TextBox ID="urlstart" CssClass="inputLB" MaxLength="50" Width="600px" runat="server" Text="历年数据查询"></asp:TextBox>
                </li>
                <li><label class="labelblue">结束字符：</label>
                    <asp:TextBox ID="urlend" CssClass="inputLB" MaxLength="50" Width="600px" runat="server"  Text="</ul>"></asp:TextBox>
                </li>                
                <li><label class="labelbluebt">内容块设置：</label>                   
                </li>
                <li><label class="labelblue">开始字符：</label>
                    <asp:TextBox ID="textstart" CssClass="inputLB" MaxLength="50" Width="600px" runat="server" Text=""></asp:TextBox>
                </li>
                <li><label class="labelblue">结束字符：</label>
                    <asp:TextBox ID="textend" CssClass="inputLB" MaxLength="50" Width="600px" runat="server"  Text=""></asp:TextBox>
                </li>
                <li><label class="labelbluebt">参数块设置：</label>
                   
                </li>
                <li><label class="labelblue">开始字符：</label>
                    <asp:TextBox ID="configstart" CssClass="inputLB" MaxLength="50" Width="600px" runat="server" Text=""></asp:TextBox>
                </li>
                <li><label class="labelblue">结束字符：</label>
                    <asp:TextBox ID="configend" CssClass="inputLB" MaxLength="50" Width="600px" runat="server"  Text=""></asp:TextBox>
                </li>
                <li><label class="labelbluebt">参数-发文文号设置：</label>
                   
                </li>
                <li><label class="labelblue">开始字符：</label>
                    <asp:TextBox ID="fwhaostart" CssClass="inputLB" MaxLength="50" Width="600px" runat="server" Text=""></asp:TextBox>
                </li>
                <li><label class="labelblue">结束字符：</label>
                    <asp:TextBox ID="fwhaoend" CssClass="inputLB" MaxLength="50" Width="600px" runat="server"  Text=""></asp:TextBox>
                </li>
                <li><label class="labelbluebt">参数-成文日期设置：</label>
                   
                </li>
                <li><label class="labelblue">开始字符：</label>
                    <asp:TextBox ID="cwdatestart" CssClass="inputLB" MaxLength="50" Width="600px" runat="server" Text=""></asp:TextBox>
                </li>
                <li><label class="labelblue">结束字符：</label>
                    <asp:TextBox ID="cwdateend" CssClass="inputLB" MaxLength="50" Width="600px" runat="server"  Text=""></asp:TextBox>
                </li>
                <li><label class="labelbluebt">参数-发文机构设置：</label>
                   
                </li>
                <li><label class="labelblue">开始字符：</label>
                    <asp:TextBox ID="fwjigoustart" CssClass="inputLB" MaxLength="50" Width="600px" runat="server" Text=""></asp:TextBox>
                </li>
                <li><label class="labelblue">结束字符：</label>
                    <asp:TextBox ID="fwjigouend" CssClass="inputLB" MaxLength="50" Width="600px" runat="server"  Text=""></asp:TextBox>
                </li>
                <li><label class="labelbluebt">参数-发布日期设置：</label>
                   
                </li>
                <li><label class="labelblue">开始字符：</label>
                    <asp:TextBox ID="fbriqistart" CssClass="inputLB" MaxLength="50" Width="600px" runat="server" Text=""></asp:TextBox>
                </li>
                <li><label class="labelblue">结束字符：</label>
                    <asp:TextBox ID="fbriqiend" CssClass="inputLB" MaxLength="50" Width="600px" runat="server"  Text=""></asp:TextBox>
                </li>
                <li  ><label class="labelblue">分析内容：</label><br />
                    <%--  <asp:Label ID="content1"  runat="server" Text="" Visible="False"></asp:Label>--%>
                    <asp:TextBox ID="textBox5"   Width="800px" TextMode="MultiLine" Height="100px" runat="server"></asp:TextBox>
                </li>
                <li><label class="labelblue">正常采集：</label>
                    <asp:TextBox ID="error" CssClass="inputLB" MaxLength="50" Width="600px" runat="server" Text="1"></asp:TextBox>
                </li>
                <li><label class="labelblue">&nbsp;</label>
                    <asp:Button ID="bc" CssClass="buttonLB" runat="server" Text=" 提取连接 " OnClick="bc_Click" />
                    <asp:Button ID="Button1" CssClass="buttonLB" runat="server" Text=" 保存配制信息 " OnClick="Button1_Click"  />
                    <asp:Button ID="Button2" CssClass="buttonLB" runat="server" Text=" 添加配制信息 " OnClick="Button2_Click"  />
                </li>
                <li>
                    <asp:Label ID="msg" runat="server" ForeColor="Red"></asp:Label>
                </li>
            </ul>
        </div>
    </div>
    </form>
</body>
</html>
