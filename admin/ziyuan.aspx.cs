﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class admin_ziyuan : System.Web.UI.Page
{
    public int PgIndex = 0;
    public int PgCount = 0;
    public int RCount = 0;
    public int classid = 0;
    public int page = 0;
    public int newPageIndex = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        //myGrid.Attributes.Add("style", "word-break:keep-all;word-wrap:normal");
        if (!Common.isAdminLogin())
        {
            Response.Redirect("login.aspx");
            Response.End();
        }
        try
        {
            classid = int.Parse(Request.QueryString["class"].ToString());
            page = int.Parse(Request.QueryString["page"].ToString());
        }
        catch { }

        if (!Page.IsPostBack)
        {
            //myGrid.Attributes.Add("style", "word-break:keep-all;word-wrap:false");
            myGrid.Attributes.Add("style", "word-break:keep-all;word-wrap:normal");
            //GridView1.Attributes.Add("style", "word-break:keep-all;word-wrap:normal");
            DataTable dt = DBqiye.getDataTable("SELECT  ID,Name  FROM Setting WHERE (SettingID = 45) and state=1");
            DataRow dr = dt.NewRow();
            dr["id"] = "0";
            dr["name"] = "查看全部";
            dt.Rows.InsertAt(dr, 0);
            fl.DataSource = dt;
            fl.DataTextField = "name";
            fl.DataValueField = "id";
            fl.DataBind();
            fl.SelectedValue = classid.ToString();
            myGrid.PageIndex = page;
            BindGrid();
        }
    }
    protected void btnGridView_Click(object sender, EventArgs e)
    {

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
    private void BindGrid()
    {
        string sql = @"select * from Resource where state=1 ";
        if (Common.strFilter(title.Text).Length > 0)
        {
            sql += "  and title like '%" + Common.strFilter(title.Text) + "%'";
        }

        if (fl.SelectedValue != "0")
        {
            sql += " and charindex(','+cast('" + fl.SelectedValue + "' as varchar)+',',','+c.typename+',')>0 ";
        }
        sql += " order by id desc";
        DataTable dt;
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

    protected void bj_Command(object sender, CommandEventArgs e)
    {
        Response.Redirect("ziyuanadd.aspx?id=" + e.CommandArgument + "&class=" + fl.SelectedValue + "&page=" + (myGrid.PageIndex + 1) + "");
        //DataTable dt = DBC.getDataTable("select * from syspara where id=" + e.CommandArgument);
        //if (dt.Rows.Count > 0)
        //{
        //    DataRow dr = dt.Rows[0];
        //    id.Text = dr["id"].ToString();
        //    para.Text = dr["para"].ToString();
        //    value.Text = dr["value"].ToString();
        //    demo.Text = dr["demo"].ToString();
        //}
    }

    protected void sc_Command(object sender, CommandEventArgs e)
    {
        DBqiye.getRowsCount("update   Resource set state=0 where id=" + e.CommandArgument);
        BindGrid();
    }

    protected void new_Click(object sender, EventArgs e)
    {
        Response.Redirect("ziyuanadd.aspx?id=0");
    }

    protected void ss_Click(object sender, EventArgs e)
    {
        BindGrid();
    }

    protected void myGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[1].Text.Length > 30) e.Row.Cells[1].Text = e.Row.Cells[1].Text.Substring(0, 30) + "...";
        }
    }
}