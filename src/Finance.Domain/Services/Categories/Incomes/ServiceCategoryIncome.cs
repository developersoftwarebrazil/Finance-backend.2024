using Finance.Domain.Entity.Entities.Categories.Incomes;
using Finance.Domain.Interfaces.Repositories.Categories.Income;
using Finance.Domain.Interfaces.Services.Categories.Incomes;

namespace Finance.Domain.Services.Categories.Incomes
{
    public class ServiceCategoryIncome : ServiceBase<CategoryIncome>, IServiceCategoryIncome
    {
        private readonly IRepositoryCategoryIncome repositoryCategoryIncome;

        public ServiceCategoryIncome(IRepositoryCategoryIncome repositoryCategoryIncome)
            : base(repositoryCategoryIncome)
        {
            this.repositoryCategoryIncome = repositoryCategoryIncome;
        }
        public async Task AddCategoryIncome(CategoryIncome categoryIncome)
        {
            var isValidate = categoryIncome.PropertyStringValidations(categoryIncome.Name, "Name");
            if (isValidate)
            {
                await repositoryCategoryIncome.Add(categoryIncome);
            }
        }

        public async Task UpdateCategoryIncome(CategoryIncome categoryIncome)
        {
            var isValidate = categoryIncome.PropertyStringValidations(categoryIncome.Name, "Name");
            if (isValidate)
            {
                await repositoryCategoryIncome.Update(categoryIncome);
            }
        }
    }
}

