using Finance.Domain.Interfaces.Repositories;
using Finance.Domain.Interfaces.Services;

namespace Finance.Domain.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> repository;
        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            this.repository = repository;
        }
        public async Task Add(TEntity obj)
        {
            await repository.Add(obj);
        }

        public async Task Update(TEntity obj)
        {
            await repository.Update(obj);
        }
        public async Task Delete(TEntity obj)
        {
            await repository.Delete(obj);
        }

        public async Task<TEntity> GetEntityById(int Id)
        {
            return await repository.GetEntityById(Id);
        }

        public async Task<List<TEntity>> List()
        {
            return await repository.List();
        }

    }
}
