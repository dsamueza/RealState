using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Realstate.Models;
using Realstate.Models.BaseDatos;

namespace Realstate.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<Models.BaseDatos.Account> Account { get; set; }
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
        public virtual DbSet<Models.BaseDatos.Task> Task { get; set; }
        public virtual DbSet<TypeProject> TypeProject { get; set; }
        public virtual DbSet<TypeTask> TypeTask { get; set; }
        public virtual DbSet<Zona> Zona { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

   
    }



}
