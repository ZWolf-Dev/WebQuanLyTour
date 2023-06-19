using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DuLich.Models
{
    public class mapMucGia
    {
        public string massage = "";
        DuLichDBEntities db = new DuLichDBEntities();
        public List<Gia> DanhSachMucGia()
        {
            return db.Gias.ToList();
        }
        public bool ThemMoi(Gia model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.MucGia) == true)
                {
                    massage = "Thiếu thông tin mức giá.";
                    return false;
                }
                db.Gias.Add(model);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool CapNhat(Gia model)
        {
            try
            {
                var updateModel = db.Gias.Find(model.ID_Gia);
                //kiểm tra null
                if (updateModel == null)
                {
                    return false;
                }
                //cập nhật gt cho các trường
                updateModel.MucGia = model.MucGia;

                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Xoa(int idGia)
        {
            var model = db.Gias.Find(idGia);
            if (model != null)
            {
                db.Gias.Remove(model);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public Gia ChiTiet(int idGia)
        {
            //tìm đối tượng có khóa là kiểu số, 1 khóa
            return db.Gias.Find(idGia);
        }
    }
}