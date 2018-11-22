using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class admin_diaochalist : System.Web.UI.Page
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
        dt = DBqiye.getDataTable(@"SELECT *,(case isIGBT WHEN '1' THEN 'IGBT领域' ELSE '其他领域' END) igbt  FROM  [company] where (id=" + sid+")  ");

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
                                 <p><span>*</span>企业信息<span>  (必填)</span> </p>
                             </div>
                             <div class='xiangxi'>
                                 <table>
                                     <tr>
                                         <th>企业名称</th>
                                         <td colspan = '3' class='tbcss2'>";
                                         str2 +=  dr["name"].ToString();
                                         str2 += @" </td>
                                     </tr>
                                     <tr>
                                         <th>企业地址</th>
                                         <td colspan = '3' class='tbcss2'>";
                                         str2 +=  dr["Address"].ToString();
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
                             <div class='con'>
                                 <p><span>*</span>甄别问题<span>  (必选)</span> </p>
                             </div>
                             <table>
                               <tr>
                                 <th>企业是否属于IGBT领域？</th>
                                 <td>";
                                str2 += dr["igbt"].ToString();
                                str2 += @"
                                 </td>
                               </tr>
                             </table>";                            str2+="<div class='title'>"+ dr["igbt"].ToString() + "</div>";
                if (dr["isIGBT"].ToString() == "1")
                {
                    str2 += "<div class='titlebj'>Ⅰ类问卷 IGBT领域企业 </div>";
                }
                else
                {
                    str2 += " <div class='titlebj'>Ⅱ类问卷 非IGBT领域企业 </div>";
                }
                    str2 += "<div class='title'>企业类型</div>";
                    str2 += @"<table>
                               <tr>
                                 <th>1.请问贵单位企业经济类型是以下哪种？</th>
                                 <td>";
                    str2 += settingname(dr["EnterpriseType"].ToString());
                    str2 += @"
                                 </td>
                               </tr>
                                 <tr>
                                 <th>2.请问贵单位企业类别是以下哪种？</th>
                                 <td>";
                    str2 += settingname(dr["EnterpriseLeibie"].ToString());
                    str2 += @"
                                 </td>
                               </tr>
                                 <tr>
                                 <th>3.请问贵单位是否为上市企业？</th>
                                 <td>";
                    str2 += settingname(dr["isshangshi"].ToString());
                    str2 += @"
                                 </td>
                               </tr>
                             </table>";
                    str2 += "<div class='title'>企业所属领域 / 行业</div>";
                    str2 += @"<table>
                               <tr>
                                 <th>1.请问贵单位属于以下哪种行业？</th>
                                 <td>";
                    str2 += (dr["Hangye"].ToString());
                    str2 += @"
                                 </td>
                               </tr>
                                 <tr>
                                 <th>2.请问贵单位属于十大重点领域的哪一领域？ (可多选)</th>
                                 <td>";
                    str2 += settingnamearray(dr["lingyu"].ToString());
                    str2 += @"
                                 </td>
                               </tr>
                                 <tr>
                                 <th>3.对应16条龙应用计划，请问贵单位属于以下哪一应用计划？ (可多选)</th>
                                 <td>";
                    str2 += settingnamearray(dr["yingyongjihua"].ToString());
                    str2 += @"
                                 </td>
                               </tr>
                             </table>";

                if (dr["isIGBT"].ToString() == "1")
                {
                    str2 += "<div class='title'>IGBT相关产品</div>";
                    str2 += @"<table>
                               <tr>
                                 <th>1.请问贵单位属于在IGBT产业链的哪一位置？ (可多选)</th>
                                 <td>";
                    str2 += settingnamearray(dr["IGBTweizhi"].ToString());
                    str2 += @"
                                 </td>
                               </tr>
                             </table>";
                    str2 += "<div class='title'>2.请问贵单位拥有哪些IGBT相关产品？</div>";
                    str2 += @" <table class='kongxi'>
                                 <tbody><tr>
                                     <th class='igbt2_1'>IGBT产品</td>
                                     <th class='igbt2_3'>产品核心是否自主知识产权</td>
                                     <th class='igbt2_3'>是否量产</td>
                                     <th class='igbt2_4'>量产年月</td>
                                     <th class='igbt2_2'>主要应用领域</td>
                                     <th class='igbt2_5'>技术创新点</td>
                                 </tr>";
                    DataTable dt1;
                    dt1 = DBqiye.getDataTable(@"SELECT *  FROM [dbo].[Results] where rno like 'H%' and ChiYouRenID=" + sid + " ");
                    // DataRow dr = dt.Rows[0];
                    foreach (DataRow dr1 in dt1.Rows)
                    {
                        string sjishu = "";
                        if (dr1["iszizhujishu"].ToString() == "1")
                        {
                            sjishu = "是";
                        }
                        else
                        {
                            sjishu = "否";
                        }
                        string sliang = "";
                        if (dr1["isliangchang"].ToString() == "1")
                        {
                            sliang = "是";
                        }
                        else
                        {
                            sliang = "否";
                        }
                        str2 += @" <tr>
                                     <td class='igbt2_1'>" + dr1["RName"].ToString() + @"</td>
                                     <td class='igbt2_3'>" + sjishu + @"  </td>
                                     <td class='igbt2_3'>" + sliang + @"  </td>
                                     <td class='igbt2_4'>" + dr1["liangchantime"].ToString() + @"</td>
                                     <td class='igbt2_2'>" + dr1["zhuyaoyongyonglingyu"].ToString() + @" </td>
                                     <td class='igbt2_5'>" + dr1["jishuchuangxindian"].ToString() + @"</td>
                                 </tr>";

                    }
                    str2 += @" </tbody></table>";
                    str2 += "<div class='title'>3.请问生产同类IGBT产品的其他企业都有谁？</div>";
                    str2 += @" <table class='kongxi'>
                                 <tbody><tr>
                                     <th class='igbt3_1'>序&nbsp;&nbsp;号</td>
                                     <th class='igbt3_2'>企业名称</td>
                                 </tr>";



                    DataTable dt2;
                    dt2 = DBqiye.getDataTable(@"SELECT *  FROM [dbo].[DuibiaoCompany] where  companyID=" + sid + " ");
                    // DataRow dr = dt.Rows[0];
                    int i1 = 1;
                    foreach (DataRow dr2 in dt2.Rows)
                    {
                        str2 += @"<tr>
                                     <td class='igbt3_1'>" + i1.ToString() + @"</td>
                                     <td class='igbt3_2'>" + dr2["qiyeName"].ToString() + @" </td>
                                  </tr>   ";
                        i1++;
                    }
                    str2 += @" </tbody></table>";

                    str2 += "<div class='title'>4.请问贵单位近三年的IGBT产品产量及2017年预计产量以及近三年的IGBT产品销售收入及2017年预计收入（单位：万元）？</div>";
                    str2 += @" <table class='kongxi'>
                                 <tbody>
                                      <tr>
                                        <td class='igbt8_1'>产量和收入</td>
                                        <td class='igbt8_2'>2014</td>
                                        <td class='igbt8_2'>2015</td>
                                        <td class='igbt8_2'>2016</td>
                                        <td class='igbt8_2'>2017(预计)</td>
                                        <td class='igbt8_2'>单位</td>
                                    </tr>";

                    DataTable dt3;
                    dt3 = DBqiye.getDataTable(@"select  top 1
                                                (select top 1 chanliang from IGBTchanliang where companyid=" + sid + @" and nianfen=2014 order by id desc) chanliang2014,
                                                (select top 1 chanliang from IGBTchanliang where companyid= " + sid + @" and nianfen=2015 order by id desc) chanliang2015,
                                                (select top 1 chanliang from IGBTchanliang where companyid= " + sid + @" and nianfen=2016 order by id desc) chanliang2016,
                                                (select top 1 chanliang from IGBTchanliang where companyid= " + sid + @" and nianfen=2017 order by id desc) chanliang2017,chnaliangDanwei,'IGBT产品产量' sname
                                                    from IGBTchanliang where  companyid=" + sid + @" and nianfen=2014  
                                                    union   
                                                select  top 1
                                                (select top 1 xiaoshoushouru from IGBTchanliang where companyid=" + sid + @" and nianfen=2014 order by id desc) chanliang2014,
                                                (select top 1 xiaoshoushouru from IGBTchanliang where companyid=" + sid + @" and nianfen=2015 order by id desc) chanliang2015,
                                                (select top 1 xiaoshoushouru from IGBTchanliang where companyid=" + sid + @" and nianfen=2016 order by id desc) chanliang2016,
                                                (select top 1 xiaoshoushouru from IGBTchanliang where companyid=" + sid + @" and nianfen=2017 order by id desc) chanliang2017,chnaliangDanwei,'IGBT产品销售收入' sname
                                                    from IGBTchanliang where  companyid=" + sid + @" and nianfen=2014  ");
                    // DataRow dr = dt.Rows[0];

                    foreach (DataRow dr3 in dt3.Rows)
                    {

                        str2 += @"<tr>                            
                                        <td class='igbt8_1'>" + dr3["sname"].ToString() + @"</td>
                                        <td class='igbt8_2'>" + dr3["chanliang2014"].ToString() + @"</td>
                                        <td class='igbt8_2'>" + dr3["chanliang2015"].ToString() + @"</td>
                                        <td class='igbt8_2'>" + dr3["chanliang2016"].ToString() + @"</td>
                                        <td class='igbt8_2'>" + dr3["chanliang2017"].ToString() + @"</td>
                                        <td class='igbt8_2'>" + dr3["chnaliangDanwei"].ToString() + @"</td>
                                  </tr>   ";
                        

                    }
                    str2 += @" </tbody></table>";
                    str2 += "<div class='title'>技术水平</div>";
                    str2 += @"<table>
                               <tr>
                                 <th>1.请问贵单位的IGBT技术来源包括哪些？ (可多选)</th>
                                 <td>";
                    str2 += dr["jishulaiyuan"].ToString();
                    str2 += @"
                                 </td>
                               </tr>
                               <tr>
                                 <th>2.请问贵单位是否有专利、查新、鉴定？若有，具体数量是多少？</th>
                                 <td>";
                    if (dr["iszhuangli"].ToString() == "0")
                    {
                        str2 += "否";
                    }
                    else
                    {
                        str2 += dr["iszhuangli"].ToString();
                    }
                    str2 += @"
                                 </td>
                               </tr>
                             </table>";
                }
                    str2 += "<div class='title'>3.贵单位对应的项目情况</div>";
                    DataTable dt4;
                    dt4 = DBqiye.getDataTable(@"SELECT *,( select  top 1 FileName from  [dbo].[ResultPic]  where CID=Results.id order by id desc) FileName  FROM [dbo].[Results] where rno like 'I%' and ChiYouRenID=" + sid + " ");
                    // DataRow dr = dt.Rows[0];
                   int i = 1;
                    foreach (DataRow dr4 in dt4.Rows)
                    {                       
                        str2 += @"
                                 <table class='kongxi'>
                                    <tbody>
                                        <tr>
                                            <th class='jishu4_1'>项目"+ i.ToString() + @"名称</td>
                                            <td class='jishu4_2'>" + dr4["RName"].ToString() + @"</td>
                                        </tr>
                                        <tr>
                                            <th class='jishu4_1'>技术指标及对应参数</td>
                                            <td class='jishu4_2'>" + dr4["jishuzhibiaocanshu"].ToString() + @"</td>
                                        </tr>
                                        <tr>
                                            <td class='jishu4_1'>技术阶段</td>
                                            <td class='jishu4_2'>
                                                " + dr4["jishujieduan"].ToString() + @"
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class='jishu4_1'>技术成果水平</td>
                                            <td class='jishu4_2'>
                                                " + settingname(dr4["ShuiPing"].ToString() )+ @"
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class='jishu4_1'>技术成果属性</td>
                                            <td class='jishu4_2'>
                                                " + settingname(dr4["ShuXing"].ToString() )+ @"
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class='jishu4_1'>成果图片展示</td>
                                            <td class='jishu4_2'> <img width='500px' src='http://www.miit-kjcg.org/"+dr4["FileName"].ToString()+@"' />              
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class='jishu4_1'>对外合作方式</td>
                                            <td class='jishu4_2'>  " + dr4["duiwaihezuo"].ToString() + @"            
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>";
                        i++;
                    }
                    str2 += @" </tbody></table>";
                    str2 += " <div class='title'>财务指标</div>";
                    str2 += " <div class='title'>请填写贵单位的资产负债、研发投入、企业总资产、销售收入、利润、税收和出口创汇情况</div>";

                    DataTable dt5;
                    dt5 = DBqiye.getDataTable(@"select top 1  *
,(select top 1 Income from CaiWu where CompanyID=" + sid + @" and Year=2014 order by id desc )income2014 
, (select top 1 Income from CaiWu where CompanyID=" + sid + @" and Year=2015 order by id desc )income2015 
,(select top 1 Income from CaiWu where CompanyID=" + sid + @" and Year=2016 order by id desc )income2016 
,(select top 1 Income from CaiWu where CompanyID=" + sid + @" and Year=2017 order by id desc )income2017 
from CaiWu where CompanyID=" + sid + @" order by id desc ");
                    DataRow dr5 = dt5.Rows[0];
                    str2 += @" <table   style='padding: 0;width:632px;' >
                                <tbody>
                                    <tr>
                                        <td class='cw1_1'>科目</td>
                                        <td class='cw1_2'>数值</td>
                                    </tr>
                                    <tr>
                                        <td class='cw1_11'>&nbsp;&nbsp;&nbsp;&nbsp;资产负债率(%)</td>
                                        <td class='cw1_2'> " + dr5["DebtRatio"].ToString() + @" </td>
                                    </tr>
                                    <tr>
                                        <td class='cw1_11'>&nbsp;&nbsp;&nbsp;&nbsp;研发投入比(%)</td>
                                        <td class='cw1_2'>" + dr5["RDInvestmentRatio"].ToString() + @"</td>
                                    </tr>
                                    <tr>
                                        <td class='cw1_11'>&nbsp;&nbsp;&nbsp;&nbsp;企业总资产(万)</td>
                                        <td class='cw1_2'>" + dr5["TotalAsset"].ToString() + @"</td>
                                    </tr>
                                    <tr>
                                        <td class='cw1_11'>
                                            <table    style='width:300px;'>
                                                <tbody >
                                                    <tr >
                                                        <td style='width:200px;'>&nbsp;&nbsp;&nbsp;&nbsp;企业销售收入(万)</td>
                                                        <td>
                                                            <table  style='width:100px;'>
                                                                <tbody >
                                                                    <tr><td style='width:100px;'>2014年</td></tr>
                                                                    <tr><td >2015年</td></tr>
                                                                    <tr><td >2016年</td></tr>
                                                                </tbody>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                        <td class='cw1_2'>
                                            <table style='width:200px;' >
                                                <tbody >
                                                    <tr >
                                                        <td  style='width:200px;'>" + dr5["Income2014"].ToString() + @"</td>
                                                    </tr>
                                                    <tr>
                                                        <td >" + dr5["Income2015"].ToString() + @"</td >
                                                    </tr >
                                                    <tr >
                                                        <td >" + dr5["Income2016"].ToString() + @"</td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td class='cw1_11'>
                                            <table style='width:300px;' >
                                                <tbody >
                                                    <tr >
                                                        <td style='width:200px;'>&nbsp;&nbsp;&nbsp;&nbsp;企业销售收入预计(万)</td>
                                                        <td>
                                                            <table  style='width:100px;'>
                                                                <tbody >
                                                                    <tr ><td  style='width:100px;'>2017年</td></tr>
                                                                </tbody>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                        <td class='cw1_2'>
                                            <table style='width:200px;' >
                                                <tbody >
                                                    <tr >
                                                        <td style='height:46px;width:200px;'>" + dr5["Income2017"].ToString() + @"</td>
                                                    </tr>

                                                </tbody>
                                            </table>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td class='cw1_11'>&nbsp;&nbsp;&nbsp;&nbsp;近三年利润总和(万)</td>
                                        <td class='cw1_2'>" + dr5["Profit"].ToString() + @"</td>
                                    </tr>
                                    <tr>
                                        <td class='cw1_11'>&nbsp;&nbsp;&nbsp;&nbsp;近三年税收总和(万)</td>
                                        <td class='cw1_2'>" + dr5["Tax"].ToString() + @"</td>
                                    </tr>
                                    <tr>
                                        <td class='cw1_11'>&nbsp;&nbsp;&nbsp;&nbsp;近三年出口创汇总和(万美元)</td>
                                        <td class='cw1_2'>" + dr5["ExportEarnings"].ToString() + @"</td>
                                    </tr>

                                </tbody>
                            </table>";
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