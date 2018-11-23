using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
   private DataTable CreateStructure()
   {
        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("CategoryID", typeof(int)));
        dt.Columns.Add(new DataColumn("CategoryName", typeof(string)));
        dt.Columns.Add(new DataColumn("Price", typeof(int)));      
        return dt;
   }
   public DataSet CreateData()
   {
     DataSet ds = new DataSet();
     DataTable dt = this.CreateStructure();

     DataRow drNew = dt.NewRow();      
     drNew = dt.NewRow();
     drNew["CategoryID"] = 1;
     drNew["CategoryName"] = "Apple";
     drNew["Price"] = 2;
     dt.Rows.Add(drNew);

     drNew = dt.NewRow();
     drNew["CategoryID"] = 2;
     drNew["CategoryName"] = "Banana";
     drNew["Price"] = 3;
     dt.Rows.Add(drNew);

     drNew = dt.NewRow();
     drNew["CategoryID"] = 3;
     drNew["CategoryName"] = "Orange";
     drNew["Price"] = 1;
     dt.Rows.Add(drNew);

     drNew = dt.NewRow();
     drNew["CategoryID"] = 4;
     drNew["CategoryName"] = "Radish";
     drNew["Price"] = 2;
     dt.Rows.Add(drNew);

     drNew = dt.NewRow();
     drNew["CategoryID"] = 5;
     drNew["CategoryName"] = "Pen";
     drNew["Price"] = 3;
     dt.Rows.Add(drNew);

     drNew = dt.NewRow();
     drNew["CategoryID"] = 6;
     drNew["CategoryName"] = "Pencil";
     drNew["Price"] = 7;
     dt.Rows.Add(drNew);

     drNew = dt.NewRow();
     drNew["CategoryID"] = 7;
     drNew["CategoryName"] = "Ruler";
     drNew["Price"] = 3;
     dt.Rows.Add(drNew);

     drNew = dt.NewRow();
     drNew["CategoryID"] = 8;
     drNew["CategoryName"] = "Eraser";
     drNew["Price"] = 5;
     dt.Rows.Add(drNew);

     ds.Tables.Add( dt );
     return ds;
   }
   protected void Button1_Click(object sender, EventArgs e)
   {
      this.GridView1.DataSource = this.CreateData();
      this.DataBind();
   }
}
