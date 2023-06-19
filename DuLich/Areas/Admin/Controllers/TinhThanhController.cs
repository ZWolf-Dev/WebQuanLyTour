using DuLich.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DuLich.Areas.Admin.Controllers
{
    public class TinhThanhController : Controller
    {
        public ActionResult DanhSach()
        {
            mapTinhThanh map = new mapTinhThanh();
            return View(map.DanhSachTheoTen());
        }
        public PartialViewResult ThemMoi()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult ThemMoi(TinhThanh model)
        {
            mapTinhThanh map = new mapTinhThanh();
            if (map.ThemMoi(model) == true)
            {
                return RedirectToAction("DanhSach");
            }
            else
            {
                //thông báo lỗi
                ModelState.AddModelError("", map.massage);
                return View(model);
            }
        }
        public ActionResult CapNhat(int idTinh)
        {
            //Tìm đối tuongj cần sửa
            var map = new mapTinhThanh();
            var tinhEdit = map.ChiTiet(idTinh);
            return View(tinhEdit);

        }
        [HttpPost]
        public ActionResult CapNhat(TinhThanh model)
        {
            mapTinhThanh map = new mapTinhThanh();
            if (map.CapNhat(model) == true)
            {
                return RedirectToAction("DanhSach");
            }
            else
            {
                //thông báo lỗi
                ModelState.AddModelError("", map.massage);
                return View(model);
            }
        }
        public ActionResult Xoa(int idTinh)
        {
            //Gọi hàm xóa trong map
            mapTinhThanh map = new mapTinhThanh();
            map.Xoa(idTinh);
            //Xóa xong quay về trang danh sách
            //return Redirect("/Admin/TinhThanh/DanhSach");
            return RedirectToAction("DanhSach");
        }
    }
}