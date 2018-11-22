using System;
using System.Collections.Generic;
 
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class admin_mingpian : System.Web.UI.Page
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
            yewubd();
            BindGrid();
        }
    }
    protected void new_Click(object sender, EventArgs e)
    {
        Response.Redirect("mingpianadd.aspx?id=0&op=add");
    }
    private void yewubd()
    {
        string sql = "SELECT [UserID],[RealName]        FROM[dbo].[User] where Enabled=1 ";
        if (Session["userid"].ToString() != "3" && Session["userid"].ToString() != "4" && Session["userid"].ToString() != "13" && Session["title"].ToString() != "4")
        {
            sql += "  and  UserID='" + Session["userid"] + "' ";
        }
        DataTable dt = DBqiye.getDataTable(sql);
        yewu.DataSource = dt;
        yewu.DataTextField = "RealName";
        yewu.DataValueField = "UserID";
        yewu.DataBind();
        yewu.Items.Insert(0, new ListItem("==请选择==", ""));
        yewu.SelectedValue = "";
    }
    private void BindGrid()
    {

        DataTable dt;
        string sql = @"SELECT *  FROM  [mingpian] where (state=1 )  ";


        if (Session["userid"].ToString() != "3" && Session["userid"].ToString() != "4" && Session["userid"].ToString() != "13" && Session["title"].ToString() != "4")
        {
            sql += " and UserID='" + Session["userid"] + "' ";
        }
        if (yewu.SelectedValue.ToString() != "")
        {
            sql += " and UserID='" + yewu.SelectedValue + "' ";
        }
        if (name.Text.ToString() != "")
        {
            sql += " and name like '%" + name.Text + "%' ";
        }
        if (company.Text.ToString() != "")
        {
            sql += " and company like '%" + company.Text + "%' ";
        }
        //Response.Write(sql);
        sql += " order by name";
        dt = DBqiye.getDataTable(sql);
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
    protected void ss_Click(object sender, EventArgs e)
    {
        BindGrid();
    }
    protected void myGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        BindGrid();
    }
    protected void sc_Command(object sender, CommandEventArgs e)
    {
        DBqiye.getRowsCount("update  mingpian set state=0 where id=" + e.CommandArgument);
        BindGrid();
    }
    protected void myGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[1].Text.Length > 10) e.Row.Cells[1].Text = e.Row.Cells[1].Text.Substring(0, 10) + "...";
        }
    }
}