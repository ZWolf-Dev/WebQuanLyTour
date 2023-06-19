using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using DuLich.Models;
namespace DuLich.App_Start
{
    public class KiemTraQuyen : AuthorizeAttribute
    {
        public string ChucNang { set; get; }
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
                        controller = "TaiKhoan", 
                        action = "DangNhap", 
                        area = "Admin"
                    }));
                return;
            }
            //Nếu ko điền chức năng=>cho phép chạy
            if (string.IsNullOrEmpty(ChucNang))
            {
                return;
            }
            //Kiểm tra quyền
            var db = new DuLichDBEntities();
            var phanQuyen = db.PhanQuyens.Count(m => m.TenDangNhap == User.TenDangNhap & m.MaChucNang == ChucNang);
            if (phanQuyen<=0)
            {
                filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new
                    {
                        controller = "TaiKhoan",
                        action = "BaoChuaPhanQuyen",
                        area = "Admin"
                    }));
                return;
            }
        }
    }
}