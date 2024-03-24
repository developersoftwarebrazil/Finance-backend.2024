using Finance.Domain.Entity.Entities.Users.Systems.Expenses;
using Finance.Domain.Interfaces.Repositories.Users.Systems.Expenses;
using Finance.Domain.Interfaces.Services.Users.Systems.Expense;

namespace Finance.Domain.Services.Users.Systems.Expenses
{
    public class ServiceUserSystemExpense : ServiceBase<UserSystemExpense>, IServiceUserSystemExpense
    {
        private readonly IRepositoryUserSystemExpense repositoryUserSystem;
        public ServiceUserSystemExpense(IRepositoryUserSystemExpense repositoryUserSystem)
        : base(repositoryUserSystem)
        {
            this.repositoryUserSystem = repositoryUserSystem;
        }

        public async Task RegisterUserOnSystemExpense(UserSystemExpense userSystemExpense)
        {
            await repositoryUserSystem.Add(userSystemExpense);
        }


    }
}
