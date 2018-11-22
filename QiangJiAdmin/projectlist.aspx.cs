using System;
using System.Collections.Generic;
 
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class admin_projectlist : System.Web.UI.Page
{
    public string str = string.Empty;
    public string cid = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Common.isAdminLogin())
        {
            Response.Redirect("login.aspx");
            Response.End();
        }

        if (Request.QueryString["id"] != null && (!string.IsNullOrEmpty(Request.QueryString["id"])) && Request.QueryString["id"].Length > 0)
        {
            cid = Request.QueryString["id"].ToString();
        }
        else
        {
            Label1.Text = "请选择企业，否则无法显示";
            return;
        }

        if (!Page.IsPostBack)
        {
            //myGrid.Attributes.Add("style", "word-break:keep-all;word-wrap:false");

            BindGrid();
        }
    }

    private void BindGrid()
    {

        DataTable dt;
        dt = DBqiye.getDataTable(@"SELECT  p.*,c.Name as CName,(select top 1  s.Name from Setting s where s.id = p.Nature ) as naturename,
                        (select top 1  s.Name from Setting s where s.id = p.Military ) as MilitaryName
                        FROM  [dbo].[Project] p left join Company c on c.ID=p.CompanyID where p.id=" + cid + " ");
        try
        {
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                str = "<table class='gridtable'>"
                    + "    <tr style = 'page-break-inside: avoid;' >"
                    + "        <th class='active' style='width: 160px;'>项目名称：</th>"
                    + "        <td> " + dr["Name"].ToString() + "</td>"
                    + "    </tr>"
                    + "    <tr style = 'page-break-inside: avoid;' >"
                    + "        <th class='active' style='width: 160px;'>企业名称：</th>"
                    + "        <td> " + dr["CName"].ToString() + "</td>"
                    + "    </tr>"
                    + "    <tr style = 'page-break-inside: avoid;' >"
                    + "        <th class='active' style='width: 160px;'>项目目标：</th>"
                    + "        <td> " + dr["Goal"].ToString() + "</td>"
                    + "    </tr>"
                    + "    <tr style = 'page-break-inside: avoid;' >"
                    + "        <th class='active' style='width: 160px;'>项目规模：</th>"
                    + "        <td> " + dr["Scale"].ToString() + " 万元</td>"
                    + "    </tr>"
                    + "    <tr style = 'page-break-inside: avoid;' >"
                    + "        <th class='active' style='width: 160px;'>固定资产投资：</th>"
                    + "        <td> " + dr["FixedInverstment"].ToString() + " 万元</td>"
                    + "    </tr>"
                    + "    <tr style = 'page-break-inside: avoid;' >"
                    + "        <th class='active' style='width: 160px;'>非固定资产投资：</th>"
                    + "        <td> " + dr["NonFixedInverstment"].ToString() + " 万元</td>"
                    + "    </tr>"
                    + "    <tr style = 'page-break-inside: avoid;' >"
                    + "        <th class='active' style='width: 160px;'>开始时间：</th>"
                    + "        <td> " + dr["StartDate"].ToString() + "至" + dr["EndDate"].ToString() + "</td>"
                    + "    </tr>"
                    + "    <tr style = 'page-break-inside: avoid;' >"
                    + "        <th class='active' style='width: 160px;'>项目进度：</th>"
                    + "        <td> " + dr["Process"].ToString() + " %</td>"
                    + "    </tr>"
                    + "    <tr style = 'page-break-inside: avoid;' >"
                    + "        <th class='active' style='width: 160px;'>项目性质：</th>"
                    + "        <td> " + dr["naturename"].ToString() + "</td>"
                    + "    </tr>"
                    + "    <tr style = 'page-break-inside: avoid;' >"
                    + "        <th class='active' style='width: 160px;'>军工情况：</th>"
                    + "        <td> " + dr["MilitaryName"].ToString() + "</td>"
                    + "    </tr>"
                    + "</table>";

                str += "项目资质：<hr>"
                    + "<table class='gridtable'>"
                    + "    <tr style = 'page-break-inside: avoid;' >"
                    + "        <th class='active' style='width: 160px;'>项目资质：</th>"
                    + "        <td> " + dr["ZiZhi"].ToString() + "</td>"
                    + "    </tr>"
                     + "</table>";
                str += "技术优势：<hr>"
                    + "<table class='gridtable'>"
                    + "    <tr style = 'page-break-inside: avoid;' >"
                    + "        <th class='active' style='width: 160px;'>技术地位：</th>"
                    + "        <td> " + DBqiye._getSettingName(dr["Tech_DiWei"].ToString()) + "</td>"
                    + "    </tr>"
                    + "    <tr style = 'page-break-inside: avoid;' >"
                    + "        <th class='active' style='width: 160px;'>查新情况：</th>"
                    + "        <td> " + dr["Tech_Chaxin"].ToString() + "</td>"
                    + "    </tr>"
                    + "    <tr style = 'page-break-inside: avoid;' >"
                    + "        <th class='active' style='width: 160px;'>技术壁垒：</th>"
                    + "        <td> " + DBqiye._getSettingName(dr["Tech_BiLei"].ToString()) + "</td>"
                    + "    </tr>"
                    + "    <tr style = 'page-break-inside: avoid;' >"
                    + "        <th class='active' style='width: 160px;'>专利著作情况：</th>"
                    + "        <td> " + dr["Tech_ZhuanLiZhuzuo"].ToString() + " </td>"
                    + "    </tr>"
                    + "    <tr style = 'page-break-inside: avoid;' >"
                    + "        <th class='active' style='width: 160px;'>研发力量：</th>"
                    + "        <td> " + dr["Tech_RDInfo"].ToString() + " </td>"
                    + "    </tr>"
                    + "    <tr style = 'page-break-inside: avoid;' >"
                    + "        <th class='active' style='width: 160px;'>未来研发方向：</th>"
                    + "        <td> " + dr["Tech_RDTarger"].ToString() + " </td>"
                    + "    </tr>"
                    + "</table>";
                str += "市场情况：<hr>"
                   + "<table class='gridtable'>"
                   + "    <tr style = 'page-break-inside: avoid;' >"
                   + "        <th class='active' style='width: 240px;'>行业优势：</th>"
                   + "        <td> " + dr["Market_YouShi"].ToString() + "</td>"
                   + "    </tr>"
                   + "    <tr style = 'page-break-inside: avoid;' >"
                   + "        <th class='active' style='width: 240px;'>细分市场规模：</th>"
                   + "        <td> " + dr["Market_Scale"].ToString() + "</td>"
                   + "    </tr>"
                   + "    <tr style = 'page-break-inside: avoid;' >"
                   + "        <th class='active' style='width: 240px;'>本项目所占细分市场份额：</th>"
                   + "        <td> " + dr["Market_Shared"].ToString() + "</td>"
                   + "    </tr>"
                   + "    <tr style = 'page-break-inside: avoid;' >"
                   + "        <th class='active' style='width: 240px;'>未来市场规模：</th>"
                   + "        <td> " + dr["Market_Scale_Future"].ToString() + " </td>"
                   + "    </tr>"
                   + "    <tr style = 'page-break-inside: avoid;' >"
                   + "        <th class='active' style='width: 240px;'>本项目可能占有的市场份额：</th>"
                   + "        <td> " + dr["Market_Shared_Future"].ToString() + " </td>"
                   + "    </tr>"
                   + "    <tr style = 'page-break-inside: avoid;' >"
                   + "        <th class='active' style='width: 240px;'>依附其他行业情况：</th>"
                   + "        <td> " + dr["Market_AreaAttach"].ToString() + " </td>"
                   + "    </tr>"
                   + "    <tr style = 'page-break-inside: avoid;' >"
                   + "        <th class='active' style='width: 240px;'>相关产业政策：</th>"
                   + "        <td> " + dr["Market_ZhengCe"].ToString() + " </td>"
                   + "    </tr>"
                   + "</table>";
                str += "资金需求：<hr>"
                 + "<table class='gridtable'>"
                 + "    <tr style = 'page-break-inside: avoid;' >"
                 + "        <th class='active' style='width: 200px;'>资金需求规模：</th>"
                 + "        <td> " + dr["RongZi_Scale"].ToString() + "</td>"
                 + "    </tr>"
                 + "    <tr style = 'page-break-inside: avoid;' >"
                 + "        <th class='active' style='width: 200px;'>资金用途：</th>"
                 + "        <td> " + dr["RongZi_Yongtu"].ToString() + "</td>"
                 + "    </tr>"
                 + "    <tr style = 'page-break-inside: avoid;' >"
                 + "        <th class='active' style='width: 200px;'>融资规划：</th>"
                 + "        <td> " + dr["Rongzi_GuiHua"].ToString() + "</td>"
                 + "    </tr>"
                 + "    <tr style = 'page-break-inside: avoid;' >"
                 + "        <th class='active' style='width: 200px;'>回报预期/退出机制：</th>"
                 + "        <td> " + DBqiye._getSettingName(dr["Rongzi_TuiChu"].ToString()) + " </td>"
                 + "    </tr>"
                 + "    <tr style = 'page-break-inside: avoid;' >"
                 + "        <th class='active' style='width: 200px;'>预期收益情况：</th>"
                 + "        <td> " + dr["RongZi_ExpectedReturn"].ToString() + " </td>"
                 + "    </tr>"
                 + "</table>";

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