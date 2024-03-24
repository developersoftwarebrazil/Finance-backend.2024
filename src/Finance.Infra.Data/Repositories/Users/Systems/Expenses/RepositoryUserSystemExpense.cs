using Finance.Domain.Entity.Entities.Users.Systems.Expenses;
using Finance.Domain.Interfaces.Repositories.Users.Systems.Expenses;
using Finance.Infra.Data.Date.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Finance.Infra.Data.Repositories.Users.Systems.Expenses
{
    public class RepositoryUserSystemExpense : RepositoryBase<UserSystemExpense>, IRepositoryUserSystemExpense
    {
        private readonly DbContextOptions<FinanceDbContext> optionsBuilder;
        public RepositoryUserSystemExpense()
        {
            optionsBuilder = new DbContextOptions<FinanceDbContext>();
        }

        public async Task<UserSystemExpense> GetUserByEmail(string userEmail)
        {
            using (var data = new FinanceDbContext(optionsBuilder))
            {
                return await
                          data.UserSystemExpenses.AsNoTracking().FirstOrDefaultAsync(
                              us => us.UserEmail.Equals(userEmail));

            }
        }

        public async Task<IList<UserSystemExpense>> UserSystemExpenseList(int systemExpenseId)
        {
            using (var data = new FinanceDbContext(optionsBuilder))
            {
                return await data.UserSystemExpenses.Where(s => s.SystemExpenseId == systemExpenseId).AsNoTracking().ToListAsync();
            }
        }

        public async Task UserRemove(List<UserSystemExpense> users)
        {
            using (var data = new FinanceDbContext(optionsBuilder))
            {
                data.UserSystemExpenses.RemoveRange(users);

                await data.SaveChangesAsync();
            }
        }
    }
}
