using Finance.Domain.Entity.Entities.Users.Systems.Incomes;

namespace Finance.Domain.Interfaces.Repositories.Users.Systems.Income
{
    public interface IRepositoryUserSystemIncome : IRepositoryBase<UserSystemIncome>
    {
        Task<IList<UserSystemIncome>> UserSystemIncomeList(int userIncomeId);
        Task<UserSystemIncome> GetUserByEmail(string userEmail);
        Task UserRemove(List<UserSystemIncome> users);
    }
}
