using System;
using System.Collections.Generic;
 
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class admin_xuqiuadd : System.Web.UI.Page
{
    public int icompanyid = 0;
    public int id = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Common.isAdminLogin())
        {
            Response.Redirect("login.aspx");
            Response.End();

        }
        icompanyid = Convert.ToInt32(Request.QueryString["cid"]);
        
        if (!Page.IsPostBack)
        {
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
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    DataTable dt;
                    dt = DBqiye.getDataTable(@"select *  from  XuQiu where id=" + id + "    ");


                    if (dt.Rows.Count > 0)
                    {
                        DataRow dr = dt.Rows[0];

                        rongzi.Text = dr["rongzi"].ToString();
                        //zhengce.Text = dr["zhengce"].ToString();
                        chanyelian.Text = dr["chanyelian"].ToString();
                        touzi.Text = dr["touzi"].ToString();
                        //shouguo.Text = dr["shouguo"].ToString();
                        beishou.Text = dr["beishou"].ToString();

                        icompanyid = Convert.ToInt32(dr["CompanyID"].ToString());
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
                icompanyid = Convert.ToInt32(Request.QueryString["cid"]);
                Button1.Visible = true;
                Button2.Visible = false;
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string sql = "";
        {
            //sql = @"INSERT INTO [dbo].[XuQiu]
            //     ([CompanyID]           ,[rongzi]           ,[zhengce]           ,[chanyelian]          
            //    ,[touzi]           ,[shouguo]           ,[beishou],[Update])VALUES(
            //        " + icompanyid + ",'" + rongzi.Text + "','" + zhengce.Text + "','" + chanyelian.Text + "','" +
            //    touzi.Text + "','" + shouguo.Text + "','" + beishou.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
            sql = @"INSERT INTO [dbo].[XuQiu]
                 ([CompanyID]           ,[rongzi],[chanyelian]          
                ,[touzi]                    ,[beishou],[Update])VALUES(
                    " + icompanyid + ",'" + rongzi.Text + "','" + chanyelian.Text + "','" +
                touzi.Text + "','" + beishou.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
        }

        int count = DBqiye.getRowsCount(sql);
        if (count > 0) Label1.Text = "保存成功"; else Label1.Text = "保存失败";
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        id = Convert.ToInt32(Request.QueryString["id"]);
        string sql = "";
        {
            sql = @"update [dbo].[XuQiu] set [rongzi] ='" + rongzi.Text + " ' ,[chanyelian]='" + chanyelian.Text
                 + "',[touzi]='" + touzi.Text + "',[beishou]='" + beishou.Text + "' where id=" + id;
        }

        int count = DBqiye.getRowsCount(sql);
        if (count > 0) Label1.Text = "保存成功"; else Label1.Text = "保存失败";
    }
}