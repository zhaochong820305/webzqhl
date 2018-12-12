using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class admin_zhengcejs : System.Web.UI.Page
{
    public int id = 0;
    public string str = string.Empty;
    public int classid = 0;
    public int page = 0;
    public string classjs = "";
    public string class2js = "";
    public string buweiview = "style=\"display:none;\"";
    public string difangview = "style=\"display:none;\"";
    public string gongchengview = "style=\"display:none;\"";
    public string kejiview = "style=\"display:none;\"";
    public string xiangmuliview= "style=\"display:none;\"";
    public string zhichiview = "style=\"display:'';\"";
    public string zhangxiangli1view = "style=\"display:'';\"";
    public string zhangxiangli2view = "style=\"display:'none';\"";
    public string zhangxiangli3view = "style=\"display:'none';\"";
    protected void Page_Load(object sender, EventArgs e)
    {
        //hangye.AutoPostBack = true;
        if (!Common.isAdminLogin())
        {
            Response.Redirect("login.aspx");
            Response.End();
        }
        try
        {
            this.content1.Text = Request.Form["content"];
        }
        catch { }
        try
        {
            id = int.Parse(Request.QueryString["id"].ToString());

            if (!Page.IsPostBack)
            {
                DataTable dt;
                //NewMethod(1, CheckBoxList1);
                //NewMethod(2, CheckBoxList2);
                //NewMethod(3, CheckBoxList3);
                //NewMethod(4, CheckBoxList4);
                //setting(51, cengji);  //发文单位所属层级
                //NewMethodRBL(51, cengjicb);// 单位层级
                sheng(2, gldiqu); //发文的部委/省级
                //setting(2, gldiqu);  //地区
                //setting(50, gongcheng); //政策所属：五大工程，其他
                //setting(6, lingyu); //政策所属：十大重点领域
                NewMethod(6, hangyec);//政策所属：十大重点领域
                NewMethodRBL(50, gongchengc);//政策所属：五大工程
                //hangye2(52, hangyecl);//政策所属：针对行业
                NewMethod(52, hangyecbl); //针对行业
                //settingzcjs(52); //针对行业
                //settinghy2js(); //行业小类
                ZhuanXiang2class(11743, zhangxiang1);
                ZhuanXiang2class(11744, zhangxiang2);
                ZhuanXiang2class(11745, zhangxiang3);
                if (id == 0)
                {
                    faburiqi.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    youxiaoqi.Text = DateTime.Now.ToString("yyyy-MM-dd");
                }
                else
                {
                    dt = NewMethod1();//更改提交
                }
            }
            //表格是否显示
            classid = int.Parse(Request.QueryString["class"].ToString());
            page = int.Parse(Request.QueryString["page"].ToString());
        }
        catch { }


    }

    private DataTable NewMethod1()
    {
        DataTable dt = DBZhengce.getDataTable("select * from zhengce where   id=" + id);
        if (dt.Rows.Count > 0)
        {
            DataRow dr = dt.Rows[0];
            mingcheng.Text = dr["mingcheng"].ToString();
            fawendanwen.Text = dr["fawendanwen"].ToString();
            wenhao.Text = dr["wenhao"].ToString();
            try { faburiqi.Text = Convert.ToDateTime(dr["faburiqi"]).ToString("yyyy-MM-dd"); } catch { }

            //cengji.Text = dr["cengji"].ToString();
            //SetChecked(cengjicb, dr["cengji"].ToString(), ",");
            //cengjicb.SelectedValue = dr["cengji"].ToString();
            //gldiqu.Text = dr["buwensheng"].ToString(); //地区
            SetChecked(gldiqu, dr["buwensheng"].ToString(), ",");
            //gongcheng.Text = dr["gongcheng"].ToString();
            //lingyu.Text = dr["lingyu"].ToString();
            //SetChecked(gongchengc, dr["gongcheng"].ToString(), ",");
            //gongchengc.SelectedValue = dr["gongcheng"].ToString();
            SetCheckedrbl(gongchengc, dr["gongcheng"].ToString(), ","); //五大工程
            SetChecked(hangyec, dr["lingyu"].ToString(), ",");

            SetChecked(hangyecbl, dr["hangye"].ToString(), ",");
            if (dr["cengji"].ToString() == "11392")//层级
            {
                cengji1.Checked = true;
                zhichiview = "";
                gongchengview = "style=\"display:none;\"";
            }
            else if (dr["cengji"].ToString() == "11393")
            {
                cengji2.Checked = true;
                buweiview = "";
                if (dr["buwei"].ToString() == "11397")//工信部
                {
                    buwei1.Checked = true;
                    gongchengview = "";
                }
                else if (dr["buwei"].ToString() == "11398")
                {
                    buwei2.Checked = true;
                    gongchengview = "style=\"display:none;\"";
                }
                else if (dr["buwei"].ToString() == "11399")
                {
                    buwei3.Checked = true;
                    gongchengview = "style=\"display:none;\"";

                }
                else if (dr["buwei"].ToString() == "11400")
                {
                    buwei4.Checked = true;
                    gongchengview = "style=\"display:none;\"";
                }
                else if (dr["buwei"].ToString() == "11401")
                {
                    buwei5.Checked = true;
                    kejiview = "";
                    gongchengview = "style=\"display:none;\"";
                    if (dr["zxleixing"].ToString() == "1")//专项
                    {
                        zhichiview = "style=\"display:none;\"";
                        zhengcel1.Checked = true;
                        xiangmuliview = "";

                        if (dr["xmleixing"].ToString() == "11743")//项目类型
                        {
                            xiangmu1.Checked = true;
                            zhangxiang1.SelectedValue = dr["zxming"].ToString();//专项名称   
                            zhangxiangli1view = "";
                            zhangxiangli2view = "style=\"display:none;\"";
                            zhangxiangli3view = "style=\"display:none;\"";
                        }
                        else if (dr["xmleixing"].ToString() == "11744")//项目类型
                        {
                            xiangmu2.Checked = true;
                            zhangxiang2.SelectedValue = dr["zxming"].ToString();//专项名称
                            zhangxiangli1view = "style=\"display:none;\"";
                            zhangxiangli2view = "";
                            zhangxiangli3view = "style=\"display:none;\"";
                        }
                        else if (dr["xmleixing"].ToString() == "11745")//项目类型
                        {
                            xiangmu3.Checked = true;
                            zhangxiang3.SelectedValue = dr["zxming"].ToString();//专项名称
                            zhangxiangli1view = "style=\"display:none;\"";
                            zhangxiangli2view = "style=\"display:none;\"";
                            zhangxiangli3view = "";
                        }
                        //专项年份
                        if (dr["zxnian"].ToString() == "2018")
                        {
                            Radio3.Checked = true;
                        }
                        else if (dr["zxnian"].ToString() == "2016")
                        {
                            Radio1.Checked = true;
                        }
                        else if (dr["zxnian"].ToString() == "2017")
                        {
                            Radio2.Checked = true;
                        }
                        else if (dr["zxnian"].ToString() == "2019")
                        {
                            Radio4.Checked = true;
                        }
                        ketifx.Text = dr["ketifx"].ToString();//课题方向
                        shishizq.Text = dr["shishizq"].ToString();//实施周期

                    }
                    else if (dr["zxleixing"].ToString() == "0")//非专项
                    {
                        zhengcel2.Checked = true;
                        zhichiview = "";
                    }
                }
            }
            else if (dr["cengji"].ToString() == "11394")
            {
                cengji3.Checked = true;
                difangview = "";
                zhichiview = "";
                gongchengview = "style=\"display:none;\"";
            }


            

            //gldiqu.SelectedValue = dr["gldiqu"].ToString();
            if (dr["gldixiang"].ToString().Contains("支持园区"))
            {
                jishu1_1.Checked = true;
            }
            else if (dr["gldixiang"].ToString().Contains("支持企业"))
            {
                jishu1_2.Checked = true;
            }
            else if (dr["gldixiang"].ToString().Contains("科研单位"))
            {
                jishu1_3.Checked = true;
            }
            if (dr["zczijin"].ToString() == "1")
            {
                RadioButton4.Checked = true;
            }
            else if (dr["zczijin"].ToString() == "0")
            {
                RadioButton5.Checked = true;
            }



            if (dr["psfangshi"].ToString().Contains("招投标"))
            {
                RadioButton1.Checked = true;
            }
            else if (dr["psfangshi"].ToString().Contains("评审"))
            {
                RadioButton2.Checked = true;
            }
            else if (dr["psfangshi"].ToString().Contains("其他"))
            {
                RadioButton3.Checked = true;
                Text3.Value = dr["psfangshi"].ToString().Substring((dr["psfangshi"].ToString().IndexOf("其他：") + 3));
            }
            //HttpContext.Current.Request["cengji"]
            //yiju.Text = dr["yiju"].ToString();
            //mubiao.Text = dr["mubiao"].ToString();

            youxiaoqi.Text = dr["youxiaoqi"].ToString();
            //hangye.Text = dr["hangye"].ToString();
            //SetChecked(hangyecl, dr["hangye"].ToString(), ",");
            //tbhangye.Text = dr["hangye"].ToString();
            //hangyejs.Value = dr["hangye"].ToString();
            //chanpin.Text = dr["chanpin"].ToString();
            zcywdizhi.Text = dr["zcywdizhi"].ToString();
            //mubiao.Text = dr["mubiao"].ToString();

            content.Text = dr["zhengceqw"].ToString().Replace("&emsp ", "&emsp;");
            url.Text = dr["url"].ToString();
            ////pic.Text = dr["pic"].ToString();
            //en.Checked = (dr["en"].ToString() == "0" ? false : true);
            //sel.Checked = (dr["sel"].ToString() == "0" ? false : true);
            try
            {
                faburiqi.Text = DateTime.Parse(dr["cdate"].ToString()).ToString("yyyy-MM-dd");
            }
            catch { }
            //try
            //{
            //    classn.Items.FindByValue(dr["classid"].ToString()).Selected = true;
            //}
            //catch { }
            //SetChecked(CheckBoxList1, dr["typename"].ToString(), ",");
            //SetChecked(CheckBoxList2, dr["typename"].ToString(), ",");
            //SetChecked(CheckBoxList3, dr["typename"].ToString(), ",");
            //SetChecked(CheckBoxList4, dr["typename"].ToString(), ",");
        }

        return dt;
    }

    private DataTable NewMethod2()
    {
        DataTable dt = DBZhengce.getDataTable("select * from zhengce where   id=" + id);
        if (dt.Rows.Count > 0)
        {
            DataRow dr = dt.Rows[0];
             
            //gongcheng.Text = dr["gongcheng"].ToString();
            //lingyu.Text = dr["lingyu"].ToString();
            //SetChecked(gongchengc, dr["gongcheng"].ToString(), ",");
            //gongchengc.SelectedValue = dr["gongcheng"].ToString();
            
            if (dr["cengji"].ToString() == "11392")//层级
            {
                
                zhichiview = "";
                gongchengview = "style=\"display:none;\"";
            }
            else if (dr["cengji"].ToString() == "11393")
            {
               
                buweiview = "";
                if (dr["buwei"].ToString() == "11397")//工信部
                {                    
                    gongchengview = "";
                    zhichiview = "";
                    xiangmuliview= "style=\"display:none;\"";
                    xiangmuliview = "style=\"display:none;\"";
                }
                else if (dr["buwei"].ToString() == "11398")//发改委
                {
                    zhichiview = "";
                    gongchengview = "style=\"display:none;\"";
                    xiangmuliview = "style=\"display:none;\"";
                }
                else if (dr["buwei"].ToString() == "11399")
                {
                    zhichiview = "";
                    gongchengview = "style=\"display:none;\"";
                    xiangmuliview = "style=\"display:none;\"";
                }
                else if (dr["buwei"].ToString() == "11400")
                {
                    zhichiview = "";
                    gongchengview = "style=\"display:none;\"";
                    xiangmuliview = "style=\"display:none;\"";
                }
                else if (dr["buwei"].ToString() == "11401")//科技部
                {                    
                    kejiview = "";
                    zhichiview = "";
                     
                    gongchengview = "style=\"display:none;\"";
                    if (dr["zxleixing"].ToString() == "1")//专项
                    {
                        xiangmuliview = "";
                        zhichiview = "style=\"display:none;\"";

                    }
                    else if (dr["zxleixing"].ToString() == "0")//非专项
                    {
                        zhichiview = "";
                        xiangmuliview = "style=\"display:none;\"";
                    }
                }
            }
            else if (dr["cengji"].ToString() == "11394")
            {               
                difangview = "";
                zhichiview = "";
                gongchengview = "style=\"display:none;\"";
            }


            
        }

        return dt;
    }

    private DataTable ZhuanXiang2class(int itype, DropDownList cl)
    {
        string sql = "";
        sql = "SELECT  [ID]      ,[HangYeID]      ,[Name]      ,[state]        FROM  [dbo].[ZhuanXiang2]    where [HangYeID] = '" + itype + "'  and state=1";
        DataTable dt = DBZhengce.getDataTable(sql);

        cl.DataSource = dt;
        cl.DataTextField = "Name";//绑定的字段名
        cl.DataValueField = "id";//绑定的值
        cl.DataBind();
        return dt;
    }
    private DataTable hangye2class(int itype, CheckBoxList cl)
    {
        string sql = "";
        sql = "SELECT  [ID]      ,[HangYeID]      ,[Name]      ,[state]        FROM  [dbo].[HangYe2]    where [HangYeID] = '" + itype + "'  and state=1";
        DataTable dt = DBZhengce.getDataTable(sql);

        cl.DataSource = dt;
        cl.DataTextField = "Name";//绑定的字段名
        cl.DataValueField = "id";//绑定的值
        cl.DataBind();
        return dt;
    }

    public static string SetCheckedrbl(RadioButtonList checkList, string selval, string separator)
    {
        selval = separator + selval + separator;        //例如："0,1,1,2,1"->",0,1,1,2,1,"
        for (int i = 0; i < checkList.Items.Count; i++)
        {
            checkList.Items[i].Selected = false;
            string val = separator + checkList.Items[i].Value + separator;
            if (selval.IndexOf(val) != -1)
            {
                checkList.Items[i].Selected = true;
                selval = selval.Replace(val, separator);        //然后从原来的值串中删除已经选中了的
                if (selval == separator)        //selval的最后一项也被选中的话，此时经过Replace后，只会剩下一个分隔符
                {
                    selval += separator;        //添加一个分隔符
                }
            }
        }
        selval = selval.Substring(1, selval.Length - 2);        //除去前后加的分割符号
        return selval;
    }
    public static string SetChecked(CheckBoxList checkList, string selval, string separator)
    {
        selval = separator + selval + separator;        //例如："0,1,1,2,1"->",0,1,1,2,1,"
        for (int i = 0; i < checkList.Items.Count; i++)
        {
            checkList.Items[i].Selected = false;
            string val = separator + checkList.Items[i].Value + separator;
            if (selval.IndexOf(val) != -1)
            {
                checkList.Items[i].Selected = true;
                selval = selval.Replace(val, separator);        //然后从原来的值串中删除已经选中了的
                if (selval == separator)        //selval的最后一项也被选中的话，此时经过Replace后，只会剩下一个分隔符
                {
                    selval += separator;        //添加一个分隔符
                }
            }
        }
        selval = selval.Substring(1, selval.Length - 2);        //除去前后加的分割符号
        return selval;
    }
    private DataTable NewMethodRBL(int itype, RadioButtonList cl)
    {
        string sql = "";
        sql = "SELECT  [ID]      ,[SettingID]      ,[Name]      ,[state]    FROM  [dbo].[Setting]    where SettingID = '" + itype + "'  and state=1";
        DataTable dt = DBZhengce.getDataTable(sql);

        cl.DataSource = dt;
        cl.DataTextField = "Name";//绑定的字段名
        cl.DataValueField = "id";//绑定的值
        cl.DataBind();
        return dt;
    }
    private DataTable NewMethod(int itype, CheckBoxList cl)
    {
        string sql = "";
        sql = "SELECT  [ID]      ,[SettingID]      ,[Name]      ,[state]    FROM  [dbo].[Setting]    where SettingID = '" + itype + "'  and state=1";
        DataTable dt = DBZhengce.getDataTable(sql);

        cl.DataSource = dt;
        cl.DataTextField = "Name";//绑定的字段名
        cl.DataValueField = "id";//绑定的值
        cl.DataBind();
        return dt;
    }

    private DataTable sheng(int itype, CheckBoxList cl)
    {
        string sql = "";
        sql = "SELECT   [id],[name]  FROM [dbo].[sheng]  where state=1";
        DataTable dt = DBZhengce.getDataTable(sql);

        cl.DataSource = dt;
        cl.DataTextField = "name";//绑定的字段名
        cl.DataValueField = "id";//绑定的值
        cl.DataBind();
        return dt;
    }
    //public static string SetChecked(CheckBoxList checkList, string selval, string separator)
    //{
    //    selval = separator + selval + separator;        //例如："0,1,1,2,1"->",0,1,1,2,1,"
    //    for (int i = 0; i < checkList.Items.Count; i++)
    //    {
    //        checkList.Items[i].Selected = false;
    //        string val = separator + checkList.Items[i].Value + separator;
    //        if (selval.IndexOf(val) != -1)
    //        {
    //            checkList.Items[i].Selected = true;
    //            selval = selval.Replace(val, separator);        //然后从原来的值串中删除已经选中了的
    //            if (selval == separator)        //selval的最后一项也被选中的话，此时经过Replace后，只会剩下一个分隔符
    //            {
    //                selval += separator;        //添加一个分隔符
    //            }
    //        }
    //    }
    //    selval = selval.Substring(1, selval.Length - 2);        //除去前后加的分割符号
    //    return selval;
    //}

    //private DataTable NewMethod(int itype, CheckBoxList cl)
    //{
    //    string sql = "";
    //    sql = "select * from zqhl_class where en>0 and typeid='" + itype + "' and fl<>4 order by typeid asc,fl asc,sx asc";//fl=4为专家类别
    //    DataTable dt = DBC.getDataTable(sql);


    //    cl.DataSource = dt;
    //    cl.DataTextField = "class";//绑定的字段名
    //    cl.DataValueField = "id";//绑定的值
    //    cl.DataBind();



    //    return dt;
    //}

    //protected void scfile_Click(object sender, EventArgs e)
    //{
    //    msg.Text = "";
    //    if (!upfile.HasFile) { msg.Text = "请选择文件后上传"; return; }
    //    if (upfile.FileBytes.Length > 1024 * 1024)
    //    { msg.Text = "文件不能大于1M"; return; }
    //    string ext = upfile.FileName.Substring(upfile.FileName.Length - 3).ToLower();
    //    if (ext != "png" && ext != "jpg" && ext != "gif")
    //    {
    //        msg.Text = "文件格式只能是png或jpg或gif"; return;
    //    }
    //    string file = DateTime.Now.ToString("yyyMMddHHmmss.ss");
    //    string filename = Server.MapPath("../upload/") + file + "." + ext;
    //    upfile.SaveAs(filename);
    //    pic.Text = "/upload/" + file + "." + ext;
    //}

    protected void bc_Click(object sender, EventArgs e)
    {

        //foreach (Control ct in this.form1.Controls)//循环查询表单里面的子控件
        //{
        //    if (ct.GetType().ToString().Equals("System.Web.UI.WebControls.CheckBox"))
        //    {
        //        CheckBox cb = (CheckBox)ct;
        //        if (cb.Checked == true)
        //        {
        //            stext+=(cb.Text + "<br/>");//这句换成取值
        //        }
        //    }
        //}
        ///Response.Write(stext);

        string classid = "0";
        string cbtext1 = "";

        string sql = "";


        try { Convert.ToDateTime(faburiqi.Text); }
        catch
        {
            msg.Text = "发布日期,时间格式不正确 ！";
            return;
        }
        if (mingcheng.Text == "")
        {
            msg.Text = "政策名称，不能为空";
            return;
        }
        if (wenhao.Text == "")
        {
            msg.Text = "政策文号，不能为空";
            return;
        }
        if (fawendanwen.Text == "")
        {
            msg.Text = "发文单位，不能为空";
            return;
        }

        //if (buwensheng.Text == "")
        //{
        //    msg.Text = "层级，不能为空";
        //    return;
        //}
        //单位层级
        string cengji = "";        

        if(Request.Form["cengji"]!=null)
        {
            cengji = (int.Parse( Request.Form["cengji"])+11391).ToString();
        }
         

        if (cengji == "")
        {
            msg.Text = "层级，不能为空";
            return;
        }
        //国家部委
        string buwei = "";
        if (Request.Form["buwei"] != null)
        {
            buwei = (int.Parse(Request.Form["buwei"]) + 11396).ToString();
        }

        
        string xmleixing = "";
        if (Request.Form["xiangmu"] != null)
        {
            xmleixing = (int.Parse(Request.Form["xiangmu"]) + 11742).ToString();
        }
        string zxming = "";
        if(xmleixing== "11743")
        {
            zxming = zhangxiang1.SelectedValue;
        }
        else if (xmleixing == "11744")
        {
            zxming = zhangxiang2.SelectedValue;
        }
        else if (xmleixing == "11745")
        {
            zxming = zhangxiang3.SelectedValue;
        }

        string zxnian = "";
        if (Request.Form["zxnian"] != null)
        {
            zxnian = (int.Parse(Request.Form["zxnian"]) ).ToString();
        }

        //if (cbtext1 == "")
        //{
        //    msg.Text = "必须选择一个分类";
        //    return;
        //}
        //cbtext1 = cbtext1.Substring(0, cbtext1.Length - 1);
        string cbtexthy = "";
        for (int i = 0; i < hangyec.Items.Count; i++)
        {
            if (hangyec.Items[i].Selected == true)
            {
                //这个打勾的
                cbtexthy += hangyec.Items[i].Value + ",";
                //if (classid == "0")
                //{
                //    classid = hangye.Items[i].Value;
                //}
            }
            else
            {
                //这是没打的
            }
        }
        string gongcheng = "";
        for (int i = 0; i < gongchengc.Items.Count; i++)
        {
            if (gongchengc.Items[i].Selected == true)
            {
                //这个打勾的
                gongcheng += gongchengc.Items[i].Value + ",";
                //if (classid == "0")
                //{
                //    classid = hangye.Items[i].Value;
                //}
            }
            else
            {
                //这是没打的
            }
        }
        string gldiqusheng = "";
        for (int i = 0; i < gldiqu.Items.Count; i++)
        {
            if (gldiqu.Items[i].Selected == true)
            {
                //这个打勾的
                gldiqusheng += gldiqu.Items[i].Value + ",";
                //if (classid == "0")
                //{
                //    classid = hangye.Items[i].Value;
                //}
            }
            else
            {
                //这是没打的
            }
        }
        //for (int i = 0; i < cengjicb.Items.Count; i++)
        //{
        //    if (cengjicb.Items[i].Selected == true)
        //    {
        //        //这个打勾的
        //        cengji = cengjicb.Items[i].Value;
        //        //if (classid == "0")
        //        //{
        //        //    classid = hangye.Items[i].Value;
        //        //}
        //    }
        //    else
        //    {
        //        //这是没打的
        //    }
        //}
        string hangye = "";
        string hangyesql = "delete from [dbo].[hangye] where zhengceid='" + id + "';";
        for (int i = 0; i < hangyecbl.Items.Count; i++)
        {
            if (hangyecbl.Items[i].Selected == true)
            {
                //这个打勾的
                hangye += hangyecbl.Items[i].Value + ",";
                //if (classid == "0")
                //{
                //    classid = hangye.Items[i].Value;
                //}
                hangyesql += "INSERT INTO [dbo].[hangye]([zhengceid],[hangye]) VALUES ('"+ id + "','"+ hangyecbl.Items[i].Value + "');";
            }
            else
            {
                //这是没打的
            }
        }
        if (hangye == "")
        {
            msg.Text = "必须选择一个或多个行业";
            return;
        }
        int zczijin = 0;
        //string gldixiang = "";
        if (RadioButton4.Checked == true) { zczijin = 1; }//固定资产投资比例
        if (RadioButton5.Checked == true) { zczijin = 0; }//一定额度资金

        //string zcjibie = "";
        //string gldixiang = "";

        //if (RadioButton6.Checked == true) { zcjibie += "国家中央支持,"; }//资产/规模要求
        //if (RadioButton7.Checked == true) { zcjibie += "部委支持,"; }//企业性质要求
        //if (RadioButton8.Checked == true) { zcjibie += "地方支持,"; }//技术要求

        string gldixiang = "";
        //string gldixiang = "";

        if (jishu1_1.Checked == true) { gldixiang += "园区"; }//组织机构/企业
        if (jishu1_2.Checked == true) { gldixiang += "企业"; }//个人
        if (jishu1_3.Checked == true) { gldixiang += " 科研单位"; }//个人
        //hangye = tbhangye.Text;
        ////hangye = hangyejs.Value;
        string psfangshi = "";
        //string gldixiang = "";

        if (RadioButton1.Checked == true) { psfangshi = "招投标"; }//招投标
        if (RadioButton2.Checked == true) { psfangshi = "评审"; }//评审          
        if (RadioButton3.Checked == true) { psfangshi = "其他：" + Text3.Value.ToString(); }//其他

        int zxleixing = -1;
        if (zhengcel1.Checked) { zxleixing = 1; }//专项
        if (zhengcel2.Checked) { zxleixing = 0; }//非专项

        if (id == 0)
        {
            //sql = "insert into zqhl_news([title],[content],classid,qz,pic,en,sel,writer,author,typename,cdate)values(";
            //sql += "'" + Common.strFilter(title.Text) + "','" + Common.strFilter(content1.Text.Replace("&emsp ", "&emsp;")) + "'," + classid + "," + Common.strFilter(qz.Text);
            //sql += ",'" + Common.strFilter(pic.Text) + "'," + ((en.Checked) ? "1" : "0") + "," + ((sel.Checked) ? "1" : "0") + ",'" + Common.strFilter(writer.Text) + "','" + Session["adminloginuser"] + "','" + cbtext1 + "','" + cdate.Text + "')";
            sql = @"INSERT INTO [dbo].[zhengce]
                           ([mingcheng]           ,[wenhao]           ,[faburiqi]           ,[fawendanwen]
                           ,[cengji] ,[buwei]           ,[buwensheng]           ,[gongcheng]           ,[lingyu]
                           ,[youxiaoqi]           ,[hangye]
                           ,[zhengceqw]           ,[zcywdizhi]         ,[state]           ,[createdate]
                           ,[userid],[caiji],[gldiqu]，[zczijin]
                           ,[zcjibie],[gldixiang],[psfangshi],[zxleixing]
                           ,[xmleixing],[zxming],[zxnian],[ketifx],[shishizq])
                     VALUES
                           ('" + Common.strFilter(mingcheng.Text) + "','" + Common.strFilter(wenhao.Text) + "','" + Common.strFilter(faburiqi.Text) + "','" + Common.strFilter(fawendanwen.Text) + "','" +
                                 Common.strFilter(cengji) + "','" + Common.strFilter(buwei) + "','" + Common.strFilter(gldiqusheng) + "','" + Common.strFilter(gongcheng) + "','" + Common.strFilter(cbtexthy) + "','" +
                                 Common.strFilter(youxiaoqi.Text) + "','" + Common.strFilter(hangye) + "','" +
                                 Common.strFilter(content1.Text.Replace("&emsp ", "&emsp;")) + "','" + Common.strFilter(zcywdizhi.Text) + "',1,'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                                 + "','" + Session["userid"] + "',0，'" + Common.strFilter(gldiqusheng) + "','" + zczijin 
                                 + "','" + cengji + "','" + gldixiang + "','"+ psfangshi + "','"+ zxleixing + "','"
                                 + xmleixing + "','"+ zxming + "','"+ zxnian + "','" + Common.strFilter(ketifx.Text) + "','" + Common.strFilter(shishizq.Text) + "');";
            //以下字段编辑时上传
            //// ,[glchanneng]           ,[gldiqu]           ,[gldixiang]
            //               ,[zcshijian]           ,[zcshuoming]           ,[gmfangshi]           ,[gmshuoming]
            //               ,[psfangshi]           ,[psshuoming]           ,[shenbaotj]           ,[sbjttiaojian]
            //               ,[xzchanneng]           ,[xzdiqu]           ,[xzzhuti]           ,[xzfashism]
            //              

        }
        else
        {
            //sql = "update zqhl_news set [title]='" + Common.strFilter(title.Text) + "',[content]='" + Common.strFilter(content1.Text.Replace("&emsp ", "&emsp;")) + "',classid=" + classid + ",qz=" + Common.strFilter(qz.Text);
            //sql += ",pic='" + Common.strFilter(pic.Text) + "',en=" + ((en.Checked) ? "1" : "0") + ",sel=" + ((sel.Checked) ? "1" : "0") + ",writer='" + Common.strFilter(writer.Text) + "',typename='" + cbtext1 + "',cdate='" + cdate.Text + "'  where id=" + id;
            sql = @"update zhengce set [mingcheng]='" + Common.strFilter(mingcheng.Text) + "',[wenhao]='" + Common.strFilter(wenhao.Text) + "' ,[faburiqi]='" + Common.strFilter(faburiqi.Text) + "',[fawendanwen]='" + Common.strFilter(fawendanwen.Text)
                + "' ,[cengji] ='" + Common.strFilter(cengji) + "' ,[buwei] ='" + Common.strFilter(buwei) + "'          ,[buwensheng]    ='" + Common.strFilter(gldiqusheng) + "'        ,[gongcheng]='" + Common.strFilter(gongcheng) + "'            ,[lingyu]='" + Common.strFilter(cbtexthy)
                + "' ,[youxiaoqi]='" + Common.strFilter(youxiaoqi.Text) + "', [gldiqu]='" + Common.strFilter(gldiqusheng) + "' ,  [zczijin]='" + zczijin + "' ,         [hangye]='" + Common.strFilter(hangye)
                + "' ,[zhengceqw] ='" + Common.strFilter(content1.Text.Replace("&emsp ", "&emsp;")) + "'           ,[zcywdizhi] ='" + Common.strFilter(zcywdizhi.Text) + "' ,[zcjibie]='" + Common.strFilter(cengji) + "'   ,[gldixiang]='" + Common.strFilter(gldixiang) 
                + "' ,[psfangshi]='" + Common.strFilter(psfangshi) + "' ,[zxleixing]='" + zxleixing + "' ,[xmleixing]='" + Common.strFilter(xmleixing) + "' ,zxming='"+ zxming + "',zxnian='"+ zxnian + "',ketifx='"+ Common.strFilter(ketifx.Text) + "',shishizq='" + Common.strFilter(shishizq.Text) + "'          ,[update]='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where id=" + id + ";";
        }
        int count = DBZhengce.getRowsCount(sql+ hangyesql);
        if (count > 0) msg.Text = "保存成功"; else msg.Text = "保存失败" + sql+ hangyesql;
        //NewMethod2();
        if (cengji== "11392")//层级
        {

            zhichiview = "";
            gongchengview = "style=\"display:none;\"";
        }
        else if (cengji== "11393")
        {

            buweiview = "";
            if (buwei == "11397")//工信部
            {
                gongchengview = "";
                zhichiview = "";
                xiangmuliview = "style=\"display:none;\"";
                xiangmuliview = "style=\"display:none;\"";
            }
            else if (buwei == "11398")//发改委
            {
                zhichiview = "";
                gongchengview = "style=\"display:none;\"";
                xiangmuliview = "style=\"display:none;\"";
            }
            else if (buwei == "11399")
            {
                zhichiview = "";
                gongchengview = "style=\"display:none;\"";
                xiangmuliview = "style=\"display:none;\"";
            }
            else if (buwei == "11400")
            {
                zhichiview = "";
                gongchengview = "style=\"display:none;\"";
                xiangmuliview = "style=\"display:none;\"";
            }
            else if (buwei == "11401")//科技部
            {
                kejiview = "";
                zhichiview = "";

                gongchengview = "style=\"display:none;\"";
                if (zxleixing == 1)//专项
                {
                    xiangmuliview = "";
                    zhichiview = "style=\"display:none;\"";
                    if (xmleixing == "11743")//项目类型
                    {
                        xiangmu1.Checked = true;
                        zhangxiang1.SelectedValue = zxming;//专项名称
                        zhangxiangli1view = "";
                        zhangxiangli2view = "style=\"display:none;\"";
                        zhangxiangli3view = "style=\"display:none;\"";
                    }
                    else if (xmleixing == "11744")//项目类型
                    {
                        xiangmu2.Checked = true;
                        zhangxiang2.SelectedValue = zxming;//专项名称
                        zhangxiangli1view = "style=\"display:none;\"";
                        zhangxiangli2view = "";
                        zhangxiangli3view = "style=\"display:none;\"";
                    }
                    else if (xmleixing == "11745")//项目类型
                    {
                        xiangmu3.Checked = true;
                        zhangxiang3.SelectedValue = zxming;//专项名称
                        zhangxiangli1view = "style=\"display:none;\"";
                        zhangxiangli2view = "style=\"display:none;\"";
                        zhangxiangli3view = "";
                    }
                }
                else if (zxleixing == 0)//非专项
                {
                    zhichiview = "";
                    xiangmuliview = "style=\"display:none;\"";
                }
            }
        }
        else if (cengji== "11394")
        {
            difangview = "";
            zhichiview = "";
            gongchengview = "style=\"display:none;\"";
        }
        Response.Write("<script language=javascript >window.opener.location.reload('zhengce.aspx'); </script > ");
    }

    private void setting(int itype, DropDownList ddlname)
    {
        DataTable dt = DBqiye.getDataTable("SELECT  [ID],[Name]  FROM [dbo].[Setting] where SettingID=" + itype + "");
        ddlname.DataSource = dt;
        ddlname.DataTextField = "Name";
        ddlname.DataValueField = "ID";
        ddlname.DataBind();
        ddlname.Items.Insert(0, new ListItem("==未选择==", "0"));
        ddlname.SelectedValue = "";
    }
    private void settingzc(int itype, DropDownList ddlname)
    {
        DataTable dt = DBZhengce.getDataTable("SELECT  [ID],[Name]  FROM [dbo].[Setting] where SettingID=" + itype + " and state=1 order by id ");
        ddlname.DataSource = dt;
        ddlname.DataTextField = "Name";
        ddlname.DataValueField = "ID";
        ddlname.DataBind();
        ddlname.Items.Insert(0, new ListItem("==未选择==", "0"));
        ddlname.SelectedValue = "";
        if (itype == 52)
        {
            foreach (DataRow dr in dt.Rows)
            {
                classjs += "\"" + dr["Name"].ToString() + "\",";
            }
            classjs = classjs.Substring(0, classjs.Length - 1);
            classjs = "[\"请选择行业\"," + classjs + "]";
        }

    }
    private void settingzcjs(int itype)
    {
        DataTable dt = DBZhengce.getDataTable("SELECT  [ID],[Name]  FROM [dbo].[Setting] where SettingID=" + itype + " and state=1 order by id ");

        if (itype == 52)
        {
            foreach (DataRow dr in dt.Rows)
            {
                classjs += "\"" + dr["Name"].ToString() + "\",";
            }
            classjs = classjs.Substring(0, classjs.Length - 1);
            classjs = "[\"请选择行业\"," + classjs + "]";
        }

    }
    private void settinghy(int itype, DropDownList ddlname)
    {
        DataTable dt = DBZhengce.getDataTable("SELECT  [ID],[Name]  FROM [dbo].[HangYe2] where HangYeID=" + itype + " and state=1");
        ddlname.DataSource = dt;
        ddlname.DataTextField = "Name";
        ddlname.DataValueField = "ID";
        ddlname.DataBind();
        //ddlname.Items.Insert(0, new ListItem("==未选择==", "0"));
        //ddlname.SelectedValue = "";
    }

    private void settinghy2js()
    {
        DataTable dt = DBZhengce.getDataTable("SELECT  [HangYeID],[Name]  FROM [dbo].[HangYe2] where   state=1 order by HangYeID");
        //class2js = "[";
        string id = string.Empty;
        foreach (DataRow dr in dt.Rows)
        {
            if (id != dr["HangYeID"].ToString())
            {
                if (id == null || id == string.Empty)
                {
                    class2js += "[";
                }
                else
                {
                    class2js = class2js.Substring(0, class2js.Length - 1);
                    class2js += "],[";
                }

                id = dr["HangYeID"].ToString();
            }

            class2js += "\"" + dr["Name"].ToString() + "\",";

        }
        class2js = class2js.Substring(0, class2js.Length - 1);
        class2js = "[  [\"请选择小类\"]," + class2js + "]]";
    }

    //protected void hangye_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    //hangye2(52, hangyecl);
    //    //hangye2class(Convert.ToInt16( hangye.SelectedValue), hangyecl);
    //    settinghy(Convert.ToInt16(hangye.SelectedValue), hangye2);
    //    tbhangye.Focus();
    //}
    //protected void hangyeadd_Click(object sender, EventArgs e)
    //{
    //    tbhangye.Text += hangye2.SelectedItem.Text+",";
    //    tbhangye.Focus();
    //}

    protected void Button1_Click(object sender, EventArgs e)
    {
        for (int b = 0; b < gldiqu.Items.Count; b++)
        {
            this.gldiqu.Items[b].Selected = true;
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        for (int b = 0; b < gldiqu.Items.Count; b++)
        {
            this.gldiqu.Items[b].Selected = false;
        }
    }
}