using System;
using System.Collections.Generic;
 
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class admin_qygl : System.Web.UI.Page
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
        //if (Session["title"].ToString() != "3" && Session["title"].ToString() != "2")
        //{
        //    Response.Redirect("login.aspx");
        //    Response.End();
        //}
        if (!Page.IsPostBack)
        {
            myGrid.Attributes.Add("style", "word-break:keep-all;word-wrap:false");
            yewubd();//业务
            Recommend();//推荐人
            setting(6, hangye);//行业领域

            setting(4, qiyesz);//企业性质
            setting(2, diqu);//所在地区
            setting(19, hezuozt);//行业领域

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
        if (Session["title"].ToString() == "3" && Session["title"].ToString() == "5")
        {
            yewu.Items.Insert(0, new ListItem("==请选择==", ""));
            yewu.SelectedValue = "0";
        }

    }
    private void Recommend()
    {
        DataTable dt = DBqiye.getDataTable("SELECT [ID] ,[Name] FROM [dbo].[Recommend]");
        tunjiang.DataSource = dt;
        tunjiang.DataTextField = "Name";
        tunjiang.DataValueField = "ID";
        tunjiang.DataBind();
        tunjiang.Items.Insert(0, new ListItem("==请选择==", ""));
        tunjiang.SelectedValue = "";
    }
    private void setting(int itype, DropDownList ddlname)
    {
        DataTable dt = DBqiye.getDataTable("SELECT  [ID],[Name]  FROM [dbo].[Setting] where SettingID=" + itype + "");
        ddlname.DataSource = dt;
        ddlname.DataTextField = "Name";
        ddlname.DataValueField = "ID";
        ddlname.DataBind();
        ddlname.Items.Insert(0, new ListItem("==请选择==", ""));
        ddlname.SelectedValue = "";
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
        //string tj = " title like '%"+Common.strFilter(title.Text)+"%'";
        //if(fl.SelectedValue!="0")
        //{
        //    tj += " and classid=" + fl.SelectedValue;
        //}
        DataTable dt;
        string sql = @"select *,(select Name from  [dbo].[Setting] where [ID]=b.Region) as City
                                   ,(select Name from  [dbo].[Setting] where [ID]=b.EnterpriseType) as EnterType
                                   ,(select Name from  [dbo].[Setting] where [ID]=b.KeyAreas) as KeyArea
                                   ,(case typeid WHEN '1' THEN '中企慧联' WHEN '2' THEN '联盟网站' WHEN '3' THEN '强基服务' WHEN '4' THEN '成果交易'  WHEN '10' THEN '调查问卷' ELSE '后台录入' END) typename
                                   ,case when b.state is null then '未审核' when b.state=1 then '已审核' when  b.state=0  then '已删除'  end as shenhe
                                    from [Company] b where (b.state=1 or   b.state is null ) ";
        if (Session["userid"].ToString() != "3" && Session["userid"].ToString() != "4" && Session["title"].ToString().Trim() != "5" && Session["userid"].ToString() != "13")
        {
            sql += " and UserID='" + Session["userid"] + "' ";
        }
        //else
        //{
        //    if (yewu.SelectedValue.Length > 0)
        //    {
        //        sql += " and UserID= " + yewu.SelectedValue;
        //    }
        //}
        if (typeid.SelectedValue.Length > 0)
        {
            sql += " and typeid= " + typeid.SelectedValue;
        }
        if (tunjiang.SelectedValue.Length > 0)
        {
            sql += " and RecommendID= " + tunjiang.SelectedValue;
        }
        if (hangye.SelectedValue.Length > 0)
        {
            sql += " and KeyAreas= " + hangye.SelectedValue;
        }
        if (qiyesz.SelectedValue.Length > 0)
        {
            sql += " and EnterpriseType= " + qiyesz.SelectedValue;
        }
        if (diqu.SelectedValue.Length > 0)
        {
            sql += " and Region= " + diqu.SelectedValue;
        }
        if (hezuozt.SelectedValue.Length > 0)
        {
            sql += " and CooperateStatus= " + hezuozt.SelectedValue;
        }
        if (sname.Text.Length > 0)
        {
            sql += " and ([Name] like '%" + sname.Text + "%'  or MemberName like '%" + sname.Text + "%' or ContactTel like '%" + sname.Text + "%' or Contact like '%" + sname.Text + "%' )";
        }

        sql += " order by b.id desc";
        // Response.Write(sql+ Session["title"].ToString());
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
        Response.Redirect("qiyelist.aspx?id=" + e.CommandArgument);
        //DataTable dt = DBqiye.getDataTable("select * from syspara where id=" + e.CommandArgument);
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
        DBqiye.getRowsCount("update Company set state=0 where id=" + e.CommandArgument);
        BindGrid();
    }

    protected void new_Click(object sender, EventArgs e)
    {
        //string str_dk = myGrid.DataKeys[e.RowIndex].Value.ToString();
        //string aaa = myGrid.DataKeys[e.Row.RowIndex].Value.ToString();
        //string aaa = myGrid.DataKeys[myGrid.Rows[e.RowIndex].RowIndex].Value.ToString();
        int index = myGrid.SelectedIndex;//获得行号
        string s1 = myGrid.Rows[index].Cells[0].Text;//第一列数据

        //Response.Redirect("news.aspx?id="+ Session["sid"]);
        this.Response.Write("<script language=javascript>window.open('news.aspx?id=" + s1 + "','newwindow','width=200,height=200')</script>");
        //Response.Write("<script>alert('请选择答案'）;</script>");
    }

    protected void ss_Click(object sender, EventArgs e)
    {
        BindGrid();
    }

    protected void myGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[1].Text.Length > 10) e.Row.Cells[1].Text = e.Row.Cells[1].Text.Substring(0, 10) + "...";
            if (e.Row.Cells[2].Text.Length > 6) e.Row.Cells[2].Text = e.Row.Cells[2].Text.Substring(0, 5) + "...";
            if (e.Row.Cells[3].Text.Length > 5) e.Row.Cells[3].Text = e.Row.Cells[3].Text.Substring(0, 5) + "...";
            e.Row.Attributes.Add("onclick", e.Row.ClientID.ToString() + ".checked=true;selectx(this)");
            e.Row.Attributes.Add("onclick", "oldBG=this.style.backgroundColor;this.style.backgroundColor='#CCC';");
        }

    }

    protected void myGrid_SelectedIndexChanged(object sender, EventArgs e)
    {
        int index = myGrid.SelectedIndex;//获得行号
        string s1 = myGrid.Rows[index].Cells[0].Text;//第一列数据
        string s2 = myGrid.Rows[index].Cells[1].Text;//第二列数据
        Session["sid"] = s1;
        //Response.Redirect("b.aspx?s1=" + s1 + "&s2=" + s2);//调用b.aspx
        DataTable dt;
        dt = DBqiye.getDataTable(@"select *,(select Name from  [dbo].[Setting] where [ID]=b.Region) as City
                                    ,(select Name from  [dbo].[Setting] where [ID]=b.EnterpriseType) as EnterType
                                     ,(select Name from  [dbo].[Setting] where [ID]=b.KeyAreas) as KeyArea
                                    from [Company] b where b.id=" + s1 + " order by b.id desc   ");

        try
        {
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                tbFangXiang.Text = dr["ShangShi_Target"].ToString();
                tbShiJian.Text = dr["ShangShi_Time"].ToString();
                tbZhuiBei.Text = dr["ShangShi_PrepareInfo"].ToString();
            }
        }
        catch
        {
            //myGrid. = 0;

        }
        finally
        {

        }
    }
    protected void btSave_Click(object sender, EventArgs e)
    {
        //Response.Write(tbFangXiang.Text);
        //Response.Write(tbShiJian.Text);
        //Response.Write(tbZhuiBei.Text);
        string sid;
        if (Session["sid"] != null && Session["sid"].ToString() != "" && Session["sid"].ToString().Length > 0)
        {
            sid = Session["sid"].ToString();
        }
        else
        {
            Response.Write("请选择企业，否则无法显示");
            return;
        }
        if (tbFangXiang.Text.Trim().Length == 0)
        {
            Labelmsg.Text = "上市方向不允许为空";
            return;
        }
        if (tbShiJian.Text.Trim().Length == 0)
        {
            Labelmsg.Text = "上市时间不允许为空";
            return;
        }
        if (tbZhuiBei.Text.Trim().Length == 0)
        {
            Labelmsg.Text = "上市准备不允许为空";
            return;
        }
        string sql = @"UPDATE [dbo].[Company] SET   [ShangShi_Target] = '" + tbFangXiang.Text.Trim() + "',[ShangShi_Time] = '" + tbShiJian.Text.Trim() + "'      ,[ShangShi_PrepareInfo] = '" + tbZhuiBei.Text.Trim() + "'  WHERE ID=" + sid + "";
        int count = DBqiye.getRowsCount(sql);
        if (count > 0)
            Response.Write("<script language='javascript' type='text/javascript'>showdiv1();</script>");
        //ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>showdiv1();</script>");
        else
            Response.Write("<script language='javascript' type='text/javascript'>showdiv0();</script>");
        //StringBuilder sb = new StringBuilder();
        //sb.Append("<script language='javascript'>");
        //if (count > 0)
        //    sb.Append("");
        //else
        //    sb.Append("document.getElementById('pmsg').innerHTML='保存失败';");
        //sb.Append("</script>");
        //ClientScript.RegisterStartupScript(this.GetType(), "LoadPicScript", sb.ToString());

    }

    protected void yewu_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
    }

    protected void tunjiang_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
    }

    protected void hangye_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
    }

    protected void qiyesz_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
    }

    protected void diqu_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
    }

    protected void hezuozt_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
    }
}