using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DuLich.Models
{
    public class mapHinhAnh
    {
        DuLichDBEntities db = new DuLichDBEntities();
        public List<HinhAnh> DanhSach(int idAlbum)
        {
            return db.HinhAnhs.Where(m => m.idAlbum == idAlbum).ToList();
        }
        public HinhAnh ChiTiet(int idAlbum)
        {
            return db.HinhAnhs.Find(idAlbum);
        }
        public int ThemMoi(HinhAnh model)
        {
            try
            {
                db.HinhAnhs.Add(model);
                db.SaveChanges();
                return model.idAlbum;
            }
            catch
            {
                return 0;
            }
        }
    }
}