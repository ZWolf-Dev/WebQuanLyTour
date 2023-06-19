using DuLich.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DuLich.Areas.Admin.Controllers
{
    public class TourController : Controller
    {
        public ActionResult DanhSach()
        {
            mapTour map = new mapTour();
            return View(map.DanhSachTour(null, null, null));
        }
        public PartialViewResult ThemMoi()
        {
            return PartialView(new TourDuLich());
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemMoi(TourDuLich model)
        {
            mapTour map = new mapTour();
            if (map.ThemMoi(model)==true)
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
        public ActionResult CapNhat(int idTour)
        {
            //Tìm đối tuongj cần sửa
            var map = new mapTour();
            var tourEdit = map.ChiTiet(idTour);
            return View(tourEdit);
            
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CapNhat(TourDuLich model)
        {
            mapTour map = new mapTour();
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
        public ActionResult Xoa(int idTour)
        {
            //Gọi hàm xóa trong map
            mapTour map = new mapTour();
            map.Xoa(idTour);
            //Xóa xong quay về trang danh sách
            //return Redirect("/Admin/Tour/DanhSach");
            return RedirectToAction("DanhSach");
        }
        //B2:Tạo form
        public ActionResult CapNhatAnh(int idTour)
        {
            return View(new mapTour().ChiTiet(idTour));
        }
        //B3: Xử lý ảnh
        [HttpPost]
        public ActionResult CapNhatAnh(int idTour, HttpPostedFileBase imgTour)
        {
            //1. Kiểm tra file có tồn tại
            if (imgTour == null)
            {
                ViewBag.error = "Chưa chọn file";
                return View(new mapTour().ChiTiet(idTour));
            }
            else
            {
                //2.Lưu file
                //Đường dẫn thư mục lưu file
                var duongDanTuongDoi = "/Data/imgTour/";
                //Đường dẫn tuyệt đối
                var duongDanTuyetDoi = Server.MapPath(duongDanTuongDoi);
                //Đường dẫn lưu ảnh = duongDanTuyetDoi + tên hình ảnh
                var ddHinhAnhTuongDoi = duongDanTuongDoi + imgTour.FileName;
                var ddHinhAnhTuyetDoi = duongDanTuyetDoi + imgTour.FileName;
                //Lưu
                imgTour.SaveAs(ddHinhAnhTuyetDoi);
                //3. Lưu thành công thì cập nhật link cho Model(tài khoản)
                new mapTour().DoiHinhAnh(idTour, ddHinhAnhTuongDoi);

                return RedirectToAction("DanhSach");
            }
        }
    }
}