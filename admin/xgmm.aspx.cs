using System;
using System.Collections.Generic;
 
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class admin_xgmm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Common.isAdminLogin())
        {
            Response.Redirect("login.aspx");
            Response.End();
        }
        //if (!Common.isAdminLogin())
        //{ Response.End(); }
        if (!Page.IsPostBack)
        {
            try
            {
                int id = Convert.ToInt32(Session["userid"].ToString());
                
                DataTable dt;
                dt = DBqiye.getDataTable(@"select *  from  [User] where UserID=" + id + "    ");


                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];

                    RealName.Text = dr["RealName"].ToString();
                    tbUser.Text = dr["LoginName"].ToString();
                    //tbPass.Text = dr["Password"].ToString();
                    //tbTitles.SelectedValue = dr["Title"].ToString();
                    //ddlSex.SelectedIndex = Convert.ToInt16(dr["Sex"].ToString());
                    tbEmail.Text = dr["Email"].ToString();
                    tbTel.Text = dr["MobilePhone"].ToString();
                    tbOfficTel.Text = dr["OfficePhone"].ToString();

                    tbHomeTel.Text = dr["HomePhone"].ToString();
                    //ddlDept.SelectedValue = dr["DepartmentID"].ToString();
                    tbEmail.Text = dr["Email"].ToString();
                    imgh.ImageUrl = dr["Qrcode"].ToString();
                    Image1.ImageUrl = dr["HeadPicture"].ToString();
                    //if (dr["Enabled"].ToString() == "True")
                    //{
                    //    cbQiYong.Checked = true;
                    //}
                    //else
                    //{
                    //    cbQiYong.Checked = false;
                    //}
                    //if (dr["IsAgent"].ToString() == "True")
                    //{
                    //    cbZuoXi.Checked = true;
                    //}
                    //else
                    //{
                    //    cbZuoXi.Checked = false;
                    //}
                }
            }
            catch
            {
                //myGrid. = 0;
                Label1.Text = "读数据库错误";
            }
            finally
            {

            }
        }
    }
    
    protected void Button2_Click(object sender, EventArgs e)
    {
        msgb.Text = "";
        if (newpass.Text.Length == 0) { msgb.Text = "新密码不能为空"; return; }
        if (!newpass.Text.Equals(confirmpass.Text)) { msgb.Text = "新密码和确认密码不符"; return; }
        DataTable dt = DBqiye.getDataTable("select Password from [User] where UserID='" + Session["userid"] + "'");// + Session["userid"].ToString());
        if (dt.Rows.Count > 0)
        {
            if (!dt.Rows[0][0].ToString().Equals(MD5.CreateMD5Hash(passwd.Text))) { msgb.Text = "旧密码不正确"; return; }
        }
        string sql = "update [User] set Password='" + MD5.CreateMD5Hash(newpass.Text) + "' where UserID='" + Session["userid"] + "'";// + Session["userid"].ToString();
        int count = DBqiye.getRowsCount(sql);
        if (count > 0) msgb.Text = "修改成功"; else msgb.Text = "修改失败";
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        if (tbUser.Text.Length < 3)
        {
            Label1.Text = ("登陆名，必须 大于3位字符 ");
            return;
        }
        if (RealName.Text.Length < 1)
        {
            Label1.Text = ("姓名，必须 大于1位字符 ");
            return;
        }


        if (tbTel.Text.Length < 11 || tbTel.Text.Length > 15)
        {
            Label1.Text = ("手机号，必须是11-15位字符 ");
            return;
        }
        if (tbOfficTel.Text.Length < 7 || tbOfficTel.Text.Length > 20)
        {
            Label1.Text = ("办公电话，必须是7-20位字符 ");
            return;
        }
        //if (tbHomeTel.Text.Length < 7 || tbHomeTel.Text.Length > 20)
        //{
        //    Label1.Text = ("家庭电话，必须是7-20位字符 ");
        //    return;
        //}
        if (!tbEmail.Text.Contains("@") && (!tbEmail.Text.Contains(".")))
        {
            Label1.Text = ("电子邮件，格式 必须正确 ");
            return;
        }
        Label1.Text = "";
        string ext = "";
        string file = "";
        string filename = "";

        string sql = "";
        {
            sql = @"update [dbo].[User] set [Email]='" + tbEmail.Text
                + "' ,[MobilePhone] ='" + tbTel.Text + "'          ,[OfficePhone]='" + tbOfficTel.Text + "'  ,[RealName]='" + RealName.Text + "'          ,[HomePhone]='" + tbHomeTel.Text
                + "'               ";
        }
        if (upfile1.FileName.Length>4)
        {
            if (!upfile1.HasFile) { Label1.Text = "请选择文件后上传"; return; }
            if (upfile1.FileBytes.Length > 1024 * 1024)
            { Label1.Text = "文件不能大于1M"; return; }
            ext = upfile1.FileName.Substring(upfile1.FileName.Length - 3).ToLower();
            if (ext != "png" && ext != "jpg" && ext != "gif")
            {
                Label1.Text = "文件格式只能是png或jpg"; return;
            }
             file = DateTime.Now.ToString("yyyMMddHHmmss.ss");
             filename = Server.MapPath("~/upload/") + file + "." + ext;
            upfile1.SaveAs(filename);
            //pic.Text = "/upload/" + file + "." + ext;
            imgh.ImageUrl = "/upload/" + file + "." + ext;
            //DBC.getRowsCount("update users set headimg='" + headimg.Text + "' where id=" + Session["userid"].ToString());
            //imgh.ImageUrl = imgh.ImageUrl;
            //Session["headimg"] = imgh.ImageUrl;
            //Global.ROOM.updateheadIMG(ulong.Parse(Session["userid"].ToString()), imgh.ImageUrl);
            sql += " ,[Qrcode]='" + "/upload/" + file + "." + ext + "' ";
        }
        Label1.Text = "上传成功";
        string sid = Session["userid"].ToString();
        string ext1 = "";
        string file1 = "";
        string filename1 = "";
        if (FileUpload1.FileName.Length>4)
        {
            if (!FileUpload1.HasFile && Image1.ImageUrl.Length == 0) { Label1.Text = "请选择文件后上传"; return; }
            if (FileUpload1.FileBytes.Length > 1024 * 1024)
            { Label1.Text = "文件不能大于1M"; return; }
            ext1 = FileUpload1.FileName.Substring(FileUpload1.FileName.Length - 3).ToLower();
            if (ext1 != "png" && ext1 != "jpg" && ext1 != "gif")
            {
                Label1.Text = "文件格式只能是png或jpg"; return;
            }
            file1 = DateTime.Now.ToString("yyyMMddHHmmss.ss");
            filename1 = Server.MapPath("~/upload/") + file1 + "." + ext1;
            FileUpload1.SaveAs(filename1);
            Image1.ImageUrl = "/upload/" + file1 + "." + ext1;
            sql += "  ,[HeadPicture]='" + "/upload/" + file1 + "." + ext1 + "'     ";

        }
        sql += "  where UserID=" + sid  ;
        //string sql = "";        
        //{
        //    sql = @"update [dbo].[User] set [Email]='" + tbEmail.Text
        //        + "' ,[MobilePhone] ='" + tbTel.Text + "'          ,[OfficePhone]='" + tbOfficTel.Text + "'           ,[HomePhone]='" + tbHomeTel.Text
        //        + "'  ,[Qrcode]='"+ "/upload/" + file + "." + ext + "'    ,[HeadPicture]='" + "/upload/" + file1 + "." + ext1 + "'               where UserID=" + sid;
        //}

        int count = DBqiye.getRowsCount(sql);
        if (count > 0) Label1.Text = "保存成功"; else Label1.Text = "保存失败";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Label1.Text = "";
        if (!upfile1.HasFile) { Label1.Text = "请选择文件后上传"; return; }
        if (upfile1.FileBytes.Length > 1024 * 1024)
        { Label1.Text = "文件不能大于1M"; return; }
        string ext = upfile1.FileName.Substring(upfile1.FileName.Length - 3).ToLower();
        if (ext != "png" && ext != "jpg" && ext != "gif")
        {
            Label1.Text = "文件格式只能是png或jpg"; return;
        }
        string file = DateTime.Now.ToString("yyyMMddHHmmss.ss");
        string filename = Server.MapPath("~/upload/") + file + "." + ext;
        upfile1.SaveAs(filename);
        //pic.Text = "/upload/" + file + "." + ext;
        imgh.ImageUrl = "/upload/" + file + "." + ext;
        //DBC.getRowsCount("update users set headimg='" + headimg.Text + "' where id=" + Session["userid"].ToString());
        //imgh.ImageUrl = imgh.ImageUrl;
        //Session["headimg"] = imgh.ImageUrl;
        //Global.ROOM.updateheadIMG(ulong.Parse(Session["userid"].ToString()), imgh.ImageUrl);
        Label1.Text = "上传成功";
    }
}