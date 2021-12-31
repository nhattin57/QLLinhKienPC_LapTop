namespace QLLinhKien.model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTPNH")]
    public partial class CTPNH
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string MaPNH { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string MaLinhKien { get; set; }

        [StringLength(50)]
        public string LoaiLinhKien { get; set; }

        [StringLength(100)]
        public string TenLinhKien { get; set; }

        [StringLength(30)]
        public string XuatSu { get; set; }

        public long? GiaBan { get; set; }

        [StringLength(20)]
        public string BaoHanh { get; set; }

        public int? SoLuongNhap { get; set; }

        public string MoTaSp { get; set; }

        public long? ThanhTien { get; set; }

        public virtual LinhKien LinhKien { get; set; }

        public virtual PhieuNhapHang PhieuNhapHang { get; set; }
    }
}
