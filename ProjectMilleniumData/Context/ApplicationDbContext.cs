using Microsoft.EntityFrameworkCore;
using ProjectMillenium.Core.Entities;
using ProjectMillenium.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMillenium.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserRole>()
            .HasKey(bc => new { bc.UserId, bc.RoleId });
            modelBuilder.Entity<UserRole>()
                .HasOne<User>(sc => sc.User)
                .WithMany(s => s.UserRoles)
                .HasForeignKey(sc => sc.UserId);


            modelBuilder.Entity<UserRole>()
                .HasOne<Role>(sc => sc.Role)
                .WithMany(s => s.UserRoles)
                .HasForeignKey(sc => sc.RoleId);

            modelBuilder.Entity<RoleClaim>()
                .HasKey(rc => new { rc.RoleClaimId });

            modelBuilder.Entity<RoleClaim>()
                .HasOne(rc => rc.Claim)
                .WithMany(r => r.RoleClaims)
                .HasForeignKey(rc => rc.RoleId);

            modelBuilder.Entity<RoleClaim>()
                .HasOne(rc => rc.Claim)
                .WithMany(c => c.RoleClaims)
                .HasForeignKey(rc => rc.ClaimId);

        }



        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Claim> Claims { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<RoleClaim> RoleClaims { get; set; }
    }
}
