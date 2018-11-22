using System;
using System.Collections.Generic;
 
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class shownews : System.Web.UI.Page
{
    public string title = "";
    public string content = "";
    public string writer = "";
    public string cdate = "";
    public int id = 0;
    public string leftmenu = "";
    public int fl = 0;
    public string flm = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            id = int.Parse(Request.QueryString["id"].ToString());
        }
        catch { }
        //try
        //{
        //    fl = int.Parse(Request.QueryString["fl"].ToString());
        //}
        //catch { }
        try
        {
            DataTable dta = DBC.getDataTable("select *,flm=(select top 1 [class] from zqhl_class a where a.id=b.classid),fl=(select top 1 fl from zqhl_class a where a.id=b.classid) from zqhl_news b where b.id=" + id);
            if (dta.Rows.Count > 0)
            {
                DataRow dr = dta.Rows[0];
                title = dr["title"].ToString();
                content = dr["content"].ToString();
                content = content.Replace(title, "");
                content = content.Replace("&emsp ", "&emsp;");
                writer = dr["writer"].ToString();
                cdate = dr["cdate"].ToString();
                fl = int.Parse(dr["fl"].ToString());
                flm = dr["flm"].ToString();
            }
        }
        catch { }
        DataTable dt;
        try//左侧菜单
        {
            dt = DBC.getDataTable("select * from zqhl_class where fl=" + fl + "  and typeid=1  order by fl asc,en asc,sx asc");
            string lm = "0";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                if (lm != dr["fl"].ToString())
                {
                    leftmenu = "<div class='con-nav'>" + dr["class"].ToString() + "</div>";
                    lm = dr["fl"].ToString();

                }
                else
                {
                    leftmenu += "<div class='con-nav-s'><a  target='_blank' href='list.aspx?class=" + dr["id"].ToString() + "&fl=" + fl + "' class='" + ((id.ToString() != dr["id"].ToString()) ? "con-nav-sa" : "con-nav-sactive") + "'>" + dr["class"].ToString() + "</a>   </div>";
                }
            }
        }
        catch { }
    }
}