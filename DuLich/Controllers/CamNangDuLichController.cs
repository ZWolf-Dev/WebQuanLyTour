using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DuLich.Controllers
{
    public class CamNangDuLichController : Controller
    {
        public ActionResult DanhSach()
        {
            return View();
        }
        public ActionResult BaiViet(int idBaiViet)
        {
            return View();
        }
    }
}