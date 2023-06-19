using DuLich.App_Start;
using DuLich.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DuLich.Controllers
{
    public class TaiKhoanHomeController : Controller
    {
        // GET: TaiKhoanHome
        public ActionResult FormDangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FormDangNhap(string tenDangNhap, string matKhau)
        {
            //1. KT ên Dn Mk có trống => Trở về trưng ĐN: Thông báo thiếu tt
            if (string.IsNullOrEmpty(tenDangNhap) == true | string.IsNullOrEmpty(matKhau) == true)
            {
                ViewBag.thongbao = "Thông báo thiếu thông tin";
                return View();
            }
            //2. Tìm TK theo tên DN trong Database
            var taiKhoan = new mapTaiKhoan().ChiTiet(tenDangNhap);
            //3. Kiểm tra tồn tại tài khoản => nếu ko tồn tại => Trở về trang ĐN: tài khoản hoặc mk ko đúng
            if (taiKhoan == null)
            {
                ViewBag.thongbao = "Tài khoản hoặc mật khẩu không đúng";
                ViewBag.tenDangNhap = tenDangNhap;
                return View();
            }
            //4. Kiểm tra MK => Nếu sai => trở về trang DN: TK hoặc MK ko đúng
            string matKhauMaHoa = new Common.MaHoa.MaHoaDuLieu().CreateMd5(matKhau);
            if (taiKhoan.MatKhau != matKhauMaHoa)
            {
                ViewBag.thongbao = "Tài khoản hoặc mật khẩu không đúng";
                ViewBag.tenDangNhap = tenDangNhap;
                return View();
            }
            //5. Kiểm tra tình trạng hoạt động (active) 
            if (taiKhoan.Active != true)
            {
                ViewBag.thongbao = "Tài khoản đang tạm khóa";
                ViewBag.tenDangNhap = tenDangNhap;
                return View();
            }
            //6. TK DN ok: Lưu lại session server
            Session["userhome"] = taiKhoan;

            //7. Lưu cookie
            CookieHelper.Create("user-dulich", taiKhoan.TenDangNhap, DateTime.Now.AddDays(10));
            CookieHelper.Create("pass-dulich", taiKhoan.MatKhau, DateTime.Now.AddDays(10));
            string user = CookieHelper.Get("user-dulich");

            //8. Chuyển hướng sang trang chủ 
            return Redirect("/Home/Index");
        }
        public ActionResult DangXuat()
        {
            Session.Remove("user");
            CookieHelper.Remove("user-dulich");
            CookieHelper.Remove("pass-dulich");
            return Redirect("/Home/Index");
        }
        //B3: Xử lý ảnh
        [HttpPost]
        public ActionResult CapNhatAnh(string tenDangNhap, HttpPostedFileBase avatar)
        {
            //1. Kiểm tra file có tồn tại
            if (avatar == null)
            {
                ViewBag.error = "Chưa chọn file";
                return View(new mapTaiKhoan().ChiTiet(tenDangNhap));
            }
            else
            {
                //2.Lưu file
                //Đường dẫn thư mục lưu file
                var duongDanTuongDoi = "/Data/Avatar/";
                //Đường dẫn tuyệt đối
                var duongDanTuyetDoi = Server.MapPath(duongDanTuongDoi);
                //Đường dẫn lưu ảnh = duongDanTuyetDoi + tên hình ảnh
                var ddHinhAnhTuongDoi = duongDanTuongDoi + avatar.FileName;
                var ddHinhAnhTuyetDoi = duongDanTuyetDoi + avatar.FileName;
                //Lưu
                avatar.SaveAs(ddHinhAnhTuyetDoi);
                //3. Lưu thành công thì cập nhật link cho Model(tài khoản)
                new mapTaiKhoan().DoiHinhAnh(tenDangNhap, ddHinhAnhTuongDoi);

                return Redirect("/Home/Index");
            }
        }
        public PartialViewResult DangKy()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult DangKy(TaiKhoan model, string NhapLaiMatKhau)
        {
            mapTaiKhoan map = new mapTaiKhoan();
            if (NhapLaiMatKhau == model.MatKhau)
            { 
                if (map.ThemMoi(model) == true)
                {
                    return RedirectToAction("FormDangNhap");
                }
                else
                {
                    //thông báo lỗi
                    ModelState.AddModelError("", map.massage);
                    return View(model);
                }
            }
            else
            {
                //thông báo lỗi
                ModelState.AddModelError("Mật khẩu xác nhận phải trùng với mật khẩu!", map.massage);
                return View(model);
            }
        }
        public ActionResult CapNhat(string tenDangNhap)
        {
            //Tìm đối tuongj cần sửa
            var map = new mapTaiKhoan();
            var taiKhoanEdit = map.ChiTiet(tenDangNhap);
            return View(taiKhoanEdit);

        }
        [HttpPost]
        public ActionResult CapNhat(TaiKhoan model)
        {
            mapTaiKhoan map = new mapTaiKhoan();
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
        [KiemTraDangNhap]
        public ActionResult ThongTinTaiKhoan(string tenDangNhap)
        {
            var taiKhoan = new mapTaiKhoan().ChiTiet(tenDangNhap);
            return View(taiKhoan);
        }
        [KiemTraDangNhap]
        public ActionResult DoiMK(string tenDangNhap)
        {
            var taiKhoan = new mapTaiKhoan().ChiTiet(tenDangNhap);
            return View(taiKhoan);
        }
        public ActionResult PhanQuyen(string tenDangNhap, string maChucNang)
        {
            var db = new DuLichDBEntities();
            var phanQuyen = db.PhanQuyens.SingleOrDefault(m => m.TenDangNhap == tenDangNhap & m.MaChucNang == maChucNang);
            if (phanQuyen != null)
            {
                db.PhanQuyens.Remove(phanQuyen);
                db.SaveChanges();
            }
            else
            {
                phanQuyen = new PhanQuyen();
                phanQuyen.TenDangNhap = tenDangNhap;
                phanQuyen.MaChucNang = maChucNang;
                db.PhanQuyens.Add(phanQuyen);
                db.SaveChanges();
            }
            return RedirectToAction("ChiTiet", new { tenDangNhap = tenDangNhap });
        }
        [HttpPost]
        public JsonResult PhanQuyenJson(string tenDangNhap, string maChucNang)
        {
            var db = new DuLichDBEntities();
            var phanQuyen = db.PhanQuyens.SingleOrDefault(m => m.TenDangNhap == tenDangNhap & m.MaChucNang == maChucNang);
            if (phanQuyen != null)
            {
                db.PhanQuyens.Remove(phanQuyen);
                db.SaveChanges();
            }
            else
            {
                phanQuyen = new PhanQuyen();
                phanQuyen.TenDangNhap = tenDangNhap;
                phanQuyen.MaChucNang = maChucNang;
                db.PhanQuyens.Add(phanQuyen);
                db.SaveChanges();
            }
            return Json(new
            {
                status = "Đã phân quyền"
            });
        }
        public ActionResult BaoChuaPhanQuyen()
        {
            return View();
        }
        #region IMPORT
        [KiemTraQuyen]
        public ActionResult Import()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Import(HttpPostedFileBase file)
        {
            string pathBin = "/Data/Bin/";
            DataTable result = DuLich.Helper.ExcelHelper.ReadFileExcel(file, Server.MapPath(pathBin));
            return View();
        }
        #endregion
    }
}