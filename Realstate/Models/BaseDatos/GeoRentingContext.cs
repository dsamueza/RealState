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
        public virtual DbSet<Link> Link { get; set; }
        public virtual DbSet<Management> Management { get; set; }
        public virtual DbSet<Parish> Parish { get; set; }
        public virtual DbSet<Predio> Predio { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<Propietario> Propietario { get; set; }
        public virtual DbSet<Province> Province { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<Sector> Sector { get; set; }
        public virtual DbSet<StatusTask> StatusTask { get; set; }
        public virtual DbSet<Task> Task { get; set; }
        public virtual DbSet<TypeTask> TypeTask { get; set; }
        public virtual DbSet<Zona> Zona { get; set; }
        public virtual DbSet<ZonaProspectada> ZonaProspectada { get; set; }
        public virtual DbSet<DetailTask> DetailTasks { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=tcp:mardisenginetestbd.database.windows.net,1433;Initial Catalog=GeoRenting;Persist Security Info=False;User ID=mardisengine;Password=Mard!s3ngin3;Encrypt=True;TrustServerCertificate=False;MultipleActiveResultSets=True;App=EntityFramework; Connection Lifetime=240;Timeout=60; Max Pool Size = 200; Min Pool Size = 10; Pooling=True;");
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

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

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

            modelBuilder.Entity<Link>(entity =>
            {
                entity.ToTable("Link", "RentingCommon");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("nchar(500)");

                entity.Property(e => e.StatusRegister).HasColumnType("nchar(10)");

                entity.Property(e => e.Usercreation)
                    .HasColumnName("usercreation")
                    .HasColumnType("nchar(10)");
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

            modelBuilder.Entity<Predio>(entity =>
            {
                entity.ToTable("Predio", "RentingCore");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.IdPropietario).HasColumnName("idPropietario");

                entity.Property(e => e.IdZonaProspectada).HasColumnName("idZonaProspectada");

                entity.Property(e => e.Image)
                    .HasColumnName("image")
                    .HasColumnType("nvarchar(max)");

                entity.Property(e => e.Latitude)
                    .HasColumnName("latitude")
                    .HasColumnType("nchar(20)");

                entity.Property(e => e.Length)
                    .HasColumnName("length")
                    .HasColumnType("nchar(20)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("nchar(500)");

                entity.Property(e => e.StatusRegister).HasColumnType("nchar(10)");

                entity.Property(e => e.Usercreation)
                    .HasColumnName("usercreation")
                    .HasColumnType("nchar(50)");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasColumnType("nchar(20)");

                entity.Property(e => e.Zona)
                    .HasColumnName("zona")
                    .HasColumnType("nchar(10)");

                entity.HasOne(d => d.IdZonaProspectadaNavigation)
                    .WithMany(p => p.Predio)
                    .HasForeignKey(d => d.IdZonaProspectada)
                    .HasConstraintName("FK_Predio_ZonaProspectada");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("Project", "RentingCore");

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasColumnType("image");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.StatusRegister)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Usercreation)
                    .HasColumnName("usercreation")
                    .HasColumnType("nchar(50)");

                entity.HasOne(d => d.IdAccountNavigation)
                    .WithMany(p => p.Project)
                    .HasForeignKey(d => d.IdAccount)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Project_Account");

                entity.HasOne(d => d.IdContryNavigation)
                    .WithMany(p => p.Project)
                    .HasForeignKey(d => d.IdContry)
                    .HasConstraintName("FK_Project_Country");

                entity.HasOne(d => d.IdDistrictNavigation)
                    .WithMany(p => p.Project)
                    .HasForeignKey(d => d.IdDistrict)
                    .HasConstraintName("FK_Project_District");

                entity.HasOne(d => d.IdLinkNavigation)
                    .WithMany(p => p.Project)
                    .HasForeignKey(d => d.IdLink)
                    .HasConstraintName("FK_Project_Link");

                entity.HasOne(d => d.IdParishNavigation)
                    .WithMany(p => p.Project)
                    .HasForeignKey(d => d.IdParish)
                    .HasConstraintName("FK_Project_Parish");

                entity.HasOne(d => d.IdProvinceNavigation)
                    .WithMany(p => p.Project)
                    .HasForeignKey(d => d.IdProvince)
                    .HasConstraintName("FK_Project_Province");

                entity.HasOne(d => d.IdSectorNavigation)
                    .WithMany(p => p.Project)
                    .HasForeignKey(d => d.IdSector)
                    .HasConstraintName("FK_Project_Sector");

                entity.HasOne(d => d.Zona)
                    .WithMany(p => p.Project)
                    .HasForeignKey(d => d.ZonaId)
                    .HasConstraintName("FK_Project_Zona");
            });

            modelBuilder.Entity<Propietario>(entity =>
            {
                entity.ToTable("propietario", "RentingCommon");

                entity.Property(e => e.Cedula)
                    .HasColumnName("cedula")
                    .HasColumnType("nchar(10)");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("nchar(10)");

                entity.Property(e => e.Movil)
                    .HasColumnName("movil")
                    .HasColumnType("nchar(10)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("nchar(10)");

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasColumnType("nchar(10)");
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

                entity.Property(e => e.Id).ValueGeneratedNever();

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

                entity.Property(e => e.IdStatusTask).ValueGeneratedOnAdd();

                entity.Property(e => e.Route)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.StatusRegister)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Usercreation)
                    .HasColumnName("usercreation")
                    .HasMaxLength(450);

                entity.HasOne(d => d.IdPredioNavigation)
                    .WithMany(p => p.Task)
                    .HasForeignKey(d => d.IdPredio)
                    .HasConstraintName("FK_Task_Predio");

                entity.HasOne(d => d.IdStatusTaskNavigation)
                    .WithMany(p => p.Task)
                    .HasForeignKey(d => d.IdStatusTask)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Task_StatusTask");

                entity.HasOne(d => d.IdTypeTaskNavigation)
                    .WithMany(p => p.Task)
                    .HasForeignKey(d => d.IdTypeTask)
                    .HasConstraintName("FK_Task_TypeTask");
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
                entity.ToTable("Zona", "RentingCommon");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("nchar(500)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("nchar(500)");

                entity.Property(e => e.StatusRegister).HasColumnType("nchar(10)");

                entity.Property(e => e.Usercreation)
                    .HasColumnName("usercreation")
                    .HasColumnType("nchar(50)");
            });

            modelBuilder.Entity<ZonaProspectada>(entity =>
            {
                entity.ToTable("ZonaProspectada", "RentingCore");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasColumnType("nchar(10)");

                entity.Property(e => e.Commentary)
                    .HasColumnName("commentary")
                    .HasColumnType("nchar(500)");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("nchar(100)");

                entity.Property(e => e.Reference)
                    .HasColumnName("reference")
                    .HasMaxLength(500);

                entity.Property(e => e.StatusRegister).HasColumnType("nchar(10)");
                entity.Property(e => e.imagen).HasColumnType("varchar(MAX)");

                entity.Property(e => e.StreetMain).HasColumnType("nchar(500)");

                entity.Property(e => e.StreetSecundary).HasColumnType("nchar(500)");

                entity.Property(e => e.Streetfour).HasColumnType("nchar(500)");

                entity.Property(e => e.Streetthree).HasColumnType("nchar(500)");

                entity.Property(e => e.Usercreation)
                    .HasColumnName("usercreation")
                    .HasColumnType("nchar(50)");

                entity.Property(e => e.Zona)
                    .HasColumnName("zona")
                    .HasColumnType("nchar(50)");

                entity.HasOne(d => d.IdProyectoNavigation)
                    .WithMany(p => p.ZonaProspectada)
                    .HasForeignKey(d => d.IdProyecto)
                    .HasConstraintName("FK_ZonaProspectada_Project");
            });
        }
    }
}
