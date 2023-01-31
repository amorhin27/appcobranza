using AppData.Domain;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Infrastructure.Persistence
{
    public class DataDbContextSeed
    {
        //public static async Task SeedAsync(DataDbContext context, ILogger<DataDbContextSeed> logger)
        //{
        //    //if (context.Personas.Any())
        //    //{
        //    //    context.Personas.AddRange(); //sin data harcodiado
        //    //    //context.Personas.AddRange(GetPersonas());
        //    //    await context.SaveChangesAsync();
        //    //    logger.LogInformation("insertar nuevos persona al db {context}", typeof(DataDbContext).Name);
        //    //}
        //}

        //private static IEnumerable<People> GetPersonas()
        //{
        //    return new List<People>
        //    {
        //        new People
        //        {
        //            PersonaId = 1,
        //            Nombres = "amorhin",
        //            ApellidoPaterno = "rojas",
        //            Dni = "70812214"
        //        },
        //        new People
        //        {
        //            PersonaId = 2,
        //            Nombres = "amorhin2",
        //            ApellidoPaterno = "rojas2",
        //            Dni = "70812213"
        //        }
        //    };
        //}
    }
}
