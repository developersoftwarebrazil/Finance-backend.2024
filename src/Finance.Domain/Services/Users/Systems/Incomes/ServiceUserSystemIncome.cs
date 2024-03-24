using Finance.Domain.Entity.Entities.Users.Systems.Incomes;
using Finance.Domain.Interfaces.Repositories.Users.Systems.Income;
using Finance.Domain.Interfaces.Services.Users.Systems.Incomes;

namespace Finance.Domain.Services.Users.Systems.Incomes
{
    public class ServiceUserSystemIncome : ServiceBase<UserSystemIncome>, IServiceUserSystemIncome
    {
        private readonly IRepositoryUserSystemIncome repositoryUserSystemIncome;
        public ServiceUserSystemIncome(IRepositoryUserSystemIncome repositoryUserSystemIncome)
        : base(repositoryUserSystemIncome)
        {
            this.repositoryUserSystemIncome = repositoryUserSystemIncome;
        }

        public async Task RegisterUserOnSystemIncome(UserSystemIncome userSystemIncome)
        {
            await repositoryUserSystemIncome.Add(userSystemIncome);
        }

    }
}
