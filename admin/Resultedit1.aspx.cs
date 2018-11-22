using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class admin_Resultedit1 : System.Web.UI.Page
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
            Response.Write(Request.QueryString["edit"]+ Request.QueryString["id"].ToString());
            DBqiye.getRowsCount("update [Results] set state=1 where id=" + Request.QueryString["id"].ToString());
            Response.Redirect("Results.aspx");
        }
        if (!Page.IsPostBack)
        {
           
            //company(); //绑定公司名称
            setting(22, JieDuan); //成果阶段
            setting(4, DanWeiXingZhi); //成果性质
            setting(2, DiZhi); //地址
            setting(11, ShuiPing); //成果水平
            setting(23, MiJi); //成果密级
            setting(24, ShuXing); //成果密级
            setting(25, ChuangXinXingShi); //成果创新形式
            setting(26, NoYingYYin); //成果创新形式
            setting(29, YingYongQingKuang); //成果创新形式
            setting(30, JiaoYiState); //成果创新形式
            yewubd();//业务
            NewMethod(6, YingYongLingYu);//应用领域
            NewMethod(3, hangyec);//行业
            //setting(3, hangye); //行业
            setting(21, webtype); //网站类型

            setting(7, ddlXingZhi);  //项目性质
            setting(8, ddlJunGong);  //军工情况
            setting(40, ddlbiaoqian);  //成果标签
            BindGrid();

        }
        
    }
    private void yewubd()
    {
        string sql = "SELECT [UserID],[RealName]        FROM[dbo].[User]  where Enabled=1 ";
        if (Session["title"].ToString() != "3")
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
        string sql = @"SELECT  p.*     FROM  [dbo].[Results] p   where id="+cid+" ";

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
                //RNo.Text = dr["RNo"].ToString();
                RName.Text = dr["RName"].ToString();
                JianJie.Text = dr["JianJie"].ToString();
                content.Text = dr["JieShao"].ToString();
                //TuPian.Text = dr["TuPian"].ToString();

                //ShiPin.Text = dr["ShiPin"].ToString();
                JieDuan.SelectedValue = dr["JieDuan"].ToString();
                DanWeiXingZhi.SelectedValue = dr["DanWeiXingZhi"].ToString();
                DiZhi.SelectedValue = dr["DiZhi"].ToString();
                //YingYongLingYu.Text = dr["YingYongLingYu"].ToString();
                biaoqian1.Text = dr["biaoqian"].ToString();
                ZiJin.Text = dr["ZiJin"].ToString();
                //if (dr["ZhuanLi"].ToString() == "1")
                //{ ZhuanLi.Checked = true; }
                //else
                //{ ZhuanLi.Checked = false; }
                //if (dr["Pingjia"].ToString() == "1")
                //{ Pingjia.Checked = true; }
                //else
                //{ Pingjia.Checked = false; }
                //if (dr["ChaXin"].ToString() == "1")
                //{ ChaXin.Checked = true; }
                //else
                //{ ChaXin.Checked = false; }
                //if (dr["JianCe"].ToString() == "1")
                //{ JianCe.Checked = true; }
                //else
                //{ JianCe.Checked = false; }
                //if (dr["ShiYongBao"].ToString() == "1")
                //{ ShiYongBao.Checked = true; }
                //else
                //{ ShiYongBao.Checked = false; }
                //ZhuanLi.Text = dr["ZhuanLi"].ToString();
                ShuiPing.SelectedValue = dr["ShuiPing"].ToString();
                MiJi.SelectedValue = dr["MiJi"].ToString();
                ShuXing.SelectedValue = dr["ShuXing"].ToString();

                ChuangXinXingShi.SelectedValue = dr["ChuangXinXingShi"].ToString();
                YingYongQingKuang.SelectedValue = dr["YingYongQingKuang"].ToString();
                NoYingYYin.SelectedValue = dr["NoYingYYin"].ToString();
                //ChiYouRenID.Text = dr["ChiYouRenID"].ToString();
                //yewu.SelectedValue = dr["userid"].ToString();
                zhongyao.Text = dr["zhongyao"].ToString();
                wanzheng.Text = dr["wanzheng"].ToString();
                JiaoYiState.SelectedValue = dr["JiaoYiState"].ToString();
                SetChecked(YingYongLingYu, dr["YingYongLingYu"].ToString(), ",");
                SetChecked(hangyec, dr["hangye"].ToString(), ",");
                //hangye.SelectedValue = dr["hangye"].ToString();
                webtype.SelectedValue = dr["webtype"].ToString();
                indexview.Checked = (dr["indexview"].ToString() == "0" ? false : true);
                yewu.SelectedValue = dr["userid"].ToString();
                BindChiYou(cid);
                BindZheng(cid);
                try { RadioButtonList1.SelectedIndex = Convert.ToInt16(dr["ChiYouRenType"]); }
                catch { }
                
                if (dr["ChiYouRenType"].ToString() == "0")
                {
                    RadioButtonList1.SelectedIndex = 0;
                    company("");                   
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
                if (dr["hezuotype1"].ToString() == "1")
                { hezuotype1.Checked = true; }
                else
                { hezuotype1.Checked = false; }
                if (dr["hezuotype2"].ToString() == "1")
                { hezuotype2.Checked = true; }
                else
                { hezuotype2.Checked = false; }
                if (dr["hezuotype3"].ToString() == "1")
                { hezuotype3.Checked = true; }
                else
                { hezuotype3.Checked = false; }
                if (dr["hezuotype4"].ToString() == "1")
                { hezuotype4.Checked = true; }
                else
                { hezuotype4.Checked = false; }
                if(dr["hezuocost1"]==null)
                { hezuocost1.Text = "0"; }
                else { hezuocost1.Text = dr["hezuocost1"].ToString(); }
                if (dr["hezuocost2"] == null)
                { hezuocost2.Text = "0"; }
                else { hezuocost2.Text = dr["hezuocost2"].ToString(); }
                if (dr["hezuocost3"] == null)
                { hezuocost3.Text = "0"; }
                else { hezuocost1.Text = dr["hezuocost3"].ToString(); }
               
                //hezuocost4.Text = dr["hezuocost4"].ToString();
                Bindpic(cid);
                voidfile.Text = dr["voidfile"].ToString();
                voidtext.Text = dr["voidtext"].ToString();

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
                TextBox3.Text= dr["ZiZhi"].ToString();
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
        dt = DBqiye.getDataTable("SELECT *  FROM [dbo].[ResultPic] where CID = " + sid + " and  state=1 ");
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
        sql = "SELECT  [ID]      ,[SettingID]      ,[Name]      ,[state]    FROM[ZhongQiHuiLian].[dbo].[Setting]    where SettingID ='"+ itype + "'";
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
        DataTable dt = DBqiye.getDataTable("SELECT  [ID],[Name]  FROM [dbo].[Setting] where SettingID=" + itype + " and state=1 order by [Name] ");
        ddlname.DataSource = dt;
        ddlname.DataTextField = "Name";
        ddlname.DataValueField = "ID";
        ddlname.DataBind();
        ddlname.Items.Insert(0, new ListItem("==请选择==", "0"));
        ddlname.SelectedValue = "0";
        if (itype == 40)
        {
            int i = 1;
            string str = "";
            foreach (DataRow dr in dt.Rows)
            {
                str+= "{ k: "+ i.ToString() + ",v: '" + dr["Name"].ToString() + "'}|" ;
            }
            hfddlList.Value = str.Substring(0,str.Length-1);
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
        DBqiye.getRowsCount("update ResultPic set state=0 where id=" + e.CommandArgument);
        BindGrid();
        typeid = 5;
        BindZheng(cid);
    }
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
        string classid = "0";
        string cbtext1 = "";
        for (int i = 0; i < YingYongLingYu.Items.Count; i++)
        {
            if (YingYongLingYu.Items[i].Selected == true)
            {
                //这个打勾的
                cbtext1 += YingYongLingYu.Items[i].Value + ",";
                if (classid == "0")
                {
                    classid = YingYongLingYu.Items[i].Value;
                }
            }
            else
            {
                //这是没打的
            }
        }
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
        cid = Request.QueryString["id"].ToString();
        this.content1.Text = Request.Form["content"];
        string XingZhiBiao = "";
        switch (DanWeiXingZhi.SelectedValue)
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
            default:
                XingZhiBiao = "C";
                break;
        }
        XingZhiBiao = XingZhiBiao + "000000";
        string sql = "";
        if (txtTest.Text.Length > 0)
        {
            sql = @"update  [dbo].[Results]
            set [RName]='" + Common.strFilter(RName.Text) + "'           ,[JianJie]='" + Common.strFilter(JianJie.Text)
            + "',[JieShao] ='" + Common.strFilter(content1.Text) + "'                           ,[JieDuan]='" + Common.strFilter(JieDuan.Text)
            + "'           ,[DanWeiXingZhi]='" + Common.strFilter(DanWeiXingZhi.SelectedValue) + "'          ,[DiZhi]='" + Common.strFilter(DiZhi.SelectedValue) + "'           ,[YingYongLingYu]='" + cbtext1 + "'           ,[ZiJin]='" + Common.strFilter(ZiJin.Text)

            + "' ,[ShuiPing]='" + Common.strFilter(ShuiPing.SelectedValue) + "'           ,[MiJi]='" + Common.strFilter(MiJi.SelectedValue) + "'           ,[ShuXing]='" + Common.strFilter(ShuXing.SelectedValue) + "'          ,[ChuangXinXingShi]='" + Common.strFilter(ChuangXinXingShi.SelectedValue)
            + "'           ,[YingYongQingKuang]='" + Common.strFilter(YingYongQingKuang.SelectedValue) + "'           ,[NoYingYYin]='" + Common.strFilter(NoYingYYin.SelectedValue) + "'           ,[ChiYouRenID]='" + Common.strFilter(ChiYouRenID.SelectedValue) + "'           ,[KeHuJingLi]='" + Session["userid"]
            + "'           ,[JiaoYiState]='" + Common.strFilter(JiaoYiState.SelectedValue) + "'           ,[Update]='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' , RNo='" + XingZhiBiao + cid + "'          ,[userid]='" + yewu.SelectedValue + "',hangye='" + Common.strFilter(cbtexthy) + "',webtype= '" + Common.strFilter(webtype.SelectedValue) + "'         ,ChiYouRenType='" + (RadioButtonList1.SelectedIndex) + "',indexview='" + ((indexview.Checked) ? "1" : "0") + "' ,[biaoqian]='" + txtTest.Text + "' ,[zhongyao]='" + Common.strFilter(zhongyao.SelectedItem.Text) + "' ,[wanzheng]='" + Common.strFilter(wanzheng.SelectedItem.Text) + "'   where id=" + cid;
        }
        else
        {
            sql = @"update  [dbo].[Results]
            set [RName]='" + Common.strFilter(RName.Text) + "'           ,[JianJie]='" + Common.strFilter(JianJie.Text)
        + "',[JieShao] ='" + Common.strFilter(content1.Text) + "'                           ,[JieDuan]='" + Common.strFilter(JieDuan.Text)
        + "'           ,[DanWeiXingZhi]='" + Common.strFilter(DanWeiXingZhi.SelectedValue) + "'          ,[DiZhi]='" + Common.strFilter(DiZhi.SelectedValue) + "'           ,[YingYongLingYu]='" + cbtext1 + "'           ,[ZiJin]='" + Common.strFilter(ZiJin.Text)

        + "' ,[ShuiPing]='" + Common.strFilter(ShuiPing.SelectedValue) + "'           ,[MiJi]='" + Common.strFilter(MiJi.SelectedValue) + "'           ,[ShuXing]='" + Common.strFilter(ShuXing.SelectedValue) + "'          ,[ChuangXinXingShi]='" + Common.strFilter(ChuangXinXingShi.SelectedValue)
        + "'           ,[YingYongQingKuang]='" + Common.strFilter(YingYongQingKuang.SelectedValue) + "'           ,[NoYingYYin]='" + Common.strFilter(NoYingYYin.SelectedValue) + "'           ,[ChiYouRenID]='" + Common.strFilter(ChiYouRenID.SelectedValue) + "'           ,[KeHuJingLi]='" + Session["userid"]
        + "'           ,[JiaoYiState]='" + Common.strFilter(JiaoYiState.SelectedValue) + "'           ,[Update]='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' , RNo='" + XingZhiBiao + cid + "'          ,[userid]='" + yewu.SelectedValue + "',hangye='" + Common.strFilter(cbtexthy) + "',webtype= '" + Common.strFilter(webtype.SelectedValue) + "'         ,ChiYouRenType='" + (RadioButtonList1.SelectedIndex) + "',indexview='" + ((indexview.Checked) ? "1" : "0") + "'  ,[zhongyao]='" + Common.strFilter(zhongyao.SelectedItem.Text) + "' ,[wanzheng]='" + Common.strFilter(wanzheng.SelectedItem.Text) + "'   where id=" + cid;
        }
        int count = DBqiye.getRowsCount(sql);
        sql = "";
        if (count > 0) Label1.Text = "保存成功" + sql; else Label1.Text = "保存失败" + sql;
        txtTest.Text = "";
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
        //ddlCompany.Items.Insert(0, new ListItem("==请选择==", ""));
        //ddlCompany.SelectedValue = "";
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
            sql += " and [Name] like '%"+ sname + "%' ";
        }

        DataTable dt = DBqiye.getDataTable(sql);
        ChiYouRenID.Items.Clear();
        ChiYouRenID.DataSource = dt;
        ChiYouRenID.DataTextField = "Name";
        ChiYouRenID.DataValueField = "ID";
        ChiYouRenID.DataBind();
        //ddlCompany.Items.Insert(0, new ListItem("==请选择==", ""));
        //ddlCompany.SelectedValue = "";
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
        string filename = Server.MapPath("~/upload/") + file + "." + ext;
        upfile.SaveAs(filename);
       
        pic.Text = "/upload/" + file + "." + ext;
        //imgh.ImageUrl = "/upload/" + file + "." + ext;
        //DBC.getRowsCount("update users set headimg='" + headimg.Text + "' where id=" + Session["userid"].ToString());
        //imgh.ImageUrl = imgh.ImageUrl;
        //Session["headimg"] = imgh.ImageUrl;
        //Global.ROOM.updateheadIMG(ulong.Parse(Session["userid"].ToString()), imgh.ImageUrl);
        Label6.Text = "上传成功";
        cid = Request.QueryString["id"].ToString();
        string sql = "";
        {
            sql = @"INSERT INTO [dbo].[ResultPic]           ([CID]           ,[FileName]           ,[text]           ,[datetime]           ,[state],[viewindex])VALUES('"
            + cid + "','" + Common.strFilter(pic.Text) + "','"+ Common.strFilter(text.Text) + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',1,'" + ((viewindex.Checked) ? "1" : "0") + "')";
        }
        int count = DBqiye.getRowsCount(sql);
        
        if (count > 0) Label6.Text = "保存成功"; else Label6.Text = "保存失败"+ sql;

        Bindpic(cid);
        typeid = 5;

    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        typeid = 7;
        Label7.Text = "";
        if (!FileUpload1.HasFile) { Label6.Text = "请选择文件后上传"; return; }
        if (FileUpload1.FileBytes.Length > 1024 * 1024*50)
        { Label7.Text = "文件不能大于50M"; return; }
        string ext = FileUpload1.FileName.Substring(FileUpload1.FileName.Length - 3).ToLower();
        if ( ext != "mp4"  && ext != "rmvb" && ext != "avi" && ext != "rm" && ext != "wmv" && ext != "3gp")
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
        string sql = "";
        {
            sql = @"update [dbo].[Results] set voidfile='" + Common.strFilter(voidfile.Text) + "',voidtext='" + Common.strFilter(voidtext.Text) + "' where id='"
            + cid + "'";
        }
        int count = DBqiye.getRowsCount(sql);

        if (count > 0) Label7.Text = "保存成功"; else Label7.Text = "保存失败" + sql;

        Bindpic(cid);
        

    }
    protected void Button17_Click(object sender, EventArgs e)
    {
        if (biaoqianadd.Text.Length == 0)
        {
            Label1.Text = ("标签不允许为空！");
            biaoqianadd.Focus();
            return;
        }
        cid = Request.QueryString["id"].ToString();
        typeid = 1;
        //string pingjiajielun1 = pingjiajielun.Text;
        //pingjiajielun1 = pingjiajielun.Text.Replace(Char.ConvertFromUtf32(32), "&nbsp;").Replace(Char.ConvertFromUtf32(13), "<br />"), "<br />");
        string sql = "";
        {
            sql = @"INSERT INTO [dbo].[Setting]
                           ([SettingID]           ,[Name]           ,[state])
                     VALUES           (40,'" + biaoqianadd.Text.Trim() + "',1)";
        }
        int count = DBqiye.getRowsCount(sql);
        sql = "";

        setting(40, ddlbiaoqian);  //成果标签
        //txtTest.Text += biaoqianadd.Text.Trim() + ",";
        if (count > 0) Label9.Text = "保存成功" + sql; else Label9.Text = "保存失败" + sql;
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
            this.content1.Text = Request.Form["content"];
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
            sql = @"update  [dbo].[Results] set ChiYouRenType='"+ RadioButtonList1.SelectedIndex + "',ChiYouRenID='"+ ChiYouRenID.Text + "' where id=" + cid;
        }
        int count = DBqiye.getRowsCount(sql);
        sql = "";
        if (count > 0) Label2.Text = "保存成功" + sql; else Label2.Text = "保存失败" + sql;
    }
    protected void Button7_Click(object sender, EventArgs e)
    {
        typeid = 3;
        try
        {
            Convert.ToSingle(hezuocost1.Text);
        }
        catch
        {
            Label4.Text = ("技术转让合作费用,必须为数字！");
            return;
        }
        //if (hezuotype1.Checked)
        //{
        //    if (Convert.ToSingle(hezuocost1.Text)== 0)
        //    {
        //        Label4.Text = ("技术转让合作费用,必须输入！");
        //        return;
        //    }
        //}
        try
        {
            Convert.ToSingle(hezuocost2.Text);
        }
        catch
        {
            Label4.Text = ("独家授权合作费用,必须为数字！");
            return;
        }
        //if (hezuotype2.Checked)
        //{
        //    if (Convert.ToSingle(hezuocost2.Text) == 0)
        //    {
        //        Label4.Text = ("独家授权合作费用,必须输入！");
        //        return;
        //    }
        //}
        try
        {
            Convert.ToSingle(hezuocost3.Text);
        }
        catch
        {
            Label4.Text = ("非独家授权合作费用,必须为数字！");
            return;
        }
        //if (hezuotype3.Checked)
        //{
        //    if (Convert.ToSingle(hezuocost3.Text) == 0)
        //    {
        //        Label4.Text = ("非独家授权合作费用,必须输入！");
        //        return;
        //    }
        //}
        
        cid = Request.QueryString["id"].ToString();
        string sql = "";
        {
            sql = @"update  [dbo].[Results] set [hezuotype1]='" + Common.strFilter(((hezuotype1.Checked) ? "1" : "0")) + "',[hezuotype2]='" + Common.strFilter(((hezuotype2.Checked) ? "1" : "0")) + "',[hezuotype3]='" + Common.strFilter(((hezuotype3.Checked) ? "1" : "0")) + "',[hezuotype4]='" + Common.strFilter(((hezuotype4.Checked) ? "1" : "0")) 
            + "',[hezuocost1]='" + Common.strFilter(hezuocost1.Text) + "',[hezuocost2]='" + Common.strFilter(hezuocost2.Text) + "',[hezuocost3]='" + Common.strFilter((hezuocost3.Text)) + "' where id=" + cid;
        }
        int count = DBqiye.getRowsCount(sql);
        sql = "";
        if (count > 0) Label4.Text = "保存成功" + sql; else Label4.Text = "保存失败" + sql;
        
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

    protected void ddlbiaoqian_SelectedIndexChanged(object sender, EventArgs e)
    {
        //biaoqian.Text += ddlbiaoqian.SelectedItem.Text+",";
    }
}