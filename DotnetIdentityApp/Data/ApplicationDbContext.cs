using DotnetIdentityApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DotnetIdentityApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<PetShopUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            string UserId = "101";
            string RoleId = "1";

            
           
            //Creating New Pet User
            var appUser = new PetShopUser
            {
                Id = UserId,
                Email = "admin@gmail.com",
                UserName = "admin",
                NormalizedUserName = "admin"
                //Id = UserId,
                //Email = "newpetuser@gmail.com",
                //NormalizedUserName = "newpetuser@gmail.com",
                //NormalizedEmail = "newpetuser@gmail.com",
                //EmailConfirmed = false,
                //UserName = "newpetuser@gmail.com",
                //PhoneNumberConfirmed = false,
                //TwoFactorEnabled = false,
                //LockoutEnabled = false,
                //AccessFailedCount = 0,
            };

            //Setting user password
            PasswordHasher<PetShopUser> ph = new PasswordHasher<PetShopUser>();
            appUser.PasswordHash = ph.HashPassword(appUser, "mytestpassword");

            //Seeding Pet User
            builder.Entity<PetShopUser>().HasData(appUser);

            //Seeding admin role
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "Admin",
                Id = RoleId,
                ConcurrencyStamp = RoleId
            });


            //Mapping User and Role
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = RoleId,
                UserId = UserId
            });
        }

    }
    
}