using Finance.Domain.Entity.Entities.Categories;
using Finance.Domain.Interfaces.Repositories.Categories;
using Finance.Domain.Interfaces.Services.Categories;

namespace Finance.Domain.Services.Categories
{
    public class ServiceCategory : ServiceBase<Category>, IServiceCategory
    {
        private readonly IRepositoryCategory repositoryCategory;

        public ServiceCategory(IRepositoryCategory repositoryCategory)
            : base(repositoryCategory)
        {
            this.repositoryCategory = repositoryCategory;
        }
        public async Task AddCategory(Category category)
        {
            var isValidate = category.PropertyStringValidations(category.Name, "Name");
            if (isValidate)
            {
                await repositoryCategory.Add(category);
            }
        }

        public async Task UpdateCategory(Category category)
        {
            var isValidate = category.PropertyStringValidations(category.Name, "Name");
            if (isValidate)
            {
                await repositoryCategory.Update(category);
            }
        }
    }
}
