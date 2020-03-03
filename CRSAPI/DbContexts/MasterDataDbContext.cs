using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using CRSAPI.Models;

namespace CRSAPI.DbContexts
{
    public partial class MasterDataDbContext : DbContext
    {
        public MasterDataDbContext()
        {
        }

        public MasterDataDbContext(DbContextOptions<MasterDataDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Associate> Associate { get; set; }
        public virtual DbSet<AssociateRole> AssociateRole { get; set; }
        public virtual DbSet<ProjectDetail> ProjectDetail { get; set; }
        public virtual DbSet<RoleMaster> RoleMaster { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=ctsinazmyaccessdb.database.windows.net;Database=MyAccess;Trusted_Connection=False;Encrypt=True;User Id=myaccessadmin; Password=one+two#3");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Associate>(entity =>
            {
                entity.ToTable("Associate", "CRS");

                entity.Property(e => e.AssociateId)
                    .HasColumnName("AssociateID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AssociateName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AssociateRole>(entity =>
            {
                entity.ToTable("AssociateRole", "CRS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AssociateId).HasColumnName("AssociateID");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");
            });

            modelBuilder.Entity<ProjectDetail>(entity =>
            {
                entity.HasKey(e => e.AssociateId)
                    .HasName("PK__ProjectD__AC40220FD3E6082D");

                entity.ToTable("ProjectDetail", "CRS");

                entity.Property(e => e.AssociateId)
                    .HasColumnName("AssociateID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.ClientName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ManagerId).HasColumnName("ManagerID");

                entity.Property(e => e.ManagerName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectEndDate).HasColumnType("datetime");

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.ProjectName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VerticalId).HasColumnName("VerticalID");

                entity.Property(e => e.VerticalName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RoleMaster>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__RoleMast__8AFACE3AF86EFF6C");

                entity.ToTable("RoleMaster", "CRS");

                entity.Property(e => e.RoleId)
                    .HasColumnName("RoleID")
                    .ValueGeneratedNever();

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
