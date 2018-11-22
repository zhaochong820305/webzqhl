using System;
using System.Collections.Generic;
 
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class include_top : System.Web.UI.UserControl
{
    public string mustring = string.Empty;
    public int fl = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            fl = int.Parse(Request.QueryString["fl"].ToString());
        }
        catch { }
        mustring  = "<li class='li1 " + ((fl == 0) ? "active1" : "") + "'><a href=' /'>首&nbsp;页</a></li>";
        mustring += "<li class='li1 " + ((fl == 1) ? "active1" : "") + "'><a href=' /'>关于联盟</a>";
        mustring += "<ul class='ul3'>";
        mustring += "<li class='li3 hx'><a href=' /'>关于联盟1</a></li>";
        mustring += "<li class='li3 hx'><a href=' /'>关于联盟2</a></li>";
        mustring += "<li class='li3 hx'><a href=' /'>关于联盟3</a></li>";
        mustring += "</ul></li>";
        mustring += "<li class='li1 " + ((fl == 1) ? "active1" : "") + "'><a href=' /'>联盟动态</a>";
        mustring += "<ul class='ul3'>";
        mustring += "<li class='li3 hx'><a href=' /'>联盟动态1</a></li>";
        mustring += "<li class='li3 hx'><a href=' /'>联盟动态2</a></li>";
        mustring += "<li class='li3 hx'><a href=' /'>联盟动态3</a></li>";
        mustring += "</ul></li>";
        mustring += "<li class='li1 " + ((fl == 1) ? "active1" : "") + "'><a href=' /'>行业动态</a></li>";
        
        mustring += "<li class='li1 " + ((fl == 1) ? "active1" : "") + "'><a href=' /'>行业专家</a></li>";
        
        mustring += "<li class='li1 " + ((fl == 1) ? "active1" : "") + "'><a href=' /'>成员发布</a></li>";
         
        mustring += "<li class='li1 " + ((fl == 1) ? "active1" : "") + "'><a href=' /'>资源共享</a></li>";
        
        mustring += "<li class='li1 " + ((fl == 1) ? "active1" : "") + "'><a href=' /'>申请加入</a></li>";
        

    }
}