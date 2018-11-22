using System;
using System.Collections.Generic;
 
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class admin_online : System.Web.UI.Page
{
    public string str = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Common.isAdminLogin())
        {
            Response.Redirect("login.aspx");
            Response.End();
        }
        if (!Page.IsPostBack)
        {
            BindGrid();
        }
    }
    private void BindGrid()
    {
        string sid = "0";
        if (Request.QueryString["id"].Length > 0)
        {
            sid = Request.QueryString["id"].ToString();
        }
        else
        {
            Response.Write("请输入用户ID否则无法显示  &nbsp;<a href ='qygl.aspx'>返回企业管理</a>");
            Response.End();
        }
        DataTable dt;
        dt = DBqiye.getDataTable(@"SELECT *  FROM[dbo].[CompanyInfo] b where b.id=" + sid + " order by b.id desc   ");

        try
        {
            if (dt.Rows.Count > 0)
            {

                DataRow dr = dt.Rows[0];

                str += "<table class='table table-bordered'>"
                    + "     <tr style = 'page-break-inside: avoid;'>"
                    + "         <th class='active' style='width: 120px;'>企业名称：</th>"
                    + "         <td colspan = '3' > " + dr["Name"].ToString() + "</td>"
                    + "     </tr>"
                    + "     <tr style = 'page-break-inside: avoid;' >"
                    + "         <th class='active' style='width: 120px;'>联系人：</th>"
                    + "         <td>" + dr["Contact"].ToString() + "</td>"
                    + "         <th class='active' style='width: 120px;'>联系电话：</th>"
                    + "         <td>" + dr["Tel"].ToString() + "</td>"
                    + "     </tr>"
                    + "     <tr style = 'page-break-inside: avoid;' >"
                    + "         <th class='active' style='width: 120px;'>项目名称：</th>"
                    + "         <td colspan = '3'> " + dr["ProjectName"].ToString() + "</td>"
                    + "     </tr>"
                    + "     <tr style = 'page-break-inside: avoid;' >"
                    + "         <th class='active' style='width: 120px;'>项目介绍：</th>"
                    + "         <td colspan = '3'>" + dr["ProjectDesc"].ToString() + "</td>"
                    + "     </tr>"
                    + "     <tr style = 'page-break-inside: avoid;' >"
                    + "         <th class='active' style='width: 120px;'>技术优势：</th>"
                    + "         <td colspan = '3'>" + dr["ProjectYouShi"].ToString() + "</td>"
                    + "     </tr>"
                    + "     <tr style = 'page-break-inside: avoid;' >"
                    + "         <th class='active' style='width: 120px; height: 31px;'>知识产权情况：</th>"
                    + "         <td class='auto-style1' colspan='3'>" + dr["ProjectZhiShi"].ToString() + "</td>"
                    + "     </tr>"
                    + "     <tr style = 'page-break-inside: avoid;' >"
                    + "         <th class='active' style='width: 120px;'>投资及进度：</th>"
                    + "         <td colspan = '3'> " + dr["ProjectTouZi"].ToString() + "</td>"
                    + "     </tr>"
                    + "     <tr style = 'page-break-inside: avoid;' >"
                    + "         <th class='active' style='width: 120px;'>销售额及利润：</th>"
                    + "         <td colspan = '3'>" + dr["ProjectSales"].ToString() + "</td>"
                    + "     </tr>"
                    + " </table>";
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