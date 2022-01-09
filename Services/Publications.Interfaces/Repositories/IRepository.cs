
using Publications.Interfaces.Entities;

namespace Publications.Interfaces.Repositories;

public interface IRepository<T> where T : class, IEntity
{
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancel = default);

    async Task<T?> GetAsync(int id, CancellationToken cancel = default)
    {
        var all = await GetAllAsync(cancel).ConfigureAwait(false);
        return all.FirstOrDefault(item => item.Id == id);
    }

    Task<int> AddAsync(T entity, CancellationToken cancel = default);

    Task<bool> UpdateAsync(T entity, CancellationToken cancel = default);

    Task<bool> DeleteAsync(T entity, CancellationToken cancel = default);
}
