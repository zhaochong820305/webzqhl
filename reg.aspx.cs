using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class reg : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            setting(4, usertypes); //用户分类
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
        if (user.Text.Length < 3)
        {
            msg.Text = "请输入用户名,最少为3位，谢谢";
            return;
        }
        if (pass.Text.Length < 6)
        {
            msg.Text = "请输入密码，最少为6位，谢谢";
            return;
        }
        if (pass.Text != pass2.Text)
        {
            msg.Text = "密码必须一样，谢谢";
            return;
        }
        if (usertypes.SelectedValue=="0")
        {
            msg.Text = "请选择用户分类，谢谢";
            return;
        }
        string sql1 = "select * from [Company] where MemberName ='" + Common.strFilter(user.Text) + "' ";
        //Response.Write(sql1);
        //Response.End();
        msg.Text = sql1;
        DataTable dt2 = DBqiye.getDataTable(sql1);
        if (dt2.Rows.Count > 0)
        {
            msg.Text = "该用户已经注册，请更换用户，谢谢";
            return;
        }
        string sql = "INSERT INTO [dbo].[Company]           ( [MemberName] ,[Name],[Address],[Incentive_HasStock]          ,[Password],[state],CreateDate,usertypes,EnterpriseType,typeid)  VALUES('" + Common.strFilter(user.Text) + "','','',0,'" + MD5.CreateMD5Hash(pass.Text) + "',1,'"+ DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','"+usertypes.SelectedValue+ "','" + usertypes.SelectedValue + "',1)  ";
        //Response.Write(sql);
        //DataTable dt = DBC.getDataTable("select * from zqhl_users where  loginuser='" + Common.strFilter(user.Text) + "'");
        //DataTable dt1 = DBqiye.getDataTable("select * from [dbo].[User] where   [Enabled]=1 and  LoginName='" + Common.strFilter(user.Text) + "'");
        int count = DBqiye.getRowsreturnid(sql+ " Select @@Identity");

        if (count>0)
        {
            Session["MemberName"] = Common.strFilter(user.Text);
            Session["usertypes"] = usertypes.SelectedValue;
            Session["sid"] = count;

            msg.Text = "注册成功";
            //return;
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
        //if (dt1.Rows.Count > 0)
        //{
        //    if (!dt1.Rows[0]["Password"].ToString().Equals(MD5.CreateMD5Hash(pass.Text)))
        //    {
        //        msg.Text = "用户名或密码错误";
        //        return;
        //    }
        //    Session["adminloginuser"] = dt1.Rows[0]["LoginName"].ToString();
        //    Session["userid"] = dt1.Rows[0]["UserID"].ToString();
        //    Session["title"] = dt1.Rows[0]["title"].ToString();
        //}
        //Response.Redirect("main.aspx");
        if (usertypes.SelectedValue.ToString() == "211")
        {
            Response.Redirect("comperson.aspx");
        }
        else
        {
            Response.Redirect("comindex.aspx");
        }

    }
}