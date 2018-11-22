using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class admin_diaoyitiaolist : System.Web.UI.Page
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
                                         <th> 联&nbsp;&nbsp;系&nbsp;人</th>
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
                                         <th>邮&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;箱</th>
                                         <td colspan = '3' class='tbcss2'>";
                str2 += dr["email"].ToString();
                str2 += @"
                                            
                                         </td>
                                     </tr>
                                 </table>
                             </div>
                             ";
                DataTable dt1;
                dt1 = DBqiye.getDataTable(@"select  top 1 * from caiwu where CompanyID=" + sid + " ");
                DataRow dr1 = dt1.Rows[0];
                str2 += @"<br><table>
                 <tr >
                     <td colspan = '4' class='tbtitle'>2017年资产财务情况</td>
                    
                  </tr>          
                  <tr>
                     <th colspan = '1' class='tbcss1'> 总&nbsp;&nbsp;资&nbsp;产</td>
                     <td colspan = '1' class='tbcss3'>                         
                        " + dr1["TotalAsset"].ToString() + @"  
                     </td>
                     <th colspan = '1' class='tbcss1'>资产负债率</td>
                     <td colspan = '1' class='tbcss3'>
                         
                         " + dr1["DebtRatio"].ToString() + @"   
                     </td>
                 </tr>
                 <tr>
                     <th colspan = '1' class='tbcss1'> 税&nbsp;&nbsp;&nbsp;收</td>
                     <td colspan = '1' class='tbcss3'>
                          " + dr1["Tax"].ToString() + @" 
                     </td>
                     <th colspan = '1' class='tbcss1'>研发投入比</td>
                     <td colspan = '1' class='tbcss3'>
                         " + dr1["RDInvestmentRatio"].ToString() + @" 
                        
                     </td>
                 </tr>
                 <tr>
                     <th colspan = '1' class='tbcss1'> 营业收入</td>
                     <td colspan = '1' class='tbcss3'>" + dr1["Income"].ToString() + @" 
                        
                     </td>
                     <th colspan = '1' class='tbcss1'>利&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;润</td>
                     <td colspan = '1' class='tbcss3'>" + dr1["Profit"].ToString() + @" 
                         
                 
                     </td>
                 </tr>
                 <tr>
                     <th colspan = '1' class='tbcss1'>企业信用等级</td>
                     <td colspan = '3' class='tbcss2'>" + dr1["xinyongdengji"].ToString() + @" 
                   
                     </td>
                 </tr>
             </table>";

                DataTable dt2;
                dt2 = DBqiye.getDataTable(@"select  top 1 * from C_yitiaolong where CompanyID=" + sid + " ");
                DataRow dr2 = dt2.Rows[0];
                str2 += @"<br><table >
                 <tr >
                     <th colspan = '4' class='tbtitle'>2017年进出口情况</td>
                    
                  </tr>          
                  <tr>
                     <th colspan = '1' class='tbcss1'> 出口产品名称</td>
                     <td colspan = '1' class='tbcss3'> " + dr2["chuchanpin"].ToString() + @"   
                  
                     </td>
                     <th colspan = '1' class='tbcss1'>出口产品货值</td>
                     <td colspan = '1' class='tbcss3'>" + dr2["chuhuozhi"].ToString() + @" 
                         
                        
                     </td>
                 </tr>
                 <tr>
                     <th colspan = '1' class='tbcss1'> 进口零部件名称</td>
                     <td colspan = '1' class='tbcss3'>" + dr2["jinlingbu"].ToString() + @" 
                 
                     </td>
                     <th colspan = '1' class='tbcss1'>进口零部件货值</td>
                     <td colspan = '1' class='tbcss3'>" + dr2["jinhuozhi"].ToString() + @" 
                         
                         
                     </td>
                 </tr>
                 <tr>
                     <th colspan = '1' class='tbcss1'> 进口原材料名称</td>
                     <td colspan = '1' class='tbcss3'>" + dr2["yuanyuncail"].ToString() + @" 
                        
                     </td>
                     <th colspan = '1' class='tbcss1'>进口原材料货值</td>
                     <td colspan = '1' class='tbcss3'>" + dr2["yuanhuozhi"].ToString() + @" 
                         
                         
                     </td>
                 </tr>
               
             </table>
             <br>
             <table >
                 <tr >
                     <td colspan='4' class='tbtitle'>技术创新情况</td>
                    
                  </tr>          
                  <tr>
                     <th colspan = '3' class='tbcss31'> 截止2017年年底企业拥有已授权发明专利的数量</td>
                     <td colspan = '1' class='tbcss11'>" + dr2["shouquanzhuanli"].ToString() + @" 
                     
                     </td>
                    
                 </tr>
                 <tr>
                     <th colspan = '3' class='tbcss31'> 截止2017年年底企业已申请但未取得授权发明专利的数量</td>
                     <td colspan = '1' class='tbcss11'>" + dr2["shenqingzhuanli"].ToString() + @" 
                     
                     </td>
                     
                 </tr>
                 <tr>
                     <th colspan = '1' class='tbcss1'> 是否高薪企业</td>
                     <td colspan = '3' class='tbcss3'>" + dr2["gaoxinqiye"].ToString() + @" 
             
                     </td>
                    
                 </tr>
                 <tr>
                     <th colspan = '1' class='tbcss1'> 企业研发机构情况</td>
                     <td colspan = '3' class='tbcss3'>" + dr2["yanfajigou"].ToString() + @" 
                         
                     </td>
                    
                 </tr>
             </table>
             <br>
             <table  >
                 <tr >
                     <th colspan='4' class='tbtitle'>企业简介</td>
                    
                  </tr>          
                  <tr>
                 
                     <td colspan = '4' class='tbcsstext'>" + dr2["jianjie"].ToString() + @" 
                         
                     </td>
                    
                 </tr>
                 
             </table>";

                DataTable dt3;
                dt3 = DBqiye.getDataTable(@"select  top 3 * from C_zhudaochanpin where CompanyID=" + sid + " ");
                //DataRow dr3 = dt3.Rows[0];
                str2 += @"<br>
                <div class='con'>
             <p><span>*</span>二、主导产品情况<span>  (必填)</span> </p>
         </div>

          <div class='xiangxi'>

             <table style='width:695px;'>    
                        
                  <tr>
                     <td colspan = '1' class='tbcss1'> 主导产品</td>
                     <td colspan = '1' class='tbcss1'>产品技术水平（国际领先、国际先进、国内领先、国内先进） </td>
                     <td colspan = '1' class='tbcss1'>配套用于何种产品（用途）</td>
                     <td colspan = '1' class='tbcss1'>2017年销售量(台套、吨等)</td>
                     <td colspan = '1' class='tbcss1'>2017年销售收入(万美元)</td>
                 </tr>";
                int i = 1;
                foreach (DataRow dr3 in dt3.Rows)
                {
                    str2 += @"<tr>
                     <td colspan = '1' class='tbcss3'> " + dr3["zhudaochanpin"].ToString() + @"  </td>
                     <td colspan = '1' class='tbcss3'>" + dr3["jishushuiping"].ToString() + @" 

                     </td>
                     <td colspan = '1' class='tbcss3'> " + dr3["chanpingyongtu"].ToString() + @"  </td>
                     <td colspan = '1' class='tbcss3'>" + dr3["xiaoshouliang"].ToString() + @"  </td>
                     <td colspan = '1' class='tbcss3'>  " + dr3["xiaoshoushouru"].ToString() + @"  
                        
                     </td>
                 </tr>";

                    str3 += @"<tr >
                     <td colspan = '1' class='tbcss3'>" + i + @" </td>
                     <td colspan = '1' class='tbcss3'>" + dr3["shangyouxuqiu"].ToString() + @"
                
                     </td>
                     <td colspan = '1' class='tbcss3'> " + dr3["xiayouyoutu"].ToString() + @" </td>
                     
                 </tr>";
                    i++;
                }



                str2 += @" </table>
         </div>
         <div class='con'>
             <p><span>*</span>三、对产业链上下游的需求<span>  (必填)</span> </p>
         </div>
           <div class='xiangxi'>

             <table>    
                        
                  <tr>
                     <td colspan = '1' class='tbcss1'> 序号</td>
                     <td colspan = '1' class='tbcss1'>有需求的上游产品（或服务）名称及产品需求</td>
                     <td colspan = '1' class='tbcss1'>可配套下游的产品（或服务）名称及规格、配套用于何种产品</td>
                    
                 </tr>
                 " + str3 + @"
                 
                 
               
               
             </table>
         </div>";
                str2 += @" <div class='con'>
             <p><span>*</span>四、企业资金运营和融资情况<span>  (必填)</span> </p>
         </div>
         <br>
         <div class='xiangxi'>

             <table>    
                 <tr>
                     <th colspan = '4' class='tbtitle'>企业资金运作情况</td>
                    
                  </tr>          
                  <tr>
                     <th colspan = '1' class='tbcss1'>企业主要结算方式</td>
                     <td colspan = '3' class='tbcss3'>" + dr2["jiesuanfangshi"].ToString() + @"
                         
                     </td>
                     
                 </tr>
                 <tr>
                     <th colspan = '1' class='tbcss1'> 企业应收应付帐款期限</td>
                     <td colspan = '3' class='tbcss3'>" + dr2["zhangkuanqixian"].ToString() + @"
                      
                     </td>
                     
                 </tr>
                 <tr>
                     <th rowspan = '2' class='tbcss1'> 企业票据数量</td>
                     <td rowspan = '2' class='tbcss3'>" + dr2["piaojunum"].ToString() + @"
                        
                     </td>
                     <th colspan = '1' class='tbcss1'>其中银票</td>
                     <td colspan = '1' class='tbcss3'>" + dr2["yinpiao"].ToString() + @"
                         
                         
                     </td>
                 </tr>
                 <tr>
                    
                     <th colspan = '1' class='tbcss1'>商票</td>
                     <td colspan = '1' class='tbcss3'>
                         " + dr2["shangpiao"].ToString() + @"
              
                     </td>
                 </tr>
             </table>
         </div>

         <br>
         <div class='xiangxi' >
             <table>
                  <tr >
                     <th colspan='4' class='tbtitle'>企业融资需求</td>                    
                  </tr>          
                  <tr>
                     <th colspan = '1' class='tbcss1'>融资需求额</td>
                     <td colspan = '3' class='tbcss3'>" + dr2["rongzixuqiu"].ToString() + @"
                        
                     </td>
                     
                 </tr>
                 <tr>
                     <th colspan = '1' class='tbcss1'> 融资用途</td>
                     <td colspan = '3' class='tbcss3'>" + dr2["rongziyongtu"].ToString() + @"
      
                     </td>
                     
                 </tr>
                 <tr>
                     <th colspan = '1' class='tbcss1'> 融资期限</td>
                     <td colspan = '3' class='tbcss3'>" + dr2["rongziqixian"].ToString() + @"
                        
                     </td>                     
                 </tr>
                 <tr>
                     <th rowspan = '2' class='tbcss1'> 拟采用融资方式及说明</td>
                     <td colspan = '3' class='tbcss3'>" + dr2["rongzifangshi"].ToString() + @"
                        
                     </td>                     
                 </tr>
                  <tr>
                    
                     <td colspan = '3' class='tbcss3'>" + dr2["rongzishuming"].ToString() + @"
                         
                     </td>                     
                 </tr>
             </table>
         </div>
         <br>
         <div class='xiangxi' >
             <table>
                 <tr >
                     <td colspan='4' class='tbtitle'>其他情况</td>                    
                  </tr>          
                  <tr>
                     <th colspan = '1' class='tbcss1'>企业对上游配套企业资金支持情况</td>
                     <td colspan = '3' class='tbcss3'>" + dr2["zijingzhichi"].ToString() + @"
                        
                     </td>
                     
                 </tr>
             </table>
         </div>";
                DataTable dt4;
                dt4 = DBqiye.getDataTable(@"select  top 3 * from C_YanFaXiangMu where CompanyID=" + sid + " ");
                str2 += @"  <div class='con'>
             <p><span>*</span>五、正在实施或拟实施项目情况<span>  (必填)</span> </p>
         </div>
         <div class='conts'>
             <p>多个项目的填主要项目，其他可在备注中说明（可选，根据实际情况填写，无项目不需填写）</p>
         </div>
         <br>
         <div class='xiangxi'>

             <table>    
                 <tr>
                     <td colspan = '5' class='tbtitle'>研发攻关项目</td>                    
                 </tr>    
                 <tr>
                     <td colspan = '1' class='tbcss1'> 项目名称</td>
                     <td colspan = '1' class='tbcss1'>主要解决的技术瓶颈（实施目标） </td>
                     <td colspan = '1' class='tbcss1'>项目开展方式</td>
                     <td colspan = '1' class='tbcss1'>项目实施期(填写格式：XX年XX月—XX年XX月)</td>
                     <td colspan = '1' class='tbcss1'>项目总投资（万元）</td>
                 </tr>";
                foreach (DataRow dr4 in dt4.Rows)
                {
              str2 += @"  <tr >
                     <td colspan = '1' class='tbcss3'>" + dr4["xiangmuming"].ToString() + @"   </td>
                     <td colspan = '1' class='tbcss3'>" + dr4["jishupingjing"].ToString() + @" 
                    
                     </td>
                     <td colspan = '1' class='tbcss3'>  " + dr4["kaizhangfangshi"].ToString() + @"  </td>
                     <td colspan = '1' class='tbcss3'> " + dr4["shishiqi"].ToString() + @"  </td>
                     <td colspan = '1' class='tbcss3'>  " + dr4["zongtouzi"].ToString() + @"  
                        
                     </td>
                 </tr>";
                }


                str2 += @"    </table>
         </div>

         <br>
         <div class='xiangxi'>

             <table>    
                 <tr>
                     <td colspan = '5' class='tbtitle'>产业化项目</td>                    
                 </tr>    
                 <tr>
                     <td colspan = '1' class='tbcss1'> 项目名称</td>
                     <td colspan = '1' class='tbcss1'>项目建设纲领</td>
                     <td colspan = '1' class='tbcss1'>项目建设内容</td>
                     <td colspan = '1' class='tbcss1'>项目实施期(填写格式：XX年XX月—XX年XX月)</td>
                     <td colspan = '1' class='tbcss1'>项目总投资（万元）</td>
                 </tr>";
                DataTable dt5;
                dt5 = DBqiye.getDataTable(@"select  top 3 * from C_ChanYeXiangMu where CompanyID=" + sid + " ");
                foreach (DataRow dr5 in dt5.Rows)
                {
                    str2 += @" 

                 <tr>
                     <td colspan = '1' class='tbcss3'>  " + dr5["xiangmu"].ToString() + @"  </td>
                     <td colspan = '1' class='tbcss3'> " + dr5["jianshegangling"].ToString() + @" 
                 
                     </td>
                     <td colspan = '1' class='tbcss3'> " + dr5["jianshenenrong"].ToString() + @"   </td>
                     <td colspan = '1' class='tbcss3'>  " + dr5["shishiqis"].ToString() + @"  </td>
                     <td colspan = '1' class='tbcss3'>  " + dr5["zongtouzis"].ToString() + @"   
                         
                     </td>
                 </tr>";
                }


                str2 += @"   
                 
                 
               
               
             </table>
         </div>";

         str2 += @" <div class='con'>
             <p>六、其它说明</p>
         </div>
         <br>
         <div class='xiangxi'>

             <table style = 'width:864px;' >
                 <tr >
                     <td colspan='4' class='tbtitle'>其它说明</td>                    
                  </tr>          
                  <tr>                 
                     <td colspan = '4' class='tbcsstext'>" + dr2["qitashuoming"].ToString() + @"                        
                     </td>                    
                 </tr>                 
             </table>
         </div>";
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