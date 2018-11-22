using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class admin_ziyuanadd : System.Web.UI.Page
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
                
                DataTable dt = DBC.getDataTable("select * from zqhl_class where en=1 and fl=4 and typeid=1 order by fl asc,sx asc");
                

                dt = DBqiye.getDataTable("  SELECT  ID,Name  FROM Setting WHERE (SettingID = 45) and state=1");
                fenlei.DataSource = dt;
                fenlei.DataTextField = "Name";
                fenlei.DataValueField = "ID";
                fenlei.DataBind();
                fenlei.Items.Insert(0, new ListItem("==请选择==", "0"));
                //fenlei.SelectedValue = "";
                if (id != 0)
                {
                    dt = DBqiye.getDataTable("select * from Resource where id=" + id);
                    if (dt.Rows.Count > 0)
                    {
                        DataRow dr = dt.Rows[0];
                        title.Text = dr["title"].ToString();
                       
                        pic.Text = dr["filename"].ToString();
                        //qz.Text = dr["qz"].ToString();
                        //pic.Text = dr["pic"].ToString();
                         
                        content.Text = dr["text"].ToString();
                        //fenlei.SelectedValue = dr["filename"].ToString();
                        try
                        {
                            
                            fenlei.Items.FindByValue(dr["classid"].ToString()).Selected = true;
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
        if (upfile.FileBytes.Length > 200 * 1024 * 1024)
        { msg.Text = "文件不能大于200M"; return; }
        string ext = upfile.FileName.Substring(upfile.FileName.Length - 4).ToLower();
        if (ext != ".pdf" && ext != ".doc" && ext != ".xls" && ext != ".txt" && ext != "docx" && ext != "xlsx")
        {
            msg.Text = "文件格式只能是pdf或doc或xls或txt"; return;
        }
        string file = DateTime.Now.ToString("yyyMMddHHmmss.ss");
        string filename = Server.MapPath("../upload/ziyuan/") + file + "." + ext;
        //string yuanfile = Server.MapPath("../yuan/upload/") + file + "." + ext;
        upfile.SaveAs(filename);
        //try
        //{
        //    imgtext.BuildWatermark(yuanfile, Server.MapPath("/") + "/images/shunyin250.png", "www.kjcgjy.com", filename);
        //}
        //catch { msg.Text += filename + ";错"; }
        pic.Text = filename;
    }

    protected void bc_Click(object sender, EventArgs e)
    {
        string sql = "";
        if (id == 0)
        {
            sql = "insert into Resource([title]           ,[classid]           ,[filename]           ,[text]          ,[userid] ,[update]           ,[state])values(";
            sql += "'" + Common.strFilter(title.Text) + "'," + fenlei.SelectedValue + ",";
            sql += "'" + Common.strFilter(pic.Text) + "','" + Common.strFilter(content.Text) + "','" + Session["userid"] + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',1)";
        }
        else
        {
            sql = "update Resource set [title]='" + Common.strFilter(title.Text) + "',filename='" + Common.strFilter(pic.Text) + "',text='" + Common.strFilter(content.Text) + "',classid=" + fenlei.SelectedValue + " where id=" + id;
        }
        int count = DBqiye.getRowsCount(sql);
        if (count > 0) msg.Text = "保存成功"; else msg.Text = "保存失败";
    }
}