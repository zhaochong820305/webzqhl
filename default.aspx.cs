using System;
using System.Collections.Generic;
 
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
public partial class _defaulto : System.Web.UI.Page
{
    public string pic = "";
    public string pictxt = "";
    //DateTime etime = DateTime.Parse(Etime.Text.ToString()).ToString("yyyy-MM-dd");
    protected void Page_Load(object sender, EventArgs e)
    {

        //string rt = "";
        string format = "<a href='{2}' target='_blank'><img id='slide-img-{1}' src='{0}' class='slide' alt=''  width='100%' height='400'/></a>";
        string formatxt = "{{\"id\":\"slide-img-{0}\",\"client\":\"\",\"desc\":\"{1}\"}}";
        try
        {
            DataTable dt = DBC.getDataTable("select top 3 * from zqhl_pic where typeid=1  order by qz,id desc");
            int ia = 1;
            foreach (DataRow dr in dt.Rows)
            {
                string tmp = dr["pic"].ToString();
                pic += string.Format(format, tmp, ia, dr["link"].ToString());
                if (pictxt.Length > 0)
                {
                    pictxt += "," + string.Format(formatxt, ia, dr["title"].ToString());
                }
                else
                {
                    pictxt = string.Format(formatxt, ia, dr["title"].ToString());
                }
                //pictxt = "";
                ia++;
            }
        }
        catch (Exception ex) { Common.WriteDiskLog("loadnr:" + ex.Message); }
    }
    public string loadnr(int classid, int length, int count)//分类id，长度，条数
    {
        string rt = "";
        string format = "<li><div class='c1'><a target='_blank' href ='shownews.aspx?id={0}'>{1}</a></div><div class='c2'>[{2}]</div></li>";
        try
        {
            DataTable dt = DBC.getDataTable("select top " + count + " * from zqhl_news where classid=" + classid + " order by qz desc,id desc");
            foreach (DataRow dr in dt.Rows)
            {
                string tmp = dr["title"].ToString();
                if (tmp.Length > length - 2) { tmp = tmp.Substring(0, length - 2) + "..."; }
                rt += string.Format(format, dr["id"].ToString(), tmp, DateTime.Parse(dr["cdate"].ToString()).ToString("yyyy-MM-dd"));
            }
            rt += "<li><div class='c1'><a target='_blank' href ='list.aspx?class=" + classid + "&fl=1'>更多...</a></li>";
        }
        catch (Exception ex) { Common.WriteDiskLog("loadnr:" + ex.Message); }
        return rt;
    }
    public string loadnr(int classid, int f1, int length, int count)//分类id，长度，条数
    {
        string rt = "";
        string format = "<li><div class='c1'><a target='_blank' href ='shownews.aspx?id={0}'>{1}</a></div><div class='c2'>[{2}]</div></li>";
        try
        {
            DataTable dt = DBC.getDataTable("select top " + count + " * from zqhl_news where classid=" + classid + " order by qz desc,id desc");
            foreach (DataRow dr in dt.Rows)
            {
                string tmp = dr["title"].ToString();
                //if (tmp.Length > length - 2) { tmp = tmp.Substring(0, length - 2) + "..."; }
                tmp = stringformat(tmp, length);
                rt += string.Format(format, dr["id"].ToString(), tmp, DateTime.Parse(dr["cdate"].ToString()).ToString("yyyy-MM-dd"));
            }
            rt += "<p align='right' class='gengduo'><br><a target='_blank' href ='list.aspx?class=" + classid + "&fl=" + f1 + "'>[更多...]</a>";
        }
        catch (Exception ex) { Common.WriteDiskLog("loadnr:" + ex.Message); }
        return rt;
    }

    public string stringformat(string str, int n)
    {
        ///
        ///格式化字符串长度，超出部分显示省略号,区分汉字跟字母。汉字2个字节，字母数字一个字节
        ///
        string temp = string.Empty;
        if (System.Text.Encoding.Default.GetByteCount(str) <= n)//如果长度比需要的长度n小,返回原字符串
        {
            return str;
        }
        else
        {
            int t = 0;
            char[] q = str.ToCharArray();
            for (int i = 0; i < q.Length; i++)
            {
                if ((int)q[i] >= 0x4E00 && (int)q[i] <= 0x9FA5)//是否汉字
                {
                    temp += q[i];
                    t += 2;
                }
                else
                {
                    if (2 == Encoding.Default.GetByteCount(q[i].ToString()))//判断是否为全角
                    {
                        temp += q[i];
                        t += 2;
                    }
                    else
                    {
                        temp += q[i];
                        t += 1;
                    }

                }
                if (t >= n)
                {
                    break;
                }
            }
            return (temp + "...");
        }
    }
    public string loadabout(int classid, int length, int count)//分类id，长度，条数
    {
        string rt = "";
        string format = "<li><div class='c1a'><a target='_blank' href ='shownews.aspx?id={0}'>{1}</a></div></li>";
        try
        {
            DataTable dt = DBC.getDataTable("select top " + count + " * from zqhl_news where classid=" + classid + " and title <>'' order by qz desc,id desc");
            foreach (DataRow dr in dt.Rows)
            {
                string tmp = dr["title"].ToString();
                // if (tmp.Length > length - 2) { tmp = tmp.Substring(0, length - 2) + "..."; }
                tmp = stringformat(tmp, length);
                rt += string.Format(format, dr["id"].ToString(), tmp);
            }
            rt += "<p align='right' class='gengduo'><br><a target='_blank' href ='list.aspx?class=" + classid + "&fl=6'>[更多...]</a></p>";
        }
        catch (Exception ex) { Common.WriteDiskLog("loadnr:" + ex.Message); }
        return rt;
    }

