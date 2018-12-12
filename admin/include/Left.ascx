<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Left.ascx.cs" Inherits="admin_include_Left" %>
<div class="left" style="height:1000px;">
 		<ul>           
            <%if (Session["title"].ToString() == "1" || Session["title"].ToString() == "3"  ||  Session["title"].ToString() == "5")
                {%>
            <li id="list3" onclick="loadurl('xwlb.aspx',this);">新闻类别</li>
            <li id="list2" onclick="loadurl('xwgl.aspx',this);">新闻管理</li>
            <%--<li id="list6" onclick="loadurl('xtsz.aspx',this);">系统设置</li>--%>
            <li id="list5" onclick="loadurl('zjgl.aspx',this);">专家管理</li>
            <li id="list9" onclick="loadurl('tpxw.aspx',this);">图片管理</li>
            <%--     <li id="list1" onclick="loadurl('yhgl.aspx',this);">管理用户</li>--%>
              <%}
            if (Session["adminloginuser"].ToString() == "admin" ||  Session["title"].ToString() == "3")
            {%>
            <li id="list7" onclick="loadurl('zxsq.aspx',this);">在线申请</li>
            <%}
            if (Session["adminloginuser"].ToString() == "admin" )
            {%>           
            <li id="list13" onclick="loadurl('manage.aspx',this);">系统管理</li>
            <li id="list12" onclick="loadurl('setlist.aspx?type=2',this);">参数配制</li>                 
            <%}
            if (Session["title"].ToString() == "4"||  Session["title"].ToString() == "3"  ||  Session["title"].ToString() == "2" )  {%>
            <li id="list15" onclick="loadurl('mingpian.aspx',this);">名片管理</li>
            <%
            } if (Session["title"].ToString() == "2" ||  Session["title"].ToString() == "3" ||  Session["title"].ToString() == "5")
            {%>
            <li id="list10" onclick="loadurl('qygl.aspx',this);">企业管理</li>
            <%--<li id="list11" onclick="loadurl('Project.aspx',this);">项目管理</li>--%>
            <%--<li id="list14" onclick="loadurl('jscg.aspx',this);">技术成果</li>--%>
            <li id="list17" onclick="loadurl('Results.aspx',this);">项目成果</li>
            <li id="list25" onclick="loadurl('qiangji.aspx',this);">强基产品库</li>
            <li id="list26" onclick="loadurl('gongye.aspx',this);">工业强基库</li>
            <%--<li id="list26" onclick="loadurl('zhanshi.aspx',this);">展示产品库</li>--%>
            <li id="list24" onclick="loadurl('ResultWait.aspx',this);">待审成果</li>
            <li id="list22" onclick="loadurl('ResultXuQiu.aspx',this);">成果需求</li>
            <li id="list20" onclick="loadurl('ResultsInfo.aspx',this);">政策研究</li>
            <li id="list18" onclick="loadurl('LiuYan.aspx',this);">成果留言</li>
            <li id="list19" onclick="loadurl('diaocha.aspx',this);">调查问卷</li>
            <li id="list21" onclick="loadurl('ziyuan.aspx',this);">资&nbsp;&nbsp;源&nbsp;&nbsp;库</li>
            <li id="list28" onclick="loadurl('zhengce.aspx',this);">政策大数据</li>
            <li id="list27" onclick="loadurl('video.aspx',this);">视频管理</li>
            <%} %>
            <li id="list23" onclick="loadurl('baoming.aspx',this);">企业报名</li>
            <li id="list4" onclick="loadurl('xgmm.aspx',this);">个人信息</li>
            <a href="tc.aspx"><li id="list8" >退出管理</li></a>
        </ul>
    </div>
<script>
    <!-- 
    function loadmenu(n) {
        for (i = 1; i <= 14; i++) {
            if (i == n) {
                var pp = getElement("ps" + i);
                //var tab = getElement("tab" + i);
                pp.className = "titlea";
                //tab.style.display = "block";
            }
            else {
                var pp = getElement("ps" + i);
                //var tab = getElement("tab" + i);
                pp.className = "title";
                //tab.style.display = "none";
            }
        }
    }
    //--> 
</script> 