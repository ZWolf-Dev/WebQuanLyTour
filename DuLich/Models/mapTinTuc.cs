using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DuLich.Models
{
    public class mapTinTuc
    {
        public string massage = "";
        DuLichDBEntities db = new DuLichDBEntities();
        public List<TinTuc> DanhSach()
        {
            return db.TinTucs.ToList();
        }
        //danh sach theo post
        public List<TinTuc> DanhSachPost()
        {
            var data = (from tintuc in db.TinTucs
                        where tintuc.PhanLoai == "post"
                        select tintuc
                               ).ToList();
            return data;
        }
        //danh sach theo page
        public List<TinTuc> DanhSachPage()
        {
            var data = (from tintuc in db.TinTucs
                        where tintuc.PhanLoai == "page"
                        select tintuc
                               ).ToList();
            return data;
        }
        //danh sach theo cta
        public List<TinTuc> DanhSachCTA()
        {
            var data = (from tintuc in db.TinTucs
                        where tintuc.PhanLoai == "CTA"
                        select tintuc
                               ).ToList();
            return data;
        }
        public bool ThemMoi(TinTuc model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.TieuDe) == true)
                {
                    massage = "Thiếu thông tin têu đề.";
                    return false;
                }
                db.TinTucs.Add(model);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool CapNhat(TinTuc model)
        {
            try
            {
                var updateModel = db.TinTucs.Find(model.ID_TinTuc);
                //kiểm tra null
                if (updateModel == null)
                {
                    return false;
                }
                //cập nhật gt cho các trường
                updateModel.HinhAnh = model.HinhAnh;
                updateModel.TieuDe = model.TieuDe;
                updateModel.BaiViet = model.BaiViet;
                updateModel.DiaDiem = model.DiaDiem;
                updateModel.LuotBinhLuan = model.LuotBinhLuan;
                updateModel.created_at = model.created_at;
                updateModel.created_by = model.created_by;
                updateModel.PhanLoai = model.PhanLoai;


                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Xoa(int idTinTuc)
        {
            var model = db.TinTucs.Find(idTinTuc);
            if (model != null)
            {
                db.TinTucs.Remove(model);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DoiHinhAnh(int idTinTuc, string linkAnh)
        {
            //1. Tìm đói tượng
            var updateModel = db.TinTucs.SingleOrDefault(m => m.ID_TinTuc == idTinTuc);
            //2. Kiem tra tồn tại
            if (updateModel == null)
            {
                return false;
            }
            //3. Cập nhật
            updateModel.HinhAnh = linkAnh;
            db.SaveChanges();
            return true;
        }
        public TinTuc ChiTiet(int idTinTuc)
        {
            //return db.TinTucs.Find(idTinTuc);
            return db.TinTucs.SingleOrDefault(item => item.ID_TinTuc == idTinTuc);
        }
    }
}