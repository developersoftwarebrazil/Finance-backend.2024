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
    public class CategoryExpenseController : ControllerBase
    {
        private readonly IRepositoryCategoryExpense repositoryCategoryExpense;
        private readonly IServiceCategoryExpense serviceCategoryExpense;
       

        public CategoryExpenseController(
            IRepositoryCategoryExpense repositoryCategoryExpense,
            IServiceCategoryExpense serviceCategoryExpense
            )
        {
            this.repositoryCategoryExpense = repositoryCategoryExpense;
            this.serviceCategoryExpense = serviceCategoryExpense;       
        }
        //Despesas

        [Produces("application/json")]
        [HttpPost("/api/AddCategoryExpense")]
        public async Task<object> AddCategoryExpense(CategoryExpense categoryExpense)
        {
            await serviceCategoryExpense.AddCategoryExpense(categoryExpense);
            return categoryExpense;
        }

        [Produces("application/json")]
        [HttpPut("/api/UpdateCategoryExpense")]
        public async Task<object> UpdateCategoryExpense(CategoryExpense categoryExpense)
        {
            await serviceCategoryExpense.UpdateCategoryExpense(categoryExpense);
            return categoryExpense;
        }

        [Produces("application/json")]
        [HttpDelete("/api/DeleteCategoryExpense")]
        public async Task<object> DeleteCategoryExpense(int id)
        {
            try
            {
                var categoryExpense = await repositoryCategoryExpense.GetEntityById(id);
                await repositoryCategoryExpense.Delete(categoryExpense);

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
            return await repositoryCategoryExpense.CategoryUserExpenseList(userEmail);
        }


        [Produces("application/json")]
        [HttpGet("/api/GetCategoryExpense")]
        public async Task<object> GetCategoryExpense(int id)
        {
            return await repositoryCategoryExpense.GetEntityById(id);
        }

    }
}
