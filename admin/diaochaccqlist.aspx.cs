using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class admin_diaochaccqlist : System.Web.UI.Page
{
    string id = "";
    public string str1 = string.Empty;
    public string str2 = string.Empty;
    public string str3 = string.Empty;
    public string str4 = string.Empty;
    public string str5 = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        id = Request.QueryString["id"].ToString();
        //Response.Write(id);
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
    private String settingname(string itype)
    {
        string str = "";
        DataTable dt = DBqiye.getDataTable("SELECT  [ID],[Name]  FROM [dbo].[Setting] where id=" + itype + "");
        if (dt.Rows.Count > 0)
        {
            str = dt.Rows[0]["Name"].ToString();
        }
        return str;
    }

    private String settingnamearray(string stra)
    {
        string[] strarray = stra.Split(',');
        string str = "";
        DataTable dt;
        for (int i = 0; i < strarray.Length; i++)
        {
            dt = DBqiye.getDataTable("SELECT  [ID],[Name]  FROM [dbo].[Setting] where id=" + strarray[i] + "");
            if (dt.Rows.Count > 0)
            {
                str += dt.Rows[0]["Name"].ToString() + ",";
            }
        }

        return str;
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
        dt = DBqiye.getDataTable(@"SELECT *  FROM  [company] where (id=" + sid + ")  ");
        string sql5 = string.Empty;



        try
        {
            if (dt.Rows.Count > 0)
            {
                //string sShangShi = "否";
                DataRow dr = dt.Rows[0];

                DataTable dt1;
                dt1 = DBqiye.getDataTable(@"SELECT *  FROM   [C_CunChuQi] where ([companyid]=" + sid + ")  ");
                DataRow dr1 = dt1.Rows[0];
                //if (dr["HasQuoted"].ToString() == "1")
                //{ sShangShi = "是"; }

                //string sgupiao = "否";
                //if (dr["Incentive_HasStock"].ToString() == "1")
                //{ sgupiao = "是"; }
                
                str2 += @"<table>
                             <tr>
                                 <td colspan='1' class='tbcss1'>单位名称：</td>
                                 <td colspan = '1' class='tbcss2'>
                                    " + dr["name"].ToString()+ @"
                                 </td>
                                 <td colspan = '1' class='tbcss1'>注册地：</td>
                                 <td colspan = '1' class='tbcss2'>
                                     " + dr["Address"].ToString() + @"
                                 </td>
                             </tr>
                             <tr>
                                 <td class='tbcss1'>项目名称：</td>
                                 <td class='tbcss4' >
                                     " + dr1["xiangmuming"].ToString() + @"
                                 </td>
                                 <td class='tbcss5'>机构代码：</td>
                                 <td class='tbcss6'>                         
                                    " + dr1["jigoudaima"].ToString() + @"
                                 </td>
                             </tr>
                             <tr>
                                 <td colspan = '1' class='tbcss1'>项目实施期：</td>
                                 <td colspan = '3' class='tbcss2'>
                                     " + dr1["shishiqi"].ToString() + @"
                                 </td>
                              </tr>
                             <tr>
                                 <td colspan = '1' class='tbcss1'>所属产业链：</td>
                                 <td colspan = '3' class='tbcsscyl'>         
                                     " + dr1["chanyelian"].ToString() + @"
                                 </td>
                              </tr>
                             <tr>
                                 <td colspan = '1' class='tbcss1'>所属产业链<br> 关键环节：</td>
                                 <td colspan = '3' class='tbcsscyl'>
                                     " + dr1["cylhuanjie"].ToString() + @"
                                 </td>
                              </tr>
                             <tr>
                                 <td colspan = '1' class='tbcss1'>所属产品：</td>
                                  <td colspan = '3' class='tbcsscyl'>
                                     " + dr1["chanpin"].ToString() + @"
                                 </td>
                              </tr>
                              <tr>
                                 <td class='tbcss1'>主要负责人：</td>
                                 <td class='tbcss12'>
                                    " + dr["Contact"].ToString() + @"
                                 </td>
                                 <td class='tbcss13'>手机：</td>
                                 <td class='tbcss14' >
                                     " + dr["ContactTel"].ToString() + @"
                                 </td>
                             </tr>
                 
                             <tr>
                                 <td class='tbcss1'> 座机： </td>
                                 <td class='tbcss12'>" + dr["tel"].ToString() + @"
                         
                          

                                 </td>
                                 <td class='tbcss13'>    传真：</td>
                                 <td class='tbcss14'  >
                                      " + dr["zipcode"].ToString() + @"
                                 </td>
                             </tr>
                              <tr>
                                 <td class='tbcss1'>电子邮箱：</td>
                                 <td class='tbcss12' colspan='3'>
                                     " + dr["email"].ToString() + @"
                                 </td>
                    
                             </tr>
                             <tr>
                                 <td class='tbcssbt' colspan='4' style='background-color:#f5f5f5; height:70px;padding-left:30px;'> 近三年经营业绩： </td>
                    
                             </tr>
                         </table>";


                DataTable dt5;
                sql5 = @"SELECT * FROM [CaiWu] where([CompanyID] = " + sid + " and [Year] = 2015)   ";
                //Response.Write(sql5);
                dt5 = DBqiye.getDataTable(sql5);
                DataRow dr5 = dt5.Rows[0];

                DataTable dt6;
                dt6 = DBqiye.getDataTable(@"SELECT *  FROM   [CaiWu] where ([CompanyID]=" + sid + ") and [Year]=2016  ");
                DataRow dr6 = dt6.Rows[0];
                DataTable dt7;
                dt7 = DBqiye.getDataTable(@"SELECT *  FROM   [CaiWu] where ([CompanyID]=" + sid + ") and [Year]=2017  ");
                DataRow dr7 = dt7.Rows[0];
                str2 += @"<table class='kongxi'>
                             <tr >
                                 <td class='igbt8_2' colspan='2'>企业情况</td>
                                 <td class='igbt8_2'>2015</td>
                                 <td class='igbt8_2'>2016</td>
                                 <td class='igbt8_2'>2017</td>                   
                             </tr>
                             <tr>
                                 <td class='igbt8_3' rowspan='3'>技术</td>
                                 <td class='igbt8_4'>研发投入占营收比例</td>
                                 <td class='igbt8_2'> " + dr5["RDInvestmentRatio"].ToString() + @"</td>
                                 <td class='igbt8_2'> " + dr6["RDInvestmentRatio"].ToString() + @"</td>
                                 <td class='igbt8_2'> " + dr7["RDInvestmentRatio"].ToString() + @"</td>
                             </tr>
                             <tr>                      
                                 <td class='igbt8_4'>当前申请专利数</td>
                                 <td class='igbt8_2'> " + dr5["zhuanlishu"].ToString() + @"</td>
                                 <td class='igbt8_2'> " + dr6["zhuanlishu"].ToString() + @"</td>
                                 <td class='igbt8_2'> " + dr7["zhuanlishu"].ToString() + @"</td>
                             </tr>
                             <tr>                      
                                 <td class='igbt8_4'>截至年底累计授权专利数</td>
                                 <td class='igbt8_2'>" + dr5["shouquanzls"].ToString() + @"</td>
                                 <td class='igbt8_2'>" + dr6["shouquanzls"].ToString() + @"</td>
                                 <td class='igbt8_2'>" + dr7["shouquanzls"].ToString() + @"</td>
                             </tr>
                             <tr>
                                 <td class='igbt8_3' rowspan='2'>市场</td>
                                 <td class='igbt8_4'>细分领域市场份额</td>
                                 <td class='igbt8_2'>" + dr5["shichangfeie"].ToString() + @"</td>
                                 <td class='igbt8_2'>" + dr6["shichangfeie"].ToString() + @"</td>
                                 <td class='igbt8_2'>" + dr7["shichangfeie"].ToString() + @"</td>
                             </tr>
                             <tr>                     
                                 <td class='igbt8_4'>市场排名</td>
                                 <td class='igbt8_2'>" + dr5["shichangpaiming"].ToString() + @"</td>
                                 <td class='igbt8_2'>" + dr6["shichangpaiming"].ToString() + @"</td>
                                 <td class='igbt8_2'>" + dr7["shichangpaiming"].ToString() + @"</td>
                             </tr>
                             <tr>
                                 <td class='igbt8_3' rowspan='4'>财务</td>
                                 <td class='igbt8_4'>总资产</td>
                                 <td class='igbt8_2'>" + dr5["TotalAsset"].ToString() + @"</td>
                                 <td class='igbt8_2'>" + dr6["TotalAsset"].ToString() + @"</td>
                                 <td class='igbt8_2'>" + dr7["TotalAsset"].ToString() + @"</td>
                             </tr>
                             <tr>                     
                                 <td class='igbt8_4'>资产负债率</td>
                                 <td class='igbt8_2'>" + dr5["DebtRatio"].ToString() + @"</td>
                                 <td class='igbt8_2'>" + dr6["DebtRatio"].ToString() + @"</td>
                                 <td class='igbt8_2'>" + dr7["DebtRatio"].ToString() + @"</td>
                             </tr>
                             <tr>                     
                                 <td class='igbt8_4'>年度营业收入</td>
                                 <td class='igbt8_2'>" + dr5["Income"].ToString() + @"</td>
                                 <td class='igbt8_2'>" + dr6["Income"].ToString() + @"</td>
                                 <td class='igbt8_2'>" + dr7["Income"].ToString() + @"</td>
                             </tr>
                             <tr>                     
                                 <td class='igbt8_4'>年度净利润</td>
                                 <td class='igbt8_2'>" + dr5["Profit"].ToString() + @"</td>
                                 <td class='igbt8_2'>" + dr6["Profit"].ToString() + @"</td>
                                 <td class='igbt8_2'>" + dr7["Profit"].ToString() + @"</td>
                             </tr>
                 
                         </table>";
                string filename = string.Empty;
                if (dr1["filename"].ToString().Length > 0)
                {
                    filename = dr1["filename"].ToString();
                }
                else
                {
                    filename = "<font color=red>未上传附件</font>";
                }
                str2 += @"<table class='kongxifj'>
                                      <tr >
 
                                          <td  class='tbcssbtfj' colspan='2'  > 附件上传： </td>
                    
                                     </tr>
                                     <tr>
                                         <td class='fujian1'>附件：</td>
                                         <td class='fujian2'>
                                           <a href='" + filename + @"'  target='_blank'>  附件下载</a>
                                         </td>
                                     </tr>
                 
                                 </table>";

            } 
            




        }
        catch
        {
            //myGrid. = 0;
            //Response.Write(sql5);
        }
        finally
        {

        }



    }
}