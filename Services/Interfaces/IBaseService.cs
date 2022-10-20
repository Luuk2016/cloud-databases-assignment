using LKenselaar.CloudDatabases.Models.Interfaces;

namespace LKenselaar.CloudDatabases.Services.Interfaces
{
    public interface IBaseService<T> where T : class, IEntity
    {
        public Task<T> GetById(Guid id);

        public Task<ICollection<T>> GetAll();

        public Task<T> Create(T entity);

        public Task<T> Update(T entity);
    }
}