    public string loadpic(int count)//分类id，长度，条数
    {
        string rt = "";
        string format = "<a><img id='slide-img-{1}' src='{0}' class='slide' alt=''  width='100%' height='400'/></a>";
        try
        {
            DataTable dt = DBC.getDataTable("select top " + count + " * from zqhl_pic  order by qz,id desc");
            int ia = 1;
            foreach (DataRow dr in dt.Rows)
            {
                string tmp = dr["pic"].ToString();
                rt += string.Format(format, tmp, ia);
                ia++;
            }
        }
        catch (Exception ex) { Common.WriteDiskLog("loadnr:" + ex.Message); }
        return rt;
    }
    public string loadfw(int count)//分类id，长度，条数
    {
        string rt = "";
        string format = " <td><a  target='_blank' href='shownews.aspx?id={0}'><img class='fwqyimg' src='{1}'/><div class='fwqy_con_biaoti'>{2}</div></a></td>"; //" <li class='fwqy_con_li'><img src='{0}'/><div class='fwqy_con_biaoti'>{1}</div></li>";
        try
        {
            DataTable dt = DBC.getDataTable("select top " + count + " * from zqhl_news where sel=1 and en=1 and pic<>'' order by qz desc,id desc");
            int ia = 1;
            foreach (DataRow dr in dt.Rows)
            {
                string tmp = dr["title"].ToString();
                if (tmp.Length > 10) tmp = tmp.Substring(0, 10) + "...";
                rt += string.Format(format, dr["id"].ToString(), dr["pic"].ToString(), tmp);
                ia++;
            }
        }
        catch (Exception ex) { Common.WriteDiskLog("loadfw:" + ex.Message); }
        return rt;
    }
    public string loadzjtd(int count)//分类id，长度，条数
    {
        string rt = "";
        string format = "<li><a  target='_blank' href='showzj.aspx?id={0}&class={1}&fl={2}' class='aa' style='background:url({6}) no-repeat center center/cover;'><span>{3}{4}{5}</span></a></li>";//"<li style='background:url({4}) no-repeat center center/cover;'><a href='showzj.aspx?id={0}&class={1}&fl={2}' class='aa' ><span>{3}</span></a></li>";//"<li><a href='showzj.aspx?id={0}&class={1}&fl={2}'><img src='{3}' width='150px' height='188px' /><p>{4}{5}<br />{6}</p></a></li>";// "<li style='background:url({4}) no-repeat center center/cover;'><a href='showzj.aspx?id={0}&class={1}&fl={2}' class='aa' ><span>{3}</span></a></li>";
        try
        {
            DataTable dt = DBC.getDataTable("select top " + count + " *,fl=(select top 1 fl from zqhl_class a where a.id=b.classid) from zqhl_zj b  order by id desc");
            foreach (DataRow dr in dt.Rows)
            {
                string tmp = dr["zjname"].ToString();
                rt += string.Format(format, dr["id"].ToString(), dr["classid"].ToString(), dr["fl"].ToString(), dr["zjname"].ToString(), (dr["zzf"].ToString() != "0") ? "（组长）" : "", dr["zw"].ToString(), dr["pic"].ToString());// (dr["zzf"].ToString()!="0")?"（组长）":"",dr["zw"].ToString());
            }
        }
        catch (Exception ex) { Common.WriteDiskLog("loadnr:" + ex.Message); }
        return rt;
    }
    public string loadzjclass(int fl, int count)//分类id，长度，条数
    {
        string rt = "";
        string format = "<li class='xx'><a  target='_blank' href='listzj.aspx?class={0}&fl={1}'>{2}</a></li>";
        try
        {
            DataTable dt = DBC.getDataTable("select top " + count + " * from zqhl_class where en=1 and fl=" + fl + " order by fl,sx");
            foreach (DataRow dr in dt.Rows)
            {
                string tmp = dr["class"].ToString();
                //if (tmp.Length > length - 2) { tmp = tmp.Substring(0, length - 2) + "..."; }
                rt += string.Format(format, dr["id"].ToString(), fl, tmp);
            }
            for (int i = dt.Rows.Count; i < count; i++)
            {
                rt += "<li class='xx'>&nbsp;</li>";
            }
        }
        catch (Exception ex) { Common.WriteDiskLog("loadnr:" + ex.Message); }
        return rt;
    }
}