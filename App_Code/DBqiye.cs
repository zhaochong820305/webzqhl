using System;
using System.Collections.Generic;
 
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
/// <summary>
/// DBqiye 的摘要说明
/// </summary>
public class DBqiye
{
    public DBqiye()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    //public static string path = AppDomain.CurrentDomain.BaseDirectory.ToString();
    public static string sqlConnectionstr = string.Empty;
    public static int sockettimeout = 180;
    public static int sendtimeout = 180;
    public static int receivetimeout = 180;
    public static void WriteDiskLog(string Log)
    {
        string path = "";
        path = Config.PATH + "\\log\\" + DateTime.Today.ToString("yyyy-MM-dd") + ".log";
        try
        {
            StreamWriter sw = new StreamWriter(path, true);
            sw.WriteLine(Log);
            //sw.WriteLine("From the StreamWriter class");
            sw.Close();
        }
        catch
        { }
    }
    public static string _getParaValue(string para)
    {
        string value = string.Empty;
        DataTable dt = DBqiye.getDataTable("select value from syspara where para='" + para + "'");
        if (dt.Rows.Count > 0)
        {
            value = dt.Rows[0][0].ToString();
        }
        return value;
    }

    public static string _getSettingName(string sid)
    {
        string value = string.Empty;
        DataTable dt = DBqiye.getDataTable("SELECT TOP 1 [Name]  FROM [dbo].[Setting] where id='" + sid + "'");
        if (dt.Rows.Count > 0)
        {
            value = dt.Rows[0][0].ToString();
        }
        return value;
    }

    public static SqlConnection createConnection()
    {
        if (sqlConnectionstr.Length.Equals(0))
        {
            try
            {
                //sqlConnectionstr = "Data Source=(local);Initial Catalog=zqhl;Integrated Security=false;User ID=zqhl;Password=zqhl123456";
                // sqlConnectionstr = "Data Source=HAIER-PC\\SQLEXPRESS;Initial Catalog=ZhongQiHuiLian;Integrated Security=false;User ID=sa;Password=sa@1234";
                sqlConnectionstr = ConfigurationManager.ConnectionStrings["SqlConnStrqiye"].ConnectionString;
                WriteDiskLog(sqlConnectionstr);
            }
            catch (Exception ex)
            { WriteDiskLog(ex.Message); }
        }
        SqlConnection con = new SqlConnection(sqlConnectionstr);
        return con;
    }
    public static DataSet getData(string sql)
    {
        SqlConnection con = DBqiye.createConnection();
        con.Open();
        SqlCommand cmd = new SqlCommand(sql, con);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        sda.Fill(ds, "dataTable");
        con.Close();
        if (Common._sqllog) { Common.WriteDiskSql(sql); }
        return ds;
    }
    public static int getSelectRowsCount(string sql)
    {
        try
        {
            SqlConnection con = DBqiye.createConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            if (Common._sqllog) { Common.WriteDiskSql(sql); }
            return dt.Rows.Count;
        }
        catch (Exception ex)
        {
            WriteDiskLog("getDataTable:" + ex.Message + ",sql:" + sql); return -1;
        }
    }
    public static void setDataLogs(string devid, string content, string oper)
    {
        getRowsCount("insert into oplogs(devid,content,oper)values(" + devid + ",'" + content + "','" + oper + "')");
    }
    public static void setDataMLogs(string title, string content, string ip, string oper)
    {
        getRowsCount("insert into syslogs(title,content,ip,oper)values('" + title + "','" + content + "','" + ip + "','" + oper + "')");
    }
    public static string getValue(string sql)
    {
        string rt = "0";
        try
        {
            SqlConnection con = DBqiye.createConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            if (dt.Rows.Count > 0)
            {
                rt = dt.Rows[0][0].ToString();
            }
        }
        catch (Exception ex)
        {
            WriteDiskLog("getDataTable:" + ex.Message + ",sql:" + sql); ;
        }
        if (Common._sqllog) { Common.WriteDiskSql(sql); }
        return rt;
    }

    public static int getRowsCount(string sql)
    {
        try
        {
            SqlConnection con = DBqiye.createConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            int count = cmd.ExecuteNonQuery();
            con.Close();
            if (Common._sqllog) { Common.WriteDiskSql(sql); }
            //WriteDiskLog("getRowsCount:sql:" + sql); //return 0;
            return count;
        }
        catch (Exception ex)
        {
            WriteDiskLog("getRowsCount:" + ex.Message + ",sql:" + sql); return 0;
        }
    }

    public static int getRowsreturnid(string sql)
    {
        try
        {
            SqlConnection con = DBqiye.createConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            int count = 0;//cmd.ExecuteNonQuery();
            count =Convert.ToInt32( cmd.ExecuteScalar()); 
            con.Close();
            if (Common._sqllog) { Common.WriteDiskSql(sql); }
            //WriteDiskLog("getRowsCount:sql:" + sql); //return 0;
            return count;
        }
        catch (Exception ex)
        {
            WriteDiskLog("getRowsCount:" + ex.Message + ",sql:" + sql); return 0;
        }
    }
    public static DataTable getDataTable(string sql)
    {
        DataTable dt = null;
        try
        {
            SqlConnection con = DBqiye.createConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            if (Common._sqllog) { Common.WriteDiskSql(sql); }
        }
        catch (Exception ex)
        {
            WriteDiskLog("getDataTable:" + ex.Message + ",sql:" + sql);
        }
        return dt;
    }
}