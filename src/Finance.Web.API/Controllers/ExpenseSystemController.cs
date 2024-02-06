using Finance.Domain.Entity.Entities.Systems.SystemExpenses;
using Finance.Domain.Interfaces.Repositories.Systems.SystemExpenses;
using Finance.Domain.Interfaces.Services.Systems.SystemExpenses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ExpenseSystemController : ControllerBase
    {
        private readonly IRepositorySystemExpense repositorySystemExpense;
        private readonly IServiceSystemExpense serviceSystemExpense;
        public ExpenseSystemController(
            IRepositorySystemExpense repositorySystemExpense,
            IServiceSystemExpense serviceSystemExpense
            )
        {
            this.repositorySystemExpense = repositorySystemExpense;
            this.serviceSystemExpense = serviceSystemExpense;
        }


        [Produces("application/json")]
        [HttpPost("/api/AddSystemExpense")]
        public async Task<object> AddSysteExpense(SystemExpense systemExpense)
        {
            await serviceSystemExpense.AddSystemExpense(systemExpense);
            return systemExpense;
        }

        [Produces("application/json")]
        [HttpPut("/api/UpdateSystemExpense")]
        public async Task<object> UpdateSystemExpense(SystemExpense systemExpense)
        {
            await serviceSystemExpense.UpdateSystemExpense(systemExpense);
            return Task.FromResult(systemExpense);
        }

        [Produces("application/json")]
        [HttpDelete("/api/DeleteSystemExpense")]
        public async Task<object> DeleteSystemExpense(int id)
        {
            try
            {
                var systemExpense = await repositorySystemExpense.GetEntityById(id);

                await repositorySystemExpense.Delete(systemExpense);

            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        [Produces("application/json")]
        [HttpGet("/api/SystemExpenseUserList")]
        public async Task<object> SystemExpenseUserList(string emailUser)
        {
            return await repositorySystemExpense.SystemExpenseUserList(emailUser);
        }

        [Produces("application/json")]
        [HttpGet("/api/GetExpenseSystem")]
        public async Task<object> GetSystemExpense(int id)
        {
            return await repositorySystemExpense.GetEntityById(id);
        }

        [Produces("application/json")]
        [HttpPost("/api/GenerateSystemExpenseCopy")]
        public async Task<object> GenerateSystemExpenseCopy()
        {
            return await repositorySystemExpense.GenerateSystemExpenseCopy();
        }

    }
}
