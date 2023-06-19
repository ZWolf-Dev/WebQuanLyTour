using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DuLich.Models
{
    public class mapLichTrinh
    {
        public string massage = "";
        DuLichDBEntities db = new DuLichDBEntities();
        public LichTrinh ChiTiet(int idLichTrinh)
        {
            //return db.TourDuLiches.Find(idTour);
            return db.LichTrinhs.Find(idLichTrinh);
        }
    }
}