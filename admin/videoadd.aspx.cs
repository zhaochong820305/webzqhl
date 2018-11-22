using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class admin_videoadd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            setting(46, videotype); //成果创新形式
            //webtype(ddlWType);//网站分类
            NewMethod(3, hangyec);//行业
            id.Text = Request.QueryString["id"];
            if (Request.QueryString["op"] == "edit")
            {
                DataTable dt = DBC.getDataTable("select * from zqhl_pic where id=" + id.Text);
                if (dt.Rows.Count > 0)
                {
                    try
                    {
                        id.ReadOnly = true;
                        DataRow dr = dt.Rows[0];
                        id.Text = dr["id"].ToString();
                        pic.Text = dr["pic"].ToString();
                        pic1.Text = dr["voidfile"].ToString();
                        title.Text = dr["title"].ToString();
                        link.Text = dr["link"].ToString();
                        imgh.ImageUrl = pic.Text;
                        qz.Text = dr["qz"].ToString();
                        videotype.SelectedValue= dr["videotype"].ToString();
                        //if (dr["en"].ToString().Equals("1"))
                        //{
                        //    en.Checked = true;
                        //}
                        //else
                        //{
                        //    en.Checked = false;
                        //}
                        en.Checked = (dr["en"].ToString() == "1" ? true : false);
                        indexview.Checked = (dr["indexview"].ToString() == "1" ? true : false);
                        SetChecked(hangyec, dr["webtype"].ToString(), ",");
                        //ddlWType.SelectedValue = dr["typeid"].ToString();
                        //qq.Text = dr["qq"].ToString();
                        //mail.Text = dr["mail"].ToString();
                        //wx.Text = dr["wx"].ToString();
                        //pass.Text = "";
                    }
                    catch (Exception ex) { Common.WriteDiskLog(ex.Message); }
                }
            }
        }

    }

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
        sql = "SELECT   [Id]      ,[Name]   FROM [dbo].[webtype] where id<=4 order by id desc";
        DataTable dt = DBC.getDataTable(sql);

        cl.DataSource = dt;
        cl.DataTextField = "Name";//绑定的字段名
        cl.DataValueField = "id";//绑定的值
        cl.DataBind();
        return dt;
    }

    private void webtype(DropDownList ddlname)
    {
        DataTable dt = DBC.getDataTable("SELECT ID,[Name]+' '+cast(x as varchar)+'*'+cast(y as varchar) as Name  FROM [dbo].[webtype]");
        ddlname.DataSource = dt;
        ddlname.DataTextField = "Name";
        ddlname.DataValueField = "ID";
        ddlname.DataBind();
        //ddlname.Items.Insert(0, new ListItem("==请选择==", "0"));
        //ddlname.SelectedValue = "";
    }

    protected void bt_Click(object sender, EventArgs e)
    {
        LinkButton bt = (LinkButton)sender;
        DataTable dt = DBC.getDataTable("select * from zqhl_pic where id=" + bt.ID.Substring(1));
        if (dt.Rows.Count > 0)
        {
            try
            {
                id.ReadOnly = true;
                DataRow dr = dt.Rows[0];
                id.Text = dr["id"].ToString();
                pic.Text = dr["pic"].ToString();
                title.Text = dr["title"].ToString();
                link.Text = dr["link"].ToString();
                imgh.ImageUrl = pic.Text;
                qz.Text = dr["qz"].ToString();
                if (dr["en"].ToString().Equals("1"))
                {
                    en.Checked = true;
                }
                else
                {
                    en.Checked = false;
                }
                //ddlWType.SelectedValue = dr["typeid"].ToString();
                //qq.Text = dr["qq"].ToString();
                //mail.Text = dr["mail"].ToString();
                //wx.Text = dr["wx"].ToString();
                //pass.Text = "";
            }
            catch (Exception ex) { Common.WriteDiskLog(ex.Message); }
        }
    }
    protected void tj_Click(object sender, EventArgs e)
    {
        id.Text = "0";
        id.ReadOnly = true;
        msg.Text = "";
        pic.Text = "";
        imgh.ImageUrl = "";
    }
    protected void Button1_Click(object sender, EventArgs e)
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
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        msg.Text = "";
        if (!FileUpload1.HasFile) { msg.Text = "请选择文件后上传"; return; }
        if (FileUpload1.FileBytes.Length > 1024 * 1024)
        { msg.Text = "文件不能大于1M"; return; }
        string ext = FileUpload1.FileName.Substring(FileUpload1.FileName.Length - 3).ToLower();
        if (ext != "png" && ext != "jpg" && ext != "gif" && ext != "mp4" && ext != ".rm" && ext != "3gp")
        {
            msg.Text = "文件格式只能是png或jpg,mp4，rm,3gp"; return;
        }
        string file = DateTime.Now.ToString("yyyMMddHHmmss.ss");
        string filename = Server.MapPath("~/upload/") + file + "." + ext;
        FileUpload1.SaveAs(filename);
        pic1.Text = "/upload/" + file + "." + ext;
        //imgh.ImageUrl = "/upload/" + file + "." + ext;
        //DBC.getRowsCount("update users set headimg='" + headimg.Text + "' where id=" + Session["userid"].ToString());
        //imgh.ImageUrl = imgh.ImageUrl;
        //Session["headimg"] = imgh.ImageUrl;
        //Global.ROOM.updateheadIMG(ulong.Parse(Session["userid"].ToString()), imgh.ImageUrl);
        msg.Text = "上传成功";
    }
    protected void bc_Click(object sender, EventArgs e)
    {
        string hangyecs = "";
        for (int i = 0; i < hangyec.Items.Count; i++)
        {
            if (hangyec.Items[i].Selected == true)
            {
                //这个打勾的
                hangyecs += hangyec.Items[i].Value + ",";
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
        if (hangyecs.Length > 1) { hangyecs = hangyecs.Substring(0, hangyecs.Length - 1); }
        
        string sql = "";
        if (id.Text.Equals("0"))
        {
            //DataTable dt = DBC.getDataTable("select * from zjinfo where loginuser='" + Common.strFilter(loginuser.Text) + "'");
            //if (dt.Rows.Count > 0) { msg.Text = "用户名重复"; return; }
            sql = "insert into zqhl_pic(title,link,pic,en,qz,typeid,indexview,webtype,state,voidfile,videotype)values(";
            sql += "'" + Common.strFilter(title.Text) + "','" + Common.strFilter(link.Text) + "',";
            sql += "'" + Common.strFilter(pic.Text) + "'";//,'admin')";
            sql += "," + (en.Checked ? "1" : "0") + "," + Common.strFilter(qz.Text) + ",7," + (indexview.Checked ? "1" : "0") + ",'"+ hangyecs + "',1,'" + Common.strFilter(pic1.Text) + "','" + Common.strFilter(videotype.SelectedValue) + "')";
        }
        else
        {
            sql = "update zqhl_pic set pic='" + Common.strFilter(pic.Text) + "'";
            sql += ",title='" + Common.strFilter(title.Text) + "',link='" + Common.strFilter(link.Text) + "'";
            sql += ",en=" + (en.Checked ? "1" : "0") + ",indexview=" + (indexview.Checked ? "1" : "0") + ",qz=" + Common.strFilter(qz.Text) + ",webtype='" + hangyecs + "',videotype='" + videotype.SelectedValue + "'";
            sql += " where id=" + id.Text;
        }
        int rt = DBC.getRowsCount(sql);
        if (rt > 0)
        { msg.Text = "成功保存" ;   }
        else
        { msg.Text = "保存失败" ; }
    }

    protected void myGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        switch (e.Row.RowType)
        {
            case DataControlRowType.Pager:// 标题头  
                break;
            case DataControlRowType.DataRow:// 数据行  
                int maxcell = e.Row.Cells.Count - 1;
                LinkButton hp = new LinkButton();
                hp.Text = "修改";
                hp.ID = "x" + e.Row.Cells[0].Text;
                hp.Click += new EventHandler(bt_Click);
                e.Row.Cells[maxcell].Controls.Add(hp);
                Label lb = new Label();
                lb.Width = 5;
                lb.Text = " ";
                e.Row.Cells[maxcell].Controls.Add(lb);
                LinkButton hp1 = new LinkButton();
                //hp1.Text = "删除";
                //hp1.ID = "s" + e.Row.Cells[0].Text;
                //hp1.Click += new EventHandler(sc_Click);
                //hp1.Attributes.Add("onclick", "if(confirm('确定要删除该用户吗？')==false){return false;}");
                e.Row.Cells[maxcell].Controls.Add(hp1);
                if (e.Row.Cells[1].Text.Length > 28)
                {
                    e.Row.Cells[1].Text = e.Row.Cells[1].Text.Substring(0, 28) + "...";
                }
                break;
        }
    }
}