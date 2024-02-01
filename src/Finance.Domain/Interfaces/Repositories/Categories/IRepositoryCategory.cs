using Finance.Domain.Entity.Entities.Categories;

namespace Finance.Domain.Interfaces.Repositories.Categories
{
    public interface IRepositoryCategory : IRepositoryBase<Category>
    {
        Task<IList<Category>> CategoryUserExpenseList(string userEmail);
        Task<IList<Category>> CategoryUserIncomeList(string userEmail);
    }
}
