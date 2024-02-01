using Finance.Domain.Entity.Entities.Systems.SystemExpenses;

namespace Finance.Domain.Interfaces.Repositories.Systems.SystemExpenses
{
    public interface IRepositorySystemExpense : IRepositoryBase<SystemExpense>
    {
        Task<IList<SystemExpense>> SystemExpenseUserList(string userEmail);
    }
}
