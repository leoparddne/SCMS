using System;
using System.Collections.Generic;
using System.Web;

namespace sheyou.Web.Utility
{
    public class JsonUnitily
    {
        /// <summary>
        /// 构建单个元素的Json
        /// </summary>
        /// <param name="name">键名</param>
        /// <param name="value">值</param>
        public static string MsgJson(string name,string value)
        {
            return "{\""+name+"\""+":"+"\""+value+"\"}";
        }
        /// <summary>
        /// 构建一个Json键值对
        /// </summary>
        /// <param name="name">键名</param>
        /// <param name="value">值</param>
        public static string JsonElement(string name, string value)
        {
            return "\"" + name + "\"" + ":" + "\"" + value + "\"";
        }
        /// <summary>
        /// 传进键值字典，返回json
        /// </summary>
        /// <param name="json">键值字典</param>
        public static string Json(Dictionary<string,string> json)
        {
            string res=string.Empty;
            int i = 0;
            res += "{";
            foreach (var dic in json)
            {
                if (i == 0)
                {
                    res += JsonElement(dic.Key, dic.Value);
                }
                else
                {
                    res += ","+JsonElement(dic.Key, dic.Value);
                }
                i++;
            }
            res += "}";
            return res;
        }
        /// <summary>
        /// 传进json字符串数组，返回json数组字符串
        /// </summary>
        /// <param name="jsonArray">json字符串数组</param>
        public static string JsonArray(List<string> jsonArray)
        {
            string res = string.Empty;
           
            
                res += "[";
                if (jsonArray.Count > 0)
                {
                    res += jsonArray[0];
                    for (int i = 1; i < jsonArray.Count; i++)
                    {
                        res += "," + jsonArray[i];
                    }
                }
                res += "]";
           
            return res;
        }
    }
}