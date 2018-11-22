using System;
using System.Collections.Generic;
 
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class admin_xwlb : System.Web.UI.Page
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
        }
        BindGrid();
    }
    private void webtype( DropDownList ddlname)
    {
        DataTable dt = DBC.getDataTable("SELECT ID,[Name]  FROM [dbo].[webtype]" );
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
    protected void myGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        BindGrid();
    }
    private void BindGrid()
    {
        DataTable dt;
        dt = DBC.getDataTable("select * from zqhl_class z ,webtype w where z.typeid=w.Id and state=1   order by z.id desc");
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

        DataTable dt = DBC.getDataTable("select *  from zqhl_class  where id=" + e.CommandArgument);
        if (dt.Rows.Count > 0)
        {
            DataRow dr = dt.Rows[0];
            id.Text = dr["id"].ToString();
            classn.Text = dr["class"].ToString();
            fl.Text = dr["fl"].ToString();
            ddlWType.SelectedValue = dr["typeid"].ToString();
        }
    }

    protected void sc_Command(object sender, CommandEventArgs e)
    {
        DBC.getRowsCount("update   zqhl_class set state=0 where id=" + e.CommandArgument);
    }

    protected void tj_Click(object sender, EventArgs e)
    {
        id.Text = "0";
    }

    protected void bc_Click(object sender, EventArgs e)
    {

        string sql = "";
        if (id.Text == "0")
        {
            sql = "insert into zqhl_class([class],fl,[typeid],state)values(";
            sql += "'" + Common.strFilter(classn.Text) + "'," + Common.strFilter(fl.Text) + "," + ddlWType.SelectedValue + ",1)";
        }
        else
        {
            sql = "update zqhl_class set [class]='" + Common.strFilter(classn.Text) + "',fl=" + Common.strFilter(fl.Text)+ ",typeid="+ ddlWType.SelectedValue;
            sql += " where id=" + id.Text;
        }
        int count = DBC.getRowsCount(sql);
        if (count > 0) { msg.Text = "保存成功"; BindGrid(); } else { msg.Text = "保存失败"; }
    }
}