namespace QLLinhKien.model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuNhapHang")]
    public partial class PhieuNhapHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhieuNhapHang()
        {
            CTPNHs = new HashSet<CTPNH>();
        }

        [Key]
        [StringLength(10)]
        public string MaPNH { get; set; }

        public int? MANV { get; set; }

        public int? MaNCC { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayNhapHang { get; set; }

        public long? TongTien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTPNH> CTPNHs { get; set; }

        public virtual NHACUNGCAP NHACUNGCAP { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
