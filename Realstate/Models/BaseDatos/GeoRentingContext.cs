using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Realstate.Models.BaseDatos
{
    public partial class GeoRentingContext : DbContext
    {
        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<District> District { get; set; }
        public virtual DbSet<Management> Management { get; set; }
        public virtual DbSet<Parish> Parish { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<ProspectoAreas> ProspectoAreas { get; set; }
        public virtual DbSet<Province> Province { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<Sector> Sector { get; set; }
        public virtual DbSet<StatusTask> StatusTask { get; set; }
        public virtual DbSet<Task> Task { get; set; }
        public virtual DbSet<TypeProject> TypeProject { get; set; }
        public virtual DbSet<TypeTask> TypeTask { get; set; }
        public virtual DbSet<Zona> Zona { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=tcp:mardisenginetestbd.database.windows.net;Database=GeoRenting;Persist Security Info=False;User ID=mardisengine;Password=Mard!s3ngin3;Encrypt=True;TrustServerCertificate=False;MultipleActiveResultSets=True;App=EntityFramework; Connection Lifetime=240;Timeout=60; Max Pool Size = 200; Min Pool Size = 10; Pooling=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account", "RentingCommon");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.StatusRegister)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country", "RentingCommon");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.StatusRegister)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.ToTable("District", "RentingCommon");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.StatusRegister)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdManagementNavigation)
                    .WithMany(p => p.District)
                    .HasForeignKey(d => d.IdManagement)
                    .HasConstraintName("FK_District_Management");

                entity.HasOne(d => d.IdProvinceNavigation)
                    .WithMany(p => p.District)
                    .HasForeignKey(d => d.IdProvince)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_District_Province");
            });

            modelBuilder.Entity<Management>(entity =>
            {
                entity.ToTable("Management", "RentingCommon");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdRegionNavigation)
                    .WithMany(p => p.Management)
                    .HasForeignKey(d => d.IdRegion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Management_Region");
            });

            modelBuilder.Entity<Parish>(entity =>
            {
                entity.ToTable("Parish", "RentingCommon");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.StatusRegister)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("Project", "RentingCore");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.StatusRegister)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTypeProjectNavigation)
                    .WithMany(p => p.Project)
                    .HasForeignKey(d => d.IdTypeProject)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Project_TypeProject");

                entity.HasOne(d => d.IdZonaNavigation)
                    .WithMany(p => p.Project)
                    .HasForeignKey(d => d.IdZona)
                    .HasConstraintName("FK_Project_Zona");

                entity.HasOne(d => d.IdAccountNavigation)
                    .WithMany(p => p.Project)
                    .HasForeignKey(d => d.IdAccount)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_Project_Account");
            });

            modelBuilder.Entity<ProspectoAreas>(entity =>
            {
                entity.ToTable("ProspectoAreas", "RentingCore");

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.MainStreet)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Neighborhood)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Reference)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.SecundaryStreet)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.StatusRegister)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Zone)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdProjectNavigation)
                    .WithMany(p => p.ProspectoAreas)
                    .HasForeignKey(d => d.IdProject)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProspectoAreas_Project");
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.ToTable("Province", "RentingCommon");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCountryNavigation)
                    .WithMany(p => p.Province)
                    .HasForeignKey(d => d.IdCountry)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Province_Country");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.ToTable("Region", "RentingCommon");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sector>(entity =>
            {
                entity.ToTable("Sector", "RentingCommon");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.StatusRegister)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDistrictNavigation)
                    .WithMany(p => p.Sector)
                    .HasForeignKey(d => d.IdDistrict)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sector_District");
            });

            modelBuilder.Entity<StatusTask>(entity =>
            {
                entity.ToTable("StatusTask", "RentingCommon");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.StatusRegister)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.ToTable("Task", "RentingCore");

                entity.Property(e => e.AggregateUri)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DateCreation).HasColumnType("date");

                entity.Property(e => e.DateModification).HasColumnType("datetime");

                entity.Property(e => e.DateValidation).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ExternalCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Route)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.StatusRegister)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TypeProject>(entity =>
            {
                entity.ToTable("TypeProject", "RentingCommon");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.StatusRegister)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TypeTask>(entity =>
            {
                entity.ToTable("TypeTask", "RentingCommon");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.StatusRegister)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Zona>(entity =>
            {
                entity.ToTable("Zona", "RentingCore");

                entity.Property(e => e.Avaluo)
                    .HasColumnName("avaluo")
                    .HasColumnType("nchar(50)");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasColumnType("nchar(10)");

                entity.Property(e => e.Commentary)
                    .HasColumnName("commentary")
                    .HasColumnType("nchar(500)");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Latitude)
                    .HasColumnName("latitude")
                    .HasColumnType("nchar(50)");

                entity.Property(e => e.Length)
                    .HasColumnName("length")
                    .HasColumnType("nchar(50)");

                entity.Property(e => e.Linkgeo)
                    .HasColumnName("linkgeo")
                    .HasColumnType("nchar(500)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("nchar(100)");

                entity.Property(e => e.Photo).HasColumnType("text");

                entity.Property(e => e.Propietario)
                    .HasColumnName("propietario")
                    .HasColumnType("nchar(10)");

                entity.Property(e => e.Reference)
                    .HasColumnName("reference")
                    .HasMaxLength(500);

                entity.Property(e => e.StatusRegister).HasColumnType("nchar(10)");

                entity.Property(e => e.StreetMain).HasColumnType("nchar(500)");

                entity.Property(e => e.StreetSecundary).HasColumnType("nchar(500)");

                entity.Property(e => e.Streetfour).HasColumnType("nchar(500)");

                entity.Property(e => e.Streetthree).HasColumnType("nchar(500)");

                entity.Property(e => e.Zona1)
                    .HasColumnName("zona")
                    .HasColumnType("nchar(50)");

                entity.HasOne(d => d.IdCountryNavigation)
                    .WithMany(p => p.Zona)
                    .HasForeignKey(d => d.IdCountry)
                    .HasConstraintName("FK_Zona_Country");

                entity.HasOne(d => d.IdDistrictNavigation)
                    .WithMany(p => p.Zona)
                    .HasForeignKey(d => d.IdDistrict)
                    .HasConstraintName("FK_Zona_District");

                entity.HasOne(d => d.IdParishNavigation)
                    .WithMany(p => p.Zona)
                    .HasForeignKey(d => d.IdParish)
                    .HasConstraintName("FK_Zona_Parish");

                entity.HasOne(d => d.IdProvinceNavigation)
                    .WithMany(p => p.Zona)
                    .HasForeignKey(d => d.IdProvince)
                    .HasConstraintName("FK_Zona_Province");

                entity.HasOne(d => d.IdSectorNavigation)
                    .WithMany(p => p.Zona)
                    .HasForeignKey(d => d.IdSector)
                    .HasConstraintName("FK_Zona_Sector");
            });
        }
    }
}
