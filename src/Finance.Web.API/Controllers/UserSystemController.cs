using Finance.Domain.Entity.Entities.Users.Systems.Expenses;
using Finance.Domain.Entity.Entities.Users.Systems.Incomes;
using Finance.Domain.Interfaces.Repositories.Users.Systems.Expenses;
using Finance.Domain.Interfaces.Repositories.Users.Systems.Income;
using Finance.Domain.Interfaces.Services.Users.Systems.Expense;
using Finance.Domain.Interfaces.Services.Users.Systems.Incomes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserSystemController : ControllerBase
    {
        private readonly IRepositoryUserSystemExpense repositoryUserSystemExpense;
        private readonly IRepositoryUserSystemIncome repositoryUserSystemIncome;
        private readonly IServiceUserSystemExpense serviceUserSystemExpense;
        private readonly IServiceUserSystemIncome serviceUserSystemIncome;
        public UserSystemController(
                IRepositoryUserSystemExpense repositoryUserSystemExpense,
                IServiceUserSystemExpense serviceUserSystemExpense,
                IRepositoryUserSystemIncome repositoryUserSystemIncome,
                IServiceUserSystemIncome serviceUserSystemIncome

            )
        {
            this.repositoryUserSystemExpense = repositoryUserSystemExpense;
            this.serviceUserSystemExpense = serviceUserSystemExpense;
            this.repositoryUserSystemIncome = repositoryUserSystemIncome;
            this.serviceUserSystemIncome = serviceUserSystemIncome;
        }

        //Despesas

        [Produces("application/json")]
        [HttpPost("/api/RegisterUserOnSystemExpense")]
        public async Task<object> RegisterUserOnSystemExpense(int userSystemExpenseId, string userEmail)
        {
            try
            {
                await serviceUserSystemExpense.RegisterUserOnSystemExpense(
                    new UserSystemExpense
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
        [HttpDelete("/api/DeleteUserOnSystemExpense")]
        public async Task<object> DeleteUserOnSystemExpense(int id)
        {
            try
            {
                var userSystemExpense = await repositoryUserSystemExpense.GetEntityById(id);
                await repositoryUserSystemExpense.Delete(userSystemExpense);
            }
            catch (Exception)
            {

                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }


        [Produces("application/json")]
        [HttpGet("/api/UserSystemExpenseList")]
        public async Task<object> UserSystemExpenseList(int userSystemExpenseId)
        {
            return await repositoryUserSystemExpense.UserSystemExpenseList(userSystemExpenseId);
        }


        //Investimentos
        [Produces("application/json")]
        [HttpPost("/api/RegisterUserOnSystemIncome")]
        public async Task<object> RegisterUserOnSystemIncome(int userSystemIncomeId, string userEmail)
        {
            try
            {
                await serviceUserSystemIncome.RegisterUserOnSystemIncome(
                    new UserSystemIncome
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
        [HttpDelete("/api/DeleteUserOnSystemIncome")]
        public async Task<object> DeleteUserOnSystemIncome(int id)
        {
            try
            {
                var userSystemIncome = await repositoryUserSystemIncome.GetEntityById(id);
                await repositoryUserSystemIncome.Delete(userSystemIncome);
            }
            catch (Exception)
            {

                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }


        [Produces("application/json")]
        [HttpGet("/api/UserSystemIncomeList")]
        public async Task<object> UserSystemIncomeList(int userIncomeId)
        {
            return await repositoryUserSystemIncome.UserSystemIncomeList(userIncomeId);
        }
    }
}