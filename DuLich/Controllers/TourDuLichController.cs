using DuLich.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DuLich.App_Start;
using System.Web.Mvc;
using System.Configuration;
using Common;

namespace DuLich.Controllers
{
    public class TourDuLichController : Controller
    {
        public ActionResult DanhSach(int? idLoaiTour)
        {
            ViewBag.idLoaiTour = idLoaiTour;
            return View(new mapTour().DanhSachTheoLoaiTour(idLoaiTour));
        }
        public ActionResult DanhSachTheoTinh(int? idTinh)
        {
            ViewBag.idTinh = idTinh;
            return View(new mapTour().DanhSachTheoTinh(idTinh));
        }
        public ActionResult KetQuaTimKiem(int? idTinh, int? idLoaiTour, int? idMucGia, string ten)
        {
            if (!String.IsNullOrEmpty(ten))
            {
                ViewBag.Ten = ten;
                return View(new mapTour().DanhSachTheoTen(ten));
            } else {
                ViewBag.idTinh = idTinh;
                ViewBag.idLoaiTour = idLoaiTour;
                ViewBag.idMucGia = idMucGia;
                return View(new mapTour().DanhSachTour(idTinh, idLoaiTour, idMucGia));
            }
        }
        public ActionResult DanhSachTheoKieu(int idKieuTour, int idLoaiTour)
        {
            return View();
        }
        [KiemTraDangNhap]
        public ActionResult ChiTiet(int idTour, int? idAlbum)
        {
            ViewBag.IdAlbum = idAlbum;
            var tour = new mapTour().ChiTiet(idTour);
            return View(tour);
        }

