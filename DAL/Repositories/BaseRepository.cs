using LKenselaar.CloudDatabases.DAL.Context;
using LKenselaar.CloudDatabases.DAL.Repositories.Interfaces;
using LKenselaar.CloudDatabases.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LKenselaar.CloudDatabases.DAL.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class, IEntity
    {
        protected readonly DatabaseContext _databaseContext;

        protected BaseRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public virtual async Task<T> GetById(Guid id)
        {
            return await _databaseContext.Set<T>()
                .SingleOrDefaultAsync(entity => entity.Id == id);
        }

        public virtual async Task<ICollection<T>> GetAll()
        {
            return await _databaseContext.Set<T>().ToListAsync();
        }

        public virtual async Task<T> Create(T entity)
        {
            await _databaseContext.Set<T>().AddAsync(entity);
            await _databaseContext.SaveChangesAsync();

            return await GetById(entity.Id);
        }

        public virtual async Task<T> Update(T entity)
        {
            var entry = _databaseContext.Add(entity);
            entry.State = EntityState.Unchanged;

            _databaseContext.Set<T>().Update(entity);
            await _databaseContext.SaveChangesAsync();

            return await GetById(entity.Id);
        }

        public async Task Commit()
        {
            await _databaseContext.SaveChangesAsync();
        }
    }
}
