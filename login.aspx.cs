using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class admin_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //setting(4, usertypes); //用户分类
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
        ddlname.SelectedValue = "0";
        if (itype == 30)
        {
            ddlname.SelectedValue = "206";
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        msg.Text = "";
        if (user.Text.Length == 0)
        {
            msg.Text = "请输入用户名，谢谢";
            return;
        }
        //DataTable dt = DBC.getDataTable("select * from zqhl_users where  loginuser='" + Common.strFilter(user.Text) + "'");
        DataTable dt1 = DBqiye.getDataTable("select * from [dbo].[Company] where   [state]=1 and  MemberName='" + Common.strFilter(user.Text) + "'");
        if (dt1.Rows.Count == 0)
        {
            msg.Text = "用户名或密码错误";
            return;
        }
        //if(dt.Rows.Count>0)
        //{
        //    if (!dt.Rows[0]["pass"].ToString().Equals(MD5.CreateMD5Hash(pass.Text)))
        //    {
        //        msg.Text = "用户名或密码错误";
        //        return;
        //    }
        //    Session["adminloginuser"] = dt.Rows[0]["loginuser"].ToString();
        //}
        if (dt1.Rows.Count > 0)
        {
            if (!dt1.Rows[0]["Password"].ToString().Equals(MD5.CreateMD5Hash(pass.Text)))
            {
                msg.Text = "用户名或密码错误";
                return;
            }
            Session["MemberName"] = dt1.Rows[0]["MemberName"].ToString();
            Session["sid"] = dt1.Rows[0]["id"].ToString();
            Session["usertypes"] = dt1.Rows[0]["usertypes"].ToString(); //usertypes.SelectedValue;
                                                                        //Session["title"] = dt1.Rows[0]["title"].ToString();
            if (Session["usertypes"].ToString() == "211")
            {
                Response.Redirect("comperson.aspx");
            }
            else
            {
                Response.Redirect("comindex.aspx");
            }
        }

       // Response.Redirect("main.aspx");
    }
}