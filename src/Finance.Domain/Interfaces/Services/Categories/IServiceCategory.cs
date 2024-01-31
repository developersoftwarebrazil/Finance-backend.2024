using Finance.Domain.Entity.Entities.Categories;

namespace Finance.Domain.Interfaces.Services.Categories
{
    public interface IServiceCategory : IServiceBase<Category>
    {
        Task AddCategory(Category category);
        Task UpdateCategory(Category category);
    }
}
