using System;
using System.Collections.Generic;
 
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class admin_zj : System.Web.UI.Page
{
    public int id = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Common.isAdminLogin())
        {
            Response.Redirect("login.aspx");
            Response.End();
        }
        
        try
        {
            //this.zjjl1.Text = Request.Form["zjjl"];
            this.zjjj1.Text = Request.Form["zjjj"];
        }
        catch { }
        try
        {
            id = int.Parse(Request.QueryString["id"].ToString());
            if (!Page.IsPostBack)
            {
                zhongyao.Text = "11";
                DataTable dt = DBC.getDataTable("select * from zqhl_class where en=1 and fl=4 and typeid=1 order by fl asc,sx asc");
                classn.DataSource = dt;
                classn.DataTextField = "class";
                classn.DataValueField = "id";
                classn.DataBind();

                dt = DBqiye.getDataTable("  SELECT  ID,Name  FROM Setting WHERE (SettingID = 34) and state=1");
                fenlei.DataSource = dt;
                fenlei.DataTextField = "Name";
                fenlei.DataValueField = "ID";
                fenlei.DataBind();
                fenlei.Items.Insert(0, new ListItem("==请选择==", "0"));
                //fenlei.SelectedValue = "";
                if (id != 0)
                {
                    dt = DBC.getDataTable("select * from zqhl_zj where id=" + id);
                    if (dt.Rows.Count > 0)
                    {
                        DataRow dr = dt.Rows[0];
                        zjname.Text = dr["zjname"].ToString();
                        zw.Text = dr["zw"].ToString();
                        pic.Text = dr["pic"].ToString();
                        pic1.Text = dr["yuantu"].ToString();
                        //qz.Text = dr["qz"].ToString();
                        //pic.Text = dr["pic"].ToString();
                        zzf.Checked = (dr["zzf"].ToString() == "0" ? false : true);
                        indexview.Checked = (dr["indexview"].ToString() == "0" ? false : true);
                        zhanhui.Checked = (dr["zhanhui"].ToString() == "0" ? false : true);
                        content.Text = dr["zjjj"].ToString();
                        //zjjl.Text = dr["zjjl"].ToString();
                        zhongyao.Text = dr["zhongyao"].ToString();
                        //sel.Checked = (dr["sel"].ToString() == "0" ? false : true);
                        //try
                        //{
                        //    cdate.Text = DateTime.Parse(dr["cdate"].ToString()).ToString("yyyy-MM-dd");
                        //}
                        //catch { }
                        try
                        {
                            classn.Items.FindByValue(dr["classid"].ToString()).Selected = true;
                            fenlei.Items.FindByValue(dr["feilei"].ToString()).Selected = true;
                        }
                        catch { }
                        
                    }
                }
            }
        }
        catch { }

        try
        {

        }
        catch { }
    }

    protected void scfile_Click(object sender, EventArgs e)
    {
        msg.Text = "";
        if (!upfile.HasFile) { msg.Text = "请选择文件后上传"; return; }
        if (upfile.FileBytes.Length > 1024 * 1024)
        { msg.Text = "文件不能大于1M"; return; }
        string ext = upfile.FileName.Substring(upfile.FileName.Length - 3).ToLower();
        if (ext != "png" && ext != "jpg" && ext != "gif")
        {
            msg.Text = "文件格式只能是png或jpg或gif"; return;
        }
        string file = DateTime.Now.ToString("yyyMMddHHmmss.ss");
        string filename = Server.MapPath("../upload/") + file + "." + ext;
        string yuanfile = Server.MapPath("../yuan/upload/") + file + "." + ext;
        upfile.SaveAs(yuanfile);
        try
        {
            imgtext.BuildWatermark(yuanfile, Server.MapPath("/") + "/images/shunyin250.png", "www.kjcgjy.com", filename);
        }
        catch { msg.Text += filename + ";错"; }
        pic.Text = "/upload/" + file + "." + ext;
    }
    protected void scfile1_Click(object sender, EventArgs e)
    {
        msg.Text = "";
        if (!upfile1.HasFile) { msg.Text = "请选择文件后上传"; return; }
        if (upfile1.FileBytes.Length > 1024 * 1024)
        { msg.Text = "文件不能大于1M"; return; }
        string ext = upfile1.FileName.Substring(upfile1.FileName.Length - 3).ToLower();
        if (ext != "png" && ext != "jpg" && ext != "gif")
        {
            msg.Text = "文件格式只能是png或jpg或gif"; return;
        }
        string file = DateTime.Now.ToString("yyyMMddHHmmss.ss");
        string filename = Server.MapPath("../upload/") + file + "." + ext;
        string yuanfile = Server.MapPath("../yuan/upload/") + file + "." + ext;
        upfile1.SaveAs(yuanfile);
        //try
        //{
        //    imgtext.BuildWatermark(yuanfile, Server.MapPath("/") + "/images/shunyin250.png", "www.kjcgjy.com", filename);
        //}
        //catch { msg.Text += filename + ";错"; }
        pic1.Text = "/yuan/upload/" + file + "." + ext;
    }

    protected void bc_Click(object sender, EventArgs e)
    {
        string sql = "";
        if (id == 0)
        {
            if (Session["userid"].ToString() == "13" || Session["userid"].ToString() == "41")//只有超级管理员
            {
                sql = "insert into zqhl_zj([zjname],[zw],classid,pic,zzf,indexview,zjjj,userid,feilei,zhongyao,zhanhui,yuantu)values(";
                sql += "'" + Common.strFilter(zjname.Text) + "','" + Common.strFilter(zw.Text) + "'," + classn.SelectedValue + ",";
                sql += "'" + Common.strFilter(pic.Text) + "'," + ((zzf.Checked) ? "1" : "0") + "," + ((indexview.Checked) ? "1" : "0") + ",'" + Common.strFilter(content.Text) + "','" + Session["userid"] + "'," + fenlei.SelectedValue + ",'" + Common.strFilter(zhongyao.Text) + "','" + ((zhanhui.Checked) ? "1" : "0") + "','" + Common.strFilter(pic1.Text) + "')";
            }
            else 
            {
                sql = "insert into zqhl_zj([zjname],[zw],classid,pic,zzf,indexview,zjjj,userid,feilei,zhongyao,zhanhui,yuantu)values(";
                sql += "'" + Common.strFilter(zjname.Text) + "','" + Common.strFilter(zw.Text) + "'," + classn.SelectedValue + ",";
                sql += "'" + Common.strFilter(pic.Text) + "',0,0,'" + Common.strFilter(content.Text) + "','" + Session["userid"] + "'," + fenlei.SelectedValue + ",'" + Common.strFilter(zhongyao.Text) + "','0','" + Common.strFilter(pic1.Text) + "')";
            }
            
        }
        else
        {
            if (Session["userid"].ToString() == "13" || Session["userid"].ToString() == "41")//只有超级管理员
            {
                sql = "update zqhl_zj set [zjname]='" + Common.strFilter(zjname.Text) + "',[zw]='" + Common.strFilter(zw.Text) + "',classid=" + classn.SelectedValue;
                sql += ",pic='" + Common.strFilter(pic.Text) + "',zzf=" + ((zzf.Checked) ? "1" : "0") + ",indexview=" + ((indexview.Checked) ? "1" : "0") + ",zjjj='" + Common.strFilter(content.Text) + "',feilei=" + fenlei.SelectedValue + ",zhongyao='" + Common.strFilter(zhongyao.Text) + "',zhanhui='" + ((zhanhui.Checked) ? "1" : "0") + "',yuantu='" + Common.strFilter(pic1.Text) + "' where id=" + id;
            }
            else
            {
                sql = "update zqhl_zj set [zjname]='" + Common.strFilter(zjname.Text) + "',[zw]='" + Common.strFilter(zw.Text) + "',classid=" + classn.SelectedValue;
                sql += ",pic='" + Common.strFilter(pic.Text) + "',zjjj='" + Common.strFilter(content.Text) + "',feilei=" + fenlei.SelectedValue + ",zhongyao='" + Common.strFilter(zhongyao.Text) + "',yuantu='" + Common.strFilter(pic1.Text) + "' where id=" + id;
            }
        }
        int count = DBC.getRowsCount(sql);
        if (count > 0) msg.Text = "保存成功"; else msg.Text = "保存失败";
    }
}