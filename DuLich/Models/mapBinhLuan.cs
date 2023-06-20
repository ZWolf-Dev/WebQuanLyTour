using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DuLich.Models
{
    public class mapBinhLuan
    {
        public string message = "";
        DuLichDBEntities db = new DuLichDBEntities();
        public List<BinhLuan> DanhSach()
        {
            return db.BinhLuans.ToList();
        }
        public List<BinhLuan> DanhSachTop5(int cap, int maTour,int? MaBinhLuan)
        {
            var data =(from s in db.BinhLuans
                       where  (s.MaTour == maTour) & (s.Cap == cap) &(s.idReply == MaBinhLuan)
                       orderby s.NgayDang
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
        public bool ThemMoi(BinhLuan model, int? idBinhLuan, int maTour, string MaTaiKhoan, string NoiDung)
        {
            try
            {
                if (idBinhLuan.Equals(null))
                {
                    model.MaTour = maTour;
                    model.MaTaiKhoan = MaTaiKhoan;
                    model.NoiDung = NoiDung;
                    model.NgayDang = DateTime.Now;
                    model.Cap = 1;
                }
                else
                {
                    model.MaTour = maTour;
                    model.MaTaiKhoan = MaTaiKhoan;
                    model.NoiDung = NoiDung;
                    model.NgayDang = DateTime.Now;
                    model.idReply = idBinhLuan;
                    model.Cap = 2;
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