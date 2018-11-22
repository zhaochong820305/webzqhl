using System;
using System.Collections.Generic;
 
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class admin_HeZuo : System.Web.UI.Page
{
    public string id = string.Empty;
    public string pid = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Common.isAdminLogin())
        {
            Response.Redirect("login.aspx");
            Response.End();
        }
        if (Request.QueryString["pid"] != null && (!string.IsNullOrEmpty(Request.QueryString["pid"])) && Request.QueryString["pid"].Length > 0)
        {
            pid = Request.QueryString["pid"].ToString();
        }
        else
        {
            Label1.Text = "请选择项目，否则无法显示";
            return;
        }

        if (!Page.IsPostBack)
        {
            string op = Request.QueryString["op"].ToString();
            if (op == "edit" || op == "kan")
            {
                if (op == "edit")
                {
                    Button4.Visible = false;
                    Button5.Visible = true;
                }
                else
                {
                    Button4.Visible = false;
                    Button5.Visible = false;
                }

                try
                {
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    DataTable dt;
                    dt = DBqiye.getDataTable(@"SELECT * ,(select Name from Setting where id =c.Type) as TName 
                                   ,(select Name from Setting where id = c.MainDirection) as MName
                                   ,(select Name from Setting where id = c.EnterpriseType) as EName  FROM  [dbo].[Cooperation] c where ProjectID = " + pid);


                    if (dt.Rows.Count > 0)
                    {
                        DataRow dr = dt.Rows[0];

                        ddlLeiBie.SelectedValue = dr["Type"].ToString();
                        ddlXingZhi.SelectedValue = dr["EnterpriseType"].ToString();
                        ddlHangYe.SelectedValue = dr["MainDirection"].ToString();
                        tbGuiMe.Text = dr["Scale"].ToString();
                        tbMiaoShu.Text = dr["Description"].ToString();
                        //icompanyid = Convert.ToInt32(dr["CompanyID"].ToString());
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
                //icompanyid = Convert.ToInt32(Request.QueryString["cid"]);
                Button4.Visible = true;
                Button5.Visible = false;
            }
            //company(); //绑定公司名称
            setting(4, ddlXingZhi);  // 性质
            setting(3, ddlHangYe);  // 行业
            setting(17, ddlLeiBie);  //类别
        }
    }
    private void setting(int itype, DropDownList ddlname)
    {
        DataTable dt = DBqiye.getDataTable("SELECT  [ID],[Name]  FROM [dbo].[Setting] where SettingID=" + itype + "");
        ddlname.DataSource = dt;
        ddlname.DataTextField = "Name";
        ddlname.DataValueField = "ID";
        ddlname.DataBind();
        //ddlname.Items.Insert(0, new ListItem("==请选择==", "0"));
        //ddlname.SelectedValue = "";
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        try
        {
            Convert.ToSingle(tbGuiMe.Text);
        }
        catch
        {
            Label1.Text = ("合作方企业规模,必须为数字！");
            return;
        }
        string sql = "";
        {
            sql = @"INSERT INTO [dbo].[Cooperation]
                       ([ProjectID]           ,[Type]           ,[Scale]           ,[MainDirection]
                       ,[EnterpriseType]           ,[Description]           ,[CreateDate]) VALUES(
                       '" + pid + "', '" + ddlLeiBie.SelectedValue + "','" + tbGuiMe.Text + "','" + ddlHangYe.SelectedValue + "','" +
                   ddlXingZhi.SelectedValue + "','" + tbMiaoShu.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
        }
        int count = DBqiye.getRowsCount(sql);
        if (count > 0) Label1.Text = "保存成功"; else Label1.Text = "保存失败";
    }

    protected void Button5_Click(object sender, EventArgs e)
    {   //修改
        int id = Convert.ToInt32(Request.QueryString["id"]);
        try
        {
            Convert.ToSingle(tbGuiMe.Text);
        }
        catch
        {
            Label1.Text = ("合作方企业规模,必须为数字！");
            return;
        }
        string sql = "";
        {
            sql = @"update [dbo].[Cooperation]
                       set [Type]= '" + ddlLeiBie.SelectedValue + "',[Scale]='" + tbGuiMe.Text + "' ,[MainDirection]='" + ddlHangYe.SelectedValue + "',[EnterpriseType]='" +
                   ddlXingZhi.SelectedValue + "' ,[Description]='" + tbMiaoShu.Text + "' where id= " + id;
        }
        int count = DBqiye.getRowsCount(sql);
        if (count > 0) Label1.Text = "保存成功"; else Label1.Text = "保存失败";
    }
}