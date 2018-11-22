using System;
using System.Collections.Generic;
 
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class admin_jscgadd : System.Web.UI.Page
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
            setting(11, ddljishu); //技术水平
            setting(3, ddlhangye); //行业
            setting(10, ddllaiyuan); //成果来源
            setting(21, ddlchengguo); //成果类型
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
        try
        {
            Convert.ToSingle(tbtouzi.Text);
        }
        catch
        {
            Label1.Text = ("总投资,必须为数字！");
            return;
        }
        try
        {
            Convert.ToSingle(tbshebei.Text);
        }
        catch
        {
            Label1.Text = ("设备投资,必须为数字！");
            return;
        }
        try
        {
            Convert.ToSingle(tblirui.Text);
        }
        catch
        {
            Label1.Text = ("新增利润,必须为数字！");
            return;
        }
        try
        {
            Convert.ToSingle(tbjieye.Text);
        }
        catch
        {
            Label1.Text = ("节省成本,必须为数字！");
            return;
        }

        string sql = "";
        {
            sql = @"INSERT INTO [dbo].[Technology]
           ([TechName]           ,[CompanyId]           ,[TechLevel]           ,[HangYe]
           ,[ResultsType]           ,[InPhase]           ,[Source]           ,[KeyWord]
           ,[Cooperation]           ,[InvestmenTotal]           ,[Equipment]           ,[Profits]
           ,[CostSavings]           ,[TechAdvancement]           ,[TechnicalParameters]           ,[CreateTime]
           ,[state]           ,[UserID])
               VALUES ('" + Common.strFilter(tbName.Text) + "','" + ddlCompany.SelectedValue + "','" + Common.strFilter(ddljishu.SelectedValue) + "','" + Common.strFilter(ddlhangye.SelectedValue) + "','" +
               Common.strFilter(ddlchengguo.SelectedValue) + "','" + Common.strFilter(tbjieduan.Text) + "','" + Common.strFilter(ddllaiyuan.SelectedValue) + "','" + Common.strFilter(tbKey.Text) + "','" +
               Common.strFilter(tbhezuo.Text) + "','" + Common.strFilter(tbtouzi.Text) + "','" + Common.strFilter(tbshebei.Text) + "','" + Common.strFilter(tblirui.Text) + "','" + 
               Common.strFilter(tbjieye.Text) + "','" + Common.strFilter(tbxianjin.Text) + "','" + Common.strFilter(tbcanshu.Text) + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',1,'" + Session["userid"] + "')";
        }
        int count = DBqiye.getRowsCount(sql);
        if (count > 0) Label1.Text = "保存成功"; else Label1.Text = "保存失败";
    }
}