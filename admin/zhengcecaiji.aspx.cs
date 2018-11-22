using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Text;
using System.Collections;
using System.Text.RegularExpressions;
using System.Data;

public partial class admin_zhengcecaiji : System.Web.UI.Page
{
    ArrayList keyword;
    public int id = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        try {id = int.Parse(Request.QueryString["id"]); } catch { }
        
        if (!Page.IsPostBack)
        {
            
            if (Request.QueryString["id"].ToString() == "0")
            {
                
                Button1.Text = " 保存配制信息";
            }
            else
            {
                BindGridedit();
                Button1.Text = " 修改配制信息";
            }
            setting(2, cityid);  //地区
        }
    }
    private void setting(int itype, DropDownList ddlname)
    {
        DataTable dt = DBZhengce.getDataTable("SELECT  [ID],[Name]  FROM [dbo].[Setting] where SettingID=" + itype + "");
        ddlname.DataSource = dt;
        ddlname.DataTextField = "Name";
        ddlname.DataValueField = "ID";
        ddlname.DataBind();
        //ddlname.Items.Insert(0, new ListItem("全国", "0"));
        // ddlname.Text = "0";
    }
    private void BindGridedit()
    {
        DataTable dt;
        string sql = @"SELECT   *  FROM [dbo].[caijiset] where [id]='"+Request.QueryString["id"]+"'  ";

        dt = DBZhengce.getDataTable(sql);
        try
        {
            if (dt.Rows.Count > 0)
            {
                //string str = "";
                DataRow dr = dt.Rows[0];
                //ArrayList al2 = new ArrayList();
                //int i = 0;
                //foreach (DataRow dr in dt.Rows)
                //{
                //    keyword[i] = dr["Name"].ToString();
                //    i++;
                //    al2.Add(dr["Name"].ToString());
                //}
                //keyword = al2;
                chinaname.Text = dr["chinaname"].ToString();
                classname.Text = dr["classname"].ToString();
                url.Text = dr["url"].ToString();
                domain.Text = dr["domain"].ToString();
                startstr.Text = dr["startstr"].ToString();

                endstr.Text = dr["endstr"].ToString();
                configstart.Text = dr["configstart"].ToString();
                configend.Text = dr["configend"].ToString();
                textstart.Text = dr["textstart"].ToString();
                textend.Text = dr["textend"].ToString();

                fwhaostart.Text = dr["fwhaostart"].ToString();
                fwhaoend.Text = dr["fwhaoend"].ToString();

                cwdatestart.Text = dr["cwdatestart"].ToString();
                cwdateend.Text = dr["cwdateend"].ToString();

                fwjigoustart.Text = dr["fwjigoustart"].ToString();
                fwjigouend.Text = dr["fwjigouend"].ToString();

                fbriqistart.Text = dr["fbriqistart"].ToString();
                fbriqiend.Text = dr["fbriqiend"].ToString();

                urlstart.Text = dr["urlstart"].ToString();
                urlend.Text = dr["urlend"].ToString();

                titlestart.Text = dr["titlestart"].ToString();
                titleend.Text = dr["titleend"].ToString();

                cishu.Text = dr["cishu"].ToString();
                cityid.Text = dr["cityid"].ToString();

                error.Text = dr["error"].ToString();
            }
        }
        catch
        {
            //myGrid. = 0;

        }
        finally
        {

        }
    }
    private void BindGrid()
    {
        DataTable dt;
        string sql = @"SELECT   [ID]      ,[SettingID]      ,[Name]  FROM [dbo].[Setting] where [SettingID]='53' and (state=1 or state is null)";
       
        dt = DBqiye.getDataTable(sql);
        try
        {
            if (dt.Rows.Count > 0)
            {
                string str = "";
                //DataRow dr = dt.Rows[0];
                ArrayList al2 = new ArrayList();
                //int i = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    //keyword[i] = dr["Name"].ToString();
                    //i++;
                    al2.Add(dr["Name"].ToString());
                }
                keyword = al2;
            }
        }
        catch
        {
            //myGrid. = 0;
            
        }
        finally
        {

        }
    }

    protected void bc_Click(object sender, EventArgs e)
    {
        BindGrid();

        string urlfx =string.Empty;
        string title = string.Empty;
        if (url.Text.Trim() == "" || domain.Text.Trim() == "")
        {
            msg.Text="网址和域名不能为空!";
            return;
        }
        try
        {
            string Html = GetHtml(url.Text.Trim());
            string Introduce = Html.Substring(Html.IndexOf(startstr.Text.Trim()) );
            Introduce = Introduce.Remove(Introduce.IndexOf(endstr.Text.Trim()) ).Trim();
            ArrayList al = GetMatchesStr(Introduce, "<a[^>]*?>.*?</a>"); 
            //ArrayList al = GetMatchesStr(Html, @"href/s*=/s*(?:[/'/""/s](?<1>[^/""/']*)[/'/""])");//提取链接             
            StringBuilder sb = new StringBuilder();
            int i = 0;
            int icount = 0;
            foreach (object var in al)
            {
                string a = var.ToString().Replace("\"", "").Replace("'", ""); 
                a = Regex.Replace(a, "<a href=", "", RegexOptions.IgnoreCase | RegexOptions.Multiline);
                //string[] urlname = a.Split(' target=_blank>');
                urlfx = domain.Text.Trim() + a.Substring(0, a.IndexOf(" target=_blank>")); //提取url 地址
                title = a.Substring( a.IndexOf(" target=_blank>")+15);
                title = title.Replace("</a>","");
                if (a.StartsWith("/"))
                    a = "" + domain.Text.Trim() + a;
                if (!a.StartsWith("http://"))
                {
                    a = "http://" + a;
                }
                else
                {
                    a = "<a href=" + a;
                }
                bool bkeyword=false;
                foreach (object k1 in keyword)
                {
                    if (a.Contains(k1.ToString()))
                    {
                        bkeyword = true;
                        break;

                    }
                }
                //if (bkeyword)
                {
                    sb.Append(a + "/r/n");
                    i++;
                    icount+=GetHtmlfeixi(urlfx.Trim(),title);
                }

            }
            textBox5.Text = sb.ToString();//把提取到网址输出到一个textBox,每个链接占一行 



            msg.Text=("共提取" + al.Count.ToString() + "个链接,过滤关键词，插入数据库成功"+ icount + "条") ;

        }
        catch (Exception err)
        {
            msg.Text=("提取出错!原因:" + err.Message);
        }

    }

    public  int  GetHtmlfeixi(string url,string title)
    {
        int count = 0;
        string Html = GetHtml(url.Trim());
        try
        {
            Html = Html.ToString().Replace("\"", "").Replace("'", "");

            string xinxi = Html.Substring(Html.IndexOf(configstart.Text.Trim()));
            xinxi = xinxi.Remove(xinxi.IndexOf(configend.Text.Trim())).Trim();//信息
            //Response.Write( xinxi);

            string Introduce = Html.Substring(Html.IndexOf(textstart.Text.Trim())+7); //全文内容
            Introduce = Introduce.Remove(Introduce.IndexOf(textend.Text.Trim())).Trim();//内容
            bool bkeyword = false;
            foreach (object k1 in keyword)
            {
                if (Introduce.Contains(k1.ToString()) || title.Contains(k1.ToString()))
                {
                    bkeyword = true;
                    break;

                }
            }
            if (bkeyword)
            {
                //textBox5.Text = title.ToString()+"---|";
                //string sql = @"INSERT INTO [dbo].[zhengce]
                //               ([mingcheng]           ,[wenhao]           ,[faburiqi]           ,[fawendanwen]
                //               ,[cengji]           ,[buwensheng]           ,[gongcheng]           ,[lingyu]
                //               ,[yiju]           ,[mubiao]           ,[youxiaoqi]           ,[hangye]
                //               ,[chanpin]            ,[zhengceqw]           ,[zcywdizhi]         ,[state]           ,[createdate]
                //                          ,[userid])
                //         VALUES
                //               ('" + Common.strFilter(mingcheng.Text) + "','" + Common.strFilter(wenhao.Text) + "','" + Common.strFilter(faburiqi.Text) + "','" + Common.strFilter(fawendanwen.Text) + "','" +
                //                     Common.strFilter(cengji.SelectedValue) + "','" + Common.strFilter(buwensheng.Text) + "','" + Common.strFilter(gongcheng.Text) + "','" + Common.strFilter(lingyu.Text) + "','" +
                //                     Common.strFilter(yiju.Text) + "','" + Common.strFilter(mubiao.Text) + "','" + Common.strFilter(youxiaoqi.Text) + "','" + Common.strFilter(hangye.SelectedValue) + "','" +
                //                     Common.strFilter(chanpin.Text) + "','" + Common.strFilter(content.Text) + "','" + Common.strFilter(zcywdizhi.Text) + "',1,'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                //                     + "','" + Session["userid"] + "')";
                string wenhao = chuli(xinxi, "[发文字号]", "</span>",6);
                string faburiqi = chuli(xinxi, "[成文日期]", "</span>",6);
                string fawendanwen = chuli(xinxi, "[发文机构]", "</li>",6);
                string youxiaoqi = chuli(xinxi, "[发布日期]", "</span>", 6);
                string sql = @"INSERT INTO [dbo].[zhengce]
                               ([mingcheng]          ,[wenhao]           ,[faburiqi]           ,[fawendanwen],[youxiaoqi]
                                ,[zhengceqw]           ,[zcywdizhi]         ,[state]           ,[createdate]
                                          ,[userid],[caiji])
                         VALUES
                               ('" + Common.strFilter(title) + "','" + Common.strFilter(wenhao) + "','" + Common.strFilter(faburiqi) + "','" + Common.strFilter(fawendanwen)+ "','" + Common.strFilter(youxiaoqi) 
                               + "','" + Common.strFilter(Introduce) + "','" + Common.strFilter(url) + "',1,'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                                     + "','" + Session["userid"] + "',1)";
                count = DBZhengce.getRowsCount(sql);
            }

        }
        catch { return 0; }
        if (count > 0)
            return 1;
        else
            return 0;
    }
    public string  chuli(string text, string startstr,string  endstr,int ilen)
    {
        //string str = string.Empty;
        string str = text.Substring(text.IndexOf(startstr)+ ilen);
        str = str.Remove(str.IndexOf(endstr)).Trim();//内容
        str = str.Replace("<span>","");
        return str;
    }
    /// <summary> 
    /// 得到Html页面 
    /// </summary> 
    public static string GetHtml(string url)
    {
        StreamReader sr = null;
        string str = null;
        //读取远程路径 
        WebRequest request = WebRequest.Create(url);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        sr = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(response.CharacterSet));
        str = sr.ReadToEnd();
        sr.Close();
        return str;
    }

    // 提取HTML代码中的网址
    public static ArrayList GetMatchesStr(string htmlCode, string strRegex)
    {
        ArrayList al = new ArrayList();

        Regex r = new Regex(strRegex, RegexOptions.IgnoreCase | RegexOptions.Multiline);
        MatchCollection m = r.Matches(htmlCode);

        for (int i = 0; i < m.Count; i++)
        {
            bool rep = false;
            string strNew = m[i].ToString();

            // 过滤重复的URL 
            foreach (string str in al)
            {
                if (strNew == str)
                {
                    rep = true;
                    break;
                }
            }

            if (!rep) al.Add(strNew);
        }

        //al.Sort();

        return al;
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        string sql = "";

        if (id == 0)
        {

            //sql = "insert into zqhl_news([title],[content],classid,qz,pic,en,sel,writer,author,typename,cdate)values(";
            //sql += "'" + Common.strFilter(title.Text) + "','" + Common.strFilter(content1.Text.Replace("&emsp ", "&emsp;")) + "'," + classid + "," + Common.strFilter(qz.Text);
            //sql += ",'" + Common.strFilter(pic.Text) + "'," + ((en.Checked) ? "1" : "0") + "," + ((sel.Checked) ? "1" : "0") + ",'" + Common.strFilter(writer.Text) + "','" + Session["adminloginuser"] + "','" + cbtext1 + "','" + cdate.Text + "')";
            sql = @"INSERT INTO [dbo].[caijiset]
                        ([url]           ,[domain]           ,[startstr]           ,[endstr] 
                        ,[titlestart]           ,[titleend]           ,[urlstart]           ,[urlend]
                        ,[configstart]           ,[configend]           ,[textstart]           ,[textend]
                        ,[fwhaostart]           ,[fwhaoend]           ,[cwdatestart]           ,[cwdateend]
                        ,[fwjigoustart]           ,[fwjigouend]           ,[fbriqistart]           ,[fbriqiend]
                        ,[chinaname]           ,[classname]           ,[update]           ,[state], [userid],[cishu],[cityid],[error])
                   VALUES
                        ('" + Common.strFilter(url.Text) + "','" + Common.strFilter(domain.Text) + "','" + Common.strFilter(startstr.Text) + "','" + Common.strFilter(endstr.Text) + "','" +
                          Common.strFilter(titlestart.Text) + "','" + Common.strFilter(titleend.Text) + "','" + Common.strFilter(urlstart.Text) + "','" + Common.strFilter(urlend.Text) + "','" +
                          Common.strFilter(configstart.Text) + "','" + Common.strFilter(configend.Text) + "','" + Common.strFilter(textstart.Text) + "','" + Common.strFilter(textend.Text) + "','" +
                          Common.strFilter(fwhaostart.Text) + "','" + Common.strFilter(fwhaoend.Text) + "','" + Common.strFilter(cwdatestart.Text) + "','" + Common.strFilter(cwdateend.Text) + "','" +
                          Common.strFilter(fwjigoustart.Text) + "','" + Common.strFilter(fwjigouend.Text) + "','" + Common.strFilter(fbriqistart.Text) + "','" + Common.strFilter(fbriqiend.Text) + "','" +
                          Common.strFilter(chinaname.Text) + "','" + Common.strFilter(classname.Text) + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                          + "',1,'" + Session["userid"] + "','" + Common.strFilter(cishu.Text) + "','" + Common.strFilter(cityid.Text) + "',1)";
        }
        else
        {
            sql = @"UPDATE [dbo].[caijiset]
                         set [url]='" + Common.strFilter(url.Text) + "'           ,[domain]='" + Common.strFilter(domain.Text) + "'           ,[startstr]='" + Common.strFilter(startstr.Text) + "'           ,[endstr]='" + Common.strFilter(endstr.Text)
                         + "',[titlestart] ='" + Common.strFilter(titlestart.Text) + "'          ,[titleend]='" + Common.strFilter(titleend.Text) + "'           ,[urlstart]='" + Common.strFilter(urlstart.Text) + "'           ,[urlend]='" + Common.strFilter(urlend.Text)
                         + "',[configstart] ='" +Common.strFilter(configstart.Text) + "'          ,[configend]='" + Common.strFilter(configend.Text) + "'           ,[textstart]='" + Common.strFilter(textstart.Text) + "'           ,[textend]='" + Common.strFilter(textend.Text) 
                         + "',[fwhaostart]='" + Common.strFilter(fwhaostart.Text) + "'           ,[fwhaoend]='" + Common.strFilter(fwhaoend.Text) + "'           ,[cwdatestart]='" + Common.strFilter(cwdatestart.Text) + "'           ,[cwdateend]='" + Common.strFilter(cwdateend.Text) 
                         + "',[fwjigoustart]='" + Common.strFilter(fwjigoustart.Text) + "'           ,[fwjigouend]='" + Common.strFilter(fwjigouend.Text) + "'           ,[fbriqistart]='" + Common.strFilter(fbriqistart.Text) + "'           ,[fbriqiend]='" + Common.strFilter(fbriqiend.Text) 
                         + "',[chinaname]='" +  Common.strFilter(chinaname.Text) + "'           ,[classname]='" + Common.strFilter(classname.Text) + "'           ,[update]='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                         + "', [cishu]='" + Common.strFilter(cishu.Text) + "', [cityid]='" + Common.strFilter(cityid.Text) + "', [error]='" + Common.strFilter(error.Text) + "' WHERE id=" + id+"";
        }
       
        int count = DBZhengce.getRowsCount(sql);
        if (count > 0) msg.Text = "配制信息保存成功" ; else msg.Text = "保存失败" + sql;
        Response.Write("<script language=javascript >window.opener.location.reload('zhengcelist.aspx?id=0'); </script > ");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string sql = "";

        //if (id == 0)
        {

            //sql = "insert into zqhl_news([title],[content],classid,qz,pic,en,sel,writer,author,typename,cdate)values(";
            //sql += "'" + Common.strFilter(title.Text) + "','" + Common.strFilter(content1.Text.Replace("&emsp ", "&emsp;")) + "'," + classid + "," + Common.strFilter(qz.Text);
            //sql += ",'" + Common.strFilter(pic.Text) + "'," + ((en.Checked) ? "1" : "0") + "," + ((sel.Checked) ? "1" : "0") + ",'" + Common.strFilter(writer.Text) + "','" + Session["adminloginuser"] + "','" + cbtext1 + "','" + cdate.Text + "')";
            sql = @"INSERT INTO [dbo].[caijiset]
                        ([url]           ,[domain]           ,[startstr]           ,[endstr] 
                        ,[titlestart]           ,[titleend]           ,[urlstart]           ,[urlend]
                        ,[configstart]           ,[configend]           ,[textstart]           ,[textend]
                        ,[fwhaostart]           ,[fwhaoend]           ,[cwdatestart]           ,[cwdateend]
                        ,[fwjigoustart]           ,[fwjigouend]           ,[fbriqistart]           ,[fbriqiend]
                        ,[chinaname]           ,[classname]           ,[update]           ,[state], [userid],[cishu],[cityid],[error])
                   VALUES
                        ('" + Common.strFilter(url.Text) + "','" + Common.strFilter(domain.Text) + "','" + Common.strFilter(startstr.Text) + "','" + Common.strFilter(endstr.Text) + "','" +
                          Common.strFilter(titlestart.Text) + "','" + Common.strFilter(titleend.Text) + "','" + Common.strFilter(urlstart.Text) + "','" + Common.strFilter(urlend.Text) + "','" +
                          Common.strFilter(configstart.Text) + "','" + Common.strFilter(configend.Text) + "','" + Common.strFilter(textstart.Text) + "','" + Common.strFilter(textend.Text) + "','" +
                          Common.strFilter(fwhaostart.Text) + "','" + Common.strFilter(fwhaoend.Text) + "','" + Common.strFilter(cwdatestart.Text) + "','" + Common.strFilter(cwdateend.Text) + "','" +
                          Common.strFilter(fwjigoustart.Text) + "','" + Common.strFilter(fwjigouend.Text) + "','" + Common.strFilter(fbriqistart.Text) + "','" + Common.strFilter(fbriqiend.Text) + "','" +
                          Common.strFilter(chinaname.Text) + "','" + Common.strFilter(classname.Text) + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                          + "',1,'" + Session["userid"] + "','" + Common.strFilter(cishu.Text) + "','" + Common.strFilter(cityid.Text) + "',1)";
        }
        

        int count = DBZhengce.getRowsCount(sql);
        if (count > 0) msg.Text = "添加配制信息保存成功"+ classname.Text; else msg.Text = "保存失败" + sql;
        Response.Write("<script language=javascript >window.opener.location.reload('zhengcelist.aspx?id=0'); </script > ");
    }
}
