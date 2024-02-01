using Finance.Domain.Entity.Entities.Users.Systems;
using Finance.Domain.Interfaces.Repositories.Users.Systems;
using Finance.Infra.Data.Date.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Finance.Infra.Data.Repositories.Users.Systems
{
    public class RepositoryUserSystem : RepositoryBase<UserSystem>, IRepositoryUserSystem
    {
        private readonly DbContextOptions<FinanceDbContext> optionsBuilder;
        public RepositoryUserSystem()
        {
            optionsBuilder = new DbContextOptions<FinanceDbContext>();
        }

        public async Task<UserSystem> GetUserByEmail(string userEmail)
        {
            using (var data = new FinanceDbContext(optionsBuilder))
            {
                return await
                          data.UserSystems.AsNoTracking().FirstOrDefaultAsync(
                              us => us.UserEmail.Equals(userEmail));

            }
        }

        public async Task<IList<UserSystem>> UserSystemExpenseList(int systemId)
        {
            using (var data = new FinanceDbContext(optionsBuilder))
            {
                return await data.UserSystems.Where(s => s.SystemExpenseId == systemId).AsNoTracking().ToListAsync();
            }
        }

        public async Task<IList<UserSystem>> UserSystemIncomeList(int systemId)
        {
            using (var data = new FinanceDbContext(optionsBuilder))
            {
                return await data.UserSystems.Where(s => s.SystemIncomeId == systemId).AsNoTracking().ToListAsync();
            }
        }
        public async Task UserRemove(List<UserSystem> users)
        {
            using (var data = new FinanceDbContext(optionsBuilder))
            {
                data.UserSystems.RemoveRange(users);

                await data.SaveChangesAsync();
            }
        }
    }
}
