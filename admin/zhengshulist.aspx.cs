using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
public partial class admin_zhengshulist : System.Web.UI.Page
{
    public string cid = string.Empty;
    public int PgIndex = 0;
    public int PgCount = 0;
    public int RCount = 0;
    public int classid = 0;
    public int page = 0;
    public int newPageIndex = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        cid = Request.QueryString["cid"].ToString();
        BindZheng(cid);
    }

    private void BindZheng(string sid)
    {

        DataTable dt;
        string sql = @"SELECT *,(select[name] FROM Setting where id = r.zhengshutype) typename FROM[dbo].[ResultZheng]
                     r where CNO = " + sid + " and state = 1 ";
        if (title.Text.Length > 0)
        {
            sql += " zhengshuname like '%"+ title.Text + "%' ";
        }
        sql += " ORDER BY ID DESC";
        dt = DBqiye.getDataTable(sql);
        try
        {
            myGrid.DataSource = dt;
            myGrid.DataBind();
            PgCount = myGrid.PageCount;
            PgIndex = myGrid.PageIndex; RCount = dt.Rows.Count;
            ///PgCount = GridView1.PageCount;
            //PgIndex = GridView1.PageIndex; GridView1 = dt.Rows.Count;
            if (dt.Rows.Count == 0) Label3.Text = " 没有查询到证书信息";
        }
        catch
        {
            Label3.Text = " 证书信息查询错误";
            //myGrid. = 0;
            //GridView1.DataSource = dt;
            //GridView1.DataBind();
        }
        finally
        {

        }
    }
    protected void btnGridView_Click(object sender, EventArgs e)
    {

        //msg.Text += ((LinkButton)sender).CommandArgument.ToString();
        try
        {
            switch (((LinkButton)sender).CommandArgument.ToString())
            {
                case "first":
                    newPageIndex = 0;
                    break;
                case "last":
                    newPageIndex = myGrid.PageCount - 1;
                    break;
                case "prev":
                    newPageIndex = myGrid.PageIndex - 1;
                    break;
                case "next":
                    newPageIndex = myGrid.PageIndex + 1;
                    break;
                case "go":
                    newPageIndex = 2;
                    //try
                    //{
                    //GridViewRow gvr = myGrid.BottomPagerRow;
                    //TextBox tb = (TextBox)gvr.FindControl("txtNewPageIndex");
                    //msg.Text += tb.Text;
                    //int res = Convert.ToInt32(tb.Text.ToString());
                    //myGrid.PageIndex = res - 1;
                    //}
                    //catch (Exception ex) { msg.Text += ex.Message; }
                    break;
            }
        }
        catch { }
        try
        {
            if (newPageIndex < 0) { newPageIndex = 0; }
            else if (newPageIndex > myGrid.PageCount - 1) { newPageIndex = myGrid.PageCount - 1; }
            myGrid.PageIndex = newPageIndex;
        }
        catch { }
    }
    protected void myGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        BindZheng(cid);
    }

    protected void ZS_Command(object sender, CommandEventArgs e)
    {
        DBqiye.getRowsCount("update ResultZheng set state=0 where id=" + e.CommandArgument);
        
        //typeid = 4;
        BindZheng(cid);
    }
    
    protected void ss_Click(object sender, EventArgs e)
    {
        BindZheng(cid);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        BindZhengpic(cid);
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        BindZhengpicshuiyin(cid);
    }

    private void BindZhengpicshuiyin(string sid)
    {

        DataTable dt;
        string sql = @"SELECT *,(select[name] FROM Setting where id = r.zhengshutype) typename FROM[dbo].[ResultZheng]
                     r where CNO = " + sid + " and state = 1 ";

        dt = DBqiye.getDataTable(sql);
        try
        {
            if (dt.Rows.Count > 0)
            {

                string zhengshufile = "";
                string minfile = "";
                string yuanfile = "";
                //DataRow dr = dt.Rows[0];
                foreach (DataRow row in dt.Rows)
                {
                    zhengshufile = row["zhengshufile"].ToString();
                    minfile = Server.MapPath("../") + "/min" + zhengshufile;
                    yuanfile = Server.MapPath("../") + "/yuan" + zhengshufile;
                    zhengshufile = Server.MapPath("../" + zhengshufile);

                    imgtext.BuildWatermark(yuanfile, Server.MapPath("/") + "/images/shunyin.png", "www.kjcgjy.com", zhengshufile);
                    MakeThumbnail(zhengshufile, minfile, 225, 300, "HW");
                    Label3.Text = "上传缩微图证书成功+水印";
                }
                DBqiye.getRowsCount("update ResultZheng set MinZFName='/min'+zhengshufile where CNO=" + sid);
                
            }
            if (dt.Rows.Count == 0) Label3.Text = " 没有查询到证书信息" + sql;
        }
        catch
        {
            Label3.Text = " 证书信息查询错误" + sql;
            //myGrid. = 0;
            //GridView1.DataSource = dt;
            //GridView1.DataBind();
        }
        finally
        {

        }
    }
    private void BindZhengpic(string sid)
    {

        DataTable dt;
        string sql = @"SELECT *,(select[name] FROM Setting where id = r.zhengshutype) typename FROM[dbo].[ResultZheng]
                     r where CNO = " + sid + " and state = 1 ";
        
        dt = DBqiye.getDataTable(sql);
        try
        {
            if (dt.Rows.Count > 0)
            {

                string zhengshufile = "";
                string minfile = "";
                //DataRow dr = dt.Rows[0];
                foreach (DataRow row in dt.Rows)
                {
                    zhengshufile = row["zhengshufile"].ToString();
                    minfile = Server.MapPath("../") +"/min"+ zhengshufile;
                    zhengshufile = Server.MapPath("../" + zhengshufile);
                                        
                    MakeThumbnail(zhengshufile, minfile, 225, 300, "HW");
                }
                DBqiye.getRowsCount("update ResultZheng set MinZFName='/min'+zhengshufile where CNO=" + sid);
                Label3.Text = "上传缩微图证书成功";
            }
            if (dt.Rows.Count == 0) Label3.Text = " 没有查询到证书信息"+ sql;
        }
        catch
        {
            Label3.Text = " 证书信息查询错误" + sql;
            //myGrid. = 0;
            //GridView1.DataSource = dt;
            //GridView1.DataBind();
        }
        finally
        {

        }
    }

    public static void MakeThumbnail(string originalImagePath, string thumbnailPath, int width, int height, string mode)
    {
        System.Drawing.Image originalImage = System.Drawing.Image.FromFile(originalImagePath);

        int towidth = width;
        int toheight = height;

        int x = 0;
        int y = 0;
        int ow = originalImage.Width;
        int oh = originalImage.Height;

        switch (mode)
        {
            case "HW"://指定高宽缩放（可能变形）                 
                break;
            case "W"://指定宽，高按比例                     
                toheight = originalImage.Height * width / originalImage.Width;
                break;
            case "H"://指定高，宽按比例 
                towidth = originalImage.Width * height / originalImage.Height;
                break;
            case "Cut"://指定高宽裁减（不变形）                 
                if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                {
                    oh = originalImage.Height;
                    ow = originalImage.Height * towidth / toheight;
                    y = 0;
                    x = (originalImage.Width - ow) / 2;
                }
                else
                {
                    ow = originalImage.Width;
                    oh = originalImage.Width * height / towidth;
                    x = 0;
                    y = (originalImage.Height - oh) / 2;
                }
                break;
            default:
                break;
        }

        //新建一个bmp图片 
        System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);

        //新建一个画板 
        Graphics g = System.Drawing.Graphics.FromImage(bitmap);

        //设置高质量插值法 
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

        //设置高质量,低速度呈现平滑程度 
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

        //清空画布并以透明背景色填充 
        g.Clear(Color.Transparent);

        //在指定位置并且按指定大小绘制原图片的指定部分 
        g.DrawImage(originalImage, new Rectangle(0, 0, towidth, toheight),
            new Rectangle(x, y, ow, oh),
            GraphicsUnit.Pixel);

        try
        {
            //以jpg格式保存缩略图 
            bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
        catch (System.Exception e)
        {
            throw e;
        }
        finally
        {
            originalImage.Dispose();
            bitmap.Dispose();
            g.Dispose();
        }
    }
    protected void myGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[1].Text.Length > 15) e.Row.Cells[1].Text = e.Row.Cells[1].Text.Substring(0, 15) + "...";
        }
    }

}