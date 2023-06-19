using DuLich.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DuLich.Areas.Admin.Controllers
{
    public class MucGiaController : Controller
    {
        public ActionResult DanhSach()
        {
            mapMucGia map = new mapMucGia();
            return View(map.DanhSachMucGia());
        }
        public PartialViewResult ThemMoi()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult ThemMoi(Gia model)
        {
            mapMucGia map = new mapMucGia();
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
        public ActionResult CapNhat(int idMucGia)
        {
            //Tìm đối tuongj cần sửa
            var map = new mapMucGia();
            var giaEdit = map.ChiTiet(idMucGia);
            return View(giaEdit);

        }
        [HttpPost]
        public ActionResult CapNhat(Gia model)
        {
            mapMucGia map = new mapMucGia();
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
        public ActionResult Xoa(int idMucGia)
        {
            //Gọi hàm xóa trong map
            mapMucGia map = new mapMucGia();
            map.Xoa(idMucGia);
            //Xóa xong quay về trang danh sách
            //return Redirect("/Admin/MucGia/DanhSach");
            return RedirectToAction("DanhSach");
        }
    }
}