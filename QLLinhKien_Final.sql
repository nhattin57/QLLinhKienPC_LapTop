Create DATABASE QLLinhKienPC_Laptop
USE QLLinhKienPC_Laptop
---

CREATE TABLE KHACHHANG(
MaKhachHang int identity(1,1),
Hoten [nvarchar](50) NULL,
GioiTinh [nvarchar](5) NULL,
SDT char(15) null,
primary key(MaKhachHang)
)
--
GO
CREATE TABLE LinhKien(
STT int identity(1,1), -- ko can quan tâm cột này
MaLinhKien  char(10),
LoaiLinhKien nvarchar(50),
TenLinhKien nvarchar(100),
XuatSu nvarchar(30),
GiaBan bigint,
BaoHanh nvarchar(20),
SoLuongTon int, --hiển thị đang còn hàng hay hết hàng
MaNCC int,
primary key(MaLinhKien)
)
GO
--
CREATE TABLE CHUCVU(
MaChucVu char(10) ,
TenChucVu [nvarchar](40) NULL,
PRIMARY KEY (MaChucVu),
)
GO
--
CREATE TABLE NHANVIEN(
MANV int identity(1,1),
HoTen nvarchar(50) NULL,
SDT char(15) null,
DiaCHi nvarchar(50) NULL,
NamSinh date NULL,
GioiTinh [nvarchar](5) NULL,
MaChucVu char(10) ,
TaiKhoan char(50) NOT NULL,
MatKhau char(50) NOT NULL,
PRIMARY KEY(MANV)
)

GO
--
select MaHoaDon,b.Hoten,c.HoTen,NgayXuatHoaDon,Tongtien
from HOADON a,KHACHHANG b, NHANVIEN c
where a.MaKhachHang=b.MaKhachHang and a.MANV=c.MANV
select * from HOADON
CREATE TABLE HOADON(
MaHoaDon char(10) ,
MaKhachHang int ,
MANV int,
NgayXuatHoaDon date,
Tongtien bigint
PRIMARY KEY(MaHoaDon),
)
GO
--
CREATE TABLE CTHD(
MaHoaDon char(10) ,
MaLinhKien char(10),
TenLinhKien nvarchar(100),
GiaBan bigint,
SoLuong int,
ThanhTien bigint,
primary key(MaHoaDon,MaLinhKien)
)
GO
--
CREATE TABLE NHACUNGCAP(
MaNCC int identity(1,1),
TenNCC nvarchar(50),
SDT char(15),
DiaChi nvarchar(50),
primary key(MANCC)
)
GO
--
CREATE TABLE PhieuNhapHang(
MaPNH char(10),
MANV int,
MaNCC int,
NgayNhapHang date,
TongTien bigint,
primary key(MaPNH)
)
GO
--
CREATE TABLE CTPNH(
MaPNH char(10),
MaLinhKien char(10),
LoaiLinhKien nvarchar(50),
TenLinhKien nvarchar(100),
XuatSu nvarchar(30),
GiaBan bigint,
BaoHanh nvarchar(20),
SoLuongNhap int,
MoTaSp nvarchar(max) null,
ThanhTien bigint,
PRIMARY KEY(MaPNH,MaLinhKien)
)
--tao khoa ngoai
Alter table LinhKien add  foreign key(MaNCC) references NHACUNGCAP (MaNCC)on update cascade on delete cascade

Alter table PhieuNhapHang add  foreign key(MaNCC) references NHACUNGCAP (MaNCC)on update cascade on delete cascade

Alter table PhieuNhapHang add  foreign key(MANV) references NHANVIEN (MANV) on update cascade on delete cascade

Alter table CTPNH add  foreign key(MAPNH) references PhieuNhapHang(MAPNH) on update cascade on delete cascade

Alter table CTPNH add  foreign key(MaLinhKien) references LinhKien(MaLinhKien) on update NO ACTION on delete NO ACTION

Alter table NHANVIEN add  foreign key(MaChucVu) references CHUCVU(MaChucVu) on update cascade on delete cascade

Alter table HOADON add  foreign key(MaKhachHang) references KHACHHANG(MaKhachHang) on update cascade on delete cascade

Alter table HOADON add  foreign key(MANV) references NHANVIEN(MANV) on update cascade on delete cascade

Alter table CTHD add  foreign key(MaHoaDon) references HOADON(MaHoaDon) on update cascade on delete cascade

Alter table CTHD add  foreign key(MaLinhKien) references LinhKien(MaLinhKien) on update cascade on delete cascade

--nhap du lieu
insert into CHUCVU values('NV',N'Nhân Viên')
insert into CHUCVU values('QL',N'Quản Lý')

insert into NHACUNGCAP values(N'Kim Đồng','0357999999',N'123 Lâm Xuân, TP Thủ Đức')
insert into NHACUNGCAP values(N'Nhật Kiệu','035788888',N'98 Nguyễn Huệ, TP HÀ Nội')

insert into LinhKien values('LK1',N'Bàn Phím',N'Bàn Phím Cơ 500',N'Nhật Bản',1000000,N'1 Năm',50,1)
insert into LinhKien values('LK2',N'Chuột',N'Chuột Logitech pro',N'Trung Quốc',50000,N'1 Năm',100,2)
insert into LinhKien values('LK3',N'Màn Hình',N'Màn Hình AOE 2K5',N'Hàn QUốc',9999999,N'1,5 Năm',100,2)

insert into KHACHHANG values(N'Hoàng Dược Sư',N'Nam','035488888')
insert into KHACHHANG values(N'Dạ Lăng Sương',N'Nữ','055777777')

insert into NHANVIEN values(N'Trần Dần','022555488',N'Quận Cam-America','9/20/1962',N'Nam','NV','trandan','trandan')
insert into NHANVIEN values(N'Hàn Dao','08455444',N'Linh Sơn- Côn Lôn','8/10/1992',N'Nữ','NV','handao','handao')
insert into NHANVIEN values(N'Hạo Thiên','022555488',N'Hạo Thiên Tông','9/3/1999',N'Nam','QL','haothien','haothien')

insert into HOADON values('HD1',1,2,'4/11/2021',1000000)
insert into HOADON values('HD2',2,2,'4/15/2021',11099999)

insert into CTHD values('HD1','LK1',N'Bàn Phím Cơ 500',1000000,1,1000000)
insert into CTHD values('HD2','LK1',N'Bàn Phím Cơ 500',1000000,1,1000000)
insert into CTHD values('HD2','LK2',N'Chuột Logitech pro',50000,2,100000)
insert into CTHD values('HD2','LK3',N'Màn Hình AOE 2K5',9999999,1,9999999)

insert into PhieuNhapHang values('PNH1',1,2,'10/10/2021',1054999900)

insert into CTPNH values('PNH1','LK1',N'Bàn Phím',N'Bàn Phím Cơ 500',N'Nhật Bản',1000000,N'1 Năm',50,N'
Màu sắc phù hợp vớt lập trình viên + waifu genshin impact hình ảnh',50000000)
insert into CTPNH values('PNH1','LK2',N'Chuột',N'Chuột Logitech pro',N'Trung Quốc',50000,N'1 Năm',100,N'
click chuột không lo mòn tha hồ URF',5000000)
insert into CTPNH values('PNH1','LK3',N'Màn Hình',N'Màn Hình AOE 2K5',N'Hàn QUốc',9999999,N'1,5 Năm',100,N'
Màn cong xem chế độ 4k full hd không che',999999900)



