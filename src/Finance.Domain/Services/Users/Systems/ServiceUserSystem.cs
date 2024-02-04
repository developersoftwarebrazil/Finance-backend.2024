using Finance.Domain.Entity.Entities.Users.Systems;
using Finance.Domain.Interfaces.Repositories.Users.Systems;
using Finance.Domain.Interfaces.Services.Users.Systems;

namespace Finance.Domain.Services.Users.Systems
{
    public class ServiceUserSystem : ServiceBase<UserSystem>, IServiceUserSystem
    {
        private readonly IRepositoryUserSystem repositoryUserSystem;
        public ServiceUserSystem(IRepositoryUserSystem repositoryUserSystem)
        : base(repositoryUserSystem)
        {
            this.repositoryUserSystem = repositoryUserSystem;
        }

        public async Task RegisterUserOnSystemExpense(UserSystem userSystem)
        {
            await repositoryUserSystem.Add(userSystem);
        }

        public async Task RegisterUserOnSystemIncome(UserSystem userSystem)
        {
            await repositoryUserSystem.Add(userSystem);
        }

    }
}
