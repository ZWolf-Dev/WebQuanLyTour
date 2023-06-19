using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DuLich.Models
{
    public class mapTinhThanh
    {
        public string massage = "";
        DuLichDBEntities db = new DuLichDBEntities();
        public List<TinhThanh> DanhSachTheoTen()
        {
            var data = (from tinh in db.TinhThanhs
                        select tinh
                        ).ToList();
            return data;
        }
        public List<TinhThanh> DanhSachQuocGia(int? idCapCha)
        {
            var data = (from tinh in db.TinhThanhs
                        where tinh.idCapCha==idCapCha
                        select tinh
                        ).ToList();
            return data;
        }
        public bool ThemMoi(TinhThanh model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.Ten) == true)
                {
                    massage = "Thiếu thông tin tên tỉnh.";
                    return false;
                }
                db.TinhThanhs.Add(model);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool CapNhat(TinhThanh model)
        {
            try
            {
                var updateModel = db.TinhThanhs.Find(model.ID_Tinh);
                //kiểm tra null
                if (updateModel == null)
                {
                    return false;
                }
                //cập nhật gt cho các trường
                updateModel.Ten = model.Ten;

                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Xoa(int idTinh)
        {
            var model = db.TinhThanhs.Find(idTinh);
            if (model != null)
            {
                db.TinhThanhs.Remove(model);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public TinhThanh ChiTiet(int idTinh)
        {
            //tìm đối tượng có khóa là kiểu số, 1 khóa
            return db.TinhThanhs.Find(idTinh);
        }
    }
}