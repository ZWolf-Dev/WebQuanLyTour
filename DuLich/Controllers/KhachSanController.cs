using DuLich.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DuLich.Controllers
{
    public class KhachSanController : Controller
    {
        public ActionResult DanhSach()
        {

            return View();
        }
        public ActionResult TimKiem(int idTinh, int idMucGia)
        {
            ViewBag.idTinh = idTinh;
            ViewBag.idMucGia = idMucGia;
            return View(new mapKhachSan().DanhSachTimKiem(idTinh, idMucGia));
        }
        public ActionResult ChiTiet(int idKhachSan)
        {
            return View();
        }
    }
}