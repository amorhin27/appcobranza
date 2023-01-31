using AppData.Domain;
using AppData.Domain.Comon;
using Microsoft.EntityFrameworkCore;

namespace AppData.Infrastructure.Persistence
{
    public  class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
        {
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-DR41GPJ\SQLEXPRESS; Database=bd_venta;Integrated Security=true")
        //        .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, Microsoft.Extensions.Logging.LogLevel.Information)
        //        .EnableSensitiveDataLogging();
        //}


        protected /*override*/ Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseModel>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreaDate = DateTime.Now;
                        entry.Entity.UserId = 1;
                        break;

                    case EntityState.Modified:
                        entry.Entity.UpdateDate = DateTime.Now;
                        entry.Entity.UserId = 1;
                        break;

                    case EntityState.Deleted:
                        entry.Entity.DeleteDate = DateTime.Now;
                        entry.Entity.UserId = 1;
                        break;
                    default:
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }



        public DbSet<People>? Personas { get; set; }
        public DbSet<Prestamo>? Prestamos { get; set; }
        public DbSet<Cobranza>? Cobranzas { get; set; }
        public DbSet<Empleado>? Empleados { get; set; }
    }
}
