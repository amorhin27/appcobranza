using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppData.Identity.Configurations
{
    public class UserRolConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    UserId = "3219007d-6cc1-4d16-aabc-7668e1617bba",
                    RoleId = "135544ca-13b8-4d77-a2b6-5b4f860908c3",
                },
                new IdentityUserRole<string>
                {
                    UserId = "cca516af-d94e-4992-9a7d-3f9aceebd03f",
                    RoleId = "aadce3aa-d31d-4810-b2d5-6d37519e2d76",
                }
                );
        }
    }
}
