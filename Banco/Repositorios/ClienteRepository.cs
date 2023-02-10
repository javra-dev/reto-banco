using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Usuario.Models;

namespace Usuario.Repositorios
{
    public class ClienteRepository : IRepositorio<Cliente>
    {
        private readonly UsuarioDbContext _dbContext;
        public ClienteRepository(UsuarioDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(Cliente entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyCollection<Cliente>> GetAllAsync()
        {
            var clientes = await _dbContext.Clientes.ToListAsync();
            return clientes;
        }
        public async Task<IReadOnlyCollection<Cuenta>> GetAllAsync(int id, DateTime ini, DateTime fin)
        {
            var clientes = await _dbContext.Cuentas
                .Include(m => m.Movimientos.Select(f => f.Fecha > ini && f.Fecha < fin))
                .Where(x => x.ClienteId == id)
                .ToListAsync();
            return clientes;
        }


        public async Task<IReadOnlyCollection<Cliente>> GetAllAsync(Expression<Func<Cliente, bool>> filter)
        {
            var clientes = await _dbContext.Clientes.Where(filter).ToListAsync();
            return clientes;
        }

        public async Task<Cliente> GetAsync(int id)
        {
            var cliente = await _dbContext.Clientes.FirstOrDefaultAsync(c => c.Id == id);
            return cliente;
        }

        public async Task RemoveAsync(int id)
        {
            var cliente = await _dbContext.Clientes.FirstOrDefaultAsync(c => c.Id == id);
            _dbContext.Remove(cliente);
            await _dbContext.SaveChangesAsync();  
        }

        public async Task UpdateAsync(Cliente entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}