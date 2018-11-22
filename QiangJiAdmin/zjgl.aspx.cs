using System;
using System.Collections.Generic;
 
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class admin_zjgl : System.Web.UI.Page
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
            DataTable dt = DBC.getDataTable("select * from zqhl_class where en=1 and fl=4 and typeid=1 order by fl asc,sx asc");
            DataRow dr = dt.NewRow();
            dr["id"] = "0";
            dr["class"] = "查看全部";
            dt.Rows.InsertAt(dr, 0);
            fl.DataSource = dt;
            fl.DataTextField = "class";
            fl.DataValueField = "id";
            fl.DataBind();
            yewubd();//业务
            BindGrid();
        }
    }
    private void yewubd()
    {
        string sql = "SELECT [UserID],[RealName] FROM [dbo].[User]  where Enabled=1  ";

        if (Session["userid"].ToString() != "3" && Session["userid"].ToString() != "4" && Session["title"].ToString() != "5" && Session["userid"].ToString() != "13")
        {
            sql += "  and  UserID='" + Session["userid"] + "' ";
        }
        //Response.Write(sql);
        DataTable dt = DBqiye.getDataTable(sql);
        yewu.DataSource = dt;
        yewu.DataTextField = "RealName";
        yewu.DataValueField = "UserID";
        yewu.DataBind();
        //if (Session["title"].ToString() == "3" && Session["title"].ToString() == "5")
        {
            yewu.Items.Insert(0, new ListItem("==请选择==", ""));
            yewu.SelectedValue = "0";
        }

    }
    protected void yewu_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
    }
    protected void btnGridView_Click(object sender, EventArgs e)
    {
        int newPageIndex = 0;
        int res = 0;
        try
        {
            GridViewRow gvr = myGrid.BottomPagerRow;
            TextBox tb = (TextBox)gvr.FindControl("TextBox1");
            //msg.Text += tb.Text;
            res = Convert.ToInt32(tb.Text.ToString());
           
        }
        catch (Exception ex)
        { //msg.Text += ex.Message; }
        }
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
                    newPageIndex = -1;
                    //myGrid.PageIndex = res - 1;
                    break;
            }
        }
        catch { }
        try
        {
            if (newPageIndex != -1)
            {
                if (newPageIndex < 0) { newPageIndex = 0; }
                else if (newPageIndex > myGrid.PageCount - 1) { newPageIndex = myGrid.PageCount - 1; }
                myGrid.PageIndex = newPageIndex;
            }
            else
            {
                myGrid.PageIndex = res - 1;
                BindGrid();
            }
            
        }
        catch { }
    }
    protected void myGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        BindGrid();
    }
    private void BindGrid()
    {
        string tj = " zjname like '%" + Common.strFilter(title.Text) + "%'";
        if (fl.SelectedValue != "0")
        {
            tj += " and classid=" + fl.SelectedValue;
        }
        if (yewu.SelectedValue.Length > 0)
        {
            tj += " and UserID= " + yewu.SelectedValue;
        }
        DataTable dt;
        dt = DBC.getDataTable(@"select (select sum(1) from zqhl_zj where id<=b.id) as IID,*,fl=(select top 1 [class] from zqhl_class a where a.id=b.classid),rname=(select RealName from [ZhongQiHuiLian].dbo.[user] u  where u.userid=b.userid) from zqhl_zj b where " + tj + " order by b.id desc");
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
        Response.Redirect("zj.aspx?id=" + e.CommandArgument);
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
        DBC.getRowsCount("delete from zqhl_zj where id=" + e.CommandArgument);
        BindGrid();
    }

    protected void new_Click(object sender, EventArgs e)
    {
        Response.Redirect("zj.aspx?id=0");
    }

    protected void ss_Click(object sender, EventArgs e)
    {
        BindGrid();
    }

    protected void Button61_Click(object sender, EventArgs e)
    {

        DataTable dt;
        dt = DBC.getDataTable("SELECT *  FROM [dbo].[zqhl_zj] ");
        try
        {
            if (dt.Rows.Count > 0)
            {

                string zhengshufile = "";
                string minfile = "";
                string yuanfile = "";
                //DataRow dr = dt.Rows[0];
                foreach (DataRow row in dt.Rows)
                {
                    zhengshufile = row["pic"].ToString();
                    minfile = Server.MapPath("../") + "/min" + zhengshufile;
                    yuanfile = Server.MapPath("../") + "/yuan" + zhengshufile;
                    zhengshufile = Server.MapPath("../" + zhengshufile);

                    try
                    {
                        imgtext.BuildWatermark(yuanfile, Server.MapPath("/") + "/images/shunyin250.png", "www.kjcgjy.com", zhengshufile);
                    }
                    catch { Label5.Text += zhengshufile + ";"; }
                    //imgtext.AddWaterText(yuanfile, "www.kjcgjy.com", zhengshufile, 255, 50);
                    // MakeThumbnail(zhengshufile, minfile, 225, 300, "HW");
                    Label5.Text += "上传缩微图证书成功+水印";
                }
                //DBqiye.getRowsCount("update ResultZheng set MinZFName='/min'+zhengshufile where CNO=" + sid);

            }
            if (dt.Rows.Count == 0) Label5.Text = " 没有查询到证书信息";
        }
        catch
        {
            Label5.Text = " 证书信息查询错误";
            //myGrid. = 0;
            //GridView1.DataSource = dt;
            //GridView1.DataBind();
        }
        finally
        {

        }

    }
}