using Finance.Domain.Entity.Entities.Categories;
using Finance.Domain.Interfaces.Repositories.Categories;
using Finance.Domain.Interfaces.Services.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly IRepositoryCategory repositoryCategory;
        private readonly IServiceCategory serviceCategory;

        public CategoryController(
            IRepositoryCategory repositoryCategory,
            IServiceCategory serviceCategory
            )
        {
            this.repositoryCategory = repositoryCategory;
            this.serviceCategory = serviceCategory;
        }

        [Produces("application/json")]
        [HttpPost("/api/AddCategory")]
        public async Task<object> AddCategory(Category category)
        {
            await serviceCategory.AddCategory(category);
            return category;
        }

        [Produces("application/json")]
        [HttpPut("/api/UpdateCategory")]
        public async Task<object> UpdateCategory(Category category)
        {
            await serviceCategory.UpdateCategory(category);
            return category;
        }

        [Produces("application/json")]
        [HttpDelete("/api/DeleteCategory")]
        public async Task<object> DeleteCategory(int id)
        {
            try
            {
                var category = await repositoryCategory.GetEntityById(id);
                await repositoryCategory.Delete(category);

            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        [Produces("application/json")]
        [HttpGet("/api/CategoryUserExpenseList")]
        public async Task<object> CategoryUserExpenseList(string userEmail)
        {
            return await repositoryCategory.CategoryUserExpenseList(userEmail);
        }

        [Produces("application/json")]
        [HttpGet("/api/CategoryUserIncomeList")]
        public async Task<object> CategoryUserIncomeList(string userEmail)
        {
            return await repositoryCategory.CategoryUserIncomeList(userEmail);
        }

        [Produces("application/json")]
        [HttpGet("/api/GetCategory")]
        public async Task<object> GetCategory(int id)
        {
            return await repositoryCategory.GetEntityById(id);
        }
    }
}
