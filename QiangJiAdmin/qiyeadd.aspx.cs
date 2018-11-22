using System;
using System.Collections.Generic;
 
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;

public partial class admin_qiyeadd : System.Web.UI.Page
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
            setting(2, ddldiqu);//所在地区
            setting(4, ddlqiyexz);//企业性质
            setting(6, hangye);//行业领域
                               //setting(19, hezuozt);
        }
    }

    private void setting(int itype, DropDownList ddlname)
    {
        DataTable dt =  DBqiye.getDataTable("SELECT  [ID],[Name]  FROM [dbo].[Setting] where SettingID=" + itype + "");
        ddlname.DataSource = dt;
        ddlname.DataTextField = "Name";
        ddlname.DataValueField = "ID";
        ddlname.DataBind();
        ddlname.Items.Insert(0, new ListItem("==请选择==", "0"));
        ddlname.SelectedValue = "";
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        // Response.Write("正在插入数据");
        if (tbname.Text.Length == 0)
        {
            Label1.Text = ("企业名称,不允许为空");
            return;
        }
        else
        {
            DataTable dt = DBqiye.getDataTable("SELECT [Name]  FROM  [dbo].[Company] where [Name]='" + tbname.Text + "'");
            if (dt != null && dt.Rows.Count > 0)
            {
                Label1.Text = ("企业名称,已经被占用请使用其它名称");
                tbname.Focus();
                tbname.ForeColor = Color.Red;
                return;
            }

        }
        if (tblogin.Text.Length == 0)
        {
            Label1.Text = ("登陆名,不允许为空");
            tblogin.Focus();            
            return;
        }
        else
        {
            DataTable dt = DBqiye.getDataTable("SELECT [MemberName]  FROM  [dbo].[Company] where [MemberName]='" + tblogin.Text + "'");
            if (dt != null && dt.Rows.Count>0)
            {
                Label1.Text = ("登陆名,已经被占用请使用其它名称");
                tblogin.Focus();
                tblogin.ForeColor = Color.Red;
                return;
            }
            
        }

        if (tbpass.Text.Length == 0)
        {
            Label1.Text = ("密码,不允许为空");
            return;
        }
        if (ddldiqu.SelectedValue == "0")
        {
            Label1.Text = ("必须选择一个地区");
            return;
        }
        if (ddlqiyexz.SelectedValue == "0")
        {
            Label1.Text = ("必须选择一个企业性质");
            return;
        }

        if (hangye.SelectedValue == "0")
        {
            Label1.Text = ("必须选择一个行业");
            return;
        }
        if (hangye2.SelectedValue == "0")
        {
            Label1.Text = ("必须选择一个二行业");
            return;
        }
        string sql = "";
        {
            if ( Session["userid"].ToString()== "13")
            {
                sql = @"INSERT INTO[dbo].[Company]
                       ([Name]           ,[MemberName]           ,[Password]           ,[Address]
                       ,[ZipCode]           ,[LegalPerson]           ,[LegalPersonTel]           ,[Contact]
                       ,[ContactTel]           ,[BusinessScope]           ,[Region]           ,[EnterpriseType]
                       ,[KeyAreas]           ,[HangYe2ID]           ,[HasQuoted]           ,[CreateDate]
                       ,Incentive_HasStock,state,typeid)     VALUES
                       ('" + Common.strFilter(tbname.Text) + "','" + Common.strFilter(tblogin.Text) + "','" + MD5.CreateMD5Hash(tbpass.Text) + "','" + Common.strFilter(tbadd.Text) + "', '" +
                       Common.strFilter(tbzipcode.Text) + "','" + Common.strFilter(tbfaren.Text) + "','" + Common.strFilter(tbfarentel.Text) + "','" + Common.strFilter(tblianxi.Text) + "','" +
                       Common.strFilter(tblianxitel.Text) + "','" + Common.strFilter(jingyingfw.Text) + "','" + ddldiqu.SelectedValue + "','" + ddlqiyexz.SelectedValue + "','" +
                       hangye.SelectedValue + "','" + hangye2.SelectedValue + "'," + ((ishangshi.Checked) ? "1" : "0") + ",'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',0,1,11)";
            }
            else
            {
                sql = @"INSERT INTO[dbo].[Company]
                       ([Name]           ,[MemberName]           ,[Password]           ,[Address]
                       ,[ZipCode]           ,[LegalPerson]           ,[LegalPersonTel]           ,[Contact]
                       ,[ContactTel]           ,[BusinessScope]           ,[Region]           ,[EnterpriseType]
                       ,[KeyAreas]           ,[HangYe2ID]           ,[HasQuoted]           ,[CreateDate]
                       ,Incentive_HasStock,state,UserID,typeid)     VALUES
                       ('" + Common.strFilter(tbname.Text) + "','" + Common.strFilter(tblogin.Text) + "','" + MD5.CreateMD5Hash(tbpass.Text) + "','" + Common.strFilter(tbadd.Text) + "', '" +
                       Common.strFilter(tbzipcode.Text) + "','" + Common.strFilter(tbfaren.Text) + "','" + Common.strFilter(tbfarentel.Text) + "','" + Common.strFilter(tblianxi.Text) + "','" +
                       Common.strFilter(tblianxitel.Text) + "','" + Common.strFilter(jingyingfw.Text) + "','" + ddldiqu.SelectedValue + "','" + ddlqiyexz.SelectedValue + "','" +
                       hangye.SelectedValue + "','" + hangye2.SelectedValue + "'," + ((ishangshi.Checked) ? "1" : "0") + ",'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',0,1," + Session["userid"] + ",11)";
            }
        }

        int count =  DBqiye.getRowsCount(sql);
        if (count > 0) Label1.Text = "保存成功"; else Label1.Text = "保存失败";

    }

    protected void hangye_SelectedIndexChanged(object sender, EventArgs e)
    {
        hangye2fl(hangye.SelectedValue, 0);
    }
    private void hangye2fl(string sid, int itype)
    {
        string sql = string.Empty;

        sql = "SELECT [ID] ,[Name]  FROM [dbo].[HangYe2] where HangYeID=" + sid + "";

        DataTable dt =  DBqiye.getDataTable(sql);
        hangye2.DataSource = dt;
        hangye2.DataTextField = "Name";
        hangye2.DataValueField = "ID";
        hangye2.DataBind();
        hangye2.Items.Insert(0, new ListItem("==请选择==", ""));
        if (itype == 0)
        {
            hangye2.SelectedValue = "";
        }
        else
        {
            hangye2.SelectedValue = itype.ToString();
        }

    }

    protected void hangye2_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dt;
        dt =  DBqiye.getDataTable(@"SELECT TOP 1 *  FROM [dbo].HangYe2 where id =" + hangye2.SelectedValue + "   ");

        try
        {
            if (dt.Rows.Count > 0)
            {
                string sShangShi = "否";
                DataRow dr = dt.Rows[0];
                Label2.Text = dr["Description"].ToString(); ;
            }
        }
        catch
        {
            //myGrid. = 0;
            Label2.Text = "";
        }
        finally
        {

        }
    }
}