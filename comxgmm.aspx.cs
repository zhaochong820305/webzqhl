using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class comxgmm : System.Web.UI.Page
{
    public string scompanyid = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Common.iscompanyLogin())
        {
            Response.Redirect("login.aspx");
            Response.End();

        }
        if (Request.QueryString["id"] != null && (!string.IsNullOrEmpty(Request.QueryString["id"])) && Request.QueryString["id"].Length > 0)
        {
            scompanyid = Request.QueryString["id"].ToString();
        }
        else if (Session["sid"] != null && Session["sid"].ToString() != "" && Session["sid"].ToString().Length > 0)
        {
            scompanyid = Session["sid"].ToString();
        }
        else
        {
            msgb.Text = "请选择企业，否则无法显示";
            return;
        }

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        msgb.Text = "";
        if (newpass.Text.Length == 0) { msgb.Text = "新密码不能为空"; return; }
        if (!newpass.Text.Equals(confirmpass.Text)) { msgb.Text = "新密码和确认密码不符"; return; }
        DataTable dt = DBqiye.getDataTable("select Password from Company where MemberName='" + Session["MemberName"] + "'");// + Session["userid"].ToString());
        if (dt.Rows.Count > 0)
        {
            if (!dt.Rows[0][0].ToString().Equals(MD5.CreateMD5Hash(passwd.Text))) { msgb.Text = "旧密码不正确"; return; }
        }
        string sql = "update [Company] set Password='" + MD5.CreateMD5Hash(newpass.Text) + "' where MemberName='" + Session["MemberName"] + "'";// + Session["userid"].ToString();
        int count = DBqiye.getRowsCount(sql);
        if (count > 0) msgb.Text = "修改成功"; else msgb.Text = "修改失败";
    }
}