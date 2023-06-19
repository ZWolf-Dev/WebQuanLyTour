using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DuLich.Models
{
    public class mapTour
    {
        public string massage = "";
        DuLichDBEntities db = new DuLichDBEntities();
        public List<TourDuLich> DanhSachAll()
        {
            var data = (from tour in db.TourDuLiches
                        select tour
                        ).ToList();
            return data;
        }
        //danh sach theo tinh
        public List<TourDuLich> DanhSachTheoTen(string ten)
        {
            var data = db.TourDuLiches.Where(s => s.TieuDe.Contains(ten)).ToList();
           
            return data;
            //var data = from tour in db.TourDuLiches
            //           select tour;
            //data = data.Where(s => s.TieuDe.Contains('%' + ten + '%'));
            //return data.ToList();
        }
        //danh sach theo tinh
        public List<TourDuLich> DanhSachTheoTinh(int? idTinh)
        {
            var data = (from tour in db.TourDuLiches
                        join tinh in db.TinhThanhs on tour.IdTinh equals tinh.ID_Tinh
                        into tinh2
                        from tinh in tinh2.DefaultIfEmpty()

                        where tour.IdTinh == idTinh
                        select tour
                        ).ToList();
            return data;
        }
        //danh sach theo loại tour
        public List<TourDuLich> DanhSachTheoLoaiTour(int? idLoaiTour)
        {
            var data = (from tour in db.TourDuLiches
                        where tour.IdLoaiTour == idLoaiTour
                        select tour
                        ).ToList();
            return data;
        }
        //danh sach theo muc gia
        public List<TourDuLich> DanhSachTheoMucGia(int? idMucGia)
        {
            var data = (from tour in db.TourDuLiches
                        where tour.IdMucGia == idMucGia
                        select tour
                        ).ToList();
            return data;
        }
        //danh sach theo ưu đãi
        public List<TourDuLich> DanhSachTopDanhGia()
        {
            var data = (from tour in db.TourDuLiches
                        where tour.DanhGia >=8
                        select tour
                        ).ToList();
            return data;
        }
        //danh sach theo tinh, loai tour, muc gia
        public List<TourDuLich> DanhSachTour(int? idTinh, int? idLoaiTour, int? idMucGia)
        {
            var data = (from item in db.TourDuLiches
                        where (item.IdTinh == idTinh | idTinh == null)
                        & (item.IdLoaiTour == idLoaiTour | idLoaiTour == null)
                        & (item.IdMucGia == idMucGia | idMucGia == null)

                        select item
                        ).ToList();
            return data;
        }
        public List<spTimkiemTour_Result> DanhSach(int? idTinh, int? idLoaiTour, int? idMucGia)
        {
            var data = db.spTimkiemTour(idTinh, idLoaiTour, idMucGia).ToList();
            return data;
        }
        public List<TourDuLich> DanhSachTotNhat()
        {
            //ĐK:
            //- Chư bắt đầu: này đi > ngày hiện tại
            //- Giá thấp nhất
            //- Lấy top 3 tour
            var data = (from item in db.TourDuLiches
                        orderby item.GiaTour descending
                        select item
                        ).ToList().Take(3).ToList();
            return data;
        }
        public List<TourDuLich> DanhSachUuDai()
        {
            //ĐK:
            //- Chư bắt đầu: này đi > ngày hiện tại
            //- Giá thấp nhất
            //- Lấy top 3 tour
            var data = (from item in db.TourDuLiches
                        orderby item.IdMucGia 
                        select item
                        ).ToList().Take(4).ToList();
            return data;
        }
        public bool ThemMoi(TourDuLich model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.TieuDe) == true)
                {
                    massage = "Thiếu thông tin têu đề.";
                    return false;
                }
                db.TourDuLiches.Add(model);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool CapNhat(TourDuLich model)
        {
            try
            {
                var updateModel = db.TourDuLiches.Find(model.ID);
                //kiểm tra null
                if (updateModel == null)
                {
                    return false;
                }
                //cập nhật gt cho các trường
                updateModel.TieuDe = model.TieuDe;
                updateModel.BaiViet = model.BaiViet;
                updateModel.DiaDiem = model.DiaDiem;
                updateModel.GiaTour = model.GiaTour;
                updateModel.HinhAnh = model.HinhAnh;
                updateModel.IdTinh = model.IdTinh;
                updateModel.IdMucGia = model.IdMucGia;
                updateModel.LichDinhKy = model.LichDinhKy;
                updateModel.SoNgayDiTour = model.SoNgayDiTour;
                updateModel.SoNguoiToiDa = model.SoNguoiToiDa;
                updateModel.NgayBatDau = model.NgayBatDau;
                updateModel.NgayKetThuc = model.NgayKetThuc;

                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Xoa(int idTour)
        {
            var model = db.TourDuLiches.Find(idTour);
            if (model != null)
            {
                db.TourDuLiches.Remove(model);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DoiHinhAnh(int idTour, string linkAnh)
        {
            //1. Tìm đói tượng
            var updateModel = db.TourDuLiches.SingleOrDefault(m => m.ID == idTour);
            //2. Kiem tra tồn tại
            if (updateModel == null)
            {
                return false;
            }
            //3. Cập nhật
            updateModel.HinhAnh = linkAnh;
            db.SaveChanges();
            return true;
        }
        public TourDuLich ChiTiet(int idTour)
        {
            //return db.TourDuLiches.Find(idTour);
            return db.TourDuLiches.SingleOrDefault(item => item.ID == idTour);
        }
    }
}