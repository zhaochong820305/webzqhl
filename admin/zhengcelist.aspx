﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="zhengcelist.aspx.cs" Inherits="admin_zhengcelist" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>管理中心</title>

    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/grid.css" rel="stylesheet" />
    <script src="js/jquery-2.1.1.min.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">

        <div style="height: 80px; width: 100%; padding-left:20px;">
            <%--应用领域：<asp:DropDownList CssClass="inputLB" Width="150px" ID="ddlhangye" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlhangye_SelectedIndexChanged"></asp:DropDownList>
            成果水平：
            <asp:DropDownList CssClass="inputLB" Width="150px" ID="ddlDiWei" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDiWei_SelectedIndexChanged"></asp:DropDownList>
            &nbsp;&nbsp;选择企业：<asp:DropDownList  CssClass="inputLB" Width="150px"  ID="ddlCompany" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCompany_SelectedIndexChanged"></asp:DropDownList>
            成果类别：<%--<asp:DropDownList  CssClass="inputLB" Width="150px"  ID="DanWeiXingZhi" runat="server" AutoPostBack="True"  OnSelectedIndexChanged="DanWeiXingZhi_SelectedIndexChanged" ></asp:DropDownList>            --%>
            <%--<asp:DropDownList ID="LeiBie" runat="server" Height="22px" Width="150px"></asp:DropDownList>
             
            <asp:DropDownList ID="indexlocation" runat="server" Height="22px" Width="150px">
                        </asp:DropDownList>
            
            
            业&nbsp;务&nbsp;员&nbsp;： <asp:DropDownList ID="yewu" Width="150px" CssClass="inputLB" runat="server" AutoPostBack="True" OnSelectedIndexChanged="yewu_SelectedIndexChanged"></asp:DropDownList>
            合作企业:&nbsp;<asp:CheckBox ID="hezuo" runat="server" /> --%>
            采集网站/栏目：<asp:TextBox ID="sname" CssClass="inputLB" Width="150px" runat="server" Text=""  ></asp:TextBox>
            
            <asp:Button ID="ss" CssClass="buttonLB" runat="server" Text="搜索" OnClick="ss_Click" />
           
            <asp:Label ID="Label5" runat="server" ForeColor="Red"></asp:Label>
            <a href="zhengcecaiji.aspx?id=0" class="buttonLB1" style="font-size:12px;line-height:20px;height:20px;display:inline-block; width:90px; " >政策采集</a> 
        </div>
        <div style="float: left; height: 500px; margin-top: 70px; line-height: 40px; width: 95%; margin-left: 19px;">
            <table border="0" style="width: 100%; height: 10%; padding: inherit; margin: 0 auto; border: thin solid #eac998;">
                <tr>
                    <td style="vertical-align: top; background-color: #F7F7DE" width="100%">

                        <asp:GridView ID="myGrid" Width="925px" Height="100%" runat="server"
                            CssClass="mGrid"
                            PagerStyle-CssClass="pgr" BackColor="White"
                            BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4"
                            ForeColor="Black" GridLines="Vertical" AllowPaging="True"
                            AutoGenerateColumns="False" PageSize="15" OnPageIndexChanging="myGrid_PageIndexChanging"
                            ShowHeaderWhenEmpty="True" OnRowDataBound="myGrid_RowDataBound">
                            <Columns>
                                <asp:BoundField DataField="id" HeaderText="编号">
                                    <HeaderStyle Width="30px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="采集网站" DataField="chinaname" />
                                <asp:BoundField HeaderText="采集栏目" DataField="classname" />
                                <asp:BoundField HeaderText="域名" DataField="domain" />
                                <asp:BoundField HeaderText="次数" DataField="cishu" />
                                <asp:BoundField HeaderText="正常" DataField="error" />
                                
                                <%--<asp:BoundField DataField="CName" HeaderText="企业名称"  />--%>
                                <%-- <asp:TemplateField HeaderText="企业名称">
                           
                                <ItemTemplate>                                 
                                    <a href="qiyelist.aspx?id=<%# Eval("CompanyID") %>" ><%# Eval("CName") %></a>   
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                                <%--      <asp:BoundField DataField="TechLevelname" HeaderText="技术水平" />
                                <asp:BoundField DataField="HangYeName" HeaderText="所属行业" />
                                <asp:BoundField DataField="ResultsTypeName" HeaderText="技术成果来源" />--%>
                                <%--       <asp:BoundField DataField="ShuiPingName" HeaderText="成果水平" />--%>
                                <%--   <asp:BoundField DataField="YYQKName" HeaderText="应用情况" />
                                <asp:BoundField DataField="JiaoYiName" HeaderText="交易状态" />--%>
                                <asp:BoundField DataField="lasttime" HeaderText="最后时间" DataFormatString="{0:yy-MM-dd HH:mm}" />

                                <asp:TemplateField HeaderText="操作">
                                    <ItemTemplate>
                                         
                                        <a href="zhengcecaiji.aspx?id=<%# Eval("ID") %>&p=<%=PgIndex %>" target="_blank">编辑</a>
                                  
                                        <asp:LinkButton ID="sc" runat="server" CommandArgument='<%# Eval("ID") %>' OnClientClick="if(confirm(&quot;确定要删除该项目数据么?&quot;)==false)return false;" OnCommand="sc_Command">删除</asp:LinkButton>

                                        
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="#CCCC99" />
                            <PagerSettings FirstPageText="&lt;&lt;" LastPageText="&gt;&gt;"
                                Mode="NumericFirstLast" />
                            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="center" />
                            <PagerTemplate>
                                <table border="0" style="width: 100%;">
                                    <tr>
                                        <td style="text-align: center; color: Black; font-size: 10pt; font-family: 宋体; text-decoration: none;">第<font style="font-family: Tahoma; color: Red"><%=PgIndex+ 1 %></font>页  
                    共<font style="font-family: Tahoma; color: Red"><%=PgCount %></font>页                   共<font style="font-family: Tahoma; color: Red"><%=RCount %></font>条                   
                    <asp:LinkButton ID="btnFirst" runat="server" CssClass="font_color" CausesValidation="False" CommandArgument="first" CommandName="Page" OnClick="btnGridView_Click" Text="首页" />
                                            <asp:LinkButton ID="btnPrev" runat="server" CssClass="font_color" CausesValidation="False" CommandArgument="prev" CommandName="Page" OnClick="btnGridView_Click" Text="上一页" />
                                            <asp:LinkButton ID="btnNext" runat="server" CssClass="font_color" CausesValidation="False" CommandArgument="next" CommandName="Page" OnClick="btnGridView_Click" Text="下一页" />
                                            <asp:LinkButton ID="btnLast" runat="server" CssClass="font_color" CausesValidation="False" CommandArgument="last" CommandName="Page" OnClick="btnGridView_Click" Text="尾页" />
                                            输入页码：<asp:TextBox ID="TextBox1" Width="30px" runat="server"></asp:TextBox> 
                                            <asp:LinkButton ID="btnGo" runat="server" CssClass="font_color" CausesValidation="False" CommandArgument="go" CommandName="Page" OnClick="btnGridView_Click" Text="跳转" />  
                                        </td>
                                    </tr>
                                </table>
                            </PagerTemplate>
                            <RowStyle BackColor="#F7F7DE" />
                            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#FBFBF2" />
                            <SortedAscendingHeaderStyle BackColor="#848384" />
                            <SortedDescendingCellStyle BackColor="#EAEAD3" />
                            <SortedDescendingHeaderStyle BackColor="#575357" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>

    </form>
</body>
</html>
