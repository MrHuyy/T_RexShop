namespace Demo_T_REX.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CT_HD
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaHD { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaSP { get; set; }

        public long Don_Gia_Ban { get; set; }

        public int SL_Mua { get; set; }

        public virtual Hoa_Don Hoa_Don { get; set; }

        public virtual San_Pham San_Pham { get; set; }
    }
}
