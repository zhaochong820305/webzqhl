using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class comGuQuan : System.Web.UI.Page
{
    public int typeid = 6;
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
            Label3.Text = "请选择企业，否则无法显示";
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
                if (dr["Incentive_HasStock"].ToString() == "True")
                { cbguquan.Checked = true; }
                else
                { cbguquan.Checked = false; }
                tbjili.Text = dr["Incentive_StockInfo"].ToString();
                
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
    protected void Button3_Click(object sender, EventArgs e)
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
            Label3.Text = ("请选择企业，否则无法显示");
            return;
        }
        string sql = @"UPDATE [dbo].[Company] SET   [Incentive_StockInfo] = '" + Common.strFilter(tbjili.Text.Trim()) + "',[Incentive_HasStock] = '" + ((cbguquan.Checked) ? "1" : "0") + "'       WHERE ID=" + sid + "";
        int count = DBqiye.getRowsCount(sql);
        typeid = 6;
        if (count > 0) Label3.Text = "保存成功"; else Label3.Text = "保存失败";
    }
}