using Finance.Domain.Entity.Entities.Systems.Expenses;

namespace Finance.Domain.Interfaces.Repositories.Systems.Expenses
{
    public interface IRepositorySystemExpense : IRepositoryBase<SystemExpense>
    {
        Task<IList<SystemExpense>> SystemExpenseUserList(string userEmail);
        Task<bool> GenerateSystemExpenseCopy();
    }
}
