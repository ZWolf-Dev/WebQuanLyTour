//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DuLich.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TinTuc
    {
        public int ID_TinTuc { get; set; }
        public string HinhAnh { get; set; }
        public string TieuDe { get; set; }
        public string DiaDiem { get; set; }
        public Nullable<int> LuotBinhLuan { get; set; }
        public string BaiViet { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public string created_by { get; set; }
        public string PhanLoai { get; set; }
        public string Link { get; set; }
    }
}
