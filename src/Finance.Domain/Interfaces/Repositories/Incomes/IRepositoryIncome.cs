using Finance.Domain.Entity.Entities.Incomes;

namespace Finance.Domain.Interfaces.Repositories.Incomes
{
    public interface  IRepositoryIncome : IRepositoryBase<Income>
    {
        Task<IList<Income>> IncomeUserList(string userEmail);
    }
}