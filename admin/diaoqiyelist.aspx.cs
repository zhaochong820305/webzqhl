using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class admin_diaoqiyelist : System.Web.UI.Page
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
        dt = DBqiye.getDataTable(@"SELECT *,(case isIGBT WHEN '1' THEN 'IGBT领域' ELSE '其他领域' END) igbt  FROM  [company] where (id=" + sid + ")  ");

        try
        {
            if (dt.Rows.Count > 0)
            {
                //string sShangShi = "否";
                DataRow dr = dt.Rows[0];
                //if (dr["HasQuoted"].ToString() == "1")
                //{ sShangShi = "是"; }

                //string sgupiao = "否";
                //if (dr["Incentive_HasStock"].ToString() == "1")
                //{ sgupiao = "是"; }


                DataTable dt1;
                dt1 = DBqiye.getDataTable(@"select  top 1 * from CompanyWenJuan where CompanyID=" + sid + " ");
                DataRow dr1 = dt1.Rows[0];

                str2 = @"  
                             <div class='con'>
                                 <p>一、<span>*</span>企业信息<span>  (必填)</span> </p>
                             </div>
                             <div class='xiangxi'>
                                 <table>
                                     <tr>
                                         <th>企业名称</th>
                                         <td colspan = '3' class='tbcss2'>";
                str2 += dr["name"].ToString();
                str2 += @" </td>
                                     </tr>
                                     <tr>
                                         <th>企业地址</th>
                                         <td colspan = '3' class='tbcss2'>";
                str2 += dr["Address"].ToString();
                str2 += @"</td>
                                     </tr>
                                     <tr>
                                         <th> 技术主管</th>
                                         <td colspan = '1' class='tbcss3'>";
                str2 += dr["Contact"].ToString();
                str2 += @"                                            
                                         </td>
                                         <th>联系电话</th>
                                         <td colspan = '1' class='tbcss3'>";
                str2 += dr["ContactTel"].ToString();
                str2 += @"
                                            
                                         </td>
                                     </tr>
                                     <tr>
                                         <th>主管邮箱</th>
                                         <td colspan = '3' class='tbcss2'>";
                str2 += dr["email"].ToString();
                str2 += @"
                                            
                                         </td>
                                     </tr>
                                     <tr>
                                         <th> 公司法人</th>
                                         <td colspan = '1' class='tbcss3'>";
                str2 += dr["LegalPerson"].ToString();
                str2 += @"                                            
                                         </td>
                                         <th>法人电话</th>
                                         <td colspan = '1' class='tbcss3'>";
                str2 += dr["LegalPersonTel"].ToString();
                str2 += @"
                                            
                                         </td>
                                     </tr>
                                     <tr>
                                         <th>企业性质</th>
                                         <td colspan = '3' class='tbcss2'>";
                str2 += dr["EnterpriseType"].ToString();
                str2 += @"
                                            
                                         </td>
                                     </tr>
                                     <tr>
                                         <th> 所在行业	</th>
                                         <td colspan = '1' class='tbcss3'>";
                str2 += dr["Hangye"].ToString();
                str2 += @"                                            
                                         </td>
                                         <th>人数</th>
                                         <td colspan = '1' class='tbcss3'>";
                str2 += dr1["renshu"].ToString();
                str2 += @"
                                            
                                         </td>
                                     </tr>
                                    <tr>
                                         <th> 注册资金		</th>
                                         <td colspan = '1' class='tbcss3'>";
                str2 += dr1["zhucezijin"].ToString();
                str2 += @"                                            
                                         </td>
                                         <th>年  产  值	</th>
                                         <td colspan = '1' class='tbcss3'>";
                str2 += dr1["nianchanzhi"].ToString();
                str2 += @"
                                            
                                         </td>
                                     </tr>
                                     <tr>
                                         <th> 是否上市			</th>
                                         <td colspan = '1' class='tbcss3'>";
                str2 += dr["HasQuoted"].ToString();
                str2 += @"                                            
                                         </td>
                                         <th>境内境外		</th>
                                         <td colspan = '1' class='tbcss3'>";
                str2 += dr1["isjingneiss"].ToString();
                str2 += @"
                                            
                                         </td>
                                     </tr>
                                    <tr>
                                         <th>上市板块	</th>
                                         <td colspan = '3' class='tbcss2'>";
                str2 += dr1["bankuai"].ToString();
                str2 += @"
                                            
                                         </td>
                                     </tr>
                                     <tr>
                                         <th>公司产品	</th>
                                         <td colspan = '3' class='tbcss2'>";
                str2 += dr1["chanpin"].ToString();
                str2 += @"
                                            
                                         </td>
                                     </tr>
                                     <tr>
                                         <th>主导产品		</th>
                                         <td colspan = '3' class='tbcss2'>";
                str2 += dr1["zhudaochanping"].ToString();
                str2 += @"
                                            
                                         </td>
                                     </tr>
                                     <tr>
                                         <th>核心技术		</th>
                                         <td colspan = '3' class='tbcss2'>";
                str2 += dr1["hexinjishu"].ToString();
                str2 += @"
                                            
                                         </td>
                                     </tr>
                                     <tr>
                                         <th>产品用途	</th>
                                         <td colspan = '3' class='tbcss2'>";
                str2 += dr1["chanpinyongtu"].ToString();
                str2 += @"
                                            
                                         </td>
                                     </tr>
                                       
                                 </table>
                             </div>
                             ";
              
                DataTable dt3;
                dt3 = DBqiye.getDataTable(@"select  top 3 * from C_ChenGuoPinJia where companyid=" + sid + " ");
                //DataRow dr3 = dt3.Rows[0];
                str2 += @"<br>
                <div class='con'>
             <p><span>*</span>三、科技成果评价和专利 <span>  (必填)</span> </p>
         </div>

          <div class='xiangxi'>

             <table style='width:695px;'>    
                  <tr>
                     <td colspan='5' class='tbtitle'>科技成果评价</td>                    
                  </tr >
                  <tr>
                     <td colspan='1' class='tbcss1'>成果名称</td>
                     <td colspan = '1' class='tbcss1'>评价单位</td>
                     <td colspan = '1' class='tbcss1'>成果水平（国际领先、国际先进、国内领先、国内先进）</td>
                     <td colspan = '1' class='tbcss1'>评价时间</td>
                     <td colspan = '1' class='tbcss1'>评价级别（国家级、省级）</td>
                 </tr>";
                int i = 1;
                foreach (DataRow dr3 in dt3.Rows)
                {
                    str2 += @"<tr>
                     <td colspan = '1' class='tbcss1'> " + dr3["chenguoming"].ToString() + @"  </td>
                     <td colspan = '1' class='tbcss1'>" + dr3["pinjiadanwen"].ToString() + @" 

                     </td>
                     <td colspan = '1' class='tbcss1'> " + dr3["chenguoshuiping"].ToString() + @"  </td>
                     <td colspan = '1' class='tbcss1'>" + dr3["pingjiashijian"].ToString() + @"  </td>
                     <td colspan = '1' class='tbcss1'>  " + dr3["pingjiajibei"].ToString() + @"  
                        
                     </td>
                 </tr>";

                    
                    i++;
                }



                str2 += @" </table>
         </div>
         ";
                //DataTable dt3;
                dt3 = DBqiye.getDataTable(@"select  top 3 * from C_ZhanLi where companyid=" + sid + " ");
                //DataRow dr3 = dt3.Rows[0];
                str2 += @"<br>
               

          <div class='xiangxi'>

             <table style='width:695px;'>    
                  <tr>
                     <td colspan='5' class='tbtitle'>专利情况</td>                    
                  </tr >
                  <tr>
                     <td colspan = '1' class='tbcss1'>专利名称</td>
                     <td colspan = '1' class='tbcss1'>专利类别（发明专利、实用性专利、国内专利、国外专利） </td>
                     <td colspan = '1' class='tbcss1'>是否授权（是，否）</td>
                    
                 </tr>";
                //int i = 1;
                foreach (DataRow dr3 in dt3.Rows)
                {
                    str2 += @"<tr>
                     <td colspan = '1' class='tbcss1'> " + dr3["zlname"].ToString() + @"  </td>
                     <td colspan = '1' class='tbcss1'>" + dr3["zlleibie"].ToString() + @" 

                     </td>
                     <td colspan = '1' class='tbcss1'> " + dr3["zlisshouquan"].ToString() + @"  </td>
                    
                 </tr>";


                    i++;
                }



                str2 += @" </table>
         </div>
         ";

                DataTable dt4;
                dt4 = DBqiye.getDataTable(@"select  top 1 * from C_QiTaXuQiu where companyid=" + sid + " ");
                DataRow dr4 = dt4.Rows[0];
                str2 += @"  <div class='con'>
                                 <p><span>*</span>三、企业需求 <span>  (必填)</span> </p>
                             </div>
                        ";


                str2 += @" 

          <br>
         <div class='xiangxi'>

             <table Width = '863px' >
 
                  <tr >
 
                      <td colspan = '2' class='tbtitle'>成果评价</td>                    
                 </tr>    
                 <tr>
                     <td style = 'width:400px;' class='tbcss1'>成果名称</td>
                     <td style = 'width:463px;' class='tbcss1'>评价目的</td>
                 </tr>
                 <tr>
                     <td colspan = '1' class='tbcss3'>&nbsp; " + dr4["chengguoname1"].ToString() + @" </td>
                     <td colspan = '1' class='tbcss3'>
                        " + dr4["pinjiamude1"].ToString() + @"
                     </td>
                 </tr>
                 <tr>
                     <td colspan = '1' class='tbcss3'>&nbsp; " + dr4["chengguoname2"].ToString() + @" </td>
                     <td colspan = '1' class='tbcss3'>
                        " + dr4["pinjiamude2"].ToString() + @"
                     </td>
                 </tr>
                 <tr>
                     <td colspan = '1' class='tbcss3'>&nbsp; " + dr4["chengguoname3"].ToString() + @" </td>
                     <td colspan = '1' class='tbcss3'>
                        " + dr4["pinjiamude3"].ToString() + @"
                     </td>
                 </tr>
             </table>
         </div>";
         str2 += @"
         <br>
         <div class='xiangxi'>

             <table Width = '863px' >
                 <tr >
                     <td colspan='2' class='tbtitle'>成果转化-成果引进需求</td>                    
                 </tr>    
                 <tr>
                     <td style = 'width:400px;' class='tbcss1'>成果转化名称</td>
                     <td style = 'width:463px;' class='tbcss1'>成果水平</td>
                     
                 </tr>
                 <tr>
                     <td colspan = '1' class='tbcss3'>&nbsp;" + dr4["chengguozhm1"].ToString() + @" </td>
                     <td colspan = '1' class='tbcss3'>
                         " + dr4["chengguosp1"].ToString() + @"
                     </td>
                 </tr>
                 <tr>
                     <td colspan = '1' class='tbcss3'>&nbsp;" + dr4["chengguozhm2"].ToString() + @" </td>
                     <td colspan = '1' class='tbcss3'>
                         " + dr4["chengguosp2"].ToString() + @"
                     </td>
                 </tr> 
                 <tr>
                     <td colspan = '1' class='tbcss3'>&nbsp;" + dr4["chengguozhm3"].ToString() + @" </td>
                     <td colspan = '1' class='tbcss3'>
                         " + dr4["chengguosp3"].ToString() + @"
                     </td>
                 </tr>
             </table>
         </div>";
         str2 += @"
         <br>
         <div class='xiangxi'>

             <table Width = '863px' >
                 <tr >
                     <td colspan='2' class='tbtitle'> 其它需求</td>                    
                 </tr>    
               
                 <tr>                     
                     <td colspan = '1' class='tbcss3'>
                          &nbsp;" + dr4["qitaxuqiuqybz"].ToString() + @"
                     </td>                    
                 </tr>
                 <tr>                    
                     <td colspan = '1' class='tbcss3'>
                        " + dr4["qitaxuqiuxx"].ToString() + @"
                     </td>
                 </tr>
             </table>
         </div>
         ";
         str2 += @"
         <br>  
         <div class='xiangxi'>
             <table>
                 <tr>
                     <td colspan='4' class='tbtitle'> 投资计划 </td>                    
                 </tr>  
                 <tr>
                     <td colspan='1' class='tbcss1'>投资项目</td>
                     <td colspan='3' class='tbcss2'>
                          " + dr4["touzhixiangmu"].ToString() + @"
                     </td>
                 </tr>
                
                 <tr>
                     <td colspan='1' class='tbcss1'> 投资额度</td>
                     <td colspan='1' class='tbcss3'>
                          " + dr4["touzhiedu"].ToString() + @"
                     </td>
                     <td colspan='1' class='tbcss1'>固定投资</td>
                     <td colspan='1' class='tbcss3'>
                          " + dr4["touzhiguding"].ToString() + @" 
                     </td>
                 </tr>
                  <tr>
                     <td colspan='1' class='tbcss1'>已完成固定投资</td>
                     <td colspan='3' class='tbcss2'>
                          " + dr4["touzhiyiwancheng"].ToString() + @"
                     </td>
                 </tr>
                 <tr>
                     <td colspan='1' class='tbcss1'>建设内容</td>
                     <td colspan='3' class='tbcss2'>
                         " + dr4["jiansheneirong"].ToString() + @"
                     </td>
                 </tr>
             </table>
         </div>
              ";
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