using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
 
using System.IO;
public partial class admin_baomingall : System.Web.UI.Page
{
    public int PgIndex = 0;
    public int PgCount = 0;
    public int RCount = 0;
    int selectFlag = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Common.isAdminLogin())
        {
            Response.Redirect("login.aspx");
            Response.End();
        }
        BindGrid();
    }
    protected void ss_Click(object sender, EventArgs e)
    {
        BindGrid();
    }

    private void BindGrid()
    {

        DataTable dt;
        string sql = @"SELECT  b.companyid,replace(b.name,' ','') name,b.sex,b.title,b.tel,b.[update],c.name cname,c.Contact,c.ContactTel,c.email,c.address,c.zipcode,isIGBT,(case isIGBT when 1  then '是' else '否' end) chuxi FROM  [company] c inner join [C_baoming] b on c.ID=b.companyid  where  typeid='14' and (b.state=1)";

        if (name.Text.ToString() != "")
        {
            sql += " and [Contact] like '%" + name.Text + "%' ";
        }
        if (company.Text.ToString() != "")
        {
            sql += " and [Name] like '%" + company.Text + "%' ";
        }

        sql += " order by c.id desc";
        //Response.Write(sql);
        dt = DBqiye.getDataTable(sql);
        try
        {
            myGrid.DataSource = dt;
            myGrid.DataBind();
            PgCount = myGrid.PageCount;
            PgIndex = myGrid.PageIndex; RCount = dt.Rows.Count;
        }
        catch
        {
            //myGrid. = 0;
            myGrid.DataSource = dt;
            myGrid.DataBind();
        }
        finally
        {

        }
    }
    protected void btnGridView_Click(object sender, EventArgs e)
    {
        int newPageIndex = 0;
        //msg.Text += ((LinkButton)sender).CommandArgument.ToString();
        try
        {
            switch (((LinkButton)sender).CommandArgument.ToString())
            {
                case "first":
                    newPageIndex = 0;
                    break;
                case "last":
                    newPageIndex = myGrid.PageCount - 1;
                    break;
                case "prev":
                    newPageIndex = myGrid.PageIndex - 1;
                    break;
                case "next":
                    newPageIndex = myGrid.PageIndex + 1;
                    break;
                case "go":
                    newPageIndex = 2;
                    //try
                    //{
                    //GridViewRow gvr = myGrid.BottomPagerRow;
                    //TextBox tb = (TextBox)gvr.FindControl("txtNewPageIndex");
                    //msg.Text += tb.Text;
                    //int res = Convert.ToInt32(tb.Text.ToString());
                    //myGrid.PageIndex = res - 1;
                    //}
                    //catch (Exception ex) { msg.Text += ex.Message; }
                    break;
            }
        }
        catch { }
        try
        {
            if (newPageIndex < 0) { newPageIndex = 0; }
            else if (newPageIndex > myGrid.PageCount - 1) { newPageIndex = myGrid.PageCount - 1; }
            myGrid.PageIndex = newPageIndex;
        }
        catch { }
    }
    protected void myGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        BindGrid();
    }
    protected void myGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[1].Text.Length > 10) e.Row.Cells[1].Text = e.Row.Cells[1].Text.Substring(0, 10) + "...";
        }
    }
    protected void btnExcel_Click(object sender, EventArgs e)
    {
        DateTime dt = System.DateTime.Now;
        string str = dt.ToString("500强企业报名表yyyyMMdd");
        ////str = str + ".xls";


        ////myGrid.AllowPaging = false;
        ////BindGrid();

        //////GridViewToExcel(myGrid, "application/ms-excel", str);
        ////ExportGridViewForUTF8(myGrid, str);
        ////// Export(gvRecord, "application/ms-excel", str);

        GridViewToExcel GridViewOutToExcel = new GridViewToExcel(Response);

        this.myGrid.AllowPaging = false; // 将有分页的GridView中的数据全部导出到Excel 

        BindGrid();
        //string name = "500强企业报名表";
        //  GridViewOutToExcel.Export("application/ms-excel", "详细信息.xls", DS_Main); 
        GridViewOutToExcel.Export("application/ms-excel", str + ".xls", myGrid, str, "");
        // 换成 export("application/ms-word", "设备信息.doc"); 那么导出的就是Word格式的了. 

        this.myGrid.AllowPaging = true;

        BindGrid();



    }
    /// <summary>
    /// 将网格数据导出到Excel
    /// </summary>
    /// <param name="ctrl">网格名称(如GridView1)</param>
    /// <param name="FileType">要导出的文件类型(Excel:application/ms-excel)</param>
    /// <param name="FileName">要保存的文件名</param>
    public static void GridViewToExcel(Control ctrl, string FileType, string FileName)
    {
        HttpContext.Current.Response.Charset = "GB2312";
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;//注意编码
        HttpContext.Current.Response.AppendHeader("Content-Disposition",
            "attachment;filename=" + HttpUtility.UrlEncode(FileName, System.Text.Encoding.UTF8).ToString());
        HttpContext.Current.Response.ContentType = FileType;//image/JPEG;text/HTML;image/GIF;vnd.ms-excel/msword 
        ctrl.Page.EnableViewState = false;
        StringWriter tw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(tw);
        ctrl.RenderControl(hw);
        HttpContext.Current.Response.Write(tw.ToString());
        HttpContext.Current.Response.End();
    }
    private void ExportGridViewForUTF8(GridView GridView, string filename)
    {

        string attachment = "attachment; filename=" + filename;
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", attachment);
        Response.Charset = "UTF-8";
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8");
        Response.ContentType = "application/ms-excel";
        System.IO.StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        GridView.RenderControl(htw);
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.End();

    }
    /// <summary>
    /// ReLoad this VerifyRenderingInServerForm is neccessary
    /// </summary>
    /// <param name="control"></param>

    public override void VerifyRenderingInServerForm(Control control)
    {

    }

}