using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DuLich.Models
{
    public class mapBinhLuan
    {
        public string massage = "";
        DuLichDBEntities db = new DuLichDBEntities();
        public List<BinhLuan> DanhSach()
        {
            return db.BinhLuans.ToList();
        }
        public List<BinhLuan> DanhSachTop5(int cap, int maTour)
        {
            var data =(from s in db.BinhLuans
                       where (s.Cap == cap)
                       & (s.MaTour == maTour)
                       orderby s.LuotThich
                       select s).Take(5);
            return data.ToList();
        }
        public int SoLuongBL(int maTour)
        {
            var data = (from s in db.BinhLuans
                        where s.MaTour == maTour
                        select s).Count();
            return data;
        }
        public bool ThemMoi(BinhLuan model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.MaTaiKhoan) == true)
                {
                    massage = "Thiếu thông tin mức giá.";
                    return false;
                }
                db.BinhLuans.Add(model);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool CapNhat(BinhLuan model)
        {
            try
            {
                var updateModel = db.BinhLuans.Find(model.MaBinhLuan);
                //kiểm tra null
                if (updateModel == null)
                {
                    return false;
                }
                //cập nhật gt cho các trường
                updateModel.NoiDung = model.NoiDung;

                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Xoa(int MaBinhLuan)
        {
            var model = db.BinhLuans.Find(MaBinhLuan);
            if (model != null)
            {
                db.BinhLuans.Remove(model);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public BinhLuan ChiTiet(int MaBinhLuan)
        {
            //tìm đối tượng có khóa là kiểu số, 1 khóa
            return db.BinhLuans.Find(MaBinhLuan);
        }
    }
}