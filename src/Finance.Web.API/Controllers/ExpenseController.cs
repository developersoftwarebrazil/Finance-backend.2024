using Finance.Domain.Entity.Entities.Expenses;
using Finance.Domain.Interfaces.Repositories.Expenses;
using Finance.Domain.Interfaces.Services.Expenses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ExpenseController : ControllerBase
    {
        private readonly IRepositoryExpense repositoryExpense;
        private readonly IServiceExpense serviceExpense;
        public ExpenseController(
            IRepositoryExpense repositoryExpense,
            IServiceExpense serviceExpense
            )
        {
            this.repositoryExpense = repositoryExpense;
            this.serviceExpense = serviceExpense;
        }

        [Produces("application/json")]
        [HttpPost("/api/AddExpense")]
        public async Task<object> AddExpense(Expense expense)
        {
            await serviceExpense.AddExpense(expense);
            return expense;
        }

        [Produces("application/json")]
        [HttpPut("/api/UpdateExpense")]
        public async Task<object> UpdateExpense(Expense expense)
        {
            await serviceExpense.UpdateExpense(expense);
            return expense;
        }

        [Produces("application/json")]
        [HttpDelete("/api/DeleteExpense")]
        public async Task<object> DeleteExpense(int id)
        {
            try
            {
                var deleteExpense = await repositoryExpense.GetEntityById(id);
                await repositoryExpense.Delete(deleteExpense);

            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        [Produces("application/json")]
        [HttpGet("/api/ExpenseUserList")]
        public async Task<object> ExpenseUserList(string userEmail)
        {
            return await repositoryExpense.ExpenseUserList(userEmail);
        }

        [Produces("application/json")]
        [HttpGet("/api/GetExpense")]
        public async Task<object> GetExpense(int id)
        {
            return await repositoryExpense.GetEntityById(id);

        }

        [Produces("application/json")]
        [HttpGet("/api/LoadGraph")]
        public async Task<object> LoadGraph(string userEmail)
        {
            return await serviceExpense.LoadGraph(userEmail);
        }

    }
}
