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
