using Finance.Domain.Entity.Entities.Categories;
using Finance.Domain.Interfaces.Repositories.Categories;
using Finance.Infra.Data.Date.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Finance.Infra.Data.Repositories.Categories
{
    public class RepositoryCategory : RepositoryBase<Category>, IRepositoryCategory
    {
        private readonly DbContextOptions<FinanceDbContext> optionsBuilder;
        public RepositoryCategory()
        {
            this.optionsBuilder = new DbContextOptions<FinanceDbContext>();
        }
        public async Task<IList<Category>> CategoryUserExpenseList(string userEmail)
        {
            using (var data = new FinanceDbContext(optionsBuilder))
            {
                return await (
                  from s in data.SystemExpenses
                  join c in data.Categories on s.Id equals c.SystemExpenseId
                  join us in data.UserSystems on s.Id equals us.SystemExpenseId
                  where us.UserEmail.Equals(userEmail) && us.ActualSystemMonth
                  select c
                ).AsNoTracking().ToListAsync();
            }
        }

        public async Task<IList<Category>> CategoryUserIncomeList(string userEmail)
        {
            using (var data = new FinanceDbContext(optionsBuilder))
            {
                return await (
                    from s in data.SystemIncomes
                    join c in data.Categories on s.Id equals c.SystemIncomeId
                    join us in data.UserSystems on c.Id equals us.SystemIncomeId
                    where us.UserEmail.Equals(userEmail) && us.ActualSystemMonth
                    select c
                    ).AsNoTracking().ToListAsync();
            }
        }
    }
}
