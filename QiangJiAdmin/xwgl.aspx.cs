using System;
using System.Collections.Generic;
 
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class admin_xwgl : System.Web.UI.Page
{
    public int PgIndex = 0;
    public int PgCount = 0;
    public int RCount = 0;
    public int classid = 0;
    public int page = 0;
    public int newPageIndex = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        //myGrid.Attributes.Add("style", "word-break:keep-all;word-wrap:normal");
        if (!Common.isAdminLogin())
        {
            Response.Redirect("login.aspx");
            Response.End();
        }
        try {
            classid = int.Parse(Request.QueryString["class"].ToString());
            page = int.Parse(Request.QueryString["page"].ToString());
        } catch { }
       
        if (!Page.IsPostBack)
        {
            //myGrid.Attributes.Add("style", "word-break:keep-all;word-wrap:false");
            myGrid.Attributes.Add("style", "word-break:keep-all;word-wrap:normal");
            //GridView1.Attributes.Add("style", "word-break:keep-all;word-wrap:normal");
            DataTable dt = DBC.getDataTable("select * from zqhl_class where en=1 or en=2 order by typeid asc,fl asc,sx asc");
            DataRow dr = dt.NewRow();
            dr["id"] = "0";
            dr["class"] = "查看全部";
            dt.Rows.InsertAt(dr, 0);
            fl.DataSource = dt;
            fl.DataTextField = "class";
            fl.DataValueField = "id";
            fl.DataBind();
            fl.SelectedValue = classid.ToString();
            myGrid.PageIndex = page;
            yewubd();
            BindGrid();
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
        BindGrid();
    }
    protected void yewu_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
    }
    private void yewubd()
    {
        string sql = "SELECT [LoginName],[RealName] FROM [dbo].[User]  where Enabled=1  ";

        if (Session["userid"].ToString() != "3" && Session["userid"].ToString() != "4" && Session["title"].ToString() != "5" && Session["userid"].ToString() != "13")
        {
            sql += "  and  UserID='" + Session["userid"] + "' ";
        }
        //Response.Write(sql);
        DataTable dt = DBqiye.getDataTable(sql);
        yewu.DataSource = dt;
        yewu.DataTextField = "RealName";
        yewu.DataValueField = "LoginName";
        yewu.DataBind();
        //if (Session["title"].ToString() == "3" && Session["title"].ToString() == "5")
        {
            yewu.Items.Insert(0, new ListItem("==请选择==", ""));
            yewu.SelectedValue = "0";
        }

    }
    private void BindGrid()
    {
        //--,rname=(select RealName from [ZhongQiHuiLian].dbo.[user] u  where u.userid=b.userid)
        string sql = @"select *,LEFT(c.fl,LEN(c.fl)-1) as hobby from (
                                select *, 
                                (select[class]+',' from zqhl_class  where charindex(','+cast(id as varchar)+',',','+b.typename+',')>0  FOR XML PATH('')) fl 
      ,rname=(select RealName from [ZhongQiHuiLian].dbo.[user] u  where  u.LoginName=b.author)                          
from zqhl_news b)c where 1=1 ";
        if (Common.strFilter(title.Text).Length>0)
        {
            sql += "  and title like '%" + Common.strFilter(title.Text) + "%'";
        }
        if (yewu.SelectedValue.Length > 0)
        {
            sql += " and author= '" + yewu.SelectedValue+"'";
        }
        if (fl.SelectedValue != "0")
        {
            sql += " and charindex(','+cast('"+ fl.SelectedValue + "' as varchar)+',',','+c.typename+',')>0 " ;
        }
        sql += " order by c.id desc";
        //Response.Write(sql);
        //Response.End();
        DataTable dt;
        dt = DBC.getDataTable(sql);
        try
        {
            myGrid.DataSource = dt;
            myGrid.DataBind();
            PgCount = myGrid.PageCount;
            PgIndex = myGrid.PageIndex; RCount = dt.Rows.Count;
        }
        catch
        {
            //myGrid. = 0;
            myGrid.DataSource = dt;
            myGrid.DataBind();
        }
        finally
        {

        }
        
    }

    protected void bj_Command(object sender, CommandEventArgs e)
    {
        Response.Redirect("news.aspx?id=" + e.CommandArgument+"&class="+fl.SelectedValue+"&page="+(myGrid.PageIndex+1 ) + "");
        //DataTable dt = DBC.getDataTable("select * from syspara where id=" + e.CommandArgument);
        //if (dt.Rows.Count > 0)
        //{
        //    DataRow dr = dt.Rows[0];
        //    id.Text = dr["id"].ToString();
        //    para.Text = dr["para"].ToString();
        //    value.Text = dr["value"].ToString();
        //    demo.Text = dr["demo"].ToString();
        //}
    }

    protected void sc_Command(object sender, CommandEventArgs e)
    {
        DBC.getRowsCount("delete from zqhl_news where id=" + e.CommandArgument);
        BindGrid();
    }

    protected void new_Click(object sender, EventArgs e)
    {
        Response.Redirect("news.aspx?id=0");
    }

    protected void ss_Click(object sender, EventArgs e)
    {
        BindGrid();
    }

    protected void myGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[1].Text.Length > 30) e.Row.Cells[1].Text = e.Row.Cells[1].Text.Substring(0, 30) + "...";
        }
    }


}