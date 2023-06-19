using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DuLich.App_Start
{
    public static class CookieHelper
    {
        public static void Create(string name,string value,DateTime expire)
        {
            HttpCookie cookie = new HttpCookie(name);
            cookie.Value = value;
            cookie.Expires = expire;
            //DateTime.Now.AddDays(7)
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
        public static string Get(string name)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[name];
            if(cookie != null)
            {
                return cookie.Value;
            }
            else
            {
                return "";
            }
        }
        public static void Remove(string name)
        {
            if (HttpContext.Current != null)
            {
                int cookieCount = HttpContext.Current.Request.Cookies.Count;
                for (var i = 0; i < cookieCount; i++)
                {
                    var cookie = HttpContext.Current.Request.Cookies[name];
                    if (cookie != null)
                    {

                        var expiredCookie = new HttpCookie(name)
                        {
                            Expires = DateTime.Now.AddDays(-1)
                        };
                        HttpContext.Current.Response.Cookies.Add(expiredCookie);
                    }
                }
                // clear cookies server side
                HttpContext.Current.Request.Cookies.Clear();
            }
        }
    }
}