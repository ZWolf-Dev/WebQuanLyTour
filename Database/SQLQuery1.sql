CREATE TABLE Gia(
ID_Gia int not null IDENTITY(101, 1) PRIMARY KEY, 
MucGia nvarchar(200) null
);
drop table TourDuLich

--thêm cột
ALTER TABLE TourDuLich
  ADD IdMucGia int;
--Tạo khóa chính
  ALTER TABLE TourDuLich ADD PRIMARY KEY (ID);
--Tạo khóa ngoại
ALTER TABLE TourDuLich
ADD CONSTRAINT fk_id_loai_tour
  FOREIGN KEY (IdLoaiTour)
  REFERENCES LoaiTour (ID_LoaiTour);
--Tạo id tự động tăng
Alter Table TourDuLich Add ID Int Identity(1, 1);
Alter Table TourDuLich Drop Column NewID
ALTER TABLE table_name
CHANGE COLUMN old_column_name new_column_name data_type;



delete from TinhThanh;


 INSERT INTO TinhThanh(Ten) VALUES(N'An Giang'),
(N'Bà Rịa – Vũng Tàu'),
(N'Bắc Giang'),
(N'Bắc Kạn'),
(N'Bạc Liêu'),
(N'Bắc Ninh'),
(N'Bến Tre'),
(N'Bình Định'),
(N'Bình Dương'),
(N'Bình Phước'),
(N'Bình Thuận'),
(N'Cà Mau'),
(N'Cao Bằng'),
(N'Cần Thơ'),
(N'Đà Nẵng'),
(N'Đắk Lắk'),
(N'Đắk Nông'),
(N'Điện Biên'),
(N'Đồng Nai'),
(N'Đồng Tháp'),
(N'Gia Lai'),
(N'Hà Giang'),
(N'Hà Nam'),
(N'Hà Nội'),
(N'Hà Tĩnh'),
(N'Hải Dương'),
(N'Hải Phòng'),
(N'Hậu Giang'),
(N'Hòa Bình'),
(N'Hưng Yên'),
(N'Hồ Chí Minh'),
(N'Khánh Hòa'),
(N'Kiên Giang'),
(N'Kon Tum'),
(N'Lai Châu'),
(N'Lâm Đồng'),
(N'Lạng Sơn'),
(N'Lào Cai'),
(N'Long An'),
(N'Nam Định'),
(N'Nghệ An'),
(N'Ninh Bình'),
(N'Ninh Thuận'),
(N'Phú Thọ'),
(N'Phú Yên'),
(N'Quảng Bình'),
(N'Quảng Nam'),
(N'Quảng Ngãi'),
(N'Quảng Ninh'),
(N'Quảng Trị'),
(N'Sóc Trăng'),
(N'Sơn La'),
(N'Tây Ninh'),
(N'Thái Bình'),
(N'Thái Nguyên'),
(N'Thanh Hóa'),
(N'Thừa Thiên Huế'),
(N'Tiền Giang'),
(N'Trà Vinh'),
(N'Tuyên Quang'),
(N'Vĩnh Long'),
(N'Vĩnh Phúc'),
(N'Yên Bái'),
(N'Thái Lan'),
(N'Nhật Bản'),
(N'Trung Quốc')


