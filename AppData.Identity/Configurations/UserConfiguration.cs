using AppData.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppData.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                new ApplicationUser
                {
                    Id = "3219007d-6cc1-4d16-aabc-7668e1617bba",
                    Email = "admin@gmail.com",
                    NormalizedEmail = "admin@gmail.com",
                    Nombre = "Admin",
                    Apellidos = "Admin",
                    UserName = "Admin",
                    NormalizedUserName = "Admin",
                    PasswordHash = hasher.HashPassword(null, "P@ssword07"),
                    EmailConfirmed = true,
                },
                new ApplicationUser
                {
                    Id = "cca516af-d94e-4992-9a7d-3f9aceebd03f",
                    Email = "amorhin10roja@gmail.com",
                    NormalizedEmail = "amorhin10roja@gmail.com",
                    Nombre = "Amorhin",
                    Apellidos = "Rojas Huarhuachi",
                    UserName = "Amorhin",
                    NormalizedUserName = "Amorhin",
                    PasswordHash = hasher.HashPassword(null, "P@ssword07"),
                    EmailConfirmed = true,
                }
                );
        }
    }
}
