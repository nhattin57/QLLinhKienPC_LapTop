﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace QLLinhKien
{
    class LinhKien
    {
        Database db;
        public LinhKien()
        {
            db = new Database();
        }

        public DataTable layDSTKMK()
        {
            string sql = "select TaiKhoan,MatKhau from NHANVIEN";
            DataTable dt = db.Execute(sql);
            //Goi phuong thuc truy xuat DL
            return dt;
        }
        public DataTable layTTchoLstViewLinhkien()
        {
            string sql =
            "select STT,MaLinhKien,LoaiLinhKien,TenLinhKien,XuatSu,GiaBan,BaoHanh,SoLuongTon,TenNCC from LinhKien a, NHACUNGCAP b where a.MaNCC = b.MaNCC";
            DataTable dt = db.Execute(sql);
            //Goi phuong thuc truy xuat DL
            return dt;
        }
        public DataTable layDSNhaCC()
        {
            string sql = "select MaNCC,TenNCC from NHACUNGCAP";
            DataTable dt = db.Execute(sql);
            return dt;
        }
        public void themLinhKien(string malk,string loailk,string tenLK,string xuatsu,double giaban,string baohanh,int slton,int maNCC)
        {
            string sql = string.Format("insert into LinhKien values('{0}',N'{1}',N'{2}',N'{3}',{4},N'{5}',{6},{7})",
                                       malk, loailk, tenLK, xuatsu, giaban, baohanh, slton, maNCC);
            db.ExecuteNonQuery(sql);
        }
        public void SuaLinhKien(string malk, string loailk, string tenLK, string xuatsu, double giaban, string baohanh, int slton, int maNCC)
        {
            string sql = string.Format("update LinhKien set LoaiLinhKien=N'{1}',TenLinhKien=N'{2}',XuatSu=N'{3}',GiaBan='{4}',BaoHanh=N'{5}',SoLuongTon='{6}',MaNCC='{7}' where MaLinhKien='{0}'",
                malk, loailk, tenLK, xuatsu, giaban, baohanh, slton, maNCC);
            db.ExecuteNonQuery(sql);
        }
        public DataTable timKiemLKTheoTen(string tenlk)
        {
            string sql = string.Format("select STT,MaLinhKien,LoaiLinhKien,TenLinhKien,XuatSu,GiaBan,BaoHanh,SoLuongTon,TenNCC from LinhKien a, NHACUNGCAP b where a.MaNCC=b.MaNCC and TenLinhKien like N'%{0}%'", tenlk);
            DataTable dt = db.Execute(sql);
            return dt;
        }
        public DataTable layMaVaTenKH()
        {
            string sql = "select MaKhachHang,Hoten from KHACHHANG";
            DataTable dt = db.Execute(sql);
            return dt;
        }
        public DataTable layMaVaTenNV()
        {
            string sql = "select MANV,HoTen from NHANVIEN";
            DataTable dt = db.Execute(sql);
            return dt;
        }
        public DataTable layMa_Ten_Gia_CuaLK()
        {
            string sql = "select MaLinhKien,TenLinhKien,GiaBan from LinhKien";
            DataTable dt = db.Execute(sql);
            return dt;
        }
        public DataTable layMa_Va_soLuongLK()
        {
            string sql = "select MaLinhKien,SoLuongTon from LinhKien";
            DataTable dt = db.Execute(sql);
            return dt;
        }
        public DataTable layMaHD()
        {
            string sql = "select MaHoaDon from HOADON";
            DataTable dt = db.Execute(sql);
            return dt;
        }
        public void themHoaDon(string maHD, int maKH, int maNV,string ngayXuatHD,double tongtien)
        {
            string sql = string.Format("insert into HOADON values('{0}','{1}','{2}','{3}','{4}')", maHD, maKH, maNV, ngayXuatHD, tongtien);
            db.ExecuteNonQuery(sql);
        }
        public void themCTHD(string maHD, string maLK,string tenLK,double giaBan,int soluong,double thanhtien)
        {
            string sql = string.Format("insert into CTHD values ('{0}','{1}',N'{2}','{3}','{4}','{5}')", maHD, maLK, tenLK, giaBan, soluong, thanhtien);
            db.ExecuteNonQuery(sql);
        }
        public void upDateSLLinhKien(int soLuong, string maLK)
        {
            string sql = string.Format("update LinhKien set SoLuongTon=SoLuongTon-'{0}' where MaLinhKien='{1}'", soLuong, maLK);
            db.ExecuteNonQuery(sql);
        }
        public DataTable layMaLK()
        {
            string sql = "select MaLinhKien from LinhKien";
            DataTable dt = db.Execute(sql);
            return dt;
        }
        public DataTable layTenLK()
        {
            string sql = "select TenLinhKien from LinhKien";
            DataTable dt = db.Execute(sql);
            return dt;
        }
        public DataTable layDSHoaDon()
        {
            string sql = "select MaHoaDon,c.Hoten,b.HoTen,NgayXuatHoaDon,Tongtien from HOADON a,NHANVIEN b,KHACHHANG c where a.MaKhachHang=c.MaKhachHang and a.MANV=b.MANV";
            DataTable dt = db.Execute(sql);
            return dt;
        }
        public DataTable layDSCTHD()
        {
            string sql = "select a.TenLinhKien,a.MaLinhKien,a.GiaBan,SoLuong,ThanhTien from CTHD a,LinhKien b where a.MaLinhKien=b.MaLinhKien";
            DataTable dt = db.Execute(sql);
            return dt;
        }
        public void updateHOADON(string maHD,int maKH,int maNV,string ngayxuatHD)
        {
            string sql = string.Format("update HOADON set MaKhachHang='{1}',MANV='{2}',NgayXuatHoaDon='{3}' where MaHoaDon='{0}'", maHD,maKH,maNV,ngayxuatHD);
            db.ExecuteNonQuery(sql);
        }
        public void updateCTHD(string maHD,string maLK,double giaban,int soluong,double thanhtien)
        {
            string sql = string.Format("update CTHD set GiaBan='{2}',SoLuong='{3}',ThanhTien='{4}' where MaHoaDon='{0}' and MaLinhKien='{1}'", maHD, maLK, giaban, soluong, thanhtien);
            db.ExecuteNonQuery(sql);
        }
        public void updateHOADONBeforeCTHD(string maHD, int maKH, int maNV, string ngayxuatHD,double tongtien)
        {
            string sql = string.Format("update HOADON set MaKhachHang='{1}',MANV='{2}',NgayXuatHoaDon='{3}',Tongtien='{4}' where MaHoaDon='{0}'", maHD, maKH, maNV, ngayxuatHD, tongtien);
                db.ExecuteNonQuery(sql);
        }
        public DataTable TimCTHDTheoMa(string maHD)
        {
            string sql = string.Format("select MaHoaDon,a.TenLinhKien,a.MaLinhKien,a.GiaBan,SoLuong,ThanhTien from CTHD a,LinhKien b where a.MaLinhKien=b.MaLinhKien and MaHoaDon='{0}'", maHD);
            DataTable dt = db.Execute(sql);
            return dt;
        }
        public DataTable timHoaDonTheoMa(string maHD)
        {
            string sql = string.Format("select MaHoaDon,c.Hoten,b.HoTen,NgayXuatHoaDon,Tongtien from HOADON a,NHANVIEN b,KHACHHANG c where a.MaKhachHang=c.MaKhachHang and a.MANV=b.MANV and MaHoaDon='{0}'", maHD);
            DataTable dt = db.Execute(sql);
            return dt;
        }
        public DataTable layThanhTienTuCTHD(string maHD)
        {
            string sql = string.Format("select ThanhTien from CTHD where MaHoaDon='{0}'", maHD);
            DataTable dt = db.Execute(sql);
            return dt;
        }
        public void deleteCTHD(string maHD)
        {
            string sql = string.Format("delete CTHD where MaHoaDon='{0}'", maHD);
            db.ExecuteNonQuery(sql);
        }
        public void deleteHoaDon(string maHD)
        {
            string sql = string.Format("delete HOADON where MaHoaDon='{0}'", maHD);
            db.ExecuteNonQuery(sql);
        }
        public void deleteCTHDwhenDoubleClickonListView(string maHD,string maLK)
        {
            string sql = string.Format("delete CTHD where MaHoaDon='{0}' and MaLinhKien='{1}'", maHD, maLK);
            db.ExecuteNonQuery(sql);
        }
        public void updateHOADONwhendoubleClickonListView(string maHD,double tongtien)
        {
            string sql = string.Format("update HOADON set Tongtien='{1}' where MaHoaDon='{0}'", maHD, tongtien);
            db.ExecuteNonQuery(sql);
        }

        //from supplier
        public DataTable loadDataSupplier()
        {
            string sql = "Select * from NhaCungCap";
            DataTable dt = db.Execute(sql);
            return dt;
        }
        public void insertSupplier(string ten, string diaChi, string SDT)
        {
            string sql = string.Format("insert into NHACUNGCAP values(N'{0}',N'{1}','{2}')", ten, diaChi, SDT);
            db.ExecuteNonQuery(sql);
        }

        public void updateSupplier(string ten, string diaChi, string SDT, int maNCC)
        {
            string sql = string.Format("update NHACUNGCAP set TenNCC =N'{0}', DiaChi=N'{1}', SDT=N'{2}' where MaNCC = '{3}'", ten, diaChi, SDT, maNCC);
            db.ExecuteNonQuery(sql);
        }
        public DataTable getLK(int MaNCC)
        {
            string sql = string.Format("select a.MaLinhKien from LinhKien a  where MaLinhKien ='{0}'", MaNCC);
            DataTable dt = db.Execute(sql);
            return dt;
        }
        public DataTable viewSupplierSearch(string name)
        {
            string sql = string.Format("select MaNCC, TenNCC, SDT, DiaChi  from NHACUNGCAP  where TenNCC like  N'%{0}%' ", name);
            DataTable dt = db.Execute(sql);
            return dt;
        }
        public DataTable getNameSupplier()
        {
            string sql = string.Format("Select TenNCC from NhaCungCap");
            DataTable dt = db.Execute(sql);
            return dt;
        }
        public DataTable getNumberPhoneSupplier()
        {
            string sql = string.Format("Select SDT from NhaCungCap");
            DataTable dt = db.Execute(sql);
            return dt;
        }
    }
}
