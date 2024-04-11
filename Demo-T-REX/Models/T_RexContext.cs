using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Demo_T_REX.Models
{
    public partial class T_RexContext : DbContext
    {
        public T_RexContext()
            : base("name=T_RexContext")
        {
        }

        public virtual DbSet<CT_HD> CT_HD { get; set; }
        public virtual DbSet<Hoa_Don> Hoa_Don { get; set; }
        public virtual DbSet<Nhan_Hieu> Nhan_Hieu { get; set; }
        public virtual DbSet<San_Pham> San_Pham { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hoa_Don>()
                .Property(e => e.SDT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Nhan_Hieu>()
                .HasMany(e => e.San_Pham)
                .WithOptional(e => e.Nhan_Hieu)
                .WillCascadeOnDelete();
        }
    }
}
