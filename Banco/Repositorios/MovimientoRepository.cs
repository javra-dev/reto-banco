using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Usuario.Models;

namespace Usuario.Repositorios
{
    public class MovimientoRepository : IRepositorio<Movimiento>
    {
        private readonly UsuarioDbContext _dbContext;
        public MovimientoRepository(UsuarioDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(Movimiento entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyCollection<Movimiento>> GetAllAsync()
        {
            var clientes = await _dbContext.Movimientos.ToListAsync();
            return clientes;
        }


        //public async Task<IReadOnlyCollection<Movimiento>> GetAllAsync(int id, DateTime ini, DateTime fin)
        //{
        //    var clientes = await _dbContext.Cuentas
        //        .Include(m => m.Movimientos.Select(f => f.Fecha > ini && f.Fecha < fin))
        //        .Where(x => x.ClienteId == id)
        //        .ToListAsync();
        //    return clientes;
        //}


        public async Task<IReadOnlyCollection<Movimiento>> GetAllAsync(Expression<Func<Movimiento, bool>> filter)
        {
            var clientes = await _dbContext.Movimientos.Where(filter).ToListAsync();
            return clientes;
        }

        public async Task<Movimiento> GetAsync(int id)
        {
            var movimiento = await _dbContext.Movimientos.FirstOrDefaultAsync(c => c.Id == id);
            return movimiento;
        }

        public async Task RemoveAsync(int id)
        {
            var movimiento = await _dbContext.Movimientos.FirstOrDefaultAsync(c => c.Id == id);
            _dbContext.Remove(movimiento);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Movimiento entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}