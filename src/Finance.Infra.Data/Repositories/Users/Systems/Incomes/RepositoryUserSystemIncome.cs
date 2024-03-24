using Finance.Domain.Entity.Entities.Users.Systems.Incomes;
using Finance.Domain.Interfaces.Repositories.Users.Systems.Income;
using Finance.Infra.Data.Date.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Finance.Infra.Data.Repositories.Users.Systems.Incomes
{
    public class RepositoryUserSystemIncome : RepositoryBase<UserSystemIncome>, IRepositoryUserSystemIncome
    {
        private readonly DbContextOptions<FinanceDbContext> optionsBuilder;
        public RepositoryUserSystemIncome()
        {
            optionsBuilder = new DbContextOptions<FinanceDbContext>();
        }

        public async Task<UserSystemIncome> GetUserByEmail(string userEmail)
        {
            using (var data = new FinanceDbContext(optionsBuilder))
            {
                return await
                          data.UserSystemIncomes.AsNoTracking().FirstOrDefaultAsync(
                              us => us.UserEmail.Equals(userEmail));

            }
        }

        public async Task<IList<UserSystemIncome>> UserSystemIncomeList(int systemIncomeId)
        {
            using (var data = new FinanceDbContext(optionsBuilder))
            {
                return await data.UserSystemIncomes.Where(s => s.SystemIncomeId == systemIncomeId).AsNoTracking().ToListAsync();
            }
        }

        public async Task UserRemove(List<UserSystemIncome> users)
        {
            using (var data = new FinanceDbContext(optionsBuilder))
            {
                data.UserSystemIncomes.RemoveRange(users);

                await data.SaveChangesAsync();
            }
        }
    }
}
