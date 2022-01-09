using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QLLinhKien.model
{
    public partial class DataQLLK : DbContext
    {
        public DataQLLK()
            : base("name=DataQLLK1")
        {
        }

        public virtual DbSet<CHUCVU> CHUCVUs { get; set; }
        public virtual DbSet<CTHD> CTHDs { get; set; }
        public virtual DbSet<CTPNH> CTPNHs { get; set; }
        public virtual DbSet<HOADON> HOADONs { get; set; }
        public virtual DbSet<KHACHHANG> KHACHHANGs { get; set; }
        public virtual DbSet<LinhKien> LinhKiens { get; set; }
        public virtual DbSet<NHACUNGCAP> NHACUNGCAPs { get; set; }
        public virtual DbSet<NHANVIEN> NHANVIENs { get; set; }
        public virtual DbSet<PhieuNhapHang> PhieuNhapHangs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CHUCVU>()
                .Property(e => e.MaChucVu)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CTHD>()
                .Property(e => e.MaHoaDon)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CTHD>()
                .Property(e => e.MaLinhKien)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CTPNH>()
                .Property(e => e.MaPNH)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CTPNH>()
                .Property(e => e.MaLinhKien)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HOADON>()
                .Property(e => e.MaHoaDon)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HOADON>()
                .HasMany(e => e.CTHDs)
                .WithRequired(e => e.HOADON)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.SDT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<LinhKien>()
                .Property(e => e.MaLinhKien)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<LinhKien>()
                .HasMany(e => e.CTHDs)
                .WithRequired(e => e.LinhKien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LinhKien>()
                .HasMany(e => e.CTPNHs)
                .WithRequired(e => e.LinhKien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHACUNGCAP>()
                .Property(e => e.SDT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.SDT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.MaChucVu)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.TaiKhoan)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.MatKhau)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PhieuNhapHang>()
                .Property(e => e.MaPNH)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PhieuNhapHang>()
                .HasMany(e => e.CTPNHs)
                .WithRequired(e => e.PhieuNhapHang)
                .WillCascadeOnDelete(false);
        }
    }
}
