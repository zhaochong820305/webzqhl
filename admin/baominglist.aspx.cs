using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class admin_baominglist : System.Web.UI.Page
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
        dt = DBqiye.getDataTable(@"SELECT * FROM  [company] where (id=" + sid + ")  ");

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
                              
                             <div class='xiangxi'>
                                 <table>
                                     <tr>
                                         <th>参会单位	</th>
                                         <td colspan = '3' class='tbcss2'>";
                str2 += dr["name"].ToString();
                str2 += @" </td>
                                     </tr>
                                     <tr>
                                         <th>通讯地址	</th>
                                         <td colspan = '1' class='tbcss2'>";
                str2 += dr["Address"].ToString();
                str2 += @"</td>
                                   <th>邮编	</th>
                                         <td colspan = '1' class='tbcss2'>";
                str2 += dr["ZipCode"].ToString();
                str2 += @"</td>  
                                     </tr>
                                     <tr>
                                         <th> 联系人姓名	</th>
                                         <td colspan = '1' class='tbcss3'>";
                str2 += dr["Contact"].ToString();
                str2 += @"                                            
                                         </td>
                                         <th>手机</th>
                                         <td colspan = '1' class='tbcss3'>";
                str2 += dr["ContactTel"].ToString();
                str2 += @"
                                            
                                         </td>
                                     </tr>
                                     <tr>
                                         <th>电子邮箱</th>
                                         <td colspan = '3' class='tbcss2'>";
                str2 += dr["email"].ToString();
                str2 += @"
                                            
                                         </td>
                                     </tr>
                                     <tr>
                                         <th>联系人是否出席</th>
                                         <td colspan = '3' class='tbcss2'>";
                //str2 += dr["isIGBT"].ToString();
                if (dr["isIGBT"].ToString() == "1")
                { str2 += "是"; }
                else { str2 += "否"; }   

                    str2 += @"
                                            
                                         </td>
                                     </tr>
                                    
                                 </table>
                             </div>
                             ";

                DataTable dt3;
                dt3 = DBqiye.getDataTable(@"select  top 7 * from C_baoming where companyid=" + sid + " ");
                //DataRow dr3 = dt3.Rows[0];
                str2 += @"<br>
               

          <div class='xiangxi'>

             <table style='width:695px;'>    
                  <tr>
                     <td  class='tbcss11'>参会人姓名</td>
                     <td  class='tbcss12'>
                         姓别
                     </td>
                     <td class='tbcss13'>职&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;务</td>
                     <td class='tbcss14' colspan='2'>
                         本人电话
                     </td>
                 </tr>";
                //int i = 1;
                foreach (DataRow dr3 in dt3.Rows)
                {
                    str2 += @"    
                    <tr>
                     <td  class='tbcss11'>" + dr3["name"].ToString() + @"</td>
                     <td  class='tbcss12'>
                         " + dr3["sex"].ToString() + @"
                     </td>
                     <td class='tbcss13'>" + dr3["title"].ToString() + @"</td>
                     <td class='tbcss14' colspan='2'>
                         " + dr3["tel"].ToString() + @"
                     </td>
                 </tr>";


                    //i++;
                }

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