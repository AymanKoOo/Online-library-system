using Core.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Seed
{
    public static class RoleSeed
    {
        public static void Seed(this ModelBuilder builder)
        {

            List<ApplicationRole> roles = new List<ApplicationRole>()
            {
                new ApplicationRole { Id = "1", Name = "Admin", NormalizedName ="ADMIN"},
                new ApplicationRole { Id = "2", Name = "User", NormalizedName = "USER" }
            };

            builder.Entity<ApplicationRole>().HasData(
              roles
            );

            var passwordHasher = new PasswordHasher<ApplicationUser>();
            var adminUser = new ApplicationUser
            {
                Id = "1",
                UserName = "Admin123",
                NormalizedUserName = "ADMIN123",
                Email = "admin123@gmail.com",
                EmailConfirmed = true,
                NormalizedEmail= "ADMIN123@GMAIL.COM",
                PasswordHash = passwordHasher.HashPassword(null, "Admin123@")
            };

            builder.Entity<ApplicationUser>().HasData(adminUser);


            var UserRole = new IdentityUserRole<string>
            {
                UserId = adminUser.Id,
                RoleId = roles.First(x => x.Name == "Admin").Id
            };

            builder.Entity<IdentityUserRole<string>>().HasData(UserRole);
            
        }
    }
}
