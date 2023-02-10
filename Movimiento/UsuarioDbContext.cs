using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Movimiento.Models;

internal class UsuarioDbContext: DbContext
{
    public UsuarioDbContext(DbContextOptions<UsuarioDbContext> dbContextOptions) : base(dbContextOptions)
    {
        try
        {
            var dbCreator = Database.GetService<IRelationalDatabaseCreator>() as RelationalDatabaseCreator;
            if (dbCreator != null)
            {
                if(!dbCreator.CanConnect()) dbCreator.Create();
                if (!dbCreator.HasTables()) dbCreator.CreateTables();

            }
        }
        catch (Exception)
        {

            throw;
        }
    }
    public DbSet<Transaccion> Transacciones { get; set; }    
}