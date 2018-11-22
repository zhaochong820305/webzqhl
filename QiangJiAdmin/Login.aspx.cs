using System;
using System.Collections.Generic;
 
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class admin_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

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
        DataTable dt1 = DBqiye.getDataTable("select * from [dbo].[User] where   [Enabled]=1 and  LoginName='" + Common.strFilter(user.Text) + "'");
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
            Session["adminloginuser"] = dt1.Rows[0]["LoginName"].ToString();
            Session["userid"] = dt1.Rows[0]["UserID"].ToString();
            Session["title"] = dt1.Rows[0]["title"].ToString();
        }

        Response.Redirect("main.aspx");
        
    }
}