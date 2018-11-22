using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
public partial class QiangJiAdmin_gongyeedit : System.Web.UI.Page
{
    public string cid = string.Empty;
    public int typeid = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Common.isAdminLogin())
        {
            Response.Redirect("login.aspx");
            Response.End();
        }
        if (Request.QueryString["type"] != null)
        {
            typeid = Convert.ToInt16(Request.QueryString["type"]);
            cid = Request.QueryString["id"].ToString();
        }
        if (Request.QueryString["edit"] != null && Request.QueryString["edit"] == "shenhe")
        {
            Response.Write(Request.QueryString["edit"] + Request.QueryString["id"].ToString());
            DBqiye.getRowsCount("update [Results] set state=1,userid='" + Session["userid"] + "' where id=" + Request.QueryString["id"].ToString() + "; update[Results] set  userid = '" + Session["userid"] + "' where userid is null and id=" + Request.QueryString["id"].ToString() + ";");
            //Response.Redirect("ResultWait.aspx");
            //DBqiye.getRowsCount();
            Response.Redirect("ResultWait.aspx");
        }
        if (!Page.IsPostBack)
        {
            setting(7, ddlXingZhi);  //项目性质
            setting(8, ddlJunGong);  //军工情况
       

            setting(2, ddldizhi);//所在地区
            setting(2, ddldiqu);//所在地区
            
            setting(4, ddlqiyexz);//企业性质
            setting(6, hangye);//行业领域
            setting(47, chanye); //工业强基十六条龙计划
            setting(21, qiangji); //网站类型
            NewMethod(3, lingyu);//行业
            shipin();
            BindGrid();
        }
    }
    private void shipin()
    {
        string sql = "select * from zqhl_pic p,webtype w where p.typeid=w.id and typeid=7 order by p.id desc ";

        DataTable dt = DBC.getDataTable(sql);
        voidku.DataSource = dt;
        voidku.DataTextField = "title";
        voidku.DataValueField = "id";
        voidku.DataBind();
        voidku.Items.Insert(0, new ListItem("==请选择==", ""));
        voidku.SelectedValue = "";
    }
     
    private void BindGrid()
    {
        if (Request.QueryString["id"] != null && (!string.IsNullOrEmpty(Request.QueryString["id"])) && Request.QueryString["id"].Length > 0)
        {
            cid = Request.QueryString["id"].ToString();
        }
        else
        {
            Label1.Text = "请选择交易成果，否则无法显示";
            return;
        }
        DataTable dt;
        string sql = @"SELECT  p.*     FROM  [dbo].[product] p   where id=" + cid + " ";

        //[Tech_LaiYuan]


        //if (Session["title"].ToString() != "3")
        //{
        //    sql += " and c.UserID='" + Session["userid"] + "' ";
        //}
        sql += " ";
        //Response.Write(sql);
        dt = DBqiye.getDataTable(sql);
        try
        {
            //myGrid.DataSource = dt;
            //myGrid.DataBind();
            //PgCount = myGrid.PageCount;
            //PgIndex = myGrid.PageIndex; RCount = dt.Rows.Count;
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                pname.Text = dr["pname"].ToString();
                price.Text = dr["price"].ToString();
                marketprice.Text = dr["marketprice"].ToString();
                orderno.Text = dr["orderno"].ToString();
                xinghao.Text = dr["xinghao"].ToString();

                pinpai.Text = dr["pinpai"].ToString();
                xilie.Text = dr["xilie"].ToString();
                pinlei.Text = dr["pinlei"].ToString();
                danwen.Text = dr["danwen"].ToString();
                kucun.Text = dr["kucun"].ToString();

                guige.Text = dr["guige"].ToString();
                qiangji.SelectedValue = dr["qiangji"].ToString();
                //lingyu.Text = dr["lingyu"].ToString();
                zhongyao.Text = dr["zhongyao"].ToString();

                SetChecked(lingyu, dr["lingyu"].ToString(), ",");
                chanye.Text = dr["chanye"].ToString();

                ddldizhi.SelectedValue= dr["dizhi"].ToString();

                content.Text= dr["xiangqing"].ToString();
                pinpai.Text = dr["pinpai"].ToString();                
                indexview.Checked = (dr["indexview"].ToString() == "1" ? true : false);

                // ChiYouRenID.SelectedValue= dr["companyid"].ToString();

                BindChiYou(cid);
                Bindpic(cid);
                BindZheng(cid);
                try { RadioButtonList1.SelectedIndex = Convert.ToInt16(dr["ChiYouRenType"]); }
                catch { }

                if (dr["companyid"].ToString() != "" && dr["companyid"]!= null)
                {
                    RadioButtonList1.SelectedIndex = 0;
                    company("");
                    ChiYouRenID.SelectedValue = dr["companyid"].ToString();
                }
                else
                {
                    RadioButtonList1.SelectedIndex = 1;
                    person("");
                }
                ChiYouRenID.SelectedValue = dr["ChiYouRenID"].ToString();
                //if (dr["ChiYouRenType"].ToString() == "0")
                //{ RadioButtonList1.SelectedIndex = 0; }
                //else
                //{ RadioButtonList1.Checked = false; }
                //合作信息
                

                //hezuocost4.Text = dr["hezuocost4"].ToString();
                
                voidfile.Text = dr["voidfile"].ToString();
                voidtext.Text = dr["voidtext"].ToString();
                voidku.SelectedValue = dr["voidku"].ToString();

                Bindzhuanjia(cid);
                //评价结论
                pingjiajielun.Text = dr["pingjiajielun"].ToString();
                zongpingfen.Text = dr["zongpingfen"].ToString();
                zhuren.Text = dr["zhuren"].ToString();
                fuzhuren.Text = dr["fuzhuren"].ToString();
                pingdate.Text = dr["pingdate"].ToString();
                //详细信息
                yiyi.Text = dr["yiyi"].ToString();
                xianjin.Text = dr["xianjin"].ToString();
                chengshu.Text = dr["chengshu"].ToString();
                yingyong.Text = dr["yingyong"].ToString();
                //项目信息
                tbMuBiao.Text = dr["Goal"].ToString();
                tbGuiGe.Text = dr["Scale"].ToString();
                tbGuDing.Text = dr["FixedInverstment"].ToString();
                tbnoGuDing.Text = dr["NonFixedInverstment"].ToString();
                tbSDate.Text = dr["StartDate"].ToString();
                tbEDate.Text = dr["EndDate"].ToString();
                tbJinDu.Text = dr["Process"].ToString();
                ddlXingZhi.SelectedValue = dr["Nature"].ToString();
                ddlJunGong.SelectedValue = dr["Military"].ToString();
                //content.Text = dr["ZiZhi"].ToString();
                TextBox3.Text = dr["ZiZhi"].ToString();
            }
        }
        catch
        {
            //myGrid. = 0;
            //myGrid.DataSource = dt;
            //myGrid.DataBind();
        }
        finally
        {

        }
    }
    private void BindChiYou(string sid)
    {

        DataTable dt;
        dt = DBqiye.getDataTable("SELECT *  FROM [dbo].[ResultRen] where CNO = " + sid + " and  state=1 ");
        //try
        //{
        //    GridView1.DataSource = dt;
        //    GridView1.DataBind();
        //    ///PgCount = GridView1.PageCount;
        //    //PgIndex = GridView1.PageIndex; GridView1 = dt.Rows.Count;
        //    if (dt.Rows.Count == 0) Label2.Text = " 没有查询到持有人数据";
        //}
        //catch
        //{
        //    Label2.Text = " 持有人查询错误";
        //    //myGrid. = 0;
        //    //GridView1.DataSource = dt;
        //    //GridView1.DataBind();
        //}
        //finally
        //{

        //}
    }
    private void Bindpic(string sid)
    {

        DataTable dt;
        dt = DBqiye.getDataTable("SELECT *  FROM [dbo].[productPic] where pID = " + sid + " and  state=1 ");
        try
        {
            GridView2.DataSource = dt;
            GridView2.DataBind();
            ///PgCount = GridView1.PageCount;
            //PgIndex = GridView1.PageIndex; GridView1 = dt.Rows.Count;
            if (dt.Rows.Count == 0) Label6.Text = " 没有查询到图片信息";
        }
        catch
        {
            Label6.Text = " 图片信息查询错误";
            //myGrid. = 0;
            //GridView1.DataSource = dt;
            //GridView1.DataBind();
        }
        finally
        {

        }
    }

    private void Bindzhuanjia(string sid)
    {

        DataTable dt;
        dt = DBqiye.getDataTable("SELECT *  FROM [dbo].[ResultExperts] where RID = " + sid + " and  state=1 ");
        try
        {
            GridView9.DataSource = dt;
            GridView9.DataBind();
            ///PgCount = GridView1.PageCount;
            //PgIndex = GridView1.PageIndex; GridView1 = dt.Rows.Count;
            if (dt.Rows.Count == 0) Label10.Text = " 没有查询到专家咨询意见信息";
        }
        catch
        {
            Label10.Text = " 专家咨询意见信息查询错误";
            //myGrid. = 0;
            //GridView1.DataSource = dt;
            //GridView1.DataBind();
        }
        finally
        {

        }
    }

    private void BindZheng(string sid)
    {

        DataTable dt;
        dt = DBqiye.getDataTable("SELECT *,(select [name] FROM Setting where id=r.zhengshutype) typename  FROM [dbo].[ResultZheng] r  where CNO = " + sid + " and  state=1 ORDER BY ID DESC ");
        try
        {
            GridView3.DataSource = dt;
            GridView3.DataBind();
            ///PgCount = GridView1.PageCount;
            //PgIndex = GridView1.PageIndex; GridView1 = dt.Rows.Count;
            if (dt.Rows.Count == 0) Label3.Text = " 没有查询到证书信息";
        }
        catch
        {
            Label3.Text = " 证书信息查询错误";
            //myGrid. = 0;
            //GridView1.DataSource = dt;
            //GridView1.DataBind();
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
    private DataTable NewMethod(int itype, CheckBoxList cl)
    {
        string sql = "";
        sql = "SELECT  [ID]      ,[SettingID]      ,[Name]      ,[state]    FROM[ZhongQiHuiLian].[dbo].[Setting]    where SettingID ='" + itype + "' and state=1";
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
        
        {
            sql += " order by id desc";
        }

        DataTable dt = DBqiye.getDataTable(sql);
        //DataTable dt = DBqiye.getDataTable("SELECT  [ID],[Name]  FROM [dbo].[Setting] where SettingID=" + itype + " and state=1 order by [id] ");
        ddlname.DataSource = dt;
        ddlname.DataTextField = "Name";
        ddlname.DataValueField = "ID";
        ddlname.DataBind();
        if (itype != 40)
        {
            ddlname.Items.Insert(0, new ListItem("==请选择==", "0"));
            ddlname.SelectedValue = "0";
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
    //    ddlCompany.DataSource = dt;
    //    ddlCompany.DataTextField = "Name";
    //    ddlCompany.DataValueField = "ID";
    //    ddlCompany.DataBind();
    //    //ddlCompany.Items.Insert(0, new ListItem("==请选择==", ""));
    //    //ddlCompany.SelectedValue = "";
    //}
    protected void sc_Command(object sender, CommandEventArgs e)
    {
        DBqiye.getRowsCount("update ResultRen set state=0 where id=" + e.CommandArgument);
        BindGrid();
        typeid = 2;
        BindChiYou(cid);
    }
    protected void fen_Command(object sender, CommandEventArgs e)
    {
        DBqiye.getRowsCount("update [ResultExperts] set state=0 where id=" + e.CommandArgument);
        BindGrid();
        typeid = 9;
        Bindzhuanjia(cid);
    }
    protected void ZS_Command(object sender, CommandEventArgs e)
    {
        DBqiye.getRowsCount("update ResultZheng set state=0 where id=" + e.CommandArgument);
        BindGrid();
        typeid = 4;
        BindZheng(cid);
    }

    protected void pic_Command(object sender, CommandEventArgs e)
    {
        DBqiye.getRowsCount("update productPic set state=0 where id=" + e.CommandArgument);
        BindGrid();
        typeid = 5;
        BindZheng(cid);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
         
        string classid = "0";
        string cbtext1 = "";
        if (pname.Text.Length == 0)
        {
            Label1.Text = ("产品名称不允许为空！");
            return;
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
        

        cid = Request.QueryString["id"].ToString();
        this.content.Text = Request.Form["content"];
        string XingZhiBiao = "";
       
        XingZhiBiao = XingZhiBiao + "";
        string sql = "";
        {
            sql = @"UPDATE [dbo].[product]
                    SET [pname] ='" + Common.strFilter(pname.Text) + "',[price] = '" + Common.strFilter(price.Text) + "' ,[marketprice] = '" + Common.strFilter(marketprice.Text) + "'   ,[orderno] = '" + Common.strFilter(orderno.Text) 
                    + "',[xinghao] ='" + Common.strFilter(xinghao.Text) + "'     ,[pinpai] = '" + Common.strFilter(pinpai.Text) + "'    ,[xilie] ='" + Common.strFilter(xilie.Text) + "'   ,[pinlei] ='" + Common.strFilter(pinlei.Text) 
                    + "',[danwen] = '" + Common.strFilter(danwen.Text) + "'     ,[shangjie] =null   ,[kucun] ='" + Common.strFilter(kucun.Text) + "',[xiangqing] ='" + Common.strFilter(content.Text) 
                    + "',[guige] = '" + Common.strFilter(guige.Text) + "'     ,[updates] = '" + Common.strFilter(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")) 
                    + "'     ,[qiangji] = '" + Common.strFilter(qiangji.Text) + "'     ,[dizhi] = '" + Common.strFilter(ddldizhi.Text) + "'                        ,[chanye] = '" + Common.strFilter(chanye.Text) 
                    + "'   ,[indexview] = '" + ((indexview.Checked) ? "1" : "0") + "'   ,[zhongyao] ='" + Common.strFilter(zhongyao.Text) + "'   ,[lingyu] ='" + Common.strFilter(cbtexthy)
                    + "'                    WHERE id="+cid;
        }
        int count = DBqiye.getRowsCount(sql);
        sql = "";
        if (count > 0) Label1.Text = "保存成功" + sql; else Label1.Text = "保存失败" + sql;
        //[userid]='" + yewu.SelectedValue + "',
        //只能超级管理员可以修改业务员

        //合作方式
        {
            sql = @" where id=" + cid;
        }
        count = DBqiye.getRowsCount(sql);

        
    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        typeid = 2;
        if (RadioButtonList1.SelectedIndex == 0)
        {
            //ChiYouRenID.Text = "企业";
            company("");
        }
        else
        {
            //ChiYouRenID.Text = "个人";
            person("");
        }
    }
    private void person(string str)
    {
        //string sql = "SELECT id,CName FROM [dbo].[ResultRen] where state=1 ";
        string sql = "SELECT   [id]      ,[zjname] FROM  [dbo].[zqhl_zj] ";
        //if (Session["title"].ToString() != "3")
        //{
        //    sql += " and UserID='" + Session["userid"] + "' ";
        //}
        if (str.Trim().Length > 0)
        {
            sql += " where  [zjname] like '%" + str + "%' ";
        }
        sql += " order by zjname";
        DataTable dt = DBC.getDataTable(sql);
        ChiYouRenID.DataSource = dt;
        ChiYouRenID.DataTextField = "zjname";
        ChiYouRenID.DataValueField = "ID";
        ChiYouRenID.DataBind();
        ChiYouRenID.Items.Insert(0, new ListItem("==请选择==", ""));
        ChiYouRenID.SelectedValue = "";
    }
    private void company(string sname)
    {
        string sql = "SELECT  [ID] ,[Name] FROM  [dbo].[Company] where state=1 ";
        if (Session["title"].ToString() != "3" && Session["title"].ToString() != "5")
        {
            sql += " and UserID='" + Session["userid"] + "' ";
        }
        if (sname.Length > 0)
        {
            sql += " and [Name] like '%" + sname + "%' ";
        }

        DataTable dt = DBqiye.getDataTable(sql);
        ChiYouRenID.Items.Clear();
        ChiYouRenID.DataSource = dt;
        ChiYouRenID.DataTextField = "Name";
        ChiYouRenID.DataValueField = "ID";
        ChiYouRenID.DataBind();
        ChiYouRenID.Items.Insert(0, new ListItem("==请选择==", ""));
        ChiYouRenID.SelectedValue = "";
    }
    protected void Button61_Click(object sender, EventArgs e)
    {
        typeid = 5;
        cid = Request.QueryString["id"].ToString();
        DataTable dt;
        dt = DBqiye.getDataTable("SELECT *  FROM [dbo].[ResultPic] where CID = " + cid + " and  state=1 ");
        try
        {
            if (dt.Rows.Count > 0)
            {

                string zhengshufile = "";
                string minfile = "";
                string yuanfile = "";
                //DataRow dr = dt.Rows[0];
                foreach (DataRow row in dt.Rows)
                {
                    zhengshufile = row["FileName"].ToString();
                    minfile = Server.MapPath("../") + "/min" + zhengshufile;
                    yuanfile = Server.MapPath("../") + "/yuan" + zhengshufile;
                    zhengshufile = Server.MapPath("../" + zhengshufile);
                    try
                    {
                        imgtext.BuildWatermark(yuanfile, Server.MapPath("/") + "/images/shunyin250.png", "www.kjcgjy.com", zhengshufile);
                    }
                    catch { Label5.Text += zhengshufile + ";错"; }
                    //imgtext.AddWaterText(yuanfile, "www.kjcgjy.com", zhengshufile, 255, 50);
                    // MakeThumbnail(zhengshufile, minfile, 225, 300, "HW");
                    Label5.Text = "上传缩微图证书成功+水印";
                }
                //DBqiye.getRowsCount("update ResultZheng set MinZFName='/min'+zhengshufile where CNO=" + sid);

            }
            if (dt.Rows.Count == 0) Label5.Text = " 没有查询到证书信息";
        }
        catch
        {
            Label5.Text = " 证书信息查询错误";

            //myGrid. = 0;
            //GridView1.DataSource = dt;
            //GridView1.DataBind();
        }
        finally
        {

        }
        //try
        //{
        //    GridView2.DataSource = dt;
        //    GridView2.DataBind();
        //    ///PgCount = GridView1.PageCount;
        //    //PgIndex = GridView1.PageIndex; GridView1 = dt.Rows.Count;
        //    if (dt.Rows.Count == 0) Label6.Text = " 没有查询到图片信息";
        //}
        //catch
        //{
        //    Label6.Text = " 图片信息查询错误";
        //    //myGrid. = 0;
        //    //GridView1.DataSource = dt;
        //    //GridView1.DataBind();
        //}
        //finally
        //{

        //}
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        typeid = 6;
        Label6.Text = "";
        if (!upfile.HasFile) { Label6.Text = "请选择文件后上传"; return; }
        if (upfile.FileBytes.Length > 1024 * 1024)
        { Label6.Text = "文件不能大于1M"; return; }
        string ext = upfile.FileName.Substring(upfile.FileName.Length - 3).ToLower();
        if (ext != "png" && ext != "jpg" && ext != "gif")
        {
            Label6.Text = "文件格式只能是png或jpg"; return;
        }
        string file = DateTime.Now.ToString("yyyMMddHHmmss.ss");
        string filename = Server.MapPath("~/productpic/") + file + "." + ext;
        //upfile.SaveAs(filename);
        string filename1 = Server.MapPath("~/yuan/productpic/") + file + "." + ext;
        upfile.SaveAs(filename1);
        pic.Text = "/productpic/" + file + "." + ext;
        imgtext.BuildWatermark(filename1, Server.MapPath("/") + "/images/shunyin.png", "www.kjcgjy.com", filename);
        //imgtext.AddWaterText(filename1, "www.kjcgjy.com", filename, 255, 50);
        //imgh.ImageUrl = "/upload/" + file + "." + ext;
        //DBC.getRowsCount("update users set headimg='" + headimg.Text + "' where id=" + Session["userid"].ToString());
        //imgh.ImageUrl = imgh.ImageUrl;
        //Session["headimg"] = imgh.ImageUrl;
        //Global.ROOM.updateheadIMG(ulong.Parse(Session["userid"].ToString()), imgh.ImageUrl);
        Label6.Text = "上传成功";
        cid = Request.QueryString["id"].ToString();
        string sql = "";
        {
            sql = @"INSERT INTO [dbo].[productPic]           ([pID]           ,[FileName]           ,[text]           ,[datetime]           ,[state],[viewindex])VALUES('"
            + cid + "','" + Common.strFilter(pic.Text) + "','" + Common.strFilter(text.Text) + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',1,'" + ((viewindex.Checked) ? "1" : "0") + "')";
        }
        int count = DBqiye.getRowsCount(sql);

        if (count > 0) Label6.Text = "保存成功"; else Label6.Text = "保存失败" + sql;

        Bindpic(cid);
        typeid = 5;

    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        cid = Request.QueryString["id"].ToString();
        string sql = "";
        {
            sql = @"update [dbo].[Results] set voidku='" + Common.strFilter(voidku.Text) + "' where id='"
            + cid + "'";
        }
        int count = DBqiye.getRowsCount(sql);

        if (count > 0) Label7.Text = "保存成功"; else Label7.Text = "保存失败" + sql;

        typeid = 7;
        //Label7.Text = "";
        if (!FileUpload1.HasFile) { Label6.Text = "请选择文件后上传"; return; }
        if (FileUpload1.FileBytes.Length > 1024 * 1024 * 50)
        { Label7.Text = "文件不能大于50M"; return; }
        string ext = FileUpload1.FileName.Substring(FileUpload1.FileName.Length - 3).ToLower();
        if (ext != "mp4" && ext != "rmvb" && ext != "avi" && ext != "rm" && ext != "wmv" && ext != "3gp")
        {
            Label7.Text = "文件格式只能是 rm、rmvb、wmv、avi、mp4、3gp"; return;
        }
        string file = DateTime.Now.ToString("yyyMMddHHmmss.ss");
        string filename = Server.MapPath("~/upload/") + file + "." + ext;
        FileUpload1.SaveAs(filename);
        voidfile.Text = "/upload/" + file + "." + ext;
        //imgh.ImageUrl = "/upload/" + file + "." + ext;
        //DBC.getRowsCount("update users set headimg='" + headimg.Text + "' where id=" + Session["userid"].ToString());
        //imgh.ImageUrl = imgh.ImageUrl;
        //Session["headimg"] = imgh.ImageUrl;
        //Global.ROOM.updateheadIMG(ulong.Parse(Session["userid"].ToString()), imgh.ImageUrl);
        Label7.Text = "上传成功";
        cid = Request.QueryString["id"].ToString();
        sql = "";
        {
            sql = @"update [dbo].[Results] set voidfile='" + Common.strFilter(voidfile.Text) + "',voidtext='" + Common.strFilter(voidtext.Text) + "',voidku='" + Common.strFilter(voidku.Text) + "' where id='"
            + cid + "'";
        }
        count = DBqiye.getRowsCount(sql);

        if (count > 0) Label7.Text = "保存成功"; else Label7.Text = "保存失败" + sql;

        Bindpic(cid);


    }
    
    protected void Button5_Click(object sender, EventArgs e)
    {
        cid = Request.QueryString["id"].ToString();
        typeid = 8;
        //string pingjiajielun1 = pingjiajielun.Text;
        //pingjiajielun1 = pingjiajielun.Text.Replace(Char.ConvertFromUtf32(32), "&nbsp;").Replace(Char.ConvertFromUtf32(13), "<br />"), "<br />");
        string sql = "";
        {
            sql = @"update  [dbo].[Results] set zongpingfen='" + zongpingfen.Text + "',pingjiajielun='" + pingjiajielun.Text + "',zhuren='" + zhuren.Text + "',fuzhuren='" + fuzhuren.Text + "',pingdate='" + pingdate.Text + "' where id=" + cid;
        }
        int count = DBqiye.getRowsCount(sql);
        sql = "";
        if (count > 0) Label9.Text = "保存成功" + sql; else Label9.Text = "保存失败" + sql;
    }
    protected void Button10_Click(object sender, EventArgs e)
    {
        cid = Request.QueryString["id"].ToString();
        typeid = 10;
        string sql = "";
        {
            sql = @"update  [dbo].[Results] set yiyi='" + yiyi.Text + "',xianjin='" + xianjin.Text + "',chengshu='" + chengshu.Text + "',yingyong='" + yingyong.Text + "' where id=" + cid;
        }
        int count = DBqiye.getRowsCount(sql);
        sql = "";
        if (count > 0) Label11.Text = "保存成功" + sql; else Label11.Text = "保存失败" + sql;
    }

    protected void Button11_Click(object sender, EventArgs e)
    {
        cid = Request.QueryString["id"].ToString();
        typeid = 11;
        if (tbMuBiao.Text.Length == 0)
        {
            Label1.Text = ("项目目标不允许为空！");
            return;
        }
        try
        {
            Convert.ToSingle(tbGuiGe.Text);
        }
        catch
        {
            Label1.Text = ("项目规模,必须为数字！");
            return;
        }
        try
        {
            Convert.ToSingle(tbGuDing.Text);
        }
        catch
        {
            Label1.Text = ("固定资产,必须为数字！");
            return;
        }
        try
        {
            Convert.ToSingle(tbnoGuDing.Text);
        }
        catch
        {
            Label1.Text = ("非固定资产,必须为数字！");
            return;
        }
        try
        {
            Convert.ToSingle(tbJinDu.Text);
        }
        catch
        {
            Label1.Text = ("项目进度,必须为数字！");
            return;
        }
        try
        {
            Convert.ToDateTime(tbSDate.Text);
        }
        catch
        {
            Label1.Text = ("开始时间,格式不正确！");
            return;
        }
        try
        {
            Convert.ToDateTime(tbEDate.Text);
        }
        catch
        {
            Label1.Text = ("结束时间,格式不正确！");
            return;
        }
        try
        {
            this.content.Text = Request.Form["content"];
        }
        catch { }
        string sql = "";
        {
            sql = @"update [dbo].[Results] set [Goal]='" + Common.strFilter(tbMuBiao.Text) + "',[Scale]='" + Common.strFilter(tbGuiGe.Text)
                + "',[Process]='" + Common.strFilter(tbJinDu.Text) + "',[Military]='" + Common.strFilter(ddlJunGong.SelectedValue) + "',[FixedInverstment]='" + Common.strFilter(tbGuDing.Text)
                + "',[NonFixedInverstment]='" + Common.strFilter(tbnoGuDing.Text) + "',[StartDate]='" + Common.strFilter(tbSDate.Text) + "' ,[EndDate]='" + Common.strFilter(tbEDate.Text) + "',Nature='" + Common.strFilter(ddlXingZhi.SelectedValue) + "',  ZiZhi='" + Common.strFilter(TextBox3.Text) + "' where ID='" + cid + "'";
        }
        //Response.Write(sql);
        //Response.End();
        int count = DBqiye.getRowsCount(sql);
        if (count > 0) Label12.Text = "保存成功"; else Label12.Text = "保存失败";

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        cid = Request.QueryString["id"].ToString();
        typeid = 2;
        string sql = "";
        {
            sql = @"update  [dbo].[product] set companyid='" + ChiYouRenID.Text + "' where id=" + cid;
        }
        int count = DBqiye.getRowsCount(sql);
        sql = "";
        if (count > 0) Label2.Text = "保存成功" + sql; else Label2.Text = "保存失败" + sql;
    }
    



    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        typeid = 2;
        company(TextBox1.Text);
    }
    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {
        typeid = 2;
        person(TextBox2.Text);
    }

   

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
        if (hangye2.SelectedValue == "0")
        {
            Label15.Text = ("必须选择一个二行业");
            return;
        }
        string sql = "";
        {
            if (Session["userid"].ToString() == "13")
            {
                sql = @"INSERT INTO[dbo].[Company]
                       ([Name]           ,[MemberName]           ,[Password]           ,[Address]
                       ,[ZipCode]           ,[LegalPerson]           ,[LegalPersonTel]           ,[Contact]
                       ,[ContactTel]           ,[BusinessScope]           ,[Region]           ,[EnterpriseType]
                       ,[KeyAreas]           ,[HangYe2ID]           ,[HasQuoted]           ,[CreateDate]
                       ,Incentive_HasStock,state)     VALUES
                       ('" + Common.strFilter(tbname.Text) + "','" + Common.strFilter(tblogin.Text) + "','" + MD5.CreateMD5Hash(tbpass.Text) + "','" + Common.strFilter(tbadd.Text) + "', '" +
                       Common.strFilter(tbzipcode.Text) + "','" + Common.strFilter(tbfaren.Text) + "','" + Common.strFilter(tbfarentel.Text) + "','" + Common.strFilter(tblianxi.Text) + "','" +
                       Common.strFilter(tblianxitel.Text) + "','" + Common.strFilter(jingyingfw.Text) + "','" + ddldiqu.SelectedValue + "','" + ddlqiyexz.SelectedValue + "','" +
                       hangye.SelectedValue + "','" + hangye2.SelectedValue + "'," + ((ishangshi.Checked) ? "1" : "0") + ",'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',0,1)";
            }
            else
            {
                sql = @"INSERT INTO[dbo].[Company]
                       ([Name]           ,[MemberName]           ,[Password]           ,[Address]
                       ,[ZipCode]           ,[LegalPerson]           ,[LegalPersonTel]           ,[Contact]
                       ,[ContactTel]           ,[BusinessScope]           ,[Region]           ,[EnterpriseType]
                       ,[KeyAreas]           ,[HangYe2ID]           ,[HasQuoted]           ,[CreateDate]
                       ,Incentive_HasStock,state,UserID)     VALUES
                       ('" + Common.strFilter(tbname.Text) + "','" + Common.strFilter(tblogin.Text) + "','" + MD5.CreateMD5Hash(tbpass.Text) + "','" + Common.strFilter(tbadd.Text) + "', '" +
                       Common.strFilter(tbzipcode.Text) + "','" + Common.strFilter(tbfaren.Text) + "','" + Common.strFilter(tbfarentel.Text) + "','" + Common.strFilter(tblianxi.Text) + "','" +
                       Common.strFilter(tblianxitel.Text) + "','" + Common.strFilter(jingyingfw.Text) + "','" + ddldiqu.SelectedValue + "','" + ddlqiyexz.SelectedValue + "','" +
                       hangye.SelectedValue + "','" + hangye2.SelectedValue + "'," + ((ishangshi.Checked) ? "1" : "0") + ",'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',0,1," + Session["userid"] + ")";
            }
        }

        int count = DBqiye.getRowsCount(sql);
        if (count > 0) Label15.Text = "保存成功"; else Label15.Text = "保存失败";
        typeid = 2;
    }
   
}