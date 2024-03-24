using Finance.Domain.Entity.Entities.Categories.Expenses;
using Finance.Domain.Interfaces.Repositories.Categories.Expenses;
using Finance.Infra.Data.Date.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Finance.Infra.Data.Repositories.Categories.Expenses
{
    public class RepositoryCategoryExpense : RepositoryBase<CategoryExpense>, IRepositoryCategoryExpense
    {
        private readonly DbContextOptions<FinanceDbContext> optionsBuilder;
        public RepositoryCategoryExpense()
        {
            optionsBuilder = new DbContextOptions<FinanceDbContext>();
        }
        public async Task<IList<CategoryExpense>> CategoryUserExpenseList(string userEmail)
        {
            using (var data = new FinanceDbContext(optionsBuilder))
            {
                return await (
                  from s in data.SystemExpenses
                  join c in data.CategoryExpenses on s.Id equals c.SystemExpenseId
                  join us in data.UserSystemExpenses on s.Id equals us.SystemExpenseId
                  where us.UserEmail.Equals(userEmail) && us.ActualSystemMonth
                  select c
                ).AsNoTracking().ToListAsync();
            }
        }

    }
}
