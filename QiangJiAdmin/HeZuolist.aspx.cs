using System;
using System.Collections.Generic;
 
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class admin_HeZuolist : System.Web.UI.Page
{
    public string pid = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Common.isAdminLogin())
        {
            Response.Redirect("login.aspx");
            Response.End();
        }
        if (Request.QueryString["pid"] != null && (!string.IsNullOrEmpty(Request.QueryString["pid"])) && Request.QueryString["pid"].Length > 0)
        {
            pid = Request.QueryString["pid"].ToString();
        }
        else
        {
            Label1.Text = "请选择项目，否则无法显示";
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
        dt = DBqiye.getDataTable(@"SELECT * ,(select Name from Setting where id =c.Type) as TName 
                                   ,(select Name from Setting where id = c.MainDirection) as MName
                                   ,(select Name from Setting where id = c.EnterpriseType) as EName  FROM  [dbo].[Cooperation] c where ProjectID = " + pid);
        try
        {
            GridView2.DataSource = dt;
            GridView2.DataBind();
            ///PgCount = GridView1.PageCount;
            //PgIndex = GridView1.PageIndex; GridView1 = dt.Rows.Count;
            if (dt.Rows.Count == 0) Label1.Text = " 没有查询到项目合作需求数据";
        }
        catch
        {
            Label1.Text = " 项目合作需求数据查询错误";
            //myGrid. = 0;
            //GridView1.DataSource = dt;
            //GridView1.DataBind();
        }
        finally
        {

        }
    }
    protected void sc_Command(object sender, CommandEventArgs e)
    {
        DBqiye.getRowsCount("delete from Cooperation where id=" + e.CommandArgument);
        //BindGrid();
        BindGrid();

    }
}