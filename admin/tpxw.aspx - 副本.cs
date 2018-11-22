using System;
using System.Collections.Generic;
 
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class admin_tpxw : System.Web.UI.Page
{
    public int PgIndex = 0;
    public int PgCount = 0;
    public int RCount = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Common.isAdminLogin())
        {
            Response.Redirect("login.aspx");
            Response.End();
        }
        if (!Page.IsPostBack)
        {
            webtype(ddlWType);//网站分类
            company(DropDownList1);//网站分类
        }
        //if ((!Common.IsOnline()) && (!Common._debug))
        //{
        //    //Response.Write("<script>alert('登录超时或未登录');window.location.href='login.aspx';</script>");
        //    Response.End();
        //}
        BindGrid();
    }
    private void webtype(DropDownList ddlname)
    {
        DataTable dt = DBC.getDataTable("SELECT ID,[Name]+' '+cast(x as varchar)+'*'+cast(y as varchar) as Name  FROM [dbo].[webtype]");
        ddlname.DataSource = dt;
        ddlname.DataTextField = "Name";
        ddlname.DataValueField = "ID";
        ddlname.DataBind();
        //ddlname.Items.Insert(0, new ListItem("==请选择==", "0"));
        //ddlname.SelectedValue = "";
    }
    private void company(DropDownList ddlname)
    {
        int classid = 18;
        DataTable dt = DBqiye.getDataTable("SELECT ID,[Name]  FROM [dbo].[company] where charindex(',18,',  ','+typeid+',')>0  ");
        ddlname.DataSource = dt;
        ddlname.DataTextField = "Name";
        ddlname.DataValueField = "ID";
        ddlname.DataBind();
        //ddlname.Items.Insert(0, new ListItem("==请选择==", "0"));
        //ddlname.SelectedValue = "";
    }
    protected void btnGridView_Click(object sender, EventArgs e)
    {
        int newPageIndex = 0;
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
    private void BindGrid()
    {
        DataSet ds;
        ds = DBC.getData("select * from zqhl_pic p,webtype w where p.typeid=w.id order by p.id desc");
        try
        {
            myGrid.DataSource = ds;
            myGrid.DataBind();
            PgCount = myGrid.PageCount;
            PgIndex = myGrid.PageIndex; RCount = ds.Tables[0].Rows.Count;
        }
        catch
        {
            //myGrid. = 0;
            myGrid.DataSource = ds;
            myGrid.DataBind();
        }
        finally
        {

        }
    }
    protected void bt_Click(object sender, EventArgs e)
    {
        LinkButton bt = (LinkButton)sender;
        DataTable dt = DBC.getDataTable("select * from zqhl_pic where id=" + bt.ID.Substring(1));
        if (dt.Rows.Count > 0)
        {
            try
            {
                id.ReadOnly = true;
                DataRow dr = dt.Rows[0];
                id.Text = dr["id"].ToString();
                pic.Text = dr["pic"].ToString();
                title.Text = dr["title"].ToString();
                link.Text = dr["link"].ToString();
                imgh.ImageUrl = pic.Text;
                qz.Text = dr["qz"].ToString();
                if (dr["en"].ToString().Equals("1"))
                {
                    en.Checked = true;
                }
                else
                {
                    en.Checked = false;
                }
                ddlWType.SelectedValue = dr["typeid"].ToString();
                //qq.Text = dr["qq"].ToString();
                //mail.Text = dr["mail"].ToString();
                //wx.Text = dr["wx"].ToString();
                //pass.Text = "";
            }
            catch (Exception ex) { Common.WriteDiskLog(ex.Message); }
        }
    }
    protected void sc_Click(object sender, EventArgs e)
    {
        LinkButton bt = (LinkButton)sender;
        int count = DBC.getRowsCount("delete from zqhl_pic where id=" + bt.ID.Substring(1));
        if (count > 0)
        {
            msg.Text = "删除成功";
            BindGrid();
        }
    }

    protected void tj_Click(object sender, EventArgs e)
    {
        id.Text = "0";
        id.ReadOnly = true;
        msg.Text = "";
        pic.Text = "";
        imgh.ImageUrl = "";
    }

    protected void bc_Click(object sender, EventArgs e)
    {
        string sql = "";
        if (id.Text.Equals("0"))
        {
            //DataTable dt = DBC.getDataTable("select * from zjinfo where loginuser='" + Common.strFilter(loginuser.Text) + "'");
            //if (dt.Rows.Count > 0) { msg.Text = "用户名重复"; return; }
            sql = "insert into zqhl_pic(title,link,pic,en,qz,typeid)values(";
            sql += "'" + Common.strFilter(title.Text) + "','" + Common.strFilter(link.Text) + "',";
            sql += "'" + Common.strFilter(pic.Text) + "'";//,'admin')";
            sql += "," + (en.Checked ? "1" : "0") + "," + Common.strFilter(qz.Text) + ","+ ddlWType.SelectedValue + ")";
        }
        else
        {
            sql = "update zqhl_pic set pic='" + Common.strFilter(pic.Text) + "'";
            sql += ",title='" + Common.strFilter(title.Text) + "',link='" + Common.strFilter(link.Text) + "'";
            sql += ",en=" + (en.Checked ? "1" : "0") + ",qz=" + Common.strFilter(qz.Text)+",typeid="+ ddlWType.SelectedValue + "";
            sql += " where id=" + id.Text;
        }
        int rt = DBC.getRowsCount(sql);
        if (rt > 0)
        { msg.Text = "成功保存"; BindGrid(); }
        else
        { msg.Text = "保存失败"; }
    }
    protected void myGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        BindGrid();
    }

    protected void myGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        switch (e.Row.RowType)
        {
            case DataControlRowType.Pager:// 标题头  
                break;
            case DataControlRowType.DataRow:// 数据行  
                int maxcell = e.Row.Cells.Count - 1;
                LinkButton hp = new LinkButton();
                hp.Text = "修改";
                hp.ID = "x" + e.Row.Cells[0].Text;
                hp.Click += new EventHandler(bt_Click);
                e.Row.Cells[maxcell].Controls.Add(hp);
                Label lb = new Label();
                lb.Width = 5;
                lb.Text = " ";
                e.Row.Cells[maxcell].Controls.Add(lb);
                LinkButton hp1 = new LinkButton();
                hp1.Text = "删除";
                hp1.ID = "s" + e.Row.Cells[0].Text;
                hp1.Click += new EventHandler(sc_Click);
                hp1.Attributes.Add("onclick", "if(confirm('确定要删除该用户吗？')==false){return false;}");
                e.Row.Cells[maxcell].Controls.Add(hp1);
                if (e.Row.Cells[1].Text.Length > 28)
                {
                    e.Row.Cells[1].Text = e.Row.Cells[1].Text.Substring(0, 28) + "...";
                }
                break;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        msg.Text = "";
        if (!upfile.HasFile) { msg.Text = "请选择文件后上传"; return; }
        if (upfile.FileBytes.Length > 1024 * 1024)
        { msg.Text = "文件不能大于1M"; return; }
        string ext = upfile.FileName.Substring(upfile.FileName.Length - 3).ToLower();
        if (ext != "png" && ext != "jpg" && ext != "gif")
        {
            msg.Text = "文件格式只能是png或jpg"; return;
        }
        string file = DateTime.Now.ToString("yyyMMddHHmmss.ss");
        string filename = Server.MapPath("~/upload/") + file + "." + ext;
        upfile.SaveAs(filename);
        pic.Text = "/upload/" + file + "." + ext;
        imgh.ImageUrl = "/upload/" + file + "." + ext;
        //DBC.getRowsCount("update users set headimg='" + headimg.Text + "' where id=" + Session["userid"].ToString());
        //imgh.ImageUrl = imgh.ImageUrl;
        //Session["headimg"] = imgh.ImageUrl;
        //Global.ROOM.updateheadIMG(ulong.Parse(Session["userid"].ToString()), imgh.ImageUrl);
        msg.Text = "上传成功";
    }
}