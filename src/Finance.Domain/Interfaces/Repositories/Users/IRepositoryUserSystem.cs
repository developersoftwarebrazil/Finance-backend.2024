using Finance.Domain.Entity.Entities.Users.Systems;

namespace Finance.Domain.Interfaces.Repositories.Users
{
    public interface IRepositoryUserSystem : IRepositoryBase<UserSystem>
    {
        Task<IList<UserSystem>> UserSystemList(int systemId);
        Task UserRemove(List<UserSystem> users);
        Task<UserSystem> GetUserByEmail(string userEmail);
    }
}
