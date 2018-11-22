using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class admin_zhengceadd : System.Web.UI.Page
{
    public int id = 0;
    public string str = string.Empty;
    public int classid = 0;
    public int page = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
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
                NewMethodRBL(51, cengjicb);//政策所属：十大重点领域
                settingzc(2, buwensheng); //发文的部委/省级
                //setting(50, gongcheng); //政策所属：五大工程，其他
                //setting(6, lingyu); //政策所属：十大重点领域
                NewMethod(6, hangyec);//政策所属：十大重点领域
                NewMethod(50, gongchengc);//政策所属：五大工程
                //hangye2(52, hangyecl);//政策所属：针对行业
                settingzc(52, hangye); //针对行业
                if (id == 0)
                {
                    faburiqi.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    youxiaoqi.Text = DateTime.Now.ToString("yyyy-MM-dd");
                }
                else
                {
                    dt = DBZhengce.getDataTable("select * from zhengce where   id=" + id);
                    if (dt.Rows.Count > 0)
                    {
                        DataRow dr = dt.Rows[0];
                        mingcheng.Text = dr["mingcheng"].ToString();
                        fawendanwen.Text = dr["fawendanwen"].ToString();
                        wenhao.Text = dr["wenhao"].ToString();
                        try { faburiqi.Text = Convert.ToDateTime(dr["faburiqi"]).ToString("yyyy-MM-dd"); } catch { }

                        //cengji.Text = dr["cengji"].ToString();
                        //SetChecked(cengjicb, dr["cengji"].ToString(), ",");
                        cengjicb.SelectedValue = dr["cengji"].ToString();
                        buwensheng.Text = dr["buwensheng"].ToString();
                        //gongcheng.Text = dr["gongcheng"].ToString();
                        //lingyu.Text = dr["lingyu"].ToString();
                        SetChecked(gongchengc, dr["gongcheng"].ToString(), ",");
                        SetChecked(hangyec, dr["lingyu"].ToString(), ",");

                        yiju.Text = dr["yiju"].ToString();
                        mubiao.Text = dr["mubiao"].ToString();

                        youxiaoqi.Text = dr["youxiaoqi"].ToString();
                        //hangye.Text = dr["hangye"].ToString();
                        //SetChecked(hangyecl, dr["hangye"].ToString(), ",");
                        tbhangye.Text = dr["hangye"].ToString();
                        chanpin.Text = dr["chanpin"].ToString();
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
                }
            }

            classid = int.Parse(Request.QueryString["class"].ToString());
            page = int.Parse(Request.QueryString["page"].ToString());
        }
        catch { }


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

        if (buwensheng.Text == "")
        {
            msg.Text = "部委省级，不能为空";
            return;
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
        string cengji = "";
        for (int i = 0; i < cengjicb.Items.Count; i++)
        {
            if (cengjicb.Items[i].Selected == true)
            {
                //这个打勾的
                cengji = cengjicb.Items[i].Value ;
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
        string hangye = "";
        //////for (int i = 0; i < hangyecl.Items.Count; i++)
        //////{
        //////    if (hangyecl.Items[i].Selected == true)
        //////    {
        //////        //这个打勾的
        //////        hangye += hangyecl.Items[i].Value + ",";
        //////        //if (classid == "0")
        //////        //{
        //////        //    classid = hangye.Items[i].Value;
        //////        //}
        //////    }
        //////    else
        //////    {
        //////        //这是没打的
        //////    }
        //////}
        hangye = tbhangye.Text;
        if (hangye == "")
        {
            msg.Text = "必须选择一个或多个行业";
            return;
        }
        if (id == 0)
        {
            //sql = "insert into zqhl_news([title],[content],classid,qz,pic,en,sel,writer,author,typename,cdate)values(";
            //sql += "'" + Common.strFilter(title.Text) + "','" + Common.strFilter(content1.Text.Replace("&emsp ", "&emsp;")) + "'," + classid + "," + Common.strFilter(qz.Text);
            //sql += ",'" + Common.strFilter(pic.Text) + "'," + ((en.Checked) ? "1" : "0") + "," + ((sel.Checked) ? "1" : "0") + ",'" + Common.strFilter(writer.Text) + "','" + Session["adminloginuser"] + "','" + cbtext1 + "','" + cdate.Text + "')";
            sql = @"INSERT INTO [dbo].[zhengce]
                           ([mingcheng]           ,[wenhao]           ,[faburiqi]           ,[fawendanwen]
                           ,[cengji]           ,[buwensheng]           ,[gongcheng]           ,[lingyu]
                           ,[yiju]           ,[mubiao]           ,[youxiaoqi]           ,[hangye]
                           ,[chanpin]            ,[zhengceqw]           ,[zcywdizhi]         ,[state]           ,[createdate]
                                      ,[userid],[caiji])
                     VALUES
                           ('" + Common.strFilter(mingcheng.Text) + "','" + Common.strFilter(wenhao.Text) + "','" + Common.strFilter(faburiqi.Text) + "','" + Common.strFilter(fawendanwen.Text) + "','" +
                                 Common.strFilter(cengji) + "','" + Common.strFilter(buwensheng.Text) + "','" + Common.strFilter(gongcheng) + "','" + Common.strFilter(cbtexthy) + "','" +
                                 Common.strFilter(yiju.Text) + "','" + Common.strFilter(mubiao.Text) + "','" + Common.strFilter(youxiaoqi.Text) + "','" + Common.strFilter(hangye) + "','" +
                                 Common.strFilter(chanpin.Text) + "','" + Common.strFilter(content1.Text.Replace("&emsp ", "&emsp;")) + "','" + Common.strFilter(zcywdizhi.Text) + "',1,'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                                 + "','" + Session["userid"] + "',0)"; 
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
                + "' ,[cengji] ='" + Common.strFilter(cengji) + "'          ,[buwensheng]    ='" + Common.strFilter(buwensheng.Text) + "'        ,[gongcheng]='" + Common.strFilter(gongcheng) + "'            ,[lingyu]='" + Common.strFilter(cbtexthy) 
                + "'  ,[yiju]='" + Common.strFilter(yiju.Text) + "'            ,[mubiao]='" + Common.strFilter(mubiao.Text) + "'            ,[youxiaoqi]='" + Common.strFilter(youxiaoqi.Text) + "'            ,[hangye]='" + Common.strFilter(hangye)
                + "' ,[chanpin]='" + Common.strFilter(chanpin.Text) + "'             ,[zhengceqw] ='" + Common.strFilter(content1.Text.Replace("&emsp ", "&emsp;")) + "'           ,[zcywdizhi] ='" + Common.strFilter(zcywdizhi.Text) + "'                  ,[update]='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+ "' where id="+ id +"";
        }
        int count = DBZhengce.getRowsCount(sql);
        if (count > 0) msg.Text = "保存成功"; else msg.Text = "保存失败"+sql;
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
        DataTable dt = DBZhengce.getDataTable("SELECT  [ID],[Name]  FROM [dbo].[Setting] where SettingID=" + itype + " and state=1");
        ddlname.DataSource = dt;
        ddlname.DataTextField = "Name";
        ddlname.DataValueField = "ID";
        ddlname.DataBind();
        ddlname.Items.Insert(0, new ListItem("==未选择==", "0"));
        ddlname.SelectedValue = "";
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

    protected void hangye_SelectedIndexChanged(object sender, EventArgs e)
    {
        //hangye2(52, hangyecl);
        //hangye2class(Convert.ToInt16( hangye.SelectedValue), hangyecl);
        settinghy(Convert.ToInt16(hangye.SelectedValue), hangye2);
    }
    protected void hangyeadd_Click(object sender, EventArgs e)
    {
        tbhangye.Text += hangye2.SelectedItem.Text+",";
    }
}