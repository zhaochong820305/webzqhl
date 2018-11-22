using System;
using System.Collections.Generic;
 
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using Top.Api;
using Top.Api.Request;
using Top.Api.Response;
public partial class admin_qiyeedit : System.Web.UI.Page
{
    public string scompanyid = "";
    public int typeid = 1;

    string urlstr = "http://gw.api.taobao.com/router/rest"; //alibaba.aliqin.fc.sms.num.query
    //string appkey = "23785452";
    string appkey = "23785452";
    string secret = "007e8086d110b5038e04ab2bdd8ebeb0";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Common.isAdminLogin())
        {
            Response.Redirect("login.aspx");
            Response.End();

        }
        //string sid = "0";
        if (Request.QueryString["id"] != null && (!string.IsNullOrEmpty(Request.QueryString["id"])) && Request.QueryString["id"].Length > 0)
        {
            scompanyid = Request.QueryString["id"].ToString();
        }
        else if (Session["sid"] != null && Session["sid"].ToString() != "" && Session["sid"].ToString().Length > 0)
        {
            scompanyid = Session["sid"].ToString();
        }
        else
        {
            Label1.Text = "请选择企业，否则无法显示";
            return;
        }
        if (Request.QueryString["edit"] != null && Request.QueryString["edit"] == "shenhe")
        {
            Response.Write(Request.QueryString["edit"] + Request.QueryString["id"].ToString());
            DBqiye.getRowsCount("update [Company] set state=1,userid='" + Session["userid"] + "' where id=" + Request.QueryString["id"].ToString() + "; update[Results] set  userid = '" + Session["userid"] + "' where userid is null and id=" + Request.QueryString["id"].ToString() + ";");
            //Response.Redirect("ResultWait.aspx");
            //DBqiye.getRowsCount();

            string phone = Request.QueryString["phone"].ToString();
            string typeid= Request.QueryString["typeid"].ToString(); 
            //if(typeid=="4")
            {
                getYanzheng(phone);
            }            
            Response.Redirect("qygl.aspx");
        }
        if (!Page.IsPostBack)
        {
            yewubd();//业务
            Recommend();//推荐人
            NewMethod(1, CheckBoxList1);
            setting(2, ddldiqu);//所在地区
            setting(4, ddlqiyexz);//企业性质
            setting(6, hangye);//行业领域
            setting(21, ddlLianMengType);//联盟分类
            setting(19, hezuozt);

            BindGrid();

        }


    }

    public string getYanzheng(string phone)
    {
        ITopClient client = new DefaultTopClient(urlstr, appkey, secret);
        AlibabaAliqinFcSmsNumSendRequest req = new AlibabaAliqinFcSmsNumSendRequest();
        Random rd = new Random();
        //Response.Write(rd.Next().ToString().Substring(0, 6));
        //string scode = rd.Next().ToString().Substring(1, 4);//随机验码
        req.Extend = "123456";
        req.SmsType = "normal";
        req.SmsFreeSignName = "科技成果交易网";
        //req.SmsParam = "{\"code\":\"1234\",\"product\":\"alidayu\"}";
        req.SmsParam = "{\"name\":\"" + phone + "\"}";
        req.RecNum = phone;//手机号 //13701122500
        //req.SmsTemplateCode = "SMS_63820762";
        req.SmsTemplateCode = "SMS_94215014";// "SMS_72830026";
        AlibabaAliqinFcSmsNumSendResponse rsp = client.Execute(req);
        //Response.Write(rsp.Body);
        if (rsp.Body.Contains("true"))
        {
            //Response.Write("sms send true" + scode);
            return phone;
        }
        else
        {
            //Response.Write("sms send false:" + rsp.Body + scode);
            return "error";
        }
        //0107285666712^1109815260840trueeibuufdkzges
        //0107285744472^1109815397495true439gth0asr0y
        //0107286008344^1109815661785true3gtqrtumy02l
    }
    private DataTable NewMethod(int itype, CheckBoxList cl)
    {
        string sql = "";
        sql = "select id,name+cast(x  as varchar )+'*'+cast(y  as varchar ) name  from webtype ";
        DataTable dt = DBC.getDataTable(sql);
        

        cl.DataSource = dt;
        cl.DataTextField = "Name";//绑定的字段名
        cl.DataValueField = "Id";//绑定的值
        cl.DataBind();


        

        return dt;
    }
    private void Bindcaiwu(string sid)
    {

        DataTable dt;
        dt = DBqiye.getDataTable("select * from [CaiWu] where CompanyID=" + sid + " ");
        try
        {
            GridView1.DataSource = dt;
            GridView1.DataBind();
            ///PgCount = GridView1.PageCount;
            //PgIndex = GridView1.PageIndex; GridView1 = dt.Rows.Count;
            if (dt.Rows.Count == 0) Label8.Text = " 没有查询到财务数据";
        }
        catch
        {
            Label8.Text = " 财务数据查询错误";
            //myGrid. = 0;
            //GridView1.DataSource = dt;
            //GridView1.DataBind();
        }
        finally
        {

        }
    }
    
    private void BindXuQiu(string sid)
    {

        DataTable dt;
        dt = DBqiye.getDataTable("select t.*  from [XuQiu] t   where CompanyID=" + sid + " ");
        try
        {
            GridView3.DataSource = dt;
            GridView3.DataBind();
            ///PgCount = GridView1.PageCount;
            //PgIndex = GridView1.PageIndex; GridView1 = dt.Rows.Count;
            if (dt.Rows.Count == 0) Label10.Text = " 没有查询到需求信息";
        }
        catch
        {
            Label10.Text = " 需求信息查询错误";
            //myGrid. = 0;
            //GridView1.DataSource = dt;
            //GridView1.DataBind();
        }
        finally
        {

        }
    }
    private void BindTeam(string sid)
    {

        DataTable dt;
        dt = DBqiye.getDataTable("select t.*,s.Name as zhiweiname  from [Team] t left join Setting s  on t.ZhiWei=s.id where CompanyID=" + sid + " ");
        try
        {
            GridView2.DataSource = dt;
            GridView2.DataBind();
            ///PgCount = GridView1.PageCount;
            //PgIndex = GridView1.PageIndex; GridView1 = dt.Rows.Count;
            if (dt.Rows.Count == 0) Label9.Text = " 没有查询到团队数据";
        }
        catch
        {
            Label9.Text = " 团队数据查询错误";
            //myGrid. = 0;
            //GridView1.DataSource = dt;
            //GridView1.DataBind();
        }
        finally
        {

        }
    }
    private void yewubd()
    {
        string sql = "SELECT [UserID],[RealName]        FROM[dbo].[User]  where Enabled=1 ";
        if (Session["title"].ToString() != "3" && Session["title"].ToString() != "5")
        {
            sql += "  and  UserID='" + Session["userid"] + "' ";
        }
        DataTable dt = DBqiye.getDataTable(sql);
        yewu.DataSource = dt;
        yewu.DataTextField = "RealName";
        yewu.DataValueField = "UserID";
        yewu.DataBind();
        yewu.Items.Insert(0, new ListItem("==请选择==", ""));
        yewu.SelectedValue = "";
    }
    private void Recommend()
    {
        DataTable dt = DBqiye.getDataTable("SELECT [ID] ,[Name] FROM [dbo].[Recommend]");
        tunjiang.DataSource = dt;
        tunjiang.DataTextField = "Name";
        tunjiang.DataValueField = "ID";
        tunjiang.DataBind();
        tunjiang.Items.Insert(0, new ListItem("==请选择==", ""));
        tunjiang.SelectedValue = "";
    }
    private void setting(int itype, DropDownList ddlname)
    {
        DataTable dt =  DBqiye.getDataTable("SELECT  [ID],[Name]  FROM [dbo].[Setting] where SettingID=" + itype + "");
        ddlname.DataSource = dt;
        ddlname.DataTextField = "Name";
        ddlname.DataValueField = "ID";
        ddlname.DataBind();
        ddlname.Items.Insert(0, new ListItem("==请选择==", "0"));
        ddlname.SelectedValue = "";
    }
    private void BindGrid()
    {
        string sid = scompanyid;
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
                //scompanyid = dr["id"].ToString();
                if (dr["HasQuoted"].ToString() == "True")
                { ishangshi.Checked = true; }
                else
                { ishangshi.Checked = false; }
                tbid.Text = sid;
                tbname.Text = dr["Name"].ToString();
                tblogin.Text = dr["MemberName"].ToString();
                tbadd.Text = dr["Address"].ToString();
                tbzipcode.Text = dr["ZipCode"].ToString();
                tbfaren.Text = dr["LegalPerson"].ToString();
                tbfarentel.Text = dr["LegalPersonTel"].ToString();
                tblianxi.Text = dr["Contact"].ToString();
                tblianxitel.Text = dr["ContactTel"].ToString();
                jingyingfw.Text = dr["BusinessScope"].ToString();
                ddldiqu.SelectedValue = dr["Region"].ToString();
                ddlqiyexz.Text = dr["EnterpriseType"].ToString();
                hangye.Text = dr["KeyAreas"].ToString();
                tbviewname.Text = dr["viewname"].ToString();
                //
                tbFangXiang.Text = dr["ShangShi_Target"].ToString();
                tbShiJian.Text = dr["ShangShi_Time"].ToString();
                tbZhuiBei.Text = dr["ShangShi_PrepareInfo"].ToString();
                //
                url.Text= dr["url"].ToString();
                if (dr["Incentive_HasStock"].ToString() == "True")
                { cbguquan.Checked = true; }
                else
                { cbguquan.Checked = false; }
                tbjili.Text = dr["Incentive_StockInfo"].ToString();
                tunjiang.SelectedValue = dr["RecommendID"].ToString();
                yewu.SelectedValue = dr["UserID"].ToString();
                hezuozt.Text = dr["MainDirection"].ToString();

                //需求信息
                //tbrongzi.Text = dr["rongzi"].ToString();
                //zhengce.Text = dr["zhengce"].ToString();
                //chanyelian.Text = dr["chanyelian"].ToString();
                //touzi.Text = dr["touzi"].ToString();
                //shouguo.Text = dr["shouguo"].ToString();
                //beishou.Text = dr["beishou"].ToString();
                try
                {
                    hangye2fl(dr["KeyAreas"].ToString(), Convert.ToInt16(dr["HangYe2ID"]));
                }
                catch
                {
                    hangye2fl(dr["KeyAreas"].ToString(), 0);
                }
                ddlLianMengType.SelectedValue = dr["lianmengtype"].ToString();
                pic.Text= dr["logo"].ToString();
                imgh.ImageUrl = pic.Text;
                Bindcaiwu(scompanyid);
                BindTeam(scompanyid);
                BindXuQiu(scompanyid);
                SetChecked(CheckBoxList1, dr["typeid"].ToString(), ",");
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        // Response.Write("正在插入数据");
        if (tbname.Text.Length == 0)
        {
            Label1.Text = ("企业名称,不允许为空");
            return;
        }
        else
        {
            DataTable dt = DBqiye.getDataTable("SELECT [Name]  FROM  [dbo].[Company] where [Name]='" + tbname.Text + "' and state=1");
            if (dt != null && dt.Rows.Count > 1)
            {
                Label1.Text = ("企业名称,已经被占用请使用其它名称");
                tbname.Focus();
                tbname.ForeColor = Color.Red;
                return;
            }

        }
        if (tblogin.Text.Length == 0)
        {
            Label1.Text = ("登陆名,不允许为空");
            tblogin.Focus();
            return;
        }
        else
        {
            DataTable dt = DBqiye.getDataTable("SELECT [MemberName]  FROM  [dbo].[Company] where [MemberName]='" + tblogin.Text + "' and state=1");
            if (dt != null && dt.Rows.Count > 1)
            {
                Label1.Text = ("登陆名,已经被占用请使用其它名称");
                tblogin.Focus();
                tblogin.ForeColor = Color.Red;
                return;
            }

        }

        string sql = "";
        string shangye2 = "";
        if (hangye2.SelectedValue == "")
        {
            shangye2 = "";
        }
        else
        {
            shangye2 = ", HangYe2ID = " + hangye2.SelectedValue + "";
        }
        if (tbpass.Text.Length == 0)
        {
            sql = @"UPDATE [dbo].[Company]
                       SET [Name] = '" + Common.strFilter(tbname.Text) + "',[MemberName] = '" + Common.strFilter(tblogin.Text) + "',[Address] ='" + Common.strFilter(tbadd.Text) + "' ,[ZipCode] ='" +
                   Common.strFilter(tbzipcode.Text) + "' ,[LegalPerson] = '" + Common.strFilter(tbfaren.Text) + "',[LegalPersonTel] = '" + Common.strFilter(tbfarentel.Text) + "',[Contact] = '" + Common.strFilter(tblianxi.Text) + "' ,[ContactTel] ='" +
                   Common.strFilter(tblianxitel.Text) + "' ,[BusinessScope] = '" + (jingyingfw.Text) + "' ,[Region] = '" + ddldiqu.SelectedValue + "',[EnterpriseType] ='" + ddlqiyexz.SelectedValue + "',[KeyAreas] ='" +
                   hangye.SelectedValue + "',[HasQuoted] = " + ((ishangshi.Checked) ? "1" : "0") + "" + shangye2 + ",[viewname]='"+tbviewname.Text+"' WHERE ID=" + tbid.Text + "";
        }
        else
        {
            sql = @"UPDATE [dbo].[Company]
                       SET [Name] = '" + Common.strFilter(tbname.Text) + "',[MemberName] = '" + Common.strFilter(tblogin.Text) + "',[Password] ='" + MD5.CreateMD5Hash(tbpass.Text) + "',[Address] ='" + Common.strFilter(tbadd.Text) + "' ,[ZipCode] ='" +
                  Common.strFilter(tbzipcode.Text) + "' ,[LegalPerson] = '" + Common.strFilter(tbfaren.Text) + "',[LegalPersonTel] = '" + Common.strFilter(tbfarentel.Text) + "',[Contact] = '" + Common.strFilter(tblianxi.Text) + "' ,[ContactTel] ='" +
                  Common.strFilter(tblianxitel.Text) + "' ,[BusinessScope] = '" + (jingyingfw.Text) + "' ,[Region] = '" + ddldiqu.SelectedValue + "',[EnterpriseType] ='" + ddlqiyexz.SelectedValue + "',[KeyAreas] ='" +
                  hangye.SelectedValue + "',[HasQuoted] = " + ((ishangshi.Checked) ? "1" : "0") + "" + shangye2 + ",[viewname]='" + tbviewname.Text + "' WHERE ID=" + tbid.Text + "";
        }
        int count = DBqiye.getRowsCount(sql);
        if (count > 0) Label1.Text = "保存成功"; else Label1.Text = "保存失败";
    }
    protected void btSave_Click(object sender, EventArgs e)
    {
        //Response.Write(tbFangXiang.Text);
        //Response.Write(tbShiJian.Text);
        //Response.Write(tbZhuiBei.Text);
        string sid = "0";
        if (Request.QueryString["id"] != null && (!string.IsNullOrEmpty(Request.QueryString["id"])) && Request.QueryString["id"].Length > 0)
        {
            sid = Request.QueryString["id"].ToString();
        }
        else
        {
            Label2.Text = "请选择企业，否则无法显示";
            return;
        }
        if (tbFangXiang.Text.Trim().Length == 0)
        {
            Label2.Text = "上市方向不允许为空";
            return;
        }
        if (tbShiJian.Text.Trim().Length == 0)
        {
            Label2.Text = "上市时间不允许为空";
            return;
        }
        if (tbZhuiBei.Text.Trim().Length == 0)
        {
            Label2.Text = "上市准备不允许为空";
            return;
        }
        string sql = @"UPDATE [dbo].[Company] SET   [ShangShi_Target] = '" + Common.strFilter(tbFangXiang.Text.Trim()) + "',[ShangShi_Time] = '" + Common.strFilter(tbShiJian.Text.Trim()) + "'      ,[ShangShi_PrepareInfo] = '" + Common.strFilter(tbZhuiBei.Text.Trim()) + "'  WHERE ID=" + sid + "";
        int count = DBqiye.getRowsCount(sql);
        typeid = 2;
        if (count > 0) Label2.Text = "保存成功"; else Label2.Text = "保存失败";

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        //Response.Write(tbFangXiang.Text);
        //Response.Write(tbShiJian.Text);
        //Response.Write(tbZhuiBei.Text);
        string sid = "0";
        if (Request.QueryString["id"] != null && (!string.IsNullOrEmpty(Request.QueryString["id"])) && Request.QueryString["id"].Length > 0)
        {
            sid = Request.QueryString["id"].ToString();
        }
        else
        {
            Label3.Text = ("请选择企业，否则无法显示");
            return;
        }
        string sql = @"UPDATE [dbo].[Company] SET   [Incentive_StockInfo] = '" + Common.strFilter(tbjili.Text.Trim()) + "',[Incentive_HasStock] = '" + ((cbguquan.Checked) ? "1" : "0") + "'       WHERE ID=" + sid + "";
        int count = DBqiye.getRowsCount(sql);
        typeid = 6;
        if (count > 0) Label3.Text = "保存成功"; else Label3.Text = "保存失败";
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        //Response.Write(tbFangXiang.Text);
        //Response.Write(tbShiJian.Text);
        //Response.Write(tbZhuiBei.Text);
        string sid = "0";
        if (Request.QueryString["id"] != null && (!string.IsNullOrEmpty(Request.QueryString["id"])) && Request.QueryString["id"].Length > 0)
        {
            sid = Request.QueryString["id"].ToString();
        }
        else
        {
            Label3.Text = ("请选择企业，否则无法显示");
            return;
        }
        string sql = @"UPDATE [dbo].[Company] SET   [RecommendID] = '" + Common.strFilter(tunjiang.SelectedValue) + "'    WHERE ID=" + sid + "";
        int count = DBqiye.getRowsCount(sql);
        typeid = 3;
        if (count > 0) Label4.Text = "保存成功"; else Label4.Text = "保存失败";
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        //Response.Write(tbFangXiang.Text);
        //Response.Write(tbShiJian.Text);
        //Response.Write(tbZhuiBei.Text);
        string sid = "0";
        if (Request.QueryString["id"] != null && (!string.IsNullOrEmpty(Request.QueryString["id"])) && Request.QueryString["id"].Length > 0)
        {
            sid = Request.QueryString["id"].ToString();
        }
        else
        {
            Label3.Text = ("请选择企业，否则无法显示");
            return;
        }
        string sql = @"UPDATE [dbo].[Company] SET   [UserID] = '" + Common.strFilter(yewu.SelectedValue) + "' WHERE ID=" + sid + "";
        int count = DBqiye.getRowsCount(sql);
        typeid = 3;
        if (count > 0) Label5.Text = "保存成功"; else Label5.Text = "保存失败";
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        //Response.Write(tbFangXiang.Text);
        //Response.Write(tbShiJian.Text);
        //Response.Write(tbZhuiBei.Text);
        string sid = "0";
        if (Request.QueryString["id"] != null && (!string.IsNullOrEmpty(Request.QueryString["id"])) && Request.QueryString["id"].Length > 0)
        {
            sid = Request.QueryString["id"].ToString();
        }
        else
        {
            Label3.Text = ("请选择企业，否则无法显示");
            return;
        }//hezuozt.Text = dr["KeyAreas"].ToString();
        string sql = @"UPDATE [dbo].[Company] SET   [MainDirection] = '" + Common.strFilter(hezuozt.SelectedValue) + "'     WHERE ID=" + sid + "";
        int count = DBqiye.getRowsCount(sql);
        typeid = 3;
        if (count > 0) Label6.Text = "保存成功"; else Label6.Text = "保存失败";
    }
    protected void Button7_Click(object sender, EventArgs e)
    {
        //Response.Write(tbFangXiang.Text);
        //Response.Write(tbShiJian.Text);
        //Response.Write(tbZhuiBei.Text);
        string sid = "0";
        if (Request.QueryString["id"] != null && (!string.IsNullOrEmpty(Request.QueryString["id"])) && Request.QueryString["id"].Length > 0)
        {
            sid = Request.QueryString["id"].ToString();
        }
        else
        {
            Label3.Text = ("请选择企业，否则无法显示");
            return;
        }
       
        string cbtext1 = "";
        for (int i = 0; i < CheckBoxList1.Items.Count; i++)
        {
            if (CheckBoxList1.Items[i].Selected == true)
            {
                //这个打勾的
                cbtext1 += CheckBoxList1.Items[i].Value + ",";
               
            }
            else
            {
                //这是没打的
            }
        }

        //hezuozt.Text = dr["KeyAreas"].ToString();
        string sql = @"UPDATE [dbo].[Company] SET   [logo] = '" + Common.strFilter(pic.Text) + "',[lianmengtype] = '" + Common.strFilter(ddlLianMengType.SelectedValue) + "',[webtype] = '" + Common.strFilter(cbtext1) + "' ,[url] = '" + Common.strFilter(url.Text) + "'    WHERE ID=" + sid + "";
        int count = DBqiye.getRowsCount(sql);
        typeid = 7;
        if (count > 0) msg.Text = "保存成功"; else msg.Text = "保存失败";
    }

    protected void Button8_Click(object sender, EventArgs e)
    {
        msg.Text = "";
        if (!upfile.HasFile) { msg.Text = "请选择文件后上传"; return; }
        if (upfile.FileBytes.Length > 1024 * 1024)
        { msg.Text = "文件不能大于1M"; return; }
        string ext = upfile.FileName.Substring(upfile.FileName.Length - 3).ToLower();
        if (ext != "png" && ext != "jpg" && ext != "gif")
        {
            msg.Text = "文件格式只能是png或jpg"; return;
        }
        string file = DateTime.Now.ToString("yyyMMddHHmmss.ss");
        string filename = Server.MapPath("~/upload/") + file + "." + ext;
        upfile.SaveAs(filename);
        pic.Text = "/upload/" + file + "." + ext;
        imgh.ImageUrl = "/upload/" + file + "." + ext;
        //DBC.getRowsCount("update users set headimg='" + headimg.Text + "' where id=" + Session["userid"].ToString());
        //imgh.ImageUrl = imgh.ImageUrl;
        //Session["headimg"] = imgh.ImageUrl;
        //Global.ROOM.updateheadIMG(ulong.Parse(Session["userid"].ToString()), imgh.ImageUrl);
        msg.Text = "上传成功";
        typeid = 7;
    }

    //protected void Button9_Click(object sender, EventArgs e)
    //{
    //    //Response.Write(tbFangXiang.Text);
    //    //Response.Write(tbShiJian.Text);
    //    //Response.Write(tbZhuiBei.Text);
    //    string sid = "0";
    //    if (Request.QueryString["id"] != null && (!string.IsNullOrEmpty(Request.QueryString["id"])) && Request.QueryString["id"].Length > 0)
    //    {
    //        sid = Request.QueryString["id"].ToString();
    //    }
    //    else
    //    {
    //        Label3.Text = ("请选择企业，否则无法显示");
    //        return;
    //    }//hezuozt.Text = dr["KeyAreas"].ToString();
    //    string sql = @"UPDATE [dbo].[Company] SET   [rongzi] = '" + Common.strFilter(tbrongzi.Text) + "',[zhengce] = '" + Common.strFilter(zhengce.Text) + "', [chanyelian] = '" + Common.strFilter(chanyelian.Text) + "',[beishou] = '" + Common.strFilter(beishou.Text) + "',[shouguo] = '" + Common.strFilter(shouguo.Text) + "', [touzi] = '" + Common.strFilter(touzi.Text) + "'     WHERE ID=" + sid + "";
    //    int count = DBqiye.getRowsCount(sql);
    //    typeid = 8;
    //    if (count > 0) Label10.Text = "保存成功"; else Label10.Text = "保存失败";
    //}

    protected void hangye_SelectedIndexChanged(object sender, EventArgs e)
    {
        hangye2fl(hangye.SelectedValue, 0);
    }

    private void hangye2fl(string sid, int itype)
    {
        string sql = string.Empty;

        sql = "SELECT [ID] ,[Name]  FROM [dbo].[HangYe2] where HangYeID=" + sid + "";

        DataTable dt = DBqiye.getDataTable(sql);
        hangye2.DataSource = dt;
        hangye2.DataTextField = "Name";
        hangye2.DataValueField = "ID";
        hangye2.DataBind();
        hangye2.Items.Insert(0, new ListItem("==请选择==", ""));
        if (itype == 0)
        {
            hangye2.SelectedValue = "";
        }
        else
        {
            hangye2.SelectedValue = itype.ToString();
        }

    }

    protected void sc_Command(object sender, CommandEventArgs e)
    {
        DBqiye.getRowsCount("delete from CaiWu where id=" + e.CommandArgument);
        //BindGrid();
        Bindcaiwu(scompanyid);

    }

    protected void xq_Command(object sender, CommandEventArgs e)
    {
        DBqiye.getRowsCount("delete from XuQiu where id=" + e.CommandArgument);
        //BindGrid();
        BindXuQiu(scompanyid);
        

    }
    protected void sc1_Command(object sender, CommandEventArgs e)
    {
        DBqiye.getRowsCount("delete from Team where id=" + e.CommandArgument);
        //BindGrid();
        BindTeam(scompanyid);
    }
    protected void hangye2_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dt;
        dt = DBqiye.getDataTable(@"SELECT TOP 1 *  FROM [dbo].HangYe2 where id =" + hangye2.SelectedValue + "   ");

        try
        {
            if (dt.Rows.Count > 0)
            {
                string sShangShi = "否";
                DataRow dr = dt.Rows[0];
                Label7.Text = dr["Description"].ToString(); ;
            }
        }
        catch
        {
            //myGrid. = 0;
            Label7.Text = "";
        }
        finally
        {

        }

    }
}