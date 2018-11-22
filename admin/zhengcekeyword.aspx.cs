using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class admin_zhengcekeyword : System.Web.UI.Page
{
    public int PgIndex = 0;
    public int PgCount = 0;
    public int RCount = 0;
    public string stype = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Common.isAdminLogin())
        {
            Response.Redirect("login.aspx");
            Response.End();
        }
        TextBox1.Focus();
        if (Request.QueryString["type"] != null && (!string.IsNullOrEmpty(Request.QueryString["type"])) && Request.QueryString["type"].Length > 0)
        {
            stype = Request.QueryString["type"].ToString();
        }
        else
        {
            Label1.Text = "请选择企业，否则无法显示";
            return;
        }
        if (!Page.IsPostBack)
        {
            BindGrid();
        }
    }
    private void BindGrid()
    {
        DataTable dt;
        string sql = @"SELECT   [ID]      ,[SettingID]      ,[Name]  FROM [dbo].[Setting] where [SettingID]='" + stype + "' and (state=1 or state is null)";
        if (stype == "40")
        {
            sql += " order by [Name]";
        }
        dt = DBZhengce.getDataTable(sql);
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
    protected void sc_Command(object sender, CommandEventArgs e)
    {
        DBZhengce.getRowsCount("update  [Setting] set state=0 where id=" + e.CommandArgument);
        BindGrid();
    }
    protected void myGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        BindGrid();
    }
    protected void myGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[1].Text.Length > 10) e.Row.Cells[1].Text = e.Row.Cells[1].Text.Substring(0, 10) + "...";
        }
    }
    protected void myGrid_RowEditing(object sender, GridViewEditEventArgs e)
    {
        myGrid.EditIndex = e.NewEditIndex;
        BindGrid();
    }
    protected void myGrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string name = ((TextBox)(myGrid.Rows[e.RowIndex].Cells[1].Controls[0])).Text.ToString().Trim();

        //string id = ((TextBox)(myGrid.Rows[e.RowIndex].Cells[0].Controls[0])).Text.ToString().Trim();

        string id = myGrid.DataKeys[e.RowIndex].Value.ToString();
        string sql = "update[Setting] set[Name] = '" + name + "' where ID='" + id + "'";
        DBZhengce.getRowsCount(sql);
        myGrid.EditIndex = -1;
        BindGrid();

    }
    protected void myGrid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        myGrid.EditIndex = -1;
        BindGrid();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text.Length == 0)
        {
            Label1.Text = ("输入类型,不允许为空！");
            return;
        }
        string sql = @"INSERT INTO [dbo].[Setting] ([SettingID]           ,[Name]           ,[state])     VALUES
                            ('" + stype + "','" + TextBox1.Text.Trim().ToString() + "', 1)";
        int count = DBZhengce.getRowsCount(sql);
        if (count > 0) Label1.Text = "保存成功"; else Label1.Text = "保存失败"+sql;
        BindGrid();
    }
}