using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DuLich.Models
{
    public class mapLoaiTour
    {
        public string massage = "";
        DuLichDBEntities db = new DuLichDBEntities();
        public List<LoaiTour> DanhSachLoaiTour()
        {
            return db.LoaiTours.ToList();
        }
        //danh sach theo id cấp cha
        public List<LoaiTour> DanhSachTheoIdCapCha(int? idCapCha)
        {
            var data = (from LoaiTour in db.LoaiTours
                        where LoaiTour.idCapCha == idCapCha
                        select LoaiTour
                        ).ToList();
            return data;
        }

        public bool ThemMoi(LoaiTour model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.LoaiTour1) == true)
                {
                    massage = "Thiếu thông tin loại tour.";
                    return false;
                }
                db.LoaiTours.Add(model);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool CapNhat(LoaiTour model)
        {
            try
            {
                var updateModel = db.LoaiTours.Find(model.ID_LoaiTour);
                //kiểm tra null
                if (updateModel == null)
                {
                    return false;
                }
                //cập nhật gt cho các trường
                updateModel.LoaiTour1 = model.LoaiTour1;

                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Xoa(int idLoaiTour)
        {
            var model = db.LoaiTours.Find(idLoaiTour);
            if (model != null)
            {
                db.LoaiTours.Remove(model);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public LoaiTour ChiTiet(int idLoaiTour)
        {
            //tìm đối tượng có khóa là kiểu số, 1 khóa
            return db.LoaiTours.Find(idLoaiTour);
        }
      
    }
}