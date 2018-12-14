using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class admin_diaochatuanlist : System.Web.UI.Page
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

                
                //if (dr["HasQuoted"].ToString() == "1")
                //{ sShangShi = "是"; }

                //string sgupiao = "否";
                //if (dr["Incentive_HasStock"].ToString() == "1")
                //{ sgupiao = "是"; }

                str2 += @"<table>
                             <tr>
                                 <td colspan='1' class='tbcss1'>企业名称：</td>
                                 <td colspan = '1' class='tbcss2'>
                                    " + dr["name"].ToString() + @"
                                 </td>
                                 <td colspan = '1' class='tbcss1'>企业地址：</td>
                                 <td colspan = '1' class='tbcss2'>
                                     " + dr["Address"].ToString() + @"
                                 </td>
                             </tr>
                              
                              <tr>
                                 <td class='tbcss1'>联  系 人：</td>
                                 <td class='tbcss12'>
                                    " + dr["Contact"].ToString() + @"
                                 </td>
                                 <td class='tbcss13'>手机：</td>
                                 <td class='tbcss14' >
                                     " + dr["ContactTel"].ToString() + @"
                                 </td>
                             </tr>
                 
                          
                              <tr>
                                 <td class='tbcss1'>邮箱：</td>
                                 <td class='tbcss12' colspan='3'>
                                     " + dr["email"].ToString() + @"
                                 </td>
                    
                             </tr>
                            
                         </table>";


                
                DataTable dt7;
                dt7 = DBqiye.getDataTable(@"SELECT *  FROM   [C_TuanTi] where ([CompanyID]=" + sid + ")  ");
                DataRow dr7 = dt7.Rows[0];
                str2 += @"<div class='con'>
                            <p ><span > *</ span > &nbsp; &nbsp; 团体标准制修订提案申请表<span>  </span > </p >          
                        </div >
          
                         <table>
                             <tr>
                                 <td colspan='1' class='tbcss1'>中文名称</td>
                                 <td colspan = '3' class='tbcss2'>
                                     " + dr7["mingcheng"].ToString() + @"
                                 </td>
                             </tr>
                             <tr>
                                 <td colspan = '1' class='tbcss1'>英文名称</td>
                                 <td colspan = '3' class='tbcss2'>
                                     " + dr7["mingchengyw"].ToString() + @" 
                                 </td>
                             </tr>
                             <tr>
                                 <td colspan = '1' class='tbcss1'> 制定/修订</td>
                                 <td colspan = '1' class='tbcss3'>";
                        if (dr7["zhiding"].ToString() == "1")
                        {
                            str2 += @"制定";
                        }
                        else if (dr7["zhiding"].ToString() == "2")
                        {
                            str2 += @"修订";
                        }

                str2 += @" </td>
                                 <td colspan = '1' class='tbcss1'>被修订标准号</td>
                                 <td colspan = '1' class='tbcss3'>
                         
                                     " + dr7["biaozhunhao"].ToString() + @"   
                                 </td>
                             </tr>
                             <tr>
                                 <td colspan = '1' class='tbcss1'>采用国际标准</td>
                                 <td colspan = '1' class='tbcss3'>";
                if (dr7["guojibz"].ToString() == "1")
                {
                    str2 += @"无";
                }
                else if (dr7["guojibz"].ToString() == "2")
                {
                    str2 += @"ISO";
                }
                else if (dr7["guojibz"].ToString() == "3")
                {
                    str2 += @"IEC";
                }
                else if (dr7["guojibz"].ToString() == "4")
                {
                    str2 += @"ITU";
                }
                else if (dr7["guojibz"].ToString() == "5")
                {
                    str2 += @"ISO/IEC";
                }
                else if (dr7["guojibz"].ToString() == "6")
                {
                    str2 += @"ISO确认的标准";
                }

                str2 += @" </td>
                                 <td colspan = '1' class='tbcss1'>采用程度</td>
                                 <td colspan = '1' class='tbcss3'>";
                if (dr7["chongdu"].ToString() == "1")
                {
                    str2 += @"等同";
                }
                else if (dr7["chongdu"].ToString() == "2")
                {
                    str2 += @"修改";
                }
                else if (dr7["chongdu"].ToString() == "3")
                {
                    str2 += @"非等效";
                }
                str2 += @"
                                 </td>
                             </tr>
                             <tr>
                                 <td colspan = '1' class='tbcss1'>采标号</td>
                                 <td colspan = '1' class='tbcss3'>
                                     " + dr7["caibiaohao"].ToString() + @" 
                                 </td>
                                 <td colspan = '1' class='tbcss1'>采标名称</td>
                                 <td colspan = '1' class='tbcss3'>
                                    " + dr7["caibiaoming"].ToString() + @"
                                      
                                 </td>
                             </tr>
                             <tr>
                                 <td colspan = '1' class='tbcss1'>标准类别</td>
                                 <td colspan = '3' class='tbcss2'>";
                if (dr7["biaozhunlei"].ToString() == "1")
                {
                    str2 += @"安全";
                }
                else if (dr7["biaozhunlei"].ToString() == "2")
                {
                    str2 += @"卫生";
                }
                else if (dr7["biaozhunlei"].ToString() == "3")
                {
                    str2 += @"环保";
                }
                else if (dr7["biaozhunlei"].ToString() == "4")
                {
                    str2 += @"基础";
                }
                else if (dr7["biaozhunlei"].ToString() == "5")
                {
                    str2 += @"方法";
                }
                else if (dr7["biaozhunlei"].ToString() == "6")
                {
                    str2 += @"管理";
                }
                else if (dr7["biaozhunlei"].ToString() == "6")
                {
                    str2 += @"产品";
                }
                else if (dr7["biaozhunlei"].ToString() == "6")
                {
                    str2 += @"其它";
                }
                str2 += @"                   
                                 </td>
                             </tr>
                             <tr>
                                 <td colspan = '1' class='tbcss1'>ICS</td>
                                 <td colspan = '3' class='tbcss2'>
                                      " + dr7["ICS"].ToString() + @"
                                 </td>
                             </tr>
                             <tr>
                                 <td colspan = '1' class='tbcss1'>上报单位</td>
                                 <td colspan = '3' class='tbcss2'>
                                      " + dr7["danwen"].ToString() + @"
                                 </td>
                             </tr>
                             <tr>
                                 <td colspan = '1' class='tbcss1'>技术归口单位
                                    （或技术委员会）
                                 </td>
                                 <td colspan = '3' class='tbcss2'>
                                      " + dr7["jishuweiyuan"].ToString() + @"
                                 </td>
                             </tr>
                             <tr>
                                 <td colspan = '1' class='tbcss1'>主管部门</td>
                                 <td colspan = '3' class='tbcss2'>
                                      " + dr7["bumen"].ToString() + @"
                                 </td>
                             </tr>
                             <tr>
                                 <td colspan = '1' class='tbcss1'>起草单位</td>
                                 <td colspan = '3' class='tbcss2'>
                                      " + dr7["qicaodw"].ToString() + @"
                                 </td>
                             </tr>
                             <tr>
                                 <td colspan = '1' class='tbcss1'>项目周期</td>
                                 <td colspan = '3' class='tbcss2'>
                                      " + dr7["zhouqi"].ToString() + @"个月
                                 </td>
                             </tr>
                             <tr>
                                 <td colspan = '1' class='tbcss1'>是否采用快速程序</td>
                                 <td colspan = '1' class='tbcss3'>";
                            if (dr7["kuaisucx"].ToString() == "1")
                            {
                                str2 += @"是";
                            }
                            else 
                            {
                                str2 += @"否";
                            }
                            str2 += @"
                                 </td>
                                 <td colspan = '1' class='tbcss1'>快速程序代码</td>
                                 <td colspan = '1' class='tbcss3'>";
                if (dr7["chengxudm"].ToString() == "1")
                {
                    str2 += @"B1";
                }
                else if (dr7["chengxudm"].ToString() == "2")
                {
                    str2 += @"B2";
                }
                else if (dr7["chengxudm"].ToString() == "3")
                {
                    str2 += @"B3";
                }
                else if (dr7["chengxudm"].ToString() == "4")
                {
                    str2 += @"B4";
                }
                else if (dr7["chengxudm"].ToString() == "5")
                {
                    str2 += @"C3";
                }

                                    
                    str2 += @"
                                 </td>
                             </tr>
                             <tr>
                                 <td colspan = '1' class='tbcss1'>经费预算说明</td>
                                 <td colspan = '3' class='tbcss2'>
                                      " + dr7["jifeiys"].ToString() + @" 
                                 </td>
                             </tr>
                             <tr style = 'height:100px;' >
                                 <td colspan='1' class='tbcss1'>目的、意义</td>
                                 <td colspan = '3' class='tbcss2'>
                                      " + dr7["mudiyy"].ToString() + @"
                                 </td>
                             </tr>
                             <tr style = 'height:100px;' >
                                 <td colspan='1' class='tbcss1'>范围和主要技术内容</td>
                                 <td colspan = '3' class='tbcss2'>
                                      " + dr7["fanweijs"].ToString() + @" 
                                 </td>
                             </tr>
                             <tr style = 'height:100px;' >
                                 <td colspan='1' class='tbcss1'>国内外情况简要说明</td>
                                 <td colspan = '3' class='tbcss2'>
                                      " + dr7["guomeiyaiqk"].ToString() + @" 
                                 </td>
                             </tr>
                             <tr style = 'height:100px;' >
                                 <td colspan='1' class='tbcss1'>有关法律法规和强制性标准的关系</td>
                                 <td colspan = '3' class='tbcss2'>
                                      " + dr7["falufg"].ToString() + @" 
                                 </td>
                             </tr>
                             <tr style = 'height:100px;' >
                                 <td colspan='1' class='tbcss1'>标准涉及的产品清单</td>
                                 <td colspan = '3' class='tbcss2'>
                                      " + dr7["chanpinqd"].ToString() + @" 
                                 </td>
                             </tr>
                             <tr>
                                 <td colspan = '1' class='tbcss1'>是否有国家级科研项目支撑</td>
                                 <td colspan = '1' class='tbcss3'>";
                            if (dr7["guojiajixm"].ToString() == "1")
                            {
                                str2 += @"是";
                            }
                            else
                            {
                                str2 += @"否";
                            }
                            str2 += @"
                                      
                                 </td>
                                 <td colspan = '1' class='tbcss1'>科研项目编号及名称</td>
                                 <td colspan = '1' class='tbcss3'>
                         
                                      " + dr7["xiangmuid"].ToString() + @"
                                 </td>
                             </tr>
                             <tr>
                                 <td colspan = '1' class='tbcss1'>是否涉及专利</td>
                                 <td colspan = '1' class='tbcss3'>";
                            if (dr7["zhuanli"].ToString() == "1")
                            {
                                str2 += @"是";
                            }
                            else
                            {
                                str2 += @"否";
                            }
                            str2 += @"
                                     
                                 </td>
                                 <td colspan = '1' class='tbcss1'>专利号及名称</td>
                                 <td colspan = '1' class='tbcss3'>
                         
                                      " + dr7["zhuanliming"].ToString() + @"
                                 </td>
                             </tr>          
                             <tr>
                                 <td colspan = '1' class='tbcss1'>是否由行标或地标转化</td>
                                 <td colspan = '1' class='tbcss3'> ";
                            if (dr7["hangbiao"].ToString() == "1")
                            {
                                str2 += @"是";
                            }
                            else
                            {
                                str2 += @"否";
                            }
                            str2 += @"
                                     
                                 </td>
                                 <td colspan = '1' class='tbcss1'>行地标标准号及名称</td>
                                 <td colspan = '1' class='tbcss3'>
                         
                                      " + dr7["hangbiaohao"].ToString() + @"
                                 </td>
                             </tr>
                             <tr>
                                 <td colspan = '1' class='tbcss1'>备注</td>
                                 <td colspan = '3' class='tbcss2'>
                                     " + dr7["benzhu"].ToString() + @" 
                                 </td>
                             </tr>
                         </table>";
                
           

            }





        }
        catch
        {
            //myGrid. = 0;
            //Response.Write(sql5);
            str2 += @"<div class='con'>
                            <p ><span > *</ span > &nbsp; &nbsp; 团体标准制修订提案申请表<span>:   -------- 读取错误 !</span > </p >          
                        </div >";
        }
        finally
        {

        }



    }
}