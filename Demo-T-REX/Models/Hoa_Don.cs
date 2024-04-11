namespace Demo_T_REX.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Hoa_Don
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hoa_Don()
        {
            CT_HD = new HashSet<CT_HD>();
        }

        [Key]
        public int MaHD { get; set; }

        public DateTime NgayLapHD { get; set; }

        public DateTime? DeliverDate { get; set; }

        public bool isConplete { get; set; }

        public bool isPaid { get; set; }

        [StringLength(11)]
        public string SDT { get; set; }

        [StringLength(255)]
        public string TenNguoNhan { get; set; }

        [StringLength(255)]
        public string DiaChiNhan { get; set; }

        [Required]
        [StringLength(128)]
        public string MaKH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_HD> CT_HD { get; set; }
    }
}
