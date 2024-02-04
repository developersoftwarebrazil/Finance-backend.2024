using Finance.Domain.Entity.Entities.Systems.SystemExpenses;
using Finance.Domain.Interfaces.Repositories.Systems.SystemExpenses;
using Finance.Infra.Data.Date.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Finance.Infra.Data.Repositories.System.SystemExpenses
{
    public class RepositorySystemExpense : RepositoryBase<SystemExpense>, IRepositorySystemExpense
    {
        private readonly DbContextOptions<FinanceDbContext> optionosBuilder;
        public RepositorySystemExpense()
        {
            this.optionosBuilder = new DbContextOptions<FinanceDbContext>();
        }

        public async Task<bool> GenerateSystemExpenseCopy()
        {
            var expenseSystemList = new List<SystemExpense>();
            try
            {
                using (var data = new FinanceDbContext(optionosBuilder))
                {
                    expenseSystemList = await data.SystemExpenses.Where(s => s.GenerateExpensesCopy).ToListAsync();

                    foreach (var expense in expenseSystemList)
                    {
                        var actualDate = DateTime.UtcNow;

                        var month = actualDate.Month;
                        var year = actualDate.Year;

                        var existingExpense = await (
                                                     from e in data.Expenses
                                                     join c in data.Categories on e.CategoryId equals c.Id
                                                     where c.SystemExpenseId == expense.Id && e.Month == month && e.Year == year
                                                     select e.Id
                                                     ).AnyAsync();


                        if (!existingExpense)
                        {
                            var systemExpenses = await (
                                                        from e in data.Expenses
                                                        join c in data.Categories on e.CategoryId equals c.Id
                                                        where c.SystemExpenseId == expense.Id && e.Month == expense.Month && e.Year == expense.YearCopy
                                                        select e
                                                       ).ToListAsync();
                            systemExpenses.ForEach(e =>
                            {
                                e.Id = 0;
                                e.Month = month;
                                e.Year = year;
                                e.RegistrationDate = actualDate;
                                e.DueDate = new DateTime(year, month, e.DueDate.Day);
                                e.RegistrationChangeDate = DateTime.MinValue;
                                e.PayedOut = false;
                            });

                            if (systemExpenses.Any())
                            {
                                data.Expenses.AddRange(systemExpenses);
                                await data.SaveChangesAsync();
                            }
                        }
                    }

                }
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        public async Task<IList<SystemExpense>> SystemExpenseUserList(string userEmail)
        {
            using (var data = new FinanceDbContext(optionosBuilder))
            {
                return await (
                            from s in data.SystemExpenses
                            join us in data.UserSystems on s.Id equals us.SystemExpenseId
                            where us.UserEmail.Equals(userEmail)
                            select s
                    ).AsNoTracking().ToListAsync();
            }
        }
    }
}
