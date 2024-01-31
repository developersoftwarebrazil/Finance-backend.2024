namespace Finance.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task Add(TEntity objects);
        Task Update(TEntity objects);
        Task Delete(TEntity objects);
        Task<TEntity> GetEntityById(int Id);
        Task<List<TEntity>> List();
    }
}
