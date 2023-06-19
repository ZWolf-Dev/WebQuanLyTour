using DuLich.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DuLich.Areas.Admin.Controllers
{
    public class AlbumController : Controller
    {
        public ActionResult DanhSach()
        {
            mapAlbum map = new mapAlbum();
            return View(map.DanhSachAlbumAnh());
        }
        public PartialViewResult ThemMoi()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult ThemMoi(AlbumAnh model)
        {
            mapAlbum map = new mapAlbum();
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
        public ActionResult CapNhat(int idAlbum)
        {
            //Tìm đối tuongj cần sửa
            var map = new mapAlbum();
            var AlbumEdit = map.ChiTiet(idAlbum);
            return View(AlbumEdit);

        }
        [HttpPost]
        public ActionResult CapNhat(AlbumAnh model)
        {
            mapAlbum map = new mapAlbum();
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
        public ActionResult Xoa(int idAlbum)
        {
            //Gọi hàm xóa trong map
            mapAlbum map = new mapAlbum();
            map.Xoa(idAlbum);
            //Xóa xong quay về trang danh sách
            //return Redirect("/Admin/MucAlbum/DanhSach");
            return RedirectToAction("DanhSach");
        }
        public ActionResult ChiTiet(int id)
        {
            return View(new mapAlbum().ChiTiet(id));
            
        }
        public ActionResult ThemHinhAnh(int idAlbum)
        {
            //1.Tải bộ ckfinder
            //2.add vào thư mục, thêm thư viện dll
            //3.kéo link ckfinder.js vào layout
            //4.cấu hình ckfinder trong file Confix.aspx
            //5.Viết fucntion js tại view
            //6.tạo button với sự kiện gọi fucntion đã viết
            return View(new HinhAnh() {idAlbum = idAlbum});
        }
        [HttpPost]
        public ActionResult ThemHinhAnh(HinhAnh model)
        {
            var map = new mapHinhAnh();
            if (map.ThemMoi(model)>0)
            {
                return RedirectToAction("ChiTiet", new { id = model.idAlbum });
            }
            else
            {
                return View(model);
            }
        }
    }
}