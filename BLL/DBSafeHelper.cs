using System;
using System.Text.RegularExpressions;

namespace BLL
{
    public class DBSafeHelper
    {
        /// <summary>
        /// 检查字符串，防sql注入
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns>true.安全, false.不安全</returns>
        public static bool ProcessSqlStr(string inputString)
        {
            string SqlStr = @"and|or|exec|execute|insert|select|delete|update|alter|create|drop|count|\*|chr|char|asc|mid|substring|master|truncate|declare|xp_cmdshell|restore|backup|net +user|net +localgroup +administrators";
            try
            {
                if ((inputString != null) && (inputString != String.Empty))
                {
                    string str_Regex = @"\b(" + SqlStr + @")\b";

                    Regex Regex = new Regex(str_Regex, RegexOptions.IgnoreCase);
                    //string s = Regex.Match(inputString).Value; 
                    if (true == Regex.IsMatch(inputString))
                        return false;

                }
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
