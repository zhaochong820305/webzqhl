using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class admin_zhnanjiayiAdd : System.Web.UI.Page
{
    public int icompanyid = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Common.isAdminLogin())
        {
            Response.Redirect("login.aspx");
            Response.End();

        }
        //zhengshutype.Focus();
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
                    dt = DBqiye.getDataTable(@"select *  from  [ResultExperts] where id=" + id + "    ");


                    if (dt.Rows.Count > 0)
                    {
                        DataRow dr = dt.Rows[0];

                        PingFen.Text = dr["PingFen"].ToString();
                        jishuchuangxin.Text = dr["jishuchuangxin"].ToString();
                        jingjizhibiao.Text = dr["jingjizhibiao"].ToString();
                        nandu.Text = dr["nandu"].ToString();
                        chengshudu.Text = dr["chengshudu"].ToString();

                        shichangjingzheng.Text = dr["shichangjingzheng"].ToString();
                        shehuixiaoyi.Text = dr["shehuixiaoyi"].ToString();
                        YiJian.Text = dr["YiJian"].ToString();
                        XingMing.Text = dr["XingMing"].ToString();
                        Pdate.Text = dr["Pdate"].ToString();

                        icompanyid = Convert.ToInt32(dr["CNO"].ToString());
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

        icompanyid = Convert.ToInt32(Request.QueryString["cid"]);

        
        //if (zhengshuname.Text.Length == 0)
        //{
        //    Label1.Text = ("证书名不能为空！");
        //    return;
        //}
        //if (zhengshuno.Text.Length == 0)
        //{
        //    Label1.Text = ("证书号不能为空！");
        //    return;
        //}
        
        string sql = "";
        {
            sql = @"INSERT INTO [dbo].[ResultExperts]
            ([RID]           ,[PingFen]           ,[YiJian]           ,[XingMing]
           ,[Pdate]           ,[jishuchuangxin]           ,[jingjizhibiao]           ,[nandu]
           ,[chengshudu]           ,[shichangjingzheng]           ,[shehuixiaoyi],[state],[updates])VALUES(
            " + icompanyid + ",'" + PingFen.Text + "','" + YiJian.Text + "','"+ XingMing.Text + "','" 
            + Pdate.Text + "','" + jishuchuangxin.Text + "','" + jingjizhibiao.Text + "','" + nandu.Text + "','"
             + chengshudu.Text + "','" + shichangjingzheng.Text + "','" + shehuixiaoyi.Text + "',1,'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
        }

        int count = DBqiye.getRowsCount(sql);
        sql = "";
        if (count > 0) Label1.Text = "保存成功" + sql; else Label1.Text = "保存失败" + sql;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {

        int id = 0;
        try
        {
            id = Convert.ToInt32(Request.QueryString["id"].ToString());
        }
        catch
        {
            Label1.Text = ("公司ID,必须是数字");
            return;
        }

        

        string sql = "";
        {
            sql = @"update [dbo].[ResultExperts]
            set [PingFen]='" + PingFen.Text + "'           ,[YiJian]='" + YiJian.Text + "'           ,[XingMing]='" + XingMing.Text 
            + "' ,[Pdate]='" + Pdate.Text + "'           ,[jishuchuangxin]='" + jishuchuangxin.Text + "'           ,[jingjizhibiao]='" + jingjizhibiao.Text + "'           ,[nandu]='" + nandu.Text 
            + "',[chengshudu]='" + chengshudu.Text + "'           ,[shichangjingzheng]='" + shichangjingzheng.Text + "'           ,[shehuixiaoyi]='" + shehuixiaoyi.Text + "' where id=" + id;
        }

        int count = DBqiye.getRowsCount(sql);
        if (count > 0) Label1.Text = "保存成功"; else Label1.Text = "保存失败" + sql;
    }
     
}