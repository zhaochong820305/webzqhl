using System;

using System.Web;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
/// <summary>
///GridViewToExcel 的摘要说明
/// </summary>
public class GridViewToExcel
{
    HttpResponse Response = null;
    public GridViewToExcel(HttpResponse response)
    {
        Response = response;
    }
    /// <summary>
    /// 将GridView里的数据导入到Excel文件中，并另存文档
    /// </summary>
    /// <param name="FileName">文件名称</param>
    /// <param name="GridViewTeacher">要导出数据的GridView</param>
    public void Export(string FileName, GridView gridview)
    {
        //用来控制添加，删除，编辑等按钮不输出，如果没有，可以隐掉代码!
        Response.Clear();
        Response.Buffer = true;
        //for (int i = 3; i < 5; i++)
        //{
        //    gridview.Columns[i].Visible = false;
        //}
        DateTime dtt = DateTime.UtcNow;
        string date1 = dtt.ToString().Split(' ')[0].ToString();
        FileName = FileName + date1 + ".xls";
        Response.Charset = "GB2312";
        Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(FileName).ToString());
        Response.ContentType = "application/ms-excel";//导出excel文件
        Response.Write("<meta http-equiv=Content-Type content=text/html;charset=GB2312>");
        StringWriter tw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(tw);
        gridview.AllowPaging = false;
        gridview.DataBind();
        gridview.RenderControl(hw);
        Response.Write(tw.ToString());
        Response.End();
    }
    public void Export(string FileType, string FileName, GridView MachineList)
    {

        string style = @"<style>.text{mso-number-format:@}</script>";//导入到excel时,保存表里数字列中前面存在的 0 .

        PrepareGridViewForExport(MachineList);//将模版列显示出来

        Response.Clear();

        Response.Charset = "GB2312";

    //    Response.ContentEncoding = Encoding.UTF7;

        Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(FileName, Encoding.UTF8).ToString());

        Response.ContentType = FileType;

   //     EnableViewState = false;

        MachineList.AllowPaging = false;

        System.Globalization.CultureInfo myCItrad = new System.Globalization.CultureInfo("ZH-CN", true);

        StringWriter sw = new StringWriter();

        HtmlTextWriter htw = new HtmlTextWriter(sw);

        MachineList.RenderControl(htw);

        Response.Write(style);

        Response.Write(sw.ToString());

        //Response.Write(dt.ToString());

        Response.End();

    }

    public void Export(string FileType, string FileName, GridView MachineList,string TitleName1,string TitleName2)
    {

       // string style = @"<style>.text{mso-number-format:@}</script>";//导入到excel时,保存表里数字列中前面存在的 0 .
        string style = "<style>td{mso-number-format:\"\\@\";}</style>";//x.h. 110419 '修正导出excel时丢字符0的问题'


        PrepareGridViewForExport(MachineList);//将模版列显示出来

        Response.Clear();

        Response.Charset = "GB2312";
        Response.ContentEncoding = System.Text.Encoding.UTF8;

        //    Response.ContentEncoding = Encoding.UTF8;

        Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(FileName, Encoding.UTF8).ToString());

        Response.ContentType = FileType;

        //     EnableViewState = false;

        MachineList.AllowPaging = false;

        System.Globalization.CultureInfo myCItrad = new System.Globalization.CultureInfo("ZH-CN", true);

        StringWriter sw = new StringWriter();

        HtmlTextWriter htw = new HtmlTextWriter(sw);

        MachineList.RenderControl(htw);

        Response.Write(style);
        Response.Write("<table><tr><td colspan=8>"+TitleName1+"</td></tr>");
        Response.Write("<tr><td colspan=8>" + TitleName2 + "</td></tr></table>");
        Response.Write(sw.ToString());

        //Response.Write(dt.ToString());

        Response.End();

    }

    public  void PrepareGridViewForExport(Control gv)//模式化特殊元素 flashcong

    {

 

        LinkButton lb = new LinkButton();

        Literal l = new Literal();

        string name = String.Empty;

 

        for (int i = 0; i < gv.Controls.Count; i++)

        {

            

            if (gv.Controls[i].GetType() == typeof(LinkButton))

            {

 

                l.Text = (gv.Controls[i] as LinkButton).Text;

                gv.Controls.Remove(gv.Controls[i]);

                gv.Controls.AddAt(i, l);

 

            }

 

            else if (gv.Controls[i].GetType() == typeof(DropDownList))

            {

 

                l.Text = (gv.Controls[i] as DropDownList).SelectedItem.Text;

                gv.Controls.Remove(gv.Controls[i]);

                gv.Controls.AddAt(i, l);

 

            }

 

            else if (gv.Controls[i].GetType() == typeof(CheckBox))
            {

                l.Text = (gv.Controls[i] as CheckBox).Checked ? "True" : "False";

                gv.Controls.Remove(gv.Controls[i]);

                gv.Controls.AddAt(i, l);

            }

 

            else if (gv.Controls[i].GetType() == typeof(ImageButton))

            {

                l.Text = "图片";

                gv.Controls.Remove(gv.Controls[i]);

                gv.Controls.AddAt(i, l);

            }

            else if (gv.Controls[i].GetType() == typeof(Label))
            {

                l.Text = (gv.Controls[i] as Label).Text;

                gv.Controls.Remove(gv.Controls[i]);

                gv.Controls.AddAt(i, l);

            }

            if (gv.Controls[i].HasControls())

            {

                PrepareGridViewForExport(gv.Controls[i]);

            }

        }

}







}
