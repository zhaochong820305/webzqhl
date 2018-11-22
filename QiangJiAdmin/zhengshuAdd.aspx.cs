using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing; //”并不包含“FromFile”的定义- C#
public partial class admin_zhengshuAdd : System.Web.UI.Page
{
    public int icompanyid = 0;
    public static int icount = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Common.isAdminLogin())
        {
            Response.Redirect("login.aspx");
            Response.End();

        }
        zhengshutype.Focus();
        icompanyid = Convert.ToInt32(Request.QueryString["cid"]);
        if (!Page.IsPostBack)
        {
            setting(28, zhengshutype); //成果类型
            //setting(2, diqu); //地址
            string op = Request.QueryString["op"].ToString();
            if (op == "edit" || op == "kan")
            {
                if (op == "edit")
                {
                    Button1.Visible = false;
                    Button2.Visible = true;
                }
                else
                {
                    Button1.Visible = false;
                    Button2.Visible = false;
                }

                try
                {
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    DataTable dt;
                    dt = DBqiye.getDataTable(@"select *  from  ResultZheng where id=" + id + "  order by id desc   ");


                    if (dt.Rows.Count > 0)
                    {
                        DataRow dr = dt.Rows[0];

                        //cgno.Text = dr["cgno"].ToString();
                        zhengshutype.Text = dr["zhengshutype"].ToString();
                        zhengshuname.Text = dr["zhengshuname"].ToString();
                        zhengshuno.Text = dr["zhengshuno"].ToString();


                        pic.Text = dr["zhengshufile"].ToString();
                        imgh.ImageUrl= dr["zhengshufile"].ToString();
                        Image1.ImageUrl = dr["MinZFName"].ToString();
                        //CLianXi.Text = dr["CLianXi"].ToString();
                        text.Text = dr["text"].ToString();
                        icompanyid = Convert.ToInt32(dr["CNO"].ToString());
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
            else
            {
                icompanyid = Convert.ToInt32(Request.QueryString["cid"]);
                Button1.Visible = true;
                Button2.Visible = false;
            }
        }
    }

    private void setting(int itype, DropDownList ddlname)
    {
        DataTable dt = DBqiye.getDataTable("SELECT  [ID],[Name]  FROM [dbo].[Setting] where SettingID=" + itype + "");
        ddlname.DataSource = dt;
        ddlname.DataTextField = "Name";
        ddlname.DataValueField = "ID";
        ddlname.DataBind();
        ddlname.Items.Insert(0, new ListItem("==请选择==", "0"));
        ddlname.SelectedValue = "0";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        icompanyid = Convert.ToInt32(Request.QueryString["cid"]);
        
        if (zhengshutype.SelectedValue == "0")
        {
            Label1.Text = ("必须选择证书分类！");
            return;
        }
        if (zhengshuname.Text.Length == 0)
        {
            Label1.Text = ("证书名不能为空！");
            return;
        }
        if (zhengshuno.Text.Length == 0)
        {
            Label1.Text = ("证书号不能为空！");
            return;
        }
        if (pic.Text.Length == 0)
        {
            Label1.Text = ("必须上传附件！"+ icompanyid);
            return;
        }
        string str = Label2.Text;
        str = str.Substring(0,str.Length - 1);

        string[] sarray = str.Split(';');
        string sql = "";
        {
           for(int i=0;i<sarray.Length;i++)
            {
                sql += @"INSERT INTO [dbo].[ResultZheng]
               (cno        ,[zhengshutype]           ,[zhengshuname]          
                ,[zhengshuno]           ,[zhengshufile]           ,[MinZFName],[state]           ,[update],[text])VALUES(
                  " + icompanyid + ",'" + zhengshutype.SelectedValue + "','" + zhengshuname.Text + "','"
                    + zhengshuno.Text + "','" + sarray[i] + "','/min" + sarray[i] + "',1,'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + text.Text + "')";
            }
           
        }

        int count = DBqiye.getRowsCount(sql);
        sql = "";
        if (count > 0) Label1.Text = "保存成功"+sql; else Label1.Text = "保存失败" + sql;
    }
    
    protected void Button2_Click(object sender, EventArgs e)
    {

        int id = 0;
        try
        {
            id = Convert.ToInt32(Request.QueryString["id"].ToString());
        }
        catch
        {
            Label1.Text = ("公司ID,必须是数字");
            return;
        }

        if (zhengshutype.SelectedValue == "0")
        {
            Label1.Text = ("必须选择证书分类！");
            return;
        }

        string sql = "";
        {
            sql = @"update [dbo].[ResultZheng]
            set [zhengshutype]='" + zhengshutype.Text + "'           ,[zhengshuname]='" + zhengshuname.Text
           + "',[zhengshuno]='" + zhengshuno.Text + "'           ,[zhengshufile]='" + pic.Text + "' ,[MinZFName]='/min" + pic.Text + "' ,[text]='" + text.Text + "'  ,[update]='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where id=" + id;
        }

        int count = DBqiye.getRowsCount(sql);
        if (count > 0) Label1.Text = "保存成功"; else Label1.Text = "保存失败" + sql;
    }
    protected void scfile_Click(object sender, EventArgs e)
    {
        msg.Text = "";
        if (!upfile.HasFile) { msg.Text = "请选择文件后上传"; return; }
        if (upfile.FileBytes.Length > 1024 * 1024)
        { msg.Text = "文件不能大于1M"; return; }
        string ext = upfile.FileName.Substring(upfile.FileName.Length - 3).ToLower();
        if (ext != "png" && ext != "jpg" && ext != "gif" && ext != "pdf" && ext != "doc")
        {
            msg.Text = "文件格式只能是png或jpg或gif或pdf"; return;
        }
        string file = DateTime.Now.ToString("yyyMMddHHmmss");
        string filename = Server.MapPath("../upload/") + file + "." + ext;
        string filenametext = Server.MapPath("../yuan/upload/") + file + "." + ext;
        //img.ImageWaterMarkText(upfile, filename, "www.kjcgjy.com", 20, "", 10);
        upfile.SaveAs(filenametext);
        //图片添加水印
        //imgtext.AddWaterText(filename, "www.kjcgjy.com", filename, 255, 30);
        //imgtext.ImageWaterMarkPicpath(filename, filenametext, "D:/csharp/Webzqhl/upload/image/1111.jpg", 5,100,10);
        imgtext.BuildWatermark(filenametext, Server.MapPath("/") + "/images/shunyin.png", "www.kjcgjy.com", filename);
        string minfile = Server.MapPath("~/min/upload/") + file + "." + ext;
        //生成缩微图
        MakeThumbnail(filename, minfile, 225, 300, "HW");
        //imgtext.BuildWatermark(minfile, "D:/csharp/Webzqhl/upload/image/shunyin.png", "", minfile);
        pic.Text = "/upload/" + file + "." + ext;
        imgh.ImageUrl = "/upload/" + file + "." + ext;
        //System.Drawing.Image img = this.imgh.Image;
        Label2.Text += "/upload/" + file + "." + ext+";";
        Label3.Text += icount+": /upload/" + file + "." + ext + ";</br>";
        Image1.ImageUrl = "/min/upload/" + file + "." + ext;
        icount++;
        msg.Text = "图片 上传成功！地址：/upload/" + file + "." + ext; ;
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

}