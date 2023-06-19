using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using DuLich.Models;
namespace DuLich.App_Start
{
    public class KiemTraDangNhap : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var User = (TaiKhoan)HttpContext.Current.Session["user"];
            //Nếu user chưa có trong session, thì kiểm tra cookie
            string user = CookieHelper.Get("user-dulich");
            string pass = CookieHelper.Get("pass-dulich");
            var taiKhoan = new mapTaiKhoan().ChiTiet(user);
            if(taiKhoan != null)
            {
                if(taiKhoan.MatKhau == pass)
                {
                    User = taiKhoan;
                    HttpContext.Current.Session["user"] = taiKhoan;
                }
            }

            //Nếu chưa có session thì chuyển về trang đăng nhập
            if (User == null)
            {
                filterContext.Result = new RedirectToRouteResult(new 
                    RouteValueDictionary(new 
                    { 
                        controller = "TaiKhoanHome", 
                        action = "FormDangNhap"
                    }));
                return;
            }  
        }
    }
}