using System;
using System.Collections.Generic;
 
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class admin_qiyeview : System.Web.UI.Page
{
    public string str1 = string.Empty;
    public string str2 = string.Empty;
    public string str3 = string.Empty;
    public string str4 = string.Empty;
    public string str5 = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        //Response.Write("session:" + Session["sid"]);
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
        if (Request.QueryString["id"] != null && string.IsNullOrEmpty(Request.QueryString["id"]) && Request.QueryString["id"].Length > 0)
        {
            sid = Request.QueryString["id"].ToString();
        }
        else if (Session["sid"] != null && Session["sid"].ToString() != "" && Session["sid"].ToString().Length > 0)
        {
            sid = Session["sid"].ToString();
        }
        else
        {
            Response.Write("请选择企业，否则无法显示 &nbsp;<a href ='qygl.aspx'>返回企业管理</a>");
            Response.End();
        }
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
                if (dr["HasQuoted"].ToString() == "1")
                { sShangShi = "是"; }

                string sgupiao = "否";
                if (dr["Incentive_HasStock"].ToString() == "1")
                { sgupiao = "是"; }

                str1 = " <table>"
                     + "   <tr>"
                     + "      <th> 企业名称 </th>"
                     + "       <td colspan = '2'> " + dr["Name"].ToString() + " </td>"
                     + "        <th> 详细地址 </th>"
                     + "        <td colspan = '4'> " + dr["Address"].ToString() + " </td>"
                     + "     </tr>"
                     + "     <tr>"
                     + "         <th> 法人姓名 </th>"
                     + "         <td> " + dr["LegalPerson"].ToString() + " </td>"
                     + "         <th> 联系电话 </th>"
                     + "         <td> " + dr["LegalPersonTel"].ToString() + " </td>"
                     + "         <th> 联系人 </th>"
                     + "         <td> " + dr["Contact"].ToString() + "  </td>"
                     + "         <th> 联系电话 </th>"
                     + "         <td> " + dr["ContactTel"].ToString() + "  </td>"
                     + "     </tr>"
                     + "     <tr>"
                     + "        <th> 所属地区 </th>"
                     + "        <td> " + dr["City"].ToString() + " </td>"
                     + "         <th> 邮编 </th>"
                     + "         <td> " + dr["ZipCode"].ToString() + " </td>"
                     + "         <th> 行业领域 </th>"
                     + "         <td colspan = '3'> " + dr["KeyArea"].ToString() + ">>  </td>"
                     + "      </tr>"
                     + "      <tr>"
                     + "          <th> 企业性质 </th>"
                     + "          <td colspan = '3'> " + dr["EnterType"].ToString() + " </td>"
                     + "           <th> 是否上市 </th>"
                     + "           <td colspan = '3'> " + sShangShi + " </td>"
                     + "        </tr>"
                     + "        <tr>"
                     + "            <th> 经营范围 </th>"
                     + "            <td colspan = '7'>" + dr["BusinessScope"].ToString() + "  </td>"
                     + "         </tr>"
                     + "     </table>";

                str2 = "   <table>"
                + "            <tr>"
                + "                <th>上市方向</th>"
                + "                <td>" + dr["ShangShi_Target"].ToString() + " </td>"
                + "                <th>上市时间</th>"
                + "                <td>" + dr["ShangShi_Time"].ToString() + " </td>"
                + "            </tr>"
                + "            <tr>"
                + "                <th>上市准备情况</th>"
                + "                <td colspan='3'>" + dr["ShangShi_PrepareInfo"].ToString() + " </td>"
                + "            </tr>"
                + "            <tr>"
                + "                <th>是否有股权激励</th>"
                + "                <td colspan='3'>" + sgupiao + " </td>"
                + "            </tr>"
                + "            <tr>"
                + "                <th>激励措施</th>"
                + "                <td colspan='3'>" + dr["Incentive_StockInfo"].ToString() + " </td>"
                + "            </tr>"
                + "        </table>";

            }
        }
        catch
        {
            //myGrid. = 0;

        }
        finally
        {

        }
        dt = DBqiye.getDataTable(@"   SELECT TOP 1 * FROM [dbo].[Team] where CompanyID = '" + sid + "'");
        try
        {
            if (dt.Rows.Count > 0)
            {
                DataRow dr1 = dt.Rows[0];
                str3 = "<table style='margin-bottom: 3px;'>"
                      + "      <tr>"
                      + "          <th>姓名</th>"
                      + "          <td>" + dr1["Name"].ToString() + "</td>"
                      + "          <th>专业</th>"
                      + "          <td>" + dr1["ZhuanYe"].ToString() + "</td>"
                      + "      </tr>"
                      + "      <tr>"
                      + "          <th>学历</th>"
                      + "          <td>" + dr1["XueLi"].ToString() + "</td>"
                      + "          <th>职位</th>"
                      + "          <td>" + dr1["ZhiWei"].ToString() + "</td>"
                      + "      </tr>"
                      + "      <tr>"
                      + "          <th>上市公司任职情况</th>"
                      + "          <td colspan='3'>" + dr1["StockCompany"].ToString() + "</td>"
                      + "      </tr>"
                      + "      <tr>"
                      + "          <th>简历</th>"
                      + "          <td colspan='3'>" + dr1["Resume"].ToString() + "</td>"
                      + "      </tr>"
                      + "  </table>";
            }
            else
            {
                str3 = "<table style='margin-bottom: 3px;'>"
                  + "      <tr>"
                  + "          <th>姓名</th>"
                  + "          <td>&nbsp;</td>"
                  + "          <th>专业</th>"
                  + "          <td>&nbsp;</td>"
                  + "      </tr>"
                  + "      <tr>"
                  + "          <th>学历</th>"
                  + "          <td>&nbsp;</td>"
                  + "          <th>职位</th>"
                  + "          <td>&nbsp;</td>"
                  + "      </tr>"
                  + "      <tr>"
                  + "          <th>上市公司任职情况</th>"
                  + "          <td colspan='3'>&nbsp;</td>"
                  + "      </tr>"
                  + "      <tr>"
                  + "          <th>简历</th>"
                  + "          <td colspan='3'>&nbsp;</td>"
                  + "      </tr>"
                  + "  </table>";
            }
        }
        catch
        {
            //myGrid. = 0;

        }
        finally
        {

        }

        dt = DBqiye.getDataTable(@"SELECT TOP 1 * FROM [dbo].[CaiWu] where CompanyID = '" + sid + "'");
        try
        {
            if (dt.Rows.Count > 0)
            {
                DataRow dr4 = dt.Rows[0];
                str4 = " <table style='margin-bottom: 3px;'>"
                        + "<tr>"
                        + "    <th colspan='4' style='text-align:center;'>" + dr4["Year"].ToString() + " 年度</th>"
                        + "</tr>"
                        + "<tr>"
                        + "    <th>企业总资产</th>"
                        + "    <td>" + dr4["TotalAsset"].ToString() + " 万元</td>"
                        + "    <th>资产负债率</th>"
                        + "    <td>" + dr4["DebtRatio"].ToString() + " %</td>"
                        + "</tr>"
                        + "<tr>"
                        + "    <th>研发投入比</th>"
                        + "    <td>" + dr4["RDInvestmentRatio"].ToString() + " %</td>"
                        + "    <th>主营业务收入</th>"
                        + "    <td>" + dr4["Income"].ToString() + " 万元</td>"
                        + "</tr>"
                        + "<tr>"
                        + "    <th>利润（万元）</th>"
                        + "    <td>" + dr4["Profit"].ToString() + "</td>"
                        + "    <th>纳税（万元）</th>"
                        + "    <td>" + dr4["Tax"].ToString() + "</td>"
                        + "</tr>"
                        + "</table>";
            }
            else
            {
                str4 = " <table style='margin-bottom: 3px;'>"
                    + "<tr>"
                    + "    <th colspan='4' style='text-align:center;'> 年度</th>"
                    + "</tr>"
                    + "<tr>"
                    + "    <th>企业总资产</th>"
                    + "    <td>  万元</td>"
                    + "    <th>资产负债率</th>"
                    + "    <td>  %</td>"
                    + "</tr>"
                    + "<tr>"
                    + "    <th>研发投入比</th>"
                    + "    <td>  %</td>"
                    + "    <th>主营业务收入</th>"
                    + "    <td>  万元</td>"
                    + "</tr>"
                    + "<tr>"
                    + "    <th>利润（万元）</th>"
                    + "    <td> </td>"
                    + "    <th>纳税（万元）</th>"
                    + "    <td> </td>"
                    + "</tr>"
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
        dt = DBqiye.getDataTable(@"SELECT TOP 1 * FROM [dbo].[Project] where CompanyID = '" + sid + "'");
        int iprojectid = 0;
        try
        {
            if (dt.Rows.Count > 0)
            {

                DataRow dr5 = dt.Rows[0];

                str5 = "<table style='margin-bottom: 3px;'>"
                        + "<tr><th colspan='4' style='text-align:center;'>项目基本信息</th></tr>"
                        + " <tr>"
                        + "     <th>项目名称</th>"
                        + "     <td>" + dr5["Name"].ToString() + "</td>"
                        + "     <th>军工情况</th>"
                        + "     <td>" + DBqiye._getSettingName(dr5["Military"].ToString()) + " </td>"
                        + " </tr>"
                        + " <tr>"
                        + "     <th>项目目标</th>"
                        + "     <td colspan='3'>" + dr5["Goal"].ToString() + "</td>"
                        + " </tr>"
                        + " <tr>"
                        + "     <th>项目规模</th>"
                        + "     <td colspan='3'>" + dr5["Scale"].ToString() + " 万元</td>"
                        + " </tr>"
                        + " <tr>"
                        + "     <th>固定资产投资</th>"
                        + "     <td>" + dr5["FixedInverstment"].ToString() + " 万元</td>"
                        + "     <th>非固定资产投资</th>"
                        + "     <td>" + dr5["NonFixedInverstment"].ToString() + " 万元</td>"
                        + " </tr>"
                        + " <tr>"
                        + "     <th>开始时间</th>"
                        + "     <td>" + dr5["StartDate"].ToString() + "</td>"
                        + "     <th>结束时间</th>"
                        + "     <td>" + dr5["EndDate"].ToString() + "</td>"
                        + " </tr>"
                        + " <tr>"
                        + "     <th>项目进度</th>"
                        + "     <td>" + dr5["Process"].ToString() + " %</td>"
                        + "     <th>项目性质</th>"
                        + "     <td>" + DBqiye._getSettingName(dr5["Nature"].ToString()) + "</td>"
                        + " </tr>"
                        + " <tr>"
                        + "     <th>项目资质</th>"
                        + "     <td colspan='3'><span style='font-family:幼圆;'><span style='font-family:宋体;'>" + dr5["ZiZhi"].ToString() + "</span></span></td>"
                        + " </tr>"
                        + " <tr><th colspan='4' style='text-align:center;'>技术信息</th></tr>"
                        + " <tr>"
                        + "     <th>技术来源</th>"
                        + "     <td>" + DBqiye._getSettingName(dr5["Tech_LaiYuan"].ToString()) + "</td>"
                        + "     <th>技术地位</th>"
                        + "     <td>" + DBqiye._getSettingName(dr5["Tech_DiWei"].ToString()) + "</td>"
                        + " </tr>"
                        + " <tr>"
                        + "     <th>技术壁垒</th>"
                        + "     <td colspan='3'>" + DBqiye._getSettingName(dr5["Tech_BiLei"].ToString()) + "</td>"
                        + " </tr>"
                        + " <tr>"
                        + "     <th>查新情况</th>"
                        + "     <td colspan='3'>" + dr5["Tech_Chaxin"].ToString() + "</td>"
                        + " </tr>"
                        + " <tr>"
                        + "     <th>研发力量</th>"
                        + "     <td colspan='3'>" + dr5["Tech_RDInfo"].ToString() + "</td>"
                        + " </tr>"
                        + " <tr>"
                        + "     <th>未来研发方向</th>"
                        + "     <td colspan='3'>" + dr5["Tech_RDTarger"].ToString() + "</td>"
                        + " </tr>"
                        + " <tr>"
                        + "     <th>专利/著作权等</th>"
                        + "     <td colspan='3'>" + dr5["Tech_ZhuanLiZhuzuo"].ToString() + "</td>"
                        + " </tr>"
                        + " <tr><th colspan='4' style='text-align:center;'>市场信息</th></tr>"
                        + "	            <tr>"
                        + "     <th>细分市场规模</th>"
                        + "     <td>" + dr5["Market_Scale"].ToString() + " 万元</td>"
                        + "     <th>本项目所占市场份额</th>"
                        + "     <td>" + dr5["Market_Shared"].ToString() + " %</td>"
                        + " </tr>"
                        + "	            <tr>"
                        + "     <th>未来市场规模</th>"
                        + "     <td>" + dr5["Market_Scale_Future"].ToString() + " 万元</td>"
                        + "     <th>项目可能占有的市场份额</th>"
                        + "     <td>" + dr5["Market_Shared_Future"].ToString() + " %</td>"
                        + " </tr>"
                        + " <tr>"
                        + "     <th>依附其他行业情况</th>"
                        + "     <td colspan='3'>" + dr5["Market_AreaAttach"].ToString() + "</td>"
                        + " </tr>"
                        + " <tr>"
                        + "     <th>相关产业政策</th>"
                        + "     <td colspan='3'>" + dr5["Market_ZhengCe"].ToString() + "</td>"
                        + " </tr>"
                        + " <tr><th colspan='4' style='text-align:center;'>融资信息</th></tr>"
                        + " <tr>"
                        + "     <th>资金需求规模</th>"
                        + "     <td>" + dr5["RongZi_Scale"].ToString() + " 万元</td>"
                        + "     <th>资金用途</th>"
                        + "     <td>" + dr5["RongZi_Yongtu"].ToString() + " </td>"
                        + " </tr>"
                        + "  <tr>"
                        + "     <th>退出机制</th>"
                        + "     <td colspan='3'>" + DBqiye._getSettingName(dr5["Rongzi_TuiChu"].ToString()) + "</td>"
                        + " </tr>"
                        + "  <tr>"
                        + "     <th>融资规划</th>"
                        + "     <td colspan='3'>" + dr5["Rongzi_GuiHua"].ToString() + "</td>"
                        + " </tr>"
                        + "  <tr>"
                        + "     <th>预期收益情况</th>"
                        + "     <td colspan='3'>" + dr5["RongZi_ExpectedReturn"].ToString() + "</td>"
                        + " </tr>";
                iprojectid = Convert.ToInt32(dr5["ID"].ToString());
            }
            else
            {
                str5 = "";
            }
        }
        catch
        {
            //myGrid. = 0;

        }
        finally
        {

        }

        if (iprojectid > 0)
        {
            dt = DBqiye.getDataTable(@"SELECT TOP 1 [ID],[ProjectID],[Scale],[Description],[CreateDate]
                                  ,(select Name from  [dbo].[Setting] where [ID]=b.Type) as Type1           
                                  ,(select Name from  [dbo].[Setting] where [ID]=b.[MainDirection]) as [MainDirections]
	                              ,(select Name from  [dbo].[Setting] where [ID]=b.[EnterpriseType]) as [EnterpriseTypes] FROM [dbo].[Cooperation] b where ProjectID = '" + iprojectid.ToString() + "'");

            try
            {
                if (dt.Rows.Count > 0)
                {
                    DataRow dr6 = dt.Rows[0];
                    str5 += " <tr><th colspan='4' style='text-align:center;'>项目需求信息</th></tr>"
                        + " <tr>"
                        + "     <th>合作类别</th>"
                        + "     <td>" + dr6["Type1"].ToString() + "</td>"
                        + "     <th>合作方行业</th>"
                        + "     <td>" + dr6["MainDirections"].ToString() + "</td>"
                        + " </tr>"
                        + " <tr>"
                        + "     <th>合作方企业性质</th>"
                        + "     <td>" + dr6["EnterpriseTypes"].ToString() + "</td>"
                        + "     <th>合作方企业规模</th>"
                        + "     <td>" + dr6["Scale"].ToString() + " 万元 </td>"
                        + " </tr>"
                        + " <tr>"
                        + "     <th>内容描述</th>"
                        + "     <td colspan='3'>" + dr6["Description"].ToString() + "</td>"
                        + " </tr>"
                        + "</table> ";
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
}