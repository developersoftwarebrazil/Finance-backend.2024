using Finance.Domain.Entity.Entities.Systems.SystemExpenses;
using Finance.Domain.Interfaces.Repositories.Systems.SystemExpenses;
using Finance.Domain.Interfaces.Services.Systems.SystemExpenses;

namespace Finance.Domain.Services.Systems.SystemExpenses
{
    public class ServiceSystemExpense : ServiceBase<SystemExpense>, IServiceSystemExpense
    {
        private readonly IRepositorySystemExpense repositorySystemExpense;
        public ServiceSystemExpense(IRepositorySystemExpense repositorySystemExpense)
        : base(repositorySystemExpense)
        {
            this.repositorySystemExpense = repositorySystemExpense;
        }

        public async Task AddSystemExpense(SystemExpense systemExpense)
        {
            var isValidate = systemExpense.PropertyStringValidations(systemExpense.Name, "Name");
            if (isValidate)
            {
                var date = DateTime.UtcNow;

                systemExpense.DayMonthlyBookClose = 1;
                systemExpense.Month = date.Month;
                systemExpense.Year = date.Year;
                systemExpense.MonthCopy = date.Month;
                systemExpense.YearCopy = date.Year;
                systemExpense.GenerateExpensesCopy = true;

                await repositorySystemExpense.Add(systemExpense);
            }
        }

        public async Task UpdateSystemExpense(SystemExpense systemExpense)
        {
            var isValidate = systemExpense.PropertyStringValidations(systemExpense.Name, "Name");
            if (isValidate)
            {
                systemExpense.DayMonthlyBookClose = 1;

                await repositorySystemExpense.Update(systemExpense);
            }
        }
    }
}
