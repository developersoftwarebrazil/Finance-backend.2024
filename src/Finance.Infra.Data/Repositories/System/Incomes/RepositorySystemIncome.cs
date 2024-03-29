﻿using Finance.Domain.Entity.Entities.Systems.Incomes;
using Finance.Domain.Interfaces.Repositories.Systems.Incomes;
using Finance.Infra.Data.Date.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Finance.Infra.Data.Repositories.System.SystemIncomes
{
    public class RepositorySystemIncome : RepositoryBase<SystemIncome>, IRepositorySystemIncome
    {
        private readonly DbContextOptions<FinanceDbContext> optionsBuilder;
        public RepositorySystemIncome()
        {
            this.optionsBuilder = new DbContextOptions<FinanceDbContext>();
        }

        public async Task<IList<SystemIncome>> SystemUserIncomeList(string userEmail)
        {
            using (var data = new FinanceDbContext(optionsBuilder))
            {
                return await (
                            from s in data.SystemIncomes
                            join us in data.UserSystemIncomes on s.Id equals us.SystemIncomeId
                            where us.UserEmail.Equals(userEmail)
                            select s
                    ).AsNoTracking().ToListAsync();
            }
        }
    }
}
