using Finance.Domain.Entity.Entities.Users.Systems.Expenses;

namespace Finance.Domain.Interfaces.Repositories.Users.Systems.Expenses
{
    public interface IRepositoryUserSystemExpense : IRepositoryBase<UserSystemExpense>
    {
        Task<IList<UserSystemExpense>> UserSystemExpenseList(int systemExpenseId);
        Task<UserSystemExpense> GetUserByEmail(string userEmail);
        Task UserRemove(List<UserSystemExpense> users);
    }
}
