namespace QLLinhKien.model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTHD")]
    public partial class CTHD
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string MaHoaDon { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string MaLinhKien { get; set; }

        [StringLength(100)]
        public string TenLinhKien { get; set; }

        public long? GiaBan { get; set; }

        public int? SoLuong { get; set; }

        public long? ThanhTien { get; set; }

        public virtual HOADON HOADON { get; set; }

        public virtual LinhKien LinhKien { get; set; }
    }
}
