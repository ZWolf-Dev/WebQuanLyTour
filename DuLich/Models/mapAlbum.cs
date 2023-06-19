using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DuLich.Models
{
    public class mapAlbum
    {
        public string massage = "";
        DuLichDBEntities db = new DuLichDBEntities();
        public List<AlbumAnh> DanhSachAlbumAnh()
        {
            return db.AlbumAnhs.ToList();
        }
        public bool ThemMoi(AlbumAnh model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.TenAlbum) == true)
                {
                    massage = "Thiếu thông tin.";
                    return false;
                }
                db.AlbumAnhs.Add(model);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool CapNhat(AlbumAnh model)
        {
            try
            {
                var updateModel = db.AlbumAnhs.Find(model.ID_Album);
                //kiểm tra null
                if (updateModel == null)
                {
                    return false;
                }
                //cập nhật gt cho các trường
                updateModel.TenAlbum = model.TenAlbum;

                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Xoa(int idAlbum)
        {
            var model = db.AlbumAnhs.Find(idAlbum);
            if (model != null)
            {
                db.AlbumAnhs.Remove(model);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public AlbumAnh ChiTiet(int idAlbum) 
        {
            return db.AlbumAnhs.Find(idAlbum);
        }
    }
}