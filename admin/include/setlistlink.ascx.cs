using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class QiangJiAdmin_include_setlistlink : System.Web.UI.UserControl
{
    public string stype = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["type"] != null && (!string.IsNullOrEmpty(Request.QueryString["type"])) && Request.QueryString["type"].Length > 0)
        {
            stype = Request.QueryString["type"].ToString();
        }
        else
        {
            //Label1.Text = "请选择企业，否则无法显示";
            return;
        }
    }
}