using Finance.Domain.Entity.Entities.Categories.Incomes;

namespace Finance.Domain.Interfaces.Services.Categories.Incomes
{
    public interface IServiceCategoryIncome : IServiceBase<CategoryIncome>
    {
        Task AddCategoryIncome(CategoryIncome categoryIncome);
        Task UpdateCategoryIncome(CategoryIncome categoryCategoryIncome);
    }

}
