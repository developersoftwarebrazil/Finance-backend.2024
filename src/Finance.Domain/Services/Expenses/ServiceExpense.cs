using Finance.Domain.Entity.Entities.Expenses;
using Finance.Domain.Entity.Enums.Systems;
using Finance.Domain.Interfaces.Repositories.Expenses;
using Finance.Domain.Interfaces.Services.Expenses;

namespace Finance.Domain.Services.Expenses
{
    public class ServiceExpense : ServiceBase<Expense>, IServiceExpense
    {
        private readonly IRepositoryExpense repositoryExpense;
        public ServiceExpense(IRepositoryExpense repositoryExpense)
        : base(repositoryExpense)
        {
            this.repositoryExpense = repositoryExpense;
        }
        public async Task AddExpense(Expense expense)
        {
            var date = DateTime.Now;

            expense.RegistrationDate = date;
            expense.Month = date.Month;
            expense.Year = date.Year;

            var isValidate = expense.PropertyStringValidations(expense.Name, "Name");
            if (isValidate)
            {
                await repositoryExpense.Add(expense);
            }
        }

        public async Task UpdateExpense(Expense expense)
        {
            var date = DateTime.Now;

            expense.RegistrationChangeDate = date;

            if (expense.PayedOut)
            {
                expense.PaymentDate = date;
            }

            var isValidate = expense.PropertyStringValidations(expense.Name, "Name");
            if (isValidate)
            {
                await repositoryExpense.Update(expense);
            }
        }
        public async Task<object> LoadGraph(string userEmail)
        {
            var userExpense = await repositoryExpense.ExpenseUserList(userEmail);
            var previuusExpense = await repositoryExpense.UnPaidExpensesPreviusMonthUserList(userEmail);

            var unPaiedExpenses_previousMonth = previuusExpense.Any() ? previuusExpense.ToList().Sum(ex => ex.Value) : 0;
            var payiedExpense = userExpense.Where(pe => pe.PayedOut && pe.TransactionTypes == TransactionTypeEnum.expense).Sum(pe => pe.Value);
            var pendingExpense = userExpense.Where(pne => !pne.PayedOut && pne.TransactionTypes == TransactionTypeEnum.expense).Sum(pne => pne.Value);
            //var income = userExpense.Where(i => i.TransactionTypes == TransactionTypeEnum.income).Sum(i => i.Value);

            return new
            {
                success = "OK",
                payiedExpense = payiedExpense,
                pendingExpense = pendingExpense,
                previusExpense = previuusExpense,
                
            };
        }
    }
}
