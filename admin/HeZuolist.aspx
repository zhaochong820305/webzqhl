<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HeZuolist.aspx.cs" Inherits="admin_HeZuolist" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="css/qiyegl.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <hr />项目合作需求： <a href="HeZuo.aspx?pid=<%=pid%>&op=add"  class="buttonLB1">添加</a> <a href="Project.aspx" class="buttonLB1">返回项目列表</a>   <asp:Label ID="Label1" runat="server" ></asp:Label>
&nbsp;<asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CssClass="gridtable">
            <Columns>
                
                <asp:BoundField DataField="TName" HeaderText="合作类别" />
                <asp:BoundField DataField="MName" HeaderText="合作方行业" />
                <asp:BoundField DataField="EName" HeaderText="合作方企业性质" />
                <asp:BoundField DataField="Scale" HeaderText="合作方企业规模" />
                <asp:BoundField DataField="Description" HeaderText="描述" />
                <asp:BoundField DataField="CreateDate" HeaderText="创建时间" />
                
                <asp:TemplateField HeaderText="操作">
                    <ItemTemplate>
                        <%--<asp:LinkButton ID="bj" runat="server" CommandArgument='<%# Eval("ID") %>' OnCommand="bj_Command">报表</asp:LinkButton>--%>
                        <a href="HeZuo.aspx?id=<%# Eval("ID") %>&op=kan&pid=<%=pid%>" >查看</a>   
                        <a href="HeZuo.aspx?id=<%# Eval("ID") %>&op=edit&pid=<%=pid%>" >编辑</a> 
                        <asp:LinkButton ID="sc" runat="server" CommandArgument='<%# Eval("ID") %>' OnClientClick="if(confirm(&quot;确定要删除该项目合作需求数据么?&quot;)==false)return false;" OnCommand="sc_Command">删除</asp:LinkButton>                                    
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
