using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DuLich.Models
{
    public class mapDichVu
    {
        DuLichDBEntities db = new DuLichDBEntities();
        public List<DichVu> DanhSach(string phanLoai)
        {
            var data = (from dichvu in db.DichVus
                        where dichvu.PhanLoai == phanLoai
                        select dichvu).ToList();
            return data;
        }
    }
}