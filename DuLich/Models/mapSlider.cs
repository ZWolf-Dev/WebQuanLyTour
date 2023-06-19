using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DuLich.Models
{
    public class mapSlider
    {
        public string massage = "";
        DuLichDBEntities db = new DuLichDBEntities();
        public List<Slider> DanhSach()
        {
            return db.Sliders.ToList();
        }
        public bool ThemMoi(Slider model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.TieuDe) == true)
                {
                    massage = "Thiếu thông tin mức giá.";
                    return false;
                }
                db.Sliders.Add(model);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool CapNhat(Slider model)
        {
            try
            {
                var updateModel = db.Sliders.Find(model.ID_Slider);
                //kiểm tra null
                if (updateModel == null)
                {
                    return false;
                }
                //cập nhật gt cho các trường
                updateModel.TieuDe = model.TieuDe;

                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Xoa(int idSlider)
        {
            var model = db.Sliders.Find(idSlider);
            if (model != null)
            {
                db.Sliders.Remove(model);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public Slider ChiTiet(int idSlider)
        {
            //tìm đối tượng có khóa là kiểu số, 1 khóa
            return db.Sliders.Find(idSlider);
        }
    }
}