        [KiemTraDangNhap]
        public ActionResult DatTour(int idTour, int? nguoilon, int? treem, string phuongtien)
        {
            ViewBag.NguoiLon = nguoilon;
            ViewBag.TreEm = treem;
            ViewBag.PhuongTien = phuongtien;
            var tour = new mapTour().ChiTiet(idTour);
            return View(tour);
        }
        //danh sach theo tinh
        [HttpPost]
        public ActionResult DatTour(int idTour, string tenDangNhap, string firstName, string lastName, string email, int soDienThoai, int dayKH, int monthKH, int yearKH, int dayTV, int monthTV, int yearTV, string diaChiDon, string diaChiTha, string tourTuyChinh, int idPhuongTien, int nguoiLon, int treEm, string tinNhan)
        {
            DuLichDBEntities db = new DuLichDBEntities();
            var datTour = new DatTour();
            datTour.taiKhoan = tenDangNhap;
            datTour.Ten = firstName + " " + lastName;
            datTour.Email = email;
            datTour.SoDienThoai = soDienThoai;
            datTour.NgayKhoiHanh = (dayKH + "/" + monthKH + "/" + yearKH).ToString();
            datTour.NgayTroVe = (dayTV + "/" + monthTV + "/" + yearTV).ToString();
            datTour.DiaChiDon = diaChiDon;
            datTour.DiaChiTha = diaChiTha;
            datTour.TourTuyChinh = tourTuyChinh ?? null;
            var phuongTien = new mapPhuongTien().ChiTiet(idPhuongTien);
            datTour.LoaiXe = phuongTien.Ten;
            var soLuong = nguoiLon + treEm;
            datTour.SoLuongHanhKhach = soLuong;
            datTour.SoLuongNguoiLon = nguoiLon;
            datTour.SoLuongTreEm = treEm;
            datTour.TinNhan = tinNhan ?? null;
            datTour.TrangThai = false;
            try
            {
                db.DatTours.Add(datTour);
                db.SaveChanges();
                //add dattourdetail
                var datTourDetail = new DatTourDetail();
                datTourDetail.idTour = idTour;
                datTourDetail.idDatTour = datTour.ID;
                var tour = new mapTour().ChiTiet(idTour);
                datTourDetail.Gia = tour.GiaTour;
                db.DatTourDetails.Add(datTourDetail);
                db.SaveChanges();

                //Xử lý giá
                var TieuDe = new mapTour().ChiTiet(idTour).TieuDe;
                var SoNguoiToiDa = new mapTour().ChiTiet(idTour).SoNguoiToiDa;
                var SoNgayDiTour = new mapTour().ChiTiet(idTour).SoNgayDiTour;
                var SNDTKhachHangNhap = dayTV - dayKH;
                var GiaTour = ((int)tour.GiaTour.GetValueOrDefault(0));
                var GiaTB = GiaTour / SoNgayDiTour;
                var Gia = GiaTour;

                if (phuongTien.DonVi != "Ngày")
                {
                    if (phuongTien.DonVi == "Chuyến")
                    {
                        if (SNDTKhachHangNhap == 0 && soLuong == SoNguoiToiDa)
                        {
                            Gia = GiaTour;
                        }
                        else
                        {
                            if (SNDTKhachHangNhap > SoNgayDiTour && soLuong > SoNguoiToiDa)
                            {
                                Gia = (int)(GiaTour - phuongTien.Gia + ((SNDTKhachHangNhap - SoNgayDiTour) * GiaTB) + (100000 * (soLuong - SoNguoiToiDa)));
                            }
                            else
                            {
                                Gia = (int)(GiaTour - phuongTien.Gia - ((SoNgayDiTour - SNDTKhachHangNhap) * GiaTB) - (100000 * (SoNguoiToiDa - soLuong)));
                            }
                        }
                    }
                    if (phuongTien.DonVi == "Người")
                    {
                        if (SNDTKhachHangNhap == 0 && soLuong == SoNguoiToiDa)
                        {
                            Gia = GiaTour;
                        }
                        else
                        {
                            if (SNDTKhachHangNhap > SoNgayDiTour && soLuong > SoNguoiToiDa)
                            {
                                Gia = (int)(GiaTour - (phuongTien.Gia * soLuong) + ((SNDTKhachHangNhap - SoNgayDiTour) * GiaTB) + (100000 * (soLuong - SoNguoiToiDa)));
                            }
                            else
                            {
                                Gia = (int)(GiaTour - (phuongTien.Gia * soLuong) - ((SoNgayDiTour - SNDTKhachHangNhap) * GiaTB) - (100000 * (SoNguoiToiDa - soLuong)));
                            }
                        }
                    }
                    if (phuongTien.DonVi == "Giờ")
                    {
                        if (SNDTKhachHangNhap == 0 && soLuong == SoNguoiToiDa)
                        {
                            Gia = GiaTour;
                        }
                        else
                        {
                            if (SNDTKhachHangNhap > SoNgayDiTour && soLuong > SoNguoiToiDa)
                            {
                                Gia = (int)(GiaTour - (phuongTien.Gia * (24 * (SNDTKhachHangNhap - SoNgayDiTour))) + ((SNDTKhachHangNhap - SoNgayDiTour) * GiaTB) + (100000 * (soLuong - SoNguoiToiDa)));
                            }
                            else
                            {
                                Gia = (int)(GiaTour - (phuongTien.Gia * (24 * (SoNgayDiTour - SNDTKhachHangNhap))) - ((SoNgayDiTour - SNDTKhachHangNhap) * GiaTB) - (100000 * (SoNguoiToiDa - soLuong)));
                            }
                        }
                    }
                }
                else
                {
                    if (SNDTKhachHangNhap == 0 && soLuong == SoNguoiToiDa)
                    {
                        Gia = GiaTour;
                    }
                    else
                    {
                        if (SNDTKhachHangNhap > SoNgayDiTour && soLuong > SoNguoiToiDa)
                        {
                            Gia = (int)(GiaTour - (phuongTien.Gia * (SNDTKhachHangNhap - SoNgayDiTour)) + ((SNDTKhachHangNhap - SoNgayDiTour) * GiaTB) + (100000 * (soLuong - SoNguoiToiDa)));
                        }
                        else
                        {
                            Gia = (int)(GiaTour - (phuongTien.Gia * (SoNgayDiTour - SNDTKhachHangNhap)) - ((SoNgayDiTour - SNDTKhachHangNhap) * GiaTB) - (100000 * (SoNguoiToiDa - soLuong)));
                        }
                    }
                }

                //SendAdmin
                string content = System.IO.File.ReadAllText(Server.MapPath("~/Content/sendmail/sendAdmin.html"));
                content = content.Replace("{{MaDatTour}}", idTour.ToString());
                content = content.Replace("{{TenKhachHang}}", firstName + lastName);
                content = content.Replace("{{TenTour}}", TieuDe);
                content = content.Replace("{{SoLuongHanhKhach}}", soLuong.ToString());
                content = content.Replace("{{SoDienThoai}}", soDienThoai.ToString());
                content = content.Replace("{{Email}}", email);
                content = content.Replace("{{LoaiXe}}", phuongTien.Ten);
                content = content.Replace("{{NgayKhoiHanh}}", (dayKH + "/" + monthKH + "/" + yearKH).ToString());
                content = content.Replace("{{NgayTroVe}}", (dayTV + "/" + monthTV + "/" + yearTV).ToString());
                content = content.Replace("{{DiaChiTha}}", diaChiTha);
                content = content.Replace("{{DiaChiDon}}", diaChiDon);
                content = content.Replace("{{GhiChu}}", tinNhan ?? "");
                content = content.Replace("{{GiaTour}}", Gia.ToString("N0"));
                var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();
                new MailHelper().SendMail(toEmail, "Đơn đặt tuor", content);

                //SendCustomer
                string content1 = System.IO.File.ReadAllText(Server.MapPath("~/Content/sendmail/sendCustomer.html"));
                content1 = content1.Replace("{{MaDatTour}}", idTour.ToString());
                content1 = content1.Replace("{{TenKhachHang}}", firstName + lastName);
                content1 = content1.Replace("{{TenTour}}", TieuDe);
                content1 = content1.Replace("{{SoLuongHanhKhach}}", soLuong.ToString());
                content1 = content1.Replace("{{SoDienThoai}}", soDienThoai.ToString());
                content1 = content1.Replace("{{Email}}", email);
                content1 = content1.Replace("{{LoaiXe}}", phuongTien.Ten);
                content1 = content1.Replace("{{NgayKhoiHanh}}", (dayKH + "/" + monthKH + "/" + yearKH).ToString());
                content1 = content1.Replace("{{NgayTroVe}}", (dayTV + "/" + monthTV + "/" + yearTV).ToString());
                content1 = content1.Replace("{{DiaChiTha}}", diaChiTha);
                content1 = content1.Replace("{{DiaChiDon}}", diaChiDon);
                content1 = content1.Replace("{{GiaTour}}", Gia.ToString("N0"));
                new MailHelper().SendMail(email, "Đơn đặt tuor", content1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Redirect("/TourDuLich/UnSuccess");
            }

            return Redirect("/TourDuLich/Success");
        }
        public ActionResult Success()
        {
            return View();
        }
        public ActionResult UnSuccess()
        {
            return View();
        }
    }
}

