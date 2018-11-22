using System;
using System.Collections.Generic;
 
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class admin_news : System.Web.UI.Page
{
    public int id = 0;
    public string str = string.Empty;
    public int classid = 0;
    public int page = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Common.isAdminLogin())
        {
            Response.Redirect("login.aspx");
            Response.End();
        }
        try
        {
            this.content1.Text = Request.Form["content"];
        }
        catch { }
        try
        {
            id = int.Parse(Request.QueryString["id"].ToString());
            
            if (!Page.IsPostBack)
            {
                DataTable dt;
                NewMethod(1, CheckBoxList1);
                NewMethod(2, CheckBoxList2);
                NewMethod(3, CheckBoxList3);
                NewMethod(4, CheckBoxList4);
                if (id == 0)
                {
                    cdate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                }
                else
                {
                    dt = DBC.getDataTable("select * from zqhl_news where   id=" + id);
                    if (dt.Rows.Count > 0)
                    {
                        DataRow dr = dt.Rows[0];
                        title.Text = dr["title"].ToString();
                        content.Text = dr["content"].ToString().Replace("&emsp ", "&emsp;");
                        writer.Text = dr["writer"].ToString();
                        qz.Text = dr["qz"].ToString();
                        pic.Text = dr["pic"].ToString();
                        en.Checked = (dr["en"].ToString() == "0" ? false : true);
                        sel.Checked = (dr["sel"].ToString() == "0" ? false : true);
                        try
                        {
                            cdate.Text = DateTime.Parse(dr["cdate"].ToString()).ToString("yyyy-MM-dd");
                        }
                        catch { }
                        try
                        {
                            classn.Items.FindByValue(dr["classid"].ToString()).Selected = true;
                        }
                        catch { }
                        SetChecked(CheckBoxList1, dr["typename"].ToString(), ",");
                        SetChecked(CheckBoxList2, dr["typename"].ToString(), ",");
                        SetChecked(CheckBoxList3, dr["typename"].ToString(), ",");
                        SetChecked(CheckBoxList4, dr["typename"].ToString(), ",");
                    }
                }
            }

            classid = int.Parse(Request.QueryString["class"].ToString());
            page = int.Parse(Request.QueryString["page"].ToString());
        }
        catch { }

        
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
        sql = "select * from zqhl_class where en>0 and typeid='"+ itype + "' and fl<>4 order by typeid asc,fl asc,sx asc";//fl=4为专家类别
        DataTable dt = DBC.getDataTable(sql);
     

        cl.DataSource = dt;
        cl.DataTextField = "class";//绑定的字段名
        cl.DataValueField = "id";//绑定的值
        cl.DataBind();


       
        return dt;
    }

    protected void scfile_Click(object sender, EventArgs e)
    {
        msg.Text = "";
        if (!upfile.HasFile) { msg.Text = "请选择文件后上传"; return; }
        if (upfile.FileBytes.Length > 1024 * 1024)
        { msg.Text = "文件不能大于1M"; return; }
        string ext = upfile.FileName.Substring(upfile.FileName.Length - 3).ToLower();
        if (ext != "png" && ext != "jpg" && ext != "gif")
        {
            msg.Text = "文件格式只能是png或jpg或gif"; return;
        }
        string file = DateTime.Now.ToString("yyyMMddHHmmss.ss");
        string filename = Server.MapPath("../upload/") + file + "." + ext;
        upfile.SaveAs(filename);
        pic.Text = "/upload/" + file + "." + ext;
    }

    protected void bc_Click(object sender, EventArgs e)
    {

        //foreach (Control ct in this.form1.Controls)//循环查询表单里面的子控件
        //{
        //    if (ct.GetType().ToString().Equals("System.Web.UI.WebControls.CheckBox"))
        //    {
        //        CheckBox cb = (CheckBox)ct;
        //        if (cb.Checked == true)
        //        {
        //            stext+=(cb.Text + "<br/>");//这句换成取值
        //        }
        //    }
        //}
        ///Response.Write(stext);
        
        string classid = "0";
        string cbtext1 = "";
         
        string sql = "";
         
        for(int i = 0; i < CheckBoxList1.Items.Count; i++) 
        {
            if (CheckBoxList1.Items[i].Selected == true)
            {
                //这个打勾的
                cbtext1 += CheckBoxList1.Items[i].Value+",";
                if (classid == "0")
                {
                    classid = CheckBoxList1.Items[i].Value;
                }
            }
            else
            {
                //这是没打的
            }
        }
        for (int i = 0; i < CheckBoxList2.Items.Count; i++)
        {
            if (CheckBoxList2.Items[i].Selected == true)
            {
                //这个打勾的
                cbtext1 += CheckBoxList2.Items[i].Value + ",";
                if (classid == "0")
                {
                    classid = CheckBoxList2.Items[i].Value;
                }
            }
            else
            {
                //这是没打的
            }
        }
        for (int i = 0; i < CheckBoxList3.Items.Count; i++)
        {
            if (CheckBoxList3.Items[i].Selected == true)
            {
                //这个打勾的
                cbtext1 += CheckBoxList3.Items[i].Value + ",";
                if (classid == "0")
                {
                    classid = CheckBoxList3.Items[i].Value;
                }
            }
            else
            {
                //这是没打的
            }
        }
        for (int i = 0; i < CheckBoxList4.Items.Count; i++)
        {
            if (CheckBoxList4.Items[i].Selected == true)
            {
                //这个打勾的
                cbtext1 += CheckBoxList4.Items[i].Value + ",";
                if (classid == "0")
                {
                    classid = CheckBoxList4.Items[i].Value;
                }
            }
            else
            {
                //这是没打的
            }
        }
        try { Convert.ToDateTime(cdate.Text); }
        catch
        {
            msg.Text = "时间格式不正确 ！";
            return;
        }

        if (cbtext1 == "")
        {
            msg.Text = "必须选择一个分类";
            return;
        }
        cbtext1 = cbtext1.Substring(0,cbtext1.Length-1);
        if (id == 0)
        {
            sql = "insert into zqhl_news([title],[content],classid,qz,pic,en,sel,writer,author,typename,cdate)values(";
            sql += "'" + Common.strFilter(title.Text) + "','" + Common.strFilter(content1.Text.Replace("&emsp ", "&emsp;")) + "'," + classid + "," + Common.strFilter(qz.Text);
            sql += ",'" + Common.strFilter(pic.Text) + "'," + ((en.Checked) ? "1" : "0") + "," + ((sel.Checked) ? "1" : "0") + ",'" + Common.strFilter(writer.Text) + "','"+ Session["adminloginuser"] + "','" + cbtext1 + "','" + cdate.Text + "')";
        }
        else
        {
            sql = "update zqhl_news set [title]='" + Common.strFilter(title.Text) + "',[content]='" + Common.strFilter(content1.Text.Replace("&emsp ", "&emsp;")) + "',classid=" + classid + ",qz=" + Common.strFilter(qz.Text);
            sql += ",pic='" + Common.strFilter(pic.Text) + "',en=" + ((en.Checked) ? "1" : "0") + ",sel=" + ((sel.Checked) ? "1" : "0") + ",writer='" + Common.strFilter(writer.Text) + "',typename='" + cbtext1 + "',cdate='" + cdate.Text + "'  where id=" + id;
        }
        int count = DBC.getRowsCount(sql);
        if (count > 0) msg.Text = "保存成功"; else msg.Text = "保存失败";
    }
}