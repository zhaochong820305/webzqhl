using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class admin_video : System.Web.UI.Page
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
            //webtype(ddlWType);//网站分类
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
        string sql = "select * from zqhl_pic p,webtype w where p.typeid=w.id and typeid=7 ";
        if (title.Text.Length > 0) {
            sql += " p.title like '%"+ title.Text + "%'";
        }
        sql += " order by p.id desc";
        ds = DBC.getData(sql);
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
                //LinkButton hp = new LinkButton();
                //hp.Text = "修改";
                //hp.ID = "x" + e.Row.Cells[0].Text;
                ////hp.Click += new EventHandler(bt_Click);
                //e.Row.Cells[maxcell].Controls.Add(hp);
                //Label lb = new Label();
                //lb.Width = 5;
                //lb.Text = " ";
                //e.Row.Cells[maxcell].Controls.Add(lb);
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

    protected void ss_Click(object sender, EventArgs e)
    {
        BindGrid();
    }
    protected void new_Click(object sender, EventArgs e)
    {
        //BindGrid();
        Response.Redirect("videoadd.aspx?id=0");
    }
}