using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DOAN_BANSACH.DAL.Entity
{
    public partial class BansachModel : DbContext
    {
        public BansachModel()
            : base("name=BansachModel")
        {
        }

        public virtual DbSet<CT_HOADON> CT_HOADON { get; set; }
        public virtual DbSet<CT_PHIEUNHAP> CT_PHIEUNHAP { get; set; }
        public virtual DbSet<HOADON> HOADON { get; set; }
        public virtual DbSet<LUONG> LUONG { get; set; }
        public virtual DbSet<NHANVIEN> NHANVIEN { get; set; }
        public virtual DbSet<PHIEUNHAP> PHIEUNHAP { get; set; }
        public virtual DbSet<SACH> SACH { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<THELOAISACH> THELOAISACH { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HOADON>()
                .Property(e => e.TENKH)
                .IsUnicode(false);

            modelBuilder.Entity<HOADON>()
                .Property(e => e.SDTKH)
                .IsUnicode(false);

            modelBuilder.Entity<HOADON>()
                .HasMany(e => e.CT_HOADON)
                .WithRequired(e => e.HOADON)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.TENNV)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.DIACHI)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUNHAP>()
                .Property(e => e.NCC)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUNHAP>()
                .HasMany(e => e.CT_PHIEUNHAP)
                .WithRequired(e => e.PHIEUNHAP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SACH>()
                .Property(e => e.TENSACH)
                .IsUnicode(false);

            modelBuilder.Entity<SACH>()
                .Property(e => e.TACGIA)
                .IsUnicode(false);

            modelBuilder.Entity<SACH>()
                .Property(e => e.GIA)
                .HasPrecision(10, 2);

            modelBuilder.Entity<SACH>()
                .HasMany(e => e.CT_HOADON)
                .WithRequired(e => e.SACH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SACH>()
                .HasMany(e => e.CT_PHIEUNHAP)
                .WithRequired(e => e.SACH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<THELOAISACH>()
                .Property(e => e.TENTHELOAISACH)
                .IsUnicode(false);
        }
    }
}
