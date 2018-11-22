using System;
using System.Collections.Generic;
 
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class listzj : System.Web.UI.Page
{
    public int id = 0;
    public string classname = "";
    public int p = 1;
    public string pg = "";
    public int fl = 0;
    public string leftmenu = "";
    int ct = 14;
    public string content = "";
    public string zzinfo = "";
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
            dt = DBC.getDataTable("select * from zqhl_class where fl=" + fl + "   and typeid=1 order by fl asc,en asc,sx asc");
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


        }
        catch { }
        try
        {
            string fmt = "<a  target='_blank' href='showzj.aspx?id={0}&class={1}&fl={2}'><img src='{3}' width='140' height='160' /></a><div class='zjjs'><span>{4}（组长）</span><p>{5}</p><p>简介：{6}</p></div>";
            dt = DBC.getDataTable("select top 1 * from zqhl_zj where classid=" + id);
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                //第一项内容为专家组长，图片，组长，简介等
                //zzinfo = string.Format(fmt, dr["id"].ToString(), id, fl, dr["pic"].ToString(), dr["zjname"].ToString(), dr["zw"].ToString(), dr["zjjj"].ToString().Length > 20 ? dr["zjjj"].ToString().Substring(0, 19) + "..." : dr["zjjj"].ToString());
            }
            fmt = "<td><a  target='_blank' href='showzj.aspx?id={0}&class={1}&fl={2}'><img src='{3}' width='150' height='150' /></a><p>{4}</p><p>{5}</p></td>";
            dt = DBC.getDataTable("select * from zqhl_zj where zzf=0 and classid=" + id);
            int fb = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                if (fb == 0) content += "<tr>";
                content += string.Format(fmt, dr["id"].ToString(), id, fl, dr["pic"].ToString(), (dr["zjname"].ToString().Length > 9) ? dr["zjname"].ToString().Substring(0, 8) + ".." : dr["zjname"].ToString(), (dr["zw"].ToString().Length > 9) ? dr["zw"].ToString().Substring(0, 8) + ".." : dr["zw"].ToString());
                if (fb == 3) { fb = 0; content += "</tr>"; } else fb++;
            }
        }
        catch { }
    }
    public string loadnr(int classid, int length, int count, int page)//分类id，长度，条数
    {
        string rt = "";
        string format = "<li><div class='c1'><a  href ='shownews.aspx?id={0}' target='_blank'>{1}</a></div><div class='c2'>[{2}]</div></li>";
        try
        {
            DataTable dt = DBC.getDataTable("select top " + count + " * from zqhl_news where classid=" + classid + " order by qz desc,id desc");
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