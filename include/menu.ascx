<%@ Control Language="C#" AutoEventWireup="true" CodeFile="menu.ascx.cs" Inherits="include_menu" %>
<div class="top">
    <div class="top_con">
        <div class="top_dz">
            <a href="http://www.miit-kjcg.org/login.aspx">登录</a>
            <a>|</a>
            <a href="http://www.miit-kjcg.org/reg.aspx">注册</a>
        </div>
        <div class="top_title">
            <div class="top_logo"></div>
            <div class="top_title_con">
                <h1>工信部电子情报所科技成果评价与推广转化服务中心</h1>
            </div>
        </div>
        <div class="shezhi">
            <a onclick="SetHome(window.location)" href="javascript:void(0)">设为首页</a>
            <a>|</a>
            <a onclick="AddFavorite(window.location,document.title)" href="javascript:void(0)">收藏本站</a>
        </div>
        <div class="nav">
            <ul class="ul1">
                <%=mustring %>
            </ul>
        </div>
    </div>
</div>