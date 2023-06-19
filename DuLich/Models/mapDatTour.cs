using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DuLich.Models
{
    public class mapDatTour
    {
        public string massage = "";
        DuLichDBEntities db = new DuLichDBEntities();
        public List<DatTour> DanhSach()
        {
            return db.DatTours.ToList();
        }
        //danh sach theo tên tài khoản
        public List<DatTour> DanhSachTheoTK(string tenDangNhap)
        {
            var data = (from dattour in db.DatTours
                        where dattour.taiKhoan == tenDangNhap
                        select dattour
                               ).ToList();
            return data;
        }

        public bool ThemMoi(DatTour model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.Ten) == true)
                {
                    massage = "Thiếu thông tin têu đề.";
                    return false;
                }
                db.DatTours.Add(model);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool CapNhat(DatTour model)
        {
            try
            {
                var updateModel = db.DatTours.Find(model.ID);
                //kiểm tra null
                if (updateModel == null)
                {
                    return false;
                }
                //cập nhật gt cho các trường
                updateModel.taiKhoan = model.taiKhoan;
                updateModel.Ten = model.Ten;
                updateModel.Email = model.Email;
                updateModel.SoDienThoai = model.SoDienThoai;
                updateModel.NgayKhoiHanh = model.NgayKhoiHanh;
                updateModel.NgayTroVe = model.NgayTroVe;
                updateModel.DiaChiDon = model.DiaChiDon;
                updateModel.DiaChiTha = model.DiaChiTha;
                updateModel.TourTuyChinh = model.TourTuyChinh;
                updateModel.LoaiXe = model.LoaiXe;
                updateModel.SoLuongHanhKhach = model.SoLuongHanhKhach;
                updateModel.TinNhan = model.TinNhan;
                updateModel.TrangThai = model.TrangThai;


                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Xoa(int idDatTour)
        {
            var model = db.DatTours.Find(idDatTour);
            if (model != null)
            {
                db.DatTours.Remove(model);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public DatTour ChiTiet(int idDatTour)
        {
            //return db.DatTours.Find(idDatTour);
            return db.DatTours.SingleOrDefault(item => item.ID == idDatTour);
        }
    }
}