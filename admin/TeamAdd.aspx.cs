using System;
using System.Collections.Generic;
 
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class admin_TeamAdd : System.Web.UI.Page
{
    public int icompanyid = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Common.isAdminLogin())
        {
            Response.Redirect("login.aspx");
            Response.End();

        }
        tbName.Focus();
        icompanyid = Convert.ToInt32(Request.QueryString["cid"]);
        if (!Page.IsPostBack)
        {
            setting(15, ZhiWei);
            string op = Request.QueryString["op"].ToString();
            if (op == "edit" || op == "kan")
            {
                if (op == "edit")
                {
                    Button1.Visible = false;
                    Button2.Visible = true;
                }
                else
                {
                    Button1.Visible = false;
                    Button2.Visible = false;
                }

                try
                {
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    DataTable dt;
                    dt = DBqiye.getDataTable(@"select *  from  [Team] where id=" + id + "    ");


                    if (dt.Rows.Count > 0)
                    {
                        DataRow dr = dt.Rows[0];

                        tbName.Text = dr["Name"].ToString();
                        tbXueLi.Text = dr["XueLi"].ToString();
                        tbZhanYe.Text = dr["ZhuanYe"].ToString();
                        ZhiWei.SelectedValue = dr["ZhiWei"].ToString();
                        tbRenZhi.Text = dr["StockCompany"].ToString();
                        tbJianLi.Text = dr["Resume"].ToString();


                        icompanyid = Convert.ToInt32(dr["CompanyID"].ToString());
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
            else
            {
                icompanyid = Convert.ToInt32(Request.QueryString["cid"]);
                Button1.Visible = true;
                Button2.Visible = false;
            }
        }
    }
    private void setting(int itype, DropDownList ddlname)
    {
        DataTable dt = DBqiye.getDataTable("SELECT  [ID],[Name]  FROM [dbo].[Setting] where SettingID=" + itype + "");
        ddlname.DataSource = dt;
        ddlname.DataTextField = "Name";
        ddlname.DataValueField = "ID";
        ddlname.DataBind();
        ddlname.Items.Insert(0, new ListItem("==请选择==", "0"));
        ddlname.SelectedValue = "";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        int icompanyid = 0;
        try
        {
            icompanyid = Convert.ToInt32(Request.QueryString["cid"].ToString());
        }
        catch
        {
            Label1.Text = ("公司ID,必须是数字");
            return;
        }


        if (tbName.Text.Trim().Length == 0)
        {
            Label1.Text = ("姓名不允许为空");
            return;

        }
        if (tbXueLi.Text.Trim().Length == 0)
        {
            Label1.Text = ("学历不允许为空");
            return;

        }
        if (tbZhanYe.Text.Trim().Length == 0)
        {
            Label1.Text = ("专业不允许为空");
            return;

        }
        if (tbRenZhi.Text.Trim().Length == 0)
        {
            Label1.Text = ("上市公司任职情况不允许为空");
            return;

        }
        if (tbJianLi.Text.Trim().Length == 0)
        {
            Label1.Text = ("简历不允许为空");
            return;

        }
        string sql = "";
        {
            sql = @"INSERT INTO [dbo].[Team]([CompanyID]           ,[Name]           ,[XueLi]           ,[ZhuanYe]
           ,[ZhiWei]           ,[StockCompany]           ,[Resume]           ,[CreateDate])VALUES(
                    " + icompanyid + ",'" + Common.strFilter(tbName.Text) + "','" + Common.strFilter(tbXueLi.Text) + "','" + Common.strFilter(tbZhanYe.Text) + "','" +
                ZhiWei.SelectedValue + "','" + Common.strFilter(tbRenZhi.Text) + "','" + Common.strFilter(tbJianLi.Text) + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
        }

        int count = DBqiye.getRowsCount(sql);
        if (count > 0) Label1.Text = "保存成功"; else Label1.Text = "保存失败";
    }
    protected void Button2_Click(object sender, EventArgs e)
    {

        int id = 0;
        try
        {
            id = Convert.ToInt32(Request.QueryString["id"].ToString());
        }
        catch
        {
            Label1.Text = ("公司ID,必须是数字");
            return;
        }
        if (tbName.Text.Trim().Length == 0)
        {
            Label1.Text = ("姓名不允许为空");
            return;

        }
        if (tbXueLi.Text.Trim().Length == 0)
        {
            Label1.Text = ("学历不允许为空");
            return;

        }
        if (tbZhanYe.Text.Trim().Length == 0)
        {
            Label1.Text = ("专业不允许为空");
            return;

        }
        if (tbRenZhi.Text.Trim().Length == 0)
        {
            Label1.Text = ("上市公司任职情况不允许为空");
            return;

        }
        if (tbJianLi.Text.Trim().Length == 0)
        {
            Label1.Text = ("简历不允许为空");
            return;

        }


        string sql = "";
        {
            sql = @"UPDATE [dbo].[Team]   SET [Name] ='" + Common.strFilter(tbName.Text) + "',[XueLi] = '" + Common.strFilter(tbXueLi.Text) + "',[ZhuanYe] ='" + Common.strFilter(tbZhanYe.Text) + "',[ZhiWei] = '"
                + ZhiWei.SelectedValue + "' ,[StockCompany] = '" + Common.strFilter(tbRenZhi.Text) + "' ,[Resume] ='" + Common.strFilter(tbJianLi.Text) + "'where id =" + id;
        }

        int count = DBqiye.getRowsCount(sql);
        if (count > 0) Label1.Text = "保存成功"; else Label1.Text = "保存失败";
    }
}