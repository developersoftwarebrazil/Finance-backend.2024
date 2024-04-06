using Finance.Domain.Entity.Entities.Incomes;
using Finance.Domain.Interfaces.Repositories.Incomes;
using Finance.Domain.Interfaces.Services.Incomes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class IncomeController : ControllerBase
    {
        private readonly IRepositoryIncome repositoryIncome;
        private readonly IServiceIncome serviceIncome;

        public IncomeController(
                IRepositoryIncome repositoryIncome,
                IServiceIncome serviceIncome
            )
        {
            this.repositoryIncome = repositoryIncome;
            this.serviceIncome = serviceIncome;
        }

        [Produces("application/json")]
        [HttpPost("/api/AddIncome")]
        public async Task<object> AddExpense(Income income)
        {
            await serviceIncome.AddIncome(income);
            return income;
        }

        [Produces("application/json")]
        [HttpPut("/api/UpdateIncome")]
        public async Task<object> UpdateIncome(Income income)
        {
            await serviceIncome.UpdateIncome(income);
            return income;
        }

        [Produces("application/json")]
        [HttpDelete("/api/DeleteIncome")]
        public async Task<object> DeleteIncome(int id)
        {
            try
            {
                var deleteIncome = await repositoryIncome.GetEntityById(id);
                await repositoryIncome.Delete(deleteIncome);

            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        [Produces("application/json")]
        [HttpGet("/api/IncomeUserList")]
        public async Task<object> IncomeUserList(string userEmail)
        {
            return await repositoryIncome.IncomeUserList(userEmail);
        }

        [Produces("application/json")]
        [HttpGet("/api/GetIncome")]
        public async Task<object> GetIncome(int id)
        {
            return await repositoryIncome.GetEntityById(id);
        }

        //[Produces("application/json")]
        //[HttpGet("/api/LoadGraph")]
        //public async Task<object> LoadGraph(string userEmail)
        //{
        //    return await serviceIncome.LoadGraph(userEmail);
        //}

    }
}
