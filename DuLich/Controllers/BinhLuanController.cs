using DuLich.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DuLich.Controllers
{
    public class BinhLuanController : Controller
    {
        // GET: BinhLuan
        [HttpPost]
        public ActionResult Create(BinhLuan model, int? idBinhLuan, int maTour, int idAlbum, string MaTaiKhoan, string NoiDung)
        {
            mapBinhLuan map = new mapBinhLuan();
            map.ThemMoi(model, idBinhLuan, maTour, MaTaiKhoan, NoiDung);
            return RedirectToAction("ChiTiet", "TourDuLich", new { idTour = maTour, idAlbum = idAlbum });
        }
    }
}