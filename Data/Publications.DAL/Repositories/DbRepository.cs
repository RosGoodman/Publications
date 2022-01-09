

using Microsoft.EntityFrameworkCore;
using Publications.DAL.Context;
using Publications.Interfaces.Entities;
using Publications.Interfaces.Repositories;

namespace Publications.DAL.Repositories;

public class DbRepository<T> : IRepository<T> where T : class, IEntity
{
    private readonly PublicationsDB _db;

    protected DbSet<T> Set { get; }

    /// <summary>  </summary>
    /// <param name="db"> Контекст базы данных. </param>
    public DbRepository(PublicationsDB db)
    {
        _db = db;
        Set = _db.Set<T>();
    }

    public async Task<int> AddAsync(T entity, CancellationToken cancel = default)
    {
        await Set.AddAsync(entity, cancel);
        await _db.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<T?> GetAsync(int id, CancellationToken cancel = default)
    {
        return await Set.FindAsync(id);
    }

    public async Task<bool> DeleteAsync(T entity, CancellationToken cancel = default)
    {
        var item = await GetAsync(entity.Id, cancel).ConfigureAwait(false);
        if(item is null) return false;

        _db.Entry(item).State = EntityState.Deleted;
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancel = default)
    {
        return await Set.ToArrayAsync(cancel).ConfigureAwait(false);
    }

    public async Task<bool> UpdateAsync(T entity, CancellationToken cancel = default)
    {
        _db.Entry(entity).State = EntityState.Modified;
        await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
        return true;
    }
}
