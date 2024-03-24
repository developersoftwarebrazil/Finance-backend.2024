using Finance.Domain.Entity.Entities.Categories.Expenses;

namespace Finance.Domain.Interfaces.Services.Categories.Expenses
{
    public interface IServiceCategoryExpense : IServiceBase<CategoryExpense>
    {
        Task AddCategoryExpense(CategoryExpense categoryExpense);
        Task UpdateCategoryExpense(CategoryExpense categoryExpense);
    }
}
