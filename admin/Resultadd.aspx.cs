using System;
using System.Collections.Generic;
 
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

public partial class admin_cgjyadd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
         
        if (!Common.isAdminLogin())
        {
            Response.Redirect("login.aspx");
            Response.End();
        }
        if (!Page.IsPostBack)
        {
            //company(); //绑定公司名称
            setting(22, JieDuan); //成果阶段
            setting(44, LeiBie); //成果性质
            setting(2, DiZhi); //地址
            setting(11, ShuiPing); //成果水平
            setting(23, MiJi); //成果密级
            setting(24, ShuXing); //成果密级
            setting(25, ChuangXinXingShi); //成果创新形式
            setting(26, NoYingYYin); //成果创新形式
            setting(29, YingYongQingKuang); //成果创新形式
            setting(30, JiaoYiState); //成果交易
            //setting(3, hangye); //行业
            setting(21, webtype); //网站类型
            //yewubd();//业务
            //NewMethod(6, YingYongLingYu);//应用领域
            NewMethod(3, hangyec);//行业
            setting(40, ddlbiaoqian);  //成果标签
        }

    }
    private DataTable NewMethod(int itype, CheckBoxList cl)
    {
        string sql = "";
        sql = "SELECT  [ID]      ,[SettingID]      ,[Name]      ,[state]    FROM[ZhongQiHuiLian].[dbo].[Setting]    where SettingID = '"+ itype + "'  and state=1";
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
        if (itype == 40 && txtDemo.Text.Trim().Length>0)
        {
            sql += " and  [Name] like '%"+ txtDemo.Text.Trim() + "%' ";
        }
        else
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
            ddlname.SelectedValue="206";
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
        
        if (RName.Text.Length == 0)
        {
            Label1.Text = ("成果姓名不允许为空！");
            return;
        }
        try
        {
            Convert.ToSingle(ZiJin.Text);
        }
        catch
        {
            Label1.Text = ("资金,必须为数字！");
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

        if (JieDuan.SelectedValue == "0" )
        {
            Label1.Text = ("成果阶段必须选择");
            return;
        }
        
        if (LeiBie.SelectedValue == "0")
        {
            Label1.Text = ("成果类别必须选择");
            return;
        }
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
        if (YingYongQingKuang.SelectedValue == "205" && NoYingYYin.SelectedValue=="0")
        {
            Label1.Text = ("未应用时，必须选择未应用原因");
            return;
        }
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
        string XingZhiBiao = "";
        switch (LeiBie.SelectedValue)
        {
            case "211":
                XingZhiBiao = "A";
                break;
            case "210":
                XingZhiBiao = "B";
                break;
            case "214":
                XingZhiBiao = "D";
                break;
            case "215":
                XingZhiBiao = "E";
                break;
            case "216":
                XingZhiBiao = "F";
                break;
            case "217":
                XingZhiBiao = "G";
                break;
            case "1311":
                XingZhiBiao = "C";
                break;
            case "1312":
                XingZhiBiao = "A";
                break;
            case "1313":
                XingZhiBiao = "E";
                break;
            case "1314":
                XingZhiBiao = "F";
                break;
            default:
                XingZhiBiao = "C";
                break;
        }
        this.content1.Text = Request.Form["content"];

        string sql = "";
        {
            sql = @"INSERT INTO [dbo].[Results]
           ([RName]           ,[JianJie]
           ,[JieShao]       ,[JieDuan]
           ,[LeiBie]           ,[DiZhi]                     ,[ZiJin]
          
           ,[ShuiPing]           ,[MiJi]           ,[ShuXing]           ,[ChuangXinXingShi]
           ,[YingYongQingKuang]           ,[NoYingYYin]                  ,[KeHuJingLi]
           ,[JiaoYiState]           ,[Update]           ,[userid]           ,[state],hangye,webtype,indexlocation,biaoqian,zhongyao,wanzheng)
               VALUES ('" + Common.strFilter(RName.Text) + "','" + Common.strFilter(JianJie.Text) + "','"  +
               Common.strFilter(content1.Text) + "','" + Common.strFilter(JieDuan.Text) + "','" +
               Common.strFilter(LeiBie.SelectedValue) + "','" + Common.strFilter(DiZhi.SelectedValue) + "','" + Common.strFilter(ZiJin.Text) + "','" +
               //Common.strFilter(((ZhuanLi.Checked) ? "1" : "0")) + "','" + Common.strFilter(((ChaXin.Checked) ? "1" : "0")) + "','" + Common.strFilter(((JianCe.Checked) ? "1" : "0")) + "','" + ((ShiYongBao.Checked) ? "1" : "0") + "','" +
               Common.strFilter(ShuiPing.SelectedValue) + "','" + Common.strFilter(MiJi.SelectedValue) + "','" + Common.strFilter(ShuXing.SelectedValue) + "','" + Common.strFilter(ChuangXinXingShi.SelectedValue) + "','" +
               Common.strFilter(YingYongQingKuang.SelectedValue) + "','" + Common.strFilter(NoYingYYin.SelectedValue) + "','" + Session["userid"] + "','" +
               Common.strFilter(JiaoYiState.SelectedValue) + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + Session["userid"] + "',1,'" + Common.strFilter(cbtexthy) + "','" + Common.strFilter(webtype.SelectedValue) + "','"+ ((indexlocation.SelectedValue)) + "','" + biaoqian.Text + "',11,11)";
        }
        int id = DBqiye.getRowsreturnid(sql+ "Select @@Identity");
        //int Gid = Convert.ToInt32(DBqiye.ExecuteScalar());
        //sql = "";
        XingZhiBiao = XingZhiBiao + "";

        string sql1 = "update Results set RNo='"+ XingZhiBiao+ id + "' where ID='"+ id + "' ";
        DBqiye.getRowsCount(sql1);
        //合作方式
        {
            sql = @"update  [dbo].[Results] set [hezuotype1]='" + Common.strFilter(((hezuotype1.Checked) ? "1" : "0")) + "',[hezuotype2]='" + Common.strFilter(((hezuotype2.Checked) ? "1" : "0")) + "',[hezuotype3]='" + Common.strFilter(((hezuotype3.Checked) ? "1" : "0")) + "',[hezuotype4]='" + Common.strFilter(((hezuotype4.Checked) ? "1" : "0"))
            + "',[hezuocost1]='" + Common.strFilter(hezuocost1.Text) + "',[hezuocost2]='" + Common.strFilter(hezuocost2.Text) + "',[hezuocost3]='" + Common.strFilter((hezuocost3.Text)) + "' where id=" + id;
        }
        int count = DBqiye.getRowsCount(sql);
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
            sql = @"INSERT INTO [dbo].[ResultPic]           ([CID]           ,[FileName]                    ,[datetime]           ,[state],[viewindex])VALUES('"
            + id + "','" + Common.strFilter(pic.Text) + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',1,1)";
        }
        count = DBqiye.getRowsCount(sql);
        sql = "";
        if (count > 0) Label1.Text = "保存成功" + sql; else Label1.Text = "保存失败"  + sql;
    }
    protected void ddlbiaoqian_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!biaoqian.Text.Contains(ddlbiaoqian.SelectedItem.Text))
        {
            biaoqian.Text += ddlbiaoqian.SelectedItem.Text + ",";
        }

    }
    protected void Button17_Click(object sender, EventArgs e)
    {
        if (biaoqianadd.Text.Length == 0)
        {
            Label1.Text = ("标签不允许为空！");
            biaoqianadd.Focus();
            return;
        }
        //cid = Request.QueryString["id"].ToString();
        //typeid = 1;
        //string pingjiajielun1 = pingjiajielun.Text;
        //pingjiajielun1 = pingjiajielun.Text.Replace(Char.ConvertFromUtf32(32), "&nbsp;").Replace(Char.ConvertFromUtf32(13), "<br />"), "<br />");

        string sql = "";
        string value = "";
        sql = "select count(*) from Setting where SettingID=40 and name= '" + biaoqianadd.Text.Trim() + "'";
        DataTable dt = DBqiye.getDataTable(sql);
        if (dt.Rows.Count > 0)
        {
            value = dt.Rows[0][0].ToString();
            if (value != "0")
            {
                Label14.Text = "标签名已经添加，请用新名添加";
                return;
            }
        }

        {
            sql = @"INSERT INTO [dbo].[Setting]
                           ([SettingID]           ,[Name]           ,[state])
                     VALUES           (40,'" + biaoqianadd.Text.Trim() + "',1)";
        }
        int count = DBqiye.getRowsCount(sql);
        sql = "";

        setting(40, ddlbiaoqian);  //成果标签
        biaoqian.Text += biaoqianadd.Text.Trim() + ",";
        if (count > 0) Label14.Text = "标签保存成功" + sql; else Label14.Text = "保存失败" + sql;
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

    protected void txtDemo_TextChanged(object sender, EventArgs e)
    {
        setting(40, ddlbiaoqian);  //成果标签
        //string[] str = { "seer", "stt", "git", "lii", "gll", "lrt" };
        //this.txtDemo.AutoCompleteCustomSource.AddRange(str);
        //this.txtDemo.AutoCompleteSource = AutoCompleteSource.CustomSource;
        //this.txtDemo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

    }
}