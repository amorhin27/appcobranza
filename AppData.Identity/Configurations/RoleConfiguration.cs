using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Identity.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "135544ca-13b8-4d77-a2b6-5b4f860908c3",
                    Name = "Administrador",
                    NormalizedName = "ADMINISTRADOR",
                },
                new IdentityRole
                {
                    Id = "aadce3aa-d31d-4810-b2d5-6d37519e2d76",
                    Name = "Venta",
                    NormalizedName = "VENTA",
                },
                new IdentityRole
                {
                    Id = "72e69b23-67ce-46e8-9c75-d8f85458396c",
                    Name = "Cobrador",
                    NormalizedName = "COBRADOR",
                });
        }
    }
}
