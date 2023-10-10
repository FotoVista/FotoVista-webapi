using FotoVista.DataAccess.DbContexts;
using FotoVista.DataAccess.IRepository;
using FotoVista.Domain.Entity;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FotoVista.DataAccess.Repository;
#pragma warning disable 

public class Repository<T> : IRepository<T> where T : Auditable
{
    private readonly DbSet<T> table;
    private readonly AppDbContext dbContext;

    public Repository(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
        table = dbContext.Set<T>();
    }

    public async Task<T> AddAsync(T entity)
    {
        await table.AddAsync(entity);
        return entity;
    }

    public async Task<T> UpdateAsync(T entity)
    {
        EntityEntry<T> entry = this.dbContext.Update(entity);
        return entry.Entity;
    }

    public async Task DestroyAsync(Expression<Func<T, bool>> expression)
    {
        var entity = await this.SelectAsync(expression);
        table.Remove(entity);
    }

    public async Task DeleteAsync(Expression<Func<T, bool>> expression)
    {
        var entity = await this.SelectAsync(expression);
        entity.IsDeleted = true;
    }
    public async Task<T> SelectAsync(Expression<Func<T, bool>> expression, string[] includes = null)
        => await this.SelectAll(expression, includes).FirstOrDefaultAsync(t => !t.IsDeleted);

    public IQueryable<T> SelectAll(Expression<Func<T, bool>> expression = null, string[] includes = null, bool isTracking = true)
    {
        var query = expression is null ? isTracking ? table : table.AsNoTracking()
            : isTracking ? table.Where(expression) : table.Where(expression).AsNoTracking();

        query = query.Where(t => !t.IsDeleted);

        if (includes is not null)
            foreach (var include in includes)
                query = query.Include(include);

        return query;
    }

    public async Task SaveAsync()
    {
        await dbContext.SaveChangesAsync();
    }

    public async Task<long> CountAsync(T entity)
    {
        return await dbContext.Set<T>().CountAsync();
    }
}
