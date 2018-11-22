using System;
using System.Collections.Generic;
 
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class admin_useradd : System.Web.UI.Page
{
    public string sid = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Common.isAdminLogin())
        {
            Response.Redirect("login.aspx");
            Response.End();
        }
        if (!Page.IsPostBack)
        {
            deptband();//部门
            string op = Request.QueryString["op"].ToString();
            if (op == "edit" || op == "kan")
            {
                if (op == "edit")
                {
                    Button1.Visible = false;
                    Button3.Visible = true;
                }
                else
                {
                    Button1.Visible = false;
                    Button3.Visible = false;
                }

                try
                {
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    sid = id.ToString();
                    DataTable dt;
                    dt = DBqiye.getDataTable(@"select *  from  [User] where UserID=" + id + "    ");


                    if (dt.Rows.Count > 0)
                    {
                        DataRow dr = dt.Rows[0];

                        tbName.Text = dr["RealName"].ToString();
                        tbUser.Text = dr["LoginName"].ToString();
                        tbPass.Text = dr["Password"].ToString();
                        tbTitles.SelectedValue = dr["Title"].ToString();
                        ddlSex.SelectedIndex = Convert.ToInt16(dr["Sex"].ToString());
                        tbEmail.Text = dr["Email"].ToString();
                        tbTel.Text = dr["MobilePhone"].ToString();
                        tbOfficTel.Text = dr["OfficePhone"].ToString();

                        tbHomeTel.Text = dr["HomePhone"].ToString();
                        ddlDept.SelectedValue = dr["DepartmentID"].ToString();
                        tbEmail.Text = dr["Email"].ToString();
                        if (dr["Enabled"].ToString() == "True")
                        {
                            cbQiYong.Checked = true;
                        }
                        else
                        {
                            cbQiYong.Checked = false;
                        }
                        if (dr["IsAgent"].ToString() == "True")
                        {
                            cbZuoXi.Checked = true;
                        }
                        else
                        {
                            cbZuoXi.Checked = false;
                        }
                    }
                }
                catch
                {
                    //myGrid. = 0;
                    Label1.Text = "读数据库错误";
                }
                finally
                {

                }
            }
            else
            {
                //icompanyid = Convert.ToInt32(Request.QueryString["cid"]);
                Button1.Visible = true;
                Button3.Visible = false;
            }
        }
    }
    private void deptband()
    {
        DataTable dt = DBqiye.getDataTable("SELECT [DepartmentID]      ,[DepartmentName]   FROM [dbo].[Department]");
        ddlDept.DataSource = dt;
        ddlDept.DataTextField = "DepartmentName";
        ddlDept.DataValueField = "DepartmentID";
        ddlDept.DataBind();
        //ddlDept.Items.Insert(0, new ListItem("==请选择==", ""));
        //ddlDept.SelectedValue = "";
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (tbUser.Text.Length < 3)
        {
            Label1.Text = ("登陆名，必须 大于3位字符 ");
            return;
        }
        if (tbName.Text.Length < 1)
        {
            Label1.Text = ("姓名，必须 大于1位字符 ");
            return;
        }

        if (tbPass.Text.Length < 3)
        {
            Label1.Text = ("密码，必须 大于3位字符 ");
            return;
        }
        if (tbTel.Text.Length < 11 || tbTel.Text.Length > 15)
        {
            Label1.Text = ("手机号，必须是11-15位字符 ");
            return;
        }
        if (tbOfficTel.Text.Length < 7 || tbOfficTel.Text.Length > 20)
        {
            Label1.Text = ("办公电话，必须是7-20位字符 ");
            return;
        }
        if (tbHomeTel.Text.Length < 7 || tbHomeTel.Text.Length > 20)
        {
            Label1.Text = ("家庭电话，必须是7-20位字符 ");
            return;
        }
        if (!tbEmail.Text.Contains("@") && (!tbEmail.Text.Contains(".")))
        {
            Label1.Text = ("电子邮件，格式 必须正确 ");
            return;
        }

        string sql = "";

        sql = @"INSERT INTO [dbo].[User]           ([LoginName]           ,[Password]           ,[RealName]           ,[Title]           ,[Sex]           ,[Email]
           ,[MobilePhone]           ,[OfficePhone]           ,[HomePhone]          
           ,[DepartmentID]           ,[Enabled]           ,[IsAgent]           ,[CreateDate])
            VALUES('" + tbUser.Text + "','" + MD5.CreateMD5Hash(tbPass.Text) + "','" + tbName.Text + "','" + tbTitles.SelectedValue + "','" + ddlSex.SelectedIndex + "','" + tbEmail.Text + "','"
        + tbTel.Text + "','" + tbOfficTel.Text + "','" + tbHomeTel.Text + "','"
        + ddlDept.SelectedValue + "','" + ((cbQiYong.Checked) ? "1" : "0") + "','" + ((cbZuoXi.Checked) ? "1" : "0") + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "')";

        int count = DBqiye.getRowsCount(sql);
        if (count > 0) Label1.Text = "保存成功"; else Label1.Text = "保存失败";
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("manage.aspx");
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        if (tbUser.Text.Length < 3)
        {
            Label1.Text = ("登陆名，必须 大于3位字符 ");
            return;
        }
        if (tbName.Text.Length < 1)
        {
            Label1.Text = ("姓名，必须 大于1位字符 ");
            return;
        }


        if (tbTel.Text.Length < 11 || tbTel.Text.Length > 15)
        {
            Label1.Text = ("手机号，必须是11-15位字符 ");
            return;
        }
        if (tbOfficTel.Text.Length < 7 || tbOfficTel.Text.Length > 20)
        {
            Label1.Text = ("办公电话，必须是7-20位字符 ");
            return;
        }
        if (tbHomeTel.Text.Length < 7 || tbHomeTel.Text.Length > 20)
        {
            Label1.Text = ("家庭电话，必须是7-20位字符 ");
            return;
        }
        if (!tbEmail.Text.Contains("@") && (!tbEmail.Text.Contains(".")))
        {
            Label1.Text = ("电子邮件，格式 必须正确 ");
            return;
        }
        sid = Request.QueryString["id"].ToString();

        string sql = "";
        if (tbPass.Text.Length > 0)
        {
            sql = @"update [dbo].[User] set [LoginName]='" + tbUser.Text + "',[Password]='" + MD5.CreateMD5Hash(tbPass.Text) + "',[RealName]='" + tbName.Text + "' ,[Title]='" + tbTitles.SelectedValue + "',[Sex]='" + ddlSex.SelectedIndex + "'           ,[Email]='" + tbEmail.Text
                + "' ,[MobilePhone] ='" + tbTel.Text + "'          ,[OfficePhone]='" + tbOfficTel.Text + "'           ,[HomePhone]='" + tbHomeTel.Text
                + "'           ,[DepartmentID]='" + ddlDept.SelectedValue + "'           ,[Enabled]='" + ((cbQiYong.Checked) ? "1" : "0") + "'           ,[IsAgent]='" + ((cbZuoXi.Checked) ? "1" : "0") + "' where UserID=" + sid;
        }
        else
        {
            sql = @"update [dbo].[User] set [LoginName]='" + tbUser.Text + "',[RealName]='" + tbName.Text + "' ,[Title]='" + tbTitles.SelectedValue + "',[Sex]='" + ddlSex.SelectedIndex + "'           ,[Email]='" + tbEmail.Text
                + "' ,[MobilePhone] ='" + tbTel.Text + "'          ,[OfficePhone]='" + tbOfficTel.Text + "'           ,[HomePhone]='" + tbHomeTel.Text
                + "'           ,[DepartmentID]='" + ddlDept.SelectedValue + "'           ,[Enabled]='" + ((cbQiYong.Checked) ? "1" : "0") + "'           ,[IsAgent]='" + ((cbZuoXi.Checked) ? "1" : "0") + "' where UserID=" + sid;
        }
        int count = DBqiye.getRowsCount(sql);
        if (count > 0) Label1.Text = "保存成功"; else Label1.Text = "保存失败";
    }
}