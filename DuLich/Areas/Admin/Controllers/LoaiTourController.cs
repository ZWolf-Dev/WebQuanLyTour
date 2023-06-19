using DuLich.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DuLich.Areas.Admin.Controllers
{
    public class LoaiTourController : Controller
    {
        public ActionResult DanhSach()
        {
            mapLoaiTour map = new mapLoaiTour();
            return View(map.DanhSachLoaiTour());
        }
        public PartialViewResult ThemMoi()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult ThemMoi(LoaiTour model)
        {
            mapLoaiTour map = new mapLoaiTour();
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
        public ActionResult CapNhat(int idLoaiTour)
        {
            //Tìm đối tuongj cần sửa
            var map = new mapLoaiTour();
            var loaiEdit = map.ChiTiet(idLoaiTour);
            return View(loaiEdit);

        }
        [HttpPost]
        public ActionResult CapNhat(LoaiTour model)
        {
            mapLoaiTour map = new mapLoaiTour();
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
        public ActionResult Xoa(int idLoaiTour)
        {
            //Gọi hàm xóa trong map
            mapLoaiTour map = new mapLoaiTour();
            map.Xoa(idLoaiTour);
            //Xóa xong quay về trang danh sách
            //return Redirect("/Admin/LoaiTour/DanhSach");
            return RedirectToAction("DanhSach");
        }
    }
}