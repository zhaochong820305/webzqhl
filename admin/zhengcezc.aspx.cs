using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class admin_zhengcezc : System.Web.UI.Page
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
        //try
        //{
        //    this.content1.Text = Request.Form["content"];
        //}
        //catch { }
        try
        {
            id = int.Parse(Request.QueryString["id"].ToString());

            if (!Page.IsPostBack)
            {
                DataTable dt;
                //NewMethod(1, CheckBoxList1);
                //NewMethod(2, CheckBoxList2);
                //NewMethod(3, CheckBoxList3);
                //NewMethod(4, CheckBoxList4);
                setting(2, gldiqu);  //地区
                //setting(2, xzdiqu);  //地区
                if (id == 0)
                {
                    //faburiqi.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    //youxiaoqi.Text = DateTime.Now.ToString("yyyy-MM-dd");
                }
                else
                {
                    dt = DBZhengce.getDataTable("select * from zhengce where   id=" + id);
                    if (dt.Rows.Count > 0)
                    {
                        DataRow dr = dt.Rows[0];
                        mingcheng.Text = dr["mingcheng"].ToString();
                        //glchanneng.Text = dr["glchanneng"].ToString();
                        gldiqu.Text = dr["gldiqu"].ToString();
                        //zcshuoming.Text = dr["zcshuoming"].ToString();
                        //gmshuoming.Text = dr["gmshuoming"].ToString();

                        //psshuoming.Text = dr["psshuoming"].ToString();
                        //sbjttiaojian.Text = dr["sbjttiaojian"].ToString();

                        //xzchanneng.Text = dr["xzchanneng"].ToString();
                        //xzdiqu.Text = dr["xzdiqu"].ToString();
                        //xzzhuti.Text = dr["xzzhuti"].ToString();
                        //content.Text = dr["xzfashism"].ToString();

                        if (dr["gldixiang"].ToString().Contains("支持园区/地方（高新区，市等）"))
                        {
                            jishu1_1.Checked = true;
                        }                        
                        if (dr["gldixiang"].ToString().Contains("支持企业（支持央企/国企；不限企业类型）"))
                        {
                            jishu1_2.Checked = true;
                        }

                        if (dr["zczijin"].ToString() == "1")
                        {
                            RadioButton4.Checked = true;
                        }
                        else
                        {
                            RadioButton5.Checked = true;
                        }
                        //if (dr["gldixiang"].ToString().Contains("项目"))
                        //{
                        //    jishu1_3.Checked = true;
                        //}
                        //if (dr["gldixiang"].ToString().Contains("其他"))
                        //{
                        //    jishu1_4.Checked = true;
                        //    txtjishu4_3.Value = dr["gldixiang"].ToString().Substring((dr["gldixiang"].ToString().IndexOf("其他：")+3));
                        //}
                        //else
                        //{
                        //    //msg.Text = dr["gldixiang"].ToString().Contains("其他").ToString(); 
                        //}

                        if (dr["zcjibie"].ToString().Contains("国家中央支持"))
                        {
                            RadioButton6.Checked = true;
                        }
                        if (dr["zcjibie"].ToString().Contains("部委支持"))
                        {
                            RadioButton7.Checked = true;
                        }
                        if (dr["zcjibie"].ToString().Contains("地方支持"))
                        {
                            RadioButton8.Checked = true;
                        }
                        //if (dr["zcjibie"].ToString().Contains("其他"))
                        //{
                        //    CheckBox11.Checked = true;
                        //    Text4.Value = dr["shenbaotj"].ToString().Substring((dr["shenbaotj"].ToString().IndexOf("其他：") + 3));
                        //}
                        //else
                        //{
                        //    //msg.Text = dr["gldixiang"].ToString().Contains("其他").ToString();
                        //}

                        //if (dr["gmfangshi"].ToString().Contains("固定资产投资比例"))
                        //{
                        //    CheckBox4.Checked = true;
                        //}
                        //if (dr["gmfangshi"].ToString().Contains("一定额度资金"))
                        //{
                        //    CheckBox5.Checked = true;
                        //}
                        //if (dr["gmfangshi"].ToString().Contains("退税"))
                        //{
                        //    CheckBox6.Checked = true;
                        //}
                        //if (dr["gmfangshi"].ToString().Contains("其他"))
                        //{
                        //    CheckBox7.Checked = true;
                        //    Text2.Value = dr["gmfangshi"].ToString().Substring((dr["gmfangshi"].ToString().IndexOf("其他：") + 3));
                        //}
                        //else
                        //{
                        //    //msg.Text = dr["gldixiang"].ToString().Contains("其他").ToString();
                        //}



                        //if (dr["zcshijian"].ToString().Contains("投资前"))
                        //{
                        //    CheckBox1.Checked = true;
                        //}
                        //else if (dr["zcshijian"].ToString().Contains("投资后"))
                        //{
                        //    CheckBox2.Checked = true;
                        //}
                        //else if(dr["zcshijian"].ToString().Contains("其他"))
                        //{
                        //    CheckBox3.Checked = true;
                        //    Text1.Value = dr["zcshijian"].ToString().Substring((dr["zcshijian"].ToString().IndexOf("其他：") + 3));
                        //}
                        //else { //msg.Text = dr["zcshijian"].ToString().Contains("其他").ToString(); 
                        //}

                        if (dr["psfangshi"].ToString().Contains("招投标"))
                        {
                            RadioButton1.Checked = true;
                        }
                        else if (dr["psfangshi"].ToString().Contains("评审"))
                        {
                            RadioButton2.Checked = true;
                        }
                        else if (dr["psfangshi"].ToString().Contains("其他"))
                        {
                            RadioButton3.Checked = true;
                            Text3.Value = dr["psfangshi"].ToString().Substring((dr["psfangshi"].ToString().IndexOf("其他：") + 3));
                        }
                        else
                        { 
                            //msg.Text = dr["psfangshi"].ToString().Contains("其他").ToString(); 
                        }

                        //SetChecked(CheckBoxList1, dr["typename"].ToString(), ",");
                        //SetChecked(CheckBoxList2, dr["typename"].ToString(), ",");
                        //SetChecked(CheckBoxList3, dr["typename"].ToString(), ",");
                        //SetChecked(CheckBoxList4, dr["typename"].ToString(), ",");
                    }
                }
            }

            classid = int.Parse(Request.QueryString["class"].ToString());
            page = int.Parse(Request.QueryString["page"].ToString());
        }
        catch { }


    }
    private void setting(int itype, DropDownList ddlname)
    {
        DataTable dt = DBqiye.getDataTable("SELECT  [ID],[Name]  FROM [dbo].[Setting] where SettingID=" + itype + "");
        ddlname.DataSource = dt;
        ddlname.DataTextField = "Name";
        ddlname.DataValueField = "ID";
        ddlname.DataBind();
        ddlname.Items.Insert(0, new ListItem("==未选择==", "0"));
        ddlname.SelectedValue = "";
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


        //try { Convert.ToDateTime(faburiqi.Text); }
        //catch
        //{
        //    msg.Text = "时间格式不正确 ！";
        //    return;
        //}
        //if (pic.Text == "")
        //{
        //    msg.Text = "必须上传图片";
        //    return;
        //}
        //if (cbtext1 == "")
        //{
        //    msg.Text = "必须选择一个分类";
        //    return;
        //}
        //cbtext1 = cbtext1.Substring(0, cbtext1.Length - 1);
        if (id == 0)
        {
            //sql = "insert into zqhl_news([title],[content],classid,qz,pic,en,sel,writer,author,typename,cdate)values(";
            //sql += "'" + Common.strFilter(title.Text) + "','" + Common.strFilter(content1.Text.Replace("&emsp ", "&emsp;")) + "'," + classid + "," + Common.strFilter(qz.Text);
            //sql += ",'" + Common.strFilter(pic.Text) + "'," + ((en.Checked) ? "1" : "0") + "," + ((sel.Checked) ? "1" : "0") + ",'" + Common.strFilter(writer.Text) + "','" + Session["adminloginuser"] + "','" + cbtext1 + "','" + cdate.Text + "')";
            
            //以下字段编辑时上传
            //// ,[glchanneng]           ,[gldiqu]           ,[gldixiang]
            //               ,[zcshijian]           ,[zcshuoming]           ,[gmfangshi]           ,[gmshuoming]
            //               ,[psfangshi]           ,[psshuoming]           ,[shenbaotj]           ,[sbjttiaojian]
            //               ,[xzchanneng]           ,[xzdiqu]           ,[xzzhuti]           ,[xzfashism]
            //              

        }
        else
        {
            string gldixiang = "";
            //string gldixiang = "";
            
            if (jishu1_1.Checked == true) { gldixiang += "支持园区/地方（高新区，市等）"; }//组织机构/企业
            if (jishu1_2.Checked == true) { gldixiang += "支持企业（支持央企/国企；不限企业类型）"; }//个人
            //if (jishu1_3.Checked == true) { gldixiang += "项目,"; }//技术转让
            //if (jishu1_4.Checked == true) { gldixiang += "其他：" + txtjishu4_3.Value.ToString(); }//其他

            string zcshijian = "";
            //string gldixiang = "";

            //if (CheckBox1.Checked == true) { zcshijian = "投资前"; }//投资前
            //if (CheckBox2.Checked == true) { zcshijian = "投资后"; }//投资后          
            //if (CheckBox3.Checked == true) { zcshijian = "其他：" + Text1.Value.ToString(); }//其他

            string psfangshi = "";
            //string gldixiang = "";

            if (RadioButton1.Checked == true) { psfangshi = "招投标"; }//招投标
            if (RadioButton2.Checked == true) { psfangshi = "评审"; }//评审          
            if (RadioButton3.Checked == true) { psfangshi = "其他：" + Text3.Value.ToString(); }//其他

            int zczijin = 0;
            //string gldixiang = "";

            if (RadioButton4.Checked == true) { zczijin = 1; }//固定资产投资比例
            if (RadioButton5.Checked == true) { zczijin = 0; }//一定额度资金
            //if (CheckBox6.Checked == true) { gmfangshi += "退税,"; }//技术转让
            //if (CheckBox7.Checked == true) { gmfangshi += "其他：" + Text2.Value.ToString(); }//其他

            string zcjibie = "";
            //string gldixiang = "";

            if (RadioButton6.Checked == true) { zcjibie += "国家中央支持,"; }//资产/规模要求
            if (RadioButton7.Checked == true) { zcjibie += "部委支持,"; }//企业性质要求
            if (RadioButton8.Checked == true) { zcjibie += "地方支持,"; }//技术要求
            //if (CheckBox11.Checked == true) { shenbaotj += "其他：" + Text4.Value.ToString(); }//其他

            //sql = "update zqhl_news set [title]='" + Common.strFilter(title.Text) + "',[content]='" + Common.strFilter(content1.Text.Replace("&emsp ", "&emsp;")) + "',classid=" + classid + ",qz=" + Common.strFilter(qz.Text);
            //sql += ",pic='" + Common.strFilter(pic.Text) + "',en=" + ((en.Checked) ? "1" : "0") + ",sel=" + ((sel.Checked) ? "1" : "0") + ",writer='" + Common.strFilter(writer.Text) + "',typename='" + cbtext1 + "',cdate='" + cdate.Text + "'  where id=" + id;
            sql = @"update zhengce set  [gldiqu]='" + Common.strFilter(gldiqu.Text) + "' ,[gldixiang]='" + Common.strFilter(gldixiang) + "',[zcshijian]='" + Common.strFilter(zcshijian)
                + "'       ,[zczijin]='" + zczijin + "' ,[zcjibie]='" + Common.strFilter(zcjibie) + "'    ,[psfangshi]='" + Common.strFilter(psfangshi)
                + "'            ,[update]='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where id="+ id +"";
        }
        int count = DBZhengce.getRowsCount(sql);
        if (count > 0) msg.Text = "保存成功"; else msg.Text = "保存失败" + sql;
    }
}