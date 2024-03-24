using Finance.Domain.Entity.Entities.Incomes;
using Finance.Domain.Interfaces.Repositories.Incomes;
using Finance.Infra.Data.Date.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Finance.Infra.Data.Repositories.Incomes
{
    public class RepositoryIncome : RepositoryBase<Income>, IRepositoryIncome
    {
        private readonly DbContextOptions<FinanceDbContext> optionsBuilder;
        public RepositoryIncome()
        {
            optionsBuilder = new DbContextOptions<FinanceDbContext>();
        }

        public async Task<IList<Income>> IncomeUserList(string userEmail)
        {
            using (var data = new FinanceDbContext(optionsBuilder))
            {
                return await (
                        from s in data.SystemIncomes
                        join c in data.CategoryIncomes on s.Id equals c.SystemIncomeId
                        join us in data.UserSystemIncomes on s.Id equals us.SystemIncomeId
                        join i in data.Incomes on c.Id equals i.CategoryIncomeId
                        where us.UserEmail.Equals(userEmail) && s.Month == i.Month && s.Year == i.Year
                        select i
                    ).AsNoTracking().ToListAsync();

            }
        }
    }
}
