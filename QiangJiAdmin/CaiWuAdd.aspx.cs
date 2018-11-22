using System;
using System.Collections.Generic;
 
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class admin_CaiWuAdd : System.Web.UI.Page
{
    public int icompanyid = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Common.isAdminLogin())
        {
            Response.Redirect("login.aspx");
            Response.End();

        }
        tbYear.Focus();
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
                    dt = DBqiye.getDataTable(@"select *  from  CaiWu where id=" + id + "    ");


                    if (dt.Rows.Count > 0)
                    {
                        DataRow dr = dt.Rows[0];

                        tbYear.Text = dr["Year"].ToString();
                        tbfuzhai.Text = dr["DebtRatio"].ToString();
                        tbYanFa.Text = dr["RDInvestmentRatio"].ToString();
                        tbZiChan.Text = dr["TotalAsset"].ToString();
                        tbShouLu.Text = dr["Income"].ToString();
                        tbLiRun.Text = dr["Profit"].ToString();
                        tbNaShui.Text = dr["Tax"].ToString();
                        tbChuKou.Text = dr["ExportEarnings"].ToString();

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

        int icompanyid = 0;
        try
        {
            icompanyid = Convert.ToInt32(Request.QueryString["cid"].ToString());
        }
        catch
        {
            Label1.Text = ("公司ID,必须是数字");
            return;
        }


        if (tbYear.Text.Length != 4)
        {
            Label1.Text = ("年份,必须是4位");
            return;
        }
        else
        {
            try
            {
                Convert.ToInt32(tbYear.Text);
            }
            catch
            {
                Label1.Text = ("年份,必须是数字");
                return;
            }
        }
        try
        {
            Convert.ToSingle(tbfuzhai.Text);
        }
        catch
        {
            Label1.Text = ("资产负债率,必须是数字");
            return;
        }
        try
        {
            Convert.ToSingle(tbYanFa.Text);
        }
        catch
        {
            Label1.Text = ("研发投入比,必须是数字");
            return;
        }
        try
        {
            Convert.ToSingle(tbZiChan.Text);
        }
        catch
        {
            Label1.Text = ("企业总资产,必须是数字");
            return;
        }
        try
        {
            Convert.ToSingle(tbShouLu.Text);
        }
        catch
        {
            Label1.Text = ("收入,必须是数字");
            return;
        }
        try
        {
            Convert.ToSingle(tbLiRun.Text);
        }
        catch
        {
            Label1.Text = ("利润,必须是数字");
            return;
        }
        try
        {
            Convert.ToSingle(tbNaShui.Text);
        }
        catch
        {
            Label1.Text = ("纳税,必须是数字");
            return;
        }
        try
        {
            Convert.ToSingle(tbChuKou.Text);
        }
        catch
        {
            Label1.Text = ("出口,必须是数字");
            return;
        }
        string sql = "";
        {
            sql = @"INSERT INTO [dbo].[CaiWu]           ([CompanyID]           ,[Year]           ,[TotalAsset]           ,[DebtRatio]
                    ,[RDInvestmentRatio]           ,[Income]           ,[Profit]           ,[Tax]           ,[ExportEarnings]           ,[CreateDate])VALUES(
                    " + icompanyid + "," + tbYear.Text + ",'" + tbZiChan.Text + "','" + tbfuzhai.Text + "','" +
                tbYanFa.Text + "','" + tbShouLu.Text + "','" + tbLiRun.Text + "','" + tbNaShui.Text + "','" + tbChuKou.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
        }

        int count = DBqiye.getRowsCount(sql);
        if (count > 0) Label1.Text = "保存成功"; else Label1.Text = "保存失败";
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


        if (tbYear.Text.Length != 4)
        {
            Label1.Text = ("年份,必须是4位");
            return;


        }
        else
        {
            try
            {
                Convert.ToInt32(tbYear.Text);
            }
            catch
            {
                Label1.Text = ("年份,必须是数字");
                return;
            }
        }
        try
        {
            Convert.ToSingle(tbfuzhai.Text);
        }
        catch
        {
            Label1.Text = ("资产负债率,必须是数字");
            return;
        }
        try
        {
            Convert.ToSingle(tbYanFa.Text);
        }
        catch
        {
            Label1.Text = ("研发投入比,必须是数字");
            return;
        }
        try
        {
            Convert.ToSingle(tbZiChan.Text);
        }
        catch
        {
            Label1.Text = ("企业总资产,必须是数字");
            return;
        }
        try
        {
            Convert.ToSingle(tbShouLu.Text);
        }
        catch
        {
            Label1.Text = ("收入,必须是数字");
            return;
        }
        try
        {
            Convert.ToSingle(tbLiRun.Text);
        }
        catch
        {
            Label1.Text = ("利润,必须是数字");
            return;
        }
        try
        {
            Convert.ToSingle(tbNaShui.Text);
        }
        catch
        {
            Label1.Text = ("纳税,必须是数字");
            return;
        }
        try
        {
            Convert.ToSingle(tbChuKou.Text);
        }
        catch
        {
            Label1.Text = ("出口,必须是数字");
            return;
        }
        string sql = "";
        {
            sql = @"update [dbo].[CaiWu] set [Year] =" + tbYear.Text + " ,[TotalAsset]='" + tbZiChan.Text + "' ,[DebtRatio]='" + tbfuzhai.Text
                + "',[RDInvestmentRatio]='" + tbYanFa.Text + "',[Income]='" + tbShouLu.Text + "',[Profit]='" + tbLiRun.Text + "',[Tax]='" + tbNaShui.Text + "' ,[ExportEarnings] ='" + tbChuKou.Text + "' where id=" + id;
        }

        int count = DBqiye.getRowsCount(sql);
        if (count > 0) Label1.Text = "保存成功"; else Label1.Text = "保存失败";
    }
}