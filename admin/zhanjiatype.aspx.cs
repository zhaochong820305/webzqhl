using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//
using System.Data;
public partial class admin_zhanjiatype : System.Web.UI.Page
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
        //if (hangye.SelectedValue != null && (!string.IsNullOrEmpty(hangye.SelectedValue)) && (hangye.SelectedValue.Length > 0))
        //{
        //    stype = hangye.SelectedValue.ToString();
        //}
        //else
        {
            stype = "43";
        }
        if (!Page.IsPostBack)
        {
            BindGrid();
            //setting(6, hangye);//行业领域
        }
    }
    private void setting(int itype, DropDownList ddlname)
    {
        DataTable dt = DBqiye.getDataTable("SELECT  [ID],[Name]  FROM [dbo].[Setting] where SettingID=" + itype + "");
        ddlname.DataSource = dt;
        ddlname.DataTextField = "Name";
        ddlname.DataValueField = "ID";
        ddlname.DataBind();
        //ddlname.Items.Insert(0, new ListItem("==请选择==", ""));
        //ddlname.SelectedValue = "";
    }
    private void BindGrid()
    {
        DataTable dt;
        string sql = @"select * from zqhl_class where en=1 and fl=4 and typeid=1 order by fl asc,sx asc" ;
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
    protected void hangye_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
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
        DBC.getRowsCount("update  [zqhl_class] set en=0 where id=" + e.CommandArgument);
        BindGrid();
    }
    protected void myGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        BindGrid();
    }
    protected void myGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //if (e.Row.Cells[1].Text.Length > 10) e.Row.Cells[1].Text = e.Row.Cells[1].Text.Substring(0, 10) + "...";

        //}
        if ((e.Row.RowState & DataControlRowState.Edit) != 0)
        {
            TextBox txt1 = e.Row.Cells[1].Controls[0] as TextBox;
            txt1.Width = 500;
            txt1.Height = 30;
            
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
        // string desc = ((TextBox)(myGrid.Rows[e.RowIndex].Cells[2].Controls[0])).Text.ToString().Trim();
        string id = myGrid.DataKeys[e.RowIndex].Value.ToString();

        //id = myGrid.DataKeys[e.RowIndex].Value.ToString();
        string sql = "update [zqhl_class] set[class] = '" + name + "'  where [ID]='" + id + "'";
        DBC.getRowsCount(sql);
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
            Label1.Text = ("输入子行业名称,不允许为空！");
            return;
        }
        
        string sql = @"INSERT INTO [dbo].[zqhl_class]  ([class]           ,[fl]           ,[en]           ,[one]           ,[sx]           ,[typeid])   VALUES
                            ('" + TextBox1.Text.Trim().ToString() + "',4, 1,0,0,1)";
        int count = DBC.getRowsCount(sql);
        if (count > 0) Label1.Text = "保存成功"; else Label1.Text = "保存失败"+ sql;
        BindGrid();
    }
}