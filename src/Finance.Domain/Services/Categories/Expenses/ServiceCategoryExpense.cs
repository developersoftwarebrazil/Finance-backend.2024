using Finance.Domain.Entity.Entities.Categories.Expenses;
using Finance.Domain.Interfaces.Repositories.Categories.Expenses;
using Finance.Domain.Interfaces.Services.Categories.Expenses;

namespace Finance.Domain.Services.Categories.Expenses
{
    public class ServiceCategoryExpense : ServiceBase<CategoryExpense>, IServiceCategoryExpense
    {
        private readonly IRepositoryCategoryExpense repositoryCategoryExpense;

        public ServiceCategoryExpense(IRepositoryCategoryExpense repositoryCategoryExpense)
            : base(repositoryCategoryExpense)
        {
            this.repositoryCategoryExpense = repositoryCategoryExpense;
        }
        public async Task AddCategoryExpense(CategoryExpense categoryExpense)
        {
            var isValidate = categoryExpense.PropertyStringValidations(categoryExpense.Name, "Name");
            if (isValidate)
            {
                await repositoryCategoryExpense.Add(categoryExpense);
            }
        }

        public async Task UpdateCategoryExpense(CategoryExpense categoryExpense)
        {
            var isValidate = categoryExpense.PropertyStringValidations(categoryExpense.Name, "Name");
            if (isValidate)
            {
                await repositoryCategoryExpense.Update(categoryExpense);
            }
        }
    }
}
