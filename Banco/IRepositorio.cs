using System.Linq.Expressions;

namespace Usuario
{
    public interface IRepositorio<T> where T : IModelos
    {
        Task CreateAsync(T entity);
        Task<IReadOnlyCollection<T>> GetAllAsync();
        Task<IReadOnlyCollection<T>> GetAllAsync(Expression<Func<T, bool>> filter);
        Task<T> GetAsync(int id);
        Task RemoveAsync(int id);
        Task UpdateAsync(T entity);
    }
}

