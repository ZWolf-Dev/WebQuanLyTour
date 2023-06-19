using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DuLich.Models
{
    public class mapPhuongTien
    {
        public string massage = "";
        DuLichDBEntities db = new DuLichDBEntities();
        public List<PhuongTien> DanhSach()
        {
            return db.PhuongTiens.ToList();
        }
        public List<PhuongTien> DanhSachPhuongTien(String dichuyen)
        {
            //String temp = "abcdefghi";
            //if (temp.indexOf("b") != -1)
            //{
            //    System.out.println("there is 'b' in temp string");
            //}
            //else
            //{
            //    System.out.println("there is no 'b' in temp string");
            //}
            if (dichuyen.IndexOf('/') == -1)
            {
                var data = (from phuongtien in db.PhuongTiens
                            where phuongtien.PhuongTien1 == dichuyen
                            | phuongtien.PhuongTien1 == dichuyen
                            select phuongtien
                              ).ToList();
                return data;
            }
            else
            {
                string[] arrListStr = dichuyen.Split(new char[] { '/' });
                var dc1 = arrListStr[0];
                var dc2 = arrListStr[1];
                var data = (from phuongtien in db.PhuongTiens
                            where phuongtien.PhuongTien1 == dc1
                            | phuongtien.PhuongTien1 == dc2
                            select phuongtien
                              ).ToList();
                return data;
            }
        }
        public bool ThemMoi(PhuongTien model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.Ten) == true)
                {
                    massage = "Thiếu thông tin.";
                    return false;
                }
                db.PhuongTiens.Add(model);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool CapNhat(PhuongTien model)
        {
            try
            {
                var updateModel = db.PhuongTiens.Find(model.ID);
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
        public bool Xoa(int idPhuongTien)
        {
            var model = db.PhuongTiens.Find(idPhuongTien);
            if (model != null)
            {
                db.PhuongTiens.Remove(model);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public PhuongTien ChiTiet(int idPhuongTien)
        {
            //tìm đối tượng có khóa là kiểu số, 1 khóa
            return db.PhuongTiens.Find(idPhuongTien);
        }
        public PhuongTien ChiTietPhuongTien(string PhuongTien)
        {
            //tìm đối tượng có khóa là kiểu số, 1 khóa
            return db.PhuongTiens.Find(PhuongTien);
        }
    }
}