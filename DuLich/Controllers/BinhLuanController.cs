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
        public ActionResult Create(BinhLuan model, int? idBinhLuan, int maTour, int idAlbum, string MaTaiKhoan, string NoiDung, int? LuotTraLoi)
        {
            if (string.IsNullOrEmpty(model.NoiDung) == true) {
                return RedirectToAction("ChiTiet", "TourDuLich", new { idTour = maTour, idAlbum = idAlbum });
            }
            else
            {
                mapBinhLuan map = new mapBinhLuan();
                map.ThemMoi(model, idBinhLuan, maTour, MaTaiKhoan, NoiDung);
                var loai = "Comment";
                var MaBinhLuan = idBinhLuan;
                Update(MaBinhLuan, null, LuotTraLoi, null, maTour, idAlbum, loai);
                return RedirectToAction("ChiTiet", "TourDuLich", new { idTour = maTour, idAlbum = idAlbum });
            }
        }
        public ActionResult Update(int? MaBinhLuan, int? LuotThich, int? LuotTraLoi, int? LuotChiaSe, int maTour, int idAlbum, string loai)
        {
            mapBinhLuan map = new mapBinhLuan();
            map.CapNhat(MaBinhLuan, LuotThich, LuotTraLoi, LuotChiaSe, loai);
            return RedirectToAction("ChiTiet", "TourDuLich", new { idTour = maTour, idAlbum = idAlbum });
        }

    }
}