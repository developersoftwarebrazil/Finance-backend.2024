namespace Finance.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task Add(TEntity obj);
        Task Update(TEntity obj);
        Task Delete(TEntity obj);
        Task<TEntity> GetEntityById(int Id);
        Task<List<TEntity>> List();
    }
}
