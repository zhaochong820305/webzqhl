using System;
using System.Collections.Generic;
 
using System.Web;
using System.Text;

/// <summary>
/// MD5 的摘要说明
/// </summary>
public class MD5
{
    public MD5()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    public static string CreateMD5Hash(string input)
    {
        // Use input string to calculate MD5 hash
        System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
        //byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
        byte[] inputBytes = Encoding.Unicode.GetBytes(input);
        byte[] hashBytes = md5.ComputeHash(inputBytes);

        // Convert the byte array to hexadecimal string  StringBuilder sb = new StringBuilder();
        StringBuilder sb = new StringBuilder(64);
        for (int i = 0; i < hashBytes.Length; i++)
        {
            sb.Append(hashBytes[i].ToString("X2"));
            // To force the hex string to lower-case letters instead of
            // upper-case, use he following line instead:
            // sb.Append(hashBytes[i].ToString("x2")); 
        }
        return sb.ToString();
    }


    //public static string CreateMD5Hash1(string strText)
    //{
    //    MD5 md5 = new MD5CryptoServiceProvider();
    //    byte[] buffer = md5.ComputeHash(Encoding.Unicode.GetBytes(strText)); //Encoding.Unicode.GetBytes(strText));
    //    string strReturn = BytesToHexString(buffer);
    //    return strReturn;
    //}
    //public static string MakeMD5String(string strText)
    //{
    //    MD5 md5 = new MD5CryptoServiceProvider();
    //    byte[] buffer = md5.ComputeHash(Encoding.Unicode.GetBytes(strText));
    //    string strReturn = BytesToHexString(buffer);
    //    return strReturn;
    //}


    #region 把Byte[]转为16进制串
    /// <summary>
    /// 把Byte[]转为16进制串
    /// </summary>
    /// <param name="input">待转换Byte【】</param>
    /// <returns>16进制串</returns>
    /// <version>1.0</version>
    /// <date>2010-1-19</date>
    /// <author>张百林</author>
    public static string BytesToHexString(byte[] input)
    {
        if (null == input)
            return string.Empty;
        else
        {
            StringBuilder sb = new StringBuilder(64);
            for (int i = 0; i < input.Length; i++)
            {
                sb.Append(input[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }


    #endregion
}