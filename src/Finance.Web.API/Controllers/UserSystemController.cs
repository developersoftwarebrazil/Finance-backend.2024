using Finance.Domain.Entity.Entities.Users.Systems;
using Finance.Domain.Interfaces.Repositories.Users.Systems;
using Finance.Domain.Interfaces.Services.Users.Systems;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserSystemController : ControllerBase
    {
        private readonly IRepositoryUserSystem repositoryUserSystem;
        private readonly IServiceUserSystem serviceUserSystem;
        public UserSystemController(
                IRepositoryUserSystem repositoryUserSystem,
                IServiceUserSystem serviceUserSystem
            )
        {
            this.repositoryUserSystem = repositoryUserSystem;
            this.serviceUserSystem = serviceUserSystem;
        }

        [Produces("application/json")]
        [HttpPost("/api/RegisterUserOnSystemExpense")]
        public async Task<object> RegisterUserOnSystemExpense(int userSystemExpenseId, string userEmail)
        {
            try
            {
                await serviceUserSystem.RegisterUserOnSystemExpense(
                    new UserSystem
                    {
                        SystemExpenseId = userSystemExpenseId,
                        UserEmail = userEmail,
                        Administrator = false,
                        ActualSystemMonth = true
                    });
            }
            catch (Exception)
            {

                return Task.FromResult(false);
            }
            return Task.FromResult(0);
        }

        [Produces("application/json")]
        [HttpPost("/api/RegisterUserOnSystemIncome")]
        public async Task<object> RegisterUserOnSystemIncome(int userSystemIncomeId, string userEmail)
        {
            try
            {
                await serviceUserSystem.RegisterUserOnSystemIncome(
                    new UserSystem
                    {
                        SystemIncomeId = userSystemIncomeId,
                        UserEmail = userEmail,
                        Administrator = false,
                        ActualSystemMonth = true
                    });
            }
            catch (Exception)
            {

                return Task.FromResult(false);
            }
            return Task.FromResult(0);
        }

        [Produces("application/json")]
        [HttpDelete("/api/DeleteUserOnSystemExpense")]
        public async Task<object> DeleteUserOnSystemExpense(int id)
        {
            try
            {
                var userExpenseSystem = await repositoryUserSystem.GetEntityById(id);
                await repositoryUserSystem.Delete(userExpenseSystem);
            }
            catch (Exception)
            {

                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }


        [Produces("application/json")]
        [HttpDelete("/api/DeleteUserOnSystemIncome")]
        public async Task<object> DeleteUserOnSystemIncome(int id)
        {
            try
            {
                var userIncomeSystem = await repositoryUserSystem.GetEntityById(id);
                await repositoryUserSystem.Delete(userIncomeSystem);
            }
            catch (Exception)
            {

                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }

        [Produces("application/json")]
        [HttpGet("/api/UserSystemExpenseList")]
        public async Task<object> UserSystemExpenseList(int userExpenseId)
        {
            return await repositoryUserSystem.UserSystemExpenseList(userExpenseId);
        }

        [Produces("application/json")]
        [HttpGet("/api/UserSystemIncomeList")]
        public async Task<object> UserSystemIncomeList(int userIncomeId)
        {
            return await repositoryUserSystem.UserSystemIncomeList(userIncomeId);
        }
    }
}