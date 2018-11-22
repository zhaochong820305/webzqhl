using System;
using System.Collections.Generic;
 
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class admin_jscglist : System.Web.UI.Page
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
        dt = DBqiye.getDataTable(@"SELECT  p.*,c.Name as CName,(select top 1  s.Name from Setting s where s.id = p.TechLevel ) as TechLevelname,
                       (select top 1  s.Name from Setting s where s.id = p.HangYe ) as HangYeName,
                       (select top 1  s.Name from Setting s where s.id = p.ResultsType ) as ResultsTypeName
                       FROM  [dbo].[Technology] p left join Company c on c.ID=p.CompanyID where p.id=" + cid + " order by p.id desc");
        try
        {
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                str = "<table class='gridtable'>"
                    + "    <tr style = 'page-break-inside: avoid;' >"
                    + "        <th class='active' style='width: 160px;'>项目名称：</th>"
                    + "        <td> " + dr["TechName"].ToString() + "</td>"
                    + "    </tr>"
                    + "    <tr style = 'page-break-inside: avoid;' >"
                    + "        <th class='active' style='width: 160px;'>企业名称：</th>"
                    + "        <td> " + dr["CName"].ToString() + "</td>"
                    + "    </tr>"
                    + "    <tr style = 'page-break-inside: avoid;' >"
                    + "        <th class='active' style='width: 160px;'>技术水平：</th>"
                    + "        <td> " + dr["TechLevelname"].ToString() + "</td>"
                    + "    </tr>"
                    + "    <tr style = 'page-break-inside: avoid;' >"
                    + "        <th class='active' style='width: 160px;'>所属行业：</th>"
                    + "        <td> " + dr["HangYeName"].ToString() + " </td>"
                    + "    </tr>"
                    + "    <tr style = 'page-break-inside: avoid;' >"
                    + "        <th class='active' style='width: 160px;'>成果类型：</th>"
                    + "        <td> " + dr["ResultsTypeName"].ToString() + " </td>"
                    + "    </tr>"
                    + "    <tr style = 'page-break-inside: avoid;' >"
                    + "        <th class='active' style='width: 160px;'>所处阶段：</th>"
                    + "        <td> " + dr["InPhase"].ToString() + " </td>"
                    + "    </tr>"
                    + "    <tr style = 'page-break-inside: avoid;' >"
                    + "        <th class='active' style='width: 160px;'>技术成果来源：</th>"
                    + "        <td> " + dr["Source"].ToString() + "</td>"
                    + "    </tr>"
                    + "    <tr style = 'page-break-inside: avoid;' >"
                    + "        <th class='active' style='width: 160px;'>关键词：</th>"
                    + "        <td> " + dr["KeyWord"].ToString() + " </td>"
                    + "    </tr>"
                    + "    <tr style = 'page-break-inside: avoid;' >"
                    + "        <th class='active' style='width: 160px;'>合作方式：</th>"
                    + "        <td> " + dr["Cooperation"].ToString() + "</td>"
                    + "    </tr>"
                    + "    <tr style = 'page-break-inside: avoid;' >"
                    + "        <th class='active' style='width: 160px;'>总资产：</th>"
                    + "        <td> " + dr["InvestmenTotal"].ToString() + "万元</td>"
                    + "    </tr>"
                    + "    <tr style = 'page-break-inside: avoid;' >"
                    + "        <th class='active' style='width: 160px;'>设备投资：</th>"
                    + "        <td> " + dr["Equipment"].ToString() + "万元</td>"
                    + "    </tr>"
                    + "    <tr style = 'page-break-inside: avoid;' >"
                    + "        <th class='active' style='width: 160px;'>新增利润：</th>"
                    + "        <td> " + dr["Profits"].ToString() + "万元</td>"
                    + "    </tr>"
                    + "    <tr style = 'page-break-inside: avoid;' >"
                    + "        <th class='active' style='width: 160px;'>节省成本：</th>"
                    + "        <td> " + dr["CostSavings"].ToString() + "万元</td>"
                    + "    </tr>"
                    + "    <tr style = 'page-break-inside: avoid;' >"
                    + "        <th class='active' style='width: 160px;'>技术先进性说明：</th>"
                    + "        <td> " + dr["TechAdvancement"].ToString() + "</td>"
                    + "    </tr>"
                    + "    <tr style = 'page-break-inside: avoid;' >"
                    + "        <th class='active' style='width: 160px;'>主要技术参数：</th>"
                    + "        <td> " + dr["TechnicalParameters"].ToString() + "</td>"
                    + "    </tr>"
                    + "</table>";

                //str += "项目资质：<hr>"
                //    + "<table class='gridtable'>"
                //    + "    <tr style = 'page-break-inside: avoid;' >"
                //    + "        <th class='active' style='width: 160px;'>项目资质：</th>"
                //    + "        <td> " + dr["ZiZhi"].ToString() + "</td>"
                //    + "    </tr>"
                //     + "</table>";
                //str += "技术优势：<hr>"
                //    + "<table class='gridtable'>"
                //    + "    <tr style = 'page-break-inside: avoid;' >"
                //    + "        <th class='active' style='width: 160px;'>技术地位：</th>"
                //    + "        <td> " + DBqiye._getSettingName(dr["Tech_DiWei"].ToString()) + "</td>"
                //    + "    </tr>"
                //    + "    <tr style = 'page-break-inside: avoid;' >"
                //    + "        <th class='active' style='width: 160px;'>查新情况：</th>"
                //    + "        <td> " + dr["Tech_Chaxin"].ToString() + "</td>"
                //    + "    </tr>"
                //    + "    <tr style = 'page-break-inside: avoid;' >"
                //    + "        <th class='active' style='width: 160px;'>技术壁垒：</th>"
                //    + "        <td> " + DBqiye._getSettingName(dr["Tech_BiLei"].ToString()) + "</td>"
                //    + "    </tr>"
                //    + "    <tr style = 'page-break-inside: avoid;' >"
                //    + "        <th class='active' style='width: 160px;'>专利著作情况：</th>"
                //    + "        <td> " + dr["Tech_ZhuanLiZhuzuo"].ToString() + " </td>"
                //    + "    </tr>"
                //    + "    <tr style = 'page-break-inside: avoid;' >"
                //    + "        <th class='active' style='width: 160px;'>研发力量：</th>"
                //    + "        <td> " + dr["Tech_RDInfo"].ToString() + " </td>"
                //    + "    </tr>"
                //    + "    <tr style = 'page-break-inside: avoid;' >"
                //    + "        <th class='active' style='width: 160px;'>未来研发方向：</th>"
                //    + "        <td> " + dr["Tech_RDTarger"].ToString() + " </td>"
                //    + "    </tr>"
                //    + "</table>";
                //str += "市场情况：<hr>"
                //   + "<table class='gridtable'>"
                //   + "    <tr style = 'page-break-inside: avoid;' >"
                //   + "        <th class='active' style='width: 240px;'>行业优势：</th>"
                //   + "        <td> " + dr["Market_YouShi"].ToString() + "</td>"
                //   + "    </tr>"
                //   + "    <tr style = 'page-break-inside: avoid;' >"
                //   + "        <th class='active' style='width: 240px;'>细分市场规模：</th>"
                //   + "        <td> " + dr["Market_Scale"].ToString() + "</td>"
                //   + "    </tr>"
                //   + "    <tr style = 'page-break-inside: avoid;' >"
                //   + "        <th class='active' style='width: 240px;'>本项目所占细分市场份额：</th>"
                //   + "        <td> " + dr["Market_Shared"].ToString() + "</td>"
                //   + "    </tr>"
                //   + "    <tr style = 'page-break-inside: avoid;' >"
                //   + "        <th class='active' style='width: 240px;'>未来市场规模：</th>"
                //   + "        <td> " + dr["Market_Scale_Future"].ToString() + " </td>"
                //   + "    </tr>"
                //   + "    <tr style = 'page-break-inside: avoid;' >"
                //   + "        <th class='active' style='width: 240px;'>本项目可能占有的市场份额：</th>"
                //   + "        <td> " + dr["Market_Shared_Future"].ToString() + " </td>"
                //   + "    </tr>"
                //   + "    <tr style = 'page-break-inside: avoid;' >"
                //   + "        <th class='active' style='width: 240px;'>依附其他行业情况：</th>"
                //   + "        <td> " + dr["Market_AreaAttach"].ToString() + " </td>"
                //   + "    </tr>"
                //   + "    <tr style = 'page-break-inside: avoid;' >"
                //   + "        <th class='active' style='width: 240px;'>相关产业政策：</th>"
                //   + "        <td> " + dr["Market_ZhengCe"].ToString() + " </td>"
                //   + "    </tr>"
                //   + "</table>";
                //str += "资金需求：<hr>"
                // + "<table class='gridtable'>"
                // + "    <tr style = 'page-break-inside: avoid;' >"
                // + "        <th class='active' style='width: 200px;'>资金需求规模：</th>"
                // + "        <td> " + dr["RongZi_Scale"].ToString() + "</td>"
                // + "    </tr>"
                // + "    <tr style = 'page-break-inside: avoid;' >"
                // + "        <th class='active' style='width: 200px;'>资金用途：</th>"
                // + "        <td> " + dr["RongZi_Yongtu"].ToString() + "</td>"
                // + "    </tr>"
                // + "    <tr style = 'page-break-inside: avoid;' >"
                // + "        <th class='active' style='width: 200px;'>融资规划：</th>"
                // + "        <td> " + dr["Rongzi_GuiHua"].ToString() + "</td>"
                // + "    </tr>"
                // + "    <tr style = 'page-break-inside: avoid;' >"
                // + "        <th class='active' style='width: 200px;'>回报预期/退出机制：</th>"
                // + "        <td> " + DBqiye._getSettingName(dr["Rongzi_TuiChu"].ToString()) + " </td>"
                // + "    </tr>"
                // + "    <tr style = 'page-break-inside: avoid;' >"
                // + "        <th class='active' style='width: 200px;'>预期收益情况：</th>"
                // + "        <td> " + dr["RongZi_ExpectedReturn"].ToString() + " </td>"
                // + "    </tr>"
                // + "</table>";

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