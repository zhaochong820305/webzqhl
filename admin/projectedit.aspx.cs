using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class admin_projectedit : System.Web.UI.Page
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
            //company(); //绑定公司名称
            setting(7, ddlXingZhi);  //项目性质
            setting(8, ddlJunGong);  //军工情况
            setting(14, ddlTuiChu);  //回报预期/退出机制
            setting(10, ddlLaiYuan); //技术来源
            setting(11, ddlDiWei);   //技术地位
            setting(12, ddlBiLei);   //技术壁垒
            BindGrid();
        }
    }
    private void BindGrid()
    {

        DataTable dt;
        dt = DBqiye.getDataTable(@"SELECT  p.*,c.Name as CName,(select top 1  s.Name from Setting s where s.id = p.Nature ) as naturename,
                        (select top 1  s.Name from Setting s where s.id = p.Military ) as MilitaryName
                        FROM  [dbo].[Project] p left join Company c on c.ID=p.CompanyID where p.id=" + cid + " order by p.id desc");
        try
        {
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                lCompany.Text = dr["CName"].ToString();
                tbName.Text = dr["Name"].ToString();
                tbMuBiao.Text = dr["Goal"].ToString();
                tbGuiGe.Text = dr["Scale"].ToString();
                tbGuDing.Text = dr["FixedInverstment"].ToString();
                tbnoGuDing.Text = dr["NonFixedInverstment"].ToString();
                tbSDate.Text = dr["StartDate"].ToString();
                tbEDate.Text = dr["EndDate"].ToString();
                tbJinDu.Text = dr["Process"].ToString();
                ddlXingZhi.SelectedValue = dr["Nature"].ToString();
                ddlJunGong.SelectedValue = dr["Military"].ToString();
                content.Text = dr["ZiZhi"].ToString();
                //DateTime.Now.AddDays(-1)
                tbShiGuiMo.Text = dr["Market_Scale"].ToString();
                tbShiFene.Text = dr["Market_Shared"].ToString();
                tbShiGuoMoWei.Text = dr["Market_Scale_Future"].ToString();
                tbShiFeeWei.Text = dr["Market_Shared_Future"].ToString();
                tbYiFuHangYe.Text = dr["Market_AreaAttach"].ToString();
                string sZhenCe = dr["Market_ZhengCe"].ToString();
                string[] sArray = sZhenCe.Split(',');
                if (sArray.Contains("120"))
                {
                    CheckBox120.Checked = true;
                }
                if (sArray.Contains("121"))
                {
                    CheckBox121.Checked = true;
                }
                if (sArray.Contains("122"))
                {
                    CheckBox122.Checked = true;
                }
                if (sArray.Contains("123"))
                {
                    CheckBox123.Checked = true;
                }
                if (sArray.Contains("124"))
                {
                    CheckBox124.Checked = true;
                }
                if (sArray.Contains("125"))
                {
                    CheckBox125.Checked = true;
                }
                if (sArray.Contains("126"))
                {
                    CheckBox126.Checked = true;
                }
                if (sArray.Contains("127"))
                {
                    CheckBox127.Checked = true;
                }
                //
                tbZiJinXuQiu.Text = dr["RongZi_Scale"].ToString();
                tbYongTu.Text = dr["RongZi_Yongtu"].ToString();
                tbRongZiGuiHua.Text = dr["Rongzi_GuiHua"].ToString();
                ddlTuiChu.Text = dr["Rongzi_TuiChu"].ToString();
                tbYuQiShou.Text = dr["RongZi_ExpectedReturn"].ToString();
                //
                ddlLaiYuan.SelectedValue = dr["Tech_LaiYuan"].ToString();
                ddlDiWei.SelectedValue = dr["Tech_DiWei"].ToString();
                ddlBiLei.SelectedValue = dr["Tech_BiLei"].ToString();
                tbChaXin.Text = dr["Tech_Chaxin"].ToString();
                tbZhuZuoQuan.Text = dr["Tech_ZhuanLiZhuzuo"].ToString();
                tbLiLiang.Text = dr["Tech_RDInfo"].ToString();
                tbYanFaFang.Text = dr["Tech_RDTarger"].ToString();
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
    private void setting(int itype, DropDownList ddlname)
    {
        DataTable dt =  DBqiye.getDataTable("SELECT  [ID],[Name]  FROM [dbo].[Setting] where SettingID=" + itype + "");
        ddlname.DataSource = dt;
        ddlname.DataTextField = "Name";
        ddlname.DataValueField = "ID";
        ddlname.DataBind();
        //ddlname.Items.Insert(0, new ListItem("==请选择==", "0"));
        //ddlname.SelectedValue = "";
    }
    //private void company()
    //{
    //    DataTable dt = DBqiye.getDataTable("SELECT  [ID] ,[Name] FROM  [dbo].[Company]");
    //    ddlCompany.DataSource = dt;
    //    ddlCompany.DataTextField = "Name";
    //    ddlCompany.DataValueField = "ID";
    //    ddlCompany.DataBind();
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
        if (tbName.Text.Length == 0)
        {
            Label1.Text = ("项目名称不允许为空！");
            return;
        }
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
            sql = @"update [dbo].[Project]  set [Name]='" + Common.strFilter(tbName.Text) + "',[Goal]='" + Common.strFilter(tbMuBiao.Text) + "',[Scale]='" + Common.strFilter(tbGuiGe.Text)
                + "',[Process]='" + Common.strFilter(tbJinDu.Text) + "',[Military]='" + Common.strFilter(ddlJunGong.SelectedValue) + "',[FixedInverstment]='" + Common.strFilter(tbGuDing.Text)
                + "',[NonFixedInverstment]='" + Common.strFilter(tbnoGuDing.Text) + "',[StartDate]='" + Common.strFilter(tbSDate.Text) + "' ,[EndDate]='" + Common.strFilter(tbEDate.Text) + "',Nature='" + Common.strFilter(ddlXingZhi.SelectedValue) + "',  ZiZhi='" + Common.strFilter(content1.Text) + "' where ID='" + cid + "'";
        }
        int count =  DBqiye.getRowsCount(sql);
        if (count > 0) Label1.Text = "保存成功"; else Label1.Text = "保存失败";
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            Convert.ToSingle(tbShiGuiMo.Text);
        }
        catch
        {
            Label2.Text = ("细分市场规模,必须为数字！");
            return;
        }
        try
        {
            Convert.ToSingle(tbShiFene.Text);
        }
        catch
        {
            Label2.Text = ("本项目所占细分市场份额,必须为数字！");
            return;
        }
        try
        {
            Convert.ToSingle(tbShiGuoMoWei.Text);
        }
        catch
        {
            Label2.Text = ("未来市场规模,必须为数字！");
            return;
        }
        try
        {
            Convert.ToSingle(tbShiFeeWei.Text);
        }
        catch
        {
            Label2.Text = ("本项目可能占有的市场份额,必须为数字！");
            return;
        }
        string scheakbox = string.Empty;
        if (CheckBox120.Checked)
            scheakbox += ",120";
        if (CheckBox121.Checked)
            scheakbox += ",121";
        if (CheckBox122.Checked)
            scheakbox += ",122";
        if (CheckBox123.Checked)
            scheakbox += ",123";
        if (CheckBox124.Checked)
            scheakbox += ",124";
        if (CheckBox125.Checked)
            scheakbox += ",125";
        if (CheckBox126.Checked)
            scheakbox += ",126";
        if (CheckBox127.Checked)
            scheakbox += ",127";
        if (scheakbox.Length > 0)
        { scheakbox += ","; }

        string sql = "";
        {
            sql = @"update [dbo].[Project]  set [Market_Scale]='" + Common.strFilter(tbShiGuiMo.Text) + "',[Market_Shared]='" + Common.strFilter(tbShiFene.Text) + "',[Market_Scale_Future]='" + Common.strFilter(tbShiGuoMoWei.Text)
                + "',[Market_Shared_Future]='" + Common.strFilter(tbShiFeeWei.Text) + "',[Market_AreaAttach]='" + Common.strFilter(tbYiFuHangYe.Text) + "',[Market_ZhengCe]='" + Common.strFilter(scheakbox) + "' where ID='" + cid + "'";
        }
        int count =  DBqiye.getRowsCount(sql);
        typeid = 3;
        if (count > 0) Label2.Text = "保存成功"; else Label2.Text = "保存失败";
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {
            Convert.ToSingle(tbZiJinXuQiu.Text);
        }
        catch
        {
            Label3.Text = ("资金需求规模,必须为数字！");
            return;
        }
        if (tbRongZiGuiHua.Text.Length == 0)
        {
            Label3.Text = ("融资规划不允许为空！");
            return;
        }

        string sql = "";
        {
            sql = @"update [dbo].[Project]  set [RongZi_Scale]='" + Common.strFilter(tbZiJinXuQiu.Text) + "',[RongZi_Yongtu]='" + Common.strFilter(tbYongTu.Text) + "',[Rongzi_GuiHua]='" + Common.strFilter(tbRongZiGuiHua.Text)
                + "',[Rongzi_TuiChu]='" + Common.strFilter(ddlTuiChu.SelectedValue) + "',[RongZi_ExpectedReturn]='" + Common.strFilter(tbYuQiShou.Text) + "'  where ID='" + cid + "'";
        }
        int count =  DBqiye.getRowsCount(sql);
        typeid = 4;
        if (count > 0) Label3.Text = "保存成功"; else Label3.Text = "保存失败";
    }

    protected void Button4_Click(object sender, EventArgs e)
    {

        string sql = "";
        {
            sql = @"update [dbo].[Project]  set [Tech_LaiYuan]='" + Common.strFilter(ddlLaiYuan.SelectedValue) + "',[Tech_DiWei]='" + Common.strFilter(ddlDiWei.SelectedValue) + "',[Tech_Chaxin]='" + Common.strFilter(tbChaXin.Text)
                + "',[Tech_BiLei]='" + Common.strFilter(ddlBiLei.SelectedValue) + "',[Tech_ZhuanLiZhuzuo]='" + Common.strFilter(tbZhuZuoQuan.Text) + "',[Tech_RDInfo]='" + Common.strFilter(tbLiLiang.Text) + "',[Tech_RDTarger]='" + Common.strFilter(tbYanFaFang.Text) + "'  where ID='" + cid + "'";
        }
        int count =  DBqiye.getRowsCount(sql);
        typeid = 2;
        if (count > 0) Label4.Text = "保存成功"; else Label4.Text = "保存失败";
    }
}