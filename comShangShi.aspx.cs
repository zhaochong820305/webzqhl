using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class comShangShi : System.Web.UI.Page
{
    public int typeid = 2;
    public string scompanyid = "";
    protected void Page_Load(object sender, EventArgs e)
    {
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
            Label2.Text = "请选择企业，否则无法显示";
            return;
        }
        if (!Page.IsPostBack)
        {


            BindGrid();

        }
    }
    private void BindGrid()
    {
        string sid = scompanyid;
        DataTable dt;
        dt = DBqiye.getDataTable(@"select *,(select Name from  [dbo].[Setting] where [ID]=b.Region) as City
                                    ,(select Name from  [dbo].[Setting] where [ID]=b.EnterpriseType) as EnterType
                                     ,(select Name from  [dbo].[Setting] where [ID]=b.KeyAreas) as KeyArea
                                    from [Company] b where b.id=" + sid + " order by b.id desc   ");

        try
        {
            if (dt.Rows.Count > 0)
            {

                string sShangShi = "否";
                DataRow dr = dt.Rows[0];
                //scompanyid = dr["id"].ToString();

                //
                tbFangXiang.Text = dr["ShangShi_Target"].ToString();
                tbShiJian.Text = dr["ShangShi_Time"].ToString();
                tbZhuiBei.Text = dr["ShangShi_PrepareInfo"].ToString();

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
    protected void btSave_Click(object sender, EventArgs e)
    {
        //Response.Write(tbFangXiang.Text);
        //Response.Write(tbShiJian.Text);
        //Response.Write(tbZhuiBei.Text);
        string sid = "0";
        if (Request.QueryString["id"] != null && (!string.IsNullOrEmpty(Request.QueryString["id"])) && Request.QueryString["id"].Length > 0)
        {
            sid = Request.QueryString["id"].ToString();
        }
        else if (Session["sid"] != null && Session["sid"].ToString() != "" && Session["sid"].ToString().Length > 0)
        {
            sid = Session["sid"].ToString();
        }
        else
        {
            Label2.Text = "请选择企业，否则无法显示";
            return;
        }
        if (tbFangXiang.Text.Trim().Length == 0)
        {
            Label2.Text = "上市方向不允许为空";
            return;
        }
        if (tbShiJian.Text.Trim().Length == 0)
        {
            Label2.Text = "上市时间不允许为空";
            return;
        }
        if (tbZhuiBei.Text.Trim().Length == 0)
        {
            Label2.Text = "上市准备不允许为空";
            return;
        }
        string sql = @"UPDATE [dbo].[Company] SET   [ShangShi_Target] = '" + Common.strFilter(tbFangXiang.Text.Trim()) + "',[ShangShi_Time] = '" + Common.strFilter(tbShiJian.Text.Trim()) + "'      ,[ShangShi_PrepareInfo] = '" + Common.strFilter(tbZhuiBei.Text.Trim()) + "'  WHERE ID=" + sid + "";
        int count = DBqiye.getRowsCount(sql);
        typeid = 2;
        if (count > 0) Label2.Text = "保存成功"; else Label2.Text = "保存失败";

    }
}