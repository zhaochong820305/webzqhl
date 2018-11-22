using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class admin_zhanshi : System.Web.UI.Page
{
    public int PgIndex = 0;
    public int PgCount = 0;
    public int RCount = 0;
    public static int dian = 0;
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
            dian = 0;

            company(); //绑定公司名称
            //setting(7, ddlXingZhi);  //项目性质
            setting(3, ddlhangye);  //应用领域

            //setting(10, ddlLaiYuan); //技术来源
            setting(11, ddlDiWei);   //技术地位
            //setting(4, DanWeiXingZhi);   //企业性质---成果所属单位性质
            setting(44, LeiBie); //成果类别
            yewubd();//业务
            setting(42, indexlocation);//首页位置
            setting(47, qianjisltl); //工业强基十六条龙计划
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
    private void company()
    {
        string sql = "SELECT  [ID] ,[Name] FROM  [dbo].[Company] where 1=1   and name<>''  and state=1  order by name ";
        //if (Session["title"].ToString() != "3")
        //{
        //    sql += " and UserID='" + Session["userid"] + "' ";
        //}
        DataTable dt = DBqiye.getDataTable(sql);
        ddlCompany.DataSource = dt;
        ddlCompany.DataTextField = "Name";
        ddlCompany.DataValueField = "ID";
        ddlCompany.DataBind();
        ddlCompany.Items.Insert(0, new ListItem("==全部==", "0"));
        ddlCompany.SelectedValue = "";
    }

    private void setting(int itype, DropDownList ddlname)
    {
        DataTable dt = DBqiye.getDataTable("SELECT  [ID],[Name]  FROM [dbo].[Setting] where SettingID=" + itype + " and state=1");
        ddlname.DataSource = dt;
        ddlname.DataTextField = "Name";
        ddlname.DataValueField = "ID";
        ddlname.DataBind();
        ddlname.Items.Insert(0, new ListItem("==全部==", "0"));
        ddlname.SelectedValue = "";
    }
    //private void company()
    //{
    //    string sql = "SELECT  [ID] ,[Name] FROM  [dbo].[Company] where 1=1 ";
    //    if (Session["title"].ToString() != "3")
    //    {
    //        sql += " and UserID='" + Session["userid"] + "' ";
    //    }
    //    DataTable dt = DBqiye.getDataTable(sql);
    //    ddlCompany.DataSource = dt;
    //    ddlCompany.DataTextField = "Name";
    //    ddlCompany.DataValueField = "ID";
    //    ddlCompany.DataBind();
    //    ddlCompany.Items.Insert(0, new ListItem("==全部==", "0"));
    //    ddlCompany.SelectedValue = "";
    //}
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
            //if (newPageIndex < 0) { newPageIndex = 0; }
            //else if (newPageIndex > myGrid.PageCount - 1) { newPageIndex = myGrid.PageCount - 1; }
            //myGrid.PageIndex = newPageIndex;
            //PgIndex= newPageIndex;
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

        DataTable dt;
        string sql = @"SELECT  p.*,(select Name from  [dbo].[Setting] where [ID]=p.ShuiPing) as ShuiPingName
                      ,(select Name from  [dbo].[Setting] where [ID]=p.YingYongQingKuang) as YYQKName
                      ,(select Name from  [dbo].[Setting] where [ID]=p.JiaoYiState) as JiaoYiName
                     ,(select RealName from  [dbo].[User] where [UserID]=p.userid) as UName
                      ,case when p.state is null then '未审核' when p.state=1 then '已审核' else  '已删除' end as shenhe
,RName+'('+cast(counts as varchar)+')'  NewName             
FROM  [dbo].[Results] p 
                       left join Company  c on  c.id=p.ChiYouRenID                         
                       where  ( p.state=1  ) and webtype>0 and zhanshi=1 ";

        //[Tech_LaiYuan]
        //if (ddlLaiYuan.SelectedValue != "0")
        //{
        //    sql += " and    p.ResultsType=" + ddlLaiYuan.SelectedValue;
        //}
        if (ddlDiWei.SelectedValue != "0")
        {
            sql += " and    p.ShuiPing=" + ddlDiWei.SelectedValue;
        }
        if (LeiBie.SelectedValue != "0")
        {
            sql += " and    p.LeiBie=" + LeiBie.SelectedValue;
        }
        if (ddlhangye.SelectedValue != "0")
        {
            //sql += " and    charindex(','+cast("+ ddlhangye.SelectedValue + " as varchar)+',',','+p.YingYongLingYu+',')>0" ;
            sql += " and    charindex(','+cast(" + ddlhangye.SelectedValue + " as varchar)+',',','+p.hangye+',')>0";
        }

        if (Session["userid"].ToString() != "3" && Session["userid"].ToString() != "4" && Session["title"].ToString() != "5" && Session["userid"].ToString() != "13")
        {
            sql += " and p.UserID='" + Session["userid"] + "' ";
        }
        if (yewu.SelectedValue.Length > 0)
        {
            sql += " and p.UserID=" + yewu.SelectedValue;
        }
        if (qianjisltl.SelectedValue != "0")
        {
            sql += " and p.qianjisltl=" + qianjisltl.SelectedValue;
        }
        if (sname.Text.Length > 0)
        {
            string zid = _getzhuanjiaid(sname.Text);
            sql += " and (p.RName like '%" + sname.Text + "%' or c.name like '%" + sname.Text + "%' ) ";
        }
        if (ddlCompany.SelectedValue != "0")
        {
            sql += " and   ChiYouRenType=0 and   p.ChiYouRenID=" + ddlCompany.SelectedValue;
        }
        //if (indexview.Checked)
        //{
        //    sql += " and   indexview=1";
        //}
        if (indexlocation.SelectedValue != "0")
        {
            sql += " and   indexlocation=" + indexlocation.SelectedValue;
        }

        if (((hezuo.Checked == true)))
        {
            sql += " and   hezuo=1";
        }
        if (dian == 0)
        { sql += " order by p.[Update] desc"; }
        else
        { sql += " order by p.[counts] desc"; }

        //Response.Write(sql+ yewu.SelectedValue);
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
    public static string _getzhuanjiaid(string sid)
    {
        string value = string.Empty;
        DataTable dt = DBC.getDataTable("SELECT TOP 1 [id]  FROM [zqhl].[dbo].[zqhl_zj] where zjname='" + sid + "'");
        if (dt.Rows.Count > 0)
        {
            value = dt.Rows[0][0].ToString();
        }
        return value;
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
        DBqiye.getRowsCount("update  Results set state=0 where id=" + e.CommandArgument);
        BindGrid();
    }

    protected void sh_Command(object sender, CommandEventArgs e)
    {
        DBqiye.getRowsCount("update  Results set state=1 where id=" + e.CommandArgument);
        BindGrid();
    }

    protected void new_Click(object sender, EventArgs e)
    {
        Response.Redirect("qiangjiadd.aspx?id=0");
    }
    protected void cyr_Click(object sender, EventArgs e)
    {
        Response.Redirect("ChiYouRenAdd.aspx?cid=0&op=add");
    }

    protected void ss_Click(object sender, EventArgs e)
    {
        BindGrid();
    }

    protected void myGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[1].Text.Length > 20) e.Row.Cells[1].Text = e.Row.Cells[1].Text.Substring(0, 20) + "...";
        }
    }

    protected void ddlXingZhi_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
    }

    protected void ddlCompany_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
    }
    protected void DanWeiXingZhi_SelectedIndexChanged(object sender, EventArgs e)
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
    protected void Button2_Click(object sender, EventArgs e)
    {
        dian = 1;
        BindGrid();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        DataTable dt;
        dt = DBqiye.getDataTable("select  top 1000 * from Results  where biaoqian is not null and biaoqianstate is null ");
        try
        {
            if (dt.Rows.Count > 0)
            {

                string ID = "";
                string biaoqian = "";
                string sql = "";
                //string biaoarray = "";
                //DataRow dr = dt.Rows[0];
                foreach (DataRow row in dt.Rows)
                {
                    ID = row["ID"].ToString();
                    biaoqian = row["biaoqian"].ToString();
                    string[] biaoarray = biaoqian.Split(',');
                    for (int i = 0; i < biaoarray.Length; i++)
                    {
                        if (biaoarray[i].Length > 0)
                        {
                            sql = " declare  @counts int ";
                            sql += "select @counts=count(*) from [Setting]  where name='" + biaoarray[i] + "' and [SettingID]=40 and state=1";
                            sql += " if (@counts=0) INSERT INTO [dbo].[Setting]([SettingID],[Name],[state])VALUES(40,'" + biaoarray[i] + "',1) ";
                            DBqiye.getDataTable(sql);
                        }
                    }
                    sql = "update results set biaoqianstate=1 where id=" + ID + "";
                    DBqiye.getDataTable(sql);
                    Label5.Text = biaoqian + "入库成功，id号：" + ID;
                    Label5.Text = "入库成功条数：" + dt.Rows.Count;
                }
                //DBqiye.getRowsCount("update ResultZheng set MinZFName='/min'+zhengshufile where CNO=" + sid);

            }
            if (dt.Rows.Count == 0) Label5.Text = " 没有标签，需要入库";
        }
        catch
        {
            Label5.Text = " 标签查询错误";
            //myGrid. = 0;
            //GridView1.DataSource = dt;
            //GridView1.DataBind();
        }
        finally
        {

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string sql = "";
        {
            sql = @"update  [dbo].[Results] set userid=41  where userid is null or userid=0 ";
            //  ,[YingYongLingYu]='" + cbtext1 + "'    去掉应用领域
        }
        int count = DBqiye.getRowsCount(sql);
        //sql = "";
        if (count > 0) Label5.Text = "保存成功" + sql; else Label5.Text = "更新0行" + sql;
    }
    protected void Button61_Click(object sender, EventArgs e)
    {

        DataTable dt;
        dt = DBqiye.getDataTable("SELECT *  FROM [dbo].[ResultPic] where  state=1 ");
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
                    zhengshufile = row["FileName"].ToString();
                    minfile = Server.MapPath("../") + "/min" + zhengshufile;
                    yuanfile = Server.MapPath("../") + "/yuan" + zhengshufile;
                    zhengshufile = Server.MapPath("../" + zhengshufile);

                    try
                    {
                        imgtext.BuildWatermark(yuanfile, Server.MapPath("/") + "/images/shuiyinshen.png", "www.kjcgjy.com", zhengshufile);
                    }
                    catch { Label5.Text += zhengshufile + ";错"; }
                    //imgtext.AddWaterText(yuanfile, "www.kjcgjy.com", zhengshufile, 255, 50);
                    // MakeThumbnail(zhengshufile, minfile, 225, 300, "HW");
                    Label5.Text = "上传缩微图证书成功+水印";
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