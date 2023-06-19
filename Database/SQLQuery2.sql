--create or alter
alter proc spTimkiemTour @idTinh int, @idLoaiTour int, @idMucGia int 
-- spTimkiemTour null,null,null
as begin
select Tour.ID, Tour.TieuDe, Tour.LichDinhky, Tour.SoNgayDiTour,
TinhThanh.Ten as TenTinhThanh, Tour.GiaTour, Tour.DiaDiem, Tour.BaiViet,
Tour.SoNguoiToiDa, 
Tour.HinhAnh,Tour.IdAlbum

from TourDulich Tour
left join TinhThanh on TinhThanh.ID_Tinh = Tour.idTinh 
left join LoaiTour on LoaiTour.ID_LoaiTour = Tour.idLoaiTour 
left join Gia on Gia.ID_Gia = Tour.IdMucGia

where (Tour.idTinh = @idTinh or @idTinh is null)
and (Tour.idLoaiTour = @idLoaiTour or @idLoaiTour is null) 
and (Tour.IdMucGia = @idMucGia or @idMucGia is null)
end



--create or alter
alter proc spTimKiemKhachSan @idTinh int, @idMucGia int 
-- spTimKiemKhachSan null, null
as begin
select KS.ID_KhachSan, KS.TenKhachSan, TinhThanh.Ten as TenTinhThanh, KS.GiaPhong, KS.ViTri,
KS.HinhAnh

from KhachSan KS
left join TinhThanh on TinhThanh.ID_Tinh = KS.idTinh 
left join Gia on Gia.ID_Gia = KS.IdMucGia

where (KS.idTinh = @idTinh or @idTinh is null)
and (KS.IdMucGia = @idMucGia or @idMucGia is null)
end