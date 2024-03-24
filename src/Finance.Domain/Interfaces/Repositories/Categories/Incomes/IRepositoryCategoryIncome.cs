using Finance.Domain.Entity.Entities.Categories.Incomes;

namespace Finance.Domain.Interfaces.Repositories.Categories.Income
{
    public interface IRepositoryCategoryIncome : IRepositoryBase<CategoryIncome>
    {
        Task<IList<CategoryIncome>> CategoryUserIncomeList(string userEmail);
    }
}
