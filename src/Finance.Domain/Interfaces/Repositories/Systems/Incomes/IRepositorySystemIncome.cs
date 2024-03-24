using Finance.Domain.Entity.Entities.Systems.Incomes;

namespace Finance.Domain.Interfaces.Repositories.Systems.Incomes
{
    public interface IRepositorySystemIncome : IRepositoryBase<SystemIncome>
    {
        Task<IList<SystemIncome>> SystemUserIncomeList(string userEmail);
    }
}
