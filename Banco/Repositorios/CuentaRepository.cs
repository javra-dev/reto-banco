using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Usuario.Models;

namespace Usuario.Repositorios
{
    public class CuentaRepository : IRepositorio<Cuenta>
    {
        private readonly UsuarioDbContext _dbContext;
        public CuentaRepository(UsuarioDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(Cuenta entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyCollection<Cuenta>> GetAllAsync()
        {
            var cuentas = await _dbContext.Cuentas.ToListAsync();
            return cuentas;
        }

        public async Task<IReadOnlyCollection<Cuenta>> GetAllAsync(Expression<Func<Cuenta, bool>> filter)
        {
            var reporte = await _dbContext.Cuentas
                .Include(x => x.Movimientos)
                .Where(filter)
                .ToListAsync();

            return reporte;

        }


        //public async Task<IReadOnlyCollection<Cuenta>> GetAllAsync(Expression<Func<Cuenta, bool>> filter)
        //{
        //    var cuentas = await _dbContext.Cuentas.Where(filter).ToListAsync();
        //    return cuentas;
        //}

        public async Task<Cuenta> GetAsync(int id)
        {
            var cuenta = await _dbContext.Cuentas.FirstOrDefaultAsync(c => c.Id == id);
            return cuenta;
        }

        public async Task RemoveAsync(int id)
        {
            var cliente = await _dbContext.Cuentas.FirstOrDefaultAsync(c => c.Id == id);
            _dbContext.Remove(cliente);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Cuenta entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
