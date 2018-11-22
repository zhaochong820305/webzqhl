using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class comperson : System.Web.UI.Page
{
    public int typeid = 1;
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
            Label1.Text = "请选择企业，否则无法显示";
            return;
        }
        if (!Page.IsPostBack)
        {
            //setting(4, danwenxz); //单位性质
            setting(2, diqu); //地址

            try
            {
                
                DataTable dt;
                dt = DBqiye.getDataTable(@"select *  from  ResultRen where cno='" + Session["sid"].ToString() + "'    ");


                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];

                    CName.Text = dr["CName"].ToString();
                    //CLianXi.Text = dr["CLianXi"].ToString();
                    Tel.Text = dr["Tel"].ToString();
                    Title.Text = dr["Title"].ToString();
                    email.Text = dr["email"].ToString();

                    //danwenxz.Text = dr["danwenxz"].ToString();
                    diqu.Text = dr["diqu"].ToString();
                    addr.Text = dr["addr"].ToString();
                    jianjie.Text = dr["jianjie"].ToString();
                    //CLianXi.Text = dr["CLianXi"].ToString();

                    scompanyid = (dr["CNO"].ToString());
                    Button1.Text = "修改信息";
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
        scompanyid = Session["sid"].ToString();


        string sql = "";
        if (Button1.Text == "添加信息")
        {
            sql = @"INSERT INTO [dbo].[ResultRen]
           ([CNo]           ,[CName]           ,[CLianXi]           ,[Tel]
           ,[Title]           ,[email]                ,[addr]
           ,[diqu]           ,[jianjie]           ,[state]           ,[update])VALUES(
                    " + scompanyid + ",'" + CName.Text + "','" + CName.Text + "','" + Tel.Text + "','"
                    + Title.Text + "','" + email.Text + "','" + addr.Text + "','"
                    + diqu.Text + "','" + jianjie.Text + "',1,'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
        }
        else
        {            
                sql = @"update [dbo].[ResultRen]
                set [CName]='" + CName.Text + "'           ,[CLianXi]='" + CName.Text + "'           ,[Tel]='" + Tel.Text
               + "',[Title]='" + Title.Text + "'           ,[email]='" + email.Text + "'              ,[addr]='" + addr.Text
               + "' ,[diqu]='" + diqu.Text + "'           ,[jianjie]='" + jianjie.Text + "'           ,[update]='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where cno='" + Session["sid"].ToString() + "'";


        }
        int count = DBqiye.getRowsCount(sql);
        if (count > 0) Label1.Text = "保存成功"; else Label1.Text = "保存失败" + sql;
    }
}