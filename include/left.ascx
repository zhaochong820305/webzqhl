<%@ Control Language="C#" AutoEventWireup="true" CodeFile="left.ascx.cs" Inherits="include_left" %>

 <div  class="index_con" >
                
                <ul class="leftmenu">
    <li class="header">企业信息</li>
    <% if (Session["usertypes"].ToString() == "211")
        { %>
    <li class="item"><a href="/comperson.aspx">基本信息</a></li>
    <% }
    else
    {%>
    <li class="item"><a href="/comindex.aspx?type=1">基本信息</a></li>
     <%} %>
    <li class="item"><a href="/comindex.aspx?type=4">财务数据</a></li>
    <li class="item"><a href="/comindex.aspx?type=5">管理团队</a></li>
    <li class="item"><a href="/comindex.aspx?type=2">上市规划</a></li>
    <li class="item"><a href="/comindex.aspx?type=6">股权激励</a></li>
   
    <li class="item"><a href="/comindex.aspx?type=7">企业LOGO</a></li>    
    
     <% if (1 == 2)
        { %>

  
    <li class="item"><a href="">项目列表</a></li>

                    <%} %>
    <li class="header">发布信息</li>
    <li class="item"><a href="/comindex.aspx?type=10">企业动态</a></li>
    <li class="item"><a href="/comindex.aspx?type=8">需求信息</a></li>
    <li class="header">帐户管理</li>
    <li class="item"><a href="comindex.aspx?type=9" style="padding-right:20px;">联系客户经理</a></li>
    
    <li class="item"><a href="comxgmm.aspx">修改密码</a></li>
</ul>
</div>
