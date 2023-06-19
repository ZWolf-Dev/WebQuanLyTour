using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DuLich.Models
{
    public class mapTaiKhoan
    {
        public string massage = "";
        DuLichDBEntities db = new DuLichDBEntities();
        public List<TaiKhoan> DanhSach()
        {
            try
            {
                return db.TaiKhoans.ToList();
            }
            catch
            {
                return new List<TaiKhoan>();
            }
        }
        public TaiKhoan ChiTiet(string tenDangNhap)
        {
            try
            {
                var model = db.TaiKhoans.SingleOrDefault(m => m.TenDangNhap == tenDangNhap.ToLower());
                return model;
            }
            catch
            {
                return null;
            }
        }
        public bool ThemMoi(TaiKhoan model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.TenDangNhap) == true)
                {
                    massage = "Thiếu thông tin.";
                    return false;
                }
                string mkMaHoa = new Common.MaHoa.MaHoaDuLieu().CreateMd5(model.MatKhau);
                model.MatKhau = mkMaHoa;
                model.Active = true;
                db.TaiKhoans.Add(model);
                db.SaveChanges();
                return true;
            }
            catch
            {
                massage = "Tên Đăng Nhập Đã Có Rồi";
                return false;
            }
        }
        public bool CapNhat(TaiKhoan model)
        {
            try
            {
                var updateModel = db.TaiKhoans.Find(model.TenDangNhap);
                //kiểm tra null
                if (updateModel == null)
                {
                    return false;
                }
                //cập nhật gt cho các trường
                updateModel.TenDangNhap = model.TenDangNhap;
                string mkMaHoa = new Common.MaHoa.MaHoaDuLieu().CreateMd5(model.MatKhau);
                updateModel.MatKhau = mkMaHoa;
                updateModel.TenHienThi = model.TenHienThi;
                updateModel.Email = model.Email;
                updateModel.SoDienThoai = model.SoDienThoai;
                updateModel.Active = model.Active;

                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Xoa(string tenDangNhap)
        {
            var model = db.TaiKhoans.Find(tenDangNhap);
            if (model != null)
            {
                db.TaiKhoans.Remove(model);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool AdminCapNhat(TaiKhoan model)
        {
            //1. Tìm đói tượng
            var updateModel = db.TaiKhoans.SingleOrDefault(m => m.TenDangNhap.ToLower() == model.TenDangNhap.ToLower());
            //2. Kiem tra tồn tại
            if(updateModel == null)
            {
                return false;
            }
            //3. Cập nhật
            updateModel.SoDienThoai = model.SoDienThoai;
            updateModel.TenHienThi = model.TenHienThi;
            updateModel.Email = model.Email;
            db.SaveChanges();
            return true;
        }
        public bool DoiMatKhau(TaiKhoan model)
        {
            //1. Tìm đói tượng
            var updateModel = db.TaiKhoans.SingleOrDefault(m => m.TenDangNhap.ToLower() == model.TenDangNhap.ToLower());
            //2. Kiem tra tồn tại
            if (updateModel == null)
            {
                return false;
            }
            //3. Cập nhật
            string mkMaHoa = new Common.MaHoa.MaHoaDuLieu().CreateMd5(model.MatKhau);
            updateModel.MatKhau = mkMaHoa;
            db.SaveChanges();
            return true;
        }
        public bool DoiHinhAnh(string tenDangNhap, string linkAnh)
        {
            //1. Tìm đói tượng
            var updateModel = db.TaiKhoans.SingleOrDefault(m => m.TenDangNhap.ToLower() == tenDangNhap.ToLower());
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
    }
}