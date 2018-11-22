using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class admin_jscg : System.Web.UI.Page
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
            myGrid.Attributes.Add("style", "word-break:keep-all;word-wrap:false");


            company(); //绑定公司名称
            //setting(7, ddlXingZhi);  //项目性质
            setting(3, ddlhangye);  //行业

            setting(10, ddlLaiYuan); //技术来源
            setting(11, ddlDiWei);   //技术地位
            
            BindGrid();
        }
    }
    private void setting(int itype, DropDownList ddlname)
    {
        DataTable dt = DBqiye.getDataTable("SELECT  [ID],[Name]  FROM [dbo].[Setting] where SettingID=" + itype + "");
        ddlname.DataSource = dt;
        ddlname.DataTextField = "Name";
        ddlname.DataValueField = "ID";
        ddlname.DataBind();
        ddlname.Items.Insert(0, new ListItem("==全部==", "0"));
        ddlname.SelectedValue = "";
    }
    private void company()
    {
        string sql = "SELECT  [ID] ,[Name] FROM  [dbo].[Company] where 1=1 ";
        if (Session["title"].ToString() != "3")
        {
            sql += " and UserID='" + Session["userid"] + "' ";
        }
        DataTable dt = DBqiye.getDataTable(sql);
        ddlCompany.DataSource = dt;
        ddlCompany.DataTextField = "Name";
        ddlCompany.DataValueField = "ID";
        ddlCompany.DataBind();
        ddlCompany.Items.Insert(0, new ListItem("==全部==", "0"));
        ddlCompany.SelectedValue = "";
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
        string sql = @"SELECT  p.*,c.Name as CName,(select top 1  s.Name from Setting s where s.id = p.TechLevel ) as TechLevelname,
                       (select top 1  s.Name from Setting s where s.id = p.HangYe ) as HangYeName,
                       (select top 1  s.Name from Setting s where s.id = p.ResultsType ) as ResultsTypeName
                       FROM  [dbo].[Technology] p left join Company c on c.ID=p.CompanyID where ( p.state=1   ) ";
        if (ddlCompany.SelectedValue != "0")
        {
            sql += " and    p.CompanyID=" + ddlCompany.SelectedValue;
        }
        
        //[Tech_LaiYuan]
        if (ddlLaiYuan.SelectedValue != "0")
        {
            sql += " and    p.ResultsType=" + ddlLaiYuan.SelectedValue;
        }
        if (ddlDiWei.SelectedValue != "0")
        {
            sql += " and    p.TechLevel=" + ddlDiWei.SelectedValue;
        }
        if (ddlhangye.SelectedValue != "0")
        {
            sql += " and    p.HangYe=" + ddlhangye.SelectedValue;
        }

        if (Session["title"].ToString() != "3")
        {
            sql += " and c.UserID='" + Session["userid"] + "' ";
        }
        sql += " order by p.id desc";
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

    protected void bj_Command(object sender, CommandEventArgs e)
    {
        Response.Redirect("news.aspx?id=" + e.CommandArgument);
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
        DBqiye.getRowsCount("update  Technology set state=0 where id=" + e.CommandArgument);
        BindGrid();
    }

    protected void new_Click(object sender, EventArgs e)
    {
        Response.Redirect("jscgadd.aspx?id=0");
    }

    protected void ss_Click(object sender, EventArgs e)
    {
        BindGrid();
    }

    protected void myGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    if (e.Row.Cells[1].Text.Length > 10) e.Row.Cells[1].Text = e.Row.Cells[1].Text.Substring(0, 10) + "...";
        //}
    }

    protected void ddlXingZhi_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
    }

    protected void ddlCompany_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
    }

    protected void ddlJunGong_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
    }

    protected void ddlLaiYuan_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
    }

    protected void ddlDiWei_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
    }

    protected void ddlBiLei_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
    }

    protected void ddlZhengCe_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
    }

    protected void ddlhangye_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
    }
}