using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace _23_D01
{
    public partial class DB002Context : DbContext
    {
        public DB002Context()
        {
        }

        public DB002Context(DbContextOptions<DB002Context> options)
            : base(options)
        {
        }

        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<Phong> Phongs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=127.0.0.1,1433;Database=DB002;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.HasKey(e => e.Manv);

                entity.ToTable("NhanVien");

                entity.Property(e => e.Manv).HasColumnName("manv");

                entity.Property(e => e.Anh)
                    .HasMaxLength(200)
                    .HasColumnName("anh")
                    .IsFixedLength(true);

                entity.Property(e => e.Chucvu)
                    .HasMaxLength(20)
                    .HasColumnName("chucvu");

                entity.Property(e => e.Chuyenmon)
                    .HasMaxLength(200)
                    .HasColumnName("chuyenmon");

                entity.Property(e => e.Gioitinh)
                    .HasMaxLength(5)
                    .HasColumnName("gioitinh");

                entity.Property(e => e.Maphong).HasColumnName("maphong");

                entity.Property(e => e.Ngaysinh)
                    .HasColumnType("date")
                    .HasColumnName("ngaysinh");

                entity.Property(e => e.Ten)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("ten");
            });

            modelBuilder.Entity<Phong>(entity =>
            {
                entity.HasKey(e => e.Maphong);

                entity.ToTable("Phong");

                entity.Property(e => e.Maphong).HasColumnName("maphong");

                entity.Property(e => e.Soluong).HasColumnName("soluong");

                entity.Property(e => e.Ten)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("ten");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
