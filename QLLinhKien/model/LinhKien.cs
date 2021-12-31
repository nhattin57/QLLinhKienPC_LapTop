namespace QLLinhKien.model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LinhKien")]
    public partial class LinhKien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LinhKien()
        {
            CTHDs = new HashSet<CTHD>();
            CTPNHs = new HashSet<CTPNH>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int STT { get; set; }

        [Key]
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

        public int? SoLuongTon { get; set; }

        public int? MaNCC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHD> CTHDs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTPNH> CTPNHs { get; set; }

        public virtual NHACUNGCAP NHACUNGCAP { get; set; }
    }
}
