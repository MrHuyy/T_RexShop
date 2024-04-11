namespace Demo_T_REX.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class San_Pham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public San_Pham()
        {
            CT_HD = new HashSet<CT_HD>();
        }

        [Key]
        public int MaSP { get; set; }

        [Required]
        [StringLength(50)]
        public string TenSP { get; set; }

        public double? Size { get; set; }

        [Required]
        [StringLength(20)]
        public string MauSac { get; set; }

        public long? Don_Gia_Ban { get; set; }

        [Required]
        [StringLength(255)]
        public string Mo_ta_SP { get; set; }

        public int GiamGia { get; set; }

        public int? SL_TonKho { get; set; }

        [Required]
        [StringLength(255)]
        public string Img { get; set; }

        public int? MaLoai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_HD> CT_HD { get; set; }

        public virtual Nhan_Hieu Nhan_Hieu { get; set; }
        public List<Nhan_Hieu> ListNhanHieu = new List<Nhan_Hieu>();
        public float don_gia_giam
        {
            get
            {
                float y = (float)GiamGia / 100;
                float x = (float)(y * Don_Gia_Ban); 
                return (float)Don_Gia_Ban - x;
            }
        }
    }
}
