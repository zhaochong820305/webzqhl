using System;
using System.Collections.Generic;
 
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class admin_jscgedit : System.Web.UI.Page
{
    public string cid = "";
    public int typeid = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Common.isAdminLogin())
        {
            Response.Redirect("login.aspx");
            Response.End();
        }

        if (Request.QueryString["id"] != null && (!string.IsNullOrEmpty(Request.QueryString["id"])) && Request.QueryString["id"].Length > 0)
        {
            cid = Request.QueryString["id"].ToString();
        }
        else
        {
            Label1.Text = "请选择企业，否则无法显示";
            return;
        }

        if (!Page.IsPostBack)
        {
            //myGrid.Attributes.Add("style", "word-break:keep-all;word-wrap:false");
            setting(11, ddljishu); //技术水平
            setting(3, ddlhangye); //行业
            setting(10, ddllaiyuan); //成果来源
            setting(21, ddlchengguo); //成果类型
            BindGrid();
        }
    }
    private void setting(int itype, DropDownList ddlname)
    {
        DataTable dt = DBqiye.getDataTable("SELECT  [ID],[Name]  FROM [dbo].[Setting] where SettingID=" + itype + "");
        ddlname.DataSource = dt;
        ddlname.DataTextField = "Name";
        ddlname.DataValueField = "ID";
        ddlname.DataBind();
        //ddlname.Items.Insert(0, new ListItem("==请选择==", "0"));
        //ddlname.SelectedValue = "";
    }
    private void BindGrid()
    {

        DataTable dt;
        dt = DBqiye.getDataTable(@"SELECT  p.*,c.Name as CName,(select top 1  s.Name from Setting s where s.id = p.TechLevel ) as TechLevelname,
                       (select top 1  s.Name from Setting s where s.id = p.HangYe ) as HangYeName,
                       (select top 1  s.Name from Setting s where s.id = p.ResultsType ) as ResultsTypeName
                       FROM  [dbo].[Technology] p left join Company c on c.ID=p.CompanyID where p.id=" + cid + " order by p.id desc");
        try
        {
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                //基础信息
                lbcompanyname.Text = dr["CName"].ToString();
                tbName.Text= dr["TechName"].ToString();
                ddljishu.SelectedValue= dr["TechLevel"].ToString();
                ddlhangye.SelectedValue = dr["HangYe"].ToString();
                ddlchengguo.SelectedValue = dr["ResultsType"].ToString();

                tbjieduan.Text = dr["InPhase"].ToString();
                ddllaiyuan.SelectedValue = dr["Source"].ToString();
                tbKey.Text = dr["KeyWord"].ToString();
                tbhezuo.Text = dr["Cooperation"].ToString();
                tbtouzi.Text = dr["InvestmenTotal"].ToString();

                tbshebei.Text = dr["Equipment"].ToString();
                tblirui.Text = dr["Profits"].ToString();
                tbjieye.Text = dr["CostSavings"].ToString();
                tbxianjin.Text = dr["TechAdvancement"].ToString();
                tbcanshu.Text = dr["TechnicalParameters"].ToString();
                //详细信息
                tbYiYi.Text = dr["YiYi"].ToString();
                tbMuBiao.Text = dr["MuBiao"].ToString();
                tbRenWu.Text = dr["RenWu"].ToString();
                tbJiChu.Text = dr["JiChu"].ToString();

                tbChuoCuo.Text = dr["ChuoCuo"].ToString();
                tbQianJing.Text = dr["QianJing"].ToString();
                tbJiHua.Text = dr["JiHua"].ToString();
                tbFangAn.Text = dr["FangAn"].ToString();
                //技术专利
                tbZhuanLi.Text = dr["ZhuanLi"].ToString();
                tbLeiXing.Text = dr["LeiXing"].ToString();
                tbHaoMa.Text = dr["HaoMa"].ToString();
                tbShenQing.Text = dr["ShenQing"].ToString();

                tbShiJian.Text = dr["ShiJian"].ToString();
                tbFenLeiHao.Text = dr["FenLeiHao"].ToString();
                tbShuoYouRen.Text = dr["ShuoYouRen"].ToString();
                //获奖情况
                JiangMing.Text = dr["JiangMing"].ToString();
                BanJiang.Text = dr["BanJiang"].ToString();
                JiangShi.Text = dr["JiangShi"].ToString();
                //成果鉴定
                JieGuo.Text = dr["JieGuo"].ToString();
                JDanWei.Text = dr["JDanWei"].ToString();
                JShiJian.Text = dr["JShiJian"].ToString();
                imgh.ImageUrl = dr["UpFileName"].ToString();
                pic.Text = dr["UpFileName"].ToString();
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (tbName.Text.Length == 0)
        {
            Label1.Text = ("项目名称不允许为空！");
            return;
        }
        try
        {
            Convert.ToSingle(tbtouzi.Text);
        }
        catch
        {
            Label1.Text = ("总投资,必须为数字！");
            return;
        }
        try
        {
            Convert.ToSingle(tbshebei.Text);
        }
        catch
        {
            Label1.Text = ("设备投资,必须为数字！");
            return;
        }
        try
        {
            Convert.ToSingle(tblirui.Text);
        }
        catch
        {
            Label1.Text = ("新增利润,必须为数字！");
            return;
        }
        try
        {
            Convert.ToSingle(tbjieye.Text);
        }
        catch
        {
            Label1.Text = ("节省成本,必须为数字！");
            return;
        }

        string sql = "";
        {
            sql = @"UPDATE [dbo].[Technology] set [TechName]='" + Common.strFilter(tbName.Text) + "',[TechLevel]='" + Common.strFilter(ddljishu.SelectedValue) + "',[HangYe]='" + Common.strFilter(ddlhangye.SelectedValue) 
                + "' ,[ResultsType]='" + Common.strFilter(ddlchengguo.SelectedValue) + "' ,[InPhase]='" + Common.strFilter(tbjieduan.Text) + "',[Source]='" + Common.strFilter(ddllaiyuan.Text) + "' ,[KeyWord]='" + Common.strFilter(tbKey.Text) 
                + "' ,[Cooperation]='" + Common.strFilter(tbhezuo.Text) + "' ,[InvestmenTotal]='" + Common.strFilter(tbtouzi.Text) + "',[Equipment]='" + Common.strFilter(tbshebei.Text) + "',[Profits]='" + Common.strFilter(tblirui.Text)
                + "' ,[CostSavings] ='" + Common.strFilter(tbjieye.Text) + "' ,[TechAdvancement]='" + Common.strFilter(tbxianjin.Text) + "',[TechnicalParameters]='" + Common.strFilter(tbcanshu.Text) + "' where id ='"+cid+"'";
        }
        int count = DBqiye.getRowsCount(sql);
        if (count > 0) Label1.Text = "保存成功"; else Label1.Text = "保存失败";
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string sql = "";
        {
            sql = @"UPDATE [dbo].[Technology] set [YiYi]='" + Common.strFilter(tbYiYi.Text) + "',[MuBiao]='" + Common.strFilter(tbMuBiao.Text) + "',[RenWu]='" + Common.strFilter(tbRenWu.Text)
                + "' ,[JiChu]='" + Common.strFilter(tbJiChu.Text) + "' ,[ChuoCuo]='" + Common.strFilter(tbChuoCuo.Text) + "',[QianJing]='" + Common.strFilter(tbQianJing.Text) + "' ,[JiHua]='" + Common.strFilter(tbJiHua.Text)
                + "' ,[FangAn]='" + Common.strFilter(tbFangAn.Text) + "'  where id ='" + cid + "'";
        }
        int count = DBqiye.getRowsCount(sql);
        typeid = 2;
        if (count > 0) Label2.Text = "保存成功"; else Label2.Text = "保存失败";
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        string sql = "";
        {
            sql = @"UPDATE [dbo].[Technology] set [ZhuanLi]='" + Common.strFilter(tbZhuanLi.Text) + "',[LeiXing]='" + Common.strFilter(tbLeiXing.Text) + "',[HaoMa]='" + Common.strFilter(tbHaoMa.Text)
                + "' ,[ShenQing]='" + Common.strFilter(tbShenQing.Text) + "' ,[ShiJian]='" + Common.strFilter(tbShiJian.Text) + "',[FenLeiHao]='" + Common.strFilter(tbFenLeiHao.Text) + "' ,[ShuoYouRen]='" + Common.strFilter(tbShuoYouRen.Text)
                + "' where id ='" + cid + "'";
        }
        int count = DBqiye.getRowsCount(sql);
        typeid = 3;
        if (count > 0) Label3.Text = "保存成功"; else Label3.Text = "保存失败";
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        string sql = "";
        {
            sql = @"UPDATE [dbo].[Technology] set [JiangMing]='" + Common.strFilter(JiangMing.Text) + "',[BanJiang]='" + Common.strFilter(BanJiang.Text) + "',[JiangShi]='" + Common.strFilter(JiangShi.Text)
                  + "' where id ='" + cid + "'";
        }
        int count = DBqiye.getRowsCount(sql);
        typeid = 4;
        if (count > 0) Label4.Text = "保存成功"; else Label4.Text = "保存失败";
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        string sql = "";
        {
            sql = @"UPDATE [dbo].[Technology] set [JieGuo]='" + Common.strFilter(JieGuo.Text) + "',[JDanWei]='" + Common.strFilter(JDanWei.Text) + "',[JShiJian]='" + Common.strFilter(JShiJian.Text)
                  + "' where id ='" + cid + "'";
        }
        int count = DBqiye.getRowsCount(sql);
        typeid = 5;
        if (count > 0) Label5.Text = "保存成功"; else Label5.Text = "保存失败";
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
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
        imgh.ImageUrl = "/upload/" + file + "." + ext;
        //DBC.getRowsCount("update users set headimg='" + headimg.Text + "' where id=" + Session["userid"].ToString());
        //imgh.ImageUrl = imgh.ImageUrl;
        //Session["headimg"] = imgh.ImageUrl;
        //Global.ROOM.updateheadIMG(ulong.Parse(Session["userid"].ToString()), imgh.ImageUrl);
        Label6.Text = "上传成功";
        string sql = "";
        {
            sql = @"UPDATE [dbo].[Technology] set [UpFileName]='" + Common.strFilter(pic.Text) + "' where id ='" + cid + "'";
        }
        int count = DBqiye.getRowsCount(sql);
        typeid = 6;
        if (count > 0) Label6.Text = "保存成功"; else Label6.Text = "保存失败";
    }
}