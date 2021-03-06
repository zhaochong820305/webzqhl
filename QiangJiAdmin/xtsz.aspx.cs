﻿using System;
using System.Collections.Generic;
 
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class admin_xtsz : System.Web.UI.Page
{
    public int PgIndex = 0;
    public int PgCount = 0;
    public int RCount = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Common.isAdminLogin())
        {
            Response.Redirect("login.aspx");
            Response.End();
        }
        BindGrid();
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
    private void BindGrid()
    {
        DataTable dt;
        dt = DBC.getDataTable("select * from syspara order by id desc");
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

        DataTable dt = DBC.getDataTable("select * from syspara where id=" + e.CommandArgument);
        if (dt.Rows.Count > 0)
        {
            DataRow dr = dt.Rows[0];
            id.Text = dr["id"].ToString();
            para.Text = dr["para"].ToString();
            value.Text = dr["value"].ToString();
            demo.Text = dr["demo"].ToString();
        }
    }

    protected void sc_Command(object sender, CommandEventArgs e)
    {
        DBC.getRowsCount("delete from syspara where id=" + e.CommandArgument);
    }

    protected void tj_Click(object sender, EventArgs e)
    {
        id.Text = "0";
        //loginuser.ReadOnly = false;
    }

    protected void bc_Click(object sender, EventArgs e)
    {

        string sql = "";
        if (value.Text.Length == 0)
        {
            msg.Text = "参数值为空，请填写"; return;
        }
        if (id.Text == "0")
        {
            //sql = "insert into syspara([para],value,demo)values(";
            //if (pass.Text.Length == 0)
            //{
            //    sql += "'" + Common.strFilter(loginuser.Text) + "','" + Common.strFilter(xm.Text) + "','" + MD5.CreateMD5Hash("123456") + "')";
            //}
            //else
            //{
            //    sql += "'" + Common.strFilter(loginuser.Text) + "','" + Common.strFilter(xm.Text) + "','" + MD5.CreateMD5Hash(pass.Text) + "')";
            //}
        }
        else
        {
            sql = "update syspara set [para]='" + Common.strFilter(para.Text) + "'";//,fl=" + Common.strFilter(fl.Text);
            sql += ",value='" + Common.strFilter(value.Text) + "'";
            sql += ",demo='" + Common.strFilter(demo.Text) + "'";
            sql += " where id=" + id.Text;
        }
        int count = DBC.getRowsCount(sql);
        if (count > 0) { msg.Text = "保存成功"; BindGrid(); } else { msg.Text = "保存失败"; }
    }
}