using Finance.Domain.Entity.Entities.Categories.Incomes;
using Finance.Domain.Interfaces.Repositories.Categories.Income;
using Finance.Infra.Data.Date.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Finance.Infra.Data.Repositories.Categories.Incomes
{
    public class RepositoryCategoryIncome : RepositoryBase<CategoryIncome>, IRepositoryCategoryIncome
    {
        private readonly DbContextOptions<FinanceDbContext> optionsBuilder;
        public RepositoryCategoryIncome()
        {
            this.optionsBuilder = new DbContextOptions<FinanceDbContext>();
        }


        public async Task<IList<CategoryIncome>> CategoryUserIncomeList(string userEmail)
        {
            using (var data = new FinanceDbContext(optionsBuilder))
            {
                return await (
                    from s in data.SystemIncomes
                    join c in data.CategoryIncomes on s.Id equals c.SystemIncomeId
                    join us in data.UserSystemIncomes on c.Id equals us.SystemIncomeId
                    where us.UserEmail.Equals(userEmail) && us.ActualSystemMonth
                    select c
                    ).AsNoTracking().ToListAsync();
            }
        }
    }
}
