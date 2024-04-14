using Finance.Domain.Entity.Entities.Expenses;

namespace Finance.Domain.Interfaces.Services.Expenses
{
    public interface IServiceExpense : IServiceBase<Expense>
    {
        Task AddExpense(Expense expense);
        Task UpdateExpense(Expense expense);
        Task<object> LoadExpenseGraph(string userEmail);
    }
}
