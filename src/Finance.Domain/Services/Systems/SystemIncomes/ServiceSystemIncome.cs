using Finance.Domain.Entity.Entities.Systems.SystemIncomes;
using Finance.Domain.Interfaces.Repositories.Systems.SystemIncomes;
using Finance.Domain.Interfaces.Services.Systems.SystemIncomes;

namespace Finance.Domain.Services.Systems.SystemIncomes
{
    public class ServiceSystemIncome : ServiceBase<SystemIncome>, IServiceSystemIncome
    {
        private readonly IRepositorySystemIncome repositorySystemIncome;

        public ServiceSystemIncome(IRepositorySystemIncome repositorySystemIncome)
        : base(repositorySystemIncome)
        {
            this.repositorySystemIncome = repositorySystemIncome;
        }
        public async Task AddSystemIncome(SystemIncome systemIncome)
        {
            var date = DateTime.UtcNow;

            systemIncome.DayMonthlyBookClose = 1;
            systemIncome.Month = date.Month;
            systemIncome.Year = date.Year;

            var isValidate = systemIncome.PropertyStringValidations(systemIncome.Name, "Name");
            if (isValidate)
            {
                await repositorySystemIncome.Add(systemIncome);

            }

        }

        public async Task UpdateSystemIncome(SystemIncome systemIncome)
        {
            var isValidate = systemIncome.PropertyStringValidations(systemIncome.Name, "Name")
            if (isValidate)
            {
                systemIncome.DayMonthlyBookClose -= 1;
                await repositorySystemIncome.Update(systemIncome);
            }

        }
    }
}
