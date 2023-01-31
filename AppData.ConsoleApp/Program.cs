using AppData.Domain;
using AppData.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

//DataDbContext dbContext = new();

#region registrar
//Persona persona = new()
//{
// Dni = "70812213",
// Nombres = "Victor",
// ApellidoPaterno  =  "Rojas",
// ApellidoMaterno = "Rivas",
// Direccion = "Av de las artes sur 417",
// Referencia = "Apurimac",
// Telefono ="999666888",
// Correo = "victor@gmail.com",
////auditoria
//Estado = true,
// CreateUser = 1,
// CreateDate = DateTime.Now
//};

//dbContext!.Personas!.Add(persona);
//await dbContext.SaveChangesAsync();

//var prestamo = new List<Prestamo>
//{
//    new Prestamo
//    {
//        PersonaId=persona.PersonaId,
//        FechaPrestamo = DateTime.Now,
//        Detalle= "primer prestamo",
//        Monto = 5000,
//        TasaInteres = 8,
//        PagoDiario = 10,
//        EstadoPrestamo = true,
//        Estado = true,
//        CreateUser = 1,
//        CreateDate = DateTime.Now
//    },
//    new Prestamo
//    {
//        PersonaId=persona.PersonaId,
//        FechaPrestamo = DateTime.Now,
//        Detalle= "segundo prestamo",
//        Monto = 1000,
//        TasaInteres = 8,
//        PagoDiario = 5,
//        EstadoPrestamo = true,
//        Estado = true,
//        CreateUser = 1,
//        CreateDate = DateTime.Now
//    }
//};
//await dbContext.AddRangeAsync(prestamo);
//await dbContext.SaveChangesAsync();
#endregion

//void queryOersona()
//{
//    var personas =  dbContext.Personas.ToList();
//    foreach (var item in personas)
//    {
//        Console.WriteLine($"{item.PersonaId} - {item.Dni} - {item.Nombres}-{item.ApellidoPaterno} - {item.ApellidoMaterno}");
//    }
//}