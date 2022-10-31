using LKenselaar.CloudDatabases.Models.Interfaces;

namespace LKenselaar.CloudDatabases.DAL.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : class, IEntity
    {
        public Task<T> GetById(Guid id);
        public Task<ICollection<T>> GetAll();
        public Task<T> Create(T entity);
        public Task Commit();
    }
}
