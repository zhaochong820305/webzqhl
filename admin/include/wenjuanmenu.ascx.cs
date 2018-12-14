using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_include_wenjuanmenu : System.Web.UI.UserControl
{
    public string stype = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Common.isAdminLogin())
        {
            Response.Redirect("login.aspx");
            Response.End();
        }
        if (Request.QueryString["type"] != null && (!string.IsNullOrEmpty(Request.QueryString["type"])) && Request.QueryString["type"].Length > 0)
        {
            stype = Request.QueryString["type"].ToString();
        }
    }
}