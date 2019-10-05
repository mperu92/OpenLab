using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OpenLab.DAL.EF.Models.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenLab.DAL.EF.Contexts
{
    public class OpenLabDbContext : IdentityDbContext<IdentityUserModel, IdentityRoleModel, int, IdentityUserClaim<int>, IdentityUserRoleModel, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public OpenLabDbContext(DbContextOptions<OpenLabDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            if (modelBuilder != null)
            {
                #region Identity
                modelBuilder.Entity<IdentityUserModel>(b =>
                {
                // Each User can have many UserClaims
                b.HasMany(e => e.Claims)
                        .WithOne()
                        .HasForeignKey(uc => uc.UserId)
                        .IsRequired();

                // Each User can have many UserLogins
                b.HasMany(e => e.Logins)
                        .WithOne()
                        .HasForeignKey(ul => ul.UserId)
                        .IsRequired();

                // Each User can have many UserTokens
                b.HasMany(e => e.Tokens)
                        .WithOne()
                        .HasForeignKey(ut => ut.UserId)
                        .IsRequired();

                // Each User can have many entries in the UserRole join table
                b.HasMany(e => e.UserRoles)
                        .WithOne(e => e.User)
                        .HasForeignKey(ur => ur.UserId)
                        .IsRequired();

                    b.ToTable("OpenLab_Users");
                });

                modelBuilder.Entity<IdentityRoleModel>(b =>
                {
                // Each Role can have many entries in the UserRole join table
                b.HasMany(e => e.UserRoles)
                        .WithOne(e => e.Role)
                        .HasForeignKey(ur => ur.RoleId)
                        .IsRequired();

                    b.ToTable("OpenLab_Roles");
                });

                modelBuilder.Entity<IdentityUserRoleModel>(b =>
                {
                    b.ToTable("OpenLab_UsersRoles");
                });

                modelBuilder.Entity<IdentityRoleClaim<int>>(b =>
                {
                    b.ToTable("OpenLab_RoleClaims");
                });

                modelBuilder.Entity<IdentityUserClaim<int>>(b =>
                {
                    b.ToTable("OpenLab_UserClaims");
                });

                modelBuilder.Entity<IdentityUserLogin<int>>(b =>
                {
                    b.ToTable("OpenLab_UserLogins");
                });

                modelBuilder.Entity<IdentityUserToken<int>>(b =>
                {
                    b.ToTable("OpenLab_UserTokens");
                });
                #endregion
            }
        }
    }
}
