using Finance.Domain.Entity.Entities.Users.Systems;

namespace Finance.Domain.Interfaces.Repositories.Users.Systems
{
    public interface IRepositoryUserSystem : IRepositoryBase<UserSystem>
    {
        Task<IList<UserSystem>> UserSystemExpenseList(int systemId);
        Task<IList<UserSystem>> UserSystemIncomeList(int systemId);
        Task<UserSystem> GetUserByEmail(string userEmail);
        Task UserRemove(List<UserSystem> users);
    }
}
