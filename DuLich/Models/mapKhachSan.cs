using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DuLich.Models
{
    public class mapKhachSan
    {
        public string massage = "";
        DuLichDBEntities db = new DuLichDBEntities();
        public List<KhachSan> DanhSach()
        {
            return db.KhachSans.ToList();
        }
        //danh sach theo tinh
        public List<KhachSan> DanhSachTheoTinh(int? idTinh)
        {
            var data = (from khachsan in db.KhachSans
                        join tinh in db.TinhThanhs on khachsan.IdTinh equals tinh.ID_Tinh
                        into tinh2
                        from tinh in tinh2.DefaultIfEmpty()

                        where khachsan.IdTinh == idTinh
                        select khachsan
                        ).ToList();
            return data;
        }
        //danh sach theo muc gia
        public List<KhachSan> DanhSachTheoMucGia(int? idMucGia)
        {
            var data = (from khachsan in db.KhachSans
                        where khachsan.IdMucGia == idMucGia
                        select khachsan
                        ).ToList();
            return data;
        }
        //danh sach theo tinh, loai khachsan, muc gia
        public List<KhachSan> DanhSachkhachsan(int? idTinh, int? idMucGia)
        {
            var data = (from item in db.KhachSans
                        where (item.IdTinh == idTinh | idTinh == null)
                        & (item.IdMucGia == idMucGia | idMucGia == null)

                        select item
                        ).ToList();
            return data;
        }
        public List<spTimKiemKhachSan_Result> DanhSachTimKiem(int? idTinh, int? idMucGia)
        {
            var data = db.spTimKiemKhachSan(idTinh, idMucGia).ToList();
            return data;
        }
        public List<KhachSan> DanhSachTotNhat()
        {
            //ĐK:
            //- Chư bắt đầu: này đi > ngày hiện tại
            //- Giá thấp nhất
            //- Lấy top 3 khachsan
            var data = (from item in db.KhachSans
                        orderby item.GiaPhong descending
                        select item
                        ).ToList().Take(3).ToList();
            return data;
        }
        public List<KhachSan> DanhSachUuDai()
        {
            //ĐK:
            //- Chư bắt đầu: này đi > ngày hiện tại
            //- Giá thấp nhất
            //- Lấy top 3 khachsan
            var data = (from item in db.KhachSans
                        orderby item.IdMucGia
                        select item
                        ).ToList().Take(4).ToList();
            return data;
        }
        public bool ThemMoi(KhachSan model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.TenKhachSan) == true)
                {
                    massage = "Thiếu thông tin têu đề.";
                    return false;
                }
                db.KhachSans.Add(model);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool CapNhat(KhachSan model)
        {
            try
            {
                var updateModel = db.KhachSans.Find(model.ID_KhachSan);
                //kiểm tra null
                if (updateModel == null)
                {
                    return false;
                }
                //cập nhật gt cho các trường
                updateModel.TenKhachSan = model.TenKhachSan;
                updateModel.BaiViet = model.BaiViet;
                updateModel.ViTri = model.ViTri;
                updateModel.GiaPhong = model.GiaPhong;
                updateModel.HinhAnh = model.HinhAnh;
                updateModel.IdTinh = model.IdTinh;
                updateModel.IdMucGia = model.IdMucGia;


                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Xoa(int idkhachsan)
        {
            var model = db.KhachSans.Find(idkhachsan);
            if (model != null)
            {
                db.KhachSans.Remove(model);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DoiHinhAnh(int idkhachsan, string linkAnh)
        {
            //1. Tìm đói tượng
            var updateModel = db.KhachSans.SingleOrDefault(m => m.ID_KhachSan == idkhachsan);
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
        public KhachSan ChiTiet(int idkhachsan)
        {
            //return db.KhachSans.Find(idkhachsan);
            return db.KhachSans.SingleOrDefault(item => item.ID_KhachSan == idkhachsan);
        }
    }
}