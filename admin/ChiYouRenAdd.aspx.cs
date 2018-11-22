using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class admin_ChiYouRenAdd : System.Web.UI.Page
{
    public int icompanyid = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Common.isAdminLogin())
        {
            Response.Redirect("login.aspx");
            Response.End();

        }
        CName.Focus();
        icompanyid = Convert.ToInt32(Request.QueryString["cid"]);
        if (!Page.IsPostBack)
        {
            setting(4, danwenxz); //成果性质
            setting(2, diqu); //地址
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
                    dt = DBqiye.getDataTable(@"select *  from  ResultRen where id=" + id + "    ");


                    if (dt.Rows.Count > 0)
                    {
                        DataRow dr = dt.Rows[0];

                        CName.Text = dr["CName"].ToString();
                        CLianXi.Text = dr["CLianXi"].ToString();
                        Tel.Text = dr["Tel"].ToString();
                        Title.Text = dr["Title"].ToString();
                        email.Text = dr["email"].ToString();

                        danwenxz.Text = dr["danwenxz"].ToString();
                        diqu.Text = dr["diqu"].ToString();
                        addr.Text = dr["addr"].ToString();
                        jianjie.Text = dr["jianjie"].ToString();
                        //CLianXi.Text = dr["CLianXi"].ToString();

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


        string sql = "";
        {
            sql = @"INSERT INTO [dbo].[ResultRen]
           ([CNo]           ,[CName]           ,[CLianXi]           ,[Tel]
           ,[Title]           ,[email]           ,[danwenxz]           ,[addr]
           ,[diqu]           ,[jianjie]           ,[state]           ,[update])VALUES(
                    " + icompanyid + ",'" + CName.Text + "','" + CLianXi.Text + "','" + Tel.Text + "','"
                    + Title.Text + "','" + email.Text + "','" + danwenxz.Text + "','" + addr.Text + "','" 
                    + diqu.Text + "','" + jianjie.Text + "',1,'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
        }

        int count = DBqiye.getRowsCount(sql);
        if (count > 0) Label1.Text = "保存成功"; else Label1.Text = "保存失败"+ sql;
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


        //if (tbYear.Text.Length != 4)
        //{
        //    Label1.Text = ("年份,必须是4位");
        //    return;


        //}
        //else
        //{
        //    try
        //    {
        //        Convert.ToInt32(tbYear.Text);
        //    }
        //    catch
        //    {
        //        Label1.Text = ("年份,必须是数字");
        //        return;
        //    }
        //}
        //try
        //{
        //    Convert.ToSingle(tbfuzhai.Text);
        //}
        //catch
        //{
        //    Label1.Text = ("资产负债率,必须是数字");
        //    return;
        //}
        //try
        //{
        //    Convert.ToSingle(tbYanFa.Text);
        //}
        //catch
        //{
        //    Label1.Text = ("研发投入比,必须是数字");
        //    return;
        //}
        //try
        //{
        //    Convert.ToSingle(tbZiChan.Text);
        //}
        //catch
        //{
        //    Label1.Text = ("企业总资产,必须是数字");
        //    return;
        //}
        //try
        //{
        //    Convert.ToSingle(tbShouLu.Text);
        //}
        //catch
        //{
        //    Label1.Text = ("收入,必须是数字");
        //    return;
        //}
        //try
        //{
        //    Convert.ToSingle(tbLiRun.Text);
        //}
        //catch
        //{
        //    Label1.Text = ("利润,必须是数字");
        //    return;
        //}
        //try
        //{
        //    Convert.ToSingle(tbNaShui.Text);
        //}
        //catch
        //{
        //    Label1.Text = ("纳税,必须是数字");
        //    return;
        //}
        //try
        //{
        //    Convert.ToSingle(tbChuKou.Text);
        //}
        //catch
        //{
        //    Label1.Text = ("出口,必须是数字");
        //    return;
        //}
        string sql = "";
        {
            sql = @"update [dbo].[ResultRen]
            set [CName]='" + CName.Text + "'           ,[CLianXi]='" + CLianXi.Text + "'           ,[Tel]='" + Tel.Text
           + "',[Title]='" + Title.Text + "'           ,[email]='" + email.Text + "'           ,[danwenxz]='" + danwenxz.Text + "'           ,[addr]='" + addr.Text 
           + "' ,[diqu]='"+ diqu.Text + "'           ,[jianjie]='" + jianjie.Text + "'           ,[update]='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where id=" + id;
        }

        int count = DBqiye.getRowsCount(sql);
        if (count > 0) Label1.Text = "保存成功"; else Label1.Text = "保存失败"+sql;
    }
}