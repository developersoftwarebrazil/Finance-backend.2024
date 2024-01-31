using Finance.Domain.Entity.Entities.Expenses;

namespace Finance.Domain.Interfaces.Repositories.Expenses
{
    public interface IRepositoryExpense : IRepositoryBase<Expense>
    {
        Task<IList<Expense>> ExpenseUserList(string userEmail);
        Task<IList<Expense>> UnPaidExpensesPreviusMonthUserList(string userEmail);
    }
}
