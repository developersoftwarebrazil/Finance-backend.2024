using Finance.Domain.Entity.Entities.Expenses;
using Finance.Domain.Interfaces.Repositories.Expenses;
using Finance.Infra.Data.Date.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Finance.Infra.Data.Repositories.Expenses
{
    public class RepositoryExpense : RepositoryBase<Expense>, IRepositoryExpense
    {
        private readonly DbContextOptions<FinanceDbContext> optionsBuilder;
        public RepositoryExpense()
        {
            this.optionsBuilder = new DbContextOptions<FinanceDbContext>();
        }
        public async Task<IList<Expense>> ExpenseUserList(string userEmail)
        {
            using (var data = new FinanceDbContext(optionsBuilder))
            {
                return await (
                        from s in data.SystemExpenses
                        join c in data.Categories on s.Id equals c.SystemExpenseId
                        join us in data.UserSystems on s.Id equals us.SystemExpenseId
                        join e in data.Expenses on c.Id equals e.CategoryId
                        where us.UserEmail.Equals(userEmail) && s.Month == e.Month && s.Year == e.Year
                        select e
                        ).AsNoTracking().ToListAsync();
            }

        }

        public async Task<IList<Expense>> UnPaidExpensesPreviusMonthUserList(string userEmail)
        {
            using (var data = new FinanceDbContext(optionsBuilder))
            {
                return await (
                    from s in data.SystemExpenses
                    join c in data.Categories on s.Id equals c.SystemExpenseId
                    join us in data.UserSystems on s.Id equals us.SystemExpenseId
                    join e in data.Expenses on c.Id equals e.CategoryId
                    where us.UserEmail.Equals(userEmail) && e.Month < DateTime.Now.Month && !e.PayedOut
                    select e
                    ).AsNoTracking().ToListAsync();
            }
        }
    }
}
