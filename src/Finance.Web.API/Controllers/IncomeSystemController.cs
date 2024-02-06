using Finance.Domain.Entity.Entities.Systems.SystemIncomes;
using Finance.Domain.Interfaces.Repositories.Systems.SystemIncomes;
using Finance.Domain.Interfaces.Services.Systems.SystemIncomes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class IncomeSystemController : ControllerBase
    {
        private readonly IRepositorySystemIncome repositorySystemIncome;
        private readonly IServiceSystemIncome serviceSystemIncome;
        public IncomeSystemController(
            IRepositorySystemIncome repositorySystemIncome,
            IServiceSystemIncome serviceSystemIncome
            )
        {
            this.repositorySystemIncome = repositorySystemIncome;
            this.serviceSystemIncome = serviceSystemIncome;
        }


        [Produces("application/json")]
        [HttpPost("/api/AddSystemIncome")]
        public async Task<object> AddSystemIncome(SystemIncome systemIncome)
        {
            await serviceSystemIncome.AddSystemIncome(systemIncome);
            return systemIncome;
        }

        [Produces("application/json")]
        [HttpPut("/api/UpdateSystemIncome")]
        public async Task<object> UpdateSystemIncome(SystemIncome systemIncome)
        {
            await serviceSystemIncome.UpdateSystemIncome(systemIncome);
            return Task.FromResult(systemIncome);
        }

        [Produces("application/json")]
        [HttpDelete("/api/DeleteSystemIncome")]
        public async Task<object> DeleteSystemIncome(int id)
        {
            try
            {
                var systemIncome = await repositorySystemIncome.GetEntityById(id);

                await repositorySystemIncome.Delete(systemIncome);

            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        [Produces("application/json")]
        [HttpGet("/api/SystemUserIncomeList")]
        public async Task<object> SystemUserIncomeList(string emailUser)
        {
            return await repositorySystemIncome.SystemUserIncomeList(emailUser);
        }

        [Produces("application/json")]
        [HttpGet("/api/GetIncomeSystem")]
        public async Task<object> GetSystemIncome(int id)
        {
            return await repositorySystemIncome.GetEntityById(id);
        }
    }
}
