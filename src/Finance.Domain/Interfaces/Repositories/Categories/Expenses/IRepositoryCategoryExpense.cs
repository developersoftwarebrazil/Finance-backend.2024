using Finance.Domain.Entity.Entities.Categories.Expenses;

namespace Finance.Domain.Interfaces.Repositories.Categories.Expenses
{
    public interface IRepositoryCategoryExpense : IRepositoryBase<CategoryExpense>
    {
        Task<IList<CategoryExpense>> CategoryUserExpenseList(string userEmail);
    }
}
