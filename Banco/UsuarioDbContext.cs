

using Microsoft.EntityFrameworkCore;
using Usuario.Models;

public class UsuarioDbContext: DbContext
{
    public UsuarioDbContext(DbContextOptions<UsuarioDbContext> options)
        : base(options)
    {
        //try
        //{
        //    var dbCreator = Database.GetService<IRelationalDatabaseCreator>() as RelationalDatabaseCreator;
        //    if (dbCreator != null)
        //    {
        //        if (!dbCreator.CanConnect()) dbCreator.Create();
        //        if (!dbCreator.HasTables()) dbCreator.CreateTables();

        //    }
        //}
        //catch (Exception)
        //{

        //    throw;
        //}
    }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Persona> Personas { get; set; }
    public DbSet<Movimiento> Movimientos { get; set; }
    public DbSet<Cuenta> Cuentas { get; set; }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<Cliente>().ToTable("Clientes");
    //    modelBuilder.Entity<Persona>().ToTable("Personas");
    //    modelBuilder.Entity<Movimiento>().ToTable("Movimientos");
    //    modelBuilder.Entity<Cuenta>().ToTable("Cuentas");
    //}
}