using System;
using System.Collections.Generic;
 
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class list : System.Web.UI.Page
{
    public int id = 0;
    public string classname = "";
    public int p = 1;
    public string pg = "";
    public int fl = 0;
    public string leftmenu = "";
    int ct = 14;
    public string content = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            id = int.Parse(Request.QueryString["class"].ToString());
        }
        catch { }
        try
        {
            p = int.Parse(Request.QueryString["p"].ToString());
        }
        catch { }
        try
        {
            fl = int.Parse(Request.QueryString["fl"].ToString());
        }
        catch { }
        DataTable dt;
        try//左侧菜单
        {
            dt = DBC.getDataTable("select * from zqhl_class where fl=" + fl + " and typeid=1 order by fl asc,en asc,sx asc");
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
                    leftmenu += "<div class='con-nav-s'><a  target='_blank' href='" + ((lm == "4") ? "listzj" : "list") + ".aspx?class=" + dr["id"].ToString() + "&fl=" + fl + "' class='" + ((id.ToString() != dr["id"].ToString()) ? "con-nav-sa" : "con-nav-sactive") + "'>" + dr["class"].ToString() + "</a>   </div>";
                }
            }
            if (lm == "5")
            {
                leftmenu += "<div class='con-nav-s'><a  target='_blank' href='zxsq.aspx?class=0&fl=5' class='con-nav-sa'>在线申请</a>   </div>";
                leftmenu += "<div class='con-nav-s'><a  target='_blank' href='lxwm.aspx?class=0&fl=5' class='con-nav-sa'>联系我们</a>   </div>";
            }
        }
        catch { }
        try
        {
            int one = 0;
            if (id == 0)
            {
                dt = DBC.getDataTable("select * from zqhl_class where fl=" + fl + " order by fl asc,en asc,sx asc");
                if (dt.Rows.Count > 1)
                {
                    classname = dt.Rows[1]["class"].ToString();
                    int.TryParse(dt.Rows[1]["one"].ToString(), out one);
                    int.TryParse(dt.Rows[1]["id"].ToString(), out id);
                }
            }
            else
            {
                dt = DBC.getDataTable("select * from zqhl_class where id=" + id + " order by fl asc,en asc,sx asc");
                if (dt.Rows.Count > 0)
                {
                    classname = dt.Rows[0]["class"].ToString();
                    int.TryParse(dt.Rows[0]["one"].ToString(), out one);
                }
            }
            if (one == 0)//多条
            {
                dt = DBC.getDataTable("select count(*) from zqhl_news where classid=" + id);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i <= (int)(int.Parse(dt.Rows[0][0].ToString()) / ct); i++)
                    {
                        pg += "<a  target='_blank' href='list.aspx?fl=" + fl + "&class=" + id + "&p=" + (i + 1) + "'>" + (i + 1) + "</a>";
                    }
                }
                content = "<div class='conh-con'><div class='conh-con-c'><ul>";
                content += loadnr(id, 40, 14, p);
                content += " </ul></div><div class='yema'><a  target='_blank' href='#'>&lt;&lt;</a>" + pg + "<a href='#'>&gt;&gt;</a></div></div>";
            }
            else//单独
            {
                dt = DBC.getDataTable("select top 1 * from zqhl_news where classid=" + id);
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    content = "<div class='conn-con'><div class='conn-con-c1'>";
                    content += dr["content"].ToString();
                    content += "</div></div>";
                }
            }

        }
        catch { }
    }
    public string loadnr(int classid, int length, int count, int page)//分类id，长度，条数
    {
        string rt = "";
        string format = "<li><div class='c1'><a  target='_blank' href ='shownews.aspx?id={0}'>{1}</a></div><div class='c2'>[{2}]</div></li>";
        try
        {
            string sql = "select top " + count + " * from zqhl_news  where classid = " + classid + " ";
            if (page > 1)
            {
                sql += " AND id <(SELECT ISNULL(min(id),0)  FROM  ( SELECT TOP(" + count + " * (" + page + "-1)) id FROM [zqhl_news] where    classid = " + classid + "   ORDER BY qz desc,id desc ) A)";
            }
            sql += " order by  qz desc,   id desc";
            DataTable dt = DBC.getDataTable(sql);

            foreach (DataRow dr in dt.Rows)
            {
                string tmp = dr["title"].ToString();
                if (tmp.Length > length - 2) { tmp = tmp.Substring(0, length - 2) + "..."; }
                rt += string.Format(format, dr["id"].ToString(), tmp, DateTime.Parse(dr["cdate"].ToString()).ToString("yyyy-MM-dd"));
            }
        }
        catch (Exception ex) { Common.WriteDiskLog("loadnr:" + ex.Message); }
        return rt;
    }
}