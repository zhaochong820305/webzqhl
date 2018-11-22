using System;
using System.Collections.Generic;
 
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class admin_zx : System.Web.UI.Page
{
    public int id = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Common.isAdminLogin())
        {
            Response.Redirect("login.aspx");
            Response.End();
        }
        try
        {
            id = int.Parse(Request.QueryString["id"].ToString());
            if (!Page.IsPostBack)
            {
                if (id != 0)
                {
                    DataTable dt;
                    dt = DBC.getDataTable("select * from zqhl_zxsq where id=" + id);
                    if (dt.Rows.Count > 0)
                    {
                        DataRow dr = dt.Rows[0];
                        qymc.Text = dr["qymc"].ToString();
                        lxr.Text = dr["lxr"].ToString();
                        lxdh.Text = dr["lxdh"].ToString();
                        xmmc.Text = dr["xmmc"].ToString();
                        //xmjs.Text = dr["xmjs"].ToString();
                        cl.Checked = (dr["cl"].ToString() == "0" ? false : true);
                        //jsys.Text = dr["jsys"].ToString();
                        //cqqk.Text = dr["cqqk"].ToString();
                        //tzjd.Text = dr["tzjd"].ToString();
                        //xslr.Text = dr["xslr"].ToString();
                        email.Text = dr["email"].ToString();
                        quyu.Text = dr["quyu"].ToString();
                        typename.Text = dr["typename"].ToString();

                        zjxm.Text = dr["zjxm"].ToString();
                    }
                }
            }
        }
        catch { }
    }


    protected void bc_Click(object sender, EventArgs e)
    {
        string sql = "";
        sql = "update zqhl_zxsq set [cl]=" + ((cl.Checked) ? "1" : "0") + " where id=" + id;
        int count = DBC.getRowsCount(sql);
        if (count > 0) msg.Text = "保存成功"; else msg.Text = "保存失败";
    }
}