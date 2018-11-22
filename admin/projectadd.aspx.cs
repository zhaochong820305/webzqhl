using System;
using System.Collections.Generic;
 
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class admin_projectadd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Common.isAdminLogin())
        {
            Response.Redirect("login.aspx");
            Response.End();
        }
        if (!Page.IsPostBack)
        {
            company(); //绑定公司名称
            setting(7, ddlXingZhi); //项目性质
            setting(8, ddlJunGong); //军工情况
        }
    }
    private void setting(int itype, DropDownList ddlname)
    {
        DataTable dt = DBqiye.getDataTable("SELECT  [ID],[Name]  FROM [dbo].[Setting] where SettingID=" + itype + "");
        ddlname.DataSource = dt;
        ddlname.DataTextField = "Name";
        ddlname.DataValueField = "ID";
        ddlname.DataBind();
        //ddlname.Items.Insert(0, new ListItem("==请选择==", "0"));
        //ddlname.SelectedValue = "";
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
        //ddlCompany.Items.Insert(0, new ListItem("==请选择==", ""));
        //ddlCompany.SelectedValue = "";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (ddlCompany.SelectedValue == "")
        {
            Label1.Text = ("请选择企业！");
            return;
        }
        if (tbName.Text.Length == 0)
        {
            Label1.Text = ("项目名称不允许为空！");
            return;
        }
        if (tbMuBiao.Text.Length == 0)
        {
            Label1.Text = ("项目目标不允许为空！");
            return;
        }
        try
        {
            Convert.ToSingle(tbGuiGe.Text);
        }
        catch
        {
            Label1.Text = ("项目规模,必须为数字！");
            return;
        }
        try
        {
            Convert.ToSingle(tbGuDing.Text);
        }
        catch
        {
            Label1.Text = ("固定资产,必须为数字！");
            return;
        }
        try
        {
            Convert.ToSingle(tbnoGuDing.Text);
        }
        catch
        {
            Label1.Text = ("非固定资产,必须为数字！");
            return;
        }
        try
        {
            Convert.ToSingle(tbJinDu.Text);
        }
        catch
        {
            Label1.Text = ("项目进度,必须为数字！");
            return;
        }
        try
        {
            Convert.ToDateTime(tbSDate.Text);
        }
        catch
        {
            Label1.Text = ("开始时间,格式不正确！");
            return;
        }
        try
        {
            Convert.ToDateTime(tbEDate.Text);
        }
        catch
        {
            Label1.Text = ("结束时间,格式不正确！");
            return;
        }
        string sql = "";
        {
            sql = @"INSERT INTO [dbo].[Project]           ([CompanyID]                     ,[Name]           ,[Goal]           ,[Scale]
                   ,[Process]                     ,[Military]           ,[FixedInverstment]
                   ,[NonFixedInverstment]           ,[StartDate]           ,[EndDate]           ,[CreateDate]   ,Nature,  ZiZhi,state ,UserID     )     VALUES
                   ('" + ddlCompany.SelectedValue + "','" + Common.strFilter(tbName.Text) + "','" + Common.strFilter(tbMuBiao.Text) + "','" + Common.strFilter(tbGuiGe.Text) + "','" +
               Common.strFilter(tbJinDu.Text) + "','" + Common.strFilter(ddlJunGong.SelectedValue) + "','" + Common.strFilter(tbGuDing.Text) + "','" +
               Common.strFilter(tbnoGuDing.Text) + "','" + Common.strFilter(tbSDate.Text) + "','" + Common.strFilter(tbEDate.Text) + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + Common.strFilter(ddlXingZhi.SelectedValue) + "','',1,'"+ Session["userid"] + "')";
        }

        int count = DBqiye.getRowsCount(sql);
        if (count > 0) Label1.Text = "保存成功"; else Label1.Text = "保存失败";
    }
}