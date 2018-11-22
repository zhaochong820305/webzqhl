using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class admin_Resultlist : System.Web.UI.Page
{
    public string str = string.Empty;
    public string str1 = string.Empty;
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
            Label1.Text = "请选择交易成果，否则无法显示";
            return;
        }

        if (!Page.IsPostBack)
        {
            //myGrid.Attributes.Add("style", "word-break:keep-all;word-wrap:false");

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
                str += dt.Rows[0]["Name"].ToString()+",";
            }
        }
       
        return str;
    }

    private void BindGrid()
    {
        string stype = "";
        string ChiYouRenID;
        DataTable dt;
        string sql = "";
        dt = DBqiye.getDataTable(@"SELECT  p.*
                       FROM  [dbo].[Results] p  where p.id=" + cid + " ");
        try
        {
            if (dt.Rows.Count > 0)
            {
                

                DataRow dr = dt.Rows[0];
                if (dr["ChiYouRenType"].ToString() == "0")
                {
                    stype = "企业";
                   
                }
                else
                {
                    stype = "个人";
                }
            ChiYouRenID = dr["ChiYouRenID"].ToString();
            str = "<table class='gridtable' width=700px>"
            + "<tr style = 'page-break-inside: avoid;' >"
            + " "
            + "                 <th class='auto-style4' width='120px'>成果编号：</th>"
            + "                <td >"
            + "                    <div class='input-group'>"
            + "                    "+ dr["RNo"].ToString() + ""
            + "                    </div>"
            + "                </td>"
            + "                <th class='auto-style4'>成果名称：</th>"
            + "                <td >"
            + "                   " + dr["RName"].ToString() + " "
            + "                </td>"
            + "            </tr>"
            + "            <tr style = 'page-break-inside: avoid;' >"
            + ""
            + ""
            + "                 <th class='auto-style3'>应用场景：</th>"
            + "                <td colspan = '3' >"
            + "                  " + dr["JianJie"].ToString() + " "
            + "                    "
            + "                </td>"
            + "            </tr>"
            + "            <tr style = 'page-break-inside: avoid;' >"
            + "                <th class='auto-style4'>成果介绍：</th>"
            + "                <td colspan = '3' >"
            + "                   " + dr["JieShao"].ToString() + " "
            + "                </td>"
            
            + "            <tr style = 'page-break-inside: avoid;' >"
            + "                <th class='auto-style3'>成果阶段：</th>"
            + "                <td class='auto-style6' colspan='3'>"
            + "            "
            + "                   " + settingname(dr["JieDuan"].ToString()) + "  "
            + "                </td>"
            + "            </tr>"
            + "            <tr style = 'page-break-inside: avoid;' >"
            + "                <th class='auto-style4'  >成果所属单位性质：</th>"
            + "                <td class='auto-style2'>"
            + "                   " + settingname(dr["DanWeiXingZhi"].ToString()) + " "
            + "                </td>"
            + "                <th class='auto-style3' >成果所在地：</th>"
            + "                <td class='auto-style1'>"
            + "                  " + settingname(dr["DiZhi"].ToString()) + "   "
            + "                </td>"
            + "            </tr>"
             + "            <tr style = 'page-break-inside: avoid;' >"
            + "                <th class='auto-style4'>应用行业：</th>"
            + "                <td colspan = '3' >"
            + "                " + settingnamearray(dr["hangye"].ToString()) + "    "
            + "                </td>"
            + "            <tr style = 'page-break-inside: avoid;' >"
            + "                <th class='auto-style4'>技术分类：</th>"
            + "                <td colspan = '3' >"
            + "                " + settingnamearray(dr["YingYongLingYu"].ToString()) + "    "
            + "                </td>"
            
            + "            <tr style = 'page-break-inside: avoid;' >"
            + "                <th class='auto-style3'>上马需配套资金：</th>"
            + "                <td colspan = '3' >"
            + "                " + dr["ZiJin"].ToString() + "万元  "
            + "                </td>"
            + "            </tr>"
           
            + "            <tr style = 'page-break-inside: avoid;' >"
            + "                <th class='auto-style4'>成果水平：</th>"
            + "                <td >"
            + "                 " + settingname(dr["ShuiPing"].ToString()) + " "
            + "                </td>"
            + "                <th class='auto-style4'>成果密级：</th>"
            + "                <td >"
            + "                    "
            + "                 " + settingname(dr["MiJi"].ToString()) + "   "
            + "                </td>"
            + "            </tr>"
            + "            <tr style = 'page-break-inside: avoid;' >"
            + "                <th class='auto-style4'>成果属性：</th>"
            + "                <td >"
            + "                  " + settingname( dr["ShuXing"].ToString()) + " "
            + "                 "
            + "                </td>"
            + "                <th class='auto-style4'>成果创新形式：</th>"
            + "                <td >"
            + "                 " + settingname( dr["ChuangXinXingShi"].ToString() )+ "   "
            + "                </td>"
            + "            </tr>"
            + "            <tr style = 'page-break-inside: avoid;' >"
            + "                <th class='auto-style4'>应用情况：</th>"
            + "                <td >"
            + "                     "
            + "                  " + settingname( dr["YingYongQingKuang"].ToString() )+ "  "
            + "                </td>"
            + "                <th class='auto-style4'>未应用原因：</th>"
            + "                <td >"
            + "                  " + settingname( dr["NoYingYYin"].ToString() )+ " "
            + "                </td>"
            + "            </tr>"           
            + "            <tr style = 'page-break-inside: avoid;' >"
            + "                <th class='auto-style4'>成果交易状态：</th>"
            + "                <td colspan = '3' >"
           
            + "                 " + settingname( dr["JiaoYiState"].ToString()) + "  "
            + "                </td>"
            + "            </tr>"
            + "            <tr style = 'page-break-inside: avoid;' >"
            + "                <th class='auto-style4'>持有人类型：</th>"
            + "                <td   colspan = '3'>"

            + "                 " + stype + "  "
            + "                </td>"
            
            + "            </tr>"

            + "        </table>";


                if (stype == "个人")
                {
                    dt = DBqiye.getDataTable(@"SELECT TOP 1 * FROM [dbo].[ResultRen] where id = '" + ChiYouRenID + "'");
                    if (dt.Rows.Count > 0)
                    {
                        DataRow dr4 = dt.Rows[0];
                        str1 = " <table class='gridtable' width=700px>"
                        + "                        <tr style = 'page-break-inside: avoid;' >"
                        + "                            <th class='active' style='width: 150px;' colspan='4'> 成果持有人数据：<br />"
                        + "                        <tr style = 'page-break-inside: avoid;' >"
                        + "                            <th class='active' style='width: 150px;'>成果持有人：</th>"
                        + "                            <td colspan = '3' >"
                        + "                              " + dr4["CName"].ToString() + " "
                        + "                                </td>"
                        + "                        </tr>"
                        + "                        <tr style = 'page-break-inside: avoid;' >"
                        + "                            <th class='active' style='width: 150px;'>联系人：</th>"
                        + "                            <td class='auto-style2'>"
                        + "                             " + dr4["CLianXi"].ToString() + "  "
                        + "                                </td>"
                        + "                            <th class='active' style='width: 150px;'>电话：</th>"
                        + "                            <td class='auto-style1'>"
                        + "                               " + dr4["tel"].ToString() + " "
                        + "                                </td>"
                        + "                        </tr>"
                        + "                        <tr style = 'page-break-inside: avoid;' >"
                        + "                            <th class='active' style='width: 120px;'>职称：</th>"
                        + "                            <td class='auto-style2'>"
                        + "                              " + dr4["Title"].ToString() + " "
                        + "                                </td>"
                        + "                            <th class='active' style='width: 120px;'>邮箱：</th>"
                        + "                            <td class='auto-style1'>"
                        + "                              " + dr4["email"].ToString() + ""
                        + "                                </td>"
                        + "                        </tr>"
                        + "                        <tr style = 'page-break-inside: avoid;' >"

                        + "                            <th class='active' style='width: 120px;'>地区：</th>"
                        + "                            <td class='auto-style1'  colspan = '3' >"
                        + "                             " + settingname(dr4["diqu"].ToString()) + " "
                        + "                                </td>"
                        + "                        </tr>"
                        + "                        <tr style = 'page-break-inside: avoid;' >"
                        + "                            <th class='active' >通讯地址：</th>"
                        + "                            <td colspan = '3' >"
                        + "                              " + dr4["addr"].ToString() + " "
                        + "                                </td>"
                        + "                        </tr>"
                        + "                        <tr style = 'page-break-inside: avoid;' >"
                        + "                            <th class='active'>简介：</th>"
                        + "                            <td colspan = '3' >"
                        + "                            " + dr4["jianjie"].ToString() + "   "
                        + "                                </td>"
                        + "                        </tr>"
                        + "                       "
                        + "                    </table>";

                    }
                }
                else
                {
                    
                    dt = DBqiye.getDataTable(@"select *,(select Name from  [dbo].[Setting] where [ID]=b.Region) as City
                                    ,(select Name from  [dbo].[Setting] where [ID]=b.EnterpriseType) as EnterType
                                     ,(select Name from  [dbo].[Setting] where [ID]=b.KeyAreas) as KeyArea
                                    from [Company] b where b.id=" + ChiYouRenID + " order by b.id desc   ");

                    try
                    {
                        if (dt.Rows.Count > 0)
                        {
                            string sShangShi = "否";
                              dr = dt.Rows[0];
                            if (dr["HasQuoted"].ToString() == "1")
                            { sShangShi = "是"; }

                            string sgupiao = "否";
                            if (dr["Incentive_HasStock"].ToString() == "1")
                            { sgupiao = "是"; }

                            str1= " <table  class='gridtable'>"
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
        }catch(Exception ex )
            {
            str += ex.ToString();
        }
      

       
    }
    }