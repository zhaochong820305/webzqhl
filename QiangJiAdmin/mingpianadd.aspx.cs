using System;
using System.Collections.Generic;
 
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class admin_mingpianadd : System.Web.UI.Page
{
    public string id;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Common.isAdminLogin())
        {
            Response.Redirect("login.aspx");
            Response.End();

        }
        
        if (!Page.IsPostBack)
        {
            setting(6, ddlqiyexz);//企业性质
            yewubd();//业务
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
                    id = (Request.QueryString["id"]);
                    DataTable dt;
                    dt = DBqiye.getDataTable(@"select *  from  [mingpian] where id=" + id + "    ");


                    if (dt.Rows.Count > 0)
                    {
                        DataRow dr = dt.Rows[0];

                        name.Text = dr["name"].ToString();
                        company.Text = dr["company"].ToString();
                        tel.Text = dr["tel"].ToString();
                        modtel.Text = dr["modtel"].ToString();
                        email.Text = dr["email"].ToString();
                        title.Text = dr["title"].ToString();

                        deptname.Text = dr["deptname"].ToString();
                        fax.Text = dr["fax"].ToString();
                        url.Text = dr["url"].ToString();
                        ddlqiyexz.SelectedValue = dr["hangye"].ToString();
                        address.Text = dr["address"].ToString();
                        yewu.SelectedValue = dr["userid"].ToString();
                        //icompanyid = Convert.ToInt32(dr["CompanyID"].ToString());
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
                //icompanyid = Convert.ToInt32(Request.QueryString["cid"]);
                Button1.Visible = true;
                Button2.Visible = false;
            }
        }
    }

    private void yewubd()
    {
        string sql = "SELECT [UserID],[RealName]        FROM[dbo].[User]  where Enabled=1  ";
        if (Session["title"].ToString() != "3" && Session["title"].ToString() != "4")
        {
            sql += "  and UserID='" + Session["userid"] + "' ";
        }
        DataTable dt = DBqiye.getDataTable(sql);
        yewu.DataSource = dt;
        yewu.DataTextField = "RealName";
        yewu.DataValueField = "UserID";
        yewu.DataBind();
        yewu.Items.Insert(0, new ListItem("==请选择==", ""));
        yewu.SelectedValue = "";
    }
    private void setting(int itype, DropDownList ddlname)
    {
        DataTable dt = DBqiye.getDataTable("SELECT  [ID],[Name]  FROM [dbo].[Setting] where SettingID=" + itype + "");
        ddlname.DataSource = dt;
        ddlname.DataTextField = "Name";
        ddlname.DataValueField = "ID";
        ddlname.DataBind();
        ddlname.Items.Insert(0, new ListItem("==请选择==", "0"));
        ddlname.SelectedValue = "0";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if(name.Text.Length<2)
        {
            Label1.Text = "姓名最少两个字";
            name.Focus();
            name.ForeColor = System.Drawing.Color.Red;
            return;
        }
        if (tel.Text.Length < 10)
        {
            Label1.Text = "电话最少十个数字";
            tel.Focus();
            tel.ForeColor = System.Drawing.Color.Red;
            return;
        }
        
        if (modtel.Text.Length < 11)
        {
            Label1.Text = "电话最少十一个数字";
            modtel.Focus();
            modtel.ForeColor = System.Drawing.Color.Red;
            return;
        }
        string sql = "";
        {
            sql = @"INSERT INTO [dbo].[mingpian]
                       ([name]           ,[company]           ,[tel]           ,[modtel]
                       ,[email]           ,[title]           ,[update]           ,[deptname]
                       ,[fax]           ,[url],[address]           ,[hangye]           ,[state], [userid])
                  VALUES
                       ('" + Common.strFilter(name.Text) + "','" + Common.strFilter(company.Text) + "','" + Common.strFilter(tel.Text) + "','" + Common.strFilter(modtel.Text) + "','"
                       + Common.strFilter(email.Text) + "','" + Common.strFilter(title.Text) + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + Common.strFilter(deptname.Text) + "','"
                       + Common.strFilter(fax.Text) + "','" + Common.strFilter(url.Text) + "','" + Common.strFilter(address.Text) + "','" + Common.strFilter(ddlqiyexz.SelectedValue) + "',1,'" + Common.strFilter(yewu.SelectedValue) + "')";
                   
        }

        int count = DBqiye.getRowsCount(sql);
        if (count > 0) Label1.Text = "保存成功"; else Label1.Text = "保存失败";
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (name.Text.Length < 2)
        {
            Label1.Text = "姓名最少两个字";
            name.Focus();
            name.ForeColor = System.Drawing.Color.Red;
            return;
        }
        if (tel.Text.Length < 10)
        {
            Label1.Text = "电话最少十个数字";
            tel.Focus();
            tel.ForeColor = System.Drawing.Color.Red;
            return;
        }

        if (modtel.Text.Length < 11)
        {
            Label1.Text = "电话最少十一个数字";
            modtel.Focus();
            modtel.ForeColor = System.Drawing.Color.Red;
            return;
        }
        id = (Request.QueryString["id"]);
        string sql = "";
        {
            sql = @"update [dbo].[mingpian]
                       set [name]='" + Common.strFilter(name.Text) + "'           ,[company]='" + Common.strFilter(company.Text) + "'          ,[tel]='" + Common.strFilter(tel.Text) + "'           ,[modtel]='" + Common.strFilter(modtel.Text)
                       + "',[email]='" + Common.strFilter(email.Text) + "'           ,[title]='" + Common.strFilter(title.Text) + "'                    ,[deptname]='" + Common.strFilter(deptname.Text)
                       + "',[fax]='" + Common.strFilter(fax.Text) + "'           ,[url]='" + Common.strFilter(url.Text) + "' ,[address]='" + Common.strFilter(address.Text) + "'           ,[hangye]='" + Common.strFilter(ddlqiyexz.SelectedValue) + "' ,[userid]='" + Common.strFilter(yewu.SelectedValue) + "' where id =" + id + "";
        }
        int count = DBqiye.getRowsCount(sql);
        if (count > 0) Label1.Text = "保存成功"; else Label1.Text = "保存失败";
    }

}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         