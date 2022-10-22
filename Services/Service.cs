using LKenselaar.CloudDatabases.DAL.Repositories.Interfaces;
using LKenselaar.CloudDatabases.Models.Interfaces;
using LKenselaar.CloudDatabases.Services.Interfaces;

namespace LKenselaar.CloudDatabases.Services
{
    public abstract class Service<T> : IBaseService<T> where T : class, IEntity
    {
        protected readonly IBaseRepository<T> _repository;

        protected Service(IBaseRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual async Task<T> GetById(Guid id) => await _repository.GetById(id);

        public virtual async Task<ICollection<T>> GetAll() => await _repository.GetAll();

        public virtual async Task<T> Create(T entity) => await _repository.Create(entity);
    }
}
