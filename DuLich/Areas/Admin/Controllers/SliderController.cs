using DuLich.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DuLich.Areas.Admin.Controllers
{
    public class SliderController : Controller
    {
        public ActionResult DanhSach()
        {
            mapSlider map = new mapSlider();
            return View(map.DanhSach());
        }
        public PartialViewResult ThemMoi()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult ThemMoi(Slider model)
        {
            mapSlider map = new mapSlider();
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
        public ActionResult CapNhat(int idSlider)
        {
            //Tìm đối tuongj cần sửa
            var map = new mapSlider();
            var SliderEdit = map.ChiTiet(idSlider);
            return View(SliderEdit);

        }
        [HttpPost]
        public ActionResult CapNhat(Slider model)
        {
            mapSlider map = new mapSlider();
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
        public ActionResult Xoa(int idSlider)
        {
            //Gọi hàm xóa trong map
            mapSlider map = new mapSlider();
            map.Xoa(idSlider);
            //Xóa xong quay về trang danh sách
            //return Redirect("/Admin/MucSlider/DanhSach");
            return RedirectToAction("DanhSach");
        }
        public ActionResult CapNhatAnh(int idSlider)
        {
            return View(new mapSlider().ChiTiet(idSlider));
        }
        //B3: Xử lý ảnh
        [HttpPost]
        public ActionResult CapNhatAnh(int idSlider, HttpPostedFileBase imgSlider)
        {
            //1. Kiểm tra file có tồn tại
            if (imgSlider == null)
            {
                ViewBag.error = "Chưa chọn file";
                return View(new mapSlider().ChiTiet(idSlider));
            }
            else
            {
                //2.Lưu file
                //Đường dẫn thư mục lưu file
                var duongDanTuongDoi = "/Data/imgSlider/";
                //Đường dẫn tuyệt đối
                var duongDanTuyetDoi = Server.MapPath(duongDanTuongDoi);
                //Đường dẫn lưu ảnh = duongDanTuyetDoi + tên hình ảnh
                var ddHinhAnhTuongDoi = duongDanTuongDoi + imgSlider.FileName;
                var ddHinhAnhTuyetDoi = duongDanTuyetDoi + imgSlider.FileName;
                //Lưu
                imgSlider.SaveAs(ddHinhAnhTuyetDoi);
                //3. Lưu thành công thì cập nhật link cho Model(tài khoản)
                new mapTour().DoiHinhAnh(idSlider, ddHinhAnhTuongDoi);

                return RedirectToAction("DanhSach");
            }
        }
    }
}