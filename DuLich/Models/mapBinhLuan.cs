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

                var data = (from s in db.BinhLuans
                            where (s.MaTour == maTour) & (s.Cap == cap) & (s.idReply == MaBinhLuan)
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
       
        public bool CapNhat(int? MaBinhLuan, int? LuotThich,int? LuotTraLoi, int? LuotChiaSe, string loai)
        {
            try
            {
                var updateModel = db.BinhLuans.Find(MaBinhLuan);
                //kiểm tra null
                if (updateModel == null)
                {
                    return false;
                }
                //cập nhật gt cho các trường
                if (loai.Equals("Like"))
                {
                    if (LuotThich.Equals(null))
                        updateModel.LuotThich = 1;
                    else
                        updateModel.LuotThich = LuotThich + 1;
                }
                if (loai.Equals("Comment"))
                {
                    if (LuotTraLoi.Equals(null))
                        updateModel.LuotTraLoi = 1;
                    else
                        updateModel.LuotTraLoi = LuotTraLoi + 1;
                }
                if(loai.Equals("Share"))
                {
                    if (LuotChiaSe.Equals(null))
                        updateModel.LuotChiaSe = 1;
                    else
                        updateModel.LuotChiaSe = LuotChiaSe + 1;
                }
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
        public BinhLuan ChiTiet(int? MaBinhLuan)
        {
            //tìm đối tượng có khóa là kiểu số, 1 khóa
            return db.BinhLuans.Find(MaBinhLuan);
        }
    }
}