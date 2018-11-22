using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
public partial class QiangJiAdmin_gongyeadd : System.Web.UI.Page
{
    public int typeid = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Common.isAdminLogin())
        {
            Response.Redirect("login.aspx");
            Response.End();
        }
        if (!Page.IsPostBack)
        {
            setting(47, chanye); //工业强基十六条龙计划
            //company(); //绑定公司名称
            //setting(22, JieDuan); //成果阶段
            //setting(44, LeiBie); //成果性质
            setting(2, DiZhi); //地址
            //setting(11, ShuiPing); //成果水平
            //setting(23, MiJi); //成果密级
            //setting(24, ShuXing); //成果密级
            //setting(25, ChuangXinXingShi); //成果创新形式
            //setting(26, NoYingYYin); //成果创新形式
            //setting(29, YingYongQingKuang); //成果创新形式
            //setting(30, JiaoYiState); //成果交易
            //setting(3, hangye); //行业
            setting(21, qiangji); //网站类型
            //yewubd();//业务
            //NewMethod(6, YingYongLingYu);//应用领域
            NewMethod(3, lingyu);//行业
            setting(2, ddldiqu);//所在地区

            setting(4, ddlqiyexz);//企业性质
            setting(6, hangye);//行业领域
            //setting(40, ddlbiaoqian);  //成果标签
        }

    }
    private DataTable NewMethod(int itype, CheckBoxList cl)
    {
        string sql = "";
        sql = "SELECT  [ID]      ,[SettingID]      ,[Name]      ,[state]    FROM[ZhongQiHuiLian].[dbo].[Setting]    where SettingID = '" + itype + "'  and state=1";
        DataTable dt = DBC.getDataTable(sql);

        cl.DataSource = dt;
        cl.DataTextField = "Name";//绑定的字段名
        cl.DataValueField = "id";//绑定的值
        cl.DataBind();
        return dt;
    }

    //private void yewubd()
    //{
    //    string sql = "SELECT [UserID],[RealName]        FROM[dbo].[User]  where Enabled=1  ";
    //    if (Session["title"].ToString() != "3")
    //    {
    //        sql += "  and  UserID='" + Session["userid"] + "' ";
    //    }
    //    DataTable dt = DBqiye.getDataTable(sql);
    //    yewu.DataSource = dt;
    //    yewu.DataTextField = "RealName";
    //    yewu.DataValueField = "UserID";
    //    yewu.DataBind();
    //    if (Session["title"].ToString() == "3")
    //    {
    //        yewu.Items.Insert(0, new ListItem("==请选择==", ""));
    //        yewu.SelectedValue = "";
    //    }

    //}

    private void setting(int itype, DropDownList ddlname)
    {
        string sql = "SELECT  [ID],[Name]  FROM [dbo].[Setting] where SettingID=" + itype + " and state=1 ";
        if (itype == 21)
        {
            sql += " and id between 170 and 173 ";
        }
        {
            sql += " order by id desc";
        }

        DataTable dt = DBqiye.getDataTable(sql);
        ddlname.DataSource = dt;
        ddlname.DataTextField = "Name";
        ddlname.DataValueField = "ID";
        ddlname.DataBind();
        ddlname.Items.Insert(0, new ListItem("==请选择==", "0"));
        ddlname.SelectedValue = "0";
        if (itype == 30)
        {
            ddlname.SelectedValue = "206";
        }
    }
    //private void company()
    //{
    //    string sql = "SELECT  [ID] ,[Name] FROM  [dbo].[Company] where 1=1 ";
    //    if (Session["title"].ToString() != "3")
    //    {
    //        sql += " and UserID='" + Session["userid"] + "' ";
    //    }
    //    DataTable dt = DBqiye.getDataTable(sql);
    //    ChiYouRenID.DataSource = dt;
    //    ChiYouRenID.DataTextField = "Name";
    //    ChiYouRenID.DataValueField = "ID";
    //    ChiYouRenID.DataBind();
    //    //ddlCompany.Items.Insert(0, new ListItem("==请选择==", ""));
    //    //ddlCompany.SelectedValue = "";
    //}

    protected void Button1_Click(object sender, EventArgs e)
    {
        //if (ddlCompany.SelectedValue == "")
        //{
        //    Label1.Text = ("请选择企业！");
        //    return;
        //}

        if (pname.Text.Length == 0)
        {
            Label1.Text = ("产品名称不允许为空！");
            return;
        }
        else
        {
            DataTable dt = DBqiye.getDataTable("SELECT [MemberName]  FROM  [dbo].[product] where [pname]='" + pname.Text + "' and  price='"+ price.Text + "' and kucun='"+ kucun.Text + "'");
            if (dt != null && dt.Rows.Count > 0)
            {
                Label15.Text = ("产品名称,价格和库存都一样不能存储");
                tblogin.Focus();
                tblogin.ForeColor = Color.Red;
                return;
            }

        }
        try
        {
            Convert.ToSingle(price.Text);
        }
        catch
        {
            Label1.Text = ("价格,必须为数字！");
            return;
        }
        try
        {
            Convert.ToSingle(marketprice.Text);
        }
        catch
        {
            Label1.Text = ("市场价格,必须为数字！");
            return;
        }
        try
        {
            Convert.ToInt32(kucun.Text);
        }
        catch
        {
            Label1.Text = ("库存,必须为数字！");
            return;
        }

        
        //try
        //{
        //    Convert.ToSingle(ZiJin.Text);
        //}
        //catch
        //{
        //    Label1.Text = ("设备投资,必须为数字！");
        //    return;
        //}
        //try
        //{
        //    Convert.ToSingle(tblirui.Text);
        //}
        //catch
        //{
        //    Label1.Text = ("新增利润,必须为数字！");
        //    return;
        //}
        //try
        //{
        //    Convert.ToSingle(tbjieye.Text);
        //}
        //catch
        //{
        //    Label1.Text = ("节省成本,必须为数字！");
        //    return;
        //}


        //if (webtype.SelectedValue == "0")
        //{
        //    Label1.Text = ("强基分类必须选择");
        //    return;
        //}
        //if (ShuiPing.SelectedValue == "0")
        //{
        //    Label1.Text = ("成果水平必须选择");
        //    return;
        //}

        string classid = "0";
        string cbtext1 = "";
        //for (int i = 0; i < YingYongLingYu.Items.Count; i++)
        //{
        //    if (YingYongLingYu.Items[i].Selected == true)
        //    {
        //        //这个打勾的
        //        cbtext1 += YingYongLingYu.Items[i].Value + ",";
        //        if (classid == "0")
        //        {
        //            classid = YingYongLingYu.Items[i].Value;
        //        }
        //    }
        //    else
        //    {
        //        //这是没打的
        //    }
        //}
        string cbtexthy = "";
        for (int i = 0; i < lingyu.Items.Count; i++)
        {
            if (lingyu.Items[i].Selected == true)
            {
                //这个打勾的
                cbtexthy += lingyu.Items[i].Value + ",";
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
        string XingZhiBiao = "";
        
        this.content1.Text = Request.Form["content"];

        string sql = "";
        {
            // sql = @"INSERT INTO [dbo].[Results]
            //([RName]           ,[JianJie]
            //,[JieShao]       ,[JieDuan]
            //,[LeiBie]           ,[DiZhi]                     ,[ZiJin]

            //,[ShuiPing]           ,[MiJi]           ,[ShuXing]           ,[ChuangXinXingShi]
            //,[YingYongQingKuang]           ,[NoYingYYin]                  ,[KeHuJingLi]
            //,[JiaoYiState]           ,[Update]           ,[userid]           ,[state],hangye,webtype,indexlocation,biaoqian,zhongyao,wanzheng)
            //    VALUES ('" + Common.strFilter(RName.Text) + "','" + Common.strFilter(JianJie.Text) + "','" +
            //    Common.strFilter(content1.Text) + "','" + Common.strFilter(JieDuan.Text) + "','" +
            //    Common.strFilter(LeiBie.SelectedValue) + "','" + Common.strFilter(DiZhi.SelectedValue) + "','" + Common.strFilter(ZiJin.Text) + "','" +

            //    Common.strFilter(ShuiPing.SelectedValue) + "','" + Common.strFilter(MiJi.SelectedValue) + "','" + Common.strFilter(ShuXing.SelectedValue) + "','" + Common.strFilter(ChuangXinXingShi.SelectedValue) + "','" +
            //    Common.strFilter(YingYongQingKuang.SelectedValue) + "','" + Common.strFilter(NoYingYYin.SelectedValue) + "','" + Session["userid"] + "','" +
            //    Common.strFilter(JiaoYiState.SelectedValue) + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + Session["userid"] + "',1,'" + Common.strFilter(cbtexthy) + "','" + Common.strFilter(webtype.SelectedValue) + "','" + ((indexlocation.SelectedValue)) + "','" + biaoqian.Text + "',11,11)";
            sql = @"INSERT INTO [dbo].[product]
           ([pname]           ,[price]           ,[marketprice]           ,[orderno]
           ,[xinghao]           ,[pinpai]           ,[xilie]           ,[pinlei]
           ,[danwen]           ,[shangjie]           ,[kucun]           ,[xiangqing]
           ,[guige]           ,[updates]           ,[state]           ,[createtime]
           ,[userid]           ,[companyid]           ,[qiangji] ,[Qiangji2]          ,[dizhi]
           ,[lingyu]           ,[chanye]           ,[indexview])
           VALUES ('" + Common.strFilter(pname.Text)  + "','" + Common.strFilter(price.Text) + "','" + Common.strFilter(marketprice.Text) + "','" + Common.strFilter(orderno.Text)
            + "','" + Common.strFilter(xinghao.Text) + "','" + Common.strFilter(pinpai.Text) + "','" + Common.strFilter(xilie.Text) + "','" + Common.strFilter(pinlei.Text)
           + "','" + Common.strFilter(danwen.Text) + "',null,'" + Common.strFilter(kucun.Text) + "','" + Common.strFilter(content1.Text)
           + "','" + Common.strFilter(guige.Text) + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',1,'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
           + "','" + Session["userid"] + "',null,'" + Common.strFilter(qiangji.SelectedValue) + "','" + Common.strFilter(qiangji2.SelectedValue) + "','" + Common.strFilter(DiZhi.SelectedValue)
           + "','" + Common.strFilter(lingyu.SelectedValue) + "','" + Common.strFilter(chanye.SelectedValue) + "','" + Common.strFilter((indexview.Checked) ? "1" : "0") 
           + "') ";
        }
        int id = DBqiye.getRowsreturnid(sql + "Select @@Identity");
        companyid.Text = id.ToString();
        
        sql = "";
        if (id > 0) Label1.Text = "保存成功" + sql; else Label1.Text = "保存失败" + sql;
        ///cid = Request.QueryString["id"].ToString();
         //图片上传
        if (!upfile.HasFile) { Label1.Text = "请选择文件后上传"; return; }
        if (upfile.FileBytes.Length > 1024 * 1024)
        { Label1.Text = "文件不能大于1M"; return; }
        string ext = upfile.FileName.Substring(upfile.FileName.Length - 3).ToLower();
        if (ext != "png" && ext != "jpg" && ext != "gif")
        {
            Label1.Text = "文件格式只能是png或jpg"; return;
        }
        string file = DateTime.Now.ToString("yyyMMddHHmmss.ss");
        string filename = Server.MapPath("~/upload/") + file + "." + ext;
        //upfile.SaveAs(filename);
        string filename1 = Server.MapPath("~/yuan/upload/") + file + "." + ext;
        upfile.SaveAs(filename1);
        pic.Text = "/upload/" + file + "." + ext;
        imgtext.BuildWatermark(filename1, Server.MapPath("/") + "/images/shunyin.png", "www.kjcgjy.com", filename);
        //imgtext.AddWaterText(filename1, "www.kjcgjy.com", filename, 255, 50);
        //imgh.ImageUrl = "/upload/" + file + "." + ext;
        //DBC.getRowsCount("update users set headimg='" + headimg.Text + "' where id=" + Session["userid"].ToString());
        //imgh.ImageUrl = imgh.ImageUrl;
        //Session["headimg"] = imgh.ImageUrl;
        //Global.ROOM.updateheadIMG(ulong.Parse(Session["userid"].ToString()), imgh.ImageUrl);
        Label1.Text = "上传成功";
        ///cid = Request.QueryString["id"].ToString();
        sql = "";
        {
            sql = @"INSERT INTO [dbo].[productPic]           ([pID]           ,[FileName]                    ,[datetime]           ,[state],[viewindex])VALUES('"
            + id + "','" + Common.strFilter(pic.Text) + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',1,1)";
        }
        int count = DBqiye.getRowsCount(sql);
        sql = "";
        if (count > 0) Label1.Text = "保存成功" + sql; else Label1.Text = "保存失败" + sql;

    }


    //protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (RadioButtonList1.SelectedIndex == 0)
    //    {
    //        //ChiYouRenID.Text = "企业";
    //        company();
    //        this.content.Text = Request.Form["content"];
    //    }
    //    else
    //    {
    //        //ChiYouRenID.Text = "个人";
    //        person();
    //        this.content.Text = Request.Form["content"];
    //    }
    //}
    //private void person()
    //{
    //    string sql = "SELECT id,CName FROM [dbo].[ResultRen] where state=1 ";
    //    if (Session["title"].ToString() != "3")
    //    {
    //        sql += " and UserID='" + Session["userid"] + "' ";
    //    }
    //    DataTable dt = DBqiye.getDataTable(sql);
    //    ChiYouRenID.DataSource = dt;
    //    ChiYouRenID.DataTextField = "CName";
    //    ChiYouRenID.DataValueField = "ID";
    //    ChiYouRenID.DataBind();
    //    //ddlCompany.Items.Insert(0, new ListItem("==请选择==", ""));
    //    //ddlCompany.SelectedValue = "";
    //}
    protected void hangye_SelectedIndexChanged(object sender, EventArgs e)
    {
        typeid = 2;
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

    protected void hangye2_SelectedIndexChanged(object sender, EventArgs e)
    {
        typeid = 2;
        DataTable dt;
        dt = DBqiye.getDataTable(@"SELECT TOP 1 *  FROM [dbo].HangYe2 where id =" + hangye2.SelectedValue + "   ");

        try
        {
            if (dt.Rows.Count > 0)
            {
                string sShangShi = "否";
                DataRow dr = dt.Rows[0];
                Label4.Text = dr["Description"].ToString(); ;
            }
        }
        catch
        {
            //myGrid. = 0;
            Label4.Text = "";
        }
        finally
        {

        }
    }
    protected void Button21_Click(object sender, EventArgs e)
    {
        // Response.Write("正在插入数据");
        if (tbname.Text.Length == 0)
        {
            Label15.Text = ("企业名称,不允许为空");
            return;
        }
        else
        {
            DataTable dt = DBqiye.getDataTable("SELECT [Name]  FROM  [dbo].[Company] where [Name]='" + tbname.Text + "'");
            if (dt != null && dt.Rows.Count > 0)
            {
                Label15.Text = ("企业名称,已经被占用请使用其它名称");
                tbname.Focus();
                tbname.ForeColor = Color.Red;
                return;
            }

        }
        if (tblogin.Text.Length == 0)
        {
            Label15.Text = ("登陆名,不允许为空");
            tblogin.Focus();
            return;
        }
        else
        {
            DataTable dt = DBqiye.getDataTable("SELECT [MemberName]  FROM  [dbo].[Company] where [MemberName]='" + tblogin.Text + "'");
            if (dt != null && dt.Rows.Count > 0)
            {
                Label15.Text = ("登陆名,已经被占用请使用其它名称");
                tblogin.Focus();
                tblogin.ForeColor = Color.Red;
                return;
            }

        }

        if (tbpass.Text.Length == 0)
        {
            Label15.Text = ("密码,不允许为空");
            return;
        }
        if (ddldiqu.SelectedValue == "0")
        {
            Label15.Text = ("必须选择一个地区");
            return;
        }
        if (ddlqiyexz.SelectedValue == "0")
        {
            Label15.Text = ("必须选择一个企业性质");
            return;
        }

        if (hangye.SelectedValue == "0")
        {
            Label15.Text = ("必须选择一个行业");
            return;
        }
        //if (hangye2.SelectedValue == "0")
        //{
        //    Label15.Text = ("必须选择一个二行业");
        //    return;
        //}
        string sql = "";
        {
            if (Session["userid"].ToString() == "13")
            {
                sql = @"INSERT INTO[dbo].[Company]
                       ([Name]           ,[MemberName]           ,[Password]           ,[Address]
                       ,[ZipCode]           ,[LegalPerson]           ,[LegalPersonTel]           ,[Contact]
                       ,[ContactTel]           ,[BusinessScope]           ,[Region]           ,[EnterpriseType]
                       ,[KeyAreas]                   ,[HasQuoted]           ,[CreateDate]
                       ,Incentive_HasStock,state)     VALUES
                       ('" + Common.strFilter(tbname.Text) + "','" + Common.strFilter(tblogin.Text) + "','" + MD5.CreateMD5Hash(tbpass.Text) + "','" + Common.strFilter(tbadd.Text) + "', '" +
                       Common.strFilter(tbzipcode.Text) + "','" + Common.strFilter(tbfaren.Text) + "','" + Common.strFilter(tbfarentel.Text) + "','" + Common.strFilter(tblianxi.Text) + "','" +
                       Common.strFilter(tblianxitel.Text) + "','" + Common.strFilter(jingyingfw.Text) + "','" + ddldiqu.SelectedValue + "','" + ddlqiyexz.SelectedValue + "','" +
                       hangye.SelectedValue + "'," + ((ishangshi.Checked) ? "1" : "0") + ",'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',0,1)";
            }
            else
            {
                sql = @"INSERT INTO[dbo].[Company]
                       ([Name]           ,[MemberName]           ,[Password]           ,[Address]
                       ,[ZipCode]           ,[LegalPerson]           ,[LegalPersonTel]           ,[Contact]
                       ,[ContactTel]           ,[BusinessScope]           ,[Region]           ,[EnterpriseType]
                       ,[KeyAreas]                    ,[HasQuoted]           ,[CreateDate]
                       ,Incentive_HasStock,state,UserID)     VALUES
                       ('" + Common.strFilter(tbname.Text) + "','" + Common.strFilter(tblogin.Text) + "','" + MD5.CreateMD5Hash(tbpass.Text) + "','" + Common.strFilter(tbadd.Text) + "', '" +
                       Common.strFilter(tbzipcode.Text) + "','" + Common.strFilter(tbfaren.Text) + "','" + Common.strFilter(tbfarentel.Text) + "','" + Common.strFilter(tblianxi.Text) + "','" +
                       Common.strFilter(tblianxitel.Text) + "','" + Common.strFilter(jingyingfw.Text) + "','" + ddldiqu.SelectedValue + "','" + ddlqiyexz.SelectedValue + "','" +
                       hangye.SelectedValue + "'," + ((ishangshi.Checked) ? "1" : "0") + ",'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',0,1," + Session["userid"] + ")";
            }
        }

        int id = DBqiye.getRowsreturnid(sql + "Select @@Identity");
        sql = "UPDATE [dbo].[product]   SET       [companyid] = " + id + " WHERE  id="+ companyid.Text  + "";
        id = DBqiye.getRowsCount(sql);
        if (id > 0) Label15.Text = "保存成功"; else Label15.Text = "保存失败" + sql;
    }


    protected void qiangji_SelectedIndexChanged(object sender, EventArgs e)
    {
        qiangji2fl(qiangji.SelectedValue, 0);
    }
    private void qiangji2fl(string sid, int itype)
    {
        string sql = string.Empty;

        sql = "SELECT [ID] ,[Name]  FROM [dbo].[Qiangji2] where HangYeID=" + sid + "";

        DataTable dt = DBqiye.getDataTable(sql);
        qiangji2.DataSource = dt;
        qiangji2.DataTextField = "Name";
        qiangji2.DataValueField = "ID";
        qiangji2.DataBind();
        qiangji2.Items.Insert(0, new ListItem("==请选择==", ""));
        if (itype == 0)
        {
            qiangji2.SelectedValue = "";
        }
        else
        {
            qiangji2.SelectedValue = itype.ToString();
        }

    }
}