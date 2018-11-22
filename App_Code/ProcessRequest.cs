using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// ProcessRequest 的摘要说明
/// </summary>
public class ProcessRequest
{
    public ProcessRequest()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    public void StartProcessRequest()
    {
        try
        {
            string getkeys = "";
            string sqlErrorPage = "/";
            if (System.Web.HttpContext.Current.Request.QueryString != null)
            {

                for (int i = 0; i < System.Web.HttpContext.Current.Request.QueryString.Count; i++)
                {
                    getkeys = System.Web.HttpContext.Current.Request.QueryString.Keys[i];
                    if (!ProcessSqlStr(System.Web.HttpContext.Current.Request.QueryString[getkeys].ToLower()))
                    {
                        System.Web.HttpContext.Current.Response.Redirect(sqlErrorPage);
                        System.Web.HttpContext.Current.Response.End();
                    }
                }
            }



        }
        catch
        {

        }
    }
    /**/
    /// <summary>
    /// 分析用户请求是否正常
    /// </summary>
    /// <param name="Str">传入用户提交数据</param>
    /// <returns>返回是否含有SQL注入式攻击代码</returns>
    private bool ProcessSqlStr(string Str)
    {
        bool ReturnValue = true;
        try
        {
            if (Str != "" && Str != null)
            {
                string SqlStr = "";
                if (SqlStr == "" || SqlStr == null)
                {
                    SqlStr = "'|and|exec|insert|select|delete|update|count|*|chr|mid|master|truncate|char|declare";
                }
                string[] anySqlStr = SqlStr.Split('|');
                foreach (string ss in anySqlStr)
                {
                    if (Str.IndexOf(ss) >= 0)
                    {
                        ReturnValue = false;
                    }
                }
            }
        }
        catch
        {
            ReturnValue = false;
        }
        return ReturnValue;
    }
}