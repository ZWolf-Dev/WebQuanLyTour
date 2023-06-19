using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DuLich.Models
{
    public class mapDatTourDetail
    {
        public string massage = "";
        DuLichDBEntities db = new DuLichDBEntities();
        public List<DatTourDetail> DanhSach()
        {
            return db.DatTourDetails.ToList();
        }

        public bool ThemMoi(DatTourDetail model)
        {
            try
            {
                db.DatTourDetails.Add(model);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool CapNhat(DatTourDetail model)
        {
            try
            {
                var updateModel = db.DatTourDetails.Find(model.idDatTour);
                //kiểm tra null
                if (updateModel == null)
                {
                    return false;
                }
                //cập nhật gt cho các trường
                updateModel.idDatTour = model.idDatTour;
                updateModel.idTour = model.idTour;
                updateModel.Gia = model.Gia;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Xoa(int idDatTourDetail)
        {
            var model = db.DatTourDetails.Find(idDatTourDetail);
            if (model != null)
            {
                db.DatTourDetails.Remove(model);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public DatTourDetail ChiTiet(int Id_DatTour)
        {
            //return db.DatTourDetails.Find(idDatTourDetail);
            return db.DatTourDetails.SingleOrDefault(item => item.idDatTour == Id_DatTour);
        }
    }
}