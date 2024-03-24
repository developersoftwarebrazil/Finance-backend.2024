using Finance.Domain.Entity.Entities.Categories.Expenses;
using Finance.Domain.Entity.Entities.Categories.Incomes;
using Finance.Domain.Interfaces.Repositories.Categories.Expenses;
using Finance.Domain.Interfaces.Repositories.Categories.Income;
using Finance.Domain.Interfaces.Services.Categories.Expenses;
using Finance.Domain.Interfaces.Services.Categories.Incomes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryIncomeController : ControllerBase
    {
        private readonly IRepositoryCategoryIncome repositoryCategoryIncome;
        private readonly IServiceCategoryIncome serviceCategoryIncome;

        public CategoryIncomeController(
            IRepositoryCategoryIncome repositoryCategoryIncome,
            IServiceCategoryIncome serviceCategoryIncome
            )
        {
            this.repositoryCategoryIncome = repositoryCategoryIncome;
            this.serviceCategoryIncome = serviceCategoryIncome;
        }
        
        //Investiemntos

        [Produces("application/json")]
        [HttpPost("/api/AddCategoryIncome")]
        public async Task<object> AddCategoryIncome(CategoryIncome categoryIncome)
        {
            await serviceCategoryIncome.AddCategoryIncome(categoryIncome);
            return categoryIncome;
        }

        [Produces("application/json")]
        [HttpPut("/api/UpdateCategoryIncome")]
        public async Task<object> UpdateCategoryIncome(CategoryIncome categoryIncome)
        {
            await serviceCategoryIncome.UpdateCategoryIncome(categoryIncome);
            return categoryIncome;
        }

        [Produces("application/json")]
        [HttpDelete("/api/DeleteCategoryIncome")]
        public async Task<object> DeleteCategoryIncome(int id)
        {
            try
            {
                var categoryIncome = await repositoryCategoryIncome.GetEntityById(id);
                await repositoryCategoryIncome.Delete(categoryIncome);

            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        [Produces("application/json")]
        [HttpGet("/api/CategoryUserIncomeList")]
        public async Task<object> CategoryUserIncomeList(string userEmail)
        {
            return await repositoryCategoryIncome.CategoryUserIncomeList(userEmail);
        }

        [Produces("application/json")]
        [HttpGet("/api/GetCategoryIncome")]
        public async Task<object> GetCategoryIncome(int id)
        {
            return await repositoryCategoryIncome.GetEntityById(id);
        }
    }
}
