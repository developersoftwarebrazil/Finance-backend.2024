using Finance.Domain.Entity.Entities.Incomes;
using Finance.Domain.Entity.Enums.Systems;
using Finance.Domain.Interfaces.Repositories.Incomes;
using Finance.Domain.Interfaces.Services.Incomes;

namespace Finance.Domain.Services.Incomes
{
    public class ServiceIncome : ServiceBase<Income>, IServiceIncome
    {
        private readonly IRepositoryIncome repositoryIncome;
        public ServiceIncome(IRepositoryIncome repositoryIncome)
            : base(repositoryIncome)
        {
            this.repositoryIncome = repositoryIncome;
        }

        public async Task AddIncome(Income income)
        {
            var date = DateTime.Now;

            income.RegistrationDate = date;
            income.Month = date.Month;
            income.Year = date.Year;

            var isValidate = income.PropertyStringValidations(income.Name, "Name");
            if (isValidate)
            {
                await repositoryIncome.Add(income);
            }
        }
        public async Task UpdateIncome(Income income)
        {
            var date = DateTime.Now;
            income.RegistrationChangeDate = date;

            var isValidate = income.PropertyStringValidations(income.Name, "Name");
            if (isValidate)
            {
                await repositoryIncome.Update(income);
            }
        }
        public async Task<object> LoadGraph(string userEmail)
        {
            var userIncome = await repositoryIncome.IncomeUserList(userEmail);

            var income = userIncome.Where(i => i.TransactionTypes == TransactionTypeEnum.income).Sum(i => i.Value);

            return new
            {
                success = "OK",
                income = income,
            };
        }
    }
}
