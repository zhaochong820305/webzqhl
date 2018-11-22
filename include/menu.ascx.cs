using System;
using System.Collections.Generic;
 
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class include_menu : System.Web.UI.UserControl
{
    public string mustring = "";
    public int fl = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            fl = int.Parse(Request.QueryString["fl"].ToString());
        }
        catch { }
        DataTable dt = DBC.getDataTable("select * from zqhl_class where en<2 and typeid=1 order by fl asc,en asc,sx asc");
        mustring = "<li class='li1 " + ((fl == 0) ? "active1" : "") + "'><a href=' /'>首&nbsp;页</a></li>";
        int lm = 0;
        int first = 0;
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            DataRow dr = dt.Rows[i];
            if (lm.ToString() != dr["fl"].ToString())
            {
                lm = int.Parse(dr["fl"].ToString());
                if (first != 0)
                { mustring += "</ul></li> "; }
                else { first = 1; }
                mustring += "<li class='li1 " + ((fl == lm) ? "active1" : "") + "'><a href='" + ((lm == 4) ? "listzj" : "list") + ".aspx?fl=" + dr["fl"].ToString() + "'>" + dr["class"].ToString() + "</a><ul class='ul3'>";

            }
            else
            {
                mustring += "<li class='li3 hx'><a href='" + ((lm == 4) ? "listzj" : "list") + ".aspx?class=" + dr["id"].ToString() + "&fl=" + dr["fl"].ToString() + "'>" + dr["class"].ToString() + "</a></li>";
            }
        }
        mustring += "<li class='li3 hx'><a href='zxsq.aspx?class=0&fl=5'>在线申请</a></li>";
        mustring += "<li class='li3 hx'><a href='lxwm.aspx?class=0&fl=5'>联系我们</a></li>";
        mustring += "</ul></li> ";
    }
}